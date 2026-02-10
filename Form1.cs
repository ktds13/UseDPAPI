using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Text;

namespace UseDPAPI
{
    public partial class Form1 : Form
    {
        // Use user input for storage path
        private string StoragePath => Path.Combine(
           GetStoragePath(),
           GetFileName()
        );

        private string GetStoragePath()
        {
            // Get storage path from user input
            string userStoragePath = txtStoragePath.Text.Trim();
            
            // Use default path if empty
            if (string.IsNullOrEmpty(userStoragePath))
            {
                return Path.Combine(
                    "C:/GW/courtlink2/CourtLink2.SmartClient/",
                    "DPAPI_ClientManager"
                );
            }
            
            return userStoragePath;
        }

        private string GetFileName()
        {
            // Get filename from user input
            string userFileName = txtFileName.Text.Trim();
            
            // Validate and sanitize the filename
            if (string.IsNullOrEmpty(userFileName))
            {
                return "DeviceID.dat"; // Default fallback
            }
            
            // Ensure it has .dat extension
            if (!userFileName.EndsWith(".dat", StringComparison.OrdinalIgnoreCase))
            {
                userFileName += ".dat";
            }
            
            // Remove invalid characters
            string invalidChars = new string(Path.GetInvalidFileNameChars());
            foreach (char c in invalidChars)
            {
                userFileName = userFileName.Replace(c, '_');
            }
            
            return userFileName;
        }

        public Form1()
        {
            InitializeComponent();
            
            // Set default values
            txtStoragePath.Text = Path.Combine(
                "C:/GW/courtlink2/CourtLink2.SmartClient/",
                "DPAPI_ClientManager"
            );
            txtFileName.Text = "DeviceID";
            
            // Update storage location display
            UpdateStorageLocation();
        }

        // Update storage location when filename changes
        private void txtFileName_TextChanged(object sender, EventArgs e)
        {
            UpdateStorageLocation();
        }

        // Update storage location when storage path changes
        private void txtStoragePath_TextChanged(object sender, EventArgs e)
        {
            UpdateStorageLocation();
        }

        // Browse for storage directory
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Select storage directory for encrypted files";
                folderDialog.ShowNewFolderButton = true;
                
                // Set initial directory if current path is valid
                string currentPath = txtStoragePath.Text.Trim();
                if (!string.IsNullOrEmpty(currentPath) && Directory.Exists(currentPath))
                {
                    folderDialog.SelectedPath = currentPath;
                }
                
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    txtStoragePath.Text = folderDialog.SelectedPath;
                }
            }
        }

        private void UpdateStorageLocation()
        {
            txtStorageLocation.Text = StoragePath;
        }

        private void LogStatus(string message, bool isError = false)
        {
            string timestamp = DateTime.Now.ToString("HH:mm:ss.fff");
            string prefix = isError ? "ERROR" : "INFO";
            string logEntry = $"[{timestamp}] {prefix}: {message}";

            if (txtStatus.Text.Length > 0)
                txtStatus.AppendText(Environment.NewLine);

            txtStatus.AppendText(logEntry);
            txtStatus.SelectionStart = txtStatus.Text.Length;
            txtStatus.ScrollToCaret();

            Application.DoEvents();
            Console.WriteLine(logEntry);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveClientId();
        }
        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadClientId();
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtStatus.Clear();
        }
        private void SaveClientId()
        {
            try
            {
                string clientId = txtClientId.Text.Trim();

                if (string.IsNullOrEmpty(clientId))
                {
                    LogStatus("Error: Client ID cannot be empty.", true);
                    return;
                }

                // Validate storage path
                string storagePath = GetStoragePath();
                if (string.IsNullOrEmpty(storagePath))
                {
                    LogStatus("Error: Storage path cannot be empty.", true);
                    return;
                }

                LogStatus("Starting encryption process...");

                // Convert to bytes
                byte[] clientIdBytes = Encoding.UTF8.GetBytes(clientId);
                LogStatus($"Client ID converted to {clientIdBytes.Length} bytes");

                byte[] encryptedData;
                string method;

                encryptedData = EncryptWithDpapi(clientIdBytes);
                method = "Windows DPAPI";    

                LogStatus($"Encryption successful using {method}: {encryptedData.Length} bytes");

                // Convert encrypted data to Base64 string
                string base64EncryptedData = Convert.ToBase64String(encryptedData);

                // Ensure the directory exists before writing the file
                string? directory = Path.GetDirectoryName(StoragePath);
                if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                    LogStatus($"Created directory: {directory}");
                }

                // Save the Base64 string directly without JSON serialization
                File.WriteAllText(StoragePath, base64EncryptedData);

                LogStatus($"✓ Client ID encrypted and saved successfully!");
                LogStatus($"  - Method: {method}");
                LogStatus($"  - Original length: {clientIdBytes.Length} bytes");
                LogStatus($"  - Encrypted length: {encryptedData.Length} bytes");
                LogStatus($"  - File: {StoragePath}");
            }
            catch (Exception ex)
            {
                LogStatus($"Error saving Client ID: {ex.Message}", true);
                LogStatus($"Exception type: {ex.GetType().Name}", true);
            }
        }
        private byte[] EncryptWithDpapi(byte[] data)
        {
            return ProtectedData.Protect(data, null, DataProtectionScope.LocalMachine);
        }

        private void LoadClientId()
        {
            try
            {
                if (!File.Exists(StoragePath))
                {
                    LogStatus("No saved Client ID found.");
                    txtClientId.Clear();
                    return;
                }

                LogStatus("Starting decryption process...");

                // Read the Base64 string directly from file
                string base64EncryptedData = File.ReadAllText(StoragePath).Trim();

                if (string.IsNullOrEmpty(base64EncryptedData))
                {
                    LogStatus("File is empty or invalid", true);
                    return;
                }

                LogStatus("Found encrypted data (Base64 format)");

                byte[] encryptedData;
                try
                {
                    encryptedData = Convert.FromBase64String(base64EncryptedData);
                }
                catch (FormatException)
                {
                    LogStatus("Invalid Base64 format in file", true);
                    return;
                }

                byte[] decryptedData = DecryptWithDpapi(encryptedData);

                string clientId = Encoding.UTF8.GetString(decryptedData);
                txtClientId.Text = clientId;

                LogStatus($"✓ Client ID decrypted and loaded successfully!");
                LogStatus($"  - Encrypted length: {encryptedData.Length} bytes");
                LogStatus($"  - Decrypted length: {decryptedData.Length} bytes");
                LogStatus($"  - File: {StoragePath}");
            }
            catch (Exception ex)
            {
                LogStatus($"Error loading Client ID: {ex.Message}", true);
                LogStatus($"Exception type: {ex.GetType().Name}", true);
            }
        }

        private byte[] DecryptWithDpapi(byte[] encryptedData)
        {
            return ProtectedData.Unprotect(encryptedData, null, DataProtectionScope.LocalMachine);
        }
       
    }
}

namespace UseDPAPI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblClientId = new Label();
            txtClientId = new TextBox();
            lblFileName = new Label();
            txtFileName = new TextBox();
            lblStoragePath = new Label();
            txtStoragePath = new TextBox();
            btnBrowse = new Button();
            btnSave = new Button();
            btnLoad = new Button();
            btnClear = new Button();
            lblStatus = new Label();
            txtStatus = new TextBox();
            lblStorageLocation = new Label();
            txtStorageLocation = new TextBox();
            SuspendLayout();
            // 
            // lblClientId
            // 
            lblClientId.AutoSize = true;
            lblClientId.Location = new Point(30, 30);
            lblClientId.Name = "lblClientId";
            lblClientId.Size = new Size(58, 15);
            lblClientId.TabIndex = 0;
            lblClientId.Text = "Data:";
            // 
            // txtClientId
            // 
            txtClientId.Location = new Point(30, 50);
            txtClientId.Name = "txtClientId";
            txtClientId.Size = new Size(400, 23);
            txtClientId.TabIndex = 1;
            txtClientId.PlaceholderText = "Enter your data here";
            // 
            // lblFileName
            // 
            lblFileName.AutoSize = true;
            lblFileName.Location = new Point(450, 30);
            lblFileName.Name = "lblFileName";
            lblFileName.Size = new Size(64, 15);
            lblFileName.TabIndex = 2;
            lblFileName.Text = "File Name:";
            // 
            // txtFileName
            // 
            txtFileName.Location = new Point(450, 50);
            txtFileName.Name = "txtFileName";
            txtFileName.Size = new Size(180, 23);
            txtFileName.TabIndex = 3;
            txtFileName.PlaceholderText = "Enter filename (without .dat)";
            txtFileName.TextChanged += txtFileName_TextChanged;
            // 
            // lblStoragePath
            // 
            lblStoragePath.AutoSize = true;
            lblStoragePath.Location = new Point(30, 90);
            lblStoragePath.Name = "lblStoragePath";
            lblStoragePath.Size = new Size(78, 15);
            lblStoragePath.TabIndex = 4;
            lblStoragePath.Text = "Storage Path:";
            // 
            // txtStoragePath
            // 
            txtStoragePath.Location = new Point(30, 110);
            txtStoragePath.Name = "txtStoragePath";
            txtStoragePath.Size = new Size(500, 23);
            txtStoragePath.TabIndex = 5;
            txtStoragePath.PlaceholderText = "Enter storage directory path";
            txtStoragePath.TextChanged += txtStoragePath_TextChanged;
            // 
            // btnBrowse
            // 
            btnBrowse.Location = new Point(540, 110);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(90, 23);
            btnBrowse.TabIndex = 6;
            btnBrowse.Text = "Browse...";
            btnBrowse.UseVisualStyleBackColor = true;
            btnBrowse.Click += btnBrowse_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(30, 150);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(100, 30);
            btnSave.TabIndex = 7;
            btnSave.Text = "Save (Encrypt)";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(140, 150);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(100, 30);
            btnLoad.TabIndex = 8;
            btnLoad.Text = "Load (Decrypt)";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(250, 150);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(100, 30);
            btnClear.TabIndex = 9;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(30, 200);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(42, 15);
            lblStatus.TabIndex = 10;
            lblStatus.Text = "Status:";
            // 
            // txtStatus
            // 
            txtStatus.Location = new Point(30, 220);
            txtStatus.Multiline = true;
            txtStatus.Name = "txtStatus";
            txtStatus.ReadOnly = true;
            txtStatus.ScrollBars = ScrollBars.Vertical;
            txtStatus.Size = new Size(600, 150);
            txtStatus.TabIndex = 11;
            // 
            // lblStorageLocation
            // 
            lblStorageLocation.AutoSize = true;
            lblStorageLocation.Location = new Point(30, 390);
            lblStorageLocation.Name = "lblStorageLocation";
            lblStorageLocation.Size = new Size(98, 15);
            lblStorageLocation.TabIndex = 12;
            lblStorageLocation.Text = "Full File Path:";
            // 
            // txtStorageLocation
            // 
            txtStorageLocation.Location = new Point(30, 410);
            txtStorageLocation.Name = "txtStorageLocation";
            txtStorageLocation.ReadOnly = true;
            txtStorageLocation.Size = new Size(600, 23);
            txtStorageLocation.TabIndex = 13;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(660, 460);
            Controls.Add(txtStorageLocation);
            Controls.Add(lblStorageLocation);
            Controls.Add(txtStatus);
            Controls.Add(lblStatus);
            Controls.Add(btnClear);
            Controls.Add(btnLoad);
            Controls.Add(btnSave);
            Controls.Add(btnBrowse);
            Controls.Add(txtStoragePath);
            Controls.Add(lblStoragePath);
            Controls.Add(txtFileName);
            Controls.Add(lblFileName);
            Controls.Add(txtClientId);
            Controls.Add(lblClientId);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "DPAPI Client ID Manager";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblClientId;
        private TextBox txtClientId;
        private Label lblFileName;
        private TextBox txtFileName;
        private Label lblStoragePath;
        private TextBox txtStoragePath;
        private Button btnBrowse;
        private Button btnSave;
        private Button btnLoad;
        private Button btnClear;
        private Label lblStatus;
        private TextBox txtStatus;
        private Label lblStorageLocation;
        private TextBox txtStorageLocation;
    }
}

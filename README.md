# DPAPI Client ID Manager

A Windows Forms application for securely encrypting and storing client IDs using Windows Data Protection API (DPAPI).

## Overview

This application provides a user-friendly interface to encrypt sensitive client IDs and store them securely on Windows systems. It uses Windows DPAPI (Data Protection API) for encryption, ensuring that encrypted data can only be decrypted by the same user account on the same machine.

## Features

- **Secure Encryption**: Uses Windows DPAPI with LocalMachine scope
- **User-Friendly Interface**: Simple Windows Forms GUI
- **Customizable Storage**: 
  - User-defined storage directory path
  - Custom filename support
  - Browse functionality for easy directory selection
- **Base64 Encoding**: Encrypted data is stored as clean Base64 strings
- **Real-time Feedback**: Comprehensive logging and status updates
- **Input Validation**: Automatic filename sanitization and path validation

## Requirements

### System Requirements
- Windows Operating System (Windows 10/11 recommended)
- .NET 8.0 Runtime

### Development Requirements
- Visual Studio 2022 or later
- .NET 8.0 SDK
- C# 12.0

## Installation

### For End Users
1. Download the latest release from the [Releases](https://github.com/ktds13/UseDPAPI/releases) page
2. Extract the files to your desired location
3. Run `UseDPAPI.exe`

### For Developers
1. Clone the repository:
   ```bash
   git clone https://github.com/ktds13/UseDPAPI.git
   ```
2. Open `UseDPAPI.sln` in Visual Studio
3. Build the solution (Ctrl+Shift+B)
4. Run the application (F5)

## Usage

### Basic Usage
1. **Enter Client ID**: Type your sensitive client ID in the "Client ID" field
2. **Set Filename**: Specify a filename (without .dat extension) - defaults to "DeviceID"
3. **Set Storage Path**: Choose where to store the encrypted file:
   - Use the default path: `C:/GW/courtlink2/CourtLink2.SmartClient/DPAPI_ClientManager`
   - Type a custom path in the "Storage Path" field
   - Click "Browse..." to select a directory
4. **Save**: Click "Save (Encrypt)" to encrypt and store the client ID
5. **Load**: Click "Load (Decrypt)" to decrypt and display a previously saved client ID

### File Structure
- **File Extension**: All encrypted files use the `.dat` extension
- **File Format**: Base64-encoded DPAPI encrypted data
- **Directory Creation**: The application automatically creates directories if they don't exist

### Security Notes
- Files encrypted on one machine/user account cannot be decrypted on another
- Uses `DataProtectionScope.LocalMachine` for encryption scope
- No password required - security is tied to the Windows user account and machine

## Configuration

### Default Settings
```csharp
Default Storage Path: C:/GW/courtlink2/CourtLink2.SmartClient/DPAPI_ClientManager/
Default Filename: DeviceID.dat
Encryption Scope: LocalMachine
```

### Customization
All settings can be modified through the UI:
- Storage path can be changed via text input or browse dialog
- Filename can be customized (automatically gets .dat extension)
- Real-time preview of full file path

## Architecture

### Key Components
- **Form1.cs**: Main application logic and UI event handlers
- **Form1.Designer.cs**: Windows Forms designer generated code
- **DPAPI Integration**: Uses `System.Security.Cryptography.ProtectedData`

### Key Methods
- `EncryptWithDpapi()`: Encrypts data using Windows DPAPI
- `DecryptWithDpapi()`: Decrypts DPAPI encrypted data
- `SaveClientId()`: Handles the complete save/encrypt workflow
- `LoadClientId()`: Handles the complete load/decrypt workflow
- `GetFileName()`: Validates and sanitizes user-provided filenames
- `GetStoragePath()`: Manages user-defined storage paths

## File Format

### Encrypted File Structure
```
[Base64 Encoded DPAPI Encrypted Data]
```

### Example File Content
```
AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAA9x8+0P8EmE2r7BXBOwFq1QAAAAACAAAAAAAQZgAAAAEAACAAAAC...
```

## Error Handling

The application includes comprehensive error handling for:
- **Empty Input**: Validates client ID is not empty
- **Invalid Paths**: Checks for valid storage paths
- **File System Errors**: Handles directory creation and file access issues
- **Encryption/Decryption Errors**: Manages DPAPI operation failures
- **Format Errors**: Validates Base64 format when loading files

## Logging

Real-time status logging includes:
- Timestamp for each operation
- Detailed process information
- File sizes and paths
- Error messages with exception types
- Success confirmations

## Contributing

1. Fork the repository
2. Create a feature branch: `git checkout -b feature-name`
3. Make your changes
4. Add tests if applicable
5. Commit your changes: `git commit -am 'Add some feature'`
6. Push to the branch: `git push origin feature-name`
7. Submit a pull request

## Development Setup

### Prerequisites
- Visual Studio 2022
- .NET 8.0 SDK
- Git

### Build Instructions
```bash
# Clone the repository
git clone https://github.com/ktds13/UseDPAPI.git

# Navigate to project directory
cd UseDPAPI

# Restore dependencies
dotnet restore

# Build the project
dotnet build

# Run the application
dotnet run
```

### Project Structure
```
UseDPAPI/
??? Form1.cs              # Main application logic
??? Form1.Designer.cs     # UI designer code
??? Form1.resx           # Form resources
??? Program.cs           # Application entry point
??? UseDPAPI.csproj      # Project file
??? UseDPAPI.sln         # Solution file
??? README.md            # This file
```

## Security Considerations

### DPAPI Security Model
- **Machine Binding**: Encrypted data is tied to the specific machine
- **User Context**: Uses LocalMachine scope for broader accessibility
- **No External Dependencies**: No passwords or keys to manage
- **Windows Integration**: Leverages built-in Windows security

### Best Practices
- Store encrypted files in secure directories
- Regularly backup encrypted files
- Test decryption before relying on stored data
- Be aware that LocalMachine scope allows any user on the machine to decrypt

## Troubleshooting

### Common Issues

**Issue**: "Could not find a part of the path" error
- **Solution**: The application will automatically create missing directories

**Issue**: "Invalid Base64 format in file" error
- **Solution**: The file may be corrupted or not created by this application

**Issue**: Cannot decrypt data
- **Solution**: Ensure you're on the same machine where the data was encrypted

**Issue**: Application won't start
- **Solution**: Ensure .NET 8.0 runtime is installed

### Debug Mode
The application logs detailed information to both the UI and console output for debugging purposes.

## Version History

### Current Version
- **Framework**: .NET 8.0
- **C# Version**: 12.0
- **Features**: Full DPAPI integration with custom storage paths

## License

This project is open source. Please check the repository for license details.

## Support

For support, issues, or feature requests:
- Create an issue on [GitHub Issues](https://github.com/ktds13/UseDPAPI/issues)
- Check existing documentation and troubleshooting guide

## Acknowledgments

- Built using Windows Forms and .NET 8.0
- Utilizes Windows Data Protection API (DPAPI)
- Inspired by secure credential storage needs

---

**Note**: This application is designed for Windows environments and requires Windows-specific APIs for encryption functionality.
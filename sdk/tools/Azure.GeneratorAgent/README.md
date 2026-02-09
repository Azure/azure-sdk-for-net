# Azure Generator Agent

The Azure Generator Agent is a powerful CLI tool for automated Azure SDK code generation and migration workflows with improved architecture and enhanced capabilities.

## Installation

### Prerequisites

- .NET 8.0 or later
- Git (for repository operations)

### Build and Run

1. Clone the repository and navigate to the project directory:
   ```bash
   cd sdk/tools/Azure.GeneratorAgent/src
   ```

2. Restore packages:
   ```bash
   dotnet restore
   ```

3. Build the project:
   ```bash
   dotnet build
   ```

## Usage

### Generate Command

Generate code for Azure SDK from an existing SDK path:

```bash
dotnet run -- generate <sdk-path>
```

**Parameters:**
- `<sdk-path>`: Path to the SDK directory to generate code for

**Example:**
```bash
dotnet run -- generate "C:\path\to\your\sdk\directory"
```

### Migrate Command

Migrate existing code to new Azure SDK patterns:

```bash
dotnet run -- migrate <sdk-path>
```

**Parameters:**
- `<sdk-path>`: Path to the SDK directory to migrate

**Example:**
```bash
dotnet run -- migrate "C:\path\to\your\sdk\directory"
```

## Configuration

Configuration is managed through `appsettings.json` and supports:

- **Logging levels and output targets**: Control verbosity and output format
- **Workflow settings**: Configure max retries, timeouts, and verbose mode
- **Environment-specific overrides**: Customize settings per environment

### Sample Configuration

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information"
    }
  },
  "Workflow": {
    "MaxRetries": 3,
    "VerboseMode": false,
    "TimeoutMinutes": 30
  }
}
```

## Features

- **SDK Path Validation**: Comprehensive validation of SDK directory structure

## Contributing

This tool is part of the Azure SDK for .NET project. Please see the [contributing guide](../../../CONTRIBUTING.md) for details on how to contribute.

## Troubleshooting

### Common Issues

1. **"Not a git repository" error**: Ensure the SDK path is within a git repository
2. **"Git is not available" error**: Install Git and ensure it's in your PATH
3. **Build failures**: Ensure .NET 8.0 or later is installed

For additional help, check the logs for detailed error information.
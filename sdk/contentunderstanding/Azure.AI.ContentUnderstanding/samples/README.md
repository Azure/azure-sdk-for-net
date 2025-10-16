# Azure AI Content Understanding Samples

This directory contains samples demonstrating how to use the Azure AI Content Understanding SDK for .NET.

## Available Samples

### Runnable Console Samples

These are complete, executable samples that demonstrate end-to-end scenarios:

| Sample | Description | Directory |
|--------|-------------|-----------|
| **Analyze URL** | Analyze a document from a remote URL using prebuilt-documentAnalyzer | [AnalyzeUrl/](AnalyzeUrl/) |
| **Analyze Binary** | Analyze a local PDF file using binary content with prebuilt-documentAnalyzer | [AnalyzeBinary/](AnalyzeBinary/) |
| **Analyze Invoice** | Extract structured invoice fields from a URL using prebuilt-invoice analyzer | [AnalyzeInvoice/](AnalyzeInvoice/) |

### Documentation Samples

These markdown-based samples show code snippets for quick reference:

- [Sample1_HelloWorld.md](Sample1_HelloWorld.md) - Basic usage example
- [Sample1_HelloWorldAsync.md](Sample1_HelloWorldAsync.md) - Async usage example

## Prerequisites

- .NET 8.0 SDK or later
- Azure Content Understanding resource
  - [Create a resource](https://learn.microsoft.com/azure/ai-services/content-understanding/quickstart/use-rest-api?tabs=document#prerequisites)
- Azure CLI (optional, for DefaultAzureCredential)
  - [Install Azure CLI](https://docs.microsoft.com/cli/azure/install-azure-cli)

## Configuration

All runnable samples use the standard .NET configuration system (`Microsoft.Extensions.Configuration`) and support two methods of configuration:

### Option 1: Environment Variables (Recommended)

Set the following environment variables:

```bash
# Required
export AZURE_CONTENT_UNDERSTANDING_ENDPOINT="https://your-resource-name.services.ai.azure.com/"

# Optional - Leave empty to use DefaultAzureCredential
export AZURE_CONTENT_UNDERSTANDING_KEY="your-key-here"
```

### Option 2: Configuration File (appsettings.json)

You can create a **shared** configuration file or **sample-specific** configuration files:

#### Shared Configuration (Recommended for Multiple Samples)

Create one configuration file that all samples will use:

```bash
# Navigate to the samples directory
cd samples/

# Copy the template
cp appsettings.json.sample appsettings.json

# Edit with your values
# All samples will automatically use this configuration
```

#### Sample-Specific Configuration

Each sample can have its own `appsettings.json` which will override the shared configuration:

```bash
# Navigate to a specific sample
cd samples/AnalyzeUrl/

# Copy the template
cp appsettings.json.sample appsettings.json

# Edit with your values
# Only this sample will use these settings
```

**Configuration Priority** (later sources override earlier ones):
1. `samples/appsettings.json` (shared across all samples)
2. `samples/SampleName/appsettings.json` (sample-specific overrides)
3. Environment variables (highest priority)

```json
{
  "AzureContentUnderstanding": {
    "Endpoint": "https://your-resource-name.services.ai.azure.com/",
    "Key": ""
  }
}
```

## Running Samples

Each sample is a standalone console application. To run a sample:

```bash
# Navigate to the sample directory
cd samples/AnalyzeUrl

# Restore dependencies
dotnet restore

# Run the sample
dotnet run
```

## Authentication

All samples support two authentication methods:

### 1. DefaultAzureCredential (Recommended for Development)

Leave the `Key` configuration empty and authenticate using one of these methods:

- **Azure CLI**: Run `az login`
- **Visual Studio**: Sign in through Visual Studio
- **Visual Studio Code**: Use the Azure Account extension
- **Environment Variables**: Set `AZURE_CLIENT_ID`, `AZURE_CLIENT_SECRET`, and `AZURE_TENANT_ID`
- **Managed Identity**: Automatically used when running on Azure services

[Learn more about DefaultAzureCredential](https://learn.microsoft.com/dotnet/api/overview/azure/identity-readme#defaultazurecredential)

### 2. API Key (Testing Only)

Set the `Key` configuration value. **Note:** This is less secure and should only be used for testing and development.

## Sample Structure

Each runnable sample follows this structure:

```
SampleName/
├── Program.cs                    # Main sample code
├── SampleHelper.cs               # Shared helper utilities
├── SampleName.csproj             # Project file
├── appsettings.json.sample       # Configuration template
└── README.md                     # Sample-specific documentation
```

## Adding More Samples

To add a new sample:

1. Create a new directory under `samples/`
2. Follow the existing sample structure
3. Update this README.md to list the new sample

## Learn More

- [Azure AI Content Understanding Documentation](https://learn.microsoft.com/azure/ai-services/content-understanding/)
- [.NET SDK Reference](https://learn.microsoft.com/dotnet/api/overview/azure/ai.contentunderstanding-readme)
- [Azure SDK for .NET Guidelines](https://azure.github.io/azure-sdk/dotnet_introduction.html)

## Need Help?

- [File an issue](https://github.com/Azure/azure-sdk-for-net/issues/new)
- [Azure SDK Support](https://github.com/Azure/azure-sdk-for-net/blob/main/SUPPORT.md)

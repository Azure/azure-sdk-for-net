# Sample15_GrantCopyAuth

This sample demonstrates how to analyze a PDF file from disk using the `prebuilt-documentSearch` analyzer.
For detailed documentation, see [Sample15_GrantCopyAuth.md](../Sample15_GrantCopyAuth.md).

## Prerequisites

- Azure subscription
- Microsoft Foundry resource
- .NET 8.0 SDK or later

## Setup

### Option 1: Use appsettings.json.sample

1. Copy `appsettings.json.sample` from the parent `samples` directory:
   ```bash
   cp ../appsettings.json.sample appsettings.json
   ```

2. Edit `appsettings.json` and fill in your values:
   - `AZURE_CONTENT_UNDERSTANDING_ENDPOINT` (required) - Your Microsoft Foundry resource endpoint
   - `AZURE_CONTENT_UNDERSTANDING_KEY` (optional) - Your API key, or leave empty to use DefaultAzureCredential

### Option 2: Use Environment Variables

Set the following environment variables:

- `AZURE_CONTENT_UNDERSTANDING_ENDPOINT` (required)
- `AZURE_CONTENT_UNDERSTANDING_KEY` (optional - DefaultAzureCredential will be used if not set)

## Run

```bash
dotnet run
```

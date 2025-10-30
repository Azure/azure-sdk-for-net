# Azure Planetary Computer SDK Tests

This directory contains tests for the Azure Planetary Computer .NET SDK.

## Test Configuration

Tests use environment variables for configuration. You can set these in two ways:

### Option 1: Using .env file (Recommended for local development)

1. Copy `.env.example` to `.env`:
   ```bash
   cp .env.example .env
   ```

2. Edit `.env` with your actual values

3. The test framework will automatically load variables from the `.env` file

### Option 2: Using system environment variables

Set the environment variables directly in your system or CI/CD pipeline.

## Required Environment Variables

### Core Configuration
- `PLANETARYCOMPUTER_ENDPOINT` - The endpoint URL for the Planetary Computer service
- `PLANETARYCOMPUTER_COLLECTION_ID` - STAC Collection ID for testing (e.g., "naip-atl")
- `PLANETARYCOMPUTER_ITEM_ID` - STAC Item ID for testing

### Authentication
- `GEOCATALOG_SCOPE` - OAuth scope for authentication (default: `https://geocatalog.spatio.azure.com/.default`)
- `AZURE_TEST_USE_CLI_AUTH` - Set to `true` to use Azure CLI authentication
- `AZURE_TEST_USE_PWSH_AUTH` - Set to `true` to use PowerShell authentication
- `AZURE_TEST_USE_AZD_AUTH` - Set to `true` to use Azure Developer CLI authentication

### Ingestion Testing
- `PLANETARYCOMPUTER_INGESTION_CONTAINER_URI` - Azure Blob Storage container URI for ingestion tests
- `PLANETARYCOMPUTER_INGESTION_CATALOG_URL` - URL to a STAC catalog JSON for ingestion tests
- `PLANETARYCOMPUTER_MANAGED_IDENTITY_OBJECT_ID` - Managed Identity Object ID for ingestion

### SAS Token Ingestion (Optional)
- `PLANETARYCOMPUTER_INGESTION_SAS_CONTAINER_URI` - Container URI with SAS token for ingestion
- `PLANETARYCOMPUTER_INGESTION_SAS_TOKEN` - SAS token for container access

## Running Tests

### Run all tests
```bash
dotnet test
```

### Run in Live mode (requires valid Azure credentials)
```bash
$env:AZURE_TEST_RUN_LIVE = "true"
dotnet test
```

### Run in Playback mode (uses recorded sessions)
```bash
$env:AZURE_TEST_RUN_LIVE = "false"
dotnet test
```

## Recording Tests

To record new test sessions:

1. Set `AZURE_TEST_RUN_LIVE=true`
2. Ensure you have valid Azure credentials configured
3. Run the tests - recordings will be saved to `SessionRecords/`
4. Commit the recorded sessions to the repository

## Notes

- The `.env` file is ignored by git to prevent accidental credential commits
- Always use `.env.example` as a template for required variables
- Sensitive values in recordings are automatically sanitized by the test framework

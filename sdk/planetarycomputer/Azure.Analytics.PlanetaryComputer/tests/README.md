# Azure Planetary Computer client library for .NET - Tests

This directory contains tests for the Azure Planetary Computer .NET SDK.

## Getting started

### Install the package

The tests reference the Azure Planetary Computer client library:

```dotnetcli
dotnet add package Azure.Analytics.PlanetaryComputer --prerelease
```

### Prerequisites

- An Azure subscription
- Access to Azure Planetary Computer service
- [.NET SDK](https://dotnet.microsoft.com/download) 8.0 or higher

### Authenticate the client

Tests use Azure credential-based authentication. You can authenticate using:

- Azure CLI: `az login`
- PowerShell: `Connect-AzAccount`
- Azure Developer CLI: `azd auth login`

Set `AZURE_TEST_USE_CLI_AUTH=true` (or `AZURE_TEST_USE_PWSH_AUTH` or `AZURE_TEST_USE_AZD_AUTH`) to use the respective authentication method.

## Key concepts

The tests verify the functionality of:

- **STAC Client**: Testing STAC catalog, collection, and item operations
- **Tiler Client**: Testing map tile and rendering operations
- **Ingestion Client**: Testing data ingestion workflows

Tests are built using:

- **NUnit** as the test framework
- **Azure.Core.TestFramework** for recording and playback
- **Environment variables** for configuration

### Test modes

Tests support three modes:

- **Live**: Executes against real Azure services
- **Record**: Executes live and saves HTTP interactions
- **Playback**: Uses recorded interactions (default)

## Examples

### Running tests in playback mode

```bash
dotnet test
```

### Running tests in live mode

```bash
$env:AZURE_TEST_MODE="Live"
dotnet test
```

### Recording new test sessions

```bash
$env:AZURE_TEST_MODE="Record"
dotnet test
```

### Configuration using .env file

Create a `.env` file based on `.env.example`:

```bash
cp .env.example .env
```

Required variables:

- `PLANETARYCOMPUTER_ENDPOINT` - Service endpoint URL
- `PLANETARYCOMPUTER_COLLECTION_ID` - Test STAC collection ID
- `PLANETARYCOMPUTER_ITEM_ID` - Test STAC item ID
- `GEOCATALOG_SCOPE` - OAuth authentication scope

## Troubleshooting

### Authentication failures

Ensure you're logged in with Azure CLI, PowerShell, or Azure Developer CLI before running live tests.

### Recording failures

If recordings fail to sanitize properly, check `PlanetaryComputerTestSanitizers.cs` for the correct sanitization rules.

### Missing environment variables

If tests fail due to missing configuration, ensure all required variables are set in `.env` or your environment.

## Next steps

- Review the [Azure Planetary Computer documentation](https://planetarycomputer.microsoft.com/docs/overview/)
- See the [samples directory](../samples) for usage examples
- Check the [main README](../README.md) for client library documentation

## Contributing

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit <https://cla.microsoft.com>.

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.

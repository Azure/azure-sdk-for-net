## Microsoft Azure PlanetaryComputer client library for .NET

The `Azure.ResourceManager.PlanetaryComputer` SDK is the **.NET Management Plane SDK** for working with `GeoCatalog` resources under the **PlanetaryComputer** service.

It supports full **CRUD operations**, as well as **recorded** and **playback testing** using the Azure SDK's standard test framework.

---

## Project Structure

```
sdk/
└── planetarycomputer/
    └── Azure.ResourceManager.PlanetaryComputer/
        ├── src/                                        # Generated SDK source code
        ├── tests/
        │   ├── Scenario/
        │   │   └── GeoCatalogCollectionTests.cs        # Main scenario tests
        │   ├── PlanetaryComputerManagementTestBase.cs  # Base test infrastructure
        │   └── PlanetaryComputerManagementTestEnvironment.cs
        ├── Azure.ResourceManager.PlanetaryComputer.csproj
        ├── Azure.ResourceManager.PlanetaryComputer.Tests.csproj
        └── assets.json                                 # Required for test recording/playback
```

---

## Getting started

### Install the Package

Install the package via [NuGet](https://www.nuget.org/):

```bash
dotnet add package Azure.ResourceManager.PlanetaryComputer --prerelease
```

---

### Prerequisites

- [.NET SDK 8.0+](https://dotnet.microsoft.com/download)
- [Azure SDK Test Proxy](https://github.com/Azure/azure-sdk-tools/blob/main/tools/test-proxy/Azure.Sdk.Tools.TestProxy/README.md)
  ```bash
  dotnet tool install --global Azure.Sdk.Tools.TestProxy
  ```
- Logged in to Azure CLI:
  ```bash
  az login
  ```
- Set the following environment variables for test execution:

```bash
$env:AZURE_SUBSCRIPTION_ID = "<your-subscription-id>"
$env:AZURE_TEST_MODE = "Record"   # or "Playback"
$env:AZURE_AUTHORITY_HOST = "https://login.microsoftonline.com"
```
---

### Authenticate the Client

To authenticate the client, use the `DefaultAzureCredential` from the Azure.Identity library. Ensure your environment is set up with the necessary Azure credentials.

```csharp
using Azure.Identity;
using Azure.ResourceManager.PlanetaryComputer;

var credential = new DefaultAzureCredential();
var client = new PlanetaryComputerManagementClient(credential);
```

## Supported Tests

| Test Name                        | Description                                 |
|----------------------------------|---------------------------------------------|
| `CreateGeoCatalog`              | Creates a GeoCatalog                        |
| `UpdateGeoCatalog`              | Updates an existing GeoCatalog              |
| `DeleteGeoCatalog`              | Deletes a GeoCatalog                        |
| `GetGeoCatalog`                 | Retrieves a specific GeoCatalog             |
| `ListGeoCatalogsInResourceGroup`| Lists GeoCatalogs in a resource group       |
| `ListGeoCatalogsBySubscription` | Lists GeoCatalogs under a subscription      |
| `CreateUpdateDeleteGeoCatalog`  | Full CRUD scenario combined                 |

---

## Running Tests

### Record Mode (Live with Azure)

1. Start the test proxy:
   ```bash
   test-proxy
   ```
2. Set mode:
   ```bash
   $env:AZURE_TEST_MODE = "Record"
   ```
3. Run a specific test:
   ```bash
   dotnet test -f net8.0 --filter "Name=CreateUpdateDeleteGeoCatalog"
   ```
4. Recordings are saved to:
   ```
   .azure-sdk-for-net/.assets/<hash>/net/sdk/PlanetaryComputer/Azure.ResourceManager.PlanetaryComputer/tests/SessionRecords
   ```

---

### Playback Mode (Offline Testing)

1. Set mode:
   ```bash
   $env:AZURE_TEST_MODE = "Playback"
   ```
2. (Optional) Restore recordings:
   ```bash
   test-proxy restore -a ./assets.json
   ```
3. Run test:
   ```bash
   dotnet test -f net8.0 --filter "Name=CreateUpdateDeleteGeoCatalog"
   ```

---


## Key concepts

The PlanetaryComputer SDK provides management capabilities for GeoCatalog resources. Key concepts include:
- **GeoCatalog**: Represents a catalog of geospatial data.
- **CRUD Operations**: Create, Read, Update, and Delete operations for GeoCatalog resources.
- **Authentication**: Uses Azure Active Directory for secure access.

## Examples

### Create a GeoCatalog

```csharp
var geoCatalogData = new GeoCatalogData(new AzureLocation("uksouth"))
{
    Properties = new GeoCatalogProperties
    {
        Tier = CatalogTier.Basic
    }
};

var geoCatalog = await client.GeoCatalogs.CreateOrUpdateAsync("resourceGroupName", "geoCatalogName", geoCatalogData);
```

### List GeoCatalogs

```csharp
var geoCatalogs = await client.GeoCatalogs.ListAsync("resourceGroupName");
foreach (var catalog in geoCatalogs)
{
    Console.WriteLine(catalog.Name);
}
```

## Troubleshooting

If you encounter issues, check the following:
- Ensure Azure CLI is logged in (`az login`).
- Verify the subscription and resource group names.
- Check for network connectivity issues.

## Next steps

Explore additional features of the PlanetaryComputer SDK:
- [Samples Repository](https://github.com/Azure/azure-sdk-for-net)

## Contributing

We welcome contributions! Please see our [Contributing Guide](https://github.com/Azure/azure-sdk-for-net/blob/main/CONTRIBUTING.md) for details on how to get started.

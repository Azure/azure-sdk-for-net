# Microsoft Azure PlanetaryComputer Management Client Library for .NET

The `Azure.ResourceManager.PlanetaryComputer` SDK is the **.NET Management Plane SDK** for working with `GeoCatalog` resources under the **PlanetaryComputer** service.

It supports full **CRUD operations**, as well as **recorded** and **playback testing** using the Azure SDK's standard test framework.

---

##  Project Structure

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

##  Getting Started

###  Install the Package

Install the package via [NuGet](https://www.nuget.org/):

```bash
dotnet add package Azure.ResourceManager.PlanetaryComputer --prerelease
```

---

###  Prerequisites

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
$env:AZURE_IDENTITY_NAME = "<Your-Identity-Name>"
```

### Authenticate the Client
Not required


---

##  Supported Tests

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

##  Running Tests

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

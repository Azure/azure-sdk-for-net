
# Developer Handbook for StorageSync team

This handbook provides guidelines and instructions for developers working on the project. It includes steps for setting up test resources, updating snippets, exporting APIs, generating code, running tests, downloading GitHub CLI, and FAQs.

## Setup Test Resources

To set up test resources, run the following PowerShell script in Powershell core (pwsh):

```powershell
.\New-TestResources.ps1 `
    -BaseName 'azsdk' `
    -ResourceGroupName 'azsdk2022-09-01' `
    -ServiceDirectory 'D:\code\ab\azure-sdk-for-net3\sdk\storagesync' `
    -SubscriptionId 'e29c162a-d1d4-4cc3-8295-80057c1f4bd9' `
    -Location 'eastus2euap' `
    -TenantId '0483643a-cb2f-462a-bc27-1a270e5bdc0a' `
    -ResourceType 'test' `
    -ProvisionerApplicationId 'c8b36958-2a0a-423d-bba9-98ff3af75f58' `
    -ProvisionerApplicationOid '8d1a2f63-15c2-4fe8-a804-213ecbaf4403' `
    -Environment AzureCloud `
    -TestApplicationId 'c8b36958-2a0a-423d-bba9-98ff3af75f58' `
    -TestApplicationOid '8d1a2f63-15c2-4fe8-a804-213ecbaf4403' `
    -EnvironmentVariables @{STORAGESYNC_TENANT_ID = "0483643a-cb2f-462a-bc27-1a270e5bdc0a" }
```

## Update Snippets

To update snippets, run the following PowerShell script:

```powershell
Location : eng\scripts
.\Update-Snippets.ps1 storagesync
```

## Export API

To export the API, run the following PowerShell script:

```powershell
Location : eng\scripts
.\Export-API.ps1 storagesync
```

## Generate Code

After changing `sdk\storagesync\Azure.ResourceManager.StorageSync\autorest.md`, generate the code by running:

```powershell
Location : sdk\storagesync\Azure.ResourceManager.StorageSync\
dotnet build /t:GenerateCode
```

## Run Tests

To run tests, use the following command:

```powershell
Location : sdk\storagesync\Azure.ResourceManager.StorageSync\
dotnet test --framework net9.0 --filter "Name~StorageSyncServiceGetTest"
```

## Download GitHub CLI

Download the GitHub CLI from https://github.com/cli/cli/releases/tag/v2.70.0 and authenticate:

```powershell
github auth login
```

## Push Test Proxy

To push the test proxy, run:

```powershell
Location : sdk\storagesync\Azure.ResourceManager.StorageSync\
test-proxy push -a .\assets.json
```

## FAQs

- **Enable Logging to a file:** https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/identity/Azure.Identity#enable-and-configure-logging
- **Tenant Mismatch Error:** This error occurs due to the credential not honoring the tenant ID provided in the default credentials construction. 

  ```json
  {"error":{"code":"InvalidAuthenticationTokenTenant","message":"The access token is from the wrong issuer 'https://sts.windows.net/72f988bf-86f1-41af-91ab-2d7cd011db47/'. It must match the tenant 'https://sts.windows.net/0483643a-cb2f-462a-bc27-1a270e5bdc0a/' associated with this subscription. Please use the authority (URL) 'https://login.windows.net/0483643a-cb2f-462a-bc27-1a270e5bdc0a' to get the token. Note, if the subscription is transferred to another tenant there is no impact to the services, but information about new tenant could take time to propagate (up to an hour). If you just transferred your subscription and see this error message, please try back later."}} Azure.RequestFailedException HResult=0x80131500
  ```

- **Test Proxy Failure:** If a test proxy failure occurs, it requires re-recording the test due to a known bug.
```


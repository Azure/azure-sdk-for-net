
# Developer Handbook for StorageSync team

This handbook provides guidelines and instructions for developers working on the project. It includes steps for setting up test resources, updating snippets, exporting APIs, generating code, running tests, downloading GitHub CLI, and FAQs.

## Setup Test Resources

To set up test resources, run the following PowerShell script in Powershell core (pwsh):

```powershell
cd eng\scripts
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
cd eng\scripts
.\Update-Snippets.ps1 storagesync
```

## Export API

To export the API, run the following PowerShell script:

```powershell
cd eng\scripts
.\Export-API.ps1 storagesync
```

## Generate Code

After changing `sdk\storagesync\Azure.ResourceManager.StorageSync\autorest.md`, generate the code by running:

```powershell
cd sdk\storagesync\Azure.ResourceManager.StorageSync\
dotnet build /t:GenerateCode
```

## Run Tests

To run tests, use the following command:

```powershell
cd sdk\storagesync\Azure.ResourceManager.StorageSync\
dotnet test --framework net9.0 --filter "Name~StorageSyncServiceGetTest"
```

## Download GitHub CLI

Download the GitHub CLI from [GitHub Download Release](https://github.com/cli/cli/releases/tag/v2.70.0) and authenticate:

```powershell
github auth login
```

## Push Test Proxy

To push the test proxy, run:

```powershell
cd sdk\storagesync\Azure.ResourceManager.StorageSync\
test-proxy push -a .\assets.json
```

## Observations

- Session Recording are now stored in separate repository [azure-sdk-assets](https://github.com/Azure/azure-sdk-assets). This link can help to extract test recordings : [asset-sync#asset-sync-retrieve-external-test-recordings](https://github.com/Azure/azure-sdk-tools/tree/main/tools/test-proxy/documentation/asset-sync#asset-sync-retrieve-external-test-recordings)

- Test-proxy has been shipped within the eng/common/testproxy folder for any repo owned by the azure-sdk team.

- **Enable Logging to a file:** [Azure.Identity#enable-and-configure-logging](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/identity/Azure.Identity#enable-and-configure-logging)

- **Tenant Mismatch Error:** This error occurs due to the credential not honoring the tenant ID provided in the default credentials construction. 

  ```json
  {"error":{"code":"InvalidAuthenticationTokenTenant","message":"The access token is from the wrong issuer 'https://sts.windows.net/72f988bf-86f1-41af-91ab-2d7cd011db47/'. It must match the tenant 'https://sts.windows.net/0483643a-cb2f-462a-bc27-1a270e5bdc0a/' associated with this subscription. Please use the authority (URL) 'https://login.windows.net/0483643a-cb2f-462a-bc27-1a270e5bdc0a' to get the token. Note, if the subscription is transferred to another tenant there is no impact to the services, but information about new tenant could take time to propagate (up to an hour). If you just transferred your subscription and see this error message, please try back later."}} Azure.RequestFailedException HResult=0x80131500
  ```

- **Test Proxy Failure:** If a test proxy failure occurs, it requires re-recording the test due to a known bug.

- StorageSyncManagementTestBase have logging enabled to a random file in output folder for troubleshooting.

- StorageSyncManagementTestBase class have ModeFromSourceCode which can be used to set the test mode : Playback or Record

- Tests must be executed in two variations: synchronous and asynchronous.

- Tests are not required to be run for Samples.

- It is sufficient to run tests for one framework only; running tests for all frameworks is not necessary.

- TestProxy command can fail with the following error and can be resolved by Github auth login command:
   
   ```powershell
   github auth login
   ```
  Git ran into an unrecoverable error. Test-Proxy is exiting. The error output from git is: remote: The 'Azure' organization has enabled or enforced SAML SSO. remote: To access this repository, you must re-authorize the OAuth Application 'Visual Studio'. fatal: unable to access 'https://github.com/Azure/azure-sdk-assets/': The requested URL returned error: 403

## Learn about different available service parameters and how to use them

Follow the steps listed in this [README]<!--(https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/playwrighttesting/Azure.Developer.MicrosoftPlaywrightTesting.NUnit/README.md)--> to integrate your existing Playwright test suite with the Microsoft Playwright Testing service.

This guide explains the different options available to you in the Azure.Developer.MicrosoftPlaywrightTesting.NUnit package and how to use them.

### Using .runsettings file

1. Create a `.runsettings` file in the root directory:

```xml
<?xml version="1.0" encoding="utf-8"?>
<RunSettings>
    <TestRunParameters>
        <!-- The below parameters are optional -->
        <Parameter name="Os" value="linux" />
        <Parameter name="RunId" value="sample-run-id" />
        <Parameter name="ServiceAuthType" value="EntraId" />
        <Parameter name="UseCloudHostedBrowsers" value="true" />
        <Parameter name="AzureTokenCredentialType" value="DefaultAzureCredential" />
        <Parameter name="EnableGitHubSummary" value="false" />
    </TestRunParameters>
    <!-- Enable Reporting feature -->
    <LoggerRunSettings>
        <Loggers>
            <Logger friendlyName="microsoft-playwright-testing" enabled="true" />
        </Loggers>
    </LoggerRunSettings>
</RunSettings>
```

  > [!NOTE]
  > You can also modify the runid by setting the environment variable `PLAYWRIGHT_SERVICE_RUN_ID`.

2. Run tests using the above `.runsettings` file:

```dotnetcli
dotnet test --settings .runsettings
```

#### Known issue: Minimal support for Azure Identity library credentials

This issue only impacts the reporting feature. Currently, the service provides minimal support for the following [Azure Credential types.](https://learn.microsoft.com/dotnet/api/overview/azure/identity-readme?view=azure-dotnet#credential-classes)

Along with this, we also support passing a Managed Identity ClientId to be used along with `DefaultAzureCredential` and `ManagedIdentityCredential`.

If you only want to use cloud-hosted browsers along with your tests, you can disable the reporting feature by removing the logger from the runsettings file and then modify the `PlaywrightServiceSetup.cs` file as per the following.

```C# Snippet:Sample1_CustomisingServiceParameters
using Azure.Core;
using Azure.Developer.MicrosoftPlaywrightTesting.NUnit;
using Azure.Identity;

namespace PlaywrightTests.Sample1; // Remember to change this as per your project namespace

[SetUpFixture]
public class PlaywrightServiceSetup : PlaywrightServiceNUnit
{
    public static readonly TokenCredential managedIdentityCredential = new ManagedIdentityCredential();

    public PlaywrightServiceSetup() : base(managedIdentityCredential) {}
}
```

## Options

1. **`Os`**:
    - **Description**: This setting allows you to choose the operating system where the browsers running Playwright tests will be hosted.
    - **Available Options**:
        - `System.Runtime.InteropServices.OSPlatform.Windows` for Windows OS.
        - `System.Runtime.InteropServices.OSPlatform.LINUX` for Linux OS.
    - **Default Value**: `System.Runtime.InteropServices.OSPlatform.LINUX`

2. **`RunId`**:
    - **Description**: This setting allows you to set a unique ID for every test run to distinguish them in the service portal.

3. **`ExposeNetwork`**:
    - **Description**: This settings exposes network available on the connecting client to the browser being connected to.

4. **`ServiceAuthType`**
    - **Description**: This setting allows you to specify the default authentication mechanism to be used for sending requests to the service.
    - **Available Options**:
        - `ServiceAuthType.EntraId` for Microsoft Entra ID authentication.
        - `ServiceAuthType.AccessToken` for MPT Access Token authentication.
    - **Default Value**: `ServiceAuthType.EntraId`

5. **`UseCloudHostedBrowsers`**
    - **Description**: This setting allows you to select whether to use cloud-hosted browsers to run your Playwright tests. Reporting features remain available even if you disable this setting.
    - **Default Value**: `true`

6. **`AzureTokenCredentialType`**:
    - **Description**: This setting allows you to select the authentication method you want to use with Entra.
    - **Available Options**:
        - `AzureTokenCredentialType.EnvironmentCredential`
        - `AzureTokenCredentialType.WorkloadIdentityCredential`
        - `AzureTokenCredentialType.ManagedIdentityCredential`
        - `AzureTokenCredentialType.SharedTokenCacheCredential`
        - `AzureTokenCredentialType.VisualStudioCredential`
        - `AzureTokenCredentialType.VisualStudioCodeCredential`
        - `AzureTokenCredentialType.AzureCliCredential`
        - `AzureTokenCredentialType.AzurePowerShellCredential`
        - `AzureTokenCredentialType.AzureDeveloperCliCredential`
        - `AzureTokenCredentialType.InteractiveBrowserCredential`
        - `AzureTokenCredentialType.DefaultAzureCredential`
    - **Default Value**: `AzureTokenCredentialType.DefaultAzureCredential`

7. **`ManagedIdentityClientId`**
    - **Description**: This setting allows you to specify the managed identity client id to be used for Microsoft Entra Id authentication.

8. **`EnableGitHubSummary`**:
    - **Description**: This setting allows you to configure the Microsoft Playwright Testing service reporter. You can choose whether to include the test run summary in the GitHub summary when running in GitHub Actions.
    - **Default Value**: `true`


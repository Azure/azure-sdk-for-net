# How to authenticate to Microsoft Playwright Testing service using service access token.

Follow the steps listed in this [README]<!--(https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/playwrighttesting/Azure.Developer.MicrosoftPlaywrightTesting.NUnit/README.md)--> to integrate your existing Playwright test suite with the Microsoft Playwright Testing service.

This guide will walk you through the steps to integrate your Playwright project where you are launching browsers from within the tests with the service.

### Setup Microsoft Playwright Testing

1. Create a file `PlaywrightServiceSetup.cs` in the root directory with the following

```C# Snippet:Sample2_SetDefaultAuthenticationMechanism
using Azure.Developer.MicrosoftPlaywrightTesting.NUnit;

namespace PlaywrightTests.Sample2; // Remember to change this as per your project namespace

[SetUpFixture]
public class PlaywrightServiceSetup : PlaywrightServiceNUnit {};
```

2. Create a .runsettings file to modify default authentication mechanism.

```xml
<?xml version="1.0" encoding="utf-8"?>
<RunSettings>
    <TestRunParameters>
        <!-- Set the service auth type as AccessToken -->
        <Parameter name="ServiceAuthType" value="AccessToken" />
    </TestRunParameters>
</RunSettings>
```

> [!NOTE]
> Make sure your project uses Microsoft.Playwright.NUnit version 1.37 or above.

### Obtain region endpoint

1. In the [Playwright portal](https://aka.ms/mpt/portal), copy the command under **Add region endpoint in your set up**.

    ![Set workspace endpoint](https://github.com/microsoft/playwright-testing-service/assets/12104064/d81ca629-2b23-4d34-8b70-67b6f7061a83)

    The endpoint URL corresponds to the workspace region. You might see a different endpoint URL in the Playwright portal, depending on the region you selected when creating the workspace.

### Set up environment

Ensure that the `PLAYWRIGHT_SERVICE_URL` that you obtained in previous step is available in your environment.

### Authenticate the client

To learn more about options for Microsoft Entra Id authentication, refer to [Azure.Identity credentials](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/identity/Azure.Identity#credentials). You can also refer to [our samples]<!--(https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/playwrighttesting/Azure.Developer.MicrosoftPlaywrightTesting.NUnit/samples/Sample1_CustomisingServiceParameters.md)--> on how to configurate different Azure Identity credentials.

### Run the tests

Run Playwright tests against browsers managed by the service using the configuration you created above.

```dotnetcli
dotnet test --settings .runsettings
```

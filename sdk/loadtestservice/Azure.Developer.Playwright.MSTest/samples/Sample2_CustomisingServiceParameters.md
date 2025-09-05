## Learn about different available service parameters and how to use them

Follow the steps listed in this [README](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/loadtestservice/Azure.Developer.Playwright.MSTest/README.md) to integrate your existing Playwright test suite with Playwright Workspaces.
This guide explains the different options available to you in the Azure.Developer.Playwright.MSTest package and how to use them.

### Customising remote browser parameters

The snippet below shows how to customize remote browser parameters like OS, expose network settings, run ids and azure credential type.

```C# Snippet:MSTest_Sample2_CustomisingServiceParameters
using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Azure.Developer.Playwright.MSTest;
using Azure.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PlaywrightService.SampleTests; // Remember to change this as per your project namespace

[TestClass]
public class PlaywrightServiceMSTestSetup
{
    private static PlaywrightServiceBrowserMSTest playwrightClient = null!;

    [AssemblyInitialize]
    public static async Task AssemblyInitialize(TestContext testContext)
    {
        playwrightClient = new PlaywrightServiceBrowserMSTest(credential: new ManagedIdentityCredential(), options: new Azure.Developer.Playwright.PlaywrightServiceBrowserClientOptions()
        {
            OS = OSPlatform.Linux,
            ExposeNetwork = "<loopback>",
            RunId = Guid.NewGuid().ToString(),
        }, context: testContext);
        await playwrightClient.InitializeAsync();
    }

    [AssemblyCleanup]
    public static async Task AssemblyCleanup()
    {
        await playwrightClient.DisposeAsync();
    }
}
```

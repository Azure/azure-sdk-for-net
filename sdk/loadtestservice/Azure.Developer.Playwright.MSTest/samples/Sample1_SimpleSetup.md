## Getting started with Azure Playwright MSTest SDK

Follow the steps listed in this [README](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/loadtestservice/Azure.Developer.Playwright.MSTest/README.md) to integrate your existing Playwright test suite with Playwright Workspaces.
This guide explains how to quickly get started with the Azure Playwright MSTest SDK.

### Minimal configuration

The below snippet demonstrates the minimal configuration required to setup Azure Playwright with an existing MSTest codebase.

```C# Snippet:MSTest_Sample1_SimpleSetup
using System.Threading.Tasks;
using Azure.Developer.Playwright.MSTest;
using Azure.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PlaywrightService.SampleTests; // Remember to change this as per your project namespace

public class PlaywrightServiceMSTestSetup
{
    private static PlaywrightServiceBrowserMSTest playwrightClient = null!;

    [AssemblyInitialize]
    public static async Task AssemblyInitialize(TestContext testContext)
    {
        playwrightClient = new PlaywrightServiceBrowserMSTest(context: testContext, credential: new DefaultAzureCredential());
        await playwrightClient.InitializeAsync();
    }

    [AssemblyCleanup]
    public static async Task AssemblyCleanup()
    {
        await playwrightClient.DisposeAsync();
    }
}
```

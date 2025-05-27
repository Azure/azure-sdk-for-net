// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#region Snippet:MSTest_Sample1_SimpleSetup
using System.Threading.Tasks;
using Azure.Developer.Playwright.MSTest;
using Azure.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

#if SNIPPET
namespace PlaywrightService.SampleTests; // Remember to change this as per your project namespace
#else
namespace PlaywrightTests.Sample1; // Remember to change this as per your project namespace
#endif

#if SNIPPET
public class PlaywrightServiceMSTestSetup
#else
public class Sample1ServiceSetup
#endif
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
#endregion

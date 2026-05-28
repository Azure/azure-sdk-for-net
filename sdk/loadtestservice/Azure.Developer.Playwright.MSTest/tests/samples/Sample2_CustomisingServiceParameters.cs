// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#region Snippet:MSTest_Sample2_CustomisingServiceParameters
using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Azure.Developer.Playwright.MSTest;
using Azure.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

#if SNIPPET
namespace PlaywrightService.SampleTests; // Remember to change this as per your project namespace
#else
namespace PlaywrightTests.Sample2; // Remember to change this as per your project namespace
#endif

[TestClass]
#if SNIPPET
public class PlaywrightServiceMSTestSetup
#else
public class Sample2ServiceSetup
#endif
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
#endregion

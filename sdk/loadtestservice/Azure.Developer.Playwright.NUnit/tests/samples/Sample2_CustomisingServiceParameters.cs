// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#region Snippet:NUnit_Sample2_CustomisingServiceParameters
using Azure.Developer.Playwright.NUnit;
using Azure.Developer.Playwright;
using Azure.Identity;
using System.Runtime.InteropServices;
using System;

#if SNIPPET
namespace PlaywrightService.SampleTests; // Remember to change this as per your project namespace
#else
namespace PlaywrightTests.Sample2; // Remember to change this as per your project namespace
#endif

[SetUpFixture]
#if SNIPPET
public class PlaywrightServiceNUnitSetup : PlaywrightServiceBrowserNUnit
#else
public class Sample2ServiceSetup : PlaywrightServiceBrowserNUnit
#endif
{
#if SNIPPET
    public PlaywrightServiceNUnitSetup() : base(
        credential: new ManagedIdentityCredential(),
        options: new PlaywrightServiceBrowserClientOptions()
        {
            OS = OSPlatform.Linux,
            ExposeNetwork = "<loopback>",
            RunName = "Playwright Workspaces Test Run",
        }
    )
    {
        // no-op
    }
#else
    public Sample2ServiceSetup() : base(
        credential: new ManagedIdentityCredential(),
        options: new PlaywrightServiceBrowserClientOptions()
        {
            OS = OSPlatform.Linux,
            ExposeNetwork = "<loopback>",
            RunName = "Playwright Workspaces Test Run",
        }
    )
    {
        // no-op
    }
#endif
}
#endregion

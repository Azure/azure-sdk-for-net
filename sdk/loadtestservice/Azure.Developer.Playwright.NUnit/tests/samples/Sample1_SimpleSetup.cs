// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#region Snippet:NUnit_Sample1_SimpleSetup
using Azure.Developer.Playwright.NUnit;
using Azure.Identity;

#if SNIPPET
namespace PlaywrightService.SampleTests; // Remember to change this as per your project namespace
#else
namespace PlaywrightTests.Sample1; // Remember to change this as per your project namespace
#endif

[SetUpFixture]
#if SNIPPET
public class PlaywrightServiceNUnitSetup : PlaywrightServiceBrowserNUnit
{
    public PlaywrightServiceNUnitSetup() : base(
        credential: new DefaultAzureCredential()
    )
    { }
}
#else
public class Sample1ServiceSetup : PlaywrightServiceBrowserNUnit
{
#if SNIPPET
    public PlaywrightServiceNUnitSetup() : base(
#else
    public Sample1ServiceSetup() : base(
#endif
        credential: new DefaultAzureCredential()
    )
    { }
}
#endif
#endregion

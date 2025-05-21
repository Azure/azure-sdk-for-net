// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#region Snippet:NUnit_Sample1_SimpleSetup
using Azure.Developer.Playwright.NUnit;

#if SNIPPET
namespace PlaywrightService.SampleTests; // Remember to change this as per your project namespace
#else
namespace PlaywrightTests.Sample1; // Remember to change this as per your project namespace
#endif

[SetUpFixture]
#if SNIPPET
public class PlaywrightServiceNUnitSetup : PlaywrightServiceBrowserNUnit { }
#else
public class Sample1ServiceSetup : PlaywrightServiceBrowserNUnit { }
#endif
#endregion

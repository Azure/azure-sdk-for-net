// // /*
// // ================================================================================
// // PLAYWRIGHT SERVICE GLOBAL SETUP (PlaywrightServiceSetup.cs)

// // This optional file demonstrates global setup/teardown for NUnit using
// // [SetUpFixture]. InitializeAsync is optional; the client can auto-initialize on
// // first GetConnectOptionsAsync<T>() call.

// // Pick ONE scenario: uncomment one block below.

// // SCENARIO A1: Use InitializeAsync in global setup (explicit)
// //     - Calls CreateInstance(...) and InitializeAsync() here.
// //     - Tests only call GetConnectOptionsAsync.

// // SCENARIO A2: Do NOT call InitializeAsync in global setup (auto-init)
// //     - Calls CreateInstance(...) only. First GetConnectOptionsAsync triggers init.

// // If you don't want a global setup at all, delete or exclude this file and use
// // one of the B1/B2 test-level patterns shown in ServicePageTest.
// // ================================================================================
// // */

// using NUnit.Framework;
// using Azure.Identity;
// using Azure.Developer.Playwright;
// using System.Runtime.InteropServices;
// using System;
// using Microsoft.Extensions.Logging;

// namespace PlaywrightTests;     // Remember to change this as per your project namespace


// [SetUpFixture]
// public class PlaywrightServiceNUnitSetup
// {
//     // SCENARIO A1: Explicit InitializeAsync in global setup
//     [OneTimeSetUp]
//     public async Task SetUp()
//     // public void SetUp()
//     {
//         ILogger logger = new NUnitLogger("AzurePlaywright");

//         var options = new PlaywrightServiceBrowserClientOptions
//         {
//             UseCloudHostedBrowsers = true,
//             OS = OSPlatform.Linux,
//             ExposeNetwork = "<loopback>",
//             RunName = "demo",
//             RunId = Guid.NewGuid().ToString(),
//             ServiceAuth = ServiceAuthType.EntraId,
//             Logger = logger
//         };

//         // Configure singleton with credential and options
//         PlaywrightServiceBrowserClient.CreateInstance(new DefaultAzureCredential(), options);

//         // For A1, do an explicit initialization. For A2, comment this out to rely on auto-init.
//         // await PlaywrightServiceBrowserClient.Instance.InitializeAsync();
//     }


//     [OneTimeTearDown]
//     public async Task GlobalTeardown()
//     {
//         await PlaywrightServiceBrowserClient.Instance.DisposeAsync();
//     }
// }


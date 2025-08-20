// /*
// ================================================================================
// HOW TO USE Azure.Developer.Playwright IN YOUR TESTS (ServicePageTest)

// InitializeAsync is optional. The client auto-initializes the first time you call
// PlaywrightServiceBrowserClient.Instance.GetConnectOptionsAsync<T>().

// Pick ONE scenario below and uncomment the block as needed.

// SCENARIO A: You ARE using PlaywrightServiceSetup.cs (global setup)
//     A1) With explicit InitializeAsync in setup:
//             - Setup file calls CreateInstance(...) and InitializeAsync().
//             - Test only fetches connect options.

//             // Example override for this file:
//             // public override async Task<(string, BrowserTypeConnectOptions?)?> ConnectOptionsAsync()
//             // {
//             //     var c = await PlaywrightServiceBrowserClient.Instance
//             //         .GetConnectOptionsAsync<BrowserTypeConnectOptions>();
//             //     return (c.WsEndpoint, c.Options);
//             // }

//     A2) Without InitializeAsync in setup (auto-init):
//             - Setup file calls CreateInstance(...) ONLY.
//             - First GetConnectOptionsAsync triggers initialization.

//             // Example override for this file (same as A1):
//             // public override async Task<(string, BrowserTypeConnectOptions?)?> ConnectOptionsAsync()
//             // {
//             //     var c = await PlaywrightServiceBrowserClient.Instance
//             //         .GetConnectOptionsAsync<BrowserTypeConnectOptions>();
//             //     return (c.WsEndpoint, c.Options);
//             // }

// SCENARIO B: You are NOT using PlaywrightServiceSetup.cs (no global setup)
//     B1) Initialize explicitly in test:
//             // public override async Task<(string, BrowserTypeConnectOptions?)?> ConnectOptionsAsync()
//             // {
//             //     PlaywrightServiceBrowserClient.CreateInstance(
//             //         credential: new DefaultAzureCredential(),
//             //         options: new PlaywrightServiceBrowserClientOptions
//             //         {
//             //             UseCloudHostedBrowsers = true,
//             //             OS = OSPlatform.Linux,
//             //             ExposeNetwork = "<loopback>",
//             //             RunName = "MyRun",
//             //             ServiceAuth = ServiceAuthType.EntraId,
//             //             Logger = new NUnitLogger("PlaywrightService")
//             //         });
//             //     await PlaywrightServiceBrowserClient.Instance.InitializeAsync();
//             //     var c = await PlaywrightServiceBrowserClient.Instance
//             //         .GetConnectOptionsAsync<BrowserTypeConnectOptions>();
//             //     return (c.WsEndpoint, c.Options);
//             // }

//     B2) Auto-initialize in test (no InitializeAsync):
//             // public override async Task<(string, BrowserTypeConnectOptions?)?> ConnectOptionsAsync()
//             // {
//             //     PlaywrightServiceBrowserClient.CreateInstance(
//             //         credential: new DefaultAzureCredential(),
//             //         options: new PlaywrightServiceBrowserClientOptions
//             //         {
//             //             UseCloudHostedBrowsers = true,
//             //             OS = OSPlatform.Linux,
//             //             ExposeNetwork = "<loopback>",
//             //             RunName = "MyRun",
//             //             ServiceAuth = ServiceAuthType.EntraId,
//             //             Logger = new NUnitLogger("PlaywrightService")
//             //         });
//             //     var c = await PlaywrightServiceBrowserClient.Instance
//             //         .GetConnectOptionsAsync<BrowserTypeConnectOptions>();
//             //     return (c.WsEndpoint, c.Options);
//             // }

// Notes:
// - If you never call CreateInstance(...), the singleton is created lazily with
//     default options when first accessed. Provide CreateInstance to customize.
// - Replace NUnitLogger with your ILogger if you are not using NUnit.
// ================================================================================
// */

using Microsoft.Playwright.NUnit;
using Azure.Developer.Playwright;
using Microsoft.Playwright;
using Azure.Identity;
using System;
using System.Runtime.InteropServices;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace PlaywrightTests;

public class ServicePageTest : PageTest
{


    public override async Task<(string, BrowserTypeConnectOptions?)?> ConnectOptionsAsync()
    {
    var options = new PlaywrightServiceBrowserClientOptions
            {
                UseCloudHostedBrowsers = true,
                OS = OSPlatform.Linux,
                ExposeNetwork = "<loopback>",
                RunName = "kashtest",
                ServiceAuth = ServiceAuthType.AccessToken,
                Logger = new NUnitLogger("PlaywrightService")
            };
        var connectOptions = await PlaywrightServiceBrowserClient.GetConnectOptionsAsync<BrowserTypeConnectOptions>(options);
        return (connectOptions.WsEndpoint, connectOptions.Options);
    }
}




//     // A1/A2 variant when using PlaywrightServiceSetup.cs (with or without InitializeAsync):
//     public override async Task<(string, BrowserTypeConnectOptions?)?> ConnectOptionsAsync()
//     {
//         var connectOptions = await PlaywrightServiceBrowserClient.Instance.GetConnectOptionsAsync<BrowserTypeConnectOptions>();
//         return (connectOptions.WsEndpoint, connectOptions.Options);
//     }
// }


// using Microsoft.Playwright.NUnit;
// using Azure.Developer.Playwright;
// using Microsoft.Playwright;
// using Azure.Identity;
// using System;
// using System.Runtime.InteropServices;
// using Microsoft.Extensions.Logging;
// using System.Threading.Tasks;
// using System.Threading;

// namespace PlaywrightTests;

// public class ServicePageTest : PageTest
// {
//     // One-time, thread-safe init across the test process.
//     private static readonly Lazy<Task> s_init = new(() =>
//     {
//         PlaywrightServiceBrowserClient.CreateInstance(
//             credential: new DefaultAzureCredential(),
//             options: new PlaywrightServiceBrowserClientOptions
//             {
//                 UseCloudHostedBrowsers = true,
//                 OS = OSPlatform.Linux,
//                 ExposeNetwork = "<loopback>",
//                 RunName = "hitest3",
//                 ServiceAuth = ServiceAuthType.EntraId,
//                 Logger = new NUnitLogger("PlaywrightService") // or any ILogger
//             });

//         // Optional: explicit init. Remove if you prefer auto-init on first GetConnectOptionsAsync.
//         // return PlaywrightServiceBrowserClient.Instance.InitializeAsync();
//         return Task.CompletedTask;
//     }, LazyThreadSafetyMode.ExecutionAndPublication);

//     public override async Task<(string, BrowserTypeConnectOptions?)?> ConnectOptionsAsync()
//     {
//         await s_init.Value; // runs once; subsequent calls await the same task

//         var connect = await PlaywrightServiceBrowserClient.Instance
//             .GetConnectOptionsAsync<BrowserTypeConnectOptions>();

//         return (connect.WsEndpoint, connect.Options);
//     }
// }

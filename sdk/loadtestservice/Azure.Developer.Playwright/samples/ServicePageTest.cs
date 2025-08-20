// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#region Snippet:ServicePageTest
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using Azure.Developer.Playwright;
using Azure.Identity;
using System.Runtime.InteropServices;

#if SNIPPET
public class ServicePageTest : PageTest
{
    public override async Task<(string, BrowserTypeConnectOptions?)?> ConnectOptionsAsync()
    {
        PlaywrightServiceBrowserClient.CreateInstance(
            credential: new DefaultAzureCredential(),
            options: new PlaywrightServiceBrowserClientOptions
            {
                UseCloudHostedBrowsers = true,
                OS = OSPlatform.Linux,
                ExposeNetwork = "<loopback>",
                RunName = "Playwright Service Test Run",
                ServiceAuth = ServiceAuthType.EntraId,
                Logger = new NUnitLogger("PlaywrightService")
            });
        var connectOptions = await PlaywrightServiceBrowserClient.Instance.GetConnectOptionsAsync<BrowserTypeConnectOptions>();
        return (connectOptions.WsEndpoint, connectOptions.Options);
    }
}
#else
namespace Azure.Developer.Playwright.Samples
{
    public class ServicePageTest : PageTest
    {
        public override async Task<(string, BrowserTypeConnectOptions?)?> ConnectOptionsAsync()
        {
            PlaywrightServiceBrowserClient.CreateInstance(
                credential: new DefaultAzureCredential(),
                options: new PlaywrightServiceBrowserClientOptions
                {
                    UseCloudHostedBrowsers = true,
                    OS = OSPlatform.Linux,
                    ExposeNetwork = "<loopback>",
                    RunName = "Playwright Service Test Run",
                    ServiceAuth = ServiceAuthType.EntraId,
                    Logger = new NUnitLogger("PlaywrightService")
                });
            var connectOptions = await PlaywrightServiceBrowserClient.Instance.GetConnectOptionsAsync<BrowserTypeConnectOptions>();
            return (connectOptions.WsEndpoint, connectOptions.Options);
        }
    }
}
#endif
#endregion

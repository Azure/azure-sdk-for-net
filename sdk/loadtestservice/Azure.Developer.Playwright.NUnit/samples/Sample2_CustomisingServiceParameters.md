## Learn about different available service parameters and how to use them

Follow the steps listed in this [README](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/loadtestservice/Azure.Developer.Playwright.NUnit/README.md) to integrate your existing Playwright test suite with Playwright Workspaces.
This guide explains the different options available to you in the Azure.Developer.Playwright.NUnit package and how to use them.

### Customising remote browser parameters

The snippet below shows how to customize remote browser parameters like OS, expose network settings, run ids and azure credential type.

```C# Snippet:NUnit_Sample2_CustomisingServiceParameters
using Azure.Developer.Playwright.NUnit;
using Azure.Developer.Playwright;
using Azure.Identity;
using System.Runtime.InteropServices;
using System;

namespace PlaywrightService.SampleTests; // Remember to change this as per your project namespace

[SetUpFixture]
public class PlaywrightServiceNUnitSetup : PlaywrightServiceBrowserNUnit
{
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
}
```

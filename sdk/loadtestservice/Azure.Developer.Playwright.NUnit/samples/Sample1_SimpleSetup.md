## Getting started with Azure Playwright NUnit SDK

Follow the steps listed in this [README](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/loadtestservice/Azure.Developer.Playwright.NUnit/README.md) to integrate your existing Playwright test suite with Playwright Workspaces.
This guide explains how to quickly get started with the Azure Playwright NUnit SDK.

### Minimal configuration

The below snippet demonstrates the minimal configuration required to setup Azure Playwright with an existing NUnit codebase.

```C# Snippet:NUnit_Sample1_SimpleSetup
using Azure.Developer.Playwright.NUnit;
using Azure.Identity;

namespace PlaywrightService.SampleTests; // Remember to change this as per your project namespace

[SetUpFixture]
public class PlaywrightServiceNUnitSetup : PlaywrightServiceBrowserNUnit
{
    public PlaywrightServiceNUnitSetup() : base(
        credential: new DefaultAzureCredential()
    )
    { }
}
```

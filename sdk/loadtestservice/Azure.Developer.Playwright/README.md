# Azure Playwright client library for .NET

Azure Playwright is a fully managed service that uses the cloud to enable you to run Playwright tests with much higher parallelization across different operating system-browser combinations simultaneously. This means faster test runs with broader scenario coverage, which helps speed up delivery of features without sacrificing quality. The service also enables you to publish test results and related artifacts to the service and view them in the service portal enabling faster and easier troubleshooting. With Azure Playwright, you can release features faster and more confidently.

## Getting started

### Install the package

Install the client library for .NET with [NuGet](https://www.nuget.org/):

```dotnetcli
dotnet add package Azure.Developer.Playwright --prerelease
```

### Authenticate the client

To learn more about options for Microsoft Entra Id authentication, refer to [Azure.Identity credentials](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/identity/Azure.Identity#credentials).

### Prerequisites

- An [Azure subscription](https://azure.microsoft.com/free/dotnet/)
- Your Azure account must be assigned the [Owner](https://learn.microsoft.com/azure/role-based-access-control/built-in-roles#owner), [Contributor](https://learn.microsoft.com/azure/role-based-access-control/built-in-roles#contributor), or one of the [classic administrator roles](https://learn.microsoft.com/azure/role-based-access-control/rbac-and-directory-admin-roles#classic-subscription-administrator-roles).

## Useful links
- [Quickstart: Run end-to-end tests at scale](https://aka.ms/pww/docs/quickstart)
- [Quickstart: Set up continuous end-to-end testing across different browsers and operating systems](https://aka.ms/pww/docs/ci)
- [Explore features and benefits](https://aka.ms/pww/docs/about)
- [Documentation](https://aka.ms/pww/docs)
- [Pricing](https://aka.ms/pww/docs/pricing)
- [Share feedback](https://aka.ms/pww/docs/feedback)

## Key concepts

Key concepts of the Azure Playwright SDK for .NET can be found [here](https://aka.ms/pww/docs/overview)

## Examples

Code samples for using this SDK can be found in the following locations
- [.NET Azure Playwright NUnit Library Code Samples](https://aka.ms/pww/samples)

### Use with NUnit (without the Azure.Developer.Playwright.NUnit package)

The core package is independent of the NUnit helper package. With NUnit, add Microsoft.Playwright and Microsoft.Playwright.NUnit, then:

1) Global setup/teardown with SetUpFixture — explicit initialization

```csharp
using NUnit.Framework;
using Azure.Developer.Playwright;
using Azure.Identity;

[SetUpFixture]
public class PlaywrightServiceSetup
{
    [OneTimeSetUp]
    public async Task SetUp()
    {
        var options = new PlaywrightServiceBrowserClientOptions
        {
            UseCloudHostedBrowsers = true
        };

        PlaywrightServiceBrowserClient.CreateInstance(new DefaultAzureCredential(), options);
        await PlaywrightServiceBrowserClient.Instance.InitializeAsync();
    }

    [OneTimeTearDown]
    public async Task GlobalTeardown()
    {
        await PlaywrightServiceBrowserClient.Instance.DisposeAsync();
    }
}
```

2) Global setup/teardown with SetUpFixture — implicit auto-initialization

```csharp
using NUnit.Framework;
using Azure.Developer.Playwright;
using Azure.Identity;

[SetUpFixture]
public class PlaywrightServiceSetup
{
    [OneTimeSetUp]
    public void SetUp()
    {
        // First GetConnectOptions call will auto-initialize the client.
        PlaywrightServiceBrowserClient.CreateInstance(
            new DefaultAzureCredential(),
            new PlaywrightServiceBrowserClientOptions { UseCloudHostedBrowsers = true });
    }

    [OneTimeTearDown]
    public async Task GlobalTeardown()
    {
        await PlaywrightServiceBrowserClient.Instance.DisposeAsync();
    }
}
```

3) Provide cloud connection options to Playwright

```csharp
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using Azure.Developer.Playwright;

public class ServicePageTest : PageTest
{
    public override async Task<(string, BrowserTypeConnectOptions?)?> ConnectOptionsAsync()
    {
        var client = PlaywrightServiceBrowserClient.Instance; // auto-initializes if not already
        var connect = await client.GetConnectOptionsAsync<BrowserTypeConnectOptions>();
        return (connect.WsEndpoint, connect.Options);
    }
}
```

Notes:
- InitializeAsync is optional because the client auto-initialize on the first getConnectOption call.
- Reference Microsoft.Playwright.NUnit 1.50.0 or newer.
- If using Microsoft Entra ID, pass a TokenCredential to CreateInstance (e.g., DefaultAzureCredential).

### Enable logging (optional)

You can pass an ILogger via options to surface client logs. 

#### NUnit-integrated logger

This logger writes to both console and NUnit's TestContext panes so all messages appear in test results:

```csharp
using System;
using Microsoft.Extensions.Logging;
using NUnit.Framework;

internal class NUnitLogger(string? category = null, LogLevel minLevel = LogLevel.Information) : ILogger
{
    private readonly string? _category = category;
    private readonly LogLevel _minLevel = minLevel;

    public bool IsEnabled(LogLevel logLevel) => logLevel >= _minLevel;
    public IDisposable BeginScope<TState>(TState state) where TState : notnull => NullScope.Instance;
    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
    {
        if (!IsEnabled(logLevel)) return;
        if (formatter == null) throw new ArgumentNullException(nameof(formatter));
        var msg = formatter(state, exception);
        if (exception != null) msg += "\n" + exception;

        var prefix = _category ?? "AzurePlaywright";
        
        var writer = (logLevel == LogLevel.Error || logLevel == LogLevel.Critical) 
            ? Console.Error : Console.Out;
        writer.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [{logLevel}] {prefix}: {msg}");

        try
        {
            string nunitLine = $"[{prefix}]: {msg}";
            if (logLevel == LogLevel.Debug)
                TestContext.Out.WriteLine(nunitLine);
            else if (logLevel == LogLevel.Error || logLevel == LogLevel.Critical)
                TestContext.Error.WriteLine(nunitLine);
            else
                TestContext.Progress.WriteLine(nunitLine);
        }
        catch
        {
          
        }
    }

    private sealed class NullScope : IDisposable
    {
        public static readonly NullScope Instance = new();
        public void Dispose() { }
    }
}
// Usage in SetUpFixture
ILogger logger = new NUnitLogger("AzurePlaywright");
var options = new PlaywrightServiceBrowserClientOptions 
{ 
    UseCloudHostedBrowsers = true,
    Logger = logger
};
PlaywrightServiceBrowserClient.CreateInstance(new DefaultAzureCredential(), options);
```


## Troubleshooting

-   File an issue via [GitHub Issues](https://github.com/Azure/azure-sdk-for-net/issues).
-   Check [previous questions](https://stackoverflow.com/questions/tagged/azure+.net) or ask new ones on Stack Overflow using Azure and .NET tags.

## Next steps

- Run tests in a [CI/CD pipeline.](https://aka.ms/pww/docs/configure-pipeline)

- Learn how to [manage access](https://aka.ms/pww/docs/manage-access) to the created workspace.

- Experiment with different number of workers to [determine the optimal configuration of your test suite](https://aka.ms/pww/docs/parallelism).

## Contributing

This project welcomes contributions and suggestions.  Most contributions require
you to agree to a Contributor License Agreement (CLA) declaring that you have
the right to, and actually do, grant us the rights to use your contribution. For
details, visit [cla.microsoft.com][cla].

This project has adopted the [Microsoft Open Source Code of Conduct][coc].
For more information see the [Code of Conduct FAQ][coc_faq] or contact
[opencode@microsoft.com][coc_contact] with any additional questions or comments.

![Impressions](https://azure-sdk-impressions.azurewebsites.net/api/impressions/azure-sdk-for-net/sdk/loadtestservice/Azure.Developer.Playwright/README.png)
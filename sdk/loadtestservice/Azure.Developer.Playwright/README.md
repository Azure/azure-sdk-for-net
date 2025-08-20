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

Code samples for using this SDK can be found in the following locations:
- [.NET Azure Playwright NUnit Library Code Samples](https://aka.ms/pww/samples)
- [SDK Samples folder](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/loadtestservice/Azure.Developer.Playwright/samples)

### Simplified Usage

You can write your Playwright test that will run on cloud-hosted browsers by extending the `PageTest` class and implementing the `ConnectOptionsAsync` method. This approach eliminates the need for separate setup files:

```C# Snippet:ServicePageTest
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using Azure.Developer.Playwright;
using Azure.Identity;
using System.Runtime.InteropServices;

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
```

Notes:
- The client auto-initializes on the first `GetConnectOptionsAsync` call.
- Reference Microsoft.Playwright.NUnit 1.50.0 or newer.
- No separate setup file is needed - everything is configured in the test class.



#### Enable logging using NUnit-integrated logger (optional)

This logger writes NUnit's TestContext panes so all messages appear in test results. Use this implementation as shown in the main example:

```C# Snippet:NUnitLogger
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
            // Ignore if TestContext is unavailable (e.g., teardown race)
        }
    }

    private sealed class NullScope : IDisposable
    {
        public static readonly NullScope Instance = new();
        public void Dispose() { }
    }
}
```

The logger is used by passing it in the `PlaywrightServiceBrowserClientOptions` as shown in the main example above.


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
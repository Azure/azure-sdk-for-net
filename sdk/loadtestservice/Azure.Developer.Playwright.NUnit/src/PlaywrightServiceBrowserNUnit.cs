// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Azure.Core;

namespace Azure.Developer.Playwright.NUnit;

/// <summary>
/// NUnit setup fixture to initialize Playwright Service.
/// </summary>
[SetUpFixture]
public class PlaywrightServiceBrowserNUnit : PlaywrightServiceBrowserClient
{
    private readonly PlaywrightServiceBrowserClientOptions _options;
    private static NUnitLogger nunitLogger { get; } = new();

    /// <summary>
    /// Initializes a new instance of the <see cref="PlaywrightServiceBrowserNUnit"/> class.
    /// </summary>
    public PlaywrightServiceBrowserNUnit() : this(
        options: new PlaywrightServiceBrowserClientOptions()
        {
            Logger = nunitLogger
        }
    )
    {
        // no-op
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="PlaywrightServiceBrowserNUnit"/> class.
    /// </summary>
    /// <param name="credential">The token credential.</param>
    public PlaywrightServiceBrowserNUnit(TokenCredential credential) : this(
        options: new PlaywrightServiceBrowserClientOptions()
        {
            Logger = nunitLogger
        },
        credential: credential
    )
    {
        // no-op
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="PlaywrightServiceBrowserNUnit"/> class.
    /// </summary>
    /// <param name="options">Client options for PlaywrightBrowserClient.</param>
    public PlaywrightServiceBrowserNUnit(PlaywrightServiceBrowserClientOptions options) : base(
        options: options
    )
    {
        _options = options;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="PlaywrightServiceBrowserNUnit"/> class.
    /// </summary>
    /// <param name="credential">The token credential.</param>
    /// <param name="options">Client options for PlaywrightBrowserClient.</param>
    public PlaywrightServiceBrowserNUnit(TokenCredential credential, PlaywrightServiceBrowserClientOptions options) : base(
        credential: credential,
        options: InjectNUnitLogger(options)
    )
    {
        _options = options;
    }

    /// <summary>
    /// Setup the resources utilized by Playwright Browser client.
    /// </summary>
    /// <returns></returns>
    [OneTimeSetUp]
    public async Task SetupAsync()
    {
        if (!_options.UseCloudHostedBrowsers)
            return;
        nunitLogger.LogInformation("\nRunning tests using Azure Playwright service.\n");

        await InitializeAsync().ConfigureAwait(false);
    }

    /// <summary>
    /// Tear down resources utilized by Playwright Browser client.
    /// </summary>
    [OneTimeTearDown]
    public async Task TearDownAsync()
    {
        await base.DisposeAsync().ConfigureAwait(false);
    }

    private static PlaywrightServiceBrowserClientOptions InjectNUnitLogger(PlaywrightServiceBrowserClientOptions options)
    {
        options.Logger ??= nunitLogger;
        return options;
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Azure.Developer.Playwright.MSTest;

/// <summary>
/// MSTest setup fixture to initialize Playwright Workspaces.
/// </summary>
public class PlaywrightServiceBrowserMSTest : PlaywrightServiceBrowserClient
{
    private readonly PlaywrightServiceBrowserClientOptions _options;

    /// <summary>
    /// Initializes a new instance of the <see cref="PlaywrightServiceBrowserMSTest"/> class.
    /// </summary>
    public PlaywrightServiceBrowserMSTest() : this(
        options: new PlaywrightServiceBrowserClientOptions()
    )
    {
        // no-op
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="PlaywrightServiceBrowserMSTest"/> class.
    /// </summary>
    /// <param name="context">MSTest test context</param>
    public PlaywrightServiceBrowserMSTest(TestContext context) : this(
        options: new PlaywrightServiceBrowserClientOptions(),
        context: context
    )
    {
        // no-op
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="PlaywrightServiceBrowserMSTest"/> class.
    /// </summary>
    /// <param name="credential">The token credential.</param>
    public PlaywrightServiceBrowserMSTest(TokenCredential credential) : this(
        options: new PlaywrightServiceBrowserClientOptions(),
        credential: credential
    )
    {
        // no-op
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="PlaywrightServiceBrowserMSTest"/> class.
    /// </summary>
    /// <param name="credential">The token credential.</param>
    /// <param name="context">MSTest test context</param>
    public PlaywrightServiceBrowserMSTest(TokenCredential credential, TestContext context) : this(
        options: new PlaywrightServiceBrowserClientOptions(),
        credential: credential,
        context: context
    )
    {
        // no-op
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="PlaywrightServiceBrowserMSTest"/> class.
    /// </summary>
    /// <param name="options">Client options for PlaywrightBrowserClient.</param>
    public PlaywrightServiceBrowserMSTest(PlaywrightServiceBrowserClientOptions options) : base(
        options: options
    )
    {
        _options = options;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="PlaywrightServiceBrowserMSTest"/> class.
    /// </summary>
    /// <param name="options">Client options for PlaywrightBrowserClient.</param>
    /// <param name="context">MSTest test context</param>
    public PlaywrightServiceBrowserMSTest(TestContext context, PlaywrightServiceBrowserClientOptions options) : base(
        options: InjectMSTestLogger(options, context)
    )
    {
        _options = options;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="PlaywrightServiceBrowserMSTest"/> class.
    /// </summary>
    /// <param name="credential">The token credential.</param>
    /// <param name="options">Client options for PlaywrightBrowserClient.</param>
    public PlaywrightServiceBrowserMSTest(TokenCredential credential, PlaywrightServiceBrowserClientOptions options) : base(
        credential: credential,
        options: options
    )
    {
        _options = options;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="PlaywrightServiceBrowserMSTest"/> class.
    /// </summary>
    /// <param name="credential">The token credential.</param>
    /// <param name="options">Client options for PlaywrightBrowserClient.</param>
    /// <param name="context">MSTest test context</param>
    public PlaywrightServiceBrowserMSTest(TokenCredential credential, TestContext context, PlaywrightServiceBrowserClientOptions options) : base(
        credential: credential,
        options: InjectMSTestLogger(options, context)
    )
    {
        _options = options;
    }

    /// <summary>
    /// Setup the resources utilized by Playwright Browser client.
    /// </summary>
    public override async Task InitializeAsync(CancellationToken cancellationToken = default)
    {
        await base.InitializeAsync(cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Tear down resources utilized by Playwright Browser client.
    /// </summary>
    public override async Task DisposeAsync()
    {
        await base.DisposeAsync().ConfigureAwait(false);
    }
    private static PlaywrightServiceBrowserClientOptions InjectMSTestLogger(PlaywrightServiceBrowserClientOptions options, TestContext testContext)
    {
        options.Logger ??= new MSTestLogger(testContext);
        return options;
    }
}

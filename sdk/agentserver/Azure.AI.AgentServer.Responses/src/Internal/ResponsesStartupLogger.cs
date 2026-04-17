// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Core;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Azure.AI.AgentServer.Responses.Internal;

/// <summary>
/// Logs Responses protocol configuration at application startup.
/// </summary>
internal sealed class ResponsesStartupLogger : IHostedService
{
    private readonly ILogger<ResponsesStartupLogger> _logger;
    private readonly IOptions<ResponsesServerOptions> _options;
    private readonly IOptions<InMemoryProviderOptions> _providerOptions;

    public ResponsesStartupLogger(
        ILogger<ResponsesStartupLogger> logger,
        IOptions<ResponsesServerOptions> options,
        IOptions<InMemoryProviderOptions> providerOptions)
    {
        _logger = logger;
        _options = options;
        _providerOptions = providerOptions;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        var opts = _options.Value;
        var providerOpts = _providerOptions.Value;

        _logger.LogInformation(
            "Responses protocol configuration: StorageProvider={StorageProvider} DefaultModel={DefaultModel} " +
            "DefaultFetchHistoryCount={DefaultFetchHistoryCount} EventStreamTtl={EventStreamTtl}",
            FoundryEnvironment.IsHosted ? "FoundryStorage" : "InMemory",
            opts.DefaultModel ?? "(not set)",
            opts.DefaultFetchHistoryCount,
            providerOpts.EventStreamTtl);

        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}

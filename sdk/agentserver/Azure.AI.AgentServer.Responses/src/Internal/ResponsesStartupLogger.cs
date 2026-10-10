// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Core.Tasks;
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
    private readonly IOptions<ResilientTaskOptions> _resilientTaskOptions;
    private readonly ResponsesProvider _provider;

    public ResponsesStartupLogger(
        ILogger<ResponsesStartupLogger> logger,
        IOptions<ResponsesServerOptions> options,
        IOptions<InMemoryProviderOptions> providerOptions,
        IOptions<ResilientTaskOptions> resilientTaskOptions,
        ResponsesProvider provider)
    {
        _logger = logger;
        _options = options;
        _providerOptions = providerOptions;
        _resilientTaskOptions = resilientTaskOptions;
        _provider = provider;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        var opts = _options.Value;
        var providerOpts = _providerOptions.Value;

        _logger.LogInformation(
            "Responses protocol configuration: StorageProvider={StorageProvider} DefaultModel={DefaultModel} " +
            "DefaultFetchHistoryCount={DefaultFetchHistoryCount} EventStreamTtl={EventStreamTtl}",
            _provider.GetType().Name,
            opts.DefaultModel ?? "(not set)",
            opts.DefaultFetchHistoryCount,
            providerOpts.EventStreamTtl);

        if (_resilientTaskOptions.Value.Enabled)
        {
            _logger.LogInformation(
                "Responses resilience is enabled; stored responses use durable tasks and startup recovery.");
        }
        else
        {
            _logger.LogWarning(
                "Responses resilience is disabled; stored responses run in-process and are not recovered after an ungraceful crash. " +
                "Call SetResilientTasksEnabled() or enable ResilientBackground to opt in.");
        }

        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace Azure.AI.AgentServer.Responses.Internal.Resilience;

/// <summary>
/// Captures the root <see cref="IServiceProvider"/> for the resilient response task handlers.
/// </summary>
/// <remarks>
/// Core invokes a resilient-task body as <c>(ctx, ct)</c> and does not inject DI into it.
/// <see cref="ResponsesResilientTaskHandler.RunTurnAsync"/> nonetheless needs the root provider to open
/// a per-turn <see cref="Microsoft.Extensions.DependencyInjection.IServiceScope"/> — including on the
/// crash-recovery path, which runs under the Core recovery scan where no request scope exists. This
/// hosted service captures the root provider at host startup (its factory receives it), so the task
/// registration closure can hand it to the handler. It is registered ahead of the Core resilient-task
/// engine so the provider is captured before any task body runs.
/// </remarks>
internal sealed class ResponsesResilientTaskRootProvider : IHostedService
{
    private IServiceProvider? _rootProvider;

    /// <summary>Gets the captured root provider, or throws if the host has not started yet.</summary>
    /// <returns>The root service provider.</returns>
    public IServiceProvider Require()
        => _rootProvider ?? throw new InvalidOperationException(
            "The resilient response task handler ran before the root service provider was captured at host startup.");

    /// <summary>Records the root provider. Invoked from the hosted-service factory at host startup.</summary>
    /// <param name="rootProvider">The root service provider.</param>
    public void Attach(IServiceProvider rootProvider) => _rootProvider = rootProvider;

    Task IHostedService.StartAsync(CancellationToken cancellationToken) => Task.CompletedTask;

    Task IHostedService.StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}

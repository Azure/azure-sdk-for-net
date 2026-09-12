// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;

namespace Azure.AI.AgentServer.Core.Streaming;

internal enum AgentEventStreamRegistrationPriority
{
    ProtocolDefault,
    Application,
}

internal sealed record AgentEventStreamRegistrationRequest(
    string Source,
    AgentEventStreamRegistrationPriority Priority,
    Func<IServiceProvider, AgentEventStreamConfiguration?> ConfigurationFactory);

internal sealed class AgentEventStreamRegistrationState
{
    private readonly List<AgentEventStreamRegistrationRequest> _requests = new();

    public void Add(AgentEventStreamRegistrationRequest request) => _requests.Add(request);

    public AgentEventStreamOptions ResolveOptions(IServiceProvider serviceProvider)
    {
        if (_requests.Count == 0)
        {
            return new AgentEventStreamOptions();
        }

        MaterializedRequest[] materialized = _requests
            .Select(request => new MaterializedRequest(
                request.Source,
                request.Priority,
                request.ConfigurationFactory(serviceProvider)))
            .Where(request => request.Configuration is not null)
            .ToArray();
        if (materialized.Length == 0)
        {
            return new AgentEventStreamOptions();
        }

        AgentEventStreamRegistrationPriority selectedPriority =
            materialized.Max(request => request.Priority);
        MaterializedRequest[] selected =
            materialized.Where(request => request.Priority == selectedPriority).ToArray();
        MaterializedRequest first = selected[0];
        MaterializedRequest? conflict =
            selected.FirstOrDefault(request =>
                !request.Configuration!.Equals(first.Configuration));

        if (conflict is not null)
        {
            throw new InvalidOperationException(
                $"Conflicting AgentEventStream backing selections at " +
                $"'{FormatPriority(selectedPriority)}' precedence: " +
                $"'{first.Source}' requested {first.Configuration}, while " +
                $"'{conflict.Source}' requested {conflict.Configuration}. " +
                "Configure one explicit application backing to override protocol defaults.");
        }

        return new AgentEventStreamOptions(first.Configuration!);
    }

    private static string FormatPriority(AgentEventStreamRegistrationPriority priority)
        => priority switch
        {
            AgentEventStreamRegistrationPriority.Application => "application",
            AgentEventStreamRegistrationPriority.ProtocolDefault => "protocol-default",
            _ => priority.ToString(),
        };

    private sealed record MaterializedRequest(
        string Source,
        AgentEventStreamRegistrationPriority Priority,
        AgentEventStreamConfiguration? Configuration);
}

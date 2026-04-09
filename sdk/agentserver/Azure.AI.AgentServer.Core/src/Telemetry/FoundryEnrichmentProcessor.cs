// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;
using OpenTelemetry;

namespace Azure.AI.AgentServer.Core.Internal;

/// <summary>
/// An OpenTelemetry span processor that enriches every span with Foundry
/// agent identity and project attributes. This processor is automatically
/// registered by <see cref="OpenTelemetryExtensions.AddAgentHostTelemetry"/>
/// so that all protocol packages receive the enrichment without additional
/// configuration.
/// </summary>
/// <remarks>
/// The processor reads <c>FOUNDRY_AGENT_NAME</c>, <c>FOUNDRY_AGENT_VERSION</c>,
/// and <c>FOUNDRY_PROJECT_ARM_ID</c> once at construction time and stamps
/// them onto every started <see cref="Activity"/>.
/// </remarks>
internal sealed class FoundryEnrichmentProcessor : BaseProcessor<Activity>
{
    private readonly string? _agentName;
    private readonly string? _agentVersion;
    private readonly string? _agentId;
    private readonly string? _projectId;

    public FoundryEnrichmentProcessor()
    {
        _agentName = FoundryEnvironment.AgentName;
        _agentVersion = FoundryEnvironment.AgentVersion;
        _projectId = FoundryEnvironment.ProjectArmId;

        _agentId = _agentName is not null && _agentVersion is not null
            ? $"{_agentName}:{_agentVersion}"
            : _agentName;
    }

    /// <inheritdoc/>
    public override void OnStart(Activity activity)
    {
        if (_projectId is not null)
        {
            activity.SetTag("microsoft.foundry.project.id", _projectId);
        }
    }

    /// <inheritdoc/>
    /// <remarks>
    /// Agent identity tags are set in <c>OnEnd</c> rather than <c>OnStart</c>
    /// so that they take precedence over any values an underlying framework
    /// (e.g. the OpenAI SDK) may have stamped during the span's lifetime.
    /// </remarks>
    public override void OnEnd(Activity activity)
    {
        if (_agentName is not null)
        {
            activity.SetTag("gen_ai.agent.name", _agentName);
        }

        if (_agentVersion is not null)
        {
            activity.SetTag("gen_ai.agent.version", _agentVersion);
        }

        if (_agentId is not null)
        {
            activity.SetTag("gen_ai.agent.id", _agentId);
        }
    }
}

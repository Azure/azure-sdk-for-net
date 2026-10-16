// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Diagnostics;
using Azure.AI.Projects.Agents.Telemetry;

namespace Azure.AI.Projects.Agents;

// Generated clients resolve these package-local adapters instead of the shared SCM types.
// Only VoiceAgents mutations opt into GenAI scopes; all other scopes retain SCM behavior.
internal sealed class ClientDiagnostics
{
    private readonly System.ClientModel.Primitives.ClientDiagnostics _diagnostics;
    private readonly Uri _voiceAgentEndpoint;

    internal bool IsDistributedTracingEnabled { get; }

    public ClientDiagnostics(ClientPipelineOptions options, bool suppressNestedClientActivities = true)
    {
        _diagnostics = new(options, suppressNestedClientActivities);
        IsDistributedTracingEnabled = options.EnableDistributedTracing != false;
    }

    private ClientDiagnostics(ClientDiagnostics diagnostics, Uri voiceAgentEndpoint)
    {
        _diagnostics = diagnostics._diagnostics;
        IsDistributedTracingEnabled = diagnostics.IsDistributedTracingEnabled;
        _voiceAgentEndpoint = voiceAgentEndpoint;
    }

    internal ClientDiagnostics ForVoiceAgents(Uri endpoint) => new(this, endpoint);

    public DiagnosticScope CreateScope(string name, ActivityKind kind = ActivityKind.Internal)
    {
        string operationName = _voiceAgentEndpoint == null ? null : name switch
        {
            "AgentAdministrationClient.GenerateAgent" => "create_agent",
            "BetaVoiceAgentsConversations.DeleteAgentConversation" => "voice_agents.conversations.delete",
            "BetaVoiceAgentsTelephony.CreateTelephonyCallJob" => "voice_agents.telephony.create_call_job",
            "BetaVoiceAgentsTelephony.CancelTelephonyCallJob" => "voice_agents.telephony.cancel_call_job",
            "BetaVoiceAgentsTelephony.ReplaceTelephonyTransferTargets" => "voice_agents.telephony.replace_transfer_targets",
            "BetaVoiceAgentsTelephony.EndTelephonyCall" => "voice_agents.telephony.end_call",
            "BetaVoiceAgentsTelephony.TransferTelephonyCall" => "voice_agents.telephony.transfer_call",
            "BetaVoiceAgentsTelephony.CreateTelephonyBinding" => "voice_agents.telephony.create_binding",
            "BetaVoiceAgentsTelephony.UpdateTelephonyBinding" => "voice_agents.telephony.update_binding",
            "BetaVoiceAgentsTelephony.DeleteTelephonyBinding" => "voice_agents.telephony.delete_binding",
            _ => null
        };

        if (operationName != null && IsDistributedTracingEnabled && OpenTelemetryScope.IsEnabled)
        {
            OpenTelemetryScope voiceScope = OpenTelemetryScope.StartVoiceAgentOperation(_voiceAgentEndpoint, operationName);
            if (voiceScope != null)
            {
                return new DiagnosticScope(voiceScope);
            }
        }

        return new DiagnosticScope(_diagnostics.CreateScope(name, kind));
    }
}

internal readonly struct DiagnosticScope : IDisposable
{
    private readonly System.ClientModel.Primitives.DiagnosticScope _diagnosticScope;
    private readonly OpenTelemetryScope _voiceAgentScope;

    internal DiagnosticScope(System.ClientModel.Primitives.DiagnosticScope diagnosticScope)
    {
        _diagnosticScope = diagnosticScope;
        _voiceAgentScope = null;
    }

    internal DiagnosticScope(OpenTelemetryScope voiceAgentScope)
    {
        _diagnosticScope = default;
        _voiceAgentScope = voiceAgentScope;
    }

    public void Start() => _diagnosticScope.Start();

    public void Failed(Exception exception)
    {
        if (_voiceAgentScope != null)
        {
            _voiceAgentScope.RecordError(exception);
        }
        else
        {
            _diagnosticScope.Failed(exception);
        }
    }

    public void Dispose()
    {
        _voiceAgentScope?.Dispose();
        _diagnosticScope.Dispose();
    }
}

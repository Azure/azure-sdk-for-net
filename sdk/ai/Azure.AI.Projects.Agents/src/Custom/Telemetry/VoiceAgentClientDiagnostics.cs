// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Threading.Tasks;
using Azure.AI.Projects.Agents.Telemetry;

namespace Azure.AI.Projects.Agents;

// Generated operations keep the SCM diagnostics types. Custom voice mutations explicitly
// select the GenAI adapter so regeneration cannot change their type binding.
internal sealed class VoiceAgentClientDiagnostics : ClientDiagnostics
{
    private readonly Uri _voiceAgentEndpoint;

    internal bool IsDistributedTracingEnabled { get; }

    internal VoiceAgentClientDiagnostics(ClientPipelineOptions options, Uri endpoint)
        : base(options, suppressNestedClientActivities: true)
    {
        IsDistributedTracingEnabled = options.EnableDistributedTracing != false;
        _voiceAgentEndpoint = endpoint;
    }

    internal static ClientResult ProcessMessage(ClientDiagnostics diagnostics, ClientPipeline pipeline, Func<PipelineMessage> createMessage, string scopeName, RequestOptions options)
    {
        using VoiceAgentDiagnosticScope scope = CreateVoiceAgentScope(diagnostics, scopeName);
        scope.Start();
        try
        {
            using PipelineMessage message = createMessage();
            return ClientResult.FromResponse(pipeline.ProcessMessage(message, options));
        }
        catch (Exception exception)
        {
            scope.Failed(exception);
            throw;
        }
    }

    internal static async Task<ClientResult> ProcessMessageAsync(ClientDiagnostics diagnostics, ClientPipeline pipeline, Func<PipelineMessage> createMessage, string scopeName, RequestOptions options)
    {
        using VoiceAgentDiagnosticScope scope = CreateVoiceAgentScope(diagnostics, scopeName);
        scope.Start();
        try
        {
            using PipelineMessage message = createMessage();
            return ClientResult.FromResponse(await pipeline.ProcessMessageAsync(message, options).ConfigureAwait(false));
        }
        catch (Exception exception)
        {
            scope.Failed(exception);
            throw;
        }
    }

    private static VoiceAgentDiagnosticScope CreateVoiceAgentScope(ClientDiagnostics diagnostics, string name)
    {
        string operationName = name switch
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

        if (operationName != null && diagnostics is VoiceAgentClientDiagnostics { IsDistributedTracingEnabled: true } voiceDiagnostics && OpenTelemetryScope.IsEnabled)
        {
            OpenTelemetryScope voiceScope = OpenTelemetryScope.StartVoiceAgentOperation(voiceDiagnostics._voiceAgentEndpoint, operationName);
            if (voiceScope != null)
            {
                return new VoiceAgentDiagnosticScope(voiceScope);
            }
        }

        return new VoiceAgentDiagnosticScope(diagnostics.CreateScope(name));
    }
}

internal readonly struct VoiceAgentDiagnosticScope : IDisposable
{
    private readonly DiagnosticScope _diagnosticScope;
    private readonly OpenTelemetryScope _voiceAgentScope;

    internal VoiceAgentDiagnosticScope(DiagnosticScope diagnosticScope)
    {
        _diagnosticScope = diagnosticScope;
        _voiceAgentScope = null;
    }

    internal VoiceAgentDiagnosticScope(OpenTelemetryScope voiceAgentScope)
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

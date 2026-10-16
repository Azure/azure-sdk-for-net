// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel;
using System.ClientModel.Primitives;
using System.Threading.Tasks;

namespace Azure.AI.Projects.Agents;

public partial class BetaVoiceAgentsTelephony
{
    internal virtual ClientResult CreateTelephonyBinding(string agentName, BinaryContent content, string foundryFeatures = default, RequestOptions options = null)
    {
        return VoiceAgentClientDiagnostics.ProcessMessage(ClientDiagnostics, Pipeline,
            () => CreateCreateTelephonyBindingRequest(agentName, content, foundryFeatures, options),
            "BetaVoiceAgentsTelephony.CreateTelephonyBinding", options);
    }

    internal virtual Task<ClientResult> CreateTelephonyBindingAsync(string agentName, BinaryContent content, string foundryFeatures = default, RequestOptions options = null)
    {
        return VoiceAgentClientDiagnostics.ProcessMessageAsync(ClientDiagnostics, Pipeline,
            () => CreateCreateTelephonyBindingRequest(agentName, content, foundryFeatures, options),
            "BetaVoiceAgentsTelephony.CreateTelephonyBinding", options);
    }

    internal virtual ClientResult UpdateTelephonyBinding(string agentName, string bindingId, string ifMatch, BinaryContent content, string foundryFeatures = default, RequestOptions options = null)
    {
        return VoiceAgentClientDiagnostics.ProcessMessage(ClientDiagnostics, Pipeline,
            () => CreateUpdateTelephonyBindingRequest(agentName, bindingId, ifMatch, content, foundryFeatures, options),
            "BetaVoiceAgentsTelephony.UpdateTelephonyBinding", options);
    }

    internal virtual Task<ClientResult> UpdateTelephonyBindingAsync(string agentName, string bindingId, string ifMatch, BinaryContent content, string foundryFeatures = default, RequestOptions options = null)
    {
        return VoiceAgentClientDiagnostics.ProcessMessageAsync(ClientDiagnostics, Pipeline,
            () => CreateUpdateTelephonyBindingRequest(agentName, bindingId, ifMatch, content, foundryFeatures, options),
            "BetaVoiceAgentsTelephony.UpdateTelephonyBinding", options);
    }

    internal virtual ClientResult DeleteTelephonyBinding(string agentName, string bindingId, string ifMatch, string foundryFeatures, RequestOptions options)
    {
        return VoiceAgentClientDiagnostics.ProcessMessage(ClientDiagnostics, Pipeline,
            () => CreateDeleteTelephonyBindingRequest(agentName, bindingId, ifMatch, foundryFeatures, options),
            "BetaVoiceAgentsTelephony.DeleteTelephonyBinding", options);
    }

    internal virtual Task<ClientResult> DeleteTelephonyBindingAsync(string agentName, string bindingId, string ifMatch, string foundryFeatures, RequestOptions options)
    {
        return VoiceAgentClientDiagnostics.ProcessMessageAsync(ClientDiagnostics, Pipeline,
            () => CreateDeleteTelephonyBindingRequest(agentName, bindingId, ifMatch, foundryFeatures, options),
            "BetaVoiceAgentsTelephony.DeleteTelephonyBinding", options);
    }

    internal virtual ClientResult TransferTelephonyCall(string agentName, string callId, BinaryContent content, string foundryFeatures = default, RequestOptions options = null)
    {
        return VoiceAgentClientDiagnostics.ProcessMessage(ClientDiagnostics, Pipeline,
            () => CreateTransferTelephonyCallRequest(agentName, callId, content, foundryFeatures, options),
            "BetaVoiceAgentsTelephony.TransferTelephonyCall", options);
    }

    internal virtual Task<ClientResult> TransferTelephonyCallAsync(string agentName, string callId, BinaryContent content, string foundryFeatures = default, RequestOptions options = null)
    {
        return VoiceAgentClientDiagnostics.ProcessMessageAsync(ClientDiagnostics, Pipeline,
            () => CreateTransferTelephonyCallRequest(agentName, callId, content, foundryFeatures, options),
            "BetaVoiceAgentsTelephony.TransferTelephonyCall", options);
    }

    internal virtual ClientResult EndTelephonyCall(string agentName, string callId, string foundryFeatures, RequestOptions options)
    {
        return VoiceAgentClientDiagnostics.ProcessMessage(ClientDiagnostics, Pipeline,
            () => CreateEndTelephonyCallRequest(agentName, callId, foundryFeatures, options),
            "BetaVoiceAgentsTelephony.EndTelephonyCall", options);
    }

    internal virtual Task<ClientResult> EndTelephonyCallAsync(string agentName, string callId, string foundryFeatures, RequestOptions options)
    {
        return VoiceAgentClientDiagnostics.ProcessMessageAsync(ClientDiagnostics, Pipeline,
            () => CreateEndTelephonyCallRequest(agentName, callId, foundryFeatures, options),
            "BetaVoiceAgentsTelephony.EndTelephonyCall", options);
    }

    internal virtual ClientResult ReplaceTelephonyTransferTargets(string agentName, string ifMatch, BinaryContent content, string foundryFeatures = default, RequestOptions options = null)
    {
        return VoiceAgentClientDiagnostics.ProcessMessage(ClientDiagnostics, Pipeline,
            () => CreateReplaceTelephonyTransferTargetsRequest(agentName, ifMatch, content, foundryFeatures, options),
            "BetaVoiceAgentsTelephony.ReplaceTelephonyTransferTargets", options);
    }

    internal virtual Task<ClientResult> ReplaceTelephonyTransferTargetsAsync(string agentName, string ifMatch, BinaryContent content, string foundryFeatures = default, RequestOptions options = null)
    {
        return VoiceAgentClientDiagnostics.ProcessMessageAsync(ClientDiagnostics, Pipeline,
            () => CreateReplaceTelephonyTransferTargetsRequest(agentName, ifMatch, content, foundryFeatures, options),
            "BetaVoiceAgentsTelephony.ReplaceTelephonyTransferTargets", options);
    }

    internal virtual ClientResult CreateTelephonyCallJob(string agentName, string idempotencyKey, BinaryContent content, string foundryFeatures = default, RequestOptions options = null)
    {
        return VoiceAgentClientDiagnostics.ProcessMessage(ClientDiagnostics, Pipeline,
            () => CreateCreateTelephonyCallJobRequest(agentName, idempotencyKey, content, foundryFeatures, options),
            "BetaVoiceAgentsTelephony.CreateTelephonyCallJob", options);
    }

    internal virtual Task<ClientResult> CreateTelephonyCallJobAsync(string agentName, string idempotencyKey, BinaryContent content, string foundryFeatures = default, RequestOptions options = null)
    {
        return VoiceAgentClientDiagnostics.ProcessMessageAsync(ClientDiagnostics, Pipeline,
            () => CreateCreateTelephonyCallJobRequest(agentName, idempotencyKey, content, foundryFeatures, options),
            "BetaVoiceAgentsTelephony.CreateTelephonyCallJob", options);
    }

    internal virtual ClientResult CancelTelephonyCallJob(string agentName, string callJobId, string ifMatch, string foundryFeatures, RequestOptions options)
    {
        return VoiceAgentClientDiagnostics.ProcessMessage(ClientDiagnostics, Pipeline,
            () => CreateCancelTelephonyCallJobRequest(agentName, callJobId, ifMatch, foundryFeatures, options),
            "BetaVoiceAgentsTelephony.CancelTelephonyCallJob", options);
    }

    internal virtual Task<ClientResult> CancelTelephonyCallJobAsync(string agentName, string callJobId, string ifMatch, string foundryFeatures, RequestOptions options)
    {
        return VoiceAgentClientDiagnostics.ProcessMessageAsync(ClientDiagnostics, Pipeline,
            () => CreateCancelTelephonyCallJobRequest(agentName, callJobId, ifMatch, foundryFeatures, options),
            "BetaVoiceAgentsTelephony.CancelTelephonyCallJob", options);
    }
}

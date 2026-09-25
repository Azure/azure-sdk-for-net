// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable SA1402 // File may only contain a single type - intentional: model accessibility markers alongside the sub-client they support

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.AI.Projects.Agents
{
    // These model types are only reachable through AgentTelephony operations the TypeSpec
    // source marks Access.internal (see client.tsp's "AgentTelephony sub-client" section), so
    // the generator emits them internal too. BetaVoiceAgentsTelephony re-exposes the operations
    // themselves publicly below (with simplified signatures); these types must be re-exposed
    // to match, or the public methods that return/accept them would be inaccessible. No
    // [CodeGenType] is needed since the name already matches the generated type -- the generator
    // detects this same-named Custom declaration and adjusts its own generated declaration's
    // accessibility to match.
    [Experimental("AAIP001")]
    public abstract partial class TelephonyBinding { }

    [Experimental("AAIP001")]
    public abstract partial class CreateTelephonyBindingContent { }

    [Experimental("AAIP001")]
    public partial class TelephonyCallJob { }

    [Experimental("AAIP001")]
    public partial class CreateTelephonyCallJobContent { }

    [Experimental("AAIP001")]
    public partial class TelephonyCallRecord { }

    [Experimental("AAIP001")]
    public partial class TelephonyTransferTargets { }

    [Experimental("AAIP001")]
    public partial class TelephonyTransferTarget { }

    [Experimental("AAIP001")]
    public partial class TelephonyCallSummary { }

    [Experimental("AAIP001")]
    public readonly partial struct TelephonyCallStatus { }
}

namespace Azure.AI.Projects.Agents._Beta.VoiceAgents
{
// The TypeSpec source marks most AgentTelephony operations Access.internal (only the
// list-bindings operation is public), presumably because they're still being finalized for
// public consumption. The generator therefore emits their strongly-typed convenience overloads
// as `internal`. This file re-exposes them publicly with simplified signatures (omitting the
// foundryFeatures opt-in, matching the pattern used elsewhere for this preview surface), mirroring
// what main's BetaVoiceAgentTelephony.cs customization did before the namespace-leak fix moved
// this sub-client from the Azure.AI.Projects.Agents namespace into Azure.AI.Projects.Agents._Beta.VoiceAgents.
public partial class BetaVoiceAgentsTelephony
{
    /// <summary> Creates a telephony binding for the voice agent named in the path. </summary>
    /// <param name="agentName"> The name of the voice agent that owns the binding. </param>
    /// <param name="telephonyBinding"> The provider-specific binding to create. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="agentName"/> or <paramref name="telephonyBinding"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="agentName"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    [Experimental("AAIP001")]
    public virtual ClientResult<TelephonyBinding> CreateTelephonyBinding(string agentName, CreateTelephonyBindingContent telephonyBinding, CancellationToken cancellationToken = default)
    {
        return CreateTelephonyBinding(
            agentName: agentName,
            telephonyBinding: telephonyBinding,
            foundryFeatures: default,
            cancellationToken: cancellationToken
        );
    }

    /// <summary> Creates a telephony binding for the voice agent named in the path. </summary>
    /// <param name="agentName"> The name of the voice agent that owns the binding. </param>
    /// <param name="telephonyBinding"> The provider-specific binding to create. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="agentName"/> or <paramref name="telephonyBinding"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="agentName"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    [Experimental("AAIP001")]
    public virtual async Task<ClientResult<TelephonyBinding>> CreateTelephonyBindingAsync(string agentName, CreateTelephonyBindingContent telephonyBinding, CancellationToken cancellationToken = default)
    {
        return await CreateTelephonyBindingAsync(
            agentName: agentName,
            telephonyBinding: telephonyBinding,
            foundryFeatures: default,
            cancellationToken: cancellationToken
        ).ConfigureAwait(false);
    }

    /// <summary> Retrieves a telephony binding owned by the voice agent named in the path. </summary>
    /// <param name="agentName"> The name of the voice agent that owns the binding. </param>
    /// <param name="bindingId"> The service-generated binding identifier. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="agentName"/> or <paramref name="bindingId"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="agentName"/> or <paramref name="bindingId"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    [Experimental("AAIP001")]
    public virtual ClientResult<TelephonyBinding> GetTelephonyBinding(string agentName, string bindingId, CancellationToken cancellationToken = default)
    {
        return GetTelephonyBinding(
            agentName: agentName,
            bindingId: bindingId,
            foundryFeatures: default,
            cancellationToken: cancellationToken
        );
    }

    /// <summary> Retrieves a telephony binding owned by the voice agent named in the path. </summary>
    /// <param name="agentName"> The name of the voice agent that owns the binding. </param>
    /// <param name="bindingId"> The service-generated binding identifier. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="agentName"/> or <paramref name="bindingId"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="agentName"/> or <paramref name="bindingId"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    [Experimental("AAIP001")]
    public virtual async Task<ClientResult<TelephonyBinding>> GetTelephonyBindingAsync(string agentName, string bindingId, CancellationToken cancellationToken = default)
    {
        return await GetTelephonyBindingAsync(
            agentName: agentName,
            bindingId: bindingId,
            foundryFeatures: default,
            cancellationToken: cancellationToken
        ).ConfigureAwait(false);
    }

    /// <summary>
    /// [Protocol Method] Updates a telephony binding owned by the voice agent named in the path.
    /// <list type="bullet">
    /// <item>
    /// <description> This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios. </description>
    /// </item>
    /// </list>
    /// </summary>
    /// <param name="agentName"> The name of the voice agent that owns the binding. </param>
    /// <param name="bindingId"> The service-generated binding identifier. </param>
    /// <param name="ifMatch"> The entity tag returned by the latest read. The request fails if the resource changed since that read. </param>
    /// <param name="content"> The content to send as the body of the request. </param>
    /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="agentName"/>, <paramref name="bindingId"/>, <paramref name="ifMatch"/> or <paramref name="content"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="agentName"/>, <paramref name="bindingId"/> or <paramref name="ifMatch"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    /// <returns> The response returned from the service. </returns>
    [Experimental("AAIP001")]
    public virtual ClientResult UpdateTelephonyBinding(string agentName, string bindingId, string ifMatch, BinaryContent content, RequestOptions options = null)
    {
        return UpdateTelephonyBinding(
            agentName: agentName,
            bindingId: bindingId,
            ifMatch: ifMatch,
            content: content,
            foundryFeatures: default,
            options: options
        );
    }

    /// <summary>
    /// [Protocol Method] Updates a telephony binding owned by the voice agent named in the path.
    /// <list type="bullet">
    /// <item>
    /// <description> This <see href="https://aka.ms/azsdk/net/protocol-methods">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios. </description>
    /// </item>
    /// </list>
    /// </summary>
    /// <param name="agentName"> The name of the voice agent that owns the binding. </param>
    /// <param name="bindingId"> The service-generated binding identifier. </param>
    /// <param name="ifMatch"> The entity tag returned by the latest read. The request fails if the resource changed since that read. </param>
    /// <param name="content"> The content to send as the body of the request. </param>
    /// <param name="options"> The request options, which can override default behaviors of the client pipeline on a per-call basis. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="agentName"/>, <paramref name="bindingId"/>, <paramref name="ifMatch"/> or <paramref name="content"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="agentName"/>, <paramref name="bindingId"/> or <paramref name="ifMatch"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    /// <returns> The response returned from the service. </returns>
    [Experimental("AAIP001")]
    public virtual async Task<ClientResult> UpdateTelephonyBindingAsync(string agentName, string bindingId, string ifMatch, BinaryContent content, RequestOptions options = null)
    {
        return await UpdateTelephonyBindingAsync(
            agentName: agentName,
            bindingId: bindingId,
            ifMatch: ifMatch,
            content: content,
            foundryFeatures: default,
            options: options
        ).ConfigureAwait(false);
    }

    /// <summary> Deletes a telephony binding owned by the voice agent named in the path. </summary>
    /// <param name="agentName"> The name of the voice agent that owns the binding. </param>
    /// <param name="bindingId"> The service-generated binding identifier. </param>
    /// <param name="ifMatch"> The entity tag returned by the latest read. The request fails if the resource changed since that read. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="agentName"/>, <paramref name="bindingId"/> or <paramref name="ifMatch"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="agentName"/>, <paramref name="bindingId"/> or <paramref name="ifMatch"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    [Experimental("AAIP001")]
    public virtual ClientResult DeleteTelephonyBinding(string agentName, string bindingId, string ifMatch, CancellationToken cancellationToken = default)
    {
        return DeleteTelephonyBinding(
            agentName: agentName,
            bindingId: bindingId,
            ifMatch: ifMatch,
            foundryFeatures: default,
            cancellationToken: cancellationToken
        );
    }

    /// <summary> Deletes a telephony binding owned by the voice agent named in the path. </summary>
    /// <param name="agentName"> The name of the voice agent that owns the binding. </param>
    /// <param name="bindingId"> The service-generated binding identifier. </param>
    /// <param name="ifMatch"> The entity tag returned by the latest read. The request fails if the resource changed since that read. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="agentName"/>, <paramref name="bindingId"/> or <paramref name="ifMatch"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="agentName"/>, <paramref name="bindingId"/> or <paramref name="ifMatch"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    [Experimental("AAIP001")]
    public virtual async Task<ClientResult> DeleteTelephonyBindingAsync(string agentName, string bindingId, string ifMatch, CancellationToken cancellationToken = default)
    {
        return await DeleteTelephonyBindingAsync(
            agentName: agentName,
            bindingId: bindingId,
            ifMatch: ifMatch,
            foundryFeatures: default,
            cancellationToken: cancellationToken
        ).ConfigureAwait(false);
    }

    /// <summary> Returns the durable inbound call history for the voice agent named in the path. </summary>
    /// <param name="agentName"> The name of the voice agent whose calls are listed. </param>
    /// <param name="provider"> Filters calls by provider. </param>
    /// <param name="status"> Filters calls by lifecycle status. </param>
    /// <param name="startedAfter"> Includes calls that started at or after this Unix timestamp in seconds. </param>
    /// <param name="startedBefore"> Includes calls that started at or before this Unix timestamp in seconds. </param>
    /// <param name="limit">
    /// A limit on the number of objects to be returned. Limit can range between 1 and 100, and the
    /// default is 20.
    /// </param>
    /// <param name="order">
    /// Sort order by the `created_at` timestamp of the objects. `asc` for ascending order and`desc`
    /// for descending order.
    /// </param>
    /// <param name="after">
    /// A cursor for use in pagination. `after` is an object ID that defines your place in the list.
    /// For instance, if you make a list request and receive 100 objects, ending with obj_foo, your
    /// subsequent call can include after=obj_foo in order to fetch the next page of the list.
    /// </param>
    /// <param name="before">
    /// A cursor for use in pagination. `before` is an object ID that defines your place in the list.
    /// For instance, if you make a list request and receive 100 objects, ending with obj_foo, your
    /// subsequent call can include before=obj_foo in order to fetch the previous page of the list.
    /// </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="agentName"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="agentName"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    [Experimental("AAIP001")]
    public virtual CollectionResult<TelephonyCallSummary> GetTelephonyCalls(string agentName, TelephonyProvider? provider = default, TelephonyCallStatus? status = default, DateTimeOffset? startedAfter = default, DateTimeOffset? startedBefore = default, int? limit = default, AgentListOrder? order = default, string after = default, string before = default, CancellationToken cancellationToken = default)
    {
        return GetTelephonyCalls(
            agentName: agentName,
            foundryFeatures: default,
            provider: provider,
            status: status,
            startedAfter: startedAfter,
            startedBefore: startedBefore,
            limit: limit,
            order: order,
            after: after,
            before: before,
            cancellationToken: cancellationToken
        );
    }

    /// <summary> Returns the durable inbound call history for the voice agent named in the path. </summary>
    /// <param name="agentName"> The name of the voice agent whose calls are listed. </param>
    /// <param name="provider"> Filters calls by provider. </param>
    /// <param name="status"> Filters calls by lifecycle status. </param>
    /// <param name="startedAfter"> Includes calls that started at or after this Unix timestamp in seconds. </param>
    /// <param name="startedBefore"> Includes calls that started at or before this Unix timestamp in seconds. </param>
    /// <param name="limit">
    /// A limit on the number of objects to be returned. Limit can range between 1 and 100, and the
    /// default is 20.
    /// </param>
    /// <param name="order">
    /// Sort order by the `created_at` timestamp of the objects. `asc` for ascending order and`desc`
    /// for descending order.
    /// </param>
    /// <param name="after">
    /// A cursor for use in pagination. `after` is an object ID that defines your place in the list.
    /// For instance, if you make a list request and receive 100 objects, ending with obj_foo, your
    /// subsequent call can include after=obj_foo in order to fetch the next page of the list.
    /// </param>
    /// <param name="before">
    /// A cursor for use in pagination. `before` is an object ID that defines your place in the list.
    /// For instance, if you make a list request and receive 100 objects, ending with obj_foo, your
    /// subsequent call can include before=obj_foo in order to fetch the previous page of the list.
    /// </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="agentName"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="agentName"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    [Experimental("AAIP001")]
    public virtual AsyncCollectionResult<TelephonyCallSummary> GetTelephonyCallsAsync(string agentName, TelephonyProvider? provider = default, TelephonyCallStatus? status = default, DateTimeOffset? startedAfter = default, DateTimeOffset? startedBefore = default, int? limit = default, AgentListOrder? order = default, string after = default, string before = default, CancellationToken cancellationToken = default)
    {
        return GetTelephonyCallsAsync(
            agentName: agentName,
            foundryFeatures: default,
            provider: provider,
            status: status,
            startedAfter: startedAfter,
            startedBefore: startedBefore,
            limit: limit,
            order: order,
            after: after,
            before: before,
            cancellationToken: cancellationToken
        );
    }

    /// <summary> Retrieves a durable inbound call record owned by the voice agent named in the path. </summary>
    /// <param name="agentName"> The name of the voice agent that owns the call record. </param>
    /// <param name="callId"> The service-generated call identifier. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="agentName"/> or <paramref name="callId"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="agentName"/> or <paramref name="callId"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    [Experimental("AAIP001")]
    public virtual ClientResult<TelephonyCallRecord> GetTelephonyCall(string agentName, string callId, CancellationToken cancellationToken = default)
    {
        return GetTelephonyCall(
            agentName: agentName,
            callId: callId,
            foundryFeatures: default,
            cancellationToken: cancellationToken
        );
    }

    /// <summary> Retrieves a durable inbound call record owned by the voice agent named in the path. </summary>
    /// <param name="agentName"> The name of the voice agent that owns the call record. </param>
    /// <param name="callId"> The service-generated call identifier. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="agentName"/> or <paramref name="callId"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="agentName"/> or <paramref name="callId"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    [Experimental("AAIP001")]
    public virtual async Task<ClientResult<TelephonyCallRecord>> GetTelephonyCallAsync(string agentName, string callId, CancellationToken cancellationToken = default)
    {
        return await GetTelephonyCallAsync(
            agentName: agentName,
            callId: callId,
            foundryFeatures: default,
            cancellationToken: cancellationToken
        ).ConfigureAwait(false);
    }

    /// <summary> Transfers an active inbound call to a configured target for the voice agent named in the path. </summary>
    /// <param name="agentName"> The name of the voice agent that owns the active call. </param>
    /// <param name="callId"> The service-generated call identifier. </param>
    /// <param name="target"> The name of a transfer target configured for the voice agent. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="agentName"/>, <paramref name="callId"/> or <paramref name="target"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="agentName"/>, <paramref name="callId"/> or <paramref name="target"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    [Experimental("AAIP001")]
    public virtual ClientResult<TelephonyCallRecord> TransferTelephonyCall(string agentName, string callId, string target, CancellationToken cancellationToken = default)
    {
        return TransferTelephonyCall(
            agentName: agentName,
            callId: callId,
            target: target,
            foundryFeatures: default,
            cancellationToken: cancellationToken
        );
    }

    /// <summary> Transfers an active inbound call to a configured target for the voice agent named in the path. </summary>
    /// <param name="agentName"> The name of the voice agent that owns the active call. </param>
    /// <param name="callId"> The service-generated call identifier. </param>
    /// <param name="target"> The name of a transfer target configured for the voice agent. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="agentName"/>, <paramref name="callId"/> or <paramref name="target"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="agentName"/>, <paramref name="callId"/> or <paramref name="target"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    [Experimental("AAIP001")]
    public virtual async Task<ClientResult<TelephonyCallRecord>> TransferTelephonyCallAsync(string agentName, string callId, string target, CancellationToken cancellationToken = default)
    {
        return await TransferTelephonyCallAsync(
            agentName: agentName,
            callId: callId,
            target: target,
            foundryFeatures: default,
            cancellationToken: cancellationToken
        ).ConfigureAwait(false);
    }

    /// <summary> Ends an active inbound call owned by the voice agent named in the path. </summary>
    /// <param name="agentName"> The name of the voice agent that owns the active call. </param>
    /// <param name="callId"> The service-generated call identifier. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="agentName"/> or <paramref name="callId"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="agentName"/> or <paramref name="callId"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    [Experimental("AAIP001")]
    public virtual ClientResult<TelephonyCallRecord> EndTelephonyCall(string agentName, string callId, CancellationToken cancellationToken = default)
    {
        return EndTelephonyCall(
            agentName: agentName,
            callId: callId,
            foundryFeatures: default,
            cancellationToken: cancellationToken
        );
    }

    /// <summary> Ends an active inbound call owned by the voice agent named in the path. </summary>
    /// <param name="agentName"> The name of the voice agent that owns the active call. </param>
    /// <param name="callId"> The service-generated call identifier. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="agentName"/> or <paramref name="callId"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="agentName"/> or <paramref name="callId"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    [Experimental("AAIP001")]
    public virtual async Task<ClientResult<TelephonyCallRecord>> EndTelephonyCallAsync(string agentName, string callId, CancellationToken cancellationToken = default)
    {
        return await EndTelephonyCallAsync(
            agentName: agentName,
            callId: callId,
            foundryFeatures: default,
            cancellationToken: cancellationToken
        ).ConfigureAwait(false);
    }

    /// <summary> Returns all transfer targets configured for the voice agent named in the path. </summary>
    /// <param name="agentName"> The name of the voice agent whose transfer targets are retrieved. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="agentName"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="agentName"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    [Experimental("AAIP001")]
    public virtual ClientResult<TelephonyTransferTargets> GetTelephonyTransferTargets(string agentName, CancellationToken cancellationToken = default)
    {
        return GetTelephonyTransferTargets(
            agentName: agentName,
            foundryFeatures: default,
            cancellationToken: cancellationToken
        );
    }

    /// <summary> Returns all transfer targets configured for the voice agent named in the path. </summary>
    /// <param name="agentName"> The name of the voice agent whose transfer targets are retrieved. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="agentName"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="agentName"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    [Experimental("AAIP001")]
    public virtual async Task<ClientResult<TelephonyTransferTargets>> GetTelephonyTransferTargetsAsync(string agentName, CancellationToken cancellationToken = default)
    {
        return await GetTelephonyTransferTargetsAsync(
            agentName: agentName,
            foundryFeatures: default,
            cancellationToken: cancellationToken
        ).ConfigureAwait(false);
    }

    /// <summary> Replaces all transfer targets configured for the voice agent named in the path. </summary>
    /// <param name="agentName"> The name of the voice agent whose transfer targets are replaced. </param>
    /// <param name="ifMatch"> The entity tag returned by the latest read. The request fails if the resource changed since that read. </param>
    /// <param name="transferTargets"> The complete set of destinations to which the voice agent may transfer calls. An empty array clears all targets when replacing the configuration. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="agentName"/>, <paramref name="ifMatch"/> or <paramref name="transferTargets"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="agentName"/> or <paramref name="ifMatch"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    [Experimental("AAIP001")]
    public virtual ClientResult<TelephonyTransferTargets> ReplaceTelephonyTransferTargets(string agentName, string ifMatch, IEnumerable<TelephonyTransferTarget> transferTargets, CancellationToken cancellationToken = default)
    {
        return ReplaceTelephonyTransferTargets(
            agentName: agentName,
            ifMatch: ifMatch,
            transferTargets: transferTargets,
            foundryFeatures: default,
            cancellationToken: cancellationToken
        );
    }

    /// <summary> Replaces all transfer targets configured for the voice agent named in the path. </summary>
    /// <param name="agentName"> The name of the voice agent whose transfer targets are replaced. </param>
    /// <param name="ifMatch"> The entity tag returned by the latest read. The request fails if the resource changed since that read. </param>
    /// <param name="transferTargets"> The complete set of destinations to which the voice agent may transfer calls. An empty array clears all targets when replacing the configuration. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="agentName"/>, <paramref name="ifMatch"/> or <paramref name="transferTargets"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="agentName"/> or <paramref name="ifMatch"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    [Experimental("AAIP001")]
    public virtual async Task<ClientResult<TelephonyTransferTargets>> ReplaceTelephonyTransferTargetsAsync(string agentName, string ifMatch, IEnumerable<TelephonyTransferTarget> transferTargets, CancellationToken cancellationToken = default)
    {
        return await ReplaceTelephonyTransferTargetsAsync(
            agentName: agentName,
            ifMatch: ifMatch,
            transferTargets: transferTargets,
            foundryFeatures: default,
            cancellationToken: cancellationToken
        ).ConfigureAwait(false);
    }

    /// <summary> Creates one durable direct outbound call job. The latest agent definition is resolved when each attempt executes. </summary>
    /// <param name="agentName"> The name of the voice agent that executes the call. </param>
    /// <param name="idempotencyKey"> A customer-generated idempotency key. Reusing it with an equivalent request returns the same call job. </param>
    /// <param name="body"> The direct outbound call to create. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="agentName"/>, <paramref name="idempotencyKey"/> or <paramref name="body"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="agentName"/> or <paramref name="idempotencyKey"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    [Experimental("AAIP001")]
    public virtual ClientResult<TelephonyCallJob> CreateTelephonyCallJob(string agentName, string idempotencyKey, CreateTelephonyCallJobContent body, CancellationToken cancellationToken = default)
    {
        return CreateTelephonyCallJob(
            agentName: agentName,
            idempotencyKey: idempotencyKey,
            body: body,
            foundryFeatures: default,
            cancellationToken: cancellationToken
        );
    }

    /// <summary> Creates one durable direct outbound call job. The latest agent definition is resolved when each attempt executes. </summary>
    /// <param name="agentName"> The name of the voice agent that executes the call. </param>
    /// <param name="idempotencyKey"> A customer-generated idempotency key. Reusing it with an equivalent request returns the same call job. </param>
    /// <param name="body"> The direct outbound call to create. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="agentName"/>, <paramref name="idempotencyKey"/> or <paramref name="body"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="agentName"/> or <paramref name="idempotencyKey"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    [Experimental("AAIP001")]
    public virtual async Task<ClientResult<TelephonyCallJob>> CreateTelephonyCallJobAsync(string agentName, string idempotencyKey, CreateTelephonyCallJobContent body, CancellationToken cancellationToken = default)
    {
        return await CreateTelephonyCallJobAsync(
            agentName: agentName,
            idempotencyKey: idempotencyKey,
            body: body,
            foundryFeatures: default,
            cancellationToken: cancellationToken
        ).ConfigureAwait(false);
    }

    /// <summary> Retrieves a durable direct or campaign-created outbound call job. </summary>
    /// <param name="agentName"></param>
    /// <param name="callJobId"></param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="agentName"/> or <paramref name="callJobId"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="agentName"/> or <paramref name="callJobId"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    [Experimental("AAIP001")]
    public virtual ClientResult<TelephonyCallJob> GetTelephonyCallJob(string agentName, string callJobId, CancellationToken cancellationToken = default)
    {
        return GetTelephonyCallJob(
            agentName: agentName,
            callJobId: callJobId,
            foundryFeatures: default,
            cancellationToken: cancellationToken
        );
    }

    /// <summary> Retrieves a durable direct or campaign-created outbound call job. </summary>
    /// <param name="agentName"></param>
    /// <param name="callJobId"></param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="agentName"/> or <paramref name="callJobId"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="agentName"/> or <paramref name="callJobId"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    [Experimental("AAIP001")]
    public virtual async Task<ClientResult<TelephonyCallJob>> GetTelephonyCallJobAsync(string agentName, string callJobId, CancellationToken cancellationToken = default)
    {
        return await GetTelephonyCallJobAsync(
            agentName: agentName,
            callJobId: callJobId,
            foundryFeatures: default,
            cancellationToken: cancellationToken
        ).ConfigureAwait(false);
    }

    /// <summary> Requests cancellation of a durable outbound call job. A connected call is allowed to finish. </summary>
    /// <param name="agentName"></param>
    /// <param name="callJobId"></param>
    /// <param name="ifMatch"> The entity tag returned by the latest read. The request fails if the resource changed since that read. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="agentName"/>, <paramref name="callJobId"/> or <paramref name="ifMatch"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="agentName"/>, <paramref name="callJobId"/> or <paramref name="ifMatch"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    [Experimental("AAIP001")]
    public virtual ClientResult<TelephonyCallJob> CancelTelephonyCallJob(string agentName, string callJobId, string ifMatch, CancellationToken cancellationToken = default)
    {
        return CancelTelephonyCallJob(
            agentName: agentName,
            callJobId: callJobId,
            ifMatch: ifMatch,
            foundryFeatures: default,
            cancellationToken: cancellationToken
        );
    }

    /// <summary> Requests cancellation of a durable outbound call job. A connected call is allowed to finish. </summary>
    /// <param name="agentName"></param>
    /// <param name="callJobId"></param>
    /// <param name="ifMatch"> The entity tag returned by the latest read. The request fails if the resource changed since that read. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="agentName"/>, <paramref name="callJobId"/> or <paramref name="ifMatch"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="agentName"/>, <paramref name="callJobId"/> or <paramref name="ifMatch"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    [Experimental("AAIP001")]
    public virtual async Task<ClientResult<TelephonyCallJob>> CancelTelephonyCallJobAsync(string agentName, string callJobId, string ifMatch, CancellationToken cancellationToken = default)
    {
        return await CancelTelephonyCallJobAsync(
            agentName: agentName,
            callJobId: callJobId,
            ifMatch: ifMatch,
            foundryFeatures: default,
            cancellationToken: cancellationToken
        ).ConfigureAwait(false);
    }
}
}

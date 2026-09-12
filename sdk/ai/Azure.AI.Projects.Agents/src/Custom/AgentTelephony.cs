// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.AI.Projects.Agents;

[Experimental("AAIP001")]
[CodeGenSuppress("GetTelephonyBindings", typeof(string), typeof(AgentDefinitionOptInKeys?), typeof(TelephonyProvider?), typeof(TelephonyBindingStatus?), typeof(int?), typeof(AgentListOrder?), typeof(string), typeof(string), typeof(CancellationToken))]
[CodeGenSuppress("GetTelephonyBindingsAsync", typeof(string), typeof(AgentDefinitionOptInKeys?), typeof(TelephonyProvider?), typeof(TelephonyBindingStatus?), typeof(int?), typeof(AgentListOrder?), typeof(string), typeof(string), typeof(CancellationToken))]
[CodeGenSuppress("GetTelephonyBindings", typeof(string), typeof(string), typeof(string), typeof(string), typeof(int?), typeof(string), typeof(string), typeof(string), typeof(RequestOptions))]
[CodeGenSuppress("GetTelephonyBindingsAsync", typeof(string), typeof(string), typeof(string), typeof(string), typeof(int?), typeof(string), typeof(string), typeof(string), typeof(RequestOptions))]
[CodeGenSuppress("GetTelephonyCalls", typeof(string), typeof(AgentDefinitionOptInKeys?), typeof(TelephonyProvider?), typeof(TelephonyCallStatus?), typeof(DateTimeOffset?), typeof(DateTimeOffset?), typeof(AgentListOrder?), typeof(string), typeof(string), typeof(CancellationToken))]
[CodeGenSuppress("GetTelephonyCallsAsync", typeof(string), typeof(AgentDefinitionOptInKeys?), typeof(TelephonyProvider?), typeof(TelephonyCallStatus?), typeof(DateTimeOffset?), typeof(DateTimeOffset?), typeof(AgentListOrder?), typeof(string), typeof(string), typeof(CancellationToken))]
[CodeGenSuppress("GetTelephonyCalls", typeof(string), typeof(string), typeof(string), typeof(string), typeof(DateTimeOffset?), typeof(DateTimeOffset?), typeof(string), typeof(string), typeof(string), typeof(RequestOptions))]
[CodeGenSuppress("GetTelephonyCallsAsync", typeof(string), typeof(string), typeof(string), typeof(string), typeof(DateTimeOffset?), typeof(DateTimeOffset?), typeof(string), typeof(string), typeof(string), typeof(RequestOptions))]
public partial class AgentTelephony
{
    /// <summary> Creates a telephony binding for the voice agent named in the path. </summary>
    /// <param name="agentName"> The name of the voice agent that owns the binding. </param>
    /// <param name="body"> The provider-specific binding to create. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="agentName"/> or <paramref name="body"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="agentName"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    [Experimental("AAIP001")]
    public virtual ClientResult<TelephonyBinding> CreateTelephonyBinding(string agentName, CreateTelephonyBindingContent body, CancellationToken cancellationToken = default)
    {
        return CreateTelephonyBinding(
            agentName: agentName,
            body: body,
            foundryFeatures: default,
            cancellationToken: cancellationToken
        );
    }

    /// <summary> Creates a telephony binding for the voice agent named in the path. </summary>
    /// <param name="agentName"> The name of the voice agent that owns the binding. </param>
    /// <param name="body"> The provider-specific binding to create. </param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="agentName"/> or <paramref name="body"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="agentName"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    [Experimental("AAIP001")]
    public virtual async Task<ClientResult<TelephonyBinding>> CreateTelephonyBindingAsync(string agentName, CreateTelephonyBindingContent body, CancellationToken cancellationToken = default)
    {
        return await CreateTelephonyBindingAsync(
            agentName: agentName,
            body: body,
            foundryFeatures: default,
            cancellationToken: cancellationToken
        ).ConfigureAwait(false);
    }

    /// <summary> Returns the telephony bindings owned by the voice agent named in the path. </summary>
    /// <param name="agentName"> The name of the voice agent whose bindings are listed. </param>
    /// <param name="provider"> Filters bindings by provider. </param>
    /// <param name="status"> Filters bindings by lifecycle status. </param>
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
    public virtual CollectionResult<TelephonyBindingListItem> GetTelephonyBindings(string agentName, TelephonyProvider? provider = default, TelephonyBindingStatus? status = default, int? limit = default, AgentListOrder? order = default, string after = default, string before = default, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(agentName, nameof(agentName));

        return new InternalOpenAICollectionResultOfT<TelephonyBindingListItem>(
            Pipeline,
            messageGenerator: (localCollectionOptions, localRequestOptions)
                => CreateGetTelephonyBindingsRequest(
                    agentName: localCollectionOptions.ExtraQueryMap["agentName"],
                    provider: localCollectionOptions.ExtraQueryMap[nameof(TelephonyProvider)],
                    status: localCollectionOptions.ExtraQueryMap[nameof(TelephonyBindingStatus)],
                    foundryFeatures: default,
                    limit: localCollectionOptions.Limit,
                    order: localCollectionOptions.Order,
                    after: localCollectionOptions.AfterId,
                    before: localCollectionOptions.BeforeId,
                    options: localRequestOptions),
            dataItemDeserializer: (e, o) => TelephonyBindingListItem.DeserializeTelephonyBindingListItem(e, o),
            new InternalOpenAICollectionResultOptions(limit, order?.ToString(), after, before, extraQueryMap: new Dictionary<string, string>() {
                { "agentName", agentName },
                { nameof(TelephonyProvider), provider?.ToString() },
                { nameof(TelephonyBindingStatus),  status?.ToString() },
            }),
            cancellationToken.ToRequestOptions());
    }

    /// <summary> Returns the telephony bindings owned by the voice agent named in the path. </summary>
    /// <param name="agentName"> The name of the voice agent whose bindings are listed. </param>
    /// <param name="provider"> Filters bindings by provider. </param>
    /// <param name="status"> Filters bindings by lifecycle status. </param>
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
    public virtual AsyncCollectionResult<TelephonyBindingListItem> GetTelephonyBindingsAsync(string agentName, TelephonyProvider? provider = default, TelephonyBindingStatus? status = default, int? limit = default, AgentListOrder? order = default, string after = default, string before = default, CancellationToken cancellationToken = default)
    {
        Argument.AssertNotNullOrEmpty(agentName, nameof(agentName));

        return new InternalOpenAIAsyncCollectionResultOfT<TelephonyBindingListItem>(
            Pipeline,
            messageGenerator: (localCollectionOptions, localRequestOptions)
                => CreateGetTelephonyBindingsRequest(
                    agentName: localCollectionOptions.ExtraQueryMap["agentName"],
                    provider: localCollectionOptions.ExtraQueryMap[nameof(TelephonyProvider)],
                    status: localCollectionOptions.ExtraQueryMap[nameof(TelephonyBindingStatus)],
                    foundryFeatures: default,
                    limit: localCollectionOptions.Limit,
                    order: localCollectionOptions.Order,
                    after: localCollectionOptions.AfterId,
                    before: localCollectionOptions.BeforeId,
                    options: localRequestOptions),
            dataItemDeserializer: (e, o) => TelephonyBindingListItem.DeserializeTelephonyBindingListItem(e, o),
            new InternalOpenAICollectionResultOptions(limit, order?.ToString(), after, before, extraQueryMap: new Dictionary<string, string>() {
                { "agentName", agentName },
                { nameof(TelephonyProvider), provider?.ToString() },
                { nameof(TelephonyBindingStatus),  status?.ToString() },
            }),
            cancellationToken.ToRequestOptions());
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
        Argument.AssertNotNullOrEmpty(agentName, nameof(agentName));

        return new AgentTelephonyGetTelephonyCallsCollectionResultOfT(
            client: this,
            agentName: agentName,
            foundryFeatures: default,
            provider: provider?.ToString(),
            status: status?.ToString(),
            startedAfter: startedAfter,
            startedBefore: startedBefore,
            limit: limit,
            order: order?.ToString(),
            after: after,
            before: before,
            options: cancellationToken.ToRequestOptions());
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
        Argument.AssertNotNullOrEmpty(agentName, nameof(agentName));

        return new AgentTelephonyGetTelephonyCallsAsyncCollectionResultOfT(
            client: this,
            agentName: agentName,
            foundryFeatures: default,
            provider: provider?.ToString(),
            status: status?.ToString(),
            startedAfter: startedAfter,
            startedBefore: startedBefore,
            limit: limit,
            order: order?.ToString(),
            after: after,
            before: before,
            options: cancellationToken.ToRequestOptions());
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

    /// <summary> Creates a draft outbound campaign. Recipients are imported and validated before the campaign can be published. </summary>
    /// <param name="agentName"></param>
    /// <param name="body"></param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="agentName"/> or <paramref name="body"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="agentName"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    [Experimental("AAIP001")]
    public virtual ClientResult<TelephonyCampaign> CreateTelephonyCampaign(string agentName, CreateTelephonyCampaignContent body, CancellationToken cancellationToken = default)
    {
        return CreateTelephonyCampaign(
            agentName: agentName,
            body: body,
            foundryFeatures: default,
            cancellationToken: cancellationToken
        );
    }

    /// <summary> Creates a draft outbound campaign. Recipients are imported and validated before the campaign can be published. </summary>
    /// <param name="agentName"></param>
    /// <param name="body"></param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="agentName"/> or <paramref name="body"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="agentName"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    [Experimental("AAIP001")]
    public virtual async Task<ClientResult<TelephonyCampaign>> CreateTelephonyCampaignAsync(string agentName, CreateTelephonyCampaignContent body, CancellationToken cancellationToken = default)
    {
        return await CreateTelephonyCampaignAsync(
            agentName: agentName,
            body: body,
            foundryFeatures: default,
            cancellationToken: cancellationToken
        ).ConfigureAwait(false);
    }

    /// <summary> Retrieves an outbound campaign, including configuration, execution state, and aggregate call-job counts. </summary>
    /// <param name="agentName"></param>
    /// <param name="campaignId"></param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="agentName"/> or <paramref name="campaignId"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="agentName"/> or <paramref name="campaignId"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    [Experimental("AAIP001")]
    public virtual ClientResult<TelephonyCampaign> GetTelephonyCampaign(string agentName, string campaignId, CancellationToken cancellationToken = default)
    {
        return GetTelephonyCampaign(
            agentName: agentName,
            campaignId: campaignId,
            foundryFeatures: default,
            cancellationToken: cancellationToken
        );
    }

    /// <summary> Retrieves an outbound campaign, including configuration, execution state, and aggregate call-job counts. </summary>
    /// <param name="agentName"></param>
    /// <param name="campaignId"></param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="agentName"/> or <paramref name="campaignId"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="agentName"/> or <paramref name="campaignId"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    [Experimental("AAIP001")]
    public virtual async Task<ClientResult<TelephonyCampaign>> GetTelephonyCampaignAsync(string agentName, string campaignId, CancellationToken cancellationToken = default)
    {
        return await GetTelephonyCampaignAsync(
            agentName: agentName,
            campaignId: campaignId,
            foundryFeatures: default,
            cancellationToken: cancellationToken
        ).ConfigureAwait(false);
    }

    /// <summary> Starts an asynchronous import of campaign recipients from a Dataset CSV, JSON array, or JSONL file. </summary>
    /// <param name="waitUntilCompleted"> Whether the method should wait until the long-running operation has completed on the service. </param>
    /// <param name="agentName"></param>
    /// <param name="campaignId"></param>
    /// <param name="idempotencyKey"></param>
    /// <param name="body"></param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="agentName"/>, <paramref name="campaignId"/>, <paramref name="idempotencyKey"/> or <paramref name="body"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="agentName"/>, <paramref name="campaignId"/> or <paramref name="idempotencyKey"/> is an empty string, and was expected to be non-empty. </exception>
    [Experimental("AAIP001")]
    public virtual OperationResult ImportTelephonyCampaignRecipients(bool waitUntilCompleted, string agentName, string campaignId, string idempotencyKey, ImportTelephonyCampaignRecipientsContent body, CancellationToken cancellationToken = default)
    {
        return ImportTelephonyCampaignRecipients(
            waitUntilCompleted: waitUntilCompleted,
            agentName: agentName,
            campaignId: campaignId,
            idempotencyKey: idempotencyKey,
            body: body,
            foundryFeatures: default,
            cancellationToken: cancellationToken
        );
    }

    /// <summary> Starts an asynchronous import of campaign recipients from a Dataset CSV, JSON array, or JSONL file. </summary>
    /// <param name="waitUntilCompleted"> Whether the method should wait until the long-running operation has completed on the service. </param>
    /// <param name="agentName"></param>
    /// <param name="campaignId"></param>
    /// <param name="idempotencyKey"></param>
    /// <param name="body"></param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="agentName"/>, <paramref name="campaignId"/>, <paramref name="idempotencyKey"/> or <paramref name="body"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="agentName"/>, <paramref name="campaignId"/> or <paramref name="idempotencyKey"/> is an empty string, and was expected to be non-empty. </exception>
    [Experimental("AAIP001")]
    public virtual async Task<OperationResult> ImportTelephonyCampaignRecipientsAsync(bool waitUntilCompleted, string agentName, string campaignId, string idempotencyKey, ImportTelephonyCampaignRecipientsContent body, CancellationToken cancellationToken = default)
    {
        return await ImportTelephonyCampaignRecipientsAsync(
            waitUntilCompleted: waitUntilCompleted,
            agentName: agentName,
            campaignId: campaignId,
            idempotencyKey: idempotencyKey,
            body: body,
            foundryFeatures: default,
            cancellationToken: cancellationToken
        ).ConfigureAwait(false);
    }

    /// <summary> Retrieves the durable status and counters for a campaign recipient import. </summary>
    /// <param name="agentName"></param>
    /// <param name="campaignId"></param>
    /// <param name="importId"></param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="agentName"/>, <paramref name="campaignId"/> or <paramref name="importId"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="agentName"/>, <paramref name="campaignId"/> or <paramref name="importId"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    [Experimental("AAIP001")]
    public virtual ClientResult<TelephonyCampaignRecipientImport> GetTelephonyCampaignRecipientImport(string agentName, string campaignId, string importId, CancellationToken cancellationToken = default)
    {
        return GetTelephonyCampaignRecipientImport(
            agentName: agentName,
            campaignId: campaignId,
            importId: importId,
            foundryFeatures: default,
            cancellationToken: cancellationToken
        );
    }

    /// <summary> Retrieves the durable status and counters for a campaign recipient import. </summary>
    /// <param name="agentName"></param>
    /// <param name="campaignId"></param>
    /// <param name="importId"></param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="agentName"/>, <paramref name="campaignId"/> or <paramref name="importId"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="agentName"/>, <paramref name="campaignId"/> or <paramref name="importId"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    [Experimental("AAIP001")]
    public virtual async Task<ClientResult<TelephonyCampaignRecipientImport>> GetTelephonyCampaignRecipientImportAsync(string agentName, string campaignId, string importId, CancellationToken cancellationToken = default)
    {
        return await GetTelephonyCampaignRecipientImportAsync(
            agentName: agentName,
            campaignId: campaignId,
            importId: importId,
            foundryFeatures: default,
            cancellationToken: cancellationToken
        ).ConfigureAwait(false);
    }

    /// <summary> Starts asynchronous validation of the current campaign draft and imported recipient snapshot. </summary>
    /// <param name="waitUntilCompleted"> Whether the method should wait until the long-running operation has completed on the service. </param>
    /// <param name="agentName"></param>
    /// <param name="campaignId"></param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="agentName"/> or <paramref name="campaignId"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="agentName"/> or <paramref name="campaignId"/> is an empty string, and was expected to be non-empty. </exception>
    [Experimental("SCME0006")]
    public virtual OperationResult ValidateTelephonyCampaign(bool waitUntilCompleted, string agentName, string campaignId, CancellationToken cancellationToken = default)
    {
        return ValidateTelephonyCampaign(
            waitUntilCompleted: waitUntilCompleted,
            agentName: agentName,
            campaignId: campaignId,
            foundryFeatures: default,
            cancellationToken: cancellationToken
        );
    }

    /// <summary> Starts asynchronous validation of the current campaign draft and imported recipient snapshot. </summary>
    /// <param name="waitUntilCompleted"> Whether the method should wait until the long-running operation has completed on the service. </param>
    /// <param name="agentName"></param>
    /// <param name="campaignId"></param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="agentName"/> or <paramref name="campaignId"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="agentName"/> or <paramref name="campaignId"/> is an empty string, and was expected to be non-empty. </exception>
    [Experimental("SCME0006")]
    public virtual async Task<OperationResult> ValidateTelephonyCampaignAsync(bool waitUntilCompleted, string agentName, string campaignId, CancellationToken cancellationToken = default)
    {
        return await ValidateTelephonyCampaignAsync(
            waitUntilCompleted: waitUntilCompleted,
            agentName: agentName,
            campaignId: campaignId,
            foundryFeatures: default,
            cancellationToken: cancellationToken
        ).ConfigureAwait(false);
    }

    /// <summary> Permanently locks the validated campaign draft and starts asynchronous call-job materialization. </summary>
    /// <param name="waitUntilCompleted"> Whether the method should wait until the long-running operation has completed on the service. </param>
    /// <param name="agentName"></param>
    /// <param name="campaignId"></param>
    /// <param name="body"></param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="agentName"/>, <paramref name="campaignId"/> or <paramref name="body"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="agentName"/> or <paramref name="campaignId"/> is an empty string, and was expected to be non-empty. </exception>
    [Experimental("AAIP001")]
    public virtual OperationResult PublishTelephonyCampaign(bool waitUntilCompleted, string agentName, string campaignId, PublishTelephonyCampaignContent body, CancellationToken cancellationToken = default)
    {
        return PublishTelephonyCampaign(
            waitUntilCompleted: waitUntilCompleted,
            agentName: agentName,
            campaignId: campaignId,
            body: body,
            foundryFeatures: default,
            cancellationToken: cancellationToken
        );
    }

    /// <summary> Permanently locks the validated campaign draft and starts asynchronous call-job materialization. </summary>
    /// <param name="waitUntilCompleted"> Whether the method should wait until the long-running operation has completed on the service. </param>
    /// <param name="agentName"></param>
    /// <param name="campaignId"></param>
    /// <param name="body"></param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="agentName"/>, <paramref name="campaignId"/> or <paramref name="body"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="agentName"/> or <paramref name="campaignId"/> is an empty string, and was expected to be non-empty. </exception>
    [Experimental("AAIP001")]
    public virtual async Task<OperationResult> PublishTelephonyCampaignAsync(bool waitUntilCompleted, string agentName, string campaignId, PublishTelephonyCampaignContent body, CancellationToken cancellationToken = default)
    {
        return await PublishTelephonyCampaignAsync(
            waitUntilCompleted: waitUntilCompleted,
            agentName: agentName,
            campaignId: campaignId,
            body: body,
            foundryFeatures: default,
            cancellationToken: cancellationToken
        ).ConfigureAwait(false);
    }

    /// <summary> Pauses dispatch of call jobs owned by a published campaign. </summary>
    /// <param name="agentName"></param>
    /// <param name="campaignId"></param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="agentName"/> or <paramref name="campaignId"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="agentName"/> or <paramref name="campaignId"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    [Experimental("AAIP001")]
    public virtual ClientResult<TelephonyCampaign> PauseTelephonyCampaign(string agentName, string campaignId, CancellationToken cancellationToken = default)
    {
        return PauseTelephonyCampaign(
            agentName: agentName,
            campaignId: campaignId,
            foundryFeatures: default,
            cancellationToken: cancellationToken
        );
    }

    /// <summary> Pauses dispatch of call jobs owned by a published campaign. </summary>
    /// <param name="agentName"></param>
    /// <param name="campaignId"></param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="agentName"/> or <paramref name="campaignId"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="agentName"/> or <paramref name="campaignId"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    [Experimental("AAIP001")]
    public virtual async Task<ClientResult<TelephonyCampaign>> PauseTelephonyCampaignAsync(string agentName, string campaignId, CancellationToken cancellationToken = default)
    {
        return await PauseTelephonyCampaignAsync(
            agentName: agentName,
            campaignId: campaignId,
            foundryFeatures: default,
            cancellationToken: cancellationToken
        ).ConfigureAwait(false);
    }

    /// <summary> Resumes dispatch of call jobs owned by a paused campaign. </summary>
    /// <param name="agentName"></param>
    /// <param name="campaignId"></param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="agentName"/> or <paramref name="campaignId"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="agentName"/> or <paramref name="campaignId"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    [Experimental("AAIP001")]
    public virtual ClientResult<TelephonyCampaign> ResumeTelephonyCampaign(string agentName, string campaignId, CancellationToken cancellationToken = default)
    {
        return ResumeTelephonyCampaign(
            agentName: agentName,
            campaignId: campaignId,
            foundryFeatures: default,
            cancellationToken: cancellationToken
        );
    }

    /// <summary> Resumes dispatch of call jobs owned by a paused campaign. </summary>
    /// <param name="agentName"></param>
    /// <param name="campaignId"></param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="agentName"/> or <paramref name="campaignId"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="agentName"/> or <paramref name="campaignId"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    [Experimental("AAIP001")]
    public virtual async Task<ClientResult<TelephonyCampaign>> ResumeTelephonyCampaignAsync(string agentName, string campaignId, CancellationToken cancellationToken = default)
    {
        return await ResumeTelephonyCampaignAsync(
            agentName: agentName,
            campaignId: campaignId,
            foundryFeatures: default,
            cancellationToken: cancellationToken
        ).ConfigureAwait(false);
    }

    /// <summary> Cancels a campaign and prevents any further call-job dispatch. </summary>
    /// <param name="agentName"></param>
    /// <param name="campaignId"></param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="agentName"/> or <paramref name="campaignId"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="agentName"/> or <paramref name="campaignId"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    [Experimental("AAIP001")]
    public virtual ClientResult<TelephonyCampaign> CancelTelephonyCampaign(string agentName, string campaignId, CancellationToken cancellationToken = default)
    {
        return CancelTelephonyCampaign(
            agentName: agentName,
            campaignId: campaignId,
            foundryFeatures: default,
            cancellationToken: cancellationToken
        );
    }

    /// <summary> Cancels a campaign and prevents any further call-job dispatch. </summary>
    /// <param name="agentName"></param>
    /// <param name="campaignId"></param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="agentName"/> or <paramref name="campaignId"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="agentName"/> or <paramref name="campaignId"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    [Experimental("AAIP001")]
    public virtual async Task<ClientResult<TelephonyCampaign>> CancelTelephonyCampaignAsync(string agentName, string campaignId, CancellationToken cancellationToken = default)
    {
        return await CancelTelephonyCampaignAsync(
            agentName: agentName,
            campaignId: campaignId,
            foundryFeatures: default,
            cancellationToken: cancellationToken
        ).ConfigureAwait(false);
    }

    /// <summary> Retrieves an asynchronous outbound campaign operation. </summary>
    /// <param name="agentName"></param>
    /// <param name="operationId"></param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="agentName"/> or <paramref name="operationId"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="agentName"/> or <paramref name="operationId"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    [Experimental("AAIP001")]
    public virtual ClientResult<TelephonyOperation> GetTelephonyOperation(string agentName, string operationId, CancellationToken cancellationToken = default)
    {
        return GetTelephonyOperation(
            agentName: agentName,
            operationId: operationId,
            foundryFeatures: default,
            cancellationToken: cancellationToken
        );
    }

    /// <summary> Retrieves an asynchronous outbound campaign operation. </summary>
    /// <param name="agentName"></param>
    /// <param name="operationId"></param>
    /// <param name="cancellationToken"> The cancellation token that can be used to cancel the operation. </param>
    /// <exception cref="ArgumentNullException"> <paramref name="agentName"/> or <paramref name="operationId"/> is null. </exception>
    /// <exception cref="ArgumentException"> <paramref name="agentName"/> or <paramref name="operationId"/> is an empty string, and was expected to be non-empty. </exception>
    /// <exception cref="ClientResultException"> Service returned a non-success status code. </exception>
    [Experimental("AAIP001")]
    public virtual async Task<ClientResult<TelephonyOperation>> GetTelephonyOperationAsync(string agentName, string operationId, CancellationToken cancellationToken = default)
    {
        return await GetTelephonyOperationAsync(
            agentName: agentName,
            operationId: operationId,
            foundryFeatures: default,
            cancellationToken: cancellationToken
        ).ConfigureAwait(false);
    }
}

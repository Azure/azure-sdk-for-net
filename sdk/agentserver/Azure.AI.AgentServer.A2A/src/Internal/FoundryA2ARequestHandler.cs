// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using global::A2A;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.Logging;

namespace Azure.AI.AgentServer.A2A.Internal;

// Constrain the exposed transport without changing the consumer's native handler or storage.
internal sealed class FoundryA2ARequestHandler(
    IA2ARequestHandler inner,
    ILogger<FoundryA2ARequestHandler> logger) : IA2ARequestHandler
{
    public Task<SendMessageResponse> SendMessageAsync(SendMessageRequest request, CancellationToken cancellationToken = default) =>
        InvokeAsync("SendMessage", () => inner.SendMessageAsync(request, cancellationToken), cancellationToken);

    public IAsyncEnumerable<StreamResponse> SendStreamingMessageAsync(SendMessageRequest request, CancellationToken cancellationToken = default) =>
        ObserveStreamAsync("SendStreamingMessage", () => inner.SendStreamingMessageAsync(request, cancellationToken), cancellationToken);

    public Task<AgentTask> GetTaskAsync(GetTaskRequest request, CancellationToken cancellationToken = default) =>
        InvokeAsync("GetTask", () => inner.GetTaskAsync(request, cancellationToken), cancellationToken);

    public Task<ListTasksResponse> ListTasksAsync(ListTasksRequest request, CancellationToken cancellationToken = default) =>
        InvokeAsync("ListTasks", () => inner.ListTasksAsync(request, cancellationToken), cancellationToken);

    public Task<AgentTask> CancelTaskAsync(CancelTaskRequest request, CancellationToken cancellationToken = default) =>
        InvokeAsync("CancelTask", () => inner.CancelTaskAsync(request, cancellationToken), cancellationToken);

    public IAsyncEnumerable<StreamResponse> SubscribeToTaskAsync(SubscribeToTaskRequest request, CancellationToken cancellationToken = default) =>
        ObserveStreamAsync("SubscribeToTask", () => inner.SubscribeToTaskAsync(request, cancellationToken), cancellationToken);

    public Task<TaskPushNotificationConfig> CreateTaskPushNotificationConfigAsync(TaskPushNotificationConfig config, CancellationToken cancellationToken = default) =>
        Task.FromException<TaskPushNotificationConfig>(PushUnsupported());

    public Task<TaskPushNotificationConfig> GetTaskPushNotificationConfigAsync(GetTaskPushNotificationConfigRequest request, CancellationToken cancellationToken = default) =>
        Task.FromException<TaskPushNotificationConfig>(PushUnsupported());

    public Task<ListTaskPushNotificationConfigsResponse> ListTaskPushNotificationConfigsAsync(ListTaskPushNotificationConfigsRequest request, CancellationToken cancellationToken = default) =>
        Task.FromException<ListTaskPushNotificationConfigsResponse>(PushUnsupported());

    public Task DeleteTaskPushNotificationConfigAsync(DeleteTaskPushNotificationConfigRequest request, CancellationToken cancellationToken = default) =>
        Task.FromException(PushUnsupported());

    public Task<AgentCard> GetExtendedAgentCardAsync(GetExtendedAgentCardRequest request, CancellationToken cancellationToken = default) =>
        Task.FromException<AgentCard>(new A2AException("Extended agent cards are not exposed by Foundry hosting.", A2AErrorCode.ExtendedAgentCardNotConfigured));

    private static A2AException PushUnsupported() =>
        new("Push notifications are not exposed by Foundry hosting.", A2AErrorCode.PushNotificationNotSupported);

    private async Task<T> InvokeAsync<T>(string operation, Func<Task<T>> action, CancellationToken cancellationToken)
    {
        try
        {
            return await action().ConfigureAwait(false);
        }
        catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
        {
            throw;
        }
        catch (A2AException exception) when (exception.ErrorCode != A2AErrorCode.InternalError)
        {
            throw;
        }
        catch (Exception exception)
        {
            // The native processor converts failures to JSON-RPC errors after this boundary.
            logger.LogError(exception, "A2A operation {Operation} failed", operation);
            throw;
        }
    }

    private async IAsyncEnumerable<StreamResponse> ObserveStreamAsync(
        string operation,
        Func<IAsyncEnumerable<StreamResponse>> createStream,
        [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        var stream = await InvokeAsync(operation, () => Task.FromResult(createStream()), cancellationToken).ConfigureAwait(false);
        var enumerator = await InvokeAsync(
            operation, () => Task.FromResult(stream.GetAsyncEnumerator(cancellationToken)), cancellationToken).ConfigureAwait(false);
        await using var disposal = enumerator.ConfigureAwait(false);
        while (await InvokeAsync(operation, () => enumerator.MoveNextAsync().AsTask(), cancellationToken).ConfigureAwait(false))
        {
            yield return enumerator.Current;
        }
    }
}

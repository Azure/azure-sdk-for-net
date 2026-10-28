// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using global::A2A;

namespace Azure.AI.AgentServer.A2A.Internal;

// Constrain the exposed transport without changing the consumer's native handler or storage.
internal sealed class FoundryA2ARequestHandler(IA2ARequestHandler inner) : IA2ARequestHandler
{
    public Task<SendMessageResponse> SendMessageAsync(SendMessageRequest request, CancellationToken cancellationToken = default) =>
        inner.SendMessageAsync(request, cancellationToken);

    public IAsyncEnumerable<StreamResponse> SendStreamingMessageAsync(SendMessageRequest request, CancellationToken cancellationToken = default) =>
        inner.SendStreamingMessageAsync(request, cancellationToken);

    public Task<AgentTask> GetTaskAsync(GetTaskRequest request, CancellationToken cancellationToken = default) =>
        inner.GetTaskAsync(request, cancellationToken);

    public Task<ListTasksResponse> ListTasksAsync(ListTasksRequest request, CancellationToken cancellationToken = default) =>
        inner.ListTasksAsync(request, cancellationToken);

    public Task<AgentTask> CancelTaskAsync(CancelTaskRequest request, CancellationToken cancellationToken = default) =>
        inner.CancelTaskAsync(request, cancellationToken);

    public IAsyncEnumerable<StreamResponse> SubscribeToTaskAsync(SubscribeToTaskRequest request, CancellationToken cancellationToken = default) =>
        inner.SubscribeToTaskAsync(request, cancellationToken);

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
}

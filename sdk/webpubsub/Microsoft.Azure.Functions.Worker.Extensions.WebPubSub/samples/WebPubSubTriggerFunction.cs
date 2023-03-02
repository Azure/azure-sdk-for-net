// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Azure.Functions.Worker;

namespace SampleApp;

public class WebPubSubTriggerFunction
{
    #region Snippet:WebPubSubTriggerUserEventFunction
    [Function("Broadcast")]
    public static UserEventResponse Run(
    [WebPubSubTrigger("chat", WebPubSubEventType.User, "message")] UserEventRequest request)
    {
        return new UserEventResponse($"[SYSTEM ACK] Received client message. From: {request.ConnectionContext.ConnectionId}, Data: {request.Data}");
    }
    #endregion
}
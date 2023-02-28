// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Functions.Worker;

namespace SampleApp;

public class WebPubSubTriggerFunction
{
    // TODO: write a sample to return both output and trigger response.
    [Function("Broadcast")]
    public static UserEventResponse Run(
    [WebPubSubTrigger("chat", WebPubSubEventType.User, "message")] UserEventRequest request)
    {
        return new UserEventResponse($"[SYSTEM ACK] Received client message. From: {request.ConnectionContext.ConnectionId}, Data: {request.Data}");
    }
}

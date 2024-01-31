// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Azure.Functions.Worker;

namespace SampleApp;

public class WebPubSubTriggerFunction
{
    #region Snippet:WebPubSubTriggerUserEventFunction
    [Function("Broadcast")]
    public static UserEventResponse Run(
    [WebPubSubTrigger("<web_pubsub_hub>", WebPubSubEventType.User, "message")] UserEventRequest request)
    {
        return new UserEventResponse("[SYSTEM ACK] Received.");
    }
    #endregion
}
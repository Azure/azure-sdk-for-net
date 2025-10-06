// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.Azure.WebJobs.Extensions.WebPubSub;
using Microsoft.Azure.WebPubSub.Common;
using Microsoft.Extensions.Logging;

namespace Microsoft.Azure.WebJobs.Samples
{
    public static class WebPubSubTriggerFunction
    {
        #region Snippet:WebPubSubTriggerFunction
        [FunctionName("WebPubSubTriggerFunction")]
        public static void Run(
            ILogger logger,
            [WebPubSubTrigger("hub", WebPubSubEventType.User, "message")] UserEventRequest request,
            string data,
            WebPubSubDataType dataType)
        {
            logger.LogInformation("Request from: {user}, data: {data}, dataType: {dataType}",
                request.ConnectionContext.UserId, data, dataType);
        }
        #endregion

        #region Snippet:MqttConnectEventTriggerFunction
        [FunctionName("mqttConnect")]
        public static WebPubSubEventResponse Run(
                [WebPubSubTrigger("hub", WebPubSubEventType.System, "connect", ClientProtocols = WebPubSubTriggerAcceptedClientProtocols.Mqtt)] MqttConnectEventRequest request,
                ILogger log)
        {
            if (request.ConnectionContext.ConnectionId != "attacker")
            {
                return request.CreateMqttResponse(request.ConnectionContext.UserId, Array.Empty<string>(), new string[] { "webpubsub.joinLeaveGroup.group1", "webpubsub.sendToGroup.group2" });
            }
            else
            {
                if (request.Mqtt.ProtocolVersion == MqttProtocolVersion.V311)
                {
                    return request.CreateMqttV311ErrorResponse(MqttV311ConnectReturnCode.NotAuthorized);
                }
                else
                {
                    return request.CreateMqttV50ErrorResponse(MqttV500ConnectReasonCode.NotAuthorized);
                }
            }
        }
        #endregion

        #region: Snippet:MqttDisconnectedEventTriggerFunction
        [FunctionName("mqttDisconnected")]
        public static void Run(
        [WebPubSubTrigger("hub", WebPubSubEventType.System, "disconnected", ClientProtocols = WebPubSubTriggerAcceptedClientProtocols.Mqtt)] MqttDisconnectedEventRequest request,
        ILogger log)
        {
        }
        #endregion

        [FunctionName("connect")]
        public static WebPubSubEventResponse Run(
        [WebPubSubTrigger("hub", WebPubSubEventType.System, "connect")] ConnectEventRequest request,
        ILogger log)
        {
            if (request.ConnectionContext.ConnectionId != "attacker")
            {
                return request.CreateResponse(request.ConnectionContext.UserId, new string[] { "group1", "group2" }, "websocket-subprotocol", new string[] { "webpubsub.joinLeaveGroup.group1", "webpubsub.sendToGroup.group2" });
            }
            else
            {
                return request.CreateErrorResponse(WebPubSubErrorCode.Unauthorized, "Unauthorized connection");
            }
        }
    }
}

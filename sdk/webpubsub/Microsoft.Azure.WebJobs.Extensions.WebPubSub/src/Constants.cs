// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub
{
    internal static class Constants
    {
        public static readonly char[] HeaderSeparator = { ',', ' ' };
        public const string AllowedAllOrigins = "*";

        // WebPubSubOptions can be set by customers.
        public const string WebPubSubConnectionStringName = "WebPubSubConnectionString";
        public const string HubNameStringName = "WebPubSubHub";
        public const string WebPubSubValidationStringName = "WebPubSubValidation";

        public const string MqttWebSocketSubprotocolValue = "mqtt";

        public static class ContentTypes
        {
            public const string JsonContentType = "application/json";
            public const string BinaryContentType = "application/octet-stream";
            public const string PlainTextContentType = "text/plain";
        }

        public static class Events
        {
            public const string ConnectEvent = "connect";
            public const string ConnectedEvent = "connected";
            public const string MessageEvent = "message";
            public const string DisconnectedEvent = "disconnected";
        }

        public static class Headers
        {
            public static class CloudEvents
            {
                private const string Prefix = "ce-";
                public const string Signature = Prefix + "signature";
                public const string Hub = Prefix + "hub";
                public const string ConnectionId = Prefix + "connectionId";
                public const string Id = Prefix + "id";
                public const string Time = Prefix + "time";
                public const string SpecVersion = Prefix + "specversion";
                public const string Type = Prefix + "type";
                public const string Source = Prefix + "source";
                public const string EventName = Prefix + "eventName";
                public const string UserId = Prefix + "userId";
                public const string State = Prefix + "connectionState";
                public const string AwpsVersion = Prefix + "awpsversion";
                public const string Subprotocol = Prefix + "subprotocol";

                #region MQTT
                public const string MqttPhysicalConnectionId = Prefix + "physicalConnectionId";
                public const string MqttSessionId = Prefix + "sessionId";
                #endregion

                public const string TypeSystemPrefix = "azure.webpubsub.sys.";
                public const string TypeUserPrefix = "azure.webpubsub.user.";
            }

            public const string WebHookRequestOrigin = "WebHook-Request-Origin";
            public const string WebHookAllowedOrigin = "WebHook-Allowed-Origin";
        }

        public class ErrorMessages
        {
            public const string NotSupportedDataType = "Message data only supports text, binary, json. Current value is: ";
            public const string NotValidWebPubSubRequest = "Invalid request that missing required fields.";
            public const string SignatureValidationFailed = "Invalid request signature.";
        }
    }
}

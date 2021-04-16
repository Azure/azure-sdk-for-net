// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub
{
    public abstract class ServiceResponse
    {
    }

    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class MessageResponse : ServiceResponse
    {
        [JsonProperty(Required = Required.Always)]
        public WebPubSubMessage Message { get; set; }

        public MessageDataType DataType { get; set; } = MessageDataType.Text;
    }

    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class ConnectResponse : ServiceResponse
    {
        [JsonProperty(Required = Required.Default)]
        public string UserId { get; set; }

        [JsonProperty(Required = Required.Default)]
        public string[] Groups { get; set; }

        [JsonProperty(Required = Required.Default)]
        public string Subprotocol { get; set; }

        [JsonProperty(Required = Required.Default)]
        public string[] Roles { get; set; }
    }

    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class ErrorResponse : ServiceResponse
    {
        [JsonProperty(Required = Required.Always)]
        public WebPubSubErrorCode Code { get; set; }

        [JsonProperty(Required = Required.Default)]
        public string ErrorMessage { get; set; }


        public ErrorResponse(WebPubSubErrorCode code, string message = null)
        {
            Code = code;
            ErrorMessage = message;
        }

        [JsonConstructor]
        public ErrorResponse()
        {
        }
    }
}

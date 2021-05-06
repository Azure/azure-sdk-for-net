// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub
{
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

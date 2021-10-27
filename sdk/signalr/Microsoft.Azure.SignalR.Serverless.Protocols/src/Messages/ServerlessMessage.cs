// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Newtonsoft.Json;

namespace Microsoft.Azure.SignalR.Serverless.Protocols
{
    /// <summary>
    /// The messages sent from Azure SignalR Service in serverless scenarios.
    /// </summary>
    public abstract class ServerlessMessage
    {
        /// <summary>
        /// The type of the message.
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public int Type { get; set; }
    }
}
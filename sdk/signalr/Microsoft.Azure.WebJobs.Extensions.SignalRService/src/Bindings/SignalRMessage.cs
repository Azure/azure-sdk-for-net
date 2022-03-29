// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Azure.SignalR;
using Newtonsoft.Json;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    /// <summary>
    /// Class that contains parameters needed for sending messages.
    /// There are three kinds of scope to send, and if more than one
    /// scopes are set, it will be resolved by the following order:
    ///     1. ConnectionId
    ///     2. UserId
    ///     3. GroupName
    /// </summary>
    [JsonObject]
    public class SignalRMessage
    {
        /// <summary>
        /// Gets or sets the id of the connection to which the message is going to send.
        /// </summary>
        [JsonProperty("connectionId")]
        public string ConnectionId { get; set; }

        /// <summary>
        /// Gets or sets the id of the user to which the message is going to send.
        /// </summary>
        [JsonProperty("userId")]
        public string UserId { get; set; }

        /// <summary>
        /// Gets or sets the name of the group to which the message is going to send.
        /// </summary>
        [JsonProperty("groupName")]
        public string GroupName { get; set; }

        /// <summary>
        /// Gets or sets the message target.
        /// </summary>
        [JsonProperty("target"), JsonRequired]
        public string Target { get; set; }

        /// <summary>
        /// Gets or sets the message arguments.
        /// </summary>
        [JsonProperty("arguments"), JsonRequired]
        public object[] Arguments { get; set; }

        /// <summary>
        /// The SignalR Service endpoints to which the message is going to send. If null, all the endpoints will be sent. You can get all the available SignalR Service endpoints with <see cref="SignalREndpointsAttribute"/> input binding.
        /// </summary>
        [JsonProperty("endpoints")]
        public ServiceEndpoint[] Endpoints { get; set; }
    }
}
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Runtime.Serialization;
using Microsoft.Azure.SignalR;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Microsoft.Azure.WebJobs.Extensions.SignalRService
{
    /// <summary>
    /// Class that contains parameters needed for group operations.
    /// Either the group operation on connectionId or userId is supported.
    /// If connectionId and userId are both set, it will be resolved by the following order:
    ///     1. ConnectionId
    ///     2. UserId
    /// </summary>
    [JsonObject]
    public class SignalRGroupAction
    {
        /// <summary>
        /// The id of the connection invoked in the group action.
        /// </summary>
        [JsonProperty("connectionId")]
        public string ConnectionId { get; set; }

        /// <summary>
        /// The id of the user invoked in the group action.
        /// </summary>
        [JsonProperty("userId")]
        public string UserId { get; set; }

        /// <summary>
        /// The name of the group invoked in the group action.
        /// </summary>
        [JsonProperty("groupName")]
        public string GroupName { get; set; }

        /// <summary>
        /// The group action type.
        /// </summary>
        [JsonProperty("action"), JsonRequired]
        public GroupAction Action { get; set; }

        /// <summary>
        /// The SignalR Service endpoints to which the group action is going to send. If null, all the endpoints will be sent. You can get all the available SignalR Service endpoints with <see cref="SignalREndpointsAttribute"/> input binding.
        /// </summary>
        [JsonProperty("endpoints")]
        public ServiceEndpoint[] Endpoints { get; set; }
    }

    /// <summary>
    /// The type of group action.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum GroupAction
    {
        /// <summary>
        /// Add a connection or a user to a group.
        /// </summary>
        [EnumMember(Value = "add")]
        Add,

        /// <summary>
        /// Remove a connection or a user from a group.
        /// </summary>
        [EnumMember(Value = "remove")]
        Remove,

        /// <summary>
        /// Remove all the connections and users from a group.
        /// </summary>
        [EnumMember(Value = "removeAll")]
        RemoveAll
    }
}
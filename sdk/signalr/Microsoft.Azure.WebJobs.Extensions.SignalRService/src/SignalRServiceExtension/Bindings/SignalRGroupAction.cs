// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

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
        [JsonProperty("connectionId")]
        public string ConnectionId { get; set; }

        [JsonProperty("userId")]
        public string UserId { get; set; }

        [JsonProperty("groupName")]
        public string GroupName { get; set; }

        [JsonProperty("action"), JsonRequired]
        public GroupAction Action { get; set; }

        [JsonProperty("endpoints")]
        public ServiceEndpoint[] Endpoints { get; set; }
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum GroupAction
    {
        [EnumMember(Value = "add")]
        Add,

        [EnumMember(Value = "remove")]
        Remove,

        [EnumMember(Value = "removeAll")]
        RemoveAll
    }
}
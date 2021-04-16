// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub
{
    /// <summary>
    /// Supported operations of rest calls.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum WebPubSubOperation
    {
        [EnumMember(Value = "sendToAll")]
        SendToAll,
        [EnumMember(Value = "closeClientConnection")]
        CloseClientConnection,
        [EnumMember(Value = "sendToConnection")]
        SendToConnection,
        [EnumMember(Value = "sendToGroup")]
        SendToGroup,
        [EnumMember(Value = "addConnectionToGroup")]
        AddConnectionToGroup,
        [EnumMember(Value = "removeConnectionFromGroup")]
        RemoveConnectionFromGroup,
        [EnumMember(Value = "sendToUser")]
        SendToUser,
        [EnumMember(Value = "addToGroup")]
        AddUserToGroup,
        [EnumMember(Value = "removeUserFromGroup")]
        RemoveUserFromGroup,
        [EnumMember(Value = "removeUserFromAllGroups")]
        RemoveUserFromAllGroups,
        [EnumMember(Value = "grandGroupPermission")]
        GrantGroupPermission,
        [EnumMember(Value = "revokeGroupPermission")]
        RevokeGroupPermission
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Messaging.WebPubSub;
using Microsoft.Azure.WebPubSub.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub
{
    /// <summary>
    /// Abstract class of operation to invoke service.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public abstract class WebPubSubOperation
    {
        internal string OperationKind
        {
            get
            {
                return GetType().Name;
            }
            set
            {
                // used in type-less for deserialize.
                _ = value;
            }
        }

        /// <summary>
        /// Create an instance of operation AddConnectionToGroup for output binding.
        /// </summary>
        /// <param name="connectionId">Target connectionId.</param>
        /// <param name="group">Target group.</param>
        /// <returns>An instance of AddConnectionToGroup.</returns>
        public static AddConnectionToGroup AddConnectionToGroup(string connectionId, string group)
        {
            return new AddConnectionToGroup
            {
                ConnectionId = connectionId,
                Group = group
            };
        }

        /// <summary>
        /// Create an instance of operation AddUserToGroup for output binding.
        /// </summary>
        /// <param name="userId">Target userId.</param>
        /// <param name="group">Target group.</param>
        /// <returns>An instance of AddUserToGroup.</returns>
        public static AddUserToGroup AddUserToGroup(string userId, string group)
        {
            return new AddUserToGroup
            {
                UserId = userId,
                Group = group
            };
        }

        /// <summary>
        /// Create an instance of operation CloseAllConnections for output binding.
        /// </summary>
        /// <param name="excluded">ConnectionIds to exclude.</param>
        /// <param name="reason">Close reason.</param>
        /// <returns>An instance of CloseAllConnections.</returns>
        public static CloseAllConnections CloseAllConnections(IList<string> excluded, string reason)
        {
            return new CloseAllConnections
            {
                Excluded = excluded,
                Reason = reason
            };
        }

        /// <summary>
        /// Create an instance of operation CloseClientConnection for output binding.
        /// </summary>
        /// <param name="connectionId">Target connectionId.</param>
        /// <param name="reason">Close reason.</param>
        /// <returns>An instance of CloseClientConnection.</returns>
        public static CloseClientConnection CloseClientConnection(string connectionId, string reason)
        {
            return new CloseClientConnection
            {
                ConnectionId = connectionId,
                Reason = reason
            };
        }

        /// <summary>
        /// Create an instance of operation CloseGroupConnections for output binding.
        /// </summary>
        /// <param name="group">Target group.</param>
        /// <param name="excluded">ConnectionIds to exclude.</param>
        /// <param name="reason">Close reason.</param>
        /// <returns>An instance of CloseGroupConnections.</returns>
        public static CloseGroupConnections CloseGroupConnections(string group, IList<string> excluded, string reason)
        {
            return new CloseGroupConnections
            {
                Group = group,
                Excluded = excluded,
                Reason = reason
            };
        }

        /// <summary>
        /// Create an instance of operation GrantPermission for output binding.
        /// </summary>
        /// <param name="connectionId">Target connectionId.</param>
        /// <param name="permission">Target permission.</param>
        /// <param name="targetName">Target name.</param>
        /// <returns>An instance of GrantPermission.</returns>
        public static GrantPermission GrantPermission(string connectionId, WebPubSubPermission permission, string targetName)
        {
            return new GrantPermission
            {
                ConnectionId = connectionId,
                Permission = permission,
                TargetName = targetName
            };
        }

        /// <summary>
        /// Create an instance of operation RemoveConnectionFromGroup for output binding.
        /// </summary>
        /// <param name="connectionId">Target connectionId.</param>
        /// <param name="group">Target group.</param>
        /// <returns>An instance of RemoveConnectionFromGroup.</returns>
        public static RemoveConnectionFromGroup RemoveConnectionFromGroup(string connectionId, string group)
        {
            return new RemoveConnectionFromGroup
            {
                ConnectionId = connectionId,
                Group = group
            };
        }

        /// <summary>
        /// Create an instance of operation RemoveUserFromAllGroups for output binding.
        /// </summary>
        /// <param name="userId">Target userId.</param>
        /// <returns>An instance of RemoveUserFromAllGroups.</returns>
        public static RemoveUserFromAllGroups RemoveUserFromAllGroups(string userId)
        {
            return new RemoveUserFromAllGroups
            {
                UserId = userId
            };
        }

        /// <summary>
        /// Create an instance of operation RemoveUserFromGroup for output binding.
        /// </summary>
        /// <param name="userId">Target userId.</param>
        /// <param name="group">Target group.</param>
        /// <returns>An instance of RemoveUserFromGroup.</returns>
        public static RemoveUserFromGroup RemoveUserFromGroup(string userId, string group)
        {
            return new RemoveUserFromGroup
            {
                UserId = userId,
                Group = group
            };
        }

        /// <summary>
        /// Create an instance of operation RevokePermission for output binding.
        /// </summary>
        /// <param name="connectionId">Target connectionId.</param>
        /// <param name="permission">Target permission.</param>
        /// <param name="targetName">Target name.</param>
        /// <returns>An instance of RevokePermission.</returns>
        public static RevokePermission RevokePermission(string connectionId, WebPubSubPermission permission, string targetName)
        {
            return new RevokePermission
            {
                ConnectionId = connectionId,
                Permission = permission,
                TargetName = targetName
            };
        }

        /// <summary>
        /// Create an instance of SendToAll for output binding.
        /// </summary>
        /// <param name="data">Web PubSub message data.</param>
        /// <param name="dataType">Web PubSub message data type.</param>
        /// <param name="excluded">ConnectionIds to exclude.</param>
        /// <returns>SendToAll</returns>
        public static SendToAll SendToAll(BinaryData data, WebPubSubDataType dataType, IList<string> excluded = null)
        {
            return new SendToAll
            {
                Data = data,
                DataType = dataType,
                Excluded = excluded
            };
        }

        /// <summary>
        /// Create an instance of operation SendToAll for output binding.
        /// </summary>
        /// <param name="data">Web PubSub message data.</param>
        /// <param name="dataType">Web PubSub message data type.</param>
        /// <param name="excluded">ConnectionIds to exclude.</param>
        /// <returns>An instance of SendToAll.</returns>
        public static SendToAll SendToAll(string data, WebPubSubDataType dataType = WebPubSubDataType.Text, IList<string> excluded = null)
        {
            return new SendToAll
            {
                Data = BinaryData.FromString(data),
                DataType = dataType,
                Excluded = excluded
            };
        }

        /// <summary>
        /// Create an instance of SendToConnection for output binding.
        /// </summary>
        /// <param name="connectionId">Target connectionId.</param>
        /// <param name="data">Message data.</param>
        /// <param name="dataType">Message data type.</param>
        /// <returns>An instance of SendToConnection.</returns>
        public static SendToConnection SendToConnection(string connectionId, BinaryData data, WebPubSubDataType dataType)
        {
            return new SendToConnection
            {
                ConnectionId = connectionId,
                Data = data,
                DataType = dataType
            };
        }

        /// <summary>
        /// Create an instance of SendToConnection for output binding.
        /// </summary>
        /// <param name="connectionId">Target connectionId.</param>
        /// <param name="data">Message data.</param>
        /// <param name="dataType">Message data type.</param>
        /// <returns>An instance of SendToConnection.</returns>
        public static SendToConnection SendToConnection(string connectionId, string data, WebPubSubDataType dataType = WebPubSubDataType.Text)
        {
            return new SendToConnection
            {
                ConnectionId = connectionId,
                Data = BinaryData.FromString(data),
                DataType = dataType
            };
        }

        /// <summary>
        /// Create an instance of SendToGroup for output binding.
        /// </summary>
        /// <param name="group">Target group.</param>
        /// <param name="data">Message data.</param>
        /// <param name="dataType">Message data type.</param>
        /// <param name="excluded">ConnectionIds to exclude.</param>
        /// <returns>An instance of SendToGroup.</returns>
        public static SendToGroup SendToGroup(string group, BinaryData data, WebPubSubDataType dataType, IList<string> excluded = null)
        {
            return new SendToGroup
            {
                Group = group,
                Data = data,
                DataType = dataType,
                Excluded = excluded
            };
        }

        /// <summary>
        /// Create an instance of SendToGroup for output binding.
        /// </summary>
        /// <param name="group">Target group.</param>
        /// <param name="data">Message data.</param>
        /// <param name="dataType">Message data type.</param>
        /// <param name="excluded">ConnectionIds to exclude.</param>
        /// <returns>An instance of SendToGroup.</returns>
        public static SendToGroup SendToGroup(string group, string data, WebPubSubDataType dataType = WebPubSubDataType.Text, IList<string> excluded = null)
        {
            return new SendToGroup
            {
                Group = group,
                Data = BinaryData.FromString(data),
                DataType = dataType,
                Excluded = excluded
            };
        }

        /// <summary>
        /// Create an instance of SendToUser for output binding.
        /// </summary>
        /// <param name="userId">Target userId.</param>
        /// <param name="data">Message data.</param>
        /// <param name="dataType">Message data type.</param>
        /// <returns>An instance of SendToUser.</returns>

        public static SendToUser SendToUser(string userId, BinaryData data, WebPubSubDataType dataType)
        {
            return new SendToUser
            {
                UserId = userId,
                Data = data,
                DataType = dataType
            };
        }

        /// <summary>
        /// Create an instance of SendToUser for output binding.
        /// </summary>
        /// <param name="userId">Target userId.</param>
        /// <param name="data">Message data.</param>
        /// <param name="dataType">Message data type.</param>
        /// <returns>An instance of SendToUser.</returns>

        public static SendToUser SendToUser(string userId, string data, WebPubSubDataType dataType = WebPubSubDataType.Text)
        {
            return new SendToUser
            {
                UserId = userId,
                Data = BinaryData.FromString(data),
                DataType = dataType
            };
        }
    }
}

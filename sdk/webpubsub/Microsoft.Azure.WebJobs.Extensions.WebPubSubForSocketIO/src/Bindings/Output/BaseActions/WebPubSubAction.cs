// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Messaging.WebPubSub;
using Microsoft.Azure.WebPubSub.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSubForSocketIO.BaseActions
{
    /// <summary>
    /// Abstract class of operation to invoke service.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    internal abstract class WebPubSubAction
    {
        internal string ActionName
        {
            get
            {
                return GetType().Name;
            }
        }

        /// <summary>
        /// Creates an instance of <see cref="AddConnectionToGroupAction"></see> for output binding.
        /// </summary>
        /// <param name="connectionId">Target connectionId.</param>
        /// <param name="group">Target group.</param>
        /// <returns>An instance of <see cref="AddConnectionToGroupAction"></see>.</returns>
        public static AddConnectionToGroupAction CreateAddConnectionToGroupAction(string connectionId, string group)
        {
            return new AddConnectionToGroupAction
            {
                ConnectionId = connectionId,
                Group = group
            };
        }

        /// <summary>
        /// Creates an instance of <see cref="CloseAllConnectionsAction"></see> for output binding.
        /// </summary>
        /// <param name="excluded">ConnectionIds to exclude.</param>
        /// <param name="reason">Close reason.</param>
        /// <returns>An instance of <see cref="CloseAllConnectionsAction"></see>.</returns>
        public static CloseAllConnectionsAction CreateCloseAllConnectionsAction(IEnumerable<string> excluded = null, string reason = null)
        {
            return new CloseAllConnectionsAction
            {
                Excluded = excluded?.ToList(),
                Reason = reason
            };
        }

        /// <summary>
        /// Creates an instance of <see cref="CloseClientConnectionAction"></see> for output binding.
        /// </summary>
        /// <param name="connectionId">Target connectionId.</param>
        /// <param name="reason">Close reason.</param>
        /// <returns>An instance of <see cref="CloseClientConnectionAction"></see>.</returns>
        public static CloseClientConnectionAction CreateCloseClientConnectionAction(string connectionId, string reason = null)
        {
            return new CloseClientConnectionAction
            {
                ConnectionId = connectionId,
                Reason = reason
            };
        }

        /// <summary>
        /// Creates an instance of <see cref="CloseGroupConnectionsAction"></see> for output binding.
        /// </summary>
        /// <param name="group">Target group.</param>
        /// <param name="excluded">ConnectionIds to exclude.</param>
        /// <param name="reason">Close reason.</param>
        /// <returns>An instance of <see cref="CloseGroupConnectionsAction"></see>.</returns>
        public static CloseGroupConnectionsAction CreateCloseGroupConnectionsAction(string group, IEnumerable<string> excluded = null, string reason = null)
        {
            return new CloseGroupConnectionsAction
            {
                Group = group,
                Excluded = excluded?.ToList(),
                Reason = reason
            };
        }

        /// <summary>
        /// Creates an instance of <see cref="RemoveConnectionFromGroupAction"></see> for output binding.
        /// </summary>
        /// <param name="connectionId">Target connectionId.</param>
        /// <param name="group">Target group.</param>
        /// <returns>An instance of <see cref="RemoveConnectionFromGroupAction"></see>.</returns>
        public static RemoveConnectionFromGroupAction CreateRemoveConnectionFromGroupAction(string connectionId, string group)
        {
            return new RemoveConnectionFromGroupAction
            {
                ConnectionId = connectionId,
                Group = group
            };
        }

        /// <summary>
        /// Creates an instance of <see cref="SendToAllAction"></see> for output binding.
        /// </summary>
        /// <param name="data">Web PubSub message data.</param>
        /// <param name="dataType">Web PubSub message data type.</param>
        /// <param name="excluded">ConnectionIds to exclude.</param>
        /// <returns>An instance of <see cref="SendToAllAction"></see>.</returns>
        public static SendToAllAction CreateSendToAllAction(BinaryData data, WebPubSubDataType dataType, IEnumerable<string> excluded = null)
        {
            return new SendToAllAction
            {
                Data = data,
                DataType = dataType,
                Excluded = excluded?.ToList(),
            };
        }

        /// <summary>
        /// Creates an instance of <see cref="SendToAllAction"></see> for output binding.
        /// </summary>
        /// <param name="data">Web PubSub message data.</param>
        /// <param name="dataType">Web PubSub message data type.</param>
        /// <param name="excluded">ConnectionIds to exclude.</param>
        /// <returns>An instance of <see cref="SendToAllAction"></see>.</returns>
        public static SendToAllAction CreateSendToAllAction(string data, WebPubSubDataType dataType = WebPubSubDataType.Text, IEnumerable<string> excluded = null)
        {
            return new SendToAllAction
            {
                Data = BinaryData.FromString(data),
                DataType = dataType,
                Excluded = excluded?.ToList(),
            };
        }

        /// <summary>
        /// Creates an instance of <see cref="SendToConnectionAction"></see> for output binding.
        /// </summary>
        /// <param name="connectionId">Target connectionId.</param>
        /// <param name="data">Message data.</param>
        /// <param name="dataType">Message data type.</param>
        /// <returns>An instance of <see cref="SendToConnectionAction"></see>.</returns>
        public static SendToConnectionAction CreateSendToConnectionAction(string connectionId, BinaryData data, WebPubSubDataType dataType)
        {
            return new SendToConnectionAction
            {
                ConnectionId = connectionId,
                Data = data,
                DataType = dataType
            };
        }

        /// <summary>
        /// Creates an instance of <see cref="SendToConnectionAction"></see> for output binding.
        /// </summary>
        /// <param name="connectionId">Target connectionId.</param>
        /// <param name="data">Message data.</param>
        /// <param name="dataType">Message data type.</param>
        /// <returns>An instance of <see cref="SendToConnectionAction"></see>.</returns>
        public static SendToConnectionAction CreateSendToConnectionAction(string connectionId, string data, WebPubSubDataType dataType = WebPubSubDataType.Text)
        {
            return new SendToConnectionAction
            {
                ConnectionId = connectionId,
                Data = BinaryData.FromString(data),
                DataType = dataType
            };
        }

        /// <summary>
        /// Creates an instance of <see cref="SendToGroupAction"></see> for output binding.
        /// </summary>
        /// <param name="group">Target group.</param>
        /// <param name="data">Message data.</param>
        /// <param name="dataType">Message data type.</param>
        /// <param name="excluded">ConnectionIds to exclude.</param>
        /// <returns>An instance of <see cref="SendToGroupAction"></see>.</returns>
        public static SendToGroupAction CreateSendToGroupAction(string group, BinaryData data, WebPubSubDataType dataType, IEnumerable<string> excluded = null)
        {
            return new SendToGroupAction
            {
                Group = group,
                Data = data,
                DataType = dataType,
                Excluded = excluded?.ToList(),
            };
        }

        /// <summary>
        /// Creates an instance of <see cref="SendToGroupAction"></see> for output binding.
        /// </summary>
        /// <param name="group">Target group.</param>
        /// <param name="data">Message data.</param>
        /// <param name="dataType">Message data type.</param>
        /// <param name="excluded">ConnectionIds to exclude.</param>
        /// <returns>An instance of <see cref="SendToGroupAction"></see>.</returns>
        public static SendToGroupAction CreateSendToGroupAction(string group, string data, WebPubSubDataType dataType = WebPubSubDataType.Text, IEnumerable<string> excluded = null)
        {
            return new SendToGroupAction
            {
                Group = group,
                Data = BinaryData.FromString(data),
                DataType = dataType,
                Excluded = excluded?.ToList(),
            };
        }
    }
}

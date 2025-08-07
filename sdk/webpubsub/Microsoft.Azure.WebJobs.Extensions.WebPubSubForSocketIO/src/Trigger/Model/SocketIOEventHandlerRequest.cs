// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSubForSocketIO.Trigger.Model
{
    /// <summary>
    /// Base class for Socket.IO events
    /// </summary>
    [DataContract]
    public abstract class SocketIOEventHandlerRequest
    {
        internal const string NamespaceProperty = "namespace";
        internal const string SocketIdProperty = "socketId";

        /// <summary>
        /// The namespace of socket
        /// </summary>
        [DataMember(Name = NamespaceProperty)]
        [JsonPropertyName(NamespaceProperty)]
        public string Namespace { get; }

        /// <summary>
        /// The socket-id of socket
        /// </summary>
        [DataMember(Name = SocketIdProperty)]
        [JsonPropertyName(SocketIdProperty)]
        public string SocketId { get; }

        /// <summary>
        /// Ctor of SocketIOEventRequest
        /// </summary>
        protected SocketIOEventHandlerRequest(string @namespace, string socketId)
        {
            Namespace = @namespace;
            SocketId = socketId;
        }
    }
}

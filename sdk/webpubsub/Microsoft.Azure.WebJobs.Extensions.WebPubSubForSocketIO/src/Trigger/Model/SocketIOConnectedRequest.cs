// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Runtime.Serialization;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSubForSocketIO.Trigger.Model
{
    /// <summary>
    /// Connected event
    /// </summary>
    [DataContract]
    public class SocketIOConnectedRequest : SocketIOEventHandlerRequest
    {
        /// <summary>
        /// Construct a SocketIOConnectedRequest
        /// </summary>
        public SocketIOConnectedRequest(string @namespace, string socketId) : base(@namespace, socketId)
        {
        }
    }
}

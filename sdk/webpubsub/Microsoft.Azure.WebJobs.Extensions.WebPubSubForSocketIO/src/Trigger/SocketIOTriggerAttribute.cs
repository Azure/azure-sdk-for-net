// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.Azure.WebPubSub.Common;
using Microsoft.Azure.WebJobs.Description;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSubForSocketIO
{
    /// <summary>
    /// Attribute used to bind a parameter to an Web PubSub for Socket.IO when a request is coming.
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter)]
#pragma warning disable CS0618 // Type or member is obsolete
    [Binding(TriggerHandlesReturnValue = true)]
#pragma warning restore CS0618 // Type or member is obsolete
    public class SocketIOTriggerAttribute : Attribute
    {
        private const string ConnectEventName = "connect";
        private const string ConnectedEventName = "connected";
        private const string DisconnectedEventName = "disconnected";

        /// <summary>
        /// Attribute used to bind a parameter to an Web PubSub for Socket.IO, when an request is from the service.
        /// </summary>
        /// <param name="hub">Target hub name of the request.</param>
        /// <param name="eventName">Target event type of the request.</param>
        /// <param name="namespace">Target namespace.</param>
        public SocketIOTriggerAttribute(string hub, string eventName, string @namespace)
            : this(hub, eventName, @namespace, null)
        {
        }

        /// <summary>
        /// Attribute used to bind a parameter to an Web PubSub for Socket.IO, when an request is from the service.
        /// </summary>
        /// <param name="hub">Target hub name of the request.</param>
        /// <param name="eventName">Target event type of the request.</param>
        public SocketIOTriggerAttribute(string hub, string eventName)
            : this(hub, eventName, "/")
        {
        }

        /// <summary>
        /// Attribute used to bind a parameter to an Web PubSub for Socket.IO, when an request is from the service.
        /// </summary>
        /// <param name="hub">Target hub name of the request.</param>
        /// <param name="eventName">Target event type of the request.</param>
        /// <param name="parameterNames">The parameter names.</param>
        public SocketIOTriggerAttribute(string hub, string eventName, string[] parameterNames)
            : this(hub, eventName, "/", parameterNames)
        {
        }

        /// <summary>
        /// Attribute used to bind a parameter to an Web PubSub for Socket.IO, when an request is from the service.
        /// </summary>
        /// <param name="hub">Target hub name of the request.</param>
        /// <param name="eventName">Target event type of the request.</param>
        /// <param name="namespace">Target namespace.</param>
        /// <param name="parameterNames">The parameter names.</param>
        public SocketIOTriggerAttribute(string hub, string eventName, string @namespace, string[] parameterNames)
        {
            Hub = hub;
            EventName = eventName;
            EventType = GetEventTypeByEventName(eventName);
            Namespace = @namespace;
            ParameterNames = parameterNames;
        }

        /// <summary>
        /// The hub of request.
        /// </summary>
        [AutoResolve]
        public string Hub { get; }

        /// <summary>
        /// The event of the request.
        /// </summary>
        [Required]
        public string EventName { get; }

        /// <summary>
        /// The event type, allowed value is system or user.
        /// </summary>
        [Required]
        internal WebPubSubEventType EventType { get; }

        /// <summary>
        /// The namespace
        /// </summary>
        [Required]
        public string Namespace { get; }

        /// <summary>
        /// Used for messages category. All the name defined in <see cref="ParameterNames"/> will map to
        /// Arguments in InvocationMessage by order. And the name can be used in parameters of method
        /// directly.
        /// </summary>
        public string[] ParameterNames { get; }

        private WebPubSubEventType GetEventTypeByEventName(string eventName)
        {
            if (string.Equals(eventName, ConnectEventName, StringComparison.OrdinalIgnoreCase)
                || string.Equals(eventName, ConnectedEventName, StringComparison.OrdinalIgnoreCase)
                || string.Equals(eventName, DisconnectedEventName, StringComparison.OrdinalIgnoreCase))
            {
                return WebPubSubEventType.System;
            }
            else
            {
                return WebPubSubEventType.User;
            }
        }
    }
}

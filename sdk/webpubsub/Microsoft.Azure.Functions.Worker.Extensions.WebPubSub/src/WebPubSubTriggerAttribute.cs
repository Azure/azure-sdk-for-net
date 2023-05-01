﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Azure.Functions.Worker.Extensions.Abstractions;

namespace Microsoft.Azure.Functions.Worker
{
    /// <summary>
    /// Binds to <see cref="WebPubSubEventRequest"/> to mark a function that should be triggered by messages sent from Web PubSub clients.
    /// </summary>
    public sealed class WebPubSubTriggerAttribute : TriggerBindingAttribute
    {
        /// <summary>
        /// Attribute used to bind a parameter to an Azure Web PubSub, when an request is from Azure Web PubSub service.
        /// </summary>
        /// <param name="hub">Target hub name of the request.</param>
        /// <param name="eventType">Target event name of the request.</param>
        /// <param name="eventName">Target event type of the request.</param>
        /// <param name="connections">Connection strings of allowed upstreams for signature checks.</param>
        public WebPubSubTriggerAttribute(string hub, WebPubSubEventType eventType, string eventName, params string[] connections)
        {
            Hub = hub;
            EventName = eventName;
            EventType = eventType;
            Connections = connections;
        }

        /// <summary>
        /// Attribute used to bind a parameter to an Azure Web PubSub, when an request is from Azure Web PubSub service.
        /// </summary>
        /// <param name="hub">Target hub name of the request.</param>
        /// <param name="eventType">Target event name of the request.</param>
        /// <param name="eventName">Target event type of the request.</param>
        public WebPubSubTriggerAttribute(string hub, WebPubSubEventType eventType, string eventName)
            : this(hub, eventType, eventName, null)
        {
        }

        /// <summary>
        /// Attribute used to bind a parameter to an Azure Web PubSub, when an request is from Azure Web PubSub service.
        /// </summary>
        /// <param name="eventType">Target event name of the request.</param>
        /// <param name="eventName">Target event type of the request.</param>
        /// <param name="connections">Connection strings of allowed upstreams for signature checks.</param>
        public WebPubSubTriggerAttribute(WebPubSubEventType eventType, string eventName, params string[] connections)
            : this("", eventType, eventName, connections)
        {
        }

        /// <summary>
        /// Attribute used to bind a parameter to an Azure Web PubSub, when an request is from Azure Web PubSub service.
        /// </summary>
        /// <param name="eventType">Target event name of the request.</param>
        /// <param name="eventName">Target event type of the request.</param>
        public WebPubSubTriggerAttribute(WebPubSubEventType eventType, string eventName)
            : this("", eventType, eventName)
        {
        }

        /// <summary>
        /// The hub of request.
        /// </summary>
        public string Hub { get; }

        /// <summary>
        /// The event of the request.
        /// </summary>
        public string EventName { get; }

        /// <summary>
        /// The event type, allowed value is system or user.
        /// </summary>
        public WebPubSubEventType EventType { get; }

        /// <summary>
        /// Allowed service upstream ConnectionString for Signature checks.
        /// </summary>
        public string[] Connections { get; }
    }
}

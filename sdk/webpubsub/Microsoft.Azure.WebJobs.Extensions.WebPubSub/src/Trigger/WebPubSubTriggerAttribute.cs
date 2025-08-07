// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.Azure.WebJobs.Description;
using Microsoft.Azure.WebPubSub.Common;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub
{
    /// <summary>
    /// Attribute used to bind a parameter to an Azure Web PubSub when a Web PubSub request is coming.
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter)]
#pragma warning disable CS0618 // Type or member is obsolete
    [Binding(TriggerHandlesReturnValue = true)]
#pragma warning restore CS0618 // Type or member is obsolete
    public class WebPubSubTriggerAttribute : Attribute
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
        public WebPubSubEventType EventType { get; }

        /// <summary>
        /// Allowed service upstream ConnectionString for Signature checks.
        /// </summary>
        public string[] Connections { get; }

        /// <summary>
        /// Specifies which client protocol can trigger the Web PubSub trigger functions. By default, it accepts all client protocols.
        /// </summary>
        public WebPubSubTriggerAcceptedClientProtocols ClientProtocols
        {
            get; set;
        }
    }
}

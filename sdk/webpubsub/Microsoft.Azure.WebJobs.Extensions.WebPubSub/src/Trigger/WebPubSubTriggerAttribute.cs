// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.ComponentModel.DataAnnotations;

using Microsoft.Azure.WebJobs.Description;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub
{
    [AttributeUsage(AttributeTargets.Parameter)]
#pragma warning disable CS0618 // Type or member is obsolete
    [Binding(TriggerHandlesReturnValue = true)]
#pragma warning restore CS0618 // Type or member is obsolete
    public class WebPubSubTriggerAttribute : Attribute
    {

        /// <summary>
        /// Used to map to method name automatically
        /// </summary>
        /// <param name="hub"></param>
        /// <param name="eventName"></param>
        /// <param name="eventType"></param>
        public WebPubSubTriggerAttribute(string hub, WebPubSubEventType eventType, string eventName)
        {
            Hub = hub;
            EventName = eventName;
            EventType = eventType;
        }

        public WebPubSubTriggerAttribute(WebPubSubEventType eventType, string eventName)
            : this ("", eventType, eventName)
        {
        }

        /// <summary>
        /// The hub of request.
        /// </summary>
        [AutoResolve]
        public string Hub { get; }
        
        /// <summary>
        /// The event of the request
        /// </summary>
        [Required]
        [AutoResolve]
        public string EventName { get; }

        /// <summary>
        /// The event type, allowed value is system or user
        /// </summary>
        [AutoResolve]
        public WebPubSubEventType EventType { get; }

    }
}

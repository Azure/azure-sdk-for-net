// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Messaging.WebPubSub.Clients
{
    /// <summary>
    /// The message representing an invoke request to the service.
    /// </summary>
    public class InvokeMessage : WebPubSubMessage
    {
        /// <summary>
        /// The invocation id
        /// </summary>
        public string InvocationId { get; }

        /// <summary>
        /// The target type of the invocation. Defaults to "event".
        /// </summary>
        public string Target { get; }

        /// <summary>
        /// The event name when targeting upstream events.
        /// </summary>
        public string EventName { get; }

        /// <summary>
        /// Type of the data
        /// </summary>
        public WebPubSubDataType DataType { get; }

        /// <summary>
        /// The data content
        /// </summary>
        public BinaryData Data { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvokeMessage"/> class.
        /// </summary>
        /// <param name="invocationId">The invocation id</param>
        /// <param name="eventName">The event name</param>
        /// <param name="data">The data content</param>
        /// <param name="dataType">Type of the data</param>
        /// <param name="target">The target type of the invocation. Defaults to "event".</param>
        public InvokeMessage(string invocationId, string eventName, BinaryData data, WebPubSubDataType dataType, string target = "event")
        {
            InvocationId = invocationId;
            Target = target;
            EventName = eventName;
            Data = data;
            DataType = dataType;
        }
    }
}

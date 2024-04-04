// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Messaging.EventGrid.Namespaces
{
    /// <summary> Receive operation details per Cloud Event. </summary>
    public partial class ReceiveDetails
    {
        /// <summary> Initializes a new instance of ReceiveDetails. </summary>
        /// <param name="brokerProperties"> The Event Broker details. </param>
        /// <param name="event"> Cloud Event details. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="brokerProperties"/> or <paramref name="event"/> is null. </exception>
        internal ReceiveDetails(BrokerProperties brokerProperties, Azure.Messaging.CloudEvent @event)
        {
            Argument.AssertNotNull(brokerProperties, nameof(brokerProperties));
            Argument.AssertNotNull(@event, nameof(@event));

            BrokerProperties = brokerProperties;
            Event = @event;
        }

        /// <summary> The Event Broker details. </summary>
        public BrokerProperties BrokerProperties { get; }
        /// <summary> Cloud Event details. </summary>
        public Azure.Messaging.CloudEvent Event { get; }
    }
}
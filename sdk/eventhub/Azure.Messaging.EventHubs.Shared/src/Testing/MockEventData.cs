// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Messaging.EventHubs.Tests
{
    /// <summary>
    ///   A mock version of <see cref="EventData" />, allowing tests to manipulate the
    ///   set of properties owned by the service when an event is consumed.
    /// </summary>
    ///
    internal class MockEventData : EventData
    {
        /// <summary>
        ///   Initializes a new instance of the <see cref="MockEventData"/> class.
        /// </summary>
        ///
        /// <param name="eventBody">The raw data to use as the body of the event.</param>
        /// <param name="properties">The set of free-form event properties to send with the event.</param>
        /// <param name="systemProperties">The set of system properties received from the Event Hubs service.</param>
        /// <param name="sequenceNumber">The sequence number assigned to the event when it was enqueued in the associated Event Hub partition.</param>
        /// <param name="offset">The offset of the event when it was received from the associated Event Hub partition.</param>
        /// <param name="enqueuedTime">The date and time, in UTC, of when the event was enqueued in the Event Hub partition.</param>
        /// <param name="partitionKey">The partition hashing key applied to the batch that the associated <see cref="EventData"/>, was sent with.</param>
        ///
        public MockEventData(ReadOnlyMemory<byte> eventBody,
                             IDictionary<string, object> properties = null,
                             IReadOnlyDictionary<string, object> systemProperties = null,
                             long sequenceNumber = long.MinValue,
                             string offset = null,
                             DateTimeOffset enqueuedTime = default,
                             string partitionKey = null) : base(BinaryData.FromBytes(eventBody),
                                                                properties,
                                                                systemProperties,
                                                                sequenceNumber,
                                                                offset,
                                                                enqueuedTime,
                                                                partitionKey)
        {
        }
    }
}

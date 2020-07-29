// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.DigitalTwins.Core
{
    /// <summary>
    /// The additional information to be used when processing a telemetry request.
    /// </summary>
    /// <remarks>
    /// For more samples, see <see href="https://github.com/Azure/azure-sdk-for-net/tree/master/sdk/digitaltwins/Azure.DigitalTwins.Core/samples">our repo samples</see>.
    /// </remarks>
    public class TelemetryOptions
    {
        /// <summary>
        /// A unique message identifier (within the scope of the digital twin id) that is commonly used for de-duplicating messages.
        /// Defaults to a random guid.
        /// </summary>
        public string MessageId { get; set; } = Guid.NewGuid().ToString();

        /// <summary>
        /// An RFC 3339 timestamp that identifies the time the telemetry was measured. It defaults to the current date/time UTC.
        /// </summary>
        public DateTimeOffset TimeStamp { get; set; } = DateTimeOffset.UtcNow;
    }
}

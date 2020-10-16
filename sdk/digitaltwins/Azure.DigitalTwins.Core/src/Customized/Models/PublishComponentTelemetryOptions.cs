// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.DigitalTwins.Core
{
    /// <inheritdoc />
    [CodeGenModel("DigitalTwinsSendComponentTelemetryOptions")]
    public partial class PublishComponentTelemetryOptions
    {
        // This class declaration changes the namespace and adds the timestamp property; do not remove.

        /// <summary>
        /// An RFC 3339 timestamp that identifies the time the telemetry was measured. It defaults to the current date/time UTC.
        /// </summary>
        public DateTimeOffset TimeStamp { get; set; } = DateTimeOffset.UtcNow;
    }
}

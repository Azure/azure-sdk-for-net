// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.DigitalTwins.Core
{
    /// <inheritdoc />
    [CodeGenModel("EventRoutesListOptions")]
    public partial class GetDigitalTwinsEventRoutesOptions
    {
        // This class declaration changes the namespace and the class name; do not remove.

        /// <summary> Identifies the request in a distributed tracing system. </summary>
        [CodeGenMember("Traceparent")]
        public string TraceParent { get; set; }

        /// <summary> Provides vendor-specific trace identification information and is a companion to TraceParent. </summary>
        [CodeGenMember("Tracestate")]
        public string TraceState { get; set; }
    }
}

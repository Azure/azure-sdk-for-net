// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.DigitalTwins.Core
{
    [CodeGenModel("DigitalTwinsUpdateRelationshipOptions")]
    internal partial class UpdateRelationshipOptions
    {
        // This class declaration changes the namespace, class name and property visibility; do not remove.

        // This class contains two properties (TraceParent ,TraceState) that are not intended to be used by the Track 2 SDKs.
        // Marking these properties as internal.

        /// <summary> Identifies the request in a distributed tracing system. </summary>
        [CodeGenMember("Traceparent")]
        internal string TraceParent { get; set; }

        /// <summary> Provides vendor-specific trace identification information and is a companion to TraceParent. </summary>
        [CodeGenMember("Tracestate")]
        internal string TraceState { get; set; }
    }
}

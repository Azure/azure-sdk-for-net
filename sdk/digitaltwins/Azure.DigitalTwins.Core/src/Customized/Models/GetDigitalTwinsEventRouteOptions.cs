// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.DigitalTwins.Core
{
    /// <inheritdoc />
    [CodeGenModel("EventRoutesGetByIdOptions")]
    internal partial class GetDigitalTwinsEventRouteOptions
    {
        // This class declaration changes the namespace, class name and property visibility; do not remove.

        // This class contains two properties (TraceParent ,TraceState, MaxItemsPerPage) that are not intended to be used by the Track 2 SDKs.
        // Marking these properties as internal.

        /// <summary> Identifies the request in a distributed tracing system. </summary>
        [CodeGenMember("Traceparent")]
        internal string TraceParent { get; set; }

        /// <summary> Provides vendor-specific trace identification information and is a companion to TraceParent. </summary>
        [CodeGenMember("Tracestate")]
        internal string TraceState { get; set; }

        // This is internal because users should not set page size here. It should be set on the pageable instances's .AsPages() method.
        internal int? MaxItemsPerPage { get; set; }
    }
}

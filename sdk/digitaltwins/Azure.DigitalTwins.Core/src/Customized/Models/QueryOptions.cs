// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.DigitalTwins.Core
{
    /// <inheritdoc />
    [CodeGenModel("QueryTwinsOptions")]
    public partial class QueryOptions
    {
        // This class declaration changes the namespace; do not remove.

        /// <summary> Identifies the request in a distributed tracing system. </summary>
        [CodeGenMember("Traceparent")]
        public string TraceParent { get; set; }

        /// <summary> Provides vendor-specific trace identification information and is a companion to TraceParent. </summary>
        [CodeGenMember("Tracestate")]
        public string TraceState { get; set; }

        // This is internal because users should not set page size here. It should be set on the pageable instances's .AsPages() method.
        internal int? MaxItemsPerPage { get; set; }
    }
}

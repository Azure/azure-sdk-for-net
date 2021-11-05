// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.DigitalTwins.Core
{
    [CodeGenModel("DigitalTwinsAddOptions")]
    internal partial class CreateOrReplaceDigitalTwinOptions
    {
        // This class declaration changes the namespace, class name and property visibility; do not remove.

        /// <summary>
        /// If-None-Match header that makes the request method conditional on a recipient cache or origin server either not having any current representation of the target resource.
        /// For more information about this property, see <see href="https://tools.ietf.org/html/rfc7232#section-3.2">RFC</see>.
        /// Acceptable values are null or <c>"*"</c>.
        /// If IfNonMatch option is null the service will replace the existing entity with the new entity.
        /// If IfNonMatch option is <c>"*"</c> the service will reject the request if the entity already exists.
        /// </summary>
        [CodeGenMember("IfNoneMatch")]
        public string IfNoneMatch { get; set; }

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

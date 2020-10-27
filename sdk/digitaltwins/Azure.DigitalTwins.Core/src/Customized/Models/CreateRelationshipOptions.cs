// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.DigitalTwins.Core
{
    /// <inheritdoc />
    [CodeGenModel("DigitalTwinsAddRelationshipOptions")]
    public partial class CreateOrReplaceRelationshipOptions
    {
        // This class declaration changes the namespace; do not remove.

        /// <summary> Identifies the request in a distributed tracing system. </summary>
        [CodeGenMember("Traceparent")]
        public string TraceParent { get; set; }

        /// <summary> Provides vendor-specific trace identification information and is a companion to TraceParent. </summary>
        [CodeGenMember("Tracestate")]
        public string TraceState { get; set; }

        /// <summary>
        /// If-Non-Match header that makes the request method conditional on a recipient cache or origin server either not having any current representation of the target resource.
        /// For more information about this property, see <see href="https://tools.ietf.org/html/rfc7232#section-3.2">RFC</see>.
        /// Acceptable values are null or "*".
        /// If IfNonMatch option is null the service will replace the existing entity with the new entity.
        /// If IfNonMatch option is "*" the service will reject the request if the entity already exists.
        /// </summary>
        [CodeGenMember("IfNoneMatch")]
        public string IfNoneMatch { get; set; }
    }
}

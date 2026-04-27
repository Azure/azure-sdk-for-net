// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;

namespace Azure.ResourceManager.Consumption.Models
{
    // Shipped v1.x exposed ConsumptionEventSummary.ETag with a public setter (the AutoRest emitter
    // treated x-ms-azure-resource etag as a regular settable property).
    // The new TypeSpec/Foundations.Resource emitter generates the property as read-only (`{ get; }`).
    // Spec-side @@visibility on EventSummary.eTag would alter the OpenAPI shape (removing readOnly),
    // so we instead rename the generated property to InternalETag via @@clientName(..., "csharp")
    // (which does not affect OpenAPI) and re-expose ETag with both getter and setter here.
    // The setter stores into a private override field; the getter prefers the override when set,
    // otherwise falls back to the deserialized InternalETag value.
    public partial class ConsumptionEventSummary
    {
        private ETag? _eTagOverride;

        /// <summary> The eTag for the resource. </summary>
        public ETag? ETag
        {
            get => _eTagOverride ?? InternalETag;
            set => _eTagOverride = value;
        }
    }
}

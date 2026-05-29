// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Billing.Models
{
    // Back-compat alias for the GA 1.2.2 `RequestType` property. The spec property is
    // `type`, the new generator emits it as `Type`, but the GA generator added a
    // disambiguating `Request` prefix. Spec-side `@@clientName` did not apply because
    // TypeSpec resolves `BillingRequestProperties.type` against the model's intrinsic
    // metadata `type` rather than the property; expose the GA name via Custom partial.
    public partial class BillingRequestProperties
    {
        /// <summary> Type of billing request. </summary>
        public BillingRequestType? RequestType
        {
            get => Type;
            set => Type = value;
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.ResourceManager.Billing;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Billing.Models
{
    // Back-compat for GA 1.2.2 BillingTransferValidationResult.Results, which was an
    // IReadOnlyList<BillingTransferValidationResultProperties>. The new MPG generator
    // emits it as IList<BillingTransferValidationResultProperties> because the underlying
    // ValidateTransferResponseProperties.results field is not explicitly @visibility(Read)
    // in the TypeSpec, and IList<T>/IReadOnlyList<T> are distinct interfaces so the change
    // is a hard MembersMustExist/MemberMustBeAvailableInBaseClass break. Suppress the
    // Generated mutable-list flatten proxy and re-expose it as the GA-shape IReadOnlyList<T>;
    // the backing ChangeTrackingList<T> implements both interfaces so the upcast is safe.
    public partial class BillingTransferValidationResult
    {
        /// <summary> The array of validation results. </summary>
        [WirePath("properties.results")]
        public IReadOnlyList<BillingTransferValidationResultProperties> Results =>
            Properties?.Results as IReadOnlyList<BillingTransferValidationResultProperties>;
    }
}

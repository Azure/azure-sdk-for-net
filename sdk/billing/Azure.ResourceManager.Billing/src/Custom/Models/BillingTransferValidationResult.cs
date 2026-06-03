// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Billing.Models
{
    [CodeGenSuppress("Results")]
    public partial class BillingTransferValidationResult
    {
        // GA 1.2.2 exposed Results as IReadOnlyList<T>; MPG flatten-proxy emits IList<T>.
        // Suppress the generated property (attribute on class) and re-expose with the GA return type.
        // The underlying ChangeTrackingList<T> implements both IList<T> and IReadOnlyList<T>,
        // so the cast is a safe O(1) reinterpretation with no allocation.
        /// <summary> The list of results of the validation. </summary>
        [WirePath("properties.results")]
        public IReadOnlyList<BillingTransferValidationResultProperties> Results
            => Properties is null ? null : (IReadOnlyList<BillingTransferValidationResultProperties>)Properties.Results;
    }
}

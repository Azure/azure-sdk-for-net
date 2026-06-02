// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.ResourceManager.CostManagement.Models
{
    // Backward-compat: baseline exposed public BenefitUtilizationSummary().
    // Generator now emits public BenefitUtilizationSummary(BillingAccountBenefitKind kind) — use that instead.
    public partial class BenefitUtilizationSummary
    {
        /// <summary> Initializes a new instance of <see cref="BenefitUtilizationSummary"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BenefitUtilizationSummary()
        {
        }
    }
}

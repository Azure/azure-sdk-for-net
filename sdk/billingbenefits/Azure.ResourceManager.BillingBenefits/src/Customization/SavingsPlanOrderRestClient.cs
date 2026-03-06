// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.BillingBenefits
{
    // Workaround: The base generator creates request methods that reference _expand field,
    // but the mgmt generator strips it from the constructor. Add it back as an uninitialized
    // field so the null-check in the request methods works correctly (always skips expand).
    internal partial class SavingsPlanOrder
    {
#pragma warning disable CS0649
        private string _expand;
#pragma warning restore CS0649
    }
}

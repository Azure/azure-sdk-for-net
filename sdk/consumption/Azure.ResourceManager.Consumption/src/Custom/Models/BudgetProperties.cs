// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Consumption.Models
{
    // Backward-compatibility: the old SDK exposed these BudgetProperties fields as nullable,
    // but the TypeSpec-generated code makes them non-nullable (required). These custom
    // property declarations preserve the nullable types for API compatibility.
    internal partial class BudgetProperties
    {
        /// <summary> The category of the budget, whether the budget tracks cost or usage. </summary>
        public BudgetCategory? Category { get; set; }

        /// <summary> The total amount of cost to track with the budget. </summary>
        public decimal? Amount { get; set; }

        /// <summary> The time covered by a budget. Tracking of the amount will be reset based on the time grain. BillingMonth, BillingQuarter, and BillingAnnual are only supported by WD customers. </summary>
        public BudgetTimeGrainType? TimeGrain { get; set; }
    }
}

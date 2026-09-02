// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Azure.ResourceManager.CostManagement.Models;

namespace Azure.ResourceManager.CostManagement
{
    public partial class BudgetData
    {
        /// <summary>
        /// The category of the budget.
        /// </summary>
        // Backward-compatibility shim. Use BudgetCategory instead.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and will be removed in a future release. Use BudgetCategory instead.")]
        public CategoryType Category
        {
            get => BudgetCategory.GetValueOrDefault();
            set => BudgetCategory = value;
        }

        /// <summary>
        /// The time covered by a budget. Tracking of the amount will be reset based on the time grain.
        /// </summary>
        // Backward-compatibility shim. Use BudgetTimeGrain instead.
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and will be removed in a future release. Use BudgetTimeGrain instead.")]
        public TimeGrainType TimeGrain
        {
            get => BudgetTimeGrain.GetValueOrDefault();
            set => BudgetTimeGrain = value;
        }
    }
}

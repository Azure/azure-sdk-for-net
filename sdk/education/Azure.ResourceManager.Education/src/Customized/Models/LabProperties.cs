// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Education.Models
{
    // The spec flattens both totalBudget and totalAllocatedBudget (both type Amount) into this
    // model, so the generator emits duplicate Currency/Value members (CS0102).
    // see https://github.com/Azure/azure-sdk-for-net/issues/60644
    [CodeGenSuppress("Currency")]
    [CodeGenSuppress("Value")]
    internal partial class LabProperties
    {
        /// <summary> The type of currency being used for the value. </summary>
        public string TotalBudgetCurrency
        {
            get
            {
                return TotalBudget is null ? default : TotalBudget.Currency;
            }
        }

        /// <summary> Amount value. </summary>
        public float? TotalBudgetValue
        {
            get
            {
                return TotalBudget is null ? default : TotalBudget.Value;
            }
        }

        /// <summary> The type of currency being used for the total allocated budget. </summary>
        public string TotalAllocatedBudgetCurrency
        {
            get
            {
                return TotalAllocatedBudget is null ? default : TotalAllocatedBudget.Currency;
            }
        }

        /// <summary> Amount value. </summary>
        public float? TotalAllocatedBudgetValue
        {
            get
            {
                return TotalAllocatedBudget is null ? default : TotalAllocatedBudget.Value;
            }
        }
    }
}

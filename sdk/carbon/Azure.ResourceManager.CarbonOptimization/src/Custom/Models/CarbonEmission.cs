// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.CarbonOptimization.Models
{
    /// <summary>
    /// The basic response for different query report, all query report result will have these information
    /// Please note <see cref="CarbonEmission"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
    /// The available derived classes include <see cref="CarbonEmissionItemDetail"/>, <see cref="CarbonEmissionMonthlySummary"/>, <see cref="CarbonEmissionOverallSummary"/>, <see cref="ResourceGroupCarbonEmissionItemDetail"/>, <see cref="ResourceGroupCarbonEmissionTopItemMonthlySummary"/>, <see cref="ResourceGroupCarbonEmissionTopItemsSummary"/>, <see cref="ResourceCarbonEmissionItemDetail"/>, <see cref="ResourceCarbonEmissionTopItemMonthlySummary"/>, <see cref="ResourceCarbonEmissionTopItemsSummary"/>, <see cref="CarbonEmissionTopItemMonthlySummary"/> and <see cref="CarbonEmissionTopItemsSummary"/>.
    /// </summary>
    public abstract partial class CarbonEmission
    {
        /// <summary> Initializes a new instance of <see cref="CarbonEmission"/>. </summary>
        /// <param name="latestMonthEmissions"> Total carbon emissions for the specified query parameters, measured in kgCO2E. This value represents total emissions over the specified date range (e.g., March-June). </param>
        /// <param name="previousMonthEmissions"> Total carbon emissions for the previous month’s date range, which is the same period as the specified date range but shifted left by one month (e.g., if the specified range is March - June, the previous month’s range will be Feb - May). The value is measured in kgCO2E. </param>
        protected CarbonEmission(double latestMonthEmissions, double previousMonthEmissions)
        {
            LatestMonthEmissions = latestMonthEmissions;
            PreviousMonthEmissions = previousMonthEmissions;
        }
    }
}

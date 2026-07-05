// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace Azure.ResourceManager.CarbonOptimization.Models
{
    /// <summary>
    /// Shared query filter parameter to configure carbon emissions data queries for all different report type defined in ReportTypeEnum.
    /// Please note <see cref="CarbonEmissionQueryFilter"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
    /// The available derived classes include <see cref="ItemDetailsQueryFilter"/>, <see cref="MonthlySummaryReportQueryFilter"/>, <see cref="OverallSummaryReportQueryFilter"/>, <see cref="TopItemsMonthlySummaryReportQueryFilter"/> and <see cref="TopItemsSummaryReportQueryFilter"/>.
    /// </summary>
    public abstract partial class CarbonEmissionQueryFilter
    {
        /// <summary> Initializes a new instance of <see cref="CarbonEmissionQueryFilter"/>. </summary>
        /// <param name="dateRange"> The start and end dates for carbon emissions data. Required. For ItemDetailsReport and TopItemsSummaryReport, only one month of data is supported at a time, so start and end dates should be equal within DateRange (e.g., start: 2024-06-01 and end: 2024-06-01). </param>
        /// <param name="subscriptionList"> List of subscription IDs for which carbon emissions data is requested. Required. Each subscription ID should be in lowercase format. The max length of list is 100. </param>
        /// <param name="carbonScopeList"> List of carbon emission scopes. Required. Accepts one or more values from EmissionScopeEnum (e.g., Scope1, Scope2, Scope3) in list form. The output will include the total emissions for the specified scopes. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="dateRange"/>, <paramref name="subscriptionList"/> or <paramref name="carbonScopeList"/> is null. </exception>
        protected CarbonEmissionQueryFilter(CarbonEmissionQueryDateRange dateRange, IEnumerable<string> subscriptionList, IEnumerable<CarbonEmissionScope> carbonScopeList)
        {
            Argument.AssertNotNull(dateRange, nameof(dateRange));
            Argument.AssertNotNull(subscriptionList, nameof(subscriptionList));
            Argument.AssertNotNull(carbonScopeList, nameof(carbonScopeList));

            DateRange = dateRange;
            SubscriptionList = subscriptionList.ToList();
            ResourceGroupUrlList = new ChangeTrackingList<string>();
            ResourceTypeList = new ChangeTrackingList<ResourceType>();
            LocationList = new ChangeTrackingList<AzureLocation>();
            CarbonScopeList = carbonScopeList.ToList();
        }
    }
}

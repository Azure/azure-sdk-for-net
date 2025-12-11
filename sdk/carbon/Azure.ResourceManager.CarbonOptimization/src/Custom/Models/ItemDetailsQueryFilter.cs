// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.CarbonOptimization.Models
{
    /// <summary> Query Parameters for ItemDetailsReport. </summary>
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSerialization(nameof(ResourceTypeList), DeserializationValueHook = nameof(DeserializeResourceTypeList))]
    public partial class ItemDetailsQueryFilter : CarbonEmissionQueryFilter
    {
        /// <summary> Initializes a new instance of <see cref="ItemDetailsQueryFilter"/>. </summary>
        /// <param name="dateRange"> The start and end dates for carbon emissions data. Required. For ItemDetailsReport and TopItemsSummaryReport, only one month of data is supported at a time, so start and end dates should be equal within DateRange (e.g., start: 2024-06-01 and end: 2024-06-01). </param>
        /// <param name="subscriptionList"> List of subscription IDs for which carbon emissions data is requested. Required. Each subscription ID should be in lowercase format. The max length of list is 100. </param>
        /// <param name="carbonScopeList"> List of carbon emission scopes. Required. Accepts one or more values from EmissionScopeEnum (e.g., Scope1, Scope2, Scope3) in list form. The output will include the total emissions for the specified scopes. </param>
        /// <param name="categoryType"> Specifies the category type for detailed emissions data, such as Resource, ResourceGroup, ResourceType, Location, or Subscription. See supported types in CategoryTypeEnum. </param>
        /// <param name="orderBy"> The column name to order the results by. See supported values in OrderByColumnEnum. </param>
        /// <param name="sortDirection"> Direction for sorting results. See supported values in SortDirectionEnum. </param>
        /// <param name="pageSize"> Number of items to return in one request, max value is 5000. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="dateRange"/>, <paramref name="subscriptionList"/> or <paramref name="carbonScopeList"/> is null. </exception>
        public ItemDetailsQueryFilter(CarbonEmissionQueryDateRange dateRange, IEnumerable<string> subscriptionList, IEnumerable<CarbonEmissionScope> carbonScopeList, CarbonEmissionCategoryType categoryType, CarbonEmissionQueryOrderByColumn orderBy, CarbonEmissionQuerySortDirection sortDirection, int pageSize) : base(dateRange, subscriptionList, carbonScopeList)
        {
            Argument.AssertNotNull(dateRange, nameof(dateRange));
            Argument.AssertNotNull(subscriptionList, nameof(subscriptionList));
            Argument.AssertNotNull(carbonScopeList, nameof(carbonScopeList));

            CategoryType = categoryType;
            OrderBy = orderBy;
            SortDirection = sortDirection;
            PageSize = pageSize;
            ReportType = CarbonEmissionQueryReportType.ItemDetailsReport;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void DeserializeResourceTypeList(JsonProperty property, ref IList<ResourceType> resourceTypeList)
        {
            if (property.Value.ValueKind == JsonValueKind.Null)
            {
                return;
            }
            List<ResourceType> array = new List<ResourceType>();
            foreach (var item in property.Value.EnumerateArray())
            {
                array.Add(new ResourceType(item.GetString()));
            }
            resourceTypeList = array;
        }
    }
}

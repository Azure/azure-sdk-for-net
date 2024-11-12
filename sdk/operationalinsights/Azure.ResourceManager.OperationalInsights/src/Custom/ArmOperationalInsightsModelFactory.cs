// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.OperationalInsights;

namespace Azure.ResourceManager.OperationalInsights.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class ArmOperationalInsightsModelFactory
    {
        /// <summary> Initializes a new instance of <see cref="OperationalInsights.OperationalInsightsTableData"/>. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="retentionInDays"> The table retention in days, between 4 and 730. Setting this property to -1 will default to the workspace retention. </param>
        /// <param name="totalRetentionInDays"> The table total retention in days, between 4 and 2555. Setting this property to -1 will default to table retention. </param>
        /// <param name="archiveRetentionInDays"> The table data archive retention in days. Calculated as (totalRetentionInDays-retentionInDays). </param>
        /// <param name="searchResults"> Parameters of the search job that initiated this table. </param>
        /// <param name="restoredLogs"> Parameters of the restore operation that initiated this table. </param>
        /// <param name="resultStatistics"> Search job execution statistics. </param>
        /// <param name="plan"> Instruct the system how to handle and charge the logs ingested to this table. </param>
        /// <param name="lastPlanModifiedDate"> The timestamp that table plan was last modified (UTC). </param>
        /// <param name="schema"> Table schema. </param>
        /// <param name="provisioningState"> Table's current provisioning state. If set to 'updating', indicates a resource lock due to ongoing operation, forbidding any update to the table until the ongoing operation is concluded. </param>
        /// <param name="retentionInDaysAsDefault"> True - Value originates from workspace retention in days, False - Customer specific. </param>
        /// <param name="totalRetentionInDaysAsDefault"> True - Value originates from retention in days, False - Customer specific. </param>
        /// <returns> A new <see cref="OperationalInsights.OperationalInsightsTableData"/> instance for mocking. </returns>
        public static OperationalInsightsTableData OperationalInsightsTableData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, int? retentionInDays = null, int? totalRetentionInDays = null, int? archiveRetentionInDays = null, OperationalInsightsTableSearchResults searchResults = null, OperationalInsightsTableRestoredLogs restoredLogs = null, OperationalInsightsTableResultStatistics resultStatistics = null, OperationalInsightsTablePlan? plan = null, string lastPlanModifiedDate = null, OperationalInsightsSchema schema = null, OperationalInsightsTableProvisioningState? provisioningState = null, RetentionInDaysAsDefaultState? retentionInDaysAsDefault = null, TotalRetentionInDaysAsDefaultState? totalRetentionInDaysAsDefault = null)
            => OperationalInsightsTableData(id, name, resourceType, systemData, retentionInDays, totalRetentionInDays, archiveRetentionInDays, searchResults, restoredLogs, resultStatistics, plan, lastPlanModifiedDate, schema, provisioningState, retentionInDaysAsDefault, totalRetentionInDaysAsDefault);
    }
}

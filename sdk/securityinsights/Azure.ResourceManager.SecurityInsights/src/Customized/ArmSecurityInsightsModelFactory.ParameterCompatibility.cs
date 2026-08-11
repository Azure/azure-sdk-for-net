// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.SecurityInsights;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.SecurityInsights.Models
{
    [CodeGenSuppress("MicrosoftSecurityIncidentCreationAlertRuleTemplate", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(int?), typeof(DateTimeOffset?), typeof(DateTimeOffset?), typeof(string), typeof(string), typeof(IEnumerable<AlertRuleTemplateDataSource>), typeof(SecurityInsightsAlertRuleTemplateStatus?), typeof(IEnumerable<string>), typeof(IEnumerable<string>), typeof(MicrosoftSecurityProductName?), typeof(IEnumerable<SecurityInsightsAlertSeverity>))]
    public static partial class ArmSecurityInsightsModelFactory
    {
        // TODO: Remove these compatibility factory methods after https://github.com/Azure/azure-sdk-for-net/issues/61815 is fixed.

        /// <param name="id"> Fully qualified resource ID for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}. </param>
        /// <param name="name"> The name of the resource. </param>
        /// <param name="resourceType"> The type of the resource. E.g. "Microsoft.Compute/virtualMachines" or "Microsoft.Storage/storageAccounts". </param>
        /// <param name="systemData"> Azure Resource Manager metadata containing createdBy and modifiedBy information. </param>
        /// <param name="alertRulesCreatedByTemplateCount"> The number of alert rules that were created by this template. </param>
        /// <param name="lastUpdatedOn"> The last time that this alert rule template has been updated. </param>
        /// <param name="createdOn"> The time that this alert rule template has been added. </param>
        /// <param name="description"> The description of the alert rule template. </param>
        /// <param name="displayName"> The display name for alert rule template. </param>
        /// <param name="requiredDataConnectors"> The required data sources for this template. </param>
        /// <param name="status"> The alert rule template status. </param>
        /// <param name="displayNamesFilter"> the alerts' displayNames on which the cases will be generated. </param>
        /// <param name="displayNamesExcludeFilter"> the alerts' displayNames on which the cases will not be generated. </param>
        /// <param name="productFilter"> The alerts' productName on which the cases will be generated. </param>
        /// <param name="severitiesFilter"> the alerts' severities on which the cases will be generated. </param>
        /// <returns> A new <see cref="Models.MicrosoftSecurityIncidentCreationAlertRuleTemplate"/> instance for mocking. </returns>
        public static MicrosoftSecurityIncidentCreationAlertRuleTemplate MicrosoftSecurityIncidentCreationAlertRuleTemplate(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, SystemData systemData = default, int? alertRulesCreatedByTemplateCount = default, DateTimeOffset? createdOn = default, DateTimeOffset? lastUpdatedOn = default, string description = default, string displayName = default, IEnumerable<AlertRuleTemplateDataSource> requiredDataConnectors = default, SecurityInsightsAlertRuleTemplateStatus? status = default, IEnumerable<string> displayNamesFilter = default, IEnumerable<string> displayNamesExcludeFilter = default, MicrosoftSecurityProductName? productFilter = default, IEnumerable<SecurityInsightsAlertSeverity> severitiesFilter = default)
        {
            return new MicrosoftSecurityIncidentCreationAlertRuleTemplate(
                id,
                name,
                resourceType,
                systemData,
                default,
                default,
                alertRulesCreatedByTemplateCount is null && lastUpdatedOn is null && createdOn is null && description is null && displayName is null && requiredDataConnectors is null && status is null && displayNamesFilter is null && displayNamesExcludeFilter is null && productFilter is null && severitiesFilter is null ? default : new MicrosoftSecurityIncidentCreationAlertRuleTemplateProperties(
                    alertRulesCreatedByTemplateCount,
                    lastUpdatedOn,
                    createdOn,
                    description,
                    displayName,
                    (requiredDataConnectors ?? new ChangeTrackingList<AlertRuleTemplateDataSource>()).ToList(),
                    status,
                    default,
                    (displayNamesFilter ?? new ChangeTrackingList<string>()).ToList(),
                    (displayNamesExcludeFilter ?? new ChangeTrackingList<string>()).ToList(),
                    productFilter,
                    (severitiesFilter ?? new ChangeTrackingList<SecurityInsightsAlertSeverity>()).ToList()));
        }
    }
}

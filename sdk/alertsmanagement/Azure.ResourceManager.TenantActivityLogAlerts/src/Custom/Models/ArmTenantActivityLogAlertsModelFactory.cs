// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.TenantActivityLogAlerts.Models
{
    // The generator does not currently emit a TenantActivityLogAlertData model-factory overload.
    // Add it in custom code so tests can create the public resource model without constructing it manually.
    public static partial class ArmTenantActivityLogAlertsModelFactory
    {
        /// <param name="id"> Fully qualified resource ID for the resource. </param>
        /// <param name="name"> The name of the resource. </param>
        /// <param name="resourceType"> The type of the resource. </param>
        /// <param name="systemData"> Azure Resource Manager metadata containing createdBy and modifiedBy information. </param>
        /// <param name="tenantScope"> The tenant GUID. Must be provided for tenant-level and management group events rules. </param>
        /// <param name="scopes"> A list of resource IDs that will be used as prefixes. </param>
        /// <param name="isEnabled"> Indicates whether this Activity Log Alert rule is enabled. </param>
        /// <param name="description"> A description of this Activity Log Alert rule. </param>
        /// <param name="conditionAllOf"> The list of Activity Log Alert rule conditions. </param>
        /// <param name="actionsActionGroups"> The list of the Action Groups. </param>
        /// <param name="tags"> The resource tags. </param>
        /// <param name="location"> The location of the resource. </param>
        /// <returns> A new <see cref="TenantActivityLogAlertData"/> instance for mocking. </returns>
        public static TenantActivityLogAlertData TenantActivityLogAlertData(
            ResourceIdentifier id = default,
            string name = default,
            ResourceType resourceType = default,
            SystemData systemData = default,
            string tenantScope = default,
            IEnumerable<string> scopes = default,
            bool? isEnabled = default,
            string description = default,
            IEnumerable<TenantActivityLogAlertAnyOfOrLeafCondition> conditionAllOf = default,
            IEnumerable<TenantActivityLogAlertActionGroup> actionsActionGroups = default,
            IDictionary<string, string> tags = default,
            AzureLocation? location = default)
        {
            scopes ??= new ChangeTrackingList<string>();
            conditionAllOf ??= new ChangeTrackingList<TenantActivityLogAlertAnyOfOrLeafCondition>();
            actionsActionGroups ??= new ChangeTrackingList<TenantActivityLogAlertActionGroup>();
            tags ??= new ChangeTrackingDictionary<string, string>();

            AlertRuleProperties properties = new AlertRuleProperties(conditionAllOf)
            {
                TenantScope = tenantScope,
                IsEnabled = isEnabled,
                Description = description,
            };

            foreach (string scope in scopes)
            {
                properties.Scopes.Add(scope);
            }

            foreach (TenantActivityLogAlertActionGroup actionGroup in actionsActionGroups)
            {
                properties.ActionsActionGroups.Add(actionGroup);
            }

            return new TenantActivityLogAlertData(
                id,
                name,
                resourceType,
                systemData,
                properties,
                location,
                tags,
                new ChangeTrackingDictionary<string, System.BinaryData>());
        }
    }
}

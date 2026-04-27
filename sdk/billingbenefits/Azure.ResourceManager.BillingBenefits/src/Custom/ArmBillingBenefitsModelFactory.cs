// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.BillingBenefits;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.BillingBenefits.Models
{
    public static partial class ArmBillingBenefitsModelFactory
    {
        // The following methods are hand-copied from the generated factory to preserve the
        // original parameter names (`entityType`, `location`). Renaming a parameter is
        // source-breaking for callers using named arguments.
        // Remove these customizations once https://github.com/microsoft/typespec/issues/10463
        // is resolved.

        /// <param name="id"> Fully qualified resource ID for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}. </param>
        /// <param name="name"> The name of the resource. </param>
        /// <param name="resourceType"> The type of the resource. E.g. "Microsoft.Compute/virtualMachines" or "Microsoft.Storage/storageAccounts". </param>
        /// <param name="systemData"> Azure Resource Manager metadata containing createdBy and modifiedBy information. </param>
        /// <param name="provisioningState"> Provisioning state of MACC as assigned by RPaaS. This indicates the last operation's status. For all practical purposes, this can be ignored. For current status of MACC resource, refer to MaccStatus. </param>
        /// <param name="status"> Represents the current status of the MACC. </param>
        /// <param name="entityType"> Represents type of the object being operated on. Possible values are primary or contributor. </param>
        /// <param name="displayName"> Display name. </param>
        /// <param name="productCode"> Represents catalog UPN. </param>
        /// <param name="billingAccountResourceId"> Fully-qualified identifier of the billing account where the MACC is applied. Present only for Enterprise Agreement customers. Format must be Azure Resource ID: /providers/Microsoft.Billing/billingAccounts/{acctId:orgId}. </param>
        /// <param name="commitment"> Commitment towards the benefit. </param>
        /// <param name="startOn"> Must be start of month. Timestamp must be in the ISO date format YYYY-MM-DDT00:00:00Z. </param>
        /// <param name="endOn"> Must be end of month. Timestamp must be in the ISO date format YYYY-MM-DDT23:59:59Z. </param>
        /// <param name="systemId"> This is the globally unique identifier of the MACC which will not change for the lifetime of the MACC. </param>
        /// <param name="automaticShortfall"> Setting this to 'Enable' enables automatic shortfall charging when commitment is not met. </param>
        /// <param name="automaticShortfallSuppressReason"> Optional field to record suppression reason for automatic shortfall. </param>
        /// <param name="shortfall"> MACC shortfall. </param>
        /// <param name="milestones"> List of milestones associated with this MACC. </param>
        /// <param name="resourceId"> This is the resource identifier of either the primary MACC or the contributor. Format: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.BillingBenefits/maccs/{maccName}. </param>
        /// <param name="isAllowContributors"> Setting this to true means multi-entity. </param>
        /// <param name="primaryResourceId"> Fully-qualified resource identifier of the primary MACC. Format: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.BillingBenefits/maccs/{maccName}. </param>
        /// <param name="primaryBillingAccountResourceId"> Fully-qualified billing account resource identifier of the primary MACC. Format must be Azure Resource ID: /providers/Microsoft.Billing/billingAccounts/{acctId:orgId}. </param>
        /// <returns> A new <see cref="BillingBenefits.ContributorData"/> instance for mocking. </returns>
        public static ContributorData ContributorData(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, SystemData systemData = default, string provisioningState = default, MaccStatus? status = default, MaccEntityType? entityType = default, string displayName = default, string productCode = default, ResourceIdentifier billingAccountResourceId = default, BillingBenefitsCommitment commitment = default, DateTimeOffset? startOn = default, DateTimeOffset? endOn = default, string systemId = default, EnablementMode? automaticShortfall = default, AutomaticShortfallSuppressReason automaticShortfallSuppressReason = default, Shortfall shortfall = default, IEnumerable<MaccMilestone> milestones = default, ResourceIdentifier resourceId = default, bool? isAllowContributors = default, ResourceIdentifier primaryResourceId = default, ResourceIdentifier primaryBillingAccountResourceId = default)
        {
            return new ContributorData(
                id,
                name,
                resourceType,
                systemData,
                additionalBinaryDataProperties: null,
                provisioningState is null && status is null && entityType is null && displayName is null && productCode is null && billingAccountResourceId is null && commitment is null && startOn is null && endOn is null && systemId is null && automaticShortfall is null && automaticShortfallSuppressReason is null && shortfall is null && milestones is null && resourceId is null && isAllowContributors is null && primaryResourceId is null && primaryBillingAccountResourceId is null ? default : new MaccModelProperties(
                    provisioningState,
                    status,
                    entityType.GetValueOrDefault(),
                    displayName,
                    productCode,
                    billingAccountResourceId,
                    commitment,
                    startOn,
                    endOn,
                    systemId,
                    automaticShortfall,
                    automaticShortfallSuppressReason,
                    shortfall,
                    (milestones ?? new ChangeTrackingList<MaccMilestone>()).ToList(),
                    resourceId,
                    isAllowContributors,
                    primaryResourceId,
                    primaryBillingAccountResourceId,
                    null));
        }

        /// <param name="id"> Fully qualified resource ID for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}. </param>
        /// <param name="name"> The name of the resource. </param>
        /// <param name="resourceType"> The type of the resource. E.g. "Microsoft.Compute/virtualMachines" or "Microsoft.Storage/storageAccounts". </param>
        /// <param name="systemData"> Azure Resource Manager metadata containing createdBy and modifiedBy information. </param>
        /// <param name="tags"> Resource tags. </param>
        /// <param name="location"> The geo-location where the resource lives. </param>
        /// <param name="provisioningState"> Provisioning state of MACC as assigned by RPaaS. This indicates the last operation's status. For all practical purposes, this can be ignored. For current status of MACC resource, refer to MaccStatus. </param>
        /// <param name="status"> Represents the current status of the MACC. </param>
        /// <param name="entityType"> Represents type of the object being operated on. Possible values are primary or contributor. </param>
        /// <param name="displayName"> Display name. </param>
        /// <param name="productCode"> Represents catalog UPN. </param>
        /// <param name="billingAccountResourceId"> Fully-qualified identifier of the billing account where the MACC is applied. Present only for Enterprise Agreement customers. Format must be Azure Resource ID: /providers/Microsoft.Billing/billingAccounts/{acctId:orgId}. </param>
        /// <param name="commitment"> Commitment towards the benefit. </param>
        /// <param name="startOn"> Must be start of month. Timestamp must be in the ISO date format YYYY-MM-DDT00:00:00Z. </param>
        /// <param name="endOn"> Must be end of month. Timestamp must be in the ISO date format YYYY-MM-DDT23:59:59Z. </param>
        /// <param name="systemId"> This is the globally unique identifier of the MACC which will not change for the lifetime of the MACC. </param>
        /// <param name="automaticShortfall"> Setting this to 'Enable' enables automatic shortfall charging when commitment is not met. </param>
        /// <param name="automaticShortfallSuppressReason"> Optional field to record suppression reason for automatic shortfall. </param>
        /// <param name="shortfall"> MACC shortfall. </param>
        /// <param name="milestones"> List of milestones associated with this MACC. </param>
        /// <param name="resourceId"> This is the resource identifier of either the primary MACC or the contributor. Format: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.BillingBenefits/maccs/{maccName}. </param>
        /// <param name="isAllowContributors"> Setting this to true means multi-entity. </param>
        /// <param name="primaryResourceId"> Fully-qualified resource identifier of the primary MACC. Format: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.BillingBenefits/maccs/{maccName}. </param>
        /// <param name="primaryBillingAccountResourceId"> Fully-qualified billing account resource identifier of the primary MACC. Format must be Azure Resource ID: /providers/Microsoft.Billing/billingAccounts/{acctId:orgId}. </param>
        /// <param name="managedBy"> The fully qualified resource ID of the resource that manages this resource. Indicates if this resource is managed by another Azure resource. If this is present, complete mode deployment will not delete the resource if it is removed from the template since it is managed by another resource. </param>
        /// <param name="kind"> Metadata used by portal/tooling/etc to render different UX experiences for resources of the same type. E.g. ApiApps are a kind of Microsoft.Web/sites type.  If supported, the resource provider must validate and persist this value. </param>
        /// <param name="etag"> The etag field is <i>not</i> required. If it is provided in the response body, it must also be provided as a header per the normal etag convention.  Entity tags are used for comparing two or more entities from the same requested resource. HTTP/1.1 uses entity tags in the etag (section 14.19), If-Match (section 14.24), If-None-Match (section 14.26), and If-Range (section 14.27) header fields. </param>
        /// <param name="identity"> Managed service identity (system assigned and/or user assigned identities). </param>
        /// <param name="sku"> The resource model definition representing SKU. </param>
        /// <param name="plan"> Plan for the resource. </param>
        /// <returns> A new <see cref="BillingBenefits.MaccData"/> instance for mocking. </returns>
        public static MaccData MaccData(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, SystemData systemData = default, IDictionary<string, string> tags = default, AzureLocation location = default, string provisioningState = default, MaccStatus? status = default, MaccEntityType? entityType = default, string displayName = default, string productCode = default, ResourceIdentifier billingAccountResourceId = default, BillingBenefitsCommitment commitment = default, DateTimeOffset? startOn = default, DateTimeOffset? endOn = default, string systemId = default, EnablementMode? automaticShortfall = default, AutomaticShortfallSuppressReason automaticShortfallSuppressReason = default, Shortfall shortfall = default, IEnumerable<MaccMilestone> milestones = default, ResourceIdentifier resourceId = default, bool? isAllowContributors = default, ResourceIdentifier primaryResourceId = default, ResourceIdentifier primaryBillingAccountResourceId = default, string managedBy = default, string kind = default, string etag = default, ManagedServiceIdentity identity = default, BillingBenefitsSku sku = default, BillingBenefitsPlan plan = default)
        {
            tags ??= new ChangeTrackingDictionary<string, string>();

            return new MaccData(
                id,
                name,
                resourceType,
                systemData,
                additionalBinaryDataProperties: null,
                tags,
                location,
                provisioningState is null && status is null && entityType is null && displayName is null && productCode is null && billingAccountResourceId is null && commitment is null && startOn is null && endOn is null && systemId is null && automaticShortfall is null && automaticShortfallSuppressReason is null && shortfall is null && milestones is null && resourceId is null && isAllowContributors is null && primaryResourceId is null && primaryBillingAccountResourceId is null ? default : new MaccModelProperties(
                    provisioningState,
                    status,
                    entityType.GetValueOrDefault(),
                    displayName,
                    productCode,
                    billingAccountResourceId,
                    commitment,
                    startOn,
                    endOn,
                    systemId,
                    automaticShortfall,
                    automaticShortfallSuppressReason,
                    shortfall,
                    (milestones ?? new ChangeTrackingList<MaccMilestone>()).ToList(),
                    resourceId,
                    isAllowContributors,
                    primaryResourceId,
                    primaryBillingAccountResourceId,
                    null),
                managedBy,
                kind,
                etag,
                identity,
                sku,
                plan);
        }

        /// <param name="id"> Fully qualified resource ID for the resource. Ex - /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{resourceProviderNamespace}/{resourceType}/{resourceName}. </param>
        /// <param name="name"> The name of the resource. </param>
        /// <param name="resourceType"> The type of the resource. E.g. "Microsoft.Compute/virtualMachines" or "Microsoft.Storage/storageAccounts". </param>
        /// <param name="systemData"> Azure Resource Manager metadata containing createdBy and modifiedBy information. </param>
        /// <param name="provisioningState"> Provisioning state of MACC as assigned by RPaaS. This indicates the last operation's status. For all practical purposes, this can be ignored. For current status of MACC resource, refer to MaccStatus. </param>
        /// <param name="status"> Represents the current status of the MACC. </param>
        /// <param name="entityType"> Represents type of the object being operated on. Possible values are primary or contributor. </param>
        /// <param name="displayName"> Display name. </param>
        /// <param name="productCode"> Represents catalog UPN. </param>
        /// <param name="billingAccountResourceId"> Fully-qualified identifier of the billing account where the MACC is applied. Present only for Enterprise Agreement customers. Format must be Azure Resource ID: /providers/Microsoft.Billing/billingAccounts/{acctId:orgId}. </param>
        /// <param name="commitment"> Commitment towards the benefit. </param>
        /// <param name="startOn"> Must be start of month. Timestamp must be in the ISO date format YYYY-MM-DDT00:00:00Z. </param>
        /// <param name="endOn"> Must be end of month. Timestamp must be in the ISO date format YYYY-MM-DDT23:59:59Z. </param>
        /// <param name="systemId"> This is the globally unique identifier of the MACC which will not change for the lifetime of the MACC. </param>
        /// <param name="automaticShortfall"> Setting this to 'Enable' enables automatic shortfall charging when commitment is not met. </param>
        /// <param name="automaticShortfallSuppressReason"> Optional field to record suppression reason for automatic shortfall. </param>
        /// <param name="shortfall"> MACC shortfall. </param>
        /// <param name="milestones"> List of milestones associated with this MACC. </param>
        /// <param name="resourceId"> This is the resource identifier of either the primary MACC or the contributor. Format: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.BillingBenefits/maccs/{maccName}. </param>
        /// <param name="isAllowContributors"> Setting this to true means multi-entity. </param>
        /// <param name="primaryResourceId"> Fully-qualified resource identifier of the primary MACC. Format: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.BillingBenefits/maccs/{maccName}. </param>
        /// <param name="primaryBillingAccountResourceId"> Fully-qualified billing account resource identifier of the primary MACC. Format must be Azure Resource ID: /providers/Microsoft.Billing/billingAccounts/{acctId:orgId}. </param>
        /// <returns> A new <see cref="ApplicableMacc"/> instance for mocking. </returns>
        public static ApplicableMacc ApplicableMacc(ResourceIdentifier id = default, string name = default, ResourceType resourceType = default, SystemData systemData = default, string provisioningState = default, MaccStatus? status = default, MaccEntityType? entityType = default, string displayName = default, string productCode = default, ResourceIdentifier billingAccountResourceId = default, BillingBenefitsCommitment commitment = default, DateTimeOffset? startOn = default, DateTimeOffset? endOn = default, string systemId = default, EnablementMode? automaticShortfall = default, AutomaticShortfallSuppressReason automaticShortfallSuppressReason = default, Shortfall shortfall = default, IEnumerable<MaccMilestone> milestones = default, ResourceIdentifier resourceId = default, bool? isAllowContributors = default, ResourceIdentifier primaryResourceId = default, ResourceIdentifier primaryBillingAccountResourceId = default)
        {
            return new ApplicableMacc(
                id,
                name,
                resourceType,
                systemData,
                additionalBinaryDataProperties: null,
                provisioningState is null && status is null && entityType is null && displayName is null && productCode is null && billingAccountResourceId is null && commitment is null && startOn is null && endOn is null && systemId is null && automaticShortfall is null && automaticShortfallSuppressReason is null && shortfall is null && milestones is null && resourceId is null && isAllowContributors is null && primaryResourceId is null && primaryBillingAccountResourceId is null ? default : new MaccModelProperties(
                    provisioningState,
                    status,
                    entityType.GetValueOrDefault(),
                    displayName,
                    productCode,
                    billingAccountResourceId,
                    commitment,
                    startOn,
                    endOn,
                    systemId,
                    automaticShortfall,
                    automaticShortfallSuppressReason,
                    shortfall,
                    (milestones ?? new ChangeTrackingList<MaccMilestone>()).ToList(),
                    resourceId,
                    isAllowContributors,
                    primaryResourceId,
                    primaryBillingAccountResourceId,
                    null));
        }
    }
}

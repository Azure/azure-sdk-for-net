// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.Maintenance
{
    // Backward-compatibility customization for the Swagger-to-TypeSpec migration.
    //
    // Background: Swagger (v1.1.3) vs TypeSpec resource path modeling
    //
    // The Maintenance REST API defines ApplyUpdates operations on two different URL path patterns:
    //
    //   1. WITHOUT parent (5-segment scope — operationId "ApplyUpdateOperationGroup_Get"):
    //      /subscriptions/{sub}/resourceGroups/{rg}/providers/{providerName}/{resourceType}/{resourceName}
    //          /providers/Microsoft.Maintenance/applyUpdates/{applyUpdateName}
    //
    //   2. WITH parent (7-segment scope — operationId "ApplyUpdates_GetParent"):
    //      /subscriptions/{sub}/resourceGroups/{rg}/providers/{providerName}/{resourceParentType}/{resourceParentName}
    //          /{resourceType}/{resourceName}/providers/Microsoft.Maintenance/applyUpdates/{applyUpdateName}
    //
    // In the old Swagger SDK (v1.1.3), both path variants shared one flat "MaintenanceApplyUpdateResource"
    // class. The 6-param CreateResourceIdentifier(subscriptionId, resourceGroupName, providerName, resourceType,
    // resourceName, applyUpdateName) built the 5-segment (without-parent) path, and was part of the public API.
    //
    // Problem: TypeSpec migration splits the resource into two classes
    //
    // In ApplyUpdate.tsp, the spec defines TWO @armResourceOperations interfaces that both reference the same
    // "ApplyUpdate" model but use different OverrideResourceName suffixes to avoid CS0111 duplicate method errors:
    //
    //   - "ApplyUpdateOps" (7-param by-parent scope) → generates "MaintenanceApplyUpdateResource"
    //     (8-param CreateResourceIdentifier with resourceParentType + resourceParentName)
    //
    //   - "ApplyUpdateOperationGroupOps" (5-param scope) → generates "MaintenanceApplyUpdateOperationGroupResource"
    //     (6-param CreateResourceIdentifier, same signature as old v1.1.3)
    //
    // This means the new generated "MaintenanceApplyUpdateResource.CreateResourceIdentifier" has 8 parameters
    // (including resourceParentType and resourceParentName), which is a BREAKING CHANGE from the old 6-param
    // version. The old 6-param overload now lives in the generated "MaintenanceApplyUpdateOperationGroupResource".
    //
    // Why this custom code exists:
    //
    // This file provides the old 6-param CreateResourceIdentifier overload on MaintenanceApplyUpdateResource,
    // marked [EditorBrowsable(EditorBrowsableState.Never)], to maintain backward compatibility for existing
    // consumers who call:
    //     MaintenanceApplyUpdateResource.CreateResourceIdentifier(sub, rg, provider, type, name, applyUpdateName)
    //
    // Without this overload, those callers would get a compile error because the generated
    // MaintenanceApplyUpdateResource now only has the 8-param version.
    //
    // The path constructed here uses the WITHOUT-parent pattern (5-segment scope), which matches the old v1.1.3
    // behavior and delegates to the ApplyUpdateOperationGroup_Get REST endpoint.
    public partial class MaintenanceApplyUpdateResource
    {
        /// <summary> Generate the resource identifier of a <see cref="MaintenanceApplyUpdateResource"/> instance. </summary>
        /// <param name="subscriptionId"> The subscriptionId. </param>
        /// <param name="resourceGroupName"> The resourceGroupName. </param>
        /// <param name="providerName"> The providerName. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="resourceName"> The resourceName. </param>
        /// <param name="applyUpdateName"> The applyUpdateName. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string providerName, string resourceType, string resourceName, string applyUpdateName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/{providerName}/{resourceType}/{resourceName}/providers/Microsoft.Maintenance/applyUpdates/{applyUpdateName}";
            return new ResourceIdentifier(resourceId);
        }
    }
}

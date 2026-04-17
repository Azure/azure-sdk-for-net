// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Maintenance.Models
{
    // Backward-compatibility customization for the Swagger-to-TypeSpec migration.
    //
    // The old Swagger SDK (v1.1.3) exposed GetApplyUpdatesByParent as an extension method on
    // ResourceGroupResource with 6 individual parameters:
    //   GetApplyUpdatesByParent(providerName, resourceParentType, resourceParentName,
    //                          resourceType, resourceName, applyUpdateName)
    //
    // This corresponded to the REST API "ApplyUpdates_GetParent" path:
    //   GET /subscriptions/{sub}/resourceGroups/{rg}/providers/{providerName}/{resourceParentType}
    //       /{resourceParentName}/{resourceType}/{resourceName}
    //       /providers/Microsoft.Maintenance/applyUpdates/{applyUpdateName}
    //
    // In the TypeSpec migration, the generated code encodes (providerName, resourceParentType,
    // resourceParentName, resourceType, resourceName) inside the parent ResourceIdentifier of the
    // MaintenanceApplyUpdateResource, not as explicit method parameters. The by-parent Get is now
    // done via MaintenanceApplyUpdateResource.Get() after constructing the resource from its
    // Collection with the scope encoded in the identifier.
    //
    // This options class groups those 6 by-parent path parameters into a single object so that
    // the backward-compatible extension method (in MockableMaintenanceResourceGroupResource)
    // can accept them in the same shape as the old v1.1.3 API while internally delegating to
    // the REST client directly.

    /// <summary> The ResourceGroupResourceGetApplyUpdatesByParent operation options. </summary>
    public partial class ResourceGroupResourceGetApplyUpdatesByParentOptions
    {
        /// <summary> Initializes a new instance of <see cref="ResourceGroupResourceGetApplyUpdatesByParentOptions"/>. </summary>
        /// <param name="providerName"> Resource provider name. </param>
        /// <param name="resourceParentType"> Resource parent type. </param>
        /// <param name="resourceParentName"> Resource parent identifier. </param>
        /// <param name="resourceType"> Resource type. </param>
        /// <param name="resourceName"> Resource identifier. </param>
        /// <param name="applyUpdateName"> applyUpdate Id. </param>
        public ResourceGroupResourceGetApplyUpdatesByParentOptions(string providerName, string resourceParentType, string resourceParentName, string resourceType, string resourceName, string applyUpdateName)
        {
            ProviderName = providerName;
            ResourceParentType = resourceParentType;
            ResourceParentName = resourceParentName;
            ResourceType = resourceType;
            ResourceName = resourceName;
            ApplyUpdateName = applyUpdateName;
        }

        /// <summary> Resource provider name. </summary>
        public string ProviderName { get; }
        /// <summary> Resource parent type. </summary>
        public string ResourceParentType { get; }
        /// <summary> Resource parent identifier. </summary>
        public string ResourceParentName { get; }
        /// <summary> Resource type. </summary>
        public string ResourceType { get; }
        /// <summary> Resource identifier. </summary>
        public string ResourceName { get; }
        /// <summary> applyUpdate Id. </summary>
        public string ApplyUpdateName { get; }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Maintenance.Models
{
    // Backward-compat bridge: The TypeSpec migration uses OverrideResourceName on ExtensionOperations
    // in ConfigurationAssignment.tsp to create separate MaintenanceConfigurationAssignment*Resource/Collection
    // classes per scope variant, resolving CS0111 duplicate method errors from merging operations that
    // share the ConfigurationAssignment model across different scope paths (5-param generic, 7-param
    // by-parent, subscription, resource-group). This changes the API from flat extension methods with
    // explicit path parameters (providerName, resourceType, resourceName, etc.) to typed Resource/Collection
    // classes with scope encoded in ResourceIdentifier. These bridge methods preserve the old v1.1.3
    // parameter-based API surface using direct REST client calls.
    //
    // This options class groups the 7 by-parent path parameters into a single object for the
    // CreateOrUpdateConfigurationAssignmentByParent extension method, matching the old SDK v1.1.3 API.

    /// <summary> The ResourceGroupResourceCreateOrUpdateConfigurationAssignmentByParent operation options. </summary>
    public partial class ResourceGroupResourceCreateOrUpdateConfigurationAssignmentByParentOptions
    {
        /// <summary> Initializes a new instance of <see cref="ResourceGroupResourceCreateOrUpdateConfigurationAssignmentByParentOptions"/>. </summary>
        /// <param name="providerName"> Resource provider name. </param>
        /// <param name="resourceParentType"> Resource parent type. </param>
        /// <param name="resourceParentName"> Resource parent identifier. </param>
        /// <param name="resourceType"> Resource type. </param>
        /// <param name="resourceName"> Resource identifier. </param>
        /// <param name="configurationAssignmentName"> Configuration assignment name. </param>
        /// <param name="data"> The configurationAssignment. </param>
        public ResourceGroupResourceCreateOrUpdateConfigurationAssignmentByParentOptions(string providerName, string resourceParentType, string resourceParentName, string resourceType, string resourceName, string configurationAssignmentName, MaintenanceConfigurationAssignmentData data)
        {
            ProviderName = providerName;
            ResourceParentType = resourceParentType;
            ResourceParentName = resourceParentName;
            ResourceType = resourceType;
            ResourceName = resourceName;
            ConfigurationAssignmentName = configurationAssignmentName;
            Data = data;
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
        /// <summary> Configuration assignment name. </summary>
        public string ConfigurationAssignmentName { get; }
        /// <summary> The configurationAssignment. </summary>
        public MaintenanceConfigurationAssignmentData Data { get; }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Maintenance.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Maintenance
{
    /// <summary> A class to add extension methods to Azure.ResourceManager.Maintenance. </summary>
    public static partial class MaintenanceExtensions
    {
        /// <summary>
        /// Track maintenance updates to resource with parent
        /// Request Path: /subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/{providerName}/{resourceParentType}/{resourceParentName}/{resourceType}/{resourceName}/providers/Microsoft.Maintenance/applyUpdates/{applyUpdateName}
        /// Operation Id: ApplyUpdates_GetParent
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="providerName"> Resource provider name. </param>
        /// <param name="resourceParentType"> Resource parent type. </param>
        /// <param name="resourceParentName"> Resource parent identifier. </param>
        /// <param name="resourceType"> Resource type. </param>
        /// <param name="resourceName"> Resource identifier. </param>
        /// <param name="applyUpdateName"> applyUpdate Id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="providerName"/>, <paramref name="resourceParentType"/>, <paramref name="resourceParentName"/>, <paramref name="resourceType"/>, <paramref name="resourceName"/> or <paramref name="applyUpdateName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="providerName"/>, <paramref name="resourceParentType"/>, <paramref name="resourceParentName"/>, <paramref name="resourceType"/>, <paramref name="resourceName"/> or <paramref name="applyUpdateName"/> is null. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<MaintenanceApplyUpdateResource>> GetApplyUpdatesByParentAsync(this ResourceGroupResource resourceGroupResource, string providerName, string resourceParentType, string resourceParentName, string resourceType, string resourceName, string applyUpdateName, CancellationToken cancellationToken = default) =>
            await GetApplyUpdatesByParentAsync(resourceGroupResource, new MaintenanceExtensionsGetApplyUpdatesByParentOptions(providerName, resourceParentType, resourceParentName, resourceType, resourceName, applyUpdateName), cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Track maintenance updates to resource with parent
        /// Request Path: /subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/{providerName}/{resourceParentType}/{resourceParentName}/{resourceType}/{resourceName}/providers/Microsoft.Maintenance/applyUpdates/{applyUpdateName}
        /// Operation Id: ApplyUpdates_GetParent
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="providerName"> Resource provider name. </param>
        /// <param name="resourceParentType"> Resource parent type. </param>
        /// <param name="resourceParentName"> Resource parent identifier. </param>
        /// <param name="resourceType"> Resource type. </param>
        /// <param name="resourceName"> Resource identifier. </param>
        /// <param name="applyUpdateName"> applyUpdate Id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="providerName"/>, <paramref name="resourceParentType"/>, <paramref name="resourceParentName"/>, <paramref name="resourceType"/>, <paramref name="resourceName"/> or <paramref name="applyUpdateName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="providerName"/>, <paramref name="resourceParentType"/>, <paramref name="resourceParentName"/>, <paramref name="resourceType"/>, <paramref name="resourceName"/> or <paramref name="applyUpdateName"/> is null. </exception>
        [ForwardsClientCalls]
        public static Response<MaintenanceApplyUpdateResource> GetApplyUpdatesByParent(this ResourceGroupResource resourceGroupResource, string providerName, string resourceParentType, string resourceParentName, string resourceType, string resourceName, string applyUpdateName, CancellationToken cancellationToken = default) =>
            GetApplyUpdatesByParent(resourceGroupResource, new MaintenanceExtensionsGetApplyUpdatesByParentOptions(providerName, resourceParentType, resourceParentName, resourceType, resourceName, applyUpdateName), cancellationToken);

        /// <summary>
        /// Register configuration for resource.
        /// Request Path: /subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/{providerName}/{resourceParentType}/{resourceParentName}/{resourceType}/{resourceName}/providers/Microsoft.Maintenance/configurationAssignments/{configurationAssignmentName}
        /// Operation Id: ConfigurationAssignments_CreateOrUpdateParent
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="providerName"> Resource provider name. </param>
        /// <param name="resourceParentType"> Resource parent type. </param>
        /// <param name="resourceParentName"> Resource parent identifier. </param>
        /// <param name="resourceType"> Resource type. </param>
        /// <param name="resourceName"> Resource identifier. </param>
        /// <param name="configurationAssignmentName"> Configuration assignment name. </param>
        /// <param name="data"> The configurationAssignment. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="providerName"/>, <paramref name="resourceParentType"/>, <paramref name="resourceParentName"/>, <paramref name="resourceType"/>, <paramref name="resourceName"/> or <paramref name="configurationAssignmentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="providerName"/>, <paramref name="resourceParentType"/>, <paramref name="resourceParentName"/>, <paramref name="resourceType"/>, <paramref name="resourceName"/>, <paramref name="configurationAssignmentName"/> or <paramref name="data"/> is null. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<MaintenanceConfigurationAssignmentData>> CreateOrUpdateConfigurationAssignmentByParentAsync(this ResourceGroupResource resourceGroupResource, string providerName, string resourceParentType, string resourceParentName, string resourceType, string resourceName, string configurationAssignmentName, MaintenanceConfigurationAssignmentData data, CancellationToken cancellationToken = default) =>
            await CreateOrUpdateConfigurationAssignmentByParentAsync(resourceGroupResource, new MaintenanceExtensionsCreateOrUpdateConfigurationAssignmentByParentOptions(providerName, resourceParentType, resourceParentName, resourceType, resourceName, configurationAssignmentName, data), cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Register configuration for resource.
        /// Request Path: /subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/{providerName}/{resourceParentType}/{resourceParentName}/{resourceType}/{resourceName}/providers/Microsoft.Maintenance/configurationAssignments/{configurationAssignmentName}
        /// Operation Id: ConfigurationAssignments_CreateOrUpdateParent
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="providerName"> Resource provider name. </param>
        /// <param name="resourceParentType"> Resource parent type. </param>
        /// <param name="resourceParentName"> Resource parent identifier. </param>
        /// <param name="resourceType"> Resource type. </param>
        /// <param name="resourceName"> Resource identifier. </param>
        /// <param name="configurationAssignmentName"> Configuration assignment name. </param>
        /// <param name="data"> The configurationAssignment. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="providerName"/>, <paramref name="resourceParentType"/>, <paramref name="resourceParentName"/>, <paramref name="resourceType"/>, <paramref name="resourceName"/> or <paramref name="configurationAssignmentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="providerName"/>, <paramref name="resourceParentType"/>, <paramref name="resourceParentName"/>, <paramref name="resourceType"/>, <paramref name="resourceName"/>, <paramref name="configurationAssignmentName"/> or <paramref name="data"/> is null. </exception>
        [ForwardsClientCalls]
        public static Response<MaintenanceConfigurationAssignmentData> CreateOrUpdateConfigurationAssignmentByParent(this ResourceGroupResource resourceGroupResource, string providerName, string resourceParentType, string resourceParentName, string resourceType, string resourceName, string configurationAssignmentName, MaintenanceConfigurationAssignmentData data, CancellationToken cancellationToken = default) =>
            CreateOrUpdateConfigurationAssignmentByParent(resourceGroupResource, new MaintenanceExtensionsCreateOrUpdateConfigurationAssignmentByParentOptions(providerName, resourceParentType, resourceParentName, resourceType, resourceName, configurationAssignmentName, data), cancellationToken);

        /// <summary>
        /// Unregister configuration for resource.
        /// Request Path: /subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/{providerName}/{resourceParentType}/{resourceParentName}/{resourceType}/{resourceName}/providers/Microsoft.Maintenance/configurationAssignments/{configurationAssignmentName}
        /// Operation Id: ConfigurationAssignments_DeleteParent
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="providerName"> Resource provider name. </param>
        /// <param name="resourceParentType"> Resource parent type. </param>
        /// <param name="resourceParentName"> Resource parent identifier. </param>
        /// <param name="resourceType"> Resource type. </param>
        /// <param name="resourceName"> Resource identifier. </param>
        /// <param name="configurationAssignmentName"> Unique configuration assignment name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="providerName"/>, <paramref name="resourceParentType"/>, <paramref name="resourceParentName"/>, <paramref name="resourceType"/>, <paramref name="resourceName"/> or <paramref name="configurationAssignmentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="providerName"/>, <paramref name="resourceParentType"/>, <paramref name="resourceParentName"/>, <paramref name="resourceType"/>, <paramref name="resourceName"/> or <paramref name="configurationAssignmentName"/> is null. </exception>
        [ForwardsClientCalls]
        public static async Task<Response<MaintenanceConfigurationAssignmentData>> DeleteConfigurationAssignmentByParentAsync(this ResourceGroupResource resourceGroupResource, string providerName, string resourceParentType, string resourceParentName, string resourceType, string resourceName, string configurationAssignmentName, CancellationToken cancellationToken = default) =>
            await DeleteConfigurationAssignmentByParentAsync(resourceGroupResource, new MaintenanceExtensionsDeleteConfigurationAssignmentByParentOptions(providerName, resourceParentType, resourceParentName, resourceType, resourceName, configurationAssignmentName), cancellationToken).ConfigureAwait(false);

        /// <summary>
        /// Unregister configuration for resource.
        /// Request Path: /subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/{providerName}/{resourceParentType}/{resourceParentName}/{resourceType}/{resourceName}/providers/Microsoft.Maintenance/configurationAssignments/{configurationAssignmentName}
        /// Operation Id: ConfigurationAssignments_DeleteParent
        /// </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource" /> instance the method will execute against. </param>
        /// <param name="providerName"> Resource provider name. </param>
        /// <param name="resourceParentType"> Resource parent type. </param>
        /// <param name="resourceParentName"> Resource parent identifier. </param>
        /// <param name="resourceType"> Resource type. </param>
        /// <param name="resourceName"> Resource identifier. </param>
        /// <param name="configurationAssignmentName"> Unique configuration assignment name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="providerName"/>, <paramref name="resourceParentType"/>, <paramref name="resourceParentName"/>, <paramref name="resourceType"/>, <paramref name="resourceName"/> or <paramref name="configurationAssignmentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="providerName"/>, <paramref name="resourceParentType"/>, <paramref name="resourceParentName"/>, <paramref name="resourceType"/>, <paramref name="resourceName"/> or <paramref name="configurationAssignmentName"/> is null. </exception>
        [ForwardsClientCalls]
        public static Response<MaintenanceConfigurationAssignmentData> DeleteConfigurationAssignmentByParent(this ResourceGroupResource resourceGroupResource, string providerName, string resourceParentType, string resourceParentName, string resourceType, string resourceName, string configurationAssignmentName, CancellationToken cancellationToken = default) =>
            DeleteConfigurationAssignmentByParent(resourceGroupResource, new MaintenanceExtensionsDeleteConfigurationAssignmentByParentOptions(providerName, resourceParentType, resourceParentName, resourceType, resourceName, configurationAssignmentName), cancellationToken);
    }
}

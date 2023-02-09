// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Azure.ResourceManager.Resources;
using System.Threading.Tasks;
using System.Threading;
using Azure.Core;
using Azure.ResourceManager.Maintenance.Models;

namespace Azure.ResourceManager.Maintenance
{
    public static partial class MaintenanceExtensions
    {
        /// <summary>
        /// Track maintenance updates to resource with parent
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/{providerName}/{resourceParentType}/{resourceParentName}/{resourceType}/{resourceName}/providers/Microsoft.Maintenance/applyUpdates/{applyUpdateName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ApplyUpdates_GetParent</description>
        /// </item>
        /// </list>
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
        public static async Task<Response<MaintenanceApplyUpdateResource>> GetApplyUpdatesByParentAsync(this ResourceGroupResource resourceGroupResource, string providerName, string resourceParentType, string resourceParentName, string resourceType, string resourceName, string applyUpdateName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(providerName, nameof(providerName));
            Argument.AssertNotNullOrEmpty(resourceParentType, nameof(resourceParentType));
            Argument.AssertNotNullOrEmpty(resourceParentName, nameof(resourceParentName));
            Argument.AssertNotNullOrEmpty(resourceType, nameof(resourceType));
            Argument.AssertNotNullOrEmpty(resourceName, nameof(resourceName));
            Argument.AssertNotNullOrEmpty(applyUpdateName, nameof(applyUpdateName));

            ResourceGroupResourceGetApplyUpdatesByParentOptions options = new ResourceGroupResourceGetApplyUpdatesByParentOptions(providerName, resourceParentType, resourceParentName, resourceType, resourceName, applyUpdateName);

            return await resourceGroupResource.GetApplyUpdatesByParentAsync(options, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Track maintenance updates to resource with parent
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/{providerName}/{resourceParentType}/{resourceParentName}/{resourceType}/{resourceName}/providers/Microsoft.Maintenance/applyUpdates/{applyUpdateName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ApplyUpdates_GetParent</description>
        /// </item>
        /// </list>
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
        public static Response<MaintenanceApplyUpdateResource> GetApplyUpdatesByParent(this ResourceGroupResource resourceGroupResource, string providerName, string resourceParentType, string resourceParentName, string resourceType, string resourceName, string applyUpdateName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(providerName, nameof(providerName));
            Argument.AssertNotNullOrEmpty(resourceParentType, nameof(resourceParentType));
            Argument.AssertNotNullOrEmpty(resourceParentName, nameof(resourceParentName));
            Argument.AssertNotNullOrEmpty(resourceType, nameof(resourceType));
            Argument.AssertNotNullOrEmpty(resourceName, nameof(resourceName));
            Argument.AssertNotNullOrEmpty(applyUpdateName, nameof(applyUpdateName));

            ResourceGroupResourceGetApplyUpdatesByParentOptions options = new ResourceGroupResourceGetApplyUpdatesByParentOptions(providerName, resourceParentType, resourceParentName, resourceType, resourceName, applyUpdateName);

            return resourceGroupResource.GetApplyUpdatesByParent(options, cancellationToken);
        }

        /// <summary>
        /// Register configuration for resource.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/{providerName}/{resourceParentType}/{resourceParentName}/{resourceType}/{resourceName}/providers/Microsoft.Maintenance/configurationAssignments/{configurationAssignmentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ConfigurationAssignments_CreateOrUpdateParent</description>
        /// </item>
        /// </list>
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
        public static async Task<Response<MaintenanceConfigurationAssignmentData>> CreateOrUpdateConfigurationAssignmentByParentAsync(this ResourceGroupResource resourceGroupResource, string providerName, string resourceParentType, string resourceParentName, string resourceType, string resourceName, string configurationAssignmentName, MaintenanceConfigurationAssignmentData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(providerName, nameof(providerName));
            Argument.AssertNotNullOrEmpty(resourceParentType, nameof(resourceParentType));
            Argument.AssertNotNullOrEmpty(resourceParentName, nameof(resourceParentName));
            Argument.AssertNotNullOrEmpty(resourceType, nameof(resourceType));
            Argument.AssertNotNullOrEmpty(resourceName, nameof(resourceName));
            Argument.AssertNotNullOrEmpty(configurationAssignmentName, nameof(configurationAssignmentName));
            Argument.AssertNotNull(data, nameof(data));

            ResourceGroupResourceCreateOrUpdateConfigurationAssignmentByParentOptions options = new ResourceGroupResourceCreateOrUpdateConfigurationAssignmentByParentOptions(providerName, resourceParentType, resourceParentName, resourceType, resourceName, configurationAssignmentName, data);

            return await resourceGroupResource.CreateOrUpdateConfigurationAssignmentByParentAsync(options, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Register configuration for resource.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/{providerName}/{resourceParentType}/{resourceParentName}/{resourceType}/{resourceName}/providers/Microsoft.Maintenance/configurationAssignments/{configurationAssignmentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ConfigurationAssignments_CreateOrUpdateParent</description>
        /// </item>
        /// </list>
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
        public static Response<MaintenanceConfigurationAssignmentData> CreateOrUpdateConfigurationAssignmentByParent(this ResourceGroupResource resourceGroupResource, string providerName, string resourceParentType, string resourceParentName, string resourceType, string resourceName, string configurationAssignmentName, MaintenanceConfigurationAssignmentData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(providerName, nameof(providerName));
            Argument.AssertNotNullOrEmpty(resourceParentType, nameof(resourceParentType));
            Argument.AssertNotNullOrEmpty(resourceParentName, nameof(resourceParentName));
            Argument.AssertNotNullOrEmpty(resourceType, nameof(resourceType));
            Argument.AssertNotNullOrEmpty(resourceName, nameof(resourceName));
            Argument.AssertNotNullOrEmpty(configurationAssignmentName, nameof(configurationAssignmentName));
            Argument.AssertNotNull(data, nameof(data));

            ResourceGroupResourceCreateOrUpdateConfigurationAssignmentByParentOptions options = new ResourceGroupResourceCreateOrUpdateConfigurationAssignmentByParentOptions(providerName, resourceParentType, resourceParentName, resourceType, resourceName, configurationAssignmentName, data);

            return resourceGroupResource.CreateOrUpdateConfigurationAssignmentByParent(options, cancellationToken);
        }

        /// <summary>
        /// Unregister configuration for resource.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/{providerName}/{resourceParentType}/{resourceParentName}/{resourceType}/{resourceName}/providers/Microsoft.Maintenance/configurationAssignments/{configurationAssignmentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ConfigurationAssignments_DeleteParent</description>
        /// </item>
        /// </list>
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
        public static async Task<Response<MaintenanceConfigurationAssignmentData>> DeleteConfigurationAssignmentByParentAsync(this ResourceGroupResource resourceGroupResource, string providerName, string resourceParentType, string resourceParentName, string resourceType, string resourceName, string configurationAssignmentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(providerName, nameof(providerName));
            Argument.AssertNotNullOrEmpty(resourceParentType, nameof(resourceParentType));
            Argument.AssertNotNullOrEmpty(resourceParentName, nameof(resourceParentName));
            Argument.AssertNotNullOrEmpty(resourceType, nameof(resourceType));
            Argument.AssertNotNullOrEmpty(resourceName, nameof(resourceName));
            Argument.AssertNotNullOrEmpty(configurationAssignmentName, nameof(configurationAssignmentName));

            ResourceGroupResourceDeleteConfigurationAssignmentByParentOptions options = new ResourceGroupResourceDeleteConfigurationAssignmentByParentOptions(providerName, resourceParentType, resourceParentName, resourceType, resourceName, configurationAssignmentName);

            return await resourceGroupResource.DeleteConfigurationAssignmentByParentAsync(options, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Unregister configuration for resource.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/{providerName}/{resourceParentType}/{resourceParentName}/{resourceType}/{resourceName}/providers/Microsoft.Maintenance/configurationAssignments/{configurationAssignmentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ConfigurationAssignments_DeleteParent</description>
        /// </item>
        /// </list>
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
        public static Response<MaintenanceConfigurationAssignmentData> DeleteConfigurationAssignmentByParent(this ResourceGroupResource resourceGroupResource, string providerName, string resourceParentType, string resourceParentName, string resourceType, string resourceName, string configurationAssignmentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(providerName, nameof(providerName));
            Argument.AssertNotNullOrEmpty(resourceParentType, nameof(resourceParentType));
            Argument.AssertNotNullOrEmpty(resourceParentName, nameof(resourceParentName));
            Argument.AssertNotNullOrEmpty(resourceType, nameof(resourceType));
            Argument.AssertNotNullOrEmpty(resourceName, nameof(resourceName));
            Argument.AssertNotNullOrEmpty(configurationAssignmentName, nameof(configurationAssignmentName));

            ResourceGroupResourceDeleteConfigurationAssignmentByParentOptions options = new ResourceGroupResourceDeleteConfigurationAssignmentByParentOptions(providerName, resourceParentType, resourceParentName, resourceType, resourceName, configurationAssignmentName);

            return resourceGroupResource.DeleteConfigurationAssignmentByParent(options, cancellationToken);
        }
    }
}

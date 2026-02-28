// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.Maintenance.Mocking;
using Azure.ResourceManager.Maintenance.Models;
using Azure.ResourceManager.Resources;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Maintenance
{
    // Suppress duplicate generated methods caused by multi-scope operations
    [CodeGenSuppress("GetMaintenanceConfigurationResource", typeof(ArmClient), typeof(ResourceIdentifier))]
    // Suppress duplicate GetAll/GetAllAsync extension methods from ConfigurationAssignmentsWithinSubscription and UpdatesOperationGroup
    [CodeGenSuppress("GetAllAsync", typeof(SubscriptionResource), typeof(string), typeof(string), typeof(string), typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("GetAll", typeof(SubscriptionResource), typeof(string), typeof(string), typeof(string), typeof(string), typeof(CancellationToken))]
    public static partial class MaintenanceExtensions
    {
        /// <summary> Gets an object representing a <see cref="MaintenanceConfigurationResource"/> along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="client"> The <see cref="ArmClient"/> the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="MaintenanceConfigurationResource"/> object. </returns>
        public static MaintenanceConfigurationResource GetMaintenanceConfigurationResource(this ArmClient client, ResourceIdentifier id)
        {
            Argument.AssertNotNull(client, nameof(client));
            return GetMockableMaintenanceArmClient(client).GetMaintenanceConfigurationResource(id);
        }

        /// <summary> Gets an object representing a <see cref="MaintenancePublicConfigurationResource"/> along with the instance operations that can be performed on it but with no data. </summary>
        /// <param name="client"> The <see cref="ArmClient"/> the method will execute against. </param>
        /// <param name="id"> The resource ID of the resource to get. </param>
        /// <returns> Returns a <see cref="MaintenancePublicConfigurationResource"/> object. </returns>
        public static MaintenancePublicConfigurationResource GetMaintenancePublicConfigurationResource(this ArmClient client, ResourceIdentifier id)
        {
            Argument.AssertNotNull(client, nameof(client));
            return GetMockableMaintenanceArmClient(client).GetMaintenancePublicConfigurationResource(id);
        }

        // ===== SubscriptionResource extensions =====

        /// <summary> Gets a collection of MaintenancePublicConfigurations in the SubscriptionResource. </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource"/> the method will execute against. </param>
        public static MaintenancePublicConfigurationCollection GetMaintenancePublicConfigurations(this SubscriptionResource subscriptionResource)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return GetMockableMaintenanceSubscriptionResource(subscriptionResource).GetMaintenancePublicConfigurations();
        }

        /// <summary> Gets the specified public maintenance configuration. </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource"/> the method will execute against. </param>
        /// <param name="resourceName"> The name of the MaintenanceConfiguration. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        public static async Task<Response<MaintenancePublicConfigurationResource>> GetMaintenancePublicConfigurationAsync(this SubscriptionResource subscriptionResource, string resourceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return await GetMockableMaintenanceSubscriptionResource(subscriptionResource).GetMaintenancePublicConfigurationAsync(resourceName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets the specified public maintenance configuration. </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource"/> the method will execute against. </param>
        /// <param name="resourceName"> The name of the MaintenanceConfiguration. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        public static Response<MaintenancePublicConfigurationResource> GetMaintenancePublicConfiguration(this SubscriptionResource subscriptionResource, string resourceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return GetMockableMaintenanceSubscriptionResource(subscriptionResource).GetMaintenancePublicConfiguration(resourceName, cancellationToken);
        }

        /// <summary> Get Configuration records within a subscription. </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource"/> the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public static AsyncPageable<MaintenanceConfigurationResource> GetMaintenanceConfigurationsAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return GetMockableMaintenanceSubscriptionResource(subscriptionResource).GetMaintenanceConfigurationsAsync(cancellationToken);
        }

        /// <summary> Get Configuration records within a subscription. </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource"/> the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public static Pageable<MaintenanceConfigurationResource> GetMaintenanceConfigurations(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return GetMockableMaintenanceSubscriptionResource(subscriptionResource).GetMaintenanceConfigurations(cancellationToken);
        }

        /// <summary> Get Configuration records within a subscription. </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource"/> the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public static AsyncPageable<MaintenanceApplyUpdateResource> GetMaintenanceApplyUpdatesAsync(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return GetMockableMaintenanceSubscriptionResource(subscriptionResource).GetMaintenanceApplyUpdatesAsync(cancellationToken);
        }

        /// <summary> Get Configuration records within a subscription. </summary>
        /// <param name="subscriptionResource"> The <see cref="SubscriptionResource"/> the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public static Pageable<MaintenanceApplyUpdateResource> GetMaintenanceApplyUpdates(this SubscriptionResource subscriptionResource, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(subscriptionResource, nameof(subscriptionResource));
            return GetMockableMaintenanceSubscriptionResource(subscriptionResource).GetMaintenanceApplyUpdates(cancellationToken);
        }

        // ===== ResourceGroupResource extensions =====

        /// <summary> Gets a collection of MaintenanceApplyUpdateResources in the ResourceGroupResource. </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource"/> the method will execute against. </param>
        public static MaintenanceApplyUpdateCollection GetMaintenanceApplyUpdates(this ResourceGroupResource resourceGroupResource)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            return GetMockableMaintenanceResourceGroupResource(resourceGroupResource).GetMaintenanceApplyUpdates();
        }

        /// <summary> Get Configuration records within a subscription and resource group. </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource"/> the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public static AsyncPageable<MaintenanceApplyUpdateResource> GetMaintenanceApplyUpdatesAsync(this ResourceGroupResource resourceGroupResource, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            return GetMockableMaintenanceResourceGroupResource(resourceGroupResource).GetMaintenanceApplyUpdatesAsync(cancellationToken);
        }

        /// <summary> Get Configuration records within a subscription and resource group. </summary>
        /// <param name="resourceGroupResource"> The <see cref="ResourceGroupResource"/> the method will execute against. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public static Pageable<MaintenanceApplyUpdateResource> GetMaintenanceApplyUpdates(this ResourceGroupResource resourceGroupResource, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            return GetMockableMaintenanceResourceGroupResource(resourceGroupResource).GetMaintenanceApplyUpdates(cancellationToken);
        }

        /// <summary> Apply maintenance updates to resource. </summary>
        public static async Task<Response<MaintenanceApplyUpdateResource>> CreateOrUpdateApplyUpdateAsync(this ResourceGroupResource resourceGroupResource, string providerName, string resourceType, string resourceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            return await GetMockableMaintenanceResourceGroupResource(resourceGroupResource).CreateOrUpdateApplyUpdateAsync(providerName, resourceType, resourceName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Apply maintenance updates to resource. </summary>
        public static Response<MaintenanceApplyUpdateResource> CreateOrUpdateApplyUpdate(this ResourceGroupResource resourceGroupResource, string providerName, string resourceType, string resourceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            return GetMockableMaintenanceResourceGroupResource(resourceGroupResource).CreateOrUpdateApplyUpdate(providerName, resourceType, resourceName, cancellationToken);
        }

        /// <summary> Apply maintenance updates to resource with parent. </summary>
        public static async Task<Response<MaintenanceApplyUpdateResource>> CreateOrUpdateApplyUpdateByParentAsync(this ResourceGroupResource resourceGroupResource, string providerName, string resourceParentType, string resourceParentName, string resourceType, string resourceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            return await GetMockableMaintenanceResourceGroupResource(resourceGroupResource).CreateOrUpdateApplyUpdateByParentAsync(providerName, resourceParentType, resourceParentName, resourceType, resourceName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Apply maintenance updates to resource with parent. </summary>
        public static Response<MaintenanceApplyUpdateResource> CreateOrUpdateApplyUpdateByParent(this ResourceGroupResource resourceGroupResource, string providerName, string resourceParentType, string resourceParentName, string resourceType, string resourceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            return GetMockableMaintenanceResourceGroupResource(resourceGroupResource).CreateOrUpdateApplyUpdateByParent(providerName, resourceParentType, resourceParentName, resourceType, resourceName, cancellationToken);
        }

        /// <summary> Track maintenance updates to resource. </summary>
        [ForwardsClientCalls]
        public static async Task<Response<MaintenanceApplyUpdateResource>> GetMaintenanceApplyUpdateAsync(this ResourceGroupResource resourceGroupResource, string providerName, string resourceType, string resourceName, string applyUpdateName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            return await GetMockableMaintenanceResourceGroupResource(resourceGroupResource).GetMaintenanceApplyUpdateAsync(providerName, resourceType, resourceName, applyUpdateName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Track maintenance updates to resource. </summary>
        [ForwardsClientCalls]
        public static Response<MaintenanceApplyUpdateResource> GetMaintenanceApplyUpdate(this ResourceGroupResource resourceGroupResource, string providerName, string resourceType, string resourceName, string applyUpdateName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            return GetMockableMaintenanceResourceGroupResource(resourceGroupResource).GetMaintenanceApplyUpdate(providerName, resourceType, resourceName, applyUpdateName, cancellationToken);
        }

        /// <summary> Track maintenance updates to resource with parent. </summary>
        public static async Task<Response<MaintenanceApplyUpdateResource>> GetApplyUpdatesByParentAsync(this ResourceGroupResource resourceGroupResource, ResourceGroupResourceGetApplyUpdatesByParentOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            return await GetMockableMaintenanceResourceGroupResource(resourceGroupResource).GetApplyUpdatesByParentAsync(options, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Track maintenance updates to resource with parent. </summary>
        public static Response<MaintenanceApplyUpdateResource> GetApplyUpdatesByParent(this ResourceGroupResource resourceGroupResource, ResourceGroupResourceGetApplyUpdatesByParentOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            return GetMockableMaintenanceResourceGroupResource(resourceGroupResource).GetApplyUpdatesByParent(options, cancellationToken);
        }

        /// <summary> Track maintenance updates to resource with parent. </summary>
        public static async Task<Response<MaintenanceApplyUpdateResource>> GetApplyUpdatesByParentAsync(this ResourceGroupResource resourceGroupResource, string providerName, string resourceParentType, string resourceParentName, string resourceType, string resourceName, string applyUpdateName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            return await GetMockableMaintenanceResourceGroupResource(resourceGroupResource).GetApplyUpdatesByParentAsync(providerName, resourceParentType, resourceParentName, resourceType, resourceName, applyUpdateName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Track maintenance updates to resource with parent. </summary>
        public static Response<MaintenanceApplyUpdateResource> GetApplyUpdatesByParent(this ResourceGroupResource resourceGroupResource, string providerName, string resourceParentType, string resourceParentName, string resourceType, string resourceName, string applyUpdateName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            return GetMockableMaintenanceResourceGroupResource(resourceGroupResource).GetApplyUpdatesByParent(providerName, resourceParentType, resourceParentName, resourceType, resourceName, applyUpdateName, cancellationToken);
        }

        // ===== ConfigurationAssignment extensions =====

        /// <summary> List configurationAssignments for resource. </summary>
        public static AsyncPageable<MaintenanceConfigurationAssignmentData> GetConfigurationAssignmentsAsync(this ResourceGroupResource resourceGroupResource, string providerName, string resourceType, string resourceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            return GetMockableMaintenanceResourceGroupResource(resourceGroupResource).GetConfigurationAssignmentsAsync(providerName, resourceType, resourceName, cancellationToken);
        }

        /// <summary> List configurationAssignments for resource. </summary>
        public static Pageable<MaintenanceConfigurationAssignmentData> GetConfigurationAssignments(this ResourceGroupResource resourceGroupResource, string providerName, string resourceType, string resourceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            return GetMockableMaintenanceResourceGroupResource(resourceGroupResource).GetConfigurationAssignments(providerName, resourceType, resourceName, cancellationToken);
        }

        /// <summary> List configurationAssignments for resource with parent. </summary>
        public static AsyncPageable<MaintenanceConfigurationAssignmentData> GetConfigurationAssignmentsByParentAsync(this ResourceGroupResource resourceGroupResource, string providerName, string resourceParentType, string resourceParentName, string resourceType, string resourceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            return GetMockableMaintenanceResourceGroupResource(resourceGroupResource).GetConfigurationAssignmentsByParentAsync(providerName, resourceParentType, resourceParentName, resourceType, resourceName, cancellationToken);
        }

        /// <summary> List configurationAssignments for resource with parent. </summary>
        public static Pageable<MaintenanceConfigurationAssignmentData> GetConfigurationAssignmentsByParent(this ResourceGroupResource resourceGroupResource, string providerName, string resourceParentType, string resourceParentName, string resourceType, string resourceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            return GetMockableMaintenanceResourceGroupResource(resourceGroupResource).GetConfigurationAssignmentsByParent(providerName, resourceParentType, resourceParentName, resourceType, resourceName, cancellationToken);
        }

        /// <summary> Register configuration for resource. </summary>
        public static async Task<Response<MaintenanceConfigurationAssignmentData>> CreateOrUpdateConfigurationAssignmentAsync(this ResourceGroupResource resourceGroupResource, string providerName, string resourceType, string resourceName, string configurationAssignmentName, MaintenanceConfigurationAssignmentData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            return await GetMockableMaintenanceResourceGroupResource(resourceGroupResource).CreateOrUpdateConfigurationAssignmentAsync(providerName, resourceType, resourceName, configurationAssignmentName, data, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Register configuration for resource. </summary>
        public static Response<MaintenanceConfigurationAssignmentData> CreateOrUpdateConfigurationAssignment(this ResourceGroupResource resourceGroupResource, string providerName, string resourceType, string resourceName, string configurationAssignmentName, MaintenanceConfigurationAssignmentData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            return GetMockableMaintenanceResourceGroupResource(resourceGroupResource).CreateOrUpdateConfigurationAssignment(providerName, resourceType, resourceName, configurationAssignmentName, data, cancellationToken);
        }

        /// <summary> Register configuration for resource with parent. </summary>
        public static async Task<Response<MaintenanceConfigurationAssignmentData>> CreateOrUpdateConfigurationAssignmentByParentAsync(this ResourceGroupResource resourceGroupResource, ResourceGroupResourceCreateOrUpdateConfigurationAssignmentByParentOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            return await GetMockableMaintenanceResourceGroupResource(resourceGroupResource).CreateOrUpdateConfigurationAssignmentByParentAsync(options, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Register configuration for resource with parent. </summary>
        public static Response<MaintenanceConfigurationAssignmentData> CreateOrUpdateConfigurationAssignmentByParent(this ResourceGroupResource resourceGroupResource, ResourceGroupResourceCreateOrUpdateConfigurationAssignmentByParentOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            return GetMockableMaintenanceResourceGroupResource(resourceGroupResource).CreateOrUpdateConfigurationAssignmentByParent(options, cancellationToken);
        }

        /// <summary> Register configuration for resource with parent. </summary>
        public static async Task<Response<MaintenanceConfigurationAssignmentData>> CreateOrUpdateConfigurationAssignmentByParentAsync(this ResourceGroupResource resourceGroupResource, string providerName, string resourceParentType, string resourceParentName, string resourceType, string resourceName, string configurationAssignmentName, MaintenanceConfigurationAssignmentData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            return await GetMockableMaintenanceResourceGroupResource(resourceGroupResource).CreateOrUpdateConfigurationAssignmentByParentAsync(providerName, resourceParentType, resourceParentName, resourceType, resourceName, configurationAssignmentName, data, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Register configuration for resource with parent. </summary>
        public static Response<MaintenanceConfigurationAssignmentData> CreateOrUpdateConfigurationAssignmentByParent(this ResourceGroupResource resourceGroupResource, string providerName, string resourceParentType, string resourceParentName, string resourceType, string resourceName, string configurationAssignmentName, MaintenanceConfigurationAssignmentData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            return GetMockableMaintenanceResourceGroupResource(resourceGroupResource).CreateOrUpdateConfigurationAssignmentByParent(providerName, resourceParentType, resourceParentName, resourceType, resourceName, configurationAssignmentName, data, cancellationToken);
        }

        /// <summary> Unregister configuration for resource. </summary>
        public static async Task<Response<MaintenanceConfigurationAssignmentData>> DeleteConfigurationAssignmentAsync(this ResourceGroupResource resourceGroupResource, string providerName, string resourceType, string resourceName, string configurationAssignmentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            return await GetMockableMaintenanceResourceGroupResource(resourceGroupResource).DeleteConfigurationAssignmentAsync(providerName, resourceType, resourceName, configurationAssignmentName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Unregister configuration for resource. </summary>
        public static Response<MaintenanceConfigurationAssignmentData> DeleteConfigurationAssignment(this ResourceGroupResource resourceGroupResource, string providerName, string resourceType, string resourceName, string configurationAssignmentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            return GetMockableMaintenanceResourceGroupResource(resourceGroupResource).DeleteConfigurationAssignment(providerName, resourceType, resourceName, configurationAssignmentName, cancellationToken);
        }

        /// <summary> Unregister configuration for resource with parent. </summary>
        public static async Task<Response<MaintenanceConfigurationAssignmentData>> DeleteConfigurationAssignmentByParentAsync(this ResourceGroupResource resourceGroupResource, ResourceGroupResourceDeleteConfigurationAssignmentByParentOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            return await GetMockableMaintenanceResourceGroupResource(resourceGroupResource).DeleteConfigurationAssignmentByParentAsync(options, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Unregister configuration for resource with parent. </summary>
        public static Response<MaintenanceConfigurationAssignmentData> DeleteConfigurationAssignmentByParent(this ResourceGroupResource resourceGroupResource, ResourceGroupResourceDeleteConfigurationAssignmentByParentOptions options, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            return GetMockableMaintenanceResourceGroupResource(resourceGroupResource).DeleteConfigurationAssignmentByParent(options, cancellationToken);
        }

        /// <summary> Unregister configuration for resource with parent. </summary>
        public static async Task<Response<MaintenanceConfigurationAssignmentData>> DeleteConfigurationAssignmentByParentAsync(this ResourceGroupResource resourceGroupResource, string providerName, string resourceParentType, string resourceParentName, string resourceType, string resourceName, string configurationAssignmentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            return await GetMockableMaintenanceResourceGroupResource(resourceGroupResource).DeleteConfigurationAssignmentByParentAsync(providerName, resourceParentType, resourceParentName, resourceType, resourceName, configurationAssignmentName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Unregister configuration for resource with parent. </summary>
        public static Response<MaintenanceConfigurationAssignmentData> DeleteConfigurationAssignmentByParent(this ResourceGroupResource resourceGroupResource, string providerName, string resourceParentType, string resourceParentName, string resourceType, string resourceName, string configurationAssignmentName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            return GetMockableMaintenanceResourceGroupResource(resourceGroupResource).DeleteConfigurationAssignmentByParent(providerName, resourceParentType, resourceParentName, resourceType, resourceName, configurationAssignmentName, cancellationToken);
        }

        // ===== Update extensions =====

        /// <summary> Get updates to resources. </summary>
        public static AsyncPageable<MaintenanceUpdate> GetUpdatesAsync(this ResourceGroupResource resourceGroupResource, string providerName, string resourceType, string resourceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            return GetMockableMaintenanceResourceGroupResource(resourceGroupResource).GetUpdatesAsync(providerName, resourceType, resourceName, cancellationToken);
        }

        /// <summary> Get updates to resources. </summary>
        public static Pageable<MaintenanceUpdate> GetUpdates(this ResourceGroupResource resourceGroupResource, string providerName, string resourceType, string resourceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            return GetMockableMaintenanceResourceGroupResource(resourceGroupResource).GetUpdates(providerName, resourceType, resourceName, cancellationToken);
        }

        /// <summary> Get updates to resources with parent. </summary>
        public static AsyncPageable<MaintenanceUpdate> GetUpdatesByParentAsync(this ResourceGroupResource resourceGroupResource, string providerName, string resourceParentType, string resourceParentName, string resourceType, string resourceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            return GetMockableMaintenanceResourceGroupResource(resourceGroupResource).GetUpdatesByParentAsync(providerName, resourceParentType, resourceParentName, resourceType, resourceName, cancellationToken);
        }

        /// <summary> Get updates to resources with parent. </summary>
        public static Pageable<MaintenanceUpdate> GetUpdatesByParent(this ResourceGroupResource resourceGroupResource, string providerName, string resourceParentType, string resourceParentName, string resourceType, string resourceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resourceGroupResource, nameof(resourceGroupResource));
            return GetMockableMaintenanceResourceGroupResource(resourceGroupResource).GetUpdatesByParent(providerName, resourceParentType, resourceParentName, resourceType, resourceName, cancellationToken);
        }
    }
}

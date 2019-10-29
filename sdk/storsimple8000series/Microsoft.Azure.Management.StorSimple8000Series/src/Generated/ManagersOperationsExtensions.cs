
namespace Microsoft.Azure.Management.StorSimple8000Series
{
    using Azure;
    using Management;
    using Rest;
    using Rest.Azure;
    using Rest.Azure.OData;
    using Models;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods for ManagersOperations.
    /// </summary>
    public static partial class ManagersOperationsExtensions
    {
            /// <summary>
            /// Retrieves all the managers in a subscription.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            public static IEnumerable<Manager> List(this IManagersOperations operations)
            {
                return operations.ListAsync().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Retrieves all the managers in a subscription.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IEnumerable<Manager>> ListAsync(this IManagersOperations operations, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Retrieves all the managers in a resource group.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name
            /// </param>
            public static IEnumerable<Manager> ListByResourceGroup(this IManagersOperations operations, string resourceGroupName)
            {
                return operations.ListByResourceGroupAsync(resourceGroupName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Retrieves all the managers in a resource group.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IEnumerable<Manager>> ListByResourceGroupAsync(this IManagersOperations operations, string resourceGroupName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListByResourceGroupWithHttpMessagesAsync(resourceGroupName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Returns the properties of the specified manager name.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name
            /// </param>
            /// <param name='managerName'>
            /// The manager name
            /// </param>
            public static Manager Get(this IManagersOperations operations, string resourceGroupName, string managerName)
            {
                return operations.GetAsync(resourceGroupName, managerName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Returns the properties of the specified manager name.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name
            /// </param>
            /// <param name='managerName'>
            /// The manager name
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<Manager> GetAsync(this IManagersOperations operations, string resourceGroupName, string managerName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetWithHttpMessagesAsync(resourceGroupName, managerName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Creates or updates the manager.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='parameters'>
            /// The manager.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name
            /// </param>
            /// <param name='managerName'>
            /// The manager name
            /// </param>
            public static Manager CreateOrUpdate(this IManagersOperations operations, Manager parameters, string resourceGroupName, string managerName)
            {
                return operations.CreateOrUpdateAsync(parameters, resourceGroupName, managerName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Creates or updates the manager.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='parameters'>
            /// The manager.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name
            /// </param>
            /// <param name='managerName'>
            /// The manager name
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<Manager> CreateOrUpdateAsync(this IManagersOperations operations, Manager parameters, string resourceGroupName, string managerName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.CreateOrUpdateWithHttpMessagesAsync(parameters, resourceGroupName, managerName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Deletes the manager.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name
            /// </param>
            /// <param name='managerName'>
            /// The manager name
            /// </param>
            public static void Delete(this IManagersOperations operations, string resourceGroupName, string managerName)
            {
                operations.DeleteAsync(resourceGroupName, managerName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Deletes the manager.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name
            /// </param>
            /// <param name='managerName'>
            /// The manager name
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task DeleteAsync(this IManagersOperations operations, string resourceGroupName, string managerName, CancellationToken cancellationToken = default(CancellationToken))
            {
                await operations.DeleteWithHttpMessagesAsync(resourceGroupName, managerName, null, cancellationToken).ConfigureAwait(false);
            }

            /// <summary>
            /// Updates the StorSimple Manager.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='parameters'>
            /// The manager update parameters.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name
            /// </param>
            /// <param name='managerName'>
            /// The manager name
            /// </param>
            public static Manager Update(this IManagersOperations operations, ManagerPatch parameters, string resourceGroupName, string managerName)
            {
                return operations.UpdateAsync(parameters, resourceGroupName, managerName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Updates the StorSimple Manager.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='parameters'>
            /// The manager update parameters.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name
            /// </param>
            /// <param name='managerName'>
            /// The manager name
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<Manager> UpdateAsync(this IManagersOperations operations, ManagerPatch parameters, string resourceGroupName, string managerName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.UpdateWithHttpMessagesAsync(parameters, resourceGroupName, managerName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Returns the public encryption key of the device.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='deviceName'>
            /// The device name
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name
            /// </param>
            /// <param name='managerName'>
            /// The manager name
            /// </param>
            public static PublicKey GetDevicePublicEncryptionKey(this IManagersOperations operations, string deviceName, string resourceGroupName, string managerName)
            {
                return operations.GetDevicePublicEncryptionKeyAsync(deviceName, resourceGroupName, managerName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Returns the public encryption key of the device.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='deviceName'>
            /// The device name
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name
            /// </param>
            /// <param name='managerName'>
            /// The manager name
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<PublicKey> GetDevicePublicEncryptionKeyAsync(this IManagersOperations operations, string deviceName, string resourceGroupName, string managerName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetDevicePublicEncryptionKeyWithHttpMessagesAsync(deviceName, resourceGroupName, managerName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Returns the encryption settings of the manager.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name
            /// </param>
            /// <param name='managerName'>
            /// The manager name
            /// </param>
            public static EncryptionSettings GetEncryptionSettings(this IManagersOperations operations, string resourceGroupName, string managerName)
            {
                return operations.GetEncryptionSettingsAsync(resourceGroupName, managerName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Returns the encryption settings of the manager.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name
            /// </param>
            /// <param name='managerName'>
            /// The manager name
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<EncryptionSettings> GetEncryptionSettingsAsync(this IManagersOperations operations, string resourceGroupName, string managerName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetEncryptionSettingsWithHttpMessagesAsync(resourceGroupName, managerName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Returns the extended information of the specified manager name.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name
            /// </param>
            /// <param name='managerName'>
            /// The manager name
            /// </param>
            public static ManagerExtendedInfo GetExtendedInfo(this IManagersOperations operations, string resourceGroupName, string managerName)
            {
                return operations.GetExtendedInfoAsync(resourceGroupName, managerName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Returns the extended information of the specified manager name.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name
            /// </param>
            /// <param name='managerName'>
            /// The manager name
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<ManagerExtendedInfo> GetExtendedInfoAsync(this IManagersOperations operations, string resourceGroupName, string managerName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetExtendedInfoWithHttpMessagesAsync(resourceGroupName, managerName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Creates the extended info of the manager.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='parameters'>
            /// The manager extended information.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name
            /// </param>
            /// <param name='managerName'>
            /// The manager name
            /// </param>
            public static ManagerExtendedInfo CreateExtendedInfo(this IManagersOperations operations, ManagerExtendedInfo parameters, string resourceGroupName, string managerName)
            {
                return operations.CreateExtendedInfoAsync(parameters, resourceGroupName, managerName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Creates the extended info of the manager.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='parameters'>
            /// The manager extended information.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name
            /// </param>
            /// <param name='managerName'>
            /// The manager name
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<ManagerExtendedInfo> CreateExtendedInfoAsync(this IManagersOperations operations, ManagerExtendedInfo parameters, string resourceGroupName, string managerName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.CreateExtendedInfoWithHttpMessagesAsync(parameters, resourceGroupName, managerName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Deletes the extended info of the manager.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name
            /// </param>
            /// <param name='managerName'>
            /// The manager name
            /// </param>
            public static void DeleteExtendedInfo(this IManagersOperations operations, string resourceGroupName, string managerName)
            {
                operations.DeleteExtendedInfoAsync(resourceGroupName, managerName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Deletes the extended info of the manager.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name
            /// </param>
            /// <param name='managerName'>
            /// The manager name
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task DeleteExtendedInfoAsync(this IManagersOperations operations, string resourceGroupName, string managerName, CancellationToken cancellationToken = default(CancellationToken))
            {
                await operations.DeleteExtendedInfoWithHttpMessagesAsync(resourceGroupName, managerName, null, cancellationToken).ConfigureAwait(false);
            }

            /// <summary>
            /// Updates the extended info of the manager.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='parameters'>
            /// The manager extended information.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name
            /// </param>
            /// <param name='managerName'>
            /// The manager name
            /// </param>
            /// <param name='ifMatch'>
            /// Pass the ETag of ExtendedInfo fetched from GET call
            /// </param>
            public static ManagerExtendedInfo UpdateExtendedInfo(this IManagersOperations operations, ManagerExtendedInfo parameters, string resourceGroupName, string managerName, string ifMatch)
            {
                return operations.UpdateExtendedInfoAsync(parameters, resourceGroupName, managerName, ifMatch).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Updates the extended info of the manager.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='parameters'>
            /// The manager extended information.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name
            /// </param>
            /// <param name='managerName'>
            /// The manager name
            /// </param>
            /// <param name='ifMatch'>
            /// Pass the ETag of ExtendedInfo fetched from GET call
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<ManagerExtendedInfo> UpdateExtendedInfoAsync(this IManagersOperations operations, ManagerExtendedInfo parameters, string resourceGroupName, string managerName, string ifMatch, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.UpdateExtendedInfoWithHttpMessagesAsync(parameters, resourceGroupName, managerName, ifMatch, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Lists the features and their support status
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name
            /// </param>
            /// <param name='managerName'>
            /// The manager name
            /// </param>
            /// <param name='odataQuery'>
            /// OData parameters to apply to the operation.
            /// </param>
            public static IEnumerable<Feature> ListFeatureSupportStatus(this IManagersOperations operations, string resourceGroupName, string managerName, ODataQuery<FeatureFilter> odataQuery = default(ODataQuery<FeatureFilter>))
            {
                return operations.ListFeatureSupportStatusAsync(resourceGroupName, managerName, odataQuery).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Lists the features and their support status
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name
            /// </param>
            /// <param name='managerName'>
            /// The manager name
            /// </param>
            /// <param name='odataQuery'>
            /// OData parameters to apply to the operation.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IEnumerable<Feature>> ListFeatureSupportStatusAsync(this IManagersOperations operations, string resourceGroupName, string managerName, ODataQuery<FeatureFilter> odataQuery = default(ODataQuery<FeatureFilter>), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListFeatureSupportStatusWithHttpMessagesAsync(resourceGroupName, managerName, odataQuery, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Returns the activation key of the manager.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name
            /// </param>
            /// <param name='managerName'>
            /// The manager name
            /// </param>
            public static Key GetActivationKey(this IManagersOperations operations, string resourceGroupName, string managerName)
            {
                return operations.GetActivationKeyAsync(resourceGroupName, managerName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Returns the activation key of the manager.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name
            /// </param>
            /// <param name='managerName'>
            /// The manager name
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<Key> GetActivationKeyAsync(this IManagersOperations operations, string resourceGroupName, string managerName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetActivationKeyWithHttpMessagesAsync(resourceGroupName, managerName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Returns the symmetric encrypted public encryption key of the manager.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name
            /// </param>
            /// <param name='managerName'>
            /// The manager name
            /// </param>
            public static SymmetricEncryptedSecret GetPublicEncryptionKey(this IManagersOperations operations, string resourceGroupName, string managerName)
            {
                return operations.GetPublicEncryptionKeyAsync(resourceGroupName, managerName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Returns the symmetric encrypted public encryption key of the manager.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name
            /// </param>
            /// <param name='managerName'>
            /// The manager name
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<SymmetricEncryptedSecret> GetPublicEncryptionKeyAsync(this IManagersOperations operations, string resourceGroupName, string managerName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetPublicEncryptionKeyWithHttpMessagesAsync(resourceGroupName, managerName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Gets the metrics for the specified manager.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='odataQuery'>
            /// OData parameters to apply to the operation.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name
            /// </param>
            /// <param name='managerName'>
            /// The manager name
            /// </param>
            public static IEnumerable<Metrics> ListMetrics(this IManagersOperations operations, ODataQuery<MetricFilter> odataQuery, string resourceGroupName, string managerName)
            {
                return operations.ListMetricsAsync(odataQuery, resourceGroupName, managerName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets the metrics for the specified manager.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='odataQuery'>
            /// OData parameters to apply to the operation.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name
            /// </param>
            /// <param name='managerName'>
            /// The manager name
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IEnumerable<Metrics>> ListMetricsAsync(this IManagersOperations operations, ODataQuery<MetricFilter> odataQuery, string resourceGroupName, string managerName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListMetricsWithHttpMessagesAsync(odataQuery, resourceGroupName, managerName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Gets the metric definitions for the specified manager.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name
            /// </param>
            /// <param name='managerName'>
            /// The manager name
            /// </param>
            public static IEnumerable<MetricDefinition> ListMetricDefinition(this IManagersOperations operations, string resourceGroupName, string managerName)
            {
                return operations.ListMetricDefinitionAsync(resourceGroupName, managerName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets the metric definitions for the specified manager.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name
            /// </param>
            /// <param name='managerName'>
            /// The manager name
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IEnumerable<MetricDefinition>> ListMetricDefinitionAsync(this IManagersOperations operations, string resourceGroupName, string managerName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListMetricDefinitionWithHttpMessagesAsync(resourceGroupName, managerName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Re-generates and returns the activation key of the manager.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name
            /// </param>
            /// <param name='managerName'>
            /// The manager name
            /// </param>
            public static Key RegenerateActivationKey(this IManagersOperations operations, string resourceGroupName, string managerName)
            {
                return operations.RegenerateActivationKeyAsync(resourceGroupName, managerName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Re-generates and returns the activation key of the manager.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name
            /// </param>
            /// <param name='managerName'>
            /// The manager name
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<Key> RegenerateActivationKeyAsync(this IManagersOperations operations, string resourceGroupName, string managerName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.RegenerateActivationKeyWithHttpMessagesAsync(resourceGroupName, managerName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

    }
}


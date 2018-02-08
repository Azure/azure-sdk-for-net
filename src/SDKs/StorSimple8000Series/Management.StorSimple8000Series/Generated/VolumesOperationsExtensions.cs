
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
    /// Extension methods for VolumesOperations.
    /// </summary>
    public static partial class VolumesOperationsExtensions
    {
            /// <summary>
            /// Retrieves all the volumes in a volume container.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='deviceName'>
            /// The device name
            /// </param>
            /// <param name='volumeContainerName'>
            /// The volume container name.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name
            /// </param>
            /// <param name='managerName'>
            /// The manager name
            /// </param>
            public static IEnumerable<Volume> ListByVolumeContainer(this IVolumesOperations operations, string deviceName, string volumeContainerName, string resourceGroupName, string managerName)
            {
                return operations.ListByVolumeContainerAsync(deviceName, volumeContainerName, resourceGroupName, managerName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Retrieves all the volumes in a volume container.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='deviceName'>
            /// The device name
            /// </param>
            /// <param name='volumeContainerName'>
            /// The volume container name.
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
            public static async Task<IEnumerable<Volume>> ListByVolumeContainerAsync(this IVolumesOperations operations, string deviceName, string volumeContainerName, string resourceGroupName, string managerName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListByVolumeContainerWithHttpMessagesAsync(deviceName, volumeContainerName, resourceGroupName, managerName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Returns the properties of the specified volume name.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='deviceName'>
            /// The device name
            /// </param>
            /// <param name='volumeContainerName'>
            /// The volume container name.
            /// </param>
            /// <param name='volumeName'>
            /// The volume name.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name
            /// </param>
            /// <param name='managerName'>
            /// The manager name
            /// </param>
            public static Volume Get(this IVolumesOperations operations, string deviceName, string volumeContainerName, string volumeName, string resourceGroupName, string managerName)
            {
                return operations.GetAsync(deviceName, volumeContainerName, volumeName, resourceGroupName, managerName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Returns the properties of the specified volume name.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='deviceName'>
            /// The device name
            /// </param>
            /// <param name='volumeContainerName'>
            /// The volume container name.
            /// </param>
            /// <param name='volumeName'>
            /// The volume name.
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
            public static async Task<Volume> GetAsync(this IVolumesOperations operations, string deviceName, string volumeContainerName, string volumeName, string resourceGroupName, string managerName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetWithHttpMessagesAsync(deviceName, volumeContainerName, volumeName, resourceGroupName, managerName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Creates or updates the volume.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='deviceName'>
            /// The device name
            /// </param>
            /// <param name='volumeContainerName'>
            /// The volume container name.
            /// </param>
            /// <param name='volumeName'>
            /// The volume name.
            /// </param>
            /// <param name='parameters'>
            /// Volume to be created or updated.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name
            /// </param>
            /// <param name='managerName'>
            /// The manager name
            /// </param>
            public static Volume CreateOrUpdate(this IVolumesOperations operations, string deviceName, string volumeContainerName, string volumeName, Volume parameters, string resourceGroupName, string managerName)
            {
                return operations.CreateOrUpdateAsync(deviceName, volumeContainerName, volumeName, parameters, resourceGroupName, managerName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Creates or updates the volume.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='deviceName'>
            /// The device name
            /// </param>
            /// <param name='volumeContainerName'>
            /// The volume container name.
            /// </param>
            /// <param name='volumeName'>
            /// The volume name.
            /// </param>
            /// <param name='parameters'>
            /// Volume to be created or updated.
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
            public static async Task<Volume> CreateOrUpdateAsync(this IVolumesOperations operations, string deviceName, string volumeContainerName, string volumeName, Volume parameters, string resourceGroupName, string managerName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.CreateOrUpdateWithHttpMessagesAsync(deviceName, volumeContainerName, volumeName, parameters, resourceGroupName, managerName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Deletes the volume.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='deviceName'>
            /// The device name
            /// </param>
            /// <param name='volumeContainerName'>
            /// The volume container name.
            /// </param>
            /// <param name='volumeName'>
            /// The volume name.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name
            /// </param>
            /// <param name='managerName'>
            /// The manager name
            /// </param>
            public static void Delete(this IVolumesOperations operations, string deviceName, string volumeContainerName, string volumeName, string resourceGroupName, string managerName)
            {
                operations.DeleteAsync(deviceName, volumeContainerName, volumeName, resourceGroupName, managerName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Deletes the volume.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='deviceName'>
            /// The device name
            /// </param>
            /// <param name='volumeContainerName'>
            /// The volume container name.
            /// </param>
            /// <param name='volumeName'>
            /// The volume name.
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
            public static async Task DeleteAsync(this IVolumesOperations operations, string deviceName, string volumeContainerName, string volumeName, string resourceGroupName, string managerName, CancellationToken cancellationToken = default(CancellationToken))
            {
                await operations.DeleteWithHttpMessagesAsync(deviceName, volumeContainerName, volumeName, resourceGroupName, managerName, null, cancellationToken).ConfigureAwait(false);
            }

            /// <summary>
            /// Gets the metrics for the specified volume.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='odataQuery'>
            /// OData parameters to apply to the operation.
            /// </param>
            /// <param name='deviceName'>
            /// The device name
            /// </param>
            /// <param name='volumeContainerName'>
            /// The volume container name.
            /// </param>
            /// <param name='volumeName'>
            /// The volume name.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name
            /// </param>
            /// <param name='managerName'>
            /// The manager name
            /// </param>
            public static IEnumerable<Metrics> ListMetrics(this IVolumesOperations operations, ODataQuery<MetricFilter> odataQuery, string deviceName, string volumeContainerName, string volumeName, string resourceGroupName, string managerName)
            {
                return operations.ListMetricsAsync(odataQuery, deviceName, volumeContainerName, volumeName, resourceGroupName, managerName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets the metrics for the specified volume.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='odataQuery'>
            /// OData parameters to apply to the operation.
            /// </param>
            /// <param name='deviceName'>
            /// The device name
            /// </param>
            /// <param name='volumeContainerName'>
            /// The volume container name.
            /// </param>
            /// <param name='volumeName'>
            /// The volume name.
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
            public static async Task<IEnumerable<Metrics>> ListMetricsAsync(this IVolumesOperations operations, ODataQuery<MetricFilter> odataQuery, string deviceName, string volumeContainerName, string volumeName, string resourceGroupName, string managerName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListMetricsWithHttpMessagesAsync(odataQuery, deviceName, volumeContainerName, volumeName, resourceGroupName, managerName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Gets the metric definitions for the specified volume.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='deviceName'>
            /// The device name
            /// </param>
            /// <param name='volumeContainerName'>
            /// The volume container name.
            /// </param>
            /// <param name='volumeName'>
            /// The volume name.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name
            /// </param>
            /// <param name='managerName'>
            /// The manager name
            /// </param>
            public static IEnumerable<MetricDefinition> ListMetricDefinition(this IVolumesOperations operations, string deviceName, string volumeContainerName, string volumeName, string resourceGroupName, string managerName)
            {
                return operations.ListMetricDefinitionAsync(deviceName, volumeContainerName, volumeName, resourceGroupName, managerName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets the metric definitions for the specified volume.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='deviceName'>
            /// The device name
            /// </param>
            /// <param name='volumeContainerName'>
            /// The volume container name.
            /// </param>
            /// <param name='volumeName'>
            /// The volume name.
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
            public static async Task<IEnumerable<MetricDefinition>> ListMetricDefinitionAsync(this IVolumesOperations operations, string deviceName, string volumeContainerName, string volumeName, string resourceGroupName, string managerName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListMetricDefinitionWithHttpMessagesAsync(deviceName, volumeContainerName, volumeName, resourceGroupName, managerName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Retrieves all the volumes in a device.
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
            public static IEnumerable<Volume> ListByDevice(this IVolumesOperations operations, string deviceName, string resourceGroupName, string managerName)
            {
                return operations.ListByDeviceAsync(deviceName, resourceGroupName, managerName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Retrieves all the volumes in a device.
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
            public static async Task<IEnumerable<Volume>> ListByDeviceAsync(this IVolumesOperations operations, string deviceName, string resourceGroupName, string managerName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListByDeviceWithHttpMessagesAsync(deviceName, resourceGroupName, managerName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Creates or updates the volume.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='deviceName'>
            /// The device name
            /// </param>
            /// <param name='volumeContainerName'>
            /// The volume container name.
            /// </param>
            /// <param name='volumeName'>
            /// The volume name.
            /// </param>
            /// <param name='parameters'>
            /// Volume to be created or updated.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name
            /// </param>
            /// <param name='managerName'>
            /// The manager name
            /// </param>
            public static Volume BeginCreateOrUpdate(this IVolumesOperations operations, string deviceName, string volumeContainerName, string volumeName, Volume parameters, string resourceGroupName, string managerName)
            {
                return operations.BeginCreateOrUpdateAsync(deviceName, volumeContainerName, volumeName, parameters, resourceGroupName, managerName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Creates or updates the volume.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='deviceName'>
            /// The device name
            /// </param>
            /// <param name='volumeContainerName'>
            /// The volume container name.
            /// </param>
            /// <param name='volumeName'>
            /// The volume name.
            /// </param>
            /// <param name='parameters'>
            /// Volume to be created or updated.
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
            public static async Task<Volume> BeginCreateOrUpdateAsync(this IVolumesOperations operations, string deviceName, string volumeContainerName, string volumeName, Volume parameters, string resourceGroupName, string managerName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.BeginCreateOrUpdateWithHttpMessagesAsync(deviceName, volumeContainerName, volumeName, parameters, resourceGroupName, managerName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Deletes the volume.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='deviceName'>
            /// The device name
            /// </param>
            /// <param name='volumeContainerName'>
            /// The volume container name.
            /// </param>
            /// <param name='volumeName'>
            /// The volume name.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name
            /// </param>
            /// <param name='managerName'>
            /// The manager name
            /// </param>
            public static void BeginDelete(this IVolumesOperations operations, string deviceName, string volumeContainerName, string volumeName, string resourceGroupName, string managerName)
            {
                operations.BeginDeleteAsync(deviceName, volumeContainerName, volumeName, resourceGroupName, managerName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Deletes the volume.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='deviceName'>
            /// The device name
            /// </param>
            /// <param name='volumeContainerName'>
            /// The volume container name.
            /// </param>
            /// <param name='volumeName'>
            /// The volume name.
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
            public static async Task BeginDeleteAsync(this IVolumesOperations operations, string deviceName, string volumeContainerName, string volumeName, string resourceGroupName, string managerName, CancellationToken cancellationToken = default(CancellationToken))
            {
                await operations.BeginDeleteWithHttpMessagesAsync(deviceName, volumeContainerName, volumeName, resourceGroupName, managerName, null, cancellationToken).ConfigureAwait(false);
            }

    }
}


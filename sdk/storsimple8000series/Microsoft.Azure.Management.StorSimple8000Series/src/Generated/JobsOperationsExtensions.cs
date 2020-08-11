
namespace Microsoft.Azure.Management.StorSimple8000Series
{
    using Azure;
    using Management;
    using Rest;
    using Rest.Azure;
    using Rest.Azure.OData;
    using Models;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods for JobsOperations.
    /// </summary>
    public static partial class JobsOperationsExtensions
    {
            /// <summary>
            /// Gets all the jobs for specified device. With optional OData query
            /// parameters, a filtered set of jobs is returned.
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
            /// <param name='odataQuery'>
            /// OData parameters to apply to the operation.
            /// </param>
            public static IPage<Job> ListByDevice(this IJobsOperations operations, string deviceName, string resourceGroupName, string managerName, ODataQuery<JobFilter> odataQuery = default(ODataQuery<JobFilter>))
            {
                return operations.ListByDeviceAsync(deviceName, resourceGroupName, managerName, odataQuery).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets all the jobs for specified device. With optional OData query
            /// parameters, a filtered set of jobs is returned.
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
            /// <param name='odataQuery'>
            /// OData parameters to apply to the operation.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IPage<Job>> ListByDeviceAsync(this IJobsOperations operations, string deviceName, string resourceGroupName, string managerName, ODataQuery<JobFilter> odataQuery = default(ODataQuery<JobFilter>), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListByDeviceWithHttpMessagesAsync(deviceName, resourceGroupName, managerName, odataQuery, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Gets the details of the specified job name.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='deviceName'>
            /// The device name
            /// </param>
            /// <param name='jobName'>
            /// The job Name.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name
            /// </param>
            /// <param name='managerName'>
            /// The manager name
            /// </param>
            public static Job Get(this IJobsOperations operations, string deviceName, string jobName, string resourceGroupName, string managerName)
            {
                return operations.GetAsync(deviceName, jobName, resourceGroupName, managerName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets the details of the specified job name.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='deviceName'>
            /// The device name
            /// </param>
            /// <param name='jobName'>
            /// The job Name.
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
            public static async Task<Job> GetAsync(this IJobsOperations operations, string deviceName, string jobName, string resourceGroupName, string managerName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetWithHttpMessagesAsync(deviceName, jobName, resourceGroupName, managerName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Cancels a job on the device.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='deviceName'>
            /// The device name
            /// </param>
            /// <param name='jobName'>
            /// The jobName.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name
            /// </param>
            /// <param name='managerName'>
            /// The manager name
            /// </param>
            public static void Cancel(this IJobsOperations operations, string deviceName, string jobName, string resourceGroupName, string managerName)
            {
                operations.CancelAsync(deviceName, jobName, resourceGroupName, managerName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Cancels a job on the device.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='deviceName'>
            /// The device name
            /// </param>
            /// <param name='jobName'>
            /// The jobName.
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
            public static async Task CancelAsync(this IJobsOperations operations, string deviceName, string jobName, string resourceGroupName, string managerName, CancellationToken cancellationToken = default(CancellationToken))
            {
                await operations.CancelWithHttpMessagesAsync(deviceName, jobName, resourceGroupName, managerName, null, cancellationToken).ConfigureAwait(false);
            }

            /// <summary>
            /// Gets all the jobs for the specified manager. With optional OData query
            /// parameters, a filtered set of jobs is returned.
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
            public static IPage<Job> ListByManager(this IJobsOperations operations, string resourceGroupName, string managerName, ODataQuery<JobFilter> odataQuery = default(ODataQuery<JobFilter>))
            {
                return operations.ListByManagerAsync(resourceGroupName, managerName, odataQuery).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets all the jobs for the specified manager. With optional OData query
            /// parameters, a filtered set of jobs is returned.
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
            public static async Task<IPage<Job>> ListByManagerAsync(this IJobsOperations operations, string resourceGroupName, string managerName, ODataQuery<JobFilter> odataQuery = default(ODataQuery<JobFilter>), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListByManagerWithHttpMessagesAsync(resourceGroupName, managerName, odataQuery, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Cancels a job on the device.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='deviceName'>
            /// The device name
            /// </param>
            /// <param name='jobName'>
            /// The jobName.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name
            /// </param>
            /// <param name='managerName'>
            /// The manager name
            /// </param>
            public static void BeginCancel(this IJobsOperations operations, string deviceName, string jobName, string resourceGroupName, string managerName)
            {
                operations.BeginCancelAsync(deviceName, jobName, resourceGroupName, managerName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Cancels a job on the device.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='deviceName'>
            /// The device name
            /// </param>
            /// <param name='jobName'>
            /// The jobName.
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
            public static async Task BeginCancelAsync(this IJobsOperations operations, string deviceName, string jobName, string resourceGroupName, string managerName, CancellationToken cancellationToken = default(CancellationToken))
            {
                await operations.BeginCancelWithHttpMessagesAsync(deviceName, jobName, resourceGroupName, managerName, null, cancellationToken).ConfigureAwait(false);
            }

            /// <summary>
            /// Gets all the jobs for specified device. With optional OData query
            /// parameters, a filtered set of jobs is returned.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='nextPageLink'>
            /// The NextLink from the previous successful call to List operation.
            /// </param>
            public static IPage<Job> ListByDeviceNext(this IJobsOperations operations, string nextPageLink)
            {
                return operations.ListByDeviceNextAsync(nextPageLink).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets all the jobs for specified device. With optional OData query
            /// parameters, a filtered set of jobs is returned.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='nextPageLink'>
            /// The NextLink from the previous successful call to List operation.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IPage<Job>> ListByDeviceNextAsync(this IJobsOperations operations, string nextPageLink, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListByDeviceNextWithHttpMessagesAsync(nextPageLink, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Gets all the jobs for the specified manager. With optional OData query
            /// parameters, a filtered set of jobs is returned.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='nextPageLink'>
            /// The NextLink from the previous successful call to List operation.
            /// </param>
            public static IPage<Job> ListByManagerNext(this IJobsOperations operations, string nextPageLink)
            {
                return operations.ListByManagerNextAsync(nextPageLink).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Gets all the jobs for the specified manager. With optional OData query
            /// parameters, a filtered set of jobs is returned.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='nextPageLink'>
            /// The NextLink from the previous successful call to List operation.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IPage<Job>> ListByManagerNextAsync(this IJobsOperations operations, string nextPageLink, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListByManagerNextWithHttpMessagesAsync(nextPageLink, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

    }
}


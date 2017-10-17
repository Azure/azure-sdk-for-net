
namespace Microsoft.Azure.Management.StorSimple8000Series
{
    using Azure;
    using Management;
    using Rest;
    using Rest.Azure;
    using Models;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods for AccessControlRecordsOperations.
    /// </summary>
    public static partial class AccessControlRecordsOperationsExtensions
    {
            /// <summary>
            /// Retrieves all the access control records in a manager.
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
            public static IEnumerable<AccessControlRecord> ListByManager(this IAccessControlRecordsOperations operations, string resourceGroupName, string managerName)
            {
                return operations.ListByManagerAsync(resourceGroupName, managerName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Retrieves all the access control records in a manager.
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
            public static async Task<IEnumerable<AccessControlRecord>> ListByManagerAsync(this IAccessControlRecordsOperations operations, string resourceGroupName, string managerName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListByManagerWithHttpMessagesAsync(resourceGroupName, managerName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Returns the properties of the specified access control record name.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='accessControlRecordName'>
            /// Name of access control record to be fetched.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name
            /// </param>
            /// <param name='managerName'>
            /// The manager name
            /// </param>
            public static AccessControlRecord Get(this IAccessControlRecordsOperations operations, string accessControlRecordName, string resourceGroupName, string managerName)
            {
                return operations.GetAsync(accessControlRecordName, resourceGroupName, managerName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Returns the properties of the specified access control record name.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='accessControlRecordName'>
            /// Name of access control record to be fetched.
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
            public static async Task<AccessControlRecord> GetAsync(this IAccessControlRecordsOperations operations, string accessControlRecordName, string resourceGroupName, string managerName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetWithHttpMessagesAsync(accessControlRecordName, resourceGroupName, managerName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Creates or Updates an access control record.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='accessControlRecordName'>
            /// The name of the access control record.
            /// </param>
            /// <param name='parameters'>
            /// The access control record to be added or updated.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name
            /// </param>
            /// <param name='managerName'>
            /// The manager name
            /// </param>
            public static AccessControlRecord CreateOrUpdate(this IAccessControlRecordsOperations operations, string accessControlRecordName, AccessControlRecord parameters, string resourceGroupName, string managerName)
            {
                return operations.CreateOrUpdateAsync(accessControlRecordName, parameters, resourceGroupName, managerName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Creates or Updates an access control record.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='accessControlRecordName'>
            /// The name of the access control record.
            /// </param>
            /// <param name='parameters'>
            /// The access control record to be added or updated.
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
            public static async Task<AccessControlRecord> CreateOrUpdateAsync(this IAccessControlRecordsOperations operations, string accessControlRecordName, AccessControlRecord parameters, string resourceGroupName, string managerName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.CreateOrUpdateWithHttpMessagesAsync(accessControlRecordName, parameters, resourceGroupName, managerName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Deletes the access control record.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='accessControlRecordName'>
            /// The name of the access control record to delete.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name
            /// </param>
            /// <param name='managerName'>
            /// The manager name
            /// </param>
            public static void Delete(this IAccessControlRecordsOperations operations, string accessControlRecordName, string resourceGroupName, string managerName)
            {
                operations.DeleteAsync(accessControlRecordName, resourceGroupName, managerName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Deletes the access control record.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='accessControlRecordName'>
            /// The name of the access control record to delete.
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
            public static async Task DeleteAsync(this IAccessControlRecordsOperations operations, string accessControlRecordName, string resourceGroupName, string managerName, CancellationToken cancellationToken = default(CancellationToken))
            {
                await operations.DeleteWithHttpMessagesAsync(accessControlRecordName, resourceGroupName, managerName, null, cancellationToken).ConfigureAwait(false);
            }

            /// <summary>
            /// Creates or Updates an access control record.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='accessControlRecordName'>
            /// The name of the access control record.
            /// </param>
            /// <param name='parameters'>
            /// The access control record to be added or updated.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name
            /// </param>
            /// <param name='managerName'>
            /// The manager name
            /// </param>
            public static AccessControlRecord BeginCreateOrUpdate(this IAccessControlRecordsOperations operations, string accessControlRecordName, AccessControlRecord parameters, string resourceGroupName, string managerName)
            {
                return operations.BeginCreateOrUpdateAsync(accessControlRecordName, parameters, resourceGroupName, managerName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Creates or Updates an access control record.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='accessControlRecordName'>
            /// The name of the access control record.
            /// </param>
            /// <param name='parameters'>
            /// The access control record to be added or updated.
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
            public static async Task<AccessControlRecord> BeginCreateOrUpdateAsync(this IAccessControlRecordsOperations operations, string accessControlRecordName, AccessControlRecord parameters, string resourceGroupName, string managerName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.BeginCreateOrUpdateWithHttpMessagesAsync(accessControlRecordName, parameters, resourceGroupName, managerName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Deletes the access control record.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='accessControlRecordName'>
            /// The name of the access control record to delete.
            /// </param>
            /// <param name='resourceGroupName'>
            /// The resource group name
            /// </param>
            /// <param name='managerName'>
            /// The manager name
            /// </param>
            public static void BeginDelete(this IAccessControlRecordsOperations operations, string accessControlRecordName, string resourceGroupName, string managerName)
            {
                operations.BeginDeleteAsync(accessControlRecordName, resourceGroupName, managerName).GetAwaiter().GetResult();
            }

            /// <summary>
            /// Deletes the access control record.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='accessControlRecordName'>
            /// The name of the access control record to delete.
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
            public static async Task BeginDeleteAsync(this IAccessControlRecordsOperations operations, string accessControlRecordName, string resourceGroupName, string managerName, CancellationToken cancellationToken = default(CancellationToken))
            {
                await operations.BeginDeleteWithHttpMessagesAsync(accessControlRecordName, resourceGroupName, managerName, null, cancellationToken).ConfigureAwait(false);
            }

    }
}


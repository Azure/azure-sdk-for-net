
namespace Microsoft.Azure.Management.PowerBIEmbedded
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Models;

    /// <summary>
    /// Extension methods for WorkspaceCollectionsOperations.
    /// </summary>
    public static partial class WorkspaceCollectionsOperationsExtensions
    {
            /// <summary>
            /// Retrieves an existing Power BI Workspace Collection.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// Azure resource group
            /// </param>
            /// <param name='workspaceCollectionName'>
            /// Power BI Embedded workspace collection name
            /// </param>
            public static WorkspaceCollection GetByName(this IWorkspaceCollectionsOperations operations, string resourceGroupName, string workspaceCollectionName)
            {
                return Task.Factory.StartNew(s => ((IWorkspaceCollectionsOperations)s).GetByNameAsync(resourceGroupName, workspaceCollectionName), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Retrieves an existing Power BI Workspace Collection.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// Azure resource group
            /// </param>
            /// <param name='workspaceCollectionName'>
            /// Power BI Embedded workspace collection name
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<WorkspaceCollection> GetByNameAsync(this IWorkspaceCollectionsOperations operations, string resourceGroupName, string workspaceCollectionName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetByNameWithHttpMessagesAsync(resourceGroupName, workspaceCollectionName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Creates a new Power BI Workspace Collection with the specified properties.
            /// A Power BI Workspace Collection contains one or more Power BI Workspaces
            /// and can be used to provision keys that provide API access to those Power
            /// BI Workspaces.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// Azure resource group
            /// </param>
            /// <param name='workspaceCollectionName'>
            /// Power BI Embedded workspace collection name
            /// </param>
            /// <param name='body'>
            /// Create workspace collection request
            /// </param>
            public static WorkspaceCollection Create(this IWorkspaceCollectionsOperations operations, string resourceGroupName, string workspaceCollectionName, CreateWorkspaceCollectionRequest body)
            {
                return Task.Factory.StartNew(s => ((IWorkspaceCollectionsOperations)s).CreateAsync(resourceGroupName, workspaceCollectionName, body), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Creates a new Power BI Workspace Collection with the specified properties.
            /// A Power BI Workspace Collection contains one or more Power BI Workspaces
            /// and can be used to provision keys that provide API access to those Power
            /// BI Workspaces.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// Azure resource group
            /// </param>
            /// <param name='workspaceCollectionName'>
            /// Power BI Embedded workspace collection name
            /// </param>
            /// <param name='body'>
            /// Create workspace collection request
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<WorkspaceCollection> CreateAsync(this IWorkspaceCollectionsOperations operations, string resourceGroupName, string workspaceCollectionName, CreateWorkspaceCollectionRequest body, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.CreateWithHttpMessagesAsync(resourceGroupName, workspaceCollectionName, body, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Update an existing Power BI Workspace Collection with the specified
            /// properties.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// Azure resource group
            /// </param>
            /// <param name='workspaceCollectionName'>
            /// Power BI Embedded workspace collection name
            /// </param>
            /// <param name='body'>
            /// Update workspace collection request
            /// </param>
            public static WorkspaceCollection Update(this IWorkspaceCollectionsOperations operations, string resourceGroupName, string workspaceCollectionName, UpdateWorkspaceCollectionRequest body)
            {
                return Task.Factory.StartNew(s => ((IWorkspaceCollectionsOperations)s).UpdateAsync(resourceGroupName, workspaceCollectionName, body), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Update an existing Power BI Workspace Collection with the specified
            /// properties.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// Azure resource group
            /// </param>
            /// <param name='workspaceCollectionName'>
            /// Power BI Embedded workspace collection name
            /// </param>
            /// <param name='body'>
            /// Update workspace collection request
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<WorkspaceCollection> UpdateAsync(this IWorkspaceCollectionsOperations operations, string resourceGroupName, string workspaceCollectionName, UpdateWorkspaceCollectionRequest body, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.UpdateWithHttpMessagesAsync(resourceGroupName, workspaceCollectionName, body, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Delete a Power BI Workspace Collection.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// Azure resource group
            /// </param>
            /// <param name='workspaceCollectionName'>
            /// Power BI Embedded workspace collection name
            /// </param>
            public static void Delete(this IWorkspaceCollectionsOperations operations, string resourceGroupName, string workspaceCollectionName)
            {
                Task.Factory.StartNew(s => ((IWorkspaceCollectionsOperations)s).DeleteAsync(resourceGroupName, workspaceCollectionName), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Delete a Power BI Workspace Collection.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// Azure resource group
            /// </param>
            /// <param name='workspaceCollectionName'>
            /// Power BI Embedded workspace collection name
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task DeleteAsync(this IWorkspaceCollectionsOperations operations, string resourceGroupName, string workspaceCollectionName, CancellationToken cancellationToken = default(CancellationToken))
            {
                await operations.DeleteWithHttpMessagesAsync(resourceGroupName, workspaceCollectionName, null, cancellationToken).ConfigureAwait(false);
            }

            /// <summary>
            /// Delete a Power BI Workspace Collection.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// Azure resource group
            /// </param>
            /// <param name='workspaceCollectionName'>
            /// Power BI Embedded workspace collection name
            /// </param>
            public static void BeginDelete(this IWorkspaceCollectionsOperations operations, string resourceGroupName, string workspaceCollectionName)
            {
                Task.Factory.StartNew(s => ((IWorkspaceCollectionsOperations)s).BeginDeleteAsync(resourceGroupName, workspaceCollectionName), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Delete a Power BI Workspace Collection.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// Azure resource group
            /// </param>
            /// <param name='workspaceCollectionName'>
            /// Power BI Embedded workspace collection name
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task BeginDeleteAsync(this IWorkspaceCollectionsOperations operations, string resourceGroupName, string workspaceCollectionName, CancellationToken cancellationToken = default(CancellationToken))
            {
                await operations.BeginDeleteWithHttpMessagesAsync(resourceGroupName, workspaceCollectionName, null, cancellationToken).ConfigureAwait(false);
            }

            /// <summary>
            /// Check that the specified Power BI Workspace Collection name is valid and
            /// not in use.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='location'>
            /// Azure location
            /// </param>
            /// <param name='body'>
            /// Check name availability request
            /// </param>
            public static CheckNameResponse CheckNameAvailability(this IWorkspaceCollectionsOperations operations, string location, CheckNameRequest body)
            {
                return Task.Factory.StartNew(s => ((IWorkspaceCollectionsOperations)s).CheckNameAvailabilityAsync(location, body), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Check that the specified Power BI Workspace Collection name is valid and
            /// not in use.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='location'>
            /// Azure location
            /// </param>
            /// <param name='body'>
            /// Check name availability request
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<CheckNameResponse> CheckNameAvailabilityAsync(this IWorkspaceCollectionsOperations operations, string location, CheckNameRequest body, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.CheckNameAvailabilityWithHttpMessagesAsync(location, body, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Retrieves all existing Power BI Workspace Collections in the specified
            /// resource group.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// Azure resource group
            /// </param>
            public static IEnumerable<WorkspaceCollection> ListByResourceGroup(this IWorkspaceCollectionsOperations operations, string resourceGroupName)
            {
                return Task.Factory.StartNew(s => ((IWorkspaceCollectionsOperations)s).ListByResourceGroupAsync(resourceGroupName), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Retrieves all existing Power BI Workspace Collections in the specified
            /// resource group.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// Azure resource group
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IEnumerable<WorkspaceCollection>> ListByResourceGroupAsync(this IWorkspaceCollectionsOperations operations, string resourceGroupName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListByResourceGroupWithHttpMessagesAsync(resourceGroupName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Retrieves all existing Power BI Workspace Collections in the specified
            /// subscription.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            public static IEnumerable<WorkspaceCollection> ListBySubscription(this IWorkspaceCollectionsOperations operations)
            {
                return Task.Factory.StartNew(s => ((IWorkspaceCollectionsOperations)s).ListBySubscriptionAsync(), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Retrieves all existing Power BI Workspace Collections in the specified
            /// subscription.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IEnumerable<WorkspaceCollection>> ListBySubscriptionAsync(this IWorkspaceCollectionsOperations operations, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ListBySubscriptionWithHttpMessagesAsync(null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Retrieves the primary and secondary access keys for the specified Power BI
            /// Workspace Collection.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// Azure resource group
            /// </param>
            /// <param name='workspaceCollectionName'>
            /// Power BI Embedded workspace collection name
            /// </param>
            public static WorkspaceCollectionAccessKeys GetAccessKeys(this IWorkspaceCollectionsOperations operations, string resourceGroupName, string workspaceCollectionName)
            {
                return Task.Factory.StartNew(s => ((IWorkspaceCollectionsOperations)s).GetAccessKeysAsync(resourceGroupName, workspaceCollectionName), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Retrieves the primary and secondary access keys for the specified Power BI
            /// Workspace Collection.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// Azure resource group
            /// </param>
            /// <param name='workspaceCollectionName'>
            /// Power BI Embedded workspace collection name
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<WorkspaceCollectionAccessKeys> GetAccessKeysAsync(this IWorkspaceCollectionsOperations operations, string resourceGroupName, string workspaceCollectionName, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetAccessKeysWithHttpMessagesAsync(resourceGroupName, workspaceCollectionName, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Regenerates the primary or secondary access key for the specified Power BI
            /// Workspace Collection.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// Azure resource group
            /// </param>
            /// <param name='workspaceCollectionName'>
            /// Power BI Embedded workspace collection name
            /// </param>
            /// <param name='body'>
            /// Access key to regenerate
            /// </param>
            public static WorkspaceCollectionAccessKeys RegenerateKey(this IWorkspaceCollectionsOperations operations, string resourceGroupName, string workspaceCollectionName, WorkspaceCollectionAccessKey body)
            {
                return Task.Factory.StartNew(s => ((IWorkspaceCollectionsOperations)s).RegenerateKeyAsync(resourceGroupName, workspaceCollectionName, body), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Regenerates the primary or secondary access key for the specified Power BI
            /// Workspace Collection.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// Azure resource group
            /// </param>
            /// <param name='workspaceCollectionName'>
            /// Power BI Embedded workspace collection name
            /// </param>
            /// <param name='body'>
            /// Access key to regenerate
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<WorkspaceCollectionAccessKeys> RegenerateKeyAsync(this IWorkspaceCollectionsOperations operations, string resourceGroupName, string workspaceCollectionName, WorkspaceCollectionAccessKey body, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.RegenerateKeyWithHttpMessagesAsync(resourceGroupName, workspaceCollectionName, body, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <summary>
            /// Migrates an existing Power BI Workspace Collection to a different resource
            /// group and/or subscription.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// Azure resource group
            /// </param>
            /// <param name='body'>
            /// Workspace migration request
            /// </param>
            public static void Migrate(this IWorkspaceCollectionsOperations operations, string resourceGroupName, MigrateWorkspaceCollectionRequest body)
            {
                Task.Factory.StartNew(s => ((IWorkspaceCollectionsOperations)s).MigrateAsync(resourceGroupName, body), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <summary>
            /// Migrates an existing Power BI Workspace Collection to a different resource
            /// group and/or subscription.
            /// </summary>
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='resourceGroupName'>
            /// Azure resource group
            /// </param>
            /// <param name='body'>
            /// Workspace migration request
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task MigrateAsync(this IWorkspaceCollectionsOperations operations, string resourceGroupName, MigrateWorkspaceCollectionRequest body, CancellationToken cancellationToken = default(CancellationToken))
            {
                await operations.MigrateWithHttpMessagesAsync(resourceGroupName, body, null, cancellationToken).ConfigureAwait(false);
            }

    }
}

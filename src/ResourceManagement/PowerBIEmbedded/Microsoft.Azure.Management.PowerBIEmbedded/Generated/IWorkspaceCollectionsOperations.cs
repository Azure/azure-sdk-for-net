
namespace Microsoft.Azure.Management.PowerBIEmbedded
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Models;

    /// <summary>
    /// WorkspaceCollectionsOperations operations.
    /// </summary>
    public partial interface IWorkspaceCollectionsOperations
    {
        /// <summary>
        /// Retrieves an existing Power BI Workspace Collection.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Azure resource group
        /// </param>
        /// <param name='workspaceCollectionName'>
        /// Power BI Embedded workspace collection name
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="ErrorException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<AzureOperationResponse<WorkspaceCollection>> GetByNameWithHttpMessagesAsync(string resourceGroupName, string workspaceCollectionName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Creates a new Power BI Workspace Collection with the specified
        /// properties. A Power BI Workspace Collection contains one or more
        /// Power BI Workspaces and can be used to provision keys that
        /// provide API access to those Power BI Workspaces.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Azure resource group
        /// </param>
        /// <param name='workspaceCollectionName'>
        /// Power BI Embedded workspace collection name
        /// </param>
        /// <param name='body'>
        /// Create workspace collection request
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="ErrorException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<AzureOperationResponse<WorkspaceCollection>> CreateWithHttpMessagesAsync(string resourceGroupName, string workspaceCollectionName, CreateWorkspaceCollectionRequest body, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Update an existing Power BI Workspace Collection with the
        /// specified properties.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Azure resource group
        /// </param>
        /// <param name='workspaceCollectionName'>
        /// Power BI Embedded workspace collection name
        /// </param>
        /// <param name='body'>
        /// Update workspace collection request
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="ErrorException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<AzureOperationResponse<WorkspaceCollection>> UpdateWithHttpMessagesAsync(string resourceGroupName, string workspaceCollectionName, UpdateWorkspaceCollectionRequest body, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Delete a Power BI Workspace Collection.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Azure resource group
        /// </param>
        /// <param name='workspaceCollectionName'>
        /// Power BI Embedded workspace collection name
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="ErrorException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<AzureOperationResponse> DeleteWithHttpMessagesAsync(string resourceGroupName, string workspaceCollectionName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Delete a Power BI Workspace Collection.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Azure resource group
        /// </param>
        /// <param name='workspaceCollectionName'>
        /// Power BI Embedded workspace collection name
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="ErrorException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<AzureOperationResponse> BeginDeleteWithHttpMessagesAsync(string resourceGroupName, string workspaceCollectionName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Check that the specified Power BI Workspace Collection name is
        /// valid and not in use.
        /// </summary>
        /// <param name='location'>
        /// Azure location
        /// </param>
        /// <param name='body'>
        /// Check name availability request
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="ErrorException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<AzureOperationResponse<CheckNameResponse>> CheckNameAvailabilityWithHttpMessagesAsync(string location, CheckNameRequest body, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Retrieves all existing Power BI Workspace Collections in the
        /// specified resource group.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Azure resource group
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="ErrorException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<AzureOperationResponse<IEnumerable<WorkspaceCollection>>> ListByResourceGroupWithHttpMessagesAsync(string resourceGroupName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Retrieves all existing Power BI Workspace Collections in the
        /// specified subscription.
        /// </summary>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="ErrorException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<AzureOperationResponse<IEnumerable<WorkspaceCollection>>> ListBySubscriptionWithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Retrieves the primary and secondary access keys for the specified
        /// Power BI Workspace Collection.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Azure resource group
        /// </param>
        /// <param name='workspaceCollectionName'>
        /// Power BI Embedded workspace collection name
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="ErrorException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<AzureOperationResponse<WorkspaceCollectionAccessKeys>> GetAccessKeysWithHttpMessagesAsync(string resourceGroupName, string workspaceCollectionName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Regenerates the primary or secondary access key for the specified
        /// Power BI Workspace Collection.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Azure resource group
        /// </param>
        /// <param name='workspaceCollectionName'>
        /// Power BI Embedded workspace collection name
        /// </param>
        /// <param name='body'>
        /// Access key to regenerate
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="ErrorException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="SerializationException">
        /// Thrown when unable to deserialize the response
        /// </exception>
        /// <exception cref="ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<AzureOperationResponse<WorkspaceCollectionAccessKeys>> RegenerateKeyWithHttpMessagesAsync(string resourceGroupName, string workspaceCollectionName, WorkspaceCollectionAccessKey body, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Migrates an existing Power BI Workspace Collection to a different
        /// resource group and/or subscription.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Azure resource group
        /// </param>
        /// <param name='body'>
        /// Workspace migration request
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="ErrorException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task<AzureOperationResponse> MigrateWithHttpMessagesAsync(string resourceGroupName, MigrateWorkspaceCollectionRequest body, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}

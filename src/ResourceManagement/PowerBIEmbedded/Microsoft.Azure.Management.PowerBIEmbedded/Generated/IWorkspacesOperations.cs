
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
    /// WorkspacesOperations operations.
    /// </summary>
    public partial interface IWorkspacesOperations
    {
        /// <summary>
        /// Retrieves all existing Power BI Workspaces in the specified
        /// Workspace Collection.
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
        Task<AzureOperationResponse<IEnumerable<Workspace>>> ListWithHttpMessagesAsync(string resourceGroupName, string workspaceCollectionName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}

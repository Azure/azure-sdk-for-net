/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.V2.Resource.Core.CollectionActions
{

    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Provides access to deleting a resource from Azure, identifying it by its resource ID.
    /// <p>
    /// (Note: this interface is not intended to be implemented by user code)
    /// </summary>
    public interface ISupportsDeleting 
    {
        /// <summary>
        /// Deletes a resource from Azure, identifying it by its resource ID.
        /// </summary>
        /// <param name="id">id the resource ID of the resource to delete</param>
        void Delete (string id);

        /// <summary>
        /// Deletes a resource from Azure, identifying it by its resource ID.
        /// </summary>
        /// <param name="id">id the resource ID of the resource to delete</param>
        /// <param name="cancellationToken">cancellationToken the cancellation token</param>
        Task DeleteAsync (string id, CancellationToken cancellationToken = default(CancellationToken));

    }
}
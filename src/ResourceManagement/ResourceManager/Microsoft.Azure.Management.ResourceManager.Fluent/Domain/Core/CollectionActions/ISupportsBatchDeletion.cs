// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Provides access to deleting multiple resource from Azure, identifying them by their IDs.
    /// <p>
    /// (Note: this interface is not intended to be implemented by user code)
    /// </summary>

    public interface ISupportsBatchDeletion
    {
        /// <summary>
        /// Deletes the specified resources from Azure asynchronously and in parallel.
        /// <p>
        /// (Note: this interface is not intended to be implemented by user code.)
        /// </summary>
        /// <param name="ids">resource IDs of the resources to be deleted</param>
        /// <param name="cancellationToken">cancellationToken the cancellation token</param>
        Task<IEnumerable<string>> DeleteByIdsAsync(IEnumerable<string> ids, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Deletes the specified resources from Azure asynchronously and in parallel.
        /// <p>
        /// (Note: this interface is not intended to be implemented by user code.)
        /// </summary>
        /// <param name="ids">resource IDs of the resources to be deleted</param>
        /// <param name="cancellationToken">cancellationToken the cancellation token</param>
        Task<IEnumerable<string>> DeleteByIdsAsync(CancellationToken cancellationToken = default(CancellationToken), params string[] ids);

        /// <summary>
        /// Deletes the specified resources from Azure.
        /// <p>
        /// (Note: this interface is not intended to be implemented by user code.)
        /// </summary>
        /// <param name="ids">resource IDs of the resources to be deleted</param>
        void DeleteByIds(IEnumerable<string> ids);

        /// <summary>
        /// Deletes the specified resources from Azure.
        /// <p>
        /// (Note: this interface is not intended to be implemented by user code.)
        /// </summary>
        /// <param name="ids">resource IDs of the resources to be deleted</param>
        void DeleteByIds(params string[] ids);
    }
}

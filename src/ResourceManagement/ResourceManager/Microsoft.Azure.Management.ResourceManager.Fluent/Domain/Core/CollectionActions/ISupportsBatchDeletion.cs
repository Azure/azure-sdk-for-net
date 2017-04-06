// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions
{
    using System.Threading;
    using System.Threading.Tasks;
    using System.Collections.Generic;

    /// <summary>
    /// Provides access to deleting multiple resource from Azure, identifying them by their IDs.
    /// (Note this interface is not intended to be implemented by user code.).
    /// </summary>
    /// <remarks>
    /// (Beta: This functionality is in preview and as such is subject to change in non-backwards compatible ways in
    /// future releases, including removal, regardless of any compatibility expectations set by the containing library
    /// version number.).
    /// </remarks>
    public interface ISupportsBatchDeletion 
    {
        /// <summary>
        /// Deletes the specified resources from Azure asynchronously and in parallel.
        /// </summary>
        /// <remarks>
        /// (Beta: This functionality is in preview and as such is subject to change in non-backwards compatible ways in
        /// future releases, including removal, regardless of any compatibility expectations set by the containing library
        /// version number.).
        /// </remarks>
        /// <param name="ids">Resource IDs of the resources to be deleted.</param>
        /// <return>An observable from which all of the successfully deleted resources can be observed.</return>
        Task<System.Collections.Generic.IEnumerable<string>> DeleteByIdsAsync(IList<string> ids, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Deletes the specified resources from Azure asynchronously and in parallel.
        /// </summary>
        /// <remarks>
        /// (Beta: This functionality is in preview and as such is subject to change in non-backwards compatible ways in
        /// future releases, including removal, regardless of any compatibility expectations set by the containing library
        /// version number.).
        /// </remarks>
        /// <param name="ids">Resource IDs of the resources to be deleted.</param>
        /// <return>An observable from which all of the successfully deleted resources can be observed.</return>
        Task<System.Collections.Generic.IEnumerable<string>> DeleteByIdsAsync(string[] ids, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Deletes the specified resources from Azure.
        /// </summary>
        /// <remarks>
        /// (Beta: This functionality is in preview and as such is subject to change in non-backwards compatible ways in
        /// future releases, including removal, regardless of any compatibility expectations set by the containing library
        /// version number.).
        /// </remarks>
        /// <param name="ids">Resource IDs of the resources to be deleted.</param>
        void DeleteByIds(IList<string> ids);

        /// <summary>
        /// Deletes the specified resources from Azure.
        /// </summary>
        /// <remarks>
        /// (Beta: This functionality is in preview and as such is subject to change in non-backwards compatible ways in
        /// future releases, including removal, regardless of any compatibility expectations set by the containing library
        /// version number.).
        /// </remarks>
        /// <param name="ids">Resource IDs of the resources to be deleted.</param>
        void DeleteByIds(params string[] ids);
    }
}
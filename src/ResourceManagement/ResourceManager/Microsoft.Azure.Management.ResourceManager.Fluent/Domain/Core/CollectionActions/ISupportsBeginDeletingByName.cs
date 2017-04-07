// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions
{
    /// <summary>
    /// Provides access to deleting a resource from Azure, identifying it by its resource ID.
    /// </summary>
    public interface ISupportsBeginDeletingByName
    {
        /// <summary>
        /// Begins deleting a resource from Azure, identifying it by its resource name. The
        /// resource will stay until get() returns null.
        /// </summary>
        /// <param name="name">the name of the resource to delete</param>
        void BeginDeleteByName(string name);

        /// <summary>
        /// Begins deleting a resource from Azure, identifying it by its resource name. The
        /// resource will stay until get() returns null.
        /// </summary>
        /// <param name="name">the name of the resource to delete</param>
        /// <param name="cancellationToken">cancellationToken the cancellation token</param>
        /// <return>A await-able Task for asynchronous operation.</return>
        Task BeginDeleteByNameAsync(string name, CancellationToken cancellationToken = default(CancellationToken));
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information. 

using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions
{
    public interface ISupportsDeletingByName
    {
        /// <summary>
        /// Deletes a resource from Azure, identifying it by its resource name.
        /// </summary>
        /// <param name="name">the name of the resource to delete</param>
        void DeleteByName(string name);

        /// <summary>
        /// Deletes a resource asynchronously from Azure, identifying it by its resource name.
        /// </summary>
        /// <param name="name">the name of the resource to delete</param>
        /// <param name="cancellationToken"></param>
        Task DeleteByNameAsync(string name, CancellationToken cancellationToken = default(CancellationToken));
    }
}

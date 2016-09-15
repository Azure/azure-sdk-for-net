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
    /// Provides access to deleting a resource from Azure, identifying it by its name and its resource group.
    /// 
    /// (Note: this interface is not intended to be implemented by user code)
    /// </summary>
    public interface ISupportsDeletingByGroup 
    {
        /// <summary>
        /// Deletes a resource from Azure, identifying it by its name and its resource group.
        /// </summary>
        /// <param name="groupName">groupName The group the resource is part of</param>
        /// <param name="name">name The name of the resource</param>
        void Delete (string groupName, string name);

        /// <summary>
        /// Deletes a resource from Azure, identifying it by its name and its resource group.
        /// </summary>
        /// <param name="groupName">groupName The group the resource is part of</param>
        /// <param name="name">name The name of the resource</param>
        /// <param name="cancellationToken">cancellationToken the cancellation token</param>
        Task DeleteAsync (string groupName, string name, CancellationToken cancellationToken = default(CancellationToken));

    }
}
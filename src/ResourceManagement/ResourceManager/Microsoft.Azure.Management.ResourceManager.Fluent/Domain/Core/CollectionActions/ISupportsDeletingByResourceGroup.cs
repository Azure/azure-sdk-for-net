// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information. 

namespace Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions
{

    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Provides access to deleting a resource from Azure, identifying it by its name and its resource group.
    /// 
    /// (Note: this interface is not intended to be implemented by user code)
    /// </summary>
    public interface ISupportsDeletingByResourceGroup 
    {
        /// <summary>
        /// Deletes a resource from Azure, identifying it by its name and its resource group.
        /// </summary>
        /// <param name="resourceGroupName">the group the resource is part of</param>
        /// <param name="name">the name of the resource</param>
        void DeleteByResourceGroup (string resourceGroupName, string name);

        /// <summary>
        /// Deletes a resource from Azure, identifying it by its name and its resource group.
        /// </summary>
        /// <param name="resourceGroupName">the group the resource is part of</param>
        /// <param name="name">the name of the resource</param>
        /// <param name="cancellationToken">cancellationToken the cancellation token</param>
        Task DeleteByResourceGroupAsync (string resourceGroupName, string name, CancellationToken cancellationToken = default(CancellationToken));

    }
}
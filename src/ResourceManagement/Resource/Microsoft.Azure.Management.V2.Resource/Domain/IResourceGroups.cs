// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information. 

namespace Microsoft.Azure.Management.Fluent.Resource
{

    using Microsoft.Azure.Management.Fluent.Resource.Core.CollectionActions;
    using Microsoft.Azure.Management.Fluent.Resource.ResourceGroup.Definition;

    /// <summary>
    /// Entry point to resource group management API.
    /// </summary>
    public interface IResourceGroups  :
        ISupportsListing<IResourceGroup>,
        ISupportsGettingByName<IResourceGroup>,
        ISupportsCreating<IBlank>,
        ISupportsDeleting,
        ISupportsBatchCreation<IResourceGroup>
    {
        /// <summary>
        /// Checks whether resource group exists.
        /// </summary>
        /// <param name="name">name The name of the resource group to check. The name is case insensitive</param>
        /// <returns>true if the resource group exists; false otherwise</returns>
        bool CheckExistence (string name);

    }
}
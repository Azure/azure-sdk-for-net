/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.V2.Resource
{

    using Microsoft.Azure.Management.V2.Resource.Core.CollectionActions;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.V2.Resource.GenericResource.Definition;

    /// <summary>
    /// Entry point to generic resources management API.
    /// </summary>
    public interface IGenericResources  :
        ISupportsListingByGroup<IGenericResource>,
        ISupportsGettingByGroup<IGenericResource>,
        ISupportsGettingById<IGenericResource>,
        ISupportsCreating<GenericResource.Definition.IBlank>
    {
        /// <summary>
        /// Checks if a resource exists in a resource group.
        /// </summary>
        /// <param name="resourceGroupName">resourceGroupName the resource group's name</param>
        /// <param name="resourceProviderNamespace">resourceProviderNamespace the resource provider's namespace</param>
        /// <param name="parentResourcePath">parentResourcePath the parent's resource path</param>
        /// <param name="resourceType">resourceType the type of the resource</param>
        /// <param name="resourceName">resourceName the name of the resource</param>
        /// <param name="apiVersion">apiVersion the API version</param>
        /// <returns>true if the resource exists; false otherwise</returns>
        bool CheckExistence (string resourceGroupName, string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, string apiVersion);

        /// <summary>
        /// Returns a resource belonging to a resource group.
        /// </summary>
        /// <param name="resourceGroupName">resourceGroupName The name of the resource group. The name is case insensitive.</param>
        /// <param name="resourceProviderNamespace">resourceProviderNamespace Resource identity.</param>
        /// <param name="parentResourcePath">parentResourcePath Resource identity.</param>
        /// <param name="resourceType">resourceType Resource identity.</param>
        /// <param name="resourceName">resourceName Resource identity.</param>
        /// <param name="apiVersion">apiVersion the String value</param>
        /// <returns>the generic resource</returns>
        IGenericResource Get (string resourceGroupName, string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, string apiVersion);

        /// <summary>
        /// Move resources from one resource group to another.
        /// </summary>
        /// <param name="sourceResourceGroupName">sourceResourceGroupName Source resource group name</param>
        /// <param name="targetResourceGroup">targetResourceGroup target resource group, can be in a different subscription</param>
        /// <param name="resources">resources the list of IDs of the resources to move</param>
        void MoveResources (string sourceResourceGroupName, IResourceGroup targetResourceGroup, IList<string> resources);

        /// <summary>
        /// Delete resource and all of its child resources.
        /// </summary>
        /// <param name="resourceGroupName">resourceGroupName The name of the resource group. The name is case insensitive.</param>
        /// <param name="resourceProviderNamespace">resourceProviderNamespace Resource identity.</param>
        /// <param name="parentResourcePath">parentResourcePath Resource identity.</param>
        /// <param name="resourceType">resourceType Resource identity.</param>
        /// <param name="resourceName">resourceName Resource identity.</param>
        /// <param name="apiVersion">apiVersion the String value</param>
        void Delete (string resourceGroupName, string resourceProviderNamespace, string parentResourcePath, string resourceType, string resourceName, string apiVersion);

    }
}
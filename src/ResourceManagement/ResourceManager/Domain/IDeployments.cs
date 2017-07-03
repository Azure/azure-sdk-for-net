// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information. 

namespace Microsoft.Azure.Management.ResourceManager.Fluent
{
    using Microsoft.Azure.Management.ResourceManager.Fluent.Deployment.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.CollectionActions;
    using Core;
    using Management.ResourceManager.Fluent;

    /// <summary>
    /// Entry point to template deployment in Azure.
    /// </summary>
    public interface IDeployments  :
        ISupportsCreating<IBlank>,
        ISupportsListing<IDeployment>,
        ISupportsListingByResourceGroup<IDeployment>,
        ISupportsGettingByName<IDeployment>,
        ISupportsGettingByResourceGroup<IDeployment>,
        ISupportsGettingById<IDeployment>,
        ISupportsDeletingById,
        ISupportsDeletingByResourceGroup,
        IHasManager<IResourceManager>,
        IHasInner<IDeploymentsOperations>
    {
        /// <summary>
        /// Checks if a deployment exists in a resource group.
        /// </summary>
        /// <param name="resourceGroupName">resourceGroupName the resource group's name</param>
        /// <param name="deploymentName">deploymentName the deployment's name</param>
        /// <returns>true if the deployment exists; false otherwise</returns>
        bool CheckExistence (string resourceGroupName, string deploymentName);

    }
}
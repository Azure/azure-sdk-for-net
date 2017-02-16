// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information. 

namespace Microsoft.Azure.Management.Resource.Fluent
{

    using Microsoft.Azure.Management.Resource.Fluent.Deployment.Definition;
    using Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions;
    using Core;

    /// <summary>
    /// Entry point to template deployment in Azure.
    /// </summary>
    public interface IDeployments  :
        ISupportsCreating<IBlank>,
        ISupportsListing<IDeployment>,
        ISupportsListingByGroup<IDeployment>,
        ISupportsGettingByName<IDeployment>,
        ISupportsGettingByGroup<IDeployment>,
        ISupportsGettingById<IDeployment>,
        ISupportsDeletingById,
        ISupportsDeletingByGroup,
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
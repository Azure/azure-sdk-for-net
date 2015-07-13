namespace Microsoft.Azure.Management.Resources
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest;
    using Microsoft.Azure.OData;
    using System.Linq.Expressions;
    using Microsoft.Azure;
    using Models;

    /// <summary>
    /// </summary>
    public partial interface IResourceManagementClient
    {
        /// <summary>
        /// The base URI of the service.
        /// </summary>
        Uri BaseUri { get; set; }

        IProvidersOperations Providers { get; }

        IResourceGroupsOperations ResourceGroups { get; }

        IResourcesOperations Resources { get; }

        ITagsOperations Tags { get; }

        IDeploymentOperationsOperations DeploymentOperations { get; }

        IResourceProviderOperationDetailsOperations ResourceProviderOperationDetails { get; }

        IDeploymentsOperations Deployments { get; }

        }
}

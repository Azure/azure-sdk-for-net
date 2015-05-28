using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Rest;
using Microsoft.Azure.OData;
using System.Linq.Expressions;
using Microsoft.Azure;
using Microsoft.Azure.Management.Resources.Models;

namespace Microsoft.Azure.Management.Resources
{
    /// <summary>
    /// </summary>
    public partial interface IResourceManagementClient : IDisposable
    {
        /// <summary>
        /// The base URI of the service.
        /// </summary>
        Uri BaseUri { get; set; }

        IProviderOperations Providers { get; }

        IResourceOperations Resources { get; }

        ITagOperations Tags { get; }

        IDeploymentOperationOperations DeploymentOperations { get; }

        IResourceProviderOperationDetailOperations ResourceProviderOperationDetails { get; }

        IResourceGroupOperations ResourceGroups { get; }

        IDeploymentOperations Deployments { get; }

        }
}

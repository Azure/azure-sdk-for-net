namespace Microsoft.Azure.Management.Resources
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using System.Linq;
    using System.Linq.Expressions;
    using Microsoft.Rest.Azure.OData;
    using Microsoft.Rest.Azure;
    using Models;

    /// <summary>
    /// </summary>
    public partial interface IResourceManagementClient
    {
        /// <summary>
        /// The base URI of the service.
        /// </summary>
        Uri BaseUri { get; set; }

        /// <summary>
        /// Gets or sets json serialization settings.
        /// </summary>
        JsonSerializerSettings SerializationSettings { get; }

        /// <summary>
        /// Gets or sets json deserialization settings.
        /// </summary>
        JsonSerializerSettings DeserializationSettings { get; }        

        /// <summary>
        /// Management credentials for Azure.
        /// </summary>
        ServiceClientCredentials Credentials { get; }

        /// <summary>
        /// Gets subscription credentials which uniquely identify Microsoft
        /// Azure subscription. The subscription ID forms part of the URI for
        /// every service call.
        /// </summary>
        string SubscriptionId { get; set; }

        /// <summary>
        /// Client Api Version.
        /// </summary>
        string ApiVersion { get; }

        /// <summary>
        /// Gets or sets the preferred language for the response.
        /// </summary>
        string AcceptLanguage { get; set; }

        /// <summary>
        /// The retry timeout for Long Running Operations.
        /// </summary>
        int? LongRunningOperationRetryTimeout { get; set; }


        IProvidersOperations Providers { get; }

        IResourceGroupsOperations ResourceGroups { get; }

        IResourcesOperations Resources { get; }

        ITagsOperations Tags { get; }

        IDeploymentOperationsOperations DeploymentOperations { get; }

        IResourceProviderOperationDetailsOperations ResourceProviderOperationDetails { get; }

        IDeploymentsOperations Deployments { get; }

    }
}

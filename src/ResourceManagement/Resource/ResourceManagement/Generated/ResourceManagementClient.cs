namespace Microsoft.Azure.Management.Resources
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Newtonsoft.Json;
    using Microsoft.Azure.OData;
    using System.Linq.Expressions;
    using Microsoft.Azure;
    using Models;

    /// <summary>
    /// </summary>
    public partial class ResourceManagementClient : ServiceClient<ResourceManagementClient>, IResourceManagementClient, IAzureClient
    {
        /// <summary>
        /// The base URI of the service.
        /// </summary>
        public Uri BaseUri { get; set; }

        /// <summary>
        /// Gets or sets json serialization settings.
        /// </summary>
        public JsonSerializerSettings SerializationSettings { get; private set; }

        /// <summary>
        /// Gets or sets json deserialization settings.
        /// </summary>
        public JsonSerializerSettings DeserializationSettings { get; private set; }        

        /// <summary>
        /// Subscription credentials which uniquely identify Microsoft Azure
        /// subscription.
        /// </summary>
        public SubscriptionCloudCredentials Credentials { get; set; }

        /// <summary>
        /// Gets subscription credentials which uniquely identify Microsoft
        /// Azure subscription. The subscription ID forms part of the URI for
        /// every service call.
        /// </summary>
        public string SubscriptionId { get; set; }

        /// <summary>
        /// Client Api Version.
        /// </summary>
        public string ApiVersion { get; private set; }

        /// <summary>
        /// The retry timeout for Long Running Operations.
        /// </summary>
        public int? LongRunningOperationRetryTimeout { get; set; }

        public virtual IProvidersOperations Providers { get; private set; }

        public virtual IResourceGroupsOperations ResourceGroups { get; private set; }

        public virtual IResourcesOperations Resources { get; private set; }

        public virtual ITagsOperations Tags { get; private set; }

        public virtual IDeploymentOperationsOperations DeploymentOperations { get; private set; }

        public virtual IResourceProviderOperationDetailsOperations ResourceProviderOperationDetails { get; private set; }

        public virtual IDeploymentsOperations Deployments { get; private set; }

        /// <summary>
        /// Initializes a new instance of the ResourceManagementClient class.
        /// </summary>
        public ResourceManagementClient() : base()
        {
            this.Initialize();
        }

        /// <summary>
        /// Initializes a new instance of the ResourceManagementClient class.
        /// </summary>
        /// <param name='handlers'>
        /// Optional. The set of delegating handlers to insert in the http
        /// client pipeline.
        /// </param>
        public ResourceManagementClient(params DelegatingHandler[] handlers) : base(handlers)
        {
            this.Initialize();
        }

        /// <summary>
        /// Initializes a new instance of the ResourceManagementClient class.
        /// </summary>
        /// <param name='rootHandler'>
        /// Optional. The http client handler used to handle http transport.
        /// </param>
        /// <param name='handlers'>
        /// Optional. The set of delegating handlers to insert in the http
        /// client pipeline.
        /// </param>
        public ResourceManagementClient(HttpClientHandler rootHandler, params DelegatingHandler[] handlers) : base(rootHandler, handlers)
        {
            this.Initialize();
        }

        /// <summary>
        /// Initializes a new instance of the ResourceManagementClient class.
        /// </summary>
        /// <param name='baseUri'>
        /// Optional. The base URI of the service.
        /// </param>
        /// <param name='handlers'>
        /// Optional. The set of delegating handlers to insert in the http
        /// client pipeline.
        /// </param>
        public ResourceManagementClient(Uri baseUri, params DelegatingHandler[] handlers) : this(handlers)
        {
            if (baseUri == null)
            {
                throw new ArgumentNullException("baseUri");
            }
            this.BaseUri = baseUri;
        }

        /// <summary>
        /// Initializes a new instance of the ResourceManagementClient class.
        /// </summary>
        /// <param name='credentials'>
        /// Required. Subscription credentials which uniquely identify Microsoft Azure subscription.
        /// </param>
        /// <param name='subscriptionId'>
        /// Required. Gets subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.
        /// </param>
        /// <param name='handlers'>
        /// Optional. The set of delegating handlers to insert in the http
        /// client pipeline.
        /// </param>
        public ResourceManagementClient(SubscriptionCloudCredentials credentials, string subscriptionId, params DelegatingHandler[] handlers) : this(handlers)
        {
            if (credentials == null)
            {
                throw new ArgumentNullException("credentials");
            }
            if (subscriptionId == null)
            {
                throw new ArgumentNullException("subscriptionId");
            }
            this.Credentials = credentials;
            this.SubscriptionId = subscriptionId;
        }

        /// <summary>
        /// Initializes a new instance of the ResourceManagementClient class.
        /// </summary>
        /// <param name='baseUri'>
        /// Optional. The base URI of the service.
        /// </param>
        /// <param name='credentials'>
        /// Required. Subscription credentials which uniquely identify Microsoft Azure subscription.
        /// </param>
        /// <param name='subscriptionId'>
        /// Required. Gets subscription credentials which uniquely identify Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.
        /// </param>
        /// <param name='handlers'>
        /// Optional. The set of delegating handlers to insert in the http
        /// client pipeline.
        /// </param>
        public ResourceManagementClient(Uri baseUri, SubscriptionCloudCredentials credentials, string subscriptionId, params DelegatingHandler[] handlers) : this(handlers)
        {
            if (baseUri == null)
            {
                throw new ArgumentNullException("baseUri");
            }
            if (credentials == null)
            {
                throw new ArgumentNullException("credentials");
            }
            if (subscriptionId == null)
            {
                throw new ArgumentNullException("subscriptionId");
            }
            this.BaseUri = baseUri;
            this.Credentials = credentials;
            this.SubscriptionId = subscriptionId;
        }

        /// <summary>
        /// Initializes client properties.
        /// </summary>
        private void Initialize()
        {
            this.Providers = new ProvidersOperations(this);
            this.ResourceGroups = new ResourceGroupsOperations(this);
            this.Resources = new ResourcesOperations(this);
            this.Tags = new TagsOperations(this);
            this.DeploymentOperations = new DeploymentOperationsOperations(this);
            this.ResourceProviderOperationDetails = new ResourceProviderOperationDetailsOperations(this);
            this.Deployments = new DeploymentsOperations(this);
            this.BaseUri = new Uri("https://management.azure.com");
            this.ApiVersion = "2014-04-01-preview";
            SerializationSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                DateFormatHandling = DateFormatHandling.IsoDateFormat,
                DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                ContractResolver = new ReadOnlyJsonContractResolver()
            };
            SerializationSettings.Converters.Add(new ResourceJsonConverter()); 
            DeserializationSettings = new JsonSerializerSettings{
                DateFormatHandling = DateFormatHandling.IsoDateFormat,
                DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                ContractResolver = new ReadOnlyJsonContractResolver()
            };
            DeserializationSettings.Converters.Add(new ResourceJsonConverter()); 
            DeserializationSettings.Converters.Add(new CloudErrorJsonConverter()); 
        }    
    }
}

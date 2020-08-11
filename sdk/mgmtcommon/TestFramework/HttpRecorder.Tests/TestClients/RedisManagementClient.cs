// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using HttpRecorder.Tests.TestClients.Redis.Models;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Newtonsoft.Json;
using Microsoft.Rest.Azure;

namespace HttpRecorder.Tests.TestClients.Redis.Models
{
    public partial class RedisCreateOrUpdateParameters
    {
        private string _location;

        /// <summary>
        /// Optional.
        /// </summary>
        public string Location
        {
            get { return this._location; }
            set { this._location = value; }
        }

        private RedisProperties _properties;

        /// <summary>
        /// Optional.
        /// </summary>
        public RedisProperties Properties
        {
            get { return this._properties; }
            set { this._properties = value; }
        }
    }

    public partial class RedisResource : IResource
    {
        /// <summary>
        /// Gets the ID of the resource.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; private set; }

        /// <summary>
        /// Gets the name of the resource.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; private set; }

        /// <summary>
        /// Gets the type of the resource.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; private set; }

        /// <summary>
        /// Required. Gets or sets the location of the resource.
        /// </summary>
        [JsonProperty("location")]
        public string Location { get; set; }

        /// <summary>
        /// Optional. Gets or sets the tags attached to the resource.
        /// </summary>
        [JsonProperty("tags")]
        public IDictionary<string, string> Tags { get; set; }

        /// <summary>
        /// Validate the object. Throws ArgumentException or ArgumentNullException if validation fails.
        /// </summary>
        public virtual void Validate()
        {
            if (Location == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Location");
            }
        }

        private string _hostName;

        /// <summary>
        /// Optional.
        /// </summary>
        public string HostName
        {
            get { return this._hostName; }
            set { this._hostName = value; }
        }

        private int? _port;

        /// <summary>
        /// Optional.
        /// </summary>
        public int? Port
        {
            get { return this._port; }
            set { this._port = value; }
        }

        private int? _sslPort;

        /// <summary>
        /// Optional.
        /// </summary>
        public int? SslPort
        {
            get { return this._sslPort; }
            set { this._sslPort = value; }
        }

        /// <summary>
        /// Optional.
        /// </summary>
        [JsonProperty("properties.provisioningState")]
        public string ProvisioningState { get; set; }
    }

    public partial class RedisSubResource : IResource
    {
        /// <summary>
        /// Gets the ID of the resource.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; private set; }

        private string _hostName;

        /// <summary>
        /// Optional.
        /// </summary>
        public string HostName
        {
            get { return this._hostName; }
            set { this._hostName = value; }
        }

        private int? _port;

        /// <summary>
        /// Optional.
        /// </summary>
        public int? Port
        {
            get { return this._port; }
            set { this._port = value; }
        }

        private int? _sslPort;

        /// <summary>
        /// Optional.
        /// </summary>
        public int? SslPort
        {
            get { return this._sslPort; }
            set { this._sslPort = value; }
        }
    }

    public partial class RedisProperties
    {
        private bool? _enableNonSslPort;

        /// <summary>
        /// Optional.
        /// </summary>
        public bool? EnableNonSslPort
        {
            get { return this._enableNonSslPort; }
            set { this._enableNonSslPort = value; }
        }

        private string _maxMemoryPolicy;

        /// <summary>
        /// Optional.
        /// </summary>
        public string MaxMemoryPolicy
        {
            get { return this._maxMemoryPolicy; }
            set { this._maxMemoryPolicy = value; }
        }

        private string _redisVersion;

        /// <summary>
        /// Optional.
        /// </summary>
        public string RedisVersion
        {
            get { return this._redisVersion; }
            set { this._redisVersion = value; }
        }

        private Sku _sku;

        /// <summary>
        /// Optional.
        /// </summary>
        public Sku Sku
        {
            get { return this._sku; }
            set { this._sku = value; }
        }
    }

    public partial class RedisReadableProperties
    {
        private string _hostName;

        /// <summary>
        /// Optional.
        /// </summary>
        public string HostName
        {
            get { return this._hostName; }
            set { this._hostName = value; }
        }

        private int? _port;

        /// <summary>
        /// Optional.
        /// </summary>
        public int? Port
        {
            get { return this._port; }
            set { this._port = value; }
        }

        private string _provisioningState;

        /// <summary>
        /// Optional.
        /// </summary>
        public string ProvisioningState
        {
            get { return this._provisioningState; }
            set { this._provisioningState = value; }
        }

        private int? _sslPort;

        /// <summary>
        /// Optional.
        /// </summary>
        public int? SslPort
        {
            get { return this._sslPort; }
            set { this._sslPort = value; }
        }
    }

    public partial class Sku
    {
        private int? _capacity;

        /// <summary>
        /// Optional.
        /// </summary>
        public int? Capacity
        {
            get { return this._capacity; }
            set { this._capacity = value; }
        }

        private string _family;

        /// <summary>
        /// Optional.
        /// </summary>
        public string Family
        {
            get { return this._family; }
            set { this._family = value; }
        }

        private string _name;

        /// <summary>
        /// Optional.
        /// </summary>
        public string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }
    }
}

namespace HttpRecorder.Tests.TestClients.Redis
{
    public static partial class RedisManagementClientExtensions
    {
    }

    public partial interface IRedisManagementClient : IDisposable
    {
        string ApiVersion
        {
            get;
            set;
        }

        /// <summary>
        /// The base URI of the service.
        /// </summary>
        Uri BaseUri
        {
            get;
            set;
        }

        ServiceClientCredentials Credentials
        {
            get;
            set;
        }

        int? LongRunningOperationInitialTimeout
        {
            get;
            set;
        }

        int? LongRunningOperationRetryTimeout
        {
            get;
            set;
        }

        IRedisOperations RedisOperations
        {
            get;
        }
    }

    public partial class RedisManagementClient : ServiceClient<RedisManagementClient>, IRedisManagementClient, IAzureClient
    {
        private string _apiVersion;

        public string ApiVersion
        {
            get { return this._apiVersion; }
            set { this._apiVersion = value; }
        }

        private Uri _baseUri;

        /// <summary>
        /// The base URI of the service.
        /// </summary>
        public Uri BaseUri
        {
            get { return this._baseUri; }
            set { this._baseUri = value; }
        }

        /// <summary>
        /// Gets or sets json serialization settings.
        /// </summary>
        public JsonSerializerSettings SerializationSettings { get; private set; }

        /// <summary>
        /// Gets or sets json deserialization settings.
        /// </summary>
        public JsonSerializerSettings DeserializationSettings { get; private set; }

        private ServiceClientCredentials _credentials;

        public ServiceClientCredentials Credentials
        {
            get { return this._credentials; }
            set { this._credentials = value; }
        }

        private int? _longRunningOperationInitialTimeout;

        public int? LongRunningOperationInitialTimeout
        {
            get { return this._longRunningOperationInitialTimeout; }
            set { this._longRunningOperationInitialTimeout = value; }
        }

        private int? _longRunningOperationRetryTimeout;

        public int? LongRunningOperationRetryTimeout
        {
            get { return this._longRunningOperationRetryTimeout; }
            set { this._longRunningOperationRetryTimeout = value; }
        }

        public bool? GenerateClientRequestId { get; set; }

        private IRedisOperations _redisOperations;

        public virtual IRedisOperations RedisOperations
        {
            get { return this._redisOperations; }
        }

        /// <summary>
        /// Initializes a new instance of the RedisManagementClient class.
        /// </summary>
        public RedisManagementClient()
            : base()
        {
            this._redisOperations = new RedisOperations(this);
            this._baseUri = new Uri("https://management.azure.com");
            this._apiVersion = "2014-04-01-preview";
            this.HttpClient.Timeout = TimeSpan.FromSeconds(300);
            this.Initialize();
        }

        /// <summary>
        /// Initializes a new instance of the RedisManagementClient class.
        /// </summary>
        /// <param name='handlers'>
        /// Optional. The set of delegating handlers to insert in the http
        /// client pipeline.
        /// </param>
        public RedisManagementClient(params DelegatingHandler[] handlers)
            : base(handlers)
        {
            this._redisOperations = new RedisOperations(this);
            this._baseUri = new Uri("https://management.azure.com");
            this._apiVersion = "2014-04-01-preview";
            this.HttpClient.Timeout = TimeSpan.FromSeconds(300);
            this.Initialize();
        }

        /// <summary>
        /// Initializes a new instance of the RedisManagementClient class.
        /// </summary>
        /// <param name='rootHandler'>
        /// Optional. The http client handler used to handle http transport.
        /// </param>
        /// <param name='handlers'>
        /// Optional. The set of delegating handlers to insert in the http
        /// client pipeline.
        /// </param>
        public RedisManagementClient(HttpClientHandler rootHandler, params DelegatingHandler[] handlers)
            : base(rootHandler, handlers)
        {
            this._redisOperations = new RedisOperations(this);
            this._baseUri = new Uri("https://management.azure.com");
            this._apiVersion = "2014-04-01-preview";
            this.HttpClient.Timeout = TimeSpan.FromSeconds(300);
            this.Initialize();
        }

        /// <summary>
        /// Initializes a new instance of the RedisManagementClient class.
        /// </summary>
        /// <param name='baseUri'>
        /// Optional. The base URI of the service.
        /// </param>
        /// <param name='handlers'>
        /// Optional. The set of delegating handlers to insert in the http
        /// client pipeline.
        /// </param>
        public RedisManagementClient(Uri baseUri, params DelegatingHandler[] handlers)
            : this(handlers)
        {
            if (baseUri == null)
            {
                throw new ArgumentNullException("baseUri");
            }
            this._baseUri = baseUri;
        }

        /// <summary>
        /// Initializes a new instance of the RedisManagementClient class.
        /// </summary>
        /// <param name='credentials'>
        /// Required.
        /// </param>
        /// <param name='handlers'>
        /// Optional. The set of delegating handlers to insert in the http
        /// client pipeline.
        /// </param>
        public RedisManagementClient(ServiceClientCredentials credentials, params DelegatingHandler[] handlers)
            : this(handlers)
        {
            if (credentials == null)
            {
                throw new ArgumentNullException("credentials");
            }
            this._credentials = credentials;

            if (this.Credentials != null)
            {
                this.Credentials.InitializeServiceClient(this);
            }
        }

        /// <summary>
        /// Initializes a new instance of the RedisManagementClient class.
        /// </summary>
        /// <param name='baseUri'>
        /// Optional. The base URI of the service.
        /// </param>
        /// <param name='credentials'>
        /// Required.
        /// </param>
        /// <param name='handlers'>
        /// Optional. The set of delegating handlers to insert in the http
        /// client pipeline.
        /// </param>
        public RedisManagementClient(Uri baseUri, ServiceClientCredentials credentials, params DelegatingHandler[] handlers)
            : this(handlers)
        {
            if (baseUri == null)
            {
                throw new ArgumentNullException("baseUri");
            }
            if (credentials == null)
            {
                throw new ArgumentNullException("credentials");
            }
            this._baseUri = baseUri;
            this._credentials = credentials;

            if (this.Credentials != null)
            {
                this.Credentials.InitializeServiceClient(this);
            }
        }

        /// <summary>
        /// Initializes client properties.
        /// </summary>
        private void Initialize()
        {
            SerializationSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                ContractResolver = new ReadOnlyJsonContractResolver()
            };
            SerializationSettings.Converters.Add(new ResourceJsonConverter());
            DeserializationSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                ContractResolver = new ReadOnlyJsonContractResolver()
            };
            DeserializationSettings.Converters.Add(new ResourceJsonConverter());
            DeserializationSettings.Converters.Add(new CloudErrorJsonConverter());
        }
    }

    public static partial class RedisOperationsExtensions
    {
        /// <summary>
        /// Create a redis cache, or replace (overwrite/recreate, with
        /// potential downtime) an existing cache
        /// </summary>
        /// <param name='operations'>
        /// Reference to the Microsoft.Azure.Management.Redis.IRedisOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required.
        /// </param>
        /// <param name='name'>
        /// Required.
        /// </param>
        /// <param name='parameters'>
        /// Required.
        /// </param>
        /// <param name='subscriptionId'>
        /// Required.
        /// </param>
        public static RedisResource BeginCreateOrUpdate(this IRedisOperations operations, string resourceGroupName, string name, RedisCreateOrUpdateParameters parameters, string subscriptionId)
        {
            return Task.Factory.StartNew((object s) =>
            {
                return ((IRedisOperations)s).BeginCreateOrUpdateAsync(resourceGroupName, name, parameters, subscriptionId);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Create a redis cache, or replace (overwrite/recreate, with
        /// potential downtime) an existing cache
        /// </summary>
        /// <param name='operations'>
        /// Reference to the Microsoft.Azure.Management.Redis.IRedisOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required.
        /// </param>
        /// <param name='name'>
        /// Required.
        /// </param>
        /// <param name='parameters'>
        /// Required.
        /// </param>
        /// <param name='subscriptionId'>
        /// Required.
        /// </param>
        public static RedisSubResource BeginCreateOrUpdateSubResource(this IRedisOperations operations, string resourceGroupName, string name, RedisCreateOrUpdateParameters parameters, string subscriptionId)
        {
            return Task.Factory.StartNew((object s) =>
            {
                return ((IRedisOperations)s).BeginCreateOrUpdateSubResourceAsync(resourceGroupName, name, parameters, subscriptionId);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Create a redis cache, or replace (overwrite/recreate, with
        /// potential downtime) an existing cache
        /// </summary>
        /// <param name='operations'>
        /// Reference to the Microsoft.Azure.Management.Redis.IRedisOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required.
        /// </param>
        /// <param name='name'>
        /// Required.
        /// </param>
        /// <param name='parameters'>
        /// Required.
        /// </param>
        /// <param name='subscriptionId'>
        /// Required.
        /// </param>
        public static Sku BeginCreateOrUpdateNonResource(this IRedisOperations operations, string resourceGroupName, string name, RedisCreateOrUpdateParameters parameters, string subscriptionId)
        {
            return Task.Factory.StartNew((object s) =>
            {
                return ((IRedisOperations)s).BeginCreateOrUpdateNonResourceAsync(resourceGroupName, name, parameters, subscriptionId);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Create a redis cache, or replace (overwrite/recreate, with
        /// potential downtime) an existing cache
        /// </summary>
        /// <param name='operations'>
        /// Reference to the Microsoft.Azure.Management.Redis.IRedisOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required.
        /// </param>
        /// <param name='name'>
        /// Required.
        /// </param>
        /// <param name='parameters'>
        /// Required.
        /// </param>
        /// <param name='subscriptionId'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public static async Task<Sku> BeginCreateOrUpdateNonResourceAsync(this IRedisOperations operations, string resourceGroupName, string name, RedisCreateOrUpdateParameters parameters, string subscriptionId, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            AzureOperationResponse<Sku> result = await operations.BeginCreateOrUpdateNonResourceWithHttpMessagesAsync(resourceGroupName, name, parameters, subscriptionId, cancellationToken).ConfigureAwait(false);
            return result.Body;
        }

        /// <summary>
        /// Create a redis cache, or replace (overwrite/recreate, with
        /// potential downtime) an existing cache
        /// </summary>
        /// <param name='operations'>
        /// Reference to the Microsoft.Azure.Management.Redis.IRedisOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required.
        /// </param>
        /// <param name='name'>
        /// Required.
        /// </param>
        /// <param name='parameters'>
        /// Required.
        /// </param>
        /// <param name='subscriptionId'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public static async Task<RedisSubResource> BeginCreateOrUpdateSubResourceAsync(this IRedisOperations operations, string resourceGroupName, string name, RedisCreateOrUpdateParameters parameters, string subscriptionId, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            AzureOperationResponse<RedisSubResource> result = await operations.BeginCreateOrUpdateSubResourceWithHttpMessagesAsync(resourceGroupName, name, parameters, subscriptionId, cancellationToken).ConfigureAwait(false);
            return result.Body;
        }

        /// <summary>
        /// Create a redis cache, or replace (overwrite/recreate, with
        /// potential downtime) an existing cache
        /// </summary>
        /// <param name='operations'>
        /// Reference to the Microsoft.Azure.Management.Redis.IRedisOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required.
        /// </param>
        /// <param name='name'>
        /// Required.
        /// </param>
        /// <param name='parameters'>
        /// Required.
        /// </param>
        /// <param name='subscriptionId'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public static async Task<RedisResource> BeginCreateOrUpdateAsync(this IRedisOperations operations, string resourceGroupName, string name, RedisCreateOrUpdateParameters parameters, string subscriptionId, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            AzureOperationResponse<RedisResource> result = await operations.BeginCreateOrUpdateWithHttpMessagesAsync(resourceGroupName, name, parameters, subscriptionId, cancellationToken).ConfigureAwait(false);
            return result.Body;
        }

        /// <summary>
        /// Create a redis cache, or replace (overwrite/recreate, with
        /// potential downtime) an existing cache
        /// </summary>
        /// <param name='operations'>
        /// Reference to the Microsoft.Azure.Management.Redis.IRedisOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required.
        /// </param>
        /// <param name='name'>
        /// Required.
        /// </param>
        /// <param name='parameters'>
        /// Required.
        /// </param>
        /// <param name='subscriptionId'>
        /// Required.
        /// </param>
        public static RedisResource CreateOrUpdate(this IRedisOperations operations, string resourceGroupName, string name, RedisCreateOrUpdateParameters parameters, string subscriptionId)
        {
            return Task.Factory.StartNew((object s) =>
            {
                return ((IRedisOperations)s).CreateOrUpdateAsync(resourceGroupName, name, parameters, subscriptionId);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="operations"></param>
        /// <param name="resoruceGroupName"></param>
        /// <param name="name"></param>
        /// <param name="parameters"></param>
        /// <param name="subscriptionId"></param>
        /// <returns></returns>
        public static RedisResource Patch(this IRedisOperations operations, string resoruceGroupName, string name, RedisCreateOrUpdateParameters parameters, string subscriptionId)
        {
            return Task.Factory.StartNew((object s) =>
            {
                return ((IRedisOperations)s).PatchAsync(resoruceGroupName, name, parameters, subscriptionId);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Create a redis cache, or replace (overwrite/recreate, with
        /// potential downtime) an existing cache
        /// </summary>
        /// <param name='operations'>
        /// Reference to the Microsoft.Azure.Management.Redis.IRedisOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required.
        /// </param>
        /// <param name='name'>
        /// Required.
        /// </param>
        /// <param name='parameters'>
        /// Required.
        /// </param>
        /// <param name='subscriptionId'>
        /// Required.
        /// </param>
        public static Sku CreateOrUpdateNonResource(this IRedisOperations operations, string resourceGroupName, string name, RedisCreateOrUpdateParameters parameters, string subscriptionId)
        {
            return Task.Factory.StartNew((object s) =>
            {
                return ((IRedisOperations)s).CreateOrUpdateNonResourceAsync(resourceGroupName, name, parameters, subscriptionId);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Create a redis cache, or replace (overwrite/recreate, with
        /// potential downtime) an existing cache
        /// </summary>
        /// <param name='operations'>
        /// Reference to the Microsoft.Azure.Management.Redis.IRedisOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required.
        /// </param>
        /// <param name='name'>
        /// Required.
        /// </param>
        /// <param name='parameters'>
        /// Required.
        /// </param>
        /// <param name='subscriptionId'>
        /// Required.
        /// </param>
        public static RedisSubResource CreateOrUpdateSubResource(this IRedisOperations operations, string resourceGroupName, string name, RedisCreateOrUpdateParameters parameters, string subscriptionId)
        {
            return Task.Factory.StartNew((object s) =>
            {
                return ((IRedisOperations)s).CreateOrUpdateSubResourceAsync(resourceGroupName, name, parameters, subscriptionId);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Create a redis cache, or replace (overwrite/recreate, with
        /// potential downtime) an existing cache
        /// </summary>
        /// <param name='operations'>
        /// Reference to the Microsoft.Azure.Management.Redis.IRedisOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required.
        /// </param>
        /// <param name='name'>
        /// Required.
        /// </param>
        /// <param name='parameters'>
        /// Required.
        /// </param>
        /// <param name='subscriptionId'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public static async Task<RedisResource> CreateOrUpdateAsync(this IRedisOperations operations, string resourceGroupName, string name, RedisCreateOrUpdateParameters parameters, string subscriptionId, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            AzureOperationResponse<RedisResource> result = await operations.CreateOrUpdateWithHttpMessagesAsync(resourceGroupName, name, parameters, subscriptionId, cancellationToken).ConfigureAwait(false);
            return result.Body;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="operations"></param>
        /// <param name="resourceGroupName"></param>
        /// <param name="name"></param>
        /// <param name="parameters"></param>
        /// <param name="subscriptionId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public static async Task<RedisResource> PatchAsync(this IRedisOperations operations, string resourceGroupName, string name, RedisCreateOrUpdateParameters parameters, string subscriptionId, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            AzureOperationResponse<RedisResource> result = await operations.PatchWithHttpMessagesAsync(resourceGroupName, name, parameters, subscriptionId, cancellationToken).ConfigureAwait(false);
            return result.Body;
        }

        /// <summary>
        /// Create a redis cache, or replace (overwrite/recreate, with
        /// potential downtime) an existing cache
        /// </summary>
        /// <param name='operations'>
        /// Reference to the Microsoft.Azure.Management.Redis.IRedisOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required.
        /// </param>
        /// <param name='name'>
        /// Required.
        /// </param>
        /// <param name='parameters'>
        /// Required.
        /// </param>
        /// <param name='subscriptionId'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public static async Task<Sku> CreateOrUpdateNonResourceAsync(this IRedisOperations operations, string resourceGroupName, string name, RedisCreateOrUpdateParameters parameters, string subscriptionId, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            AzureOperationResponse<Sku> result = await operations.CreateOrUpdateNonResourceWithHttpMessagesAsync(resourceGroupName, name, parameters, subscriptionId, cancellationToken).ConfigureAwait(false);
            return result.Body;
        }

        /// <summary>
        /// Create a redis cache, or replace (overwrite/recreate, with
        /// potential downtime) an existing cache
        /// </summary>
        /// <param name='operations'>
        /// Reference to the Microsoft.Azure.Management.Redis.IRedisOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required.
        /// </param>
        /// <param name='name'>
        /// Required.
        /// </param>
        /// <param name='parameters'>
        /// Required.
        /// </param>
        /// <param name='subscriptionId'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public static async Task<RedisSubResource> CreateOrUpdateSubResourceAsync(this IRedisOperations operations, string resourceGroupName, string name, RedisCreateOrUpdateParameters parameters, string subscriptionId, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            AzureOperationResponse<RedisSubResource> result = await operations.CreateOrUpdateSubResourceWithHttpMessagesAsync(resourceGroupName, name, parameters, subscriptionId, cancellationToken).ConfigureAwait(false);
            return result.Body;
        }

        /// <summary>
        /// Deletes a redis cache. This operation takes a while to complete.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the Microsoft.Azure.Management.Redis.IRedisOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required.
        /// </param>
        /// <param name='name'>
        /// Required.
        /// </param>
        /// <param name='subscriptionId'>
        /// Required.
        /// </param>
        public static void BeginDelete(this IRedisOperations operations, string resourceGroupName, string name, string subscriptionId)
        {
            Task.Factory.StartNew((object s) =>
            {
                return ((IRedisOperations)s).BeginDeleteAsync(resourceGroupName, name, subscriptionId);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        public static void Delete(this IRedisOperations operations, string resourceGroupName, string name, string subscriptionId)
        {
            Task.Factory.StartNew((object s) =>
            {
                return ((IRedisOperations)s).DeleteAsync(resourceGroupName, name, subscriptionId);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Deletes a redis cache. This operation takes a while to complete.
        /// </summary>
        /// <param name='operations'>
        /// Reference to the Microsoft.Azure.Management.Redis.IRedisOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required.
        /// </param>
        /// <param name='name'>
        /// Required.
        /// </param>
        /// <param name='subscriptionId'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public static async Task BeginDeleteAsync(this IRedisOperations operations, string resourceGroupName, string name, string subscriptionId, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await operations.BeginDeleteWithHttpMessagesAsync(resourceGroupName, name, subscriptionId, cancellationToken).ConfigureAwait(false);
            return;
        }
        public static async Task DeleteAsync(this IRedisOperations operations, string resourceGroupName, string name, string subscriptionId, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            await operations.DeleteWithHttpMessagesAsync(resourceGroupName, name, subscriptionId, cancellationToken).ConfigureAwait(false);
            return;
        }

        public static Sku BeginPost(this IRedisOperations operations, string resourceGroupName, string name, string subscriptionId)
        {
            return Task.Factory.StartNew((object s) =>
            {
                return ((IRedisOperations)s).BeginPostAsync(resourceGroupName, name, subscriptionId);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        public static Sku Post(this IRedisOperations operations, string resourceGroupName, string name, string subscriptionId)
        {
            return Task.Factory.StartNew((object s) =>
            {
                return ((IRedisOperations)s).PostAsync(resourceGroupName, name, subscriptionId);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }
        public static async Task<Sku> BeginPostAsync(this IRedisOperations operations, string resourceGroupName, string name, string subscriptionId, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            AzureOperationResponse<Sku> result = await operations.BeginPostWithHttpMessagesAsync(resourceGroupName, name, subscriptionId, cancellationToken).ConfigureAwait(false);
            return result.Body;
        }
        public static async Task<Sku> PostAsync(this IRedisOperations operations, string resourceGroupName, string name, string subscriptionId, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            AzureOperationResponse<Sku> result = await operations.PostWithHttpMessagesAsync(resourceGroupName, name, subscriptionId, cancellationToken).ConfigureAwait(false);
            return result.Body;
        }


        /// <summary>
        /// Gets a redis cache (resource description).
        /// </summary>
        /// <param name='operations'>
        /// Reference to the Microsoft.Azure.Management.Redis.IRedisOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required.
        /// </param>
        /// <param name='name'>
        /// Required.
        /// </param>
        /// <param name='subscriptionId'>
        /// Required.
        /// </param>
        public static RedisResource Get(this IRedisOperations operations, string resourceGroupName, string name, string subscriptionId)
        {
            return Task.Factory.StartNew((object s) =>
            {
                return ((IRedisOperations)s).GetAsync(resourceGroupName, name, subscriptionId);
            }
            , operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Gets a redis cache (resource description).
        /// </summary>
        /// <param name='operations'>
        /// Reference to the Microsoft.Azure.Management.Redis.IRedisOperations.
        /// </param>
        /// <param name='resourceGroupName'>
        /// Required.
        /// </param>
        /// <param name='name'>
        /// Required.
        /// </param>
        /// <param name='subscriptionId'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public static async Task<RedisResource> GetAsync(this IRedisOperations operations, string resourceGroupName, string name, string subscriptionId, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            AzureOperationResponse<RedisResource> result = await operations.GetWithHttpMessagesAsync(resourceGroupName, name, subscriptionId, cancellationToken).ConfigureAwait(false);
            return result.Body;
        }
    }

    public partial interface IRedisOperations
    {
        /// <summary>
        /// Create a redis cache, or replace (overwrite/recreate, with
        /// potential downtime) an existing cache
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Required.
        /// </param>
        /// <param name='name'>
        /// Required.
        /// </param>
        /// <param name='parameters'>
        /// Required.
        /// </param>
        /// <param name='subscriptionId'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<RedisResource>> BeginCreateOrUpdateWithHttpMessagesAsync(string resourceGroupName, string name, RedisCreateOrUpdateParameters parameters, string subscriptionId, CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        Task<AzureOperationResponse<RedisResource>> CreateOrUpdateWithHttpMessagesAsync(string resourceGroupName, string name, RedisCreateOrUpdateParameters parameters, string subscriptionId, CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        Task<AzureOperationResponse<RedisResource>> PatchWithHttpMessagesAsync(string resourceGroupName, string name, RedisCreateOrUpdateParameters parameters, string subscriptionId,
                                                                                                CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Create a redis cache, or replace (overwrite/recreate, with
        /// potential downtime) an existing cache
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Required.
        /// </param>
        /// <param name='name'>
        /// Required.
        /// </param>
        /// <param name='parameters'>
        /// Required.
        /// </param>
        /// <param name='subscriptionId'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<RedisSubResource>> BeginCreateOrUpdateSubResourceWithHttpMessagesAsync(string resourceGroupName, string name, RedisCreateOrUpdateParameters parameters, string subscriptionId, CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        Task<AzureOperationResponse<RedisSubResource>> CreateOrUpdateSubResourceWithHttpMessagesAsync(string resourceGroupName, string name, RedisCreateOrUpdateParameters parameters, string subscriptionId, CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Create a redis cache, or replace (overwrite/recreate, with
        /// potential downtime) an existing cache
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Required.
        /// </param>
        /// <param name='name'>
        /// Required.
        /// </param>
        /// <param name='parameters'>
        /// Required.
        /// </param>
        /// <param name='subscriptionId'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<Sku>> BeginCreateOrUpdateNonResourceWithHttpMessagesAsync(string resourceGroupName, string name, RedisCreateOrUpdateParameters parameters, string subscriptionId, CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        Task<AzureOperationResponse<Sku>> CreateOrUpdateNonResourceWithHttpMessagesAsync(string resourceGroupName, string name, RedisCreateOrUpdateParameters parameters, string subscriptionId, CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Deletes a redis cache. This operation takes a while to complete.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Required.
        /// </param>
        /// <param name='name'>
        /// Required.
        /// </param>
        /// <param name='subscriptionId'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse> BeginDeleteWithHttpMessagesAsync(string resourceGroupName, string name, string subscriptionId, CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        Task<AzureOperationResponse> DeleteWithHttpMessagesAsync(string resourceGroupName, string name, string subscriptionId, CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Gets a redis cache (resource description).
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Required.
        /// </param>
        /// <param name='name'>
        /// Required.
        /// </param>
        /// <param name='subscriptionId'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        Task<AzureOperationResponse<RedisResource>> GetWithHttpMessagesAsync(string resourceGroupName, string name, string subscriptionId, CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        Task<AzureOperationResponse<Sku>> BeginPostWithHttpMessagesAsync(string resourceGroupName, string name, string subscriptionId, CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        Task<AzureOperationResponse<Sku>> PostWithHttpMessagesAsync(string resourceGroupName, string name, string subscriptionId, CancellationToken cancellationToken = default(System.Threading.CancellationToken));
    }

    internal partial class RedisOperations : IServiceOperations<RedisManagementClient>, IRedisOperations
    {
        /// <summary>
        /// Initializes a new instance of the RedisOperations class.
        /// </summary>
        /// <param name='client'>
        /// Reference to the service client.
        /// </param>
        internal RedisOperations(RedisManagementClient client)
        {
            this._client = client;
        }

        private RedisManagementClient _client;

        /// <summary>
        /// Gets a reference to the
        /// Microsoft.Azure.Management.Redis.RedisManagementClient.
        /// </summary>
        public RedisManagementClient Client
        {
            get { return this._client; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resourceGroupName"></param>
        /// <param name="name"></param>
        /// <param name="parameters"></param>
        /// <param name="subscriptionId"></param>
        /// <param name="httpMethod"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<AzureOperationResponse<RedisResource>> BeginCreateOrUpdateWithHttpMessagesAsync(string resourceGroupName,
                                                                                                    string name, RedisCreateOrUpdateParameters parameters,
                                                                                                    string subscriptionId, HttpMethod httpMethod,
                                                                                                    CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // Validate
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException("resourceGroupName");
            }
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }
            if (parameters == null)
            {
                throw new ArgumentNullException("parameters");
            }
            if (subscriptionId == null)
            {
                throw new ArgumentNullException("subscriptionId");
            }

            // Tracing
            bool shouldTrace = ServiceClientTracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("resourceGroupName", resourceGroupName);
                tracingParameters.Add("name", name);
                tracingParameters.Add("parameters", parameters);
                tracingParameters.Add("subscriptionId", subscriptionId);
                ServiceClientTracing.Enter(invocationId, this, "BeginCreateOrUpdateAsync", tracingParameters);
            }

            // Construct URL
            string url = "";
            url = url + "/subscriptions/";
            url = url + Uri.EscapeDataString(subscriptionId);
            url = url + "/resourceGroups/";
            url = url + Uri.EscapeDataString(resourceGroupName);
            url = url + "/providers/Microsoft.Cache/Redis/";
            url = url + Uri.EscapeDataString(name);
            string baseUrl = this.Client.BaseUri.AbsoluteUri;
            // Trim '/' character from the end of baseUrl and beginning of url.
            if (baseUrl[baseUrl.Length - 1] == '/')
            {
                baseUrl = baseUrl.Substring(0, baseUrl.Length - 1);
            }
            if (url[0] == '/')
            {
                url = url.Substring(1);
            }
            url = baseUrl + "/" + url;
            url = url.Replace(" ", "%20");

            // Create HTTP transport objects
            HttpRequestMessage httpRequest = new HttpRequestMessage();
            httpRequest.Method = httpMethod;
            httpRequest.RequestUri = new Uri(url);

            // Set Headers

            // Set Credentials
            if (this.Client.Credentials != null)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await this.Client.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            }

            // Serialize Request
            string requestContent = JsonConvert.SerializeObject(parameters, this.Client.SerializationSettings);
            httpRequest.Content = new StringContent(requestContent, Encoding.UTF8);
            httpRequest.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

            // Send Request
            if (shouldTrace)
            {
                ServiceClientTracing.SendRequest(invocationId, httpRequest);
            }
            cancellationToken.ThrowIfCancellationRequested();
            HttpResponseMessage httpResponse = await this.Client.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            if (shouldTrace)
            {
                ServiceClientTracing.ReceiveResponse(invocationId, httpResponse);
            }
            HttpStatusCode statusCode = httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
            if (statusCode != HttpStatusCode.OK && statusCode != HttpStatusCode.Created && statusCode != HttpStatusCode.Accepted)
            {
                CloudError error = JsonConvert.DeserializeObject<CloudError>(responseContent, Client.DeserializationSettings);
                CloudException ex = new CloudException();
                if (error != null)
                {
                    ex = new CloudException(error.Message);
                }
                ex.Request = new HttpRequestMessageWrapper(httpRequest, requestContent);
                ex.Response = new HttpResponseMessageWrapper(httpResponse, responseContent);

                if (shouldTrace)
                {
                    ServiceClientTracing.Error(invocationId, ex);
                }
                throw ex;
            }

            // Create Result
            AzureOperationResponse<RedisResource> result = new AzureOperationResponse<RedisResource>();
            result.Request = httpRequest;
            result.Response = httpResponse;

            // Deserialize Response
            if (statusCode == HttpStatusCode.OK || statusCode == HttpStatusCode.Created)
            {
                RedisResource resultModel = JsonConvert.DeserializeObject<RedisResource>(responseContent, this.Client.DeserializationSettings);
                result.Body = resultModel;
            }

            if (shouldTrace)
            {
                ServiceClientTracing.Exit(invocationId, result);
            }
            return result;
        }

        public async Task<AzureOperationResponse<RedisResource>> PatchWithHttpMessagesAsync(string resourceGroupName, string name, RedisCreateOrUpdateParameters parameters, string subscriptionId,
                                                                                                CancellationToken cancellationToken = default(CancellationToken))
        {
            // Send Request
            AzureOperationResponse<RedisResource> response = await BeginCreateOrUpdateWithHttpMessagesAsync(
                resourceGroupName,
                name,
                parameters,
                subscriptionId,
                new HttpMethod("PATCH"),
                cancellationToken);

            Debug.Assert(response.Response.StatusCode == HttpStatusCode.OK ||
                         response.Response.StatusCode == HttpStatusCode.Created ||
                         response.Response.StatusCode == HttpStatusCode.Accepted);

            return await this.Client.GetPutOrPatchOperationResultAsync(response,
                null,
                cancellationToken);
        }
        public async Task<AzureOperationResponse<RedisResource>> CreateOrUpdateWithHttpMessagesAsync(string resourceGroupName, string name,
                                                                                                     RedisCreateOrUpdateParameters parameters, string subscriptionId,
                                                                                                     CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // Send Request
            AzureOperationResponse<RedisResource> response = await BeginCreateOrUpdateWithHttpMessagesAsync(
                resourceGroupName,
                name,
                parameters,
                subscriptionId,
                cancellationToken);

            Debug.Assert(response.Response.StatusCode == HttpStatusCode.OK ||
                         response.Response.StatusCode == HttpStatusCode.Created ||
                         response.Response.StatusCode == HttpStatusCode.Accepted);

            return await this.Client.GetPutOrPatchOperationResultAsync(response,
                null,
                cancellationToken);
        }


        /// <summary>
        /// Create a redis cache, or replace (overwrite/recreate, with
        /// potential downtime) an existing cache
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Required.
        /// </param>
        /// <param name='name'>
        /// Required.
        /// </param>
        /// <param name='parameters'>
        /// Required.
        /// </param>
        /// <param name='subscriptionId'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public async Task<AzureOperationResponse<RedisResource>> BeginCreateOrUpdateWithHttpMessagesAsync(string resourceGroupName,
                                                                                                string name, RedisCreateOrUpdateParameters parameters,
                                                                                                string subscriptionId,
                                                                                                CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            return await BeginCreateOrUpdateWithHttpMessagesAsync(resourceGroupName, name, parameters, subscriptionId, HttpMethod.Put, cancellationToken);
        }

        /// <summary>
        /// Create a redis cache, or replace (overwrite/recreate, with
        /// potential downtime) an existing cache
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Required.
        /// </param>
        /// <param name='name'>
        /// Required.
        /// </param>
        /// <param name='parameters'>
        /// Required.
        /// </param>
        /// <param name='subscriptionId'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public async Task<AzureOperationResponse<Sku>> BeginCreateOrUpdateNonResourceWithHttpMessagesAsync(string resourceGroupName, string name, RedisCreateOrUpdateParameters parameters, string subscriptionId, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // Validate
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException("resourceGroupName");
            }
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }
            if (parameters == null)
            {
                throw new ArgumentNullException("parameters");
            }
            if (subscriptionId == null)
            {
                throw new ArgumentNullException("subscriptionId");
            }

            // Tracing
            bool shouldTrace = ServiceClientTracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("resourceGroupName", resourceGroupName);
                tracingParameters.Add("name", name);
                tracingParameters.Add("parameters", parameters);
                tracingParameters.Add("subscriptionId", subscriptionId);
                ServiceClientTracing.Enter(invocationId, this, "BeginCreateOrUpdateAsync", tracingParameters);
            }

            // Construct URL
            string url = "";
            url = url + "/subscriptions/";
            url = url + Uri.EscapeDataString(subscriptionId);
            url = url + "/resourceGroups/";
            url = url + Uri.EscapeDataString(resourceGroupName);
            url = url + "/providers/Microsoft.Cache/Redis/";
            url = url + Uri.EscapeDataString(name);
            string baseUrl = this.Client.BaseUri.AbsoluteUri;
            // Trim '/' character from the end of baseUrl and beginning of url.
            if (baseUrl[baseUrl.Length - 1] == '/')
            {
                baseUrl = baseUrl.Substring(0, baseUrl.Length - 1);
            }
            if (url[0] == '/')
            {
                url = url.Substring(1);
            }
            url = baseUrl + "/" + url;
            url = url.Replace(" ", "%20");

            // Create HTTP transport objects
            HttpRequestMessage httpRequest = new HttpRequestMessage();
            httpRequest.Method = HttpMethod.Put;
            httpRequest.RequestUri = new Uri(url);

            // Set Headers

            // Set Credentials
            if (this.Client.Credentials != null)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await this.Client.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            }

            // Serialize Request
            string requestContent = JsonConvert.SerializeObject(parameters, this.Client.SerializationSettings);
            httpRequest.Content = new StringContent(requestContent, Encoding.UTF8);
            httpRequest.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

            // Send Request
            if (shouldTrace)
            {
                ServiceClientTracing.SendRequest(invocationId, httpRequest);
            }
            cancellationToken.ThrowIfCancellationRequested();
            HttpResponseMessage httpResponse = await this.Client.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            if (shouldTrace)
            {
                ServiceClientTracing.ReceiveResponse(invocationId, httpResponse);
            }
            HttpStatusCode statusCode = httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
            if (statusCode != HttpStatusCode.OK && statusCode != HttpStatusCode.Created && statusCode != HttpStatusCode.Accepted)
            {
                CloudError error = JsonConvert.DeserializeObject<CloudError>(responseContent, Client.DeserializationSettings);
                CloudException ex = new CloudException();
                if (error != null)
                {
                    ex = new CloudException(error.Message);
                }
                ex.Request = new HttpRequestMessageWrapper(httpRequest, requestContent);
                ex.Response = new HttpResponseMessageWrapper(httpResponse, responseContent);

                if (shouldTrace)
                {
                    ServiceClientTracing.Error(invocationId, ex);
                }
                throw ex;
            }

            // Create Result
            AzureOperationResponse<Sku> result = new AzureOperationResponse<Sku>();
            result.Request = httpRequest;
            result.Response = httpResponse;

            // Deserialize Response
            if (statusCode == HttpStatusCode.OK || statusCode == HttpStatusCode.Created)
            {
                Sku resultModel = JsonConvert.DeserializeObject<Sku>(responseContent, this.Client.DeserializationSettings);
                result.Body = resultModel;
            }

            if (shouldTrace)
            {
                ServiceClientTracing.Exit(invocationId, result);
            }
            return result;
        }

        public async Task<AzureOperationResponse<Sku>> CreateOrUpdateNonResourceWithHttpMessagesAsync(string resourceGroupName, string name, RedisCreateOrUpdateParameters parameters, string subscriptionId, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // Send Request
            AzureOperationResponse<Sku> response = await BeginCreateOrUpdateNonResourceWithHttpMessagesAsync(
                resourceGroupName,
                name,
                parameters,
                subscriptionId,
                cancellationToken);

            Debug.Assert(response.Response.StatusCode == HttpStatusCode.OK ||
                         response.Response.StatusCode == HttpStatusCode.Created ||
                         response.Response.StatusCode == HttpStatusCode.Accepted);

            return await this.Client.GetPutOrPatchOperationResultAsync(response,
                null,
                cancellationToken);
        }

        /// <summary>
        /// Create a redis cache, or replace (overwrite/recreate, with
        /// potential downtime) an existing cache
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Required.
        /// </param>
        /// <param name='name'>
        /// Required.
        /// </param>
        /// <param name='parameters'>
        /// Required.
        /// </param>
        /// <param name='subscriptionId'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public async Task<AzureOperationResponse<RedisSubResource>> BeginCreateOrUpdateSubResourceWithHttpMessagesAsync(string resourceGroupName, string name, RedisCreateOrUpdateParameters parameters, string subscriptionId, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // Validate
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException("resourceGroupName");
            }
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }
            if (parameters == null)
            {
                throw new ArgumentNullException("parameters");
            }
            if (subscriptionId == null)
            {
                throw new ArgumentNullException("subscriptionId");
            }

            // Tracing
            bool shouldTrace = ServiceClientTracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("resourceGroupName", resourceGroupName);
                tracingParameters.Add("name", name);
                tracingParameters.Add("parameters", parameters);
                tracingParameters.Add("subscriptionId", subscriptionId);
                ServiceClientTracing.Enter(invocationId, this, "BeginCreateOrUpdateAsync", tracingParameters);
            }

            // Construct URL
            string url = "";
            url = url + "/subscriptions/";
            url = url + Uri.EscapeDataString(subscriptionId);
            url = url + "/resourceGroups/";
            url = url + Uri.EscapeDataString(resourceGroupName);
            url = url + "/providers/Microsoft.Cache/Redis/";
            url = url + Uri.EscapeDataString(name);
            string baseUrl = this.Client.BaseUri.AbsoluteUri;
            // Trim '/' character from the end of baseUrl and beginning of url.
            if (baseUrl[baseUrl.Length - 1] == '/')
            {
                baseUrl = baseUrl.Substring(0, baseUrl.Length - 1);
            }
            if (url[0] == '/')
            {
                url = url.Substring(1);
            }
            url = baseUrl + "/" + url;
            url = url.Replace(" ", "%20");

            // Create HTTP transport objects
            HttpRequestMessage httpRequest = new HttpRequestMessage();
            httpRequest.Method = HttpMethod.Put;
            httpRequest.RequestUri = new Uri(url);

            // Set Headers

            // Set Credentials
            if (this.Client.Credentials != null)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await this.Client.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            }

            // Serialize Request
            string requestContent = JsonConvert.SerializeObject(parameters, this.Client.SerializationSettings);
            httpRequest.Content = new StringContent(requestContent, Encoding.UTF8);
            httpRequest.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

            // Send Request
            if (shouldTrace)
            {
                ServiceClientTracing.SendRequest(invocationId, httpRequest);
            }
            cancellationToken.ThrowIfCancellationRequested();
            HttpResponseMessage httpResponse = await this.Client.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            if (shouldTrace)
            {
                ServiceClientTracing.ReceiveResponse(invocationId, httpResponse);
            }
            HttpStatusCode statusCode = httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
            if (statusCode != HttpStatusCode.OK && statusCode != HttpStatusCode.Created && statusCode != HttpStatusCode.Accepted)
            {
                CloudError error = JsonConvert.DeserializeObject<CloudError>(responseContent, Client.DeserializationSettings);
                CloudException ex = new CloudException();
                if (error != null)
                {
                    ex = new CloudException(error.Message);
                }
                ex.Request = new HttpRequestMessageWrapper(httpRequest, requestContent);
                ex.Response = new HttpResponseMessageWrapper(httpResponse, responseContent);

                if (shouldTrace)
                {
                    ServiceClientTracing.Error(invocationId, ex);
                }
                throw ex;
            }

            // Create Result
            AzureOperationResponse<RedisSubResource> result = new AzureOperationResponse<RedisSubResource>();
            result.Request = httpRequest;
            result.Response = httpResponse;

            // Deserialize Response
            if (statusCode == HttpStatusCode.OK || statusCode == HttpStatusCode.Created)
            {
                RedisSubResource resultModel = JsonConvert.DeserializeObject<RedisSubResource>(responseContent, this.Client.DeserializationSettings);
                result.Body = resultModel;
            }

            if (shouldTrace)
            {
                ServiceClientTracing.Exit(invocationId, result);
            }
            return result;
        }

        public async Task<AzureOperationResponse<RedisSubResource>> CreateOrUpdateSubResourceWithHttpMessagesAsync(string resourceGroupName, string name, RedisCreateOrUpdateParameters parameters, string subscriptionId, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // Send Request
            AzureOperationResponse<RedisSubResource> response = await BeginCreateOrUpdateSubResourceWithHttpMessagesAsync(
                resourceGroupName,
                name,
                parameters,
                subscriptionId,
                cancellationToken);

            Debug.Assert(response.Response.StatusCode == HttpStatusCode.OK ||
                         response.Response.StatusCode == HttpStatusCode.Created ||
                         response.Response.StatusCode == HttpStatusCode.Accepted);

            return await this.Client.GetPutOrPatchOperationResultAsync(response,
                null,
                cancellationToken);
        }

        /// <summary>
        /// Deletes a redis cache. This operation takes a while to complete.
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Required.
        /// </param>
        /// <param name='name'>
        /// Required.
        /// </param>
        /// <param name='subscriptionId'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public async Task<AzureOperationResponse> BeginDeleteWithHttpMessagesAsync(string resourceGroupName, string name, string subscriptionId, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // Validate
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException("resourceGroupName");
            }
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }
            if (subscriptionId == null)
            {
                throw new ArgumentNullException("subscriptionId");
            }

            // Tracing
            bool shouldTrace = ServiceClientTracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("resourceGroupName", resourceGroupName);
                tracingParameters.Add("name", name);
                tracingParameters.Add("subscriptionId", subscriptionId);
                ServiceClientTracing.Enter(invocationId, this, "BeginDeleteAsync", tracingParameters);
            }

            // Construct URL
            string url = "";
            url = url + "/subscriptions/";
            url = url + Uri.EscapeDataString(subscriptionId);
            url = url + "/resourceGroups/";
            url = url + Uri.EscapeDataString(resourceGroupName);
            url = url + "/providers/Microsoft.Cache/Redis/";
            url = url + Uri.EscapeDataString(name);
            string baseUrl = this.Client.BaseUri.AbsoluteUri;
            // Trim '/' character from the end of baseUrl and beginning of url.
            if (baseUrl[baseUrl.Length - 1] == '/')
            {
                baseUrl = baseUrl.Substring(0, baseUrl.Length - 1);
            }
            if (url[0] == '/')
            {
                url = url.Substring(1);
            }
            url = baseUrl + "/" + url;
            url = url.Replace(" ", "%20");

            // Create HTTP transport objects
            HttpRequestMessage httpRequest = new HttpRequestMessage();
            httpRequest.Method = HttpMethod.Delete;
            httpRequest.RequestUri = new Uri(url);

            // Set Credentials
            if (this.Client.Credentials != null)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await this.Client.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            }

            // Send Request
            if (shouldTrace)
            {
                ServiceClientTracing.SendRequest(invocationId, httpRequest);
            }
            cancellationToken.ThrowIfCancellationRequested();
            HttpResponseMessage httpResponse = await this.Client.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            if (shouldTrace)
            {
                ServiceClientTracing.ReceiveResponse(invocationId, httpResponse);
            }
            HttpStatusCode statusCode = httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
            if (statusCode != HttpStatusCode.OK && statusCode != HttpStatusCode.Accepted && statusCode != HttpStatusCode.Created
                && statusCode != HttpStatusCode.NotFound && statusCode != HttpStatusCode.NoContent)
            {
                CloudError error = JsonConvert.DeserializeObject<CloudError>(responseContent, Client.DeserializationSettings);
                CloudException ex = new CloudException();
                if (error != null)
                {
                    ex = new CloudException(error.Message);
                }
                ex.Request = new HttpRequestMessageWrapper(httpRequest, null);
                ex.Response = new HttpResponseMessageWrapper(httpResponse, responseContent);
                if (shouldTrace)
                {
                    ServiceClientTracing.Error(invocationId, ex);
                }
                throw ex;
            }

            // Create Result
            AzureOperationResponse result = new AzureOperationResponse();
            result.Request = httpRequest;
            result.Response = httpResponse;

            if (shouldTrace)
            {
                ServiceClientTracing.Exit(invocationId, result);
            }
            return result;
        }

        public async Task<AzureOperationResponse> DeleteWithHttpMessagesAsync(
            string resourceGroupName,
            string name,
            string subscriptionId,
            CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // Send Request
            AzureOperationResponse response = await BeginDeleteWithHttpMessagesAsync(
                resourceGroupName,
                name,
                subscriptionId,
                cancellationToken);

            Debug.Assert(response.Response.StatusCode == HttpStatusCode.OK ||
                response.Response.StatusCode == HttpStatusCode.Accepted ||
                response.Response.StatusCode == HttpStatusCode.Created ||
                response.Response.StatusCode == HttpStatusCode.NoContent);

            return await this.Client.GetPostOrDeleteOperationResultAsync(response, null, cancellationToken);
        }

        public async Task<AzureOperationResponse<Sku>> BeginPostWithHttpMessagesAsync(string resourceGroupName, string name, string subscriptionId, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // Validate
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException("resourceGroupName");
            }
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }
            if (subscriptionId == null)
            {
                throw new ArgumentNullException("subscriptionId");
            }

            // Tracing
            bool shouldTrace = ServiceClientTracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("resourceGroupName", resourceGroupName);
                tracingParameters.Add("name", name);
                tracingParameters.Add("subscriptionId", subscriptionId);
                ServiceClientTracing.Enter(invocationId, this, "BeginDeleteAsync", tracingParameters);
            }

            // Construct URL
            string url = "";
            url = url + "/subscriptions/";
            url = url + Uri.EscapeDataString(subscriptionId);
            url = url + "/resourceGroups/";
            url = url + Uri.EscapeDataString(resourceGroupName);
            url = url + "/providers/Microsoft.Cache/Redis/";
            url = url + Uri.EscapeDataString(name);
            string baseUrl = this.Client.BaseUri.AbsoluteUri;
            // Trim '/' character from the end of baseUrl and beginning of url.
            if (baseUrl[baseUrl.Length - 1] == '/')
            {
                baseUrl = baseUrl.Substring(0, baseUrl.Length - 1);
            }
            if (url[0] == '/')
            {
                url = url.Substring(1);
            }
            url = baseUrl + "/" + url;
            url = url.Replace(" ", "%20");

            // Create HTTP transport objects
            HttpRequestMessage httpRequest = new HttpRequestMessage();
            httpRequest.Method = HttpMethod.Post;
            httpRequest.RequestUri = new Uri(url);

            // Set Credentials
            if (this.Client.Credentials != null)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await this.Client.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            }

            // Send Request
            if (shouldTrace)
            {
                ServiceClientTracing.SendRequest(invocationId, httpRequest);
            }
            cancellationToken.ThrowIfCancellationRequested();
            HttpResponseMessage httpResponse = await this.Client.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            if (shouldTrace)
            {
                ServiceClientTracing.ReceiveResponse(invocationId, httpResponse);
            }
            HttpStatusCode statusCode = httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
            if (statusCode != HttpStatusCode.OK && statusCode != HttpStatusCode.Accepted && statusCode != HttpStatusCode.NotFound)
            {
                CloudError error = JsonConvert.DeserializeObject<CloudError>(responseContent, Client.DeserializationSettings);
                CloudException ex = new CloudException();
                if (error != null)
                {
                    ex = new CloudException(error.Message);
                }
                ex.Request = new HttpRequestMessageWrapper(httpRequest, null);
                ex.Response = new HttpResponseMessageWrapper(httpResponse, responseContent);
                if (shouldTrace)
                {
                    ServiceClientTracing.Error(invocationId, ex);
                }
                throw ex;
            }

            // Create Result
            AzureOperationResponse<Sku> result = new AzureOperationResponse<Sku>();
            result.Request = httpRequest;
            result.Response = httpResponse;
            result.Body = JsonConvert.DeserializeObject<Sku>(responseContent, this.Client.DeserializationSettings);

            if (shouldTrace)
            {
                ServiceClientTracing.Exit(invocationId, result);
            }
            return result;
        }

        public async Task<AzureOperationResponse<Sku>> PostWithHttpMessagesAsync(
            string resourceGroupName,
            string name,
            string subscriptionId,
            CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // Send Request
            AzureOperationResponse<Sku> response = await BeginPostWithHttpMessagesAsync(
                resourceGroupName,
                name,
                subscriptionId,
                cancellationToken);

            Debug.Assert(response.Response.StatusCode == HttpStatusCode.OK ||
                response.Response.StatusCode == HttpStatusCode.Accepted ||
                response.Response.StatusCode == HttpStatusCode.Created);

            return await this.Client.GetPostOrDeleteOperationResultAsync<Sku>(response, null, cancellationToken);
        }



        /// <summary>
        /// Gets a redis cache (resource description).
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Required.
        /// </param>
        /// <param name='name'>
        /// Required.
        /// </param>
        /// <param name='subscriptionId'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public async Task<AzureOperationResponse<RedisResource>> GetWithHttpMessagesAsync(string resourceGroupName, string name, string subscriptionId, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // Validate
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException("resourceGroupName");
            }
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }
            if (subscriptionId == null)
            {
                throw new ArgumentNullException("subscriptionId");
            }

            // Tracing
            bool shouldTrace = ServiceClientTracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("resourceGroupName", resourceGroupName);
                tracingParameters.Add("name", name);
                tracingParameters.Add("subscriptionId", subscriptionId);
                ServiceClientTracing.Enter(invocationId, this, "GetLongRunningOperationStatusAsync", tracingParameters);
            }

            // Construct URL
            string url = "";
            url = url + "/subscriptions/";
            url = url + Uri.EscapeDataString(subscriptionId);
            url = url + "/resourceGroups/";
            url = url + Uri.EscapeDataString(resourceGroupName);
            url = url + "/providers/Microsoft.Cache/Redis/";
            url = url + Uri.EscapeDataString(name);
            string baseUrl = this.Client.BaseUri.AbsoluteUri;
            // Trim '/' character from the end of baseUrl and beginning of url.
            if (baseUrl[baseUrl.Length - 1] == '/')
            {
                baseUrl = baseUrl.Substring(0, baseUrl.Length - 1);
            }
            if (url[0] == '/')
            {
                url = url.Substring(1);
            }
            url = baseUrl + "/" + url;
            url = url.Replace(" ", "%20");

            // Create HTTP transport objects
            HttpRequestMessage httpRequest = new HttpRequestMessage();
            httpRequest.Method = HttpMethod.Get;
            httpRequest.RequestUri = new Uri(url);

            // Set Credentials
            if (this.Client.Credentials != null)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await this.Client.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            }

            // Send Request
            if (shouldTrace)
            {
                ServiceClientTracing.SendRequest(invocationId, httpRequest);
            }
            cancellationToken.ThrowIfCancellationRequested();
            HttpResponseMessage httpResponse = await this.Client.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            if (shouldTrace)
            {
                ServiceClientTracing.ReceiveResponse(invocationId, httpResponse);
            }
            HttpStatusCode statusCode = httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
            if (statusCode != HttpStatusCode.OK)
            {
                CloudError error = JsonConvert.DeserializeObject<CloudError>(responseContent, Client.DeserializationSettings);
                CloudException ex = new CloudException();
                if (error != null)
                {
                    ex = new CloudException(error.Message);
                }
                ex.Request = new HttpRequestMessageWrapper(httpRequest, null);
                ex.Response = new HttpResponseMessageWrapper(httpResponse, responseContent);
                if (shouldTrace)
                {
                    ServiceClientTracing.Error(invocationId, ex);
                }
                throw ex;
            }

            // Create Result
            AzureOperationResponse<RedisResource> result = new AzureOperationResponse<RedisResource>();
            result.Request = httpRequest;
            result.Response = httpResponse;

            // Deserialize Response
            if (statusCode == HttpStatusCode.OK)
            {
                RedisResource resultModel = JsonConvert.DeserializeObject<RedisResource>(responseContent, this.Client.DeserializationSettings);
                result.Body = resultModel;
            }

            if (shouldTrace)
            {
                ServiceClientTracing.Exit(invocationId, result);
            }
            return result;
        }

        /// <summary>
        /// Gets a redis cache (resource description).
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Required.
        /// </param>
        /// <param name='name'>
        /// Required.
        /// </param>
        /// <param name='subscriptionId'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public async Task<AzureOperationResponse<Sku>> GetSkuWithHttpMessagesAsync(string resourceGroupName, string name, string subscriptionId, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // Validate
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException("resourceGroupName");
            }
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }
            if (subscriptionId == null)
            {
                throw new ArgumentNullException("subscriptionId");
            }

            // Tracing
            bool shouldTrace = ServiceClientTracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("resourceGroupName", resourceGroupName);
                tracingParameters.Add("name", name);
                tracingParameters.Add("subscriptionId", subscriptionId);
                ServiceClientTracing.Enter(invocationId, this, "GetLongRunningOperationStatusAsync", tracingParameters);
            }

            // Construct URL
            string url = "";
            url = url + "/subscriptions/";
            url = url + Uri.EscapeDataString(subscriptionId);
            url = url + "/resourceGroups/";
            url = url + Uri.EscapeDataString(resourceGroupName);
            url = url + "/providers/Microsoft.Cache/Redis/";
            url = url + Uri.EscapeDataString(name);
            string baseUrl = this.Client.BaseUri.AbsoluteUri;
            // Trim '/' character from the end of baseUrl and beginning of url.
            if (baseUrl[baseUrl.Length - 1] == '/')
            {
                baseUrl = baseUrl.Substring(0, baseUrl.Length - 1);
            }
            if (url[0] == '/')
            {
                url = url.Substring(1);
            }
            url = baseUrl + "/" + url;
            url = url.Replace(" ", "%20");

            // Create HTTP transport objects
            HttpRequestMessage httpRequest = new HttpRequestMessage();
            httpRequest.Method = HttpMethod.Get;
            httpRequest.RequestUri = new Uri(url);

            // Set Credentials
            if (this.Client.Credentials != null)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await this.Client.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            }

            // Send Request
            if (shouldTrace)
            {
                ServiceClientTracing.SendRequest(invocationId, httpRequest);
            }
            cancellationToken.ThrowIfCancellationRequested();
            HttpResponseMessage httpResponse = await this.Client.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            if (shouldTrace)
            {
                ServiceClientTracing.ReceiveResponse(invocationId, httpResponse);
            }
            HttpStatusCode statusCode = httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
            if (statusCode != HttpStatusCode.OK)
            {
                CloudError error = JsonConvert.DeserializeObject<CloudError>(responseContent, Client.DeserializationSettings);
                CloudException ex = new CloudException();
                if (error != null)
                {
                    ex = new CloudException(error.Message);
                }
                ex.Request = new HttpRequestMessageWrapper(httpRequest, null);
                ex.Response = new HttpResponseMessageWrapper(httpResponse, responseContent);
                if (shouldTrace)
                {
                    ServiceClientTracing.Error(invocationId, ex);
                }
                throw ex;
            }

            // Create Result
            AzureOperationResponse<Sku> result = new AzureOperationResponse<Sku>();
            result.Request = httpRequest;
            result.Response = httpResponse;

            // Deserialize Response
            if (statusCode == HttpStatusCode.OK)
            {
                Sku resultModel = JsonConvert.DeserializeObject<Sku>(responseContent, this.Client.DeserializationSettings);
                result.Body = resultModel;
            }

            if (shouldTrace)
            {
                ServiceClientTracing.Exit(invocationId, result);
            }
            return result;
        }

        /// <summary>
        /// Gets a redis cache (resource description).
        /// </summary>
        /// <param name='resourceGroupName'>
        /// Required.
        /// </param>
        /// <param name='name'>
        /// Required.
        /// </param>
        /// <param name='subscriptionId'>
        /// Required.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        public async Task<AzureOperationResponse<RedisSubResource>> GetSubResourceWithHttpMessagesAsync(string resourceGroupName, string name, string subscriptionId, CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // Validate
            if (resourceGroupName == null)
            {
                throw new ArgumentNullException("resourceGroupName");
            }
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }
            if (subscriptionId == null)
            {
                throw new ArgumentNullException("subscriptionId");
            }

            // Tracing
            bool shouldTrace = ServiceClientTracing.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = ServiceClientTracing.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("resourceGroupName", resourceGroupName);
                tracingParameters.Add("name", name);
                tracingParameters.Add("subscriptionId", subscriptionId);
                ServiceClientTracing.Enter(invocationId, this, "GetLongRunningOperationStatusAsync", tracingParameters);
            }

            // Construct URL
            string url = "";
            url = url + "/subscriptions/";
            url = url + Uri.EscapeDataString(subscriptionId);
            url = url + "/resourceGroups/";
            url = url + Uri.EscapeDataString(resourceGroupName);
            url = url + "/providers/Microsoft.Cache/Redis/";
            url = url + Uri.EscapeDataString(name);
            string baseUrl = this.Client.BaseUri.AbsoluteUri;
            // Trim '/' character from the end of baseUrl and beginning of url.
            if (baseUrl[baseUrl.Length - 1] == '/')
            {
                baseUrl = baseUrl.Substring(0, baseUrl.Length - 1);
            }
            if (url[0] == '/')
            {
                url = url.Substring(1);
            }
            url = baseUrl + "/" + url;
            url = url.Replace(" ", "%20");

            // Create HTTP transport objects
            HttpRequestMessage httpRequest = new HttpRequestMessage();
            httpRequest.Method = HttpMethod.Get;
            httpRequest.RequestUri = new Uri(url);

            // Set Credentials
            if (this.Client.Credentials != null)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await this.Client.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            }

            // Send Request
            if (shouldTrace)
            {
                ServiceClientTracing.SendRequest(invocationId, httpRequest);
            }
            cancellationToken.ThrowIfCancellationRequested();
            HttpResponseMessage httpResponse = await this.Client.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
            if (shouldTrace)
            {
                ServiceClientTracing.ReceiveResponse(invocationId, httpResponse);
            }
            HttpStatusCode statusCode = httpResponse.StatusCode;
            cancellationToken.ThrowIfCancellationRequested();
            string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
            if (statusCode != HttpStatusCode.OK)
            {
                CloudError error = JsonConvert.DeserializeObject<CloudError>(responseContent, Client.DeserializationSettings);
                CloudException ex = new CloudException();
                if (error != null)
                {
                    ex = new CloudException(error.Message);
                }
                ex.Request = new HttpRequestMessageWrapper(httpRequest, null);
                ex.Response = new HttpResponseMessageWrapper(httpResponse, responseContent);
                if (shouldTrace)
                {
                    ServiceClientTracing.Error(invocationId, ex);
                }
                throw ex;
            }

            // Create Result
            AzureOperationResponse<RedisSubResource> result = new AzureOperationResponse<RedisSubResource>();
            result.Request = httpRequest;
            result.Response = httpResponse;

            // Deserialize Response
            if (statusCode == HttpStatusCode.OK)
            {
                RedisSubResource resultModel = JsonConvert.DeserializeObject<RedisSubResource>(responseContent, this.Client.DeserializationSettings);
                result.Body = resultModel;
            }

            if (shouldTrace)
            {
                ServiceClientTracing.Exit(invocationId, result);
            }
            return result;
        }
    }
}

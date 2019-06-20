// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace CR.Azure.NetCore.Tests.TestClients.RedisClient
{
    using CR.Azure.NetCore.Tests.Redis;
    using CR.Azure.NetCore.Tests.TestClients.Interface;
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Microsoft.Rest.Serialization;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text;

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


    public static partial class RedisManagementClientExtensions
    {
    }
}

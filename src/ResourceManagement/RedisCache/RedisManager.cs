﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Authentication;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Rest;
using System;
using System.Linq;

namespace Microsoft.Azure.Management.Redis.Fluent
{
    public partial class RedisManager : Manager<IRedisManagementClient>, IRedisManager
    {
        private IRedisCaches redisCaches;

        private RedisManager(RestClient restClient, string subscriptionId)
            : base(restClient, subscriptionId, new RedisManagementClient(new Uri(restClient.BaseUri),
                restClient.Credentials,
                restClient.RootHttpHandler,
                restClient.Handlers.ToArray())
            {
                SubscriptionId = subscriptionId
            }
    )
        {
        }

        #region StorageManager builder
        public static IRedisManager Authenticate(AzureCredentials credentials, string subscriptionId)
        {
            return new RedisManager(RestClient.Configure()
                    .WithEnvironment(credentials.Environment)
                    .WithCredentials(credentials)
                    .WithDelegatingHandler(new ProviderRegistrationDelegatingHandler(credentials))
                    .Build(), subscriptionId);
        }
        
        public static IRedisManager Authenticate(RestClient restClient, String subscriptionId)
        {
            return new RedisManager(restClient, subscriptionId);
        }

        /// <summary>
        /// Returns a Configurable instance that can be used to create RedisManager with optional configuration.
        /// </summary>
        /// <returns>The instance allowing configurations</returns>
        public static IConfigurable Configure()
        {
            return new Configurable();
        }

        #endregion

        #region IConfigurable and it's implementation

        public interface IConfigurable : IAzureConfigurable<IConfigurable>
        {
            IRedisManager Authenticate(AzureCredentials credentials, string subscriptionId);
        }

        protected class Configurable :
            AzureConfigurable<IConfigurable>,
            IConfigurable
        {
            public IRedisManager Authenticate(AzureCredentials credentials, string subscriptionId)
            {
                return new RedisManager(BuildRestClient(credentials), subscriptionId);
            }
        }

        #endregion IConfigurable and it's implementation

        #region IRedisManager implementation 
        public IRedisCaches RedisCaches
        {
            get
            {
                if (redisCaches == null)
                {
                    redisCaches = new RedisCachesImpl(this);
                }
                return redisCaches;
            }
        }
        #endregion
    }

    /// <summary>
    /// Entry point to Azure Redis Cache management.
    /// </summary>
    public interface IRedisManager : IManager<IRedisManagementClient>
    {
        /// <summary>
        /// Gets the Redis Cache management API entry point.
        /// </summary>
        IRedisCaches RedisCaches { get; }
    }
}

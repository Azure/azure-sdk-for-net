﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using System;
using System.Linq;
using Microsoft.Azure.Management.ResourceManager.Fluent.Authentication;

namespace Microsoft.Azure.Management.Storage.Fluent
{
    public class StorageManager : Manager<IStorageManagementClient>, IStorageManager
    {
        #region ctrs

        private StorageManager(RestClient restClient, string subscriptionId) :
            base(restClient, subscriptionId, new StorageManagementClient(new Uri(restClient.BaseUri),
                restClient.Credentials,
                restClient.RootHttpHandler,
                restClient.Handlers.ToArray())
            {
                SubscriptionId = subscriptionId
            })
        {
        }

        #endregion

        #region StorageManager builder

        /// <summary>
        /// Creates an instance of StorageManager that exposes storage resource management API entry points.
        /// </summary>
        /// <param name="credentials">the credentials to use</param>
        /// <param name="subscriptionId">the subscription UUID</param>
        /// <returns>the StorageManager</returns>
        public static IStorageManager Authenticate(AzureCredentials credentials, string subscriptionId)
        {
            return Authenticate(RestClient.Configure()
                    .WithEnvironment(credentials.Environment)
                    .WithCredentials(credentials)
                    .WithDelegatingHandler(new ProviderRegistrationDelegatingHandler(credentials))
                    .Build(), subscriptionId);
        }

        /// <summary>
        /// Creates an instance of StorageManager that exposes storage resource management API entry points.
        /// </summary>
        /// <param name="restClient">the RestClient to be used for API calls.</param>
        /// <param name="subscriptionId">the subscription UUID</param>
        /// <returns>the StorageManager</returns>
        public static IStorageManager Authenticate(RestClient restClient, string subscriptionId)
        {
            return new StorageManager(restClient, subscriptionId);
        }

        /// <summary>
        /// Get a Configurable instance that can be used to create StorageManager with optional configuration.
        /// </summary>
        /// <returns>the instance allowing configurations</returns>
        public static IConfigurable Configure()
        {
            return new Configurable();
        }

        #endregion


        #region IConfigurable and it's implementation

        /// <summary>
        /// The inteface allowing configurations to be set.
        /// </summary>
        public interface IConfigurable : IAzureConfigurable<IConfigurable>
        {
            IStorageManager Authenticate(AzureCredentials credentials, string subscriptionId);
        }

        protected class Configurable :
            AzureConfigurable<IConfigurable>,
            IConfigurable
        {
            /// <summary>
            /// Creates an instance of StorageManager that exposes storage management API entry points.
            /// </summary>
            /// <param name="credentials">credentials the credentials to use</param>
            /// <param name="subscriptionId">The subscription UUID</param>
            /// <return>the interface exposing storage management API entry points that work in a subscription</returns>
            public IStorageManager Authenticate(AzureCredentials credentials, string subscriptionId)
            {
                return new StorageManager(BuildRestClient(credentials), subscriptionId);
            }
        }

        #endregion

        #region IStorageManager implementation 

        private IStorageAccounts storageAccounts;
        private IUsages usages;

        public IStorageAccounts StorageAccounts
        {
            get
            {
                if (storageAccounts == null)
                {
                    storageAccounts = new StorageAccountsImpl(this);
                }
                return storageAccounts;
            }
        }

        public IUsages Usages {
            get
            {
                if (usages == null)
                {
                    usages = new UsagesImpl(Inner.Usage);
                }
                return usages;
            }
        }

        #endregion
    }

    /// <summary>
    /// Entry point to Azure storage resource management.
    /// </summary>
    public interface IStorageManager : IManager<IStorageManagementClient>
    {
        /// <summary>
        /// Gets the storage resource management API entry point.
        /// </summary>
        IStorageAccounts StorageAccounts { get; }

        /// <summary>
        /// Gets the storage resource usage management API entry point.
        /// </summary>
        IUsages Usages { get; }
    }
}

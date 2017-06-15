// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Fluent.Authentication;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Storage.Fluent;
using System;
using System.Linq;

namespace Microsoft.Azure.Management.Batch.Fluent
{
    public class BatchManager : Manager<IBatchManagementClient>, IBatchManager
    {
        private IStorageManager storageManager;
        private IBatchAccounts batchAccounts;

        public BatchManager(RestClient restClient, string subscriptionId) :
            base(restClient, subscriptionId, new BatchManagementClient(new Uri(restClient.BaseUri),
                restClient.Credentials,
                restClient.RootHttpHandler,
                restClient.Handlers.ToArray())
            {
                SubscriptionId = subscriptionId
            })
        {
            storageManager = StorageManager.Authenticate(restClient, subscriptionId);
        }

        #region BatchManager builder

        public static IBatchManager Authenticate(AzureCredentials credentials, string subscriptionId)
        {
            return new BatchManager(RestClient.Configure()
                    .WithEnvironment(credentials.Environment)
                    .WithCredentials(credentials)
                    .WithDelegatingHandler(new ProviderRegistrationDelegatingHandler(credentials))
                    .Build(), subscriptionId);
        }

        /// <summary>
        /// Creates an instance of BatchManager that exposes Batch resource management API entry points.
        /// </summary>
        /// <param name="restClient">the RestClient to be used for API calls</param>
        /// <param name="subscriptionId">the subscription</param>
        /// <return>the BatchManager</return>
        ///
        public static IBatchManager Authenticate(RestClient restClient, String subscriptionId)
        {
            return new BatchManager(restClient, subscriptionId);
        }

        public static IConfigurable Configure()
        {
            return new Configurable();
        }

        #endregion BatchManager builder

        #region IConfigurable and it's implementation

        public interface IConfigurable : IAzureConfigurable<IConfigurable>
        {
            IBatchManager Authenticate(AzureCredentials credentials, string subscriptionId);
        }

        protected class Configurable :
            AzureConfigurable<IConfigurable>,
            IConfigurable
        {
            public IBatchManager Authenticate(AzureCredentials credentials, string subscriptionId)
            {
                return new BatchManager(BuildRestClient(credentials), subscriptionId);
            }
        }

        #endregion IConfigurable and it's implementation

        #region IBatchManager implementation

        public IBatchAccounts BatchAccounts
        {
            get
            {
                if (batchAccounts == null)
                {
                    batchAccounts = new BatchAccountsImpl(this, storageManager);
                }

                return batchAccounts;
            }
        }

        #endregion IBatchManager implementation
    }

    public interface IBatchManager : IManager<IBatchManagementClient>
    {
        IBatchAccounts BatchAccounts { get; }
    }
}
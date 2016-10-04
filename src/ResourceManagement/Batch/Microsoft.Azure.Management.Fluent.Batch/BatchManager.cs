// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Batch;
using Microsoft.Azure.Management.Fluent.Resource.Authentication;
using Microsoft.Azure.Management.Fluent.Resource.Core;
using Microsoft.Azure.Management.Fluent.Storage;
using Microsoft.Rest;
using System;
using System.Linq;

namespace Microsoft.Azure.Management.Fluent.Batch
{
    public class BatchManager : ManagerBase, IBatchManager
    {
        private IStorageManager storageManager;
        private IBatchAccounts batchAccounts;

        #region SDK clients

        private BatchManagementClient client;

        #endregion SDK clients

        public BatchManager(RestClient restClient, string subscriptionId) : base(restClient, subscriptionId)
        {
            client = new BatchManagementClient(new Uri(restClient.BaseUri),
                restClient.Credentials,
                restClient.RootHttpHandler,
                restClient.Handlers.ToArray());
            client.SubscriptionId = subscriptionId;
            storageManager = StorageManager.Authenticate(restClient, subscriptionId);
        }

        #region BatchManager builder

        public static IBatchManager Authenticate(AzureCredentials credentials, string subscriptionId)
        {
            return new BatchManager(RestClient.Configure()
                    .withEnvironment(credentials.Environment)
                    .withCredentials(credentials)
                    .build(), subscriptionId);
        }

        /**
         * Creates an instance of BatchManager that exposes Batch resource management API entry points.
         *
         * @param restClient the RestClient to be used for API calls.
         * @param subscriptionId the subscription
         * @return the BatchManager
         */

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
                    batchAccounts = new BatchAccountsImpl(
                        client.BatchAccount,
                        this,
                        client.Application,
                        client.ApplicationPackage,
                        client.Location,
                        storageManager);
                }

                return batchAccounts;
            }
        }

        #endregion IBatchManager implementation
    }

    public interface IBatchManager : IManagerBase
    {
        IBatchAccounts BatchAccounts { get; }
    }
}
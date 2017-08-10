// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Fluent.Authentication;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using System;
using System.Linq;

namespace Microsoft.Azure.Management.CosmosDB.Fluent
{         
    public class CosmosDBManager : Manager<IDocumentDB>, ICosmosDBManager
    {
        #region Fluent private collections
        private ICosmosDBAccounts databaseAccounts;
        #endregion

        public CosmosDBManager(RestClient restClient, string subscriptionId) :
            base(restClient, subscriptionId, new DocumentDB(
                new Uri(restClient.BaseUri),
                    restClient.Credentials,
                    restClient.RootHttpHandler,
                    restClient.Handlers.ToArray())
            {
                SubscriptionId = subscriptionId
            })
        {
        }
        
        public static ICosmosDBManager Authenticate(AzureCredentials credentials, string subscriptionId)
        {
            return new CosmosDBManager(RestClient.Configure()
                    .WithEnvironment(credentials.Environment)
                    .WithCredentials(credentials)
                    .WithDelegatingHandler(new ProviderRegistrationDelegatingHandler(credentials))
                    .Build(), subscriptionId);
        }

        public static ICosmosDBManager Authenticate(RestClient restClient, string subscriptionId)
        {
            return new CosmosDBManager(restClient, subscriptionId);
        }

        public static IConfigurable Configure()
        {
            return new Configurable();
        }
        

        #region IConfigurable and it's implementation

        public interface IConfigurable : IAzureConfigurable<IConfigurable>
        {
            ICosmosDBManager Authenticate(AzureCredentials credentials, string subscriptionId);
        }

        protected class Configurable :
            AzureConfigurable<IConfigurable>,
            IConfigurable
        {
            public ICosmosDBManager Authenticate(AzureCredentials credentials, string subscriptionId)
            {
                return new CosmosDBManager(BuildRestClient(credentials), subscriptionId);
            }
        }

        #endregion

        public ICosmosDBAccounts CosmosDBAccounts
        {
            get
            {
                if (databaseAccounts == null)
                {
                    databaseAccounts = new CosmosDBAccountsImpl(this);
                }

                return databaseAccounts;
            }
        }
    }

    public interface ICosmosDBManager : IManager<IDocumentDB>
    {
       ICosmosDBAccounts CosmosDBAccounts { get; }
    }
}

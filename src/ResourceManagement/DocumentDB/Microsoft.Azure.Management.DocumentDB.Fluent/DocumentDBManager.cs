// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Fluent.Authentication;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using System;
using System.Linq;

namespace Microsoft.Azure.Management.DocumentDB.Fluent
{         
    public class DocumentDBManager : Manager<IDocumentDB>, IDocumentDBManager
    {
        #region Fluent private collections
        private IDatabaseAccounts databaseAccounts;
        #endregion

        public DocumentDBManager(RestClient restClient, string subscriptionId) :
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
        
        public static IDocumentDBManager Authenticate(AzureCredentials credentials, string subscriptionId)
        {
            return new DocumentDBManager(RestClient.Configure()
                    .WithEnvironment(credentials.Environment)
                    .WithCredentials(credentials)
                    .Build(), subscriptionId);
        }

        public static IDocumentDBManager Authenticate(RestClient restClient, string subscriptionId)
        {
            return new DocumentDBManager(restClient, subscriptionId);
        }

        public static IConfigurable Configure()
        {
            return new Configurable();
        }
        

        #region IConfigurable and it's implementation

        public interface IConfigurable : IAzureConfigurable<IConfigurable>
        {
            IDocumentDBManager Authenticate(AzureCredentials credentials, string subscriptionId);
        }

        protected class Configurable :
            AzureConfigurable<IConfigurable>,
            IConfigurable
        {
            public IDocumentDBManager Authenticate(AzureCredentials credentials, string subscriptionId)
            {
                return new DocumentDBManager(BuildRestClient(credentials), subscriptionId);
            }
        }

        #endregion

        public IDatabaseAccounts DocumentDBAccounts
        {
            get
            {
                if (databaseAccounts == null)
                {
                    databaseAccounts = new DatabaseAccountsImpl(this);
                }

                return databaseAccounts;
            }
        }
    }

    public interface IDocumentDBManager : IManager<IDocumentDB>
    {
       IDatabaseAccounts DocumentDBAccounts { get; }
    }
}

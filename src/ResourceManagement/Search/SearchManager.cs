// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Fluent.Authentication;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using System;
using System.Linq;

namespace Microsoft.Azure.Management.Search.Fluent
{
    public class SearchManager : Manager<ISearchManagementClient>, ISearchManager
    {
        #region Fluent private collections
        private ISearchServices searchServices;
        #endregion

        public SearchManager(RestClient restClient, string subscriptionId) :
            base(restClient, subscriptionId, new SearchManagementClient(
                new Uri(restClient.BaseUri),
                    restClient.Credentials,
                    restClient.RootHttpHandler,
                    restClient.Handlers.ToArray())
            {
                SubscriptionId = subscriptionId
            })
        {
        }

        public static ISearchManager Authenticate(AzureCredentials credentials, string subscriptionId)
        {
            return new SearchManager(RestClient.Configure()
                    .WithEnvironment(credentials.Environment)
                    .WithCredentials(credentials)
                    .WithDelegatingHandler(new ProviderRegistrationDelegatingHandler(credentials))
                    .Build(), subscriptionId);
        }

        public static ISearchManager Authenticate(RestClient restClient, string subscriptionId)
        {
            return new SearchManager(restClient, subscriptionId);
        }

        public static IConfigurable Configure()
        {
            return new Configurable();
        }


        #region IConfigurable and it's implementation

        public interface IConfigurable : IAzureConfigurable<IConfigurable>
        {
            ISearchManager Authenticate(AzureCredentials credentials, string subscriptionId);
        }

        protected class Configurable :
            AzureConfigurable<IConfigurable>,
            IConfigurable
        {
            public ISearchManager Authenticate(AzureCredentials credentials, string subscriptionId)
            {
                return new SearchManager(BuildRestClient(credentials), subscriptionId);
            }
        }

        #endregion

        public ISearchServices SearchServices
        {
            get
            {
                if (searchServices == null)
                {
                    searchServices = new SearchServicesImpl(this);
                }

                return searchServices;
            }
        }
    }

    public interface ISearchManager : IManager<ISearchManagementClient>
    {
        ISearchServices SearchServices { get; }
    }
}

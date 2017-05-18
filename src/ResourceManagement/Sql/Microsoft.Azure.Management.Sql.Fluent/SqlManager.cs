// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Fluent.Authentication;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using System;
using System.Linq;

namespace Microsoft.Azure.Management.Sql.Fluent
{
    public class SqlManager : Manager<ISqlManagementClient>, ISqlManager
    {
        private ISqlServers sqlServers;

        public SqlManager(RestClient restClient, string subscriptionId) :
            base(restClient, subscriptionId, new SqlManagementClient(new Uri(restClient.BaseUri),
                restClient.Credentials,
                restClient.RootHttpHandler,
                restClient.Handlers.ToArray())
            {
                SubscriptionId = subscriptionId
            })
        {
        }

        #region SqlManager builder


        public static ISqlManager Authenticate(AzureCredentials credentials, string subscriptionId)
        {
            return new SqlManager(RestClient.Configure()
                    .WithEnvironment(credentials.Environment)
                    .WithCredentials(credentials)
                    .WithDelegatingHandler(new ProviderRegistrationDelegatingHandler(credentials))
                    .Build(), subscriptionId);
        }

        /// <summary>
        /// Creates an instance of SqlManager that exposes Sql management API entry points.
        /// </summary>
        /// <param name="restClient"> the RestClient to be used for API calls</param>
        /// <param name="subscriptionId"> the subscription</param>
        /// <return>The SqlManager</return>
        public static ISqlManager Authenticate(RestClient restClient, string subscriptionId)
        {
            return new SqlManager(restClient, subscriptionId);
        }

        public static IConfigurable Configure()
        {
            return new Configurable();
        }

        #endregion SqlManager builder

        #region IConfigurable and it's implementation

        public interface IConfigurable : IAzureConfigurable<IConfigurable>
        {
            ISqlManager Authenticate(AzureCredentials credentials, string subscriptionId);
        }

        protected class Configurable :
            AzureConfigurable<IConfigurable>,
            IConfigurable
        {
            public ISqlManager Authenticate(AzureCredentials credentials, string subscriptionId)
            {
                return new SqlManager(BuildRestClient(credentials), subscriptionId);
            }
        }

        #endregion IConfigurable and it's implementation

        public ISqlServers SqlServers
        {
            get
            {
                if (sqlServers == null)
                {
                    sqlServers = new SqlServersImpl(this);
                }

                return sqlServers;
            }
        }
    }

    public interface ISqlManager : IManager<ISqlManagementClient>
    {
        ISqlServers SqlServers { get; }
    }
}
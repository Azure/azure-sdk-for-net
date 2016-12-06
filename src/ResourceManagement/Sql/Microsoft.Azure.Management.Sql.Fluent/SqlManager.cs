// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Resource.Fluent.Authentication;
using Microsoft.Azure.Management.Resource.Fluent.Core;
using System;
using System.Linq;

namespace Microsoft.Azure.Management.Sql.Fluent
{
    public class SqlManager : ManagerBase, ISqlManager
    {
        private ISqlServers sqlServers;

        #region SDK clients

        private SqlManagementClient client;

        #endregion SDK clients

        public SqlManager(RestClient restClient, string subscriptionId) : base(restClient, subscriptionId)
        {
            client = new SqlManagementClient(new Uri(restClient.BaseUri),
                restClient.Credentials,
                restClient.RootHttpHandler,
                restClient.Handlers.ToArray());
            client.SubscriptionId = subscriptionId;
        }

        #region SqlManager builder


        public static ISqlManager Authenticate(AzureCredentials credentials, string subscriptionId)
        {
            return new SqlManager(RestClient.Configure()
                    .WithEnvironment(credentials.Environment)
                    .WithCredentials(credentials)
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
                    sqlServers = new SqlServersImpl(
                            client.Servers,
                            client.ElasticPools,
                            client.Databases,
                            client.RecommendedElasticPools,
                            this);
                }

                return sqlServers;
            }
        }
    }

    public interface ISqlManager : IManagerBase
    {
        ISqlServers SqlServers { get; }
    }
}
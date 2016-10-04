// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Management.Fluent.Resource.Core;
using Microsoft.Rest.Azure;
using Microsoft.Rest;
using Microsoft.Azure.Management.Fluent.Resource;
using Microsoft.Azure.Management.Graph.RBAC;
using Microsoft.Azure.Management.Fluent.Resource.Authentication;

namespace Microsoft.Azure.Management.Fluent.Graph.RBAC
{
    public class GraphRbacManager : ManagerBase, IGraphRbacManager
    {
        #region SDK clients
        private GraphRbacManagementClient client;
        #endregion

        #region Fluent private collections
        private IUsers users;
        private IServicePrincipals servicePrincipals;
        #endregion

        #region ctrs

        public GraphRbacManager(RestClient restClient, string subscriptionId, string tenantId) : base(restClient, subscriptionId)
        {
            client = new GraphRbacManagementClient(new Uri(restClient.BaseUri),
                restClient.Credentials,
                restClient.RootHttpHandler,
                restClient.Handlers.ToArray());
            client.TenantID = tenantId;
        }

        #endregion

        #region Graph RBAC Manager builder

        public static IGraphRbacManager Authenticate(AzureCredentials credentials, string subscriptionId, string tenantId)
        {
            return new GraphRbacManager(RestClient.Configure()
                    .WithBaseUri(credentials.Environment.GraphEndpoint)
                    .WithCredentials(credentials)
                    .Build(), subscriptionId, tenantId);
        }

        public static IGraphRbacManager Authenticate(RestClient restClient, string subscriptionId, string tenantId)
        {
            return new GraphRbacManager(restClient, subscriptionId, tenantId);
        }

        public static IConfigurable Configure()
        {
            return new Configurable();
        }

        #endregion


        #region IConfigurable and it's implementation

        public interface IConfigurable : IAzureConfigurable<IConfigurable>
        {
            IGraphRbacManager Authenticate(AzureCredentials credentials, string subscriptionId, string tenantId);
        }

        protected class Configurable :
            AzureConfigurable<IConfigurable>,
            IConfigurable
        {
            public IGraphRbacManager Authenticate(AzureCredentials credentials, string subscriptionId, string tenantId)
            {
                return new GraphRbacManager(BuildRestClientForGraph(credentials), subscriptionId, tenantId);
            }
        }

        #endregion

        #region IGraphRbacManager implementation 

        public IUsers Users
        {
            get
            {
                if (users == null)
                {
                    users = new UsersImpl(
                        client.Users,
                        this);
                }

                return users;
            }
        }

        public IServicePrincipals ServicePrincipals
        {
            get
            {
                if (servicePrincipals == null)
                {
                    servicePrincipals = new ServicePrincipalsImpl(client.ServicePrincipals, this);
                }
                return servicePrincipals;
            }
        }
        #endregion
    }

    public interface IGraphRbacManager : IManagerBase
    {
        IUsers Users { get; }
        IServicePrincipals ServicePrincipals { get; }
    }
}

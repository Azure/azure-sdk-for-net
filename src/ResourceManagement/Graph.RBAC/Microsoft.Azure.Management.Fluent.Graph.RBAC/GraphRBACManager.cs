﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Management.V2.Resource.Core;
using Microsoft.Rest.Azure;
using Microsoft.Rest;
using Microsoft.Azure.Management.V2.Resource;
using Microsoft.Azure.Management.Graph.RBAC;

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
            client = new GraphRbacManagementClient(
                restClient.Credentials,
                restClient.RootHttpHandler,
                restClient.Handlers.ToArray());
            client.TenantID = tenantId;
        }

        #endregion

        #region Graph RBAC Manager builder

        public static IGraphRbacManager Authenticate(ServiceClientCredentials graphCredentials, string subscriptionId, string tenantId)
        {
            return new GraphRbacManager(RestClient.Configure()
                    .withEnvironment(AzureEnvironment.AzureGlobalCloud)
                    .withCredentials(graphCredentials)
                    .build(), subscriptionId, tenantId);
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
            IGraphRbacManager Authenticate(ServiceClientCredentials graphCredentials, string subscriptionId, string tenantId);
        }

        protected class Configurable :
            AzureConfigurable<IConfigurable>,
            IConfigurable
        {
            public IGraphRbacManager Authenticate(ServiceClientCredentials credentials, string subscriptionId, string tenantId)
            {
                return new GraphRbacManager(BuildRestClient(credentials), subscriptionId, tenantId);
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

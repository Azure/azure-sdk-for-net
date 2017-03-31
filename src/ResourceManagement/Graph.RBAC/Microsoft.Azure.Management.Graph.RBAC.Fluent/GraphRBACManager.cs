// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.ResourceManager.Fluent.Authentication;

namespace Microsoft.Azure.Management.Graph.RBAC.Fluent
{
    /// <summary>
    /// Entry point to Azure Graoh RBAC management.
    /// </summary>
    /// <remarks>
    /// (Beta: This functionality is in preview and as such is subject to change in non-backwards compatible ways in future releases, including removal, regardless of any compatibility expectations set by the containing library version number.)
    /// </remarks>
    public class GraphRbacManager : Manager<IGraphRbacManagementClient>, IGraphRbacManager
    {
        #region Fluent private collections
        private IUsers users;
        private IServicePrincipals servicePrincipals;
        #endregion

        #region ctrs

        public GraphRbacManager(RestClient restClient, string subscriptionId, string tenantId) :
            base(restClient, subscriptionId, new GraphRbacManagementClient(new Uri(restClient.BaseUri),
                restClient.Credentials,
                restClient.RootHttpHandler,
                restClient.Handlers.ToArray())
            {
                TenantID = tenantId
            })
        {
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
                        Inner.Users,
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
                    servicePrincipals = new ServicePrincipalsImpl(Inner.ServicePrincipals, this);
                }
                return servicePrincipals;
            }
        }
        #endregion
    }

    public interface IGraphRbacManager : IManager<IGraphRbacManagementClient>
    {
        IUsers Users { get; }
        IServicePrincipals ServicePrincipals { get; }
    }
}

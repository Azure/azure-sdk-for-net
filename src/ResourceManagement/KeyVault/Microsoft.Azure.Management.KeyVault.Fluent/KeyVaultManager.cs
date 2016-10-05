// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Management.Resource.Fluent.Core;
using Microsoft.Rest.Azure;
using Microsoft.Rest;
using Microsoft.Azure.Management.Resource.Fluent;
using Microsoft.Azure.Management.Graph.RBAC.Fluent;
using Microsoft.Azure.Management.KeyVault.Fluent;
using Microsoft.Azure.Management.Graph.RBAC.Fluent;
using Microsoft.Azure.Management.Resource.Fluent.Authentication;

namespace Microsoft.Azure.Management.KeyVault.Fluent
{
    public class KeyVaultManager : ManagerBase, IKeyVaultManager
    {
        private IGraphRbacManager graphRbacManager;
        private string tenantId;

        #region SDK clients
        private KeyVaultManagementClient client;
        #endregion

        #region Fluent private collections
        private IVaults vaults;
        #endregion

        #region ctrs

        public KeyVaultManager(RestClient restClient, string subscriptionId, string tenantId) : base(restClient, subscriptionId)
        {
            client = new KeyVaultManagementClient(new Uri(restClient.BaseUri),
                restClient.Credentials,
                restClient.RootHttpHandler,
                restClient.Handlers.ToArray());
            client.SubscriptionId = subscriptionId;
            string graphEndpoint = AzureEnvironment.AzureGlobalCloud.GraphEndpoint;
            if (restClient.Credentials is AzureCredentials)
            {
                graphEndpoint = ((AzureCredentials)restClient.Credentials).Environment.GraphEndpoint;
            }
            graphRbacManager = GraphRbacManager.Authenticate(RestClient.Configure()
                .WithBaseUri(graphEndpoint)
                .WithCredentials(restClient.Credentials)
                .Build(), subscriptionId, tenantId);
            this.tenantId = tenantId;
        }

        #endregion

        #region Key Vault Manager builder

        public static IKeyVaultManager Authenticate(AzureCredentials credentials, string subscriptionId)
        {
            return new KeyVaultManager(RestClient.Configure()
                    .WithEnvironment(credentials.Environment)
                    .WithCredentials(credentials)
                    .Build(), subscriptionId, credentials.TenantId);
        }

        public static IKeyVaultManager Authenticate(RestClient restClient, string subscriptionId, string tenantId)
        {
            return new KeyVaultManager(restClient, subscriptionId, tenantId);
        }

        public static IConfigurable Configure()
        {
            return new Configurable();
        }

        #endregion


        #region IConfigurable and it's implementation

        public interface IConfigurable : IAzureConfigurable<IConfigurable>
        {
            IKeyVaultManager Authenticate(AzureCredentials credentials, string subscriptionId);
        }

        protected class Configurable :
            AzureConfigurable<IConfigurable>,
            IConfigurable
        {
            public IKeyVaultManager Authenticate(AzureCredentials credentials, string subscriptionId)
            {
                return new KeyVaultManager(BuildRestClient(credentials), subscriptionId, credentials.TenantId);
            }
        }

        #endregion

        #region IKeyVaultManager implementation 

        public IVaults Vaults
        {
            get
            {
                if (vaults == null)
                {
                    vaults = new VaultsImpl(
                        client.Vaults,
                        this,
                        graphRbacManager,
                        tenantId);
                }

                return vaults;
            }
        }
        
        #endregion
    }

    public interface IKeyVaultManager : IManagerBase
    {
        IVaults Vaults { get; }
    }
}

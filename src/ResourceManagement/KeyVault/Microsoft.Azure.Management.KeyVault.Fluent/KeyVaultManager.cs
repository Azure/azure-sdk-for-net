// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.Graph.RBAC.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Authentication;

namespace Microsoft.Azure.Management.KeyVault.Fluent
{
    public class KeyVaultManager : Manager<IKeyVaultManagementClient>, IKeyVaultManager
    {
        private IGraphRbacManager graphRbacManager;
        private string tenantId;

        #region Fluent private collections
        private IVaults vaults;
        #endregion

        #region ctrs

        public KeyVaultManager(RestClient restClient, string subscriptionId, string tenantId) :
            base(restClient, subscriptionId, new KeyVaultManagementClient(new Uri(restClient.BaseUri),
                restClient.Credentials,
                restClient.RootHttpHandler,
                restClient.Handlers.ToArray())
            {
                SubscriptionId = subscriptionId
            })
        {
            string graphEndpoint = AzureEnvironment.AzureGlobalCloud.GraphEndpoint;
            if (restClient.Credentials is AzureCredentials)
            {
                graphEndpoint = ((AzureCredentials)restClient.Credentials).Environment.GraphEndpoint;
            }
            graphRbacManager = GraphRbacManager.Authenticate(RestClient.Configure()
                .WithBaseUri(graphEndpoint)
                .WithDelegatingHandlers(restClient.Handlers.ToArray())
                .WithCredentials(restClient.Credentials)
                .Build(), tenantId);
            this.tenantId = tenantId;
        }

        #endregion

        #region Key Vault Manager builder

        public static IKeyVaultManager Authenticate(AzureCredentials credentials, string subscriptionId)
        {
            return new KeyVaultManager(RestClient.Configure()
                    .WithEnvironment(credentials.Environment)
                    .WithCredentials(credentials)
                    .WithDelegatingHandler(new ProviderRegistrationDelegatingHandler(credentials))
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
                        this,
                        graphRbacManager,
                        tenantId);
                }

                return vaults;
            }
        }
        
        #endregion
    }

    public interface IKeyVaultManager : IManager<IKeyVaultManagementClient>
    {
        IVaults Vaults { get; }
    }
}

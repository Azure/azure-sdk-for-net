using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Management.V2.Resource.Core;
using Microsoft.Rest.Azure;
using Microsoft.Rest;
using Microsoft.Azure.Management.V2.Resource;
using Microsoft.Azure.Management.Graph.RBAC;
using Microsoft.Azure.Management.KeyVault;
using Microsoft.Azure.Management.Fluent.Graph.RBAC;

namespace Microsoft.Azure.Management.Fluent.KeyVault
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

        public KeyVaultManager(RestClient restClient, ServiceClientCredentials graphCredentials, string subscriptionId, string tenantId) : base(restClient, subscriptionId)
        {
            client = new KeyVaultManagementClient(new Uri(restClient.BaseUri),
                restClient.Credentials,
                restClient.RootHttpHandler,
                restClient.Handlers.ToArray());
            client.SubscriptionId = subscriptionId;
            graphRbacManager = GraphRbacManager.Authenticate(graphCredentials, subscriptionId, tenantId);
            this.tenantId = tenantId;
        }

        #endregion

        #region Key Vault Manager builder

        public static IKeyVaultManager Authenticate(ServiceClientCredentials serviceClientCredentials, ServiceClientCredentials graphCredentials, string subscriptionId, string tenantId)
        {
            return new KeyVaultManager(RestClient.Configure()
                    .withEnvironment(AzureEnvironment.AzureGlobalCloud)
                    .withCredentials(serviceClientCredentials)
                    .build(), graphCredentials, subscriptionId, tenantId);
        }

        public static IKeyVaultManager Authenticate(RestClient restClient, ServiceClientCredentials graphCredentials, string subscriptionId, string tenantId)
        {
            return new KeyVaultManager(restClient, graphCredentials, subscriptionId, tenantId);
        }

        public static IConfigurable Configure()
        {
            return new Configurable();
        }

        #endregion


        #region IConfigurable and it's implementation

        public interface IConfigurable : IAzureConfigurable<IConfigurable>
        {
            IKeyVaultManager Authenticate(ServiceClientCredentials serviceClientCredentials, ServiceClientCredentials graphCredentials, string subscriptionId, string tenantId);
        }

        protected class Configurable :
            AzureConfigurable<IConfigurable>,
            IConfigurable
        {
            public IKeyVaultManager Authenticate(ServiceClientCredentials credentials, ServiceClientCredentials graphCredentials, string subscriptionId, string tenantId)
            {
                return new KeyVaultManager(BuildRestClient(credentials), graphCredentials, subscriptionId, tenantId);
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

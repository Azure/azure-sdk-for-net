using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Management.V2.Resource;
using Microsoft.Azure.Management.V2.Resource.Core;
using Microsoft.Rest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.V2.Storage
{
    public class StorageManager : ManagerBase, IStorageManager
    {
        #region SDK clients
        private StorageManagementClient storageManagementClient;
        #endregion

        #region Fluent private collections
        private IStorageAccounts storageAccounts;
        #endregion

        #region ctrs

        private StorageManager(RestClient restClient, string subscriptionId) : base(restClient, subscriptionId)
        {
            storageManagementClient = new StorageManagementClient(new Uri(restClient.BaseUri),
                restClient.Credentials,
                restClient.RootHttpHandler,
                restClient.Handlers.ToArray());
            storageManagementClient.SubscriptionId = subscriptionId;
        }

        #endregion

        #region StorageManager builder

        public static IStorageManager Authenticate(ServiceClientCredentials serviceClientCredentials, string subscriptionId)
        {
            return new StorageManager(RestClient.Configure()
                    .withEnvironment(AzureEnvironment.AzureGlobalCloud)
                    .withCredentials(serviceClientCredentials)
                    .build(), subscriptionId);
        }

        public static IStorageManager Authenticate(RestClient restClient, string subscriptionId)
        {
            return new StorageManager(restClient, subscriptionId);
        }

        public static IConfigurable Configure()
        {
            return new Configurable();
        }

        #endregion


        #region IConfigurable and it's implementation

        public interface IConfigurable : IAzureConfigurable<IConfigurable>
        {
            IStorageManager Authenticate(ServiceClientCredentials serviceClientCredentials, string subscriptionId);
        }

        protected class Configurable :
            AzureConfigurable<IConfigurable>,
            IConfigurable
        {
            public IStorageManager Authenticate(ServiceClientCredentials credentials, string subscriptionId)
            {
                return new StorageManager(BuildRestClient(credentials), subscriptionId);
            }
        }

        #endregion

        #region IStorageManager implementation 

        public IStorageAccounts StorageAccounts
        {
            get
            {
                if (storageAccounts == null)
                {
                    storageAccounts = new StorageAccountsImpl(storageManagementClient.StorageAccounts, this);
                }
                return storageAccounts;
            }
        }

        #endregion
    }

    public interface IStorageManager : IManagerBase
    {
        IStorageAccounts StorageAccounts { get; }
    }
}

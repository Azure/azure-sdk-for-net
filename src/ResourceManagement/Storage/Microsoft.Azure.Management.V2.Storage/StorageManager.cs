using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Management.V2.Resource;
using Microsoft.Azure.Management.V2.Resource.Core;
using Microsoft.Rest;
using System;
using System.Linq;

namespace Microsoft.Azure.Management.V2.Storage
{
    public class StorageManager : ManagerBase, IStorageManager
    {
        #region SDK clients
        private StorageManagementClient storageManagementClient;
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

        /// <summary>
        /// Creates an instance of StorageManager that exposes storage resource management API entry points.
        /// </summary>
        /// <param name="serviceClientCredentials">the credentials to use</param>
        /// <param name="subscriptionId">the subscription UUID</param>
        /// <returns>the StorageManager</returns>
        public static IStorageManager Authenticate(ServiceClientCredentials serviceClientCredentials, string subscriptionId)
        {
            return new StorageManager(RestClient.Configure()
                    .withEnvironment(AzureEnvironment.AzureGlobalCloud)
                    .withCredentials(serviceClientCredentials)
                    .build(), subscriptionId);
        }

        /// <summary>
        /// Creates an instance of StorageManager that exposes storage resource management API entry points.
        /// </summary>
        /// <param name="restClient">the RestClient to be used for API calls.</param>
        /// <param name="subscriptionId">the subscription UUID</param>
        /// <returns>the StorageManager</returns>
        public static IStorageManager Authenticate(RestClient restClient, string subscriptionId)
        {
            return new StorageManager(restClient, subscriptionId);
        }

        /// <summary>
        /// Get a Configurable instance that can be used to create StorageManager with optional configuration.
        /// </summary>
        /// <returns>the instance allowing configurations</returns>
        public static IConfigurable Configure()
        {
            return new Configurable();
        }

        #endregion


        #region IConfigurable and it's implementation

        /// <summary>
        /// The inteface allowing configurations to be set.
        /// </summary>
        public interface IConfigurable : IAzureConfigurable<IConfigurable>
        {
            IStorageManager Authenticate(ServiceClientCredentials serviceClientCredentials, string subscriptionId);
        }

        protected class Configurable :
            AzureConfigurable<IConfigurable>,
            IConfigurable
        {
            /// <summary>
            /// Creates an instance of StorageManager that exposes storage management API entry points.
            /// </summary>
            /// <param name="credentials">credentials the credentials to use</param>
            /// <param name="subscriptionId">The subscription UUID</param>
            /// <return>the interface exposing storage management API entry points that work in a subscription</returns>
            public IStorageManager Authenticate(ServiceClientCredentials credentials, string subscriptionId)
            {
                return new StorageManager(BuildRestClient(credentials), subscriptionId);
            }
        }

        #endregion

        #region IStorageManager implementation 

        private IStorageAccounts storageAccounts;
        private IUsages usages;

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

        public IUsages Usages {
            get
            {
                if (usages == null)
                {
                    usages = new UsagesImpl(storageManagementClient.Usage);
                }
                return usages;
            }
        }

        #endregion
    }

    /// <summary>
    /// Entry point to Azure storage resource management.
    /// </summary>
    public interface IStorageManager : IManagerBase
    {
        /// <summary>
        /// Gets the storage resource management API entry point.
        /// </summary>
        IStorageAccounts StorageAccounts { get; }

        /// <summary>
        /// Gets the storage resource usage management API entry point.
        /// </summary>
        IUsages Usages { get; }
    }
}

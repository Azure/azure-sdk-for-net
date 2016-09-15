using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.V2.Resource.Core;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Rest.Azure;
using Microsoft.Rest;
using Microsoft.Azure.Management.V2.Resource;
using Microsoft.Azure.Management.V2.Storage;
using Microsoft.Azure.Management.V2.Network;

namespace Microsoft.Azure.Management.V2.Compute
{
    public class ComputeManager : ManagerBase, IComputeManager
    {
        private IStorageManager storageManager;
        private INetworkManager networkManager;

        #region SDK clients
        private ComputeManagementClient client;
        #endregion

        #region Fluent private collections
        private IVirtualMachines virtualMachines;
        private IVirtualMachineImages virtualMachineImages;
        private IAvailabilitySets availabilitySets;
        #endregion

        #region ctrs

        public ComputeManager(RestClient restClient, string subscriptionId)  : base(restClient, subscriptionId)
        {
            client = new ComputeManagementClient(new Uri(restClient.BaseUri),
                restClient.Credentials,
                restClient.RootHttpHandler,
                restClient.Handlers.ToArray());
            client.SubscriptionId = subscriptionId;
            storageManager = StorageManager.Authenticate(restClient, subscriptionId);
            networkManager = NetworkManager.Authenticate(restClient, subscriptionId);
        }

        #endregion

        #region ComputeManager builder

        public static IComputeManager Authenticate(ServiceClientCredentials serviceClientCredentials, string subscriptionId)
        {
            return new ComputeManager(RestClient.Configure()
                    .withEnvironment(AzureEnvironment.AzureGlobalCloud)
                    .withCredentials(serviceClientCredentials)
                    .build(), subscriptionId);
        }

        public static IComputeManager Authenticate(RestClient restClient, string subscriptionId)
        {
            return new ComputeManager(restClient, subscriptionId);
        }

        public static IConfigurable Configure()
        {
            return new Configurable();
        }

        #endregion


        #region IConfigurable and it's implementation

        public interface IConfigurable : IAzureConfigurable<IConfigurable>
        {
            IComputeManager Authenticate(ServiceClientCredentials serviceClientCredentials, string subscriptionId);
        }

        protected class Configurable :
            AzureConfigurable<IConfigurable>,
            IConfigurable
        {
            public IComputeManager Authenticate(ServiceClientCredentials credentials, string subscriptionId)
            {
                return new ComputeManager(BuildRestClient(credentials), subscriptionId);
            }
        }

        #endregion

        #region IComputeManager implementation 

        public IVirtualMachines VirtualMachines
        {
            get
            {
                if (virtualMachines == null)
                {
                    virtualMachines = new VirtualMachinesImpl(
                        client.VirtualMachines, 
                        client.VirtualMachineSizes, 
                        this,
                        storageManager,
                        networkManager);
                }

                return virtualMachines;
            }
        }

        public IVirtualMachineImages VirtualMachineImages
        {
            get
            {
                if (virtualMachineImages == null)
                {
                    virtualMachineImages = new VirtualMachineImagesImpl(client.VirtualMachineImages);
                }
                return virtualMachineImages;
            }
        }


        public IAvailabilitySets AvailabilitySets
        {
            get
            {
                if (availabilitySets == null)
                {
                    availabilitySets = new AvailabilitySetsImpl(client.AvailabilitySets, this);
                }
                return availabilitySets;
            }
        }
        #endregion
    }

    public interface IComputeManager : IManagerBase
    {
        IVirtualMachines VirtualMachines { get; }
        IVirtualMachineImages VirtualMachineImages { get; }
        IAvailabilitySets AvailabilitySets { get; }
    }
}

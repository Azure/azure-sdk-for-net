// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Fluent.Resource.Core;
using Microsoft.Rest;
using Microsoft.Azure.Management.Fluent.Resource;
using Microsoft.Azure.Management.Fluent.Storage;
using Microsoft.Azure.Management.Fluent.Network;
using Microsoft.Azure.Management.Fluent.Resource.Authentication;

namespace Microsoft.Azure.Management.Fluent.Compute
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
        private IVirtualMachineExtensionImages virtualMachineExtensionImages;
        private IAvailabilitySets availabilitySets;
        private IVirtualMachineScaleSets virtualMachineScaleSets;
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

        public static IComputeManager Authenticate(AzureCredentials credentials, string subscriptionId)
        {
            return new ComputeManager(RestClient.Configure()
                    .WithEnvironment(credentials.Environment)
                    .WithCredentials(credentials)
                    .Build(), subscriptionId);
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
            IComputeManager Authenticate(AzureCredentials credentials, string subscriptionId);
        }

        protected class Configurable :
            AzureConfigurable<IConfigurable>,
            IConfigurable
        {
            public IComputeManager Authenticate(AzureCredentials credentials, string subscriptionId)
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
                        client.VirtualMachineExtensions,
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
                    virtualMachineImages = new VirtualMachineImagesImpl(new VirtualMachinePublishersImpl(client.VirtualMachineImages, client.VirtualMachineExtensionImages));
                }
                return virtualMachineImages;
            }
        }

        public IVirtualMachineExtensionImages VirtualMachineExtensionImages
        {
            get
            {
                if (virtualMachineExtensionImages == null)
                {
                    virtualMachineExtensionImages = new VirtualMachineExtensionImagesImpl(new VirtualMachinePublishersImpl(client.VirtualMachineImages, client.VirtualMachineExtensionImages));
                }
                return virtualMachineExtensionImages;
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

        public IVirtualMachineScaleSets VirtualMachineScaleSets {
            get
            {
                if (virtualMachineScaleSets == null)
                {
                    virtualMachineScaleSets = new VirtualMachineScaleSetsImpl(client.VirtualMachineScaleSets, this, 
                        this.storageManager,
                        this.networkManager);
                }
                return virtualMachineScaleSets;
            }
        }
        #endregion
    }

    public interface IComputeManager : IManagerBase
    {
        IVirtualMachines VirtualMachines { get; }
        IVirtualMachineImages VirtualMachineImages { get; }

        IVirtualMachineExtensionImages VirtualMachineExtensionImages { get; }

        IAvailabilitySets AvailabilitySets { get; }
        IVirtualMachineScaleSets VirtualMachineScaleSets { get; }
    }
}

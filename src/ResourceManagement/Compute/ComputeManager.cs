// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Storage.Fluent;
using Microsoft.Azure.Management.Network.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Authentication;
using Microsoft.Azure.Management.Graph.RBAC.Fluent;

namespace Microsoft.Azure.Management.Compute.Fluent
{
    public class ComputeManager : Manager<IComputeManagementClient>, IComputeManager
    {
        private IStorageManager storageManager;
        private INetworkManager networkManager;
        private IGraphRbacManager rbacManager;

        #region Fluent private collections
        private IVirtualMachines virtualMachines;
        private IVirtualMachineImages virtualMachineImages;
        private IVirtualMachineExtensionImages virtualMachineExtensionImages;
        private IAvailabilitySets availabilitySets;
        private IVirtualMachineScaleSets virtualMachineScaleSets;
        private IComputeUsages usages;
        private IDisks disks;
        private ISnapshots snapshots;
        private IVirtualMachineCustomImages virtualMachineCustomImages;
        private IContainerServices containerServices;
        #endregion

        #region ctrs

        public ComputeManager(RestClient restClient, string subscriptionId) :
            base(restClient, subscriptionId, new ComputeManagementClient(new Uri(restClient.BaseUri),
                restClient.Credentials,
                restClient.RootHttpHandler,
                restClient.Handlers.ToArray())
            {
                SubscriptionId = subscriptionId
            })
        {
            storageManager = StorageManager.Authenticate(restClient, subscriptionId);
            networkManager = NetworkManager.Authenticate(restClient, subscriptionId);
            rbacManager = GraphRbacManager.Authenticate(restClient, ((AzureCredentials)(restClient.Credentials)).TenantId);
        }

        #endregion

        #region ComputeManager builder

        public static IComputeManager Authenticate(AzureCredentials credentials, string subscriptionId)
        {
            return Authenticate(RestClient.Configure()
                    .WithEnvironment(credentials.Environment)
                    .WithCredentials(credentials)
                    .WithDelegatingHandler(new ProviderRegistrationDelegatingHandler(credentials))
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
                        this,
                        storageManager,
                        networkManager,
                        rbacManager);
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
                    virtualMachineImages = new VirtualMachineImagesImpl(
                        new VirtualMachinePublishersImpl(
                            Inner.VirtualMachineImages, 
                            Inner.VirtualMachineExtensionImages),
                        Inner.VirtualMachineImages);
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
                    virtualMachineExtensionImages = new VirtualMachineExtensionImagesImpl(
                        new VirtualMachinePublishersImpl(
                            Inner.VirtualMachineImages,
                            Inner.VirtualMachineExtensionImages));
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
                    availabilitySets = new AvailabilitySetsImpl(this);
                }
                return availabilitySets;
            }
        }

        public IVirtualMachineScaleSets VirtualMachineScaleSets {
            get
            {
                if (virtualMachineScaleSets == null)
                {
                    virtualMachineScaleSets = new VirtualMachineScaleSetsImpl(
                        this, 
                        storageManager,
                        networkManager,
                        rbacManager);
                }
                return virtualMachineScaleSets;
            }
        }

        public IComputeUsages Usages
        {
            get
            {
                if (usages == null)
                {
                    usages = new ComputeUsagesImpl(Inner);
                }
                return usages;
            }
        }

        public IDisks Disks
        {
            get
            {
                if (disks == null)
                {
                    disks = new DisksImpl(this);
                }
                return disks;
            }
        }

        public ISnapshots Snapshots
        {
            get
            {
                if (snapshots == null)
                {
                    snapshots = new SnapshotsImpl(this);
                }
                return snapshots;
            }
        }

        public IVirtualMachineCustomImages VirtualMachineCustomImages
        {
            get
            {
                if (virtualMachineCustomImages == null)
                {
                    virtualMachineCustomImages = new VirtualMachineCustomImagesImpl(this);
                }
                return virtualMachineCustomImages;
            }
        }

        public IContainerServices ContainerServices
        {
            get
            {
                if (containerServices == null)
                {
                    containerServices = new ContainerServicesImpl(this);
                }
                return containerServices;
            }
        }
        #endregion
    }

    public interface IComputeManager : IManager<IComputeManagementClient>
    {
        IVirtualMachines VirtualMachines { get; }

        IVirtualMachineImages VirtualMachineImages { get; }

        IVirtualMachineExtensionImages VirtualMachineExtensionImages { get; }

        IAvailabilitySets AvailabilitySets { get; }

        IVirtualMachineScaleSets VirtualMachineScaleSets { get; }

        IComputeUsages Usages { get; }

        IDisks Disks { get; }

        ISnapshots Snapshots { get; }

        IVirtualMachineCustomImages VirtualMachineCustomImages { get; }

        IContainerServices ContainerServices { get; }
    }
}

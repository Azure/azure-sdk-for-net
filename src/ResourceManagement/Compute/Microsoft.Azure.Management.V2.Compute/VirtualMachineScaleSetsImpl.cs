/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/ 

namespace Microsoft.Azure.Management.V2.Compute
{

    using Microsoft.Azure.Management.V2.Resource.Core.CollectionActions;
    using Microsoft.Azure.Management.V2.Network;
    using Microsoft.Azure.Management.V2.Resource.Core;
    using Microsoft.Azure.Management.V2.Storage;
    using Management.Compute;
    using Microsoft.Azure.Management.Compute.Models;
    using System.Collections.Generic;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// The implementation for {@link VirtualMachineScaleSets}.
    /// </summary>
    public partial class VirtualMachineScaleSetsImpl  :
        GroupableResources<IVirtualMachineScaleSet,VirtualMachineScaleSetImpl,VirtualMachineScaleSetInner, IVirtualMachineScaleSetsOperations, ComputeManager>,
        IVirtualMachineScaleSets
    {
        private StorageManager storageManager;
        private NetworkManager networkManager;
        private  VirtualMachineScaleSetsImpl (IVirtualMachineScaleSetsOperations client, ComputeManager computeManager, StorageManager storageManager, NetworkManager networkManager) : base(client, computeManager)
        {
            this.storageManager = storageManager;
            this.networkManager = networkManager;
        }

        //public async override Task<IVirtualMachineScaleSet> GetByGroupAsync(string resourceGroupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        //{
        //    throw new NotImplementedException();
        //}

        public PagedList<IVirtualMachineScaleSet> ListByGroup (string groupName)
        {
            //$ return wrapList(this.innerCollection.list(groupName));
            return null;
        }

        public PagedList<IVirtualMachineScaleSet> List ()
        {
            //$ return wrapList(this.innerCollection.listAll());
            return null;
        }

        public void Delete (string id)
        {
            this.Delete(ResourceUtils.GroupFromResourceId(id), ResourceUtils.NameFromResourceId(id));
        }

        public void Delete (string groupName, string name)
        {
            this.InnerCollection.Delete(groupName, name);
        }

        public void Deallocate (string groupName, string name)
        {
            this.InnerCollection.Deallocate(groupName, name);
        }

        public void PowerOff (string groupName, string name)
        {
            this.InnerCollection.PowerOff(groupName, name);
        }

        public void Restart (string groupName, string name)
        {
            this.InnerCollection.Restart(groupName, name);
        }

        public void Start (string groupName, string name)
        {
            this.InnerCollection.Start(groupName, name);

        }

        public void Reimage (string groupName, string name)
        {
            this.InnerCollection.Reimage(groupName, name);

        }

        public VirtualMachineScaleSetImpl Define (string name)
        {
            return WrapModel(name);
        }

        protected override VirtualMachineScaleSetImpl WrapModel (string name)
        {

            VirtualMachineScaleSetInner inner = new VirtualMachineScaleSetInner
            {
                VirtualMachineProfile = new VirtualMachineScaleSetVMProfile
                {
                    StorageProfile = new VirtualMachineScaleSetStorageProfile
                    {
                        OsDisk = new VirtualMachineScaleSetOSDisk
                        {
                            VhdContainers = new List<string>()
                        }
                    },
                    OsProfile = new VirtualMachineScaleSetOSProfile
                    {

                    },
                    NetworkProfile = new VirtualMachineScaleSetNetworkProfile
                    {
                        NetworkInterfaceConfigurations = new List<VirtualMachineScaleSetNetworkConfigurationInner>()
                        {
                            new VirtualMachineScaleSetNetworkConfigurationInner
                            {
                                Primary = true,
                                Name = "primary-nic-cfg",
                                IpConfigurations = new List<VirtualMachineScaleSetIPConfigurationInner>()
                                {
                                    new VirtualMachineScaleSetIPConfigurationInner
                                    {
                                        Name = "primary-nic-ip-cfg"
                                    }
                                }
                            }
                        }
                    }
                }
            };
            return new VirtualMachineScaleSetImpl(name,
                inner,
                this.InnerCollection,
                this.MyManager,
                this.storageManager,
                this.networkManager);
        }

        protected override IVirtualMachineScaleSet WrapModel (VirtualMachineScaleSetInner inner)
        {
            return new VirtualMachineScaleSetImpl(inner.Name,
                inner,
                this.InnerCollection,
                this.MyManager,
                this.storageManager,
                this.networkManager);
        }

        Task<PagedList<IVirtualMachineScaleSet>> ISupportsListingByGroup<IVirtualMachineScaleSet>.ListByGroupAsync(string resourceGroupName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task ISupportsDeleting.DeleteAsync(string id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Task ISupportsDeletingByGroup.DeleteAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async override Task<IVirtualMachineScaleSet> GetByGroupAsync(string groupName, string name)
        {
            throw new NotImplementedException();
        }
    }
}
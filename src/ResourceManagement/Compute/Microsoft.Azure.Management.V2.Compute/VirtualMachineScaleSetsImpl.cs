// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information. 

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
    using Rest.Azure;

    /// <summary>
    /// The implementation for {@link VirtualMachineScaleSets}.
    /// </summary>
    internal partial class VirtualMachineScaleSetsImpl  :
        GroupableResources<IVirtualMachineScaleSet,VirtualMachineScaleSetImpl,VirtualMachineScaleSetInner, IVirtualMachineScaleSetsOperations, ComputeManager>,
        IVirtualMachineScaleSets
    {
        private IStorageManager storageManager;
        private INetworkManager networkManager;
        public  VirtualMachineScaleSetsImpl (IVirtualMachineScaleSetsOperations client, ComputeManager computeManager, IStorageManager storageManager, INetworkManager networkManager) : base(client, computeManager)
        {
            this.storageManager = storageManager;
            this.networkManager = networkManager;
        }

        public PagedList<IVirtualMachineScaleSet> ListByGroup (string groupName)
        {
            IPage<VirtualMachineScaleSetInner> firstPage = InnerCollection.List(groupName);
            var pagedList = new PagedList<VirtualMachineScaleSetInner>(firstPage, (string nextPageLink) =>
            {
                return InnerCollection.ListNext(nextPageLink);
            });
            return WrapList(pagedList);
        }

        public PagedList<IVirtualMachineScaleSet> List ()
        {
            IPage<VirtualMachineScaleSetInner> firstPage = InnerCollection.ListAll();
            var pagedList = new PagedList<VirtualMachineScaleSetInner>(firstPage, (string nextPageLink) =>
            {
                return InnerCollection.ListAllNext(nextPageLink);
            });
            return WrapList(pagedList);
        }

        public void Delete (string id)
        {
            this.Delete(ResourceUtils.GroupFromResourceId(id), ResourceUtils.NameFromResourceId(id));
        }

        public void Delete (string groupName, string name)
        {
            this.InnerCollection.Delete(groupName, name);
        }

        Task ISupportsDeleting.DeleteAsync(string id, CancellationToken cancellationToken)
        {
            return this.InnerCollection.DeleteAsync(ResourceUtils.GroupFromResourceId(id), 
                ResourceUtils.NameFromResourceId(id),
                cancellationToken);
        }

        public Task DeleteAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            return this.InnerCollection.DeleteAsync(groupName,
                name,
                cancellationToken);
        }

        public async override Task<IVirtualMachineScaleSet> GetByGroupAsync(string groupName, string name)
        {
            var scaleSet = await this.InnerCollection.GetAsync(groupName, name);
            return WrapModel(scaleSet);
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
                this.Manager,
                this.storageManager,
                this.networkManager);
        }

        protected override IVirtualMachineScaleSet WrapModel (VirtualMachineScaleSetInner inner)
        {
            return new VirtualMachineScaleSetImpl(inner.Name,
                inner,
                this.InnerCollection,
                this.Manager,
                this.storageManager,
                this.networkManager);
        }
    }
}
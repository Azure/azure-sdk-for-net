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

    /// <summary>
    /// The implementation for {@link VirtualMachineScaleSets}.
    /// </summary>
    public partial class VirtualMachineScaleSetsImpl  :
        GroupableResources<IVirtualMachineScaleSet,VirtualMachineScaleSetImpl,VirtualMachineScaleSetInner, IVirtualMachineScaleSetsOperations, ComputeManager>,
        IVirtualMachineScaleSets
    {
        private StorageManager storageManager;
        private NetworkManager networkManager;
        private  VirtualMachineScaleSetsImpl (IVirtualMachineScaleSetsOperations client, ComputeManager computeManager, StorageManager storageManager, NetworkManager networkManager)
        {

            //$ ComputeManager computeManager,
            //$ StorageManager storageManager,
            //$ NetworkManager networkManager) {
            //$ super(client, computeManager);
            //$ this.storageManager = storageManager;
            //$ this.networkManager = networkManager;
            //$ }

        }

        public IVirtualMachineScaleSet GetByGroup (string groupName, string name)
        {

            //$ return wrapModel(this.innerCollection.get(groupName, name));

            return null;
        }

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

            //$ this.delete(ResourceUtils.groupFromResourceId(id), ResourceUtils.nameFromResourceId(id));

        }

        public void Delete (string groupName, string name)
        {

            //$ this.innerCollection.delete(groupName, name);

        }

        public void Deallocate (string groupName, string name)
        {

            //$ this.innerCollection.deallocate(groupName, name);

        }

        public void PowerOff (string groupName, string name)
        {

            //$ this.innerCollection.powerOff(groupName, name);

        }

        public void Restart (string groupName, string name)
        {

            //$ this.innerCollection.restart(groupName, name);

        }

        public void Start (string groupName, string name)
        {

            //$ this.innerCollection.start(groupName, name);

        }

        public void Reimage (string groupName, string name)
        {

            //$ this.innerCollection.reimage(groupName, name);

        }

        public VirtualMachineScaleSetImpl Define (string name)
        {

            //$ return wrapModel(name);

            return null;
        }

        protected VirtualMachineScaleSetImpl WrapModel (string name)
        {

            //$ VirtualMachineScaleSetInner inner = new VirtualMachineScaleSetInner();
            //$ 
            //$ inner.withVirtualMachineProfile(new VirtualMachineScaleSetVMProfile());
            //$ inner.virtualMachineProfile()
            //$ .withStorageProfile(new VirtualMachineScaleSetStorageProfile()
            //$ .withOsDisk(new VirtualMachineScaleSetOSDisk().withVhdContainers(new ArrayList<String>())));
            //$ inner.virtualMachineProfile()
            //$ .withOsProfile(new VirtualMachineScaleSetOSProfile());
            //$ 
            //$ inner.virtualMachineProfile()
            //$ .withNetworkProfile(new VirtualMachineScaleSetNetworkProfile());
            //$ 
            //$ inner.virtualMachineProfile()
            //$ .networkProfile()
            //$ .withNetworkInterfaceConfigurations(new ArrayList<VirtualMachineScaleSetNetworkConfigurationInner>());
            //$ 
            //$ VirtualMachineScaleSetNetworkConfigurationInner primaryNetworkInterfaceConfiguration =
            //$ new VirtualMachineScaleSetNetworkConfigurationInner()
            //$ .withPrimary(true)
            //$ .withName("primary-nic-cfg")
            //$ .withIpConfigurations(new ArrayList<VirtualMachineScaleSetIPConfigurationInner>());
            //$ primaryNetworkInterfaceConfiguration
            //$ .ipConfigurations()
            //$ .add(new VirtualMachineScaleSetIPConfigurationInner()
            //$ .withName("primary-nic-ip-cfg"));
            //$ 
            //$ inner.virtualMachineProfile()
            //$ .networkProfile()
            //$ .networkInterfaceConfigurations()
            //$ .add(primaryNetworkInterfaceConfiguration);
            //$ 
            //$ return new VirtualMachineScaleSetImpl(name,
            //$ inner,
            //$ this.innerCollection,
            //$ super.myManager,
            //$ this.storageManager,
            //$ this.networkManager);

            return null;
        }

        protected VirtualMachineScaleSetImpl WrapModel (VirtualMachineScaleSetInner inner)
        {

            //$ return new VirtualMachineScaleSetImpl(inner.name(),
            //$ inner,
            //$ this.innerCollection,
            //$ super.myManager,
            //$ this.storageManager,
            //$ this.networkManager);

            return null;
        }

    }
}
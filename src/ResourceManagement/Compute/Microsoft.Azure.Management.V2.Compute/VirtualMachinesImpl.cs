/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/

namespace Microsoft.Azure.Management.V2.Compute
{

    using Microsoft.Azure.Management.Compute.Models;
    using Microsoft.Azure.Management.Network.Models;
    using Microsoft.Azure.Management.V2.Resource.Core.CollectionActions;
    using Microsoft.Azure.Management.V2.Resource;
    using Microsoft.Azure.Management.V2.Resource.Core;
    using Microsoft.Azure.Management.Storage.Models;
    using Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition;
    using Management.Compute;
    using Storage;
    using Network;
    using System.Threading.Tasks;
    using System.Threading;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The implementation for {@link VirtualMachines}.
    /// </summary>
    public partial class VirtualMachinesImpl :
        GroupableResources<IVirtualMachine,
            VirtualMachineImpl,
            VirtualMachineInner,
            IVirtualMachinesOperations,
            ComputeManager>,
        IVirtualMachines
    {
        private IStorageManager storageManager;
        private INetworkManager networkManager;
        private VirtualMachineSizesImpl vmSizes;

        internal VirtualMachinesImpl(IVirtualMachinesOperations client, IVirtualMachineSizesOperations virtualMachineSizesClient, ComputeManager computeManager, IStorageManager storageManager, INetworkManager networkManager) :
            base(client, computeManager)
        {
            this.storageManager = storageManager;
            this.networkManager = networkManager;
            this.vmSizes = new VirtualMachineSizesImpl(virtualMachineSizesClient);
        }

        public PagedList<IVirtualMachine> List()
        {
            // There is no API supporting listing of availabiltiy set across subscription so enumerate all RGs and then
            // flatten the "list of list of availibility sets" as "list of availibility sets" .
            return new ChildListFlattener<IResourceGroup, IVirtualMachine>(MyManager.ResourceManager.ResourceGroups.List(), (IResourceGroup resourceGroup) =>
            {
                return ListByGroup(resourceGroup.Name);
            }).Flatten();
        }

        public PagedList<IVirtualMachine> ListByGroup(string resourceGroupName)
        {
            var pagedList = new PagedList<VirtualMachineInner>(this.InnerCollection.List(resourceGroupName));
            return WrapList(pagedList);
        }

        public void Delete(string id)
        {
            DeleteAsync(id).Wait();
        }

        public void Delete(string groupName, string name)
        {
            DeleteAsync(groupName, name).Wait();
        }

        public IBlank Define(string name)
        {
            return WrapModel(name);
        }

        public void Deallocate(string groupName, string name)
        {
            this.InnerCollection.Deallocate(groupName, name);
        }

        public void Generalize(string groupName, string name)
        {
            this.InnerCollection.Generalize(groupName, name);
        }

        public void PowerOff(string groupName, string name)
        {
            this.InnerCollection.PowerOff(groupName, name);
        }

        public void Restart(string groupName, string name)
        {
            this.InnerCollection.Restart(groupName, name);
        }

        public void Start(string groupName, string name)
        {
            this.InnerCollection.Start(groupName, name);
        }

        public void Redeploy(string groupName, string name)
        {
            this.InnerCollection.Redeploy(groupName, name);
        }

        public string Capture(string groupName, string name, string containerName, bool overwriteVhd)
        {
            VirtualMachineCaptureParametersInner parameters = new VirtualMachineCaptureParametersInner();
            parameters.DestinationContainerName = containerName;
            parameters.OverwriteVhds = overwriteVhd;
            VirtualMachineCaptureResultInner captureResult = this.InnerCollection.Capture(groupName, name, parameters);
            return captureResult.Output.ToString();
        }

        public IVirtualMachineSizes Sizes()
        {
            return this.vmSizes;
        }

        protected override VirtualMachineImpl WrapModel(string name)
        {
            var osDisk = new OSDisk();
            var storageProfile = new StorageProfile();
            storageProfile.OsDisk = osDisk;
            storageProfile.DataDisks = new List<DataDisk>();
            var networkProfile = new NetworkProfile();
            networkProfile.NetworkInterfaces = new List<NetworkInterfaceReferenceInner>();

            VirtualMachineInner inner = new VirtualMachineInner();
            inner.StorageProfile = storageProfile;
            inner.OsProfile = new OSProfile();
            inner.HardwareProfile = new HardwareProfile();
            inner.NetworkProfile = networkProfile;

            return new VirtualMachineImpl(name,
                inner,
                this.InnerCollection,
                base.MyManager,
                this.storageManager,
                this.networkManager);
        }

        protected override IVirtualMachine WrapModel(VirtualMachineInner virtualMachineInner)
        {
            return new VirtualMachineImpl(virtualMachineInner.Name,
                virtualMachineInner,
                this.InnerCollection,
                base.MyManager,
                this.storageManager,
                this.networkManager);
        }

        public Task DeleteAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            return ((ISupportsDeletingByGroup)this).DeleteAsync(ResourceUtils.GroupFromResourceId(id), ResourceUtils.NameFromResourceId(id));
        }

        public async Task DeleteAsync(string groupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.InnerCollection.DeleteAsync(groupName, name, cancellationToken);
        }

        public async Task<PagedList<IVirtualMachine>> ListByGroupAsync(string resourceGroupName, CancellationToken cancellationToken)
        {
            var data = await this.InnerCollection.ListAsync(resourceGroupName);
            return WrapList(new PagedList<VirtualMachineInner>(data));
        }

        public async override Task<IVirtualMachine> GetByGroupAsync(string groupName, string name)
        {
            var data = await this.InnerCollection.GetAsync(groupName, name);
            return this.WrapModel(data);
        }
    }
}
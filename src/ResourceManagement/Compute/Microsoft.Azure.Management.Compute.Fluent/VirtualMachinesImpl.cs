// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Management.Compute.Fluent;
    using Management.Compute.Fluent.Models;
    using Resource.Fluent.Core;
    using Resource.Fluent.Core.CollectionActions;
    using Network.Fluent;
    using Storage.Fluent;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// The implementation for VirtualMachines.
    /// </summary>
    internal partial class VirtualMachinesImpl :
        GroupableResources<IVirtualMachine,
            VirtualMachineImpl,
            VirtualMachineInner,
            IVirtualMachinesOperations, 
            IComputeManager>,
        IVirtualMachines
    {
        private readonly IStorageManager storageManager;
        private readonly INetworkManager networkManager;
        private readonly VirtualMachineSizesImpl vmSizes;
        private readonly IVirtualMachineExtensionsOperations virtualMachineExtensionsClient;

        internal VirtualMachinesImpl(IVirtualMachinesOperations client, IVirtualMachineExtensionsOperations virtualMachineExtensionsClient, IVirtualMachineSizesOperations virtualMachineSizesClient, ComputeManager computeManager, IStorageManager storageManager, INetworkManager networkManager) :
            base(client, computeManager)
        {
            this.virtualMachineExtensionsClient = virtualMachineExtensionsClient;
            this.storageManager = storageManager;
            this.networkManager = networkManager;
            this.vmSizes = new VirtualMachineSizesImpl(virtualMachineSizesClient);
        }

        public PagedList<IVirtualMachine> List()
        {
            var pagedList = new PagedList<VirtualMachineInner>(this.InnerCollection.ListAll(), (string nextPageLink) =>
            {
                return InnerCollection.ListAllNext(nextPageLink);
            });

            return WrapList(pagedList);
        }

        public PagedList<IVirtualMachine> ListByGroup(string resourceGroupName)
        {
            var pagedList = new PagedList<VirtualMachineInner>(this.InnerCollection.List(resourceGroupName), (string nextPageLink) =>
            {
                return InnerCollection.ListNext(nextPageLink);
            });
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

        public async Task DeleteAsync(string groupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            await this.InnerCollection.DeleteAsync(groupName, name, cancellationToken);
        }

        public VirtualMachineImpl Define(string name)
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
                this.virtualMachineExtensionsClient,
                base.Manager,
                this.storageManager,
                this.networkManager);
        }

        protected override IVirtualMachine WrapModel(VirtualMachineInner virtualMachineInner)
        {
            return new VirtualMachineImpl(virtualMachineInner.Name,
                virtualMachineInner,
                this.InnerCollection,
                this.virtualMachineExtensionsClient,
                base.Manager,
                this.storageManager,
                this.networkManager);
        }

        public Task DeleteAsync(string id, CancellationToken cancellationToken = default(CancellationToken))
        {
            return ((ISupportsDeletingByGroup)this).DeleteAsync(ResourceUtils.GroupFromResourceId(id), ResourceUtils.NameFromResourceId(id), cancellationToken);
        }

        public async override Task<IVirtualMachine> GetByGroupAsync(string groupName, string name)
        {
            var data = await this.InnerCollection.GetAsync(groupName, name);
            return this.WrapModel(data);
        }
    }
}
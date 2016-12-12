// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Compute.Fluent
{
    using System.Threading.Tasks;
    using Models;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core.CollectionActions;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Storage.Fluent.Models;
    using System.Threading;
    using Microsoft.Azure.Management.Resource.Fluent;
    using VirtualMachine.Definition;
    using Network.Fluent;
    using Storage.Fluent;
    using System.Collections.Generic;

    /// <summary>
    /// The implementation for VirtualMachines.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbXB1dGUuaW1wbGVtZW50YXRpb24uVmlydHVhbE1hY2hpbmVzSW1wbA==
    internal partial class VirtualMachinesImpl :
        GroupableResources<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine, Microsoft.Azure.Management.Compute.Fluent.VirtualMachineImpl, Models.VirtualMachineInner, IVirtualMachinesOperations, IComputeManager>,
        IVirtualMachines
    {
        private readonly IStorageManager storageManager;
        private readonly INetworkManager networkManager;
        private readonly VirtualMachineSizesImpl vmSizes;
        private readonly IVirtualMachineExtensionsOperations virtualMachineExtensionsClient;
        ///GENMHASH:CF74C66AC4A6B06C41B8E9D08F5D5F4B:DB478B04CDDECD11BE9F5F93E71FB984
        internal VirtualMachinesImpl(IVirtualMachinesOperations client, IVirtualMachineExtensionsOperations virtualMachineExtensionsClient, IVirtualMachineSizesOperations virtualMachineSizesClient, ComputeManager computeManager, IStorageManager storageManager, INetworkManager networkManager) :
            base(client, computeManager)
        {
            this.virtualMachineExtensionsClient = virtualMachineExtensionsClient;
            this.storageManager = storageManager;
            this.networkManager = networkManager;
            this.vmSizes = new VirtualMachineSizesImpl(virtualMachineSizesClient);
        }

        ///GENMHASH:7D6013E8B95E991005ED921F493EFCE4:36E25639805611CF89054C004B22BB15
        public PagedList<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine> List()
        {
            var pagedList = new PagedList<VirtualMachineInner>(this.InnerCollection.ListAll(), (string nextPageLink) =>
            {
                return InnerCollection.ListAllNext(nextPageLink);
            });

            return WrapList(pagedList);
        }

        ///GENMHASH:95834C6C7DA388E666B705A62A7D02BF:3953AC722DFFCDF40E1EEF787AFD1326
        public PagedList<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine> ListByGroup(string groupName)
        {
            var pagedList = new PagedList<VirtualMachineInner>(this.InnerCollection.List(groupName), (string nextPageLink) =>
            {
                return InnerCollection.ListNext(nextPageLink);
            });
            return WrapList(pagedList);
        }

        ///GENMHASH:0679DF8CA692D1AC80FC21655835E678:B9B028D620AC932FDF66D2783E476B0D
        public override Task DeleteByGroupAsync(string groupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.InnerCollection.DeleteAsync(groupName, name, cancellationToken);
        }

        public VirtualMachineImpl Define(string name)
        {
            return WrapModel(name);
        }

        ///GENMHASH:2048E8AC80AC022225C462CE7FD14A6F:AB513A3D7E5B1192B76F853CB23CBB12
        public void Deallocate(string groupName, string name)
        {
            this.InnerCollection.Deallocate(groupName, name);
        }

        ///GENMHASH:00E88CFB1570D8A0A8E9FDE81CE27B2D:41D46BEAFAD59BFEA295012F3A5791B5
        public void Generalize(string groupName, string name)
        {
            this.InnerCollection.Generalize(groupName, name);
        }

        ///GENMHASH:9F1310A4445A183902C9AF672DA34354:F32BEF843CE33ABB858763CFD92B9A36
        public void PowerOff(string groupName, string name)
        {
            this.InnerCollection.PowerOff(groupName, name);
        }

        ///GENMHASH:CD0E967F30C27C522C0DE3E4523C6CDD:8C9B139D9CD48BE89CACA8348E2E8469
        public void Restart(string groupName, string name)
        {
            this.InnerCollection.Restart(groupName, name);
        }

        ///GENMHASH:F5C1D0B90DEED77EE54F7CEB164C727E:4E2B451086A707DC66F26388A688071E
        public void Start(string groupName, string name)
        {
            this.InnerCollection.Start(groupName, name);
        }

        ///GENMHASH:5BA0ADF7CF4FCFD811B372F59A1C376E:0961DB2042C5E898ED8D9586E90E4F33
        public void Redeploy(string groupName, string name)
        {
            this.InnerCollection.Redeploy(groupName, name);
        }

        ///GENMHASH:E5D7B16A7B6C705114CC71E8BB2B20E1:6975A84E6594FF8DEA88E6C992B0B500
        public string Capture(string groupName, string name, string containerName, string vhdPrefix, bool overwriteVhd)
        {
            VirtualMachineCaptureParametersInner parameters = new VirtualMachineCaptureParametersInner();
            parameters.DestinationContainerName = containerName;
            parameters.OverwriteVhds = overwriteVhd;
            parameters.VhdPrefix = vhdPrefix;
            VirtualMachineCaptureResultInner captureResult = this.InnerCollection.Capture(groupName, name, parameters);
            return captureResult.Output.ToString();
        }

        ///GENMHASH:56C0F52C716CCBD879A6E9E8D44C3FA8:971714229723AE4B74BC25F6C0AF31AE
        public IVirtualMachineSizes Sizes()
        {
            return this.vmSizes;
        }

        ///GENMHASH:2FE8C4C2D5EAD7E37787838DE0B47D92:F59DCE21697E0967B005EDC164141A79
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

        ///GENMHASH:7C70549803EBDDFC5C2F931D81D21F99:9ECCC2DACA9F6008FB5426B0426C7B1C
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

        ///GENMHASH:AB63F782DA5B8D22523A284DAD664D17:7C0A1D0C3FE28C45F35B565F4AFF751D
        public async override Task<IVirtualMachine> GetByGroupAsync(string groupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            var data = await this.InnerCollection.GetAsync(groupName, name, null, cancellationToken);
            return this.WrapModel(data);
        }
    }
}
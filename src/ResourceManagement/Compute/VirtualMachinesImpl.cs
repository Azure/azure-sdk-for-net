// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Microsoft.Azure.Management.Graph.RBAC.Fluent;
    using Models;
    using Network.Fluent;
    using ResourceManager.Fluent.Core;
    using Rest.Azure;
    using Storage.Fluent;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// The implementation for VirtualMachines.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbXB1dGUuaW1wbGVtZW50YXRpb24uVmlydHVhbE1hY2hpbmVzSW1wbA==
    internal partial class VirtualMachinesImpl :
        TopLevelModifiableResources<
            IVirtualMachine,
            VirtualMachineImpl,
            VirtualMachineInner,
            IVirtualMachinesOperations,
            IComputeManager>,
        IVirtualMachines
    {
        private readonly IStorageManager storageManager;
        private readonly INetworkManager networkManager;
        private readonly IGraphRbacManager rbacManager;
        private readonly VirtualMachineSizesImpl vmSizes;

        ///GENMHASH:CF74C66AC4A6B06C41B8E9D08F5D5F4B:DB478B04CDDECD11BE9F5F93E71FB984
        internal VirtualMachinesImpl(
            IComputeManager computeManager,
            IStorageManager storageManager,
            INetworkManager networkManager, 
            IGraphRbacManager rbacManager) :
            base(computeManager.Inner.VirtualMachines, computeManager)
        {
            this.storageManager = storageManager;
            this.networkManager = networkManager;
            this.rbacManager = rbacManager;
            this.vmSizes = new VirtualMachineSizesImpl(computeManager.Inner.VirtualMachineSizes);
        }

        ///GENMHASH:7D6013E8B95E991005ED921F493EFCE4:36E25639805611CF89054C004B22BB15
        protected async override Task<IPage<VirtualMachineInner>> ListInnerAsync(CancellationToken cancellationToken)
        {
            return await Inner.ListAllAsync(cancellationToken);
        }

        protected async override Task<IPage<VirtualMachineInner>> ListInnerNextAsync(string nextLink, CancellationToken cancellationToken)
        {
            return await Inner.ListAllNextAsync(nextLink, cancellationToken);
        }

        ///GENMHASH:95834C6C7DA388E666B705A62A7D02BF:3953AC722DFFCDF40E1EEF787AFD1326
        protected async override Task<IPage<VirtualMachineInner>> ListInnerByGroupAsync(string groupName, CancellationToken cancellationToken)
        {
            return await Inner.ListAsync(groupName, cancellationToken);
        }

        protected async override Task<IPage<VirtualMachineInner>> ListInnerByGroupNextAsync(string nextLink, CancellationToken cancellationToken)
        {
            return await Inner.ListNextAsync(nextLink, cancellationToken);
        }

        ///GENMHASH:0679DF8CA692D1AC80FC21655835E678:B9B028D620AC932FDF66D2783E476B0D
        protected async override Task DeleteInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            await Inner.DeleteAsync(groupName, name, cancellationToken);
        }

        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:AD7C28D26EC1F237B93E54AD31899691
        public VirtualMachineImpl Define(string name)
        {
            return WrapModel(name);
        }

        ///GENMHASH:2048E8AC80AC022225C462CE7FD14A6F:AB513A3D7E5B1192B76F853CB23CBB12
        public async Task DeallocateAsync(string groupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            await Inner.DeallocateAsync(groupName, name, cancellationToken);
        }

        ///GENMHASH:2048E8AC80AC022225C462CE7FD14A6F:5B568A74BA34923154B4D31492B0C92D
        public void Deallocate(string groupName, string name)
        {
            Extensions.Synchronize(() => this.Inner.DeallocateAsync(groupName, name));
        }

        ///GENMHASH:00E88CFB1570D8A0A8E9FDE81CE27B2D:41D46BEAFAD59BFEA295012F3A5791B5
        public async Task GeneralizeAsync(string groupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            await Inner.GeneralizeAsync(groupName, name, cancellationToken);
        }

        ///GENMHASH:00E88CFB1570D8A0A8E9FDE81CE27B2D:504A7551D91B09781F4903910609216C
        public void Generalize(string groupName, string name)
        {
            Extensions.Synchronize(() => this.Inner.GeneralizeAsync(groupName, name));
        }

        ///GENMHASH:9F1310A4445A183902C9AF672DA34354:F32BEF843CE33ABB858763CFD92B9A36
        public async Task PowerOffAsync(string groupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            await Inner.PowerOffAsync(groupName, name, cancellationToken);
        }

        ///GENMHASH:9F1310A4445A183902C9AF672DA34354:83A472D7E09E0673F32CBA699DC15325
        public void PowerOff(string groupName, string name)
        {
            Extensions.Synchronize(() => this.Inner.PowerOffAsync(groupName, name));
        }

        ///GENMHASH:CD0E967F30C27C522C0DE3E4523C6CDD:8C9B139D9CD48BE89CACA8348E2E8469
        public async Task RestartAsync(string groupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            await Inner.RestartAsync(groupName, name, cancellationToken);
        }

        ///GENMHASH:CD0E967F30C27C522C0DE3E4523C6CDD:A8F52D851502AC1A4DED0213F947A99D
        public void Restart(string groupName, string name)
        {
            Extensions.Synchronize(() => this.Inner.RestartAsync(groupName, name));
        }

        ///GENMHASH:F5C1D0B90DEED77EE54F7CEB164C727E:4E2B451086A707DC66F26388A688071E
        public async Task StartAsync(string groupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            await Inner.StartAsync(groupName, name, cancellationToken);
        }

        ///GENMHASH:F5C1D0B90DEED77EE54F7CEB164C727E:C9C91090340AC7B92658ED0FECEB6F8F
        public void Start(string groupName, string name)
        {
            Extensions.Synchronize(() => this.Inner.StartAsync(groupName, name));
        }

        ///GENMHASH:5BA0ADF7CF4FCFD811B372F59A1C376E:0961DB2042C5E898ED8D9586E90E4F33
        public async Task RedeployAsync(string groupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            await Inner.RedeployAsync(groupName, name, cancellationToken);
        }

        ///GENMHASH:5BA0ADF7CF4FCFD811B372F59A1C376E:4FE4D054ADD4EAF10A50571AB9FC3FD0
        public void Redeploy(string groupName, string name)
        {
            Extensions.Synchronize(() => this.Inner.RedeployAsync(groupName, name));
        }

        ///GENMHASH:7DBF1DD4080EA265532035CF9FB8D313:1A99BFC30D31869BE5E39DD7E4E0639D
        public async Task MigrateToManagedAsync(string groupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            await Inner.ConvertToManagedDisksAsync(groupName, name, cancellationToken);
        }

        ///GENMHASH:7DBF1DD4080EA265532035CF9FB8D313:C9EA85EF9B4A5425DA3BF761D0D65796
        public void MigrateToManaged(string groupName, string name)
        {
            Extensions.Synchronize(() => this.Inner.ConvertToManagedDisksAsync(groupName, name));
        }

        ///GENMHASH:E5D7B16A7B6C705114CC71E8BB2B20E1:6975A84E6594FF8DEA88E6C992B0B500
        public async Task<string> CaptureAsync(
            string groupName, 
            string name, 
            string containerName, 
            string vhdPrefix, 
            bool overwriteVhd, 
            CancellationToken cancellationToken = default(CancellationToken))
        {
            VirtualMachineCaptureParametersInner parameters = new VirtualMachineCaptureParametersInner();
            parameters.DestinationContainerName = containerName;
            parameters.OverwriteVhds = overwriteVhd;
            parameters.VhdPrefix = vhdPrefix;
            VirtualMachineCaptureResultInner captureResult = await Inner.CaptureAsync(groupName, name, parameters, cancellationToken);
            return captureResult.Output.ToString();
        }

        ///GENMHASH:E5D7B16A7B6C705114CC71E8BB2B20E1:3352FEB5932DA51CF51CFE2F1E02A3C7
        public string Capture(string groupName, string name, string containerName, string vhdPrefix, bool overwriteVhd)
        {
            return Extensions.Synchronize(() => this.CaptureAsync(groupName, name, containerName, vhdPrefix, overwriteVhd));
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

            return new VirtualMachineImpl(
                name,
                inner,
                base.Manager,
                this.storageManager,
                this.networkManager, 
                this.rbacManager);
        }

        ///GENMHASH:7C70549803EBDDFC5C2F931D81D21F99:9ECCC2DACA9F6008FB5426B0426C7B1C
        protected override IVirtualMachine WrapModel(VirtualMachineInner virtualMachineInner)
        {
            return new VirtualMachineImpl(virtualMachineInner.Name,
                virtualMachineInner,
                base.Manager,
                this.storageManager,
                this.networkManager,
                this.rbacManager);
        }

        ///GENMHASH:AB63F782DA5B8D22523A284DAD664D17:7C0A1D0C3FE28C45F35B565F4AFF751D
        protected async override Task<VirtualMachineInner> GetInnerByGroupAsync(string groupName, string name, CancellationToken cancellationToken)
        {
            return await Inner.GetAsync(groupName, name, cancellationToken: cancellationToken);
        }
    }
}

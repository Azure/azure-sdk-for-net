// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information. 
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Resource.Fluent.Core.CollectionActions;
    using Network.Fluent;
    using Resource.Fluent.Core;
    using Storage.Fluent;
    using Management.Compute.Fluent;
    using Management.Compute.Fluent.Models;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Rest.Azure;

    /// <summary>
    /// The implementation for VirtualMachineScaleSets.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbXB1dGUuaW1wbGVtZW50YXRpb24uVmlydHVhbE1hY2hpbmVTY2FsZVNldHNJbXBs
    internal partial class VirtualMachineScaleSetsImpl  :
        GroupableResources<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet, Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetImpl, Models.VirtualMachineScaleSetInner, IVirtualMachineScaleSetsOperations, ComputeManager>,
        IVirtualMachineScaleSets
    {
        private IVirtualMachineScaleSetVMsOperations vmInstanceClient;
        private IStorageManager storageManager;
        private INetworkManager networkManager;
        ///GENMHASH:D153EE3A7098DCC0FDE502B79387242D:20D58C6F0677BACCE2BBFE4994C6C570
        internal VirtualMachineScaleSetsImpl (
            IVirtualMachineScaleSetsOperations client,
            IVirtualMachineScaleSetVMsOperations vmInstanceClient,
            ComputeManager computeManager,
            IStorageManager storageManager,
            INetworkManager networkManager) : base(client, computeManager)
        {
            this.vmInstanceClient = vmInstanceClient;
            this.storageManager = storageManager;
            this.networkManager = networkManager;
        }

        ///GENMHASH:95834C6C7DA388E666B705A62A7D02BF:3953AC722DFFCDF40E1EEF787AFD1326
        public PagedList<IVirtualMachineScaleSet> ListByGroup(string groupName)
        {
            IPage<VirtualMachineScaleSetInner> firstPage = InnerCollection.List(groupName);
            var pagedList = new PagedList<VirtualMachineScaleSetInner>(firstPage, (string nextPageLink) =>
            {
                return InnerCollection.ListNext(nextPageLink);
            });
            return WrapList(pagedList);
        }

        ///GENMHASH:7D6013E8B95E991005ED921F493EFCE4:36E25639805611CF89054C004B22BB15
        public PagedList<IVirtualMachineScaleSet> List()
        {
            IPage<VirtualMachineScaleSetInner> firstPage = InnerCollection.ListAll();
            var pagedList = new PagedList<VirtualMachineScaleSetInner>(firstPage, (string nextPageLink) =>
            {
                return InnerCollection.ListAllNext(nextPageLink);
            });
            return WrapList(pagedList);
        }

        ///GENMHASH:0679DF8CA692D1AC80FC21655835E678:B9B028D620AC932FDF66D2783E476B0D
        public override Task DeleteByGroupAsync(string groupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.InnerCollection.DeleteAsync(groupName,
                name,
                cancellationToken);
        }

        ///GENMHASH:AB63F782DA5B8D22523A284DAD664D17:7C0A1D0C3FE28C45F35B565F4AFF751D
        public async override Task<IVirtualMachineScaleSet> GetByGroupAsync(string groupName, string name, CancellationToken cancellationToken = default(CancellationToken))
        {
            var scaleSet = await this.InnerCollection.GetAsync(groupName, name, cancellationToken);
            return WrapModel(scaleSet);
        }

        ///GENMHASH:2048E8AC80AC022225C462CE7FD14A6F:AB513A3D7E5B1192B76F853CB23CBB12
        public void Deallocate(string groupName, string name)
        {
            this.InnerCollection.Deallocate(groupName, name);
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

        ///GENMHASH:4DBD1302C1BE61E6004FB18DA868020B:A8445E32081DE89D5D3DAD2DAAFEFB2F
        public void Reimage(string groupName, string name)
        {
            this.InnerCollection.Reimage(groupName, name);

        }

        ///GENMHASH:8ACFB0E23F5F24AD384313679B65F404:AD7C28D26EC1F237B93E54AD31899691
        public VirtualMachineScaleSetImpl Define(string name)
        {
            return WrapModel(name);
        }

        ///GENMHASH:2FE8C4C2D5EAD7E37787838DE0B47D92:27A03B2324B448752C7D390DCE29131C
        protected override VirtualMachineScaleSetImpl WrapModel(string name)
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
                this.vmInstanceClient,
                this.Manager,
                this.storageManager,
                this.networkManager);
        }

        ///GENMHASH:02DED088A2888BB795F0F3D5DD74F4BD:0CC380C02D012262305D81ABE5B0E53E
        protected override IVirtualMachineScaleSet WrapModel(VirtualMachineScaleSetInner inner)
        {
            return new VirtualMachineScaleSetImpl(inner.Name,
                inner,
                this.InnerCollection,
                this.vmInstanceClient,
                this.Manager,
                this.storageManager,
                this.networkManager);
        }
    }
}
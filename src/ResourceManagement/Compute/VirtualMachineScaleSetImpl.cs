// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Network.Fluent;
    using ResourceManager.Fluent;
    using ResourceManager.Fluent.Core;
    using ResourceManager.Fluent.Core.ResourceActions;
    using Storage.Fluent;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using VirtualMachineScaleSet.DefinitionManaged;
    using VirtualMachineScaleSet.DefinitionManagedOrUnmanaged;
    using VirtualMachineScaleSet.DefinitionUnmanaged;
    using VirtualMachineScaleSet.Update;
    using System.Threading;
    using Microsoft.Azure.Management.Graph.RBAC.Fluent;

    /// <summary>
    /// Implementation of VirtualMachineScaleSet.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbXB1dGUuaW1wbGVtZW50YXRpb24uVmlydHVhbE1hY2hpbmVTY2FsZVNldEltcGw=
    internal partial class VirtualMachineScaleSetImpl :
        GroupableParentResource<IVirtualMachineScaleSet,
            Models.VirtualMachineScaleSetInner,
            VirtualMachineScaleSetImpl,
            IComputeManager,
            VirtualMachineScaleSet.Definition.IWithGroup,
            VirtualMachineScaleSet.Definition.IWithSku,
            VirtualMachineScaleSet.Definition.IWithCreate,
            VirtualMachineScaleSet.Update.IWithApply>,
        IVirtualMachineScaleSet,
        IDefinitionManagedOrUnmanaged,
        IDefinitionManaged,
        IDefinitionUnmanaged,
        IUpdate,
        VirtualMachineScaleSet.Definition.IWithRoleAndScopeOrCreate,
        VirtualMachineScaleSet.Update.IWithRoleAndScopeOrApply
    {
        // Clients
        private IStorageManager storageManager;
        private INetworkManager networkManager;
        private IGraphRbacManager rbacManager;

        // used to generate unique name for any dependency resources
        private IResourceNamer namer;

        private bool isMarketplaceLinuxImage = false;

        // name of an existing subnet in the primary network to use
        private string existingPrimaryNetworkSubnetNameToAssociate;

        // unique key of a creatable storage accounts to be used for virtual machines child resources that
        // requires storage [OS disk]
        private List<string> creatableStorageAccountKeys = new List<string>();

        // reference to an existing storage account to be used for virtual machines child resources that
        // requires storage [OS disk]
        private List<IStorageAccount> existingStorageAccountsToAssociate = new List<IStorageAccount>();

        // Name of the container in the storage account to use to store the disks
        private string vhdContainerName;

        // the child resource extensions
        private IDictionary<string, IVirtualMachineScaleSetExtension> extensions;

        // reference to the primary and internal internet facing load balancer
        private ILoadBalancer primaryInternetFacingLoadBalancer;

        private ILoadBalancer primaryInternalLoadBalancer;

        // Load balancer specific variables used during update
        private bool removePrimaryInternetFacingLoadBalancerOnUpdate;

        private bool removePrimaryInternalLoadBalancerOnUpdate;
        private ILoadBalancer primaryInternetFacingLoadBalancerToAttachOnUpdate;
        private ILoadBalancer primaryInternalLoadBalancerToAttachOnUpdate;
        private List<string> primaryInternetFacingLBBackendsToRemoveOnUpdate = new List<string>();
        private List<string> primaryInternetFacingLBInboundNatPoolsToRemoveOnUpdate = new List<string>();
        private List<string> primaryInternalLBBackendsToRemoveOnUpdate = new List<string>();
        private List<string> primaryInternalLBInboundNatPoolsToRemoveOnUpdate = new List<string>();
        private List<string> primaryInternetFacingLBBackendsToAddOnUpdate = new List<string>();
        private List<string> primaryInternetFacingLBInboundNatPoolsToAddOnUpdate = new List<string>();
        private List<string> primaryInternalLBBackendsToAddOnUpdate = new List<string>();
        private List<string> primaryInternalLBInboundNatPoolsToAddOnUpdate = new List<string>();
        private bool isUnmanagedDiskSelected;
        private ManagedDataDiskCollection managedDataDisks;
        private VirtualMachineScaleSetMsiHelper virtualMachineScaleSetMsiHelper;

        ///GENMHASH:F0C80BE7722CB6620CCF10F060FE486B:C5CB976F0B76FD0A094017AD226F4439
        internal VirtualMachineScaleSetImpl(
            string name,
            VirtualMachineScaleSetInner innerModel,
            IComputeManager computeManager,
            IStorageManager storageManager,
            INetworkManager networkManager, 
            IGraphRbacManager rbacManager) : base(name, innerModel, computeManager)
        {
            this.storageManager = storageManager;
            this.networkManager = networkManager;
            this.rbacManager = rbacManager;
            this.namer = SdkContext.CreateResourceNamer(this.Name);
            this.managedDataDisks = new ManagedDataDiskCollection(this);
            this.virtualMachineScaleSetMsiHelper = new VirtualMachineScaleSetMsiHelper(rbacManager);
        }

        ///GENMHASH:AAC1F72971316317A21BEC14F977DEDE:ABC059395726B5D6BEB36206C2DDA144
        public VirtualMachineScaleSetImpl WithPrimaryInternetFacingLoadBalancerBackends(params string[] backendNames)
        {
            if (this.IsInCreateMode)
            {
                VirtualMachineScaleSetIPConfigurationInner defaultPrimaryIPConfig = this.PrimaryNicDefaultIPConfiguration();
                RemoveAllBackendAssociationFromIPConfiguration(this.primaryInternetFacingLoadBalancer, defaultPrimaryIPConfig);
                AssociateBackEndsToIPConfiguration(this.primaryInternetFacingLoadBalancer.Id,
                        defaultPrimaryIPConfig,
                        backendNames);
            }
            else
            {
                AddToList(this.primaryInternetFacingLBBackendsToAddOnUpdate, backendNames);
            }
            return this;
        }

        ///GENMHASH:42E5559F93A5ECA057CA5F045A1C8057:C9C1A747426C7D8AEF7280B613F858AE
        public IEnumerable<IVirtualMachineScaleSetNetworkInterface> ListNetworkInterfacesByInstanceId(string virtualMachineInstanceId)
        {
            return this.networkManager.NetworkInterfaces.ListByVirtualMachineScaleSetInstanceId(this.ResourceGroupName, this.Name, virtualMachineInstanceId);
        }

        ///GENMHASH:99E12A9D1F6C67E6350163C75A02C0CF:EB015A0D5BB20773EED2BA22F09DBFE4
        private static void RemoveLoadBalancerAssociationFromIPConfiguration(ILoadBalancer loadBalancer, VirtualMachineScaleSetIPConfigurationInner ipConfig)
        {
            RemoveAllBackendAssociationFromIPConfiguration(loadBalancer, ipConfig);
            RemoveAllInboundNatPoolAssociationFromIPConfiguration(loadBalancer, ipConfig);
        }

        ///GENMHASH:0B86CB1DFA370E0EF503AA943BA12699:72153688799C022C061CCB2A43E36DC0
        public VirtualMachineScaleSetImpl WithoutPrimaryInternetFacingLoadBalancer()
        {
            if (this.IsInUpdateMode())
            {
                this.removePrimaryInternetFacingLoadBalancerOnUpdate = true;
            }
            return this;
        }

        ///GENMHASH:8761D0D225B7C49A7A5025186E94B263:21AAF0008CE6CF3F9846F2DFE1CBEBCB
        public void PowerOff()
        {
            Management.ResourceManager.Fluent.Core.Extensions.Synchronize(() => Manager.Inner.VirtualMachineScaleSets.PowerOffAsync(ResourceGroupName, Name));
        }

        public async Task PowerOffAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await Manager.Inner.VirtualMachineScaleSets.PowerOffAsync(ResourceGroupName, Name, cancellationToken: cancellationToken);
        }

        ///GENMHASH:976BC0FCB9812014FA27474FCF6A694F:51AD565B2270FC1F9104F1A5BC632E24
        public VirtualMachineScaleSetImpl WithStoredLinuxImage(string imageUrl)
        {
            VirtualHardDisk userImageVhd = new VirtualHardDisk();
            userImageVhd.Uri = imageUrl;
            Inner
                    .VirtualMachineProfile
                    .StorageProfile.OsDisk.CreateOption = DiskCreateOptionTypes.FromImage;
            Inner
                    .VirtualMachineProfile
                    .StorageProfile.OsDisk.Image = userImageVhd;
            // For platform image osType will be null, azure will pick it from the image metadata.
            Inner
                    .VirtualMachineProfile
                    .StorageProfile.OsDisk.OsType = OperatingSystemTypes.Linux;
            Inner
                    .VirtualMachineProfile
                    .OsProfile.LinuxConfiguration = new LinuxConfiguration();
            return this;
        }

        ///GENMHASH:667E734583F577A898C6389A3D9F4C09:B1A3725E3B60B26D7F37CA7ABFE371B0
        public void Deallocate()
        {
            Management.ResourceManager.Fluent.Core.Extensions.Synchronize(() => Manager.Inner.VirtualMachineScaleSets.DeallocateAsync(this.ResourceGroupName, this.Name));
            Refresh();
        }

        public async Task DeallocateAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await Manager.Inner.VirtualMachineScaleSets.DeallocateAsync(this.ResourceGroupName, this.Name, cancellationToken: cancellationToken);
            await RefreshAsync(cancellationToken);
        }

        ///GENMHASH:5C1E5D4B34E988B57615D99543B65A28:FA6DEF6159D987B906C75A28496BD099
        public VirtualMachineScaleSetImpl WithOSDiskCaching(CachingTypes cachingType)
        {
            Inner
                .VirtualMachineProfile
                .StorageProfile.OsDisk.Caching = cachingType;
            return this;
        }

        ///GENMHASH:C8D0FD360C8F8A611F6F85F99CDE83D0:C73CD8C0F99ACCAB4E6C5579E1D974E4
        private static void RemoveAllInboundNatPoolAssociationFromIPConfiguration(ILoadBalancer loadBalancer, VirtualMachineScaleSetIPConfigurationInner ipConfig)
        {
            List<SubResource> toRemove = new List<SubResource>();
            foreach (SubResource subResource in ipConfig.LoadBalancerInboundNatPools)
            {
                if (subResource.Id.ToLower().StartsWith(loadBalancer.Id.ToLower() + "/"))
                {
                    toRemove.Add(subResource);
                }
            }
            foreach (SubResource subResource in toRemove)
            {
                ipConfig.LoadBalancerInboundNatPools.Remove(subResource);
            }
        }

        ///GENMHASH:FD824AC9D26C404162A9EEEE0B9A4489:B9DC6752667EC750602BB3CBA2F9F1A0
        public VirtualMachineScaleSetImpl WithPrimaryInternetFacingLoadBalancerInboundNatPools(params string[] natPoolNames)
        {
            if (this.IsInCreateMode)
            {
                VirtualMachineScaleSetIPConfigurationInner defaultPrimaryIPConfig = this.PrimaryNicDefaultIPConfiguration();
                RemoveAllInboundNatPoolAssociationFromIPConfiguration(this.primaryInternetFacingLoadBalancer,
                        defaultPrimaryIPConfig);
                AssociateInboundNatPoolsToIPConfiguration(this.primaryInternetFacingLoadBalancer.Id,
                        defaultPrimaryIPConfig,
                        natPoolNames);
            }
            else
            {
                AddToList(this.primaryInternetFacingLBInboundNatPoolsToAddOnUpdate, natPoolNames);
            }
            return this;
        }

        ///GENMHASH:2E38406EB22698CAE339875C7D4BDD7E:258FD1D5537E0DC025DC120D7BC231E2
        internal VirtualMachineScaleSetImpl WithUnmanagedDataDisk(VirtualMachineScaleSetUnmanagedDataDiskImpl unmanagedDisk)
        {
            if (Inner.VirtualMachineProfile.StorageProfile.DataDisks == null)
            {
                Inner
                .VirtualMachineProfile
                .StorageProfile
                .DataDisks = new List<VirtualMachineScaleSetDataDisk>();
            }
            IList<VirtualMachineScaleSetDataDisk> dataDisks = Inner
                .VirtualMachineProfile
                .StorageProfile
                .DataDisks;
            dataDisks.Add(unmanagedDisk.Inner);
            return this;
        }

        ///GENMHASH:123FF0223083F789E78E45771A759A9C:FFF894943EBDE56EEC0675ADF0891867
        public CachingTypes OSDiskCachingType()
        {
            return Inner.VirtualMachineProfile.StorageProfile.OsDisk.Caching.Value;
        }

        ///GENMHASH:C5EB453493B1100152604C49B4350246:13A96702474EC693EFE5444489CDEDCC
        public VirtualMachineScaleSetImpl WithOSDiskName(string name)
        {
            Inner
                .VirtualMachineProfile
                .StorageProfile.OsDisk.Name = name;
            return this;
        }

        ///GENMHASH:F792F6C8C594AA68FA7A0FCA92F55B55:CEAEE81352B41505EB71BF5E42D2A3B6
        public VirtualMachineScaleSetSkuTypes Sku()
        {
            return VirtualMachineScaleSetSkuTypes.FromSku(Inner.Sku);
        }

        ///GENMHASH:B2876749E60D892750D75C97943BBB13:00E375F5DFA1F92EE59D32432D8BB9AD
        public VirtualMachineScaleSetImpl WithSpecificLinuxImageVersion(ImageReference imageReference)
        {
            Inner
                .VirtualMachineProfile
                .StorageProfile.OsDisk.CreateOption = DiskCreateOptionTypes.FromImage;
            Inner
                .VirtualMachineProfile
                .StorageProfile.ImageReference = imageReference.Inner;
            Inner
                .VirtualMachineProfile
                .OsProfile.LinuxConfiguration = new LinuxConfiguration();
            this.isMarketplaceLinuxImage = true;
            return this;
        }

        ///GENMHASH:1E53238DF79E665335390B7452E9A04C:341F8A896942EC0102DC34824A8AED9B
        public VirtualMachineScaleSetImpl WithoutExtension(string name)
        {
            if (this.extensions.ContainsKey(name))
            {
                this.extensions.Remove(name);
            }
            return this;
        }

        /// <summary>
        /// Checks whether the OS disk is based on a stored image ('captured' or 'bring your own feature').
        /// </summary>
        /// <param name="storageProfile">The storage profile.</param>
        /// <return>True if the OS disk is configured to use custom image ('captured' or 'bring your own feature').</return>
        ///GENMHASH:013BB4FB645C080F536E8E117C28F1AD:B153E6EE63AB77BCE2C751BD7243E659
        private bool IsOSDiskFromStoredImage(VirtualMachineScaleSetStorageProfile storageProfile)
        {
            VirtualMachineScaleSetOSDisk osDisk = storageProfile.OsDisk;
            return IsOSDiskFromImage(osDisk)
                && osDisk.Image != null
            && osDisk.Image.Uri != null;
        }

        ///GENMHASH:E7610DABE1E75344D9E0DBC0332E7F96:92F04FC0178BF91F20DF542F454DC302
        public VirtualMachineScaleSetExtensionImpl UpdateExtension(string name)
        {
            IVirtualMachineScaleSetExtension value = null;
            if (!this.extensions.TryGetValue(name, out value))
            {
                throw new ArgumentException("Extension with name '" + name + "' not found");
            }
            return (VirtualMachineScaleSetExtensionImpl)value;
        }

        ///GENMHASH:F16446581B25DFD00E74CB1193EBF605:438AB79E7DABFF084F3F25050C0B0DCB
        public VirtualMachineScaleSetImpl WithoutVMAgent()
        {
            Inner
                .VirtualMachineProfile
                .OsProfile.WindowsConfiguration.ProvisionVMAgent = true;
            return this;
        }

        ///GENMHASH:ACFF159DD59B63FA783C8B3D4A7A36F5:86B1B0C90A3820575D5746DAF454199B
        public VirtualMachineScaleSetImpl WithExistingPrimaryNetworkSubnet(INetwork network, string subnetName)
        {
            this.existingPrimaryNetworkSubnetNameToAssociate = MergePath(network.Id, "subnets", subnetName);
            return this;
        }

        ///GENMHASH:C7EEDB0D031020E6FE0ADF5003AD9EF3:08412BF58A15F18D9122928A38242D9E
        public VirtualMachineScaleSetImpl WithoutPrimaryInternalLoadBalancer()
        {
            if (this.IsInUpdateMode())
            {
                this.removePrimaryInternalLoadBalancerOnUpdate = true;
            }
            return this;
        }

        ///GENMHASH:6E6D232E3678D03B3716EA09F0ADD0A9:660BA6BD38564D432FD56906D5F71954
        private static void RemoveBackendsFromIPConfiguration(string loadBalancerId, VirtualMachineScaleSetIPConfigurationInner ipConfig, params string[] backendNames)
        {
            List<SubResource> toRemove = new List<SubResource>();
            foreach (string backendName in backendNames)
            {
                string backendPoolId = MergePath(loadBalancerId, "backendAddressPools", backendName);
                foreach (SubResource subResource in ipConfig.LoadBalancerBackendAddressPools)
                {
                    if (subResource.Id.Equals(backendPoolId, StringComparison.OrdinalIgnoreCase))
                    {
                        toRemove.Add(subResource);
                        break;
                    }
                }
            }
            foreach (SubResource subResource in toRemove)
            {
                ipConfig.LoadBalancerBackendAddressPools.Remove(subResource);
            }
        }

        /// <summary>
        /// Checks whether the OS disk is based on an platform image (image in PIR).
        /// </summary>
        /// <param name="storageProfile">The storage profile.</param>
        /// <return>True if the OS disk is configured to be based on platform image.</return>
        ///GENMHASH:B4160179254ABD9C885CF5B824F69A10:8A0B58C5E0133CF29412CD658BAF8289
        private bool IsOSDiskFromPlatformImage(VirtualMachineScaleSetStorageProfile storageProfile)
        {
            ImageReferenceInner imageReference = storageProfile.ImageReference;
            return IsOSDiskFromImage(storageProfile.OsDisk)
                && imageReference != null
                && imageReference.Publisher != null
                && imageReference.Offer != null
                && imageReference.Sku != null
                && imageReference.Version != null;
        }

        ///GENMHASH:CD7DD8B4BD138F5F21FC2A082781B05E:DF7F973BA6DA44DB874A039E8656D907
        private void ThrowIfManagedDiskDisabled(string message)
        {
            if (!this.IsManagedDiskEnabled())
            {
                throw new NotSupportedException(message);
            }
        }

        ///GENMHASH:EC363135C0A3366C1FA98226F4AE5D05:894AACC37E5DFF8EECFF47C4ACFBFB70
        public IReadOnlyDictionary<string, Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetExtension> Extensions()
        {
            return this.extensions as IReadOnlyDictionary<string, Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetExtension>;
        }

        ///GENMHASH:EB45314951D6F0A225DF2E0CC4444647:31CE7DD3ED015A2C03AF72E95A38202E
        internal VirtualMachineScaleSetImpl WithExtension(VirtualMachineScaleSetExtensionImpl extension)
        {
            this.extensions.Add(extension.Name(), extension);
            return this;
        }

        ///GENMHASH:85147EF10797D4C57F7D765BDFEAE89E:65DEB6D772EFEFA23B2E9C18CCAB48DC
        public IReadOnlyList<string> PrimaryPublicIPAddressIds()
        {
            ILoadBalancer loadBalancer = (this as Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet).GetPrimaryInternetFacingLoadBalancer();
            if (loadBalancer != null)
            {
                return loadBalancer.PublicIPAddressIds;
            }
            return new List<string>();
        }

        /// <summary>
        /// Checks whether the OS disk is based on an image (image from PIR or custom image [captured, bringYourOwnFeature]).
        /// </summary>
        /// <param name="osDisk">The osDisk value in the storage profile.</param>
        /// <return>True if the OS disk is configured to use image from PIR or custom image.</return>
        ///GENMHASH:B97D8C3B1AC557A077AC173B1DB0B348:4CD85EE98AD4F7CBC33994D722986AE5
        private bool IsOSDiskFromImage(VirtualMachineScaleSetOSDisk osDisk)
        {
            return osDisk.CreateOption == DiskCreateOptionTypes.FromImage;
        }

        ///GENMHASH:062EA8E95730159A684C56D3DFCB4846:2E75CE480B794ADCA106E649FAD94DB6
        public UpgradeMode UpgradeModel()
        {
            return (Inner.UpgradePolicy != null) ? Inner.UpgradePolicy.Mode.Value : UpgradeMode.Automatic;
        }

        ///GENMHASH:B56D58DDB3B4EFB6D2FB8BFF6488E3FF:48A72DF34AA591EEC3FD96876F4C2258
        public IEnumerable<IVirtualMachineScaleSetNetworkInterface> ListNetworkInterfaces()
        {
            return this.networkManager.NetworkInterfaces.ListByVirtualMachineScaleSet(this.ResourceGroupName, this.Name);
        }

        ///GENMHASH:ADE83EE6665AFEEF1CA076067FC2BAB1:901C9A9B6E5CC49CB120EDA00E46E94E
        public IReadOnlyDictionary<string, Microsoft.Azure.Management.Network.Fluent.ILoadBalancerInboundNatPool> ListPrimaryInternalLoadBalancerInboundNatPools()
        {
            if ((this as Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet).GetPrimaryInternalLoadBalancer() != null)
            {
                return GetInboundNatPoolsAssociatedWithIPConfiguration(this.primaryInternalLoadBalancer,
                        PrimaryNicDefaultIPConfiguration());
            }
            return new Dictionary<string, ILoadBalancerInboundNatPool>();
        }

        ///GENMHASH:F0B439C5B2A4923B3B36B77503386DA7:B38C06867B5D878680004A07BD077546
        public int Capacity()
        {
            return (int)Inner.Sku.Capacity.Value;
        }

        ///GENMHASH:5357697C243DBDD2060BF2C164461C10:CCFD65A9998AF06471C50E7F44A70A67
        public VirtualMachineScaleSetImpl WithExistingPrimaryInternetFacingLoadBalancer(ILoadBalancer loadBalancer)
        {
            if (loadBalancer.PublicIPAddressIds.Count == 0)
            {
                throw new ArgumentException("Parameter loadBalancer must be an internet facing load balancer");
            }

            if (this.IsInCreateMode)
            {
                this.primaryInternetFacingLoadBalancer = loadBalancer;
                AssociateLoadBalancerToIPConfiguration(this.primaryInternetFacingLoadBalancer,
                        this.PrimaryNicDefaultIPConfiguration());
            }
            else
            {
                this.primaryInternetFacingLoadBalancerToAttachOnUpdate = loadBalancer;
            }
            return this;
        }

        ///GENMHASH:D7A14F2EFF1E4165DA55EF07B6C19534:7212B561D81BB0678D70A3F6EF38FA07
        public VirtualMachineScaleSetExtensionImpl DefineNewExtension(string name)
        {
            return new VirtualMachineScaleSetExtensionImpl(new Models.VirtualMachineScaleSetExtension { Name = name }, this);
        }

        ///GENMHASH:F2FFAF5448D7DFAFBE00130C62E87053:F7407CEA3D12779F169A4F2984ACFC2B
        public VirtualMachineScaleSetImpl WithRootPassword(string password)
        {
            Inner
                    .VirtualMachineProfile
                    .OsProfile
                    .AdminPassword = password;
            return this;
        }

        /// <summary>
        /// Checks whether the OS disk is based on a CustomImage.
        /// A custom image is represented by com.microsoft.azure.management.compute.VirtualMachineCustomImage.
        /// </summary>
        /// <param name="storageProfile">The storage profile.</param>
        /// <return>True if the OS disk is configured to be based on custom image.</return>
        ///GENMHASH:F53D85CC99C2482FBAB2FEB42F5A129A:F979E27E10A5C3D262E33101E3EF232A
        private bool IsOsDiskFromCustomImage(VirtualMachineScaleSetStorageProfile storageProfile)
        {
            ImageReferenceInner imageReference = storageProfile.ImageReference;
            return IsOSDiskFromImage(storageProfile.OsDisk)
                && imageReference != null
                && imageReference.Id != null;
        }

        ///GENMHASH:0ACBCB3C1F81BA37F134262122B79DA2:A4F154B483C36885CF45861AA9C1885F
        private void LoadCurrentPrimaryLoadBalancersIfAvailable()
        {
            if (this.primaryInternetFacingLoadBalancer != null && this.primaryInternalLoadBalancer != null)
            {
                return;
            }

            string firstLoadBalancerId = null;
            VirtualMachineScaleSetIPConfigurationInner ipConfig = PrimaryNicDefaultIPConfiguration();
            if (ipConfig.LoadBalancerBackendAddressPools.Count > 0)
            {
                firstLoadBalancerId = ResourceUtils
                        .ParentResourcePathFromResourceId(ipConfig.LoadBalancerBackendAddressPools.ElementAt(0).Id);
            }

            if (firstLoadBalancerId == null && ipConfig.LoadBalancerInboundNatPools.Count > 0)
            {
                firstLoadBalancerId = ResourceUtils
                        .ParentResourcePathFromResourceId(ipConfig.LoadBalancerInboundNatPools.ElementAt(0).Id);
            }

            if (firstLoadBalancerId == null)
            {
                return;
            }

            ILoadBalancer loadBalancer1 = this.networkManager
                .LoadBalancers
                .GetById(firstLoadBalancerId);
            if (loadBalancer1.PublicIPAddressIds != null && loadBalancer1.PublicIPAddressIds.Count > 0)
            {
                this.primaryInternetFacingLoadBalancer = loadBalancer1;
            }
            else
            {
                this.primaryInternalLoadBalancer = loadBalancer1;
            }

            string secondLoadBalancerId = null;
            foreach (SubResource subResource in ipConfig.LoadBalancerBackendAddressPools)
            {
                if (!subResource.Id.ToLower().StartsWith(firstLoadBalancerId.ToLower()))
                {
                    secondLoadBalancerId = ResourceUtils
                            .ParentResourcePathFromResourceId(subResource.Id);
                    break;
                }
            }

            if (secondLoadBalancerId == null)
            {
                foreach (SubResource subResource in ipConfig.LoadBalancerInboundNatPools)
                {
                    if (!subResource.Id.ToLower().StartsWith(firstLoadBalancerId.ToLower()))
                    {
                        secondLoadBalancerId = ResourceUtils
                                .ParentResourcePathFromResourceId(subResource.Id);
                        break;
                    }
                }
            }

            if (secondLoadBalancerId == null)
            {
                return;
            }

            ILoadBalancer loadBalancer2 = this.networkManager
            .LoadBalancers
            .GetById(secondLoadBalancerId);
            if (loadBalancer2.PublicIPAddressIds != null && loadBalancer2.PublicIPAddressIds.Count > 0)
            {
                this.primaryInternetFacingLoadBalancer = loadBalancer2;
            }
            else
            {
                this.primaryInternalLoadBalancer = loadBalancer2;
            }
        }

        ///GENMHASH:C9A8EFD03D810995DC8CE56B0EFD441D:E7976D224D54D6C1BB8B22CE27B71F44
        public VirtualMachineScaleSetImpl WithOverProvision(bool enabled)
        {
            Inner
                    .Overprovision = enabled;
            return this;
        }

        ///GENMHASH:1D38DD2A6D3BB89ECF81A51A4906BE8C:412BD8EB9EA1AA5A85C0515A53ACF43C
        public string ManagedServiceIdentityPrincipalId()
        {
            if (this.Inner.Identity != null)
            {
                return this.Inner.Identity.PrincipalId;
            }
            return null;
        }

        ///GENMHASH:9019C44FB9C28F62603D9972D45A9522:04EA2CF2FF84B5C44179285E14BA0FF0
        public bool IsManagedServiceIdentityEnabled()
        {
           return this.ManagedServiceIdentityPrincipalId() != null
            && this.ManagedServiceIdentityTenantId() != null;
        }

        ///GENMHASH:D19E7D61822C4048249EC4B57FA6F59B:E55E888BE3583ADCF1863F5A9DC47299
        public string ManagedServiceIdentityTenantId()
        {
            if (this.Inner.Identity != null)
            {
                return this.Inner.Identity.TenantId;
            }
            return null;
        }

        ///GENMHASH:E059E91FE0CBE4B6875986D1B46994D2:DAA85BBA01C168FF877DF34933F404C0
        public VirtualMachineScaleSetImpl WithManagedServiceIdentity()
        {
            this.virtualMachineScaleSetMsiHelper.WithManagedServiceIdentity(this.Inner);
            return this;
        }

        ///GENMHASH:D9244CA3B3398B7594B546247D593343:67897BA2A9EA709C2A4B86073D4D0171
        public VirtualMachineScaleSetImpl WithManagedServiceIdentity(int tokenPort)
        {
            this.virtualMachineScaleSetMsiHelper.WithManagedServiceIdentity(tokenPort, this.Inner);
            return this;
        }

        ///GENMHASH:DEF511724D2CC8CA91F24E084BC9AA22:B156E25B8F4ADB8DA7E762E9B3B26AA3
        public VirtualMachineScaleSetImpl WithRoleDefinitionBasedAccessTo(string scope, string roleDefinitionId)
        {
            this.virtualMachineScaleSetMsiHelper.WithRoleDefinitionBasedAccessTo(scope, roleDefinitionId);
            return this;
        }

        ///GENMHASH:F6C5721A84FA825F62951BE51537DD36:F9981224C9274380FA869CF773AE86FA
        public VirtualMachineScaleSetImpl WithRoleBasedAccessToCurrentResourceGroup(BuiltInRole asRole)
        {
            this.virtualMachineScaleSetMsiHelper.WithRoleBasedAccessToCurrentResourceGroup(asRole);
            return this;
        }

        ///GENMHASH:EFFF7ECD982913DB369E1EF1644031CB:818B408B1CD54C896CA7BA8C333687D3
        public VirtualMachineScaleSetImpl WithRoleBasedAccessTo(string scope, BuiltInRole asRole)
        {
            this.virtualMachineScaleSetMsiHelper.WithRoleBasedAccessTo(scope, asRole);
            return this;
        }

        ///GENMHASH:5FD7E26022EAFDACD062A87DDA8FD39A:D4ED935DBBDA2F0DA85365422E2FFCA8
        public VirtualMachineScaleSetImpl WithRoleDefinitionBasedAccessToCurrentResourceGroup(string roleDefinitionId)
        {
            this.virtualMachineScaleSetMsiHelper.WithRoleDefinitionBasedAccessToCurrentResourceGroup(roleDefinitionId);
            return this;
        }

        internal OperatingSystemTypes OSTypeIntern()
        {
            VirtualMachineScaleSetVMProfile vmProfile = this.Inner.VirtualMachineProfile;
            if (vmProfile != null
                    && vmProfile.StorageProfile != null
                    && vmProfile.StorageProfile.OsDisk != null
                    && vmProfile.StorageProfile.OsDisk.OsType != null)
            {
                return vmProfile.StorageProfile.OsDisk.OsType.Value;
            }
            if (vmProfile != null
                    && vmProfile.OsProfile != null)
            {
                if (vmProfile.OsProfile.LinuxConfiguration != null)
                {
                    return OperatingSystemTypes.Linux;
                }
                if (vmProfile.OsProfile.WindowsConfiguration != null)
                {
                    return OperatingSystemTypes.Windows;
                }
            }
            // This should never hit
            //
            throw new ArgumentException("Unable to resolve the operating system type");
        }

        ///GENMHASH:801A53D3DABA33CC92425D2203FD9242:023B6E0293C3EE52841DA58E9038A4E6
        private static IReadOnlyDictionary<string, Microsoft.Azure.Management.Network.Fluent.ILoadBalancerInboundNatPool> GetInboundNatPoolsAssociatedWithIPConfiguration(ILoadBalancer loadBalancer, VirtualMachineScaleSetIPConfigurationInner ipConfig)
        {
            String loadBalancerId = loadBalancer.Id;
            Dictionary<string, ILoadBalancerInboundNatPool> attachedInboundNatPools = new Dictionary<string, ILoadBalancerInboundNatPool>();
            var lbInboundNatPools = loadBalancer.InboundNatPools;
            foreach (ILoadBalancerInboundNatPool lbInboundNatPool in lbInboundNatPools.Values)
            {
                String inboundNatPoolId = MergePath(loadBalancerId, "inboundNatPools", lbInboundNatPool.Name);
                foreach (SubResource subResource in ipConfig.LoadBalancerInboundNatPools)
                {
                    if (subResource.Id.Equals(inboundNatPoolId, StringComparison.OrdinalIgnoreCase))
                    {
                        attachedInboundNatPools.Add(lbInboundNatPool.Name, lbInboundNatPool);
                    }
                }
            }
            return attachedInboundNatPools;
        }

        ///GENMHASH:98B10909018928720DBCCEBE53E08820:75A4D7D6FD5B54E56A4949AE30530D27
        public VirtualMachineScaleSetImpl WithoutAutoUpdate()
        {
            Inner
                    .VirtualMachineProfile
                    .OsProfile.WindowsConfiguration.EnableAutomaticUpdates = false;
            return this;
        }

        ///GENMHASH:AD16DA08B5E002AC14DA8E4DF1A29686:7CAC61F59FB870FA1BA64452A78CD17B
        private static void RemoveAllBackendAssociationFromIPConfiguration(ILoadBalancer loadBalancer, VirtualMachineScaleSetIPConfigurationInner ipConfig)
        {
            List<SubResource> toRemove = new List<SubResource>();
            foreach (SubResource subResource in ipConfig.LoadBalancerBackendAddressPools)
            {
                if (subResource.Id.ToLower().StartsWith(loadBalancer.Id.ToLower() + "/"))
                {
                    toRemove.Add(subResource);
                }
            }

            foreach (SubResource subResource in toRemove)
            {
                ipConfig.LoadBalancerBackendAddressPools.Remove(subResource);
            }
        }

        ///GENMHASH:27AD431A042600C45C4C0CA529477319:47186F09CC543669168F4089A11F6E5E
        private static void AssociateInboundNatPoolsToIPConfiguration(string loadBalancerId, VirtualMachineScaleSetIPConfigurationInner ipConfig, params string[] inboundNatPools)
        {
            List<SubResource> inboundNatPoolSubResourcesToAssociate = new List<SubResource>();
            foreach (string inboundNatPool in inboundNatPools)
            {
                string inboundNatPoolId = MergePath(loadBalancerId, "inboundNatPools", inboundNatPool);
                bool found = false;
                foreach (SubResource subResource in ipConfig.LoadBalancerInboundNatPools)
                {
                    if (subResource.Id.Equals(inboundNatPoolId, StringComparison.OrdinalIgnoreCase))
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    inboundNatPoolSubResourcesToAssociate.Add(new SubResource
                    {
                        Id = inboundNatPoolId
                    });
                }
            }
            foreach (SubResource backendSubResource in inboundNatPoolSubResourcesToAssociate)
            {
                ipConfig.LoadBalancerInboundNatPools.Add(backendSubResource);
            }
        }

        ///GENMHASH:5DCF4E29F6EA4E300D272317D5090075:2CECE7F3DC203120ADD63663E7930758
        private static void RemoveInboundNatPoolsFromIPConfiguration(string loadBalancerId, VirtualMachineScaleSetIPConfigurationInner ipConfig, params string[] inboundNatPoolNames)
        {
            List<SubResource> toRemove = new List<SubResource>();
            foreach (string natPoolName in inboundNatPoolNames)
            {
                string inboundNatPoolId = MergePath(loadBalancerId, "inboundNatPools", natPoolName);
                foreach (SubResource subResource in ipConfig.LoadBalancerInboundNatPools)
                {
                    if (subResource.Id.Equals(inboundNatPoolId, StringComparison.OrdinalIgnoreCase))
                    {
                        toRemove.Add(subResource);
                        break;
                    }
                }
            }
            foreach (SubResource subResource in toRemove)
            {
                ipConfig.LoadBalancerInboundNatPools.Remove(subResource);
            }
        }

        ///GENMHASH:08CFC096AC6388D1C0E041ECDF099E3D:4479808A1E2B2A23538E662AD3F721EE
        public void Restart()
        {
            Management.ResourceManager.Fluent.Core.Extensions.Synchronize(() => Manager.Inner.VirtualMachineScaleSets.RestartAsync(this.ResourceGroupName, this.Name));
        }

        public async Task RestartAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await Manager.Inner.VirtualMachineScaleSets.RestartAsync(this.ResourceGroupName, this.Name, cancellationToken: cancellationToken);
        }

        ///GENMHASH:5880487AA9218E8DF536932A49A0ACDD:35850B81E88D88D68766589B9671E590
        public VirtualMachineScaleSetImpl WithNewStorageAccount(string name)
        {
            Storage.Fluent.StorageAccount.Definition.IWithGroup definitionWithGroup = this.storageManager
                    .StorageAccounts
                    .Define(name)
                    .WithRegion(this.RegionName);
            ICreatable<IStorageAccount> definitionAfterGroup;
            if (this.newGroup != null)
            {
                definitionAfterGroup = definitionWithGroup.WithNewResourceGroup(this.newGroup);
            }
            else
            {
                definitionAfterGroup = definitionWithGroup.WithExistingResourceGroup(this.ResourceGroupName);
            }
            return WithNewStorageAccount(definitionAfterGroup);
        }

        ///GENMHASH:2DC51FEC3C45675856B4AC1D97BECBFD:625251347BC517ED9D6E5D9755FBF00B
        public VirtualMachineScaleSetImpl WithNewStorageAccount(ICreatable<Microsoft.Azure.Management.Storage.Fluent.IStorageAccount> creatable)
        {
            this.creatableStorageAccountKeys.Add(creatable.Key);
            this.AddCreatableDependency(creatable as IResourceCreator<Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasId>);
            return this;
        }

        ///GENMHASH:F91F57741BB7E185BF012523964DEED0:89445F7853BF795F5610E29A0AD00373
        protected override void AfterCreating()
        {
            this.ClearCachedProperties();
            this.InitializeChildrenFromInner();
        }

        ///GENMHASH:4002186478A1CB0B59732EBFB18DEB3A:9A047B4B22E09AEB6344D4F23EC361E5
        public override async Task<IVirtualMachineScaleSet> RefreshAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var response = await GetInnerAsync(cancellationToken);
            SetInner(response);
            ClearCachedProperties();
            InitializeChildrenFromInner();
            return this;
        }

        protected override async Task<VirtualMachineScaleSetInner> GetInnerAsync(CancellationToken cancellationToken)
        {
            return await Manager.Inner.VirtualMachineScaleSets.GetAsync(ResourceGroupName, Name, cancellationToken: cancellationToken);
        }

        ///GENMHASH:0B0C2470711F6450D4872789FDEB62A0:27733295CC242C366636316AC58FC2D3
        private VirtualMachineScaleSetDataDisk GetDataDiskInner(int lun)
        {
            VirtualMachineScaleSetStorageProfile storageProfile = this
                .Inner
                .VirtualMachineProfile
                .StorageProfile;
            IList<VirtualMachineScaleSetDataDisk> dataDisks = storageProfile
                .DataDisks;
            if (dataDisks == null)
            {
                return null;
            }
            foreach (var dataDisk in dataDisks)
            {
                if (dataDisk.Lun == lun)
                {
                    return dataDisk;
                }
            }
            return null;
        }

        ///GENMHASH:F074773AE211BBEB7F46B598EA72155B:7704FB8C0D7ED4D767CE8138EA441588
        public VirtualMachineScaleSetImpl WithExistingPrimaryInternalLoadBalancer(ILoadBalancer loadBalancer)
        {
            if (loadBalancer.PublicIPAddressIds.Count != 0)
            {
                throw new ArgumentException("Parameter loadBalancer must be an internal load balancer");
            }
            string lbNetworkId = null;
            foreach (ILoadBalancerPrivateFrontend frontEnd in loadBalancer.PrivateFrontends.Values)
            {
                if (frontEnd.NetworkId != null)
                {
                    lbNetworkId = frontEnd.NetworkId;
                }
            }

            if (this.IsInCreateMode)
            {
                string vmNICNetworkId = ResourceUtils.ParentResourcePathFromResourceId(this.existingPrimaryNetworkSubnetNameToAssociate);
                // Azure has a really wired BUG that - it throws exception when vnet of VMSS and LB are not same
                // (code: NetworkInterfaceAndInternalLoadBalancerMustUseSameVnet) but at the same time Azure update
                // the VMSS's network section to refer this invalid internal LB. This makes VMSS un-usable and portal
                // will show a error above VMSS profile page.
                //
                if (!vmNICNetworkId.Equals(lbNetworkId, StringComparison.OrdinalIgnoreCase))
                {
                    throw new ArgumentException("Virtual network associated with scale set virtual machines"
                            + " and internal load balancer must be same. "
                            + "'" + vmNICNetworkId + "'"
                            + "'" + lbNetworkId);
                }

                this.primaryInternalLoadBalancer = loadBalancer;
                AssociateLoadBalancerToIPConfiguration(this.primaryInternalLoadBalancer,
                        this.PrimaryNicDefaultIPConfiguration());
            }
            else
            {
                string vmNicVnetId = ResourceUtils.ParentResourcePathFromResourceId(PrimaryNicDefaultIPConfiguration()
                        .Subnet
                        .Id);
                if (!vmNicVnetId.Equals(lbNetworkId, StringComparison.OrdinalIgnoreCase))
                {
                    throw new ArgumentException("Virtual network associated with scale set virtual machines"
                            + " and internal load balancer must be same. "
                            + "'" + vmNicVnetId + "'"
                            + "'" + lbNetworkId);
                }
                this.primaryInternalLoadBalancerToAttachOnUpdate = loadBalancer;
            }
            return this;
        }

        ///GENMHASH:89EFB8F9AFBDF98FFAD5606983F59A03:E986803721702DC6EF28DDC04CC96CD1
        public VirtualMachineScaleSetImpl WithNewDataDiskFromImage(int imageLun)
        {
            this.managedDataDisks.newDisksFromImage.Add(new VirtualMachineScaleSetDataDisk()
            {
                Lun = imageLun
            });
            return this;
        }

        ///GENMHASH:92519C2F478984EF05C22A5573361AFE:D60066031CF6D3EF0D84A196BD186C4C
        public VirtualMachineScaleSetImpl WithNewDataDiskFromImage(int imageLun, int newSizeInGB, CachingTypes cachingType)
        {
            this.managedDataDisks.newDisksFromImage.Add(new VirtualMachineScaleSetDataDisk()
            {
                Lun = imageLun,
                DiskSizeGB = newSizeInGB,
                Caching = cachingType
            });
            return this;
        }

        ///GENMHASH:BABD7F4E5FDF4ECA60DB2F163B33F4C7:70147D65554CF848675D35124D742DB0
        public VirtualMachineScaleSetImpl WithNewDataDiskFromImage(int imageLun, int newSizeInGB, CachingTypes cachingType, StorageAccountTypes storageAccountType)
        {
            VirtualMachineScaleSetManagedDiskParameters managedDiskParameters = new VirtualMachineScaleSetManagedDiskParameters();
            managedDiskParameters.StorageAccountType = storageAccountType;
            this.managedDataDisks.newDisksFromImage.Add(new VirtualMachineScaleSetDataDisk()
            {
                Lun = imageLun,
                DiskSizeGB = newSizeInGB,
                ManagedDisk = managedDiskParameters,
                Caching = cachingType
            });
            return this;
        }

        ///GENMHASH:7F0A9CB4CB6BBC98F72CF50A81EBFBF4:3C12806E439FD7F02ABD5EEE521A9AB0
        public VirtualMachineScaleSetStorageProfile StorageProfile()
        {
            return Inner.VirtualMachineProfile.StorageProfile;
        }

        ///GENMHASH:3874257232804C74BD7501DE2BE2F0E9:D48844CD7D7EEEF909BD7006D3A7E439
        public VirtualMachineScaleSetImpl WithLatestWindowsImage(string publisher, string offer, string sku)
        {
            ImageReference imageReference = new ImageReference()
            {
                Publisher = publisher,
                Offer = offer,
                Sku = sku,
                Version = "latest"
            };
            return WithSpecificWindowsImageVersion(imageReference);
        }

        ///GENMHASH:2127E32A8F02C513138DB1208F98C806:1DD59433AF6ED9834170252D06569286
        public IReadOnlyDictionary<string, Microsoft.Azure.Management.Network.Fluent.ILoadBalancerInboundNatPool> ListPrimaryInternetFacingLoadBalancerInboundNatPools()
        {
            if ((this as Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet).GetPrimaryInternetFacingLoadBalancer() != null)
            {
                return GetInboundNatPoolsAssociatedWithIPConfiguration(this.primaryInternetFacingLoadBalancer,
                        PrimaryNicDefaultIPConfiguration());
            }
            return new Dictionary<string, ILoadBalancerInboundNatPool>();
        }

        ///GENMHASH:8CB9B7EEE4A4226A6F5BBB2958CC5E81:A9181EF01C6B9C8C3CB92E9F535B6236
        public VirtualMachineScaleSetImpl WithExistingStorageAccount(IStorageAccount storageAccount)
        {
            this.existingStorageAccountsToAssociate.Add(storageAccount);
            return this;
        }

        ///GENMHASH:3DF1B6140B6B4ECBFA96FE642F2CD144:CCED3778DD625697E59E50F8F58EAFD7
        public VirtualMachineScaleSetImpl WithPrimaryInternalLoadBalancerBackends(params string[] backendNames)
        {
            if (this.IsInCreateMode)
            {
                VirtualMachineScaleSetIPConfigurationInner defaultPrimaryIPConfig = PrimaryNicDefaultIPConfiguration();
                RemoveAllBackendAssociationFromIPConfiguration(this.primaryInternalLoadBalancer,
                        defaultPrimaryIPConfig);
                AssociateBackEndsToIPConfiguration(this.primaryInternalLoadBalancer.Id,
                        defaultPrimaryIPConfig,
                        backendNames);
            }
            else
            {
                AddToList(this.primaryInternalLBBackendsToAddOnUpdate, backendNames);
            }
            return this;
        }

        ///GENMHASH:F24EFD30F0D04113B41EA2C36B55F059:9662F39CFDAE2D5E028F6D055A529B1F
        public VirtualMachineScaleSetImpl WithWindowsCustomImage(string customImageId)
        {
            ImageReferenceInner imageReferenceInner = new ImageReferenceInner();
            imageReferenceInner.Id = customImageId;
            Inner
                .VirtualMachineProfile
                .StorageProfile.OsDisk.CreateOption = DiskCreateOptionTypes.FromImage;
            Inner
                .VirtualMachineProfile
                .StorageProfile.ImageReference = imageReferenceInner;
            Inner
                .VirtualMachineProfile
                .OsProfile.WindowsConfiguration = new WindowsConfiguration();
            // sets defaults for "Stored(Custom)Image" or "VM(Platform)Image"
            Inner
                .VirtualMachineProfile
                .OsProfile.WindowsConfiguration.ProvisionVMAgent = true;
            Inner
                .VirtualMachineProfile
                .OsProfile.WindowsConfiguration.EnableAutomaticUpdates = true;
            return this;
        }

        ///GENMHASH:90924DCFADE551C6E90B738982E6C2F7:8E8BCFD08143E85B586E9D48D32AF4E0
        public VirtualMachineScaleSetImpl WithOSDiskStorageAccountType(StorageAccountTypes accountType)
        {
            this.managedDataDisks.SetDefaultStorageAccountType(accountType);
            return this;
        }

        ///GENMHASH:1BBF95374A03EFFD0583730762AB8753:657393D43CB30B9E2DA291459E17BAD9
        public VirtualMachineScaleSetImpl WithTimeZone(string timeZone)
        {
            Inner
                    .VirtualMachineProfile
                    .OsProfile.WindowsConfiguration.TimeZone = timeZone;
            return this;
        }

        ///GENMHASH:E50F40651A5B1AF20BC79D94DD871BC0:8D097652777E7CA886C41C25ADBEAA28
        private static string MergePath(params string[] segments)
        {
            StringBuilder builder = new StringBuilder();
            foreach (string segment in segments)
            {
                string tmp = segment;
                while (tmp.Length > 1 && tmp.EndsWith("/"))
                {
                    tmp = tmp.Substring(0, tmp.Length - 1);
                }

                if (tmp.Length > 0)
                {
                    builder.Append(tmp);
                    builder.Append("/");
                }
            }

            string merged = builder.ToString();
            if (merged.EndsWith("/"))
            {
                merged = merged.Substring(0, merged.Length - 1);
            }
            return merged;
        }

        ///GENMHASH:CE03CDBD07CA3BD7500B36B206A91A4A:592F5357F294A567BF101FAB341C6CCA
        public VirtualMachineScaleSetImpl WithLinuxCustomImage(string customImageId)
        {
            ImageReferenceInner imageReferenceInner = new ImageReferenceInner();
            imageReferenceInner.Id = customImageId;
            Inner
                .VirtualMachineProfile
                .StorageProfile.OsDisk.CreateOption = DiskCreateOptionTypes.FromImage;
            Inner
                .VirtualMachineProfile
                .StorageProfile.ImageReference = imageReferenceInner;
            Inner
                .VirtualMachineProfile
                .OsProfile.LinuxConfiguration = new LinuxConfiguration();
            this.isMarketplaceLinuxImage = true;
            return this;
        }

        ///GENMHASH:2582ED197AB392F5EC837F6BC8FE2FF0:29B4432F98CD641D0280C31D00CAFB2D
        private void SetPrimaryIPConfigurationBackendsAndInboundNatPools()
        {
            if (this.IsInCreateMode)
            {
                return;
            }

            this.LoadCurrentPrimaryLoadBalancersIfAvailable();

            VirtualMachineScaleSetIPConfigurationInner primaryIPConfig = PrimaryNicDefaultIPConfiguration();
            if (this.primaryInternetFacingLoadBalancer != null)
            {
                RemoveBackendsFromIPConfiguration(this.primaryInternetFacingLoadBalancer.Id,
                        primaryIPConfig,
                        this.primaryInternetFacingLBBackendsToRemoveOnUpdate.ToArray());

                AssociateBackEndsToIPConfiguration(primaryInternetFacingLoadBalancer.Id,
                        primaryIPConfig,
                        this.primaryInternetFacingLBBackendsToAddOnUpdate.ToArray());

                RemoveInboundNatPoolsFromIPConfiguration(this.primaryInternetFacingLoadBalancer.Id,
                        primaryIPConfig,
                        this.primaryInternetFacingLBInboundNatPoolsToRemoveOnUpdate.ToArray());

                AssociateInboundNatPoolsToIPConfiguration(primaryInternetFacingLoadBalancer.Id,
                        primaryIPConfig,
                        this.primaryInternetFacingLBInboundNatPoolsToAddOnUpdate.ToArray());
            }

            if (this.primaryInternalLoadBalancer != null)
            {
                RemoveBackendsFromIPConfiguration(this.primaryInternalLoadBalancer.Id,
                        primaryIPConfig,
                        this.primaryInternalLBBackendsToRemoveOnUpdate.ToArray());

                AssociateBackEndsToIPConfiguration(primaryInternalLoadBalancer.Id,
                        primaryIPConfig,
                        this.primaryInternalLBBackendsToAddOnUpdate.ToArray());

                RemoveInboundNatPoolsFromIPConfiguration(this.primaryInternalLoadBalancer.Id,
                        primaryIPConfig,
                        this.primaryInternalLBInboundNatPoolsToRemoveOnUpdate.ToArray());

                AssociateInboundNatPoolsToIPConfiguration(primaryInternalLoadBalancer.Id,
                        primaryIPConfig,
                        this.primaryInternalLBInboundNatPoolsToAddOnUpdate.ToArray());
            }

            if (this.removePrimaryInternetFacingLoadBalancerOnUpdate)
            {
                if (this.primaryInternetFacingLoadBalancer != null)
                {
                    RemoveLoadBalancerAssociationFromIPConfiguration(this.primaryInternetFacingLoadBalancer, primaryIPConfig);
                }
            }

            if (this.removePrimaryInternalLoadBalancerOnUpdate)
            {
                if (this.primaryInternalLoadBalancer != null)
                {
                    RemoveLoadBalancerAssociationFromIPConfiguration(this.primaryInternalLoadBalancer, primaryIPConfig);
                }
            }

            if (this.primaryInternetFacingLoadBalancerToAttachOnUpdate != null)
            {
                if (this.primaryInternetFacingLoadBalancer != null)
                {
                    RemoveLoadBalancerAssociationFromIPConfiguration(this.primaryInternetFacingLoadBalancer, primaryIPConfig);
                }
                AssociateLoadBalancerToIPConfiguration(this.primaryInternetFacingLoadBalancerToAttachOnUpdate, primaryIPConfig);
                if (this.primaryInternetFacingLBBackendsToAddOnUpdate.Count > 0)
                {
                    RemoveAllBackendAssociationFromIPConfiguration(this.primaryInternetFacingLoadBalancerToAttachOnUpdate, primaryIPConfig);
                    AssociateBackEndsToIPConfiguration(this.primaryInternetFacingLoadBalancerToAttachOnUpdate.Id,
                            primaryIPConfig,
                            this.primaryInternetFacingLBBackendsToAddOnUpdate.ToArray());
                }
                if (this.primaryInternetFacingLBInboundNatPoolsToAddOnUpdate.Count > 0)
                {
                    RemoveAllInboundNatPoolAssociationFromIPConfiguration(this.primaryInternetFacingLoadBalancerToAttachOnUpdate, primaryIPConfig);
                    AssociateInboundNatPoolsToIPConfiguration(this.primaryInternetFacingLoadBalancerToAttachOnUpdate.Id,
                            primaryIPConfig,
                            this.primaryInternetFacingLBInboundNatPoolsToAddOnUpdate.ToArray());
                }
            }

            if (this.primaryInternalLoadBalancerToAttachOnUpdate != null)
            {
                if (this.primaryInternalLoadBalancer != null)
                {
                    RemoveLoadBalancerAssociationFromIPConfiguration(this.primaryInternalLoadBalancer, primaryIPConfig);
                }
                AssociateLoadBalancerToIPConfiguration(this.primaryInternalLoadBalancerToAttachOnUpdate, primaryIPConfig);
                if (this.primaryInternalLBBackendsToAddOnUpdate.Count > 0)
                {
                    RemoveAllBackendAssociationFromIPConfiguration(this.primaryInternalLoadBalancerToAttachOnUpdate, primaryIPConfig);
                    AssociateBackEndsToIPConfiguration(this.primaryInternalLoadBalancerToAttachOnUpdate.Id,
                            primaryIPConfig,
                            this.primaryInternalLBBackendsToAddOnUpdate.ToArray());
                }

                if (this.primaryInternalLBInboundNatPoolsToAddOnUpdate.Count > 0)
                {
                    RemoveAllInboundNatPoolAssociationFromIPConfiguration(this.primaryInternalLoadBalancerToAttachOnUpdate, primaryIPConfig);
                    AssociateInboundNatPoolsToIPConfiguration(this.primaryInternalLoadBalancerToAttachOnUpdate.Id,
                            primaryIPConfig,
                            this.primaryInternalLBInboundNatPoolsToAddOnUpdate.ToArray());
                }
            }

            this.removePrimaryInternetFacingLoadBalancerOnUpdate = false;
            this.removePrimaryInternalLoadBalancerOnUpdate = false;
            this.primaryInternetFacingLoadBalancerToAttachOnUpdate = null;
            this.primaryInternalLoadBalancerToAttachOnUpdate = null;
            this.primaryInternetFacingLBBackendsToRemoveOnUpdate.Clear();
            this.primaryInternetFacingLBInboundNatPoolsToRemoveOnUpdate.Clear();
            this.primaryInternalLBBackendsToRemoveOnUpdate.Clear();
            this.primaryInternalLBInboundNatPoolsToRemoveOnUpdate.Clear();
            this.primaryInternetFacingLBBackendsToAddOnUpdate.Clear();
            this.primaryInternetFacingLBInboundNatPoolsToAddOnUpdate.Clear();
            this.primaryInternalLBBackendsToAddOnUpdate.Clear();
            this.primaryInternalLBInboundNatPoolsToAddOnUpdate.Clear();
        }

        ///GENMHASH:B532EFEBE670EE3FA1185DA0A91F40B5:4C1AD969AF53405CB7FB7BF930887497
        private void ClearCachedProperties()
        {
            this.primaryInternetFacingLoadBalancer = null;
            this.primaryInternalLoadBalancer = null;
        }

        ///GENMHASH:33905CDEAEEF3BB750202A2D6D557629:DB1E6EAD0CBA02A64BE5E2EE1AE862FC
        public bool OverProvisionEnabled()
        {
            return Inner.Overprovision.Value;
        }

        ///GENMHASH:AFF08018A4055EA21949F6479B3BCCA0:4175296A99E4DC787679DF89D1FABCD5
        public VirtualMachineScaleSetNetworkProfile NetworkProfile()
        {
            return Inner.VirtualMachineProfile.NetworkProfile;
        }

        ///GENMHASH:408E3AC8FC1959B99618665484BFE199:6DCFB156DC060B1BEBD0F007DDD76D62
        private void SetOSDiskDefault()
        {
            if (IsInUpdateMode())
            {
                return;
            }
            VirtualMachineScaleSetStorageProfile storageProfile = Inner.VirtualMachineProfile.StorageProfile;
            VirtualMachineScaleSetOSDisk osDisk = storageProfile.OsDisk;
            if (IsOSDiskFromImage(osDisk))
            {
                // ODDisk CreateOption: FROM_IMAGE
                //
                if (IsManagedDiskEnabled())
                {
                    // Note:
                    // Managed disk
                    //     Supported: PlatformImage and CustomImage
                    //     UnSupported: StoredImage
                    //
                    if (osDisk.ManagedDisk == null)
                    {
                        osDisk.ManagedDisk = new VirtualMachineScaleSetManagedDiskParameters();
                    }
                    if (osDisk.ManagedDisk.StorageAccountType == null)
                    {
                        osDisk.ManagedDisk
                            .StorageAccountType = StorageAccountTypes.StandardLRS;
                    }
                    osDisk.VhdContainers = null;
                    // We won't set osDisk.Name() explicitly for managed disk, if it is null CRP generates unique
                    // name for the disk resource within the resource group.
                }
                else
                {
                    // Note:
                    // Native (un-managed) disk
                    //     Supported: PlatformImage and StoredImage
                    //     UnSupported: CustomImage
                    //
                    osDisk.ManagedDisk = null;
                    if (osDisk.Name == null)
                    {
                        WithOSDiskName(this.Name + "-os-disk");
                    }
                }
            }
            else
            {
                // NOP [ODDisk CreateOption: ATTACH, ATTACH is not supported for VMSS]
            }
            if (Inner.VirtualMachineProfile.StorageProfile.OsDisk.Caching == null)
            {
                WithOSDiskCaching(CachingTypes.ReadWrite);
            }
        }

        ///GENMHASH:8FDBCB5DF6AFD1594DF170521CE46D5F:4DF21C8BC272D1C368C4F1F79237B3D0
        public VirtualMachineScaleSetImpl WithPopularWindowsImage(KnownWindowsVirtualMachineImage knownImage)
        {
            return WithSpecificWindowsImageVersion(knownImage.ImageReference());
        }

        ///GENMHASH:8371720B72164AB21B88202FD4561610:9ECD956712FBC7CB9A976884F3BEAB45
        public IReadOnlyDictionary<string, Microsoft.Azure.Management.Network.Fluent.ILoadBalancerBackend> ListPrimaryInternetFacingLoadBalancerBackends()
        {
            if ((this as Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet).GetPrimaryInternetFacingLoadBalancer() != null)
            {
                return GetBackendsAssociatedWithIPConfiguration(this.primaryInternetFacingLoadBalancer,
                        PrimaryNicDefaultIPConfiguration());
            }
            return new Dictionary<string, ILoadBalancerBackend>();
        }

        ///GENMHASH:5810786355B161A5CD254C9E3BE76524:F7407CEA3D12779F169A4F2984ACFC2B
        public VirtualMachineScaleSetImpl WithAdminPassword(string password)
        {
            Inner
                    .VirtualMachineProfile
                    .OsProfile
                    .AdminPassword = password;
            return this;
        }

        ///GENMHASH:83A8BCB96B7881DAF693D324E0E9BAAE:83FB521120A40493EBC9C3BFCC730829
        public ILoadBalancer GetPrimaryInternetFacingLoadBalancer()
        {
            if (this.primaryInternetFacingLoadBalancer == null)
            {
                LoadCurrentPrimaryLoadBalancersIfAvailable();
            }
            return this.primaryInternetFacingLoadBalancer;
        }

        ///GENMHASH:B899054CADDD4C764670C53E2A300590:038D6D03640016D71036DDBF325D8E0F
        public VirtualMachineScaleSetImpl WithoutPrimaryInternetFacingLoadBalancerNatPools(params string[] natPoolNames)
        {
            AddToList(this.primaryInternetFacingLBInboundNatPoolsToRemoveOnUpdate, natPoolNames);
            return this;
        }

        ///GENMHASH:9BBA27913235B4504FD9F07549E645CC:0BF9F49BB572288259C5C2CF97915D33
        public VirtualMachineScaleSetImpl WithSsh(string publicKeyData)
        {
            VirtualMachineScaleSetOSProfile osProfile = Inner
                    .VirtualMachineProfile
                    .OsProfile;
            if (osProfile.LinuxConfiguration.Ssh == null)
            {
                SshConfiguration sshConfiguration = new SshConfiguration();
                sshConfiguration.PublicKeys = new List<SshPublicKey>();
                osProfile.LinuxConfiguration.Ssh = sshConfiguration;
            }
            SshPublicKey sshPublicKey = new SshPublicKey();
            sshPublicKey.KeyData = publicKeyData;
            sshPublicKey.Path = "/home/" + osProfile.AdminUsername + "/.ssh/authorized_keys";
            osProfile.LinuxConfiguration.Ssh.PublicKeys.Add(sshPublicKey);
            return this;
        }

        ///GENMHASH:864D8E4C8CD2E86906490FEDA8FB3F2B:8DBC7BDC302D2B4665D3623CB5CE6F9B
        private static IReadOnlyDictionary<string, Microsoft.Azure.Management.Network.Fluent.ILoadBalancerBackend> GetBackendsAssociatedWithIPConfiguration(ILoadBalancer loadBalancer, VirtualMachineScaleSetIPConfigurationInner ipConfig)
        {
            string loadBalancerId = loadBalancer.Id;
            Dictionary<string, ILoadBalancerBackend> attachedBackends = new Dictionary<string, ILoadBalancerBackend>();
            var lbBackends = loadBalancer.Backends;
            foreach (ILoadBalancerBackend lbBackend in lbBackends.Values)
            {
                string backendId = MergePath(loadBalancerId, "backendAddressPools", lbBackend.Name);
                foreach (SubResource subResource in ipConfig.LoadBalancerBackendAddressPools)
                {
                    if (subResource.Id.Equals(backendId, StringComparison.OrdinalIgnoreCase))
                    {
                        attachedBackends.Add(lbBackend.Name, lbBackend);
                    }
                }
            }
            return attachedBackends;
        }

        ///GENMHASH:38EF4A7AB82168A6DD38F533747DA9D5:362113C4E307F07B620E363B30115839
        public string ComputerNamePrefix()
        {
            return Inner.VirtualMachineProfile.OsProfile.ComputerNamePrefix;
        }

        ///GENMHASH:44218FC054E9DD430ECE7417A9705EB2:2DB39ADE66ABE6DB110EEDB9C63E2DB3
        public VirtualMachineScaleSetImpl WithPrimaryInternalLoadBalancerInboundNatPools(params string[] natPoolNames)
        {
            if (this.IsInCreateMode)
            {
                VirtualMachineScaleSetIPConfigurationInner defaultPrimaryIPConfig = this.PrimaryNicDefaultIPConfiguration();
                RemoveAllInboundNatPoolAssociationFromIPConfiguration(this.primaryInternalLoadBalancer,
                        defaultPrimaryIPConfig);
                AssociateInboundNatPoolsToIPConfiguration(this.primaryInternalLoadBalancer.Id,
                        defaultPrimaryIPConfig,
                        natPoolNames);
            }
            else
            {
                AddToList(this.primaryInternalLBInboundNatPoolsToAddOnUpdate, natPoolNames);
            }
            return this;
        }

        ///GENMHASH:0B0B068704882D0210B822A215F5536D:243E7BC061CB4C21AF430343B3ACCDAA
        public VirtualMachineScaleSetImpl WithStoredWindowsImage(string imageUrl)
        {
            VirtualHardDisk userImageVhd = new VirtualHardDisk();
            userImageVhd.Uri = imageUrl;
            Inner
                .VirtualMachineProfile
                .StorageProfile.OsDisk.CreateOption = DiskCreateOptionTypes.FromImage;
            Inner
                .VirtualMachineProfile
                .StorageProfile.OsDisk.Image = userImageVhd;
            // For platform image osType will be null, azure will pick it from the image metadata.
            Inner
                .VirtualMachineProfile
                .StorageProfile.OsDisk.OsType = OperatingSystemTypes.Windows;
            Inner
                .VirtualMachineProfile
                .OsProfile.WindowsConfiguration = new WindowsConfiguration();
            // sets defaults for "Stored(Custom)Image" or "VM(Platform)Image"
            Inner
                .VirtualMachineProfile
                .OsProfile.WindowsConfiguration.ProvisionVMAgent = true;
            Inner
                .VirtualMachineProfile
                .OsProfile.WindowsConfiguration.EnableAutomaticUpdates = true;
            return this;
        }

        ///GENMHASH:CAFE3044E63DB355E0097F6FD22A0282:600739A4DD068DBA0CF85CC076E9111F
        public IEnumerable<IVirtualMachineScaleSetSku> ListAvailableSkus()
        {
            return Management.ResourceManager.Fluent.Core.Extensions.Synchronize(() => Manager.Inner.VirtualMachineScaleSets.ListSkusAsync(ResourceGroupName, Name))
                   .AsContinuousCollection(link => Management.ResourceManager.Fluent.Core.Extensions.Synchronize(() => Manager.Inner.VirtualMachineScaleSets.ListSkusNextAsync(link)))
                   .Select(inner => new VirtualMachineScaleSetSkuImpl(inner));
        }

        ///GENMHASH:B521ECE36A8645ACCD4603A46DF73D20:6C43F204834714CB74740068BED95D98
        private bool IsInUpdateMode()
        {
            return !this.IsInCreateMode;
        }

        ///GENMHASH:CE408710AAEBD9F32D9AA9DB3280112C:DE7951813645A18DB8AC5B2A48405BD0
        public VirtualMachineScaleSetImpl WithSku(VirtualMachineScaleSetSkuTypes skuType)
        {
            Inner.Sku = skuType.Sku;
            return this;
        }

        ///GENMHASH:C28C7D09D57FFF72FA8A6AEC7292936E:58BB80E4580D65A5E408E4BA250168E1
        public VirtualMachineScaleSetImpl WithSku(IVirtualMachineScaleSetSku sku)
        {
            return this.WithSku(sku.SkuType);
        }

        ///GENMHASH:9177073080371FB82A479834DA14F493:CB0A5903865A994CFC26F01586B9FD22
        public VirtualMachineScaleSetImpl WithPopularLinuxImage(KnownLinuxVirtualMachineImage knownImage)
        {
            return WithSpecificLinuxImageVersion(knownImage.ImageReference());
        }

        ///GENMHASH:6D51A334B57DF882E890FEBA9887BE77:7C195F155B243BEB1BF2C9C922692404
        public VirtualMachineScaleSetImpl WithLatestLinuxImage(string publisher, string offer, string sku)
        {
            ImageReference imageReference = new ImageReference();
            imageReference.Publisher = publisher;
            imageReference.Offer = offer;
            imageReference.Sku = sku;
            imageReference.Version = "latest";
            return WithSpecificLinuxImageVersion(imageReference);
        }

        ///GENMHASH:CBF523A860AE839D0C4D7384E636EA3A:FBFD113A504A5E7AC32C778EDF3C9726
        public VirtualMachineScaleSetImpl WithoutOverProvisioning()
        {
            return this.WithOverProvision(false);
        }

        ///GENMHASH:7CC775D2FD3FE91AF2002BEF58F09719:99855FF2EE95AA6F2863BA16C5E195B6
        public VirtualMachineScaleSetImpl WithoutPrimaryInternetFacingLoadBalancerBackends(params string[] backendNames)
        {
            AddToList(this.primaryInternetFacingLBBackendsToRemoveOnUpdate, backendNames);
            return this;
        }

        ///GENMHASH:4A7665D6C5D507E115A9A8E551801DB6:2F9DC0F45AE7B5E40E42D209F813E9DD
        public VirtualMachineScaleSetImpl WithSpecificWindowsImageVersion(ImageReference imageReference)
        {
            Inner
                .VirtualMachineProfile
                .StorageProfile.OsDisk.CreateOption = DiskCreateOptionTypes.FromImage;
            Inner
                .VirtualMachineProfile
                .StorageProfile.ImageReference = imageReference.Inner;
            Inner
                .VirtualMachineProfile
                .OsProfile.WindowsConfiguration = new WindowsConfiguration();
            // sets defaults for "Stored(Custom)Image" or "VM(Platform)Image"
            Inner
                .VirtualMachineProfile
                .OsProfile.WindowsConfiguration.ProvisionVMAgent = true;
            Inner
                .VirtualMachineProfile
                .OsProfile.WindowsConfiguration.EnableAutomaticUpdates = true;
            return this;
        }

        ///GENMHASH:8EC66BEFDF0AB45D9707306C2856E7C8:31CFCE6190972DAB49A6CC439CE9500F
        private void SetPrimaryIPConfigurationSubnet()
        {
            if (this.IsInUpdateMode())
            {
                return;
            }
            VirtualMachineScaleSetIPConfigurationInner ipConfig = this.PrimaryNicDefaultIPConfiguration();
            ipConfig.Subnet = new ApiEntityReference
            {
                Id = this.existingPrimaryNetworkSubnetNameToAssociate
            };
            this.existingPrimaryNetworkSubnetNameToAssociate = null;
        }

        ///GENMHASH:C81171F34FA85CED80852E725FF8B7A4:8AADBD78C0C1C88EB899BC43FF6E8A1E
        public bool IsManagedDiskEnabled()
        {
            VirtualMachineScaleSetStorageProfile storageProfile = Inner.VirtualMachineProfile.StorageProfile;
            if (IsOsDiskFromCustomImage(storageProfile))
            {
                return true;
            }
            if (IsOSDiskFromStoredImage(storageProfile))
            {
                return false;
            }
            if (IsOSDiskFromPlatformImage(storageProfile))
            {
                if (this.isUnmanagedDiskSelected)
                {
                    return false;
                }
            }
            if (IsInCreateMode)
            {
                return true;
            }
            else
            {
                var vhdContainers = storageProfile
                .OsDisk
                .VhdContainers;
                return vhdContainers == null || vhdContainers.Count == 0;
            }
        }

        ///GENMHASH:B37B5DD609CF1DB836ABB9CBB32E93E3:EBFBB1CB0457C2978B29376127013BE6
        public VirtualMachineScaleSetImpl WithDataDiskDefaultStorageAccountType(StorageAccountTypes storageAccountType)
        {
            this.managedDataDisks.SetDefaultStorageAccountType(storageAccountType);
            return this;
        }

        ///GENMHASH:938517A3FC2059570C8EA6BFD0A7E151:78F7A73923F62410889B71C234EDE483
        private VirtualMachineScaleSetIPConfigurationInner PrimaryNicDefaultIPConfiguration()
        {
            IList<VirtualMachineScaleSetNetworkConfigurationInner> nicConfigurations = Inner
                    .VirtualMachineProfile
                    .NetworkProfile
                    .NetworkInterfaceConfigurations;
            foreach (VirtualMachineScaleSetNetworkConfigurationInner nicConfiguration in nicConfigurations)
            {
                if (nicConfiguration.Primary.HasValue && nicConfiguration.Primary == true)
                {
                    if (nicConfiguration.IpConfigurations.Count > 0)
                    {
                        VirtualMachineScaleSetIPConfigurationInner ipConfig = nicConfiguration.IpConfigurations.ElementAt(0);
                        if (ipConfig.LoadBalancerBackendAddressPools == null)
                        {
                            ipConfig.LoadBalancerBackendAddressPools = new List<SubResource>();
                        }
                        if (ipConfig.LoadBalancerInboundNatPools == null)
                        {
                            ipConfig.LoadBalancerInboundNatPools = new List<SubResource>();
                        }
                        return ipConfig;
                    }
                }
            }
            throw new Exception("Could not find the primary nic configuration or an IP configuration in it");
        }

        ///GENMHASH:AC21A10EE2E745A89E94E447800452C1:B5D7FA290CD4B78F425E5D837D1426C5
        protected override void BeforeCreating()
        {
            this.virtualMachineScaleSetMsiHelper.AddOrUpdateMSIExtension(this);
            if (this.extensions.Count > 0)
            {
                Inner.VirtualMachineProfile
                    .ExtensionProfile = new VirtualMachineScaleSetExtensionProfile
                    {
                        Extensions = new List<Models.VirtualMachineScaleSetExtension>()
                    };
                foreach (IVirtualMachineScaleSetExtension extension in this.extensions.Values)
                {
                    Inner.VirtualMachineProfile
                        .ExtensionProfile
                        .Extensions.Add(extension.Inner);
                }
            }
        }

        ///GENMHASH:FD4CE9D235CA642C8185D0844177DDFB:D7E2129941B29E412D9F2124F2BAE432
        public IReadOnlyList<string> VhdContainers()
        {
            if (Inner.VirtualMachineProfile.StorageProfile != null
                && Inner.VirtualMachineProfile.StorageProfile.OsDisk != null
                && Inner.VirtualMachineProfile.StorageProfile.OsDisk.VhdContainers != null)
            {
                return Inner.VirtualMachineProfile.StorageProfile.OsDisk.VhdContainers?.ToList();
            }
            return new List<string>();
        }

        ///GENMHASH:67723971057BB45E3F0FFEB5B7B65F34:314C13CB065F185378CB337F9FEEC400
        private void SetOSProfileDefaults()
        {
            if (IsInUpdateMode())
            {
                return;
            }
            if (Inner.Sku.Capacity == null)
            {
                this.WithCapacity(2);
            }
            if (Inner.UpgradePolicy == null
                || Inner.UpgradePolicy.Mode == null)
            {
                Inner.UpgradePolicy = new UpgradePolicy();
                Inner.UpgradePolicy.Mode = UpgradeMode.Automatic;
            }
            VirtualMachineScaleSetOSProfile osProfile = Inner
                .VirtualMachineProfile
                .OsProfile;
            VirtualMachineScaleSetOSDisk osDisk = Inner.VirtualMachineProfile.StorageProfile.OsDisk;
            if (IsOSDiskFromImage(osDisk))
            {
                // ODDisk CreateOption: FROM_IMAGE
                //
                if (this.OSType() == OperatingSystemTypes.Linux || this.isMarketplaceLinuxImage)
                {
                    if (osProfile.LinuxConfiguration == null)
                    {
                        osProfile.LinuxConfiguration = new LinuxConfiguration();
                    }
                    osProfile
                        .LinuxConfiguration
                        .DisablePasswordAuthentication = osProfile.AdminPassword == null;
                }
                if (this.ComputerNamePrefix() == null)
                {
                    // VM name cannot contain only numeric values and cannot exceed 15 chars
                    if ((new Regex(@"^\d+$")).IsMatch(this.Name))
                    {
                        this.WithComputerNamePrefix(SdkContext.RandomResourceName("vmss-vm", 12));
                    }
                    else if (this.Name.Length <= 12)
                    {
                        this.WithComputerNamePrefix(this.Name + "-vm");
                    }
                    else
                    {
                        this.WithComputerNamePrefix(SdkContext.RandomResourceName("vmss-vm", 12));
                    }
                }
            }
            else
            {
                // NOP [ODDisk CreateOption: ATTACH, ATTACH is not supported for VMSS]
                Inner
                    .VirtualMachineProfile
                    .OsProfile = null;
            }
        }

        ///GENMHASH:A890CDCD402F1815F0ACD6293C3C115C:8FEE8350E44B2F78F72EE527639CDC76
        public INetwork GetPrimaryNetwork()
        {
            string subnetId = PrimaryNicDefaultIPConfiguration().Subnet.Id;
            string virtualNetworkId = ResourceUtils.ParentResourcePathFromResourceId(subnetId);
            return this.networkManager
                    .Networks
                    .GetById(virtualNetworkId);
        }

        ///GENMHASH:8E925C4949ADC5B976067DDC58BE3E3C:D2243C739D20D636DF7C32705C2B6CAF
        public IVirtualMachineScaleSetVMs VirtualMachines()
        {
            return new VirtualMachineScaleSetVMsImpl(this, Manager);
        }

        ///GENMHASH:D5F141800B409906045662B0DD536DE4:26BA1C1FFB483992498725C1ED900BA1
        public VirtualMachineScaleSetImpl WithRootUsername(string rootUserName)
        {
            Inner
                .VirtualMachineProfile
                .OsProfile
                .AdminUsername = rootUserName;
            return this;
        }

        ///GENMHASH:D7FDEEE05B0AD7938194763373E58DCF:B966166E0B6ED23B8FE875ADCB3E96A7
        public VirtualMachineScaleSetImpl WithUpgradeMode(UpgradeMode upgradeMode)
        {
            if (Inner.UpgradePolicy == null)
            {
                Inner.UpgradePolicy = new UpgradePolicy();
            }

            Inner
                    .UpgradePolicy
                    .Mode = upgradeMode;
            return this;
        }

        ///GENMHASH:EBD956A6D9170606742388660BDAF883:0632C1C1A1EE3CCF1E3F260984431012
        private static void AddToList<T>(List<T> list, params T[] items)
        {
            foreach (T item in items)
            {
                list.Add(item);
            }
        }

        ///GENMHASH:1E2CA1FC9878A5C0B08DAAE75CBAD541:CA4C4022D33F6F7487EF6C4ECA5FF3D3
        public IReadOnlyDictionary<string, Microsoft.Azure.Management.Network.Fluent.ILoadBalancerBackend> ListPrimaryInternalLoadBalancerBackends()
        {
            if ((this as Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet).GetPrimaryInternalLoadBalancer() != null)
            {
                return GetBackendsAssociatedWithIPConfiguration(this.primaryInternalLoadBalancer,
                        PrimaryNicDefaultIPConfiguration());
            }
            return new Dictionary<string, ILoadBalancerBackend>();
        }

        ///GENMHASH:DB561BC9EF939094412065B65EB3D2EA:323D5930D438D7B746B03A2AB231B061
        public void Reimage()
        {
            Management.ResourceManager.Fluent.Core.Extensions.Synchronize(() => Manager.Inner.VirtualMachineScaleSets.ReimageAsync(ResourceGroupName, Name));
        }
        public async Task ReimageAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await Manager.Inner.VirtualMachineScaleSets.ReimageAsync(ResourceGroupName, Name, cancellationToken);
        }

        ///GENMHASH:7BA741621F15820BA59476A9CFEBBD88:395C45C93AFFE4737734EBBF09A6B2AF
        public VirtualMachineScaleSetImpl WithComputerNamePrefix(string namePrefix)
        {
            Inner
                    .VirtualMachineProfile
                    .OsProfile
                    .ComputerNamePrefix = namePrefix;
            return this;
        }

        ///GENMHASH:A50ABE2E1C931A4A3E6C46728ECA9763:0D2CCE10FD77C080849AE0BE069DCC7D
        public VirtualMachineScaleSetImpl WithAutoUpdate()
        {
            Inner
                    .VirtualMachineProfile
                    .OsProfile.WindowsConfiguration.EnableAutomaticUpdates = true;
            return this;
        }

        private async Task HandleOSDiskContainersAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            VirtualMachineScaleSetStorageProfile storageProfile = Inner
                    .VirtualMachineProfile
                    .StorageProfile;
            if (IsManagedDiskEnabled())
            {
                storageProfile.OsDisk.VhdContainers = null;
                return;
            }

            if (IsOSDiskFromStoredImage(storageProfile))
            {
                // There is a restriction currently that virtual machine's disk cannot be stored in multiple storage
                // accounts if scale set is based on stored image. Remove this check once azure start supporting it.
                //
                if (storageProfile.OsDisk.VhdContainers != null)
                {
                    storageProfile.OsDisk
                        .VhdContainers
                        .Clear();
                }
                return;
            }

            if (this.IsInCreateMode
                && this.creatableStorageAccountKeys.Count == 0
                && this.existingStorageAccountsToAssociate.Count == 0)
            {
                IStorageAccount storageAccount = await this.storageManager.StorageAccounts
                        .Define(this.namer.RandomName("stg", 24).Replace("-", ""))
                        .WithRegion(this.RegionName)
                        .WithExistingResourceGroup(this.ResourceGroupName)
                        .CreateAsync(cancellationToken);
                String containerName = vhdContainerName;
                if (containerName == null)
                {
                    containerName = "vhds";
                }
                storageProfile.OsDisk
                        .VhdContainers
                        .Add(MergePath(storageAccount.EndPoints.Primary.Blob, containerName));
                vhdContainerName = null;
                creatableStorageAccountKeys.Clear();
                existingStorageAccountsToAssociate.Clear();
                return;
            }
            else
            {
                string containerName = this.vhdContainerName;
                if (containerName == null)
                {
                    foreach (string containerUrl in storageProfile.OsDisk.VhdContainers)
                    {
                        containerName = containerUrl.Substring(containerUrl.LastIndexOf("/") + 1);
                        break;
                    }
                }

                if (containerName == null)
                {
                    containerName = "vhds";
                }

                foreach (string storageAccountKey in this.creatableStorageAccountKeys)
                {
                    IStorageAccount storageAccount = (IStorageAccount)CreatedResource(storageAccountKey);
                    storageProfile.OsDisk
                            .VhdContainers
                            .Add(MergePath(storageAccount.EndPoints.Primary.Blob, containerName));
                }

                foreach (IStorageAccount storageAccount in this.existingStorageAccountsToAssociate)
                {
                    storageProfile.OsDisk
                            .VhdContainers
                            .Add(MergePath(storageAccount.EndPoints.Primary.Blob, containerName));
                }

                this.vhdContainerName = null;
                this.creatableStorageAccountKeys.Clear();
                this.existingStorageAccountsToAssociate.Clear();
            }
        }

        ///GENMHASH:15C87FF18F2D92A7CA828FB69E15D8F4:FAB35812CDE5256B5EEDB90655E51B75
        private void ThrowIfManagedDiskEnabled(string message)
        {
            if (this.IsManagedDiskEnabled())
            {
                throw new NotSupportedException(message);
            }
        }

        ///GENMHASH:39841E710EB7DD7AE8E99B918CA0EEEA:C48030ECFE011DCB363EBC211AAE918D
        public string OSDiskName()
        {
            return Inner.VirtualMachineProfile.StorageProfile.OsDisk.Name;
        }

        ///GENMHASH:1BAF4F1B601F89251ABCFE6CC4867026:637A809EDFD013CAD03D1C7CE71A5FD8
        public OperatingSystemTypes OSType()
        {
            return Inner.VirtualMachineProfile.StorageProfile.OsDisk.OsType.GetValueOrDefault();
        }

        ///GENMHASH:F7E8AD723108078BE0FE19CD860DD3D3:78969D0BA29AFC39123F017955CEE8EE
        public VirtualMachineScaleSetImpl WithWinRM(WinRMListener listener)
        {
            if (Inner.VirtualMachineProfile.OsProfile.WindowsConfiguration.WinRM == null)
            {
                WinRMConfiguration winRMConfiguration = new WinRMConfiguration();
                Inner
                        .VirtualMachineProfile
                        .OsProfile.WindowsConfiguration.WinRM = winRMConfiguration;
            }
            if (Inner.VirtualMachineProfile.OsProfile.WindowsConfiguration.WinRM.Listeners == null)
            {
                Inner
                    .VirtualMachineProfile
                    .OsProfile
                    .WindowsConfiguration.WinRM
                    .Listeners = new List<WinRMListener>();
            }
            Inner
                    .VirtualMachineProfile
                    .OsProfile
                    .WindowsConfiguration
                    .WinRM
                    .Listeners
                    .Add(listener);
            return this;
        }

        ///GENMHASH:E8024524BA316DC9DEEB983B272ABF81:35404321E1B27D532B34DF57EB311A9E
        public VirtualMachineScaleSetImpl WithCustomData(string base64EncodedCustomData)
        {
            Inner
                .VirtualMachineProfile
                .OsProfile
                .CustomData = base64EncodedCustomData;
            return this;
        }

        ///GENMHASH:7AD7A06F139BA844A9B0CC9596C66F00:6CC5B2412B485510418552D419E955F9
        private static void AssociateLoadBalancerToIPConfiguration(ILoadBalancer loadBalancer,
                                                                   VirtualMachineScaleSetIPConfigurationInner ipConfig)
        {
            var backends = loadBalancer.Backends.Values;

            string[] backendNames = new string[backends.Count()];
            int i = 0;
            foreach (ILoadBalancerBackend backend in backends)
            {
                backendNames[i] = backend.Name;
                i++;
            }

            AssociateBackEndsToIPConfiguration(loadBalancer.Id,
                    ipConfig,
                    backendNames);

            var inboundNatPools = loadBalancer.InboundNatPools.Values;
            string[] natPoolNames = new string[inboundNatPools.Count()];
            i = 0;
            foreach (ILoadBalancerInboundNatPool inboundNatPool in inboundNatPools)
            {
                natPoolNames[i] = inboundNatPool.Name;
                i++;
            }

            AssociateInboundNatPoolsToIPConfiguration(loadBalancer.Id,
                    ipConfig,
                    natPoolNames);
        }

        ///GENMHASH:359B78C1848B4A526D723F29D8C8C558:B8E11C7D3FD0F8058EC1203B18D3671D
        protected async override Task<VirtualMachineScaleSetInner> CreateInnerAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            if (IsInCreateMode)
            {
                this.SetOSProfileDefaults();
                this.SetOSDiskDefault();
            }
            this.SetPrimaryIPConfigurationSubnet();
            this.SetPrimaryIPConfigurationBackendsAndInboundNatPools();
            if (IsManagedDiskEnabled())
            {
                this.managedDataDisks.SetDataDisksDefaults();
            }
            else
            {
                IList<VirtualMachineScaleSetDataDisk> dataDisks = Inner
                .VirtualMachineProfile
                .StorageProfile
                .DataDisks;
                VirtualMachineScaleSetUnmanagedDataDiskImpl.SetDataDisksDefaults(dataDisks, Name);
            }
            await HandleOSDiskContainersAsync(cancellationToken);
            var scalesetInner = await Manager.Inner.VirtualMachineScaleSets.CreateOrUpdateAsync(ResourceGroupName, Name, Inner, cancellationToken);
            // Inner has to be updated so that virtualMachineScaleSetMsiHelper can fetch MSI identity
            this.SetInner(scalesetInner);
            await virtualMachineScaleSetMsiHelper.CreateMSIRbacRoleAssignmentsAsync(this);
            return scalesetInner;
        }

        ///GENMHASH:621A22301B3EB5233E9DB4ED5BEC5735:E8427EEC4ACC25554660EF889ECD07A2
        public VirtualMachineScaleSetImpl WithDataDiskDefaultCachingType(CachingTypes cachingType)
        {
            this.managedDataDisks.SetDefaultCachingType(cachingType);
            return this;
        }

        ///GENMHASH:BC7873AAD73CC4C7525B7C9F39F3F121:A055D9C6DB5164F68AE250D30F989A3F
        public VirtualMachineScaleSetImpl WithoutPrimaryInternalLoadBalancerBackends(params string[] backendNames)
        {
            AddToList(this.primaryInternalLBBackendsToRemoveOnUpdate, backendNames);
            return this;
        }

        ///GENMHASH:085C052B5E99B190740EE6AF70CF4D53:4F450AB75A3E01A0CCB9AFBF4F23BE28
        public VirtualMachineScaleSetImpl WithCapacity(int capacity)
        {
            Inner
                    .Sku.Capacity = capacity;
            return this;
        }

        ///GENMHASH:ED2B5B9A3A19B5A8C2C3E6E1CDBF9402:6A6DEBF76624FF70612A6981A86CC468
        public VirtualMachineScaleSetImpl WithUnmanagedDisks()
        {
            this.isUnmanagedDiskSelected = true;
            return this;
        }

        ///GENMHASH:6D9F740D6D73C56877B02D9F1C96F6E7:3AA1543C2E39D6E6D148C51D89E3B4C6
        protected override void InitializeChildrenFromInner()
        {
            this.extensions = new Dictionary<string, IVirtualMachineScaleSetExtension>();
            if (Inner.VirtualMachineProfile.ExtensionProfile != null
               && Inner.VirtualMachineProfile.ExtensionProfile.Extensions != null)
            {
                foreach (var innerExtenison in Inner.VirtualMachineProfile.ExtensionProfile.Extensions)
                {
                    this.extensions.Add(innerExtenison.Name, new VirtualMachineScaleSetExtensionImpl(innerExtenison, this));
                }
            }
        }

        ///GENMHASH:0F38250A3837DF9C2C345D4A038B654B:5723E041D4826DFBE50B8B49C31EAF08
        public void Start()
        {
            Management.ResourceManager.Fluent.Core.Extensions.Synchronize(() => Manager.Inner.VirtualMachineScaleSets.StartAsync(ResourceGroupName, Name));
        }

        public async Task StartAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await Manager.Inner.VirtualMachineScaleSets.StartAsync(ResourceGroupName, Name, cancellationToken: cancellationToken);
        }

        ///GENMHASH:E3A33B29616A6EAF518CC10EA90B45C7:191C8844004D95B6F7362BD81543FE33
        public ILoadBalancer GetPrimaryInternalLoadBalancer()
        {
            if (this.primaryInternalLoadBalancer == null)
            {
                LoadCurrentPrimaryLoadBalancersIfAvailable();
            }
            return this.primaryInternalLoadBalancer;
        }

        ///GENMHASH:674F68CEE727AFB7E6F6D9C7FADE1175:9D8CEFD984A116AE33BB221254786FA5
        public VirtualMachineScaleSetImpl WithNewDataDisk(int sizeInGB)
        {
            ThrowIfManagedDiskDisabled(ManagedUnmanagedDiskErrors.VMSS_Both_Unmanaged_And_Managed_Disk_Not_Aallowed);
            this.managedDataDisks.implicitDisksToAssociate.Add(new VirtualMachineScaleSetDataDisk()
            {
                Lun = -1,
                DiskSizeGB = sizeInGB
            });
            return this;
        }

        ///GENMHASH:B213E98FA6979257F6E6F61C9B5E550B:AAA573249324CF7B1EBD45AD10721744
        public VirtualMachineScaleSetImpl WithNewDataDisk(int sizeInGB, int lun, CachingTypes cachingType)
        {
            ThrowIfManagedDiskDisabled(ManagedUnmanagedDiskErrors.VMSS_Both_Unmanaged_And_Managed_Disk_Not_Aallowed);
            this.managedDataDisks.implicitDisksToAssociate.Add(new VirtualMachineScaleSetDataDisk()
            {
                Lun = lun,
                DiskSizeGB = sizeInGB,
                Caching = cachingType
            });
            return this;
        }

        ///GENMHASH:1D3A0A89681FFD35007B24FCED6BF299:96D67639BA263640D554DB8A3CC5D75C
        public VirtualMachineScaleSetImpl WithNewDataDisk(int sizeInGB, int lun, CachingTypes cachingType, StorageAccountTypes storageAccountType)
        {
            ThrowIfManagedDiskDisabled(ManagedUnmanagedDiskErrors.VMSS_Both_Unmanaged_And_Managed_Disk_Not_Aallowed);
            VirtualMachineScaleSetManagedDiskParameters managedDiskParameters = new VirtualMachineScaleSetManagedDiskParameters();
            managedDiskParameters.StorageAccountType = storageAccountType;
            this.managedDataDisks.implicitDisksToAssociate.Add(new VirtualMachineScaleSetDataDisk()
            {
                Lun = lun,
                DiskSizeGB = sizeInGB,
                Caching = cachingType,
                ManagedDisk = managedDiskParameters
            });
            return this;
        }

        ///GENMHASH:3CAA43EAEEB81309EADF54AA78725296:E14EB64EB306A8F5A0DF21CD2E85782B
        public VirtualMachineScaleSetImpl WithVMAgent()
        {
            Inner
                    .VirtualMachineProfile
                    .OsProfile.WindowsConfiguration.ProvisionVMAgent = true;
            return this;
        }

        ///GENMHASH:9E11BB028D83D0EF7340685F19FBA340:E9A91314DAD8267710EFDE4AAE671CCF
        public IVirtualMachineScaleSetNetworkInterface GetNetworkInterfaceByInstanceId(string instanceId, string name)
        {
            return this.networkManager.NetworkInterfaces.GetByVirtualMachineScaleSetInstanceId(this.ResourceGroupName,
                this.Name,
                instanceId,
                name);
        }

        ///GENMHASH:BF5FD367567995AC0C50DACEDECE61BD:6FB961EBF4FEC9C5343282A34D18848B
        public VirtualMachineScaleSetImpl WithoutPrimaryInternalLoadBalancerNatPools(params string[] natPoolNames)
        {
            AddToList(this.primaryInternalLBInboundNatPoolsToRemoveOnUpdate, natPoolNames);
            return this;
        }

        ///GENMHASH:0E3F9BC2C5C0DB936DBA634A972BC916:26BA1C1FFB483992498725C1ED900BA1
        public VirtualMachineScaleSetImpl WithAdminUsername(string adminUserName)
        {
            Inner
                .VirtualMachineProfile
                .OsProfile
                .AdminUsername = adminUserName;
            return this;
        }

        ///GENMHASH:D05B148D26960ED1D8EF344B16F36F78:00EC0F6EA3A819049F5C89068A74593C
        public VirtualMachineScaleSetImpl WithOverProvisioning()
        {
            return this.WithOverProvision(true);
        }

        ///GENMHASH:9C4A541B9A2E22540116BFA125189F57:2F8856B5F0BA5E1B741D68C6CED48D9A
        public VirtualMachineScaleSetImpl WithoutDataDisk(int lun)
        {
            if (!IsManagedDiskEnabled())
            {
                return this;
            }
            this.managedDataDisks.diskLunsToRemove.Add(lun);
            return this;
        }

        ///GENMHASH:C4918DA109F597102F1B013B0137F3A2:671581C8F41182347B219436B693EB8A
        private static void AssociateBackEndsToIPConfiguration(string loadBalancerId,
                                                        VirtualMachineScaleSetIPConfigurationInner ipConfig,
                                                        params string[] backendNames)
        {
            List<SubResource> backendSubResourcesToAssociate = new List<SubResource>();
            foreach (string backendName in backendNames)
            {
                String backendPoolId = MergePath(loadBalancerId, "backendAddressPools", backendName);
                bool found = false;
                foreach (SubResource subResource in ipConfig.LoadBalancerBackendAddressPools)
                {
                    if (subResource.Id.Equals(backendPoolId, StringComparison.OrdinalIgnoreCase))
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    backendSubResourcesToAssociate.Add(new SubResource
                    {
                        Id = backendPoolId
                    });
                }
            }

            foreach (SubResource backendSubResource in backendSubResourcesToAssociate)
            {
                ipConfig.LoadBalancerBackendAddressPools.Add(backendSubResource);
            }
        }

        VirtualMachineScaleSet.Update.IWithPrimaryLoadBalancer IUpdatable<VirtualMachineScaleSet.Update.IWithPrimaryLoadBalancer>.Update()
        {
            return this;
        }

        ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbXB1dGUuaW1wbGVtZW50YXRpb24uVmlydHVhbE1hY2hpbmVTY2FsZVNldEltcGwuTWFuYWdlZERhdGFEaXNrQ29sbGVjdGlvbg==
        internal partial class ManagedDataDiskCollection
        {
            public IList<Models.VirtualMachineScaleSetDataDisk> implicitDisksToAssociate;
            public IList<int> diskLunsToRemove;
            public IList<Models.VirtualMachineScaleSetDataDisk> newDisksFromImage;
            private VirtualMachineScaleSetImpl vmss;
            private CachingTypes? defaultCachingType;
            private StorageAccountTypes? defaultStorageAccountType;

            internal ManagedDataDiskCollection(VirtualMachineScaleSetImpl vmss)
            {
                this.vmss = vmss;
                this.implicitDisksToAssociate = new List<VirtualMachineScaleSetDataDisk>();
                this.diskLunsToRemove = new List<int>();
                this.newDisksFromImage = new List<VirtualMachineScaleSetDataDisk>();
            }

            ///GENMHASH:E896A9714FD3ED579D3A806B2D670211:9EC21D752F2334263B0BF51F5BEF2FE2
            internal void SetDefaultStorageAccountType(StorageAccountTypes defaultStorageAccountType)
            {
                this.defaultStorageAccountType = defaultStorageAccountType;
            }

            ///GENMHASH:CA7F491172B86E1C8B0D8508E4161245:48D903B27EEF73A7FA2C1B3E0E47B216
            internal void SetDataDisksDefaults()
            {
                VirtualMachineScaleSetStorageProfile storageProfile = this.vmss
                    .Inner
                    .VirtualMachineProfile
                    .StorageProfile;
                if (IsPending())
                {
                    if (storageProfile.DataDisks == null)
                    {
                        storageProfile.DataDisks = new List<VirtualMachineScaleSetDataDisk>();
                    }
                    var dataDisks = storageProfile.DataDisks;
                    HashSet<int> usedLuns = new HashSet<int>();
                    // Get all used luns
                    //
                    foreach (var dataDisk in dataDisks)
                    {
                        if (dataDisk.Lun != -1)
                        {
                            usedLuns.Add(dataDisk.Lun);
                        }
                    }
                    foreach (var dataDisk in this.implicitDisksToAssociate)
                    {
                        if (dataDisk.Lun != -1)
                        {
                            usedLuns.Add(dataDisk.Lun);
                        }
                    }
                    foreach (var dataDisk in this.newDisksFromImage)
                    {
                        if (dataDisk.Lun != -1)
                        {
                            usedLuns.Add(dataDisk.Lun);
                        }
                    }
                    // Func to get the next available lun
                    //
                    Func<int> nextLun = () =>
                    {
                        int l = 0;
                        while (usedLuns.Contains(l))
                        {
                            l++;
                        }
                        usedLuns.Add(l);
                        return l;
                    };
                    SetImplicitDataDisks(nextLun);
                    SetImageBasedDataDisks();
                    RemoveDataDisks();
                }
                if (storageProfile.DataDisks != null
                    && storageProfile.DataDisks.Count == 0)
                {
                    if (vmss.IsInCreateMode)
                    {
                        // If there is no data disks at all, then setting it to null rather than [] is necessary.
                        // This is for take advantage of CRP's implicit creation of the data disks if the image has
                        // more than one data disk image(s).
                        //
                        storageProfile.DataDisks = null;
                    }
                }
                this.Clear();
            }

            ///GENMHASH:77E6B131587760C1313B68052BA1F959:3583CA6C895B07FD3877A9CFC685B07B
            private CachingTypes GetDefaultCachingType()
            {
                if (defaultCachingType == null || !defaultCachingType.HasValue)
                {
                    return CachingTypes.ReadWrite;
                }
                return defaultCachingType.Value;
            }

            ///GENMHASH:B33308470B073DF5A31970C4C53291A4:3ED328226BD857CB73174798CB8638CC
            private void SetImageBasedDataDisks()
            {
                VirtualMachineScaleSetStorageProfile storageProfile = this.vmss
                    .Inner
                    .VirtualMachineProfile
                    .StorageProfile;
                var dataDisks = storageProfile.DataDisks;
                foreach (var dataDisk in this.newDisksFromImage)
                {
                    dataDisk.CreateOption = DiskCreateOptionTypes.FromImage;
                    // Don't set default caching type for the disk, either user has to specify it explicitly or let CRP pick
                    // it from the image
                    dataDisk.Name = null;
                    dataDisks.Add(dataDisk);
                }
            }

            ///GENMHASH:BDEEEC08EF65465346251F0F99D16258:7FA0EAA436FE9B4E519F2A6F85491919
            private void Clear()
            {
                implicitDisksToAssociate.Clear();
                diskLunsToRemove.Clear();
                newDisksFromImage.Clear();
            }

            ///GENMHASH:C474BAF5F2762CA941D8C01DC8F0A2CB:123893CCEC4625CDE4B7BCBFC68DCF5B
            internal void SetDefaultCachingType(CachingTypes cachingType)
            {
                this.defaultCachingType = cachingType;
            }

            ///GENMHASH:8F31500456F297BA5B51A162318FE60B:B2C684FBABF2AB3AFDFCC790ACB99D8C
            private void RemoveDataDisks()
            {
                VirtualMachineScaleSetStorageProfile storageProfile = this.vmss
                    .Inner
                    .VirtualMachineProfile
                    .StorageProfile;
                var dataDisks = storageProfile.DataDisks;
                foreach (var lun in this.diskLunsToRemove)
                {
                    int indexToRemove = 0;
                    foreach (var dataDisk in dataDisks)
                    {
                        if (dataDisk.Lun == lun)
                        {
                            dataDisks.RemoveAt(indexToRemove);
                            break;
                        }
                        indexToRemove++;
                    }
                }
            }

            ///GENMHASH:647794DB64052F8555CB8ABDABF9F24D:419FDCEEC4AAB55470C80A42C1D69868
            private StorageAccountTypes GetDefaultStorageAccountType()
            {
                if (defaultStorageAccountType == null || !defaultStorageAccountType.HasValue)
                {
                    return StorageAccountTypes.StandardLRS;
                }
                return defaultStorageAccountType.Value;
            }

            ///GENMHASH:0E80C978BE389A20F8B9BDDCBC308EBF:0EC63377965A94AB9FD183B5A71C65E2
            private void SetImplicitDataDisks(Func<int> nextLun)
            {
                VirtualMachineScaleSetStorageProfile storageProfile = this.vmss
                    .Inner
                    .VirtualMachineProfile
                    .StorageProfile;
                var dataDisks = storageProfile.DataDisks;
                foreach (var dataDisk in this.implicitDisksToAssociate)
                {
                    dataDisk.CreateOption = DiskCreateOptionTypes.Empty;
                    if (dataDisk.Lun == -1)
                    {
                        dataDisk.Lun = nextLun();
                    }
                    if (dataDisk.Caching == null)
                    {
                        dataDisk.Caching = GetDefaultCachingType();
                    }
                    if (dataDisk.ManagedDisk == null)
                    {
                        dataDisk.ManagedDisk = new VirtualMachineScaleSetManagedDiskParameters();
                    }
                    if (dataDisk.ManagedDisk.StorageAccountType == null)
                    {
                        dataDisk.ManagedDisk.StorageAccountType = GetDefaultStorageAccountType();
                    }
                    dataDisk.Name = null;
                    dataDisks.Add(dataDisk);
                }
            }

            ///GENMHASH:EC209EBA0DF87A8C3CEA3D68742EA90D:99000851407BA5F5FA9785B299474B9E
            private bool IsPending()
            {
                return implicitDisksToAssociate.Count > 0
                    || diskLunsToRemove.Count > 0
                    || newDisksFromImage.Count > 0;
            }
        }
    }
}
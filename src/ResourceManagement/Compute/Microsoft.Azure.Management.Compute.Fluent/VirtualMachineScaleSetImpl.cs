// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information. 

namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Models;
    using Microsoft.Azure.Management.Storage.Fluent;
    using VirtualMachineScaleSet.Update;
    using Microsoft.Azure.Management.Network.Fluent;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
    using VirtualMachineScaleSet.Definition;
    using Microsoft.Azure.Management.Storage.Fluent.Models;
    using Microsoft.Azure.Management.Resource.Fluent;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using System.Threading;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System;

    /// <summary>
    /// Implementation of VirtualMachineScaleSet.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbXB1dGUuaW1wbGVtZW50YXRpb24uVmlydHVhbE1hY2hpbmVTY2FsZVNldEltcGw=
    internal partial class VirtualMachineScaleSetImpl :
        GroupableParentResource<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet, Models.VirtualMachineScaleSetInner, Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetImpl, IComputeManager, VirtualMachineScaleSet.Definition.IWithGroup, VirtualMachineScaleSet.Definition.IWithSku, VirtualMachineScaleSet.Definition.IWithCreate, VirtualMachineScaleSet.Update.IWithApply>,
        IVirtualMachineScaleSet,
        IDefinition,
        IUpdate
    {
        // Clients
        private IVirtualMachineScaleSetsOperations client;
        private IVirtualMachineScaleSetVMsOperations vmInstancesClient;
        private IStorageManager storageManager;
        private INetworkManager networkManager;
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

        internal VirtualMachineScaleSetImpl(string name, VirtualMachineScaleSetInner innerModel, IVirtualMachineScaleSetsOperations client, IVirtualMachineScaleSetVMsOperations vmInstancesClient, ComputeManager computeManager, IStorageManager storageManager, INetworkManager networkManager) : base(name, innerModel, computeManager)
        {
            this.client = client;
            this.vmInstancesClient = vmInstancesClient;
            this.storageManager = storageManager;
            this.networkManager = networkManager;
            this.namer = SharedSettings.CreateResourceNamer(this.Name);
        }

        ///GENMHASH:6D9F740D6D73C56877B02D9F1C96F6E7:3AA1543C2E39D6E6D148C51D89E3B4C6
        protected override void InitializeChildrenFromInner()
        {
            this.extensions = new Dictionary<string, IVirtualMachineScaleSetExtension>();
            if (this.Inner.VirtualMachineProfile.ExtensionProfile != null
               && this.Inner.VirtualMachineProfile.ExtensionProfile.Extensions != null)
            {
                foreach (var innerExtenison in this.Inner.VirtualMachineProfile.ExtensionProfile.Extensions)
                {
                    this.extensions.Add(innerExtenison.Name, new VirtualMachineScaleSetExtensionImpl(innerExtenison, this));
                }
            }
        }

        ///GENMHASH:AC21A10EE2E745A89E94E447800452C1:B5D7FA290CD4B78F425E5D837D1426C5
        protected override void BeforeCreating()
        {
            if (this.extensions.Count > 0)
            {
                this.Inner.VirtualMachineProfile
                    .ExtensionProfile = new VirtualMachineScaleSetExtensionProfile
                    {
                        Extensions = new List<VirtualMachineScaleSetExtensionInner>()
                    };
                foreach (IVirtualMachineScaleSetExtension extension in this.extensions.Values)
                {
                    this.Inner.VirtualMachineProfile
                        .ExtensionProfile
                        .Extensions.Add(extension.Inner);
                }
            }
        }

        ///GENMHASH:359B78C1848B4A526D723F29D8C8C558:7E3A196C87869BA2C348FE60F0D489C9
        protected override async Task<VirtualMachineScaleSetInner> CreateInnerAsync()
        {
            this.SetOSDiskAndOSProfileDefaults();
            this.SetPrimaryIpConfigurationSubnet();
            this.SetPrimaryIpConfigurationBackendsAndInboundNatPools();
            await HandleOSDiskContainersAsync();
            return await client.CreateOrUpdateAsync(this.ResourceGroupName, this.Name, this.Inner);
        }

        ///GENMHASH:F91F57741BB7E185BF012523964DEED0:89445F7853BF795F5610E29A0AD00373
        protected override void AfterCreating()
        {
            this.ClearCachedProperties();
            this.InitializeChildrenFromInner();
        }

        #region Getters

        ///GENMHASH:F0B439C5B2A4923B3B36B77503386DA7:B38C06867B5D878680004A07BD077546
        public int Capacity()
        {
            return (int)this.Inner.Sku.Capacity.Value;
        }

        ///GENMHASH:38EF4A7AB82168A6DD38F533747DA9D5:362113C4E307F07B620E363B30115839
        public string ComputerNamePrefix()
        {
            return this.Inner.VirtualMachineProfile.OsProfile.ComputerNamePrefix;
        }

        ///GENMHASH:AFF08018A4055EA21949F6479B3BCCA0:4175296A99E4DC787679DF89D1FABCD5
        public VirtualMachineScaleSetNetworkProfile NetworkProfile()
        {
            return this.Inner.VirtualMachineProfile.NetworkProfile;
        }

        ///GENMHASH:123FF0223083F789E78E45771A759A9C:FFF894943EBDE56EEC0675ADF0891867
        public CachingTypes OsDiskCachingType()
        {
            return this.Inner.VirtualMachineProfile.StorageProfile.OsDisk.Caching.Value;
        }

        ///GENMHASH:39841E710EB7DD7AE8E99B918CA0EEEA:C48030ECFE011DCB363EBC211AAE918D
        public string OsDiskName()
        {
            return this.Inner.VirtualMachineProfile.StorageProfile.OsDisk.Name;

        }

        ///GENMHASH:1BAF4F1B601F89251ABCFE6CC4867026:637A809EDFD013CAD03D1C7CE71A5FD8
        public OperatingSystemTypes OsType()
        {
            return this.Inner.VirtualMachineProfile.StorageProfile.OsDisk.OsType.Value;
        }

        ///GENMHASH:33905CDEAEEF3BB750202A2D6D557629:6C42C71E7F1E361AE09BA585BFB11328
        public bool OverProvisionEnabled()
        {
            return this.Inner.OverProvision.Value;
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

        ///GENMHASH:83A8BCB96B7881DAF693D324E0E9BAAE:83FB521120A40493EBC9C3BFCC730829
        public ILoadBalancer GetPrimaryInternetFacingLoadBalancer()
        {
            if (this.primaryInternetFacingLoadBalancer == null)
            {
                LoadCurrentPrimaryLoadBalancersIfAvailable();
            }
            return this.primaryInternetFacingLoadBalancer;
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
            return new VirtualMachineScaleSetVMsImpl(this, this.vmInstancesClient, this.Manager);
        }

        ///GENMHASH:1E2CA1FC9878A5C0B08DAAE75CBAD541:CA4C4022D33F6F7487EF6C4ECA5FF3D3
        public IDictionary<string, ILoadBalancerBackend> ListPrimaryInternalLoadBalancerBackends()
        {
            if ((this as Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet).GetPrimaryInternalLoadBalancer() != null)
            {
                return GetBackendsAssociatedWithIpConfiguration(this.primaryInternalLoadBalancer,
                        PrimaryNicDefaultIPConfiguration());
            }
            return new Dictionary<string, ILoadBalancerBackend>();
        }

        ///GENMHASH:ADE83EE6665AFEEF1CA076067FC2BAB1:901C9A9B6E5CC49CB120EDA00E46E94E
        public IDictionary<string, Microsoft.Azure.Management.Network.Fluent.ILoadBalancerInboundNatPool> ListPrimaryInternalLoadBalancerInboundNatPools()
        {
            if ((this as Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet).GetPrimaryInternalLoadBalancer() != null)
            {
                return GetInboundNatPoolsAssociatedWithIpConfiguration(this.primaryInternalLoadBalancer,
                        PrimaryNicDefaultIPConfiguration());
            }
            return new Dictionary<string, ILoadBalancerInboundNatPool>();
        }

        ///GENMHASH:8371720B72164AB21B88202FD4561610:9ECD956712FBC7CB9A976884F3BEAB45
        public IDictionary<string, Microsoft.Azure.Management.Network.Fluent.ILoadBalancerBackend> ListPrimaryInternetFacingLoadBalancerBackends()
        {
            if ((this as Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet).GetPrimaryInternetFacingLoadBalancer() != null)
            {
                return GetBackendsAssociatedWithIpConfiguration(this.primaryInternetFacingLoadBalancer,
                        PrimaryNicDefaultIPConfiguration());
            }
            return new Dictionary<string, ILoadBalancerBackend>();
        }

        ///GENMHASH:2127E32A8F02C513138DB1208F98C806:1DD59433AF6ED9834170252D06569286
        public IDictionary<string, Microsoft.Azure.Management.Network.Fluent.ILoadBalancerInboundNatPool> ListPrimaryInternetFacingLoadBalancerInboundNatPools()
        {
            if ((this as Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet).GetPrimaryInternetFacingLoadBalancer() != null)
            {
                return GetInboundNatPoolsAssociatedWithIpConfiguration(this.primaryInternetFacingLoadBalancer,
                        PrimaryNicDefaultIPConfiguration());
            }
            return new Dictionary<string, ILoadBalancerInboundNatPool>();
        }

        ///GENMHASH:85147EF10797D4C57F7D765BDFEAE89E:65DEB6D772EFEFA23B2E9C18CCAB48DC
        public IList<string> PrimaryPublicIpAddressIds()
        {
            ILoadBalancer loadBalancer = (this as Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet).GetPrimaryInternetFacingLoadBalancer();
            if (loadBalancer != null)
            {
                return loadBalancer.PublicIpAddressIds;
            }
            return new List<string>();
        }

        ///GENMHASH:7F0A9CB4CB6BBC98F72CF50A81EBFBF4:3C12806E439FD7F02ABD5EEE521A9AB0
        public VirtualMachineScaleSetStorageProfile StorageProfile()
        {
            return this.Inner.VirtualMachineProfile.StorageProfile;
        }

        ///GENMHASH:062EA8E95730159A684C56D3DFCB4846:2E75CE480B794ADCA106E649FAD94DB6
        public UpgradeMode UpgradeModel()
        {
            // upgradePolicy is a required property so no null check
            return this.Inner.UpgradePolicy.Mode.Value;
        }

        ///GENMHASH:FD4CE9D235CA642C8185D0844177DDFB:D7E2129941B29E412D9F2124F2BAE432
        public IList<string> VhdContainers()
        {
            if (this.Inner.VirtualMachineProfile.StorageProfile != null
                && this.Inner.VirtualMachineProfile.StorageProfile.OsDisk != null
                && this.Inner.VirtualMachineProfile.StorageProfile.OsDisk.VhdContainers != null)
            {
                return this.Inner.VirtualMachineProfile.StorageProfile.OsDisk.VhdContainers;
            }
            return new List<string>();
        }

        ///GENMHASH:CAFE3044E63DB355E0097F6FD22A0282:600739A4DD068DBA0CF85CC076E9111F
        public PagedList<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetSku> ListAvailableSkus()
        {
            PagedList<VirtualMachineScaleSetSku> innerPagedList = new PagedList<VirtualMachineScaleSetSku>(this.client.ListSkus(this.ResourceGroupName, this.Name), nextLink =>
            {
                return this.client.ListSkusNext(nextLink);
            });

            return PagedListConverter.Convert<VirtualMachineScaleSetSku, IVirtualMachineScaleSetSku>(innerPagedList, inner =>
            {
                return new VirtualMachineScaleSetSkuImpl(inner);
            });
        }

        ///GENMHASH:EC363135C0A3366C1FA98226F4AE5D05:894AACC37E5DFF8EECFF47C4ACFBFB70
        public IReadOnlyDictionary<string, Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetExtension> Extensions()
        {
            return this.extensions as IReadOnlyDictionary<string, Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetExtension>;
        }

        ///GENMHASH:F792F6C8C594AA68FA7A0FCA92F55B55:CEAEE81352B41505EB71BF5E42D2A3B6
        public VirtualMachineScaleSetSkuTypes Sku()
        {
            return new VirtualMachineScaleSetSkuTypes(this.Inner.Sku);
        }

        #endregion

        #region Withers

        ///GENMHASH:CE408710AAEBD9F32D9AA9DB3280112C:DE7951813645A18DB8AC5B2A48405BD0
        public VirtualMachineScaleSetImpl WithSku(VirtualMachineScaleSetSkuTypes skuType)
        {
            this.Inner.Sku = skuType.Sku;
            return this;
        }

        ///GENMHASH:C28C7D09D57FFF72FA8A6AEC7292936E:58BB80E4580D65A5E408E4BA250168E1
        public VirtualMachineScaleSetImpl WithSku(IVirtualMachineScaleSetSku sku)
        {
            return this.WithSku(sku.SkuType);
        }

        ///GENMHASH:ACFF159DD59B63FA783C8B3D4A7A36F5:86B1B0C90A3820575D5746DAF454199B
        public VirtualMachineScaleSetImpl WithExistingPrimaryNetworkSubnet(INetwork network, string subnetName)
        {
            this.existingPrimaryNetworkSubnetNameToAssociate = MergePath(network.Id, "subnets", subnetName);
            return this;
        }

        ///GENMHASH:5357697C243DBDD2060BF2C164461C10:CCFD65A9998AF06471C50E7F44A70A67
        public VirtualMachineScaleSetImpl WithExistingPrimaryInternetFacingLoadBalancer(ILoadBalancer loadBalancer)
        {
            if (loadBalancer.PublicIpAddressIds.Count == 0)
            {
                throw new ArgumentException("Parameter loadBalancer must be an internet facing load balancer");
            }

            if (this.IsInCreateMode)
            {
                this.primaryInternetFacingLoadBalancer = loadBalancer;
                AssociateLoadBalancerToIpConfiguration(this.primaryInternetFacingLoadBalancer,
                        this.PrimaryNicDefaultIPConfiguration());
            }
            else
            {
                this.primaryInternetFacingLoadBalancerToAttachOnUpdate = loadBalancer;
            }
            return this;
        }

        ///GENMHASH:AAC1F72971316317A21BEC14F977DEDE:ABC059395726B5D6BEB36206C2DDA144
        public VirtualMachineScaleSetImpl WithPrimaryInternetFacingLoadBalancerBackends(params string[] backendNames)
        {
            if (this.IsInCreateMode)
            {
                VirtualMachineScaleSetIPConfigurationInner defaultPrimaryIpConfig = this.PrimaryNicDefaultIPConfiguration();
                RemoveAllBackendAssociationFromIpConfiguration(this.primaryInternetFacingLoadBalancer, defaultPrimaryIpConfig);
                AssociateBackEndsToIpConfiguration(this.primaryInternetFacingLoadBalancer.Id,
                        defaultPrimaryIpConfig,
                        backendNames);
            }
            else
            {
                AddToList(this.primaryInternetFacingLBBackendsToAddOnUpdate, backendNames);
            }
            return this;
        }

        ///GENMHASH:FD824AC9D26C404162A9EEEE0B9A4489:B9DC6752667EC750602BB3CBA2F9F1A0
        public VirtualMachineScaleSetImpl WithPrimaryInternetFacingLoadBalancerInboundNatPools(params string[] natPoolNames)
        {
            if (this.IsInCreateMode)
            {
                VirtualMachineScaleSetIPConfigurationInner defaultPrimaryIpConfig = this.PrimaryNicDefaultIPConfiguration();
                RemoveAllInboundNatPoolAssociationFromIpConfiguration(this.primaryInternetFacingLoadBalancer,
                        defaultPrimaryIpConfig);
                AssociateInboundNATPoolsToIpConfiguration(this.primaryInternetFacingLoadBalancer.Id,
                        defaultPrimaryIpConfig,
                        natPoolNames);
            }
            else
            {
                AddToList(this.primaryInternetFacingLBInboundNatPoolsToAddOnUpdate, natPoolNames);
            }
            return this;
        }

        ///GENMHASH:F074773AE211BBEB7F46B598EA72155B:7704FB8C0D7ED4D767CE8138EA441588
        public VirtualMachineScaleSetImpl WithExistingPrimaryInternalLoadBalancer(ILoadBalancer loadBalancer)
        {
            if (loadBalancer.PublicIpAddressIds.Count != 0)
            {
                throw new ArgumentException("Parameter loadBalancer must be an internal load balancer");
            }
            string lbNetworkId = null;
            foreach (ILoadBalancerFrontend frontEnd in loadBalancer.Frontends.Values)
            {
                if (frontEnd.Inner.Subnet.Id != null)
                {
                    lbNetworkId = ResourceUtils.ParentResourcePathFromResourceId(frontEnd.Inner.Subnet.Id);
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
                AssociateLoadBalancerToIpConfiguration(this.primaryInternalLoadBalancer,
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

        ///GENMHASH:3DF1B6140B6B4ECBFA96FE642F2CD144:CCED3778DD625697E59E50F8F58EAFD7
        public VirtualMachineScaleSetImpl WithPrimaryInternalLoadBalancerBackends(params string[] backendNames)
        {
            if (this.IsInCreateMode)
            {
                VirtualMachineScaleSetIPConfigurationInner defaultPrimaryIpConfig = PrimaryNicDefaultIPConfiguration();
                RemoveAllBackendAssociationFromIpConfiguration(this.primaryInternalLoadBalancer,
                        defaultPrimaryIpConfig);
                AssociateBackEndsToIpConfiguration(this.primaryInternalLoadBalancer.Id,
                        defaultPrimaryIpConfig,
                        backendNames);
            }
            else
            {
                AddToList(this.primaryInternalLBBackendsToAddOnUpdate, backendNames);
            }
            return this;
        }

        ///GENMHASH:44218FC054E9DD430ECE7417A9705EB2:2DB39ADE66ABE6DB110EEDB9C63E2DB3
        public VirtualMachineScaleSetImpl WithPrimaryInternalLoadBalancerInboundNatPools(params string[] natPoolNames)
        {
            if (this.IsInCreateMode)
            {
                VirtualMachineScaleSetIPConfigurationInner defaultPrimaryIpConfig = this.PrimaryNicDefaultIPConfiguration();
                RemoveAllInboundNatPoolAssociationFromIpConfiguration(this.primaryInternalLoadBalancer,
                        defaultPrimaryIpConfig);
                AssociateInboundNATPoolsToIpConfiguration(this.primaryInternalLoadBalancer.Id,
                        defaultPrimaryIpConfig,
                        natPoolNames);
            }
            else
            {
                AddToList(this.primaryInternalLBInboundNatPoolsToAddOnUpdate, natPoolNames);
            }
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

        ///GENMHASH:0B86CB1DFA370E0EF503AA943BA12699:72153688799C022C061CCB2A43E36DC0
        public VirtualMachineScaleSetImpl WithoutPrimaryInternetFacingLoadBalancer()
        {
            if (this.IsInUpdateMode())
            {
                this.removePrimaryInternetFacingLoadBalancerOnUpdate = true;
            }
            return this;
        }

        ///GENMHASH:7CC775D2FD3FE91AF2002BEF58F09719:99855FF2EE95AA6F2863BA16C5E195B6
        public VirtualMachineScaleSetImpl WithoutPrimaryInternetFacingLoadBalancerBackends(params string[] backendNames)
        {
            AddToList(this.primaryInternetFacingLBBackendsToRemoveOnUpdate, backendNames);
            return this;
        }

        ///GENMHASH:BC7873AAD73CC4C7525B7C9F39F3F121:A055D9C6DB5164F68AE250D30F989A3F
        public VirtualMachineScaleSetImpl WithoutPrimaryInternalLoadBalancerBackends(params string[] backendNames)
        {
            AddToList(this.primaryInternalLBBackendsToRemoveOnUpdate, backendNames);
            return this;
        }

        ///GENMHASH:B899054CADDD4C764670C53E2A300590:6FB961EBF4FEC9C5343282A34D18848B
        public VirtualMachineScaleSetImpl WithoutPrimaryInternetFacingLoadBalancerNatPools(params string[] natPoolNames)
        {
            AddToList(this.primaryInternalLBInboundNatPoolsToRemoveOnUpdate, natPoolNames);
            return this;
        }

        ///GENMHASH:BF5FD367567995AC0C50DACEDECE61BD:038D6D03640016D71036DDBF325D8E0F
        public VirtualMachineScaleSetImpl WithoutPrimaryInternalLoadBalancerNatPools(params string[] natPoolNames)
        {
            AddToList(this.primaryInternetFacingLBInboundNatPoolsToRemoveOnUpdate, natPoolNames);
            return this;
        }

        ///GENMHASH:8FDBCB5DF6AFD1594DF170521CE46D5F:4DF21C8BC272D1C368C4F1F79237B3D0
        public VirtualMachineScaleSetImpl WithPopularWindowsImage(KnownWindowsVirtualMachineImage knownImage)
        {
            return WithSpecificWindowsImageVersion(knownImage.ImageReference());
        }

        ///GENMHASH:3874257232804C74BD7501DE2BE2F0E9:D48844CD7D7EEEF909BD7006D3A7E439
        public VirtualMachineScaleSetImpl WithLatestWindowsImage(string publisher, string offer, string sku)
        {
            ImageReference imageReference = new ImageReference
            {
                Publisher = publisher,
                Offer = offer,
                Sku = sku,
                Version = "latest"
            };
            return WithSpecificWindowsImageVersion(imageReference);
        }

        ///GENMHASH:4A7665D6C5D507E115A9A8E551801DB6:34766ED2773D600054F8D54E17BAE777
        public VirtualMachineScaleSetImpl WithSpecificWindowsImageVersion(ImageReference imageReference)
        {
            this.Inner
                    .VirtualMachineProfile
                    .StorageProfile.OsDisk.CreateOption = DiskCreateOptionTypes.FromImage;
            this.Inner
                    .VirtualMachineProfile
                    .StorageProfile.ImageReference = imageReference;
            this.Inner
                    .VirtualMachineProfile
                    .OsProfile.WindowsConfiguration = new WindowsConfiguration()
                    {
                        // sets defaults for "Stored(Custom)Image" or "VM(Platform)Image"
                        ProvisionVMAgent = true,
                        EnableAutomaticUpdates = true
                    };
            return this;
        }

        ///GENMHASH:0B0B068704882D0210B822A215F5536D:243E7BC061CB4C21AF430343B3ACCDAA
        public VirtualMachineScaleSetImpl WithStoredWindowsImage(string imageUrl)
        {
            VirtualHardDisk userImageVhd = new VirtualHardDisk()
            {
                Uri = imageUrl
            };
            this.Inner
                    .VirtualMachineProfile
                    .StorageProfile.OsDisk.CreateOption = DiskCreateOptionTypes.FromImage;
            this.Inner
                    .VirtualMachineProfile
                    .StorageProfile.OsDisk.Image = userImageVhd;
            // For platform image osType will be null, azure will pick it from the image metadata.
            this.Inner
                    .VirtualMachineProfile
                    .StorageProfile.OsDisk.OsType = OperatingSystemTypes.Windows;
            this.Inner
                    .VirtualMachineProfile
                    .OsProfile.WindowsConfiguration = new WindowsConfiguration()
                    {
                        // sets defaults for "Stored(Custom)Image" or "VM(Platform)Image"
                        ProvisionVMAgent = true,
                        EnableAutomaticUpdates = true
                    };
            return this;
        }

        ///GENMHASH:9177073080371FB82A479834DA14F493:CB0A5903865A994CFC26F01586B9FD22
        public VirtualMachineScaleSetImpl WithPopularLinuxImage(KnownLinuxVirtualMachineImage knownImage)
        {
            return WithSpecificLinuxImageVersion(knownImage.ImageReference());
        }

        ///GENMHASH:6D51A334B57DF882E890FEBA9887BE77:7C195F155B243BEB1BF2C9C922692404
        public VirtualMachineScaleSetImpl WithLatestLinuxImage(string publisher, string offer, string sku)
        {
            ImageReference imageReference = new ImageReference
            {
                Publisher = publisher,
                Offer = offer,
                Sku = sku,
                Version = "latest"
            };
            return WithSpecificLinuxImageVersion(imageReference);
        }

        ///GENMHASH:B2876749E60D892750D75C97943BBB13:8A00469CB79E03A6AEE1700CD469F036
        public VirtualMachineScaleSetImpl WithSpecificLinuxImageVersion(ImageReference imageReference)
        {
            this.Inner
                    .VirtualMachineProfile
                    .StorageProfile.OsDisk.CreateOption = DiskCreateOptionTypes.FromImage;
            this.Inner
                    .VirtualMachineProfile
                    .StorageProfile.ImageReference = imageReference;
            this.Inner
                    .VirtualMachineProfile
                    .OsProfile.LinuxConfiguration = new LinuxConfiguration();
            this.isMarketplaceLinuxImage = true;
            return this;
        }

        ///GENMHASH:976BC0FCB9812014FA27474FCF6A694F:51AD565B2270FC1F9104F1A5BC632E24
        public VirtualMachineScaleSetImpl WithStoredLinuxImage(string imageUrl)
        {
            VirtualHardDisk userImageVhd = new VirtualHardDisk();
            userImageVhd.Uri = imageUrl;
            this.Inner
                    .VirtualMachineProfile
                    .StorageProfile.OsDisk.CreateOption = DiskCreateOptionTypes.FromImage;
            this.Inner
                    .VirtualMachineProfile
                    .StorageProfile.OsDisk.Image = userImageVhd;
            // For platform image osType will be null, azure will pick it from the image metadata.
            this.Inner
                    .VirtualMachineProfile
                    .StorageProfile.OsDisk.OsType = OperatingSystemTypes.Linux;
            this.Inner
                    .VirtualMachineProfile
                    .OsProfile.LinuxConfiguration = new LinuxConfiguration();
            return this;
        }

        ///GENMHASH:D5F141800B409906045662B0DD536DE4:26BA1C1FFB483992498725C1ED900BA1
        public VirtualMachineScaleSetImpl WithRootUsername(string rootUserName)
        {
            this.Inner
                .VirtualMachineProfile
                .OsProfile
                .AdminUsername = rootUserName;
            return this;
        }

        ///GENMHASH:F2FFAF5448D7DFAFBE00130C62E87053:F7407CEA3D12779F169A4F2984ACFC2B
        public VirtualMachineScaleSetImpl WithRootPassword(string password)
        {
            this.Inner
                    .VirtualMachineProfile
                    .OsProfile
                    .AdminPassword = password;
            return this;
        }

        ///GENMHASH:0E3F9BC2C5C0DB936DBA634A972BC916:26BA1C1FFB483992498725C1ED900BA1
        public VirtualMachineScaleSetImpl WithAdminUsername(string adminUserName)
        {
            this.Inner
                .VirtualMachineProfile
                .OsProfile
                .AdminUsername = adminUserName;
            return this;
        }

        ///GENMHASH:5810786355B161A5CD254C9E3BE76524:F7407CEA3D12779F169A4F2984ACFC2B
        public VirtualMachineScaleSetImpl WithAdminPassword(string password)
        {
            this.Inner
                    .VirtualMachineProfile
                    .OsProfile
                    .AdminPassword = password;
            return this;
        }

        ///GENMHASH:9BBA27913235B4504FD9F07549E645CC:0BF9F49BB572288259C5C2CF97915D33
        public VirtualMachineScaleSetImpl WithSsh(string publicKeyData)
        {
            VirtualMachineScaleSetOSProfile osProfile = this.Inner
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

        ///GENMHASH:3CAA43EAEEB81309EADF54AA78725296:E14EB64EB306A8F5A0DF21CD2E85782B
        public VirtualMachineScaleSetImpl WithVmAgent()
        {
            this.Inner
                    .VirtualMachineProfile
                    .OsProfile.WindowsConfiguration.ProvisionVMAgent = true;
            return this;
        }

        ///GENMHASH:F16446581B25DFD00E74CB1193EBF605:438AB79E7DABFF084F3F25050C0B0DCB
        public VirtualMachineScaleSetImpl WithoutVmAgent()
        {
            this.Inner
                    .VirtualMachineProfile
                    .OsProfile.WindowsConfiguration.ProvisionVMAgent = true;
            return this;
        }

        ///GENMHASH:A50ABE2E1C931A4A3E6C46728ECA9763:0D2CCE10FD77C080849AE0BE069DCC7D
        public VirtualMachineScaleSetImpl WithAutoUpdate()
        {
            this.Inner
                    .VirtualMachineProfile
                    .OsProfile.WindowsConfiguration.EnableAutomaticUpdates = true;
            return this;
        }

        ///GENMHASH:98B10909018928720DBCCEBE53E08820:75A4D7D6FD5B54E56A4949AE30530D27
        public VirtualMachineScaleSetImpl WithoutAutoUpdate()
        {
            this.Inner
                    .VirtualMachineProfile
                    .OsProfile.WindowsConfiguration.EnableAutomaticUpdates = false;
            return this;
        }

        ///GENMHASH:1BBF95374A03EFFD0583730762AB8753:657393D43CB30B9E2DA291459E17BAD9
        public VirtualMachineScaleSetImpl WithTimeZone(string timeZone)
        {
            this.Inner
                    .VirtualMachineProfile
                    .OsProfile.WindowsConfiguration.TimeZone = timeZone;
            return this;
        }

        ///GENMHASH:F7E8AD723108078BE0FE19CD860DD3D3:78969D0BA29AFC39123F017955CEE8EE
        public VirtualMachineScaleSetImpl WithWinRm(WinRMListener listener)
        {
            if (this.Inner.VirtualMachineProfile.OsProfile.WindowsConfiguration.WinRM == null)
            {
                WinRMConfiguration winRMConfiguration = new WinRMConfiguration();
                this.Inner
                        .VirtualMachineProfile
                        .OsProfile.WindowsConfiguration.WinRM = winRMConfiguration;
            }

            if (this.Inner.VirtualMachineProfile.OsProfile.WindowsConfiguration.WinRM.Listeners == null)
            {
                this.Inner
                    .VirtualMachineProfile
                    .OsProfile
                    .WindowsConfiguration.WinRM
                    .Listeners = new List<WinRMListener>();
            }

            this.Inner
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
            this.Inner
                .VirtualMachineProfile
                .OsProfile
                .CustomData = base64EncodedCustomData;
            return this;
        }

        ///GENMHASH:5C1E5D4B34E988B57615D99543B65A28:FA6DEF6159D987B906C75A28496BD099
        public VirtualMachineScaleSetImpl WithOsDiskCaching(CachingTypes cachingType)
        {
            this.Inner
                    .VirtualMachineProfile
                    .StorageProfile.OsDisk.Caching = cachingType;
            return this;
        }

        ///GENMHASH:C5EB453493B1100152604C49B4350246:13A96702474EC693EFE5444489CDEDCC
        public VirtualMachineScaleSetImpl WithOsDiskName(string name)
        {
            this.Inner
                    .VirtualMachineProfile
                    .StorageProfile.OsDisk.Name = name;
            return this;
        }

        ///GENMHASH:7BA741621F15820BA59476A9CFEBBD88:395C45C93AFFE4737734EBBF09A6B2AF
        public VirtualMachineScaleSetImpl WithComputerNamePrefix(string namePrefix)
        {
            this.Inner
                    .VirtualMachineProfile
                    .OsProfile
                    .ComputerNamePrefix = namePrefix;
            return this;
        }

        ///GENMHASH:D7FDEEE05B0AD7938194763373E58DCF:B966166E0B6ED23B8FE875ADCB3E96A7
        public VirtualMachineScaleSetImpl WithUpgradeMode(UpgradeMode upgradeMode)
        {
            this.Inner
                    .UpgradePolicy
                    .Mode = upgradeMode;
            return this;
        }

        ///GENMHASH:C9A8EFD03D810995DC8CE56B0EFD441D:2CAE9E848FD32118B304BEAAC0B5066D
        public VirtualMachineScaleSetImpl WithOverProvision(bool enabled)
        {
            this.Inner
                    .OverProvision = enabled;
            return this;
        }

        ///GENMHASH:CBF523A860AE839D0C4D7384E636EA3A:FBFD113A504A5E7AC32C778EDF3C9726
        public VirtualMachineScaleSetImpl WithoutOverProvisioning()
        {
            return this.WithOverProvision(false);
        }

        ///GENMHASH:D05B148D26960ED1D8EF344B16F36F78:00EC0F6EA3A819049F5C89068A74593C
        public VirtualMachineScaleSetImpl WithOverProvisioning()
        {
            return this.WithOverProvision(true);
        }

        ///GENMHASH:085C052B5E99B190740EE6AF70CF4D53:4F450AB75A3E01A0CCB9AFBF4F23BE28
        public VirtualMachineScaleSetImpl WithCapacity(int capacity)
        {
            this.Inner
                    .Sku.Capacity = capacity;
            return this;
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
            this.AddCreatableDependency(creatable as IResourceCreator<Microsoft.Azure.Management.Resource.Fluent.Core.IHasId>);
            return this;
        }

        ///GENMHASH:8CB9B7EEE4A4226A6F5BBB2958CC5E81:A9181EF01C6B9C8C3CB92E9F535B6236
        public VirtualMachineScaleSetImpl WithExistingStorageAccount(IStorageAccount storageAccount)
        {
            this.existingStorageAccountsToAssociate.Add(storageAccount);
            return this;
        }

        ///GENMHASH:D7A14F2EFF1E4165DA55EF07B6C19534:7212B561D81BB0678D70A3F6EF38FA07
        public VirtualMachineScaleSetExtensionImpl DefineNewExtension(string name)
        {
            return new VirtualMachineScaleSetExtensionImpl(new VirtualMachineScaleSetExtensionInner { Name = name }, this);
        }

        ///GENMHASH:EB45314951D6F0A225DF2E0CC4444647:31CE7DD3ED015A2C03AF72E95A38202E
        internal VirtualMachineScaleSetImpl WithExtension(VirtualMachineScaleSetExtensionImpl extension)
        {
            this.extensions.Add(extension.Name(), extension);
            return this;
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

        ///GENMHASH:1E53238DF79E665335390B7452E9A04C:341F8A896942EC0102DC34824A8AED9B
        public VirtualMachineScaleSetImpl WithoutExtension(string name)
        {
            if (this.extensions.ContainsKey(name))
            {
                this.extensions.Remove(name);
            }
            return this;
        }

        #endregion

        #region Actions

        ///GENMHASH:4002186478A1CB0B59732EBFB18DEB3A:9A047B4B22E09AEB6344D4F23EC361E5
        public override IVirtualMachineScaleSet Refresh()
        {
            var response = client.Get(this.ResourceGroupName,
                this.Name);
            SetInner(response);
            this.ClearCachedProperties();
            this.InitializeChildrenFromInner();
            return this;
        }

        ///GENMHASH:667E734583F577A898C6389A3D9F4C09:B1A3725E3B60B26D7F37CA7ABFE371B0
        public void Deallocate()
        {
            this.client.Deallocate(this.ResourceGroupName, this.Name);
        }

        ///GENMHASH:8761D0D225B7C49A7A5025186E94B263:21AAF0008CE6CF3F9846F2DFE1CBEBCB
        public void PowerOff()
        {
            this.client.PowerOff(this.ResourceGroupName, this.Name);
        }

        ///GENMHASH:DB561BC9EF939094412065B65EB3D2EA:323D5930D438D7B746B03A2AB231B061
        public void Reimage()
        {
            this.client.Reimage(this.ResourceGroupName, this.Name);
        }

        ///GENMHASH:08CFC096AC6388D1C0E041ECDF099E3D:4479808A1E2B2A23538E662AD3F721EE
        public void Restart()
        {
            this.client.Restart(this.ResourceGroupName, this.Name);
        }

        ///GENMHASH:0F38250A3837DF9C2C345D4A038B654B:5723E041D4826DFBE50B8B49C31EAF08
        public void Start()
        {
            this.client.Start(this.ResourceGroupName, this.Name);
        }

        #endregion

        #region Helpers

        ///GENMHASH:B521ECE36A8645ACCD4603A46DF73D20:6C43F204834714CB74740068BED95D98
        private bool IsInUpdateMode()
        {
            return !this.IsInCreateMode;
        }

        ///GENMHASH:8200C3AA2986ADE3279CEB6CF0EA96D9:902A99F7BBADF1A8D66E6AE021D9D37D
        private void SetOSDiskAndOSProfileDefaults()
        {
            if (this.IsInUpdateMode())
            {
                return;
            }

            if (this.Inner.Sku.Capacity == null)
            {
                this.WithCapacity(2);
            }

            if (this.Inner.UpgradePolicy == null
                    || this.Inner.UpgradePolicy.Mode == null)
            {
                this.Inner.UpgradePolicy = new UpgradePolicy
                {
                    Mode = UpgradeMode.Automatic
                };
            }

            VirtualMachineScaleSetOSProfile osProfile = this.Inner
                    .VirtualMachineProfile
                    .OsProfile;
            // linux image: Custom or marketplace linux image
            if ((this.Inner.VirtualMachineProfile.StorageProfile.OsDisk.OsType != null
                && this.Inner.VirtualMachineProfile.StorageProfile.OsDisk.OsType == OperatingSystemTypes.Linux) || this.isMarketplaceLinuxImage)
            {
                if (osProfile.LinuxConfiguration == null)
                {
                    osProfile.LinuxConfiguration = new LinuxConfiguration();
                }
                osProfile
                    .LinuxConfiguration
                    .DisablePasswordAuthentication = osProfile.AdminPassword == null;
            }

            if (this.Inner.VirtualMachineProfile.StorageProfile.OsDisk.Caching == null)
            {
                this.WithOsDiskCaching(CachingTypes.ReadWrite);
            }

            if (this.OsDiskName() == null)
            {
                this.WithOsDiskName(this.Name + "-os-disk");
            }

            if (this.ComputerNamePrefix() == null)
            {
                // VM name cannot contain only numeric values and cannot exceed 15 chars
                if ((new Regex(@"^\d+$")).IsMatch(this.Name))
                {
                    this.WithComputerNamePrefix(SharedSettings.RandomResourceName("vmss-vm", 12));
                }
                else if (this.Name.Length <= 12)
                {
                    this.WithComputerNamePrefix(this.Name + "-vm");
                }
                else
                {
                    this.WithComputerNamePrefix(SharedSettings.RandomResourceName("vmss-vm", 12));
                }
            }
        }

        ///GENMHASH:F60C5902A709BFEB700B6B3CCE5663A8:76A3EB6FFB2F9BFB55AE1B46314EF027
        private bool IsCustomImage(VirtualMachineScaleSetStorageProfile storageProfile)
        {
            return storageProfile.OsDisk.Image != null
                    && storageProfile.OsDisk.Image.Uri != null;
        }

        ///GENMHASH:A3BEF34E904F3350A24482F5F0F6C369:DA52BB75B8BFDF93918E03080D37DEF6
        private async Task HandleOSDiskContainersAsync()
        {
            VirtualMachineScaleSetStorageProfile storageProfile = this.Inner
                    .VirtualMachineProfile
                    .StorageProfile;
            if (IsCustomImage(storageProfile))
            {
                // There is a restriction currently that virtual machine's disk cannot be stored in multiple storage accounts
                // if scale set is based on custom image. Remove this check once azure start supporting it.
                storageProfile.OsDisk
                        .VhdContainers
                        .Clear();
                await Task.Yield();
                return;
            }

            if (this.IsInCreateMode
                && this.creatableStorageAccountKeys.Count == 0
                && this.existingStorageAccountsToAssociate.Count == 0)
            {
                IStorageAccount storageAccount = await this.storageManager.StorageAccounts
                        .Define(this.namer.RandomName("stg", 24))
                        .WithRegion(this.RegionName)
                        .WithExistingResourceGroup(this.ResourceGroupName)
                        .CreateAsync();
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

        ///GENMHASH:8EC66BEFDF0AB45D9707306C2856E7C8:31CFCE6190972DAB49A6CC439CE9500F
        private void SetPrimaryIpConfigurationSubnet()
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

        ///GENMHASH:2582ED197AB392F5EC837F6BC8FE2FF0:29B4432F98CD641D0280C31D00CAFB2D
        private void SetPrimaryIpConfigurationBackendsAndInboundNatPools()
        {
            if (this.IsInCreateMode)
            {
                return;
            }

            this.LoadCurrentPrimaryLoadBalancersIfAvailable();

            VirtualMachineScaleSetIPConfigurationInner primaryIpConfig = PrimaryNicDefaultIPConfiguration();
            if (this.primaryInternetFacingLoadBalancer != null)
            {
                RemoveBackendsFromIpConfiguration(this.primaryInternetFacingLoadBalancer.Id,
                        primaryIpConfig,
                        this.primaryInternetFacingLBBackendsToRemoveOnUpdate.ToArray());

                AssociateBackEndsToIpConfiguration(primaryInternetFacingLoadBalancer.Id,
                        primaryIpConfig,
                        this.primaryInternetFacingLBBackendsToAddOnUpdate.ToArray());

                RemoveInboundNatPoolsFromIpConfiguration(this.primaryInternetFacingLoadBalancer.Id,
                        primaryIpConfig,
                        this.primaryInternetFacingLBInboundNatPoolsToRemoveOnUpdate.ToArray());

                AssociateInboundNATPoolsToIpConfiguration(primaryInternetFacingLoadBalancer.Id,
                        primaryIpConfig,
                        this.primaryInternetFacingLBInboundNatPoolsToAddOnUpdate.ToArray());
            }

            if (this.primaryInternalLoadBalancer != null)
            {
                RemoveBackendsFromIpConfiguration(this.primaryInternalLoadBalancer.Id,
                        primaryIpConfig,
                        this.primaryInternalLBBackendsToRemoveOnUpdate.ToArray());

                AssociateBackEndsToIpConfiguration(primaryInternalLoadBalancer.Id,
                        primaryIpConfig,
                        this.primaryInternalLBBackendsToAddOnUpdate.ToArray());

                RemoveInboundNatPoolsFromIpConfiguration(this.primaryInternalLoadBalancer.Id,
                        primaryIpConfig,
                        this.primaryInternalLBInboundNatPoolsToRemoveOnUpdate.ToArray());

                AssociateInboundNATPoolsToIpConfiguration(primaryInternalLoadBalancer.Id,
                        primaryIpConfig,
                        this.primaryInternalLBInboundNatPoolsToAddOnUpdate.ToArray());
            }

            if (this.removePrimaryInternetFacingLoadBalancerOnUpdate)
            {
                if (this.primaryInternetFacingLoadBalancer != null)
                {
                    RemoveLoadBalancerAssociationFromIpConfiguration(this.primaryInternetFacingLoadBalancer, primaryIpConfig);
                }
            }

            if (this.removePrimaryInternalLoadBalancerOnUpdate)
            {
                if (this.primaryInternalLoadBalancer != null)
                {
                    RemoveLoadBalancerAssociationFromIpConfiguration(this.primaryInternalLoadBalancer, primaryIpConfig);
                }
            }

            if (this.primaryInternetFacingLoadBalancerToAttachOnUpdate != null)
            {
                if (this.primaryInternetFacingLoadBalancer != null)
                {
                    RemoveLoadBalancerAssociationFromIpConfiguration(this.primaryInternetFacingLoadBalancer, primaryIpConfig);
                }
                AssociateLoadBalancerToIpConfiguration(this.primaryInternetFacingLoadBalancerToAttachOnUpdate, primaryIpConfig);
                if (this.primaryInternetFacingLBBackendsToAddOnUpdate.Count > 0)
                {
                    RemoveAllBackendAssociationFromIpConfiguration(this.primaryInternetFacingLoadBalancerToAttachOnUpdate, primaryIpConfig);
                    AssociateBackEndsToIpConfiguration(this.primaryInternetFacingLoadBalancerToAttachOnUpdate.Id,
                            primaryIpConfig,
                            this.primaryInternetFacingLBBackendsToAddOnUpdate.ToArray());
                }
                if (this.primaryInternetFacingLBInboundNatPoolsToAddOnUpdate.Count > 0)
                {
                    RemoveAllInboundNatPoolAssociationFromIpConfiguration(this.primaryInternetFacingLoadBalancerToAttachOnUpdate, primaryIpConfig);
                    AssociateInboundNATPoolsToIpConfiguration(this.primaryInternetFacingLoadBalancerToAttachOnUpdate.Id,
                            primaryIpConfig,
                            this.primaryInternetFacingLBInboundNatPoolsToAddOnUpdate.ToArray());
                }
            }

            if (this.primaryInternalLoadBalancerToAttachOnUpdate != null)
            {
                if (this.primaryInternalLoadBalancer != null)
                {
                    RemoveLoadBalancerAssociationFromIpConfiguration(this.primaryInternalLoadBalancer, primaryIpConfig);
                }
                AssociateLoadBalancerToIpConfiguration(this.primaryInternalLoadBalancerToAttachOnUpdate, primaryIpConfig);
                if (this.primaryInternalLBBackendsToAddOnUpdate.Count > 0)
                {
                    RemoveAllBackendAssociationFromIpConfiguration(this.primaryInternalLoadBalancerToAttachOnUpdate, primaryIpConfig);
                    AssociateBackEndsToIpConfiguration(this.primaryInternalLoadBalancerToAttachOnUpdate.Id,
                            primaryIpConfig,
                            this.primaryInternalLBBackendsToAddOnUpdate.ToArray());
                }

                if (this.primaryInternalLBInboundNatPoolsToAddOnUpdate.Count > 0)
                {
                    RemoveAllInboundNatPoolAssociationFromIpConfiguration(this.primaryInternalLoadBalancerToAttachOnUpdate, primaryIpConfig);
                    AssociateInboundNATPoolsToIpConfiguration(this.primaryInternalLoadBalancerToAttachOnUpdate.Id,
                            primaryIpConfig,
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
            if (loadBalancer1.PublicIpAddressIds != null && loadBalancer1.PublicIpAddressIds.Count > 0)
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
            if (loadBalancer2.PublicIpAddressIds != null && loadBalancer2.PublicIpAddressIds.Count > 0)
            {
                this.primaryInternetFacingLoadBalancer = loadBalancer2;
            }
            else
            {
                this.primaryInternalLoadBalancer = loadBalancer2;
            }
        }

        ///GENMHASH:938517A3FC2059570C8EA6BFD0A7E151:78F7A73923F62410889B71C234EDE483
        private VirtualMachineScaleSetIPConfigurationInner PrimaryNicDefaultIPConfiguration()
        {
            IList<VirtualMachineScaleSetNetworkConfigurationInner> nicConfigurations = this.Inner
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

        ///GENMHASH:C4918DA109F597102F1B013B0137F3A2:671581C8F41182347B219436B693EB8A
        private static void AssociateBackEndsToIpConfiguration(string loadBalancerId,
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

        ///GENMHASH:27AD431A042600C45C4C0CA529477319:47186F09CC543669168F4089A11F6E5E
        private static void AssociateInboundNATPoolsToIpConfiguration(string loadBalancerId,
                                                        VirtualMachineScaleSetIPConfigurationInner ipConfig,
                                                        params string[] inboundNatPools)
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

        ///GENMHASH:864D8E4C8CD2E86906490FEDA8FB3F2B:8DBC7BDC302D2B4665D3623CB5CE6F9B
        private static IDictionary<string, Microsoft.Azure.Management.Network.Fluent.ILoadBalancerBackend> GetBackendsAssociatedWithIpConfiguration(ILoadBalancer loadBalancer,
                                                                                     VirtualMachineScaleSetIPConfigurationInner ipConfig)
        {
            string loadBalancerId = loadBalancer.Id;
            IDictionary<string, ILoadBalancerBackend> attachedBackends = new Dictionary<string, ILoadBalancerBackend>();
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

        ///GENMHASH:801A53D3DABA33CC92425D2203FD9242:023B6E0293C3EE52841DA58E9038A4E6
        private static IDictionary<string, Microsoft.Azure.Management.Network.Fluent.ILoadBalancerInboundNatPool> GetInboundNatPoolsAssociatedWithIpConfiguration(ILoadBalancer loadBalancer,
                                                                                                   VirtualMachineScaleSetIPConfigurationInner ipConfig)
        {
            String loadBalancerId = loadBalancer.Id;
            IDictionary<string, ILoadBalancerInboundNatPool> attachedInboundNatPools = new Dictionary<string, ILoadBalancerInboundNatPool>();
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

        ///GENMHASH:7AD7A06F139BA844A9B0CC9596C66F00:6CC5B2412B485510418552D419E955F9
        private static void AssociateLoadBalancerToIpConfiguration(ILoadBalancer loadBalancer,
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

            AssociateBackEndsToIpConfiguration(loadBalancer.Id,
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

            AssociateInboundNATPoolsToIpConfiguration(loadBalancer.Id,
                    ipConfig,
                    natPoolNames);
        }

        ///GENMHASH:99E12A9D1F6C67E6350163C75A02C0CF:EB015A0D5BB20773EED2BA22F09DBFE4
        private static void RemoveLoadBalancerAssociationFromIpConfiguration(ILoadBalancer loadBalancer,
                                                                             VirtualMachineScaleSetIPConfigurationInner ipConfig)
        {
            RemoveAllBackendAssociationFromIpConfiguration(loadBalancer, ipConfig);
            RemoveAllInboundNatPoolAssociationFromIpConfiguration(loadBalancer, ipConfig);
        }

        ///GENMHASH:AD16DA08B5E002AC14DA8E4DF1A29686:7CAC61F59FB870FA1BA64452A78CD17B
        private static void RemoveAllBackendAssociationFromIpConfiguration(ILoadBalancer loadBalancer,
                                                                           VirtualMachineScaleSetIPConfigurationInner ipConfig)
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

        ///GENMHASH:C8D0FD360C8F8A611F6F85F99CDE83D0:C73CD8C0F99ACCAB4E6C5579E1D974E4
        private static void RemoveAllInboundNatPoolAssociationFromIpConfiguration(ILoadBalancer loadBalancer,
                                                                                  VirtualMachineScaleSetIPConfigurationInner ipConfig)
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

        ///GENMHASH:6E6D232E3678D03B3716EA09F0ADD0A9:660BA6BD38564D432FD56906D5F71954
        private static void RemoveBackendsFromIpConfiguration(string loadBalancerId,
                                                       VirtualMachineScaleSetIPConfigurationInner ipConfig,
                                                       params string[] backendNames)
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

        ///GENMHASH:5DCF4E29F6EA4E300D272317D5090075:2CECE7F3DC203120ADD63663E7930758
        private static void RemoveInboundNatPoolsFromIpConfiguration(string loadBalancerId,
                                                              VirtualMachineScaleSetIPConfigurationInner ipConfig,
                                                              params string[] inboundNatPoolNames)
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

        ///GENMHASH:EBD956A6D9170606742388660BDAF883:0632C1C1A1EE3CCF1E3F260984431012
        private static void AddToList<T>(List<T> list, params T[] items)
        {
            foreach (T item in items)
            {
                list.Add(item);
            }
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

        VirtualMachineScaleSet.Update.IWithPrimaryLoadBalancer IUpdatable<VirtualMachineScaleSet.Update.IWithPrimaryLoadBalancer>.Update()
        {
            return this;
        }

        #endregion
    }
}

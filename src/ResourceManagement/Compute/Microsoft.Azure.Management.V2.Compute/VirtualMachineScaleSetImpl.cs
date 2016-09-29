// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information. 

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.V2.Network;
using Microsoft.Azure.Management.V2.Resource;
using Microsoft.Azure.Management.V2.Resource.Core;
using Microsoft.Azure.Management.V2.Resource.Core.ResourceActions;
using Microsoft.Azure.Management.V2.Storage;
using Microsoft.Azure.Management.Compute;
using Microsoft.Rest.Azure;
using System.Text;
using System.Text.RegularExpressions;
using System;

namespace Microsoft.Azure.Management.V2.Compute
{
    internal partial class VirtualMachineScaleSetImpl :
        GroupableResource<IVirtualMachineScaleSet,
            VirtualMachineScaleSetInner,
            Rest.Azure.Resource,
            VirtualMachineScaleSetImpl,
            IComputeManager,
            VirtualMachineScaleSet.Definition.IWithGroup,
            VirtualMachineScaleSet.Definition.IWithSku,
            VirtualMachineScaleSet.Definition.IWithCreate,
            VirtualMachineScaleSet.Update.IUpdate>,
        IVirtualMachineScaleSet,
        VirtualMachineScaleSet.Definition.IDefinition,
        VirtualMachineScaleSet.Update.IUpdate
    {
        // Clients
        private IVirtualMachineScaleSetsOperations client;
        private IStorageManager storageManager;
        private INetworkManager networkManager;
        // used to generate unique name for any dependency resources
        private ResourceNamer namer;
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
        // cached primary virtual network
        private INetwork primaryVirtualNetwork;

        internal VirtualMachineScaleSetImpl(string name,
                    VirtualMachineScaleSetInner innerModel,
                    IVirtualMachineScaleSetsOperations client,
                    ComputeManager computeManager,
                    IStorageManager storageManager,
                    INetworkManager networkManager) : base(name, innerModel, computeManager)
        {
            this.client = client;
            this.storageManager = storageManager;
            this.networkManager = networkManager;
            this.namer = new ResourceNamer(this.Name);
            //TODO this.skuConverter = new PagedListConverter<VirtualMachineScaleSetSkuInner, VirtualMachineScaleSetSku>()
        }

        #region Getters

        public int? Capacity
        {
            get
            {
                return (int?)this.Inner.Sku.Capacity;
            }
        }

        public string ComputerNamePrefix
        {
            get
            {
                return this.Inner.VirtualMachineProfile.OsProfile.ComputerNamePrefix;
            }
        }

        public VirtualMachineScaleSetNetworkProfile NetworkProfile
        {
            get
            {
                return this.Inner.VirtualMachineProfile.NetworkProfile;
            }
        }

        public CachingTypes? OsDiskCachingType
        {
            get
            {
                return this.Inner.VirtualMachineProfile.StorageProfile.OsDisk.Caching;
            }
        }

        public string OsDiskName
        {
            get
            {
                return this.Inner.VirtualMachineProfile.StorageProfile.OsDisk.Name;
            }
        }

        public OperatingSystemTypes? OsType
        {
            get
            {
                return this.Inner.VirtualMachineProfile.StorageProfile.OsDisk.OsType;
            }
        }

        public bool? OverProvisionEnabled
        {
            get
            {
                return this.Inner.OverProvision;
            }
        }


        public ILoadBalancer GetPrimaryInternalLoadBalancer()
        {
            if (this.primaryInternalLoadBalancer == null)
            {
                loadCurrentPrimaryLoadBalancersIfAvailable();
            }
            return this.primaryInternalLoadBalancer;
        }

        public ILoadBalancer GetPrimaryInternetFacingLoadBalancer()
        {
            if (this.primaryInternetFacingLoadBalancer == null)
            {
                loadCurrentPrimaryLoadBalancersIfAvailable();
            }
            return this.primaryInternetFacingLoadBalancer;
        }

        public INetwork GetPrimaryNetwork()
        {
            if (this.primaryVirtualNetwork == null)
            {
                string subnetId = primaryNicDefaultIPConfiguration().Subnet.Id;
                string virtualNetworkId = ResourceUtils.ParentResourcePathFromResourceId(subnetId);
                this.primaryVirtualNetwork = this.networkManager
                        .Networks
                        .GetById(virtualNetworkId);
            }
            return this.primaryVirtualNetwork;
        }

        public IDictionary<string, IBackend> ListPrimaryInternalLoadBalancerBackends()
        {
            if ((this as Microsoft.Azure.Management.V2.Compute.IVirtualMachineScaleSet).GetPrimaryInternalLoadBalancer() != null)
            {
                return getBackendsAssociatedWithIpConfiguration(this.primaryInternalLoadBalancer,
                        primaryNicDefaultIPConfiguration());
            }
            return new Dictionary<string, IBackend>();
        }

        public IDictionary<string, IInboundNatPool> ListPrimaryInternalLoadBalancerInboundNatPools()
        {
            if ((this as Microsoft.Azure.Management.V2.Compute.IVirtualMachineScaleSet).GetPrimaryInternalLoadBalancer() != null)
            {
                return getInboundNatPoolsAssociatedWithIpConfiguration(this.primaryInternalLoadBalancer,
                        primaryNicDefaultIPConfiguration());
            }
            return new Dictionary<string, IInboundNatPool>();
        }

        public IDictionary<string, IBackend> ListPrimaryInternetFacingLoadBalancerBackends()
        {
            if ((this as Microsoft.Azure.Management.V2.Compute.IVirtualMachineScaleSet).GetPrimaryInternetFacingLoadBalancer() != null)
            {
                return getBackendsAssociatedWithIpConfiguration(this.primaryInternetFacingLoadBalancer,
                        primaryNicDefaultIPConfiguration());
            }
            return new Dictionary<string, IBackend>();
        }

        public IDictionary<string, IInboundNatPool> ListPrimaryInternetFacingLoadBalancerInboundNatPools()
        {
            if ((this as Microsoft.Azure.Management.V2.Compute.IVirtualMachineScaleSet).GetPrimaryInternetFacingLoadBalancer() != null)
            {
                return getInboundNatPoolsAssociatedWithIpConfiguration(this.primaryInternetFacingLoadBalancer,
                        primaryNicDefaultIPConfiguration());
            }
            return new Dictionary<string, IInboundNatPool>();
        }

        public IList<string> PrimaryPublicIpAddressIds
        {
            get
            {
                ILoadBalancer loadBalancer = (this as Microsoft.Azure.Management.V2.Compute.IVirtualMachineScaleSet).GetPrimaryInternetFacingLoadBalancer();
                if (loadBalancer != null)
                {
                    return loadBalancer.PublicIpAddressIds;
                }
                return new List<string>();
            }
        }

        public VirtualMachineScaleSetStorageProfile StorageProfile
        {
            get
            {
                return this.Inner.VirtualMachineProfile.StorageProfile;
            }
        }

        public UpgradeMode? UpgradeModel
        {
            get
            {
                return this.Inner.UpgradePolicy.Mode;
            }
        }

        public IList<string> VhdContainers
        {
            get
            {
                if (this.Inner.VirtualMachineProfile.StorageProfile != null
                    && this.Inner.VirtualMachineProfile.StorageProfile.OsDisk != null
                    && this.Inner.VirtualMachineProfile.StorageProfile.OsDisk.VhdContainers != null)
                {
                    return this.Inner.VirtualMachineProfile.StorageProfile.OsDisk.VhdContainers;
                }
                return new List<string>();
            }
        }

        public PagedList<Microsoft.Azure.Management.V2.Compute.IVirtualMachineScaleSetSku> ListAvailableSkus()
        {
            throw new NotImplementedException();
        }

        public IDictionary<string, Microsoft.Azure.Management.V2.Compute.IVirtualMachineScaleSetExtension> Extensions()
        {
            return this.extensions;
        }

        public VirtualMachineScaleSetSkuTypes Sku()
        {
            return new VirtualMachineScaleSetSkuTypes(this.Inner.Sku);
        }

        #endregion

        #region Withers

        public VirtualMachineScaleSetImpl WithSku(VirtualMachineScaleSetSkuTypes skuType)
        {
            this.Inner.Sku = skuType.Sku;
            return this;
        }

        public VirtualMachineScaleSetImpl WithSku(IVirtualMachineScaleSetSku sku)
        {
            return this.WithSku(sku.SkuType());
        }

        public VirtualMachineScaleSetImpl WithExistingPrimaryNetworkSubnet(INetwork network, string subnetName)
        {
            this.existingPrimaryNetworkSubnetNameToAssociate = mergePath(network.Id, "subnets", subnetName);
            return this;
        }

        public VirtualMachineScaleSetImpl WithPrimaryInternetFacingLoadBalancer(ILoadBalancer loadBalancer)
        {
            if (loadBalancer.PublicIpAddressIds.Count == 0)
            {
                throw new ArgumentException("Parameter loadBalancer must be an internet facing load balancer");
            }

            if (this.IsInCreateMode)
            {
                this.primaryInternetFacingLoadBalancer = loadBalancer;
                associateLoadBalancerToIpConfiguration(this.primaryInternetFacingLoadBalancer,
                        this.primaryNicDefaultIPConfiguration());
            }
            else
            {
                this.primaryInternetFacingLoadBalancerToAttachOnUpdate = loadBalancer;
            }
            return this;
        }

        public VirtualMachineScaleSetImpl WithPrimaryInternetFacingLoadBalancerBackends(params string[] backendNames)
        {
            if (this.IsInCreateMode)
            {
                VirtualMachineScaleSetIPConfigurationInner defaultPrimaryIpConfig = this.primaryNicDefaultIPConfiguration();
                removeAllBackendAssociationFromIpConfiguration(this.primaryInternetFacingLoadBalancer, defaultPrimaryIpConfig);
                associateBackEndsToIpConfiguration(this.primaryInternetFacingLoadBalancer.Id,
                        defaultPrimaryIpConfig,
                        backendNames);
            }
            else
            {
                addToList(this.primaryInternetFacingLBBackendsToAddOnUpdate, backendNames);
            }
            return this;
        }

        public VirtualMachineScaleSetImpl WithPrimaryInternetFacingLoadBalancerInboundNatPools(params string[] natPoolNames)
        {
            if (this.IsInCreateMode)
            {
                VirtualMachineScaleSetIPConfigurationInner defaultPrimaryIpConfig = this.primaryNicDefaultIPConfiguration();
                removeAllInboundNatPoolAssociationFromIpConfiguration(this.primaryInternetFacingLoadBalancer,
                        defaultPrimaryIpConfig);
                associateInboundNATPoolsToIpConfiguration(this.primaryInternetFacingLoadBalancer.Id,
                        defaultPrimaryIpConfig,
                        natPoolNames);
            }
            else
            {
                addToList(this.primaryInternetFacingLBInboundNatPoolsToAddOnUpdate, natPoolNames);
            }
            return this;
        }

        public VirtualMachineScaleSetImpl WithPrimaryInternalLoadBalancer(ILoadBalancer loadBalancer)
        {
            if (loadBalancer.PublicIpAddressIds.Count != 0)
            {
                throw new ArgumentException("Parameter loadBalancer must be an internal load balancer");
            }
            string lbNetworkId = null;
            foreach (IFrontend frontEnd in loadBalancer.Frontends().Values)
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
                associateLoadBalancerToIpConfiguration(this.primaryInternalLoadBalancer,
                        this.primaryNicDefaultIPConfiguration());
            }
            else
            {
                string vmNicVnetId = ResourceUtils.ParentResourcePathFromResourceId(primaryNicDefaultIPConfiguration()
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

        public VirtualMachineScaleSetImpl WithPrimaryInternalLoadBalancerBackends(params string[] backendNames)
        {
            if (this.IsInCreateMode)
            {
                VirtualMachineScaleSetIPConfigurationInner defaultPrimaryIpConfig = primaryNicDefaultIPConfiguration();
                removeAllBackendAssociationFromIpConfiguration(this.primaryInternalLoadBalancer,
                        defaultPrimaryIpConfig);
                associateBackEndsToIpConfiguration(this.primaryInternalLoadBalancer.Id,
                        defaultPrimaryIpConfig,
                        backendNames);
            }
            else
            {
                addToList(this.primaryInternalLBBackendsToAddOnUpdate, backendNames);
            }
            return this;
        }

        public VirtualMachineScaleSetImpl WithPrimaryInternalLoadBalancerInboundNatPools(params string[] natPoolNames)
        {
            if (this.IsInCreateMode)
            {
                VirtualMachineScaleSetIPConfigurationInner defaultPrimaryIpConfig = this.primaryNicDefaultIPConfiguration();
                removeAllInboundNatPoolAssociationFromIpConfiguration(this.primaryInternalLoadBalancer,
                        defaultPrimaryIpConfig);
                associateInboundNATPoolsToIpConfiguration(this.primaryInternalLoadBalancer.Id,
                        defaultPrimaryIpConfig,
                        natPoolNames);
            }
            else
            {
                addToList(this.primaryInternalLBInboundNatPoolsToAddOnUpdate, natPoolNames);
            }
            return this;
        }

        public VirtualMachineScaleSetImpl WithoutPrimaryInternalLoadBalancer()
        {
            if (this.IsInUpdateMode)
            {
                this.removePrimaryInternalLoadBalancerOnUpdate = true;
            }
            return this;
        }

        public VirtualMachineScaleSetImpl WithoutPrimaryInternetFacingLoadBalancer()
        {
            if (this.IsInUpdateMode)
            {
                this.removePrimaryInternetFacingLoadBalancerOnUpdate = true;
            }
            return this;
        }

        public VirtualMachineScaleSetImpl WithoutPrimaryInternetFacingLoadBalancerBackends(params string[] backendNames)
        {
            addToList(this.primaryInternetFacingLBBackendsToRemoveOnUpdate, backendNames);
            return this;
        }

        public VirtualMachineScaleSetImpl WithoutPrimaryInternalLoadBalancerBackends(params string[] backendNames)
        {
            addToList(this.primaryInternalLBBackendsToRemoveOnUpdate, backendNames);
            return this;
        }

        public VirtualMachineScaleSetImpl WithoutPrimaryInternetFacingLoadBalancerNatPools(params string[] natPoolNames)
        {
            addToList(this.primaryInternalLBInboundNatPoolsToRemoveOnUpdate, natPoolNames);
            return this;
        }

        public VirtualMachineScaleSetImpl WithoutPrimaryInternalLoadBalancerNatPools(params string[] natPoolNames)
        {
            addToList(this.primaryInternetFacingLBInboundNatPoolsToRemoveOnUpdate, natPoolNames);
            return this;
        }

        public VirtualMachineScaleSetImpl WithPopularWindowsImage(KnownWindowsVirtualMachineImage knownImage)
        {
            return WithSpecificWindowsImageVersion(knownImage.ImageReference());
        }

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
                    .OsProfile.WindowsConfiguration = new WindowsConfiguration();
            // sets defaults for "Stored(Custom)Image" or "VM(Platform)Image"
            this.Inner
                    .VirtualMachineProfile
                    .OsProfile.WindowsConfiguration.ProvisionVMAgent = true;
            this.Inner
                    .VirtualMachineProfile
                    .OsProfile.WindowsConfiguration.EnableAutomaticUpdates = true;
            return this;
        }

        public VirtualMachineScaleSetImpl WithStoredWindowsImage(string imageUrl)
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
                    .StorageProfile.OsDisk.OsType = OperatingSystemTypes.Windows;
            this.Inner
                    .VirtualMachineProfile
                    .OsProfile.WindowsConfiguration = new WindowsConfiguration();
            // sets defaults for "Stored(Custom)Image" or "VM(Platform)Image"
            this.Inner
                    .VirtualMachineProfile
                    .OsProfile.WindowsConfiguration.ProvisionVMAgent = true;
            this.Inner
                    .VirtualMachineProfile
                    .OsProfile.WindowsConfiguration.EnableAutomaticUpdates = true;
            return this;
        }

        public VirtualMachineScaleSetImpl WithPopularLinuxImage(KnownLinuxVirtualMachineImage knownImage)
        {
            return WithSpecificLinuxImageVersion(knownImage.ImageReference());
        }

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

        public VirtualMachineScaleSetImpl WithStoredLinuxImage(String imageUrl)
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

        public VirtualMachineScaleSetImpl WithAdminUserName(String adminUserName)
        {
            this.Inner
                    .VirtualMachineProfile
                    .OsProfile
                    .AdminUsername = adminUserName;
            return this;
        }

        public VirtualMachineScaleSetImpl WithRootUserName(String rootUserName)
        {
            return this.WithAdminUserName(rootUserName);
        }

        public VirtualMachineScaleSetImpl WithPassword(string password)
        {
            this.Inner
                    .VirtualMachineProfile
                    .OsProfile
                    .AdminPassword = password;
            return this;
        }

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

        public VirtualMachineScaleSetImpl WithVmAgent()
        {
            this.Inner
                    .VirtualMachineProfile
                    .OsProfile.WindowsConfiguration.ProvisionVMAgent = true;
            return this;
        }

        public VirtualMachineScaleSetImpl WithoutVmAgent()
        {
            this.Inner
                    .VirtualMachineProfile
                    .OsProfile.WindowsConfiguration.ProvisionVMAgent = true;
            return this;
        }

        public VirtualMachineScaleSetImpl WithAutoUpdate()
        {
            this.Inner
                    .VirtualMachineProfile
                    .OsProfile.WindowsConfiguration.EnableAutomaticUpdates = true;
            return this;
        }

        public VirtualMachineScaleSetImpl WithoutAutoUpdate()
        {
            this.Inner
                    .VirtualMachineProfile
                    .OsProfile.WindowsConfiguration.EnableAutomaticUpdates = false;
            return this;
        }

        public VirtualMachineScaleSetImpl WithTimeZone(string timeZone)
        {
            this.Inner
                    .VirtualMachineProfile
                    .OsProfile.WindowsConfiguration.TimeZone = timeZone;
            return this;
        }

        public VirtualMachineScaleSetImpl WithWinRm(WinRMListener listener)
        {
            if (this.Inner.VirtualMachineProfile.OsProfile.WindowsConfiguration.WinRM == null)
            {
                WinRMConfiguration winRMConfiguration = new WinRMConfiguration();
                this.Inner
                        .VirtualMachineProfile
                        .OsProfile.WindowsConfiguration.WinRM = winRMConfiguration;
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

        public VirtualMachineScaleSetImpl WithOsDiskCaching(CachingTypes cachingType)
        {
            this.Inner
                    .VirtualMachineProfile
                    .StorageProfile.OsDisk.Caching = cachingType;
            return this;
        }

        public VirtualMachineScaleSetImpl WithOsDiskName(string name)
        {
            this.Inner
                    .VirtualMachineProfile
                    .StorageProfile.OsDisk.Name = name;
            return this;
        }

        public VirtualMachineScaleSetImpl WithComputerNamePrefix(string namePrefix)
        {
            this.Inner
                    .VirtualMachineProfile
                    .OsProfile
                    .ComputerNamePrefix = namePrefix;
            return this;
        }

        public VirtualMachineScaleSetImpl WithUpgradeMode(UpgradeMode upgradeMode)
        {
            this.Inner
                    .UpgradePolicy
                    .Mode = upgradeMode;
            return this;
        }

        public VirtualMachineScaleSetImpl WithOverProvision(bool enabled)
        {
            this.Inner
                    .OverProvision = enabled;
            return this;
        }

        public VirtualMachineScaleSetImpl WithoutOverProvisioning()
        {
            return this.WithOverProvision(true);
        }

        public VirtualMachineScaleSetImpl WithOverProvisioning()
        {
            return this.WithOverProvision(false);
        }

        public VirtualMachineScaleSetImpl WithCapacity(int capacity)
        {
            this.Inner
                    .Sku.Capacity = capacity;
            return this;
        }

        public VirtualMachineScaleSetImpl WithNewStorageAccount(String name)
        {
            Storage.StorageAccount.Definition.IWithGroup definitionWithGroup = this.storageManager
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

        public VirtualMachineScaleSetImpl WithNewStorageAccount(ICreatable<IStorageAccount> creatable)
        {
            this.creatableStorageAccountKeys.Add(creatable.Key);
            this.AddCreatableDependency(creatable as IResourceCreator<Microsoft.Azure.Management.V2.Resource.Core.IResource>);
            return this;
        }

        public VirtualMachineScaleSetImpl WithExistingStorageAccount(IStorageAccount storageAccount)
        {
            this.existingStorageAccountsToAssociate.Add(storageAccount);
            return this;
        }

        public VirtualMachineScaleSetExtensionImpl DefineNewExtension(string name)
        {
            return new VirtualMachineScaleSetExtensionImpl(new VirtualMachineScaleSetExtensionInner { Name = name }, this);
        }

        internal VirtualMachineScaleSetImpl WithExtension(VirtualMachineScaleSetExtensionImpl extension)
        {
            this.extensions.Add(extension.Name, extension);
            return this;
        }

        public VirtualMachineScaleSetExtensionImpl UpdateExtension(string name)
        {
            IVirtualMachineScaleSetExtension value = null;
            if (!this.extensions.TryGetValue(name, out value))
            {
                throw new ArgumentException("Extension with name '" + name + "' not found");
            }
            return (VirtualMachineScaleSetExtensionImpl)value;
        }

        public VirtualMachineScaleSetImpl WithoutExtension(String name)
        {
            if (this.extensions.ContainsKey(name))
            {
                this.extensions.Remove(name);
            }
            return this;
        }

        #endregion

        #region Actions
        public override IVirtualMachineScaleSet Refresh()
        {
            var response = client.Get(this.ResourceGroupName,
                this.Name);
            SetInner(response);
            return this;
        }

        public void Deallocate()
        {
            this.client.Deallocate(this.ResourceGroupName, this.Name);
        }

        public void PowerOff()
        {
            this.client.PowerOff(this.ResourceGroupName, this.Name);
        }

        public void Reimage()
        {
            this.client.Reimage(this.ResourceGroupName, this.Name);
        }

        public void Restart()
        {
            this.client.Restart(this.ResourceGroupName, this.Name);
        }

        public void Start()
        {
            this.client.Start(this.ResourceGroupName, this.Name);
        }

        #endregion

        public override async Task<IVirtualMachineScaleSet> CreateResourceAsync(CancellationToken cancellationToken)
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

            this.setOSDiskAndOSProfileDefaults();
            this.setPrimaryIpConfigurationBackendsAndInboundNatPools();
            await handleOSDiskContainersAsync();
            await client.CreateOrUpdateAsync(this.ResourceGroupName, this.Name, this.Inner);
            this.clearCachedProperties();
            return this;
        }

        #region Helpers

        private bool IsInUpdateMode
        {
            get
            {
                return !this.IsInCreateMode;
            }
        }

        private void setOSDiskAndOSProfileDefaults()
        {
            Microsoft.Azure.Management.V2.Compute.IVirtualMachineScaleSet self = this
                as Microsoft.Azure.Management.V2.Compute.IVirtualMachineScaleSet;
            if (this.IsInUpdateMode)
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
            if (self.OsType == OperatingSystemTypes.Linux || this.isMarketplaceLinuxImage)
            {
                if (osProfile.LinuxConfiguration == null)
                {
                    osProfile.LinuxConfiguration = new LinuxConfiguration();
                }
                osProfile
                    .LinuxConfiguration
                    .DisablePasswordAuthentication = osProfile.AdminPassword == null;
            }

            if (self.OsDiskCachingType == null)
            {
                this.WithOsDiskCaching(CachingTypes.ReadWrite);
            }

            if (self.OsDiskName == null)
            {
                this.WithOsDiskName(this.Name + "-os-disk");
            }

            if (self.ComputerNamePrefix == null)
            {
                // VM name cannot contain only numeric values and cannot exceed 15 chars
                if ((new Regex(@"^\d+$")).IsMatch(self.Name))
                {
                    this.WithComputerNamePrefix(ResourceNamer.RandomResourceName("vmss-vm", 12));
                }
                else if (self.Name.Length <= 12)
                {
                    this.WithComputerNamePrefix(this.Name + "-vm");
                }
                else
                {
                    this.WithComputerNamePrefix(ResourceNamer.RandomResourceName("vmss-vm", 12));
                }
            }
        }

        private bool isCustomImage(VirtualMachineScaleSetStorageProfile storageProfile)
        {
            return storageProfile.OsDisk.Image != null
                    && storageProfile.OsDisk.Image.Uri != null;
        }

        private async Task handleOSDiskContainersAsync()
        {
            VirtualMachineScaleSetStorageProfile storageProfile = this.Inner
                    .VirtualMachineProfile
                    .StorageProfile;
            if (isCustomImage(storageProfile))
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
                        .Add(mergePath(storageAccount.EndPoints.Primary.Blob, containerName));
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
                            .Add(mergePath(storageAccount.EndPoints.Primary.Blob, containerName));
                }

                foreach (IStorageAccount storageAccount in this.existingStorageAccountsToAssociate)
                {
                    storageProfile.OsDisk
                            .VhdContainers
                            .Add(mergePath(storageAccount.EndPoints.Primary.Blob, containerName));
                }

                this.vhdContainerName = null;
                this.creatableStorageAccountKeys.Clear();
                this.existingStorageAccountsToAssociate.Clear();
            }
        }

        private void setPrimaryIpConfigurationSubnet()
        {
            if (this.IsInUpdateMode)
            {
                return;
            }

            VirtualMachineScaleSetIPConfigurationInner ipConfig = this.primaryNicDefaultIPConfiguration();
            ipConfig.Subnet = new ApiEntityReference
            {
                    Id = this.existingPrimaryNetworkSubnetNameToAssociate
            };
            this.existingPrimaryNetworkSubnetNameToAssociate = null;
        }

        private void setPrimaryIpConfigurationBackendsAndInboundNatPools()
        {
            if (this.IsInCreateMode)
            {
                return;
            }

            this.loadCurrentPrimaryLoadBalancersIfAvailable();

            VirtualMachineScaleSetIPConfigurationInner primaryIpConfig = primaryNicDefaultIPConfiguration();
            if (this.primaryInternetFacingLoadBalancer != null)
            {
                removeBackendsFromIpConfiguration(this.primaryInternetFacingLoadBalancer.Id,
                        primaryIpConfig,
                        this.primaryInternetFacingLBBackendsToRemoveOnUpdate.ToArray());

                associateBackEndsToIpConfiguration(primaryInternetFacingLoadBalancer.Id,
                        primaryIpConfig,
                        this.primaryInternetFacingLBBackendsToAddOnUpdate.ToArray());

                removeInboundNatPoolsFromIpConfiguration(this.primaryInternetFacingLoadBalancer.Id,
                        primaryIpConfig,
                        this.primaryInternetFacingLBInboundNatPoolsToRemoveOnUpdate.ToArray());

                associateInboundNATPoolsToIpConfiguration(primaryInternetFacingLoadBalancer.Id,
                        primaryIpConfig,
                        this.primaryInternetFacingLBInboundNatPoolsToAddOnUpdate.ToArray());
            }

            if (this.primaryInternalLoadBalancer != null)
            {
                removeBackendsFromIpConfiguration(this.primaryInternalLoadBalancer.Id,
                        primaryIpConfig,
                        this.primaryInternalLBBackendsToRemoveOnUpdate.ToArray());

                associateBackEndsToIpConfiguration(primaryInternalLoadBalancer.Id,
                        primaryIpConfig,
                        this.primaryInternalLBBackendsToAddOnUpdate.ToArray());

                removeInboundNatPoolsFromIpConfiguration(this.primaryInternalLoadBalancer.Id,
                        primaryIpConfig,
                        this.primaryInternalLBInboundNatPoolsToRemoveOnUpdate.ToArray());

                associateInboundNATPoolsToIpConfiguration(primaryInternalLoadBalancer.Id,
                        primaryIpConfig,
                        this.primaryInternalLBInboundNatPoolsToAddOnUpdate.ToArray());
            }

            if (this.removePrimaryInternetFacingLoadBalancerOnUpdate)
            {
                if (this.primaryInternetFacingLoadBalancer != null)
                {
                    removeLoadBalancerAssociationFromIpConfiguration(this.primaryInternetFacingLoadBalancer, primaryIpConfig);
                }
            }

            if (this.removePrimaryInternalLoadBalancerOnUpdate)
            {
                if (this.primaryInternalLoadBalancer != null)
                {
                    removeLoadBalancerAssociationFromIpConfiguration(this.primaryInternalLoadBalancer, primaryIpConfig);
                }
            }

            if (this.primaryInternetFacingLoadBalancerToAttachOnUpdate != null)
            {
                if (this.primaryInternetFacingLoadBalancer != null)
                {
                    removeLoadBalancerAssociationFromIpConfiguration(this.primaryInternetFacingLoadBalancer, primaryIpConfig);
                }
                associateLoadBalancerToIpConfiguration(this.primaryInternetFacingLoadBalancerToAttachOnUpdate, primaryIpConfig);
                if (this.primaryInternetFacingLBBackendsToAddOnUpdate.Count > 0)
                {
                    removeAllBackendAssociationFromIpConfiguration(this.primaryInternetFacingLoadBalancerToAttachOnUpdate, primaryIpConfig);
                    associateBackEndsToIpConfiguration(this.primaryInternetFacingLoadBalancerToAttachOnUpdate.Id,
                            primaryIpConfig,
                            this.primaryInternetFacingLBBackendsToAddOnUpdate.ToArray());
                }
                if (this.primaryInternetFacingLBInboundNatPoolsToAddOnUpdate.Count > 0)
                {
                    removeAllInboundNatPoolAssociationFromIpConfiguration(this.primaryInternetFacingLoadBalancerToAttachOnUpdate, primaryIpConfig);
                    associateInboundNATPoolsToIpConfiguration(this.primaryInternetFacingLoadBalancerToAttachOnUpdate.Id,
                            primaryIpConfig,
                            this.primaryInternetFacingLBInboundNatPoolsToAddOnUpdate.ToArray());
                }
            }

            if (this.primaryInternalLoadBalancerToAttachOnUpdate != null)
            {
                if (this.primaryInternalLoadBalancer != null)
                {
                    removeLoadBalancerAssociationFromIpConfiguration(this.primaryInternalLoadBalancer, primaryIpConfig);
                }
                associateLoadBalancerToIpConfiguration(this.primaryInternalLoadBalancerToAttachOnUpdate, primaryIpConfig);
                if (this.primaryInternalLBBackendsToAddOnUpdate.Count > 0)
                {
                    removeAllBackendAssociationFromIpConfiguration(this.primaryInternalLoadBalancerToAttachOnUpdate, primaryIpConfig);
                    associateBackEndsToIpConfiguration(this.primaryInternalLoadBalancerToAttachOnUpdate.Id,
                            primaryIpConfig,
                            this.primaryInternalLBBackendsToAddOnUpdate.ToArray());
                }

                if (this.primaryInternalLBInboundNatPoolsToAddOnUpdate.Count > 0)
                {
                    removeAllInboundNatPoolAssociationFromIpConfiguration(this.primaryInternalLoadBalancerToAttachOnUpdate, primaryIpConfig);
                    associateInboundNATPoolsToIpConfiguration(this.primaryInternalLoadBalancerToAttachOnUpdate.Id,
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

        private void clearCachedProperties()
        {
            this.primaryInternetFacingLoadBalancer = null;
            this.primaryInternalLoadBalancer = null;
            this.primaryVirtualNetwork = null;
        }

        private void loadCurrentPrimaryLoadBalancersIfAvailable()
        {
            if (this.primaryInternetFacingLoadBalancer != null && this.primaryInternalLoadBalancer != null)
            {
                return;
            }

            string firstLoadBalancerId = null;
            VirtualMachineScaleSetIPConfigurationInner ipConfig = primaryNicDefaultIPConfiguration();
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

        private VirtualMachineScaleSetIPConfigurationInner primaryNicDefaultIPConfiguration()
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

        private static void associateBackEndsToIpConfiguration(String loadBalancerId,
                                                        VirtualMachineScaleSetIPConfigurationInner ipConfig,
                                                        params string[] backendNames)
        {
            List<SubResource> backendSubResourcesToAssociate = new List<SubResource>();
            foreach (string backendName in backendNames)
            {
                String backendPoolId = mergePath(loadBalancerId, "backendAddressPools", backendName);
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

        private static void associateInboundNATPoolsToIpConfiguration(String loadBalancerId,
                                                        VirtualMachineScaleSetIPConfigurationInner ipConfig,
                                                        params string[] inboundNatPools)
        {
            List<SubResource> inboundNatPoolSubResourcesToAssociate = new List<SubResource>();
            foreach (string inboundNatPool in inboundNatPools)
            {
                string inboundNatPoolId = mergePath(loadBalancerId, "inboundNatPools", inboundNatPool);
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

        private static IDictionary<string, IBackend> getBackendsAssociatedWithIpConfiguration(ILoadBalancer loadBalancer,
                                                                                     VirtualMachineScaleSetIPConfigurationInner ipConfig)
        {
            string loadBalancerId = loadBalancer.Id;
            IDictionary<string, IBackend> attachedBackends = new Dictionary<string, IBackend>();
            IDictionary<string, IBackend> lbBackends = loadBalancer.Backends();
            foreach (IBackend lbBackend in lbBackends.Values)
            {
                string backendId = mergePath(loadBalancerId, "backendAddressPools", lbBackend.Name);
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

        private static IDictionary<string, IInboundNatPool> getInboundNatPoolsAssociatedWithIpConfiguration(ILoadBalancer loadBalancer,
                                                                                                   VirtualMachineScaleSetIPConfigurationInner ipConfig)
        {
            String loadBalancerId = loadBalancer.Id;
            IDictionary<string, IInboundNatPool> attachedInboundNatPools = new Dictionary<string, IInboundNatPool>();
            IDictionary<string, IInboundNatPool> lbInboundNatPools = loadBalancer.InboundNatPools();
            foreach (IInboundNatPool lbInboundNatPool in lbInboundNatPools.Values)
            {
                String inboundNatPoolId = mergePath(loadBalancerId, "inboundNatPools", lbInboundNatPool.Name);
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

        private static void associateLoadBalancerToIpConfiguration(ILoadBalancer loadBalancer,
                                                                   VirtualMachineScaleSetIPConfigurationInner ipConfig)
        {
            var backends = loadBalancer.Backends().Values;

            string[] backendNames = new string[backends.Count];
            int i = 0;
            foreach (IBackend backend in backends)
            {
                backendNames[i] = backend.Name;
                i++;
            }

            associateBackEndsToIpConfiguration(loadBalancer.Id,
                    ipConfig,
                    backendNames);

            var inboundNatPools = loadBalancer.InboundNatPools().Values;
            string[] natPoolNames = new string[inboundNatPools.Count];
            i = 0;
            foreach (IInboundNatPool inboundNatPool in inboundNatPools)
            {
                natPoolNames[i] = inboundNatPool.Name;
                i++;
            }

            associateInboundNATPoolsToIpConfiguration(loadBalancer.Id,
                    ipConfig,
                    natPoolNames);
        }

        private static void removeLoadBalancerAssociationFromIpConfiguration(ILoadBalancer loadBalancer,
                                                                             VirtualMachineScaleSetIPConfigurationInner ipConfig)
        {
            removeAllBackendAssociationFromIpConfiguration(loadBalancer, ipConfig);
            removeAllInboundNatPoolAssociationFromIpConfiguration(loadBalancer, ipConfig);
        }

        private static void removeAllBackendAssociationFromIpConfiguration(ILoadBalancer loadBalancer,
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

        private static void removeAllInboundNatPoolAssociationFromIpConfiguration(ILoadBalancer loadBalancer,
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

        private static void removeBackendsFromIpConfiguration(string loadBalancerId,
                                                       VirtualMachineScaleSetIPConfigurationInner ipConfig,
                                                       params string[] backendNames)
        {
            List<SubResource> toRemove = new List<SubResource>();
            foreach (string backendName in backendNames)
            {
                string backendPoolId = mergePath(loadBalancerId, "backendAddressPools", backendName);
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

        private static void removeInboundNatPoolsFromIpConfiguration(String loadBalancerId,
                                                              VirtualMachineScaleSetIPConfigurationInner ipConfig,
                                                              params string[] inboundNatPoolNames)
        {
            List<SubResource> toRemove = new List<SubResource>();
            foreach (string natPoolName in inboundNatPoolNames)
            {
                string inboundNatPoolId = mergePath(loadBalancerId, "inboundNatPools", natPoolName);
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

        private static void addToList<T>(List<T> list, params T[] items)
        {
            foreach (T item in items)
            {
                list.Add(item);
            }
        }

        private static string mergePath(params string[] segments)
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
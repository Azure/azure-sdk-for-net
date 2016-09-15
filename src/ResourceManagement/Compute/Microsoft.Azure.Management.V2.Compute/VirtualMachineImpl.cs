/**
* Copyright (c) Microsoft Corporation. All rights reserved.
* Licensed under the MIT License. See License.txt in the project root for
* license information.
*/

namespace Microsoft.Azure.Management.V2.Compute
{

    using Microsoft.Azure.Management.Compute.Models;
    using Microsoft.Azure.Management.V2.Network;
    using Microsoft.Azure.Management.V2.Network.NetworkInterface.Definition;
    using Microsoft.Azure.Management.V2.Compute.VirtualMachine.Definition;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.V2.Resource.Core;
    using System.Collections.Generic;
    using Microsoft.Azure.Management.V2.Resource.Core.ResourceActions;
    using Microsoft.Rest;
    using Microsoft.Azure.Management.Storage.Models;
    using Microsoft.Azure.Management.V2.Storage;
    using Microsoft.Azure.Management.V2.Resource;
    using Microsoft.Azure.Management.V2.Compute.VirtualMachine.Update;
    using System.Threading;
    using Microsoft.Azure.Management.Network.Models;
    using Management.Compute;
    using System;
    using System.Text.RegularExpressions;

    /// <summary>
    /// The implementation for {@link VirtualMachine} and its create and update interfaces.
    /// </summary>
    public partial class VirtualMachineImpl :
        GroupableResource<IVirtualMachine,
            VirtualMachineInner,
            Rest.Azure.Resource,
            VirtualMachineImpl,
            IComputeManager,
            VirtualMachine.Definition.IWithGroup,
            VirtualMachine.Definition.IWithNetwork,
            VirtualMachine.Definition.IWithCreate,
            IUpdate>,
        IVirtualMachine,
        VirtualMachine.Definition.IDefinition,
        IUpdate
    {
        private IVirtualMachinesOperations client;
        private IStorageManager storageManager;
        private INetworkManager networkManager;
        private string vmName;
        private ResourceNamer namer;
        private string creatableStorageAccountKey;
        private string creatableAvailabilitySetKey;
        private string creatablePrimaryNetworkInterfaceKey;
        private IList<string> creatableSecondaryNetworkInterfaceKeys;
        private IStorageAccount existingStorageAccountToAssociate;
        private IAvailabilitySet existingAvailabilitySetToAssociate;
        private INetworkInterface existingPrimaryNetworkInterfaceToAssociate;
        private IList<INetworkInterface> existingSecondaryNetworkInterfacesToAssociate;
        private INetworkInterface primaryNetworkInterface;
        private IPublicIpAddress primaryPublicIpAddress;
        private VirtualMachineInstanceView virtualMachineInstanceView;
        private bool isMarketplaceLinuxImage;
        private IList<IVirtualMachineDataDisk> dataDisks;
        private IWithPrimaryPrivateIp nicDefinitionWithPrivateIp;
        private IWithPrimaryNetworkSubnet nicDefinitionWithSubnet;
        private Network.NetworkInterface.Definition.IWithCreate nicDefinitionWithCreate;

        //private PagedListConverter<VirtualMachineSizeOperations,IVirtualMachineSize> virtualMachineSizeConverter;

        internal VirtualMachineImpl(string name,
            VirtualMachineInner innerModel,
            IVirtualMachinesOperations client,
            IComputeManager computeManager,
            IStorageManager storageManager,
            INetworkManager networkManager) :
            base(name, innerModel, computeManager)
        {

            this.client = client;
            this.storageManager = storageManager;
            this.networkManager = networkManager;
            this.vmName = name;
            this.isMarketplaceLinuxImage = false;
            this.namer = new ResourceNamer(this.vmName);
            this.creatableSecondaryNetworkInterfaceKeys = new List<string>();
            this.existingSecondaryNetworkInterfacesToAssociate = new List<INetworkInterface>();
            // this.virtualMachineSizeConverter = new PagedListConverter<VirtualMachineSizeInner, VirtualMachineSize>() {
            // @Override
            // public VirtualMachineSize typeConvert(VirtualMachineSizeInner inner) {
            // return new VirtualMachineSizeImpl(inner);
            // }
            // };
            InitializeDataDisks();
            // }
        }

        public async override Task<IVirtualMachine> Refresh()
        {
            var response = await client.GetWithHttpMessagesAsync(this.ResourceGroupName,
                this.Name);
            SetInner(response.Body);
            return this;
        }

        public void Deallocate()
        {
            this.client.Deallocate(this.ResourceGroupName, this.Name);
        }

        public void Generalize()
        {
            this.client.Generalize(this.ResourceGroupName, this.Name);
        }

        public void PowerOff()
        {
            this.client.PowerOff(this.ResourceGroupName, this.Name);
        }

        public void Restart()
        {
            this.client.Restart(this.ResourceGroupName, this.Name);
        }

        public void Start()
        {
            this.client.Start(this.ResourceGroupName, this.Name);
        }

        public void Redeploy()
        {
            this.client.Redeploy(this.ResourceGroupName, this.Name);
        }

        public PagedList<IVirtualMachineSize> AvailableSizes()
        {
            // PageImpl<VirtualMachineSizeInner> page = new PageImpl<>();
            // page.setItems(this.client.listAvailableSizes(this.ResourceGroupName, this.Name).getBody());
            // page.setNextPageLink(null);
            // return this.virtualMachineSizeConverter.convert(new PagedList<VirtualMachineSizeInner>(page) {
            // @Override
            // public Page<VirtualMachineSizeInner> nextPage(String nextPageLink) throws RestException, IOException {
            // return null;
            // }
            // });

            return null;
        }

        public string Capture(string containerName, bool overwriteVhd)
        {
            VirtualMachineCaptureParametersInner parameters = new VirtualMachineCaptureParametersInner();
            parameters.DestinationContainerName = containerName;
            parameters.OverwriteVhds = overwriteVhd;
            VirtualMachineCaptureResultInner captureResult = this.client.Capture(this.ResourceGroupName, this.Name, parameters);
            return captureResult.ToString();
        }

        public VirtualMachineInstanceView RefreshInstanceView()
        {
            this.virtualMachineInstanceView = this.client.Get(this.ResourceGroupName,
                this.Name,
                InstanceViewTypes.InstanceView).InstanceView;
            return this.virtualMachineInstanceView;
        }

        /// <summary>
        /// .
        /// Setters
        /// </summary>
        public VirtualMachineImpl WithNewPrimaryNetwork(ICreatable<INetwork> creatable)
        {
            this.nicDefinitionWithPrivateIp = this.PreparePrimaryNetworkInterface(this.namer.RandomName("nic", 20))
                .WithNewPrimaryNetwork(creatable);
            return this;
        }

        public VirtualMachineImpl WithNewPrimaryNetwork(string addressSpace)
        {
            this.nicDefinitionWithPrivateIp = this.PreparePrimaryNetworkInterface(this.namer.RandomName("nic", 20))
                .WithNewPrimaryNetwork(addressSpace);
            return this;
        }

        public VirtualMachineImpl WithExistingPrimaryNetwork(INetwork network)
        {
            this.nicDefinitionWithSubnet = this.PreparePrimaryNetworkInterface(this.namer.RandomName("nic", 20))
                .WithExistingPrimaryNetwork(network);
            return this;
        }

        public VirtualMachineImpl WithSubnet(string name)
        {
            this.nicDefinitionWithPrivateIp = this.nicDefinitionWithSubnet
                .WithSubnet(name);
            return this;
        }

        public VirtualMachineImpl WithPrimaryPrivateIpAddressDynamic()
        {
            this.nicDefinitionWithCreate = this.nicDefinitionWithPrivateIp
                .WithPrimaryPrivateIpAddressDynamic();
            return this;
        }

        public VirtualMachineImpl WithPrimaryPrivateIpAddressStatic(string staticPrivateIpAddress)
        {
            this.nicDefinitionWithCreate = this.nicDefinitionWithPrivateIp
                .WithPrimaryPrivateIpAddressStatic(staticPrivateIpAddress);
            return this;
        }

        public VirtualMachineImpl WithNewPrimaryPublicIpAddress(ICreatable<IPublicIpAddress> creatable)
        {
            var nicCreatable = this.nicDefinitionWithCreate
                .WithNewPrimaryPublicIpAddress(creatable);
            this.AddCreatableDependency(nicCreatable as IResourceCreator<IResource>);
            return this;
        }

        public VirtualMachineImpl WithNewPrimaryPublicIpAddress(string leafDnsLabel)
        {
            var nicCreatable = this.nicDefinitionWithCreate
                .WithNewPrimaryPublicIpAddress(leafDnsLabel);
            this.creatablePrimaryNetworkInterfaceKey = nicCreatable.Key;
            this.AddCreatableDependency(nicCreatable as IResourceCreator<IResource>);
            return this;
        }

        public VirtualMachineImpl WithExistingPrimaryPublicIpAddress(IPublicIpAddress publicIpAddress)
        {
            var nicCreatable = this.nicDefinitionWithCreate
                .WithExistingPrimaryPublicIpAddress(publicIpAddress);
            this.creatablePrimaryNetworkInterfaceKey = nicCreatable.Key;
            this.AddCreatableDependency(nicCreatable as IResourceCreator<IResource>);
            return this;
        }

        public VirtualMachineImpl WithoutPrimaryPublicIpAddress()
        {
            var nicCreatable = this.nicDefinitionWithCreate;
            this.creatablePrimaryNetworkInterfaceKey = nicCreatable.Key;
            this.AddCreatableDependency(nicCreatable as IResourceCreator<IResource>);
            return this;
        }

        public VirtualMachineImpl WithNewPrimaryNetworkInterface(ICreatable<INetworkInterface> creatable)
        {
            this.creatablePrimaryNetworkInterfaceKey = creatable.Key;
            this.AddCreatableDependency(creatable as IResourceCreator<IResource>);
            return this;
        }

        public VirtualMachineImpl WithNewPrimaryNetworkInterface(string name, string publicDnsNameLabel)
        {
            var definitionCreatable = PrepareNetworkInterface(name)
                .WithNewPrimaryPublicIpAddress(publicDnsNameLabel);
            return WithNewPrimaryNetworkInterface(definitionCreatable);
        }

        public VirtualMachineImpl WithExistingPrimaryNetworkInterface(INetworkInterface networkInterface)
        {
            this.existingPrimaryNetworkInterfaceToAssociate = networkInterface;
            return this;
        }

        public VirtualMachineImpl WithStoredWindowsImage(string imageUrl)
        {
            VirtualHardDisk userImageVhd = new VirtualHardDisk();
            userImageVhd.Uri = imageUrl;
            this.Inner.StorageProfile.OsDisk.CreateOption = DiskCreateOptionTypes.FromImage;
            this.Inner.StorageProfile.OsDisk.Image = userImageVhd;
            // For platform image osType will be null, azure will pick it from the image metadata.
            this.Inner.StorageProfile.OsDisk.OsType = OperatingSystemTypes.Windows;
            this.Inner.OsProfile.WindowsConfiguration = new WindowsConfiguration();
            // sets defaults for "Stored(User)Image" or "VM(Platform)Image"
            this.Inner.OsProfile.WindowsConfiguration.ProvisionVMAgent = true;
            this.Inner.OsProfile.WindowsConfiguration.EnableAutomaticUpdates = true;
            return this;
        }

        public VirtualMachineImpl WithStoredLinuxImage(string imageUrl)
        {
            VirtualHardDisk userImageVhd = new VirtualHardDisk();
            userImageVhd.Uri = imageUrl;
            this.Inner.StorageProfile.OsDisk.CreateOption = DiskCreateOptionTypes.FromImage;
            this.Inner.StorageProfile.OsDisk.Image = userImageVhd;
            // For platform image osType will be null, azure will pick it from the image metadata.
            this.Inner.StorageProfile.OsDisk.OsType = OperatingSystemTypes.Linux;
            this.Inner.OsProfile.LinuxConfiguration = new LinuxConfiguration();
            return this;
        }

        public VirtualMachineImpl WithPopularWindowsImage(KnownWindowsVirtualMachineImage knownImage)
        {
            return WithSpecificWindowsImageVersion(knownImage.ImageReference());
        }

        public VirtualMachineImpl WithPopularLinuxImage(KnownLinuxVirtualMachineImage knownImage)
        {
            return WithSpecificLinuxImageVersion(knownImage.ImageReference());
        }

        public VirtualMachineImpl WithSpecificWindowsImageVersion(ImageReference imageReference)
        {
            this.Inner.StorageProfile.OsDisk.CreateOption = DiskCreateOptionTypes.FromImage;
            this.Inner.StorageProfile.ImageReference = imageReference;
            this.Inner.OsProfile.WindowsConfiguration = new WindowsConfiguration();
            // sets defaults for "Stored(User)Image" or "VM(Platform)Image"
            this.Inner.OsProfile.WindowsConfiguration.ProvisionVMAgent = true;
            this.Inner.OsProfile.WindowsConfiguration.EnableAutomaticUpdates = true;
            return this;
        }

        public VirtualMachineImpl WithSpecificLinuxImageVersion(ImageReference imageReference)
        {
            this.Inner.StorageProfile.OsDisk.CreateOption = DiskCreateOptionTypes.FromImage;
            this.Inner.StorageProfile.ImageReference = imageReference;
            this.Inner.OsProfile.LinuxConfiguration = new LinuxConfiguration();
            this.isMarketplaceLinuxImage = true;
            return this;
        }

        public VirtualMachineImpl WithLatestWindowsImage(string publisher, string offer, string sku)
        {
            ImageReference imageReference = new ImageReference();
            imageReference.Publisher = publisher;
            imageReference.Offer = offer;
            imageReference.Sku = sku;
            imageReference.Version = "latest";
            return WithSpecificWindowsImageVersion(imageReference);
        }

        public VirtualMachineImpl WithLatestLinuxImage(string publisher, string offer, string sku)
        {
            ImageReference imageReference = new ImageReference();
            imageReference.Publisher = publisher;
            imageReference.Offer = offer;
            imageReference.Sku = sku;
            imageReference.Version = "latest";
            return WithSpecificLinuxImageVersion(imageReference);
        }

        public VirtualMachineImpl WithOsDisk(string osDiskUrl, OperatingSystemTypes osType)
        {
            VirtualHardDisk osDisk = new VirtualHardDisk();
            osDisk.Uri = osDiskUrl;
            this.Inner.StorageProfile.OsDisk.CreateOption = DiskCreateOptionTypes.Attach;
            this.Inner.StorageProfile.OsDisk.Vhd = osDisk;
            this.Inner.StorageProfile.OsDisk.OsType = osType;
            return this;
        }

        public VirtualMachineImpl WithRootUserName(string rootUserName)
        {
            this.Inner.OsProfile.AdminUsername = rootUserName;
            return this;
        }

        public VirtualMachineImpl WithAdminUserName(string adminUserName)
        {
            this.Inner.OsProfile.AdminUsername = adminUserName;
            return this;
        }

        public VirtualMachineImpl WithSsh(string publicKeyData)
        {
            OSProfile osProfile = this.Inner.OsProfile;
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

        public VirtualMachineImpl DisableVmAgent()
        {
            this.Inner.OsProfile.WindowsConfiguration.ProvisionVMAgent = false;
            return this;
        }

        public VirtualMachineImpl DisableAutoUpdate()
        {
            this.Inner.OsProfile.WindowsConfiguration.EnableAutomaticUpdates = false;
            return this;
        }

        public VirtualMachineImpl WithTimeZone(string timeZone)
        {
            this.Inner.OsProfile.WindowsConfiguration.TimeZone = timeZone;
            return this;
        }

        public VirtualMachineImpl WithWinRm(WinRMListener listener)
        {
            if (this.Inner.OsProfile.WindowsConfiguration.WinRM == null)
            {
                WinRMConfiguration winRMConfiguration = new WinRMConfiguration();
                this.Inner.OsProfile.WindowsConfiguration.WinRM = winRMConfiguration;
            }

            this.Inner.OsProfile
                .WindowsConfiguration
                .WinRM
                .Listeners
                .Add(listener);
            return this;
        }

        public VirtualMachineImpl WithPassword(string password)
        {
            this.Inner.OsProfile.AdminPassword = password;
            return this;
        }

        public VirtualMachineImpl WithSize(string sizeName)
        {
            this.Inner.HardwareProfile.VmSize = sizeName;
            return this;
        }

        public VirtualMachineImpl WithOsDiskCaching(CachingTypes cachingType)
        {
            this.Inner.StorageProfile.OsDisk.Caching = cachingType;
            return this;
        }

        public VirtualMachineImpl WithOsDiskVhdLocation(string containerName, string vhdName)
        {
            VirtualHardDisk osVhd = new VirtualHardDisk();
            osVhd.Uri = this.TemporaryBlobUrl(containerName, vhdName);
            this.Inner.StorageProfile.OsDisk.Vhd = osVhd;
            return this;
        }

        public VirtualMachineImpl WithOsDiskEncryptionSettings(DiskEncryptionSettings settings)
        {
            this.Inner.StorageProfile.OsDisk.EncryptionSettings = settings;
            return this;
        }

        public VirtualMachineImpl WithOsDiskSizeInGb(int? size)
        {
            this.Inner.StorageProfile.OsDisk.DiskSizeGB = size;
            return this;
        }

        public VirtualMachineImpl WithOsDiskName(string name)
        {
            this.Inner.StorageProfile.OsDisk.Name = name;
            return this;
        }

        public DataDiskImpl DefineNewDataDisk(string name)
        {
            return DataDiskImpl.PrepareDataDisk(name, DiskCreateOptionTypes.Empty, this);
        }

        public DataDiskImpl DefineExistingDataDisk(string name)
        {

            return DataDiskImpl.PrepareDataDisk(name, DiskCreateOptionTypes.Attach, this);
        }

        public VirtualMachineImpl WithNewDataDisk(int? sizeInGB)
        {
            return WithDataDisk(DataDiskImpl.CreateNewDataDisk(sizeInGB.HasValue ? sizeInGB.Value : 0, this));
        }

        public VirtualMachineImpl WithExistingDataDisk(string storageAccountName, string containerName, string vhdName)
        {
            return WithDataDisk(DataDiskImpl.CreateFromExistingDisk(storageAccountName, containerName, vhdName, this));
        }

        public VirtualMachineImpl WithNewStorageAccount(ICreatable<IStorageAccount> creatable)
        {
            // This method's effect is NOT additive.
            if (this.creatableStorageAccountKey == null)
            {
                this.creatableStorageAccountKey = creatable.Key;
                this.AddCreatableDependency(creatable as IResourceCreator<IResource>);
            }
            return this;
        }

        public VirtualMachineImpl WithNewStorageAccount(string name)
        {

            Storage.StorageAccount.Definition.IWithGroup definitionWithGroup = this.storageManager
                .StorageAccounts
                .Define(name)
                .WithRegion(this.RegionName);
            Storage.StorageAccount.Definition.IWithCreate definitionAfterGroup;
            if (this.newGroup != null) {
                definitionAfterGroup = definitionWithGroup.WithNewResourceGroup(this.newGroup);
            } else {
                definitionAfterGroup = definitionWithGroup.WithExistingResourceGroup(this.ResourceGroupName);
            }

            return WithNewStorageAccount(definitionAfterGroup);
        }

        public VirtualMachineImpl WithExistingStorageAccount(IStorageAccount storageAccount)
        {
            this.existingStorageAccountToAssociate = storageAccount;
            return this;
        }

        public VirtualMachineImpl WithNewAvailabilitySet(ICreatable<IAvailabilitySet> creatable)
        {

            // This method's effect is NOT additive.
            if (this.creatableAvailabilitySetKey == null)
            {
                this.creatableAvailabilitySetKey = creatable.Key;
                this.AddCreatableDependency(creatable as IResourceCreator<IResource>);
            }
            return this;
        }

        public VirtualMachineImpl WithNewAvailabilitySet(string name)
        {
            return WithNewAvailabilitySet(base.MyManager.AvailabilitySets.Define(name)
                .WithRegion(this.RegionName)
                .WithExistingResourceGroup(this.ResourceGroupName));
        }

        public VirtualMachineImpl WithExistingAvailabilitySet(IAvailabilitySet availabilitySet)
        {
            this.existingAvailabilitySetToAssociate = availabilitySet;
            return this;
        }

        public VirtualMachineImpl WithNewSecondaryNetworkInterface(ICreatable<INetworkInterface> creatable)
        {
            this.creatableSecondaryNetworkInterfaceKeys.Add(creatable.Key);
            this.AddCreatableDependency(creatable as IResourceCreator<IResource>);
            return this;
        }

        public VirtualMachineImpl WithExistingSecondaryNetworkInterface(INetworkInterface networkInterface)
        {
            this.existingSecondaryNetworkInterfacesToAssociate.Add(networkInterface);
            return this;
        }

        public VirtualMachineImpl WithoutDataDisk(string name)
        {
            int idx = -1;
            foreach (IVirtualMachineDataDisk dataDisk in this.dataDisks)
            {
                idx++;
                if (dataDisk.Name.Equals(name, System.StringComparison.OrdinalIgnoreCase))
                {
                    this.dataDisks.RemoveAt(idx);
                    this.Inner.StorageProfile.DataDisks.RemoveAt(idx);
                    break;
                }
            }

            return this;
        }

        public VirtualMachineImpl WithoutDataDisk(int lun)
        {
            int idx = -1;
            foreach (IVirtualMachineDataDisk dataDisk in this.dataDisks)
            {
                idx++;
                if (dataDisk.Lun == lun)
                {
                    this.dataDisks.RemoveAt(idx);
                    this.Inner.StorageProfile.DataDisks.RemoveAt(idx);
                    break;
                }
            }

            return this;
        }

        public DataDiskImpl UpdateDataDisk(string name)
        {
            foreach (IVirtualMachineDataDisk dataDisk in this.dataDisks)
            {
                if (dataDisk.Name.Equals(name, System.StringComparison.OrdinalIgnoreCase))
                {
                    return (DataDiskImpl)dataDisk;
                }
            }

            throw new Exception("A data disk with name  '" + name + "' not found");
        }

        public VirtualMachineImpl WithoutSecondaryNetworkInterface(string name)
        {
            if (this.Inner.NetworkProfile != null
            && this.Inner.NetworkProfile.NetworkInterfaces != null)
            {
                int idx = -1;
                foreach (NetworkInterfaceReferenceInner nicReference in this.Inner.NetworkProfile.NetworkInterfaces)
                {
                    idx++;
                    if (!nicReference.Primary == true
                        && name.Equals(ResourceUtils.NameFromResourceId(nicReference.Id), StringComparison.OrdinalIgnoreCase)) {
                        this.Inner.NetworkProfile.NetworkInterfaces.RemoveAt(idx);
                        break;
                    }
                }
            }
            return this;
        }

        /// <summary>
        /// .
        /// Getters
        /// </summary>
        public string ComputerName
        {
            get
            {
                return Inner.OsProfile.ComputerName;
            }
        }
        public string Size
        {
            get
            {
                return Inner.HardwareProfile.VmSize;
            }
        }
        public OperatingSystemTypes? OsType
        {
            get
            {
                return Inner.StorageProfile.OsDisk.OsType;
            }
        }
        public string OsDiskVhdUri
        {
            get
            {
                return Inner.StorageProfile.OsDisk.Vhd.Uri;
            }
        }
        public CachingTypes? OsDiskCachingType
        {
            get
            {
                return Inner.StorageProfile.OsDisk.Caching;
            }
        }

        public int? OsDiskSize
        {
            get
            {
                if (Inner.StorageProfile.OsDisk.DiskSizeGB == null)
                {
                    // Server returns OS disk size as 0 for auto-created disks for which
                    // size was not explicitly set by the user.
                    return 0;
                }

                return Inner.StorageProfile.OsDisk.DiskSizeGB;
            }
        }

        public IList<IVirtualMachineDataDisk> DataDisks()
        {

            return this.dataDisks;
        }

        public INetworkInterface PrimaryNetworkInterface()
        {
            if (this.primaryNetworkInterface == null)
            {
                String primaryNicId = this.PrimaryNetworkInterfaceId;
                this.primaryNetworkInterface = this.networkManager.NetworkInterfaces.GetById(primaryNicId);
            }

            return this.primaryNetworkInterface;
        }

        public IPublicIpAddress PrimaryPublicIpAddress()
        {
            if (this.primaryPublicIpAddress == null)
            {
                this.primaryPublicIpAddress = this.PrimaryNetworkInterface().PrimaryPublicIpAddress();
            }

            return this.primaryPublicIpAddress;
        }

        public IList<string> NetworkInterfaceIds
        {
            get
            {
                List<string> nicIds = new List<string>();
                foreach (NetworkInterfaceReferenceInner nicRef in Inner.NetworkProfile.NetworkInterfaces)
                {
                    nicIds.Add(nicRef.Id);
                }
                return nicIds;
            }
        }

        public string PrimaryNetworkInterfaceId
        {
            get
            {
                IList<NetworkInterfaceReferenceInner> nicRefs = this.Inner.NetworkProfile.NetworkInterfaces;
                String primaryNicRefId = null;

                if (nicRefs.Count == 1)
                {
                    // One NIC so assume it to be primary
                    primaryNicRefId = nicRefs[0].Id;
                }
                else if (nicRefs.Count == 0)
                {
                    // No NICs so null
                    primaryNicRefId = null;
                }
                else
                {
                    // Find primary interface as flagged by Azure
                    foreach (NetworkInterfaceReferenceInner nicRef in Inner.NetworkProfile.NetworkInterfaces)
                    {
                        if (nicRef.Primary != null && nicRef.Primary == true)
                        {
                            primaryNicRefId = nicRef.Id;
                            break;
                        }
                    }

                    // If Azure didn't flag any NIC as primary then assume the first one
                    if (primaryNicRefId == null)
                    {
                        primaryNicRefId = nicRefs[0].Id;
                    }
                }

                return primaryNicRefId;
            }
        }

        public string AvailabilitySetId
        {
            get
            {
                if (Inner.AvailabilitySet != null)
                {
                    return Inner.AvailabilitySet.Id;
                }

                return null;
            }
        }

        public string ProvisioningState
        {
            get
            {
                return Inner.ProvisioningState;
            }
        }

        public string LicenseType
        {
            get
            {
                return Inner.LicenseType;
            }
        }
        public IList<VirtualMachineExtensionInner> Resources
        {
            get
            {
                return Inner.Resources;
            }
        }

        public Plan Plan
        {
            get
            {
                return Inner.Plan;
            }
        }

        public StorageProfile StorageProfile
        {
            get
            {
                return Inner.StorageProfile;
            }
        }

        public OSProfile OsProfile
        {
            get
            {
                return Inner.OsProfile;
            }
        }

        public DiagnosticsProfile DiagnosticsProfile
        {
            get
            {
                return Inner.DiagnosticsProfile;
            }
        }

        public string VmId
        {
            get
            {
                return Inner.VmId;
            }
        }
        public VirtualMachineInstanceView InstanceView
        {
            get
            {
                if (this.virtualMachineInstanceView == null)
                {
                    this.RefreshInstanceView();
                }

                return this.virtualMachineInstanceView;
            }
        }
        public PowerState? PowerState
        {
            get
            {
                string powerStateCode = this.GetStatusCodeFromInstanceView("PowerState");
                if (powerStateCode != null)
                {
                    return (PowerState)Enum.Parse(typeof(Microsoft.Azure.Management.V2.Compute.PowerState), powerStateCode);
                }

                return null;
            }
        }
        public override IVirtualMachine CreateResource()
        {
            return this.CreateResourceAsync().Result;
        }

        public override async Task<IVirtualMachine> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            if (IsInCreateMode) {
                SetOSDiskAndOSProfileDefaults();
                SetHardwareProfileDefaults();
            }

            DataDiskImpl.SetDataDisksDefaults(this.dataDisks, this.vmName);
            await HandleStorageSettingsAsync();
            HandleNetworkSettings();
            HandleAvailabilitySettings();
            var response = await client.CreateOrUpdateAsync(ResourceGroupName, vmName, Inner);
            this.SetInner(response);
            ClearCachedRelatedResources();
            InitializeDataDisks();
            return this;
        }

        private VirtualMachineImpl WithDataDisk(DataDiskImpl dataDisk)
        {
            this.Inner
                .StorageProfile
                .DataDisks
                .Add(dataDisk.Inner);
            this.dataDisks.Add(dataDisk);
            return this;
        }

        private void SetOSDiskAndOSProfileDefaults()
        {

            if (!IsInCreateMode)
            {
                return;
            }

            OSDisk osDisk = this.Inner.StorageProfile.OsDisk;
            if (IsOSDiskFromImage(osDisk))
            {
                if (osDisk.Vhd == null)
                {
                    // Sets the OS disk VHD for "UserImage" and "VM(Platform)Image"
                    WithOsDiskVhdLocation("vhds", this.vmName + "-os-disk-" + Guid.NewGuid().ToString() + ".vhd");
                }
                OSProfile osProfile = this.Inner.OsProfile;
                if (osDisk.OsType == OperatingSystemTypes.Linux || this.isMarketplaceLinuxImage)
                {
                    // linux image: User or marketplace linux image
                    if (osProfile.LinuxConfiguration == null)
                    {
                        osProfile.LinuxConfiguration = new LinuxConfiguration();
                    }
                    this.Inner.OsProfile.LinuxConfiguration.DisablePasswordAuthentication = osProfile.AdminPassword == null;
                }
            }

            if (osDisk.Caching == null)
            {
                WithOsDiskCaching(CachingTypes.ReadWrite);
            }

            if (osDisk.Name == null)
            {
                this.WithOsDiskName(this.vmName + "-os-disk");
            }

            if (this.Inner.OsProfile.ComputerName == null)
            {
                // VM name cannot contain only numeric values and cannot exceed 15 chars
                if ((new Regex(@"^\d+$")).IsMatch(vmName))
                {
                    this.Inner.OsProfile.ComputerName = ResourceNamer.RandomResourceName("vm", 15);
                }
                else if (vmName.Length <= 15)
                {
                    this.Inner.OsProfile.ComputerName = vmName;
                }
                else
                {
                    this.Inner.OsProfile.ComputerName = ResourceNamer.RandomResourceName("vm", 15);
                }
            }
        }

        private void SetHardwareProfileDefaults()
        {
            if (!IsInCreateMode)
            {
                return;
            }

            HardwareProfile hardwareProfile = this.Inner.HardwareProfile;
            if (hardwareProfile.VmSize == null)
            {
                hardwareProfile.VmSize = VirtualMachineSizeTypes.BasicA0;
            }
        }

        private void HandleStorageSettings()
        {
            this.HandleStorageSettingsAsync().Wait();
        }

        private async Task HandleStorageSettingsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            IStorageAccount storageAccount = null;
            if (this.creatableStorageAccountKey != null)
            {
                storageAccount = (IStorageAccount)this.CreatedResource(this.creatableStorageAccountKey);
            }
            else if (this.existingStorageAccountToAssociate != null)
            {
                storageAccount = this.existingStorageAccountToAssociate;
            }
            else if (this.OsDiskRequiresImplicitStorageAccountCreation == true ||
                this.DataDisksRequiresImplicitStorageAccountCreation == true)
            {
                storageAccount = await this.storageManager.StorageAccounts
                .Define(this.namer.RandomName("stg", 24))
                .WithRegion(this.RegionName)
                .WithExistingResourceGroup(this.ResourceGroupName)
                .CreateAsync();
            }

            if (IsInCreateMode)
            {
                if (this.IsOSDiskFromImage(this.Inner.StorageProfile.OsDisk))
                {
                    string uri = this.Inner.StorageProfile.OsDisk.Vhd.Uri;
                    if (uri.StartsWith("{storage-base-url}"))
                    {
                        uri = uri.Remove(0, "{storage-base-url}".Length).Insert(0,
                            storageAccount.EndPoints.Primary.Blob);

                    }

                    this.Inner.StorageProfile.OsDisk.Vhd.Uri = uri;
                }

                DataDiskImpl.EnsureDisksVhdUri(this.dataDisks, storageAccount, this.vmName);
            }
            else
            {
                if (storageAccount != null)
                {
                    DataDiskImpl.EnsureDisksVhdUri(this.dataDisks, storageAccount, this.vmName);
                }
                else
                {
                    DataDiskImpl.EnsureDisksVhdUri(this.dataDisks, this.vmName);
                }
            }
        }

        private void HandleNetworkSettings()
        {
            if (IsInCreateMode)
            {
                INetworkInterface primaryNetworkInterface = null;
                if (this.creatablePrimaryNetworkInterfaceKey != null)
                {
                    primaryNetworkInterface = (INetworkInterface)this.CreatedResource(this.creatablePrimaryNetworkInterfaceKey);
                }
                else if (this.existingPrimaryNetworkInterfaceToAssociate != null)
                {
                    primaryNetworkInterface = this.existingPrimaryNetworkInterfaceToAssociate;
                }

                if (primaryNetworkInterface != null)
                {
                    NetworkInterfaceReferenceInner nicReference = new NetworkInterfaceReferenceInner();
                    nicReference.Primary = true;
                    nicReference.Id = primaryNetworkInterface.Id;
                    this.Inner.NetworkProfile.NetworkInterfaces.Add(nicReference);
                }
            }

            // sets the virtual machine secondary network interfaces
            //
            foreach (string creatableSecondaryNetworkInterfaceKey in this.creatableSecondaryNetworkInterfaceKeys)
            {
                INetworkInterface secondaryNetworkInterface = (INetworkInterface)this.CreatedResource(creatableSecondaryNetworkInterfaceKey);
                NetworkInterfaceReferenceInner nicReference = new NetworkInterfaceReferenceInner();
                nicReference.Primary = false;
                nicReference.Id = secondaryNetworkInterface.Id;
                this.Inner.NetworkProfile.NetworkInterfaces.Add(nicReference);
            }

            foreach (INetworkInterface secondaryNetworkInterface in this.existingSecondaryNetworkInterfacesToAssociate)
            {
                NetworkInterfaceReferenceInner nicReference = new NetworkInterfaceReferenceInner();
                nicReference.Primary = false;
                nicReference.Id = secondaryNetworkInterface.Id;
                this.Inner.NetworkProfile.NetworkInterfaces.Add(nicReference);
            }
        }

        private void HandleAvailabilitySettings()
        {
            if (!IsInCreateMode)
            {
                return;
            }

            IAvailabilitySet availabilitySet = null;
            if (this.creatableAvailabilitySetKey != null)
            {
                availabilitySet = (IAvailabilitySet)this.CreatedResource(this.creatableAvailabilitySetKey);
            }
            else if (this.existingAvailabilitySetToAssociate != null)
            {
                availabilitySet = this.existingAvailabilitySetToAssociate;
            }

            if (availabilitySet != null)
            {
                if (this.Inner.AvailabilitySet == null)
                {
                    this.Inner.AvailabilitySet = new Rest.Azure.SubResource();
                }

                this.Inner.AvailabilitySet.Id  = availabilitySet.Id;
            }
        }

        private bool? OsDiskRequiresImplicitStorageAccountCreation
        {
            get
            {
                if (this.creatableStorageAccountKey != null
                    || this.existingStorageAccountToAssociate != null
                    || !this.IsInCreateMode)
                {
                    return false;
                }

                return this.IsOSDiskFromImage(this.Inner.StorageProfile.OsDisk);
            }
        }

        private bool DataDisksRequiresImplicitStorageAccountCreation
        {
            get
            {
                if (this.creatableStorageAccountKey != null
                    || this.existingStorageAccountToAssociate != null
                    || this.dataDisks.Count == 0)
                {
                    return false;
                }

                bool hasEmptyVhd = false;
                foreach (IVirtualMachineDataDisk dataDisk in this.dataDisks)
                {
                    if (dataDisk.CreateOption == DiskCreateOptionTypes.Empty)
                    {
                        if (dataDisk.Inner.Vhd == null)
                        {
                            hasEmptyVhd = true;
                            break;
                        }
                    }
                }

                if (IsInCreateMode)
                {
                    return hasEmptyVhd;
                }

                if (hasEmptyVhd)
                {
                    // In update mode, if any of the data disk has vhd uri set then use same container
                    // to store this disk, no need to create a storage account implicitly.
                    foreach (IVirtualMachineDataDisk dataDisk in this.dataDisks)
                    {
                        if (dataDisk.CreateOption == DiskCreateOptionTypes.Attach && dataDisk.Inner.Vhd != null)
                        {
                            return false;
                        }
                    }
                    return true;
                }

                return false;
            }
        }

        private bool IsOSDiskAttached(OSDisk osDisk)
        {
            return osDisk.CreateOption == DiskCreateOptionTypes.Attach;
        }

        private bool IsOSDiskFromImage(OSDisk osDisk)
        {
            return !this.IsOSDiskAttached(osDisk);
        }

        private string TemporaryBlobUrl(string containerName, string blobName)
        {
            return "{storage-base-url}" + containerName + "/" + blobName;
        }

        private IWithPrimaryPublicIpAddress PrepareNetworkInterface(string name)
        {
            Network.NetworkInterface.Definition.IWithGroup definitionWithGroup = this.networkManager.NetworkInterfaces
                .Define(name)
                .WithRegion(this.RegionName);
            Network.NetworkInterface.Definition.IWithPrimaryNetwork definitionWithNetwork;
            if (this.newGroup != null)
            {
                definitionWithNetwork = definitionWithGroup.WithNewResourceGroup(this.newGroup);
            }
            else
            {
                definitionWithNetwork = definitionWithGroup.WithExistingResourceGroup(this.ResourceGroupName);
            }
            return definitionWithNetwork
                .WithNewPrimaryNetwork("vnet" + name)
                .WithPrimaryPrivateIpAddressDynamic();
        }

        private void InitializeDataDisks()
        {
            if (this.Inner.StorageProfile.DataDisks == null)
            {
                this.Inner
                    .StorageProfile
                    .DataDisks = new List<DataDisk>();
            }

            this.dataDisks = new List<IVirtualMachineDataDisk>();
            foreach (DataDisk dataDiskInner in this.StorageProfile.DataDisks)
            {
                this.dataDisks.Add(new DataDiskImpl(dataDiskInner, this));
            }
        }

        private IWithPrimaryNetwork PreparePrimaryNetworkInterface(string name)
        {
            Network.NetworkInterface.Definition.IWithGroup definitionWithGroup = this.networkManager.NetworkInterfaces
            .Define(name)
            .WithRegion(this.RegionName);
            Network.NetworkInterface.Definition.IWithPrimaryNetwork definitionAfterGroup;
            if (this.newGroup != null)
            {
                definitionAfterGroup = definitionWithGroup.WithNewResourceGroup(this.newGroup);
            }
            else
            {
                definitionAfterGroup = definitionWithGroup.WithExistingResourceGroup(this.ResourceGroupName);
            }

            return definitionAfterGroup;
        }

        private string GetStatusCodeFromInstanceView(string codePrefix)
        {
            foreach (InstanceViewStatus status in this.InstanceView.Statuses)
            {
                if (status.Code != null && status.Code.StartsWith(codePrefix))
                {
                    return status.Code.Substring(codePrefix.Length + 1).ToUpper();
                }
            }

            return null;
        }

        private void ClearCachedRelatedResources()
        {
            this.primaryNetworkInterface = null;
            this.primaryPublicIpAddress = null;
            this.virtualMachineInstanceView = null;
        }

    }
}
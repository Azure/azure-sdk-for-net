// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
using Microsoft.Azure.Management.Compute.Fluent.Models;
using Microsoft.Azure.Management.Graph.RBAC.Fluent;
using Microsoft.Azure.Management.Network.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
using Microsoft.Azure.Management.Storage.Fluent;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.Compute.Fluent
{
    /// <summary>
    /// The implementation for VirtualMachine and its create and update interfaces.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbXB1dGUuaW1wbGVtZW50YXRpb24uVmlydHVhbE1hY2hpbmVJbXBs
    internal partial class VirtualMachineImpl :
        GroupableResource<IVirtualMachine,
            VirtualMachineInner,
            VirtualMachineImpl,
            IComputeManager,
            VirtualMachine.Definition.IWithGroup,
            VirtualMachine.Definition.IWithNetwork,
            VirtualMachine.Definition.IWithCreate,
            VirtualMachine.Update.IUpdate>,
        IVirtualMachine,
        VirtualMachine.DefinitionManagedOrUnmanaged.IDefinitionManagedOrUnmanaged,
        VirtualMachine.DefinitionManaged.IDefinitionManaged,
        VirtualMachine.DefinitionUnmanaged.IDefinitionUnmanaged,
        VirtualMachine.Update.IUpdate,
        VirtualMachine.Definition.IWithRoleAndScopeOrCreate,
        VirtualMachine.Update.IWithRoleAndScopeOrUpdate
    {
        private readonly IStorageManager storageManager;
        private readonly INetworkManager networkManager;
        private readonly string vmName;
        // used to generate unique name for any dependency resources
        private readonly IResourceNamer namer;
        // unique key of a creatable storage account to be used for virtual machine child resources that
        // requires storage [OS disk, data disk etc..] requires storage [OS disk, data disk, boot diagnostics etc..]
        private string creatableStorageAccountKey;
        // unique key of a creatable availability set that this virtual machine to put
        private string creatableAvailabilitySetKey;
        // unique key of a creatable network interface that needs to be used as virtual machine's primary network interface
        private string creatablePrimaryNetworkInterfaceKey;
        // unique key of a creatable network interfaces that needs to be used as virtual machine's secondary network interface
        private IList<string> creatableSecondaryNetworkInterfaceKeys;
        // reference to an existing storage account to be used for virtual machine child resources that
        // requires storage [OS disk, data disk, boot diagnostics etc..]
        private IStorageAccount existingStorageAccountToAssociate;
        // reference to an existing availability set that this virtual machine to put
        private IAvailabilitySet existingAvailabilitySetToAssociate;
        // reference to an existing network interface that needs to be used as virtual machine's primary network interface
        private INetworkInterface existingPrimaryNetworkInterfaceToAssociate;
        // reference to a list of existing network interfaces that needs to be used as virtual machine's secondary network interface
        private IList<INetworkInterface> existingSecondaryNetworkInterfacesToAssociate;
        private VirtualMachineInstanceView virtualMachineInstanceView;
        private bool isMarketplaceLinuxImage;
        // Intermediate state of network interface definition to which private IP can be associated
        private Network.Fluent.NetworkInterface.Definition.IWithPrimaryPrivateIP nicDefinitionWithPrivateIP;
        // Intermediate state of network interface definition to which subnet can be associated
        private Network.Fluent.NetworkInterface.Definition.IWithPrimaryNetworkSubnet nicDefinitionWithSubnet;
        // Intermediate state of network interface definition to which public IP can be associated
        private Network.Fluent.NetworkInterface.Definition.IWithCreate nicDefinitionWithCreate;
        // The entry point to manage extensions associated with the virtual machine
        private VirtualMachineExtensionsImpl virtualMachineExtensions;
        // Flag indicates native disk is selected for OS and Data disks
        private bool isUnmanagedDiskSelected;
        // The native data disks associated with the virtual machine
        private IList<IVirtualMachineUnmanagedDataDisk> unmanagedDataDisks;
        // To track the managed data disks
        private ManagedDataDiskCollection managedDataDisks;
        // unique key of a creatable storage account to be used for boot diagnostics
        private string creatableDiagnosticsStorageAccountKey;
        // Utility to setup MSI for the virtual machine
        private VirtualMachineMsiHelper virtualMachineMsiHelper;

        ///GENMHASH:0A331C2401291DF824493E64F2798884:D3B04C536032C2BDC056A8F85225875E
        internal VirtualMachineImpl(
            string name,
            VirtualMachineInner innerModel,
            IComputeManager computeManager,
            IStorageManager storageManager,
            INetworkManager networkManager, 
            IGraphRbacManager rbacManager)
            : base(name, innerModel, computeManager)
        {
            this.storageManager = storageManager;
            this.networkManager = networkManager;
            this.vmName = name;
            this.isMarketplaceLinuxImage = false;
            this.namer = SdkContext.CreateResourceNamer(this.vmName);
            this.creatableSecondaryNetworkInterfaceKeys = new List<string>();
            this.existingSecondaryNetworkInterfacesToAssociate = new List<INetworkInterface>();
            InitializeExtensions();
            this.managedDataDisks = new ManagedDataDiskCollection(this);
            InitializeDataDisks();
            this.virtualMachineMsiHelper = new VirtualMachineMsiHelper(rbacManager);
        }

        ///GENMHASH:4002186478A1CB0B59732EBFB18DEB3A:4C74CDEFBB89F8ADB720DB2B740C1AB3

        public override async Task<IVirtualMachine> RefreshAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var response = await GetInnerAsync(cancellationToken);
            SetInner(response);
            ClearCachedRelatedResources();
            InitializeDataDisks();
            virtualMachineExtensions.Refresh();
            return this;
        }
        protected override async Task<VirtualMachineInner> GetInnerAsync(CancellationToken cancellationToken)
        {
            return await Manager.Inner.VirtualMachines.GetAsync(ResourceGroupName, Name, cancellationToken: cancellationToken);
        }

        ///GENMHASH:667E734583F577A898C6389A3D9F4C09:B1A3725E3B60B26D7F37CA7ABFE371B0
        public void Deallocate()
        {
            Extensions.Synchronize(() => Manager.Inner.VirtualMachines.DeallocateAsync(this.ResourceGroupName, this.Name));
            Refresh();
        }

        public async Task DeallocateAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await Manager.Inner.VirtualMachines.DeallocateAsync(this.ResourceGroupName, this.Name, cancellationToken);
            await RefreshAsync(cancellationToken);
        }

        ///GENMHASH:F5949CB4AFA8DD0B8DED0F369B12A8F6:6AC69BE8BE090CDE9822C84DD5F906F3
        public VirtualMachineInstanceView RefreshInstanceView()
        {
            return Extensions.Synchronize(() => RefreshInstanceViewAsync());
        }

        ///GENMHASH:D97B6272C7E7717C00D4F9B818A713C0:8DD09B90F0555BB3E1AEF7B9AF044379
        public async Task<Models.VirtualMachineInstanceView> RefreshInstanceViewAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var virtualMachineInner = await this.Manager.Inner.VirtualMachines.GetAsync(this.ResourceGroupName,
                this.Name,
                InstanceViewTypes.InstanceView, 
                cancellationToken);
            this.virtualMachineInstanceView = virtualMachineInner.InstanceView;
            return this.virtualMachineInstanceView;
        }

        ///GENMHASH:0745971EF3F2CE7276C7E535722C5E6C:F7A7B3A36B61441CF0850BDE432A2805
        public void Generalize()
        {
            Extensions.Synchronize(() => Manager.Inner.VirtualMachines.GeneralizeAsync(this.ResourceGroupName, this.Name));
        }

        public async Task GeneralizeAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await Manager.Inner.VirtualMachines.GeneralizeAsync(this.ResourceGroupName, this.Name, cancellationToken);
        }

        ///GENMHASH:8761D0D225B7C49A7A5025186E94B263:21AAF0008CE6CF3F9846F2DFE1CBEBCB
        public void PowerOff()
        {
            Extensions.Synchronize(() => Manager.Inner.VirtualMachines.PowerOffAsync(this.ResourceGroupName, this.Name));
        }

        public async Task PowerOffAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await Manager.Inner.VirtualMachines.PowerOffAsync(this.ResourceGroupName, this.Name, cancellationToken);
        }

        ///GENMHASH:08CFC096AC6388D1C0E041ECDF099E3D:4479808A1E2B2A23538E662AD3F721EE
        public void Restart()
        {
            Extensions.Synchronize(() => Manager.Inner.VirtualMachines.RestartAsync(this.ResourceGroupName, this.Name));
        }

        public async Task RestartAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await Manager.Inner.VirtualMachines.RestartAsync(this.ResourceGroupName, this.Name, cancellationToken);
        }

        ///GENMHASH:0F38250A3837DF9C2C345D4A038B654B:5723E041D4826DFBE50B8B49C31EAF08
        public void Start()
        {
            Extensions.Synchronize(() => Manager.Inner.VirtualMachines.StartAsync(this.ResourceGroupName, this.Name));
        }

        public async Task StartAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await Manager.Inner.VirtualMachines.StartAsync(this.ResourceGroupName, this.Name, cancellationToken);
        }

        ///GENMHASH:D9EB75AF88B1A07EDC0965B26A7F7C04:E30F1E083D68AA7A68C7128405BA3741
        public void Redeploy()
        {
            Extensions.Synchronize(() => Manager.Inner.VirtualMachines.RedeployAsync(this.ResourceGroupName, this.Name));
        }

        public async Task RedeployAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await Manager.Inner.VirtualMachines.RedeployAsync(this.ResourceGroupName, this.Name, cancellationToken);

        }

        ///GENMHASH:BF8CE5C594210A476EF389DC52B15805:2795B67DFA718D9C0FFC69E152857591
        public void ConvertToManaged()
        {
            this.ConvertToManagedAsync().Wait();
        }

        ///GENMHASH:BE99BB2DEA25942BB991922E902344B7:BB9B58DA6D2DB651B79BA46AE181759B
        public async Task ConvertToManagedAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await Manager.Inner.VirtualMachines.ConvertToManagedDisksAsync(this.ResourceGroupName, this.Name, cancellationToken);
            await this.RefreshAsync(cancellationToken);
        }

        ///GENMHASH:842FBE4DCB8BFE1B50632DBBE157AEA8:B5262187B60CE486998F800E9A96B659
        public IEnumerable<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineSize> AvailableSizes()
        {
            return Extensions.Synchronize(() => Manager.Inner.VirtualMachines.ListAvailableSizesAsync(this.ResourceGroupName,this.Name))
                .Select(inner => new VirtualMachineSizeImpl(inner));
        }

        ///GENMHASH:1F383B6B989059B78D6ECB949E789CD4:D3D812C91301FB29508197FA8534CDDC
        public string Capture(string containerName, string vhdPrefix, bool overwriteVhd)
        {
            return Extensions.Synchronize(() => this.CaptureAsync(containerName, vhdPrefix, overwriteVhd));
        }

        ///GENMHASH:C345130B595C0FF585A57651EFDC3A0F:E97CAC99D13041F7FEAACC7E4508DC7B
        public async Task<string> CaptureAsync(string containerName, string vhdPrefix, bool overwriteVhd, CancellationToken cancellationToken = default(CancellationToken))
        {
            VirtualMachineCaptureParametersInner parameters = new VirtualMachineCaptureParametersInner();
            parameters.DestinationContainerName = containerName;
            parameters.OverwriteVhds = overwriteVhd;
            parameters.VhdPrefix = vhdPrefix;
            VirtualMachineCaptureResultInner captureResult = await Manager.Inner.VirtualMachines.CaptureAsync(
                this.ResourceGroupName, 
                this.Name, 
                parameters,
                cancellationToken);
            return JsonConvert.SerializeObject(captureResult.Output);
        }

        ///GENMHASH:3FAB18211D6DAAAEF5CA426426D16F0C:AD7170076BCB5437E69B77AC63B3373E
        public VirtualMachineImpl WithNewPrimaryNetwork(ICreatable<Microsoft.Azure.Management.Network.Fluent.INetwork> creatable)
        {
            this.nicDefinitionWithPrivateIP = this.PreparePrimaryNetworkInterface(this.namer.RandomName("nic", 20))
                .WithNewPrimaryNetwork(creatable);
            return this;
        }

        ///GENMHASH:C8A4DDE66256242DF61087375BF710B0:BE10050EE1789706DD7774B3C47BE916
        public VirtualMachineImpl WithNewPrimaryNetwork(string addressSpace)
        {
            this.nicDefinitionWithPrivateIP = this.PreparePrimaryNetworkInterface(this.namer.RandomName("nic", 20))
                .WithNewPrimaryNetwork(addressSpace);
            return this;
        }

        ///GENMHASH:EE2847D8AC43E9B7C3BFB967F80560D4:A3EFBF1BD0F4CAB5595668104129F2F4
        public VirtualMachineImpl WithExistingPrimaryNetwork(INetwork network)
        {
            this.nicDefinitionWithSubnet = this.PreparePrimaryNetworkInterface(this.namer.RandomName("nic", 20))
                .WithExistingPrimaryNetwork(network);
            return this;
        }

        ///GENMHASH:0FBBECB150CBC82F165D8BA614AB135A:D0002A3AE79C25026E85606A72066F48
        public VirtualMachineImpl WithSubnet(string name)
        {
            this.nicDefinitionWithPrivateIP = this.nicDefinitionWithSubnet
                .WithSubnet(name);
            return this;
        }

        ///GENMHASH:022FCEBED3C6606D834C45EAD65C0D6F:29E2281B1650F8D65A367942B42B75EF
        public VirtualMachineImpl WithPrimaryPrivateIPAddressDynamic()
        {
            this.nicDefinitionWithCreate = this.nicDefinitionWithPrivateIP
                .WithPrimaryPrivateIPAddressDynamic();
            return this;
        }

        ///GENMHASH:655D6F837286729FEB47BD78B3EB9A08:D2502E1AE46296B5C8F75C71F9B84C27
        public VirtualMachineImpl WithPrimaryPrivateIPAddressStatic(string staticPrivateIPAddress)
        {
            this.nicDefinitionWithCreate = this.nicDefinitionWithPrivateIP
                .WithPrimaryPrivateIPAddressStatic(staticPrivateIPAddress);
            return this;
        }

        ///GENMHASH:54B52B6B32A26AD456CFB5E00BE4A7E1:A19C73689F2772054260CA742BE6FC13
        public async Task<IReadOnlyList<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtension>> ListExtensionsAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await this.virtualMachineExtensions.ListAsync(cancellationToken);
        }

        ///GENMHASH:979FFAEA86882618784D4077FB80332F:B79EEB6C251B19AEB675FFF7A365C818
        public IReadOnlyDictionary<string, Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineExtension> ListExtensions()
        {
            return this.virtualMachineExtensions.AsMap();
        }

        ///GENMHASH:12E96FEFBC60AB582A0B69EBEEFD1E59:C1EAF0B5EE0258D48F9956AEFBA1EA2D
        public VirtualMachineImpl WithNewPrimaryPublicIPAddress(ICreatable<Microsoft.Azure.Management.Network.Fluent.IPublicIPAddress> creatable)
        {
            var nicCreatable = this.nicDefinitionWithCreate
                .WithNewPrimaryPublicIPAddress(creatable);
            this.creatablePrimaryNetworkInterfaceKey = nicCreatable.Key;
            this.AddCreatableDependency(nicCreatable as IResourceCreator<IHasId>);
            return this;
        }

        ///GENMHASH:BA50EF0AC88D5405DFE18FCE26A595B2:027C20A1A590AAED2CC3F40647663D8B
        public VirtualMachineImpl WithNewPrimaryPublicIPAddress(string leafDnsLabel)
        {
            var nicCreatable = this.nicDefinitionWithCreate
                .WithNewPrimaryPublicIPAddress(leafDnsLabel);
            this.creatablePrimaryNetworkInterfaceKey = nicCreatable.Key;
            this.AddCreatableDependency(nicCreatable as IResourceCreator<IHasId>);
            return this;
        }

        ///GENMHASH:2B7C2F1E86A359473717299AD4D4DCBA:2EE2D29B7C228132508D27F040A79175
        public VirtualMachineImpl WithExistingPrimaryPublicIPAddress(IPublicIPAddress publicIPAddress)
        {
            var nicCreatable = this.nicDefinitionWithCreate
                .WithExistingPrimaryPublicIPAddress(publicIPAddress);
            this.creatablePrimaryNetworkInterfaceKey = nicCreatable.Key;
            this.AddCreatableDependency(nicCreatable as IResourceCreator<IHasId>);
            return this;
        }

        ///GENMHASH:D0AB91F51DBDFA04880ED371AD9E48EE:8727C9A4820EB72700E55883936D2638
        public VirtualMachineImpl WithoutPrimaryPublicIPAddress()
        {
            var nicCreatable = this.nicDefinitionWithCreate;
            this.creatablePrimaryNetworkInterfaceKey = nicCreatable.Key;
            this.AddCreatableDependency(nicCreatable as IResourceCreator<IHasId>);
            return this;
        }

        ///GENMHASH:6C6E9480071A571B23369210C67E4329:BAD887D9D5A633B4D6DE3058819C017C
        public VirtualMachineImpl WithNewPrimaryNetworkInterface(ICreatable<Microsoft.Azure.Management.Network.Fluent.INetworkInterface> creatable)
        {
            this.creatablePrimaryNetworkInterfaceKey = creatable.Key;
            this.AddCreatableDependency(creatable as IResourceCreator<IHasId>);
            return this;
        }

        ///GENMHASH:ADDFF59E01604BE661F6CB8C83CD4B0F:2125FE20491BB581219A9D8E245DECB9
        public VirtualMachineImpl WithNewPrimaryNetworkInterface(string name, string publicDnsNameLabel)
        {
            var definitionCreatable = PrepareNetworkInterface(name)
                .WithNewPrimaryPublicIPAddress(publicDnsNameLabel);
            return WithNewPrimaryNetworkInterface(definitionCreatable);
        }

        ///GENMHASH:CBAE11E07A4D8591E942E289CE471B4E:541A4F4628D59C210D53444D29D4557B
        public VirtualMachineImpl WithExistingPrimaryNetworkInterface(INetworkInterface networkInterface)
        {
            this.existingPrimaryNetworkInterfaceToAssociate = networkInterface;
            return this;
        }

        ///GENMHASH:0B0B068704882D0210B822A215F5536D:D1A7C8363353BBD6CD981B3F2D3565F3
        public VirtualMachineImpl WithStoredWindowsImage(string imageUrl)
        {
            VirtualHardDisk userImageVhd = new VirtualHardDisk();
            userImageVhd.Uri = imageUrl;
            Inner.StorageProfile.OsDisk.CreateOption = DiskCreateOptionTypes.FromImage;
            Inner.StorageProfile.OsDisk.Image = userImageVhd;
            // For platform image osType will be null, azure will pick it from the image metadata.
            Inner.StorageProfile.OsDisk.OsType = OperatingSystemTypes.Windows;
            Inner.OsProfile.WindowsConfiguration = new WindowsConfiguration();
            // sets defaults for "Stored(User)Image" or "VM(Platform)Image"
            Inner.OsProfile.WindowsConfiguration.ProvisionVMAgent = true;
            Inner.OsProfile.WindowsConfiguration.EnableAutomaticUpdates = true;
            return this;
        }

        ///GENMHASH:976BC0FCB9812014FA27474FCF6A694F:8E0FB1EEED9F15976FCF3F34580897D3
        public VirtualMachineImpl WithStoredLinuxImage(string imageUrl)
        {
            VirtualHardDisk userImageVhd = new VirtualHardDisk();
            userImageVhd.Uri = imageUrl;
            Inner.StorageProfile.OsDisk.CreateOption = DiskCreateOptionTypes.FromImage;
            Inner.StorageProfile.OsDisk.Image = userImageVhd;
            // For platform | custom image osType will be null, azure will pick it from the image metadata.
            // But for stored image, osType needs to be specified explicitly
            //
            Inner.StorageProfile.OsDisk.OsType = OperatingSystemTypes.Linux;
            Inner.OsProfile.LinuxConfiguration = new LinuxConfiguration();
            return this;
        }

        ///GENMHASH:8FDBCB5DF6AFD1594DF170521CE46D5F:4DF21C8BC272D1C368C4F1F79237B3D0
        public VirtualMachineImpl WithPopularWindowsImage(KnownWindowsVirtualMachineImage knownImage)
        {
            return WithSpecificWindowsImageVersion(knownImage.ImageReference());
        }

        ///GENMHASH:9177073080371FB82A479834DA14F493:CB0A5903865A994CFC26F01586B9FD22
        public VirtualMachineImpl WithPopularLinuxImage(KnownLinuxVirtualMachineImage knownImage)
        {
            return WithSpecificLinuxImageVersion(knownImage.ImageReference());
        }

        ///GENMHASH:4A7665D6C5D507E115A9A8E551801DB6:AD810F1DA749F7286A899D037376A9E3
        public VirtualMachineImpl WithSpecificWindowsImageVersion(ImageReference imageReference)
        {
            Inner.StorageProfile.OsDisk.CreateOption = DiskCreateOptionTypes.FromImage;
            Inner.StorageProfile.ImageReference = imageReference.Inner;
            Inner.OsProfile.WindowsConfiguration = new WindowsConfiguration();
            // sets defaults for "Stored(User)Image" or "VM(Platform)Image"
            Inner.OsProfile.WindowsConfiguration.ProvisionVMAgent = true;
            Inner.OsProfile.WindowsConfiguration.EnableAutomaticUpdates = true;
            return this;
        }

        ///GENMHASH:B2876749E60D892750D75C97943BBB13:23C60ED2B7F40C8320F1091338191A7F
        public VirtualMachineImpl WithSpecificLinuxImageVersion(ImageReference imageReference)
        {
            Inner.StorageProfile.OsDisk.CreateOption = DiskCreateOptionTypes.FromImage;
            Inner.StorageProfile.ImageReference = imageReference.Inner;
            Inner.OsProfile.LinuxConfiguration = new LinuxConfiguration();
            this.isMarketplaceLinuxImage = true;
            return this;
        }

        ///GENMHASH:3874257232804C74BD7501DE2BE2F0E9:742DE46D93113DBA276B0A311D52D664
        public VirtualMachineImpl WithLatestWindowsImage(string publisher, string offer, string sku)
        {
            ImageReference imageReference = new ImageReference();
            imageReference.Publisher = publisher;
            imageReference.Offer = offer;
            imageReference.Sku = sku;
            imageReference.Version = "latest";
            return WithSpecificWindowsImageVersion(imageReference);
        }

        ///GENMHASH:6D51A334B57DF882E890FEBA9887BE77:3A21A7EF50A9FC7A93D7C8AEFA8F3130
        public VirtualMachineImpl WithLatestLinuxImage(string publisher, string offer, string sku)
        {
            ImageReference imageReference = new ImageReference();
            imageReference.Publisher = publisher;
            imageReference.Offer = offer;
            imageReference.Sku = sku;
            imageReference.Version = "latest";
            return WithSpecificLinuxImageVersion(imageReference);
        }

        ///GENMHASH:F24EFD30F0D04113B41EA2C36B55F059:944E1D0765AA783776E77434132D18AA
        public VirtualMachineImpl WithWindowsCustomImage(string customImageId)
        {
            ImageReferenceInner imageReferenceInner = new ImageReferenceInner();
            imageReferenceInner.Id = customImageId;
            Inner.StorageProfile.OsDisk.CreateOption = DiskCreateOptionTypes.FromImage;
            Inner.StorageProfile.ImageReference = imageReferenceInner;
            Inner.OsProfile.WindowsConfiguration = new WindowsConfiguration();
            // sets defaults for "Stored(User)Image", "VM(Platform | Custom)Image"
            Inner.OsProfile.WindowsConfiguration.ProvisionVMAgent = true;
            Inner.OsProfile.WindowsConfiguration.EnableAutomaticUpdates = true;
            return this;
        }


        ///GENMHASH:CE03CDBD07CA3BD7500B36B206A91A4A:5BEEBF6F7B101075BFFD1089DC6B2D0F
        public VirtualMachineImpl WithLinuxCustomImage(string customImageId)
        {
            ImageReferenceInner imageReferenceInner = new ImageReferenceInner();
            imageReferenceInner.Id = customImageId;
            Inner.StorageProfile.OsDisk.CreateOption = DiskCreateOptionTypes.FromImage;
            Inner.StorageProfile.ImageReference = imageReferenceInner;
            Inner.OsProfile.LinuxConfiguration = new LinuxConfiguration();
            this.isMarketplaceLinuxImage = true;
            return this;
        }

        ///GENMHASH:57A0D9F7821CCF113A2473B139EA6535:A5202C2E2CECEF8345A7B13AA2F45579
        public VirtualMachineImpl WithSpecializedOSUnmanagedDisk(string osDiskUrl, OperatingSystemTypes osType)
        {
            VirtualHardDisk osVhd = new VirtualHardDisk();
            osVhd.Uri = osDiskUrl;
            Inner.StorageProfile.OsDisk.CreateOption = DiskCreateOptionTypes.Attach;
            Inner.StorageProfile.OsDisk.Vhd = osVhd;
            Inner.StorageProfile.OsDisk.OsType = osType;
            Inner.StorageProfile.OsDisk.ManagedDisk = null;
            return this;
        }

        ///GENMHASH:1F74902637AB57C68DF7BEB69565D69F:E405AA329DD9CF5E18080043D36F5E0A
        public VirtualMachineImpl WithSpecializedOSDisk(IDisk disk, OperatingSystemTypes osType)
        {
            ManagedDiskParametersInner diskParametersInner = new ManagedDiskParametersInner();
            diskParametersInner.Id = disk.Id;
            Inner.StorageProfile.OsDisk.CreateOption = DiskCreateOptionTypes.Attach;
            Inner.StorageProfile.OsDisk.ManagedDisk = diskParametersInner;
            Inner.StorageProfile.OsDisk.OsType = osType;
            Inner.StorageProfile.OsDisk.Vhd = null;
            return this;
        }

        ///GENMHASH:D5F141800B409906045662B0DD536DE4:E70AA61215804A9BAB05750F6C16BA9D
        public VirtualMachineImpl WithRootUsername(string rootUsername)
        {
            Inner.OsProfile.AdminUsername = rootUsername;
            return this;
        }

        ///GENMHASH:0E3F9BC2C5C0DB936DBA634A972BC916:8D59AD6440CA44B929F3A1907924F5BC
        public VirtualMachineImpl WithAdminUsername(string adminUsername)
        {
            Inner.OsProfile.AdminUsername = adminUsername;
            return this;
        }


        ///GENMHASH:9BBA27913235B4504FD9F07549E645CC:7C9396228419D56BC31B8BC248BB451A
        public VirtualMachineImpl WithSsh(string publicKeyData)
        {
            OSProfile osProfile = Inner.OsProfile;
            if (osProfile.LinuxConfiguration.Ssh == null)
            {
                SshConfiguration sshConfiguration = new SshConfiguration()
                {
                    PublicKeys = new List<SshPublicKey>()
                };
                osProfile.LinuxConfiguration.Ssh = sshConfiguration;
            }

            SshPublicKey sshPublicKey = new SshPublicKey();
            sshPublicKey.KeyData = publicKeyData;
            sshPublicKey.Path = "/home/" + osProfile.AdminUsername + "/.ssh/authorized_keys";
            osProfile.LinuxConfiguration.Ssh.PublicKeys.Add(sshPublicKey);
            return this;
        }

        ///GENMHASH:F16446581B25DFD00E74CB1193EBF605:7DBCBEBCFCFF036703E8C4680854445D
        public VirtualMachineImpl WithoutVMAgent()
        {
            Inner.OsProfile.WindowsConfiguration.ProvisionVMAgent = false;
            return this;
        }

        ///GENMHASH:98B10909018928720DBCCEBE53E08820:C53BBE49BDF4B37F836CAF494E3A07C9
        public VirtualMachineImpl WithoutAutoUpdate()
        {
            Inner.OsProfile.WindowsConfiguration.EnableAutomaticUpdates = false;
            return this;
        }

        ///GENMHASH:1BBF95374A03EFFD0583730762AB8753:A0586AA1F362669D4458B9D2C4605A9F
        public VirtualMachineImpl WithTimeZone(string timeZone)
        {
            Inner.OsProfile.WindowsConfiguration.TimeZone = timeZone;
            return this;
        }

        ///GENMHASH:F7E8AD723108078BE0FE19CD860DD3D3:7AB774480B8E9543A8CAEE7340C4B7B8
        public VirtualMachineImpl WithWinRM(WinRMListener listener)
        {
            if (Inner.OsProfile.WindowsConfiguration.WinRM == null)
            {
                Inner.OsProfile.WindowsConfiguration.WinRM = new WinRMConfiguration()
                {
                    Listeners = new List<WinRMListener>()
                };
            }
            Inner.OsProfile
                .WindowsConfiguration
                .WinRM
                .Listeners
                .Add(listener);
            return this;
        }

        ///GENMHASH:F2FFAF5448D7DFAFBE00130C62E87053:31B639B9D779BF92E26C4DAAF832C9E7
        public VirtualMachineImpl WithRootPassword(string password)
        {
            Inner.OsProfile.AdminPassword = password;
            return this;
        }

        ///GENMHASH:5810786355B161A5CD254C9E3BE76524:31B639B9D779BF92E26C4DAAF832C9E7
        public VirtualMachineImpl WithAdminPassword(string password)
        {
            Inner.OsProfile.AdminPassword = password;
            return this;
        }

        ///GENMHASH:E8024524BA316DC9DEEB983B272ABF81:A4BB71EB8065E0206CCD541A9DCF4958
        public VirtualMachineImpl WithCustomData(string base64EncodedCustomData)
        {
            Inner.OsProfile.CustomData = base64EncodedCustomData;
            return this;
        }

        ///GENMHASH:51EBA8D3FB4D3F3417FFB3844F1E5D31:D277FC6E9690E3315F7B673013620ECF
        public VirtualMachineImpl WithComputerName(string computerName)
        {
            Inner.OsProfile.ComputerName = computerName;
            return this;
        }

        ///GENMHASH:3EDA6D9B767CDD07D76DD15C0E0B7128:7E4761B66D0FB9A09715DA978222FC55
        public VirtualMachineImpl WithSize(string sizeName)
        {
            Inner.HardwareProfile.VmSize = sizeName;
            return this;
        }

        ///GENMHASH:619ABAAD3F8A01F52AFF9E0735BDAE77:EC0CEDDCD615AA4EFB41DF60CEE2588B
        public VirtualMachineImpl WithSize(VirtualMachineSizeTypes size)
        {
            Inner.HardwareProfile.VmSize = size.ToString();
            return this;
        }

        ///GENMHASH:68806A9EFF9AE1233F4E313BFAB88A1E:89DEE527C9AED179FFFF9E5303751431
        public VirtualMachineImpl WithOSDiskCaching(CachingTypes cachingType)
        {
            Inner.StorageProfile.OsDisk.Caching = cachingType;
            return this;
        }

        ///GENMHASH:6AD476CF269D3B37CBD6D308C3557D31:16840EEFCED2B5791EEB29EDAE4CB087
        public VirtualMachineImpl WithOSDiskVhdLocation(string containerName, string vhdName)
        {
            // Sets the native (un-managed) disk backing virtual machine OS disk
            //
            if (IsManagedDiskEnabled())
            {
                return this;
            }
            StorageProfile storageProfile = Inner.StorageProfile;
            OSDisk osDisk = storageProfile.OsDisk;
            // Setting native (un-managed) disk backing virtual machine OS disk is valid only when
            // the virtual machine is created from image.
            //
            if (!this.IsOSDiskFromImage(osDisk))
            {
                return this;
            }
            // Exclude custom user image as they won't support using native (un-managed) disk to back
            // virtual machine OS disk.
            //
            if (this.IsOsDiskFromCustomImage(storageProfile))
            {
                return this;
            }
            // OS Disk from 'Platform image' requires explicit storage account to be specified.
            //
            if (this.IsOSDiskFromPlatformImage(storageProfile))
            {
                VirtualHardDisk osVhd = new VirtualHardDisk();
                osVhd.Uri = TemporaryBlobUrl(containerName, vhdName);
                Inner.StorageProfile.OsDisk.Vhd = osVhd;
                return this;
            }
            // 'Stored image' and 'Bring your own feature image' has a restriction that the native
            // disk backing OS disk based on these images should reside in the same storage account
            // as the image.
            if (this.IsOSDiskFromStoredImage(storageProfile))
            {
                VirtualHardDisk osVhd = new VirtualHardDisk();
                Uri sourceCustomImageUrl = new Uri(osDisk.Image.Uri);
                Uri destinationVhdUrl = new Uri(new Uri($"{sourceCustomImageUrl.Scheme}://{sourceCustomImageUrl.Host}"),
                    $"{containerName}/{vhdName}");
                osVhd.Uri = destinationVhdUrl.ToString();
                Inner.StorageProfile.OsDisk.Vhd = osVhd;
            }
            return this;
        }

        ///GENMHASH:90924DCFADE551C6E90B738982E6C2F7:279439FCFF8597A1B86C671E92AB9C4F
        public VirtualMachineImpl WithOSDiskStorageAccountType(StorageAccountTypes accountType)
        {
            if (Inner.StorageProfile.OsDisk.ManagedDisk == null)
            {
                Inner
                .StorageProfile
                .OsDisk
                .ManagedDisk = new ManagedDiskParametersInner();
            }
            Inner
                .StorageProfile
                .OsDisk
                .ManagedDisk
                .StorageAccountType = accountType;
            return this;
        }

        ///GENMHASH:621A22301B3EB5233E9DB4ED5BEC5735:E8427EEC4ACC25554660EF889ECD07A2
        public VirtualMachineImpl WithDataDiskDefaultCachingType(CachingTypes cachingType)
        {
            this.managedDataDisks.SetDefaultCachingType(cachingType);
            return this;
        }

        ///GENMHASH:B37B5DD609CF1DB836ABB9CBB32E93E3:EBFBB1CB0457C2978B29376127013BE6
        public VirtualMachineImpl WithDataDiskDefaultStorageAccountType(StorageAccountTypes storageAccountType)
        {
            this.managedDataDisks.SetDefaultStorageAccountType(storageAccountType);
            return this;
        }

        ///GENMHASH:75485319699D66A3C75429B0EB7E0665:AE8D3788AAA49304D58C3DFB3E942C15
        public VirtualMachineImpl WithOSDiskEncryptionSettings(DiskEncryptionSettings settings)
        {
            Inner.StorageProfile.OsDisk.EncryptionSettings = settings;
            return this;
        }

        ///GENMHASH:48CC3BB0EDCE9EE56CB8FEBA4DD9E903:4FFC5F3F684247159297E3463471B6EA
        public VirtualMachineImpl WithOSDiskSizeInGB(int size)
        {
            Inner.StorageProfile.OsDisk.DiskSizeGB = size;
            return this;
        }

        ///GENMHASH:C5EB453493B1100152604C49B4350246:28D2B19DAE6A4D168B24165D74135721
        public VirtualMachineImpl WithOSDiskName(string name)
        {
            Inner.StorageProfile.OsDisk.Name = name;
            return this;
        }

        ///GENMHASH:821D92F0F65352C735EB6081A9BEA9DC:D57B8D7D879942E6738D5D4440AE7921
        public UnmanagedDataDiskImpl DefineUnmanagedDataDisk(string name)
        {
            ThrowIfManagedDiskEnabled(ManagedUnmanagedDiskErrors.VM_Both_Managed_And_Uumanaged_Disk_Not_Allowed);
            return UnmanagedDataDiskImpl.PrepareDataDisk(name, this);
        }

        ///GENMHASH:D4AA1D687C6ADC8E82CF97490E7E2840:4AA0CB7C28989E00E5658781AA7B4944
        public VirtualMachineImpl WithNewUnmanagedDataDisk(int sizeInGB)
        {
            ThrowIfManagedDiskEnabled(ManagedUnmanagedDiskErrors.VM_Both_Managed_And_Uumanaged_Disk_Not_Allowed);
            return DefineUnmanagedDataDisk(null)
                .WithNewVhd(sizeInGB)
                .Attach();
        }

        ///GENMHASH:D5B97545D30FE11F617914568F503B7C:EF873831879537CFDC6AB3A92D1B32E1
        public VirtualMachineImpl WithExistingUnmanagedDataDisk(string storageAccountName, string containerName, string vhdName)
        {
            //$ throwIfManagedDiskEnabled(ManagedUnmanagedDiskErrors.VM_BOTH_MANAGED_AND_UNMANAGED_DISK_NOT_ALLOWED);
            return DefineUnmanagedDataDisk(null)
                .WithExistingVhd(storageAccountName, containerName, vhdName)
                .Attach();
        }


        ///GENMHASH:986009C9CE2533065F3AE9DC169521A5:FB9664669ECF7CF62DE326E69D76F5DE
        public VirtualMachineImpl WithoutUnmanagedDataDisk(string name)
        {
            // Its ok not to throw here, since in general 'withoutXX' can be NOP
            int idx = -1;
            foreach (var dataDisk in this.unmanagedDataDisks)
            {
                idx++;
                if (dataDisk.Name.Equals(name, System.StringComparison.OrdinalIgnoreCase))
                {
                    this.unmanagedDataDisks.RemoveAt(idx);
                    Inner.StorageProfile.DataDisks.RemoveAt(idx);
                    break;
                }
            }
            return this;
        }

        ///GENMHASH:54D3B4BD3F03BEE3E2ACA4B49D0F23C0:1476C04BA42BC075365EAA5629BAD60A
        public VirtualMachineImpl WithoutUnmanagedDataDisk(int lun)
        {
            // Its ok not to throw here, since in general 'withoutXX' can be NOP
            int idx = -1;
            foreach (var dataDisk in this.unmanagedDataDisks)
            {
                idx++;
                if (dataDisk.Lun == lun)
                {
                    this.unmanagedDataDisks.RemoveAt(idx);
                    Inner.StorageProfile.DataDisks.RemoveAt(idx);
                    break;
                }
            }
            return this;
        }

        ///GENMHASH:429C59D407353456A6B5003023273BD7:15F5523485D6FBD0739BA14B1BBC4FAD
        public UnmanagedDataDiskImpl UpdateUnmanagedDataDisk(string name)
        {
            ThrowIfManagedDiskEnabled(ManagedUnmanagedDiskErrors.VM_No_Unmanaged_Disk_To_Update);
            foreach (var dataDisk in this.unmanagedDataDisks)
            {
                if (dataDisk.Name.Equals(name, System.StringComparison.OrdinalIgnoreCase))
                {
                    return (UnmanagedDataDiskImpl)dataDisk;
                }
            }
            throw new Exception("A data disk with name  '" + name + "' not found");
        }

        ///GENMHASH:ED389F29DE6EBB941FA1654A4421A870:EFA122C6179091039C9A2EC452DF4EBB
        public VirtualMachineImpl WithNewDataDisk(ICreatable<Microsoft.Azure.Management.Compute.Fluent.IDisk> creatable)
        {
            ThrowIfManagedDiskDisabled(ManagedUnmanagedDiskErrors.VM_Both_Unmanaged_And_Managed_Disk_Not_Allowed);
            this.AddCreatableDependency(creatable as IResourceCreator<IHasId>);
            this.managedDataDisks.NewDisksToAttach.Add(creatable.Key, new DataDisk()
            {
                Lun = -1
            });
            return this;
        }

        ///GENMHASH:AF80B886368560BF40BD597B1A4C0333:269383EDE2B9B5C9085729DEEBBDCCF9
        public VirtualMachineImpl WithNewDataDisk(ICreatable<Microsoft.Azure.Management.Compute.Fluent.IDisk> creatable, int lun, CachingTypes cachingType)
        {
            ThrowIfManagedDiskDisabled(ManagedUnmanagedDiskErrors.VM_Both_Unmanaged_And_Managed_Disk_Not_Allowed);
            this.AddCreatableDependency(creatable as IResourceCreator<IHasId>);
            this.managedDataDisks.NewDisksToAttach.Add(creatable.Key, new DataDisk()
            {
                Lun = lun,
                Caching = cachingType
            });
            return this;
        }

        ///GENMHASH:674F68CEE727AFB7E6F6D9C7FADE1175:DD2D09ACF9139B1967714865BD1D48FB
        public VirtualMachineImpl WithNewDataDisk(int sizeInGB)
        {
            ThrowIfManagedDiskDisabled(ManagedUnmanagedDiskErrors.VM_Both_Unmanaged_And_Managed_Disk_Not_Allowed);
            this.managedDataDisks.ImplicitDisksToAssociate.Add(new DataDisk()
            {
                Lun = -1,
                DiskSizeGB = sizeInGB
            });
            return this;
        }

        ///GENMHASH:B213E98FA6979257F6E6F61C9B5E550B:17763285B1830F7E43D5411D6D535DE5
        public VirtualMachineImpl WithNewDataDisk(int sizeInGB, int lun, CachingTypes cachingType)
        {
            ThrowIfManagedDiskDisabled(ManagedUnmanagedDiskErrors.VM_Both_Unmanaged_And_Managed_Disk_Not_Allowed);
            this.managedDataDisks.ImplicitDisksToAssociate.Add(new DataDisk()
            {
                Lun = lun,
                DiskSizeGB = sizeInGB,
                Caching = cachingType
            });
            return this;
        }

        ///GENMHASH:1D3A0A89681FFD35007B24FCED6BF299:A69C7823EE7EC5B383A6E9CA6366F777
        public VirtualMachineImpl WithNewDataDisk(int sizeInGB, int lun, CachingTypes cachingType, StorageAccountTypes storageAccountType)
        {
            ThrowIfManagedDiskDisabled(ManagedUnmanagedDiskErrors.VM_Both_Unmanaged_And_Managed_Disk_Not_Allowed);
            ManagedDiskParametersInner managedDiskParameters = new ManagedDiskParametersInner();
            managedDiskParameters.StorageAccountType = storageAccountType;
            this.managedDataDisks.ImplicitDisksToAssociate.Add(new DataDisk()
            {
                Lun = lun,
                DiskSizeGB = sizeInGB,
                Caching = cachingType,
                ManagedDisk = managedDiskParameters
            });
            return this;
        }

        ///GENMHASH:780DFAACAB0C49C5480A9653F0D1B16F:CD32B2E3A381F3A5162D15E662EAE22E
        public VirtualMachineImpl WithExistingDataDisk(IDisk disk)
        {
            ThrowIfManagedDiskDisabled(ManagedUnmanagedDiskErrors.VM_Both_Unmanaged_And_Managed_Disk_Not_Allowed);
            ManagedDiskParametersInner managedDiskParameters = new ManagedDiskParametersInner();
            managedDiskParameters.Id = disk.Id;
            this.managedDataDisks.ExistingDisksToAttach.Add(new DataDisk()
            {
                Lun = -1,
                ManagedDisk = managedDiskParameters
            });
            return this;
        }

        ///GENMHASH:C0B5162CF8CEAACE1539900D43997C4E:ABA2632CB438B4020F743732E9561257
        public VirtualMachineImpl WithExistingDataDisk(IDisk disk, int lun, CachingTypes cachingType)
        {
            ThrowIfManagedDiskDisabled(ManagedUnmanagedDiskErrors.VM_Both_Unmanaged_And_Managed_Disk_Not_Allowed);
            ManagedDiskParametersInner managedDiskParameters = new ManagedDiskParametersInner();
            managedDiskParameters.Id = disk.Id;
            this.managedDataDisks.ExistingDisksToAttach.Add(new DataDisk()
            {
                Lun = lun,
                ManagedDisk = managedDiskParameters,
                Caching = cachingType
            });
            return this;
        }

        ///GENMHASH:EE587883AA52548AF30AC4624CC57C2A:7255A6270AEAD6441F6727139E21D862
        public VirtualMachineImpl WithExistingDataDisk(IDisk disk, int newSizeInGB, int lun, CachingTypes cachingType)
        {
            ThrowIfManagedDiskDisabled(ManagedUnmanagedDiskErrors.VM_Both_Unmanaged_And_Managed_Disk_Not_Allowed);
            ManagedDiskParametersInner managedDiskParameters = new ManagedDiskParametersInner();
            managedDiskParameters.Id = disk.Id;
            this.managedDataDisks.ExistingDisksToAttach.Add(new DataDisk()
            {
                Lun = lun,
                DiskSizeGB = newSizeInGB,
                ManagedDisk = managedDiskParameters,
                Caching = cachingType
            });
            return this;
        }

        ///GENMHASH:89EFB8F9AFBDF98FFAD5606983F59A03:39E3B69A49E68069F2BF73DCEFF3A443
        public VirtualMachineImpl WithNewDataDiskFromImage(int imageLun)
        {
            this.managedDataDisks.NewDisksFromImage.Add(new DataDisk
            {
                Lun = imageLun
            });
            return this;
        }

        ///GENMHASH:92519C2F478984EF05C22A5573361AFE:0CF3D5F4C913309400D9221477B87E1F
        public VirtualMachineImpl WithNewDataDiskFromImage(int imageLun, int newSizeInGB, CachingTypes cachingType)
        {
            this.managedDataDisks.NewDisksFromImage.Add(new DataDisk
            {
                Lun = imageLun,
                DiskSizeGB = newSizeInGB,
                Caching = cachingType
            });
            return this;
        }

        ///GENMHASH:BABD7F4E5FDF4ECA60DB2F163B33F4C7:17AC541DFB3C3AEDF45259848089B054
        public VirtualMachineImpl WithNewDataDiskFromImage(int imageLun, int newSizeInGB, CachingTypes cachingType, StorageAccountTypes storageAccountType)
        {
            ManagedDiskParametersInner managedDiskParameters = new ManagedDiskParametersInner();
            managedDiskParameters.StorageAccountType = storageAccountType;
            this.managedDataDisks.NewDisksFromImage.Add(new DataDisk()
            {
                Lun = imageLun,
                DiskSizeGB = newSizeInGB,
                ManagedDisk = managedDiskParameters,
                Caching = cachingType
            });
            return this;
        }

        ///GENMHASH:9C4A541B9A2E22540116BFA125189F57:2F8856B5F0BA5E1B741D68C6CED48D9A
        public VirtualMachineImpl WithoutDataDisk(int lun)
        {
            if (!IsManagedDiskEnabled())
            {
                return this;
            }
            this.managedDataDisks.DiskLunsToRemove.Add(lun);
            return this;
        }

        ///GENMHASH:2DC51FEC3C45675856B4AC1D97BECBFD:03CBC8ECAD4A07D8AE9ABC931CB422F4
        public VirtualMachineImpl WithNewStorageAccount(ICreatable<Microsoft.Azure.Management.Storage.Fluent.IStorageAccount> creatable)
        {
            // This method's effect is NOT additive.
            if (this.creatableStorageAccountKey == null)
            {
                this.creatableStorageAccountKey = creatable.Key;
                this.AddCreatableDependency(creatable as IResourceCreator<IHasId>);
            }
            return this;
        }

        ///GENMHASH:5880487AA9218E8DF536932A49A0ACDD:35850B81E88D88D68766589B9671E590
        public VirtualMachineImpl WithNewStorageAccount(string name)
        {
            Storage.Fluent.StorageAccount.Definition.IWithGroup definitionWithGroup = this.storageManager
                .StorageAccounts
                .Define(name)
                .WithRegion(this.RegionName);
            Storage.Fluent.StorageAccount.Definition.IWithCreate definitionAfterGroup;
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

        ///GENMHASH:8CB9B7EEE4A4226A6F5BBB2958CC5E81:371A29A476B6231AF7CE026E180DF69D
        public VirtualMachineImpl WithExistingStorageAccount(IStorageAccount storageAccount)
        {
            this.existingStorageAccountToAssociate = storageAccount;
            return this;
        }


        ///GENMHASH:B0D2BED63AF533A1F9AA9D14B66DDA1E:49A8C40E80E0F9117A98775EBC1A348C
        public VirtualMachineImpl WithNewAvailabilitySet(ICreatable<Microsoft.Azure.Management.Compute.Fluent.IAvailabilitySet> creatable)
        {
            if (this.creatableAvailabilitySetKey == null)
            {
                this.creatableAvailabilitySetKey = creatable.Key;
                this.AddCreatableDependency(creatable as IResourceCreator<IHasId>);
            }
            return this;
        }

        ///GENMHASH:0BFC73C37B3D941247E33A0B1AC6113E:391711091FE21C5DAD7F2EAE81567FB0
        public VirtualMachineImpl WithNewAvailabilitySet(string name)
        {
            AvailabilitySet.Definition.IWithGroup definitionWithGroup = base.Manager
                .AvailabilitySets
                .Define(name)
                .WithRegion(this.RegionName);
            AvailabilitySet.Definition.IWithSku definitionWithSku;
            if (this.newGroup != null)
            {
                definitionWithSku = definitionWithGroup.WithNewResourceGroup(this.newGroup);
            }
            else
            {
                definitionWithSku = definitionWithGroup.WithExistingResourceGroup(this.ResourceGroupName);
            }
            ICreatable<IAvailabilitySet> creatable;
            if (IsManagedDiskEnabled())
            {
                creatable = definitionWithSku.WithSku(AvailabilitySetSkuTypes.Managed);
            }
            else
            {
                creatable = definitionWithSku.WithSku(AvailabilitySetSkuTypes.Unmanaged);
            }
            return this.WithNewAvailabilitySet(creatable);
        }

        ///GENMHASH:F2733A66EF0AF45C62E9C44FD29CC576:FC9409B8E6841C279554A2938B4E9F12
        public VirtualMachineImpl WithExistingAvailabilitySet(IAvailabilitySet availabilitySet)
        {
            this.existingAvailabilitySetToAssociate = availabilitySet;
            return this;
        }

        ///GENMHASH:720FC1AD6CE12835DF562FA21CBA22C1:8E210E27AC5BBEFD085A05D8458DC632
        public VirtualMachineImpl WithNewSecondaryNetworkInterface(ICreatable<Microsoft.Azure.Management.Network.Fluent.INetworkInterface> creatable)
        {
            this.creatableSecondaryNetworkInterfaceKeys.Add(creatable.Key);
            this.AddCreatableDependency(creatable as IResourceCreator<IHasId>);
            return this;
        }

        ///GENMHASH:2F9CE7894E6D642D5ABF71D29F2F4B37:60F56E8691A7813CC9E596CB262E800E
        public VirtualMachineImpl WithExistingSecondaryNetworkInterface(INetworkInterface networkInterface)
        {
            this.existingSecondaryNetworkInterfacesToAssociate.Add(networkInterface);
            return this;
        }

        ///GENMHASH:D4842E34F33259DEFED4C90844786E59:39378392E4693029B7DDB841A336DF68
        public IVirtualMachineEncryption DiskEncryption()
        {
            return new VirtualMachineEncryptionImpl(this);
        }

        ///GENMHASH:1B6EFD4FB09DB19A9365B92299382732:6E8FA7A8D0E6C28DD34AA5ED876E9C3F
        public VirtualMachineImpl WithoutSecondaryNetworkInterface(string name)
        {
            if (Inner.NetworkProfile != null
                && Inner.NetworkProfile.NetworkInterfaces != null)
            {
                int idx = -1;
                foreach (NetworkInterfaceReferenceInner nicReference in Inner.NetworkProfile.NetworkInterfaces)
                {
                    idx++;
                    if (nicReference.Primary.HasValue
                        && !nicReference.Primary == true
                        && name.Equals(ResourceUtils.NameFromResourceId(nicReference.Id), StringComparison.OrdinalIgnoreCase))
                    {
                        Inner.NetworkProfile.NetworkInterfaces.RemoveAt(idx);
                        break;
                    }
                }
            }
            return this;
        }

        ///GENMHASH:D7A14F2EFF1E4165DA55EF07B6C19534:85E4528E76EBEB2F2002B48ABD89A8E5
        public VirtualMachineExtensionImpl DefineNewExtension(string name)
        {
            return this.virtualMachineExtensions.Define(name);
        }

        ///GENMHASH:E7610DABE1E75344D9E0DBC0332E7F96:A6222B1A3B3DAF08C7A0DB8408674E80
        public VirtualMachineExtensionImpl UpdateExtension(string name)
        {
            return this.virtualMachineExtensions.Update(name);
        }

        ///GENMHASH:1E53238DF79E665335390B7452E9A04C:C28505CD9AD86AC2345C0714B80220AF
        public VirtualMachineImpl WithoutExtension(string name)
        {
            this.virtualMachineExtensions.Remove(name);
            return this;
        }

        ///GENMHASH:4154589CF64AC591DEDEA5AD2CE5AB3E:0D1CED8472F2D89553DFD9B987FDC9E4
        public VirtualMachineImpl WithPlan(PurchasePlan plan)
        {
            Inner.Plan = new Plan()
            {
                Publisher = plan.Publisher,
                Product = plan.Product,
                Name = plan.Name
            };
            return this;
        }

        ///GENMHASH:168EACA3A73F047931B326C48BD71C2D:25C0F05C248DCD851959044BB5CDA543
        public VirtualMachineImpl WithPromotionalPlan(PurchasePlan plan, string promotionCode)
        {
            this.WithPlan(plan);
            Inner.Plan.PromotionCode = promotionCode;
            return this;
        }

        ///GENMHASH:ED2B5B9A3A19B5A8C2C3E6E1CDBF9402:6A6DEBF76624FF70612A6981A86CC468
        public VirtualMachineImpl WithUnmanagedDisks()
        {
            this.isUnmanagedDiskSelected = true;
            return this;
        }

        ///GENMHASH:4C7CAAD83BFD2178732EBCF6E061B2FA:E84D8725C76163C38C60209300BBC171
        public VirtualMachineImpl WithBootDiagnostics()
        {
            // Diagnostics storage uri will be set later by this.HandleBootDiagnosticsStorageSettings(..)
            //
            this.EnableDisableBootDiagnostics(true);
            return this;
        }


        ///GENMHASH:863CDD9F8489B70A038C82A8B4339C1E:9ABCD9EF7B6D335327D3363AC01E0FFF
        public VirtualMachineImpl WithBootDiagnostics(ICreatable<Microsoft.Azure.Management.Storage.Fluent.IStorageAccount> creatable)
        {
            // Diagnostics storage uri will be set later by this.HandleBootDiagnosticsStorageSettings(..)
            //
            EnableDisableBootDiagnostics(true);
            this.creatableDiagnosticsStorageAccountKey = creatable.Key;
            this.AddCreatableDependency(creatable as IResourceCreator<IHasId>);
            return this;
        }

        ///GENMHASH:5719F860C08C586F249065EB7A86DED3:D78B3EDD6BE5C30863D9F9E21A28EE11
        public VirtualMachineImpl WithBootDiagnostics(string storageAccountBlobEndpointUri)
        {
            this.EnableDisableBootDiagnostics(true);
            this.Inner
                .DiagnosticsProfile
                .BootDiagnostics
                .StorageUri = storageAccountBlobEndpointUri;
            return this;
        }

        ///GENMHASH:F731B4942EC78BDFB7DA69F73C48F080:7E7787C820A03B7F2B97B51FDACA8053
        public VirtualMachineImpl WithBootDiagnostics(IStorageAccount storageAccount)
        {
            return this.WithBootDiagnostics(storageAccount.EndPoints.Primary.Blob);
        }

        ///GENMHASH:5892700B93394BCA74ABA1B081C6F158:455622D3AC079705ADC12CAFAD0028C2
        public VirtualMachineImpl WithoutBootDiagnostics()
        {
            this.EnableDisableBootDiagnostics(false);
            return this;
        }

        ///GENMHASH:C81171F34FA85CED80852E725FF8B7A4:56767F3A519F0DF8AB9F685ABA15F2E4
        public bool IsManagedDiskEnabled()
        {
            if (IsOsDiskFromCustomImage(Inner.StorageProfile))
            {
                return true;
            }

            if (IsOSDiskAttachedManaged(Inner.StorageProfile.OsDisk))
            {
                return true;
            }
            if (IsOSDiskFromStoredImage(Inner.StorageProfile))
            {
                return false;
            }
            if (IsOSDiskAttachedUnmanaged(Inner.StorageProfile.OsDisk))
            {
                return false;
            }
            if (IsOSDiskFromPlatformImage(Inner.StorageProfile))
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
                return Inner.StorageProfile.OsDisk.Vhd == null;
            }
        }

        ///GENMHASH:3EFB25CB32AC4B416B8E0501FDE1DBE9:9063BC00A181FC49D367F4FD1F0EB371
        public string ComputerName()
        {
            if (Inner.OsProfile == null)
            {
                // VM created by attaching a specialized OS Disk VHD will not have the osProfile.
                return null;
            }
            return Inner.OsProfile.ComputerName;
        }

        ///GENMHASH:C19382933BDE655D0F0F95CD9474DFE7:2F66035F0CB425AA1735B96753E25A51
        public VirtualMachineSizeTypes Size()
        {
            return VirtualMachineSizeTypes.Parse(Inner.HardwareProfile.VmSize);
        }

        ///GENMHASH:1BAF4F1B601F89251ABCFE6CC4867026:AACA43FF0E9DA39D6993719C23FB0486
        public OperatingSystemTypes OSType()
        {
            return Inner.StorageProfile.OsDisk.OsType.Value;
        }

        ///GENMHASH:E6371CFFB9CB09E08DD4757D639CBF27:976273E359EA5250C90646DEEB682652
        public string OSUnmanagedDiskVhdUri()
        {
            if (IsManagedDiskEnabled())
            {
                return null;
            }
            return Inner.StorageProfile.OsDisk.Vhd.Uri;
        }

        ///GENMHASH:123FF0223083F789E78E45771A759A9C:1604791894B0C3EF16EEDF56536B8B70
        public CachingTypes OSDiskCachingType()
        {
            return Inner.StorageProfile.OsDisk.Caching.Value;
        }

        ///GENMHASH:034DA366E39060AAD75E1DA786657383:65EDBB2144C128EB0C43030D512C5EED
        public int OSDiskSize()
        {
            if (Inner.StorageProfile.OsDisk.DiskSizeGB == null)
            {
                // Server returns OS disk size as 0 for auto-created disks for which
                // size was not explicitly set by the user.
                return 0;
            }
            return Inner.StorageProfile.OsDisk.DiskSizeGB.Value;
        }

        ///GENMHASH:E5CADE85564466522E512C04EB3F57B6:086F150AD4D805B10FE2EDCCE4784829
        public StorageAccountTypes? OSDiskStorageAccountType()
        {
            if (!IsManagedDiskEnabled() || this.StorageProfile().OsDisk.ManagedDisk == null)
            {
                return null;
            }
            return this.StorageProfile().OsDisk.ManagedDisk.StorageAccountType;
        }

        ///GENMHASH:C6D786A0345B2C4ADB349E573A0BF6C7:E98CE6464DD63DE655EAFA519D693285
        public string OSDiskId()
        {
            if (!IsManagedDiskEnabled())
            {
                return null;
            }
            return this.StorageProfile().OsDisk.ManagedDisk.Id;
        }

        ///GENMHASH:0F25C4AF79F7680F2CB3C57410B5BC20:FFF5003A8246F7DB1BDBE31636E6CE9C
        public IReadOnlyDictionary<int, Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineUnmanagedDataDisk> UnmanagedDataDisks()
        {
            Dictionary<int, IVirtualMachineUnmanagedDataDisk> dataDisks = new Dictionary<int, IVirtualMachineUnmanagedDataDisk>();
            if (!IsManagedDiskEnabled())
            {
                foreach (var dataDisk in this.unmanagedDataDisks)
                {
                    dataDisks.Add(dataDisk.Lun, dataDisk);
                }
            }
            return dataDisks;
        }

        ///GENMHASH:353C54F9ADAEAEDD54EE4F0AACF9DF9B:E5641D026D42E80470787BB2990E88CE
        public IReadOnlyDictionary<int, Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineDataDisk> DataDisks()
        {
            Dictionary<int, IVirtualMachineDataDisk> dataDisks = new Dictionary<int, IVirtualMachineDataDisk>();
            if (IsManagedDiskEnabled())
            {
                var innerDataDisks = Inner.StorageProfile.DataDisks;
                if (innerDataDisks != null)
                {
                    foreach (var innerDataDisk in innerDataDisks)
                    {
                        dataDisks.Add(innerDataDisk.Lun, new VirtualMachineDataDiskImpl(innerDataDisk));
                    }
                }
            }
            return dataDisks;
        }

        ///GENMHASH:2A7ACF9E7DA59ECB74A3F0607B98CEA8:46FD353C4642C823383ED54BCE79C710
        public INetworkInterface GetPrimaryNetworkInterface()
        {
            return this.networkManager.NetworkInterfaces.GetById(this.PrimaryNetworkInterfaceId());
        }

        ///GENMHASH:D3ADA5DC7B5CC9C5BD29AC1110C61014:EC93403D80CE55A8079C6FDA3D5DE566
        public IPublicIPAddress GetPrimaryPublicIPAddress()
        {
            return this.GetPrimaryNetworkInterface().PrimaryIPConfiguration.GetPublicIPAddress();
        }

        ///GENMHASH:5977CC2F7355BB73CD32528805FEDA4D:8A6DCD2F68FE8ED005BB9933A0E74217
        public string GetPrimaryPublicIPAddressId()
        {
            return this.GetPrimaryNetworkInterface().PrimaryIPConfiguration.PublicIPAddressId;
        }

        ///GENMHASH:606A3D349546DF27E3A091C321476658:DC63C44DC2A2862C6AC14F711DCB1EFA
        public IReadOnlyList<string> NetworkInterfaceIds()
        {
            List<string> nicIds = new List<string>();
            foreach (NetworkInterfaceReferenceInner nicRef in Inner.NetworkProfile.NetworkInterfaces)
            {
                nicIds.Add(nicRef.Id);
            }
            return nicIds;
        }

        ///GENMHASH:8149ED362968AEDB6044CB62BAB0373B:2296DA5603B8E3273CF41C4869FD4795
        public string PrimaryNetworkInterfaceId()
        {
            IList<NetworkInterfaceReferenceInner> nicRefs = Inner.NetworkProfile.NetworkInterfaces;
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
                    if (nicRef.Primary != null && nicRef.Primary.HasValue && nicRef.Primary == true)
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

        ///GENMHASH:AE4C4EDD69D8398105E588BB437DB52F:66995F8696299A549C7E506466483AED
        public string AvailabilitySetId()
        {
            if (Inner.AvailabilitySet != null)
            {
                return Inner.AvailabilitySet.Id;
            }
            return null;
        }

        ///GENMHASH:99D5BF64EA8AA0E287C9B6F77AAD6FC4:3DB04077E6BABC0FB5A5ACDA19D11309
        public string ProvisioningState()
        {
            return Inner.ProvisioningState;
        }

        ///GENMHASH:069B0F660FC41DE3B93D2DC7C8D6822E:32B4F61D2B05A6879D35794E524767CB
        public string LicenseType()
        {
            return Inner.LicenseType;
        }

        ///GENMHASH:283A7CD491ABC476D6646B943D8641A8:BB7251641858D1CBEADD4ABE2AF921D3
        public Plan Plan()
        {
            return Inner.Plan;
        }

        ///GENMHASH:7F0A9CB4CB6BBC98F72CF50A81EBFBF4:3689C1A52147BB53E4C284572C790C00
        public StorageProfile StorageProfile()
        {
            return Inner.StorageProfile;
        }

        ///GENMHASH:5390AD803419DE6CEAFF825AD0A94458:7197E049071CE2157D45362744EAD102
        public OSProfile OSProfile()
        {
            return Inner.OsProfile;
        }

        ///GENMHASH:6DC69B57C0EF18B742D6A9F6EF064DB6:918D5C0812D3C8CF539A3DD9FC338819
        public DiagnosticsProfile DiagnosticsProfile()
        {
            return Inner.DiagnosticsProfile;
        }

        ///GENMHASH:F91DF44F14D53833479DE592AB2B2890:A44F980B37B6696BA13F0A8DB633DCCA
        public string VMId()
        {
            return Inner.VmId;
        }

        ///GENMHASH:E21E3E6E61153DDD23E28BC18B49F1AC:BAF1B6669763368768C132F520B23A67
        public VirtualMachineInstanceView InstanceView()
        {
            if (this.virtualMachineInstanceView == null)
            {
                this.RefreshInstanceView();
            }
            return this.virtualMachineInstanceView;
        }

        ///GENMHASH:74D6BC0CA5239D9979A6C4F61D973616:C90E0C1B7FFF1EE7A6D2A1D595F52BE7
        public PowerState PowerState()
        {
            return Fluent.PowerState.FromInstanceView(this.InstanceView());
        }

        ///GENMHASH:D8D324B42ED7B0976032110E0D5D3320:32345B0AB329E6E420804CD852C47627
        public bool IsBootDiagnosticsEnabled()
        {
            if (this.Inner.DiagnosticsProfile != null
                && this.Inner.DiagnosticsProfile.BootDiagnostics != null
                && this.Inner.DiagnosticsProfile.BootDiagnostics.Enabled != null
                && this.Inner.DiagnosticsProfile.BootDiagnostics.Enabled.HasValue) {
                    return this.Inner.DiagnosticsProfile.BootDiagnostics.Enabled.Value;
            }
            return false;
        }

        ///GENMHASH:F842C1987E811B219C87CFA14349A00B:556CABFA1947D39EDB3AAE3870809862
        public string BootDiagnosticsStorageUri()
        {
            // Even though diagnostics can disabled azure still keep the storage uri
            if (this.Inner.DiagnosticsProfile != null
                && this.Inner.DiagnosticsProfile.BootDiagnostics != null) {
                    return this.Inner.DiagnosticsProfile.BootDiagnostics.StorageUri;
            }
            return null;
        }

        ///GENMHASH:9019C44FB9C28F62603D9972D45A9522:04EA2CF2FF84B5C44179285E14BA0FF0
        public string ManagedServiceIdentityPrincipalId()
        {
            if (this.Inner.Identity != null) {
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
            if (this.Inner.Identity != null) {
                return this.Inner.Identity.TenantId;
            }
            return null;
        }

        ///GENMHASH:E059E91FE0CBE4B6875986D1B46994D2:AF3425B1B2ADC5865D8191FBE2FE4BBC
        public VirtualMachineImpl WithManagedServiceIdentity()
        {
            this.virtualMachineMsiHelper.WithManagedServiceIdentity(this.Inner);
            return this;
        }

        ///GENMHASH:D9244CA3B3398B7594B546247D593343:FE0DBB208E366B7AD2F00C67E391FED1
        public VirtualMachineImpl WithManagedServiceIdentity(int tokenPort)
        {
            this.virtualMachineMsiHelper.WithManagedServiceIdentity(tokenPort, this.Inner);
            return this;
        }

        ///GENMHASH:DEF511724D2CC8CA91F24E084BC9AA22:72F0234D4EBEB820BB2E8EB0ED1665A6
        public VirtualMachineImpl WithRoleDefinitionBasedAccessTo(string scope, string roleDefinitionId)
        {
            this.virtualMachineMsiHelper.WithRoleDefinitionBasedAccessTo(scope, roleDefinitionId);
            return this;
        }

        ///GENMHASH:F6C5721A84FA825F62951BE51537DD36:8A9263C84F0D839E6FAFC22D8AA1C9C4
        public VirtualMachineImpl WithRoleBasedAccessToCurrentResourceGroup(BuiltInRole asRole)
        {
            this.virtualMachineMsiHelper.WithRoleBasedAccessToCurrentResourceGroup(asRole);
            return this;
        }

        ///GENMHASH:5FD7E26022EAFDACD062A87DDA8FD39A:7E679ACDB7E20973F54635A194130E55
        public VirtualMachineImpl WithRoleDefinitionBasedAccessToCurrentResourceGroup(string roleDefinitionId)
        {
            this.virtualMachineMsiHelper.WithRoleDefinitionBasedAccessToCurrentResourceGroup(roleDefinitionId);
            return this;
        }

        ///GENMHASH:EFFF7ECD982913DB369E1EF1644031CB:C9A5FE940311449954FA688A4B3D8333
        public VirtualMachineImpl WithRoleBasedAccessTo(string scope, BuiltInRole asRole)
        {
            this.virtualMachineMsiHelper.WithRoleBasedAccessTo(scope, asRole);
            return this;
        }

        ///GENMHASH:0202A00A1DCF248D2647DBDBEF2CA865:272F8DA403745EB8C8C6DCCD8A4778E2
        public async override Task<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            if (IsInCreateMode)
            {
                SetOSDiskDefaults();
                SetOSProfileDefaults();
                SetHardwareProfileDefaults();
            }
            if (IsManagedDiskEnabled())
            {
                managedDataDisks.SetDataDisksDefaults();
            }
            else
            {
                UnmanagedDataDiskImpl.SetDataDisksDefaults(this.unmanagedDataDisks, this.vmName);
            }
            var diskStorageAccount = await HandleStorageSettingsAsync(cancellationToken);
            await HandleBootDiagnosticsStorageSettingsAsync(diskStorageAccount, cancellationToken);
            HandleNetworkSettings();
            HandleAvailabilitySettings();
            var response = await Manager.Inner.VirtualMachines.CreateOrUpdateAsync(ResourceGroupName, vmName, Inner, cancellationToken);
            var extensionsCommited = await this.virtualMachineExtensions.CommitAndGetAllAsync(cancellationToken);
            if (extensionsCommited.Any())
            {
                // Another get to fetch vm inner with extensions list reflecting the commited changes to extensions
                //
                response = await Manager.Inner.VirtualMachines.GetAsync(ResourceGroupName, vmName, null, cancellationToken);
            }
            this.Reset(response);
            MSIResourcesSetupResult msiResourceSetupResult = await virtualMachineMsiHelper.SetupVirtualMachineMSIResourcesAsync(this, cancellationToken);
            if (msiResourceSetupResult.IsExtensionInstalledOrUpdated)
            {
                // Another get to fetch vm inner with extensions list reflecting MSI extension changes.
                //
                response = await Manager.Inner.VirtualMachines.GetAsync(ResourceGroupName, vmName, null, cancellationToken);
                this.Reset(response);
            }
            return this;
        }

        ///GENMHASH:C39D7E2559FD1B42A87D25FE5A1DF9FB:66952279088908D6E3122C9FE427DCE3
        private void Reset(VirtualMachineInner inner)
        {
            this.SetInner(inner);
            ClearCachedRelatedResources();
            InitializeDataDisks();
            InitializeExtensions();
        }

        ///GENMHASH:F0BA5F3F27F923CBF88531E8051E2766:3A9860E56B386DEBF12E9494C009C2A3
        internal VirtualMachineImpl WithExtension(VirtualMachineExtensionImpl extension)
        {
            this.virtualMachineExtensions.AddExtension(extension);
            return this;
        }

        ///GENMHASH:935C3974286F7E329FEE80FBDDC054A4:A1DADF029D57D1765F6994801B1B1197
        internal VirtualMachineImpl WithUnmanagedDataDisk(UnmanagedDataDiskImpl dataDisk)
        {
            Inner
                .StorageProfile
                .DataDisks
                .Add(dataDisk.Inner);
            this.unmanagedDataDisks
                .Add(dataDisk);
            return this;
        }

        ///GENMHASH:F8B60EFFDA7AE3E1DE1C427665105067:0C39F05B8A560CA80F8F94A7A6DC6D17
        private void SetOSDiskDefaults()
        {
            if (IsInUpdateMode())
            {
                return;
            }
            StorageProfile storageProfile = Inner.StorageProfile;
            OSDisk osDisk = storageProfile.OsDisk;
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
                        osDisk.ManagedDisk = new ManagedDiskParametersInner();
                    }
                    if (osDisk.ManagedDisk.StorageAccountType == null)
                    {
                        osDisk.ManagedDisk
                            .StorageAccountType = StorageAccountTypes.StandardLRS;
                    }
                    osDisk.Vhd = null;
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
                    if (IsOSDiskFromPlatformImage(storageProfile)
                        || IsOSDiskFromStoredImage(storageProfile))
                    {
                        if (osDisk.Vhd == null)
                        {
                            string osDiskVhdContainerName = "vhds";
                            string osDiskVhdName = this.vmName + "-os-disk-" + Guid.NewGuid().ToString() + ".Vhd";
                            WithOSDiskVhdLocation(osDiskVhdContainerName, osDiskVhdName);
                        }
                        osDisk.ManagedDisk = null;
                    }
                    if (osDisk.Name == null)
                    {
                        WithOSDiskName(this.vmName + "-os-disk");
                    }
                }
            }
            else
            {
                // ODDisk CreateOption: ATTACH
                //
                if (IsManagedDiskEnabled())
                {
                    // In case of attach, it is not allowed to change the storage account type of the
                    // managed disk.
                    //
                    if (osDisk.ManagedDisk != null)
                    {
                        osDisk.ManagedDisk.StorageAccountType = null;
                    }
                    osDisk.Vhd = null;
                }
                else
                {
                    osDisk.ManagedDisk = null;
                    if (osDisk.Name == null)
                    {
                        WithOSDiskName(this.vmName + "-os-disk");
                    }
                }
            }
            if (osDisk.Caching == null)
            {
                WithOSDiskCaching(CachingTypes.ReadWrite);
            }
        }

        ///GENMHASH:67723971057BB45E3F0FFEB5B7B65F34:0E41FE124CF67BA67B6A50BC9B9B57B0
        private void SetOSProfileDefaults()
        {
            if (IsInUpdateMode())
            {
                return;
            }
            StorageProfile storageProfile = Inner.StorageProfile;
            OSDisk osDisk = storageProfile.OsDisk;
            if (IsOSDiskFromImage(osDisk))
            {
                // ODDisk CreateOption: FROM_IMAGE
                //
                if (osDisk.OsType == OperatingSystemTypes.Linux || this.isMarketplaceLinuxImage)
                {
                    // linux image: PlatformImage | CustomImage | StoredImage
                    //
                    OSProfile osProfile = Inner.OsProfile;
                    if (osProfile.LinuxConfiguration == null)
                    {
                        osProfile.LinuxConfiguration = new LinuxConfiguration();
                    }
                    Inner.OsProfile
                        .LinuxConfiguration
                        .DisablePasswordAuthentication = osProfile.AdminPassword == null;
                }
                if (Inner.OsProfile.ComputerName == null)
                {
                    // VM name cannot contain only numeric values and cannot exceed 15 chars
                    if ((new Regex(@"^\d+$")).IsMatch(vmName))
                    {
                        Inner.OsProfile.ComputerName = SdkContext.RandomResourceName("vm", 15);
                    }
                    else if (vmName.Length <= 15)
                    {
                        Inner.OsProfile.ComputerName = vmName;
                    }
                    else
                    {
                        Inner.OsProfile.ComputerName = SdkContext.RandomResourceName("vm", 15);
                    }
                }
            }
            else
            {
                // ODDisk CreateOption: ATTACH
                //
                // OS Profile must be set to null when an VM's OS disk is ATTACH-ed to a managed disk or
                // Specialized VHD
                //
                Inner.OsProfile = null;
            }
        }

        ///GENMHASH:BAA70B10A8929783F1FC5D60B4D80538:733856474CD1EBA8B9EB83FA7C73D293
        private void SetHardwareProfileDefaults()
        {
            if (!IsInCreateMode)
            {
                return;
            }
            HardwareProfile hardwareProfile = Inner.HardwareProfile;
            if (hardwareProfile.VmSize == null)
            {
                hardwareProfile.VmSize = VirtualMachineSizeTypes.BasicA0.ToString();
            }
        }

        ///GENMHASH:E9830BD8841F5F66740928BA7AA21EB0:52457D4653AB87BFDAB452BDB2A8B34C
        private async Task<IStorageAccount> HandleStorageSettingsAsync(CancellationToken cancellationToken = default(CancellationToken))
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
            else if (this.OsDiskRequiresImplicitStorageAccountCreation() ||
                this.DataDisksRequiresImplicitStorageAccountCreation())
            {
                storageAccount = await this.storageManager.StorageAccounts
                .Define(this.namer.RandomName("stg", 24).Replace("-", ""))
                .WithRegion(this.RegionName)
                .WithExistingResourceGroup(this.ResourceGroupName)
                .CreateAsync(cancellationToken);
            }

            if (!IsManagedDiskEnabled())
            {
                if (IsInCreateMode)
                {
                    if (this.IsOSDiskFromPlatformImage(Inner.StorageProfile))
                    {
                        string uri = Inner.StorageProfile.OsDisk.Vhd.Uri;
                        if (uri.StartsWith("{storage-base-url}"))
                        {
                            uri = uri.Remove(0, "{storage-base-url}".Length).Insert(0,
                                storageAccount.EndPoints.Primary.Blob);
                        }
                        Inner.StorageProfile.OsDisk.Vhd.Uri = uri;
                    }
                    UnmanagedDataDiskImpl.EnsureDisksVhdUri(this.unmanagedDataDisks, storageAccount, this.vmName);
                }
                else
                {
                    if (storageAccount != null)
                    {
                        UnmanagedDataDiskImpl.EnsureDisksVhdUri(this.unmanagedDataDisks, storageAccount, this.vmName);
                    }
                    else
                    {
                        UnmanagedDataDiskImpl.EnsureDisksVhdUri(this.unmanagedDataDisks, this.vmName);
                    }
                }
            }
            return storageAccount;
        }


        ///GENMHASH:679C8E77D63CDAC3C75B428C73FDBA6F:810F9B4884B03FC354476CC848056897
        private async Task<Microsoft.Azure.Management.Storage.Fluent.IStorageAccount> HandleBootDiagnosticsStorageSettingsAsync(IStorageAccount diskStorageAccount, 
            CancellationToken cancellationToken = default(CancellationToken))
        {
            if (this.Inner.DiagnosticsProfile == null 
                || this.Inner.DiagnosticsProfile.BootDiagnostics == null)
            {
                return diskStorageAccount;
            } else if (this.Inner.DiagnosticsProfile.BootDiagnostics.StorageUri != null)
            {
                return diskStorageAccount;
            } else if (this.Inner.DiagnosticsProfile.BootDiagnostics.Enabled.HasValue 
                && this.Inner.DiagnosticsProfile.BootDiagnostics.Enabled == true)
            {
                if (this.creatableDiagnosticsStorageAccountKey != null)
                {
                    var diagnosticsStgAccount = (IStorageAccount)this.CreatedResource(this.creatableDiagnosticsStorageAccountKey);
                    this.Inner.DiagnosticsProfile.BootDiagnostics.StorageUri = diagnosticsStgAccount.EndPoints.Primary.Blob;
                    return diskStorageAccount == null? diagnosticsStgAccount : diskStorageAccount;
                }
                if (diskStorageAccount != null)
                {
                    this.Inner.DiagnosticsProfile.BootDiagnostics.StorageUri = diskStorageAccount.EndPoints.Primary.Blob;
                    return diskStorageAccount;
                }
                else
                {
                    var diagnosticsStgAccount = await this.storageManager.StorageAccounts
                        .Define(this.namer.RandomName("stg", 24).Replace("-", ""))
                        .WithRegion(this.RegionName)
                        .WithExistingResourceGroup(this.ResourceGroupName)
                        .CreateAsync(cancellationToken);
                    this.Inner
                        .DiagnosticsProfile
                        .BootDiagnostics
                        .StorageUri = diagnosticsStgAccount.EndPoints.Primary.Blob;
                    return diagnosticsStgAccount;
                }
            }
            return diskStorageAccount;
        }

        ///GENMHASH:D07A07F736607425258AAE80368A516D:168FE2B09726F397B3F197216CE80D80
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
                    Inner.NetworkProfile.NetworkInterfaces.Add(nicReference);
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
                Inner.NetworkProfile.NetworkInterfaces.Add(nicReference);
            }

            foreach (INetworkInterface secondaryNetworkInterface in this.existingSecondaryNetworkInterfacesToAssociate)
            {
                NetworkInterfaceReferenceInner nicReference = new NetworkInterfaceReferenceInner();
                nicReference.Primary = false;
                nicReference.Id = secondaryNetworkInterface.Id;
                Inner.NetworkProfile.NetworkInterfaces.Add(nicReference);
            }
        }

        ///GENMHASH:C5029F7D6B24C60F12C8C8EE00CA338D:4025A91B58E8284506099B34457E6276
        private void EnableDisableBootDiagnostics(bool enable)
        {
            if (this.Inner.DiagnosticsProfile == null)
            {
                this.Inner.DiagnosticsProfile =  new DiagnosticsProfile();
            }
            if (this.Inner.DiagnosticsProfile.BootDiagnostics == null)
            {
                this.Inner.DiagnosticsProfile.BootDiagnostics = new BootDiagnostics();
            }
            if (enable)
            {
                this.Inner.DiagnosticsProfile.BootDiagnostics.Enabled = true;
            }
            else
            {
                this.Inner.DiagnosticsProfile.BootDiagnostics.Enabled = false;
                this.Inner.DiagnosticsProfile.BootDiagnostics.StorageUri = null;
            }
        }

        ///GENMHASH:53777A14878B3B30AC6877B2675500B6:1AB26718B32878FC0C06014D270C9E47
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
                if (Inner.AvailabilitySet == null)
                {
                    Inner.AvailabilitySet = new SubResource();
                }

                Inner.AvailabilitySet.Id = availabilitySet.Id;
            }
        }

        ///GENMHASH:0F7707B8B59F80529877E77CA52B31EB:6699FB156B9D992393D42B866A411897
        private bool OsDiskRequiresImplicitStorageAccountCreation()
        {
            if (IsManagedDiskEnabled())
            {
                return false;
            }
            if (this.creatableStorageAccountKey != null
                || this.existingStorageAccountToAssociate != null
                || !IsInCreateMode)
            {
                return false;
            }
            return IsOSDiskFromPlatformImage(Inner.StorageProfile);
        }

        ///GENMHASH:E54BC4A600C7D7F1F1FE5ECD633F9B03:25941EB989277B5A8346038827B5F346
        private bool DataDisksRequiresImplicitStorageAccountCreation()
        {
            if (IsManagedDiskEnabled())
            {
                return false;
            }
            if (this.creatableStorageAccountKey != null
                || this.existingStorageAccountToAssociate != null
                || this.unmanagedDataDisks.Count == 0)
            {
                return false;
            }
            bool hasEmptyVhd = false;
            foreach (var dataDisk in this.unmanagedDataDisks)
            {
                if (dataDisk.CreationMethod == DiskCreateOptionTypes.Empty
                    || dataDisk.CreationMethod == DiskCreateOptionTypes.FromImage)
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
                foreach (var dataDisk in this.unmanagedDataDisks)
                {
                    if (dataDisk.CreationMethod == DiskCreateOptionTypes.Attach && dataDisk.Inner.Vhd != null)
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// Checks whether the OS disk is directly attached to a unmanaged VHD.
        /// </summary>
        /// <param name="osDisk">The osDisk value in the storage profile.</param>
        /// <return>True if the OS disk is attached to a unmanaged VHD, false otherwise.</return>
        ///GENMHASH:6CAC7BFC25EF528C827BF922106219DC:721D04FDAA4169ED19C4CC3CCA1A2EDC
        private bool IsOSDiskAttachedUnmanaged(OSDisk osDisk)
        {
            return osDisk.CreateOption == DiskCreateOptionTypes.Attach
                && osDisk.Vhd != null
                && osDisk.Vhd.Uri != null;
        }

        /// <summary>
        /// Checks whether the OS disk is directly attached to a managed disk.
        /// </summary>
        /// <param name="osDisk">The osDisk value in the storage profile.</param>
        /// <return>True if the OS disk is attached to a managed disk, false otherwise.</return>
        ///GENMHASH:854EABA33961F7FA017100E1888B2F8F:4738C912BD9ED6489A96318D934E8BC9
        private bool IsOSDiskAttachedManaged(OSDisk osDisk)
        {
            return osDisk.CreateOption == DiskCreateOptionTypes.Attach
                && osDisk.ManagedDisk != null
                && osDisk.ManagedDisk.Id != null;
        }

        /// <summary>
        /// Checks whether the OS disk is based on an image (image from PIR or custom image [captured, bringYourOwnFeature]).
        /// </summary>
        /// <param name="osDisk">The osDisk value in the storage profile.</param>
        /// <return>True if the OS disk is configured to use image from PIR or custom image.</return>
        ///GENMHASH:2BC5DC58EDF7989592189AD8B4E29C17:4CD85EE98AD4F7CBC33994D722986AE5
        private bool IsOSDiskFromImage(OSDisk osDisk)
        {
            return osDisk.CreateOption == DiskCreateOptionTypes.FromImage;
        }

        /// <summary>
        /// Checks whether the OS disk is based on an platform image (image in PIR).
        /// </summary>
        /// <param name="storageProfile">The storage profile.</param>
        /// <return>True if the OS disk is configured to be based on platform image.</return>
        ///GENMHASH:78EB0F392606FADDDAFE3E594B6F4E7F:8A0B58C5E0133CF29412CD658BAF8289
        private bool IsOSDiskFromPlatformImage(StorageProfile storageProfile)
        {
            ImageReferenceInner imageReference = storageProfile.ImageReference;
            return IsOSDiskFromImage(storageProfile.OsDisk)
            && imageReference != null
            && imageReference.Publisher != null
            && imageReference.Offer != null
            && imageReference.Sku != null
            && imageReference.Version != null;
        }

        /// <summary>
        /// Checks whether the OS disk is based on a CustomImage.
        /// A custom image is represented by com.microsoft.azure.management.compute.VirtualMachineCustomImage.
        /// </summary>
        /// <param name="storageProfile">The storage profile.</param>
        /// <return>True if the OS disk is configured to be based on custom image.</return>
        ///GENMHASH:441A8F22C03964CEECA8AFEBA8740C9C:F979E27E10A5C3D262E33101E3EF232A
        private bool IsOsDiskFromCustomImage(StorageProfile storageProfile)
        {
            ImageReferenceInner imageReference = storageProfile.ImageReference;
            return IsOSDiskFromImage(storageProfile.OsDisk)
                && imageReference != null
                && imageReference.Id != null;
        }

        /// <summary>
        /// Checks whether the OS disk is based on a stored image ('captured' or 'bring your own feature').
        /// A stored image is created by calling VirtualMachine.capture(String, String, boolean).
        /// </summary>
        /// <param name="storageProfile">The storage profile.</param>
        /// <return>True if the OS disk is configured to use custom image ('captured' or 'bring your own feature').</return>
        ///GENMHASH:195FC3E4B41990335C260656FB0A8071:F51CCA18341E6B7F7C44FBF50F4BFC68
        private bool IsOSDiskFromStoredImage(StorageProfile storageProfile)
        {
            OSDisk osDisk = storageProfile.OsDisk;
            return IsOSDiskFromImage(osDisk)
                && osDisk.Image != null
                && osDisk.Image.Uri != null;
        }

        ///GENMHASH:8143A53E487619B77CA38F74DEA81560:B603F79C83B2E3EB33CD223B542FC5BB
        private string TemporaryBlobUrl(string containerName, string blobName)
        {
            return "{storage-base-url}" + containerName + "/" + blobName;
        }

        ///GENMHASH:E972A9EA7BC4745B11D042E506C9EC88:67C9F7C47AB1078BBDB948EE068D0EDC
        private Network.Fluent.NetworkInterface.Definition.IWithPrimaryPublicIPAddress PrepareNetworkInterface(string name)
        {
            Network.Fluent.NetworkInterface.Definition.IWithGroup definitionWithGroup = this.networkManager.NetworkInterfaces
                .Define(name)
                .WithRegion(this.RegionName);
            Network.Fluent.NetworkInterface.Definition.IWithPrimaryNetwork definitionWithNetwork;
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
                .WithPrimaryPrivateIPAddressDynamic();
        }

        ///GENMHASH:528DB7AD001AA15B5C463269BA0A948C:86593E909D0CD3E320C19512D2A5F96A
        private Network.Fluent.NetworkInterface.Definition.IWithPrimaryNetwork PreparePrimaryNetworkInterface(string name)
        {
            Network.Fluent.NetworkInterface.Definition.IWithGroup definitionWithGroup = this.networkManager.NetworkInterfaces
            .Define(name)
            .WithRegion(this.RegionName);
            Network.Fluent.NetworkInterface.Definition.IWithPrimaryNetwork definitionAfterGroup;
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

        ///GENMHASH:5D074C2BCA5877F1D6C918952020AA65:1F2CEECDB6231FC6883D5B321DFBE9BF
        private void InitializeDataDisks()
        {
            if (Inner.StorageProfile.DataDisks == null)
            {
                Inner
                    .StorageProfile
                    .DataDisks = new List<DataDisk>();
            }
            this.isUnmanagedDiskSelected = false;
            this.managedDataDisks.Clear();
            this.unmanagedDataDisks = new List<IVirtualMachineUnmanagedDataDisk>();
            if (!IsManagedDiskEnabled())
            {
                foreach (var dataDiskInner in this.StorageProfile().DataDisks)
                {
                    this.unmanagedDataDisks.Add(new UnmanagedDataDiskImpl(dataDiskInner, this));
                }
            }
        }

        private void InitializeExtensions()
        {
            this.virtualMachineExtensions = new VirtualMachineExtensionsImpl(this);
        }

        ///GENMHASH:7F6A7E961EA5A11F2B8013E54123A7D0:C1CDD6BC19A1D800E2865E3DC44941E1
        private void ClearCachedRelatedResources()
        {
            this.virtualMachineInstanceView = null;
        }

        ///GENMHASH:15C87FF18F2D92A7CA828FB69E15D8F4:FAB35812CDE5256B5EEDB90655E51B75
        private void ThrowIfManagedDiskEnabled(string message)
        {
            if (this.IsManagedDiskEnabled())
            {
                throw new NotSupportedException(message);
            }
        }

        ///GENMHASH:CD7DD8B4BD138F5F21FC2A082781B05E:DF7F973BA6DA44DB874A039E8656D907
        private void ThrowIfManagedDiskDisabled(string message)
        {
            if (!this.IsManagedDiskEnabled())
            {
                throw new NotSupportedException(message);
            }
        }

        ///GENMHASH:B521ECE36A8645ACCD4603A46DF73D20:6C43F204834714CB74740068BED95D98
        private bool IsInUpdateMode()
        {
            return !this.IsInCreateMode;
        }

        ///GENMHASH:31F1AF1FE9C5F41A363BCD2478A5DEE0:7DFBFA37EDE490851B9F2FD6F2A6E971
        internal AzureEnvironment Environment()
        {
            return this.Manager.RestClient.Environment;
        }

        ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbXB1dGUuaW1wbGVtZW50YXRpb24uVmlydHVhbE1hY2hpbmVJbXBsLk1hbmFnZWREYXRhRGlza0NvbGxlY3Rpb24=
        partial class ManagedDataDiskCollection
        {
            public IDictionary<string, Models.DataDisk> NewDisksToAttach;
            public IList<Models.DataDisk> ExistingDisksToAttach;
            public IList<Models.DataDisk> ImplicitDisksToAssociate;
            public IList<int> DiskLunsToRemove;
            public IList<Models.DataDisk> NewDisksFromImage;
            private VirtualMachineImpl vm;
            private CachingTypes? defaultCachingType;
            private StorageAccountTypes? defaultStorageAccountType;

            ///GENMHASH:CA7F491172B86E1C8B0D8508E4161245:D1D4C18FF276F4E074EBD85D149B5349
            internal void SetDataDisksDefaults()
            {
                VirtualMachineInner vmInner = this.vm.Inner;
                if (IsPending())
                {
                    if (vmInner.StorageProfile.DataDisks == null)
                    {
                        vmInner.StorageProfile.DataDisks = new List<DataDisk>();
                    }
                    var dataDisks = vmInner.StorageProfile.DataDisks;
                    var usedLuns = new HashSet<int>();
                    // Get all used luns
                    //
                    foreach (var dataDisk in dataDisks)
                    {
                        if (dataDisk.Lun != -1)
                        {
                            usedLuns.Add(dataDisk.Lun);
                        }
                    }
                    foreach (var dataDisk in this.NewDisksToAttach.Values)
                    {
                        if (dataDisk.Lun != -1)
                        {
                            usedLuns.Add(dataDisk.Lun);
                        }
                    }
                    foreach (var dataDisk in this.ExistingDisksToAttach)
                    {
                        if (dataDisk.Lun != -1)
                        {
                            usedLuns.Add(dataDisk.Lun);
                        }
                    }
                    foreach (var dataDisk in this.ImplicitDisksToAssociate)
                    {
                        if (dataDisk.Lun != -1)
                        {
                            usedLuns.Add(dataDisk.Lun);
                        }
                    }
                    foreach (var dataDisk in this.NewDisksFromImage)
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
                    SetAttachableNewDataDisks(nextLun);
                    SetAttachableExistingDataDisks(nextLun);
                    SetImplicitDataDisks(nextLun);
                    SetImageBasedDataDisks();
                    RemoveDataDisks();
                }
                if (vmInner.StorageProfile.DataDisks != null
                    && vmInner.StorageProfile.DataDisks.Count == 0)
                {
                    if (vm.IsInCreateMode)
                    {
                        // If there is no data disks at all, then setting it to null rather than [] is necessary.
                        // This is for take advantage of CRP's implicit creation of the data disks if the image has
                        // more than one data disk image(s).
                        //
                        vmInner.StorageProfile.DataDisks = null;
                    }
                }
                this.Clear();
            }

            ///GENMHASH:0829442EB7C4FFD252C60EC2CCEF6312:62D273A513407F6CCA06E06DD3D01589
            internal void SetAttachableNewDataDisks(Func<int> nextLun)
            {
                var dataDisks = vm.Inner.StorageProfile.DataDisks;
                foreach (var entry in this.NewDisksToAttach)
                {
                    var managedDisk = (IDisk)vm.CreatedResource(entry.Key);
                    DataDisk dataDisk = entry.Value;
                    dataDisk.CreateOption = DiskCreateOptionTypes.Attach;
                    if (dataDisk.Lun == -1)
                    {
                        dataDisk.Lun = nextLun();
                    }
                    dataDisk.ManagedDisk = new ManagedDiskParametersInner();
                    dataDisk.ManagedDisk.Id = managedDisk.Id;
                    if (dataDisk.Caching == null)
                    {
                        dataDisk.Caching = GetDefaultCachingType();
                    }
                    // Don't set default storage account type for the attachable managed disks, it is already
                    // defined in the managed disk and not allowed to change.
                    dataDisk.Name = null;
                    dataDisks.Add(dataDisk);
                }
            }

            ///GENMHASH:BDEEEC08EF65465346251F0F99D16258:03DF97ED7F5E19A604383CDB6F977583
            internal void Clear()
            {
                NewDisksToAttach.Clear();
                ExistingDisksToAttach.Clear();
                ImplicitDisksToAssociate.Clear();
                DiskLunsToRemove.Clear();
            }

            ///GENMHASH:0E80C978BE389A20F8B9BDDCBC308EBF:F8C8996370B742865324C10D4FF7ACF4
            internal void SetImplicitDataDisks(Func<int> nextLun)
            {
                var dataDisks = vm.Inner.StorageProfile.DataDisks;
                foreach (var dataDisk in this.ImplicitDisksToAssociate)
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
                        dataDisk.ManagedDisk = new ManagedDiskParametersInner();
                    }
                    if (dataDisk.ManagedDisk.StorageAccountType == null)
                    {
                        dataDisk.ManagedDisk.StorageAccountType = GetDefaultStorageAccountType();
                    }
                    dataDisk.Name = null;
                    dataDisks.Add(dataDisk);
                }
            }

            ///GENMHASH:EC209EBA0DF87A8C3CEA3D68742EA90D:5A0A84D8C0755F9E394C7D219CCD1CA5
            internal bool IsPending()
            {
                return NewDisksToAttach.Count > 0
                    || ExistingDisksToAttach.Count > 0
                    || ImplicitDisksToAssociate.Count > 0
                    || DiskLunsToRemove.Count > 0;
            }

            ///GENMHASH:1B972065A6AA6248776B41DE6F26CB8F:E48C33EDF09F7C0FF8274C18F487CABF
            internal void SetAttachableExistingDataDisks(Func<int> nextLun)
            {
                var dataDisks = vm.Inner.StorageProfile.DataDisks;
                foreach (var dataDisk in this.ExistingDisksToAttach)
                {
                    dataDisk.CreateOption = DiskCreateOptionTypes.Attach;
                    if (dataDisk.Lun == -1)
                    {
                        dataDisk.Lun = nextLun();
                    }
                    if (dataDisk.Caching == null)
                    {
                        dataDisk.Caching = GetDefaultCachingType();
                    }
                    // Don't set default storage account type for the attachable managed disks, it is already
                    // defined in the managed disk and not allowed to change.
                    dataDisk.Name = null;
                    dataDisks.Add(dataDisk);
                }
            }

            ///GENMHASH:E896A9714FD3ED579D3A806B2D670211:9EC21D752F2334263B0BF51F5BEF2FE2
            internal void SetDefaultStorageAccountType(StorageAccountTypes defaultStorageAccountType)
            {
                this.defaultStorageAccountType = defaultStorageAccountType;
            }

            ///GENMHASH:77E6B131587760C1313B68052BA1F959:3583CA6C895B07FD3877A9CFC685B07B
            internal CachingTypes GetDefaultCachingType()
            {
                if (defaultCachingType == null)
                {
                    return CachingTypes.ReadWrite;
                }
                return defaultCachingType.Value;
            }

            ///GENMHASH:B33308470B073DF5A31970C4C53291A4:4521033F354DF5B57E3BD39652BD8FF9
            internal void SetImageBasedDataDisks()
            {
                var dataDisks = vm.Inner.StorageProfile.DataDisks;
                foreach (var dataDisk in this.NewDisksFromImage)
                {
                    dataDisk.CreateOption = DiskCreateOptionTypes.FromImage;
                    // Don't set default caching type for the disk, either user has to specify it explicitly or let CRP pick
                    // it from the image
                    // Don't set default storage account type for the disk, either user has to specify it explicitly or let
                    // CRP pick it from the image
                    dataDisk.Name = null;
                    dataDisks.Add(dataDisk);
                }
            }

            ///GENMHASH:C474BAF5F2762CA941D8C01DC8F0A2CB:123893CCEC4625CDE4B7BCBFC68DCF5B
            internal void SetDefaultCachingType(CachingTypes cachingType)
            {
                this.defaultCachingType = cachingType;
            }

            ///GENMHASH:8F31500456F297BA5B51A162318FE60B:D8B2ED5EFB9DF0321EAAF10ACCE8A1C3
            internal void RemoveDataDisks()
            {
                var dataDisks = vm.Inner.StorageProfile.DataDisks;
                foreach (var lun in this.DiskLunsToRemove)
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
            internal StorageAccountTypes GetDefaultStorageAccountType()
            {
                if (defaultStorageAccountType == null)
                {
                    return StorageAccountTypes.StandardLRS;
                }
                return defaultStorageAccountType.Value;
            }

            ///GENMHASH:F6F68BF2F3D740A8BBA2AA1A30D0B189:428C729973EF037C0B0B7EF8BA639DD8
            internal ManagedDataDiskCollection(VirtualMachineImpl vm)
            {
                this.vm = vm;
                this.NewDisksToAttach = new Dictionary<string, DataDisk>();
                this.ExistingDisksToAttach = new List<DataDisk>();
                this.ImplicitDisksToAssociate = new List<DataDisk>();
                this.NewDisksFromImage = new List<DataDisk>();
                this.DiskLunsToRemove = new List<int>();
            }
        }
    }
}

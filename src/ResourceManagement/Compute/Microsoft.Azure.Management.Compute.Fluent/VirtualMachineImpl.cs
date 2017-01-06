// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent;
    using Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
    using VirtualMachine.Definition;
    using Microsoft.Azure.Management.Storage.Fluent;
    using VirtualMachine.Update;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.Storage.Fluent.Models;
    using System.Threading;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Network.Fluent.NetworkInterface.Definition;
    using Microsoft.Azure.Management.Resource.Fluent;
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Newtonsoft.Json;
    using System.Text.RegularExpressions;
    using System;

    /// <summary>
    /// The implementation for VirtualMachine and its create and update interfaces.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbXB1dGUuaW1wbGVtZW50YXRpb24uVmlydHVhbE1hY2hpbmVJbXBs
    internal partial class VirtualMachineImpl  :
        GroupableResource<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachine, Models.VirtualMachineInner, Microsoft.Azure.Management.Compute.Fluent.VirtualMachineImpl, IComputeManager, VirtualMachine.Definition.IWithGroup, VirtualMachine.Definition.IWithNetwork, VirtualMachine.Definition.IWithCreate, VirtualMachine.Update.IUpdate>,
        IVirtualMachine,
        VirtualMachine.Definition.IDefinition,
        VirtualMachine.Update.IUpdate
    {
        private readonly IVirtualMachinesOperations client;
        private readonly IStorageManager storageManager;
        private readonly INetworkManager networkManager;
        private readonly string vmName;
        private readonly IResourceNamer namer;
        private string creatableStorageAccountKey;
        private string creatableAvailabilitySetKey;
        private string creatablePrimaryNetworkInterfaceKey;
        private IList<string> creatableSecondaryNetworkInterfaceKeys;
        private IStorageAccount existingStorageAccountToAssociate;
        private IAvailabilitySet existingAvailabilitySetToAssociate;
        private INetworkInterface existingPrimaryNetworkInterfaceToAssociate;
        private IList<Microsoft.Azure.Management.Network.Fluent.INetworkInterface> existingSecondaryNetworkInterfacesToAssociate;
        private VirtualMachineInstanceView virtualMachineInstanceView;
        private bool isMarketplaceLinuxImage;
        private IList<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineDataDisk> dataDisks;
        private Network.Fluent.NetworkInterface.Definition.IWithPrimaryPrivateIp nicDefinitionWithPrivateIp;
        private Network.Fluent.NetworkInterface.Definition.IWithPrimaryNetworkSubnet nicDefinitionWithSubnet;
        private Network.Fluent.NetworkInterface.Definition.IWithCreate nicDefinitionWithCreate;
        private VirtualMachineExtensionsImpl virtualMachineExtensions;

        internal VirtualMachineImpl(string name,
            VirtualMachineInner innerModel,
            IVirtualMachinesOperations client,
            IVirtualMachineExtensionsOperations extensionsClient,
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
            this.namer = SharedSettings.CreateResourceNamer(this.vmName);
            this.creatableSecondaryNetworkInterfaceKeys = new List<string>();
            this.existingSecondaryNetworkInterfacesToAssociate = new List<INetworkInterface>();
            this.virtualMachineExtensions = new VirtualMachineExtensionsImpl(extensionsClient, this);
            InitializeDataDisks();
        }

        ///GENMHASH:4002186478A1CB0B59732EBFB18DEB3A:6F7E72CD01C24BD732735CFACEA35424
        public override IVirtualMachine Refresh()
        {
            var response = client.Get(ResourceGroupName, Name);

            SetInner(response);
            ClearCachedRelatedResources();
            InitializeDataDisks();
            virtualMachineExtensions.Refresh();
            return this;
        }

        ///GENMHASH:667E734583F577A898C6389A3D9F4C09:B1A3725E3B60B26D7F37CA7ABFE371B0
        public void Deallocate()
        {
            this.client.Deallocate(this.ResourceGroupName, this.Name);
        }

        ///GENMHASH:0745971EF3F2CE7276C7E535722C5E6C:F7A7B3A36B61441CF0850BDE432A2805
        public void Generalize()
        {
            this.client.Generalize(this.ResourceGroupName, this.Name);
        }

        ///GENMHASH:8761D0D225B7C49A7A5025186E94B263:21AAF0008CE6CF3F9846F2DFE1CBEBCB
        public void PowerOff()
        {
            this.client.PowerOff(this.ResourceGroupName, this.Name);
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

        ///GENMHASH:D9EB75AF88B1A07EDC0965B26A7F7C04:E30F1E083D68AA7A68C7128405BA3741
        public void Redeploy()
        {
            this.client.Redeploy(this.ResourceGroupName, this.Name);
        }

        ///GENMHASH:842FBE4DCB8BFE1B50632DBBE157AEA8:B5262187B60CE486998F800E9A96B659
        public PagedList<Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineSize> AvailableSizes() 
        {
            return PagedListConverter.Convert<VirtualMachineSize, IVirtualMachineSize>(this.client.ListAvailableSizes(this.ResourceGroupName,
                this.Name), innerSize =>
                {
                    return new VirtualMachineSizeImpl(innerSize);
                });
        }

        ///GENMHASH:1F383B6B989059B78D6ECB949E789CD4:5016B72EA4E673B81B58BB9DC0B517E0
        public string Capture(string containerName, string vhdPreifx, bool overwriteVhd)
        {
            VirtualMachineCaptureParametersInner parameters = new VirtualMachineCaptureParametersInner();
            parameters.DestinationContainerName = containerName;
            parameters.OverwriteVhds = overwriteVhd;
            parameters.VhdPrefix = vhdPreifx;
            VirtualMachineCaptureResultInner captureResult = this.client.Capture(this.ResourceGroupName, this.Name, parameters);
            return JsonConvert.SerializeObject(captureResult.Output);
        }

        ///GENMHASH:F5949CB4AFA8DD0B8DED0F369B12A8F6:43A87ABD605FCDAA3CA444A643F83DB4
        public VirtualMachineInstanceView RefreshInstanceView()
        {
            this.virtualMachineInstanceView = this.client.Get(this.ResourceGroupName,
                this.Name,
                InstanceViewTypes.InstanceView).InstanceView;
            return this.virtualMachineInstanceView;
        }

        #region Setters

        ///GENMHASH:3FAB18211D6DAAAEF5CA426426D16F0C:AD7170076BCB5437E69B77AC63B3373E
        public VirtualMachineImpl WithNewPrimaryNetwork(ICreatable<INetwork> creatable)
        {
            this.nicDefinitionWithPrivateIp = this.PreparePrimaryNetworkInterface(this.namer.RandomName("nic", 20))
                .WithNewPrimaryNetwork(creatable);
            return this;
        }

        ///GENMHASH:C8A4DDE66256242DF61087375BF710B0:BE10050EE1789706DD7774B3C47BE916
        public VirtualMachineImpl WithNewPrimaryNetwork(string addressSpace)
        {
            this.nicDefinitionWithPrivateIp = this.PreparePrimaryNetworkInterface(this.namer.RandomName("nic", 20))
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
            this.nicDefinitionWithPrivateIp = this.nicDefinitionWithSubnet
                .WithSubnet(name);
            return this;
        }

        ///GENMHASH:022FCEBED3C6606D834C45EAD65C0D6F:29E2281B1650F8D65A367942B42B75EF
        public VirtualMachineImpl WithPrimaryPrivateIpAddressDynamic()
        {
            this.nicDefinitionWithCreate = this.nicDefinitionWithPrivateIp
                .WithPrimaryPrivateIpAddressDynamic();
            return this;
        }

        ///GENMHASH:655D6F837286729FEB47BD78B3EB9A08:D2502E1AE46296B5C8F75C71F9B84C27
        public VirtualMachineImpl WithPrimaryPrivateIpAddressStatic(string staticPrivateIpAddress)
        {
            this.nicDefinitionWithCreate = this.nicDefinitionWithPrivateIp
                .WithPrimaryPrivateIpAddressStatic(staticPrivateIpAddress);
            return this;
        }

        ///GENMHASH:12E96FEFBC60AB582A0B69EBEEFD1E59:C1EAF0B5EE0258D48F9956AEFBA1EA2D
        public VirtualMachineImpl WithNewPrimaryPublicIpAddress(ICreatable<IPublicIpAddress> creatable)
        {
            var nicCreatable = this.nicDefinitionWithCreate
                .WithNewPrimaryPublicIpAddress(creatable);
            this.creatablePrimaryNetworkInterfaceKey = nicCreatable.Key;
            this.AddCreatableDependency(nicCreatable as IResourceCreator<IHasId>);
            return this;
        }

        ///GENMHASH:BA50EF0AC88D5405DFE18FCE26A595B2:027C20A1A590AAED2CC3F40647663D8B
        public VirtualMachineImpl WithNewPrimaryPublicIpAddress(string leafDnsLabel)
        {
            var nicCreatable = this.nicDefinitionWithCreate
                .WithNewPrimaryPublicIpAddress(leafDnsLabel);
            this.creatablePrimaryNetworkInterfaceKey = nicCreatable.Key;
            this.AddCreatableDependency(nicCreatable as IResourceCreator<IHasId>);
            return this;
        }

        ///GENMHASH:2B7C2F1E86A359473717299AD4D4DCBA:2EE2D29B7C228132508D27F040A79175
        public VirtualMachineImpl WithExistingPrimaryPublicIpAddress(IPublicIpAddress publicIpAddress)
        {
            var nicCreatable = this.nicDefinitionWithCreate
                .WithExistingPrimaryPublicIpAddress(publicIpAddress);
            this.creatablePrimaryNetworkInterfaceKey = nicCreatable.Key;
            this.AddCreatableDependency(nicCreatable as IResourceCreator<IHasId>);
            return this;
        }

        ///GENMHASH:D0AB91F51DBDFA04880ED371AD9E48EE:8727C9A4820EB72700E55883936D2638
        public VirtualMachineImpl WithoutPrimaryPublicIpAddress()
        {
            var nicCreatable = this.nicDefinitionWithCreate;
            this.creatablePrimaryNetworkInterfaceKey = nicCreatable.Key;
            this.AddCreatableDependency(nicCreatable as IResourceCreator<IHasId>);
            return this;
        }

        ///GENMHASH:6C6E9480071A571B23369210C67E4329:BAD887D9D5A633B4D6DE3058819C017C
        public VirtualMachineImpl WithNewPrimaryNetworkInterface(ICreatable<INetworkInterface> creatable)
        {
            this.creatablePrimaryNetworkInterfaceKey = creatable.Key;
            this.AddCreatableDependency(creatable as IResourceCreator<IHasId>);
            return this;
        }

        ///GENMHASH:ADDFF59E01604BE661F6CB8C83CD4B0F:2125FE20491BB581219A9D8E245DECB9
        public VirtualMachineImpl WithNewPrimaryNetworkInterface(string name, string publicDnsNameLabel)
        {
            var definitionCreatable = PrepareNetworkInterface(name)
                .WithNewPrimaryPublicIpAddress(publicDnsNameLabel);
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
            VirtualHardDisk userImageVhd = new VirtualHardDisk()
            {
                Uri = imageUrl
            };
            this.Inner.StorageProfile.OsDisk.CreateOption = DiskCreateOptionTypes.FromImage;
            this.Inner.StorageProfile.OsDisk.Image = userImageVhd;
            // For platform image osType will be null, azure will pick it from the image metadata.
            this.Inner.StorageProfile.OsDisk.OsType = OperatingSystemTypes.Windows;
            this.Inner.OsProfile.WindowsConfiguration = new WindowsConfiguration()
            {
                // sets defaults for "Stored(User)Image" or "VM(Platform)Image"
                ProvisionVMAgent = true,
                EnableAutomaticUpdates = true
            };
            return this;
        }

        ///GENMHASH:976BC0FCB9812014FA27474FCF6A694F:A85188B583788ED2462CA3FB7BD1E5B9
        public VirtualMachineImpl WithStoredLinuxImage(string imageUrl)
        {
            VirtualHardDisk userImageVhd = new VirtualHardDisk()
            {
                Uri = imageUrl
            };
            this.Inner.StorageProfile.OsDisk.CreateOption = DiskCreateOptionTypes.FromImage;
            this.Inner.StorageProfile.OsDisk.Image = userImageVhd;
            // For platform image osType will be null, azure will pick it from the image metadata.
            this.Inner.StorageProfile.OsDisk.OsType = OperatingSystemTypes.Linux;
            this.Inner.OsProfile.LinuxConfiguration = new LinuxConfiguration();
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

        ///GENMHASH:4A7665D6C5D507E115A9A8E551801DB6:79BD1EC9C57E036BC474695931D3A393
        public VirtualMachineImpl WithSpecificWindowsImageVersion(ImageReference imageReference)
        {
            this.Inner.StorageProfile.OsDisk.CreateOption = DiskCreateOptionTypes.FromImage;
            this.Inner.StorageProfile.ImageReference = imageReference;
            this.Inner.OsProfile.WindowsConfiguration = new WindowsConfiguration()
            {
                // sets defaults for "Stored(User)Image" or "VM(Platform)Image"
                ProvisionVMAgent = true,
                EnableAutomaticUpdates = true
            };
            return this;
        }

        ///GENMHASH:B2876749E60D892750D75C97943BBB13:19F6D3CB49C5070B017EF845A7D475B7
        public VirtualMachineImpl WithSpecificLinuxImageVersion(ImageReference imageReference)
        {
            this.Inner.StorageProfile.OsDisk.CreateOption = DiskCreateOptionTypes.FromImage;
            this.Inner.StorageProfile.ImageReference = imageReference;
            this.Inner.OsProfile.LinuxConfiguration = new LinuxConfiguration();
            this.isMarketplaceLinuxImage = true;
            return this;
        }

        ///GENMHASH:3874257232804C74BD7501DE2BE2F0E9:742DE46D93113DBA276B0A311D52D664
        public VirtualMachineImpl WithLatestWindowsImage(string publisher, string offer, string sku)
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

        ///GENMHASH:6D51A334B57DF882E890FEBA9887BE77:3A21A7EF50A9FC7A93D7C8AEFA8F3130
        public VirtualMachineImpl WithLatestLinuxImage(string publisher, string offer, string sku)
        {
            ImageReference imageReference = new ImageReference()
            {
                Publisher = publisher,
                Offer = offer,
                Sku = sku,
                Version = "latest"
            };
            return WithSpecificLinuxImageVersion(imageReference);
        }

        ///GENMHASH:B295590F27A70564841BB66C74BFA5A5:94DD4E3CAAEC40963C3D578A0FA53770
        public VirtualMachineImpl WithOsDisk(string osDiskUrl, OperatingSystemTypes osType)
        {
            VirtualHardDisk osDisk = new VirtualHardDisk()
            {
                Uri = osDiskUrl
            };
            this.Inner.StorageProfile.OsDisk.CreateOption = DiskCreateOptionTypes.Attach;
            this.Inner.StorageProfile.OsDisk.Vhd = osDisk;
            this.Inner.StorageProfile.OsDisk.OsType = osType;
            return this;
        }

        ///GENMHASH:D5F141800B409906045662B0DD536DE4:E70AA61215804A9BAB05750F6C16BA9D
        public VirtualMachineImpl WithRootUsername(string rootUsername)
        {
            this.Inner.OsProfile.AdminUsername = rootUsername;
            return this;
        }

        ///GENMHASH:0E3F9BC2C5C0DB936DBA634A972BC916:8D59AD6440CA44B929F3A1907924F5BC
        public VirtualMachineImpl WithAdminUsername(string adminUsername)
        {
            this.Inner.OsProfile.AdminUsername = adminUsername;
            return this;
        }

        ///GENMHASH:9BBA27913235B4504FD9F07549E645CC:7C9396228419D56BC31B8BC248BB451A
        public VirtualMachineImpl WithSsh(string publicKeyData)
        {
            OSProfile osProfile = this.Inner.OsProfile;
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
        public VirtualMachineImpl WithoutVmAgent()
        {
            this.Inner.OsProfile.WindowsConfiguration.ProvisionVMAgent = false;
            return this;
        }

        ///GENMHASH:98B10909018928720DBCCEBE53E08820:C53BBE49BDF4B37F836CAF494E3A07C9
        public VirtualMachineImpl WithoutAutoUpdate()
        {
            this.Inner.OsProfile.WindowsConfiguration.EnableAutomaticUpdates = false;
            return this;
        }

        ///GENMHASH:1BBF95374A03EFFD0583730762AB8753:A0586AA1F362669D4458B9D2C4605A9F
        public VirtualMachineImpl WithTimeZone(string timeZone)
        {
            this.Inner.OsProfile.WindowsConfiguration.TimeZone = timeZone;
            return this;
        }

        ///GENMHASH:F7E8AD723108078BE0FE19CD860DD3D3:7AB774480B8E9543A8CAEE7340C4B7B8
        public VirtualMachineImpl WithWinRm(WinRMListener listener)
        {
            if (this.Inner.OsProfile.WindowsConfiguration.WinRM == null)
            {
                this.Inner.OsProfile.WindowsConfiguration.WinRM = new WinRMConfiguration()
                {
                    Listeners = new List<WinRMListener>()
                };
            }

            this.Inner.OsProfile
                .WindowsConfiguration
                .WinRM
                .Listeners
                .Add(listener);
            return this;
        }

        ///GENMHASH:F2FFAF5448D7DFAFBE00130C62E87053:31B639B9D779BF92E26C4DAAF832C9E7
        public VirtualMachineImpl WithRootPassword(string password)
        {
            this.Inner.OsProfile.AdminPassword = password;
            return this;
        }

        ///GENMHASH:5810786355B161A5CD254C9E3BE76524:31B639B9D779BF92E26C4DAAF832C9E7
        public VirtualMachineImpl WithAdminPassword(string password)
        {
            this.Inner.OsProfile.AdminPassword = password;
            return this;
        }

        ///GENMHASH:E8024524BA316DC9DEEB983B272ABF81:A4BB71EB8065E0206CCD541A9DCF4958
        public VirtualMachineImpl WithCustomData(string base64EncodedCustomData)
        {
            this.Inner.OsProfile.CustomData = base64EncodedCustomData;
            return this;
        }

        ///GENMHASH:51EBA8D3FB4D3F3417FFB3844F1E5D31:D277FC6E9690E3315F7B673013620ECF
        public VirtualMachineImpl WithComputerName(string computerName)
        {
            this.Inner.OsProfile.ComputerName = computerName;
            return this;
        }

        ///GENMHASH:3EDA6D9B767CDD07D76DD15C0E0B7128:7E4761B66D0FB9A09715DA978222FC55
        public VirtualMachineImpl WithSize(string sizeName)
        {
            this.Inner.HardwareProfile.VmSize = sizeName;
            return this;
        }

        ///GENMHASH:619ABAAD3F8A01F52AFF9E0735BDAE77:EC0CEDDCD615AA4EFB41DF60CEE2588B
        public VirtualMachineImpl WithSize(VirtualMachineSizeTypes size)
        {
            this.Inner.HardwareProfile.VmSize = size.ToString();
            return this;
        }

        ///GENMHASH:5C1E5D4B34E988B57615D99543B65A28:89DEE527C9AED179FFFF9E5303751431
        public VirtualMachineImpl WithOsDiskCaching(CachingTypes cachingType)
        {
            this.Inner.StorageProfile.OsDisk.Caching = cachingType;
            return this;
        }

        ///GENMHASH:6AD476CF269D3B37CBD6D308C3557D31:A518E6F6C484957225ED2708C83AA8BA
        public VirtualMachineImpl WithOsDiskVhdLocation(string containerName, string vhdName)
        {
            var storageProfile = this.Inner.StorageProfile;
            var osDisk = storageProfile.OsDisk;
            if (this.IsOSDiskFromImage(osDisk))
            {
                var osVhd = new VirtualHardDisk();
                if (this.IsOSDiskFromPlatformImage(storageProfile))
                {
                    // OS Disk from 'Platform image' requires explicit storage account to be specified.
                    osVhd.Uri = this.TemporaryBlobUrl(containerName, vhdName);
                }
                else if (this.IsOSDiskFromCustomImage(osDisk))
                {
                    // 'Captured image' and 'Bring your own feature image' has a restriction that the
                    // OS disk based on these images should reside in the same storage account as the
                    // image.
                    Uri sourceCustomImageUrl = new Uri(osDisk.Image.Uri);
                    Uri destinationVhdUrl = new Uri(new Uri($"{sourceCustomImageUrl.Scheme}://{sourceCustomImageUrl.Host}"), 
                        $"{containerName}/{vhdName}");
                    osVhd.Uri = destinationVhdUrl.ToString();
                }
                this.Inner.StorageProfile.OsDisk.Vhd = osVhd;
            }
            return this;
        }

        ///GENMHASH:75485319699D66A3C75429B0EB7E0665:AE8D3788AAA49304D58C3DFB3E942C15
        public VirtualMachineImpl WithOsDiskEncryptionSettings(DiskEncryptionSettings settings)
        {
            this.Inner.StorageProfile.OsDisk.EncryptionSettings = settings;
            return this;
        }

        ///GENMHASH:D94BB1D4150B88A53D339C0C39080239:4FFC5F3F684247159297E3463471B6EA
        public VirtualMachineImpl WithOsDiskSizeInGb(int size)
        {
            this.Inner.StorageProfile.OsDisk.DiskSizeGB = size;
            return this;
        }

        ///GENMHASH:C5EB453493B1100152604C49B4350246:28D2B19DAE6A4D168B24165D74135721
        public VirtualMachineImpl WithOsDiskName(string name)
        {
            this.Inner.StorageProfile.OsDisk.Name = name;
            return this;
        }

        ///GENMHASH:7D2AE1FD40DE7AA5C025215CCF888244:8119D68DCFB9E48F50E14B259CD54572
        public DataDiskImpl DefineNewDataDisk(string name)
        {
            return DataDiskImpl.PrepareDataDisk(name, DiskCreateOptionTypes.Empty, this);
        }

        ///GENMHASH:47118A0FBA688F04890006E53850FB04:24FFE683F1FA191C954B0D6960F70CD1
        public DataDiskImpl DefineExistingDataDisk(string name)
        {
            return DataDiskImpl.PrepareDataDisk(name, DiskCreateOptionTypes.Attach, this);
        }

        ///GENMHASH:5B486E3124D02F072D2CC6D621C20A6A:1332CD0D7E03C6DD8D3AB312EDA9B829
        public VirtualMachineImpl WithNewDataDisk(int? sizeInGB)
        {
            return WithDataDisk(DataDiskImpl.CreateNewDataDisk(sizeInGB.HasValue ? sizeInGB.Value : 0, this));
        }

        ///GENMHASH:EFBF3F38387CEC365187D7057A42EA95:03436F973A14B431E7F2897F2CD39997
        public VirtualMachineImpl WithExistingDataDisk(string storageAccountName, string containerName, string vhdName)
        {
            return WithDataDisk(DataDiskImpl.CreateFromExistingDisk(storageAccountName, containerName, vhdName, this)); ;
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
        public VirtualMachineImpl WithNewAvailabilitySet(ICreatable<IAvailabilitySet> creatable)
        {
            // This method's effect is NOT additive.
            if (this.creatableAvailabilitySetKey == null)
            {
                this.creatableAvailabilitySetKey = creatable.Key;
                this.AddCreatableDependency(creatable as IResourceCreator<IHasId>);
            }
            return this;
        }

        ///GENMHASH:0BFC73C37B3D941247E33A0B1AC6113E:AFB68D0A012B99563ED93968E32F9185
        public VirtualMachineImpl WithNewAvailabilitySet(string name)
        {
            AvailabilitySet.Definition.IWithGroup definitionWithGroup  = base.Manager.AvailabilitySets.Define(name)
                .WithRegion(this.RegionName);
            AvailabilitySet.Definition.IWithCreate definitionAfterGroup;
            if (this.newGroup != null)
            {
                definitionAfterGroup = definitionWithGroup.WithNewResourceGroup(this.newGroup);
            }
            else
            {
                definitionAfterGroup = definitionWithGroup.WithExistingResourceGroup(this.ResourceGroupName);
            }
            return this.WithNewAvailabilitySet(definitionAfterGroup);
        }

        ///GENMHASH:F2733A66EF0AF45C62E9C44FD29CC576:FC9409B8E6841C279554A2938B4E9F12
        public VirtualMachineImpl WithExistingAvailabilitySet(IAvailabilitySet availabilitySet)
        {
            this.existingAvailabilitySetToAssociate = availabilitySet;
            return this;
        }

        ///GENMHASH:720FC1AD6CE12835DF562FA21CBA22C1:8E210E27AC5BBEFD085A05D8458DC632
        public VirtualMachineImpl WithNewSecondaryNetworkInterface(ICreatable<INetworkInterface> creatable)
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

        ///GENMHASH:D7A14F2EFF1E4165DA55EF07B6C19534:85E4528E76EBEB2F2002B48ABD89A8E5
        public VirtualMachineExtensionImpl DefineNewExtension(string name)
        {
            return this.virtualMachineExtensions.Define(name);
        }

        ///GENMHASH:1407F91229E79AD8F5E77DA1F8111134:A705DBA44C7F93E8FD30D4D46B5C47F4
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

        ///GENMHASH:9C4A541B9A2E22540116BFA125189F57:994143012DF019B8AF6069397616F64D
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

        ///GENMHASH:DF7522D26901A7CA01A508515FE0BB4E:8B3C60E4C29138E35737BCE44C0CB258
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

        ///GENMHASH:1B6EFD4FB09DB19A9365B92299382732:6E8FA7A8D0E6C28DD34AA5ED876E9C3F
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
                        && name.Equals(ResourceUtils.NameFromResourceId(nicReference.Id), StringComparison.OrdinalIgnoreCase))
                    {
                        this.Inner.NetworkProfile.NetworkInterfaces.RemoveAt(idx);
                        break;
                    }
                }
            }
            return this;
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

        #endregion

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
            return new VirtualMachineSizeTypes(Inner.HardwareProfile.VmSize);
            
        }

        ///GENMHASH:1BAF4F1B601F89251ABCFE6CC4867026:AACA43FF0E9DA39D6993719C23FB0486
        public OperatingSystemTypes OsType()
        {
            return Inner.StorageProfile.OsDisk.OsType.Value;
        }
        ///GENMHASH:D97CA4262C0C853895BFF5AD2FE910FE:75A04C61F19354FB4BFDE8310A43BE22
        public string OsDiskVhdUri()
        {
            return Inner.StorageProfile.OsDisk.Vhd.Uri;
        }

        ///GENMHASH:123FF0223083F789E78E45771A759A9C:1604791894B0C3EF16EEDF56536B8B70
        public CachingTypes OsDiskCachingType()
        {
                return Inner.StorageProfile.OsDisk.Caching.Value;
        }

        ///GENMHASH:034DA366E39060AAD75E1DA786657383:65EDBB2144C128EB0C43030D512C5EED
        public int OsDiskSize()
        {
            if (Inner.StorageProfile.OsDisk.DiskSizeGB == null)
            {
                // Server returns OS disk size as 0 for auto-created disks for which
                // size was not explicitly set by the user.
                return 0;
            }

            return Inner.StorageProfile.OsDisk.DiskSizeGB.Value;
        }

        ///GENMHASH:353C54F9ADAEAEDD54EE4F0AACF9DF9B:ED32C59FD33B2B1F38D38B903D623AF6
        public IList<IVirtualMachineDataDisk> DataDisks()
        {
            return this.dataDisks;
        }

        ///GENMHASH:2A7ACF9E7DA59ECB74A3F0607B98CEA8:46FD353C4642C823383ED54BCE79C710
        public INetworkInterface GetPrimaryNetworkInterface()
        {
            return this.networkManager.NetworkInterfaces.GetById(this.PrimaryNetworkInterfaceId());
        }

        ///GENMHASH:D3ADA5DC7B5CC9C5BD29AC1110C61014:EC93403D80CE55A8079C6FDA3D5DE566
        public IPublicIpAddress GetPrimaryPublicIpAddress()
        {
            return this.GetPrimaryNetworkInterface().PrimaryIpConfiguration.GetPublicIpAddress();
        }

        ///GENMHASH:5977CC2F7355BB73CD32528805FEDA4D:8A6DCD2F68FE8ED005BB9933A0E74217
        public string GetPrimaryPublicIpAddressId()
        {
            return this.GetPrimaryNetworkInterface().PrimaryIpConfiguration.PublicIpAddressId;
        }

        ///GENMHASH:606A3D349546DF27E3A091C321476658:DC63C44DC2A2862C6AC14F711DCB1EFA
        public List<string> NetworkInterfaceIds()
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

        ///GENMHASH:EC363135C0A3366C1FA98226F4AE5D05:B79EEB6C251B19AEB675FFF7A365C818
        public IDictionary<string, IVirtualMachineExtension> Extensions()
        {
            return this.virtualMachineExtensions.AsMap();
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
        public OSProfile OsProfile()
        {
            return Inner.OsProfile;
        }

        ///GENMHASH:6DC69B57C0EF18B742D6A9F6EF064DB6:918D5C0812D3C8CF539A3DD9FC338819
        public DiagnosticsProfile DiagnosticsProfile()
        {
            return Inner.DiagnosticsProfile;
        }

        ///GENMHASH:F91DF44F14D53833479DE592AB2B2890:A44F980B37B6696BA13F0A8DB633DCCA
        public string VmId()
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
            return Microsoft.Azure.Management.Compute.Fluent.PowerState.FromInstanceView(InstanceView());
        }

        ///GENMHASH:0202A00A1DCF248D2647DBDBEF2CA865:696F8827B1A96E7F4EC00ACFB6F1A5D3
        public override async Task<IVirtualMachine> CreateResourceAsync (CancellationToken cancellationToken = default(CancellationToken))
        {
            if (IsInCreateMode)
            {
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
            await this.virtualMachineExtensions.CommitAndGetAllAsync(cancellationToken);
            return this;
        }

        ///GENMHASH:F0BA5F3F27F923CBF88531E8051E2766:3A9860E56B386DEBF12E9494C009C2A3
        internal VirtualMachineImpl WithExtension (VirtualMachineExtensionImpl extension)
        {
            this.virtualMachineExtensions.AddExtension(extension);
            return this;
        }

        ///GENMHASH:282FF4452DF4CF09F73806B54DF00772:E90B7357DA7CC668442CE4AD7063D31F
        internal VirtualMachineImpl WithDataDisk (DataDiskImpl dataDisk)
        {
            this.Inner
                .StorageProfile
                .DataDisks
                .Add(dataDisk.Inner);
            this.dataDisks.Add(dataDisk);
            return this;
        }

        ///GENMHASH:8200C3AA2986ADE3279CEB6CF0EA96D9:CC52783B24A47119F0F16A03CED2F5D7
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
                    WithOsDiskVhdLocation("vhds", $"{this.vmName}-os-disk-{Guid.NewGuid().ToString()}.vhd");
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

                if (this.Inner.OsProfile.ComputerName == null)
                {
                    // VM name cannot contain only numeric values and cannot exceed 15 chars
                    if ((new Regex(@"^\d+$")).IsMatch(vmName))
                    {
                        this.Inner.OsProfile.ComputerName = SharedSettings.RandomResourceName("vm", 15);
                    }
                    else if (vmName.Length <= 15)
                    {
                        this.Inner.OsProfile.ComputerName = vmName;
                    }
                    else
                    {
                        this.Inner.OsProfile.ComputerName = SharedSettings.RandomResourceName("vm", 15);
                    }
                }
            }
            else
            {
                // Compute has a new restriction that OS Profile property need to set null
                // when an VM's OS disk is ATTACH-ed to a Specialized VHD
                this.Inner.OsProfile = null;
            }

            if (osDisk.Caching == null)
            {
                WithOsDiskCaching(CachingTypes.ReadWrite);
            }

            if (osDisk.Name == null)
            {
                this.WithOsDiskName(this.vmName + "-os-disk");
            }
        }

        ///GENMHASH:BAA70B10A8929783F1FC5D60B4D80538:1862E80AB426A8462EF7CCA1F526D1E1
        private void SetHardwareProfileDefaults()
        {
            if (!IsInCreateMode)
            {
                return;
            }

            HardwareProfile hardwareProfile = this.Inner.HardwareProfile;
            if (hardwareProfile.VmSize == null)
            {
                hardwareProfile.VmSize = VirtualMachineSizeTypes.BasicA0.ToString();
            }
        }

        ///GENMHASH:E9830BD8841F5F66740928BA7AA21EB0:73D58ABB761C4FD3FB4A9FB8F09D4AD9
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
            else if (this.OsDiskRequiresImplicitStorageAccountCreation() ||
                this.DataDisksRequiresImplicitStorageAccountCreation())
            {
                storageAccount = await this.storageManager.StorageAccounts
                .Define(this.namer.RandomName("stg", 24))
                .WithRegion(this.RegionName)
                .WithExistingResourceGroup(this.ResourceGroupName)
                .CreateAsync();
            }

            if (IsInCreateMode)
            {
                if (this.IsOSDiskFromPlatformImage(this.Inner.StorageProfile))
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
                if (this.Inner.AvailabilitySet == null)
                {
                    this.Inner.AvailabilitySet = new SubResource();
                }

                this.Inner.AvailabilitySet.Id = availabilitySet.Id;
            }
        }

        ///GENMHASH:0F7707B8B59F80529877E77CA52B31EB:08513201BFA3D2D10C66596B1206149C
        private bool OsDiskRequiresImplicitStorageAccountCreation()
        {
            if (this.creatableStorageAccountKey != null
                    || this.existingStorageAccountToAssociate != null
                    || !this.IsInCreateMode)
            {
                return false;
            }
            return this.IsOSDiskFromPlatformImage(this.Inner.StorageProfile);
        }

        ///GENMHASH:E54BC4A600C7D7F1F1FE5ECD633F9B03:53D1A8A0AD2043B84D4E532A83CF8FA2
        private bool DataDisksRequiresImplicitStorageAccountCreation()
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
                if (dataDisk.CreationMethod == DiskCreateOptionTypes.Empty)
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
        /// Checks whether the OS disk is directly attached to a VHD.
        /// </summary>
        /// <param name="osDisk">The osDisk value in the storage profile.</param>
        /// <return>True if the OS disk is attached to a VHD, false otherwise.</return>
        ///GENMHASH:0ED4CA225B0A1048DF1630BBB905CABF:E131DE14687B0FC1C69A169BDE13FE68
        private bool IsOSDiskAttached(OSDisk osDisk)
        {
            return osDisk.CreateOption == DiskCreateOptionTypes.Attach;
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
        ///GENMHASH:78EB0F392606FADDDAFE3E594B6F4E7F:EC985B78EECA34D134228416A96997F8
        private bool IsOSDiskFromPlatformImage(StorageProfile storageProfile)
        {
            return IsOSDiskFromImage(storageProfile.OsDisk) && storageProfile.ImageReference != null;
        }

        /// <summary>
        /// Checks whether the OS disk is based on an custom image ('captured' or 'bring your own feature').
        /// </summary>
        /// <param name="osDisk">The osDisk value in the storage profile.</param>
        /// <return>True if the OS disk is configured to use custom image ('captured' or 'bring your own feature').</return>
        ///GENMHASH:6ECB87AED370EEF376897E9E3C4BE1C9:9ED794F35129AD9597F3C0434390D657
        private bool IsOSDiskFromCustomImage(OSDisk osDisk)
        {
            return IsOSDiskFromImage(osDisk) && osDisk.Image != null && osDisk.Image.Uri != null;
        }

        ///GENMHASH:8143A53E487619B77CA38F74DEA81560:B603F79C83B2E3EB33CD223B542FC5BB
        private string TemporaryBlobUrl(string containerName, string blobName)
        {
            return "{storage-base-url}" + containerName + "/" + blobName;
        }

        ///GENMHASH:E972A9EA7BC4745B11D042E506C9EC88:67C9F7C47AB1078BBDB948EE068D0EDC
        private Network.Fluent.NetworkInterface.Definition.IWithPrimaryPublicIpAddress PrepareNetworkInterface(string name)
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
                .WithPrimaryPrivateIpAddressDynamic();
        }

        ///GENMHASH:5D074C2BCA5877F1D6C918952020AA65:3A678A2280962ABD06FEAAD671D67F7D
        private void InitializeDataDisks()
        {
            if (this.Inner.StorageProfile.DataDisks == null)
            {
                this.Inner
                    .StorageProfile
                    .DataDisks = new List<DataDisk>();
            }

            this.dataDisks = new List<IVirtualMachineDataDisk>();
            foreach (DataDisk dataDiskInner in this.StorageProfile().DataDisks)
            {
                this.dataDisks.Add(new DataDiskImpl(dataDiskInner, this));
            }
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

        ///GENMHASH:7F6A7E961EA5A11F2B8013E54123A7D0:C1CDD6BC19A1D800E2865E3DC44941E1
        private void ClearCachedRelatedResources()
        {
            this.virtualMachineInstanceView = null;
        }
    }
}

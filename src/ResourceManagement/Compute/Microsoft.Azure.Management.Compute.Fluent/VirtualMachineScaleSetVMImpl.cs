// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Models;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using System.Threading;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
    using System.Linq;

    /// <summary>
    /// Implementation of VirtualMachineScaleSetVM.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbXB1dGUuaW1wbGVtZW50YXRpb24uVmlydHVhbE1hY2hpbmVTY2FsZVNldFZNSW1wbA==
    internal partial class VirtualMachineScaleSetVMImpl :
        ChildResource<VirtualMachineScaleSetVMInner, Microsoft.Azure.Management.Compute.Fluent.VirtualMachineScaleSetImpl, Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSet>,
        IVirtualMachineScaleSetVM
    {
        private VirtualMachineInstanceView virtualMachineInstanceView;
        private IVirtualMachineScaleSetVMsOperations client;
        private ComputeManager computeManager;
        ///GENMHASH:7A41C20BB6F19CCDAC03072604BF281B:10AB7511A9B5C284B8E2E1F35126DD60
        public string WindowsTimeZone()
        {
            if (this.Inner.OsProfile.WindowsConfiguration != null) {
                return this.Inner.OsProfile.WindowsConfiguration.TimeZone;
            }
            return null;
        }

        ///GENMHASH:8006E2F4F5C772E64BE499575C23780D:2ED90BBE66E656BF8B3BA6587E7CF62E
        public bool IsLatestScaleSetUpdateApplied()
        {
            return this.Inner.LatestModelApplied.Value;
        }

        ///GENMHASH:E7427635BBFB570FFA7032F5F2EC45D2:19936AEDB1795B871183BA432EECF56F
        public bool BootDiagnosticEnabled()
        {
            if (this.Inner.DiagnosticsProfile != null
                && this.Inner.DiagnosticsProfile.BootDiagnostics != null) {
                    return this.Inner.DiagnosticsProfile.BootDiagnostics.Enabled.Value;
            }
            return false;
        }

        ///GENMHASH:8761D0D225B7C49A7A5025186E94B263:BA170CE7D8B4381095CF80F0B121B545
        public void PowerOff()
        {
            this.PowerOffAsync().Wait();
        }

        ///GENMHASH:F5949CB4AFA8DD0B8DED0F369B12A8F6:E8FB723EB69B1FF154465213A3298460
        public VirtualMachineInstanceView RefreshInstanceView()
        {
            VirtualMachineScaleSetVMInstanceViewInner instanceViewInner = this.client.GetInstanceView(this.Parent.ResourceGroupName,
                this.Parent.Name,
                this.InstanceId());

            if (instanceViewInner != null) {
                this.virtualMachineInstanceView = new VirtualMachineInstanceView()
                {
                    BootDiagnostics = instanceViewInner.BootDiagnostics,
                    Disks = instanceViewInner.Disks,
                    Extensions = instanceViewInner.Extensions,
                    PlatformFaultDomain = instanceViewInner.PlatformFaultDomain,
                    PlatformUpdateDomain = instanceViewInner.PlatformUpdateDomain,
                    RdpThumbPrint = instanceViewInner.RdpThumbPrint,
                    Statuses = instanceViewInner.Statuses,
                    VmAgent = instanceViewInner.VmAgent
                };
            }
            return this.virtualMachineInstanceView;
        }

        ///GENMHASH:667E734583F577A898C6389A3D9F4C09:E31C3E6AAB81275E957AEE7FFC644CBF
        public void Deallocate()
        {
            this.DeallocateAsync().Wait();
        }

        ///GENMHASH:8442F1C1132907DE46B62B277F4EE9B7:605B8FC69F180AFC7CE18C754024B46C
        public string Type()
        {
            return this.Inner.Type;
        }

        ///GENMHASH:74D6BC0CA5239D9979A6C4F61D973616:C90E0C1B7FFF1EE7A6D2A1D595F52BE7
        public PowerState PowerState()
        {
            return Microsoft.Azure.Management.Compute.Fluent.PowerState.FromInstanceView(this.InstanceView());
        }

        ///GENMHASH:F80DBECC128264AD2E1D6546D7B09EB3:01DE0FF46DCB4DD3745B7173E66AFDB6
        public bool IsOsBasedOnPlatformImage()
        {
            return this.PlatformImageReference() != null;
        }

        ///GENMHASH:123FF0223083F789E78E45771A759A9C:4C15A2B31C3EDC9F84F5ED384B0E13D8
        public CachingTypes OsDiskCachingType()
        {
            return this.Inner.StorageProfile.OsDisk.Caching.Value;
        }

        ///GENMHASH:6DC69B57C0EF18B742D6A9F6EF064DB6:6CD28FCFD5EA7F340C6DE5F87BC3580C
        public DiagnosticsProfile DiagnosticsProfile()
        {
            return this.Inner.DiagnosticsProfile;
        }

        ///GENMHASH:ACA2D5620579D8158A29586CA1FF4BC6:899F2B088BBBD76CCBC31221756265BC
        public string Id()
        {
            return this.Inner.Id;
        }

        ///GENMHASH:F792F6C8C594AA68FA7A0FCA92F55B55:43E446F640DC3345BDBD9A3378F2018A
        public Sku Sku()
        {
            return this.Inner.Sku;
        }

        ///GENMHASH:606A3D349546DF27E3A091C321476658:DE6214AA350F8F418A233CAFCB35739F
        public IList<string> NetworkInterfaceIds()
        {
            return this.Inner
                .NetworkProfile
                .NetworkInterfaces
                .Select(nic => nic.Id).ToList();
        }

        ///GENMHASH:D5AD274A3026D80CDF6A0DD97D9F20D4:58ABB710ED036C0D7836493A79C470A9
        public Task StartAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.client.StartAsync(this.Parent.ResourceGroupName,
                this.Parent.Name,
                this.InstanceId(),
                cancellationToken);
        }

        ///GENMHASH:4B19A5F1B35CA91D20F63FBB66E86252:9B2A27091279EF147C6847EBD7A52FA9
        public IReadOnlyDictionary<string, string> Tags()
        {
            if (this.Inner.Tags == null)
            {
                return new Dictionary<string, string>();
            }
            return this.Inner.Tags as IReadOnlyDictionary<string, string>;
        }

        ///GENMHASH:7F6A7E961EA5A11F2B8013E54123A7D0:C1CDD6BC19A1D800E2865E3DC44941E1
        private void ClearCachedRelatedResources()
        {
            this.virtualMachineInstanceView = null;
        }

        ///GENMHASH:EC363135C0A3366C1FA98226F4AE5D05:E08DF139B6B7A79C2B17270C6CB16CD0
        public IReadOnlyDictionary<string, Microsoft.Azure.Management.Compute.Fluent.IVirtualMachineScaleSetVMInstanceExtension> Extensions()
        {
            if (this.Inner.Resources == null)
            {
                return new Dictionary<string, IVirtualMachineScaleSetVMInstanceExtension>();
            }
            return this.Inner.Resources
                .ToDictionary(r => r.Name, 
                              r => (new VirtualMachineScaleSetVMInstanceExtensionImpl(r, this) as IVirtualMachineScaleSetVMInstanceExtension));
        }

        ///GENMHASH:C19382933BDE655D0F0F95CD9474DFE7:DB5E59650C351CEA1A8047EAB8DFA902
        public VirtualMachineSizeTypes Size()
        {
            if (this.Inner.HardwareProfile != null && this.Inner.HardwareProfile.VmSize != null) {
                return new VirtualMachineSizeTypes(this.Inner.HardwareProfile.VmSize);
            }
            if (this.Sku() != null && this.Sku().Name != null) {
                return new VirtualMachineSizeTypes(this.Sku().Name);
            }
            return null;
        }

        ///GENMHASH:3E38805ED0E7BA3CAEE31311D032A21C:61C1065B307679F3800C701AE0D87070
        public override string Name()
        {
           return this.Inner.Name;
        }

        ///GENMHASH:F54E5F59629E7189DFAA84B469430E3E:C91262C6EFD95C4E63C8AE6648458189
        public bool IsLinuxPasswordAuthenticationEnabled()
        {
            if (this.Inner.OsProfile.LinuxConfiguration != null) {
                return this.Inner.OsProfile.LinuxConfiguration.DisablePasswordAuthentication ?? false;
            }
            return false;
        }

        ///GENMHASH:6A2970A94B2DD4A859B00B9B9D9691AD:4208AEB8137598AB1A39881825F4406A
        public Region Region()
        {
            return Microsoft.Azure.Management.Resource.Fluent.Core.Region.Create(this.RegionName());
        }

        ///GENMHASH:AE4C4EDD69D8398105E588BB437DB52F:03C423E26F1CAEDC60B8BCBB1D78DBE6
        public string AvailabilitySetId()
        {
            if (this.Inner.AvailabilitySet != null) {
                return this.Inner.AvailabilitySet.Id;
            }
            return null;
        }

        ///GENMHASH:C0EB387DE858347CC9ECD61143087BEE:370DCDB672E2ABECD4FA09EF809A2A86
        public Task DeallocateAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.client.DeallocateAsync(this.Parent.ResourceGroupName,
                this.Parent.Name,
                this.InstanceId(),
                cancellationToken);
        }

        ///GENMHASH:5390AD803419DE6CEAFF825AD0A94458:840BEA574ED55AAD9998A3A420D98257
        public OSProfile OsProfile()
        {
            return this.Inner.OsProfile;
        }

        ///GENMHASH:128FD79E8DC783A2FF49FDFCCE4187DD:343C0BEE1A4B7107E587437CC211D9EC
        public string CustomImageVhdUri()
        {
            if (this.Inner.StorageProfile.OsDisk.Image != null) {
                return this.Inner.StorageProfile.OsDisk.Image.Uri;
            }
            return null;
        }

        ///GENMHASH:F340B9C68B7C557DDB54F615FEF67E89:3054A3D10ED7865B89395E7C007419C9
        public string RegionName()
        {
            return this.Inner.Location;
        }

        ///GENMHASH:FEB63CBC1CA7D22A121F19D94AB44052:7E7C3C37B9FF921AE8D5F1C8460403A7
        public Task RestartAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.client.RestartAsync(this.Parent.ResourceGroupName,
                this.Parent.Name,
                this.InstanceId(),
                cancellationToken);
        }

        ///GENMHASH:D49CFB6F544192733FF4EC93E412EF97:2FFF55F1D47FDA3AA92B579EE7A51EA2
        public IVirtualMachineImage GetPlatformImage()
        {
            if (this.IsOsBasedOnPlatformImage()) {
                ImageReference imageReference = this.PlatformImageReference();
                return this.computeManager.VirtualMachineImages.GetImage(this.Region(),
                    imageReference.Publisher,
                    imageReference.Offer,
                    imageReference.Sku,
                    imageReference.Version);
            }
            return null;
        }

        ///GENMHASH:65E6085BB9054A86F6A84772E3F5A9EC:3AF56414924A2B5C8018E43635C23E6D
        public void Delete()
        {
            DeleteAsync().Wait();
        }

        ///GENMHASH:84A1C38F299C7713046CF6F1527D8F63:F642711AE7F703621C557536E835ED40
        public int OsDiskSizeInGB()
        {
            if (this.Inner.StorageProfile.OsDisk.DiskSizeGB != null) {
                return this.Inner.StorageProfile.OsDisk.DiskSizeGB ?? 0;
            }
            // Its a known issue that size of OS disk based on platform image is sometimes null
            return 0;
        }

        ///GENMHASH:8DA87DECB2E8018044C8A2F4DE659FC1:9CB0D65951E0503EA1C48915D3F0E2A0
        public string BootDiagnosticStorageAccountUri()
        {
            if (this.Inner.DiagnosticsProfile != null
                && this.Inner.DiagnosticsProfile.BootDiagnostics != null) {
                    return this.Inner.DiagnosticsProfile.BootDiagnostics.StorageUri;
            }
            return null;
        }

        ///GENMHASH:9F6C057D1401DFDC309A6553A712FD5F:D2CFA0DA4C386F7509555F3479BBB036
        public bool IsWindowsVmAgentProvisioned()
        {
            if (this.Inner.OsProfile.WindowsConfiguration != null) {
                return this.Inner.OsProfile.WindowsConfiguration.ProvisionVMAgent ?? false;
            }
            return false;
        }

        ///GENMHASH:E21E3E6E61153DDD23E28BC18B49F1AC:1C335DE060E2C5BE410D8822875D2876
        public VirtualMachineInstanceView InstanceView()
        {
            if (this.virtualMachineInstanceView == null) {
                RefreshInstanceView();
            }
            return this.virtualMachineInstanceView;
        }

        ///GENMHASH:DB561BC9EF939094412065B65EB3D2EA:EE9FAF4FEA996048F4927C08CF0BBB9F
        public void Reimage()
        {
            this.ReimageAsync().Wait();
        }

        ///GENMHASH:8DDA5FB2E9E6E0697D0969997C1BE9C4:9DD8966D7074391F9512E63BBEB93FA9
        public string InstanceId()
        {
            return this.Inner.InstanceId;
        }

        ///GENMHASH:3EFB25CB32AC4B416B8E0501FDE1DBE9:80F5BE509026B52C7249F4402079EF25
        public string ComputerName()
        {
            return this.Inner.OsProfile.ComputerName;
        }

        ///GENMHASH:39841E710EB7DD7AE8E99B918CA0EEEA:2F3BC2C8125DFCF2467F6219DA16876C
        public string OsDiskName()
        {
            return this.Inner.StorageProfile.OsDisk.Name;
        }

        ///GENMHASH:1BAF4F1B601F89251ABCFE6CC4867026:FB684D7D2C82711ED8A5D7DE503D692B
        public OperatingSystemTypes OsType()
        {
            return this.Inner.StorageProfile.OsDisk.OsType.Value;
        }

        ///GENMHASH:3ABC41CDC1AC150E4431F11073623E1A:CE1EF18259254D728183B6023A6CBE91
        public ImageReference PlatformImageReference()
        {
            return this.Inner.StorageProfile.ImageReference;
        }

        ///GENMHASH:D689C0F3639A0E935C55CB38C26FAAFD:E6911DC70A59F96D2F88F3FF5122E38B
        public Task PowerOffAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.client.PowerOffAsync(this.Parent.ResourceGroupName,
                this.Parent.Name,
                this.InstanceId(), 
                cancellationToken);
        }

        ///GENMHASH:04E0C67356E08FBE5594BBF625AFC82E:AF9371203DB21801143C352B6122DB4F
        public string AdministratorUserName()
        {
            return this.Inner.OsProfile.AdminUsername;
        }

        ///GENMHASH:960A44940EE0E051601BB59CD935FE22:09B1869890AC6095FE0FBE503BBBBFB6
        public Task ReimageAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.client.ReimageAsync(this.Parent.ResourceGroupName,
                this.Parent.Name,
                this.InstanceId(),
                cancellationToken);
        }

        ///GENMHASH:08CFC096AC6388D1C0E041ECDF099E3D:8DC054450782B914522C4E063E233AAE
        public void Restart()
        {
            this.RestartAsync().Wait();
        }

        ///GENMHASH:0F38250A3837DF9C2C345D4A038B654B:0E335374306A3050322A5D1E4C468CF8
        public void Start()
        {
            this.StartAsync().Wait();
        }

        ///GENMHASH:882F1CC2224D95370B7A4269ED87EC4F:FA558C03B2F8DB0C8883E9CE9D380464
        public bool IsWindowsAutoUpdateEnabled()
        {
            if (this.Inner.OsProfile.WindowsConfiguration != null) {
                return this.Inner.OsProfile.WindowsConfiguration.EnableAutomaticUpdates ?? false;
            }
            return false;
        }

        ///GENMHASH:4002186478A1CB0B59732EBFB18DEB3A:44ACDDF0B04148CC3F9347EA7C0643B4
        public IVirtualMachineScaleSetVM Refresh()
        {
            this.SetInner(this.client.Get(this.Parent.ResourceGroupName,
                this.Parent.Name,
                this.InstanceId()));
                this.ClearCachedRelatedResources();
            return this;
        }

        ///GENMHASH:0FEDA307DAD2022B36843E8905D26EAD:C5FE9F038576055F219FB734E49D39D9
        public Task DeleteAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return this.client.DeleteAsync(this.Parent.ResourceGroupName,
                this.Parent.Name,
                this.InstanceId(), cancellationToken);
        }

        ///GENMHASH:56E00E1F789510BB94AFCDC1FF61D00B:C0B660115AA9DC53D76DEDA856496556
        internal VirtualMachineScaleSetVMImpl(VirtualMachineScaleSetVMInner inner,
            VirtualMachineScaleSetImpl parent,
            IVirtualMachineScaleSetVMsOperations client,
            ComputeManager computeManager) : base(inner, parent)
        {
            this.client = client;
            this.computeManager = computeManager;
            this.virtualMachineInstanceView = this.Inner.InstanceView;
        }

        ///GENMHASH:7F0A9CB4CB6BBC98F72CF50A81EBFBF4:BBFAD2E04A2C1C43EB33356B7F7A2AD6
        public StorageProfile StorageProfile()
        {
            return this.Inner.StorageProfile;
        }

        ///GENMHASH:D97CA4262C0C853895BFF5AD2FE910FE:8AE50992E9627A3D3844895445A18A8D
        public string OsDiskVhdUri()
        {
            if (this.Inner.StorageProfile.OsDisk.Vhd != null) {
                return this.Inner.StorageProfile.OsDisk.Vhd.Uri;
            }
            return null;
        }

        ///GENMHASH:8149ED362968AEDB6044CB62BAB0373B:4C59C3CF7F7CCFC21F5209A58AA3CE06
        public string PrimaryNetworkInterfaceId()
        {
            foreach(var reference in this.Inner.NetworkProfile.NetworkInterfaces)  {
                bool isPrimary = reference.Primary ?? false;
                if (isPrimary) {
                    return reference.Id;
                }
            }
            return null;
        }
    }
}
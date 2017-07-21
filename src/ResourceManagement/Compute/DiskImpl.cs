// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Models;
    using ResourceManager.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// The implementation for Disk and its create and update interfaces.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbXB1dGUuaW1wbGVtZW50YXRpb24uRGlza0ltcGw=
    internal partial class DiskImpl :
        GroupableResource<IDisk, 
            DiskInner,
            DiskImpl, 
            IComputeManager, 
            Disk.Definition.IWithGroup,
            Disk.Definition.IWithDiskSource,
            Disk.Definition.IWithCreate,
            Disk.Update.IUpdate>,
        IDisk,
        Disk.Definition.IDefinition,
        Disk.Update.IUpdate
    {
        ///GENMHASH:40B6E8297181515AA2C730D3D30BE761:113A819FAF18DEACEC4BCC60120F8166
        internal DiskImpl(string name, DiskInner innerModel, IComputeManager computeManager) : base(name, innerModel, computeManager)
        {
        }

        ///GENMHASH:B5D0CEDC0E866EFD1D97D2FC06AC78B2:540C8E40423CBE57B12D10B8EE2CEEF4
        public DiskImpl WithSizeInGB(int sizeInGB)
        {
            Inner.DiskSizeGB = sizeInGB;
            return this;
        }

        ///GENMHASH:AAD8E592A024E583CCB079E40FA35511:86D949645392B88CC8EBDF08E3E0EDF8
        public DiskImpl WithLinuxFromVhd(string vhdUrl)
        {
            Inner.OsType = OperatingSystemTypes.Linux;
            Inner.CreationData = new CreationData();
            Inner.CreationData.CreateOption = DiskCreateOption.Import;
            Inner.CreationData.SourceUri = vhdUrl;
            return this;
        }

        ///GENMHASH:0305227D84160F6D01FAC3F90C4D3B17:B17E3BD9F6452F930B5081BFB28B816E
        public DiskImpl WithWindowsFromDisk(string sourceDiskId)
        {
            Inner.OsType = OperatingSystemTypes.Windows;
            Inner.CreationData = new CreationData();
            Inner.CreationData.CreateOption = DiskCreateOption.Copy;
            Inner.CreationData.SourceResourceId = sourceDiskId;
            return this;
        }

        ///GENMHASH:B024A3F2B7DF627DB59422FF7F7B1A64:E2C0A81CA2E3138B95F8C3A8D029297C
        public DiskImpl WithWindowsFromDisk(IDisk sourceDisk)
        {
            WithWindowsFromDisk(sourceDisk.Id);
            if (sourceDisk.OSType != null && sourceDisk.OSType.HasValue)
            {
                WithOSType(sourceDisk.OSType.Value);
            }
            WithSku(sourceDisk.Sku);
            return this;
        }

        ///GENMHASH:C9FA7E95A384165D3EF616382AA69B2D:E7F1DA78794C44C2AC55569F4DDCBD11
        public DiskImpl WithOSType(OperatingSystemTypes osType)
        {
            Inner.OsType = osType;
            return this;
        }

        ///GENMHASH:E4F5CCFED775B8C1F10A8019B52CC013:AF82C13C6612DFDED62B43750E8734C8
        public DiskImpl WithLinuxFromDisk(string sourceDiskId)
        {
            Inner.OsType = OperatingSystemTypes.Linux;
            Inner.CreationData = new CreationData();
            Inner.CreationData.CreateOption = DiskCreateOption.Copy;
            Inner.CreationData.SourceResourceId = sourceDiskId;
            return this;
        }

        ///GENMHASH:2F60AEDC3637C02CE6A3AD7DD7020FCF:5A86C9FEF29C8DD39335BC3E23501E52
        public DiskImpl WithLinuxFromDisk(IDisk sourceDisk)
        {
            WithLinuxFromDisk(sourceDisk.Id);
            if (sourceDisk.OSType != null && sourceDisk.OSType.HasValue)
            {
                this.WithOSType(sourceDisk.OSType.Value);
            }
            this.WithSku(sourceDisk.Sku);
            return this;
        }

        ///GENMHASH:32ABF27B7A32286845C5FAFE717F8E4D:5065B0FD2B80D38CDBB3AD2A7840B68D
        public CreationSource Source()
        {
            return new CreationSource(Inner.CreationData);
        }

        ///GENMHASH:D85E911348B4AD36294F154A7C700412:507C952D65DEB7C06C2758D22266AB43
        public DiskCreateOption CreationMethod()
        {
            return Inner.CreationData.CreateOption;
        }

        ///GENMHASH:28C892DD6868506954A9B3D406FE4710:E57D05C8BB272E6441E14E0F73F93F60
        public DiskImpl WithWindowsFromVhd(string vhdUrl)
        {
            Inner.OsType = OperatingSystemTypes.Windows;
            Inner.CreationData = new CreationData();
            Inner.CreationData.CreateOption = DiskCreateOption.Import;
            Inner.CreationData.SourceUri = vhdUrl;
            return this;
        }

        ///GENMHASH:C14080365CC6F93E30BB51B78DED7084:769384CE5F12D8DA31D146E04DAD108F
        public async Task RevokeAccessAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await Manager.Inner.Disks.RevokeAccessAsync(ResourceGroupName, Name, cancellationToken);
        }

        ///GENMHASH:C14080365CC6F93E30BB51B78DED7084:769384CE5F12D8DA31D146E04DAD108F
        public void RevokeAccess()
        {
            Extensions.Synchronize(() => this.RevokeAccessAsync());
        }

        ///GENMHASH:920045A2761D4D5D5F5E2E52D43917D0:28B657BB52464897349F96AD3FEE7B7C
        public int SizeInGB()
        {
            if (Inner.DiskSizeGB != null && Inner.DiskSizeGB.HasValue)
            {
                return Inner.DiskSizeGB.Value;
            }
            return 0;
        }

        ///GENMHASH:1BAF4F1B601F89251ABCFE6CC4867026:F71645491B82E137E4D1786750E7ADF0
        public OperatingSystemTypes? OSType()
        {
            return Inner.OsType;
        }

        ///GENMHASH:F792F6C8C594AA68FA7A0FCA92F55B55:A57B8C47BCE45BC6F3DA10CAF14C67BE
        public DiskSkuTypes Sku()
        {
            if (Inner.AccountType != null && Inner.AccountType.HasValue)
            {
                return DiskSkuTypes.FromStorageAccountType(Inner.AccountType.Value);
            }
            return null;
        }

        ///GENMHASH:0202A00A1DCF248D2647DBDBEF2CA865:4862DE76074C3C17570C425395A8E68C
        public async override Task<Microsoft.Azure.Management.Compute.Fluent.IDisk> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var diskInner = await Manager.Inner.Disks.CreateOrUpdateAsync(ResourceGroupName, Name, Inner, cancellationToken);
            SetInner(diskInner);
            return this;
        }

        ///GENMHASH:3E35FB42190F8D9DBB9DAD636FA3EDE3:18D9C432A23D2C301F2F3E9EF7C57583
        public string VirtualMachineId()
        {
            return Inner.OwnerId;
        }

        ///GENMHASH:DAC486F08AF23F259E630032FC20FAF1:3FE53F300A729DFBC3C1F55BBB117CA1
        public async Task<string> GrantAccessAsync(int accessDurationInSeconds, CancellationToken cancellationToken = default(CancellationToken))
        {
            GrantAccessDataInner grantAccessDataInner = new GrantAccessDataInner();
            grantAccessDataInner.Access = AccessLevel.Read;
            grantAccessDataInner.DurationInSeconds = accessDurationInSeconds;

            AccessUriInner accessUriInner = await Manager.Inner.Disks.GrantAccessAsync(ResourceGroupName, Name, grantAccessDataInner, cancellationToken);
            if (accessUriInner == null)
            {
                return null;
            }
            return accessUriInner.AccessSAS;
        }

        ///GENMHASH:DAC486F08AF23F259E630032FC20FAF1:3FE53F300A729DFBC3C1F55BBB117CA1
        public string GrantAccess(int accessDurationInSeconds)
        {
            return Extensions.Synchronize(() => this.GrantAccessAsync(accessDurationInSeconds));
        }

        ///GENMHASH:4002186478A1CB0B59732EBFB18DEB3A:AACFFB1D9582E4E00031423DDDD4036A
        protected override async Task<DiskInner> GetInnerAsync(CancellationToken cancellationToken)
        {
            return await Manager.Inner.Disks.GetAsync(ResourceGroupName, Name, cancellationToken: cancellationToken);
        }

        ///GENMHASH:B0C9EEFDDA443C25158B8F287BDAF3D8:6F1F05D0FB05C43F2A1F954CC1CBE3FB
        public DiskImpl FromDisk(string managedDiskId)
        {
            Inner.CreationData = new CreationData();
            Inner.CreationData.CreateOption = DiskCreateOption.Copy;
            Inner.CreationData.SourceResourceId = managedDiskId;
            return this;
        }

        ///GENMHASH:35554EAE5498D7FE6802046334117879:D648CB8B53E8FA621C5DBFFF214D7EFA
        public DiskImpl FromDisk(IDisk managedDisk)
        {
            if (managedDisk.OSType != null && managedDisk.OSType.HasValue)
            {
                return FromDisk(managedDisk.Id)
                    .WithOSType(managedDisk.OSType.Value)
                    .WithSku(managedDisk.Sku);
            }
            else
            {
                return FromDisk(managedDisk.Id)
                    .WithSku(managedDisk.Sku);
            }
        }

        ///GENMHASH:26BC80239F0CCAAB14CDBC15A85351B8:5C4E68981DCB985DABC30CE2B145CC62
        public DiskImpl WithSku(DiskSkuTypes sku)
        {
            Inner.AccountType = sku.AccountType;
            return this;
        }

        ///GENMHASH:27B8AD5B496821160B763BEE4B6DAB47:A99E5BCABB2F6C6A293C01FAEA00D27B
        public DiskImpl WithWindowsFromSnapshot(string sourceSnapshotId)
        {
            Inner.OsType = OperatingSystemTypes.Windows;
            Inner.CreationData = new CreationData();
            Inner.CreationData.CreateOption = DiskCreateOption.Copy;
            Inner.CreationData.SourceResourceId = sourceSnapshotId;
            return this;
        }

        ///GENMHASH:B78CFB2B90CBCD4E1774158A24658400:F8CDA696580CA3AD1C0ED55ED6F90AD9
        public DiskImpl WithWindowsFromSnapshot(ISnapshot sourceSnapshot)
        {
            WithWindowsFromSnapshot(sourceSnapshot.Id);
            if (sourceSnapshot.OSType != null && sourceSnapshot.OSType.HasValue) {
                this.WithOSType(sourceSnapshot.OSType.Value);
            }
            this.WithSku(sourceSnapshot.Sku);
            return this;
        }

        ///GENMHASH:33732DE66CF09C72524FF6128BF39B86:95A2FDC64707881A6ECE16C0FF2967B1
        public DiskImpl WithData()
        {
            Inner.CreationData = new CreationData();
            Inner.CreationData.CreateOption = DiskCreateOption.Empty;
            return this;
        }

        ///GENMHASH:20127E6A8A1B4B28CE511AEB479A6C9A:B42B6D1380F4A7780F5B729A33312605
        public DiskImpl FromVhd(string vhdUrl)
        {
            Inner.CreationData = new CreationData();
            Inner.CreationData.CreateOption = DiskCreateOption.Import;
            Inner.CreationData.SourceUri = vhdUrl;
            return this;
        }

        ///GENMHASH:70CBBB70E322069BB113700431A2BB15:B0B6C2751314366F7CFDC62C6B6738E6
        public DiskImpl WithLinuxFromSnapshot(string sourceSnapshotId)
        {
            Inner.OsType = OperatingSystemTypes.Linux;
            Inner.CreationData = new CreationData();
            Inner.CreationData.CreateOption = DiskCreateOption.Copy;
            Inner.CreationData.SourceResourceId = sourceSnapshotId;
            return this;
        }

        ///GENMHASH:F9105F65A54CB3C0F922B30A209C500A:CE423770F06D02068CC781CA801FC6A3
        public DiskImpl WithLinuxFromSnapshot(ISnapshot sourceSnapshot)
        {
            WithLinuxFromSnapshot(sourceSnapshot.Id);
            if (sourceSnapshot.OSType != null && sourceSnapshot.OSType.HasValue)
            {
                this.WithOSType(sourceSnapshot.OSType.Value);
            }
            this.WithSku(sourceSnapshot.Sku);
            return this;
        }

        ///GENMHASH:5F18484CFD1C1619630DC7FB8FF815BB:FBD6F65B68D899E456B4367CF287DD44
        public bool IsAttachedToVirtualMachine()
        {
            return this.VirtualMachineId() != null;
        }

        ///GENMHASH:8D34B63403FF8A31ACD1E973BFBE7F09:E487F6DBBFE574160FCF0ECE22B0979B
        public DiskImpl FromSnapshot(string snapshotId)
        {
            Inner.CreationData = new CreationData();
            Inner.CreationData.CreateOption = DiskCreateOption.Copy;
            Inner.CreationData.SourceResourceId = snapshotId;
            return this;
        }

        ///GENMHASH:5BA6C6B418238F9AAD214C5F09B6E1CB:1EB84A49445D7528CE46D6A009A82F9E
        public DiskImpl FromSnapshot(ISnapshot snapshot)
        {
            return FromSnapshot(snapshot.Id);
        }
    }
}
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
    /// The implementation for Snapshot and its create and update interfaces.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbXB1dGUuaW1wbGVtZW50YXRpb24uU25hcHNob3RJbXBs
    internal partial class SnapshotImpl :
        GroupableResource<ISnapshot,
            SnapshotInner,
            SnapshotImpl, 
            IComputeManager,
            Snapshot.Definition.IWithGroup,
            Snapshot.Definition.IWithSnapshotSource,
            Snapshot.Definition.IWithCreate,
            Snapshot.Update.IUpdate>,
        ISnapshot,
        Snapshot.Definition.IDefinition,
        Snapshot.Update.IUpdate
    {
        ///GENMHASH:7065B24BABAC7FE0E97BB15717DED4C5:113A819FAF18DEACEC4BCC60120F8166
        internal SnapshotImpl(string name, SnapshotInner innerModel, IComputeManager computeManager) :
            base(name, innerModel, computeManager)
        {
        }

        ///GENMHASH:E3D5170F7AD778FE9D743F7A13428F7F:6F1F05D0FB05C43F2A1F954CC1CBE3FB
        public SnapshotImpl WithDataFromDisk(string managedDiskId)
        {
            Inner.CreationData = new CreationData();
            Inner.CreationData.CreateOption = DiskCreateOption.Copy;
            Inner.CreationData.SourceResourceId = managedDiskId;
            return this;
        }

        ///GENMHASH:677041EE7B045118782B0F039AD8F8C2:E22D7D9513E288182D42BE3859574904
        public SnapshotImpl WithDataFromDisk(IDisk managedDisk)
        {
            if (managedDisk.OSType != null && managedDisk.OSType.HasValue)
            {
                return WithDataFromDisk(managedDisk.Id)
                    .WithOSType(managedDisk.OSType.Value)
                    .WithSku(managedDisk.Sku);
            }
            else
            {
                return WithDataFromDisk(managedDisk.Id)
                    .WithSku(managedDisk.Sku);
            }
        }

        ///GENMHASH:B5D0CEDC0E866EFD1D97D2FC06AC78B2:540C8E40423CBE57B12D10B8EE2CEEF4
        public SnapshotImpl WithSizeInGB(int sizeInGB)
        {
            Inner.DiskSizeGB = sizeInGB;
            return this;
        }


        ///GENMHASH:AAD8E592A024E583CCB079E40FA35511:86D949645392B88CC8EBDF08E3E0EDF8
        public SnapshotImpl WithLinuxFromVhd(string vhdUrl)
        {
            Inner.OsType = OperatingSystemTypes.Linux;
            Inner.CreationData = new CreationData();
            Inner.CreationData.CreateOption = DiskCreateOption.Import;
            Inner.CreationData.SourceUri = vhdUrl;
            return this;
        }

        ///GENMHASH:93365D8F43EDEE99B4D1A8F4C19749AE:E487F6DBBFE574160FCF0ECE22B0979B
        public SnapshotImpl WithDataFromSnapshot(string snapshotId)
        {
            Inner.CreationData = new CreationData();
            Inner.CreationData.CreateOption = DiskCreateOption.Copy;
            Inner.CreationData.SourceResourceId = snapshotId;
            return this;
        }

        ///GENMHASH:8F0C864A5B5D204A3A41847B10A1C7E1:5CE2FC820A0809F1F6106E680C7D4333
        public SnapshotImpl WithDataFromSnapshot(ISnapshot snapshot)
        {
            return WithDataFromSnapshot(snapshot.Id);
        }

        ///GENMHASH:DAC486F08AF23F259E630032FC20FAF1:3FE53F300A729DFBC3C1F55BBB117CA1
        public async Task<string> GrantAccessAsync(int accessDurationInSeconds, CancellationToken cancellationToken = default(CancellationToken))
        {
            GrantAccessDataInner grantAccessDataInner = new GrantAccessDataInner();
            grantAccessDataInner.Access = AccessLevel.Read;
            grantAccessDataInner.DurationInSeconds = accessDurationInSeconds;

            AccessUriInner accessUriInner = await Manager.Inner.Snapshots.GrantAccessAsync(
                ResourceGroupName, Name, grantAccessDataInner, cancellationToken);
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

        ///GENMHASH:0305227D84160F6D01FAC3F90C4D3B17:B17E3BD9F6452F930B5081BFB28B816E
        public SnapshotImpl WithWindowsFromDisk(string sourceDiskId)
        {
            Inner.OsType = OperatingSystemTypes.Windows;
            Inner.CreationData = new CreationData();
            Inner.CreationData.CreateOption = DiskCreateOption.Copy;
            Inner.CreationData.SourceResourceId = sourceDiskId;
            return this;
        }

        ///GENMHASH:B024A3F2B7DF627DB59422FF7F7B1A64:E2C0A81CA2E3138B95F8C3A8D029297C
        public SnapshotImpl WithWindowsFromDisk(IDisk sourceDisk)
        {
            WithWindowsFromDisk(sourceDisk.Id);
            if (sourceDisk.OSType != null && sourceDisk.OSType.HasValue)
            {
                this.WithOSType(sourceDisk.OSType.Value);
            }
            this.WithSku(sourceDisk.Sku);
            return this;
        }

        ///GENMHASH:C9FA7E95A384165D3EF616382AA69B2D:E7F1DA78794C44C2AC55569F4DDCBD11
        public SnapshotImpl WithOSType(OperatingSystemTypes osType)
        {
            Inner.OsType = osType;
            return this;
        }

        ///GENMHASH:4002186478A1CB0B59732EBFB18DEB3A:465E0149E0D9FAAA15FE3F675F59732D
        protected override async Task<SnapshotInner> GetInnerAsync(CancellationToken cancellationToken)
        {
            return await Manager.Inner.Snapshots.GetAsync(ResourceGroupName, Name, cancellationToken: cancellationToken);
        }

        ///GENMHASH:E4F5CCFED775B8C1F10A8019B52CC013:AF82C13C6612DFDED62B43750E8734C8
        public SnapshotImpl WithLinuxFromDisk(string sourceDiskId)
        {
            Inner.OsType = OperatingSystemTypes.Linux;
            Inner.CreationData = new CreationData();
            Inner.CreationData.CreateOption = DiskCreateOption.Copy;
            Inner.CreationData.SourceResourceId = sourceDiskId;
            return this;
        }

        ///GENMHASH:2F60AEDC3637C02CE6A3AD7DD7020FCF:5A86C9FEF29C8DD39335BC3E23501E52
        public SnapshotImpl WithLinuxFromDisk(IDisk sourceDisk)
        {
            WithLinuxFromDisk(sourceDisk.Id);
            if (sourceDisk.OSType != null && sourceDisk.OSType.HasValue)
            {
                WithOSType(sourceDisk.OSType.Value);
            }
            WithSku(sourceDisk.Sku);
            return this;
        }

        ///GENMHASH:32ABF27B7A32286845C5FAFE717F8E4D:5065B0FD2B80D38CDBB3AD2A7840B68D
        public CreationSource Source()
        {
            return new CreationSource(Inner.CreationData);
        }

        ///GENMHASH:BE7E147B48A8E5D7518DE00A1A239664:B42B6D1380F4A7780F5B729A33312605
        public SnapshotImpl WithDataFromVhd(string vhdUrl)
        {
            Inner.CreationData = new CreationData();
            Inner.CreationData.CreateOption = DiskCreateOption.Import;
            Inner.CreationData.SourceUri = vhdUrl;
            return this;
        }

        ///GENMHASH:D85E911348B4AD36294F154A7C700412:507C952D65DEB7C06C2758D22266AB43
        public DiskCreateOption CreationMethod()
        {
            return Inner.CreationData.CreateOption;
        }

        ///GENMHASH:28C892DD6868506954A9B3D406FE4710:E57D05C8BB272E6441E14E0F73F93F60
        public SnapshotImpl WithWindowsFromVhd(string vhdUrl)
        {
            Inner.OsType = OperatingSystemTypes.Windows;
            Inner.CreationData = new CreationData();
            Inner.CreationData.CreateOption = DiskCreateOption.Import;
            Inner.CreationData.SourceUri = vhdUrl;
            return this;
        }

        ///GENMHASH:26BC80239F0CCAAB14CDBC15A85351B8:5C4E68981DCB985DABC30CE2B145CC62
        public SnapshotImpl WithSku(DiskSkuTypes sku)
        {
            Inner.AccountType = sku.AccountType;
            return this;
        }

        ///GENMHASH:27B8AD5B496821160B763BEE4B6DAB47:A99E5BCABB2F6C6A293C01FAEA00D27B
        public SnapshotImpl WithWindowsFromSnapshot(string sourceSnapshotId)
        {
            Inner.OsType = OperatingSystemTypes.Windows;
            Inner.CreationData = new CreationData();
            Inner.CreationData.CreateOption = DiskCreateOption.Copy;
            Inner.CreationData.SourceResourceId = sourceSnapshotId;
            return this;
        }

        ///GENMHASH:B78CFB2B90CBCD4E1774158A24658400:F8CDA696580CA3AD1C0ED55ED6F90AD9
        public SnapshotImpl WithWindowsFromSnapshot(ISnapshot sourceSnapshot)
        {
            WithWindowsFromSnapshot(sourceSnapshot.Id);
            if (sourceSnapshot.OSType != null && sourceSnapshot.OSType.HasValue)
            {
                WithOSType(sourceSnapshot.OSType.Value);
            }
            WithSku(sourceSnapshot.Sku);
            return this;
        }

        ///GENMHASH:C14080365CC6F93E30BB51B78DED7084:769384CE5F12D8DA31D146E04DAD108F
        public async Task RevokeAccessAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await Manager.Inner.Snapshots.RevokeAccessAsync(ResourceGroupName, Name, cancellationToken);
        }

        ///GENMHASH:C14080365CC6F93E30BB51B78DED7084:769384CE5F12D8DA31D146E04DAD108F
        public void RevokeAccess()
        {
            Extensions.Synchronize(() => RevokeAccessAsync());
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
                return new DiskSkuTypes(Inner.AccountType.Value);
            }
            return null;
        }

        ///GENMHASH:70CBBB70E322069BB113700431A2BB15:B0B6C2751314366F7CFDC62C6B6738E6
        public SnapshotImpl WithLinuxFromSnapshot(string sourceSnapshotId)
        {
            Inner.OsType = OperatingSystemTypes.Linux;
            Inner.CreationData = new CreationData();
            Inner.CreationData.CreateOption = DiskCreateOption.Copy;
            Inner.CreationData.SourceResourceId = sourceSnapshotId;
            return this;
        }

        ///GENMHASH:F9105F65A54CB3C0F922B30A209C500A:CE423770F06D02068CC781CA801FC6A3
        public SnapshotImpl WithLinuxFromSnapshot(ISnapshot sourceSnapshot)
        {
            WithLinuxFromSnapshot(sourceSnapshot.Id);
            if (sourceSnapshot.OSType != null && sourceSnapshot.OSType.HasValue)
            {
                WithOSType(sourceSnapshot.OSType.Value);
            }
            WithSku(sourceSnapshot.Sku);
            return this;
        }

        ///GENMHASH:0202A00A1DCF248D2647DBDBEF2CA865:4862DE76074C3C17570C425395A8E68C
        public async override Task<ISnapshot> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var snapshotInner = await Manager.Inner.Snapshots.CreateOrUpdateAsync(ResourceGroupName, Name, Inner, cancellationToken);
            SetInner(snapshotInner);
            return this;
        }
    }
}
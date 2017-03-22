// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Models;
    using ResourceManager.Fluent;
    using System.Collections.Generic;

    /// <summary>
    /// The implementation for VirtualMachineCustomImage.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbXB1dGUuaW1wbGVtZW50YXRpb24uVmlydHVhbE1hY2hpbmVDdXN0b21JbWFnZUltcGw=
    internal partial class VirtualMachineCustomImageImpl :
        GroupableResource<IVirtualMachineCustomImage,
            ImageInner,
            VirtualMachineCustomImageImpl, 
            IComputeManager,
            VirtualMachineCustomImage.Definition.IWithGroup,
            VirtualMachineCustomImage.Definition.IWithOSDiskImageSourceAltVirtualMachineSource,
            VirtualMachineCustomImage.Definition.IWithCreate,
            object>,
        IVirtualMachineCustomImage,
        VirtualMachineCustomImage.Definition.IDefinition
    {
        ///GENMHASH:35C6004A0049CA82CAB4E36FD4074FA3:113A819FAF18DEACEC4BCC60120F8166
        internal VirtualMachineCustomImageImpl(string name, ImageInner innerModel, IComputeManager computeManager) :
            base(name, innerModel, computeManager)
        {
        }

        ///GENMHASH:D56077CEB6F4BC29067D1495F17A7955:BD98217A776917172DAD36841C524F30
        public VirtualMachineCustomImageImpl WithDataDiskImageFromVhd(string sourceVhdUrl)
        {
            DefineDataDiskImage()
                .WithLun(-1)
                .FromVhd(sourceVhdUrl)
                .Attach();
            return this;
        }

        ///GENMHASH:7A0B27D94CA2F0AFB4A9652950F57AFE:43A777A43BC53007F5243CC234331AFB
        public VirtualMachineCustomImageImpl WithOSDiskSizeInGB(int diskSizeGB)
        {
            var imageOsDisk = this.EnsureOsDiskImage();
            imageOsDisk.DiskSizeGB = diskSizeGB;
            return this;
        }

        ///GENMHASH:0E35B57E40F7013714501510E6A82763:FA0DA2D49BB19FB064747F80391EAE9A
        public CustomImageDataDiskImpl DefineDataDiskImage()
        {
            return new CustomImageDataDiskImpl(new ImageDataDisk(),this);
        }

        ///GENMHASH:4B04B5578F522B6D67AC092ED5FBCE91:0D973F87F3643713E968DB6281AB091B
        public bool IsCreatedFromVirtualMachine()
        {
            return this.SourceVirtualMachineId() != null;
        }

        ///GENMHASH:D1C4946A9D880775BE2352E9E76C9EED:AC7317852CF2F1330BAFC7715BAE78BC
        public VirtualMachineCustomImageImpl WithLinuxFromVhd(string sourceVhdUrl, OperatingSystemStateTypes osState)
        {
            var imageOsDisk = EnsureOsDiskImage();
            imageOsDisk.OsState = osState;
            imageOsDisk.OsType = OperatingSystemTypes.Linux;
            imageOsDisk.BlobUri = sourceVhdUrl;
            return this;
        }

        ///GENMHASH:68806A9EFF9AE1233F4E313BFAB88A1E:1071A5DFED9420CCE4BC2A527876347B
        public VirtualMachineCustomImageImpl WithOSDiskCaching(CachingTypes cachingType)
        {
            var imageOsDisk = EnsureOsDiskImage();
            imageOsDisk.Caching = cachingType;
            return this;
        }

        ///GENMHASH:D660B915C7DA582BBE874F8D2757FB0A:0044BB116AAF8812F23F9F359960E510
        public VirtualMachineCustomImageImpl WithWindowsFromDisk(string sourceManagedDiskId, OperatingSystemStateTypes osState)
        {
            var imageOsDisk = EnsureOsDiskImage();
            imageOsDisk.OsState = osState;
            imageOsDisk.OsType = OperatingSystemTypes.Windows;
            imageOsDisk.ManagedDisk = new SubResource()
            {
                Id = sourceManagedDiskId
            };
            return this;
        }

        ///GENMHASH:E32C4E2FF3CA09EACD413EB87D724DB1:5C854FA52193FBAF30E0B052729FE56C
        public VirtualMachineCustomImageImpl WithWindowsFromDisk(IDisk sourceManagedDisk, OperatingSystemStateTypes osState)
        {
            return WithWindowsFromDisk(sourceManagedDisk.Id, osState);
        }

        ///GENMHASH:4002186478A1CB0B59732EBFB18DEB3A:4F402C1981DA7F09CE4549AA85EF82EF
        public override IVirtualMachineCustomImage Refresh()
        {
            ImageInner imageInner = Manager.Inner.Images.Get(ResourceGroupName, Name);
            SetInner(imageInner);
            return this;
        }

        ///GENMHASH:F8F5E034B580C65E1958A4165F6207B3:34DFF336CAE464BA69C47A7AA2362690
        public VirtualMachineCustomImageImpl WithLinuxFromDisk(string sourceManagedDiskId, OperatingSystemStateTypes osState)
        {
            var imageOsDisk = this.EnsureOsDiskImage();
            imageOsDisk.OsState = osState;
            imageOsDisk.OsType = OperatingSystemTypes.Linux;
            imageOsDisk.ManagedDisk = new SubResource()
            {
                Id = sourceManagedDiskId
            };
            return this;
        }

        ///GENMHASH:F40AACF05EEBCEC01371839C967AF08E:83720436CA6F52E320BEC17AA5E2BE07
        public VirtualMachineCustomImageImpl WithLinuxFromDisk(IDisk sourceManagedDisk, OperatingSystemStateTypes osState)
        {
            return WithLinuxFromDisk(sourceManagedDisk.Id, osState);
        }

        ///GENMHASH:39A9E5FEDDAB9A28D94661C485694A9F:D1E45B4D74F91292BC482E8EF055C28A
        public VirtualMachineCustomImageImpl WithDataDiskImageFromManagedDisk(string sourceManagedDiskId)
        {
            this.DefineDataDiskImage()
                .WithLun(-1)
                .FromManagedDisk(sourceManagedDiskId)
                .Attach();
            return this;
        }

        ///GENMHASH:85A9EE879E1162FDFB3C363C1B28127D:28C2E30A2CCDD7B839CA62E5E108441F
        public VirtualMachineCustomImageImpl WithDataDiskImageFromSnapshot(string sourceSnapshotId)
        {
            this.DefineDataDiskImage()
                .WithLun(-1)
                .FromSnapshot(sourceSnapshotId)
                .Attach();
            return this;
        }

        ///GENMHASH:9E984BEB4133DD0B3AA842B63D7D77AC:1C3F555F09D9102CFCAD04ADC6BBFE42
        public ImageOSDisk OsDiskImage()
        {
            if (Inner.StorageProfile == null) {
                return null;
            }
            return Inner.StorageProfile.OsDisk;
        }

        ///GENMHASH:AD43D1605284BA4522153DD29AFF8D8B:7D4D98F4B0CD177EAA3A94285F340953
        public VirtualMachineCustomImageImpl WithWindowsFromVhd(string sourceVhdUrl, OperatingSystemStateTypes osState)
        {
            var imageOsDisk = this.EnsureOsDiskImage();
            imageOsDisk.OsState = osState;
            imageOsDisk.OsType = OperatingSystemTypes.Windows;
            imageOsDisk.BlobUri = sourceVhdUrl;
            return this;
        }

        ///GENMHASH:A9B6728240A4B95433E54D7F2431D575:B65391AF61655CEE129B6EA0A26BC818
        public VirtualMachineCustomImageImpl FromVirtualMachine(string virtualMachineId)
        {
            Inner.SourceVirtualMachine = new SubResource()
            {
                Id = virtualMachineId
            };
            return this;
        }

        ///GENMHASH:39D442D903ADE78FB2397B6E0BC2D909:E3787ED9F29D3287F8DEBD116F7E5864
        public VirtualMachineCustomImageImpl FromVirtualMachine(IVirtualMachine virtualMachine)
        {
            return this.FromVirtualMachine(virtualMachine.Id);
        }

        ///GENMHASH:3B053B65EFD7AC679AEB5F6225138946:0495B2B792DD2C108EA88C32EEDB5E1B
        public VirtualMachineCustomImageImpl WithWindowsFromSnapshot(string sourceSnapshotId, OperatingSystemStateTypes osState)
        {
            var imageOsDisk = this.EnsureOsDiskImage();
            imageOsDisk.OsState = osState;
            imageOsDisk.OsType = OperatingSystemTypes.Windows;
            imageOsDisk.Snapshot = new SubResource()
            {
                Id = sourceSnapshotId
            };
            return this;
        }

        ///GENMHASH:08AE63BC7FCA79E69D620127098720E9:930E356C2CDF0BE3E37BE468FC02BF79
        public VirtualMachineCustomImageImpl WithWindowsFromSnapshot(ISnapshot sourceSnapshot, OperatingSystemStateTypes osState)
        {
            return this.WithWindowsFromSnapshot(sourceSnapshot.Id, osState);
        }

        ///GENMHASH:333EAA45B1D1CC338A9F5F2890D1FCF7:3D915441151BB98BE34814C400261E58
        public string SourceVirtualMachineId()
        {
            if (Inner.SourceVirtualMachine == null) {
                return null;
            }
            return Inner.SourceVirtualMachine.Id;
        }

        ///GENMHASH:1C7A9AF7A9A2B672155EEEF5F6420E08:03573333EBFDEDB75330E6D42BEFE5F3
        internal VirtualMachineCustomImageImpl WithCustomImageDataDisk(CustomImageDataDiskImpl customImageDataDisk)
        {
            if (Inner.StorageProfile == null) {
                Inner.StorageProfile = new ImageStorageProfile();
            }
            if (Inner.StorageProfile.DataDisks == null) {
                Inner.StorageProfile.DataDisks = new List<ImageDataDisk>();
            }
            Inner.StorageProfile.DataDisks.Add(customImageDataDisk.Inner);
            return this;
        }

        ///GENMHASH:6F1E3BE4AB7D8C34567FE15B20B16EAF:420419EBE6CD60053DC391B80B4294E8
        private void EnsureDefaultLuns()
        {
            if (Inner.StorageProfile != null
                && Inner.StorageProfile.DataDisks != null) {
                var imageDisks = Inner.StorageProfile.DataDisks;
                var usedLuns = new HashSet<int>();
                foreach(var imageDisk in imageDisks)  {
                    if (imageDisk.Lun != -1) {
                        usedLuns.Add(imageDisk.Lun);
                    }
                }
                if (usedLuns.Count == imageDisks.Count) {
                    return;
                }
                foreach(var imageDisk in imageDisks)  {
                    if (imageDisk.Lun != -1) {
                        continue;
                    }
                    int i = 0;
                    while (usedLuns.Contains(i)) {
                        i++;
                    }
                    imageDisk.Lun = i;
                    usedLuns.Add(i);
                }
            }
        }

        ///GENMHASH:467A5E1DBEFF6DFFFD3FD21A958498A3:C71F36C1B0B9950F5EC79B4A234987CC
        public IReadOnlyDictionary<int, Models.ImageDataDisk> DataDiskImages()
        {
            if (Inner.StorageProfile == null || Inner.StorageProfile.DataDisks == null) {
                return new Dictionary<int, ImageDataDisk>();
            }
            Dictionary<int, ImageDataDisk> diskImages = new Dictionary<int, ImageDataDisk>();
            foreach(var dataDisk in Inner.StorageProfile.DataDisks)  {
                diskImages.Add(dataDisk.Lun, dataDisk);
            }
            return diskImages;
        }

        ///GENMHASH:F6E3577574DD9BBB65B312D78461CDF4:8390A7C04DC74112B8FBA74388AF9C57
        public VirtualMachineCustomImageImpl WithLinuxFromSnapshot(string sourceSnapshotId, OperatingSystemStateTypes osState)
        {
            var imageOsDisk = this.EnsureOsDiskImage();
            imageOsDisk.OsState = osState;
            imageOsDisk.OsType = OperatingSystemTypes.Linux;
            imageOsDisk.Snapshot = new SubResource()
            {
                Id = sourceSnapshotId
            };
            return this;
        }

        ///GENMHASH:317134690AC492A13AB6664204ABFD95:2CD52FED9DD80D3ACA7A05FE17CBFC89
        public VirtualMachineCustomImageImpl WithLinuxFromSnapshot(ISnapshot sourceSnapshot, OperatingSystemStateTypes osState)
        {
            return this.WithLinuxFromSnapshot(sourceSnapshot.Id, osState);
        }

        ///GENMHASH:0202A00A1DCF248D2647DBDBEF2CA865:C8D15C8E118FE252D0C33A0277604CB7
        public override async Task<IVirtualMachineCustomImage> CreateResourceAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            EnsureDefaultLuns();
            var imageInner = await Manager.Inner.Images.CreateOrUpdateAsync(ResourceGroupName, Name, Inner);
            SetInner(imageInner);
            return this;
        }

        ///GENMHASH:E625C1F29CDEA4A229F9F716CB068DE5:C82C3D88AD1345B17C97817FCB05C6D8
        private ImageOSDisk EnsureOsDiskImage()
        {
            if (Inner.StorageProfile == null) {
                Inner.StorageProfile = new ImageStorageProfile();
            }
            if (Inner.StorageProfile.OsDisk == null) {
                Inner
                    .StorageProfile
                    .OsDisk = new ImageOSDisk();
            }
            return Inner.StorageProfile.OsDisk;
        }
    }
}
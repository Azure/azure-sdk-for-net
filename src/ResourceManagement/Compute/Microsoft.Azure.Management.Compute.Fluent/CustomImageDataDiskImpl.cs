// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Compute.Fluent
{
    using Models;
    using VirtualMachineCustomImage;
    using VirtualMachineCustomImage.CustomImageDataDisk.Definition;
    using ResourceManager.Fluent.Core;
    using ResourceManager.Fluent;

    /// <summary>
    /// The implementation for VirtualMachineCustomImage.CustomImageDataDisk.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmNvbXB1dGUuaW1wbGVtZW50YXRpb24uQ3VzdG9tSW1hZ2VEYXRhRGlza0ltcGw=
    internal partial class CustomImageDataDiskImpl :
        ChildResource<
            ImageDataDisk, 
            VirtualMachineCustomImageImpl,
            IVirtualMachineCustomImage>,
        ICustomImageDataDisk,
        IDefinition<VirtualMachineCustomImage.Definition.IWithCreateAndDataDiskImageOSDiskSettings>
    {
        ///GENMHASH:AC3A90103821E89724D7B8998CD3FE4A:C0847EA0CDA78F6D91EFD239C70F0FA7
        internal CustomImageDataDiskImpl(ImageDataDisk inner, VirtualMachineCustomImageImpl parent) : base(inner, parent)
        {
        }

        ///GENMHASH:D0B4FABB64DACD41B9CAAC16C298BBE1:C0A2DA398CBB044A81E11595D53C422E
        public CustomImageDataDiskImpl FromManagedDisk(string sourceManagedDiskId)
        {
            Inner.ManagedDisk = new SubResource()
            {
                Id = sourceManagedDiskId
            };
            return this;
        }

        ///GENMHASH:19379144AF0027E31705C491BF01DE93:BE96FC435877454BE586D579141E15DA
        public CustomImageDataDiskImpl FromManagedDisk(IDisk sourceManagedDisk)
        {
            Inner.ManagedDisk = new SubResource()
            {
                Id = sourceManagedDisk.Id
            };
            return this;
        }

        ///GENMHASH:3E38805ED0E7BA3CAEE31311D032A21C:57DB4AF5CAF84DCDAF67B8AE5BBF9A70
        public override string Name()
        {
            return string.Format("%d", Inner.Lun);
        }

        ///GENMHASH:882CBC438050DF11EA9106685AC96492:7A9F6C9AAA328B01C869D7E73483A30C
        public CustomImageDataDiskImpl WithDiskSizeInGB(int diskSizeGB)
        {
            Inner.DiskSizeGB = diskSizeGB;
            return this;
        }

        ///GENMHASH:84D34B069F2841504AA1DE676FBF7143:54AEB1FA4318E2287B56DE751B25DB84
        public CustomImageDataDiskImpl WithDiskCaching(CachingTypes cachingType)
        {
            Inner.Caching = cachingType;
            return this;
        }

        ///GENMHASH:13EC56EC56A0CEA1ECD6EA3EA38EB40F:D3A7D61EDBE1631F4C5B0CD3CCDF840C
        public CustomImageDataDiskImpl WithLun(int lun)
        {
            Inner.Lun = lun;
            return this;
        }

        ///GENMHASH:20127E6A8A1B4B28CE511AEB479A6C9A:F7453FD460F528C36BFEB3F905E4CCEF
        public CustomImageDataDiskImpl FromVhd(string sourceVhdUrl)
        {
            Inner.BlobUri = sourceVhdUrl;
            return this;
        }

        ///GENMHASH:077EB7776EFFBFAA141C1696E75EF7B3:2BA83F380103FA104C2E7DA546CF60B6
        public VirtualMachineCustomImageImpl Attach()
        {
            return Parent.WithCustomImageDataDisk(this);
        }

        ///GENMHASH:8D34B63403FF8A31ACD1E973BFBE7F09:7432CF6CED181EEFBBE1AEC96A1146E1
        public CustomImageDataDiskImpl FromSnapshot(string sourceSnapshotId)
        {
            Inner.Snapshot = new SubResource()
            {
                Id = sourceSnapshotId
            };
            return this;
        }
    }
}
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.ResourceManager.Compute.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Compute.Tests.Unit
{
    public class DiskControllerTypeTests
    {
        [Test]
        public void CanClearLegacyDiskControllerTypeOnStorageProfile()
        {
            var profile = new VirtualMachineScaleSetStorageProfile { DiskControllerType = "SCSI" };
            Assert.AreEqual(DiskControllerType.Scsi, profile.DiskControllerKind);

            profile.DiskControllerType = null;

            Assert.IsNull(profile.DiskControllerKind);
            Assert.IsNull(profile.DiskControllerType);
        }

        [Test]
        public void CanClearLegacyDiskControllerTypeOnUpdateStorageProfile()
        {
            var profile = new VirtualMachineScaleSetUpdateStorageProfile { DiskControllerType = "NVMe" };
            Assert.AreEqual(DiskControllerType.NVMe, profile.DiskControllerKind);

            profile.DiskControllerType = null;

            Assert.IsNull(profile.DiskControllerKind);
            Assert.IsNull(profile.DiskControllerType);
        }

        [Test]
        public void CanClearDiskControllerKindWithNullString()
        {
            var profile = new VirtualMachineScaleSetStorageProfile { DiskControllerKind = "SCSI" };
            Assert.AreEqual(DiskControllerType.Scsi, profile.DiskControllerKind);

            string diskControllerType = null;
            profile.DiskControllerKind = diskControllerType;

            Assert.IsNull(profile.DiskControllerKind);
        }
    }
}

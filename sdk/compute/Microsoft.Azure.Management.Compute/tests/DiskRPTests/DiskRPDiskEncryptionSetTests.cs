using System;
using System.Collections.Generic;
using System.Text;
using Compute.Tests.DiskRPTests;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace Compute.Tests.DiskRPTests
{
    public class DiskRPDiskEncryptionSetTests : DiskRPTestsBase
    {
        private static string supportedZoneLocation = "centraluseuap";

        [Fact]
        public void DiskEncryptionSet_CRUD()
        {
            DiskEncryptionSet_CRUD_Execute("DiskEncryptionSet_CRUD", EncryptionType.EncryptionAtRestWithCustomerKey, location: supportedZoneLocation);
        }

        [Fact]
        public void DiskEncryptionSet_CRUD_EncryptionWithPlatformAndCustomerKeys()
        {
            DiskEncryptionSet_CRUD_Execute("DiskEncryptionSet_CRUD_EncryptionWithPlatformAndCustomerKeys", EncryptionType.EncryptionAtRestWithPlatformAndCustomerKeys, location: supportedZoneLocation);
        }

        [Fact]
        public void DiskEncryptionSet_List()
        {
            DiskEncryptionSet_List_Execute("DiskEncryptionSet_List", location: supportedZoneLocation);
        }

        [Fact]
        public void DiskEncryptionSet_CreateDisk()
        {
            DiskEncryptionSet_CreateDisk_Execute("DiskEncryptionSet_CreateDisk", location: supportedZoneLocation);
        }

        [Fact]
        public void DiskEncryptionSet_AddDESToExistingDisk()
        {
            DiskEncryptionSet_UpdateDisk_Execute("DiskEncryptionSet_AddDESToExistingDisk", location: supportedZoneLocation);
        }
    }
}

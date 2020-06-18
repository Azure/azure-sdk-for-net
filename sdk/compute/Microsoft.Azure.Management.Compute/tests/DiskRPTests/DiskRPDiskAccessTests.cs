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
    public class DiskRPDiskAccessTests : DiskRPTestsBase
    {
        private static string supportedZoneLocation = "centraluseuap";

        [Fact]
        public void DiskAccess_CRUD()
        {
            DiskAccess_CRUD_Execute("DiskAccess_CRUD", location: supportedZoneLocation);
        }

        [Fact(Skip = "TODO: Wait for Microsoft.Azure.Management.Network dll upgrade")]
        public void DiskAccess_WithPrivateEndpoint_CRUD()
        {
            DiskAccess_WithPrivateEndpoint_CRUD_Execute("DiskAccess_WithPrivateEndpoint_CRUD", location: supportedZoneLocation);
        }

        [Fact]
        public void DiskAccess_List()
        {
            DiskAccess_List_Execute("DiskAccess_List", location: supportedZoneLocation);
        }

        [Fact]
        public void DiskAccess_CreateDisk()
        {
            DiskAccess_CreateDisk_Execute("DiskAccess_CreateDisk", location: supportedZoneLocation);
        }

        [Fact]
        public void DiskAccess_AddDiskAccessToExistingDisk()
        {
            DiskAccess_UpdateDisk_Execute("DiskAccess_AddDiskAccessToExistingDisk", location: supportedZoneLocation);
        }

        [Fact]
        public void DiskAccess_RemoveDiskAccessFromExistingDisk()
        {
            DiskAccess_UpdateDisk_RemoveDiskAccess_Execute("DiskAccess_RemoveDiskAccessFromExistingDisk", location: supportedZoneLocation);
        }
    }
}

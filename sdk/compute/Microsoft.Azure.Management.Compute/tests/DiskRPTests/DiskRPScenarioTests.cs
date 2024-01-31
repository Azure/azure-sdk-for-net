// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Compute.Models;
using System.Collections.Generic;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace Compute.Tests.DiskRPTests
{
    public class DiskRPScenarioTests : DiskRPTestsBase
    {
        [Fact]
        public void Disk_CRUD_EmptyDisk()
        {
            Disk_CRUD_Execute(DiskCreateOption.Empty, "Disk_CRUD_EmptyDisk", diskSizeGB: 5);
        }

        [Fact]
        public void Disk_CRUD_EmptyDisk_Zones()
        {
            string supportedZoneLocation = "eastus2";
            Disk_CRUD_Execute(DiskCreateOption.Empty, "Disk_CRUD_EmptyDisk_Zones", diskSizeGB: 5, location: supportedZoneLocation, zones: new List<string> { "1" });
        }

        [Fact]
        public void Disk_CRUD_ImportDisk()
        {
            Disk_CRUD_Execute(DiskCreateOption.Import, "Disk_CRUD_ImportDisk", diskSizeGB: 150, location: "eastus2");
        }

        [Fact]
        public void Disk_CRUD_PremiumDiskWithTier()
        {
            PremiumDisk_CRUD_Execute(DiskCreateOption.Empty, "Disk_CRUD_PremiumDiskWithTier", diskSizeGB: 32, tier: "P4", location: "eastus2euap");
        }

        [Fact]
        public void Disk_CRUD_PremiumZRSDisk()
        {
            SSDZRSDisk_CRUD_Execute(DiskCreateOption.Empty, StorageAccountTypes.PremiumZRS, "Disk_CRUD_PremiumZRSDisk", diskSizeGB: 32, tier: "P4", location: "eastus2euap");
        }

        [Fact]
        public void Disk_CRUD_StandardSSDZRSDisk()
        {
            SSDZRSDisk_CRUD_Execute(DiskCreateOption.Empty, StorageAccountTypes.StandardSSDZRS, "Disk_CRUD_StandardSSDZRSDisk", diskSizeGB: 32, location: "eastus2euap");
        }
        
        [Fact]
        public void Disk_CRUD_PremiumDiskWithBursting()
        {
            PremiumDisk_CRUD_Execute(DiskCreateOption.Import, "Disk_CRUD_PremiumDiskWithBursting", tier: "P30", diskSizeGB: 1024, burstingEnabled: true, location: "eastus2euap");
        }

        [Fact]
        public void Disk_CRUD_PerformancePlusDiskWithBursting()
        {
            PremiumDisk_CRUD_Execute(DiskCreateOption.Empty, "Disk_CRUD_PerformancePlusDiskWithBursting", tier: "P30", diskSizeGB: 1024, burstingEnabled: true, location: "eastus2euap", isPerformancePlus : true);
        }

        [Fact]
        public void Snapshot_CRUD_EmptyDisk()
        {
            Snapshot_CRUD_Execute(DiskCreateOption.Empty, "Snapshot_CRUD_EmptyDisk", diskSizeGB: 5, location: "eastus2");
        }

        [Fact]
        public void IncrementalSnapshot_CRUD_EmptyDisk()
        {
            Snapshot_CRUD_Execute(DiskCreateOption.Empty, "IncrementalSnapshot_CRUD_EmptyDisk", diskSizeGB: 5, incremental: true, location: "centraluseuap");
        }

        [Fact]
        public void Snapshot_CRUD_WithSecurityType()
        {
            Snapshot_CRUD_WithSecurityType_Execute("Snapshot_CRUD_WithSecurityType", location: "eastus2");
        }

        [Fact]
        public void Snapshot_CRUD_WithAcceleratedNetwork()
        {
            Snapshot_CRUD_WithAcceleratedNetwork_Execute(DiskCreateOption.Empty, "Snapshot_CRUD_WithAcceleratedNetwork", diskSizeGB: 5, location: "eastus2");
        }

        [Fact]
        public void Disk_List_EmptyDisk()
        {
            Disk_List_Execute(DiskCreateOption.Empty, "Disk_List_EmptyDisk", diskSizeGB: 5);
        }

        [Fact]
        public void Disk_List_ImportDisk()
        {
            Disk_List_Execute(DiskCreateOption.Import, "Disk_List_ImportDisk", diskSizeGB: 150, location: "eastus2");
        }

        [Fact]
        public void Snapshot_List_EmptyDisk()
        {
            Snapshot_List_Execute(DiskCreateOption.Empty, "Snapshot_List_EmptyDisk", diskSizeGB: 5);
        }

        [Fact]
        public void Disk_CRUD_WithSecurityProfile_Import()
        {
            Disk_CRUD_WithSecurityProfile_Execute(DiskCreateOption.Import, "Disk_CRUD_WithSecurityProfile_Import", location: "centraluseuap");
        }
        [Fact]
        public void Disk_CRUD_WithSupportsHibernationFlag_EmptyDisk()
        {
            Disk_CRUD_WithSupportsHibernationFlag_Execute(DiskCreateOption.Empty, "Disk_CRUD_WithSupportsHibernationFlag_EmptyDisk", diskSizeGB: 5);
        }

        [Fact]
        public void Disk_CRUD_WithAcceleratedNetworking_EmptyDisk()
        {
            Disk_CRUD_WithAcceleratedNetworking_Execute(DiskCreateOption.Empty, "Disk_CRUD_WithAcceleratedNetworking_EmptyDisk", diskSizeGB: 5);
        }

        [Fact]
        public void Disk_CRUD_WithPurchasePlan_EmptyDisk()
        {
            Disk_CRUD_WithPurchasePlan_Execute(DiskCreateOption.Empty, "Disk_CRUD_WithPurchasePlan_EmptyDisk", diskSizeGB: 5);
        }

        [Fact]
        public void Disk_CRUD_WithArchitecture_EmptyDisk()
        {
            Disk_CRUD_WithArchitecture_Execute(DiskCreateOption.Empty, "Disk_CRUD_WithArchitecture_EmptyDisk", diskSizeGB: 5);
        }

        [Fact(Skip = "operation not supported in region")]
        public void Disk_CRUD_WithDiskControllerType()
        {
            Disk_CRUD_WithDiskControllerType_Execute(DiskCreateOption.Empty, "Disk_CRUD_WithDiskControllerType", diskSizeGB: 5);
        }

        [Fact(Skip = "Operation not supported in region")]
        public void Disk_CRUD_OptimizeFrequentAttach()
        {
            Disk_OptimizeFrequentAttach_Execute(DiskCreateOption.Empty, "Disk_CRUD_OptimizeFrequentAttach", diskSizeGB: 32, location: "eastus2euap");
        }
    }
}

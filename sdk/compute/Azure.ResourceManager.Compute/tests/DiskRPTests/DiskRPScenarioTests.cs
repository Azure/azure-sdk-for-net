// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.ResourceManager.Compute.Models;
using NUnit.Framework;
namespace Azure.ResourceManager.Compute.Tests.DiskRPTests
{
    public class DiskRPScenarioTests : DiskRPTestsBase
    {
        public DiskRPScenarioTests(bool isAsync)
        : base(isAsync)
        {
        }

        [Test]
        public async Task Disk_CRUD_EmptyDisk()
        {
            await Disk_CRUD_Execute(DiskCreateOption.Empty.ToString(), "Disk_CRUD_EmptyDisk", diskSizeGB: 5);
        }

        [Test]
        public async Task Disk_CRUD_EmptyDisk_Zones()
        {
            string supportedZoneLocation = "eastus2";
            await Disk_CRUD_Execute(DiskCreateOption.Empty.ToString(), "Disk_CRUD_EmptyDisk_Zones", diskSizeGB: 5, location: supportedZoneLocation, zones: new List<string> { "1" });
        }

        [Test]
        public async Task Disk_CRUD_ImportDisk()
        {
            await Disk_CRUD_Execute(DiskCreateOption.Import.ToString(), "Disk_CRUD_ImportDisk", diskSizeGB: 150, location: "eastus2");
        }

        [Test]
        public async Task Snapshot_CRUD_EmptyDisk()
        {
            await Snapshot_CRUD_Execute(DiskCreateOption.Empty.ToString(), "Snapshot_CRUD_EmptyDisk", diskSizeGB: 5, location: "eastus2");
        }

        [Test]
        public async Task IncrementalSnapshot_CRUD_EmptyDisk()
        {
            await Snapshot_CRUD_Execute(DiskCreateOption.Empty.ToString(), "IncrementalSnapshot_CRUD_EmptyDisk", diskSizeGB: 5, incremental: true, location: "southeastasia");
        }

        [Test]
        public async Task Disk_List_EmptyDisk()
        {
            await Disk_List_Execute(DiskCreateOption.Empty.ToString(), "Disk_List_EmptyDisk", diskSizeGB: 5);
        }

        [Test]
        public async Task Disk_List_ImportDisk()
        {
            await Disk_List_Execute(DiskCreateOption.Import.ToString(), "Disk_List_ImportDisk", diskSizeGB: 150, location: "eastus2");
        }

        [Test]
        public async Task Snapshot_List_EmptyDisk()
        {
            await Snapshot_List_Execute(DiskCreateOption.Empty.ToString(), "Snapshot_List_EmptyDisk", diskSizeGB: 5);
        }
    }
}

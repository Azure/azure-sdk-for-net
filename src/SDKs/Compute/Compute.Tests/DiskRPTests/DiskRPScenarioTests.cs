// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Compute.Models;
using System.Collections.Generic;
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
            Disk_CRUD_Execute(DiskCreateOption.Import, "Disk_CRUD_ImportDisk", diskSizeGB: 150);
        }

        [Fact]
        public void Snapshot_CRUD_EmptyDisk()
        {
            Snapshot_CRUD_Execute(DiskCreateOption.Empty, "Snapshot_CRUD_EmptyDisk", diskSizeGB: 5);
        }

        [Fact]
        public void Disk_List_EmptyDisk()
        {
            Disk_List_Execute(DiskCreateOption.Empty, "Disk_List_EmptyDisk", diskSizeGB: 5);
        }

        [Fact]
        public void Disk_List_ImportDisk()
        {
            Disk_List_Execute(DiskCreateOption.Import, "Disk_List_ImportDisk", diskSizeGB: 150);
        }

        [Fact]
        public void Snapshot_List_EmptyDisk()
        {
            Snapshot_List_Execute(DiskCreateOption.Empty, "Snapshot_List_EmptyDisk", diskSizeGB: 5);
        }
    }
}
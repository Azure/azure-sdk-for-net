// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Compute.Models;
using Xunit;

namespace Compute.Tests.DiskRPTests
{
    public class DiskRPScenarioTests : DiskRPTestsBase
    {
        [Fact]
        public void Disk_CRUD_EmptyDisk()
        {
            Disk_CRUD_Execute(DiskCreateOption.Empty, diskSizeGB: 5);
        }

        [Fact]
        public void Snapshot_CRUD_EmptyDisk()
        {
            Snapshot_CRUD_Execute(DiskCreateOption.Empty, diskSizeGB: 5);
        }

        [Fact]
        public void Disk_List_EmptyDisk()
        {
            Disk_List_Execute(DiskCreateOption.Empty, diskSizeGB: 5);
        }

        [Fact]
        public void Snapshot_List_EmptyDisk()
        {
            Snapshot_List_Execute(DiskCreateOption.Empty, diskSizeGB: 5);
        }
    }
}
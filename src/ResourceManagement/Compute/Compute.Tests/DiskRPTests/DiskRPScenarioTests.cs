//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

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
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

using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.WindowsAzure.Testing;

namespace Microsoft.WindowsAzure.Management.Testing
{
    using System;
    using System.Linq;
    using Management;
    using Management.Models;
    using Microsoft.Azure.Test;
    using Xunit;

    public class ManagementReproTests : TestBase
    {
        [Fact]
        public void CanListRoleSizeInfo()
        {
            using (var undoContext = UndoContext.Current)
            {
                undoContext.Start();

                string affinityGroupName = HttpMockServer.GetAssetName("CanListRoleSizeInfo", "testag");

                var mgmt = this.GetManagementClient();

                var roleSizeList = mgmt.RoleSizes.List();

                foreach (var loc in mgmt.Locations.List())
                {
                    Assert.True(loc.ComputeCapabilities != null);

                    Assert.True(loc.ComputeCapabilities.VirtualMachinesRoleSizes.Any());
                    foreach (var r in loc.ComputeCapabilities.VirtualMachinesRoleSizes)
                    {
                        Assert.True(roleSizeList.Any(s => string.Equals(r, s.Name, StringComparison.OrdinalIgnoreCase)));
                    }

                    Assert.True(loc.ComputeCapabilities.WebWorkerRoleSizes.Any());
                    foreach (var r in loc.ComputeCapabilities.WebWorkerRoleSizes)
                    {
                        Assert.True(roleSizeList.Any(s => string.Equals(r, s.Name, StringComparison.OrdinalIgnoreCase)));
                    }

                    Assert.True(loc.StorageCapabilities.StorageAccountTypes.Any());
                    Assert.True(loc.StorageCapabilities.StorageAccountTypes.Any(
                        s => string.Equals("Standard_LRS", s, StringComparison.OrdinalIgnoreCase)));
                    Assert.True(loc.StorageCapabilities.StorageAccountTypes.Any(
                        s => string.Equals("Standard_GRS", s, StringComparison.OrdinalIgnoreCase)));
                    Assert.True(loc.StorageCapabilities.StorageAccountTypes.Any(
                        s => string.Equals("Standard_RAGRS", s, StringComparison.OrdinalIgnoreCase)));
                    Assert.True(loc.StorageCapabilities.StorageAccountTypes.Any(
                        s => string.Equals("Standard_ZRS", s, StringComparison.OrdinalIgnoreCase)));
                }

                var locName = mgmt.Locations.List().First().Name;
                var agParam = new AffinityGroupCreateParameters
                {
                    Name = affinityGroupName,
                    Label = affinityGroupName + "Label",
                    Description = affinityGroupName + "Description",
                    Location = locName
                };
                mgmt.AffinityGroups.Create(agParam);

                var agGetResult = mgmt.AffinityGroups.Get(affinityGroupName);
                Assert.True(agGetResult.Name.Equals(agParam.Name));
                Assert.True(agGetResult.Label.Equals(agParam.Label));
                Assert.True(agGetResult.Description.Equals(agParam.Description));
                Assert.True(agGetResult.Location.Equals(agParam.Location));

                var ag = mgmt.AffinityGroups.List().First(g => g.Name.Equals(affinityGroupName));

                Assert.True(ag.ComputeCapabilities != null);

                Assert.True(ag.ComputeCapabilities.VirtualMachinesRoleSizes.Any());
                foreach (var r in ag.ComputeCapabilities.VirtualMachinesRoleSizes)
                {
                    Assert.True(roleSizeList.Any(s => string.Equals(r, s.Name, StringComparison.OrdinalIgnoreCase)));
                }

                Assert.True(ag.ComputeCapabilities.WebWorkerRoleSizes.Any());
                foreach (var r in ag.ComputeCapabilities.WebWorkerRoleSizes)
                {
                    Assert.True(roleSizeList.Any(s => string.Equals(r, s.Name, StringComparison.OrdinalIgnoreCase)));
                }
            }
        }
    }
}

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

using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Linq;
using Xunit;

namespace Microsoft.Azure.Management.RecoveryServices.Tests
{
    public class VaultUsageScenarioTests : TestBase
    {
        [Fact]
        public void RetrieveVaultUsages()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                using (RecoveryServicesTestBase _testFixture = new RecoveryServicesTestBase(context))
                {
                    string vaultName = VaultDefinition.TestCrud.VaultName;

                    _testFixture.CreateVault(vaultName);
                    var vault = _testFixture.GetVault(vaultName);
                    Assert.NotNull(vault);

                    var vaults = _testFixture.ListVaults();
                    Assert.NotNull(vaults);
                    Assert.NotEmpty(vaults);
                    Assert.Contains(vaults, v => v.Name == vaultName);

                    var response = _testFixture.ListVaultUsages(vaultName);

                    Assert.NotNull(response);
                    Assert.NotEmpty(response);
                    foreach (var usage in response)
                    {
                        Assert.NotNull(usage.Name.Value);
                        Assert.NotNull(usage.Unit);
                        Assert.NotNull(usage.CurrentValue);
                        Assert.NotNull(usage.Limit);
                    }

                    var replicationResponse = _testFixture.ListReplicationUsages(vaultName);

                    Assert.NotNull(replicationResponse);
                    Assert.Empty(replicationResponse);
                }
            }
        }
    }
}


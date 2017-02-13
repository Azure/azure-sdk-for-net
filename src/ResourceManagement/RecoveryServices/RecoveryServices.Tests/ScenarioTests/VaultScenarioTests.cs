// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Linq;
using Xunit;

namespace Microsoft.Azure.Management.RecoveryServices.Tests
{
    public class VaultScenarioTests : TestBase
    {
        [Fact]
        public void CanCreateGetListDeleteVaultTest()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                using (RecoveryServicesTestBase _testFixture = new RecoveryServicesTestBase(context))
                {
                    string vaultName = VaultDefinition.TestCrud.VaultName;
                    string vaultName2 = VaultDefinition.TestList.VaultName;

                    _testFixture.CreateVault(vaultName);
                    var vault = _testFixture.GetVault(vaultName);
                    Assert.NotNull(vault);

                    _testFixture.CreateVault(vaultName2);
                    var vaults = _testFixture.ListVaults();
                    Assert.NotNull(vaults);
                    Assert.NotEmpty(vaults);
                    Assert.True(vaults.Any(v => v.Name == vaultName));
                    Assert.True(vaults.Any(v => v.Name == vaultName2));

                    _testFixture.DeleteVault(vaultName2);
                    Assert.Throws<CloudException>(() =>
                    {
                        _testFixture.GetVault(vaultName2);
                    });
                }
            }
        }
    }
}

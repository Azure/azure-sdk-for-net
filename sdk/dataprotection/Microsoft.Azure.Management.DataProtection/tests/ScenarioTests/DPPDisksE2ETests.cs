using Microsoft.Azure.Management.DataProtection.Backup.Tests.TestHelpers;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using Xunit;

namespace Microsoft.Azure.Management.DataProtection.Backup.Tests.ScenarioTests
{
    public class DPPDisksE2ETests : TestBase, IDisposable
    {
        private const string TestVault = "DiskbackupVault1";
        private const string TestVaultRg = "mayaggarDiskRG";

        [Fact]
        public void DisksE2ETests()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            using (TestHelper testHelper = new TestHelper() { VaultName = TestVault, ResourceGroup = TestVaultRg })
            {
                testHelper.Initialize(context);
                testHelper.CreatePolicy("retentionpolicy2");
                testHelper.ValidateForBackup("TestDiskCmk2");
                testHelper.CreateBackupInstance("TestDiskCmk2");
            }
        }
        public void Dispose()
        {
        }
    }
}

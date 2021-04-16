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
                // initilizing test context
                testHelper.Initialize(context);

                // Create Backup vault
                testHelper.CreateVault();

                // Get Backup Vault
                //testHelper.GetVault();

                // Create Policy
                testHelper.CreatePolicy("retentionpolicy2");

                // Get Policy
                //testHelper.GetPolicy("retentionpolicy2");
                
                // Configure Backup
                //testHelper.CreateBackupInstance("TestDiskCmk2");

                // Validate For Backup
                //testHelper.ValidateForBackup("TestDiskCmk2");

                // Trigger Backup
                //testHelper.TriggerBackup("TestDiskCmk2");

                // Validate for Restore
                //testHelper.ValidateForRestore("TestDiskCmk2");

                // Trigger Restore
                //testHelper.TriggerRestore("TestDiskCmk2");
            }
        }
        public void Dispose()
        {
        }
    }
}

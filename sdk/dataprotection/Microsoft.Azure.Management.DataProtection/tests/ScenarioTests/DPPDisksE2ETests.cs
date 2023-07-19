using Microsoft.Azure.Management.DataProtection.Backup.Tests.TestHelpers;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using Xunit;

namespace Microsoft.Azure.Management.DataProtection.Backup.Tests.ScenarioTests
{
    public class DPPDisksE2ETests : TestBase, IDisposable
    {
        private const string TestVault = "DiskbackupVault2";
        private const string TestVaultRg = "mayaggarDiskRG";
        private const string testBackupInstance = "testingDisk";
        private const string testPolicy = "retentionpolicy2";

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
                testHelper.GetVault();

                // Create Policy
                testHelper.CreatePolicy(testPolicy);

                // Get Policy
                testHelper.GetPolicy(testPolicy);

                // Validate For Backup
                testHelper.ValidateForBackup();

                // Configure Backup
                testHelper.CreateBackupInstance();

                // Trigger Backup
                testHelper.TriggerBackup(testBackupInstance);

                // Validate for Restore
                testHelper.ValidateForRestore(testBackupInstance);

                // Trigger Restore
                testHelper.TriggerRestore(testBackupInstance);
                
            }
        }
        public void Dispose()
        {
        }
    }
}

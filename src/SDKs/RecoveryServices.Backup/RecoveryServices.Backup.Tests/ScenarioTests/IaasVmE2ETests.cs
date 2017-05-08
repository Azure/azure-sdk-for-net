// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace Microsoft.Azure.Management.RecoveryServices.Backup.Tests
{
    /// <summary>
    /// In order to run the tests in Record mode, some test artifacts need to be created manually. Here are the details:
    /// 1. Resource Group - Any permissible name is allowed.
    /// 2. Azure VM: any size, version, created in the above resource group.
    /// 3. Resource Group for Storage Account - Any permissible name is allowed.
    /// 4. Storage Account: any configuration, but should be of the same version of the above VM, created in the resource group specified for the storage account. 
    ///    This will be used for the restore operation.
    /// NOTE: Region should preferably be West US. Otherwise, it should be in the same region as the test vault being created.
    /// 
    /// These details need to be updated in the TestSettings.json file. A sample is given here:
    /// 
    /// {
    /// "VirtualMachineName": "pstestv2vm1",
    /// "VirtualMachineResourceGroupName": "pstestrg",
    /// "VirtualMachineType": "Compute",
    /// "RestoreStorageAccountName": "pstestrg4762",
    /// "RestoreStorageAccountResourceGroupName": "pstestrg"
    /// }
    /// 
    /// Here, if the VM is a Classic Compute VM, set VirtualMachineType as "Classic" and if it is a Compute VM, set VirtualMachineType as "Compute"
    /// </summary>
    public class IaasVmE2ETests : TestBase, IDisposable
    {

        [Fact]
        public void IaasVmE2ETest()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            using(var testHelper = new TestHelper())
            {
                testHelper.Initialize(context);

                var containerUniqueName = BackupDefinition.TestCrud.VmDefinition.ContainerUniqueName;
                var containerName = BackupDefinition.TestCrud.VmDefinition.ContainerName;
                var itemName = BackupDefinition.TestCrud.VmDefinition.ItemName;
                var policyName = BackupDefinition.TestCrud.PolicyName;
                var storageAccountId = BackupDefinition.TestCrud.VmDefinition.RestoreStorageAccount
                    .GetStorageAccountId(testHelper.BackupClient.SubscriptionId);

                // 1. Enable protection
                testHelper.EnableProtection(containerName, itemName, policyName);
                
                // 2. List protected items
                var items = testHelper.ListProtectedItems();
                Assert.NotNull(items);
                Assert.True(items.Any(item => itemName.Contains(item.Name.ToLower())));

                // 3. Trigger backup
                var backupJobId = testHelper.Backup(containerName, itemName);
                testHelper.WaitForJobCompletion(backupJobId);

                // 4. List recovery points
                var recoveryPoints = testHelper.ListRecoveryPoints(containerName, itemName);
                Assert.NotNull(recoveryPoints);
                Assert.True(recoveryPoints.Any());

                var iaasVmRecoveryPoint = (IaasVMRecoveryPoint) recoveryPoints.First().Properties;
                Assert.NotNull(iaasVmRecoveryPoint);

                // 5. Trigger restore
                var backedupItem = items.First(item => item.Name.Equals(containerUniqueName));
                var recoveryPoint = recoveryPoints.First();
                var sourceResourceId = ((AzureIaaSVMProtectedItem)backedupItem.Properties).VirtualMachineId;
                var restoreJobId = testHelper.Restore(containerName, itemName, recoveryPoint.Name, sourceResourceId, storageAccountId);
                testHelper.WaitForJobCompletion(restoreJobId);

                // 6. Disable protection
                var disableJobId = testHelper.DisableProtection(containerName, itemName);
                testHelper.WaitForJobCompletion(disableJobId);
            }
        }

        public void Dispose()
        {
            
        }
    }
}

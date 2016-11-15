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

using System;
using System.Linq;
using Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace Microsoft.Azure.Management.RecoveryServices.Backup.Tests
{
    public class ItemScenarioTests : TestBase, IDisposable
    {
        TestHelper testHelper { get; set; }

        public ItemScenarioTests()
        {
            testHelper = new TestHelper();
        }

        [Fact]
        public void TriggerBackupAndRestoreTest()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
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
                var items = testHelper.ListItems();
                Assert.NotNull(items);
                Assert.True(items.Any(item => itemName.Contains(item.Name.ToLower())));

                // 3. Trigger backup
                var backupJobId = testHelper.Backup(containerName, itemName);
                testHelper.WaitForJobCompletion(backupJobId);

                // 4. List recovery points
                var recoveryPoints = testHelper.ListRecoveryPoints(containerName, itemName);
                Assert.NotNull(recoveryPoints);
                Assert.True(recoveryPoints.Any());

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
            testHelper.Dispose();
        }
    }
}

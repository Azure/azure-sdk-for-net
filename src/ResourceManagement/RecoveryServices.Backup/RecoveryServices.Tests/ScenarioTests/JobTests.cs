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

using Microsoft.Azure.Management.RecoveryServices.Backup;
using Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using Microsoft.Azure.Test;
using Microsoft.Azure.Test.HttpRecorder;
using RecoveryServices.Backup.Tests.Helpers;
using System;
using System.Configuration;
using System.Net;
using System.Threading;
using Xunit;

namespace RecoveryServices.Backup.Tests
{
    public class JobTests : RecoveryServicesBackupTestsBase
    {
        public void ListJobsAndGetJobTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();

                string resourceNamespace = ConfigurationManager.AppSettings["ResourceNamespace"];
                string resourceGroupName = ConfigurationManager.AppSettings["RsVaultRgNameRP"];
                string resourceName = ConfigurationManager.AppSettings["RsVaultNameRP"];
                string location = ConfigurationManager.AppSettings["vaultLocationRP"];
                // TODO: Create VM instead of taking these parameters from config
                string containerUniqueName = ConfigurationManager.AppSettings["RsVaultIaasVMContainerUniqueNameRP"];
                string itemUniqueName = ConfigurationManager.AppSettings["RsVaultIaasVMItemUniqueNameRP"];
                string containeType = ConfigurationManager.AppSettings["IaaSVMContainerType"];
                string itemType = ConfigurationManager.AppSettings["IaaSVMItemType"];
                string containerUri = containeType + ";" + containerUniqueName;
                string itemUri = itemType + ";" + itemUniqueName;
                string utcDateTimeFormat = ConfigurationManager.AppSettings["UTCDateTimeFormat"];

                var client = GetServiceClient<RecoveryServicesBackupManagementClient>(resourceNamespace);

                // 1. Create vault
                VaultTestHelpers vaultTestHelper = new VaultTestHelpers(client);
                vaultTestHelper.CreateVault(resourceGroupName, resourceName, location);

                // 2. Get default policy
                PolicyTestHelpers policyTestHelper = new PolicyTestHelpers(client);
                string policyId = policyTestHelper.GetDefaultPolicyId(resourceGroupName, resourceName);

                // 3. Enable protection
                ProtectedItemTestHelpers protectedItemTestHelper = new ProtectedItemTestHelpers(client);
                DateTime protectionStartTime = DateTime.UtcNow;
                protectedItemTestHelper.EnableProtection(resourceGroupName, resourceName, policyId, containerUri, itemUri);
                DateTime protectionEndTime = DateTime.UtcNow;

                // ACTION: List jobs
                CommonJobQueryFilters commonFilters = new CommonJobQueryFilters();
                commonFilters.BackupManagementType = BackupManagementType.AzureIaasVM.ToString();
                commonFilters.StartTime = protectionStartTime.ToString(utcDateTimeFormat);
                commonFilters.EndTime = protectionEndTime.ToString(utcDateTimeFormat);
                JobTestHelpers helper = new JobTestHelpers(client);
                var jobList = helper.ListJobs(resourceGroupName, resourceName, commonFilters, null);

                // VALIDATION
                foreach (var job in jobList.ItemList.Value)
                {
                    Assert.NotNull(job.Id);
                    Assert.NotNull(job.Name);
                    helper.ValidateJobResponse(job.Properties, commonFilters);

                    // validating getjob
                    var jobDetails = helper.GetJob(resourceGroupName, resourceName, job.Name);
                    Assert.NotNull(jobDetails);
                    Assert.NotNull(jobDetails.Item);
                    helper.ValidateJobResponse(jobDetails.Item.Properties, null);
                }
            }
        }

        [Fact]
        public void CancelJobTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();

                string resourceNamespace = ConfigurationManager.AppSettings["ResourceNamespace"];
                string resourceGroupName = ConfigurationManager.AppSettings["RsVaultRgNameRP"];
                string resourceName = ConfigurationManager.AppSettings["RsVaultNameRP"];
                string location = ConfigurationManager.AppSettings["vaultLocationRP"];
                // TODO: Create VM instead of taking these parameters from config
                string containerUniqueName = ConfigurationManager.AppSettings["RsVaultIaasVMContainerUniqueNameRP"];
                string itemUniqueName = ConfigurationManager.AppSettings["RsVaultIaasVMItemUniqueNameRP"];
                string containeType = ConfigurationManager.AppSettings["IaaSVMContainerType"];
                string itemType = ConfigurationManager.AppSettings["IaaSVMItemType"];
                string containerUri = containeType + ";" + containerUniqueName;
                string itemUri = itemType + ";" + itemUniqueName;

                var client = GetServiceClient<RecoveryServicesBackupManagementClient>(resourceNamespace);

                // 1. Create vault
                VaultTestHelpers vaultTestHelper = new VaultTestHelpers(client);
                vaultTestHelper.CreateVault(resourceGroupName, resourceName, location);

                // 2. Get default policy
                PolicyTestHelpers policyTestHelper = new PolicyTestHelpers(client);
                string policyId = policyTestHelper.GetDefaultPolicyId(resourceGroupName, resourceName);

                // 3. Enable protection
                ProtectedItemTestHelpers protectedItemTestHelper = new ProtectedItemTestHelpers(client);
                DateTime protectionStartTime = DateTime.UtcNow;
                protectedItemTestHelper.EnableProtection(resourceGroupName, resourceName, policyId, containerUri, itemUri);
                DateTime protectionEndTime = DateTime.UtcNow;

                // 4. Trigger backup and get the job
                BackupTestHelpers backupTestHelper = new BackupTestHelpers(client);
                string jobId = backupTestHelper.BackupProtectedItem(resourceGroupName, resourceName, containerUri, itemUri);
                CommonJobQueryFilters commonFilters = new CommonJobQueryFilters();
                commonFilters.Status = JobStatus.InProgress.ToString();
                commonFilters.Operation = JobOperation.Backup.ToString();
                JobTestHelpers helper = new JobTestHelpers(client);
                var job = helper.GetJob(resourceGroupName, resourceName, jobId);

                // ACTION: Cancel the job
                var cancelResponse = helper.CancelJob(resourceGroupName, resourceName, jobId);
                var opId = helper.GetOpId(cancelResponse.Location);
                var opStatus = helper.GetJobOperationStatus(resourceGroupName, resourceName, jobId, opId);
                TestUtilities.RetryActionWithTimeout(
                    () => opStatus = helper.GetJobOperationStatus(resourceGroupName, resourceName, jobId, opId),
                    () => opStatus.StatusCode != HttpStatusCode.Accepted,
                    TimeSpan.FromMinutes(30),
                    statusCode =>
                    {
                        if (HttpMockServer.Mode == HttpRecorderMode.Record)
                        {
                            Thread.Sleep(15 * 1000);
                        }
                        return true;
                    });
            }
        }
    }
}

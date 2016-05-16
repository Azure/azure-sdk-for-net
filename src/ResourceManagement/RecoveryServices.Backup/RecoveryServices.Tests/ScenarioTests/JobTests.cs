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

using Hyak.Common;
using Microsoft.Azure.Management.RecoveryServices.Backup;
using Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using Microsoft.Azure.Test;
using RecoveryServices.Tests.Helpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using System.Threading;
using Microsoft.Azure.Test.HttpRecorder;

namespace RecoveryServices.Tests
{
    public class JobTests : RecoveryServicesTestsBase
    {       
        public void ListJobsAndGetJobTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();

                string resourceNamespace = null;

                if (string.IsNullOrEmpty(resourceNamespace))
                {
                    resourceNamespace = ConfigurationManager.AppSettings["ResourceNamespace"];
                }

                var client = GetServiceClient<RecoveryServicesBackupManagementClient>(resourceNamespace);

                CommonJobQueryFilters commonFilters = new CommonJobQueryFilters();
                commonFilters.BackupManagementType = BackupManagementType.AzureIaasVM.ToString();
                commonFilters.StartTime = (new DateTime(2016, 4, 12, 20, 0, 0)).ToUniversalTime().ToString("yyyy-MM-dd hh:mm:ss tt");
                commonFilters.EndTime = (new DateTime(2016, 4, 13, 20, 0, 0)).ToUniversalTime().ToString("yyyy-MM-dd hh:mm:ss tt");

                JobTestHelper helper = new JobTestHelper(client);
                var jobList = helper.ListJobs(commonFilters, null);

                foreach (var job in jobList.ItemList.Value)
                {
                    Assert.NotNull(job.Id);
                    Assert.NotNull(job.Name);
                    helper.ValidateJobResponse(job.Properties, commonFilters);

                    // validating getjob
                    var jobDetalis = helper.GetJob(job.Name);
                    Assert.NotNull(jobDetalis);
                    Assert.NotNull(jobDetalis.Item);
                    helper.ValidateJobResponse(jobDetalis.Item.Properties, null);
                }
            }
        }

        [Fact]
        public void CancelJobTest()
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start();

                string resourceNamespace = null;

                if (string.IsNullOrEmpty(resourceNamespace))
                {
                    resourceNamespace = ConfigurationManager.AppSettings["ResourceNamespace"];
                }

                var client = GetServiceClient<RecoveryServicesBackupManagementClient>(resourceNamespace);

                // take a protected item, and trigger backup
                // wait for it to complete. cancel it.
                CommonJobQueryFilters commonFilters = new CommonJobQueryFilters();
                commonFilters.Status = JobStatus.InProgress.ToString();
                commonFilters.Operation = JobOperation.Backup.ToString();

                JobTestHelper helper = new JobTestHelper(client);
                var jobList = helper.ListJobs(commonFilters, null);

                if (jobList.ItemList.Value.Count > 0)
                {
                    string jobId, opId;
                    jobId = jobList.ItemList.Value[0].Name;
                    // cancel the first job
                    var cancelResponse = helper.CancelJob(jobId);
                    opId = helper.GetOpId(cancelResponse.Location);
                    var opStatus = helper.GetJobOperationStatus(jobId, opId);

                    while (opStatus.StatusCode == HttpStatusCode.Accepted)
                    {
                        if (HttpMockServer.Mode == HttpRecorderMode.Record)
                        {
                            Thread.Sleep(15 * 1000);
                        }
                        opStatus = helper.GetJobOperationStatus(jobId, opId);
                    }
                }
            }
        }
    }
}

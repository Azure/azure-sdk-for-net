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
using Microsoft.Azure;
using Microsoft.Azure.Management.DataLake.Analytics;
using Microsoft.Azure.Management.DataLake.Analytics.Models;
using Microsoft.Azure.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Xunit;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

namespace DataLakeAnalytics.Tests
{
    public class JobOperationTests : TestBase
    {
        private CommonTestFixture commonData;

        [Fact] 
        public void SubmitGetListCancelTest()
        {
            using (var context = MockContext.Start(this.GetType().FullName))
            {
                commonData = new CommonTestFixture(context);
                commonData.HostUrl =
                    commonData.DataLakeAnalyticsManagementHelper.TryCreateDataLakeAnalyticsAccount(commonData.ResourceGroupName,
                        commonData.Location, commonData.DataLakeStoreAccountName, commonData.SecondDataLakeAnalyticsAccountName);
                
                // TODO: Remove this sleep once defect 5022906 is fixed
                TestUtilities.Wait(120000); // Sleep for two minutes to give the account a chance to provision the queue
                var clientToUse = this.GetDataLakeAnalyticsJobManagementClient(context);
                var accountClient = this.GetDataLakeAnalyticsManagementClient(context);

                Guid jobId = TestUtilities.GenerateGuid();
                var secondId = TestUtilities.GenerateGuid();
                // Submit a job to the account
                var jobToSubmit = new JobInformation
                {
                    Name = "azure sdk data lake analytics job",
                    JobId = jobId.ToString(),
                    DegreeOfParallelism = 2,
                    Type = JobType.USql,
                    Properties = new USql
                    {
                        // TODO: figure out why this is no longer showing up as a property
                        // Type = JobType.USql, 
                        Script = "DROP DATABASE IF EXISTS testdb; CREATE DATABASE testdb;"
                    }
                };

                var jobCreateResponse = clientToUse.Jobs.Create(commonData.DataLakeAnalyticsAccountName, jobId.ToString(), jobToSubmit);

                Assert.NotNull(jobCreateResponse);

                // Cancel the job
                clientToUse.Jobs.Cancel(commonData.DataLakeAnalyticsAccountName, jobCreateResponse.JobId);

                // Get the job and ensure that it says it was cancelled.
                var getCancelledJobResponse = clientToUse.Jobs.Get(commonData.DataLakeAnalyticsAccountName, jobCreateResponse.JobId);

                Assert.Equal(JobResult.Cancelled, getCancelledJobResponse.Result);
                Assert.NotNull(getCancelledJobResponse.ErrorMessage);
                Assert.NotEmpty(getCancelledJobResponse.ErrorMessage);

                // Resubmit the job
                jobToSubmit.JobId = secondId.ToString();
                jobCreateResponse = clientToUse.Jobs.Create(commonData.DataLakeAnalyticsAccountName, secondId.ToString(), jobToSubmit);

                Assert.NotNull(jobCreateResponse);

                // Poll the job until it finishes
                var getJobResponse = clientToUse.Jobs.Get(commonData.DataLakeAnalyticsAccountName, jobCreateResponse.JobId);
                Assert.NotNull(getJobResponse);

                int maxWaitInSeconds = 180; // 3 minutes should be long enough
                int curWaitInSeconds = 0;
                while (getJobResponse.State != JobState.Ended && curWaitInSeconds < maxWaitInSeconds)
                {
                    // wait 5 seconds before polling again
                    TestUtilities.Wait(5000);
                    curWaitInSeconds += 5;
                    getJobResponse = clientToUse.Jobs.Get(commonData.DataLakeAnalyticsAccountName, jobCreateResponse.JobId);
                    Assert.NotNull(getJobResponse);
                }

                Assert.True(curWaitInSeconds <= maxWaitInSeconds);

                // Verify the job completes successfully
                Assert.True(
                    getJobResponse.State == JobState.Ended && getJobResponse.Result == JobResult.Succeeded,
                    string.Format("Job: {0} did not return success. Current job state: {1}. Actual result: {2}. Error (if any): {3}",
                        getJobResponse.JobId, getJobResponse.State, getJobResponse.Result, getJobResponse.ErrorMessage));

                var listJobResponse = clientToUse.Jobs.List(commonData.DataLakeAnalyticsAccountName, null);
                Assert.NotNull(listJobResponse);

                Assert.True(listJobResponse.Any(job => job.JobId == getJobResponse.JobId));

                // Just compile the job
                var compileResponse = clientToUse.Jobs.Build(commonData.DataLakeAnalyticsAccountName, jobToSubmit);
                Assert.NotNull(compileResponse);

                // list the jobs both with a hand crafted query string and using the parameters
                listJobResponse = clientToUse.Jobs.List(commonData.DataLakeAnalyticsAccountName, select:  "jobId" );
                Assert.NotNull(listJobResponse);

                Assert.True(listJobResponse.Any(job => job.JobId == getJobResponse.JobId));
                
                /* TODO: re-enable if we can figure out a way to include this
                listJobResponse = clientToUse.Jobs.ListWithQueryString(commonData.DataLakeAnalyticsAccountName, "$select=jobId");
                Assert.NotNull(listJobResponse);
                
                Assert.True(listJobResponse.Value.Any(job => job.JobId == getJobResponse.JobId));
                */
            }
        }
    }
}

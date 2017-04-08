// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

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
                
                var clientToUse = this.GetDataLakeAnalyticsJobManagementClient(context);

                Guid jobId = TestUtilities.GenerateGuid();
                var secondId = TestUtilities.GenerateGuid();
                // Submit a job to the account
                var jobToSubmit = new JobInformation
                {
                    Name = "azure sdk data lake analytics job",
                    DegreeOfParallelism = 2,
                    Type = JobType.USql,
                    Properties = new USqlJobProperties
                    {
                        // TODO: figure out why this is no longer showing up as a property
                        // Type = JobType.USql, 
                        Script = "DROP DATABASE IF EXISTS testdb; CREATE DATABASE testdb;"
                    }
                };

                // check to make sure the job doesn't already exist
                Assert.False(clientToUse.Job.Exists(commonData.SecondDataLakeAnalyticsAccountName, jobId));
                var jobCreateResponse = clientToUse.Job.Create(commonData.SecondDataLakeAnalyticsAccountName, jobId, jobToSubmit);

                Assert.NotNull(jobCreateResponse);

                // Cancel the job
                clientToUse.Job.Cancel(commonData.SecondDataLakeAnalyticsAccountName, jobCreateResponse.JobId.GetValueOrDefault());

                // check to make sure the job does exist now
                Assert.True(clientToUse.Job.Exists(commonData.SecondDataLakeAnalyticsAccountName, jobId));

                // Get the job and ensure that it says it was cancelled.
                var getCancelledJobResponse = clientToUse.Job.Get(commonData.SecondDataLakeAnalyticsAccountName, jobCreateResponse.JobId.GetValueOrDefault());

                Assert.Equal(JobResult.Cancelled, getCancelledJobResponse.Result);
                Assert.NotNull(getCancelledJobResponse.ErrorMessage);
                Assert.NotEmpty(getCancelledJobResponse.ErrorMessage);

                // Resubmit the job
                jobCreateResponse = clientToUse.Job.Create(commonData.SecondDataLakeAnalyticsAccountName, secondId, jobToSubmit);

                Assert.NotNull(jobCreateResponse);

                // Poll the job until it finishes
                var getJobResponse = clientToUse.Job.Get(commonData.SecondDataLakeAnalyticsAccountName, jobCreateResponse.JobId.GetValueOrDefault());
                Assert.NotNull(getJobResponse);

                int maxWaitInSeconds = 180; // 3 minutes should be long enough
                int curWaitInSeconds = 0;
                while (getJobResponse.State != JobState.Ended && curWaitInSeconds < maxWaitInSeconds)
                {
                    // wait 5 seconds before polling again
                    TestUtilities.Wait(5000);
                    curWaitInSeconds += 5;
                    getJobResponse = clientToUse.Job.Get(commonData.SecondDataLakeAnalyticsAccountName, jobCreateResponse.JobId.GetValueOrDefault());
                    Assert.NotNull(getJobResponse);
                }

                Assert.True(curWaitInSeconds <= maxWaitInSeconds);

                // Verify the job completes successfully
                Assert.True(
                    getJobResponse.State == JobState.Ended && getJobResponse.Result == JobResult.Succeeded,
                    string.Format("Job: {0} did not return success. Current job state: {1}. Actual result: {2}. Error (if any): {3}",
                        getJobResponse.JobId, getJobResponse.State, getJobResponse.Result, getJobResponse.ErrorMessage));

                var listJobResponse = clientToUse.Job.List(commonData.SecondDataLakeAnalyticsAccountName, null);
                Assert.NotNull(listJobResponse);

                Assert.True(listJobResponse.Any(job => job.JobId == getJobResponse.JobId));

                // Just compile the job, which requires a jobId in the job object.
                // jobToSubmit.JobId = getJobResponse.JobId;
                var compileResponse = clientToUse.Job.Build(commonData.SecondDataLakeAnalyticsAccountName, jobToSubmit);
                Assert.NotNull(compileResponse);

                // now compile a broken job and verify diagnostics report an error
                jobToSubmit.Properties.Script = "DROP DATABASE IF EXIST FOO; CREATE DATABASE FOO;";
                compileResponse = clientToUse.Job.Build(commonData.SecondDataLakeAnalyticsAccountName, jobToSubmit);
                Assert.NotNull(compileResponse);

                Assert.Equal(1, ((USqlJobProperties)compileResponse.Properties).Diagnostics.Count);
                Assert.Equal(SeverityTypes.Error, ((USqlJobProperties)compileResponse.Properties).Diagnostics[0].Severity);
                Assert.Equal(18, ((USqlJobProperties)compileResponse.Properties).Diagnostics[0].ColumnNumber);
                Assert.Equal(22, ((USqlJobProperties)compileResponse.Properties).Diagnostics[0].End);
                Assert.Equal(17, ((USqlJobProperties)compileResponse.Properties).Diagnostics[0].Start);
                Assert.Equal(1, ((USqlJobProperties)compileResponse.Properties).Diagnostics[0].LineNumber);
                Assert.Contains("E_CSC_USER_SYNTAXERROR", ((USqlJobProperties)compileResponse.Properties).Diagnostics[0].Message);

                // list the jobs both with a hand crafted query string and using the parameters
                listJobResponse = clientToUse.Job.List(commonData.SecondDataLakeAnalyticsAccountName, select:  "jobId" );
                Assert.NotNull(listJobResponse);

                Assert.True(listJobResponse.Any(job => job.JobId == getJobResponse.JobId));
            }
        }
    }
}

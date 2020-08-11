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
        public void USqlSubmitGetListCancelTest()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                commonData = new CommonTestFixture(context);
                commonData.HostUrl =
                    commonData.DataLakeAnalyticsManagementHelper.TryCreateDataLakeAnalyticsAccount(
                        commonData.ResourceGroupName,
                        commonData.Location, 
                        commonData.DataLakeStoreAccountName, 
                        commonData.SecondDataLakeAnalyticsAccountName
                    );

                // Wait 5 minutes for the account setup
                TestUtilities.Wait(300000);

                var clientToUse = this.GetDataLakeAnalyticsJobManagementClient(context);

                Guid jobId = TestUtilities.GenerateGuid();
                Guid secondId = TestUtilities.GenerateGuid();

                // Job relationship information
                var recurrenceId = TestUtilities.GenerateGuid();
                var recurrenceName = TestUtilities.GenerateName("recurrence");

                var runId01 = TestUtilities.GenerateGuid();
                var runId02 = TestUtilities.GenerateGuid();

                var pipelineId = TestUtilities.GenerateGuid();
                var pipelineName = TestUtilities.GenerateName("jobPipeline");
                var pipelineUri = string.Format("https://{0}.contoso.com/myJob", TestUtilities.GenerateName("pipelineuri"));

                // Submit a usql job to the account
                var jobToSubmit = new CreateJobParameters
                {
                    Name = "azure sdk data lake analytics job",
                    Type = JobType.USql,
                    DegreeOfParallelism = 2,
                    Properties = new CreateUSqlJobProperties
                    {
                        RuntimeVersion = "default",
                        Script = "DROP DATABASE IF EXISTS testdb; CREATE DATABASE testdb;"
                    },
                    Related = new JobRelationshipProperties
                    {
                        PipelineId = pipelineId,
                        PipelineName = pipelineName,
                        PipelineUri = pipelineUri,
                        RecurrenceId = recurrenceId,
                        RecurrenceName = recurrenceName,
                        RunId = runId01
                    }
                };

                // Check to make sure the usql job doesn't already exist
                Assert.False(
                    clientToUse.Job.Exists(
                        commonData.SecondDataLakeAnalyticsAccountName, 
                        jobId
                    )
                );

                // Submit the usql job
                var jobCreateResponse = 
                    clientToUse.Job.Create(
                        commonData.SecondDataLakeAnalyticsAccountName, 
                        jobId, 
                        jobToSubmit
                    );

                Assert.NotNull(jobCreateResponse);

                // Check to make sure the usql job does exist now
                Assert.True(
                    clientToUse.Job.Exists(
                        commonData.SecondDataLakeAnalyticsAccountName, 
                        jobId
                    )
                );

                // Cancel the usql job
                clientToUse.Job.Cancel(
                    commonData.SecondDataLakeAnalyticsAccountName, 
                    jobCreateResponse.JobId.GetValueOrDefault()
                );

                // Get the usql job and ensure that it says it was cancelled
                var getCancelledJobResponse = 
                    clientToUse.Job.Get(
                        commonData.SecondDataLakeAnalyticsAccountName, 
                        jobCreateResponse.JobId.GetValueOrDefault()
                    );

                Assert.Equal(JobResult.Cancelled, getCancelledJobResponse.Result);
                Assert.NotNull(getCancelledJobResponse.ErrorMessage);
                Assert.NotEmpty(getCancelledJobResponse.ErrorMessage);

                // Resubmit the usql job
                // First update the runId to a new run
                jobToSubmit.Related.RunId = runId02;
                jobCreateResponse = 
                    clientToUse.Job.Create(
                        commonData.SecondDataLakeAnalyticsAccountName, 
                        secondId, 
                        jobToSubmit
                    );

                Assert.NotNull(jobCreateResponse);

                // Poll the usql job until it finishes
                var getJobResponse = 
                    clientToUse.Job.Get(
                        commonData.SecondDataLakeAnalyticsAccountName, 
                        jobCreateResponse.JobId.GetValueOrDefault()
                    );

                Assert.NotNull(getJobResponse);

                int maxWaitInSeconds = 180; // 3 minutes should be long enough
                int curWaitInSeconds = 0;
                while (getJobResponse.State != JobState.Ended && curWaitInSeconds < maxWaitInSeconds)
                {
                    // Wait 5 seconds before polling again
                    TestUtilities.Wait(5000);
                    curWaitInSeconds += 5;
                    getJobResponse = 
                        clientToUse.Job.Get(
                            commonData.SecondDataLakeAnalyticsAccountName, 
                            jobCreateResponse.JobId.GetValueOrDefault()
                        );

                    Assert.NotNull(getJobResponse);
                }

                Assert.True(curWaitInSeconds <= maxWaitInSeconds);

                // Verify the usql job completes successfully
                Assert.True(
                    getJobResponse.State == JobState.Ended && getJobResponse.Result == JobResult.Succeeded,
                    string.Format(
                        "Job: {0} did not return success. Current job state: {1}. Actual result: {2}. Error (if any): {3}",
                        getJobResponse.JobId, 
                        getJobResponse.State, 
                        getJobResponse.Result, 
                        getJobResponse.ErrorMessage
                    )
                );

                // Validate usql job relationship info
                Assert.Equal(runId02, getJobResponse.Related.RunId);
                Assert.Equal(pipelineId, getJobResponse.Related.PipelineId);
                Assert.Equal(pipelineName, getJobResponse.Related.PipelineName);
                Assert.Equal(recurrenceName, getJobResponse.Related.RecurrenceName);
                Assert.Equal(recurrenceId, getJobResponse.Related.RecurrenceId);
                Assert.Equal(pipelineUri, getJobResponse.Related.PipelineUri);

                // Get the list of usql jobs and check that the submitted job exists
                var listJobResponse = 
                    clientToUse.Job.List(
                        commonData.SecondDataLakeAnalyticsAccountName
                    );

                Assert.NotNull(listJobResponse);
                Assert.Contains(listJobResponse, job => job.JobId == getJobResponse.JobId);

                // Validate usql job relationship retrieval (get/list pipeline and get/list recurrence)
                var getPipeline = 
                    clientToUse.Pipeline.Get(
                        commonData.SecondDataLakeAnalyticsAccountName, 
                        pipelineId
                    );

                Assert.Equal(pipelineId, getPipeline.PipelineId);
                Assert.Equal(pipelineName, getPipeline.PipelineName);
                Assert.Equal(pipelineUri, getPipeline.PipelineUri);
                Assert.True(getPipeline.Runs.Count() >= 2);

                var listPipeline = 
                    clientToUse.Pipeline.List(
                        commonData.SecondDataLakeAnalyticsAccountName
                    );

                Assert.Single(listPipeline);
                Assert.Contains(listPipeline, pipeline => pipeline.PipelineId == pipelineId);

                // Recurrence get/list
                var getRecurrence = 
                    clientToUse.Recurrence.Get(
                        commonData.SecondDataLakeAnalyticsAccountName, 
                        recurrenceId
                    );

                Assert.Equal(recurrenceId, getRecurrence.RecurrenceId);
                Assert.Equal(recurrenceName, getRecurrence.RecurrenceName);

                var listRecurrence = 
                    clientToUse.Recurrence.List(
                        commonData.SecondDataLakeAnalyticsAccountName
                    );

                Assert.Single(listRecurrence);
                Assert.Contains(listRecurrence, recurrence => recurrence.RecurrenceId == recurrenceId);

                // TODO: re-enable this after the next prod push
                // List the usql jobs with only the jobId property filled
                // listJobResponse = clientToUse.Job.List(commonData.SecondDataLakeAnalyticsAccountName, select: "jobId");
                
                // Assert.NotNull(listJobResponse);
                // Assert.True(listJobResponse.Any(job => job.JobId == getJobResponse.JobId));
            }
        }

        [Fact]
        public void USqlBuildTest()
        {
            using (var context = MockContext.Start(this.GetType()))
            {
                commonData = new CommonTestFixture(context);
                commonData.HostUrl =
                    commonData.DataLakeAnalyticsManagementHelper.TryCreateDataLakeAnalyticsAccount(
                        commonData.ResourceGroupName,
                        commonData.Location, 
                        commonData.DataLakeStoreAccountName, 
                        commonData.SecondDataLakeAnalyticsAccountName
                    );

                // Wait 5 minutes for the account setup
                TestUtilities.Wait(300000);

                var clientToUse = this.GetDataLakeAnalyticsJobManagementClient(context);

                // Compile a usql job, which requires a jobId in the job object
                // Submit a usql job to the account
                var jobToBuild = new BuildJobParameters
                {
                    Name = "azure sdk data lake analytics job",
                    Type = JobType.USql,
                    Properties = new CreateUSqlJobProperties
                    {
                        Script = "DROP DATABASE IF EXISTS testdb; CREATE DATABASE testdb;"
                    }
                };

                // Just compile the usql job, which requires a jobId in the job object
                var compileResponse = 
                    clientToUse.Job.Build(
                        commonData.SecondDataLakeAnalyticsAccountName, 
                        jobToBuild
                    );

                Assert.NotNull(compileResponse);

                // Now compile a broken usql job and verify diagnostics report an error
                jobToBuild.Properties.Script = "DROP DATABASE IF EXIST FOO; CREATE DATABASE FOO;";
                compileResponse = 
                    clientToUse.Job.Build(
                        commonData.SecondDataLakeAnalyticsAccountName, 
                        jobToBuild
                    );

                Assert.NotNull(compileResponse);
                Assert.Equal(1, ((USqlJobProperties)compileResponse.Properties).Diagnostics.Count);
                Assert.Equal(SeverityTypes.Error, ((USqlJobProperties)compileResponse.Properties).Diagnostics[0].Severity);
                Assert.Equal(18, ((USqlJobProperties)compileResponse.Properties).Diagnostics[0].ColumnNumber);
                Assert.Equal(22, ((USqlJobProperties)compileResponse.Properties).Diagnostics[0].End);
                Assert.Equal(17, ((USqlJobProperties)compileResponse.Properties).Diagnostics[0].Start);
                Assert.Equal(1, ((USqlJobProperties)compileResponse.Properties).Diagnostics[0].LineNumber);
                Assert.Contains("E_CSC_USER_SYNTAXERROR", ((USqlJobProperties)compileResponse.Properties).Diagnostics[0].Message);
            }
        }
    }
}


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

﻿
namespace Azure.Batch.Unit.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;

    using BatchTestCommon;

    using Microsoft.Azure.Batch;
    using Microsoft.Azure.Batch.Auth;
    using Microsoft.Azure.Batch.Common;
    using Microsoft.Rest.Azure;
    using Xunit;
    using Protocol = Microsoft.Azure.Batch.Protocol;
    using Models = Microsoft.Azure.Batch.Protocol.Models;
    using TestUtilities;

    public class JobAutoTerminationUnitTests
    {
        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public async Task UpdateBoundJobWithNewAutoTerminationPropertiesTest()
        {
            using (BatchClient client = ClientUnitTestCommon.CreateDummyClient())
            {
                Models.CloudJob protoJob = new Models.CloudJob(id: "id", onAllTasksComplete: Models.OnAllTasksComplete.NoAction, onTaskFailure: Models.OnTaskFailure.PerformExitOptionsJobAction);

                CloudJob boundJob = await client.JobOperations.GetJobAsync(string.Empty, additionalBehaviors: InterceptorFactory.CreateGetJobRequestInterceptor(protoJob));
                Assert.Equal(OnAllTasksComplete.NoAction, boundJob.OnAllTasksComplete);
                Assert.Equal(OnTaskFailure.PerformExitOptionsJobAction, boundJob.OnTaskFailure);

                // Can update job's auto complete properties.
                boundJob.OnAllTasksComplete = OnAllTasksComplete.TerminateJob;
                Assert.Equal(OnAllTasksComplete.TerminateJob, boundJob.OnAllTasksComplete);
            }
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public async Task ExitConditionsAreSentOnTask()
        {
            const string jobId = "id-123";
            const string taskId = "id-001";

            using (BatchClient client = ClientUnitTestCommon.CreateDummyClient())
            {
                Models.CloudJob protoJob = new Models.CloudJob(id: jobId, onAllTasksComplete: Models.OnAllTasksComplete.NoAction, onTaskFailure: Models.OnTaskFailure.PerformExitOptionsJobAction);

                var fakeAddTaskResponse = ClientUnitTestCommon.SimulateServiceResponse<Models.TaskAddParameter, Models.TaskAddOptions, AzureOperationHeaderResponse<Models.TaskAddHeaders>>((parameters, options) =>
                {
                    Assert.Equal((Models.JobAction?)JobAction.Terminate, parameters.ExitConditions.DefaultProperty.JobAction);
                    Assert.Equal(0, parameters.ExitConditions.ExitCodeRanges.First().Start);
                    Assert.Equal(4, parameters.ExitConditions.ExitCodeRanges.First().End);
                    Assert.Equal((Models.JobAction?)JobAction.Disable, parameters.ExitConditions.ExitCodeRanges.First().ExitOptions.JobAction);
                    // These need to be compared as strings because they are different types but we are interested in the values being the same.
                    Assert.Equal(DependencyAction.Satisfy.ToString(), parameters.ExitConditions.ExitCodeRanges.First().ExitOptions.DependencyAction.ToString());
                    Assert.Equal(3, parameters.ExitConditions.ExitCodes.First().Code);
                    Assert.Equal((Models.JobAction?)JobAction.None, parameters.ExitConditions.ExitCodes.First().ExitOptions.JobAction);
                    Assert.Equal((Models.JobAction?)JobAction.Terminate, parameters.ExitConditions.FileUploadError.JobAction);

                    return new AzureOperationHeaderResponse<Models.TaskAddHeaders>()
                    {
                        Response = new HttpResponseMessage(HttpStatusCode.Accepted)
                    };
                });

                CloudJob boundJob = await client.JobOperations.GetJobAsync(string.Empty, additionalBehaviors: InterceptorFactory.CreateGetJobRequestInterceptor(protoJob));

                boundJob.OnAllTasksComplete = OnAllTasksComplete.TerminateJob;

                CloudTask cloudTask = new CloudTask(taskId, "cmd /c echo hello world");

                cloudTask.ExitConditions = new ExitConditions()
                {
                    Default = new ExitOptions() { JobAction = JobAction.Terminate },
                    ExitCodeRanges = new List<ExitCodeRangeMapping>()
                    {
                        new ExitCodeRangeMapping(0, 4, new ExitOptions() { DependencyAction = DependencyAction.Satisfy, JobAction = JobAction.Disable, })
                    },
                    ExitCodes = new List<ExitCodeMapping>()
                    {
                        new ExitCodeMapping(3, new ExitOptions() {JobAction = JobAction.None})
                    },
                    PreProcessingError = new ExitOptions() { JobAction = JobAction.Terminate },
                    FileUploadError = new ExitOptions() { JobAction = JobAction.Terminate }
                };

                boundJob.AddTask(cloudTask, additionalBehaviors: fakeAddTaskResponse);
            }
        }
    }
}

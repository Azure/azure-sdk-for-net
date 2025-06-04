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


    public class BindingStateConstraintUnitTests
    {
        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void Pool_WhenReturnedFromServer_HasExpectedUnboundProperties()
        {
            const string cloudPoolId = "id-123";
            const string virtualMachineSize = "4";
            const string cloudPoolDisplayName = "pool-display-name-test";
            MetadataItem metadataItem = new MetadataItem("foo", "bar");

            using BatchClient client = ClientUnitTestCommon.CreateDummyClient();
            CloudPool cloudPool = client.PoolOperations.CreatePool(cloudPoolId, virtualMachineSize, new VirtualMachineConfiguration(imageReference: new ImageReference(), nodeAgentSkuId: "df"));
            cloudPool.DisplayName = cloudPoolDisplayName;
            cloudPool.Metadata = new List<MetadataItem> { metadataItem };

            Assert.Equal(cloudPoolId, cloudPool.Id); // can set an unbound object
            Assert.Equal(cloudPool.Metadata.First().Name, metadataItem.Name);
            Assert.Equal(cloudPool.Metadata.First().Value, metadataItem.Value);

            cloudPool.Commit(additionalBehaviors: InterceptorFactory.CreateAddPoolRequestInterceptor());

            // writing isn't allowed for a cloudPool that is in an readonly state.
            Assert.Throws<InvalidOperationException>(() => cloudPool.AutoScaleFormula = "Foo");
            Assert.Throws<InvalidOperationException>(() => cloudPool.DisplayName = "Foo");
            Assert.Throws<InvalidOperationException>(() => cloudPool.VirtualMachineConfiguration = null);
            Assert.Throws<InvalidOperationException>(() => cloudPool.ResizeTimeout = TimeSpan.FromSeconds(10));
            Assert.Throws<InvalidOperationException>(() => cloudPool.Metadata = null);
            Assert.Throws<InvalidOperationException>(() => cloudPool.TargetDedicatedComputeNodes = 5);
            Assert.Throws<InvalidOperationException>(() => cloudPool.VirtualMachineConfiguration = null);
            Assert.Throws<InvalidOperationException>(() => cloudPool.VirtualMachineSize = "small");

            //read is allowed though
            Assert.Null(cloudPool.AutoScaleFormula);
            Assert.Equal(cloudPoolDisplayName, cloudPool.DisplayName);
            Assert.NotNull(cloudPool.VirtualMachineConfiguration);
            Assert.Null(cloudPool.ResizeTimeout);
            Assert.Equal(1, cloudPool.Metadata.Count);
            Assert.Null(cloudPool.TargetDedicatedComputeNodes);
            Assert.Equal(virtualMachineSize, cloudPool.VirtualMachineSize);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void Pool_WhenReturnedFromServer_HasExpectedBoundProperties()
        {
            const string cloudPoolId = "id-123";
            const string cloudPoolDisplayName = "pool-display-name-test";
            MetadataItem metadataItem = new MetadataItem("foo", "bar");

            using BatchClient client = ClientUnitTestCommon.CreateDummyClient();
            Models.CloudPool protoPool = new Models.CloudPool(id: cloudPoolId, displayName: cloudPoolDisplayName, metadata: new[]
            {
                    new Models.MetadataItem
                    {
                        Name = metadataItem.Name,
                        Value = metadataItem.Value
                    }
                });

            CloudPool boundPool = client.PoolOperations.GetPool(string.Empty, additionalBehaviors: InterceptorFactory.CreateGetPoolRequestInterceptor(protoPool));

            // Cannot change these bound properties.
            Assert.Throws<InvalidOperationException>(() => boundPool.Id = "cannot-change-id");
            Assert.Throws<InvalidOperationException>(() => boundPool.TargetDedicatedComputeNodes = 1);

            // Swap the value with the name and the name with the value.
            boundPool.Metadata = new[] { new MetadataItem(metadataItem.Value, metadataItem.Name) };
            Assert.Equal(metadataItem.Name, boundPool.Metadata.First().Value);
            Assert.Equal(metadataItem.Value, boundPool.Metadata.First().Name);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void CloudJobSchedule_WhenSendingToTheServer_HasExpectedUnboundProperties()
        {
            const string jobScheduleId = "id-123";
            const string displayName = "DisplayNameFoo";
            MetadataItem metadataItem = new MetadataItem("foo", "bar");

            using BatchClient client = ClientUnitTestCommon.CreateDummyClient();
            CloudJobSchedule jobSchedule = client.JobScheduleOperations.CreateJobSchedule();
            jobSchedule.Id = jobScheduleId;
            jobSchedule.DisplayName = displayName;
            jobSchedule.Metadata = new List<MetadataItem> { metadataItem };
            jobSchedule.JobSpecification = new JobSpecification
            {
                OnAllTasksComplete = OnAllTasksComplete.TerminateJob,
                OnTaskFailure = OnTaskFailure.PerformExitOptionsJobAction
            };

            Assert.Equal(jobScheduleId, jobSchedule.Id); // can set an unbound object
            Assert.Equal(jobSchedule.Metadata.First().Name, metadataItem.Name);
            Assert.Equal(jobSchedule.Metadata.First().Value, metadataItem.Value);
            Assert.Equal(OnAllTasksComplete.TerminateJob, jobSchedule.JobSpecification.OnAllTasksComplete);
            Assert.Equal(OnTaskFailure.PerformExitOptionsJobAction, jobSchedule.JobSpecification.OnTaskFailure);

            jobSchedule.Commit(additionalBehaviors: InterceptorFactory.CreateAddJobScheduleRequestInterceptor());

            // writing isn't allowed for a jobSchedule that is in an read only state.
            Assert.Throws<InvalidOperationException>(() => jobSchedule.Id = "cannot-change-id");
            Assert.Throws<InvalidOperationException>(() => jobSchedule.DisplayName = "cannot-change-display-name");

            //Can still read though
            Assert.Equal(jobScheduleId, jobSchedule.Id);
            Assert.Equal(displayName, jobSchedule.DisplayName);

            jobSchedule.Refresh(additionalBehaviors:
                    InterceptorFactory.CreateGetJobScheduleRequestInterceptor(
                        new Models.CloudJobSchedule()
                        {
                            JobSpecification = new Models.JobSpecification()
                        }));

            jobSchedule.JobSpecification.OnAllTasksComplete = OnAllTasksComplete.NoAction;
            jobSchedule.JobSpecification.OnTaskFailure = OnTaskFailure.NoAction;
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void CloudJobSchedule_WhenReturnedFromServer_HasExpectedBoundProperties()
        {
            const string jobScheduleId = "id-123";
            const string displayName = "DisplayNameFoo";
            MetadataItem metadataItem = new MetadataItem("foo", "bar");

            using BatchClient client = ClientUnitTestCommon.CreateDummyClient();
            DateTime creationTime = DateTime.Now;

            var cloudJobSchedule = new Models.CloudJobSchedule
            {
                Id = jobScheduleId,
                DisplayName = displayName,
                Metadata = new[]
                        {
                                new Models.MetadataItem { Name = metadataItem.Name, Value = metadataItem.Value }
                            },
                CreationTime = creationTime,
                JobSpecification = new Models.JobSpecification
                {
                    OnAllTasksComplete = Models.OnAllTasksComplete.TerminateJob,
                    OnTaskFailure = Models.OnTaskFailure.PerformExitOptionsJobAction
                }
            };

            CloudJobSchedule boundJobSchedule = client.JobScheduleOperations.GetJobSchedule(
                jobScheduleId,
                additionalBehaviors: InterceptorFactory.CreateGetJobScheduleRequestInterceptor(cloudJobSchedule));

            Assert.Equal(jobScheduleId, boundJobSchedule.Id); // reading is allowed from a jobSchedule that is returned from the server.
            Assert.Equal(creationTime, boundJobSchedule.CreationTime);
            Assert.Equal(displayName, boundJobSchedule.DisplayName);
            Assert.Equal(OnAllTasksComplete.TerminateJob, boundJobSchedule.JobSpecification.OnAllTasksComplete);
            Assert.Equal(OnTaskFailure.PerformExitOptionsJobAction, boundJobSchedule.JobSpecification.OnTaskFailure);

            Assert.Throws<InvalidOperationException>(() => boundJobSchedule.DisplayName = "cannot-change-display-name");
            Assert.Throws<InvalidOperationException>(() => boundJobSchedule.Id = "cannot-change-id");

            boundJobSchedule.JobSpecification.OnAllTasksComplete = OnAllTasksComplete.TerminateJob;
            boundJobSchedule.JobSpecification.OnTaskFailure = OnTaskFailure.NoAction;

            Assert.Equal(OnAllTasksComplete.TerminateJob, boundJobSchedule.JobSpecification.OnAllTasksComplete);
            Assert.Equal(OnTaskFailure.NoAction, boundJobSchedule.JobSpecification.OnTaskFailure);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void CloudJob_WhenSendingToTheServer_HasExpectedUnboundProperties()
        {
            const string jobId = "id-123";
            const string displayName = "DisplayNameFoo";
            MetadataItem metadataItem = new MetadataItem("foo", "bar");
            const int priority = 0;
            const string applicationId = "testApp";
            const string applicationVersion = "beta";

            using BatchClient client = ClientUnitTestCommon.CreateDummyClient();
            CloudJob cloudJob = client.JobOperations.CreateJob(jobId, new PoolInformation { AutoPoolSpecification = new AutoPoolSpecification { KeepAlive = false } });
            cloudJob.Id = jobId;
            cloudJob.DisplayName = displayName;
            cloudJob.Metadata = new List<MetadataItem> { metadataItem };
            cloudJob.Priority = priority;
            cloudJob.JobManagerTask = new JobManagerTask
            {
                ApplicationPackageReferences = new List<ApplicationPackageReference>
                {
                    new ApplicationPackageReference { ApplicationId = applicationId, Version = applicationVersion }
                },
                AuthenticationTokenSettings = new AuthenticationTokenSettings() { Access = AccessScope.Job }
            };

            cloudJob.OnAllTasksComplete = OnAllTasksComplete.NoAction;
            cloudJob.OnTaskFailure = OnTaskFailure.NoAction;


            Assert.Throws<InvalidOperationException>(() => cloudJob.Url); // cannot read a Url since it's unbound at this point.
            Assert.Equal(jobId, cloudJob.Id); // can set an unbound object
            Assert.Equal(cloudJob.Metadata.First().Name, metadataItem.Name);
            Assert.Equal(cloudJob.Metadata.First().Value, metadataItem.Value);
            Assert.Equal(OnAllTasksComplete.NoAction, cloudJob.OnAllTasksComplete);
            Assert.Equal(OnTaskFailure.NoAction, cloudJob.OnTaskFailure);

            cloudJob.Commit(additionalBehaviors: InterceptorFactory.CreateAddJobRequestInterceptor());

            // writing isn't allowed for a job that is in an invalid state.
            Assert.Throws<InvalidOperationException>(() => cloudJob.Id = "cannot-change-id");
            Assert.Throws<InvalidOperationException>(() => cloudJob.DisplayName = "cannot-change-display-name");

            AuthenticationTokenSettings authenticationTokenSettings = new AuthenticationTokenSettings { Access = AccessScope.Job };
            Assert.Throws<InvalidOperationException>(() => { cloudJob.JobManagerTask.AuthenticationTokenSettings = authenticationTokenSettings; });
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void CloudJob_WhenReturnedFromServer_HasExpectedBoundProperties()
        {
            const string jobId = "id-123";
            const string displayName = "DisplayNameFoo";
            string applicationVersion = "beta";
            string applicationId = "test";

            MetadataItem metadataItem = new MetadataItem("foo", "bar");
            const int priority = 0;
            var onAllTasksComplete = OnAllTasksComplete.TerminateJob;

            using BatchClient client = ClientUnitTestCommon.CreateDummyClient();
            DateTime creationTime = DateTime.Now;

            Models.CloudJob protoJob = new Models.CloudJob(
                jobId,
                displayName,
                jobManagerTask: new Models.JobManagerTask()
                {
                    ApplicationPackageReferences = new[] { new Models.ApplicationPackageReference() { ApplicationId = applicationId, Version = applicationVersion } }
                },
                metadata: new[] { new Models.MetadataItem { Name = metadataItem.Name, Value = metadataItem.Value } },
                creationTime: creationTime,
                priority: priority,
                url: ClientUnitTestCommon.DummyBaseUrl,
                onAllTasksComplete: Models.OnAllTasksComplete.NoAction);

            CloudJob boundJob = client.JobOperations.GetJob(jobId, additionalBehaviors: InterceptorFactory.CreateGetJobRequestInterceptor(protoJob));

            Assert.Equal(jobId, boundJob.Id); // reading is allowed from a job that is returned from the server.
            Assert.Equal(creationTime, boundJob.CreationTime);
            Assert.Equal(displayName, boundJob.DisplayName);
            Assert.Equal(applicationId, boundJob.JobManagerTask.ApplicationPackageReferences.First().ApplicationId);
            Assert.Equal(applicationVersion, boundJob.JobManagerTask.ApplicationPackageReferences.First().Version);

            AssertPatchableJobPropertiesCanBeWritten(boundJob, priority, metadataItem, onAllTasksComplete);

            // Can only read a url from a returned object.
            Assert.Equal(ClientUnitTestCommon.DummyBaseUrl, boundJob.Url);

            // Cannot change a bound displayName, Id and any property on a JobManagerTask.
            Assert.Throws<InvalidOperationException>(() => boundJob.DisplayName = "cannot-change-display-name");
            Assert.Throws<InvalidOperationException>(() => boundJob.Id = "cannot-change-id");
            Assert.Throws<InvalidOperationException>(() => boundJob.JobManagerTask.ApplicationPackageReferences = new List<ApplicationPackageReference>());
            Assert.Throws<InvalidOperationException>(() => boundJob.JobManagerTask = new JobManagerTask());
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void CloudTask_WhenReturnedFromServer_HasExpectedBoundProperties()
        {
            const string jobId = "id-123";
            const string taskId = "id-123";
            const int exitCode = 1;
            const int exitCodeRangeStart = 0;
            const int exitCodeRangeEnd = 4;
            Models.ExitOptions terminateExitOption = new Models.ExitOptions() { JobAction = Models.JobAction.Terminate };
            Models.ExitOptions disableExitOption = new Models.ExitOptions()
            {
                JobAction = Models.JobAction.Disable,
                DependencyAction = Models.DependencyAction.Satisfy
            };

            using BatchClient client = ClientUnitTestCommon.CreateDummyClient();
            Models.CloudTask cloudTask = new Models.CloudTask()
            {
                Id = jobId,
                ExitConditions = new Models.ExitConditions()
                {
                    DefaultProperty = disableExitOption,
                    ExitCodeRanges = new List<Models.ExitCodeRangeMapping>() { new Models.ExitCodeRangeMapping(exitCodeRangeStart, exitCodeRangeEnd, terminateExitOption) },
                    ExitCodes = new List<Models.ExitCodeMapping>() { new Models.ExitCodeMapping(exitCode, terminateExitOption) },
                    PreProcessingError = terminateExitOption,
                    FileUploadError = disableExitOption
                }
            };

            CloudTask boundTask = client.JobOperations.GetTask(
                jobId,
                taskId,
                additionalBehaviors: InterceptorFactory.CreateGetTaskRequestInterceptor(cloudTask));

            Assert.Equal(taskId, boundTask.Id); // reading is allowed from a task that is returned from the server.
                                                // These need to be compared as strings because they are different types but we are interested in the values being the same.
            Assert.Equal(disableExitOption.JobAction.ToString(), boundTask.ExitConditions.Default.JobAction.ToString());
            Assert.Equal(DependencyAction.Satisfy, boundTask.ExitConditions.Default.DependencyAction);
            Assert.Equal(DependencyAction.Satisfy, boundTask.ExitConditions.FileUploadError.DependencyAction);
            Assert.Throws<InvalidOperationException>(() => boundTask.ExitConditions = new ExitConditions());
            Assert.Throws<InvalidOperationException>(() => boundTask.DependsOn = new TaskDependencies(new List<string>(), new List<TaskIdRange>()));
            Assert.Throws<InvalidOperationException>(() => boundTask.UserIdentity = new UserIdentity("abc"));
            Assert.Throws<InvalidOperationException>(() => boundTask.CommandLine = "Cannot change command line");
            Assert.Throws<InvalidOperationException>(() => boundTask.ExitConditions.Default = new ExitOptions() { JobAction = JobAction.Terminate });
        }

        private static void AssertPatchableJobPropertiesCanBeWritten(CloudJob boundJob, int priority, MetadataItem metadataItem, OnAllTasksComplete onAllTasksComplete)
        {
            boundJob.Priority = priority + 1;
            Assert.Equal(priority + 1, boundJob.Priority);

            const string virtualMachineSize = "4";
            const string displayName = "Testing-pool";

            boundJob.PoolInformation = new PoolInformation
            {
                AutoPoolSpecification = new AutoPoolSpecification
                {
                    KeepAlive = false,
                    PoolSpecification = new PoolSpecification
                    {
                            VirtualMachineConfiguration = new VirtualMachineConfiguration(imageReference: new ImageReference(), nodeAgentSkuId: "df"),
                            VirtualMachineSize = virtualMachineSize,
                            DisplayName = displayName,
                    }
                }
            };

            Assert.Equal(false, boundJob.PoolInformation.AutoPoolSpecification.KeepAlive);

            Assert.Equal("df", boundJob.PoolInformation.AutoPoolSpecification.PoolSpecification.VirtualMachineConfiguration.NodeAgentSkuId);
            Assert.Equal(virtualMachineSize, boundJob.PoolInformation.AutoPoolSpecification.PoolSpecification.VirtualMachineSize);
            Assert.Equal(displayName, boundJob.PoolInformation.AutoPoolSpecification.PoolSpecification.DisplayName);

            TimeSpan maxWallClockTime = new TimeSpan(0, 0, 0);
            boundJob.Constraints = new JobConstraints(maxWallClockTime, 2);

            Assert.Equal(2, boundJob.Constraints.MaxTaskRetryCount);
            Assert.Equal(maxWallClockTime, boundJob.Constraints.MaxWallClockTime);

            // Swap the value with the name and the name with the value.
            boundJob.Metadata = new[] { new MetadataItem(metadataItem.Value, metadataItem.Name) };
            Assert.Equal(metadataItem.Name, boundJob.Metadata.First().Value);
            Assert.Equal(metadataItem.Value, boundJob.Metadata.First().Name);

            boundJob.OnAllTasksComplete = OnAllTasksComplete.TerminateJob;
            Assert.Equal(OnAllTasksComplete.TerminateJob, boundJob.OnAllTasksComplete);
        }
    }
}
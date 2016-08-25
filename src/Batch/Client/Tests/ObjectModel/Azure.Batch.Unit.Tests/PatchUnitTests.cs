// Copyright (c) Microsoft and contributors.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//
// See the License for the specific language governing permissions and
// limitations under the License.

﻿namespace Azure.Batch.Unit.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using BatchTestCommon;
    using Microsoft.Azure.Batch;
    using Protocol=Microsoft.Azure.Batch.Protocol;
    using Microsoft.Azure.Batch.Common;
    using Microsoft.Azure.Batch.Protocol.BatchRequests;
    using Microsoft.Rest.Azure;
    using TestUtilities;
    using Xunit;

    public class PatchUnitTests
    {
        #region Job

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void TestPatchJob_ThrowsOnUnbound()
        {
            using (BatchClient client = ClientUnitTestCommon.CreateDummyClient())
            {
                CloudJob job = client.JobOperations.CreateJob();
                Assert.Throws<InvalidOperationException>(() => job.CommitChanges());
            }
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void TestPatchJob_ThrowsOnNullPropertySet()
        {
            const string jobId = "Foo";
            var protoJob = new Protocol.Models.CloudJob(
                id: jobId);

            Action<CloudJob> modificationFunction = job => job.PoolInformation = null;
            Action<Protocol.Models.JobPatchParameter> assertAction = patchParameters =>
            {
                Assert.False(true, "Should have failed PATCH validation before issuing the request");
            };

            //This should throw because we set a property to null which is not supported by PATCH
            Assert.Throws<InvalidOperationException>(() => CommonPatchJobTest(protoJob, modificationFunction, assertAction));
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void TestPatchJob_NewComplexParameterIsSerialized()
        {
            const string jobId = "Foo";
            const string newPoolId = "Bar";
            var protoJob = new Protocol.Models.CloudJob(id: jobId);

            Action<CloudJob> modificationFunction = job =>
            {
                job.PoolInformation = new PoolInformation() { PoolId = newPoolId };
            };

            Action<Protocol.Models.JobPatchParameter> assertAction = patchParameters =>
            {
                Assert.Null(patchParameters.Priority);
                Assert.Null(patchParameters.Constraints);
                Assert.Null(patchParameters.Metadata);
                Assert.Null(patchParameters.OnAllTasksComplete);

                Assert.NotNull(patchParameters.PoolInfo);
                Assert.Equal(newPoolId, patchParameters.PoolInfo.PoolId);
            };

            CommonPatchJobTest(protoJob, modificationFunction, assertAction);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void TestPatchJob_NewSimpleParameterIsSerialized()
        {
            const string jobId = "Foo";
            const int newPriority = 5;
            var protoJob = new Protocol.Models.CloudJob(id: jobId);
            var newOnAllTasksCompleted = Protocol.Models.OnAllTasksComplete.TerminateJob;


            Action<CloudJob> modificationFunction = job =>
            {
                job.Priority = newPriority;
                job.OnAllTasksComplete = (Microsoft.Azure.Batch.Common.OnAllTasksComplete?)newOnAllTasksCompleted;
            };

            Action<Protocol.Models.JobPatchParameter> assertAction = patchParameters =>
            {
                Assert.Null(patchParameters.Constraints);
                Assert.Null(patchParameters.Metadata);
                Assert.Null(patchParameters.PoolInfo);

                Assert.NotNull(patchParameters.Priority);
                Assert.Equal(newPriority, patchParameters.Priority);

                Assert.NotNull(patchParameters.OnAllTasksComplete);
                Assert.Equal(newOnAllTasksCompleted, patchParameters.OnAllTasksComplete);
            };

            CommonPatchJobTest(protoJob, modificationFunction, assertAction);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void TestPatchJob_ChangedCollectionParameterIsSerialized()
        {
            const string jobId = "Foo";

            var protoJob = new Protocol.Models.CloudJob(
                id: jobId,
                metadata: new List<Protocol.Models.MetadataItem>()
                    {
                        new Protocol.Models.MetadataItem("Foo", "Bar")
                    });

            Action<CloudJob> modificationFunction = job =>
                {
                    job.Metadata.Add(new MetadataItem("Baz", "Qux"));
                };

            Action<Protocol.Models.JobPatchParameter> assertAction = patchParameters =>
                {
                    Assert.Null(patchParameters.Priority);
                    Assert.Null(patchParameters.Constraints);
                    Assert.Null(patchParameters.PoolInfo);
                    Assert.Null(patchParameters.OnAllTasksComplete);

                    Assert.NotNull(patchParameters.Metadata);
                    Assert.Equal(2, patchParameters.Metadata.Count);
                };

            CommonPatchJobTest(protoJob, modificationFunction, assertAction);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void TestPatchJob_ChangedComplexParameterIsSerialized()
        {
            const string jobId = "Foo";
            TimeSpan newMaxWallClock = TimeSpan.FromSeconds(20);

            var protoJob = new Protocol.Models.CloudJob(
                id: jobId,
                constraints: new Protocol.Models.JobConstraints(maxWallClockTime: TimeSpan.FromSeconds(10)));

            Action<CloudJob> modificationFunction = job =>
                {
                    job.Constraints.MaxWallClockTime = newMaxWallClock;
                };

            Action<Protocol.Models.JobPatchParameter> assertAction = patchParameters =>
                {
                    Assert.Null(patchParameters.Priority);
                    Assert.Null(patchParameters.Metadata);
                    Assert.Null(patchParameters.PoolInfo);
                    Assert.Null(patchParameters.OnAllTasksComplete);

                    Assert.NotNull(patchParameters.Constraints);
                    Assert.Equal(newMaxWallClock, patchParameters.Constraints.MaxWallClockTime);
                    Assert.Null(patchParameters.Constraints.MaxTaskRetryCount);
                };

            CommonPatchJobTest(protoJob, modificationFunction, assertAction);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void TestPatchJob_UnchangedEntitiesAreIgnored()
        {
            const string jobId = "Foo";

            var protoJob = new Protocol.Models.CloudJob(
                id: jobId,
                constraints: new Protocol.Models.JobConstraints(maxWallClockTime: TimeSpan.FromSeconds(10)),
                metadata: new List<Protocol.Models.MetadataItem>() { new Protocol.Models.MetadataItem() },
                poolInfo: new Protocol.Models.PoolInformation(poolId: "Test"));

            Action<CloudJob> modificationFunction = job =>
                {
                    //Do nothing
                };

            Action<Protocol.Models.JobPatchParameter> assertAction = patchParameters =>
                {
                    Assert.Null(patchParameters.Priority);
                    Assert.Null(patchParameters.Metadata);
                    Assert.Null(patchParameters.PoolInfo);
                    Assert.Null(patchParameters.OnAllTasksComplete);
                    Assert.Null(patchParameters.Constraints);
                };

            CommonPatchJobTest(protoJob, modificationFunction, assertAction);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void TestPatchJob_UnchangedChildEntityWithNonemptyListIsIgnored()
        {
            const string jobId = "Foo";

            var protoJob = new Protocol.Models.CloudJob(
                id: jobId,
                poolInfo: new Protocol.Models.PoolInformation(
                    poolId: "Test",
                    autoPoolSpecification: new Protocol.Models.AutoPoolSpecification(
                        Protocol.Models.PoolLifetimeOption.Job,
                        pool: new Protocol.Models.PoolSpecification(
                            "small",
                            applicationPackageReferences: new List<Protocol.Models.ApplicationPackageReference>()
                                {
                                    new Protocol.Models.ApplicationPackageReference("a")
                                }))));

            Action<CloudJob> modificationFunction = job =>
                {
                    //Do nothing
                };

            Action<Protocol.Models.JobPatchParameter> assertAction = patchParameters =>
                {
                    Assert.Null(patchParameters.Priority);
                    Assert.Null(patchParameters.Metadata);
                    Assert.Null(patchParameters.PoolInfo);
                    Assert.Null(patchParameters.OnAllTasksComplete);
                    Assert.Null(patchParameters.Constraints);
                };

            CommonPatchJobTest(protoJob, modificationFunction, assertAction);
        }

        #endregion

        #region Pool

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void TestPatchPool_ThrowsOnUnbound()
        {
            using (BatchClient client = ClientUnitTestCommon.CreateDummyClient())
            {
                CloudPool pool = client.PoolOperations.CreatePool();
                Assert.Throws<InvalidOperationException>(() => pool.CommitChanges());
            }
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void TestPatchPool_ThrowsOnNullPropertySet()
        {
            const string poolId = "Foo";
            var protoPool = new Protocol.Models.CloudPool(id: poolId);

            Action<CloudPool> modificationFunction = pool => pool.StartTask = null;
            Action<Protocol.Models.PoolPatchParameter> assertAction = patchParameters =>
            {
                Assert.False(true, "Should have failed PATCH validation before issuing the request");
            };

            //This should throw because we set a property to null which is not supported by PATCH
            Assert.Throws<InvalidOperationException>(() => CommonPatchPoolTest(protoPool, modificationFunction, assertAction));
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void TestPatchPool_NewComplexParameterIsSerialized()
        {
            const string poolId = "Foo";
            const string newCommandLine = "Hello";

            var protoPool = new Protocol.Models.CloudPool(id: poolId);

            Action<CloudPool> modificationFunction = pool => pool.StartTask = new StartTask(newCommandLine);
            Action<Protocol.Models.PoolPatchParameter> assertAction = patchParameters =>
            {
                Assert.Null(patchParameters.Metadata);
                Assert.Null(patchParameters.ApplicationPackageReferences);
                Assert.Null(patchParameters.CertificateReferences);

                Assert.NotNull(patchParameters.StartTask);
                Assert.Equal(newCommandLine, patchParameters.StartTask.CommandLine);
            };

            CommonPatchPoolTest(protoPool, modificationFunction, assertAction);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void TestPatchPool_ChangedCollectionParameterIsSerialized()
        {
            const string poolId = "Foo";

            var protoPool = new Protocol.Models.CloudPool(
                id: poolId,
                metadata: new List<Protocol.Models.MetadataItem>()
                    {
                        new Protocol.Models.MetadataItem("Foo", "Bar")
                    });

            Action<CloudPool> modificationFunction = pool => pool.Metadata.Add(new MetadataItem("Baz", "Qux"));
            Action<Protocol.Models.PoolPatchParameter> assertAction = patchParameters =>
            {
                Assert.Null(patchParameters.StartTask);
                Assert.Null(patchParameters.ApplicationPackageReferences);
                Assert.Null(patchParameters.CertificateReferences);

                Assert.NotNull(patchParameters.Metadata);
                Assert.Equal(2, patchParameters.Metadata.Count);
            };

            CommonPatchPoolTest(protoPool, modificationFunction, assertAction);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void TestPatchPool_ChangedComplexParameterIsSerialized()
        {
            const string poolId = "Foo";
            const string newCommandLine = "Hello";

            var protoPool = new Protocol.Models.CloudPool(id: poolId, startTask: new Protocol.Models.StartTask(commandLine: "Foo"));

            Action<CloudPool> modificationFunction = pool => pool.StartTask.CommandLine = newCommandLine;
            Action<Protocol.Models.PoolPatchParameter> assertAction = patchParameters =>
            {
                Assert.Null(patchParameters.Metadata);
                Assert.Null(patchParameters.ApplicationPackageReferences);
                Assert.Null(patchParameters.CertificateReferences);

                Assert.NotNull(patchParameters.StartTask);
                Assert.Equal(newCommandLine, patchParameters.StartTask.CommandLine);
            };

            CommonPatchPoolTest(protoPool, modificationFunction, assertAction);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void TestPatchPool_UnchangedEntitiesAreIgnored()
        {
            const string poolId = "Foo";

            var protoPool = new Protocol.Models.CloudPool(
                id: poolId,
                startTask: new Protocol.Models.StartTask(commandLine: "Foo"),
                metadata: new List<Protocol.Models.MetadataItem>() { new Protocol.Models.MetadataItem() });

            Action<CloudPool> modificationFunction = pool =>
                {
                    //Do nothing
                };

            Action<Protocol.Models.PoolPatchParameter> assertAction = patchParameters =>
            {
                Assert.Null(patchParameters.Metadata);
                Assert.Null(patchParameters.ApplicationPackageReferences);
                Assert.Null(patchParameters.CertificateReferences);
                Assert.Null(patchParameters.StartTask);
            };

            CommonPatchPoolTest(protoPool, modificationFunction, assertAction);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void TestPatchPool_UnchangedChildEntityWithNonemptyListIsIgnored()
        {
            const string poolId = "Foo";

            var protoPool = new Protocol.Models.CloudPool(
                id: poolId,
                startTask: new Protocol.Models.StartTask(
                    commandLine: "Foo",
                    resourceFiles: new List<Protocol.Models.ResourceFile>()
                        {
                            new Protocol.Models.ResourceFile("sas", "filepath")
                        }));

            Action<CloudPool> modificationFunction = pool =>
                {
                    //Do nothing
                };

            Action<Protocol.Models.PoolPatchParameter> assertAction = patchParameters =>
                {
                    Assert.Null(patchParameters.Metadata);
                    Assert.Null(patchParameters.ApplicationPackageReferences);
                    Assert.Null(patchParameters.CertificateReferences);
                    Assert.Null(patchParameters.StartTask);
                };

            CommonPatchPoolTest(protoPool, modificationFunction, assertAction);
        }

        #endregion

        #region JobSchedule

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void TestPatchJobSchedule_ThrowsOnUnbound()
        {
            using (BatchClient client = ClientUnitTestCommon.CreateDummyClient())
            {
                CloudJobSchedule jobSchedule = client.JobScheduleOperations.CreateJobSchedule();
                Assert.Throws<InvalidOperationException>(() => jobSchedule.CommitChanges());
            }
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void TestPatchJobSchedule_ThrowsOnNullPropertySet()
        {
            const string jobScheduleId = "Foo";
            var protoJobSchedule = new Protocol.Models.CloudJobSchedule(id: jobScheduleId);

            Action<CloudJobSchedule> modificationFunction = jobSchedule => jobSchedule.JobSpecification = null;
            Action<Protocol.Models.JobSchedulePatchParameter> assertAction = patchParameters =>
            {
                Assert.False(true, "Should have failed PATCH validation before issuing the request");
            };

            //This should throw because we set a property to null which is not supported by PATCH
            Assert.Throws<InvalidOperationException>(() => CommonPatchJobScheduleTest(protoJobSchedule, modificationFunction, assertAction));
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void TestPatchJobSchedule_NewComplexParameterIsSerialized()
        {
            const string jobScheduleId = "Foo";
            const int newPriority = 5;

            var protoJobSchedule = new Protocol.Models.CloudJobSchedule(id: jobScheduleId);

            Action<CloudJobSchedule> modificationFunction = jobSchedule => jobSchedule.JobSpecification = new JobSpecification() { Priority = newPriority };
            Action<Protocol.Models.JobSchedulePatchParameter> assertAction = patchParameters =>
            {
                Assert.Null(patchParameters.Metadata);
                Assert.Null(patchParameters.Schedule);

                Assert.NotNull(patchParameters.JobSpecification);
                Assert.Equal(newPriority, patchParameters.JobSpecification.Priority);
            };

            CommonPatchJobScheduleTest(protoJobSchedule, modificationFunction, assertAction);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void TestPatchJobSchedule_ChangedCollectionParameterIsSerialized()
        {
            const string jobScheduleId = "Foo";

            var protoJobSchedule = new Protocol.Models.CloudJobSchedule(
                id: jobScheduleId,
                metadata: new List<Protocol.Models.MetadataItem>()
                    {
                        new Protocol.Models.MetadataItem("Foo", "Bar")
                    });

            Action<CloudJobSchedule> modificationFunction = jobSchedule => jobSchedule.Metadata.Add(new MetadataItem("Baz", "Qux"));
            Action<Protocol.Models.JobSchedulePatchParameter> assertAction = patchParameters =>
            {
                Assert.Null(patchParameters.JobSpecification);
                Assert.Null(patchParameters.Schedule);

                Assert.NotNull(patchParameters.Metadata);
                Assert.Equal(2, patchParameters.Metadata.Count);
            };

            CommonPatchJobScheduleTest(protoJobSchedule, modificationFunction, assertAction);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void TestPatchJobSchedule_ChangedComplexParameterIsSerialized()
        {
            const string jobScheduleId = "Foo";
            TimeSpan newStartWindow = TimeSpan.FromSeconds(20);

            var protoJobSchedule = new Protocol.Models.CloudJobSchedule(
                id: jobScheduleId,
                schedule: new Protocol.Models.Schedule(startWindow: TimeSpan.FromSeconds(10)));

            Action<CloudJobSchedule> modificationFunction = jobSchedule => jobSchedule.Schedule.StartWindow = newStartWindow;
            Action<Protocol.Models.JobSchedulePatchParameter> assertAction = patchParameters =>
            {
                Assert.Null(patchParameters.JobSpecification);
                Assert.Null(patchParameters.Metadata);

                Assert.NotNull(patchParameters.Schedule);
                Assert.Equal(newStartWindow, patchParameters.Schedule.StartWindow);
            };

            CommonPatchJobScheduleTest(protoJobSchedule, modificationFunction, assertAction);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void TestPatchJobSchedule_UnchangedPropertiesAreIgnored()
        {
            const string jobScheduleId = "Foo";

            var protoJobSchedule = new Protocol.Models.CloudJobSchedule(
                id: jobScheduleId,
                schedule: new Protocol.Models.Schedule(startWindow: TimeSpan.FromSeconds(10)),
                metadata: new List<Protocol.Models.MetadataItem>() { new Protocol.Models.MetadataItem() },
                jobSpecification: new Protocol.Models.JobSpecification(
                    poolInfo: new Protocol.Models.PoolInformation(poolId: "Test")));

            Action<CloudJobSchedule> modificationFunction = jobSchedule =>
                {
                    //Do nothing
                };

            Action<Protocol.Models.JobSchedulePatchParameter> assertAction = patchParameters =>
                {
                    Assert.Null(patchParameters.JobSpecification);
                    Assert.Null(patchParameters.Metadata);
                    Assert.Null(patchParameters.Schedule);
                };

            CommonPatchJobScheduleTest(protoJobSchedule, modificationFunction, assertAction);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void TestPatchJobSchedule_UnchangedChildEntityWithNonEmptyListIsIgnored()
        {
            const string jobScheduleId = "Foo";

            var protoJobSchedule = new Protocol.Models.CloudJobSchedule(
                id: jobScheduleId,
                jobSpecification: new Protocol.Models.JobSpecification(
                    poolInfo: new Protocol.Models.PoolInformation(
                        poolId: "Test",
                        autoPoolSpecification: new Protocol.Models.AutoPoolSpecification(
                        Protocol.Models.PoolLifetimeOption.Job,
                        pool: new Protocol.Models.PoolSpecification(
                            "small",
                            applicationPackageReferences: new List<Protocol.Models.ApplicationPackageReference>()
                                {
                                    new Protocol.Models.ApplicationPackageReference("a")
                                })))));

            Action<CloudJobSchedule> modificationFunction = jobSchedule =>
                {
                    //Do nothing
                };

            Action<Protocol.Models.JobSchedulePatchParameter> assertAction = patchParameters =>
                {
                    Assert.Null(patchParameters.JobSpecification);
                    Assert.Null(patchParameters.Metadata);
                    Assert.Null(patchParameters.Schedule);
                };

            CommonPatchJobScheduleTest(protoJobSchedule, modificationFunction, assertAction);
        }

        #endregion

        #region Private helper methods

        private static void CommonPatchJobTest(
            Protocol.Models.CloudJob startEntity,
            Action<CloudJob> modificationFunction,
            Action<Protocol.Models.JobPatchParameter> assertAction)
        {
            using (BatchClient client = ClientUnitTestCommon.CreateDummyClient())
            {
                CloudJob job = client.JobOperations.GetJob(
                    string.Empty,
                    additionalBehaviors: InterceptorFactory.CreateGetJobRequestInterceptor(startEntity));

                modificationFunction(job);

                var patchInterceptor = ShimPatchJob(assertAction);
                job.CommitChanges(additionalBehaviors: new[] { patchInterceptor });

                //Ensure that the job is in readable but unmodifiable state
                var id = job.Id;
                var priority = job.Priority;

                Assert.Throws<InvalidOperationException>(() => job.Priority = 5);
            }
        }

        private static Protocol.RequestInterceptor ShimPatchJob(Action<Protocol.Models.JobPatchParameter> assertAction)
        {
            return new Protocol.RequestInterceptor(req =>
            {
                var patchJobRequest = (JobPatchBatchRequest)req;

                patchJobRequest.ServiceRequestFunc = ct =>
                    {
                        assertAction(patchJobRequest.Parameters);
                        return Task.FromResult(new AzureOperationHeaderResponse<Protocol.Models.JobPatchHeaders>());
                    };
            });
        }

        private static void CommonPatchPoolTest(
            Protocol.Models.CloudPool startEntity,
            Action<CloudPool> modificationFunction,
            Action<Protocol.Models.PoolPatchParameter> assertAction)
        {
            using (BatchClient client = ClientUnitTestCommon.CreateDummyClient())
            {
                CloudPool pool = client.PoolOperations.GetPool(
                    string.Empty,
                    additionalBehaviors: InterceptorFactory.CreateGetPoolRequestInterceptor(startEntity));

                modificationFunction(pool);

                var patchInterceptor = ShimPatchPool(assertAction);
                pool.CommitChanges(additionalBehaviors: new[] { patchInterceptor });

                //Ensure that the job is in readable but unmodifiable state
                var id = pool.Id;
                Assert.Throws<InvalidOperationException>(() => pool.Metadata = null);
            }
        }

        private static Protocol.RequestInterceptor ShimPatchPool(Action<Protocol.Models.PoolPatchParameter> assertAction)
        {
            return new Protocol.RequestInterceptor(req =>
            {
                var patchPoolRequest = (PoolPatchBatchRequest)req;

                patchPoolRequest.ServiceRequestFunc = ct =>
                {
                    assertAction(patchPoolRequest.Parameters);
                    return Task.FromResult(new AzureOperationHeaderResponse<Protocol.Models.PoolPatchHeaders>());
                };
            });
        }

        private static void CommonPatchJobScheduleTest(
            Protocol.Models.CloudJobSchedule startEntity,
            Action<CloudJobSchedule> modificationFunction,
            Action<Protocol.Models.JobSchedulePatchParameter> assertAction)
        {
            using (BatchClient client = ClientUnitTestCommon.CreateDummyClient())
            {
                CloudJobSchedule jobSchedule = client.JobScheduleOperations.GetJobSchedule(
                    string.Empty,
                    additionalBehaviors: InterceptorFactory.CreateGetJobScheduleRequestInterceptor(startEntity));

                modificationFunction(jobSchedule);

                var patchInterceptor = ShimPatchJobSchedule(assertAction);
                jobSchedule.CommitChanges(additionalBehaviors: new[] { patchInterceptor });

                //Ensure that the job is in readable but unmodifiable state
                var id = jobSchedule.Id;

                Assert.Throws<InvalidOperationException>(() => jobSchedule.Metadata = null);
            }
        }

        private static Protocol.RequestInterceptor ShimPatchJobSchedule(Action<Protocol.Models.JobSchedulePatchParameter> assertAction)
        {
            return new Protocol.RequestInterceptor(req =>
            {
                var patchJobScheduleRequest = (JobSchedulePatchBatchRequest)req;

                patchJobScheduleRequest.ServiceRequestFunc = ct =>
                {
                    assertAction(patchJobScheduleRequest.Parameters);
                    return Task.FromResult(new AzureOperationHeaderResponse<Protocol.Models.JobSchedulePatchHeaders>());
                };
            });
        }

        #endregion

    }
}

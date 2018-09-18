// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

﻿namespace Azure.Batch.Unit.Tests
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
    using Protocol = Microsoft.Azure.Batch.Protocol;
    using Models=Microsoft.Azure.Batch.Protocol.Models;

    using Xunit;

    public class TaskDependenciesUnitTests
    {
        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void CannotSetUsesTaskDependenciesFromABoundCloudJob()
        {
            const string jobId = "id-123";
            const bool usesTaskDependencies = true;
            // Bound

            using (BatchClient client = ClientUnitTestCommon.CreateDummyClient())
            {
                Protocol.RequestInterceptor interceptor = new Protocol.RequestInterceptor(
                    baseRequest =>
                    {
                        var request = (Protocol.BatchRequest<Models.JobGetOptions, AzureOperationResponse<Models.CloudJob, Models.JobGetHeaders>>)baseRequest;
                                                request.ServiceRequestFunc = (token) =>
                        {
                            var response = new AzureOperationResponse<Models.CloudJob, Models.JobGetHeaders>
                            {
                                Body = new Protocol.Models.CloudJob { UsesTaskDependencies = usesTaskDependencies }
                            };

                            return Task.FromResult(response);
                        };
                    });

                var cloudJob = client.JobOperations.GetJob(jobId, additionalBehaviors: new List<BatchClientBehavior> { interceptor });
                Assert.Equal(usesTaskDependencies, cloudJob.UsesTaskDependencies);
                Assert.Throws<InvalidOperationException>(() => cloudJob.UsesTaskDependencies = false);
            }
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void CanReadUsesTaskDependenciesFromABoundCloudJobScheduleTest()
        {
            const string jobId = "id-123";
            const bool usesTaskDependencies = true;

            using (BatchClient client = ClientUnitTestCommon.CreateDummyClient())
            {
                Protocol.RequestInterceptor interceptor = new Protocol.RequestInterceptor(
                    baseRequest =>
                        {
                            var request = (Protocol.BatchRequest<Models.JobScheduleGetOptions, AzureOperationResponse<Models.CloudJobSchedule, Models.JobScheduleGetHeaders>>)baseRequest;

                            request.ServiceRequestFunc = token =>
                                {
                                    var response = new AzureOperationResponse<Models.CloudJobSchedule, Models.JobScheduleGetHeaders>
                                    {
                                        Body = new Protocol.Models.CloudJobSchedule(jobId, schedule: new Protocol.Models.Schedule(), jobSpecification: new Protocol.Models.JobSpecification(){ UsesTaskDependencies = true })
                                    };

                                    return Task.FromResult(response);
                                };
                        });

                Microsoft.Azure.Batch.CloudJobSchedule unboundCloudJob = client.JobScheduleOperations.GetJobSchedule(jobId, additionalBehaviors: new List<BatchClientBehavior> { interceptor });

                Assert.Equal(usesTaskDependencies, unboundCloudJob.JobSpecification.UsesTaskDependencies);
            }
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void CannotModifyUsesTaskDependenciesOnAJobScheduleAfterItHasBeenCommitted()
        {
            const bool usesTaskDependencies = true;


            using (BatchClient client = ClientUnitTestCommon.CreateDummyClient())
            {
                Protocol.RequestInterceptor interceptor = new Protocol.RequestInterceptor(
                    baseRequest =>
                        {
                            var request = (Protocol.BatchRequests.JobScheduleAddBatchRequest)baseRequest;

                            request.ServiceRequestFunc = token =>
                                {
                                    var response = new AzureOperationHeaderResponse<Models.JobScheduleAddHeaders> { Response = new HttpResponseMessage(HttpStatusCode.Created) };

                                    return Task.FromResult(response);
                                };
                        });

                Microsoft.Azure.Batch.CloudJobSchedule cloudJobSchedule = client.JobScheduleOperations.CreateJobSchedule();
                Microsoft.Azure.Batch.JobSpecification jobSpec = new Microsoft.Azure.Batch.JobSpecification(poolInformation: null) { UsesTaskDependencies = usesTaskDependencies };
                cloudJobSchedule.JobSpecification = jobSpec;
                cloudJobSchedule.Commit(new List<BatchClientBehavior> { interceptor });

                // writing isn't allowed for a CloudJobSchedule.JobSpecification.UsesTaskDependencies that is in an invalid state. 
                Assert.Throws<InvalidOperationException>(() => cloudJobSchedule.JobSpecification.UsesTaskDependencies = false);
            }
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void WhenAddingTasksWithDependenciesToAJob_TheDependenciesAreCorrectlyIncludedInTheRestProxy()
        {
            const string jobId = "id-123";

            using (BatchClient client = ClientUnitTestCommon.CreateDummyClient())
            {
                var returnFakeJob = ClientUnitTestCommon.SimulateServiceResponse<Models.JobGetOptions, AzureOperationResponse<Models.CloudJob, Models.JobGetHeaders>>(_ =>
                    new AzureOperationResponse<Models.CloudJob, Models.JobGetHeaders>
                    {
                        Body = new Protocol.Models.CloudJob { Id = jobId, UsesTaskDependencies = true }
                    });

                var verifyTaskDependencies = ClientUnitTestCommon.SimulateServiceResponse<Models.TaskAddParameter, Models.TaskAddOptions, AzureOperationHeaderResponse<Models.TaskAddHeaders>>((parameters, options) =>
                    {
                        Assert.Equal((Int32.Parse(parameters.Id) - 10).ToString(), parameters.DependsOn.TaskIds.Single());
                        Assert.Equal(5, parameters.DependsOn.TaskIdRanges.Single().Start);
                        Assert.Equal(15, parameters.DependsOn.TaskIdRanges.Single().End);

                        return new AzureOperationHeaderResponse<Models.TaskAddHeaders>()
                        {
                            Response = new HttpResponseMessage(HttpStatusCode.Accepted)
                        };
                    });


                var job = client.JobOperations.GetJob(jobId, additionalBehaviors: returnFakeJob);

                for (int j = 0; j < 5; j++)
                {
                    var taskWithDependencies = new Microsoft.Azure.Batch.CloudTask((10 + j).ToString(), "cmd /c hostname")
                    {
                        DependsOn = new Microsoft.Azure.Batch.TaskDependencies(new[] { j.ToString() }, new[] { new Microsoft.Azure.Batch.TaskIdRange(5, 15) }),
                    };

                    job.AddTask(taskWithDependencies, additionalBehaviors: verifyTaskDependencies);  // assertions happen in the callback
                }
            }
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void WhenATaskIsRetrievedFromTheService_ItsDependenciesAreSurfacedCorrectly()
        {
            using (BatchClient client = ClientUnitTestCommon.CreateDummyClient())
            {
                var returnFakeTasks = ClientUnitTestCommon.SimulateServiceResponse<Models.TaskListOptions, AzureOperationResponse<IPage<Models.CloudTask>, Models.TaskListHeaders>>(_ =>
                    new AzureOperationResponse<IPage<Models.CloudTask>, Models.TaskListHeaders>
                    {
                        Body = new FakePage<Models.CloudTask>(new []
                        {
                            new Protocol.Models.CloudTask
                            {
                                DependsOn = new Protocol.Models.TaskDependencies
                                {
                                    TaskIdRanges = new[] { new Protocol.Models.TaskIdRange(5, 15) },
                                    TaskIds = new List<string> { "5" }
                                },
                                Id = "5",
                                State = Models.TaskState.Active,
                            }
                        })
                    });

                var tasks = client.JobOperations.ListTasks("job", additionalBehaviors: returnFakeTasks).ToList();

                var taskDependencies = tasks.First().DependsOn;

                Assert.Equal("5", taskDependencies.TaskIds.Single());
                Assert.Equal(5, taskDependencies.TaskIdRanges.Single().Start);
                Assert.Equal(15, taskDependencies.TaskIdRanges.Single().End);
            }
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void CannotModifyDependenciesOfABoundTask()
        {
            using (BatchClient client = ClientUnitTestCommon.CreateDummyClient())
            {
                var returnFakeTasks = ClientUnitTestCommon.SimulateServiceResponse<Models.TaskGetOptions, AzureOperationResponse<Models.CloudTask, Models.TaskGetHeaders>>(_ =>
                    new AzureOperationResponse<Models.CloudTask, Models.TaskGetHeaders>
                    {
                        Body = new Protocol.Models.CloudTask
                        {
                            DependsOn = new Protocol.Models.TaskDependencies
                            {
                                TaskIdRanges = new[] { new Protocol.Models.TaskIdRange(5, 15) },
                                TaskIds = new List<string> { "5" }
                            },
                            Id = "5",
                            State = Models.TaskState.Active,
                        }
                    });

                var task = client.JobOperations.GetTask("job", "5", additionalBehaviors: returnFakeTasks);

                var newDependencies = Microsoft.Azure.Batch.TaskDependencies.OnId("hello");
                Assert.Throws<InvalidOperationException>(() => task.DependsOn = newDependencies);
            }
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void TaskDependenciesCanSuccessfullyStoreTaskIds()
        {
            IList<string> taskIds = new List<string> { "1", "alice" };

            var taskDependencies = new Microsoft.Azure.Batch.TaskDependencies(taskIds, null);

            Assert.Equal(2, taskDependencies.TaskIds.Count);
            Assert.Equal("1", taskDependencies.TaskIds[0]);
            Assert.Equal("alice", taskDependencies.TaskIds[1]);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void TaskDependenciesCanSuccessfullyStoreTaskIdRanges()
        {
            IList<Microsoft.Azure.Batch.TaskIdRange> taskIdRanges = new List<Microsoft.Azure.Batch.TaskIdRange>
            {
                new Microsoft.Azure.Batch.TaskIdRange(1, 5),
                new Microsoft.Azure.Batch.TaskIdRange(8, 8),
            };

            var taskDependencies = new Microsoft.Azure.Batch.TaskDependencies(null, taskIdRanges);
            
            Assert.Equal(2, taskDependencies.TaskIdRanges.Count);
            Assert.Equal(1, taskDependencies.TaskIdRanges[0].Start);
            Assert.Equal(5, taskDependencies.TaskIdRanges[0].End);
            Assert.Equal(8, taskDependencies.TaskIdRanges[1].Start);
            Assert.Equal(8, taskDependencies.TaskIdRanges[1].End);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void ANullListOfIdsIsTreatedAsAnEmptyList()
        {
            var taskDependencies = new Microsoft.Azure.Batch.TaskDependencies(null, null);
            Assert.NotNull(taskDependencies.TaskIds);
            Assert.Equal(0, taskDependencies.TaskIds.Count);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void ANullListOfRangesIsTreatedAsAnEmptyList()
        {
            var taskDependencies = new Microsoft.Azure.Batch.TaskDependencies(null, null);
            Assert.NotNull(taskDependencies.TaskIdRanges);
            Assert.Equal(0, taskDependencies.TaskIdRanges.Count);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void ADependencyOnASingleIdCanBeExpressedUsingAFactoryMethod()
        {
            var taskDependencies = Microsoft.Azure.Batch.TaskDependencies.OnId("mysupertask");

            Assert.Equal(1, taskDependencies.TaskIds.Count);
            Assert.Equal(0, taskDependencies.TaskIdRanges.Count);
            
            Assert.Equal("mysupertask", taskDependencies.TaskIds[0]);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void ADependencyOnMultipleIdsCanBeExpressedUsingAFactoryMethod_Literals()
        {
            var taskDependencies = Microsoft.Azure.Batch.TaskDependencies.OnIds("mytask", "yourtask", "everybodystask");

            Assert.Equal(3, taskDependencies.TaskIds.Count);
            Assert.Equal(0, taskDependencies.TaskIdRanges.Count);

            Assert.Equal("mytask", taskDependencies.TaskIds[0]);
            Assert.Equal("yourtask", taskDependencies.TaskIds[1]);
            Assert.Equal("everybodystask", taskDependencies.TaskIds[2]);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void ADependencyOnMultipleIdsCanBeExpressedUsingAFactoryMethod_Sequence()
        {
            var taskIds = Enumerable.Range(1, 4).Select(i => "frame" + i);
            var taskDependencies = Microsoft.Azure.Batch.TaskDependencies.OnIds(taskIds);

            Assert.Equal(4, taskDependencies.TaskIds.Count);
            Assert.Equal(0, taskDependencies.TaskIdRanges.Count);

            Assert.Equal("frame1", taskDependencies.TaskIds[0]);
            Assert.Equal("frame4", taskDependencies.TaskIds[3]);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void ADependencyOnMultipleIdsCanBeExpressedUsingAFactoryMethod_ExplicitArray()
        {
            var taskIds = Enumerable.Range(1, 4).Select(i => "frame" + i).ToArray();
            var taskDependencies = Microsoft.Azure.Batch.TaskDependencies.OnIds(taskIds);

            Assert.Equal(4, taskDependencies.TaskIds.Count);
            Assert.Equal(0, taskDependencies.TaskIdRanges.Count);

            Assert.Equal("frame1", taskDependencies.TaskIds[0]);
            Assert.Equal("frame4", taskDependencies.TaskIds[3]);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void ADependencyOnMultipleTasksCanBeExpressedUsingAFactoryMethod_Literals()
        {
            var myTask = new Microsoft.Azure.Batch.CloudTask("mytask", "my.exe");
            var yourTask = new Microsoft.Azure.Batch.CloudTask("yourtask", "your.exe");
            var everybodysTask = new Microsoft.Azure.Batch.CloudTask("everybodystask", "everybodys.exe");
            var taskDependencies = Microsoft.Azure.Batch.TaskDependencies.OnTasks(myTask, yourTask, everybodysTask);

            Assert.Equal(3, taskDependencies.TaskIds.Count);
            Assert.Equal(0, taskDependencies.TaskIdRanges.Count);

            Assert.Equal("mytask", taskDependencies.TaskIds[0]);
            Assert.Equal("yourtask", taskDependencies.TaskIds[1]);
            Assert.Equal("everybodystask", taskDependencies.TaskIds[2]);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void ADependencyOnMultipleTasksCanBeExpressedUsingAFactoryMethod_Sequence()
        {
            var tasks = Enumerable.Range(1, 4).Select(i => new Microsoft.Azure.Batch.CloudTask("frame" + i, "cmd /c hostname"));
            var taskDependencies = Microsoft.Azure.Batch.TaskDependencies.OnTasks(tasks);

            Assert.Equal(4, taskDependencies.TaskIds.Count);
            Assert.Equal(0, taskDependencies.TaskIdRanges.Count);

            Assert.Equal("frame1", taskDependencies.TaskIds[0]);
            Assert.Equal("frame4", taskDependencies.TaskIds[3]);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void ADependencyOnMultipleTasksCanBeExpressedUsingAFactoryMethod_ExplicitArray()
        {
            var tasks = Enumerable.Range(1, 4).Select(i => new Microsoft.Azure.Batch.CloudTask("frame" + i, "cmd /c hostname")).ToArray();
            var taskDependencies = Microsoft.Azure.Batch.TaskDependencies.OnTasks(tasks);

            Assert.Equal(4, taskDependencies.TaskIds.Count);
            Assert.Equal(0, taskDependencies.TaskIdRanges.Count);

            Assert.Equal("frame1", taskDependencies.TaskIds[0]);
            Assert.Equal("frame4", taskDependencies.TaskIds[3]);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void ADependencyOnASingleIdRangeCanBeExpressedUsingAFactoryMethod()
        {
            var taskDependencies = Microsoft.Azure.Batch.TaskDependencies.OnIdRange(10, 15);

            Assert.Equal(0, taskDependencies.TaskIds.Count);
            Assert.Equal(1, taskDependencies.TaskIdRanges.Count);

            Assert.Equal(10, taskDependencies.TaskIdRanges[0].Start);
            Assert.Equal(15, taskDependencies.TaskIdRanges[0].End);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void TaskDependenciesWithNullPropertiesFromProtocol()
        {
            var taskDependencies = new TaskDependencies(new Protocol.Models.TaskDependencies());
            Assert.Null(taskDependencies.TaskIds);
            Assert.Null(taskDependencies.TaskIdRanges);
        }
    }
}
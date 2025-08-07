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
    using TestUtilities;
    using BatchTestCommon;
    using Microsoft.Azure.Batch;
    using Microsoft.Azure.Batch.Auth;
    using Microsoft.Rest.Azure;
    using Xunit;
    using Models = Microsoft.Azure.Batch.Protocol.Models;
    using Protocol = Microsoft.Azure.Batch.Protocol;

    public class ApplicationPackageReferencesUnitTests
    {
        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void GetPoolWithApplicationReferencesTest()
        {
            const string applicationId = "blender.exe";
            const string version = "blender";

            using BatchClient client = ClientUnitTestCommon.CreateDummyClient();
            Protocol.RequestInterceptor interceptor = new Protocol.RequestInterceptor(
                baseRequest =>
                {
                    var request = (Protocol.BatchRequest<Models.PoolGetOptions, AzureOperationResponse<Models.CloudPool, Models.PoolGetHeaders>>)baseRequest;

                    request.ServiceRequestFunc = (token) =>
                    {
                        var response = new AzureOperationResponse<Models.CloudPool, Models.PoolGetHeaders>
                        {
                            Body = new Models.CloudPool
                            {
                                ApplicationPackageReferences = new[]
                                {
                                            new Protocol.Models.ApplicationPackageReference
                                            {
                                                 ApplicationId = applicationId,
                                                 Version = version
                                            }
                                },
                                CurrentDedicatedNodes = 4,
                                VirtualMachineConfiguration = new Models.VirtualMachineConfiguration(imageReference: new Models.ImageReference(), nodeAgentSKUId: "df"),
                                Id = "pool-id"
                            },
                        };

                        return Task.FromResult(response);
                    };
                });

            Microsoft.Azure.Batch.CloudPool cloudPool = client.PoolOperations.GetPool("pool-id", additionalBehaviors: new List<BatchClientBehavior> { interceptor });

            Assert.Equal(version, cloudPool.ApplicationPackageReferences.First().Version);
            Assert.Equal(applicationId, cloudPool.ApplicationPackageReferences.First().ApplicationId);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public async Task UpdateAPoolWithNewApplicationPackages()
        {
            const string applicationId = "blender";
            const string version = "beta";
            const string poolId = "mock-pool";

            using BatchClient client = ClientUnitTestCommon.CreateDummyClient();
            Protocol.RequestInterceptor interceptor = new Protocol.RequestInterceptor(
                baseRequest =>
                {
                    Protocol.BatchRequests.PoolGetBatchRequest request = (Protocol.BatchRequests.PoolGetBatchRequest)baseRequest;

                    request.ServiceRequestFunc = (token) =>
                    {
                        var response = new AzureOperationResponse<Models.CloudPool, Models.PoolGetHeaders>
                        {
                            Body = new Protocol.Models.CloudPool
                            {
                                CurrentDedicatedNodes = 4,
                                VirtualMachineConfiguration = new Models.VirtualMachineConfiguration(imageReference: new Models.ImageReference(), nodeAgentSKUId: "df"),
                                Id = poolId
                            }
                        };
                        return Task.FromResult(response);
                    };
                });

            Microsoft.Azure.Batch.CloudPool cloudPool = client.PoolOperations.GetPool("pool-id", additionalBehaviors: new List<BatchClientBehavior> { interceptor });

            // At this point the pool shouldn't have any application packages
            Assert.Null(cloudPool.ApplicationPackageReferences);

            cloudPool.ApplicationPackageReferences = new[]
            {
                    new Microsoft.Azure.Batch.ApplicationPackageReference()
                    {
                        ApplicationId = applicationId,
                        Version = version
                    }
                };

            interceptor = new Protocol.RequestInterceptor(
                baseRequest =>
                {
                    Protocol.BatchRequests.PoolUpdatePropertiesBatchRequest request =
                        (Protocol.BatchRequests.PoolUpdatePropertiesBatchRequest)baseRequest;

                        // Need to check to see if ApplicationPackageReferences is being populated.
                        Assert.Equal(applicationId, request.Parameters.ApplicationPackageReferences[0].ApplicationId);
                    Assert.Equal(version, request.Parameters.ApplicationPackageReferences[0].Version);

                    request.ServiceRequestFunc = token => Task.FromResult(new AzureOperationHeaderResponse<Models.PoolUpdatePropertiesHeaders>() { Response = new HttpResponseMessage(HttpStatusCode.NoContent) });
                });

            // Updating application pool to contain packages.
            await cloudPool.CommitAsync(additionalBehaviors: new List<BatchClientBehavior> { interceptor });
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void CreateJobWithApplicationReferencesTest()
        {
            const string applicationId = "blender.exe";
            const string version = "blender";
            const string jobId = "mock-job";

            using BatchClient client = ClientUnitTestCommon.CreateDummyClient();
            Microsoft.Azure.Batch.PoolInformation autoPoolSpecification = new Microsoft.Azure.Batch.PoolInformation
            {
                AutoPoolSpecification = new Microsoft.Azure.Batch.AutoPoolSpecification
                {
                    KeepAlive = false,
                    PoolSpecification = new Microsoft.Azure.Batch.PoolSpecification
                    {
                        ApplicationPackageReferences = new List<Microsoft.Azure.Batch.ApplicationPackageReference>
                            {
                                new Microsoft.Azure.Batch.ApplicationPackageReference
                                {
                                    ApplicationId = applicationId,
                                    Version = version
                                }
                            },
                        AutoScaleEnabled = false
                    }
                }
            };

            Microsoft.Azure.Batch.CloudJob cloudJob = client.JobOperations.CreateJob(jobId, autoPoolSpecification);

            Assert.Equal(applicationId, cloudJob.PoolInformation.AutoPoolSpecification.PoolSpecification.ApplicationPackageReferences.First().ApplicationId);
            Assert.Equal(version, cloudJob.PoolInformation.AutoPoolSpecification.PoolSpecification.ApplicationPackageReferences.First().Version);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public async Task CreateJobScheduleWithApplicationPackageReferences()
        {
            const string applicationId = "blender.exe";
            const string version = "blender";
            const string jobId = "mock-job";

            using BatchClient client = ClientUnitTestCommon.CreateDummyClient();
            Protocol.RequestInterceptor interceptor = new Protocol.RequestInterceptor(
                baseRequest =>
                    {
                        var request =
                            (Protocol.BatchRequest<Models.JobScheduleGetOptions, AzureOperationResponse<Models.CloudJobSchedule, Models.JobScheduleGetHeaders>>)baseRequest;

                        request.ServiceRequestFunc = (token) =>
                            {
                                var response = new AzureOperationResponse<Models.CloudJobSchedule, Models.JobScheduleGetHeaders>
                                {
                                    Body = new Models.CloudJobSchedule
                                    {
                                        JobSpecification = new Protocol.Models.JobSpecification
                                        {
                                            PoolInfo = new Models.PoolInformation
                                            {
                                                AutoPoolSpecification = new Models.AutoPoolSpecification
                                                {
                                                    Pool = new Models.PoolSpecification
                                                    {
                                                        ApplicationPackageReferences = new[]
                                                        {
                                                                new Protocol.Models.ApplicationPackageReference
                                                                {
                                                                        ApplicationId = applicationId,
                                                                        Version = version,
                                                                }
                                                        },
                                                        TaskSlotsPerNode = 4
                                                    }
                                                }
                                            }
                                        }
                                    }
                                };
                                return Task.FromResult(response);
                            };
                    });

            Microsoft.Azure.Batch.CloudJobSchedule cloudJobSchedule = await client.JobScheduleOperations.GetJobScheduleAsync(jobId, additionalBehaviors: new List<BatchClientBehavior> { interceptor });

            Assert.Equal(applicationId, cloudJobSchedule.JobSpecification.PoolInformation.AutoPoolSpecification.PoolSpecification.ApplicationPackageReferences.First().ApplicationId);
            Assert.Equal(version, cloudJobSchedule.JobSpecification.PoolInformation.AutoPoolSpecification.PoolSpecification.ApplicationPackageReferences.First().Version);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public async Task GetPoolWithApplicationPackageReferences()
        {
            const string applicationId = "blender.exe";
            const string version = "blender";
            const string poolName = "test-pool";

            using BatchClient client = ClientUnitTestCommon.CreateDummyClient();
            Protocol.RequestInterceptor interceptor = new Protocol.RequestInterceptor(baseRequest =>
            {
                var request = (Protocol.BatchRequest<Models.PoolGetOptions, AzureOperationResponse<Models.CloudPool, Models.PoolGetHeaders>>)baseRequest;

                request.ServiceRequestFunc = async (token) =>
                {
                    var response = new AzureOperationResponse<Models.CloudPool, Models.PoolGetHeaders>
                    {
                        Body = new Models.CloudPool
                        {
                            ApplicationPackageReferences = new[]
                            {
                                    new Protocol.Models.ApplicationPackageReference
                                        {
                                            ApplicationId = applicationId,
                                            Version = version
                                        }
                            },
                        }
                    };

                    Task<AzureOperationResponse<Models.CloudPool, Models.PoolGetHeaders>> task = Task.FromResult(response);
                    return await task;
                };
            });

            var pool = await client.PoolOperations.GetPoolAsync(poolName, additionalBehaviors: new List<BatchClientBehavior> { interceptor });

            var appRefs = pool.ApplicationPackageReferences;

            Assert.Equal(applicationId, appRefs[0].ApplicationId);
            Assert.Equal(version, appRefs[0].Version);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public async Task GetJobScheduleWithApplicationPackageReferences()
        {
            const string applicationId = "app-1";
            const string version = "1.0";

            using BatchClient client = ClientUnitTestCommon.CreateDummyClient();
            Protocol.RequestInterceptor interceptor = new Protocol.RequestInterceptor(baseRequest =>
            {
                var request = (Protocol.BatchRequest<Models.JobScheduleGetOptions, AzureOperationResponse<Models.CloudJobSchedule, Models.JobScheduleGetHeaders>>)baseRequest;

                request.ServiceRequestFunc = (token) =>
                {
                    var response = new AzureOperationResponse<Models.CloudJobSchedule, Models.JobScheduleGetHeaders>
                    {
                        Body = new Models.CloudJobSchedule
                        {
                            JobSpecification = new Protocol.Models.JobSpecification
                            {
                                PoolInfo = new Models.PoolInformation
                                {
                                    AutoPoolSpecification = new Protocol.Models.AutoPoolSpecification
                                    {
                                        Pool = new Models.PoolSpecification
                                        {
                                            ApplicationPackageReferences = new List<Protocol.Models.ApplicationPackageReference>
                                            {
                                                    new Protocol.Models.ApplicationPackageReference
                                                    {
                                                        ApplicationId = applicationId,
                                                        Version = version
                                                    }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    };
                    return Task.FromResult(response);
                };
            });

            Microsoft.Azure.Batch.CloudJobSchedule jobSchedule = await client.JobScheduleOperations.GetJobScheduleAsync("test", additionalBehaviors: new List<BatchClientBehavior> { interceptor });

            Microsoft.Azure.Batch.ApplicationPackageReference apr = jobSchedule.JobSpecification.PoolInformation.AutoPoolSpecification.PoolSpecification.ApplicationPackageReferences.First();

            Assert.Equal(applicationId, apr.ApplicationId);
            Assert.Equal(version, apr.Version);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void CreateCloudTaskWithApplicationPackageReferences()
        {
            const string jobId = "id-123";
            const string taskId = "id-123";
            const string applicationId = "testApp";
            const string applicationVersion = "beta";

            using BatchClient client = ClientUnitTestCommon.CreateDummyClient();
            Models.CloudJob returnFakeJob = new Models.CloudJob(jobId);
            var job = client.JobOperations.GetJob(jobId, additionalBehaviors: InterceptorFactory.CreateGetJobRequestInterceptor(returnFakeJob));

            var verifyAPRs = ClientUnitTestCommon.SimulateServiceResponse<Models.TaskAddParameter, Models.TaskAddOptions, AzureOperationHeaderResponse<Models.TaskAddHeaders>>(
                (parameters, options) =>
            {
                Assert.Equal(applicationId, parameters.ApplicationPackageReferences.First().ApplicationId);
                Assert.Equal(applicationVersion, parameters.ApplicationPackageReferences.First().Version);

                return new AzureOperationHeaderResponse<Models.TaskAddHeaders>
                {
                    Response = new HttpResponseMessage(HttpStatusCode.Accepted)
                };
            });

            var taskWithAPRs = new CloudTask(taskId, "cmd /c hostname")
            {
                ApplicationPackageReferences = new List<ApplicationPackageReference>
                    {
                        new ApplicationPackageReference
                        {
                            ApplicationId = applicationId,
                            Version = applicationVersion
                        }
                    }
            };

            job.AddTask(taskWithAPRs, additionalBehaviors: verifyAPRs);  // assertions happen in the callback
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void GetJobManagerTaskWithApplicationPackageReferences()
        {
            const string jobId = "id-123";
            const string applicationId = "foo";
            const string version = "beta";

            using BatchClient client = ClientUnitTestCommon.CreateDummyClient();
            Models.CloudJob protoJob = new Models.CloudJob
            {
                Id = jobId,
                JobManagerTask = new Models.JobManagerTask
                {
                    ApplicationPackageReferences = new List<Models.ApplicationPackageReference>
                        {
                            new Models.ApplicationPackageReference
                            {
                                Version = version, ApplicationId = applicationId
                            }
                        }
                }
            };

            var job = client.JobOperations.GetJob(jobId, additionalBehaviors: InterceptorFactory.CreateGetJobRequestInterceptor(protoJob));
            Assert.Equal(applicationId, job.JobManagerTask.ApplicationPackageReferences.First().ApplicationId);
            Assert.Equal(version, job.JobManagerTask.ApplicationPackageReferences.First().Version);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void CheckIfGetApplicationPackageReferencesIsReadableButNotWritableOnABoundPool()
        {
            const string applicationId = "blender.exe";
            const string version = "blender";

            using BatchClient client = ClientUnitTestCommon.CreateDummyClient();
            Protocol.RequestInterceptor interceptor = new Protocol.RequestInterceptor(
                baseRequest =>
                {
                    var request = (Protocol.BatchRequest<Models.PoolGetOptions, AzureOperationResponse<Models.CloudPool, Models.PoolGetHeaders>>)baseRequest;

                    request.ServiceRequestFunc = (token) =>
                    {
                        var response = new AzureOperationResponse<Models.CloudPool, Models.PoolGetHeaders>
                        {
                            Body = new Models.CloudPool
                            {
                                ApplicationPackageReferences = new[]
                                {
                                         new Protocol.Models.ApplicationPackageReference
                                         {
                                              ApplicationId = applicationId,
                                              Version = version
                                         }
                                }
                            }
                        };

                        return Task.FromResult(response);
                    };
                });

            Microsoft.Azure.Batch.CloudPool cloudPool = client.PoolOperations.GetPool("pool-id", additionalBehaviors: new List<BatchClientBehavior> { interceptor });
            Assert.Throws<InvalidOperationException>(() => cloudPool.ApplicationPackageReferences.First().ApplicationId = applicationId);
            Assert.Throws<InvalidOperationException>(() => cloudPool.ApplicationPackageReferences.First().Version = version);
            Assert.Equal(version, cloudPool.ApplicationPackageReferences.First().Version);
            Assert.Equal(applicationId, cloudPool.ApplicationPackageReferences.First().ApplicationId);
        }
    }
}

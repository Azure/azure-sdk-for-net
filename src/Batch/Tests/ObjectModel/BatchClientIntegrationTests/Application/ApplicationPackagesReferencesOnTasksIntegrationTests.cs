using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BatchClientIntegrationTests.Fixtures;
using BatchClientIntegrationTests.IntegrationTestUtilities;

using BatchTestCommon;

using Microsoft.Azure.Batch;
using Microsoft.Azure.Batch.Common;
using Microsoft.Azure.Batch.Protocol;

using Xunit;

namespace BatchClientIntegrationTests.Application
{
    public class ApplicationPackagesReferencesOnTasksIntegrationTests
    {
        private static readonly TimeSpan TestTimeout = TimeSpan.FromMinutes(4);

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.MediumDuration)]
        public async Task CanCreateCloudTasksWithAppPackageReferences()
        {
            var jobId = TestUtilities.GetMyName()+ "-"+ Guid.NewGuid();
            var taskId = "task-id";

            const string applicationId = "blender";

            Func<Task> test = async () =>
            {
                using (BatchClient client = await TestUtilities.OpenBatchClientFromEnvironmentAsync().ConfigureAwait(false))
                {
                    var poolInfo = new PoolInformation
                    {
                        AutoPoolSpecification = new AutoPoolSpecification
                        {
                            PoolSpecification = new PoolSpecification
                            {
                                CloudServiceConfiguration = new CloudServiceConfiguration(PoolFixture.OSFamily),
                                VirtualMachineSize = PoolFixture.VMSize,
                            },
                            PoolLifetimeOption = PoolLifetimeOption.Job
                        }
                    };

                    CloudJob response = null;
                    try
                    {
                        CloudJob job = client.JobOperations.CreateJob(jobId, poolInfo);
                        await job.CommitAsync().ConfigureAwait(false);

                        response = await client.JobOperations.GetJobAsync(jobId).ConfigureAwait(false);

                        CloudTask cloudTask = new CloudTask(taskId, "cmd /c ping 127.0.0.1")
                        {
                            ApplicationPackageReferences =
                                new[]
                                    {
                                        new ApplicationPackageReference
                                            {
                                                ApplicationId = applicationId,
                                                Version = PoolFixture.VMSize
                                            }
                                    }
                        };

                        await response.AddTaskAsync(cloudTask);

                        CloudTask cloudTaskResponse = await response.GetTaskAsync(taskId);

                    }
                    finally
                    {
                        if (response != null)
                        {
                            TestUtilities.DeleteJobIfExistsAsync(client, jobId).Wait();
                        }
                    }
                }
            };

            await SynchronizationContextHelper.RunTestAsync(test, TestTimeout);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.MediumDuration)]
        public async Task CanCreateJobManagerTaskWithAppPackageReferences()
        {
            var jobId = TestUtilities.GetMyName() + "-" + Guid.NewGuid();

            const string applicationId = "blender";

            /*Func<Task> test = async () =>
            {*/
            using (BatchClient client = await TestUtilities.OpenBatchClientFromEnvironmentAsync().ConfigureAwait(false))
            {
                
                var poolInfo = new PoolInformation
                {
                    AutoPoolSpecification = new AutoPoolSpecification
                    {
                        PoolSpecification = new PoolSpecification
                        {
                            CloudServiceConfiguration = new CloudServiceConfiguration(PoolFixture.OSFamily),
                            VirtualMachineSize = PoolFixture.VMSize,
                        },
                        PoolLifetimeOption = PoolLifetimeOption.Job
                    }
                };

                CloudJob response = null;
                try
                {
                    //List<CloudJob> jobs = await client.JobOperations.ListJobs().ToListAsync();

                    CloudJob job = client.JobOperations.CreateJob(jobId, poolInfo);
                    job.JobManagerTask = new JobManagerTask { ApplicationPackageReferences = new []{ new ApplicationPackageReference
                    {
                        ApplicationId = applicationId,
                        Version = PoolFixture.VMSize
                    }}};
                    
                    await job.CommitAsync().ConfigureAwait(false);

                    response = await client.JobOperations.GetJobAsync(jobId).ConfigureAwait(false);

                    Assert.NotNull(response);

                    //Assert.Equal(applicationId, response.JobManagerTask.ApplicationPackageReferences.First().ApplicationId);

                }
                catch(Exception exception)
                {
                    throw exception;
                }
                finally
                {
                    if (response != null)
                    {
                        TestUtilities.DeleteJobIfExistsAsync(client, jobId).Wait();
                    }
                }
            }
            //};
            //await SynchronizationContextHelper.RunTestAsync(test, TestTimeout);
        }
    }

    public abstract class BatchCustomClientBehavior : RequestInterceptor
    {
        public BatchCustomClientBehavior():base()
        {
        }

        public static void Dosomthing(IBatchRequest request)
        {
        }
    }
}


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
    using Microsoft.Rest.Azure;
    using Xunit;
    using Protocol=Microsoft.Azure.Batch.Protocol;
    using Models = Microsoft.Azure.Batch.Protocol.Models;

    public class BindingStateConstraintUnitTests
    {
        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void Pool_UnboundAndBoundTests()
        {
            const string cloudPoolId = "id-123";
            const string osFamily = "2";
            const string virtualMachineSize = "4";
            const string cloudPoolDisplayName = "pool-display-name-test";
            MetadataItem metadataItem = new MetadataItem("foo", "bar");

            BatchSharedKeyCredentials credentials = ClientUnitTestCommon.CreateDummySharedKeyCredential();
            using (BatchClient client = BatchClient.Open(credentials))
            {
                CloudPool cloudPool = client.PoolOperations.CreatePool(cloudPoolId, virtualMachineSize, new CloudServiceConfiguration(osFamily));
                cloudPool.DisplayName = cloudPoolDisplayName;
                cloudPool.Metadata = new List<MetadataItem> { metadataItem };
                
                Assert.Equal(cloudPoolId, cloudPool.Id); // can set an unbound object
                Assert.Equal(cloudPool.Metadata.First().Name, metadataItem.Name);
                Assert.Equal(cloudPool.Metadata.First().Value, metadataItem.Value);

                Protocol.RequestInterceptor interceptor = new Protocol.RequestInterceptor(baseRequest =>
                {
                    var request = (Protocol.BatchRequests.PoolAddBatchRequest)baseRequest;

                    request.ServiceRequestFunc = (ct) =>
                    {
                        var response = new AzureOperationHeaderResponse<Models.PoolAddHeaders>
                        {
                            Response = new HttpResponseMessage(HttpStatusCode.Accepted),
                        };
                        
                        var task = Task.FromResult(response);
                        return task;
                    };
                });

                cloudPool.Commit(additionalBehaviors: new List<BatchClientBehavior> { interceptor });

                // writing isn't allowed for a cloudPool that is in an readonly state.
                Assert.Throws<InvalidOperationException>(() => cloudPool.AutoScaleFormula = "Foo");
                Assert.Throws<InvalidOperationException>(() => cloudPool.DisplayName = "Foo");
                Assert.Throws<InvalidOperationException>(() => cloudPool.CloudServiceConfiguration = null);
                Assert.Throws<InvalidOperationException>(() => cloudPool.ResizeTimeout = TimeSpan.FromSeconds(10));
                Assert.Throws<InvalidOperationException>(() => cloudPool.Metadata = null);
                Assert.Throws<InvalidOperationException>(() => cloudPool.TargetDedicated = 5);
                Assert.Throws<InvalidOperationException>(() => cloudPool.VirtualMachineConfiguration = null);
                Assert.Throws<InvalidOperationException>(() => cloudPool.VirtualMachineSize = "small");

                //read is allowed though
                Assert.Null(cloudPool.AutoScaleFormula);
                Assert.Equal(cloudPoolDisplayName, cloudPool.DisplayName);
                Assert.NotNull(cloudPool.CloudServiceConfiguration);
                Assert.Null(cloudPool.ResizeTimeout);
                Assert.Equal(1, cloudPool.Metadata.Count);
                Assert.Null(cloudPool.TargetDedicated);
                Assert.Null(cloudPool.VirtualMachineConfiguration);
                Assert.Equal(virtualMachineSize, cloudPool.VirtualMachineSize);

                interceptor = new Protocol.RequestInterceptor(baseRequest =>
                {
                    var request = (Protocol.BatchRequest<Models.PoolGetOptions, AzureOperationResponse<Models.CloudPool, Models.PoolGetHeaders>>)baseRequest;

                    request.ServiceRequestFunc = (ct) =>
                    {
                        var response = new AzureOperationResponse<Models.CloudPool, Models.PoolGetHeaders>
                        {
                            Body = new Models.CloudPool
                            {
                                DisplayName = cloudPoolDisplayName,
                                Metadata = new[]
                                {
                                    new Models.MetadataItem
                                    {
                                        Name = metadataItem.Name,
                                        Value = metadataItem.Value
                                    }
                                },
                                CloudServiceConfiguration = new Models.CloudServiceConfiguration()
                            }
                        };

                        var task = Task.FromResult(response);
                        return task;
                    };
                });


                CloudPool boundPool = client.PoolOperations.GetPool(cloudPoolId, additionalBehaviors: new List<BatchClientBehavior> { interceptor });

                // Cannot change these bound properties.
                Assert.Throws<InvalidOperationException>(() => boundPool.DisplayName = "cannot-change-display-name");
                Assert.Throws<InvalidOperationException>(() => boundPool.Id = "cannot-change-id");
                
                Assert.Throws<InvalidOperationException>(() => boundPool.TargetDedicated = 1);
                Assert.Throws<InvalidOperationException>(() => boundPool.VirtualMachineSize = "cannot-change-1");


                // Swap the value with the name and the name with the value.
                boundPool.Metadata = new[] { new MetadataItem(metadataItem.Value, metadataItem.Name) };
                Assert.Equal(metadataItem.Name, boundPool.Metadata.First().Value);
                Assert.Equal(metadataItem.Value, boundPool.Metadata.First().Name);
            }
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void CloudJobSchedule_UnboundAndBoundTests()
        {
            const string jobScheduleId = "id-123";
            const string displayName = "DisplayNameFoo";
            MetadataItem metadataItem = new MetadataItem("foo", "bar");

            BatchSharedKeyCredentials credentials = ClientUnitTestCommon.CreateDummySharedKeyCredential();
            using (BatchClient client = BatchClient.Open(credentials))
            {
                Protocol.RequestInterceptor interceptor = new Protocol.RequestInterceptor(baseRequest =>
                {
                    var request = (Protocol.BatchRequests.JobScheduleAddBatchRequest)baseRequest;

                    request.ServiceRequestFunc = async (token) =>
                    {
                        var response = new AzureOperationHeaderResponse<Models.JobScheduleAddHeaders>
                        {
                            Response = new HttpResponseMessage(HttpStatusCode.Accepted),
                        };

                        var task = Task.FromResult(response);
                        return await task;
                    };
                });

                CloudJobSchedule jobSchedule = client.JobScheduleOperations.CreateJobSchedule();
                jobSchedule.Id = jobScheduleId;
                jobSchedule.DisplayName = displayName;
                jobSchedule.Metadata = new List<MetadataItem> { metadataItem };

                Assert.Equal(jobSchedule.Id, jobScheduleId); // can set an unbound object
                Assert.Equal(jobSchedule.Metadata.First().Name, metadataItem.Name);
                Assert.Equal(jobSchedule.Metadata.First().Value, metadataItem.Value);

                jobSchedule.Commit(additionalBehaviors: new List<BatchClientBehavior> { interceptor });

                // writing isn't allowed for a jobSchedule that is in an read only state.
                Assert.Throws<InvalidOperationException>(() => jobSchedule.Id = "cannot-change-id");
                Assert.Throws<InvalidOperationException>(() => jobSchedule.DisplayName = "cannot-change-display-name");

                //Can still read though
                Assert.Equal(jobScheduleId, jobSchedule.Id);
                Assert.Equal(displayName, jobSchedule.DisplayName);

                DateTime creationTime = DateTime.Now;

                interceptor = new Protocol.RequestInterceptor(baseRequest =>
                {
                    var request = (Protocol.BatchRequest<Models.JobScheduleGetOptions, AzureOperationResponse<Models.CloudJobSchedule, Models.JobScheduleGetHeaders>>)baseRequest;

                    request.ServiceRequestFunc = async (token) =>
                    {
                        var response = new AzureOperationResponse<Models.CloudJobSchedule, Models.JobScheduleGetHeaders>
                        {
                            Response = new HttpResponseMessage(HttpStatusCode.Accepted),
                            Body = new Models.CloudJobSchedule
                            {
                                Id = jobScheduleId,
                                DisplayName = displayName,
                                Metadata = new[] {
                                new Models.MetadataItem
                                    {
                                        Name = metadataItem.Name, Value = metadataItem.Value
                                    }
                                },
                                CreationTime = creationTime
                            }
                        };

                        var task = Task.FromResult(response);
                        return await task;
                    };
                });

                CloudJobSchedule boundJobSchedule = client.JobScheduleOperations.GetJobSchedule(jobScheduleId, additionalBehaviors: new List<BatchClientBehavior> { interceptor });

                Assert.Equal(jobScheduleId, boundJobSchedule.Id); // reading is allowed from a jobSchedule that is returned from the server.
                Assert.Equal(creationTime, boundJobSchedule.CreationTime);
                Assert.Equal(displayName, boundJobSchedule.DisplayName);

                Assert.Throws<InvalidOperationException>(() => boundJobSchedule.DisplayName = "cannot-change-display-name");
                Assert.Throws<InvalidOperationException>(() => boundJobSchedule.Id = "cannot-change-id");
            }
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public void CloudJob_UnboundAndBoundTests()
        {
            const string jobId = "id-123";
            const string displayName = "DisplayNameFoo";
            MetadataItem metadataItem = new MetadataItem("foo", "bar");
            const int priority = 0;

            BatchSharedKeyCredentials credentials = ClientUnitTestCommon.CreateDummySharedKeyCredential();
            using (BatchClient client = BatchClient.Open(credentials))
            {
                Protocol.RequestInterceptor interceptor = new Protocol.RequestInterceptor(baseRequest =>
                {
                    var request = (Protocol.BatchRequests.JobAddBatchRequest)baseRequest;

                    request.ServiceRequestFunc = async (token) =>
                    {
                        var response = new AzureOperationHeaderResponse<Models.JobAddHeaders>
                        {
                             Response = new HttpResponseMessage(HttpStatusCode.Accepted),
                        };

                        var task = Task.FromResult(response);
                        return await task;
                    };
                });

                CloudJob cloudJob = client.JobOperations.CreateJob(jobId, new PoolInformation { AutoPoolSpecification = new AutoPoolSpecification { KeepAlive = false }});
                cloudJob.Id = jobId;
                cloudJob.DisplayName = displayName;
                cloudJob.Metadata = new List<MetadataItem> { metadataItem };
                cloudJob.Priority = priority;

                Assert.Throws<InvalidOperationException>(() => cloudJob.Url); // cannot read a Url since it's unbound at this point.
                Assert.Equal(cloudJob.Id, jobId); // can set an unbound object
                Assert.Equal(cloudJob.Metadata.First().Name, metadataItem.Name);
                Assert.Equal(cloudJob.Metadata.First().Value, metadataItem.Value);

                cloudJob.Commit(additionalBehaviors: new List<BatchClientBehavior> { interceptor });

                // writing isn't allowed for a job that is in an invalid state.
                Assert.Throws<InvalidOperationException>(() => cloudJob.Id = "cannot-change-id");
                Assert.Throws<InvalidOperationException>(() => cloudJob.DisplayName = "cannot-change-display-name");
                
                DateTime creationTime = DateTime.Now;

                interceptor = new Protocol.RequestInterceptor(baseRequest =>
                {
                    var request = (Protocol.BatchRequest<Models.JobGetOptions, AzureOperationResponse<Models.CloudJob, Models.JobGetHeaders>>)baseRequest;

                    request.ServiceRequestFunc = async (token) =>
                    {
                        var response = new AzureOperationResponse<Models.CloudJob, Models.JobGetHeaders>
                        {
                            Body = new Models.CloudJob
                            {
                                Id = jobId,
                                DisplayName = displayName,
                                Metadata = new[]{
                                                    new Models.MetadataItem
                                                        {
                                                            Name = metadataItem.Name, Value = metadataItem.Value
                                                        }
                                                },
                                CreationTime = creationTime,
                                Priority = priority,
                                Url = ClientUnitTestCommon.DummyBaseUrl
                            }
                        };

                        var task = Task.FromResult(response);
                        return await task;
                    };
                });

                CloudJob boundJob = client.JobOperations.GetJob(jobId, additionalBehaviors: new List<BatchClientBehavior> { interceptor });

                Assert.Equal(jobId, boundJob.Id); // reading is allowed from a job that is returned from the server.
                Assert.Equal(creationTime, boundJob.CreationTime);
                Assert.Equal(displayName, boundJob.DisplayName);

                // You can change the Priority, Metadata, PoolInformation and JobConstraints after a job has been returned.
                ValuesThatCanBeChangedInABoundJob(boundJob, priority, metadataItem);

                // Can only read a url from a returned object.
                Assert.Equal(ClientUnitTestCommon.DummyBaseUrl, boundJob.Url);

                // Cannot change a bound displayName and Id.
                Assert.Throws<InvalidOperationException>(() => boundJob.DisplayName = "cannot-change-display-name");
                Assert.Throws<InvalidOperationException>(() => boundJob.Id = "cannot-change-id");
            }
        }

        private static void ValuesThatCanBeChangedInABoundJob(CloudJob boundJob, int priority, MetadataItem metadataItem)
        {
            boundJob.Priority = priority + 1;
            Assert.Equal(priority + 1, boundJob.Priority);

            const string osFamily = "2";
            const string virtualMachineSize = "4";
            const string displayName = "Testing-pool";
            
            boundJob.PoolInformation = new PoolInformation
            {
                AutoPoolSpecification = new AutoPoolSpecification
                {
                    KeepAlive = false,
                    PoolSpecification = new PoolSpecification
                    {
                            CloudServiceConfiguration = new CloudServiceConfiguration(osFamily),
                            VirtualMachineSize = virtualMachineSize,
                            DisplayName = displayName,
                    }
                }
            };

            Assert.Equal(false, boundJob.PoolInformation.AutoPoolSpecification.KeepAlive);

            Assert.Equal(osFamily, boundJob.PoolInformation.AutoPoolSpecification.PoolSpecification.CloudServiceConfiguration.OSFamily);
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
        }
    }
}
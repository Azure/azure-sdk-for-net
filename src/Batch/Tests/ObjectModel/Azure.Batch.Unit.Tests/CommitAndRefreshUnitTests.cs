namespace Azure.Batch.Unit.Tests
{
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using BatchTestCommon;
    using Microsoft.Azure.Batch;
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Xunit;
    using Xunit.Abstractions;
    using Protocol = Microsoft.Azure.Batch.Protocol;

    public class CommitAndRefreshUnitTests
    {
        private readonly ITestOutputHelper testOutputHelper;

        public CommitAndRefreshUnitTests(ITestOutputHelper testOutputHelper)
        {
            this.testOutputHelper = testOutputHelper;
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public async Task UnboundJobCommitAndRefreshWorks()
        {
            using (BatchClient batchClient = ClientUnitTestCommon.CreateDummyClient())
            {
                const string id = "Bar";
                const string displayName = "Baz";
                var prepTask = new Protocol.Models.JobPreparationTask(id);

                Protocol.Models.CloudJob protoJob = new Protocol.Models.CloudJob(
                    id: id,
                    displayName: displayName,
                    jobPreparationTask: prepTask);
                batchClient.CustomBehaviors.Add(this.CreateJobRequestInterceptor(protoJob));

                CloudJob job = batchClient.JobOperations.CreateJob(id, new PoolInformation()
                    {
                        PoolId = "Foo"
                    });

                await job.CommitAsync();

                await job.RefreshAsync();

                Assert.Equal(id, job.Id);
                Assert.Equal(displayName, job.DisplayName);
                Assert.Null(job.PoolInformation);
                Assert.NotNull(job.JobPreparationTask);
                Assert.Equal(prepTask.Id, job.JobPreparationTask.Id);
            }
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public async Task UnboundPoolCommitAndRefreshWorks()
        {
            using (BatchClient batchClient = ClientUnitTestCommon.CreateDummyClient())
            {
                const string id = "Bar";
                const string displayName = "Baz";
                var startTask = new Protocol.Models.StartTask("cmd /c dir");
                var protoPool = new Protocol.Models.CloudPool(
                    id: id,
                    displayName: displayName,
                    startTask: startTask);
                batchClient.CustomBehaviors.Add(this.CreatePoolRequestInterceptor(protoPool));

                CloudPool pool = batchClient.PoolOperations.CreatePool(id, "Woo", new CloudServiceConfiguration("4"));

                await pool.CommitAsync();

                await pool.RefreshAsync();

                Assert.Equal(id, pool.Id);
                Assert.Equal(displayName, pool.DisplayName);
                Assert.Null(pool.CloudServiceConfiguration);
                Assert.NotNull(pool.StartTask);
                Assert.Equal(startTask.CommandLine, pool.StartTask.CommandLine);
            }
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public async Task UnboundJobScheduleCommitAndRefreshWorks()
        {
            using (BatchClient batchClient = ClientUnitTestCommon.CreateDummyClient())
            {
                const string id = "Bar";
                const string displayName = "Baz";
                var jobSpecification = new Protocol.Models.JobSpecification(displayName: displayName);
                var protoJobSchedule = new Protocol.Models.CloudJobSchedule(
                    id: id,
                    displayName: displayName,
                    jobSpecification: jobSpecification);
                batchClient.CustomBehaviors.Add(this.CreateJobScheduleRequestInterceptor(protoJobSchedule));

                CloudJobSchedule jobSchedule = batchClient.JobScheduleOperations.CreateJobSchedule(id, new Schedule(), null);

                await jobSchedule.CommitAsync();

                await jobSchedule.RefreshAsync();

                Assert.Equal(id, jobSchedule.Id);
                Assert.Equal(displayName, jobSchedule.DisplayName);
                Assert.Null(jobSchedule.Schedule);
                Assert.NotNull(jobSchedule.JobSpecification);
                Assert.Equal(jobSpecification.DisplayName, jobSchedule.JobSpecification.DisplayName);
            }
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public async Task UnboundCertificateCommitAndRefreshWorks()
        {
            using (BatchClient batchClient = ClientUnitTestCommon.CreateDummyClient())
            {
                string pfxFilePath = TestCommon.GetTemporaryCertificateFilePath("unboundcertificateunittest.pfx");
                try
                {
                    CertificateBuilder.CreateSelfSignedInFile("test", pfxFilePath, CommonResources.CertificatePassword);

                    const string expectedThumbprint = "ABC";
                    var protoCertificate = new Protocol.Models.Certificate(thumbprint: expectedThumbprint);

                    batchClient.CustomBehaviors.Add(this.CreateCertificateRequestInterceptor(protoCertificate));

                    Certificate certificate = batchClient.CertificateOperations.CreateCertificate(
                        pfxFilePath,
                        CommonResources.CertificatePassword);

                    Assert.NotNull(certificate.ThumbprintAlgorithm);

                    await certificate.CommitAsync();

                    await certificate.RefreshAsync();

                    Assert.Equal(expectedThumbprint, certificate.Thumbprint);
                    Assert.Null(certificate.ThumbprintAlgorithm);
                }
                finally
                {
                    File.Delete(pfxFilePath);
                }
            }
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public async Task UnboundTaskRefreshFails()
        {
            var task = new CloudTask("Foo", "Bar");
            await Assert.ThrowsAsync<InvalidOperationException>(async () => await task.RefreshAsync());
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public async Task UnboundJobDirectRefreshFailsWithMissingPathVariables()
        {
            using (BatchClient batchClient = ClientUnitTestCommon.CreateDummyClient())
            {
                CloudJob job = batchClient.JobOperations.CreateJob(null, new PoolInformation());

                ValidationException e = await Assert.ThrowsAsync<ValidationException>(async () => await job.RefreshAsync());
                Assert.Contains("'jobId' cannot be null", e.Message);
            }
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public async Task UnboundPoolDirectRefreshFailsWithMissingPathVariables()
        {
            using (BatchClient batchClient = ClientUnitTestCommon.CreateDummyClient())
            {
                CloudPool pool = batchClient.PoolOperations.CreatePool();

                ValidationException e = await Assert.ThrowsAsync<ValidationException>(async () => await pool.RefreshAsync());
                Assert.Contains("'poolId' cannot be null", e.Message);
            }
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public async Task UnboundJobScheduleDirectRefreshFailsWithMissingPathVariables()
        {
            using (BatchClient batchClient = ClientUnitTestCommon.CreateDummyClient())
            {
                CloudJobSchedule jobSchedule = batchClient.JobScheduleOperations.CreateJobSchedule();

                ValidationException e = await Assert.ThrowsAsync<ValidationException>(async () => await jobSchedule.RefreshAsync());
                Assert.Contains("'jobScheduleId' cannot be null", e.Message);
            }
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public async Task UnboundCertificateDirectRefreshFailsWithMissingPathVariables()
        {
            using (BatchClient batchClient = ClientUnitTestCommon.CreateDummyClient())
            {
                Certificate certificate = new Certificate(batchClient, null, null, null, null);

                ValidationException e = await Assert.ThrowsAsync<ValidationException>(async () => await certificate.RefreshAsync());
                Assert.Contains("'thumbprintAlgorithm' cannot be null", e.Message);
            }
        }


        private Protocol.RequestInterceptor CreateJobRequestInterceptor(Protocol.Models.CloudJob jobToReturn)
        {
            return new Protocol.RequestInterceptor(req =>
                {
                    var getJobRequest = req as Protocol.BatchRequests.JobGetBatchRequest;
                    var addJobRequest = req as Protocol.BatchRequests.JobAddBatchRequest;

                    if (getJobRequest != null)
                    {
                        getJobRequest.ServiceRequestFunc = ct =>
                            {
                                return Task.FromResult(new AzureOperationResponse<Protocol.Models.CloudJob, Protocol.Models.JobGetHeaders>()
                                    {
                                        Body = jobToReturn
                                    });
                            };
                    }

                    if (addJobRequest != null)
                    {
                        addJobRequest.ServiceRequestFunc = ct =>
                            {
                                return Task.FromResult(new AzureOperationHeaderResponse<Protocol.Models.JobAddHeaders>());
                            };
                    }
                });
        }

        private Protocol.RequestInterceptor CreatePoolRequestInterceptor(Protocol.Models.CloudPool poolToReturn)
        {
            return new Protocol.RequestInterceptor(req =>
            {
                var getPoolRequest = req as Protocol.BatchRequests.PoolGetBatchRequest;
                var addPoolRequest = req as Protocol.BatchRequests.PoolAddBatchRequest;

                if (getPoolRequest != null)
                {
                    getPoolRequest.ServiceRequestFunc = ct =>
                    {
                        return Task.FromResult(new AzureOperationResponse<Protocol.Models.CloudPool, Protocol.Models.PoolGetHeaders>()
                        {
                            Body = poolToReturn
                        });
                    };
                }

                if (addPoolRequest != null)
                {
                    addPoolRequest.ServiceRequestFunc = ct =>
                    {
                        return Task.FromResult(new AzureOperationHeaderResponse<Protocol.Models.PoolAddHeaders>());
                    };
                }
            });
        }

        private Protocol.RequestInterceptor CreateJobScheduleRequestInterceptor(Protocol.Models.CloudJobSchedule jobScheduleToReturn)
        {
            return new Protocol.RequestInterceptor(req =>
            {
                var getJobScheduleRequest = req as Protocol.BatchRequests.JobScheduleGetBatchRequest;
                var addJobScheduleRequest = req as Protocol.BatchRequests.JobScheduleAddBatchRequest;

                if (getJobScheduleRequest != null)
                {
                    getJobScheduleRequest.ServiceRequestFunc = ct =>
                    {
                        return Task.FromResult(new AzureOperationResponse<Protocol.Models.CloudJobSchedule, Protocol.Models.JobScheduleGetHeaders>()
                        {
                            Body = jobScheduleToReturn
                        });
                    };
                }

                if (addJobScheduleRequest != null)
                {
                    addJobScheduleRequest.ServiceRequestFunc = ct =>
                    {
                        return Task.FromResult(new AzureOperationHeaderResponse<Protocol.Models.JobScheduleAddHeaders>());
                    };
                }
            });
        }

        private Protocol.RequestInterceptor CreateCertificateRequestInterceptor(Protocol.Models.Certificate certificateToReturn)
        {
            return new Protocol.RequestInterceptor(req =>
            {
                var getCertificateRequest = req as Protocol.BatchRequests.CertificateGetBatchRequest;
                var addCertificateRequest = req as Protocol.BatchRequests.CertificateAddBatchRequest;

                if (getCertificateRequest != null)
                {
                    getCertificateRequest.ServiceRequestFunc = ct =>
                    {
                        return Task.FromResult(new AzureOperationResponse<Protocol.Models.Certificate, Protocol.Models.CertificateGetHeaders>()
                        {
                            Body = certificateToReturn
                        });
                    };
                }

                if (addCertificateRequest != null)
                {
                    addCertificateRequest.ServiceRequestFunc = ct =>
                    {
                        return Task.FromResult(new AzureOperationHeaderResponse<Protocol.Models.CertificateAddHeaders>());
                    };
                }
            });
        }
    }
}

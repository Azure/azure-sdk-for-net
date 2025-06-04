// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

﻿namespace Azure.Batch.Unit.Tests
{
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using BatchTestCommon;
    using Microsoft.Azure.Batch;
    using Microsoft.Rest;
    using TestUtilities;
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
            using BatchClient batchClient = ClientUnitTestCommon.CreateDummyClient();
            const string id = "Bar";
            const string displayName = "Baz";
            var prepTask = new Protocol.Models.JobPreparationTask(id);

            Protocol.Models.CloudJob protoJob = new Protocol.Models.CloudJob(
                id: id,
                displayName: displayName,
                jobPreparationTask: prepTask);

            CloudJob job = batchClient.JobOperations.CreateJob(id, new PoolInformation()
            {
                PoolId = "Foo"
            });

            await job.CommitAsync(additionalBehaviors: InterceptorFactory.CreateAddJobRequestInterceptor());

            await job.RefreshAsync(additionalBehaviors: InterceptorFactory.CreateGetJobRequestInterceptor(protoJob));

            Assert.Equal(id, job.Id);
            Assert.Equal(displayName, job.DisplayName);
            Assert.Null(job.PoolInformation);
            Assert.NotNull(job.JobPreparationTask);
            Assert.Equal(prepTask.Id, job.JobPreparationTask.Id);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public async Task UnboundPoolCommitAndRefreshWorks()
        {
            using BatchClient batchClient = ClientUnitTestCommon.CreateDummyClient();
            const string id = "Bar";
            const string displayName = "Baz";
            var startTask = new Protocol.Models.StartTask("cmd /c dir");
            var protoPool = new Protocol.Models.CloudPool(
                id: id,
                displayName: displayName,
                startTask: startTask);

            CloudPool pool = batchClient.PoolOperations.CreatePool(id, "Woo", new VirtualMachineConfiguration(imageReference: new ImageReference(), nodeAgentSkuId: "df"));

            await pool.CommitAsync(additionalBehaviors: InterceptorFactory.CreateAddPoolRequestInterceptor());

            await pool.RefreshAsync(additionalBehaviors: InterceptorFactory.CreateGetPoolRequestInterceptor(protoPool));

            Assert.Equal(id, pool.Id);
            Assert.Equal(displayName, pool.DisplayName);
            Assert.Null(pool.VirtualMachineConfiguration);
            Assert.NotNull(pool.StartTask);
            Assert.Equal(startTask.CommandLine, pool.StartTask.CommandLine);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public async Task UnboundJobScheduleCommitAndRefreshWorks()
        {
            using BatchClient batchClient = ClientUnitTestCommon.CreateDummyClient();
            const string id = "Bar";
            const string displayName = "Baz";
            var jobSpecification = new Protocol.Models.JobSpecification()
            {
                DisplayName = displayName
            };
            var protoJobSchedule = new Protocol.Models.CloudJobSchedule(
                id: id,
                displayName: displayName,
                jobSpecification: jobSpecification);

            CloudJobSchedule jobSchedule = batchClient.JobScheduleOperations.CreateJobSchedule(id, new Schedule(), null);

            await jobSchedule.CommitAsync(additionalBehaviors: InterceptorFactory.CreateAddJobScheduleRequestInterceptor());

            await jobSchedule.RefreshAsync(additionalBehaviors: InterceptorFactory.CreateGetJobScheduleRequestInterceptor(protoJobSchedule));

            Assert.Equal(id, jobSchedule.Id);
            Assert.Equal(displayName, jobSchedule.DisplayName);
            Assert.Null(jobSchedule.Schedule);
            Assert.NotNull(jobSchedule.JobSpecification);
            Assert.Equal(jobSpecification.DisplayName, jobSchedule.JobSpecification.DisplayName);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public async Task UnboundCertificateCommitAndRefreshWorks()
        {
            using BatchClient batchClient = ClientUnitTestCommon.CreateDummyClient();
            const string expectedThumbprint = "ABC";
            var protoCertificate = new Protocol.Models.Certificate(thumbprint: expectedThumbprint);
            Certificate certificate = new Certificate(
                batchClient,
                null,
                string.Empty,
                expectedThumbprint,
                "SHA1");

            Assert.NotNull(certificate.ThumbprintAlgorithm);

            await certificate.CommitAsync(additionalBehaviors: InterceptorFactory.CreateAddCertificateRequestInterceptor());

            await certificate.RefreshAsync(additionalBehaviors: InterceptorFactory.CreateGetCertificateRequestInterceptor(protoCertificate));

            Assert.Equal(expectedThumbprint, certificate.Thumbprint);
            Assert.Null(certificate.ThumbprintAlgorithm);
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
            using BatchClient batchClient = ClientUnitTestCommon.CreateDummyClient();
            CloudJob job = batchClient.JobOperations.CreateJob(null, new PoolInformation());

            ValidationException e = await Assert.ThrowsAsync<ValidationException>(async () => await job.RefreshAsync());
            Assert.Contains("'jobId' cannot be null", e.Message);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public async Task UnboundPoolDirectRefreshFailsWithMissingPathVariables()
        {
            using BatchClient batchClient = ClientUnitTestCommon.CreateDummyClient();
            CloudPool pool = batchClient.PoolOperations.CreatePool();

            ValidationException e = await Assert.ThrowsAsync<ValidationException>(async () => await pool.RefreshAsync());
            Assert.Contains("'poolId' cannot be null", e.Message);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public async Task UnboundJobScheduleDirectRefreshFailsWithMissingPathVariables()
        {
            using BatchClient batchClient = ClientUnitTestCommon.CreateDummyClient();
            CloudJobSchedule jobSchedule = batchClient.JobScheduleOperations.CreateJobSchedule();

            ValidationException e = await Assert.ThrowsAsync<ValidationException>(async () => await jobSchedule.RefreshAsync());
            Assert.Contains("'jobScheduleId' cannot be null", e.Message);
        }

        [Fact]
        [Trait(TestTraits.Duration.TraitName, TestTraits.Duration.Values.VeryShortDuration)]
        public async Task UnboundCertificateDirectRefreshFailsWithMissingPathVariables()
        {
            using BatchClient batchClient = ClientUnitTestCommon.CreateDummyClient();
            Certificate certificate = new Certificate(batchClient, null, null, null, null);

            ValidationException e = await Assert.ThrowsAsync<ValidationException>(async () => await certificate.RefreshAsync());
            Assert.Contains("'thumbprintAlgorithm' cannot be null", e.Message);
        }
    }
}

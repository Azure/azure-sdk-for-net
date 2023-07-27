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

﻿using Microsoft.Azure.Batch.Conventions.Files.IntegrationTests.Utilities;
using Microsoft.Azure.Batch.Conventions.Files.Utilities;
using Microsoft.Azure.Batch.FileConventions.Integration.Tests.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using BlobTestUtils = Microsoft.Azure.Batch.Conventions.Files.IntegrationTests.Utilities.BlobUtils;

namespace Microsoft.Azure.Batch.Conventions.Files.IntegrationTests
{
    public class CloudJobExtensionsTests : IntegrationTest, IClassFixture<CloudJobExtensionsTests.JobIdFixtureImpl>
    {
        private readonly string _jobId;

        public CloudJobExtensionsTests(JobIdFixtureImpl jobIdFixture, ITestOutputHelper output)
            : base(jobIdFixture, output)
        {
            _jobId = jobIdFixture.JobId;
        }

        public class JobIdFixtureImpl : JobIdFixture
        {
            protected override string TestId { get; } = "cloudjobext";
        }

        [LiveTest]
        [Fact]
        public async Task CloudJobOutputStorageExtensionSavesToCorrectContainer()
        {
            using (var batchClient = BatchClient.Open(new FakeBatchServiceClient()))
            {
                var job = batchClient.JobOperations.CreateJob(_jobId, null);

                await job.OutputStorage(blobClient).SaveAsync(JobOutputKind.JobOutput, FilePath("TestText1.txt"));

                var blobs = job.OutputStorage(blobClient).ListOutputs(JobOutputKind.JobOutput).ToList();
                Assert.NotEmpty(blobs);
                Assert.True(BlobTestUtils.CheckOutputFileRefListContainsDenotedUri(blobs, $"{_jobId}/$JobOutput/Files/TestText1.txt"));
            }
        }

        [LiveTest]
        [Fact]
        public async Task CloudJobGetStorageContainerUrlExtensionSasPermitsWritingToJobOutputContainer()
        {
            using (var batchClient = BatchClient.Open(new FakeBatchServiceClient()))
            {
                var job = batchClient.JobOperations.CreateJob(_jobId, null);

                var url = job.GetOutputStorageContainerUrl(blobClient, TimeSpan.FromMinutes(5));

                // Write something using the SAS URL

                var jobOutputStorageFromUrl = new JobOutputStorage(new Uri(url));

                await jobOutputStorageFromUrl.SaveAsync(JobOutputKind.JobPreview, FilePath("TestText1.txt"), "SavedViaSas.txt");

                // And retrieve that same thing using the account credentials to verify
                // it was successfully written (and to the correct place)

                var jobOutputStorageFromAccount = job.OutputStorage(blobClient);

                var blobs = jobOutputStorageFromAccount.ListOutputs(JobOutputKind.JobPreview).ToList();
                Assert.NotEmpty(blobs);
                Assert.True(BlobTestUtils.CheckOutputFileRefListContainsDenotedUri(blobs, $"{_jobId}/$JobPreview/SavedViaSas.txt"));
            }
        }
    }

    public class CloudJobExtensionsContainerCreationTests : IntegrationTest, IClassFixture<CloudJobExtensionsContainerCreationTests.JobIdFixtureImpl>
    {
        private readonly string _jobId;

        public CloudJobExtensionsContainerCreationTests(JobIdFixtureImpl jobIdFixture, ITestOutputHelper output)
            : base(jobIdFixture, output)
        {
            _jobId = jobIdFixture.JobId;
        }

        public class JobIdFixtureImpl : JobIdFixture
        {
            protected override string TestId { get; } = "cloudjobcc";

            protected override bool AutoCreateContainer { get; } = false;
        }

        [LiveTest]
        [Fact]
        public async Task CloudJobPrepareOutputStorageExtensionCreatesCorrectContainer()
        {
            using (var batchClient = BatchClient.Open(new FakeBatchServiceClient()))
            {
                var job = batchClient.JobOperations.CreateJob(_jobId, null);

                var blobClient = base.blobClient;

                var expectedContainer = ContainerNameUtils.GetSafeContainerName(_jobId);

                var expectedContainerExists = await base.blobClient.GetBlobContainerClient(expectedContainer).ExistsAsync();

                Assert.False(expectedContainerExists, $"Output storage container for {_jobId} should not have existed before test ran");

                await job.PrepareOutputStorageAsync(base.blobClient);

                expectedContainerExists = await base.blobClient.GetBlobContainerClient(expectedContainer).ExistsAsync();

                Assert.True(expectedContainerExists, $"Output storage container for {_jobId} should have existed after test ran");

            }
        }
    }
}

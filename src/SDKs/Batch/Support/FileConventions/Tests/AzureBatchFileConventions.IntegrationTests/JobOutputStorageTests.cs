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

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using Microsoft.Azure.Batch.Conventions.Files.IntegrationTests.Utilities;
using Microsoft.Azure.Batch.Conventions.Files.IntegrationTests.Xunit;
using Microsoft.WindowsAzure.Storage.RetryPolicies;

namespace Microsoft.Azure.Batch.Conventions.Files.IntegrationTests
{
    public class JobOutputStorageTests : IntegrationTest, IClassFixture<JobOutputStorageTests.JobIdFixtureImpl>
    {
        private readonly string _jobId;

        public JobOutputStorageTests(JobIdFixtureImpl jobIdFixture, ITestOutputHelper output)
            : base(jobIdFixture, output)
        {
            _jobId = jobIdFixture.JobId;
        }

        public class JobIdFixtureImpl : JobIdFixture
        {
            protected override string TestId { get; } = "joboutput";
        }

        [Fact]
        public async Task IfAFileIsSaved_ThenItAppearsInTheList()
        {
            var jobOutputStorage = new JobOutputStorage(StorageAccount, _jobId);
            await jobOutputStorage.SaveAsyncImpl(JobOutputKind.JobOutput, FileBase, "TestText1.txt");

            var blobs = jobOutputStorage.ListOutputs(JobOutputKind.JobOutput).ToList();
            Assert.NotEqual(0, blobs.Count);
            Assert.Contains(blobs, b => b.Uri.AbsoluteUri.EndsWith($"{_jobId}/$JobOutput/TestText1.txt"));
        }

        [Fact]
        public async Task IfAFileIsSaved_UsingThePublicMethod_ThenTheCurrentDirectoryIsInferred()
        {
            // To avoid needing to mess with the process working directory, relative path tests
            // normally go through the internal SaveAsyncImpl method.  This test verifies that
            // the public SaveAsync method forwards the appropriate directory to SaveAsyncImpl.

            Assert.True(File.Exists(FilePath("TestText1.txt")), "Current directory is not what was expected - cannot verify current directory inference");

            var jobOutputStorage = new JobOutputStorage(StorageAccount, _jobId);
            await jobOutputStorage.SaveAsync(JobOutputKind.JobOutput, FilePath("TestText1.txt"));

            var blobs = jobOutputStorage.ListOutputs(JobOutputKind.JobOutput).ToList();
            Assert.NotEqual(0, blobs.Count);
            Assert.Contains(blobs, b => b.Uri.AbsoluteUri.EndsWith($"{_jobId}/$JobOutput/Files/TestText1.txt"));
        }

        [Fact]
        public async Task IfAFileIsSavedWithAnExplicitPath_ThenItAppearsInTheList()
        {
            var jobOutputStorage = new JobOutputStorage(StorageAccount, _jobId);
            await jobOutputStorage.SaveAsync(JobOutputKind.JobOutput, FilePath("TestText1.txt"), "RenamedTestText1.txt");

            var blobs = jobOutputStorage.ListOutputs(JobOutputKind.JobOutput).ToList();
            Assert.NotEqual(0, blobs.Count);
            Assert.Contains(blobs, b => b.Uri.AbsoluteUri.EndsWith($"{_jobId}/$JobOutput/RenamedTestText1.txt"));
        }

        [Fact]
        public async Task IfAFileWithAMultiLevelPathIsSaved_ThenItAppearsInTheList()
        {
            var jobOutputStorage = new JobOutputStorage(StorageAccount, _jobId);
            await jobOutputStorage.SaveAsyncImpl(JobOutputKind.JobOutput, FileBase, "File\\Under\\TestText2.txt");

            var blobs = jobOutputStorage.ListOutputs(JobOutputKind.JobOutput).ToList();
            Assert.NotEqual(0, blobs.Count);
            Assert.Contains(blobs, b => b.Uri.AbsoluteUri.EndsWith($"{_jobId}/$JobOutput/File/Under/TestText2.txt"));
        }

        [Fact]
        public async Task IfAFileIsSavedWithAnExplicitMultiLevelPath_ThenItAppearsInTheList()
        {
            var jobOutputStorage = new JobOutputStorage(StorageAccount, _jobId);
            await jobOutputStorage.SaveAsync(JobOutputKind.JobOutput, FilePath("TestText1.txt"), "File/In/The/Depths/TestText3.txt");

            var blobs = jobOutputStorage.ListOutputs(JobOutputKind.JobOutput).ToList();
            Assert.NotEqual(0, blobs.Count);
            Assert.Contains(blobs, b => b.Uri.AbsoluteUri.EndsWith($"{_jobId}/$JobOutput/File/In/The/Depths/TestText3.txt"));
        }

        [Fact]
        public async Task IfAFileIsSaved_ThenItCanBeGot()
        {
            var jobOutputStorage = new JobOutputStorage(StorageAccount, _jobId);
            await jobOutputStorage.SaveAsync(JobOutputKind.JobOutput, FilePath("TestText1.txt"), "Gettable.txt");

            var blob = await jobOutputStorage.GetOutputAsync(JobOutputKind.JobOutput, "Gettable.txt");

            var blobContent = await blob.ReadAsByteArrayAsync();
            var originalContent = File.ReadAllBytes(FilePath("TestText1.txt"));

            Assert.Equal(originalContent, blobContent);
        }

        [Fact]
        public async Task IfAFileIsSavedWithAMultiLevelPath_ThenItCanBeGot()
        {
            var jobOutputStorage = new JobOutputStorage(StorageAccount, _jobId);
            await jobOutputStorage.SaveAsync(JobOutputKind.JobOutput, FilePath("TestText1.txt"), "This/File/Is/Gettable.txt");

            var blob = await jobOutputStorage.GetOutputAsync(JobOutputKind.JobOutput, "This/File/Is/Gettable.txt");

            var blobContent = await blob.ReadAsByteArrayAsync();
            var originalContent = File.ReadAllBytes(FilePath("TestText1.txt"));

            Assert.Equal(originalContent, blobContent);
        }

        [Fact]
        public async Task IfARetryPolicyIsSpecifiedInTheStorageAccountConstructor_ThenItIsUsed()
        {
            var jobOutputStorage = new JobOutputStorage(StorageAccount, _jobId, new LinearRetry(TimeSpan.FromSeconds(5), 4));
            await jobOutputStorage.SaveAsync(JobOutputKind.JobOutput, FilePath("TestText1.txt"), "SavedWithLinearRetry1.txt");

            var output = await jobOutputStorage.GetOutputAsync(JobOutputKind.JobOutput, "SavedWithLinearRetry1.txt");
            var blob = output.CloudBlob;
            var storageClient = blob.ServiceClient;
            Assert.IsType<LinearRetry>(storageClient.DefaultRequestOptions.RetryPolicy);
        }

        [Fact]
        public async Task IfARetryPolicyIsSpecifiedInTheContainerUrlConstructor_ThenItIsUsed()
        {
            using (var batchClient = BatchClient.Open(new FakeBatchServiceClient()))
            {
                var job = batchClient.JobOperations.CreateJob(_jobId, null);
                var container = job.GetOutputStorageContainerUrl(StorageAccount, TimeSpan.FromMinutes(2));

                var jobOutputStorage = new JobOutputStorage(new Uri(container), new LinearRetry(TimeSpan.FromSeconds(5), 4));
                await jobOutputStorage.SaveAsync(JobOutputKind.JobOutput, FilePath("TestText1.txt"), "SavedWithLinearRetry2.txt");

                var output = await jobOutputStorage.GetOutputAsync(JobOutputKind.JobOutput, "SavedWithLinearRetry2.txt");
                var blob = output.CloudBlob;
                var storageClient = blob.ServiceClient;
                Assert.IsType<LinearRetry>(storageClient.DefaultRequestOptions.RetryPolicy);
            }
        }
    }
}

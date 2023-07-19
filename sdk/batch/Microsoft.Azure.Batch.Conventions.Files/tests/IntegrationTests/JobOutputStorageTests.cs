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
using Microsoft.Azure.Batch.FileConventions.Integration.Tests.Infrastructure;
using Microsoft.Azure.Batch.Conventions.Files.Utilities;
using BlobTestUtils = Microsoft.Azure.Batch.Conventions.Files.IntegrationTests.Utilities.BlobUtils;

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

        [LiveTest]
        [Fact]
        public async Task IfAFileIsSaved_ThenItAppearsInTheList()
        {
            var jobOutputStorage = new JobOutputStorage(blobClient, _jobId);
            await jobOutputStorage.SaveAsyncImpl(JobOutputKind.JobOutput, FileBase, "TestText1.txt");

            var blobs = jobOutputStorage.ListOutputs(JobOutputKind.JobOutput).ToList();
            Assert.NotEmpty(blobs);
            Assert.True(BlobTestUtils.CheckOutputFileRefListContainsDenotedUri(blobs, $"{_jobId}/$JobOutput/TestText1.txt"));
        }

        [LiveTest]
        [Fact]
        public async Task IfAFileIsSaved_UsingThePublicMethod_ThenTheCurrentDirectoryIsInferred()
        {
            // To avoid needing to mess with the process working directory, relative path tests
            // normally go through the internal SaveAsyncImpl method.  This test verifies that
            // the public SaveAsync method forwards the appropriate directory to SaveAsyncImpl.

            Assert.True(File.Exists(FilePath("TestText1.txt")), "Current directory is not what was expected - cannot verify current directory inference");

            var jobOutputStorage = new JobOutputStorage(blobClient, _jobId);
            await jobOutputStorage.SaveAsync(JobOutputKind.JobOutput, FilePath("TestText1.txt"));

            var blobs = jobOutputStorage.ListOutputs(JobOutputKind.JobOutput).ToList();
            Assert.NotEmpty(blobs);
            Assert.True(BlobTestUtils.CheckOutputFileRefListContainsDenotedUri(blobs, $"{_jobId}/$JobOutput/Files/TestText1.txt"));
        }

        [LiveTest]
        [Fact]
        public async Task IfAFileIsSavedWithAnExplicitPath_ThenItAppearsInTheList()
        {
            var jobOutputStorage = new JobOutputStorage(blobClient, _jobId);
            await jobOutputStorage.SaveAsync(JobOutputKind.JobOutput, FilePath("TestText1.txt"), "RenamedTestText1.txt");

            var blobs = jobOutputStorage.ListOutputs(JobOutputKind.JobOutput).ToList();
            Assert.NotEmpty(blobs);
            Assert.True(BlobTestUtils.CheckOutputFileRefListContainsDenotedUri(blobs, $"{_jobId}/$JobOutput/RenamedTestText1.txt"));
        }

        [LiveTest]
        [Fact]
        public async Task IfAFileWithAMultiLevelPathIsSaved_ThenItAppearsInTheList()
        {
            var jobOutputStorage = new JobOutputStorage(blobClient, _jobId);
            await jobOutputStorage.SaveAsyncImpl(JobOutputKind.JobOutput, FileBase, "File\\Under\\TestText2.txt");

            var blobs = jobOutputStorage.ListOutputs(JobOutputKind.JobOutput).ToList();
            Assert.NotEmpty(blobs);
            Assert.True(BlobTestUtils.CheckOutputFileRefListContainsDenotedUri(blobs, $"{_jobId}/$JobOutput/File/Under/TestText2.txt"));
        }

        [LiveTest]
        [Fact]
        public async Task IfAFileIsSavedWithAnExplicitMultiLevelPath_ThenItAppearsInTheList()
        {
            var jobOutputStorage = new JobOutputStorage(blobClient, _jobId);
            await jobOutputStorage.SaveAsync(JobOutputKind.JobOutput, FilePath("TestText1.txt"), "File/In/The/Depths/TestText3.txt");

            var blobs = jobOutputStorage.ListOutputs(JobOutputKind.JobOutput).ToList();
            Assert.NotEmpty(blobs);
            Assert.True(BlobTestUtils.CheckOutputFileRefListContainsDenotedUri(blobs, $"{_jobId}/$JobOutput/File/In/The/Depths/TestText3.txt"));
        }

        [LiveTest]
        [Fact]
        public async Task IfAFileIsSaved_ThenItAppearsInTheListByHierachy()
        {
            var jobOutputStorage = new JobOutputStorage(blobClient, _jobId);
            await jobOutputStorage.SaveAsync(JobOutputKind.JobOutput, FilePath("TestText1.txt"), "This/File/Is/Gettable.txt");

            var jobOutputContainerName = ContainerNameUtils.GetSafeContainerName(_jobId);
            var blobs = blobClient.GetBlobContainerClient(jobOutputContainerName).ListBlobsByHierachy().ToList();
            Assert.NotEmpty(blobs);
            Assert.Contains(blobs, b => b.Blob.Name.Equals($"$JobOutput/This/File/Is/Gettable.txt"));
        }

        [LiveTest]
        [Fact]
        public async Task IfAFileIsSaved_ThenItCanBeGot()
        {
            var jobOutputStorage = new JobOutputStorage(blobClient, _jobId);
            await jobOutputStorage.SaveAsync(JobOutputKind.JobOutput, FilePath("TestText1.txt"), "Gettable.txt");

            var blob = jobOutputStorage.GetOutput(JobOutputKind.JobOutput, "Gettable.txt");

            var blobContent = await blob.ReadAsByteArrayAsync();
            var originalContent = File.ReadAllBytes(FilePath("TestText1.txt"));

            Assert.Equal(originalContent, blobContent);
        }

        [LiveTest]
        [Fact]
        public async Task IfAFileIsSavedWithAMultiLevelPath_ThenItCanBeGot()
        {
            var jobOutputStorage = new JobOutputStorage(blobClient, _jobId);
            await jobOutputStorage.SaveAsync(JobOutputKind.JobOutput, FilePath("TestText1.txt"), "This/File/Is/Gettable.txt");

            var blob = jobOutputStorage.GetOutput(JobOutputKind.JobOutput, "This/File/Is/Gettable.txt");

            var blobContent = await blob.ReadAsByteArrayAsync();
            var originalContent = File.ReadAllBytes(FilePath("TestText1.txt"));

            Assert.Equal(originalContent, blobContent);
        }
    }
}

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

using Microsoft.Azure.Batch.Conventions.Files.IntegrationTests.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using System.Threading;
using Microsoft.Azure.Batch.Conventions.Files.IntegrationTests.Xunit;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.RetryPolicies;

namespace Microsoft.Azure.Batch.Conventions.Files.IntegrationTests
{
    public class TaskOutputStorageTests : IntegrationTest, IClassFixture<TaskOutputStorageTests.JobIdFixtureImpl>
    {
        private readonly string _jobId;
        private readonly string _taskId = "test-task";

        public TaskOutputStorageTests(JobIdFixtureImpl jobIdFixture, ITestOutputHelper output)
            : base(jobIdFixture, output)
        {
            _jobId = jobIdFixture.JobId;
        }

        public class JobIdFixtureImpl : JobIdFixture
        {
            protected override string TestId { get; } = "taskoutput";
        }

        [Fact]
        public async Task IfAFileIsSaved_ThenItAppearsInTheList()
        {
            var taskOutputStorage = new TaskOutputStorage(StorageAccount, _jobId, _taskId);
            await taskOutputStorage.SaveAsyncImpl(TaskOutputKind.TaskPreview, FileBase, "TestText1.txt");

            var blobs = taskOutputStorage.ListOutputs(TaskOutputKind.TaskPreview).ToList();
            Assert.NotEqual(0, blobs.Count);
            Assert.Contains(blobs, b => b.Uri.AbsoluteUri.EndsWith($"{_jobId}/{_taskId}/$TaskPreview/TestText1.txt"));
        }

        [Fact]
        public async Task IfAFileIsSaved_UsingThePublicMethod_ThenTheCurrentDirectoryIsInferred()
        {
            // To avoid needing to mess with the process working directory, relative path tests
            // normally go through the internal SaveAsyncImpl method.  This test verifies that
            // the public SaveAsync method forwards the appropriate directory to SaveAsyncImpl.

            Assert.True(File.Exists(FilePath("TestText1.txt")), "Current directory is not what was expected - cannot verify current directory inference");

            var taskOutputStorage = new TaskOutputStorage(StorageAccount, _jobId, _taskId);
            await taskOutputStorage.SaveAsync(TaskOutputKind.TaskPreview, FilePath("TestText1.txt"));

            var blobs = taskOutputStorage.ListOutputs(TaskOutputKind.TaskPreview).ToList();
            Assert.NotEqual(0, blobs.Count);
            Assert.Contains(blobs, b => b.Uri.AbsoluteUri.EndsWith($"{_jobId}/{_taskId}/$TaskPreview/TestText1.txt"));
        }

        [Fact]
        public async Task IfAFileIsSavedWithAnExplicitPath_ThenItAppearsInTheList()
        {
            var taskOutputStorage = new TaskOutputStorage(StorageAccount, _jobId, _taskId);
            await taskOutputStorage.SaveAsync(TaskOutputKind.TaskPreview, FilePath("TestText1.txt"), "RenamedTestText1.txt");

            var blobs = taskOutputStorage.ListOutputs(TaskOutputKind.TaskPreview).ToList();
            Assert.NotEqual(0, blobs.Count);
            Assert.Contains(blobs, b => b.Uri.AbsoluteUri.EndsWith($"{_jobId}/{_taskId}/$TaskPreview/RenamedTestText1.txt"));
        }

        [Fact]
        public async Task IfAFileWithAMultiLevelPathIsSaved_ThenItAppearsInTheList()
        {
            var taskOutputStorage = new TaskOutputStorage(StorageAccount, _jobId, _taskId);
            await taskOutputStorage.SaveAsyncImpl(TaskOutputKind.TaskPreview, FileBase, "File\\Under\\TestText2.txt");

            var blobs = taskOutputStorage.ListOutputs(TaskOutputKind.TaskPreview).ToList();
            Assert.NotEqual(0, blobs.Count);
            Assert.Contains(blobs, b => b.Uri.AbsoluteUri.EndsWith($"{_jobId}/{_taskId}/$TaskPreview/File/Under/TestText2.txt"));
        }

        [Fact]
        public async Task IfAFileIsSavedWithAnExplicitMultiLevelPath_ThenItAppearsInTheList()
        {
            var taskOutputStorage = new TaskOutputStorage(StorageAccount, _jobId, _taskId);
            await taskOutputStorage.SaveAsync(TaskOutputKind.TaskPreview, FilePath("TestText1.txt"), "File/In/The/Depths/TestText3.txt");

            var blobs = taskOutputStorage.ListOutputs(TaskOutputKind.TaskPreview).ToList();
            Assert.NotEqual(0, blobs.Count);
            Assert.Contains(blobs, b => b.Uri.AbsoluteUri.EndsWith($"{_jobId}/{_taskId}/$TaskPreview/File/In/The/Depths/TestText3.txt"));
        }

        [Fact]
        public async Task IfAFileIsSaved_ThenItCanBeGot()
        {
            var taskOutputStorage = new TaskOutputStorage(StorageAccount, _jobId, _taskId);
            await taskOutputStorage.SaveAsync(TaskOutputKind.TaskPreview, FilePath("TestText1.txt"), "Gettable.txt");

            var blob = await taskOutputStorage.GetOutputAsync(TaskOutputKind.TaskPreview, "Gettable.txt");

            var blobContent = await blob.ReadAsByteArrayAsync();
            var originalContent = File.ReadAllBytes(FilePath("TestText1.txt"));

            Assert.Equal(originalContent, blobContent);
        }

        [Fact]
        public async Task IfAFileIsSavedWithAMultiLevelPath_ThenItCanBeGot()
        {
            var taskOutputStorage = new TaskOutputStorage(StorageAccount, _jobId, _taskId);
            await taskOutputStorage.SaveAsync(TaskOutputKind.TaskPreview, FilePath("TestText1.txt"), "This/File/Is/Gettable.txt");

            var blob = await taskOutputStorage.GetOutputAsync(TaskOutputKind.TaskPreview, "This/File/Is/Gettable.txt");

            var blobContent = await blob.ReadAsByteArrayAsync();
            var originalContent = File.ReadAllBytes(FilePath("TestText1.txt"));

            Assert.Equal(originalContent, blobContent);
        }

        [Fact]
        public async Task IfTextIsSaved_ThenItCanBeGot()
        {
            var sampleXml = "<document><empty /></document>";

            var taskOutputStorage = new TaskOutputStorage(StorageAccount, _jobId, _taskId);
            await taskOutputStorage.SaveTextAsync(TaskOutputKind.TaskOutput, sampleXml, "TextNotFromFile.xml");

            var blob = await taskOutputStorage.GetOutputAsync(TaskOutputKind.TaskOutput, "TextNotFromFile.xml");

            var blobContent = Encoding.UTF8.GetString(await blob.ReadAsByteArrayAsync());

            Assert.Equal(sampleXml, blobContent);
        }

        [Fact]
        public async Task IfAFileIsSavedWithAPathOutsideTheWorkingDirectory_ThenTheUpPartsOfThePathAreStripped()
        {
            var taskOutputStorage = new TaskOutputStorage(StorageAccount, _jobId, _taskId);
            await taskOutputStorage.SaveAsyncImpl(TaskOutputKind.TaskIntermediate, FileSubfolder("File"), @"..\TestTextForOutsideWorkingDirectory.txt");

            var blob = await taskOutputStorage.GetOutputAsync(TaskOutputKind.TaskIntermediate, "TestTextForOutsideWorkingDirectory.txt");

            var blobContent = await blob.ReadAsByteArrayAsync();
            var originalContent = File.ReadAllBytes(FilePath("TestTextForOutsideWorkingDirectory.txt"));

            Assert.Equal(originalContent, blobContent);
        }

        [Fact]
        public async Task IfAUserAttemptsToWriteOutsideTheContainerByBypassingTheUpChecker_ThenTheWriteFails()
        {
            var taskOutputStorage = new TaskOutputStorage(StorageAccount, _jobId, _taskId);
            var ex = await Assert.ThrowsAsync<StorageException>(async () =>
                await taskOutputStorage.SaveAsyncImpl(TaskOutputKind.TaskIntermediate, FileSubfolder("File\\Under\\Further"), @"Under\..\..\..\..\TestTextForFarOutsideWorkingDirectory.txt")
            );

            Assert.Equal(404, ex.RequestInformation.HttpStatusCode);
        }

        [Fact]
        public async Task IfAFileIsSavedTracked_ThenChangesArePersisted()
        {
            var file = Path.GetTempFileName();

            try
            {
                var taskOutputStorage = new TaskOutputStorage(StorageAccount, _jobId, _taskId);
                using (await taskOutputStorage.SaveTrackedAsync(TaskOutputKind.TaskLog, file, "Tracked1.txt", TimeSpan.FromMilliseconds(10)))
                {
                    await Task.Delay(TimeSpan.FromMilliseconds(30));
                    File.AppendAllLines(file, new[] { "Line 1" });
                    await Task.Delay(TimeSpan.FromMilliseconds(20));
                    File.AppendAllLines(file, new[] { "Line 2" });
                    await Task.Delay(TimeSpan.FromMilliseconds(20));
                    File.AppendAllLines(file, new[] { "Line 3" });
                }

                var blob = await taskOutputStorage.GetOutputAsync(TaskOutputKind.TaskLog, "Tracked1.txt");

                var blobContent = await blob.ReadAsByteArrayAsync();
                var originalContent = File.ReadAllBytes(file);

                Assert.Equal(originalContent, blobContent);
            }
            finally
            {
                File.Delete(file);
            }
        }

        [Fact]
        public async Task IfATrackedFileIsIsUseWhenItIsDueToBeFlushed_ThenNoErrorOccursAndChangesArePersisted()
        {
            var file = Path.GetTempFileName();

            try
            {
                var taskOutputStorage = new TaskOutputStorage(StorageAccount, _jobId, _taskId);
                using (await taskOutputStorage.SaveTrackedAsync(TaskOutputKind.TaskLog, file, "Tracked2.txt", TimeSpan.FromMilliseconds(5)))
                {
                    using (var writer = File.AppendText(file))
                    {
                        for (int i = 0; i < 100; ++i)
                        {
                            await Task.Delay(TimeSpan.FromMilliseconds(3));
                            await writer.WriteLineAsync($"Line {i}");
                            await Task.Delay(TimeSpan.FromMilliseconds(3));
                        }
                    }
                    using (var writer = File.AppendText(file))
                    {
                        for (int i = 0; i < 100; ++i)
                        {
                            await writer.WriteLineAsync($"Line {i + 100}");
                            await Task.Delay(TimeSpan.FromMilliseconds(2));
                        }
                    }
                }

                var blob = await taskOutputStorage.GetOutputAsync(TaskOutputKind.TaskLog, "Tracked2.txt");

                var blobContent = await blob.ReadAsByteArrayAsync();
                var originalContent = File.ReadAllBytes(file);

                Assert.Equal(originalContent, blobContent);
            }
            finally
            {
                File.Delete(file);
            }
        }

        [Fact]
        public async Task IfARetryPolicyIsSpecifiedInTheStorageAccountConstructor_ThenItIsUsed()
        {
            var taskOutputStorage = new TaskOutputStorage(StorageAccount, _jobId, _taskId, new LinearRetry(TimeSpan.FromSeconds(5), 4));
            await taskOutputStorage.SaveAsync(TaskOutputKind.TaskOutput, FilePath("TestText1.txt"), "SavedWithLinearRetry1.txt");

            var output = await taskOutputStorage.GetOutputAsync(TaskOutputKind.TaskOutput, "SavedWithLinearRetry1.txt");
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

                var taskOutputStorage = new TaskOutputStorage(new Uri(container), _taskId, new LinearRetry(TimeSpan.FromSeconds(5), 4));
                await taskOutputStorage.SaveAsync(TaskOutputKind.TaskOutput, FilePath("TestText1.txt"), "SavedWithLinearRetry2.txt");

                var output = await taskOutputStorage.GetOutputAsync(TaskOutputKind.TaskOutput, "SavedWithLinearRetry2.txt");
                var blob = output.CloudBlob;
                var storageClient = blob.ServiceClient;
                Assert.IsType<LinearRetry>(storageClient.DefaultRequestOptions.RetryPolicy);
            }
        }
    }
}

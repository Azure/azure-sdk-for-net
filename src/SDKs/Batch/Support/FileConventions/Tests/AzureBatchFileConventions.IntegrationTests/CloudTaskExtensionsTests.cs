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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.Azure.Batch.Conventions.Files.IntegrationTests
{
    public class CloudTaskExtensionsTests : IntegrationTest, IClassFixture<CloudTaskExtensionsTests.JobIdFixtureImpl>
    {
        private readonly string _jobId;
        private readonly string _taskId = "task-ext-test";

        public CloudTaskExtensionsTests(JobIdFixtureImpl jobIdFixture, ITestOutputHelper output)
            : base(jobIdFixture, output)
        {
            _jobId = jobIdFixture.JobId;
        }

        public class JobIdFixtureImpl : JobIdFixture
        {
            protected override string TestId { get; } = "cloudtaskext";
        }

        [Fact]
        public async Task CloudJobOutputStorageExtensionSavesToCorrectContainer()
        {
            var taskResponse = new Batch.Protocol.Models.CloudTask
            {
                Id = _taskId,
                Url = $"http://contoso.noregion.batch.azure.com/jobs/{_jobId}/tasks/{_taskId}",  // TODO: remove if .NET client library can surface CloudTask.JobId directly
            };

            using (var batchClient = BatchClient.Open(new FakeBatchServiceClient(taskResponse)))
            {
                var task = await batchClient.JobOperations.GetTaskAsync(_jobId, _taskId);

                await task.OutputStorage(StorageAccount).SaveAsync(TaskOutputKind.TaskOutput, FilePath("TestText1.txt"));

                var blobs = task.OutputStorage(StorageAccount).ListOutputs(TaskOutputKind.TaskOutput).ToList();
                Assert.NotEqual(0, blobs.Count);
                Assert.Contains(blobs, b => b.Uri.AbsoluteUri.EndsWith($"{_jobId}/{_taskId}/$TaskOutput/Files/TestText1.txt"));
            }
        }
    }
}

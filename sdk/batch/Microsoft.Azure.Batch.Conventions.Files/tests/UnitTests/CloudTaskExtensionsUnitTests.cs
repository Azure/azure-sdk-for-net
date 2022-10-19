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

﻿using Microsoft.Azure.Batch.Conventions.Files.UnitTests.Utilities;
using Azure.Storage.Blobs;
using Azure.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Microsoft.Azure.Batch.Conventions.Files.UnitTests
{
    public class CloudTaskExtensionsUnitTests
    {
        [Fact]
        public void CannotCreateOutputStorageForNullTask()
        {
            CloudTask task = null;
            BlobServiceClient blobClient = new BlobServiceClient(new Uri("http://fakestorageaccount.blob.core.windows.net"), new StorageSharedKeyCredential("fake", "ZmFrZQ=="));
            var ex = Assert.Throws<ArgumentNullException>(() => task.OutputStorage(blobClient));
            Assert.Equal("task", ex.ParamName);
        }

        [Fact]
        public void CannotCreateOutputStorageForNullBlobServiceClient()
        {
            var taskResponse = new Batch.Protocol.Models.CloudTask
            {
                Id = "faketask",
                Url = $"http://contoso.noregion.batch.azure.com/jobs/fakejob/tasks/faketask",  // TODO: remove if .NET client library can surface CloudTask.JobId directly
            };

            using (var batchClient = BatchClient.Open(new FakeBatchServiceClient(taskResponse)))
            {
                CloudTask task = batchClient.JobOperations.GetTask("fakejob", "faketask");
                BlobServiceClient blobClient = null;
                var ex = Assert.Throws<ArgumentNullException>(() => task.OutputStorage(blobClient));
                Assert.Equal("blobClient", ex.ParamName);
            }
        }

        [Fact]
        public void GetTaskOutputStoragePathReturnsExpectedValue()
        {
            const string taskId = "test-task";
            var task = new CloudTask(taskId, "test");

            var taskLogPath = task.GetOutputStoragePath(TaskOutputKind.TaskLog);
            Assert.Equal($"{taskId}/${TaskOutputKind.TaskLog.ToString()}", taskLogPath);

            taskLogPath = task.GetOutputStoragePath(TaskOutputKind.TaskOutput);
            Assert.Equal($"{taskId}/${TaskOutputKind.TaskOutput.ToString()}", taskLogPath);

            taskLogPath = task.GetOutputStoragePath(TaskOutputKind.TaskPreview);
            Assert.Equal($"{taskId}/${TaskOutputKind.TaskPreview.ToString()}", taskLogPath);

            taskLogPath = task.GetOutputStoragePath(TaskOutputKind.Custom("foo"));
            Assert.Equal($"{taskId}/${TaskOutputKind.Custom("foo").ToString()}", taskLogPath);
        }
    }
}

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
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
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
            CloudStorageAccount storageAccount = new CloudStorageAccount(new StorageCredentials("fake", "ZmFrZQ=="), true);
            var ex = Assert.Throws<ArgumentNullException>(() => task.OutputStorage(storageAccount));
            Assert.Equal("task", ex.ParamName);
        }

        [Fact]
        public void CannotCreateOutputStorageForNullStorageAccount()
        {
            var taskResponse = new Batch.Protocol.Models.CloudTask
            {
                Id = "faketask",
                Url = $"http://contoso.noregion.batch.azure.com/jobs/fakejob/tasks/faketask",  // TODO: remove if .NET client library can surface CloudTask.JobId directly
            };

            using (var batchClient = BatchClient.Open(new FakeBatchServiceClient(taskResponse)))
            {
                CloudTask task = batchClient.JobOperations.GetTask("fakejob", "faketask");
                CloudStorageAccount storageAccount = null;
                var ex = Assert.Throws<ArgumentNullException>(() => task.OutputStorage(storageAccount));
                Assert.Equal("storageAccount", ex.ParamName);
            }
        }
    }
}

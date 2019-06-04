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

﻿using FsCheck.Xunit;
using Microsoft.Azure.Batch.Conventions.Files.UnitTests.Generators;
using Microsoft.Azure.Batch.Conventions.Files.UnitTests.Utilities;
using Microsoft.Azure.Batch.Conventions.Files.Utilities;
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
    [Properties(Arbitrary = new [] { typeof(BatchIdGenerator) })]
    public class CloudJobExtensionsUnitTests
    {
        [Fact]
        public void CannotCreateOutputStorageForNullJob()
        {
            CloudJob job = null;
            CloudStorageAccount storageAccount = new CloudStorageAccount(new StorageCredentials("fake", "ZmFrZQ=="), true);
            var ex = Assert.Throws<ArgumentNullException>(() => job.OutputStorage(storageAccount));
            Assert.Equal("job", ex.ParamName);
        }

        [Fact]
        public void CannotCreateOutputStorageForNullStorageAccount()
        {
            using (var batchClient = BatchClient.Open(new FakeBatchServiceClient()))
            {
                CloudJob job = batchClient.JobOperations.CreateJob();
                job.Id = "fakejob";
                CloudStorageAccount storageAccount = null;
                var ex = Assert.Throws<ArgumentNullException>(() => job.OutputStorage(storageAccount));
                Assert.Equal("storageAccount", ex.ParamName);
            }
        }

        [Fact]
        public async Task CannotPrepareOutputStorageForNullJob()
        {
            CloudJob job = null;
            CloudStorageAccount storageAccount = new CloudStorageAccount(new StorageCredentials("fake", "ZmFrZQ=="), true);
            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => job.PrepareOutputStorageAsync(storageAccount));
            Assert.Equal("job", ex.ParamName);
        }

        [Property]
        public void JobOutputStorageContainerNameAgreesWithSafeContainerName(BatchId jobId)
        {
            using (var batchClient = BatchClient.Open(new FakeBatchServiceClient()))  // FsCheck doesn't like async tests
            {
                CloudJob job = batchClient.JobOperations.CreateJob();
                job.Id = jobId.ToString();
                var actualContainerName = job.OutputStorageContainerName();
                var expectedContainerName = ContainerNameUtils.GetSafeContainerName(job.Id);
                Assert.Equal(expectedContainerName, actualContainerName);  // We have other tests for validating the outputs of GetSafeContainerName - we do not need to reproduce those here
            }
        }

        [Fact]
        public void CannotGetOutputStorageContainerNameForNullJob()
        {
            CloudJob job = null;
            var ex = Assert.Throws<ArgumentNullException>(() => job.OutputStorageContainerName());
            Assert.Equal("job", ex.ParamName);
        }

        [Fact]
        public void CannotGetOutputStorageUrlForNullJob()
        {
            CloudJob job = null;
            CloudStorageAccount storageAccount = new CloudStorageAccount(new StorageCredentials("fake", "ZmFrZQ=="), true);
            var ex = Assert.Throws<ArgumentNullException>(() => job.GetOutputStorageContainerUrl(storageAccount, TimeSpan.FromMinutes(5)));
            Assert.Equal("job", ex.ParamName);
        }

        [Fact]
        public void CannotGetOutputStorageUrlForNullStorageAccount()
        {
            using (var batchClient = BatchClient.Open(new FakeBatchServiceClient()))
            {
                CloudJob job = batchClient.JobOperations.CreateJob();
                job.Id = "fakejob";
                CloudStorageAccount storageAccount = null;
                var ex = Assert.Throws<ArgumentNullException>(() => job.GetOutputStorageContainerUrl(storageAccount, TimeSpan.FromMinutes(5)));
                Assert.Equal("storageAccount", ex.ParamName);
            }
        }

        [Fact]
        public void CannotGetOutputStorageUrlWithZeroExpiryTime()
        {
            using (var batchClient = BatchClient.Open(new FakeBatchServiceClient()))
            {
                CloudJob job = batchClient.JobOperations.CreateJob();
                job.Id = "fakejob";
                CloudStorageAccount storageAccount = new CloudStorageAccount(new StorageCredentials("fake", "ZmFrZQ=="), true);
                var ex = Assert.Throws<ArgumentException>(() => job.GetOutputStorageContainerUrl(storageAccount, TimeSpan.FromMinutes(0)));
                Assert.Equal("expiryTime", ex.ParamName);
            }
        }

        [Fact]
        public void CannotGetOutputStorageUrlWithNegativeExpiryTime()
        {
            using (var batchClient = BatchClient.Open(new FakeBatchServiceClient()))
            {
                CloudJob job = batchClient.JobOperations.CreateJob();
                job.Id = "fakejob";
                CloudStorageAccount storageAccount = new CloudStorageAccount(new StorageCredentials("fake", "ZmFrZQ=="), true);
                var ex = Assert.Throws<ArgumentException>(() => job.GetOutputStorageContainerUrl(storageAccount, TimeSpan.FromMinutes(-5)));
                Assert.Equal("expiryTime", ex.ParamName);
            }
        }
    }
}

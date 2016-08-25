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

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Microsoft.Azure.Batch.Conventions.Files.UnitTests
{
    public class JobOutputStorageUnitTests
    {
        private readonly JobOutputStorage _storage = new JobOutputStorage(new Uri("http://example.test/"));

        [Fact]
        public async Task CannotPassANullKindWhenSaving()
        {
            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => _storage.SaveAsync(null, "test.txt"));
            Assert.Equal("kind", ex.ParamName);
        }

        [Fact]
        public async Task CannotPassANullFilePathWhenSaving()
        {
            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => _storage.SaveAsync(JobOutputKind.JobOutput, null));
            Assert.Equal("relativePath", ex.ParamName);
        }

        [Fact]
        public async Task CannotPassAnEmptyFilePathWhenSaving()
        {
            var ex = await Assert.ThrowsAsync<ArgumentException>(() => _storage.SaveAsync(JobOutputKind.JobOutput, ""));
            Assert.Equal("relativePath", ex.ParamName);
        }

        [Fact]
        public async Task CannotPassAnAbsoluteFilePathWhenSaving()
        {
            var ex = await Assert.ThrowsAsync<ArgumentException>(() => _storage.SaveAsync(JobOutputKind.JobOutput, @"c:\temp\test.txt"));
            Assert.Equal("relativePath", ex.ParamName);
        }

        [Fact]
        public async Task CannotPassANullKindWhenSavingToDestination()
        {
            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => _storage.SaveAsync(null, "test.txt", "testing.txt"));
            Assert.Equal("kind", ex.ParamName);
        }

        [Fact]
        public async Task CannotPassANullFilePathWhenSavingToDestination()
        {
            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => _storage.SaveAsync(JobOutputKind.JobOutput, null, "testing.txt"));
            Assert.Equal("sourcePath", ex.ParamName);
        }

        [Fact]
        public async Task CannotPassAnEmptyFilePathWhenSavingToDestination()
        {
            var ex = await Assert.ThrowsAsync<ArgumentException>(() => _storage.SaveAsync(JobOutputKind.JobOutput, "", "testing.txt"));
            Assert.Equal("sourcePath", ex.ParamName);
        }

        [Fact]
        public async Task CannotPassANullDestinationWhenSavingToDestination()
        {
            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => _storage.SaveAsync(JobOutputKind.JobOutput, "test.txt", null));
            Assert.Equal("destinationRelativePath", ex.ParamName);
        }

        [Fact]
        public async Task CannotPassAnEmptyDestinationWhenSavingToDestination()
        {
            var ex = await Assert.ThrowsAsync<ArgumentException>(() => _storage.SaveAsync(JobOutputKind.JobOutput, "test.txt", ""));
            Assert.Equal("destinationRelativePath", ex.ParamName);
        }

        [Fact]
        public void CannotPassANullKindWhenListing()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => _storage.ListOutputs(null));
            Assert.Equal("kind", ex.ParamName);
        }

        [Fact]
        public async Task CannotPassANullKindWhenGetting()
        {
            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => _storage.GetOutputAsync(null, "test.txt"));
            Assert.Equal("kind", ex.ParamName);
        }

        [Fact]
        public async Task CannotPassANullFilePathWhenGetting()
        {
            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => _storage.GetOutputAsync(JobOutputKind.JobOutput, null));
            Assert.Equal("filePath", ex.ParamName);
        }

        [Fact]
        public async Task CannotPassAnEmptyFilePathWhenGetting()
        {
            var ex = await Assert.ThrowsAsync<ArgumentException>(() => _storage.GetOutputAsync(JobOutputKind.JobOutput, ""));
            Assert.Equal("filePath", ex.ParamName);
        }
    }
}

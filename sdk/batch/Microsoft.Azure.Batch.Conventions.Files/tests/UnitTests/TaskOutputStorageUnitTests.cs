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
    public class TaskOutputStorageUnitTests
    {
        private readonly TaskOutputStorage _storage = new TaskOutputStorage(new Uri("http://example.test/"), "test-task");

        [Fact]
        public async Task CannotPassANullKindWhenSaving()
        {
            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => _storage.SaveAsync(null, "test.txt"));
            Assert.Equal("kind", ex.ParamName);
        }

        [Fact]
        public async Task CannotPassANullFilePathWhenSaving()
        {
            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => _storage.SaveAsync(TaskOutputKind.TaskLog, null));
            Assert.Equal("relativePath", ex.ParamName);
        }

        [Fact]
        public async Task CannotPassAnEmptyFilePathWhenSaving()
        {
            var ex = await Assert.ThrowsAsync<ArgumentException>(() => _storage.SaveAsync(TaskOutputKind.TaskLog, ""));
            Assert.Equal("relativePath", ex.ParamName);
        }

#if Windows
        [Fact]
        public async Task CannotPassAnAbsoluteFilePathWhenSaving()
        {
            var ex = await Assert.ThrowsAsync<ArgumentException>(() => _storage.SaveAsync(TaskOutputKind.TaskLog, @"c:\temp\test.txt"));
            Assert.Equal("relativePath", ex.ParamName);
        }
#endif
        [Fact]
        public async Task CannotPassANullKindWhenSavingToDestination()
        {
            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => _storage.SaveAsync(null, "test.txt", "testing.txt"));
            Assert.Equal("kind", ex.ParamName);
        }

        [Fact]
        public async Task CannotPassANullFilePathWhenSavingToDestination()
        {
            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => _storage.SaveAsync(TaskOutputKind.TaskLog, null, "testing.txt"));
            Assert.Equal("sourcePath", ex.ParamName);
        }

        [Fact]
        public async Task CannotPassAnEmptyFilePathWhenSavingToDestination()
        {
            var ex = await Assert.ThrowsAsync<ArgumentException>(() => _storage.SaveAsync(TaskOutputKind.TaskLog, "", "testing.txt"));
            Assert.Equal("sourcePath", ex.ParamName);
        }

        [Fact]
        public async Task CannotPassANullDestinationWhenSavingToDestination()
        {
            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => _storage.SaveAsync(TaskOutputKind.TaskLog, "test.txt", null));
            Assert.Equal("destinationRelativePath", ex.ParamName);
        }

        [Fact]
        public async Task CannotPassAnEmptyDestinationWhenSavingToDestination()
        {
            var ex = await Assert.ThrowsAsync<ArgumentException>(() => _storage.SaveAsync(TaskOutputKind.TaskLog, "test.txt", ""));
            Assert.Equal("destinationRelativePath", ex.ParamName);
        }

        [Fact]
        public async Task CannotPassANullFilePathWhenSavingTracked()
        {
            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => _storage.SaveTrackedAsync(null));
            Assert.Equal("relativePath", ex.ParamName);
        }

        [Fact]
        public async Task CannotPassAnEmptyFilePathWhenSavingTracked()
        {
            var ex = await Assert.ThrowsAsync<ArgumentException>(() => _storage.SaveTrackedAsync(""));
            Assert.Equal("relativePath", ex.ParamName);
        }

#if Windows
        [Fact]
        public async Task CannotPassAnAbsoluteFilePathWhenSavingTracked()
        {
            var ex = await Assert.ThrowsAsync<ArgumentException>(() => _storage.SaveTrackedAsync(@"c:\test.txt"));
            Assert.Equal("relativePath", ex.ParamName);
        }
#endif
        [Fact]
        public async Task CannotPassANullKindWhenSavingTrackedToDestination()
        {
            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => _storage.SaveTrackedAsync(null, "test.txt", "testing.txt", TimeSpan.FromSeconds(1)));
            Assert.Equal("kind", ex.ParamName);
        }

        [Fact]
        public async Task CannotPassANullFilePathWhenSavingTrackedToDestination()
        {
            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => _storage.SaveTrackedAsync(TaskOutputKind.TaskLog, null, "testing.txt", TimeSpan.FromSeconds(1)));
            Assert.Equal("sourcePath", ex.ParamName);
        }

        [Fact]
        public async Task CannotPassAnEmptyFilePathWhenSavingTrackedToDestination()
        {
            var ex = await Assert.ThrowsAsync<ArgumentException>(() => _storage.SaveTrackedAsync(TaskOutputKind.TaskLog, "", "testing.txt", TimeSpan.FromSeconds(1)));
            Assert.Equal("sourcePath", ex.ParamName);
        }

        [Fact]
        public async Task CannotPassANullDestinationWhenSavingTrackedToDestination()
        {
            var ex = await Assert.ThrowsAsync<ArgumentNullException>(() => _storage.SaveTrackedAsync(TaskOutputKind.TaskLog, "test.txt", null, TimeSpan.FromSeconds(1)));
            Assert.Equal("destinationRelativePath", ex.ParamName);
        }

        [Fact]
        public async Task CannotPassAnEmptyDestinationWhenSavingTrackedToDestination()
        {
            var ex = await Assert.ThrowsAsync<ArgumentException>(() => _storage.SaveTrackedAsync(TaskOutputKind.TaskLog, "test.txt", "", TimeSpan.FromSeconds(1)));
            Assert.Equal("destinationRelativePath", ex.ParamName);
        }

        [Fact]
        public void CannotPassANullKindWhenListing()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => _storage.ListOutputs(null));
            Assert.Equal("kind", ex.ParamName);
        }

        [Fact]
        public void CannotPassANullKindWhenGetting()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => _storage.GetOutput(null, "test.txt"));
            Assert.Equal("kind", ex.ParamName);
        }

        [Fact]
        public void CannotPassANullFilePathWhenGetting()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => _storage.GetOutput(TaskOutputKind.TaskLog, null));
            Assert.Equal("filePath", ex.ParamName);
        }

        [Fact]
        public void CannotPassAnEmptyFilePathWhenGetting()
        {
            var ex = Assert.Throws<ArgumentException>(() => _storage.GetOutput(TaskOutputKind.TaskLog, ""));
            Assert.Equal("filePath", ex.ParamName);
        }

        [Fact]
        public void GetTaskOutputStoragePathReturnsExpectedValue()
        {
            const string taskId = "test-task";
            var taskStorage = new TaskOutputStorage(new Uri("http://example.test/"), taskId);

            var taskLogPath = taskStorage.GetOutputStoragePath(TaskOutputKind.TaskLog);
            Assert.Equal($"{taskId}/${TaskOutputKind.TaskLog.ToString()}", taskLogPath);

            taskLogPath = taskStorage.GetOutputStoragePath(TaskOutputKind.TaskOutput);
            Assert.Equal($"{taskId}/${TaskOutputKind.TaskOutput.ToString()}", taskLogPath);

            taskLogPath = taskStorage.GetOutputStoragePath(TaskOutputKind.TaskPreview);
            Assert.Equal($"{taskId}/${TaskOutputKind.TaskPreview.ToString()}", taskLogPath);

            taskLogPath = taskStorage.GetOutputStoragePath(TaskOutputKind.Custom("foo"));
            Assert.Equal($"{taskId}/${TaskOutputKind.Custom("foo").ToString()}", taskLogPath);
        }
    }
}

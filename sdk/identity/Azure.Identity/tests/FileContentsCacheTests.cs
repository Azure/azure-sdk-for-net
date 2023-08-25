// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    public class FileContentsCacheTests
    {
        private TestTempFileHandler _tempFiles = new TestTempFileHandler();

        [Test]
        public async Task VerifyCacheAndRefresh()
        {
            string originalText = Guid.NewGuid().ToString();

            string updatedText = Guid.NewGuid().ToString();

            string filePath = _tempFiles.GetTempFilePath();

            File.WriteAllText(filePath, originalText);

            var fileCache = new FileContentsCache(filePath, TimeSpan.FromSeconds(1));

            // assert the file text is returned
            Assert.AreEqual(originalText, await fileCache.GetTokenFileContentsAsync(default));

            File.WriteAllText(filePath, updatedText);

            // assert the cached file text is still returned
            Assert.AreEqual(originalText, await fileCache.GetTokenFileContentsAsync(default));

            await Task.Delay(TimeSpan.FromSeconds(1.5));

            // assert the updated file text is returned
            Assert.AreEqual(updatedText, await fileCache.GetTokenFileContentsAsync(default));
        }

        [Test]
        public void VerifyCancellationTokenHonored()
        {
            string filePath = _tempFiles.GetTempFilePath();

            File.WriteAllText(filePath, Guid.NewGuid().ToString());

            var fileCache = new FileContentsCache(filePath);

            var cts = new CancellationTokenSource();

            cts.Cancel();

            Assert.ThrowsAsync<TaskCanceledException>(() => fileCache.GetTokenFileContentsAsync(cts.Token));
        }

        [TearDown]
        public void CleanupTestAssertionFiles()
        {
            _tempFiles.CleanupTempFiles();
        }
    }
}

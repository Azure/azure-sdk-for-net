// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    public class TestTempFileHandler
    {
        public string GetTempFilePath()
        {
            if (!_testTempFiles.ContainsKey(TestContext.CurrentContext.Test.ID))
            {
                _testTempFiles[TestContext.CurrentContext.Test.ID] = new List<string>();
            }

            var path = Path.Combine(TestContext.CurrentContext.WorkDirectory, Path.GetRandomFileName());

            _testTempFiles[TestContext.CurrentContext.Test.ID].Add(path);

            return path;
        }

        public void CleanupTempFiles()
        {
            if (_testTempFiles.TryGetValue(TestContext.CurrentContext.Test.ID, out List<string> assertionFiles))
            {
                foreach (var path in assertionFiles)
                {
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }
                }

                assertionFiles.Clear();
            }
        }

        private ConcurrentDictionary<string, List<string>> _testTempFiles = new ConcurrentDictionary<string, List<string>>();
    }
}

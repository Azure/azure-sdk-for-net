// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure.Storage.DataMovement.Tests
{
    public class DisposingLocalDirectory : IDisposable
    {
        public string DirectoryPath { get; private set; }

        public DisposingLocalDirectory(string directoryPath)
        {
            DirectoryPath = directoryPath;
        }

        public void Dispose()
        {
            if (string.IsNullOrEmpty(DirectoryPath))
            {
                try
                {
                    Directory.Delete(DirectoryPath, true);
                }
                catch
                {
                    // swallow the exception to avoid hiding another test failure
                }
            }
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using Azure.Core.TestFramework;
using Azure.Storage.Test.Shared;
using System.IO;
using System.Collections.Generic;

namespace Azure.Storage.DataMovement.Tests
{
    /// <summary>
    /// Base class for Blob DataMovement Tests tests
    /// </summary>
    public abstract class DataMovementTestBase : StorageTestBase<StorageTestEnvironment>
    {
        public DataMovementTestBase(bool async, RecordedTestMode? mode = null)
            : base(async, mode /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [SetUp]
        public void Setup()
        {
        }

        public List<string> ListFilesInDirectory(string directory)
        {
            List<string> files = new List<string>();
            foreach (string fileName in Directory.EnumerateFiles(directory))
            {
                files.Add(fileName);
            }
            return files;
        }
    }
}

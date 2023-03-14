// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using Azure.Core.TestFramework;
using Azure.Storage.Test.Shared;
using System.IO;
using System.Collections.Generic;
using System;

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
        public static string GetNewTransferId() => Guid.NewGuid().ToString();

        public List<string> ListFilesInDirectory(string directory)
        {
            List<string> files = new List<string>();

            // Create a queue of folders to enumerate files from, starting with provided path
            Queue<string> folders = new();
            folders.Enqueue(directory);

            while (folders.Count > 0)
            {
                // Grab a folder from the queue
                string dir = folders.Dequeue();

                // Try to enumerate and queue all subdirectories of the current folder
                try
                {
                    foreach (string subdir in Directory.EnumerateDirectories(dir))
                    {
                        folders.Enqueue(subdir);
                    }
                }
                catch
                {
                    // If we lack permissions to enumerate, throw if the caller specifies
                    // that we shouldn't continue on error.
                    //
                    // TODO: Logging for missing permissions to enumerate folder
                    //
                    // Afterthought: once logging is implemented, we can just log any problems
                    // (whether with given dir or subdir), and skip if told to/throw if not. No need for
                    // the `dir == _basePath` check (which right now is just a filler signal
                    // for something going wrong, as opposed to an "success" with an empty list).
                    if (dir == directory)
                    {
                        throw;
                    }

                    // Otherwise, just log the failed subdirectory and continue to list as many
                    // files as accessible.
                    continue;
                }

                // Send all files in the directory to the scan results
                foreach (string file in Directory.EnumerateFiles(dir))
                {
                    files.Add(file);
                }
            }
            return files;
        }

        public static DisposingLocalDirectory GetTestLocalDirectoryAsync(string directoryPath = default)
        {
            if (string.IsNullOrEmpty(directoryPath))
            {
                directoryPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            }
            Directory.CreateDirectory(directoryPath);
            return new DisposingLocalDirectory(directoryPath);
        }

        public Dictionary<string, string> BuildTags()
            => new Dictionary<string, string>
            {
                { "tagKey0", "tagValue0" },
                { "tagKey1", "tagValue1" }
            };
    }
}

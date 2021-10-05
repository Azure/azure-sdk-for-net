// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;

namespace Azure.Storage.Files.DataLake.Tests
{
    public class DisposingFileSystem : IAsyncDisposable
    {
        public DataLakeFileSystemClient FileSystem;

        public DisposingFileSystem(DataLakeFileSystemClient fileSystem)
        {
            FileSystem = fileSystem;
        }

        public async ValueTask DisposeAsync()
        {
            if (FileSystem != null)
            {
                try
                {
                    await FileSystem.DeleteIfExistsAsync();
                    FileSystem = null;
                }
                catch
                {
                    // swallow the exception to avoid hiding another test failure
                }
            }
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Storage.Test.Shared;

namespace Azure.Storage.Files.DataLake.Tests
{
    public class DisposingFileSystem : IDisposingContainer<DataLakeFileSystemClient>
    {
        public DataLakeFileSystemClient FileSystem => Container;

        public DataLakeFileSystemClient Container { get; private set; }

        public DisposingFileSystem(DataLakeFileSystemClient fileSystem)
        {
            Container = fileSystem;
        }

        public async ValueTask DisposeAsync()
        {
            if (Container != null)
            {
                try
                {
                    await Container.DeleteIfExistsAsync();
                    Container = null;
                }
                catch
                {
                    // swallow the exception to avoid hiding another test failure
                }
            }
        }
    }
}

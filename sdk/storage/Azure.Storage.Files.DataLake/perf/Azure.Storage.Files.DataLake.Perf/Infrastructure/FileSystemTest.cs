// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Test.Perf;

namespace Azure.Storage.Files.DataLake.Perf
{
    public abstract class FileSystemTest<TOptions> : ServiceTest<TOptions> where TOptions : PerfOptions
    {
        protected static string FileSystemName { get; } = $"FileSystemTest-{Guid.NewGuid()}".ToLowerInvariant();

        protected DataLakeFileSystemClient DataLakeFileSystemClient { get; private set; }

        public FileSystemTest(TOptions options) : base(options)
        {
            DataLakeFileSystemClient = DataLakeServiceClient.GetFileSystemClient(FileSystemName);
        }

        public override async Task GlobalSetupAsync()
        {
            await base.GlobalSetupAsync();
            await DataLakeFileSystemClient.CreateIfNotExistsAsync();
        }

        public override async Task GlobalCleanupAsync()
        {
            await DataLakeFileSystemClient.DeleteIfExistsAsync();
            await base.GlobalCleanupAsync();
        }
    }
}

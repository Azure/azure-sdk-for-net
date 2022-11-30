// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading.Tasks;
using Azure.Test.Perf;

namespace Azure.Storage.Files.DataLake.Perf
{
    public abstract class FileTest<TOptions> : FileSystemTest<TOptions> where TOptions : SizeOptions
    {
        private readonly bool _createFile;
        private readonly bool _singletonFile;

        protected string FileName { get; }
        protected DataLakeFileClient FileClient { get; private set; }

        /// <param name="options">Test options.</param>
        /// <param name="createFile">Whether to create the file on the service during setup.</param>
        /// <param name="singletonFile">Whether to use a global file vs individual files.</param>
        public FileTest(TOptions options, bool createFile, bool singletonFile) : base(options)
        {
            FileName = "Azure.Storage.Files.DataLake.Perf.FileTest" + (singletonFile ? "" : $"-{Guid.NewGuid()}");
            FileClient = DataLakeFileSystemClient
                .GetDirectoryClient(string.Empty)
                .GetFileClient(FileName);

            _createFile = createFile;
            _singletonFile = singletonFile;
        }

        public override async Task GlobalSetupAsync()
        {
            await base.GlobalSetupAsync();
            if (_singletonFile)
            {
                if (_createFile)
                {
                    await CreateFileAsync();
                }
                else
                {
                    // resource is available to work with
                    await FileClient.CreateIfNotExistsAsync();
                }
            }
        }

        public override async Task SetupAsync()
        {
            await base.SetupAsync();
            if (!_singletonFile)
            {
                if (_createFile)
                {
                    await CreateFileAsync();
                }
                else
                {
                    // resource is available to work with
                    await FileClient.CreateIfNotExistsAsync();
                }
            }
        }

        private async Task CreateFileAsync()
        {
            using Stream stream = RandomStream.Create(Options.Size);
            // No need to delete file in cleanup, since FileSystemTest.GlobalCleanup() deletes the whole container
            await FileClient.UploadAsync(stream, overwrite: true);
        }
    }
}

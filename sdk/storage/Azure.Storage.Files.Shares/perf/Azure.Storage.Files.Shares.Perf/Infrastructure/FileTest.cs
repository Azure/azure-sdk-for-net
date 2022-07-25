// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading.Tasks;
using Azure.Test.Perf;

namespace Azure.Storage.Files.Shares.Perf
{
    public abstract class FileTest<TOptions> : ShareTest<TOptions> where TOptions : SizeOptions
    {
        private readonly bool _createFile;
        private readonly bool _singletonFile;

        protected string FileName { get; }
        protected ShareFileClient FileClient { get; private set; }

        /// <param name="options">Test options.</param>
        /// <param name="createFile">Whether to create the blob on the service during setup.</param>
        /// <param name="singletonFile">Whether to use a global blob vs individual blobs.</param>
        public FileTest(TOptions options, bool createFile, bool singletonFile) : base(options)
        {
            FileName = "Azure.Storage.Files.Shares.Perf.FileTest" + (singletonFile ? "" : $"-{Guid.NewGuid()}");
            FileClient = ShareClient.GetRootDirectoryClient().GetFileClient(FileName);

            _createFile = createFile;
            _singletonFile = singletonFile;
        }

        public override async Task GlobalSetupAsync()
        {
            await base.GlobalSetupAsync();
            if (_createFile && _singletonFile)
            {
                await CreateFileAsync();
            }
        }

        public override async Task SetupAsync()
        {
            await base.SetupAsync();
            if (_createFile && !_singletonFile)
            {
                await CreateFileAsync();
            }
        }

        private async Task CreateFileAsync()
        {
            using Stream stream = RandomStream.Create(Options.Size);
            // No need to delete file in cleanup, since ContainerTest.GlobalCleanup() deletes the whole container
            FileClient.Create(Options.Size);
            await FileClient.UploadAsync(stream);
        }
    }
}

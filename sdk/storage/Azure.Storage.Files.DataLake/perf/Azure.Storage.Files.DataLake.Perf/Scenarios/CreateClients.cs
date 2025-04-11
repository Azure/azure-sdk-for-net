// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using Azure.Test.Perf;

namespace Azure.Storage.Files.DataLake.Perf.Scenarios
{
    /// <summary>
    /// This tests various client ctors and hierarchy traversal.
    /// </summary>
    public class CreateClients : PerfTest<PerfOptions>
    {
        private static readonly TokenCredential s_tokenCredential = new ClientSecretCredential("foo", "bar", "baz");
        private static readonly PerfTestEnvironment s_testEnvironment = PerfTestEnvironment.Instance;
        private static readonly Uri s_fileSystemUri = new DataLakeUriBuilder(s_testEnvironment.StorageEndpoint) { FileSystemName = "foo" }.ToUri();
        private static readonly Uri s_directoryUri = new DataLakeUriBuilder(s_testEnvironment.StorageEndpoint) { FileSystemName = "foo", DirectoryOrFilePath = "bar" }.ToUri();
        private static readonly Uri s_fileUri = new DataLakeUriBuilder(s_testEnvironment.StorageEndpoint) { FileSystemName = "foo", DirectoryOrFilePath = "bar/baz" }.ToUri();

        public CreateClients(PerfOptions options) : base(options)
        {
        }

#pragma warning disable CA1806 // Do not ignore method results
        public override void Run(CancellationToken cancellationToken)
        {
            var serviceClient = new DataLakeServiceClient(s_testEnvironment.StorageEndpoint);
            new DataLakeServiceClient(s_testEnvironment.StorageEndpoint, s_tokenCredential);
            new DataLakeServiceClient(s_testEnvironment.StorageEndpoint, new StorageSharedKeyCredential("s_testEnvironment.StorageAccountKey", Convert.ToBase64String(Guid.NewGuid().ToByteArray())));

            var fileSystemClient = new DataLakeFileSystemClient(s_fileSystemUri);
            new DataLakeFileSystemClient(s_fileSystemUri, s_tokenCredential);
            new DataLakeFileSystemClient(s_fileSystemUri, s_testEnvironment.DataLakeCredential);

            var directoryClient = new DataLakeDirectoryClient(s_directoryUri);
            new DataLakeDirectoryClient(s_directoryUri, s_tokenCredential);
            new DataLakeDirectoryClient(s_directoryUri, s_testEnvironment.DataLakeCredential);

            new DataLakeFileClient(s_fileUri);
            new DataLakeFileClient(s_fileUri, s_tokenCredential);
            new DataLakeFileClient(s_fileUri, s_testEnvironment.DataLakeCredential);

            new DataLakePathClient(s_fileUri);
            new DataLakePathClient(s_fileUri, s_tokenCredential);
            new DataLakePathClient(s_fileUri, s_testEnvironment.DataLakeCredential);

            serviceClient.GetFileSystemClient("foo");
            fileSystemClient.GetDirectoryClient("foo");
            fileSystemClient.GetFileClient("foo");
            directoryClient.GetFileClient("foo");
        }
#pragma warning restore CA1806 // Do not ignore method results

        public override Task RunAsync(CancellationToken cancellationToken)
        {
            Run(cancellationToken);
            return Task.CompletedTask;
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Test.Perf;

namespace Azure.Storage.Files.Shares.Perf.Scenarios
{
    /// <summary>
    /// This tests various client ctors and hierarchy traversal.
    /// </summary>
    public class CreateClients : PerfTest<PerfOptions>
    {
        private static readonly string s_connectionString = $"DefaultEndpointsProtocol=https;AccountName=foo;AccountKey={Convert.ToBase64String(Guid.NewGuid().ToByteArray())};EndpointSuffix=core.windows.net";
        private static readonly Uri s_serviceUri = new Uri("https://foo.files.core.windows.net");
        private static readonly Uri s_shareUri = new Uri("https://foo.files.core.windows.net/foo");
        private static readonly Uri s_directoryUri = new Uri("https://foo.files.core.windows.net/foo/bar");
        private static readonly Uri s_fileUri = new Uri("https://foo.files.core.windows.net/foo/bar/baz");
        private static readonly AzureSasCredential s_azureSasCredential = new AzureSasCredential("foo");
        private static readonly StorageSharedKeyCredential s_storageSharedKey = new StorageSharedKeyCredential("foo", Convert.ToBase64String(Guid.NewGuid().ToByteArray()));

        public CreateClients(PerfOptions options) : base(options)
        {
        }

#pragma warning disable CA1806 // Do not ignore method results
        public override void Run(CancellationToken cancellationToken)
        {
            var serviceClient = new ShareServiceClient(s_connectionString);
            new ShareServiceClient(s_serviceUri);
            new ShareServiceClient(s_serviceUri, s_azureSasCredential);
            new ShareServiceClient(s_serviceUri, s_storageSharedKey);

            var shareClient = new ShareClient(s_connectionString, "foo");
            new ShareClient(s_shareUri);
            new ShareClient(s_shareUri, s_azureSasCredential);
            new ShareClient(s_shareUri, s_storageSharedKey);

            var directoryClient = new ShareDirectoryClient(s_connectionString, "foo", "bar");
            new ShareDirectoryClient(s_directoryUri);
            new ShareDirectoryClient(s_directoryUri, s_azureSasCredential);
            new ShareDirectoryClient(s_directoryUri, s_storageSharedKey);

            new ShareFileClient(s_connectionString, "foo", "bar/baz");
            new ShareFileClient(s_fileUri);
            new ShareFileClient(s_fileUri, s_azureSasCredential);
            new ShareFileClient(s_fileUri, s_storageSharedKey);

            serviceClient.GetShareClient("foo");
            shareClient.GetDirectoryClient("bar");
            directoryClient.GetFileClient("baz");
        }
#pragma warning restore CA1806 // Do not ignore method results

        public override Task RunAsync(CancellationToken cancellationToken)
        {
            Run(cancellationToken);
            return Task.CompletedTask;
        }
    }
}

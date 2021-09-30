// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Storage.Blobs.Models;

using ShareClientBuilder = Azure.Storage.Test.Shared.ClientBuilder<
    Azure.Storage.Files.Shares.ShareServiceClient,
    Azure.Storage.Files.Shares.ShareClientOptions>;

namespace Azure.Storage.Files.Shares.Tests
{
    public static class ClientBuilderExtensions
    {
        public static string GetNewShareName(this ShareClientBuilder clientBuilder)
            => $"test-share-{clientBuilder.Recording.Random.NewGuid()}";
        public static string GetNewDirectoryName(this ShareClientBuilder clientBuilder)
            => $"test-directory-{clientBuilder.Recording.Random.NewGuid()}";
        public static string GetNewNonAsciiDirectoryName(this ShareClientBuilder clientBuilder)
            => $"test-dire¢t Ø®ϒ%3A-{clientBuilder.Recording.Random.NewGuid()}";
        public static string GetNewFileName(this ShareClientBuilder clientBuilder)
            => $"test-file-{clientBuilder.Recording.Random.NewGuid()}";
        public static string GetNewNonAsciiFileName(this ShareClientBuilder clientBuilder)
            => $"test-ƒ¡£€‽%3A-{clientBuilder.Recording.Random.NewGuid()}";

        public static async Task<DisposingShare> GetTestShareAsync(
            this ShareClientBuilder clientBuilder,
            ShareServiceClient service = default,
            string shareName = default,
            IDictionary<string, string> metadata = default)
        {
            service ??= clientBuilder.GetServiceClient_SharedKey();
            metadata ??= new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            shareName ??= clientBuilder.GetNewShareName();
            ShareClient share = clientBuilder.AzureCoreRecordedTestBase.InstrumentClient(service.GetShareClient(shareName));
            return await DisposingShare.CreateAsync(share, metadata);
        }

        public static async Task<DisposingDirectory> GetTestDirectoryAsync(
            this ShareClientBuilder clientBuilder,
            ShareServiceClient service = default,
            string shareName = default,
            string directoryName = default)
        {
            DisposingShare test = await clientBuilder.GetTestShareAsync(service, shareName);
            directoryName ??= clientBuilder.GetNewDirectoryName();

            ShareDirectoryClient directory = clientBuilder.AzureCoreRecordedTestBase.InstrumentClient(test.Share.GetDirectoryClient(directoryName));
            return await DisposingDirectory.CreateAsync(test, directory);
        }

        public static async Task<DisposingFile> GetTestFileAsync(
            this ShareClientBuilder clientBuilder,
            ShareServiceClient service = default,
            string shareName = default,
            string directoryName = default,
            string fileName = default)
        {
            DisposingDirectory test = await clientBuilder.GetTestDirectoryAsync(service, shareName, directoryName);
            fileName ??= clientBuilder.GetNewFileName();
            ShareFileClient file = clientBuilder.AzureCoreRecordedTestBase.InstrumentClient(test.Directory.GetFileClient(fileName));
            return await DisposingFile.CreateAsync(test, file);
        }

        public class DisposingShare : IAsyncDisposable
        {
            public ShareClient Share { get; private set; }

            public static async Task<DisposingShare> CreateAsync(ShareClient share, IDictionary<string, string> metadata)
            {
                await share.CreateIfNotExistsAsync(metadata: metadata);
                return new DisposingShare(share);
            }

            public DisposingShare(ShareClient share)
            {
                Share = share;
            }

            public async ValueTask DisposeAsync()
            {
                if (Share != null)
                {
                    try
                    {
                        await Share.DeleteIfExistsAsync();
                        Share = null;
                    }
                    catch
                    {
                        // swallow the exception to avoid hiding another test failure
                    }
                }
            }
        }

        public class DisposingDirectory : IAsyncDisposable
        {
            private DisposingShare _test;

            public ShareClient Share => _test.Share;
            public ShareDirectoryClient Directory { get; }

            public static async Task<DisposingDirectory> CreateAsync(DisposingShare test, ShareDirectoryClient directory)
            {
                await directory.CreateIfNotExistsAsync();
                return new DisposingDirectory(test, directory);
            }

            private DisposingDirectory(DisposingShare test, ShareDirectoryClient directory)
            {
                _test = test;
                Directory = directory;
            }

            public async ValueTask DisposeAsync()
            {
                await _test.DisposeAsync();
            }
        }

        public class DisposingFile : IAsyncDisposable
        {
            private DisposingDirectory _test;

            public ShareClient Share => _test.Share;
            public ShareDirectoryClient Directory => _test.Directory;
            public ShareFileClient File { get; }

            public static async Task<DisposingFile> CreateAsync(DisposingDirectory test, ShareFileClient file)
            {
                await file.CreateAsync(maxSize: Constants.MB);
                return new DisposingFile(test, file);
            }

            private DisposingFile(DisposingDirectory test, ShareFileClient file)
            {
                _test = test;
                File = file;
            }

            public async ValueTask DisposeAsync()
            {
                await _test.DisposeAsync();
            }
        }
    }
}

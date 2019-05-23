// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Azure.Storage.Common;
using Azure.Storage.Files;
using Azure.Storage.Files.Models;
using Azure.Storage.Test.Shared;

namespace Azure.Storage.Test
{
    partial class TestHelper
    {
        public static string GetNewShareName() => $"test-share-{Guid.NewGuid()}";
        public static string GetNewDirectoryName() => $"test-directory-{Guid.NewGuid()}";
        public static string GetNewFileName() => $"test-file-{Guid.NewGuid()}";

        public static Uri InvalidUri = new Uri("https://error.file.core.windows.net");

        public static IDisposable GetNewDirectory(out DirectoryClient directory, FileServiceClient service = default)
        {
            var disposingShare = TestHelper.GetNewShare(out var share, default, service);

            var directoryName = TestHelper.GetNewDirectoryName();

            directory = share.GetDirectoryClient(directoryName);
            _ = directory.CreateAsync().Result;

            return disposingShare;
        }

        public static IDisposable GetNewFile(out FileClient file, FileServiceClient service = default, string shareName = default, string directoryName = default, string fileName = default)
        {
            var disposingShare = TestHelper.GetNewShare(out var share, shareName, service);

            var directory = share.GetDirectoryClient(directoryName ?? TestHelper.GetNewDirectoryName());
            _ = directory.CreateAsync().Result;

            file = directory.GetFileClient(fileName ?? TestHelper.GetNewFileName());
            _ = file.CreateAsync(
                maxSize: Constants.MB).Result;

            return disposingShare;
        }

        public static FileConnectionOptions GetFaultyFileConnectionOptions(
            SharedKeyCredentials credentials = null,
            int raiseAt = default,
            Exception raise = default)
        {
            raise = raise ?? new IOException("Simulated connection fault");
            var options = GetOptions<FileConnectionOptions>(credentials);
            options.PerCallPolicies.Add(new FaultyDownloadPipelinePolicy(raiseAt, raise));
            return options;
        }

        public static FileServiceClient GetServiceClient_SharedKey()
            => new FileServiceClient(
                    new Uri(TestConfigurations.DefaultTargetTenant.FileServiceEndpoint),
                    GetOptions<FileConnectionOptions>(
                        new SharedKeyCredentials(
                            TestConfigurations.DefaultTargetTenant.AccountName,
                            TestConfigurations.DefaultTargetTenant.AccountKey)));


        public static FileServiceClient GetServiceClient_AccountSas(SharedKeyCredentials sharedKeyCredentials = default, SasQueryParameters sasCredentials = default)
            => new FileServiceClient(
                    new Uri($"{TestConfigurations.DefaultTargetTenant.FileServiceEndpoint}?{sasCredentials ?? GetNewAccountSasCredentials(sharedKeyCredentials ?? GetNewSharedKeyCredentials())}"),
                    GetOptions<FileConnectionOptions>());

        public static FileServiceClient GetServiceClient_FileServiceSasShare(string shareName, SharedKeyCredentials sharedKeyCredentials = default, SasQueryParameters sasCredentials = default)
            => new FileServiceClient(
                    new Uri($"{TestConfigurations.DefaultTargetTenant.FileServiceEndpoint}?{sasCredentials ?? GetNewFileServiceSasCredentialsShare(shareName, sharedKeyCredentials ?? GetNewSharedKeyCredentials())}"),
                    GetOptions<FileConnectionOptions>());

        public static FileServiceClient GetServiceClient_FileServiceSasFile(string shareName, string filePath, SharedKeyCredentials sharedKeyCredentials = default, SasQueryParameters sasCredentials = default)
            => new FileServiceClient(
                    new Uri($"{TestConfigurations.DefaultTargetTenant.FileServiceEndpoint}?{sasCredentials ?? GetNewFileServiceSasCredentialsFile(shareName, filePath, sharedKeyCredentials ?? GetNewSharedKeyCredentials())}"),
                    GetOptions<FileConnectionOptions>());

        public static IDisposable GetNewShare(out ShareClient share, string shareName = default, FileServiceClient service = default, IDictionary<string, string> metadata = default)
        {
            service = service ?? GetServiceClient_SharedKey();

            var result = new DisposingShare(service.GetShareClient(shareName ?? GetNewShareName()), metadata ?? new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase));

            share = result.ShareClient;

            return result;
        }

        public static SharedKeyCredentials GetNewSharedKeyCredentials()
            => new SharedKeyCredentials(
                    TestConfigurations.DefaultTargetTenant.AccountName,
                    TestConfigurations.DefaultTargetTenant.AccountKey
                    );

        public static SasQueryParameters GetNewAccountSasCredentials(SharedKeyCredentials sharedKeyCredentials = default)
            => new AccountSasSignatureValues
            {
                Protocol = SasProtocol.None,
                Services = new AccountSasServices { File = true }.ToString(),
                ResourceTypes = new AccountSasResourceTypes { Container = true }.ToString(),
                StartTime = DateTimeOffset.UtcNow.AddHours(-1),
                ExpiryTime = DateTimeOffset.UtcNow.AddHours(+1),
                Permissions = new FileAccountSasPermissions { Create = true, Delete = true }.ToString(),
                IPRange = new IPRange { Start = IPAddress.None, End = IPAddress.None }
            }.ToSasQueryParameters(sharedKeyCredentials);

        public static SasQueryParameters GetNewFileServiceSasCredentialsShare(string shareName, SharedKeyCredentials sharedKeyCredentials = default)
            => new FileSasBuilder
            {
                ShareName = shareName,
                Protocol = SasProtocol.None,
                StartTime = DateTimeOffset.UtcNow.AddHours(-1),
                ExpiryTime = DateTimeOffset.UtcNow.AddHours(+1),
                Permissions = new ShareSasPermissions { Read = true, Write = true, List = true, Create = true, Delete = true }.ToString(),
                IPRange = new IPRange { Start = IPAddress.None, End = IPAddress.None }
            }.ToSasQueryParameters(sharedKeyCredentials ?? GetNewSharedKeyCredentials());

        public static SasQueryParameters GetNewFileServiceSasCredentialsFile(string shareName, string filePath, SharedKeyCredentials sharedKeyCredentials = default)
            => new FileSasBuilder
            {
                ShareName = shareName,
                FilePath = filePath,
                Protocol = SasProtocol.None,
                StartTime = DateTimeOffset.UtcNow.AddHours(-1),
                ExpiryTime = DateTimeOffset.UtcNow.AddHours(+1),
                Permissions = new FileSasPermissions { Read = true, Write = true, Create = true, Delete = true }.ToString(),
                IPRange = new IPRange { Start = IPAddress.None, End = IPAddress.None }
            }.ToSasQueryParameters(sharedKeyCredentials ?? GetNewSharedKeyCredentials());

        public static SignedIdentifier[] BuildSignedIdentifiers() =>
            new[]
            {
                new SignedIdentifier
                {
                    Id = GetNewString(),
                    AccessPolicy =
                        new AccessPolicy
                        {
                            Start =  DateTimeOffset.UtcNow.AddHours(-1),
                            Expiry =  DateTimeOffset.UtcNow.AddHours(1),
                            Permission = "rw"
                        }
                }
            };

        class DisposingShare : IDisposable
        {
            public ShareClient ShareClient { get; }

            public DisposingShare(ShareClient share, IDictionary<string, string> metadata)
            {
                share.CreateAsync(metadata: metadata, quotaInBytes: 1).Wait();

                this.ShareClient = share;
            }

            public void Dispose()
            {
                if (this.ShareClient != null)
                {
                    try
                    {
                        this.ShareClient.DeleteAsync(default/*, new DeleteSnapshotsOptionType()*/).Wait();
                    }
                    catch
                    {
                        // swallow the exception to avoid hiding another test failure
                    }
                }
            }
        }
    }
}

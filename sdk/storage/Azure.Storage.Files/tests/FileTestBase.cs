// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Azure.Core.Pipeline;
using Azure.Core.Pipeline.Policies;
using Azure.Core.Testing;
using Azure.Storage.Files.Models;
using Azure.Storage.Sas;
using Azure.Storage.Test;
using Azure.Storage.Test.Shared;

namespace Azure.Storage.Files.Tests
{
    public class FileTestBase : StorageTestBase
    {
        public static Uri InvalidUri = new Uri("https://error.file.core.windows.net");

        public FileTestBase(RecordedTestMode? mode = null)
            : base(mode)
        {
        }

        public string GetNewShareName() => $"test-share-{this.Recording.Random.NewGuid()}";
        public string GetNewDirectoryName() => $"test-directory-{this.Recording.Random.NewGuid()}";
        public string GetNewFileName() => $"test-file-{this.Recording.Random.NewGuid()}";

        public FileConnectionOptions GetOptions(IStorageCredentials credentials = null)
            => this.Recording.InstrumentClientOptions(
                    new FileConnectionOptions
                    {
                        Credentials = credentials,
                        ResponseClassifier = new TestResponseClassifier(),
                        LoggingPolicy = LoggingPolicy.Shared,
                        RetryPolicy =
                            new RetryPolicy()
                            {
                                Mode = RetryMode.Exponential,
                                MaxRetries = Azure.Storage.Constants.MaxReliabilityRetries,
                                Delay = TimeSpan.FromSeconds(this.Mode == RecordedTestMode.Playback ? 0.01 : 0.5),
                                MaxDelay = TimeSpan.FromSeconds(this.Mode == RecordedTestMode.Playback ? 0.1 : 10)
                            }
                    });

        public IDisposable GetNewDirectory(out DirectoryClient directory, FileServiceClient service = default)
        {
            var disposingShare = this.GetNewShare(out var share, default, service);
            var directoryName = this.GetNewDirectoryName();
            directory = this.InstrumentClient(share.GetDirectoryClient(directoryName));
            _ = directory.CreateAsync().Result;
            return disposingShare;
        }

        public IDisposable GetNewFile(out FileClient file, FileServiceClient service = default, string shareName = default, string directoryName = default, string fileName = default)
        {
            var disposingShare = this.GetNewShare(out var share, shareName, service);
            var directory = this.InstrumentClient(share.GetDirectoryClient(directoryName ?? this.GetNewDirectoryName()));
            _ = directory.CreateAsync().Result;

            file = this.InstrumentClient(directory.GetFileClient(fileName ?? this.GetNewFileName()));
            _ = file.CreateAsync(maxSize: Constants.MB).Result;

            return disposingShare;
        }

        public FileConnectionOptions GetFaultyFileConnectionOptions(
            SharedKeyCredentials credentials = null,
            int raiseAt = default,
            Exception raise = default)
        {
            raise = raise ?? new IOException("Simulated connection fault");
            var options = this.GetOptions(credentials);
            options.AddPolicy(HttpPipelinePosition.PerCall, new FaultyDownloadPipelinePolicy(raiseAt, raise));
            return options;
        }

        public FileServiceClient GetServiceClient_SharedKey()
            => this.InstrumentClient(
                new FileServiceClient(
                    new Uri(TestConfigurations.DefaultTargetTenant.FileServiceEndpoint),
                    this.GetOptions(
                        new SharedKeyCredentials(
                            TestConfigurations.DefaultTargetTenant.AccountName,
                            TestConfigurations.DefaultTargetTenant.AccountKey))));

        public FileServiceClient GetServiceClient_AccountSas(SharedKeyCredentials sharedKeyCredentials = default, SasQueryParameters sasCredentials = default)
            => this.InstrumentClient(
                new FileServiceClient(
                    new Uri($"{TestConfigurations.DefaultTargetTenant.FileServiceEndpoint}?{sasCredentials ?? this.GetNewAccountSasCredentials(sharedKeyCredentials ?? this.GetNewSharedKeyCredentials())}"),
                    this.GetOptions()));

        public FileServiceClient GetServiceClient_FileServiceSasShare(string shareName, SharedKeyCredentials sharedKeyCredentials = default, SasQueryParameters sasCredentials = default)
            => this.InstrumentClient(
                new FileServiceClient(
                    new Uri($"{TestConfigurations.DefaultTargetTenant.FileServiceEndpoint}?{sasCredentials ?? this.GetNewFileServiceSasCredentialsShare(shareName, sharedKeyCredentials ?? this.GetNewSharedKeyCredentials())}"),
                    this.GetOptions()));

        public FileServiceClient GetServiceClient_FileServiceSasFile(string shareName, string filePath, SharedKeyCredentials sharedKeyCredentials = default, SasQueryParameters sasCredentials = default)
            => this.InstrumentClient(
                new FileServiceClient(
                    new Uri($"{TestConfigurations.DefaultTargetTenant.FileServiceEndpoint}?{sasCredentials ?? this.GetNewFileServiceSasCredentialsFile(shareName, filePath, sharedKeyCredentials ?? this.GetNewSharedKeyCredentials())}"),
                    this.GetOptions()));

        public IDisposable GetNewShare(out ShareClient share, string shareName = default, FileServiceClient service = default, IDictionary<string, string> metadata = default)
        {
            service ??= this.GetServiceClient_SharedKey();
            var result = new DisposingShare(
                this.InstrumentClient(service.GetShareClient(shareName ?? this.GetNewShareName())),
                metadata ?? new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase));
            share = this.InstrumentClient(result.ShareClient);
            return result;
        }

        public SharedKeyCredentials GetNewSharedKeyCredentials()
            => new SharedKeyCredentials(
                TestConfigurations.DefaultTargetTenant.AccountName,
                TestConfigurations.DefaultTargetTenant.AccountKey);

        public SasQueryParameters GetNewAccountSasCredentials(SharedKeyCredentials sharedKeyCredentials = default)
            => new AccountSasBuilder
            {
                Protocol = SasProtocol.None,
                Services = new AccountSasServices { Files = true }.ToString(),
                ResourceTypes = new AccountSasResourceTypes { Container = true }.ToString(),
                StartTime = this.Recording.UtcNow.AddHours(-1),
                ExpiryTime = this.Recording.UtcNow.AddHours(+1),
                Permissions = new FileAccountSasPermissions { Create = true, Delete = true }.ToString(),
                IPRange = new IPRange(IPAddress.None, IPAddress.None)
            }.ToSasQueryParameters(sharedKeyCredentials);

        public SasQueryParameters GetNewFileServiceSasCredentialsShare(string shareName, SharedKeyCredentials sharedKeyCredentials = default)
            => new FileSasBuilder
            {
                ShareName = shareName,
                Protocol = SasProtocol.None,
                StartTime = this.Recording.UtcNow.AddHours(-1),
                ExpiryTime = this.Recording.UtcNow.AddHours(+1),
                Permissions = new ShareSasPermissions { Read = true, Write = true, List = true, Create = true, Delete = true }.ToString(),
                IPRange = new IPRange(IPAddress.None, IPAddress.None)
            }.ToSasQueryParameters(sharedKeyCredentials ?? this.GetNewSharedKeyCredentials());

        public SasQueryParameters GetNewFileServiceSasCredentialsFile(string shareName, string filePath, SharedKeyCredentials sharedKeyCredentials = default)
            => new FileSasBuilder
            {
                ShareName = shareName,
                FilePath = filePath,
                Protocol = SasProtocol.None,
                StartTime = this.Recording.UtcNow.AddHours(-1),
                ExpiryTime = this.Recording.UtcNow.AddHours(+1),
                Permissions = new FileSasPermissions { Read = true, Write = true, Create = true, Delete = true }.ToString(),
                IPRange = new IPRange(IPAddress.None, IPAddress.None)
            }.ToSasQueryParameters(sharedKeyCredentials ?? this.GetNewSharedKeyCredentials());

        public SignedIdentifier[] BuildSignedIdentifiers() =>
            new[]
            {
                new SignedIdentifier
                {
                    Id = this.GetNewString(),
                    AccessPolicy =
                        new AccessPolicy
                        {
                            Start =  this.Recording.UtcNow.AddHours(-1),
                            Expiry =  this.Recording.UtcNow.AddHours(1),
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

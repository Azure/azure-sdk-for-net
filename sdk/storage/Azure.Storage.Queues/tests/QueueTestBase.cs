// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;
using System.Net;
using Azure.Core.Pipeline;
using Azure.Core.Testing;
using Azure.Storage.Queues.Models;
using Azure.Storage.Sas;
using Azure.Storage.Test;
using Azure.Storage.Test.Shared;

namespace Azure.Storage.Queues.Tests
{
    public class QueueTestBase : StorageTestBase
    {
        public string GetNewQueueName() => $"test-queue-{this.Recording.Random.NewGuid()}";
        public string GetNewMessageId() => $"test-message-{this.Recording.Random.NewGuid()}";

        public QueueTestBase(bool async) : this(async, null) { }

        public QueueTestBase(bool async, RecordedTestMode? mode = null)
            : base(async, mode)
        {
        }

        public QueueClientOptions GetOptions()
            => this.Recording.InstrumentClientOptions(
                    new QueueClientOptions
                    {
                        ResponseClassifier = new TestResponseClassifier(),
                        Diagnostics = { IsLoggingEnabled = true },
                        Retry =
                        {
                            Mode = RetryMode.Exponential,
                            MaxRetries = Azure.Storage.Constants.MaxReliabilityRetries,
                            Delay = TimeSpan.FromSeconds(this.Mode == RecordedTestMode.Playback ? 0.01 : 0.5),
                            MaxDelay = TimeSpan.FromSeconds(this.Mode == RecordedTestMode.Playback ? 0.1 : 10)
                        }
                    });

        public QueueServiceClient GetServiceClient_SharedKey()
            => this.InstrumentClient(
                new QueueServiceClient(
                    new Uri(this.TestConfigDefault.QueueServiceEndpoint),
                    new StorageSharedKeyCredential(
                        this.TestConfigDefault.AccountName,
                        this.TestConfigDefault.AccountKey),
                    this.GetOptions()));

        public QueueServiceClient GetServiceClient_AccountSas(StorageSharedKeyCredential sharedKeyCredentials = default, SasQueryParameters sasCredentials = default)
            => this.InstrumentClient(
                new QueueServiceClient(
                    new Uri($"{this.TestConfigDefault.QueueServiceEndpoint}?{sasCredentials ?? this.GetNewAccountSasCredentials(sharedKeyCredentials ?? this.GetNewSharedKeyCredentials())}"),
                    this.GetOptions()));

        public QueueServiceClient GetServiceClient_QueueServiceSas(string queueName, StorageSharedKeyCredential sharedKeyCredentials = default, SasQueryParameters sasCredentials = default)
            => this.InstrumentClient(
                new QueueServiceClient(
                    new Uri($"{this.TestConfigDefault.QueueServiceEndpoint}?{sasCredentials ?? this.GetNewQueueServiceSasCredentials(queueName, sharedKeyCredentials ?? this.GetNewSharedKeyCredentials())}"),
                    this.GetOptions()));

        public QueueServiceClient GetServiceClient_OauthAccount() =>
            this.GetServiceClientFromOauthConfig(this.TestConfigOAuth);

        private QueueServiceClient GetServiceClientFromOauthConfig(TenantConfiguration config) =>
            this.InstrumentClient(
                new QueueServiceClient(
                    new Uri(config.QueueServiceEndpoint),
                    this.GetOAuthCredential(config),
                    this.GetOptions()));

        public IDisposable GetNewQueue(out QueueClient queue, QueueServiceClient service = default, IDictionary<string, string> metadata = default)
        {
            var containerName = this.GetNewQueueName();
            service ??= this.GetServiceClient_SharedKey();
            queue = this.InstrumentClient(service.GetQueueClient(containerName));
            return new DisposingQueue(queue, metadata ?? new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase));
        }

        public StorageSharedKeyCredential GetNewSharedKeyCredentials()
            => new StorageSharedKeyCredential(
                this.TestConfigDefault.AccountName,
                this.TestConfigDefault.AccountKey);

        public SasQueryParameters GetNewAccountSasCredentials(StorageSharedKeyCredential sharedKeyCredentials = default)
            => new AccountSasBuilder
            {
                Protocol = SasProtocol.None,
                Services = new AccountSasServices { Queues = true }.ToString(),
                ResourceTypes = new AccountSasResourceTypes { Container = true }.ToString(),
                StartTime = this.Recording.UtcNow.AddHours(-1),
                ExpiryTime = this.Recording.UtcNow.AddHours(+1),
                Permissions = new QueueAccountSasPermissions { Read = true, Write = true, Update = true, Process = true, Add = true, Delete = true, List = true }.ToString(),
                IPRange = new IPRange(IPAddress.None, IPAddress.None)
            }.ToSasQueryParameters(sharedKeyCredentials);

        public SasQueryParameters GetNewQueueServiceSasCredentials(string queueName, StorageSharedKeyCredential sharedKeyCredentials = default)
            => new QueueSasBuilder
            {
                QueueName = queueName,
                Protocol = SasProtocol.None,
                StartTime = this.Recording.UtcNow.AddHours(-1),
                ExpiryTime = this.Recording.UtcNow.AddHours(+1),
                Permissions = new QueueAccountSasPermissions { Read = true, Update = true, Process = true, Add = true }.ToString(),
                IPRange = new IPRange(IPAddress.None, IPAddress.None)
            }.ToSasQueryParameters(sharedKeyCredentials ?? this.GetNewSharedKeyCredentials());

        class DisposingQueue : IDisposable
        {
            public QueueClient QueueClient { get; }

            public DisposingQueue(QueueClient queue, IDictionary<string, string> metadata)
            {
                queue.CreateAsync(metadata: metadata).Wait();

                this.QueueClient = queue;
            }

            public void Dispose()
            {
                if (this.QueueClient != null)
                {
                    try
                    {
                        this.QueueClient.DeleteAsync().Wait();
                    }
                    catch
                    {
                        // swallow the exception to avoid hiding another test failure
                    }
                }
            }
        }

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
                            Permission = "raup"
                        }
                }
            };
    }
}

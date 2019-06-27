// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Azure.Core.Pipeline.Policies;
using Azure.Core.Testing;
using Azure.Storage.Common;
using Azure.Storage.Queues.Models;
using Azure.Storage.Test;
using Azure.Storage.Test.Shared;

namespace Azure.Storage.Queues.Tests
{
    public class QueueTestBase : StorageTestBase
    {
        public string GetNewQueueName() => $"test-queue-{this.Recording.Random.NewGuid()}";
        public string GetNewMessageId() => $"test-message-{this.Recording.Random.NewGuid()}";

        public QueueTestBase(RecordedTestMode? mode = null)
            : base(mode)
        {
        }

        public QueueConnectionOptions GetOptions(IStorageCredentials credentials = null)
            => this.Recording.InstrumentClientOptions(
                    new QueueConnectionOptions
                    {
                        Credentials = credentials,
                        ResponseClassifier = new TestResponseClassifier(),
                        Diagnostics = { DisableLogging = false },
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
                    new Uri(TestConfigurations.DefaultTargetTenant.QueueServiceEndpoint),
                    this.GetOptions(
                        new SharedKeyCredentials(
                            TestConfigurations.DefaultTargetTenant.AccountName,
                            TestConfigurations.DefaultTargetTenant.AccountKey))));

        public QueueServiceClient GetServiceClient_AccountSas(SharedKeyCredentials sharedKeyCredentials = default, SasQueryParameters sasCredentials = default)
            => this.InstrumentClient(
                new QueueServiceClient(
                    new Uri($"{TestConfigurations.DefaultTargetTenant.QueueServiceEndpoint}?{sasCredentials ?? this.GetNewAccountSasCredentials(sharedKeyCredentials ?? this.GetNewSharedKeyCredentials())}"),
                    this.GetOptions()));

        public QueueServiceClient GetServiceClient_QueueServiceSas(string queueName, SharedKeyCredentials sharedKeyCredentials = default, SasQueryParameters sasCredentials = default)
            => this.InstrumentClient(
                new QueueServiceClient(
                    new Uri($"{TestConfigurations.DefaultTargetTenant.QueueServiceEndpoint}?{sasCredentials ?? this.GetNewQueueServiceSasCredentials(queueName, sharedKeyCredentials ?? this.GetNewSharedKeyCredentials())}"),
                    this.GetOptions()));

        public async Task<QueueServiceClient> GetServiceClient_OauthAccount()
            => await this.GetServiceClientFromOauthConfig(TestConfigurations.DefaultTargetOAuthTenant);

        private async Task<QueueServiceClient> GetServiceClientFromOauthConfig(TenantConfiguration config)
        {
            var initalToken = await this.GenerateOAuthToken(
                config.ActiveDirectoryAuthEndpoint,
                config.ActiveDirectoryTenantId,
                config.ActiveDirectoryApplicationId,
                config.ActiveDirectoryApplicationSecret);

            return this.InstrumentClient(
                new QueueServiceClient(
                    new Uri(config.QueueServiceEndpoint),
                    this.GetOptions(new TokenCredentials(initalToken))));
        }

        public IDisposable GetNewQueue(out QueueClient queue, QueueServiceClient service = default, IDictionary<string, string> metadata = default)
        {
            var containerName = this.GetNewQueueName();
            service = service ?? this.GetServiceClient_SharedKey();
            var result = new DisposingQueue(
                this.InstrumentClient(service.GetQueueClient(containerName)),
                metadata ?? new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase));
            queue = this.InstrumentClient(result.QueueClient);
            return result;
        }

        public SharedKeyCredentials GetNewSharedKeyCredentials()
            => new SharedKeyCredentials(
                TestConfigurations.DefaultTargetTenant.AccountName,
                TestConfigurations.DefaultTargetTenant.AccountKey);

        public SasQueryParameters GetNewAccountSasCredentials(SharedKeyCredentials sharedKeyCredentials = default)
            => new AccountSasSignatureValues
            {
                Protocol = SasProtocol.None,
                Services = new AccountSasServices { Queue = true }.ToString(),
                ResourceTypes = new AccountSasResourceTypes { Container = true }.ToString(),
                StartTime = this.Recording.UtcNow.AddHours(-1),
                ExpiryTime = this.Recording.UtcNow.AddHours(+1),
                Permissions = new QueueAccountSasPermissions { Read = true, Write = true, Update = true, Process = true, Add = true, Delete = true, List = true }.ToString(),
                IPRange = new IPRange { Start = IPAddress.None, End = IPAddress.None }
            }.ToSasQueryParameters(sharedKeyCredentials);

        public SasQueryParameters GetNewQueueServiceSasCredentials(string queueName, SharedKeyCredentials sharedKeyCredentials = default)
            => new QueueSasBuilder
            {
                QueueName = queueName,
                Protocol = SasProtocol.None,
                StartTime = this.Recording.UtcNow.AddHours(-1),
                ExpiryTime = this.Recording.UtcNow.AddHours(+1),
                Permissions = new QueueAccountSasPermissions { Read = true, Update = true, Process = true, Add = true }.ToString(),
                IPRange = new IPRange { Start = IPAddress.None, End = IPAddress.None }
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

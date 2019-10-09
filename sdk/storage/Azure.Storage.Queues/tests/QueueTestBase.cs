// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Net;
using Azure.Core.Pipeline;
using Azure.Core.Testing;
using Azure.Storage.Common.Test;
using Azure.Storage.Queues.Models;
using Azure.Storage.Sas;
using Azure.Storage.Test;
using Azure.Storage.Test.Shared;

namespace Azure.Storage.Queues.Tests
{
    public class QueueTestBase : StorageTestBase
    {
        public string GetNewQueueName() => $"test-queue-{Recording.Random.NewGuid()}";
        public string GetNewMessageId() => $"test-message-{Recording.Random.NewGuid()}";

        protected string SecondaryStorageTenantPrimaryHost() =>
            new Uri(TestConfigSecondary.QueueServiceEndpoint).Host;

        protected string SecondaryStorageTenantSecondaryHost() =>
            new Uri(TestConfigSecondary.QueueServiceSecondaryEndpoint).Host;

        public QueueTestBase(bool async) : this(async, null) { }

        public QueueTestBase(bool async, RecordedTestMode? mode = null)
            : base(async, mode)
        {
        }

        public QueueClientOptions GetOptions()
        {
            var options = new QueueClientOptions
            {
                Diagnostics = { IsLoggingEnabled = true },
                Retry =
                {
                    Mode = RetryMode.Exponential,
                    MaxRetries = Azure.Storage.Constants.MaxReliabilityRetries,
                    Delay = TimeSpan.FromSeconds(Mode == RecordedTestMode.Playback ? 0.01 : 0.5),
                    MaxDelay = TimeSpan.FromSeconds(Mode == RecordedTestMode.Playback ? 0.1 : 10)
                }
            };
            if (Mode != RecordedTestMode.Live)
            {
                options.AddPolicy(new RecordedClientRequestIdPolicy(Recording), HttpPipelinePosition.PerCall);
            }

            return Recording.InstrumentClientOptions(options);
        }

        public QueueServiceClient GetServiceClient_SharedKey()
            => InstrumentClient(
                new QueueServiceClient(
                    new Uri(TestConfigDefault.QueueServiceEndpoint),
                    new StorageSharedKeyCredential(
                        TestConfigDefault.AccountName,
                        TestConfigDefault.AccountKey),
                    GetOptions()));

        public QueueServiceClient GetServiceClient_AccountSas(StorageSharedKeyCredential sharedKeyCredentials = default, SasQueryParameters sasCredentials = default)
            => InstrumentClient(
                new QueueServiceClient(
                    new Uri($"{TestConfigDefault.QueueServiceEndpoint}?{sasCredentials ?? GetNewAccountSasCredentials(sharedKeyCredentials ?? GetNewSharedKeyCredentials())}"),
                    GetOptions()));

        public QueueServiceClient GetServiceClient_QueueServiceSas(string queueName, StorageSharedKeyCredential sharedKeyCredentials = default, SasQueryParameters sasCredentials = default)
            => InstrumentClient(
                new QueueServiceClient(
                    new Uri($"{TestConfigDefault.QueueServiceEndpoint}?{sasCredentials ?? GetNewQueueServiceSasCredentials(queueName, sharedKeyCredentials ?? GetNewSharedKeyCredentials())}"),
                    GetOptions()));

        public QueueServiceClient GetServiceClient_OauthAccount() =>
            GetServiceClientFromOauthConfig(TestConfigOAuth);

        public QueueServiceClient GetServiceClient_SecondaryAccount_ReadEnabledOnRetry(int numberOfReadFailuresToSimulate, out TestExceptionPolicy testExceptionPolicy, bool simulate404 = false)
=> GetSecondaryReadServiceClient(TestConfigSecondary, numberOfReadFailuresToSimulate, out testExceptionPolicy, simulate404);

        public QueueClient GetQueueClient_SecondaryAccount_ReadEnabledOnRetry(int numberOfReadFailuresToSimulate, out TestExceptionPolicy testExceptionPolicy, bool simulate404 = false)
=> GetSecondaryReadQueueClient(TestConfigSecondary, numberOfReadFailuresToSimulate, out testExceptionPolicy, simulate404);

        private QueueServiceClient GetSecondaryReadServiceClient(TenantConfiguration config, int numberOfReadFailuresToSimulate, out TestExceptionPolicy testExceptionPolicy, bool simulate404 = false, List<RequestMethod> enabledRequestMethods = null)
        {
            QueueClientOptions options = getSecondaryStorageOptions(config, out testExceptionPolicy, numberOfReadFailuresToSimulate, simulate404, enabledRequestMethods);

            return InstrumentClient(
                 new QueueServiceClient(
                    new Uri(config.QueueServiceEndpoint),
                    new StorageSharedKeyCredential(config.AccountName, config.AccountKey),
                    options));
        }

        private QueueClient GetSecondaryReadQueueClient(TenantConfiguration config, int numberOfReadFailuresToSimulate, out TestExceptionPolicy testExceptionPolicy, bool simulate404 = false, List<RequestMethod> enabledRequestMethods = null)
        {
            QueueClientOptions options = getSecondaryStorageOptions(config, out testExceptionPolicy, numberOfReadFailuresToSimulate, simulate404, enabledRequestMethods);

            return InstrumentClient(
                 new QueueClient(
                    new Uri(config.QueueServiceEndpoint).AppendToPath(GetNewQueueName()),
                    new StorageSharedKeyCredential(config.AccountName, config.AccountKey),
                    options));
        }

        private QueueClientOptions getSecondaryStorageOptions(TenantConfiguration config, out TestExceptionPolicy testExceptionPolicy, int numberOfReadFailuresToSimulate = 1, bool simulate404 = false, List<RequestMethod> enabledRequestMethods = null)
        {
            QueueClientOptions options = GetOptions();
            options.GeoRedundantSecondaryUri = new Uri(config.QueueServiceSecondaryEndpoint);
            options.Retry.MaxRetries = 4;
            testExceptionPolicy = new TestExceptionPolicy(numberOfReadFailuresToSimulate, options.GeoRedundantSecondaryUri, simulate404, enabledRequestMethods);
            options.AddPolicy(testExceptionPolicy, HttpPipelinePosition.PerRetry);
            return options;
        }

        private QueueServiceClient GetServiceClientFromOauthConfig(TenantConfiguration config) =>
            InstrumentClient(
                new QueueServiceClient(
                    new Uri(config.QueueServiceEndpoint),
                    GetOAuthCredential(config),
                    GetOptions()));

        public IDisposable GetNewQueue(out QueueClient queue, QueueServiceClient service = default, IDictionary<string, string> metadata = default)
        {
            var containerName = GetNewQueueName();
            service ??= GetServiceClient_SharedKey();
            queue = InstrumentClient(service.GetQueueClient(containerName));
            return new DisposingQueue(queue, metadata ?? new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase));
        }

        public StorageSharedKeyCredential GetNewSharedKeyCredentials()
            => new StorageSharedKeyCredential(
                TestConfigDefault.AccountName,
                TestConfigDefault.AccountKey);

        public SasQueryParameters GetNewAccountSasCredentials(StorageSharedKeyCredential sharedKeyCredentials = default)
            => new AccountSasBuilder
            {
                Protocol = SasProtocol.None,
                Services = new AccountSasServices { Queues = true }.ToString(),
                ResourceTypes = new AccountSasResourceTypes { BlobContainer = true }.ToString(),
                StartTime = Recording.UtcNow.AddHours(-1),
                ExpiryTime = Recording.UtcNow.AddHours(+1),
                Permissions = new QueueAccountSasPermissions { Read = true, Write = true, Update = true, Process = true, Add = true, Delete = true, List = true }.ToString(),
                IPRange = new IPRange(IPAddress.None, IPAddress.None)
            }.ToSasQueryParameters(sharedKeyCredentials);

        public SasQueryParameters GetNewQueueServiceSasCredentials(string queueName, StorageSharedKeyCredential sharedKeyCredentials = default)
            => new QueueSasBuilder
            {
                QueueName = queueName,
                Protocol = SasProtocol.None,
                StartTime = Recording.UtcNow.AddHours(-1),
                ExpiryTime = Recording.UtcNow.AddHours(+1),
                Permissions = new QueueAccountSasPermissions { Read = true, Update = true, Process = true, Add = true }.ToString(),
                IPRange = new IPRange(IPAddress.None, IPAddress.None)
            }.ToSasQueryParameters(sharedKeyCredentials ?? GetNewSharedKeyCredentials());

        private class DisposingQueue : IDisposable
        {
            public QueueClient QueueClient { get; }

            public DisposingQueue(QueueClient queue, IDictionary<string, string> metadata)
            {
                queue.CreateAsync(metadata: metadata).Wait();

                QueueClient = queue;
            }

            public void Dispose()
            {
                if (QueueClient != null)
                {
                    try
                    {
                        QueueClient.DeleteAsync().Wait();
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
                    Id = GetNewString(),
                    AccessPolicy =
                        new AccessPolicy
                        {
                            Start =  Recording.UtcNow.AddHours(-1),
                            Expiry =  Recording.UtcNow.AddHours(1),
                            Permission = "raup"
                        }
                }
            };
    }
}

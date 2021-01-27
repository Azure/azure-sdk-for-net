// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
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
                    MaxRetries = Constants.MaxReliabilityRetries,
                    Delay = TimeSpan.FromSeconds(Mode == RecordedTestMode.Playback ? 0.01 : 1),
                    MaxDelay = TimeSpan.FromSeconds(Mode == RecordedTestMode.Playback ? 0.1 : 60)
                },
                Transport = GetTransport()
        };
            if (Mode != RecordedTestMode.Live)
            {
                options.AddPolicy(new RecordedClientRequestIdPolicy(Recording), HttpPipelinePosition.PerCall);
            }

            return InstrumentClientOptions(options);
        }

        public QueueServiceClient GetServiceClient_SharedKey(QueueClientOptions options = default)
            => InstrumentClient(
                new QueueServiceClient(
                    new Uri(TestConfigDefault.QueueServiceEndpoint),
                    new StorageSharedKeyCredential(
                        TestConfigDefault.AccountName,
                        TestConfigDefault.AccountKey),
                    options ?? GetOptions()));

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

        public Security.KeyVault.Keys.KeyClient GetKeyClient_TargetKeyClient()
            => GetKeyClient(TestConfigurations.DefaultTargetKeyVault);

        public TokenCredential GetTokenCredential_TargetKeyClient()
            => GetKeyClientTokenCredential(TestConfigurations.DefaultTargetKeyVault);

        private static Security.KeyVault.Keys.KeyClient GetKeyClient(KeyVaultConfiguration config)
            => new Security.KeyVault.Keys.KeyClient(
                new Uri(config.VaultEndpoint),
                GetKeyClientTokenCredential(config));

        private static TokenCredential GetKeyClientTokenCredential(KeyVaultConfiguration config)
            => new Identity.ClientSecretCredential(
                config.ActiveDirectoryTenantId,
                config.ActiveDirectoryApplicationId,
                config.ActiveDirectoryApplicationSecret);

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

        public async Task<DisposingQueue> GetTestQueueAsync(
            QueueServiceClient service = default,
            IDictionary<string, string> metadata = default)
        {
            service ??= GetServiceClient_SharedKey();
            metadata ??= new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            QueueClient queue = InstrumentClient(service.GetQueueClient(GetNewQueueName()));
            return await DisposingQueue.CreateAsync(queue, metadata);
        }

        public QueueClient GetEncodingClient(
            string queueName,
            QueueMessageEncoding encoding)
        {
            var options = GetOptions();
            options.MessageEncoding = encoding;
            var service = GetServiceClient_SharedKey(options);
            return InstrumentClient(service.GetQueueClient(queueName));
        }

        public StorageSharedKeyCredential GetNewSharedKeyCredentials()
            => new StorageSharedKeyCredential(
                TestConfigDefault.AccountName,
                TestConfigDefault.AccountKey);

        public SasQueryParameters GetNewAccountSasCredentials(
            StorageSharedKeyCredential sharedKeyCredentials = default,
            AccountSasResourceTypes resourceTypes = AccountSasResourceTypes.Container)
        {
            var builder = new AccountSasBuilder
            {
                Protocol = SasProtocol.None,
                Services = AccountSasServices.Queues,
                ResourceTypes = resourceTypes,
                StartsOn = Recording.UtcNow.AddHours(-1),
                ExpiresOn = Recording.UtcNow.AddHours(+1),
                IPRange = new SasIPRange(IPAddress.None, IPAddress.None)
            };
            builder.SetPermissions(
                AccountSasPermissions.Read |
                AccountSasPermissions.Write |
                AccountSasPermissions.Update |
                AccountSasPermissions.Process |
                AccountSasPermissions.Add |
                AccountSasPermissions.Delete |
                AccountSasPermissions.List);
            return builder.ToSasQueryParameters(sharedKeyCredentials ?? GetNewSharedKeyCredentials());
        }

        public SasQueryParameters GetNewQueueServiceSasCredentials(string queueName, StorageSharedKeyCredential sharedKeyCredentials = default)
        {
            var builder = new QueueSasBuilder
            {
                QueueName = queueName,
                Protocol = SasProtocol.None,
                StartsOn = Recording.UtcNow.AddHours(-1),
                ExpiresOn = Recording.UtcNow.AddHours(+1),
                IPRange = new SasIPRange(IPAddress.None, IPAddress.None)
            };
            builder.SetPermissions(QueueAccountSasPermissions.Read | QueueAccountSasPermissions.Update | QueueAccountSasPermissions.Process | QueueAccountSasPermissions.Add);
            return builder.ToSasQueryParameters(sharedKeyCredentials ?? GetNewSharedKeyCredentials());
        }

        internal StorageConnectionString GetConnectionString(
            SharedAccessSignatureCredentials credentials = default,
            bool includeEndpoint = true)
        {
            credentials ??= GetAccountSasCredentials();
            if (!includeEndpoint)
            {
                return TestExtensions.CreateStorageConnectionString(
                    credentials,
                    TestConfigDefault.AccountName);
            }

            (Uri, Uri) queueUri = StorageConnectionString.ConstructQueueEndpoint(
                Constants.Https,
                TestConfigDefault.AccountName,
                default,
                default);

            return new StorageConnectionString(
                    credentials,
                    queueStorageUri: queueUri);
        }

        public class DisposingQueue : IAsyncDisposable
        {
            public QueueClient Queue { get; private set; }

            public static async Task<DisposingQueue> CreateAsync(QueueClient queue, IDictionary<string, string> metadata)
            {
                await queue.CreateIfNotExistsAsync(metadata: metadata);
                return new DisposingQueue(queue);
            }

            private DisposingQueue(QueueClient queue)
            {
                Queue = queue;
            }

            public async ValueTask DisposeAsync()
            {
                if (Queue != null)
                {
                    try
                    {
                        await Queue.DeleteIfExistsAsync();
                        Queue = null;
                    }
                    catch
                    {
                        // swallow the exception to avoid hiding another test failure
                    }
                }
            }
        }

        public QueueSignedIdentifier[] BuildSignedIdentifiers() =>
            new[]
            {
                new QueueSignedIdentifier
                {
                    Id = GetNewString(),
                    AccessPolicy =
                        new QueueAccessPolicy
                        {
                            StartsOn =  Recording.UtcNow.AddHours(-1),
                            ExpiresOn =  Recording.UtcNow.AddHours(1),
                            Permissions = "raup"
                        }
                }
            };

        public QueueServiceProperties GetQueueServiceProperties() =>
            new QueueServiceProperties()
            {
                Logging = new QueueAnalyticsLogging()
                {
                    Version = "1.0",
                    Read = false,
                    Write = false,
                    Delete = false,
                    RetentionPolicy = new QueueRetentionPolicy()
                    {
                        Enabled = false
                    }
                },
                HourMetrics = new QueueMetrics()
                {
                    Version = "1.0",
                    Enabled = true,
                    IncludeApis = true,
                    RetentionPolicy = new QueueRetentionPolicy()
                    {
                        Enabled = true,
                        Days = 7
                    }
                },
                MinuteMetrics = new QueueMetrics()
                {
                    Version = "1.0",
                    Enabled = false,
                    RetentionPolicy = new QueueRetentionPolicy()
                    {
                        Enabled = true,
                        Days = 7
                    }
                },
                Cors = new[]
                {
                    new QueueCorsRule()
                    {
                        AllowedOrigins = "http://www.contoso.com,http://www.fabrikam.com",
                        AllowedMethods = "GET,PUT",
                        MaxAgeInSeconds = 500,
                        ExposedHeaders = "x-ms-meta-customheader,x-ms-meta-data*",
                        AllowedHeaders = "x-ms-meta-customheader,x-ms-meta-target*"
                    }
                }
            };
    }
}

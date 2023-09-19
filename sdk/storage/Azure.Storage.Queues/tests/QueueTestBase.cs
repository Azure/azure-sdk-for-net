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
    public class QueueTestBase : StorageTestBase<StorageTestEnvironment>
    {
        /// <summary>
        /// Source of clients.
        /// </summary>
        protected ClientBuilder<QueueServiceClient, QueueClientOptions> QueuesClientBuilder { get; }

        public string GetNewQueueName() => QueuesClientBuilder.GetNewQueueName();
        public string GetNewMessageId() => QueuesClientBuilder.GetNewMessageId();

        public Uri GetDefaultPrimaryEndpoint() => new Uri(QueuesClientBuilder.Tenants.TestConfigDefault.QueueServiceEndpoint);

        protected string SecondaryStorageTenantPrimaryHost() =>
            new Uri(Tenants.TestConfigSecondary.QueueServiceEndpoint).Host;

        protected string SecondaryStorageTenantSecondaryHost() =>
            new Uri(Tenants.TestConfigSecondary.QueueServiceSecondaryEndpoint).Host;

        public QueueTestBase(bool async) : this(async, null) { }

        public QueueTestBase(bool async, RecordedTestMode? mode = null)
            : base(async, mode)
        {
            QueuesClientBuilder = new ClientBuilder<QueueServiceClient, QueueClientOptions>(
                ServiceEndpoint.Queue,
                Tenants,
                (uri, clientOptions) => new QueueServiceClient(uri, clientOptions),
                (uri, sharedKeyCredential, clientOptions) => new QueueServiceClient(uri, sharedKeyCredential, clientOptions),
                (uri, tokenCredential, clientOptions) => new QueueServiceClient(uri, tokenCredential, clientOptions),
                (uri, azureSasCredential, clientOptions) => new QueueServiceClient(uri, azureSasCredential, clientOptions),
                () => new QueueClientOptions());
        }

        public QueueClientOptions GetOptions()
            => QueuesClientBuilder.GetOptions();

        public QueueClientOptions GetOptionsWithAudience(QueueAudience audience)
        {
            QueueClientOptions options = QueuesClientBuilder.GetOptions(false);
            options.Audience = audience;
            return options;
        }

        public QueueServiceClient GetServiceClient_SharedKey(QueueClientOptions options = default)
            => InstrumentClient(GetServiceClient_SharedKey_UnInstrumented(options));

        private QueueServiceClient GetServiceClient_SharedKey_UnInstrumented(QueueClientOptions options = default)
            => new QueueServiceClient(
                    new Uri(TestConfigDefault.QueueServiceEndpoint),
                    new StorageSharedKeyCredential(
                        TestConfigDefault.AccountName,
                        TestConfigDefault.AccountKey),
                    options ?? GetOptions());

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

        public QueueServiceClient GetServiceClient_SecondaryAccount_ReadEnabledOnRetry(int numberOfReadFailuresToSimulate, out TestExceptionPolicy testExceptionPolicy, bool simulate404 = false)
            => GetSecondaryReadServiceClient(Tenants.TestConfigSecondary, numberOfReadFailuresToSimulate, out testExceptionPolicy, simulate404);

        public QueueClient GetQueueClient_SecondaryAccount_ReadEnabledOnRetry(int numberOfReadFailuresToSimulate, out TestExceptionPolicy testExceptionPolicy, bool simulate404 = false)
            => GetSecondaryReadQueueClient(Tenants.TestConfigSecondary, numberOfReadFailuresToSimulate, out testExceptionPolicy, simulate404);

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

        public async Task<DisposingQueue> GetTestQueueAsync(
            QueueServiceClient service = default,
            IDictionary<string, string> metadata = default)
            => await QueuesClientBuilder.GetTestQueueAsync(service, metadata);

        public QueueClient GetEncodingClient(
            string queueName,
            QueueMessageEncoding encoding,
            params SyncAsyncEventHandler<QueueMessageDecodingFailedEventArgs>[] messageDecodingFailedHandlers)
        {
            var options = GetOptions();
            options.MessageEncoding = encoding;
            foreach (var messageDecodingFailedHandler in messageDecodingFailedHandlers)
            {
                options.MessageDecodingFailed += messageDecodingFailedHandler;
            }
            var service = GetServiceClient_SharedKey_UnInstrumented(options);
            var queueClient = service.GetQueueClient(queueName);
            return InstrumentClient(queueClient);
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
                return new StorageConnectionString(
                    credentials,
                    (new Uri(TestConfigDefault.BlobServiceEndpoint), new Uri(TestConfigDefault.BlobServiceSecondaryEndpoint)),
                    (new Uri(TestConfigDefault.QueueServiceEndpoint), new Uri(TestConfigDefault.QueueServiceSecondaryEndpoint)),
                    (new Uri(TestConfigDefault.TableServiceEndpoint), new Uri(TestConfigDefault.TableServiceSecondaryEndpoint)),
                    (new Uri(TestConfigDefault.FileServiceEndpoint), new Uri(TestConfigDefault.FileServiceSecondaryEndpoint)));
            }

            (Uri, Uri) queueUri = (new Uri(TestConfigDefault.QueueServiceEndpoint), new Uri(TestConfigDefault.QueueServiceSecondaryEndpoint));

            return new StorageConnectionString(
                    credentials,
                    queueStorageUri: queueUri);
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

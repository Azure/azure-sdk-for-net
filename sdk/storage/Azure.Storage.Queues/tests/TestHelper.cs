// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Azure.Storage.Common;
using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;

namespace Azure.Storage.Test
{
    partial class TestHelper
    {
        public static string GetNewQueueName() => $"test-queue-{Guid.NewGuid()}";
        public static string GetNewMessageId() => $"test-message-{Guid.NewGuid()}";

        public static QueueServiceClient GetServiceClient_SharedKey()
            => new QueueServiceClient(
                    new Uri(TestConfigurations.DefaultTargetTenant.QueueServiceEndpoint),
                    GetOptions<QueueConnectionOptions>(
                        new SharedKeyCredentials(
                            TestConfigurations.DefaultTargetTenant.AccountName,
                            TestConfigurations.DefaultTargetTenant.AccountKey)));
        
        public static QueueServiceClient GetServiceClient_AccountSas(SharedKeyCredentials sharedKeyCredentials = default, SasQueryParameters sasCredentials = default)
            => new QueueServiceClient(
                    new Uri($"{TestConfigurations.DefaultTargetTenant.QueueServiceEndpoint}?{sasCredentials ?? GetNewAccountSasCredentials(sharedKeyCredentials ?? GetNewSharedKeyCredentials())}"),
                    GetOptions<QueueConnectionOptions>());

        public static QueueServiceClient GetServiceClient_QueueServiceSas(string queueName, SharedKeyCredentials sharedKeyCredentials = default, SasQueryParameters sasCredentials = default)
            => new QueueServiceClient(
                    new Uri($"{TestConfigurations.DefaultTargetTenant.QueueServiceEndpoint}?{sasCredentials ?? GetNewQueueServiceSasCredentials(queueName, sharedKeyCredentials ?? GetNewSharedKeyCredentials())}"),
                    GetOptions<QueueConnectionOptions>());

        public static async Task<QueueServiceClient> GetServiceClient_OauthAccount()
            => await GetServiceClientFromOauthConfig(TestConfigurations.DefaultTargetOAuthTenant);

        private static async Task<QueueServiceClient> GetServiceClientFromOauthConfig(TenantConfiguration config)
        {
            var initalToken = await TestHelper.GenerateOAuthToken(
                config.ActiveDirectoryAuthEndpoint,
                config.ActiveDirectoryTenantId,
                config.ActiveDirectoryApplicationId,
                config.ActiveDirectoryApplicationSecret);

            return new QueueServiceClient(
                new Uri(config.QueueServiceEndpoint),
                GetOptions<QueueConnectionOptions>(new TokenCredentials(initalToken)));
        }

        public static IDisposable GetNewQueue(out QueueClient queue, QueueServiceClient service = default, IDictionary<string, string> metadata = default)
        {
            var containerName = TestHelper.GetNewQueueName();

            service = service ?? GetServiceClient_SharedKey();

            var result = new DisposingQueue(service.GetQueueClient(containerName), metadata ?? new Dictionary<string, string>());

            queue = result.QueueClient;

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
                Services = new AccountSasServices { Queue = true }.ToString(),
                ResourceTypes = new AccountSasResourceTypes { Container = true }.ToString(),
                StartTime = DateTimeOffset.UtcNow.AddHours(-1),
                ExpiryTime = DateTimeOffset.UtcNow.AddHours(+1),
                Permissions = new QueueAccountSasPermissions { Read = true, Write = true, Update = true, Process = true, Add = true, Delete = true, List = true }.ToString(),
                IPRange = new IPRange { Start = IPAddress.None, End = IPAddress.None }
            }.ToSasQueryParameters(sharedKeyCredentials);

        public static SasQueryParameters GetNewQueueServiceSasCredentials(string queueName, SharedKeyCredentials sharedKeyCredentials = default)
            => new QueueSasBuilder
            {
                QueueName = queueName,
                Protocol = SasProtocol.None,
                StartTime = DateTimeOffset.UtcNow.AddHours(-1),
                ExpiryTime = DateTimeOffset.UtcNow.AddHours(+1),
                Permissions = new QueueAccountSasPermissions { Read = true, Update = true, Process = true, Add = true }.ToString(),
                IPRange = new IPRange { Start = IPAddress.None, End = IPAddress.None }
            }.ToSasQueryParameters(sharedKeyCredentials ?? GetNewSharedKeyCredentials());

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
                            Permission = "raup"
                        }
                }
            };
    }
}

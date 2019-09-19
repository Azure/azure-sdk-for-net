// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.Testing;
using Azure.Storage.Common;
using Azure.Storage.Queues.Tests;
using Azure.Storage.Test;
using NUnit.Framework;

namespace Azure.Storage.Queues.Test
{
    public class QueueClientTests : QueueTestBase
    {
        public QueueClientTests(bool async)
            : base(async, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        [Test]
        public void Ctor_ConnectionString()
        {
            var accountName = "accountName";
            var accountKey = Convert.ToBase64String(new byte[] { 0, 1, 2, 3, 4, 5 });

            var credentials = new StorageSharedKeyCredential(accountName, accountKey);
            var queueEndpoint = new Uri("http://127.0.0.1/" + accountName);
            var queueSecondaryEndpoint = new Uri("http://127.0.0.1/" + accountName + "-secondary");

            var connectionString = new StorageConnectionString(credentials, (default, default), (queueEndpoint, queueSecondaryEndpoint), (default, default), (default, default));

            var queueName = GetNewQueueName();

            QueueClient client = InstrumentClient(new QueueClient(connectionString.ToString(true), queueName, GetOptions()));

            var builder = new QueueUriBuilder(client.Uri);

            Assert.AreEqual(queueName, builder.QueueName);
            //Assert.AreEqual("accountName", builder.AccountName);
        }

        [Test]
        public async Task CreateAsync_WithSharedKey()
        {
            // Arrange
            var queueName = GetNewQueueName();
            QueueServiceClient service = GetServiceClient_SharedKey();
            QueueClient queue = InstrumentClient(service.GetQueueClient(queueName));

            try
            {
                // Act
                Response result = await queue.CreateAsync();

                // Assert
                Assert.IsNotNull(result.Headers.RequestId, $"{nameof(result)} may not be populated");
            }
            finally
            {
                await queue.DeleteAsync();
            }
        }

        [Test]
        public async Task CreateAsync_FromService()
        {
            var name = GetNewQueueName();
            QueueServiceClient service = GetServiceClient_SharedKey();
            try
            {
                Response<QueueClient> result = await service.CreateQueueAsync(name);
                Response<Models.QueueProperties> properties = await result.Value.GetPropertiesAsync();
                Assert.AreEqual(0, properties.Value.ApproximateMessagesCount);
            }
            finally
            {
                await service.DeleteQueueAsync(name);
            }
        }

        [Test]
        public async Task CreateAsync_WithOauth()
        {
            // Arrange
            var queueName = GetNewQueueName();
            QueueServiceClient service = GetServiceClient_OauthAccount();
            QueueClient queue = InstrumentClient(service.GetQueueClient(queueName));

            try
            {
                // Act
                Response result = await queue.CreateAsync();

                // Assert
                Assert.IsNotNull(result.Headers.RequestId, $"{nameof(result)} may not be populated");
            }
            finally
            {
                await queue.DeleteAsync();
            }
        }

        [Test]
        public async Task CreateAsync_WithAccountSas()
        {
            // Arrange
            var queueName = GetNewQueueName();
            QueueServiceClient service = GetServiceClient_AccountSas();
            QueueClient queue = InstrumentClient(service.GetQueueClient(queueName));

            try
            {
                // Act
                Response result = await queue.CreateAsync();

                // Assert
                Assert.IsNotNull(result.Headers.RequestId, $"{nameof(result)} may not be populated");
            }
            finally
            {
                await queue.DeleteAsync();
            }
        }

        [Test]
        public async Task CreateAsync_WithQueueServiceSas()
        {
            // Arrange
            var queueName = GetNewQueueName();
            QueueServiceClient service = GetServiceClient_QueueServiceSas(queueName);
            QueueClient queue = InstrumentClient(service.GetQueueClient(queueName));
            var pass = false;

            try
            {
                // Act
                Response result = await queue.CreateAsync();


                // Assert
                Assert.Fail("CreateAsync unexpected success: queue service SAS should not be usable to create queue");
            }
            catch (StorageRequestFailedException ex) when (ex.ErrorCode == "AuthorizationFailure") // TODO verify if this is a missing service code
            {
                pass = true;
            }
            finally
            {
                if (!pass)
                {
                    await queue.DeleteAsync();
                }
            }
        }

        [Test]
        public async Task CreateAsync_Error()
        {
            // Arrange
            var queueName = GetNewQueueName();
            QueueServiceClient service = GetServiceClient_SharedKey();
            QueueClient queue = InstrumentClient(service.GetQueueClient(queueName));
            await queue.CreateAsync();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                queue.CreateAsync(metadata: new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase) { { "key", "value" } }),
                actualException => Assert.AreEqual("QueueAlreadyExists", actualException.ErrorCode));
        }

        [Test]
        public async Task GetPropertiesAsync()
        {
            // Arrange
            using (GetNewQueue(out QueueClient queue))
            {
                // Act
                Response<Models.QueueProperties> queueProperties = await queue.GetPropertiesAsync();

                // Assert
                Assert.IsNotNull(queueProperties);
            }
        }

        [Test]
        public async Task GetPropertiesAsync_Error()
        {
            // Arrange
            var queueName = GetNewQueueName();
            QueueServiceClient service = GetServiceClient_SharedKey();
            QueueClient queue = InstrumentClient(service.GetQueueClient(queueName));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                queue.GetPropertiesAsync(),
                actualException => Assert.AreEqual("QueueNotFound", actualException.ErrorCode));
        }

        [Test]
        public async Task SetMetadataAsync_OnCreate()
        {
            // Arrange
            IDictionary<string, string> metadata = BuildMetadata();
            using (GetNewQueue(out QueueClient queue, metadata: metadata))
            {
                // Assert
                Response<Models.QueueProperties> result = await queue.GetPropertiesAsync();
                Assert.AreEqual("bar", result.Value.Metadata["foo"]);
                Assert.AreEqual("data", result.Value.Metadata["meta"]);
            }
        }

        [Test]
        public async Task SetMetadataAsync_Metadata()
        {
            // Arrange
            using (GetNewQueue(out QueueClient queue))
            {
                // Act
                IDictionary<string, string> metadata = BuildMetadata();
                await queue.SetMetadataAsync(metadata);

                // Assert
                Response<Models.QueueProperties> result = await queue.GetPropertiesAsync();
                Assert.AreEqual("bar", result.Value.Metadata["foo"]);
                Assert.AreEqual("data", result.Value.Metadata["meta"]);
            }
        }

        // Note that this test intentionally does not call queue.CreateAsync()
        [Test]
        public async Task SetMetadataAsync_Error()
        {
            // Arrange
            var queueName = GetNewQueueName();
            QueueServiceClient service = GetServiceClient_SharedKey();
            QueueClient queue = InstrumentClient(service.GetQueueClient(queueName));
            IDictionary<string, string> metadata = BuildMetadata();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                queue.SetMetadataAsync(metadata),
                actualException => Assert.AreEqual("QueueNotFound", actualException.ErrorCode));
        }

        [Test]
        public async Task GetAccessPolicyAsync()
        {
            // Arrange
            using (GetNewQueue(out QueueClient queue))
            {
                Models.SignedIdentifier[] signedIdentifiers = BuildSignedIdentifiers();

                // Act
                Response setResult = await queue.SetAccessPolicyAsync(signedIdentifiers);

                // Assert
                Response<IEnumerable<Models.SignedIdentifier>> result = await queue.GetAccessPolicyAsync();
                Models.SignedIdentifier acl = result.Value.First();

                Assert.AreEqual(1, result.Value.Count());
                Assert.AreEqual(signedIdentifiers[0].Id, acl.Id);
                Assert.AreEqual(signedIdentifiers[0].AccessPolicy.Start, acl.AccessPolicy.Start);
                Assert.AreEqual(signedIdentifiers[0].AccessPolicy.Expiry, acl.AccessPolicy.Expiry);
                Assert.AreEqual(signedIdentifiers[0].AccessPolicy.Permission, acl.AccessPolicy.Permission);
            }
        }

        // Note that this test intentionally does not call queue.CreateAsync()
        [Test]
        public async Task GetAccessPolicyAsync_Error()
        {
            // Arrange
            var queueName = GetNewQueueName();
            QueueServiceClient service = GetServiceClient_SharedKey();
            QueueClient queue = InstrumentClient(service.GetQueueClient(queueName));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                queue.GetAccessPolicyAsync(),
                actualException => Assert.AreEqual("QueueNotFound", actualException.ErrorCode));
        }

        [Test]
        public async Task SetAccessPolicyAsync()
        {
            using (GetNewQueue(out QueueClient queue))
            {
                Models.SignedIdentifier[] signedIdentifiers = BuildSignedIdentifiers();
                Response result = await queue.SetAccessPolicyAsync(signedIdentifiers);
                Assert.IsFalse(string.IsNullOrWhiteSpace(result.Headers.RequestId));
            }
        }

        // Note that this test intentionally does not call queue.CreateAsync()
        [Test]
        public async Task SetAccessPolicyAsync_Error()
        {
            // Arrange
            var queueName = GetNewQueueName();
            QueueServiceClient service = GetServiceClient_SharedKey();
            QueueClient queue = InstrumentClient(service.GetQueueClient(queueName));
            Models.SignedIdentifier[] signedIdentifiers = BuildSignedIdentifiers();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                queue.SetAccessPolicyAsync(signedIdentifiers),
                actualException => Assert.AreEqual("QueueNotFound", actualException.ErrorCode));
        }

        [Test]
        public async Task DeleteAsync()
        {
            // Arrange
            var queueName = GetNewQueueName();
            QueueServiceClient service = GetServiceClient_SharedKey();
            QueueClient queue = InstrumentClient(service.GetQueueClient(queueName));
            await queue.CreateAsync();

            // Act
            Response result = await queue.DeleteAsync();

            // Assert
            Assert.AreNotEqual(default, result.Headers.RequestId, $"{nameof(result)} may not be populated");
        }

        [Test]
        public async Task DeleteAsync_FromService()
        {
            var name = GetNewQueueName();
            QueueServiceClient service = GetServiceClient_SharedKey();
            try
            {
                QueueClient queue = (await service.CreateQueueAsync(name)).Value;
                await service.DeleteQueueAsync(name);

                // Ensure the queue no longer returns values
                Assert.ThrowsAsync<StorageRequestFailedException>(
                    async () => await queue.GetPropertiesAsync());
            }
            finally
            {
            }
        }


        // Note that this test intentionally does not call queue.CreateAsync()
        [Test]
        public async Task DeleteAsync_Error()
        {
            // Arrange
            var queueName = GetNewQueueName();
            QueueServiceClient service = GetServiceClient_SharedKey();
            QueueClient queue = InstrumentClient(service.GetQueueClient(queueName));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                queue.DeleteAsync(),
                actualException => Assert.AreEqual("QueueNotFound", actualException.ErrorCode));
        }
    }
}

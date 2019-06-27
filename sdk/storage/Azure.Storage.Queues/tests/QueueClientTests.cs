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
    [TestFixture]
    public class QueueClientTests : QueueTestBase
    {
        public QueueClientTests()
            : base(/* Use RecordedTestMode.Record here to re-record just these tests */)
        {
        }

        [Test]
        public void Ctor_ConnectionString()
        {
            var accountName = "accountName";
            var accountKey = Convert.ToBase64String(new byte[] { 0, 1, 2, 3, 4, 5 });

            var credentials = new SharedKeyCredentials(accountName, accountKey);
            var queueEndpoint = new Uri("http://127.0.0.1/" + accountName);
            var queueSecondaryEndpoint = new Uri("http://127.0.0.1/" + accountName + "-secondary");

            var connectionString = new StorageConnectionString(credentials, (default, default), (queueEndpoint, queueSecondaryEndpoint), (default, default), (default, default));

            var queueName = this.GetNewQueueName();

            var client = this.InstrumentClient(new QueueClient(connectionString.ToString(true), queueName, this.GetOptions()));

            var builder = new QueueUriBuilder(client.Uri);

            Assert.AreEqual(queueName, builder.QueueName);
            //Assert.AreEqual("accountName", builder.AccountName);
        }

        [Test]
        public async Task CreateAsync_WithSharedKey()
        {
            // Arrange
            var queueName = this.GetNewQueueName();
            var service = this.GetServiceClient_SharedKey();
            var queue = this.InstrumentClient(service.GetQueueClient(queueName));

            try
            {
                // Act
                var result = await queue.CreateAsync();

                // Assert
                Assert.IsNotNull(result.Headers.RequestId, $"{nameof(result)} may not be populated");
            }
            finally
            {
                await queue.DeleteAsync();
            }
        }

        [Test]
        public async Task CreateAsync_WithOauth()
        {
            // Arrange
            var queueName = this.GetNewQueueName();
            var service = await this.GetServiceClient_OauthAccount();
            var queue = this.InstrumentClient(service.GetQueueClient(queueName));

            try
            {
                // Act
                var result = await queue.CreateAsync();

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
            var queueName = this.GetNewQueueName();
            var service = this.GetServiceClient_AccountSas();
            var queue = this.InstrumentClient(service.GetQueueClient(queueName));

            try
            {
                // Act
                var result = await queue.CreateAsync();

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
            var queueName = this.GetNewQueueName();
            var service = this.GetServiceClient_QueueServiceSas(queueName);
            var queue = this.InstrumentClient(service.GetQueueClient(queueName));
            var pass = false;

            try
            {
                // Act
                var result = await queue.CreateAsync();


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
            var queueName = this.GetNewQueueName();
            var service = this.GetServiceClient_SharedKey();
            var queue = this.InstrumentClient(service.GetQueueClient(queueName));
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
            using (this.GetNewQueue(out var queue))
            {
                // Act
                var queueProperties = await queue.GetPropertiesAsync();

                // Assert
                Assert.IsNotNull(queueProperties);
            }
        }

        [Test]
        public async Task GetPropertiesAsync_Error()
        {
            // Arrange
            var queueName = this.GetNewQueueName();
            var service = this.GetServiceClient_SharedKey();
            var queue = this.InstrumentClient(service.GetQueueClient(queueName));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                queue.GetPropertiesAsync(),
                actualException => Assert.AreEqual("QueueNotFound", actualException.ErrorCode));
        }

        [Test]
        public async Task SetMetadataAsync_OnCreate()
        {
            // Arrange
            var metadata = this.BuildMetadata();
            using (this.GetNewQueue(out var queue, metadata: metadata))
            {
                // Assert
                var result = await queue.GetPropertiesAsync();
                Assert.AreEqual("bar", result.Value.Metadata["foo"]);
                Assert.AreEqual("data", result.Value.Metadata["meta"]);
            }
        }

        [Test]
        public async Task SetMetadataAsync_Metadata()
        {
            // Arrange
            using (this.GetNewQueue(out var queue))
            {
                // Act
                var metadata = this.BuildMetadata();
                await queue.SetMetadataAsync(metadata);

                // Assert
                var result = await queue.GetPropertiesAsync();
                Assert.AreEqual("bar", result.Value.Metadata["foo"]);
                Assert.AreEqual("data", result.Value.Metadata["meta"]);
            }
        }

        // Note that this test intentionally does not call queue.CreateAsync()
        [Test]
        public async Task SetMetadataAsync_Error()
        {
            // Arrange
            var queueName = this.GetNewQueueName();
            var service = this.GetServiceClient_SharedKey();
            var queue = this.InstrumentClient(service.GetQueueClient(queueName));
            var metadata = this.BuildMetadata();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                queue.SetMetadataAsync(metadata),
                actualException => Assert.AreEqual("QueueNotFound", actualException.ErrorCode));
        }

        [Test]
        public async Task GetAccessPolicyAsync()
        {
            // Arrange
            using (this.GetNewQueue(out var queue))
            {
                var signedIdentifiers = this.BuildSignedIdentifiers();

                // Act
                var setResult = await queue.SetAccessPolicyAsync(signedIdentifiers);

                // Assert
                var result = await queue.GetAccessPolicyAsync();
                var acl = result.Value.First();

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
            var queueName = this.GetNewQueueName();
            var service = this.GetServiceClient_SharedKey();
            var queue = this.InstrumentClient(service.GetQueueClient(queueName));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                queue.GetAccessPolicyAsync(),
                actualException => Assert.AreEqual("QueueNotFound", actualException.ErrorCode));
        }

        [Test]
        public async Task SetAccessPolicyAsync()
        {
            using (this.GetNewQueue(out var queue))
            {
                var signedIdentifiers = this.BuildSignedIdentifiers();
                var result = await queue.SetAccessPolicyAsync(signedIdentifiers);
                Assert.IsFalse(String.IsNullOrWhiteSpace(result.Headers.RequestId));
            }
        }

        // Note that this test intentionally does not call queue.CreateAsync()
        [Test]
        public async Task SetAccessPolicyAsync_Error()
        {
            // Arrange
            var queueName = this.GetNewQueueName();
            var service = this.GetServiceClient_SharedKey();
            var queue = this.InstrumentClient(service.GetQueueClient(queueName));
            var signedIdentifiers = this.BuildSignedIdentifiers();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                queue.SetAccessPolicyAsync(signedIdentifiers),
                actualException => Assert.AreEqual("QueueNotFound", actualException.ErrorCode));
        }

        [Test]
        public async Task DeleteAsync()
        {
            // Arrange
            var queueName = this.GetNewQueueName();
            var service = this.GetServiceClient_SharedKey();
            var queue = this.InstrumentClient(service.GetQueueClient(queueName));
            await queue.CreateAsync();

            // Act
            var result = await queue.DeleteAsync();

            // Assert
            Assert.AreNotEqual(default, result.Headers.RequestId, $"{nameof(result)} may not be populated");
        }

        // Note that this test intentionally does not call queue.CreateAsync()
        [Test]
        public async Task DeleteAsync_Error()
        {
            // Arrange
            var queueName = this.GetNewQueueName();
            var service = this.GetServiceClient_SharedKey();
            var queue = this.InstrumentClient(service.GetQueueClient(queueName));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                queue.DeleteAsync(),
                actualException => Assert.AreEqual("QueueNotFound", actualException.ErrorCode));
        }
    }
}

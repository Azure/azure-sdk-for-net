// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Storage.Common;
using Azure.Storage.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Azure.Storage.Queues.Test
{
    [TestClass]
    public class QueueClientTests
    {
        [TestMethod]
        public void Ctor_ConnectionString()
        {
            var accountName = "accountName";
            var accountKey = Convert.ToBase64String(new byte[] { 0, 1, 2, 3, 4, 5 });

            var credentials = new SharedKeyCredentials(accountName, accountKey);
            var queueEndpoint = new Uri("http://127.0.0.1/" + accountName);
            var queueSecondaryEndpoint = new Uri("http://127.0.0.1/" + accountName + "-secondary");

            var connectionString = new StorageConnectionString(credentials, (default, default), (queueEndpoint, queueSecondaryEndpoint), (default, default), (default, default));

            var queueName = TestHelper.GetNewQueueName();

            var client = new QueueClient(connectionString.ToString(true), queueName, TestHelper.GetOptions<QueueConnectionOptions>());

            var builder = new QueueUriBuilder(client.Uri);

            Assert.AreEqual(queueName, builder.QueueName);
            //Assert.AreEqual("accountName", builder.AccountName);
        }

        [TestMethod]
        public async Task CreateAsync_WithSharedKey()
        {
            // Arrange
            var queueName = TestHelper.GetNewQueueName();
            var service = TestHelper.GetServiceClient_SharedKey();
            var queue = service.GetQueueClient(queueName);

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

        [TestMethod]
        public async Task CreateAsync_WithOauth()
        {
            // Arrange
            var queueName = TestHelper.GetNewQueueName();
            var service = await TestHelper.GetServiceClient_OauthAccount();
            var queue = service.GetQueueClient(queueName);

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

        [TestMethod]
        public async Task CreateAsync_WithAccountSas()
        {
            // Arrange
            var queueName = TestHelper.GetNewQueueName();
            var service = TestHelper.GetServiceClient_AccountSas();
            var queue = service.GetQueueClient(queueName);

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

        [TestMethod]
        public async Task CreateAsync_WithQueueServiceSas()
        {
            // Arrange
            var queueName = TestHelper.GetNewQueueName();
            var service = TestHelper.GetServiceClient_QueueServiceSas(queueName);
            var queue = service.GetQueueClient(queueName);
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

        [TestMethod]
        public async Task CreateAsync_Error()
        {
            // Arrange
            var queueName = TestHelper.GetNewQueueName();
            var service = TestHelper.GetServiceClient_SharedKey();
            var queue = service.GetQueueClient(queueName);
            await queue.CreateAsync();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                queue.CreateAsync(metadata: new Dictionary<string, string> { { "key", "value" } }),
                actualException => Assert.AreEqual("QueueAlreadyExists", actualException.ErrorCode));
        }


        [TestMethod]
        public async Task GetPropertiesAsync()
        {
            // Arrange
            using (TestHelper.GetNewQueue(out var queue))
            {
                // Act
                var queueProperties = await queue.GetPropertiesAsync();

                // Assert
                Assert.IsNotNull(queueProperties);
            }
        }

        [TestMethod]
        public async Task GetPropertiesAsync_Error()
        {
            // Arrange
            var queueName = TestHelper.GetNewQueueName();
            var service = TestHelper.GetServiceClient_SharedKey();
            var queue = service.GetQueueClient(queueName);

            // Act
            await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                queue.GetPropertiesAsync(),
                actualException => Assert.AreEqual("QueueNotFound", actualException.ErrorCode));
        }

        [TestMethod]
        public async Task SetMetadataAsync_OnCreate()
        {
            // Arrange
            var metadata = TestHelper.BuildMetadata();
            using (TestHelper.GetNewQueue(out var queue, metadata: metadata))
            {
                // Assert
                var result = await queue.GetPropertiesAsync();
                Assert.AreEqual("bar", result.Value.Metadata["foo"]);
                Assert.AreEqual("data", result.Value.Metadata["meta"]);
            }
        }

        [TestMethod]
        public async Task SetMetadataAsync_Metadata()
        {
            // Arrange
            using (TestHelper.GetNewQueue(out var queue))
            {
                // Act
                var metadata = TestHelper.BuildMetadata();
                await queue.SetMetadataAsync(metadata);

                // Assert
                var result = await queue.GetPropertiesAsync();
                Assert.AreEqual("bar", result.Value.Metadata["foo"]);
                Assert.AreEqual("data", result.Value.Metadata["meta"]);
            }
        }

        // Note that this test intentionally does not call queue.CreateAsync()
        [TestMethod]
        public async Task SetMetadataAsync_Error()
        {
            // Arrange
            var queueName = TestHelper.GetNewQueueName();
            var service = TestHelper.GetServiceClient_SharedKey();
            var queue = service.GetQueueClient(queueName);
            var metadata = TestHelper.BuildMetadata();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                queue.SetMetadataAsync(metadata),
                actualException => Assert.AreEqual("QueueNotFound", actualException.ErrorCode));
        }

        [TestMethod]
        public async Task GetAccessPolicyAsync()
        {
            // Arrange
            using (TestHelper.GetNewQueue(out var queue))
            {
                var signedIdentifiers = TestHelper.BuildSignedIdentifiers();

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
        [TestMethod]
        public async Task GetAccessPolicyAsync_Error()
        {
            // Arrange
            var queueName = TestHelper.GetNewQueueName();
            var service = TestHelper.GetServiceClient_SharedKey();
            var queue = service.GetQueueClient(queueName);

            // Act
            await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                queue.GetAccessPolicyAsync(),
                actualException => Assert.AreEqual("QueueNotFound", actualException.ErrorCode));
        }

        [TestMethod]
        public async Task SetAccessPolicyAsync()
        {
            using (TestHelper.GetNewQueue(out var queue))
            {
                var signedIdentifiers = TestHelper.BuildSignedIdentifiers();
                var result = await queue.SetAccessPolicyAsync(signedIdentifiers);
                Assert.IsFalse(String.IsNullOrWhiteSpace(result.Headers.RequestId));
            }
        }

        // Note that this test intentionally does not call queue.CreateAsync()
        [TestMethod]
        public async Task SetAccessPolicyAsync_Error()
        {
            // Arrange
            var queueName = TestHelper.GetNewQueueName();
            var service = TestHelper.GetServiceClient_SharedKey();
            var queue = service.GetQueueClient(queueName);
            var signedIdentifiers = TestHelper.BuildSignedIdentifiers();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                queue.SetAccessPolicyAsync(signedIdentifiers),
                actualException => Assert.AreEqual("QueueNotFound", actualException.ErrorCode));
        }

        [TestMethod]
        public async Task DeleteAsync()
        {
            // Arrange
            var queueName = TestHelper.GetNewQueueName();
            var service = TestHelper.GetServiceClient_SharedKey();
            var queue = service.GetQueueClient(queueName);
            await queue.CreateAsync();

            // Act
            var result = await queue.DeleteAsync();

            // Assert
            Assert.AreNotEqual(default, result.Headers.RequestId, $"{nameof(result)} may not be populated");
        }

        // Note that this test intentionally does not call queue.CreateAsync()
        [TestMethod]
        public async Task DeleteAsync_Error()
        {
            // Arrange
            var queueName = TestHelper.GetNewQueueName();
            var service = TestHelper.GetServiceClient_SharedKey();
            var queue = service.GetQueueClient(queueName);

            // Act
            await TestHelper.AssertExpectedExceptionAsync<StorageRequestFailedException>(
                queue.DeleteAsync(),
                actualException => Assert.AreEqual("QueueNotFound", actualException.ErrorCode));
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Storage.Test;
using Azure.Storage.Queues.Models;
using Azure.Storage.Queues.Tests;
using NUnit.Framework;
using Azure.Core;
using Azure.Storage.Sas;
using Azure.Core.TestFramework;
using System.Buffers.Text;
using System.Text;

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

            var connectionString = new StorageConnectionString(credentials, (default, default), (queueEndpoint, queueSecondaryEndpoint), (default, default));

            var queueName = GetNewQueueName();

            QueueClient client1 = InstrumentClient(new QueueClient(connectionString.ToString(true), queueName, GetOptions()));

            QueueClient client2 = InstrumentClient(new QueueClient(connectionString.ToString(true), queueName));

            var builder1 = new QueueUriBuilder(client1.Uri);
            var builder2 = new QueueUriBuilder(client2.Uri);

            Assert.AreEqual(queueName, builder1.QueueName);
            Assert.AreEqual(queueName, builder2.QueueName);

            //Assert.AreEqual("accountName", builder.AccountName);
        }

        [Test]
        public async Task Ctor_ConnectionString_Sas()
        {
            // Arrange
            SharedAccessSignatureCredentials sasCred = GetAccountSasCredentials(
                AccountSasServices.All,
                AccountSasResourceTypes.All,
                AccountSasPermissions.All);

            StorageConnectionString conn1 = GetConnectionString(
                credentials: sasCred,
                includeEndpoint: true);

            QueueClient queueClient1 = GetClient(conn1.ToString(exportSecrets: true));

            // Also test with a connection string not containing the blob endpoint.
            // This should still work provided account name and Sas credential are present.
            StorageConnectionString conn2 = GetConnectionString(
                credentials: sasCred,
                includeEndpoint: false);

            QueueClient queueClient2 = GetClient(conn2.ToString(exportSecrets: true));

            QueueClient GetClient(string connectionString) =>
                InstrumentClient(
                    new QueueClient(
                        connectionString,
                        GetNewQueueName(),
                        GetOptions()));

            try
            {
                // Act
                await queueClient1.CreateIfNotExistsAsync();
                await queueClient2.CreateIfNotExistsAsync();

                var data = GetRandomBuffer(Constants.KB);

                Response<QueueProperties> prop1 = await queueClient1.GetPropertiesAsync();
                Response<QueueProperties> prop2 = await queueClient2.GetPropertiesAsync();

                // Assert
                Assert.IsNotNull(prop1.Value.Metadata);
                Assert.IsNotNull(prop2.Value.Metadata);
            }
            finally
            {
                // Clean up
                await queueClient1.DeleteIfExistsAsync();
                await queueClient2.DeleteIfExistsAsync();
            }
        }

        [Test]
        public void Ctor_Uri()
        {
            var accountName = "accountName";
            var accountKey = Convert.ToBase64String(new byte[] { 0, 1, 2, 3, 4, 5 });
            var queueEndpoint = new Uri("http://127.0.0.1/" + accountName);
            var credentials = new StorageSharedKeyCredential(accountName, accountKey);

            QueueClient queue = InstrumentClient(new QueueClient(queueEndpoint, credentials));
            var builder = new QueueUriBuilder(queue.Uri);

            Assert.AreEqual(accountName, builder.AccountName);
        }

        [Test]
        public void Ctor_TokenCredential_Http()
        {
            // Arrange
            TokenCredential tokenCredential = GetOAuthCredential(TestConfigHierarchicalNamespace);
            Uri uri = new Uri(TestConfigPremiumBlob.BlobServiceEndpoint).ToHttp();

            // Act
            TestHelper.AssertExpectedException(
                () => new QueueClient(uri, tokenCredential),
                new ArgumentException("Cannot use TokenCredential without HTTPS."));
        }

        [Test]
        public async Task Ctor_AzureSasCredential()
        {
            // Arrange
            string sas = GetNewAccountSasCredentials().ToString();
            await using DisposingQueue test = await GetTestQueueAsync();
            Uri uri = test.Queue.Uri;

            // Act
            var sasClient = InstrumentClient(new QueueClient(uri, new AzureSasCredential(sas), GetOptions()));
            QueueProperties properties = await sasClient.GetPropertiesAsync();

            // Assert
            Assert.IsNotNull(properties);
        }

        [Test]
        public async Task Ctor_AzureSasCredential_VerifyNoSasInUri()
        {
            // Arrange
            string sas = GetNewAccountSasCredentials().ToString();
            await using DisposingQueue test = await GetTestQueueAsync();
            Uri uri = test.Queue.Uri;
            uri = new Uri(uri.ToString() + "?" + sas);

            // Act
            TestHelper.AssertExpectedException<ArgumentException>(
                () => new QueueClient(uri, new AzureSasCredential(sas)),
                e => e.Message.Contains($"You cannot use {nameof(AzureSasCredential)} when the resource URI also contains a Shared Access Signature"));
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
                await queue.DeleteIfExistsAsync();
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
                QueueClient queue = result.Value;
                Response<QueueProperties> properties = await queue.GetPropertiesAsync();
                Assert.AreEqual(0, properties.Value.ApproximateMessagesCount);
                var accountName = new QueueUriBuilder(service.Uri).AccountName;
                TestHelper.AssertCacheableProperty(accountName, () => queue.AccountName);
                TestHelper.AssertCacheableProperty(name, () => queue.Name);
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
                await queue.DeleteIfExistsAsync();
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
                await queue.DeleteIfExistsAsync();
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
            catch (RequestFailedException ex) when (ex.ErrorCode == "AuthorizationFailure") // TODO verify if this is a missing service code
            {
                pass = true;
            }
            finally
            {
                if (!pass)
                {
                    await queue.DeleteIfExistsAsync();
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
            await queue.CreateIfNotExistsAsync();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                queue.CreateAsync(metadata: new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase) { { "key", "value" } }),
                actualException => Assert.AreEqual("QueueAlreadyExists", actualException.ErrorCode));
        }

        [Test]
        public async Task CreateIfNotExistsAsync_NotExists()
        {
            // Arrange
            var queueName = GetNewQueueName();
            QueueServiceClient service = GetServiceClient_SharedKey();
            QueueClient queue = InstrumentClient(service.GetQueueClient(queueName));

            // Act
            Response response = await queue.CreateIfNotExistsAsync();

            // Assert
            Assert.IsNotNull(response);

            // Cleanup
            await queue.DeleteIfExistsAsync();
        }

        [Test]
        public async Task CreateIfNotExistsAsync_Exists()
        {
            // Arrange
            var queueName = GetNewQueueName();
            QueueServiceClient service = GetServiceClient_SharedKey();
            QueueClient queue = InstrumentClient(service.GetQueueClient(queueName));
            await queue.CreateIfNotExistsAsync();

            // Act
            Response response = await queue.CreateIfNotExistsAsync();

            // Assert
            Assert.IsNull(response);

            // Cleanup
            await queue.DeleteIfExistsAsync();
        }

        [Test]
        public async Task CreateIfNotExistsAsync_ExistsDifferentMetadata()
        {
            // Arrange
            var queueName = GetNewQueueName();
            QueueServiceClient service = GetServiceClient_SharedKey();
            QueueClient queue = InstrumentClient(service.GetQueueClient(queueName));

            await queue.CreateIfNotExistsAsync(BuildMetadata());

            // Act
            Response response = await queue.CreateIfNotExistsAsync();

            // Assert
            Assert.IsNull(response);

            // Cleanup
            await queue.DeleteIfExistsAsync();
        }

        [Test]
        public async Task CreateIfNotExistsAsync_Error()
        {
            // Arrange
            var queueName = GetNewQueueName();
            QueueServiceClient service = GetServiceClient_SharedKey();
            QueueClient queue = InstrumentClient(service.GetQueueClient(queueName));
            QueueClient unauthorizedQueueClient = InstrumentClient(new QueueClient(queue.Uri, GetOptions()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                unauthorizedQueueClient.CreateIfNotExistsAsync(),
                e => Assert.AreEqual("ResourceNotFound", e.ErrorCode));
        }

        [Test]
        public async Task ExistsAsync_Exists()
        {
            // Arrange
            var queueName = GetNewQueueName();
            QueueServiceClient service = GetServiceClient_SharedKey();
            QueueClient queue = InstrumentClient(service.GetQueueClient(queueName));
            await queue.CreateIfNotExistsAsync();

            // Act
            Response<bool> response = await queue.ExistsAsync();

            // Assert
            Assert.IsTrue(response.Value);

            // Cleanup
            await queue.DeleteIfExistsAsync();
        }

        [Test]
        public async Task ExistsAsync_NotExists()
        {
            // Arrange
            var queueName = GetNewQueueName();
            QueueServiceClient service = GetServiceClient_SharedKey();
            QueueClient queue = InstrumentClient(service.GetQueueClient(queueName));

            // Act
            Response<bool> response = await queue.ExistsAsync();

            // Assert
            Assert.IsFalse(response.Value);
        }

        [Test]
        public async Task ExistsAsync_Error()
        {
            // Arrange
            var queueName = GetNewQueueName();
            QueueServiceClient service = GetServiceClient_SharedKey();
            QueueClient queue = InstrumentClient(service.GetQueueClient(queueName));
            QueueClient unauthorizedQueueClient = InstrumentClient(new QueueClient(queue.Uri, GetOptions()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                unauthorizedQueueClient.ExistsAsync(),
                e => Assert.AreEqual("ResourceNotFound", e.ErrorCode));
        }

        [Test]
        public async Task DeleteIfExistsAsync_Exists()
        {
            // Arrange
            var queueName = GetNewQueueName();
            QueueServiceClient service = GetServiceClient_SharedKey();
            QueueClient queue = InstrumentClient(service.GetQueueClient(queueName));
            await queue.CreateIfNotExistsAsync();

            // Act
            Response<bool> response = await queue.DeleteIfExistsAsync();

            // Assert
            Assert.IsTrue(response.Value);
        }

        [Test]
        public async Task DeleteIfExistsAsync_NotExists()
        {
            // Arrange
            var queueName = GetNewQueueName();
            QueueServiceClient service = GetServiceClient_SharedKey();
            QueueClient queue = InstrumentClient(service.GetQueueClient(queueName));

            // Act
            Response<bool> response = await queue.DeleteIfExistsAsync();

            // Assert
            Assert.IsFalse(response.Value);
        }

        [Test]
        public async Task DeleteIfExistsAsync_Error()
        {
            // Arrange
            var queueName = GetNewQueueName();
            QueueServiceClient service = GetServiceClient_SharedKey();
            QueueClient queue = InstrumentClient(service.GetQueueClient(queueName));
            QueueClient unauthorizedQueueClient = InstrumentClient(new QueueClient(queue.Uri, GetOptions()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                unauthorizedQueueClient.DeleteIfExistsAsync(),
                e => Assert.AreEqual("ResourceNotFound", e.ErrorCode));
        }

        [Test]
        public async Task GetPropertiesAsync()
        {
            // Arrange
            await using DisposingQueue test = await GetTestQueueAsync();

            // Act
            Response<Models.QueueProperties> queueProperties = await test.Queue.GetPropertiesAsync();

            // Assert
            Assert.IsNotNull(queueProperties);
        }

        [Test]
        public async Task GetPropertiesAsync_Error()
        {
            // Arrange
            var queueName = GetNewQueueName();
            QueueServiceClient service = GetServiceClient_SharedKey();
            QueueClient queue = InstrumentClient(service.GetQueueClient(queueName));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                queue.GetPropertiesAsync(),
                actualException => Assert.AreEqual("QueueNotFound", actualException.ErrorCode));
        }

        #region Secondary Storage

        [Test]
        public async Task GetPropertiesAsync_SecondaryStorage()
        {
            QueueClient queueClient = GetQueueClient_SecondaryAccount_ReadEnabledOnRetry(1, out TestExceptionPolicy testExceptionPolicy);
            await queueClient.CreateIfNotExistsAsync();
            Response<QueueProperties> properties = await EnsurePropagatedAsync(
                async () => await queueClient.GetPropertiesAsync(),
                properties => properties.GetRawResponse().Status != 404);

            Assert.IsNotNull(properties);
            Assert.AreEqual(200, properties.GetRawResponse().Status);

            await queueClient.DeleteIfExistsAsync();
            AssertSecondaryStorageFirstRetrySuccessful(SecondaryStorageTenantPrimaryHost(), SecondaryStorageTenantSecondaryHost(), testExceptionPolicy);
        }
        #endregion

        [Test]
        public async Task SetMetadataAsync_OnCreate()
        {
            // Arrange
            IDictionary<string, string> metadata = BuildMetadata();
            await using DisposingQueue test = await GetTestQueueAsync(metadata: metadata);

            // Assert
            Response<Models.QueueProperties> result = await test.Queue.GetPropertiesAsync();
            Assert.AreEqual("bar", result.Value.Metadata["foo"]);
            Assert.AreEqual("data", result.Value.Metadata["meta"]);
        }

        [Test]
        public async Task SetMetadataAsync_Metadata()
        {
            // Arrange
            await using DisposingQueue test = await GetTestQueueAsync();

            // Act
            IDictionary<string, string> metadata = BuildMetadata();
            await test.Queue.SetMetadataAsync(metadata);

            // Assert
            Response<Models.QueueProperties> result = await test.Queue.GetPropertiesAsync();
            Assert.AreEqual("bar", result.Value.Metadata["foo"]);
            Assert.AreEqual("data", result.Value.Metadata["meta"]);
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
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                queue.SetMetadataAsync(metadata),
                actualException => Assert.AreEqual("QueueNotFound", actualException.ErrorCode));
        }

        [Test]
        public async Task GetAccessPolicyAsync()
        {
            // Arrange
            await using DisposingQueue test = await GetTestQueueAsync();

            QueueSignedIdentifier[] signedIdentifiers = BuildSignedIdentifiers();

            // Act
            Response setResult = await test.Queue.SetAccessPolicyAsync(signedIdentifiers);

            // Assert
            Response<IEnumerable<Models.QueueSignedIdentifier>> result = await test.Queue.GetAccessPolicyAsync();
            Models.QueueSignedIdentifier acl = result.Value.First();

            Assert.AreEqual(1, result.Value.Count());
            Assert.AreEqual(signedIdentifiers[0].Id, acl.Id);
            Assert.AreEqual(signedIdentifiers[0].AccessPolicy.StartsOn, acl.AccessPolicy.StartsOn);
            Assert.AreEqual(signedIdentifiers[0].AccessPolicy.ExpiresOn, acl.AccessPolicy.ExpiresOn);
            Assert.AreEqual(signedIdentifiers[0].AccessPolicy.Permissions, acl.AccessPolicy.Permissions);
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
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                queue.GetAccessPolicyAsync(),
                actualException => Assert.AreEqual("QueueNotFound", actualException.ErrorCode));
        }

        [Test]
        public async Task SetAccessPolicyAsync()
        {
            await using DisposingQueue test = await GetTestQueueAsync();

            Models.QueueSignedIdentifier[] signedIdentifiers = BuildSignedIdentifiers();
            Response result = await test.Queue.SetAccessPolicyAsync(signedIdentifiers);
            Assert.IsFalse(string.IsNullOrWhiteSpace(result.Headers.RequestId));
        }

        // Note that this test intentionally does not call queue.CreateAsync()
        [Test]
        public async Task SetAccessPolicyAsync_Error()
        {
            // Arrange
            var queueName = GetNewQueueName();
            QueueServiceClient service = GetServiceClient_SharedKey();
            QueueClient queue = InstrumentClient(service.GetQueueClient(queueName));
            Models.QueueSignedIdentifier[] signedIdentifiers = BuildSignedIdentifiers();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
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
            await queue.CreateIfNotExistsAsync();

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
                Assert.ThrowsAsync<RequestFailedException>(
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
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                queue.DeleteAsync(),
                actualException => Assert.AreEqual("QueueNotFound", actualException.ErrorCode));
        }

        [Test]
        public async Task SendMessageAsync()
        {
            // Arrange
            await using DisposingQueue test = await GetTestQueueAsync();

            // Act
            Response<Models.SendReceipt> response = await test.Queue.SendMessageAsync(
                messageText: GetNewString(),
                visibilityTimeout: new TimeSpan(0, 0, 1),
                timeToLive: new TimeSpan(1, 0, 0));

            // Assert
            Assert.NotNull(response.Value);
        }

        [Test]
        public async Task SendReceiveNullMessageAsync()
        {
            // Arrange
            await using DisposingQueue test = await GetTestQueueAsync();

            // Act
            Response<Models.SendReceipt> response = await test.Queue.SendMessageAsync(messageText: null);

            // Assert
            Assert.NotNull(response.Value);

            // Act
            QueueMessage receivedMessage = (await test.Queue.ReceiveMessagesAsync()).Value.First();

            Assert.AreEqual(string.Empty, receivedMessage.MessageText);
        }

        [Test]
        public async Task EncodesOutgoingMessage()
        {
            // Arrange
            await using DisposingQueue test = await GetTestQueueAsync();
            var encodingClient = GetEncodingClient(test.Queue.Name, QueueMessageEncoding.Base64);
            var messageText = GetNewString();
            var encodedText = Convert.ToBase64String(Encoding.UTF8.GetBytes(messageText));

            // Act
            Response<Models.SendReceipt> response = await encodingClient.SendMessageAsync(messageText: messageText);

            // Assert
            Assert.NotNull(response.Value);

            // Act
            QueueMessage receivedMessage = (await test.Queue.ReceiveMessagesAsync()).Value.First();

            Assert.AreEqual(encodedText, receivedMessage.MessageText);
        }

        [Test]
        public async Task EncodesOutgoingMessageAndRespectsSegmentBoundaries()
        {
            // Arrange
            await using DisposingQueue test = await GetTestQueueAsync();
            var encodingClient = GetEncodingClient(test.Queue.Name, QueueMessageEncoding.Base64);
            var payload = "pre payload post";
            var bytes = Encoding.UTF8.GetBytes(payload);
            var segment = new ArraySegment<byte>(bytes, 4, 7);
            var data = BinaryData.FromBytes(segment);

            // Act
            Response<Models.SendReceipt> response = await encodingClient.SendMessageAsync(data);

            // Assert
            Assert.NotNull(response.Value);

            // Act
            QueueMessage receivedMessage = (await encodingClient.ReceiveMessagesAsync()).Value.First();

            Assert.AreEqual("payload", receivedMessage.Body.ToString());
        }

        [Test]
        public async Task DecodesReceivedMessage()
        {
            // Arrange
            await using DisposingQueue test = await GetTestQueueAsync();
            var encodingClient = GetEncodingClient(test.Queue.Name, QueueMessageEncoding.Base64);
            var messageText = GetNewString();
            var encodedText = Convert.ToBase64String(Encoding.UTF8.GetBytes(messageText));
            // Act
            Response<Models.SendReceipt> response = await test.Queue.SendMessageAsync(messageText: encodedText);

            // Assert
            Assert.NotNull(response.Value);

            // Act
            QueueMessage receivedMessage = (await encodingClient.ReceiveMessagesAsync()).Value.First();

            // Assert
            Assert.AreEqual(messageText, receivedMessage.MessageText);
        }

        [Test]
        public async Task DecodesPeekedMessage()
        {
            // Arrange
            await using DisposingQueue test = await GetTestQueueAsync();
            var encodingClient = GetEncodingClient(test.Queue.Name, QueueMessageEncoding.Base64);
            var messageText = GetNewString();
            var encodedText = Convert.ToBase64String(Encoding.UTF8.GetBytes(messageText));
            // Act
            Response<Models.SendReceipt> response = await test.Queue.SendMessageAsync(messageText: encodedText);

            // Assert
            Assert.NotNull(response.Value);

            // Act
            PeekedMessage receivedMessage = (await encodingClient.PeekMessagesAsync()).Value.First();

            // Assert
            Assert.AreEqual(messageText, receivedMessage.MessageText);
        }

        [Test]
        public async Task CanSendAndReceiveNonUTFBytes()
        {
            // Arrange
            await using DisposingQueue test = await GetTestQueueAsync();
            var encodingClient = GetEncodingClient(test.Queue.Name, QueueMessageEncoding.Base64);
            byte[] content = new byte[] { 0xFF, 0x00 }; // Not a valid UTF-8 byte sequence.

            // Act
            Response<Models.SendReceipt> response = await encodingClient.SendMessageAsync(message: BinaryData.FromBytes(content));

            // Assert
            Assert.NotNull(response.Value);

            // Act
            QueueMessage receivedMessage = (await encodingClient.ReceiveMessagesAsync()).Value.First();

            // Assert
            CollectionAssert.AreEqual(content, receivedMessage.Body.ToArray());
        }

        [Test]
        public async Task SendMessageAsync_SAS()
        {
            // Arrange
            await using DisposingQueue test = await GetTestQueueAsync();

            QueueSasBuilder sasBuilder = new QueueSasBuilder
            {
                QueueName = test.Queue.Name,
                StartsOn = Recording.UtcNow.AddHours(-1),
                ExpiresOn = Recording.UtcNow.AddHours(1)
            };
            sasBuilder.SetPermissions("a");
            SasQueryParameters sasQueryParameters = sasBuilder.ToSasQueryParameters(GetNewSharedKeyCredentials());

            QueueUriBuilder uriBuilder = new QueueUriBuilder(test.Queue.Uri)
            {
                Sas = sasQueryParameters
            };

            QueueClient queueClient = InstrumentClient(new QueueClient(
                uriBuilder.ToUri(),
                GetOptions()));

            // Act
            Response<SendReceipt> response = await queueClient.SendMessageAsync(
                messageText: GetNewString(),
                visibilityTimeout: new TimeSpan(0, 0, 1),
                timeToLive: new TimeSpan(1, 0, 0));

            // Assert
            Assert.NotNull(response.Value);
        }

        [Test]
        public async Task SendMessageAsync_SasWithIdentifier()
        {
            // Arrange
            string signedIdentifierId = GetNewString();
            await using DisposingQueue test = await GetTestQueueAsync();

            QueueSignedIdentifier signedIdentifier = new QueueSignedIdentifier
            {
                Id = signedIdentifierId,
                AccessPolicy = new QueueAccessPolicy
                {
                    StartsOn = Recording.UtcNow.AddHours(-1),
                    ExpiresOn = Recording.UtcNow.AddHours(1),
                    Permissions = "a"
                }
            };
            await test.Queue.SetAccessPolicyAsync(permissions: new QueueSignedIdentifier[] { signedIdentifier });

            QueueSasBuilder sasBuilder = new QueueSasBuilder
            {
                QueueName = test.Queue.Name,
                Identifier = signedIdentifierId
            };

            SasQueryParameters sasQueryParameters = sasBuilder.ToSasQueryParameters(GetNewSharedKeyCredentials());

            QueueUriBuilder uriBuilder = new QueueUriBuilder(test.Queue.Uri)
            {
                Sas = sasQueryParameters
            };

            QueueClient queueClient = InstrumentClient(new QueueClient(
                uriBuilder.ToUri(),
                GetOptions()));

            // Act
            Response<SendReceipt> response = await queueClient.SendMessageAsync(
                messageText: GetNewString(),
                visibilityTimeout: new TimeSpan(0, 0, 1),
                timeToLive: new TimeSpan(1, 0, 0));

            // Assert
            Assert.NotNull(response.Value);
        }

        [Test]
        public async Task SendMessageAsync_Min()
        {
            // Arrange
            await using DisposingQueue test = await GetTestQueueAsync();

            // Act
            Response<Models.SendReceipt> response = await test.Queue.SendMessageAsync(string.Empty);

            // Assert
            Assert.NotNull(response.Value);
        }

        [Test]
        public async Task SendMessageAsync_ExtendedExceptionMessage()
        {
            // Arrange
            await using DisposingQueue test = await GetTestQueueAsync();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                test.Queue.SendMessageAsync(
                    messageText: string.Empty,
                    visibilityTimeout: TimeSpan.FromSeconds(10),
                    timeToLive: TimeSpan.FromSeconds(7)),
                e =>
                {
                    Assert.AreEqual(QueueErrorCode.InvalidQueryParameterValue.ToString(), e.ErrorCode);
                    Assert.IsTrue(e.Message.Contains($"Additional Information:{Environment.NewLine}QueryParameterName: visibilitytimeout{Environment.NewLine}QueryParameterValue: 10{Environment.NewLine}Reason: messagettl must be greater than visibilitytimeout"));
                });
        }

        // Note that this test intentionally does not call queue.CreateAsync()
        [Test]
        public async Task SendMessageAsync_Error()
        {
            // Arrange
            var queueName = GetNewQueueName();
            QueueServiceClient service = GetServiceClient_SharedKey();
            QueueClient queue = InstrumentClient(service.GetQueueClient(queueName));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                queue.SendMessageAsync(string.Empty),
                actualException => Assert.AreEqual("QueueNotFound", actualException.ErrorCode));
        }

        [Test]
        public async Task ReceiveMessagesAsync()
        {
            // Arrange
            await using DisposingQueue test = await GetTestQueueAsync();

            await test.Queue.SendMessageAsync(GetNewString());
            await test.Queue.SendMessageAsync(GetNewString());
            await test.Queue.SendMessageAsync(GetNewString());

            // Act
            Response<Models.QueueMessage[]> response = await test.Queue.ReceiveMessagesAsync(
                maxMessages: 2,
                visibilityTimeout: new TimeSpan(1, 0, 0));

            // Assert
            Assert.AreEqual(2, response.Value.Count());
        }

        [Test]
        public async Task ReceiveMessagesAsync_Min()
        {
            // Arrange
            await using DisposingQueue test = await GetTestQueueAsync();

            await test.Queue.SendMessageAsync(GetNewString());
            await test.Queue.SendMessageAsync(GetNewString());
            await test.Queue.SendMessageAsync(GetNewString());

            // Act
            Response<Models.QueueMessage[]> response = await test.Queue.ReceiveMessagesAsync();

            // Assert
            Assert.AreEqual(1, response.Value.Count());
        }

        // Note that this test intentionally does not call queue.CreateAsync()
        [Test]
        public async Task ReceiveMessagesAsync_Error()
        {
            // Arrange
            var queueName = GetNewQueueName();
            QueueServiceClient service = GetServiceClient_SharedKey();
            QueueClient queue = InstrumentClient(service.GetQueueClient(queueName));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                queue.ReceiveMessagesAsync(),
                actualException => Assert.AreEqual("QueueNotFound", actualException.ErrorCode));
        }

        [Test]
        public async Task ReceiveMessageAsync()
        {
            // Arrange
            await using DisposingQueue test = await GetTestQueueAsync();

            var messageText = GetNewString();
            await test.Queue.SendMessageAsync(messageText);

            // Act
            Response<Models.QueueMessage> response = await test.Queue.ReceiveMessageAsync(
                visibilityTimeout: new TimeSpan(1, 0, 0));

            // Assert
            Assert.AreEqual(messageText, response.Value.MessageText);
        }

        [Test]
        public async Task ReceiveMessageAsync_Min()
        {
            // Arrange
            await using DisposingQueue test = await GetTestQueueAsync();

            var messageText = GetNewString();
            await test.Queue.SendMessageAsync(messageText);

            // Act
            Response<Models.QueueMessage> response = await test.Queue.ReceiveMessageAsync();

            // Assert
            Assert.AreEqual(messageText, response.Value.MessageText);
        }

        [Test]
        public async Task ReceiveMessageAsync_EmptyQueue()
        {
            // Arrange
            await using DisposingQueue test = await GetTestQueueAsync();

            var messageText = GetNewString();

            // Act
            Response<Models.QueueMessage> response = await test.Queue.ReceiveMessageAsync();

            // Assert
            Assert.IsNull(response.Value);
        }

        [Test]
        public async Task ReceiveMessageAsync_EmptyQueue_With_ResponseCast()
        {
            // Arrange
            await using DisposingQueue test = await GetTestQueueAsync();

            var messageText = GetNewString();

            // Act
            Models.QueueMessage message = await test.Queue.ReceiveMessageAsync();

            // Assert
            Assert.IsNull(message);
        }

        // Note that this test intentionally does not call queue.CreateAsync()
        [Test]
        public async Task ReceiveMessageAsync_Error()
        {
            // Arrange
            var queueName = GetNewQueueName();
            QueueServiceClient service = GetServiceClient_SharedKey();
            QueueClient queue = InstrumentClient(service.GetQueueClient(queueName));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                queue.ReceiveMessagesAsync(),
                actualException => Assert.AreEqual("QueueNotFound", actualException.ErrorCode));
        }

        [Test]
        public async Task PeekMessagesAsync()
        {
            // Arrange
            await using DisposingQueue test = await GetTestQueueAsync();

            await test.Queue.SendMessageAsync(GetNewString());
            await test.Queue.SendMessageAsync(GetNewString());
            await test.Queue.SendMessageAsync(GetNewString());

            // Act
            Response<Models.PeekedMessage[]> response = await test.Queue.PeekMessagesAsync(maxMessages: 2);

            // Assert
            Assert.AreEqual(2, response.Value.Count());
        }

        [Test]
        public async Task PeekMessagesAsync_Min()
        {
            // Arrange
            await using DisposingQueue test = await GetTestQueueAsync();

            await test.Queue.SendMessageAsync(GetNewString());
            await test.Queue.SendMessageAsync(GetNewString());
            await test.Queue.SendMessageAsync(GetNewString());

            // Act
            Response<Models.PeekedMessage[]> response = await test.Queue.PeekMessagesAsync();

            // Assert
            Assert.AreEqual(1, response.Value.Count());
        }

        // Note that this test intentionally does not call queue.CreateAsync()
        [Test]
        public async Task PeekMessagesAsync_Error()
        {
            // Arrange
            var queueName = GetNewQueueName();
            QueueServiceClient service = GetServiceClient_SharedKey();
            QueueClient queue = InstrumentClient(service.GetQueueClient(queueName));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                queue.PeekMessagesAsync(),
                actualException => Assert.AreEqual("QueueNotFound", actualException.ErrorCode));
        }

        [Test]
        public async Task PeekMessageAsync()
        {
            // Arrange
            await using DisposingQueue test = await GetTestQueueAsync();

            var messageText = GetNewString();
            await test.Queue.SendMessageAsync(messageText);

            // Act
            Response<Models.PeekedMessage> response = await test.Queue.PeekMessageAsync();

            // Assert
            Assert.AreEqual(messageText, response.Value.MessageText);
        }

        // Note that this test intentionally does not call queue.CreateAsync()
        [Test]
        public async Task PeekMessageAsync_Error()
        {
            // Arrange
            var queueName = GetNewQueueName();
            QueueServiceClient service = GetServiceClient_SharedKey();
            QueueClient queue = InstrumentClient(service.GetQueueClient(queueName));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                queue.PeekMessageAsync(),
                actualException => Assert.AreEqual("QueueNotFound", actualException.ErrorCode));
        }

        [Test]
        public async Task PeekMessageAsync_EmptyQueue()
        {
            // Arrange
            await using DisposingQueue test = await GetTestQueueAsync();

            // Act
            Response<Models.PeekedMessage> response = await test.Queue.PeekMessageAsync();

            // Assert
            Assert.IsNull(response.Value);
        }

        [Test]
        public async Task PeekMessageAsync_EmptyQueue_WithResponseCast()
        {
            // Arrange
            await using DisposingQueue test = await GetTestQueueAsync();

            // Act
            Models.PeekedMessage message = await test.Queue.PeekMessageAsync();

            // Assert
            Assert.IsNull(message);
        }

        [Test]
        public async Task ClearMessagesAsync()
        {
            // Arrange
            await using DisposingQueue test = await GetTestQueueAsync();

            await test.Queue.SendMessageAsync(GetNewString());
            await test.Queue.SendMessageAsync(GetNewString());
            await test.Queue.SendMessageAsync(GetNewString());

            // Act
            Response response = await test.Queue.ClearMessagesAsync();

            // Assert
            Assert.IsNotNull(response.Headers.RequestId);
        }

        // Note that this test intentionally does not call queue.CreateAsync()
        [Test]
        public async Task ClearMessagesAsync_Error()
        {
            // Arrange
            var queueName = GetNewQueueName();
            QueueServiceClient service = GetServiceClient_SharedKey();
            QueueClient queue = InstrumentClient(service.GetQueueClient(queueName));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                queue.ClearMessagesAsync(),
                actualException => Assert.AreEqual("QueueNotFound", actualException.ErrorCode));
        }

        [Test]
        public async Task DeleteMessageAsync()
        {
            // Arrange
            await using DisposingQueue test = await GetTestQueueAsync();
            Models.SendReceipt enqueuedMessage = (await test.Queue.SendMessageAsync(string.Empty)).Value;

            // Act
            Response result = await test.Queue.DeleteMessageAsync(enqueuedMessage.MessageId, enqueuedMessage.PopReceipt);

            // Assert
            Assert.IsNotNull(result.Headers.RequestId);
        }

        [Test]
        public async Task DeleteMessagAsync_Error()
        {
            // Arrange
            await using DisposingQueue test = await GetTestQueueAsync();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                test.Queue.DeleteMessageAsync(GetNewMessageId(), GetNewString()),
                actualException => Assert.AreEqual("MessageNotFound", actualException.ErrorCode));
        }

        [Test]
        public async Task DeleteMessageAsync_DeletePeek()
        {
            // Arrange
            await using DisposingQueue test = await GetTestQueueAsync();
            Models.SendReceipt enqueuedMessage = (await test.Queue.SendMessageAsync(string.Empty)).Value;

            // Act
            Response result = await test.Queue.DeleteMessageAsync(enqueuedMessage.MessageId, enqueuedMessage.PopReceipt);

            // Assert
            await test.Queue.PeekMessagesAsync();
            Assert.IsNotNull(result.Headers.RequestId);
        }

        [Test]
        public async Task UpdateMessageAsync_Update()
        {
            // Arrange
            await using DisposingQueue test = await GetTestQueueAsync();

            var message0 = "foo";
            var message1 = "bar";
            Models.SendReceipt enqueuedMessage = (await test.Queue.SendMessageAsync(message0)).Value;

            // Act
            Response<Models.UpdateReceipt> result = await test.Queue.UpdateMessageAsync(
                enqueuedMessage.MessageId,
                enqueuedMessage.PopReceipt,
                message1,
                new TimeSpan(100));

            // Assert
            Assert.IsNotNull(result.GetRawResponse().Headers.RequestId);
        }

        [Test]
        public async Task UpdateMessageAsync_Min()
        {
            // Arrange
            await using DisposingQueue test = await GetTestQueueAsync();

            var message0 = "foo";
            var message1 = "bar";
            Models.SendReceipt enqueuedMessage = (await test.Queue.SendMessageAsync(message0)).Value;

            // Act
            Response<Models.UpdateReceipt> result = await test.Queue.UpdateMessageAsync(
                enqueuedMessage.MessageId,
                enqueuedMessage.PopReceipt,
                message1);

            // Assert
            Assert.IsNotNull(result.GetRawResponse().Headers.RequestId);
        }

        [Test]
        public async Task UpdateMessageAsync_UpdateDequeuedMessage()
        {
            await using DisposingQueue test = await GetTestQueueAsync();

            var message0 = "foo";
            var message1 = "bar";

            await test.Queue.SendMessageAsync(message0);
            Models.QueueMessage message = (await test.Queue.ReceiveMessagesAsync(1)).Value.First();

            Response<Models.UpdateReceipt> update = await test.Queue.UpdateMessageAsync(
                message.MessageId,
                message.PopReceipt,
                message1);

            Assert.AreNotEqual(update.Value.PopReceipt, message.PopReceipt);
            Assert.AreNotEqual(update.Value.NextVisibleOn, message.NextVisibleOn);

            Models.QueueMessage newMessage = message.Update(update);
            Assert.AreEqual(message.MessageId, newMessage.MessageId);
            Assert.AreEqual(message.MessageText, newMessage.MessageText);
            Assert.AreEqual(message.InsertedOn, newMessage.InsertedOn);
            Assert.AreEqual(message.ExpiresOn, newMessage.ExpiresOn);
            Assert.AreEqual(message.DequeueCount, newMessage.DequeueCount);
            Assert.AreNotEqual(message.PopReceipt, newMessage.PopReceipt);
            Assert.AreNotEqual(message.NextVisibleOn, newMessage.NextVisibleOn);
            Assert.AreEqual(update.Value.PopReceipt, newMessage.PopReceipt);
            Assert.AreEqual(update.Value.NextVisibleOn, newMessage.NextVisibleOn);
        }

        [Test]
        public async Task UpdateMessageAsync_UpdatePeek()
        {
            // Arrange
            await using DisposingQueue test = await GetTestQueueAsync();

            var message0 = "foo";
            var message1 = "bar";
            Models.SendReceipt enqueuedMessage = (await test.Queue.SendMessageAsync(message0)).Value;

            // Act
            await test.Queue.UpdateMessageAsync(enqueuedMessage.MessageId, enqueuedMessage.PopReceipt, message1);

            // Assert
            Response<Models.PeekedMessage[]> peekedMessages = await test.Queue.PeekMessagesAsync(1);
            Models.PeekedMessage peekedMessage = peekedMessages.Value.First();

            Assert.AreEqual(1, peekedMessages.Value.Count());
            Assert.AreEqual(message1, peekedMessage.MessageText);
        }

        [Test]
        public async Task UpdateMessageAsync_Error()
        {
            // Arrange
            await using DisposingQueue test = await GetTestQueueAsync();

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                test.Queue.UpdateMessageAsync(GetNewMessageId(), GetNewString(), string.Empty),
                actualException => Assert.AreEqual("MessageNotFound", actualException.ErrorCode));
        }

        [Test]
        public async Task UpdateMessageAsync_UpdateVisibilityTimeoutOnlyPreservesContent()
        {
            // Arrange
            await using DisposingQueue test = await GetTestQueueAsync();

            var message = "foo";
            Models.SendReceipt enqueuedMessage = (await test.Queue.SendMessageAsync(message)).Value;

            // Act
            Response<Models.UpdateReceipt> result = await test.Queue.UpdateMessageAsync(
                enqueuedMessage.MessageId,
                enqueuedMessage.PopReceipt,
                visibilityTimeout: new TimeSpan(100));
            var receivedMessage = (await test.Queue.ReceiveMessagesAsync(1)).Value.First();

            // Assert
            Assert.AreEqual(enqueuedMessage.MessageId, receivedMessage.MessageId);
            Assert.AreEqual(message, receivedMessage.MessageText);
        }

        #region GenerateSasTests
        [Test]
        public void CanGenerateSas_ClientConstructors()
        {
            // Arrange
            var constants = new TestConstants(this);
            var blobEndpoint = new Uri("https://127.0.0.1/" + constants.Sas.Account);
            var blobSecondaryEndpoint = new Uri("https://127.0.0.1/" + constants.Sas.Account + "-secondary");
            var storageConnectionString = new StorageConnectionString(constants.Sas.SharedKeyCredential, queueStorageUri: (blobEndpoint, blobSecondaryEndpoint));
            string connectionString = storageConnectionString.ToString(true);

            // Act - QueueClient(string connectionString, string blobContainerName)
            QueueClient container = InstrumentClient(new QueueClient(
                connectionString,
                GetNewQueueName()));
            Assert.IsTrue(container.CanGenerateSasUri);

            // Act - QueueClient(string connectionString, string blobContainerName, BlobClientOptions options)
            QueueClient container2 = InstrumentClient(new QueueClient(
                connectionString,
                GetNewQueueName(),
                GetOptions()));
            Assert.IsTrue(container2.CanGenerateSasUri);

            // Act - QueueClient(Uri blobContainerUri, BlobClientOptions options = default)
            QueueClient container3 = InstrumentClient(new QueueClient(
                blobEndpoint,
                GetOptions()));
            Assert.IsFalse(container3.CanGenerateSasUri);

            // Act - QueueClient(Uri blobContainerUri, StorageSharedKeyCredential credential, BlobClientOptions options = default)
            QueueClient container4 = InstrumentClient(new QueueClient(
                blobEndpoint,
                constants.Sas.SharedKeyCredential,
                GetOptions()));
            Assert.IsTrue(container4.CanGenerateSasUri);
        }

        [Test]
        public void GenerateSas_RequiredParameters()
        {
            // Arrange
            var constants = new TestConstants(this);
            var blobEndpoint = new Uri("http://127.0.0.1/" + constants.Sas.Account);
            var blobSecondaryEndpoint = new Uri("http://127.0.0.1/" + constants.Sas.Account + "-secondary");
            var storageConnectionString = new StorageConnectionString(constants.Sas.SharedKeyCredential, queueStorageUri: (blobEndpoint, blobSecondaryEndpoint));
            string connectionString = storageConnectionString.ToString(true);
            string queueName = GetNewQueueName();
            QueueSasPermissions permissions = QueueSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            QueueClient queueClient = InstrumentClient(new QueueClient(connectionString, queueName, GetOptions()));

            // Act
            Uri sasUri =  queueClient.GenerateSasUri(permissions, expiresOn);

            // Assert
            QueueSasBuilder sasBuilder = new QueueSasBuilder(permissions, expiresOn)
            {
                QueueName = queueName
            };
            QueueUriBuilder expectedUri = new QueueUriBuilder(blobEndpoint)
            {
                QueueName = queueName,
                Sas = sasBuilder.ToSasQueryParameters(constants.Sas.SharedKeyCredential)
            };
            Assert.AreEqual(expectedUri.ToUri().ToString(), sasUri.ToString());
        }

        [Test]
        public void GenerateSas_Builder()
        {
            var constants = new TestConstants(this);
            var blobEndpoint = new Uri("http://127.0.0.1/" + constants.Sas.Account);
            var blobSecondaryEndpoint = new Uri("http://127.0.0.1/" + constants.Sas.Account + "-secondary");
            var storageConnectionString = new StorageConnectionString(constants.Sas.SharedKeyCredential, queueStorageUri: (blobEndpoint, blobSecondaryEndpoint));
            string connectionString = storageConnectionString.ToString(true);
            string queueName = GetNewQueueName();
            QueueSasPermissions permissions = QueueSasPermissions.Read;
            DateTimeOffset startsOn = Recording.UtcNow.AddHours(-1);
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            QueueClient queueClient = InstrumentClient(new QueueClient(connectionString, queueName, GetOptions()));

            QueueSasBuilder sasBuilder = new QueueSasBuilder(permissions, expiresOn)
            {
                QueueName = queueName,
                StartsOn = startsOn
            };

            // Act
            Uri sasUri = queueClient.GenerateSasUri(sasBuilder);

            // Assert
            QueueSasBuilder sasBuilder2 = new QueueSasBuilder(permissions, expiresOn)
            {
                QueueName = queueName,
                StartsOn = startsOn
            };
            QueueUriBuilder expectedUri = new QueueUriBuilder(blobEndpoint)
            {
                QueueName = queueName,
                Sas = sasBuilder2.ToSasQueryParameters(constants.Sas.SharedKeyCredential)
            };
            Assert.AreEqual(expectedUri.ToUri().ToString(), sasUri.ToString());
        }

        [Test]
        public void GenerateSas_BuilderWrongName()
        {
            // Arrange
            var constants = new TestConstants(this);
            var blobEndpoint = new Uri("http://127.0.0.1/");
            UriBuilder blobUriBuilder = new UriBuilder(blobEndpoint);
            blobUriBuilder.Path += constants.Sas.Account + "/" + GetNewQueueName();
            QueueSasPermissions permissions = QueueSasPermissions.Read;
            DateTimeOffset expiresOn = Recording.UtcNow.AddHours(+1);
            QueueClient queueClient = InstrumentClient(new QueueClient(
                blobUriBuilder.Uri,
                constants.Sas.SharedKeyCredential,
                GetOptions()));

            QueueSasBuilder sasBuilder = new QueueSasBuilder(permissions, expiresOn)
            {
                QueueName = GetNewQueueName() //different queueName
            };

            // Act
            try
            {
                queueClient.GenerateSasUri(sasBuilder);

                Assert.Fail("QueueClient.GenerateSasUri should have failed with an ArgumentException.");
            }
            catch (InvalidOperationException)
            {
                //the correct exception came back
            }
        }
        #endregion
    }
}

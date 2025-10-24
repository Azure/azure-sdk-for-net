// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Storage.Queues.Models;
using Azure.Storage.Queues.Specialized;
using Azure.Storage.Queues.Tests;
using Azure.Storage.Sas;
using Azure.Storage.Test;
using Azure.Storage.Test.Shared;
using NUnit.Framework;

namespace Azure.Storage.Queues.Test
{
    internal class QueueSasTests : QueueTestBase
    {
        public QueueSasTests(bool async, QueueClientOptions.ServiceVersion serviceVersion)
            : base(async, serviceVersion, null /* RecordedTestMode.Record /* to re-record */)
        {
        }

        /// <summary>
        /// Create ServiceClient with Custom Account SAS without invoking other clients
        /// </summary>
        private QueueServiceClient GetQueueServiceClientWithCustomAccountSas(
            string permissions = default,
            string services = default,
            string resourceType = default)
        {
            // Use UriBuilder over QueueUriBuilder to apply custom SAS, QueueUriBuilder requires SasQueryParameters
            UriBuilder uriBuilder = new UriBuilder(GetDefaultPrimaryEndpoint())
            {
                Query = GetCustomAccountSas(permissions, services, resourceType)
            };

            return InstrumentClient(new QueueServiceClient(uriBuilder.Uri, GetOptions()));
        }

        /// <summary>
        /// Create QueueClient with Custom Account SAS without invoking other clients
        /// </summary>
        private async Task<QueueClient> GetQueueClientWithCustomAccountSas(
            string queueName = default,
            string permissions = default,
            string services = default,
            string resourceType = default)
        {
            queueName = queueName ?? GetNewQueueName();
            // Use UriBuilder over QueueUriBuilder to apply custom SAS, QueueUriBuilder requires SasQueryParameters
            UriBuilder uriBuilder = new UriBuilder(GetDefaultPrimaryEndpoint())
            {
                Path = queueName,
                Query = GetCustomAccountSas(permissions, services, resourceType)
            };

            QueueClient queueClient = InstrumentClient(new QueueClient(uriBuilder.Uri, GetOptions()));
            await queueClient.CreateAsync();
            return queueClient;
        }

        private async Task InvokeAccountSasTest(
            string permissions = "rwdylacuptfi",
            string services = "bqtf",
            string resourceType = "sco")
        {
            // Arrange
            await using DisposingQueue test = await GetTestQueueAsync();
            QueueClient queue = test.Queue;
            await queue.CreateAsync().ConfigureAwait(false);

            // Generate a SAS that would set the srt / ResourceTypes in a different order than
            // the .NET SDK would normally create the SAS
            TestAccountSasBuilder accountSasBuilder = new TestAccountSasBuilder(
                permissions: permissions,
                expiresOn: Recording.UtcNow.AddDays(1),
                services: services,
                resourceTypes: resourceType);

            string sasQueryParams = GetCustomAccountSas(permissions: permissions, services: services, resourceType: resourceType);
            UriBuilder blobUriBuilder = new UriBuilder(queue.Uri)
            {
                Query = sasQueryParams
            };

            // Assert
            QueueClient sasQueueClient = InstrumentClient(new QueueClient(blobUriBuilder.Uri, GetOptions()));
            await sasQueueClient.GetPropertiesAsync();

            Assert.AreEqual("?" + sasQueryParams, sasQueueClient.Uri.Query);
        }

        [RecordedTest]
        [TestCase("sco")]
        [TestCase("soc")]
        [TestCase("cos")]
        [TestCase("ocs")]
        [TestCase("cs")]
        [TestCase("oc")]
        [ServiceVersion(Min = QueueClientOptions.ServiceVersion.V2020_06_12)]
        public async Task AccountSas_ResourceTypeOrder(string resourceType)
        {
            await InvokeAccountSasTest(resourceType: resourceType);
        }

        [RecordedTest]
        [TestCase("bfqt")]
        [TestCase("qftb")]
        [TestCase("tqfb")]
        [TestCase("fqt")]
        [TestCase("qb")]
        [TestCase("fq")]
        [ServiceVersion(Min = QueueClientOptions.ServiceVersion.V2020_06_12)]
        public async Task AccountSas_ServiceOrder(string services)
        {
            await InvokeAccountSasTest(services: services);
        }

        [RecordedTest]
        [ServiceVersion(Min = QueueClientOptions.ServiceVersion.V2026_02_06)]
        public async Task SendMessageAsync_UserDelegationSAS()
        {
            // Arrange
            string queueName = GetNewQueueName();
            QueueServiceClient service = GetServiceClient_OAuth();
            await using DisposingQueue test = await GetTestQueueAsync(service);

            Response<UserDelegationKey> userDelegationKeyResponse = await service.GetUserDelegationKeyAsync(
                expiresOn: Recording.UtcNow.AddHours(1));

            UserDelegationKey userDelegationKey = userDelegationKeyResponse.Value;

            Uri queueUri = test.Queue.GenerateUserDelegationSasUri(QueueSasPermissions.All, Recording.UtcNow.AddHours(1), userDelegationKey);

            QueueClient queueClient = InstrumentClient(new QueueClient(queueUri, GetOptions()));

            // Act
            Response<SendReceipt> response = await queueClient.SendMessageAsync(
                messageText: GetNewString(),
                visibilityTimeout: new TimeSpan(0, 0, 1),
                timeToLive: new TimeSpan(1, 0, 0));

            // Assert
            Assert.NotNull(response.Value);
        }

        [RecordedTest]
        [ServiceVersion(Min = QueueClientOptions.ServiceVersion.V2026_02_06)]
        public async Task SendMessageAsync_UserDelegationSAS_Builder()
        {
            // Arrange
            string queueName = GetNewQueueName();
            QueueServiceClient service = GetServiceClient_OAuth();
            await using DisposingQueue test = await GetTestQueueAsync(service);

            Response<UserDelegationKey> userDelegationKeyResponse = await service.GetUserDelegationKeyAsync(
                expiresOn: Recording.UtcNow.AddHours(1));

            UserDelegationKey userDelegationKey = userDelegationKeyResponse.Value;

            QueueSasBuilder queueSasBuilder = new QueueSasBuilder(QueueSasPermissions.All, Recording.UtcNow.AddHours(1))
            {
                QueueName = test.Queue.Name
            };

            Uri queueUri = test.Queue.GenerateUserDelegationSasUri(queueSasBuilder, userDelegationKey);

            QueueClient queueClient = InstrumentClient(new QueueClient(queueUri, GetOptions()));

            // Act
            Response<SendReceipt> response = await queueClient.SendMessageAsync(
                messageText: GetNewString(),
                visibilityTimeout: new TimeSpan(0, 0, 1),
                timeToLive: new TimeSpan(1, 0, 0));

            // Assert
            Assert.NotNull(response.Value);
        }

        [RecordedTest]
        [LiveOnly] // Cannot record Entra ID token
        [ServiceVersion(Min = QueueClientOptions.ServiceVersion.V2026_04_06)]
        public async Task QueueClient_UserDelegationSAS_DelegatedTenantId()
        {
            // Arrange
            QueueServiceClient service = GetServiceClient_OAuth();
            await using DisposingQueue test = await GetTestQueueAsync(service);

            // We need to get the tenant ID from the token credential used to authenticate the request
            TokenCredential tokenCredential = TestEnvironment.Credential;
            AccessToken accessToken = await tokenCredential.GetTokenAsync(
                new TokenRequestContext(Scopes),
                CancellationToken.None);

            JwtSecurityToken jwtSecurityToken = new JwtSecurityTokenHandler().ReadJwtToken(accessToken.Token);
            jwtSecurityToken.Payload.TryGetValue(Constants.Sas.TenantId, out object tenantId);

            QueueGetUserDelegationKeyOptions options = new QueueGetUserDelegationKeyOptions()
            {
                DelegatedUserTenantId = tenantId?.ToString()
            };

            Response<UserDelegationKey> userDelegationKey = await service.GetUserDelegationKeyAsync(
                expiresOn: Recording.UtcNow.AddHours(1),
                options: options);

            Assert.IsNotNull(userDelegationKey.Value);
            Assert.AreEqual(options.DelegatedUserTenantId, userDelegationKey.Value.SignedDelegatedUserTenantId);

            jwtSecurityToken.Payload.TryGetValue(Constants.Sas.ObjectId, out object objectId);

            QueueSasBuilder queueSasBuilder = new QueueSasBuilder(QueueSasPermissions.Read, Recording.UtcNow.AddHours(1))
            {
                QueueName = test.Queue.Name,
                DelegatedUserObjectId = objectId?.ToString()
            };

            QueueSasQueryParameters sasQueryParameters = queueSasBuilder.ToSasQueryParameters(userDelegationKey.Value, service.AccountName, out string stringToSign);

            QueueUriBuilder uriBuilder = new QueueUriBuilder(test.Queue.Uri)
            {
                Sas = sasQueryParameters
            };

            QueueClient identityQueueClient = InstrumentClient(new QueueClient(uriBuilder.ToUri(), TestEnvironment.Credential, GetOptions()));

            // Act
            Response<QueueProperties> response = await identityQueueClient.GetPropertiesAsync();

            // Assert
            Assert.IsNotNull(response.GetRawResponse().Headers.RequestId);
        }

        [RecordedTest]
        [LiveOnly] // Cannot record Entra ID token
        [ServiceVersion(Min = QueueClientOptions.ServiceVersion.V2026_04_06)]
        public async Task QueueClient_UserDelegationSAS_DelegatedTenantId_Failed()
        {
            // Arrange
            QueueServiceClient service = GetServiceClient_OAuth();
            await using DisposingQueue test = await GetTestQueueAsync(service);

            // We need to get the tenant ID from the token credential used to authenticate the request
            TokenCredential tokenCredential = TestEnvironment.Credential;
            AccessToken accessToken = await tokenCredential.GetTokenAsync(
                new TokenRequestContext(Scopes),
                CancellationToken.None);

            JwtSecurityToken jwtSecurityToken = new JwtSecurityTokenHandler().ReadJwtToken(accessToken.Token);
            jwtSecurityToken.Payload.TryGetValue(Constants.Sas.TenantId, out object tenantId);

            QueueGetUserDelegationKeyOptions options = new QueueGetUserDelegationKeyOptions()
            {
                DelegatedUserTenantId = tenantId?.ToString()
            };

            Response<UserDelegationKey> userDelegationKey = await service.GetUserDelegationKeyAsync(
                expiresOn: Recording.UtcNow.AddHours(1),
                options: options);

            Assert.IsNotNull(userDelegationKey.Value);
            Assert.AreEqual(options.DelegatedUserTenantId, userDelegationKey.Value.SignedDelegatedUserTenantId);

            jwtSecurityToken.Payload.TryGetValue(Constants.Sas.ObjectId, out object objectId);

            QueueSasBuilder queueSasBuilder = new QueueSasBuilder(QueueSasPermissions.Read, Recording.UtcNow.AddHours(1))
            {
                QueueName = test.Queue.Name,
                // We are deliberately not passing in DelegatedUserObjectId to cause an auth failure
            };

            QueueSasQueryParameters sasQueryParameters = queueSasBuilder.ToSasQueryParameters(userDelegationKey.Value, service.AccountName, out string stringToSign);

            QueueUriBuilder uriBuilder = new QueueUriBuilder(test.Queue.Uri)
            {
                Sas = sasQueryParameters
            };

            QueueClient identityQueueClient = InstrumentClient(new QueueClient(uriBuilder.ToUri(), TestEnvironment.Credential, GetOptions()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                identityQueueClient.GetPropertiesAsync(),
                e => Assert.AreEqual("AuthenticationFailed", e.ErrorCode));
        }

        [RecordedTest]
        [LiveOnly]
        [ServiceVersion(Min = QueueClientOptions.ServiceVersion.V2026_04_06)]
        public async Task QueueClient_UserDelegationSAS_Roundtrip()
        {
            // Arrange
            QueueServiceClient service = GetServiceClient_OAuth();
            await using DisposingQueue test = await GetTestQueueAsync(service);

            // We need to get the tenant ID from the token credential used to authenticate the request
            TokenCredential tokenCredential = TestEnvironment.Credential;
            AccessToken accessToken = await tokenCredential.GetTokenAsync(
                new TokenRequestContext(Scopes),
                CancellationToken.None);

            JwtSecurityToken jwtSecurityToken = new JwtSecurityTokenHandler().ReadJwtToken(accessToken.Token);
            jwtSecurityToken.Payload.TryGetValue(Constants.Sas.TenantId, out object tenantId);

            QueueGetUserDelegationKeyOptions options = new QueueGetUserDelegationKeyOptions()
            {
                DelegatedUserTenantId = tenantId?.ToString()
            };

            Response<UserDelegationKey> userDelegationKey = await service.GetUserDelegationKeyAsync(
                expiresOn: Recording.UtcNow.AddHours(1),
                options: options);

            Assert.IsNotNull(userDelegationKey.Value);
            Assert.AreEqual(options.DelegatedUserTenantId, userDelegationKey.Value.SignedDelegatedUserTenantId);

            jwtSecurityToken.Payload.TryGetValue(Constants.Sas.ObjectId, out object objectId);

            QueueSasBuilder queueSasBuilder = new QueueSasBuilder(QueueSasPermissions.Read, Recording.UtcNow.AddHours(1))
            {
                QueueName = test.Queue.Name,
                DelegatedUserObjectId = objectId?.ToString()
            };

            QueueSasQueryParameters sasQueryParameters = queueSasBuilder.ToSasQueryParameters(userDelegationKey.Value, service.AccountName, out string stringToSign);

            QueueUriBuilder originalUriBuilder = new QueueUriBuilder(test.Queue.Uri)
            {
                Sas = sasQueryParameters
            };

            QueueUriBuilder roundtripUriBuilder = new QueueUriBuilder(originalUriBuilder.ToUri());

            Assert.AreEqual(originalUriBuilder.ToUri(), roundtripUriBuilder.ToUri());
            Assert.AreEqual(originalUriBuilder.Sas.ToString(), roundtripUriBuilder.Sas.ToString());
        }

        [RecordedTest]
        [LiveOnly] // Cannot record Entra ID token
        [ServiceVersion(Min = QueueClientOptions.ServiceVersion.V2026_02_06)]
        public async Task SendMessageAsync_UserDelegationSAS_DelegatedObjectId()
        {
            // Arrange
            QueueServiceClient service = GetServiceClient_OAuth();
            await using DisposingQueue test = await GetTestQueueAsync(service);

            Response<UserDelegationKey> userDelegationKeyResponse = await service.GetUserDelegationKeyAsync(
                expiresOn: Recording.UtcNow.AddHours(1));

            // We need to get the object ID from the token credential used to authenticate the request
            TokenCredential tokenCredential = TestEnvironment.Credential;
            AccessToken accessToken = await tokenCredential.GetTokenAsync(
                new TokenRequestContext(Scopes),
                CancellationToken.None);

            JwtSecurityToken jwtSecurityToken = new JwtSecurityTokenHandler().ReadJwtToken(accessToken.Token);
            jwtSecurityToken.Payload.TryGetValue(Constants.Sas.ObjectId, out object objectId);

            UserDelegationKey userDelegationKey = userDelegationKeyResponse.Value;

            QueueSasBuilder queueSasBuilder = new QueueSasBuilder(QueueSasPermissions.All, Recording.UtcNow.AddHours(1))
            {
                QueueName = test.Queue.Name,
                DelegatedUserObjectId = objectId?.ToString()
            };

            QueueSasQueryParameters sasQueryParameters = queueSasBuilder.ToSasQueryParameters(userDelegationKey, service.AccountName, out string stringToSign);

            QueueUriBuilder uriBuilder = new QueueUriBuilder(test.Queue.Uri)
            {
                Sas = sasQueryParameters
            };

            QueueClient identityQueueClient = InstrumentClient(new QueueClient(uriBuilder.ToUri(), TestEnvironment.Credential, GetOptions()));

            // Act
            Response<SendReceipt> response = await identityQueueClient.SendMessageAsync(
                messageText: GetNewString(),
                visibilityTimeout: new TimeSpan(0, 0, 1),
                timeToLive: new TimeSpan(1, 0, 0));

            // Assert
            Assert.NotNull(response.Value);
        }

        [RecordedTest]
        [LiveOnly] // Cannot record Entra ID token
        [ServiceVersion(Min = QueueClientOptions.ServiceVersion.V2026_02_06)]
        public async Task SendMessageAsync_UserDelegationSAS_DelegatedObjectId_Fail()
        {
            // Arrange
            QueueServiceClient service = GetServiceClient_OAuth();
            await using DisposingQueue test = await GetTestQueueAsync(service);

            Response<UserDelegationKey> userDelegationKeyResponse = await service.GetUserDelegationKeyAsync(
                expiresOn: Recording.UtcNow.AddHours(1));

            // We need to get the object ID from the token credential used to authenticate the request
            TokenCredential tokenCredential = TestEnvironment.Credential;
            AccessToken accessToken = await tokenCredential.GetTokenAsync(
                new TokenRequestContext(Scopes),
                CancellationToken.None);

            JwtSecurityToken jwtSecurityToken = new JwtSecurityTokenHandler().ReadJwtToken(accessToken.Token);
            jwtSecurityToken.Payload.TryGetValue(Constants.Sas.ObjectId, out object objectId);

            UserDelegationKey userDelegationKey = userDelegationKeyResponse.Value;

            QueueSasBuilder queueSasBuilder = new QueueSasBuilder(QueueSasPermissions.All, Recording.UtcNow.AddHours(1))
            {
                QueueName = test.Queue.Name,
                DelegatedUserObjectId = objectId?.ToString()
            };

            QueueSasQueryParameters sasQueryParameters = queueSasBuilder.ToSasQueryParameters(userDelegationKey, service.AccountName, out string stringToSign);

            QueueUriBuilder uriBuilder = new QueueUriBuilder(test.Queue.Uri)
            {
                Sas = sasQueryParameters
            };

            QueueClient identityQueueClient = InstrumentClient(new QueueClient(uriBuilder.ToUri(), GetOptions()));

            // Act
            await TestHelper.AssertExpectedExceptionAsync<RequestFailedException>(
                identityQueueClient.SendMessageAsync(
                    messageText: GetNewString(),
                    visibilityTimeout: new TimeSpan(0, 0, 1),
                    timeToLive: new TimeSpan(1, 0, 0)),
                e => Assert.AreEqual("AuthenticationFailed", e.ErrorCode));
        }

        // Creating Client from GetStorageClient
        #region QueueServiceClient
        private async Task InvokeAccountServiceToQueueSasTest(
            string permissions = default,
            string services = default,
            string resourceType = default)
        {
            // Arrange
            QueueServiceClient serviceClient = GetQueueServiceClientWithCustomAccountSas(
                permissions: permissions,
                services: services,
                resourceType: resourceType);

            // Act
            QueueClient queueClient = serviceClient.GetQueueClient(GetNewQueueName());

            // Assert
            Assert.AreEqual(serviceClient.Uri.Query, queueClient.Uri.Query);
            await queueClient.CreateAsync();
            await queueClient.DeleteIfExistsAsync();
        }

        [RecordedTest]
        public async Task AccountSasResources_ServiceToQueue()
        {
            string resourceType = "soc";
            await InvokeAccountServiceToQueueSasTest(resourceType: resourceType);
        }

        [RecordedTest]
        public async Task AccountSasServices_ServiceToQueue()
        {
            string services = "fqt";
            await InvokeAccountServiceToQueueSasTest(services: services);
        }

        [RecordedTest]
        public async Task AccountSasPermissions_ServiceToQueue()
        {
            string permissions = "cudypafitrwl";
            await InvokeAccountServiceToQueueSasTest(permissions: permissions);
        }
        #endregion

        #region QueueClient
        private async Task InvokeAccountQueueToServiceSasTest(
            string permissions = default,
            string services = default,
            string resourceType = default)
        {
            // Arrange
            QueueClient queueClient = await GetQueueClientWithCustomAccountSas(
                permissions: permissions,
                services: services,
                resourceType: resourceType);
            try
            {
                // Act
                QueueServiceClient serviceClient = queueClient.GetParentQueueServiceClient();

                // Assert
                Assert.AreEqual(queueClient.Uri.Query, serviceClient.Uri.Query);
                await serviceClient.GetPropertiesAsync();
            }
            finally
            {
                await queueClient.DeleteIfExistsAsync();
            }
        }

        [RecordedTest]
        public async Task AccountSasResources_QueueToService()
        {
            string resourceType = "soc";
            await InvokeAccountQueueToServiceSasTest(resourceType: resourceType);
        }

        [RecordedTest]
        public async Task AccountSasServices_QueueToService()
        {
            string services = "fqt";
            await InvokeAccountQueueToServiceSasTest(services: services);
        }

        [RecordedTest]
        public async Task AccountSasPermissions_QueueToService()
        {
            string permissions = "cudypafitrwl";
            await InvokeAccountQueueToServiceSasTest(permissions: permissions);
        }
        #endregion
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;
using Microsoft.Azure.WebJobs.Extensions.Clients.Shared;
using Microsoft.Azure.WebJobs.Host.TestCommon;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Extensions.Clients.Tests
{
    public class StorageClientProviderTests
    {
        private TestLogger _testLogger;
        private TestLogger<TestClient> _logger;
        private Mock<AzureComponentFactory> _componentFactoryMock;

        [SetUp]
        public void Setup()
        {
            _testLogger = new TestLogger("StorageClientProviderTests");
            _logger = new TestLogger<TestClient>(_testLogger);
            _componentFactoryMock = new Mock<AzureComponentFactory>();
        }

        #region Connection String Detection Tests

        [Test]
        public void DetectsConnectionStringAuthentication()
        {
            // Arrange
            var connectionString = "DefaultEndpointsProtocol=https;AccountName=testaccount;AccountKey=dGVzdGtleQ==;EndpointSuffix=core.windows.net";
            var config = CreateConfiguration(new Dictionary<string, string>
            {
                { "AzureWebJobsStorage", connectionString }
            });

            var provider = CreateTestProvider(config);

            // Act
            provider.GetWebJobsConnectionStringSection(ConnectionStringNames.Storage);

            // Assert
            var logMessages = _testLogger.GetLogMessages();
            Assert.That(logMessages.Any(m =>
                m.EventId.Id == 300 &&
                m.FormattedMessage.Contains("ConnectionString")), Is.True);
            Assert.That(logMessages.Any(m =>
                m.EventId.Id == 301 &&
                m.FormattedMessage.Contains("testaccount")), Is.True);
        }

        [Test]
        public void ExtractsAccountNameFromConnectionString()
        {
            // Arrange
            var connectionString = "DefaultEndpointsProtocol=https;AccountName=myStorageAccount;AccountKey=key;EndpointSuffix=core.windows.net";
            var config = CreateConfiguration(new Dictionary<string, string>
            {
                { "AzureWebJobsStorage", connectionString }
            });

            var provider = CreateTestProvider(config);

            // Act
            provider.GetWebJobsConnectionStringSection(ConnectionStringNames.Storage);

            // Assert
            var logMessages = _testLogger.GetLogMessages();
            Assert.That(logMessages.Any(m =>
                m.FormattedMessage.Contains("myStorageAccount")), Is.True);
        }

        [Test]
        public void HandlesConnectionStringWithoutAccountName()
        {
            // Arrange - Connection string without explicit AccountName (e.g., development storage)
            var connectionString = "UseDevelopmentStorage=true";
            var config = CreateConfiguration(new Dictionary<string, string>
            {
                { "AzureWebJobsStorage", connectionString }
            });

            var provider = CreateTestProvider(config);

            // Act
            provider.GetWebJobsConnectionStringSection(ConnectionStringNames.Storage);

            // Assert
            var logMessages = _testLogger.GetLogMessages();
            Assert.That(logMessages.Any(m =>
                m.EventId.Id == 300 &&
                m.FormattedMessage.Contains("ConnectionString")), Is.True);
        }

        #endregion

        #region Managed Identity Detection Tests

        [Test]
        public void DetectsSystemAssignedManagedIdentity()
        {
            // Arrange
            var config = CreateConfiguration(new Dictionary<string, string>
            {
                { "AzureWebJobsStorage:blobServiceUri", "https://testaccount.blob.core.windows.net" },
                { "AzureWebJobsStorage:credential", "managedidentity" }
            });

            var provider = CreateTestProvider(config);

            // Act
            provider.GetWebJobsConnectionStringSection(ConnectionStringNames.Storage);

            // Assert
            var logMessages = _testLogger.GetLogMessages();
            Assert.That(logMessages.Any(m =>
                m.EventId.Id == 302 &&
                m.FormattedMessage.Contains("System-Assigned")), Is.True);
        }

        [Test]
        public void DetectsUserAssignedManagedIdentity()
        {
            // Arrange
            var clientId = "12345678-1234-1234-1234-123456789012";
            var config = CreateConfiguration(new Dictionary<string, string>
            {
                { "AzureWebJobsStorage:blobServiceUri", "https://testaccount.blob.core.windows.net" },
                { "AzureWebJobsStorage:clientId", clientId }
            });

            var provider = CreateTestProvider(config);

            // Act
            provider.GetWebJobsConnectionStringSection(ConnectionStringNames.Storage);

            // Assert - clientId should be masked (showing first 4 and last 4 chars)
            var logMessages = _testLogger.GetLogMessages();
            Assert.That(logMessages.Any(m =>
                m.EventId.Id == 302 &&
                m.FormattedMessage.Contains("User-Assigned")), Is.True);
            // Full clientId should NOT appear - it should be masked
            Assert.That(logMessages.All(m =>
                !m.FormattedMessage.Contains(clientId)), Is.True);
            // Masked version should appear (first 4 chars "1234" and last 4 "9012")
            Assert.That(logMessages.Any(m =>
                m.FormattedMessage.Contains("1234...9012")), Is.True);
        }

        #endregion

        #region Service Principal Detection Tests

        [Test]
        public void DetectsServicePrincipalWithClientSecret()
        {
            // Arrange
            var config = CreateConfiguration(new Dictionary<string, string>
            {
                { "AzureWebJobsStorage:blobServiceUri", "https://testaccount.blob.core.windows.net" },
                { "AzureWebJobsStorage:clientId", "client-id" },
                { "AzureWebJobsStorage:clientSecret", "secret-value" },
                { "AzureWebJobsStorage:tenantId", "tenant-id" }
            });

            var provider = CreateTestProvider(config);

            // Act
            provider.GetWebJobsConnectionStringSection(ConnectionStringNames.Storage);

            // Assert
            var logMessages = _testLogger.GetLogMessages();
            Assert.That(logMessages.Any(m =>
                m.EventId.Id == 303 &&
                m.FormattedMessage.Contains("ClientSecret")), Is.True);
        }

        [Test]
        public void DetectsServicePrincipalWithCertificate()
        {
            // Arrange
            var config = CreateConfiguration(new Dictionary<string, string>
            {
                { "AzureWebJobsStorage:blobServiceUri", "https://testaccount.blob.core.windows.net" },
                { "AzureWebJobsStorage:clientId", "client-id" },
                { "AzureWebJobsStorage:clientCertificatePath", "/path/to/cert.pfx" },
                { "AzureWebJobsStorage:tenantId", "tenant-id" }
            });

            var provider = CreateTestProvider(config);

            // Act
            provider.GetWebJobsConnectionStringSection(ConnectionStringNames.Storage);

            // Assert
            var logMessages = _testLogger.GetLogMessages();
            Assert.That(logMessages.Any(m =>
                m.EventId.Id == 303 &&
                m.FormattedMessage.Contains("Certificate")), Is.True);
        }

        #endregion

        #region DefaultAzureCredential Detection Tests

        [Test]
        public void DetectsDefaultAzureCredential()
        {
            // Arrange - Has service URI but no explicit credentials
            var config = CreateConfiguration(new Dictionary<string, string>
            {
                { "AzureWebJobsStorage:blobServiceUri", "https://testaccount.blob.core.windows.net" }
            });

            var provider = CreateTestProvider(config);

            // Act
            provider.GetWebJobsConnectionStringSection(ConnectionStringNames.Storage);

            // Assert
            var logMessages = _testLogger.GetLogMessages();
            Assert.That(logMessages.Any(m =>
                m.EventId.Id == 306 &&
                m.FormattedMessage.Contains("DefaultAzureCredential")), Is.True);
        }

        [Test]
        public void DetectsDefaultAzureCredentialWithAccountName()
        {
            // Arrange - Has accountName but no explicit credentials
            var config = CreateConfiguration(new Dictionary<string, string>
            {
                { "AzureWebJobsStorage:accountName", "testaccount" }
            });

            var provider = CreateTestProvider(config);

            // Act
            provider.GetWebJobsConnectionStringSection(ConnectionStringNames.Storage);

            // Assert
            var logMessages = _testLogger.GetLogMessages();
            Assert.That(logMessages.Any(m =>
                m.EventId.Id == 306), Is.True);
        }

        #endregion

        #region Account Name Extraction Tests

        [Test]
        public void ExtractsAccountNameFromBlobServiceUri()
        {
            // Arrange
            var config = CreateConfiguration(new Dictionary<string, string>
            {
                { "AzureWebJobsStorage:blobServiceUri", "https://extractedaccount.blob.core.windows.net" }
            });

            var provider = CreateTestProvider(config);

            // Act
            provider.GetWebJobsConnectionStringSection(ConnectionStringNames.Storage);

            // Assert
            var logMessages = _testLogger.GetLogMessages();
            Assert.That(logMessages.Any(m =>
                m.FormattedMessage.Contains("extractedaccount")), Is.True);
        }

        #endregion

        #region Configuration Structure Logging Tests

        [Test]
        public void LogsConfigurationStructure()
        {
            // Arrange
            var config = CreateConfiguration(new Dictionary<string, string>
            {
                { "AzureWebJobsStorage:accountName", "testaccount" },
                { "AzureWebJobsStorage:clientId", "client-id" }
            });

            var provider = CreateTestProvider(config);

            // Act
            provider.GetWebJobsConnectionStringSection(ConnectionStringNames.Storage);

            // Assert
            var logMessages = _testLogger.GetLogMessages();
            Assert.That(logMessages.Any(m =>
                m.EventId.Id == 307 &&
                m.FormattedMessage.Contains("AccountName=True") &&
                m.FormattedMessage.Contains("ClientId=True")), Is.True);
        }

        #endregion

        #region Default vs Custom Connection Tests

        [Test]
        public void IdentifiesDefaultConnection()
        {
            // Arrange
            var config = CreateConfiguration(new Dictionary<string, string>
            {
                { "AzureWebJobsStorage:blobServiceUri", "https://testaccount.blob.core.windows.net" }
            });

            var provider = CreateTestProvider(config);

            // Act - null or empty connection name should use default
            provider.GetWebJobsConnectionStringSection(null);

            // Assert
            var logMessages = _testLogger.GetLogMessages();
            Assert.That(logMessages.Any(m =>
                m.EventId.Id == 300 &&
                m.FormattedMessage.Contains("default")), Is.True);
        }

        [Test]
        public void IdentifiesCustomConnection()
        {
            // Arrange
            var config = CreateConfiguration(new Dictionary<string, string>
            {
                { "AzureWebJobsMyCustomConnection:blobServiceUri", "https://customaccount.blob.core.windows.net" }
            });

            var provider = CreateTestProvider(config);

            // Act
            provider.GetWebJobsConnectionStringSection("MyCustomConnection");

            // Assert
            var logMessages = _testLogger.GetLogMessages();
            Assert.That(logMessages.Any(m =>
                m.EventId.Id == 300 &&
                m.FormattedMessage.Contains("custom")), Is.True);
        }

        #endregion

        #region Sensitive Value Masking Tests

        [Test]
        public void MasksSensitiveValuesInLogs()
        {
            // Arrange
            var clientId = "12345678-1234-1234-1234-123456789012";
            var config = CreateConfiguration(new Dictionary<string, string>
            {
                { "AzureWebJobsStorage:blobServiceUri", "https://testaccount.blob.core.windows.net" },
                { "AzureWebJobsStorage:clientId", clientId },
                { "AzureWebJobsStorage:clientSecret", "super-secret-value" },
                { "AzureWebJobsStorage:tenantId", "tenant-id-value" }
            });

            var provider = CreateTestProvider(config);

            // Act
            provider.GetWebJobsConnectionStringSection(ConnectionStringNames.Storage);

            // Assert - Client secret should never appear in logs
            var logMessages = _testLogger.GetLogMessages();
            Assert.That(logMessages.All(m =>
                !m.FormattedMessage.Contains("super-secret-value")), Is.True);
        }

        [Test]
        public void RedactsSasTokenInConnectionString()
        {
            // Arrange - Connection string with SAS token
            var sasToken = "sv=2021-06-08&ss=bfqt&srt=sco&sp=rwdlacupiytfx&se=2024-12-31&sig=verysecretSignature123";
            var connectionString = $"BlobEndpoint=https://testaccount.blob.core.windows.net;SharedAccessSignature={sasToken}";
            var config = CreateConfiguration(new Dictionary<string, string>
            {
                { "AzureWebJobsStorage", connectionString }
            });

            var provider = CreateTestProvider(config);

            // Act
            provider.GetWebJobsConnectionStringSection(ConnectionStringNames.Storage);

            // Assert - SAS signature should never appear in logs
            var logMessages = _testLogger.GetLogMessages();
            Assert.That(logMessages.All(m =>
                !m.FormattedMessage.Contains("verysecretSignature123")), Is.True);
            Assert.That(logMessages.All(m =>
                !m.FormattedMessage.Contains(sasToken)), Is.True);
            // Should indicate SAS was detected
            Assert.That(logMessages.Any(m =>
                m.FormattedMessage.Contains("SAS")), Is.True);
        }

        [Test]
        public void RedactsSasTokenInServiceUri()
        {
            // Arrange - Service URI with SAS token in query string
            var sasSignature = "verysecretSignature456";
            var serviceUri = $"https://testaccount.blob.core.windows.net?sv=2021-06-08&ss=b&srt=sco&sp=r&sig={sasSignature}";
            var config = CreateConfiguration(new Dictionary<string, string>
            {
                { "AzureWebJobsStorage:blobServiceUri", serviceUri }
            });

            var provider = CreateTestProvider(config);

            // Act
            provider.GetWebJobsConnectionStringSection(ConnectionStringNames.Storage);

            // Assert - SAS signature should never appear in any log message
            var logMessages = _testLogger.GetLogMessages();
            Assert.That(logMessages.All(m =>
                !m.FormattedMessage.Contains(sasSignature)), Is.True);
            // Full SAS query params should not appear
            Assert.That(logMessages.All(m =>
                !m.FormattedMessage.Contains("sv=2021-06-08")), Is.True);
        }

        [Test]
        public void MasksClientIdInManagedIdentityLogs()
        {
            // Arrange - User-assigned managed identity with client ID
            var clientId = "abcd1234-5678-90ab-cdef-1234567890ab";
            var config = CreateConfiguration(new Dictionary<string, string>
            {
                { "AzureWebJobsStorage:blobServiceUri", "https://testaccount.blob.core.windows.net" },
                { "AzureWebJobsStorage:clientId", clientId }
            });

            var provider = CreateTestProvider(config);

            // Act
            provider.GetWebJobsConnectionStringSection(ConnectionStringNames.Storage);

            // Assert - Full client ID should not appear in logs (should be masked)
            var logMessages = _testLogger.GetLogMessages();
            Assert.That(logMessages.All(m =>
                !m.FormattedMessage.Contains(clientId)), Is.True);
            // Should contain partial masked value (first 4 and last 4 chars)
            Assert.That(logMessages.Any(m =>
                m.FormattedMessage.Contains("abcd") &&
                m.FormattedMessage.Contains("90ab")), Is.True);
        }

        [Test]
        public void DoesNotLogAccountKey()
        {
            // Arrange - Connection string with account key
            var accountKey = "SuperSecretAccountKey1234567890==";
            var connectionString = $"DefaultEndpointsProtocol=https;AccountName=testaccount;AccountKey={accountKey};EndpointSuffix=core.windows.net";
            var config = CreateConfiguration(new Dictionary<string, string>
            {
                { "AzureWebJobsStorage", connectionString }
            });

            var provider = CreateTestProvider(config);

            // Act
            provider.GetWebJobsConnectionStringSection(ConnectionStringNames.Storage);

            // Assert - Account key should never appear in logs
            var logMessages = _testLogger.GetLogMessages();
            Assert.That(logMessages.All(m =>
                !m.FormattedMessage.Contains(accountKey)), Is.True);
            Assert.That(logMessages.All(m =>
                !m.FormattedMessage.Contains("SuperSecretAccountKey")), Is.True);
        }

        [Test]
        public void MasksTenantIdInServicePrincipalLogs()
        {
            // Arrange
            var tenantId = "tenant-guid-1234-5678-90abcdef1234";
            var clientId = "client-guid-1234-5678-90abcdef5678";
            var config = CreateConfiguration(new Dictionary<string, string>
            {
                { "AzureWebJobsStorage:blobServiceUri", "https://testaccount.blob.core.windows.net" },
                { "AzureWebJobsStorage:clientId", clientId },
                { "AzureWebJobsStorage:clientSecret", "secret" },
                { "AzureWebJobsStorage:tenantId", tenantId }
            });

            var provider = CreateTestProvider(config);

            // Act
            provider.GetWebJobsConnectionStringSection(ConnectionStringNames.Storage);

            // Assert - Full tenant ID should not appear in logs
            var logMessages = _testLogger.GetLogMessages();
            Assert.That(logMessages.All(m =>
                !m.FormattedMessage.Contains(tenantId)), Is.True);
            Assert.That(logMessages.All(m =>
                !m.FormattedMessage.Contains(clientId)), Is.True);
        }

        #endregion

        #region Helper Methods

        private IConfiguration CreateConfiguration(Dictionary<string, string> settings)
        {
            return new ConfigurationBuilder()
                .AddInMemoryCollection(settings)
                .Build();
        }

        private TestStorageClientProvider CreateTestProvider(IConfiguration configuration)
        {
            return new TestStorageClientProvider(
                configuration,
                _componentFactoryMock.Object,
                null, // AzureEventSourceLogForwarder is sealed and can be null
                _logger);
        }

        #endregion

        #region Test Helper Classes

        /// <summary>
        /// Wrapper for TestLogger that implements ILogger{T}.
        /// </summary>
        private class TestLogger<T> : ILogger<T>
        {
            private readonly TestLogger _innerLogger;

            public TestLogger(TestLogger innerLogger)
            {
                _innerLogger = innerLogger;
            }

            public IDisposable BeginScope<TState>(TState state) => _innerLogger.BeginScope(state);

            public bool IsEnabled(LogLevel logLevel) => _innerLogger.IsEnabled(logLevel);

            public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
                => _innerLogger.Log(logLevel, eventId, state, exception, formatter);
        }

        /// <summary>
        /// Concrete implementation of StorageClientProvider for testing purposes.
        /// </summary>
        private class TestStorageClientProvider : StorageClientProvider<TestClient, TestClientOptions>
        {
            public TestStorageClientProvider(
                IConfiguration configuration,
                AzureComponentFactory componentFactory,
                AzureEventSourceLogForwarder logForwarder,
                ILogger<TestClient> logger)
                : base(configuration, componentFactory, logForwarder, logger)
            {
            }

            protected override string ServiceUriSubDomain => "blob";
        }

        #endregion
    }
}

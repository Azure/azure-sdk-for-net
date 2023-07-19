// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Storage.Tests
{
    public class StorageServerTimeoutPolicyTests : SyncAsyncPolicyTestBase
    {
        private const int ServerTimeoutSeconds = 15;
        private static TimeSpan ServerTimeout = TimeSpan.FromSeconds(ServerTimeoutSeconds);

        public StorageServerTimeoutPolicyTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public async Task DoesNotAppendTimeoutWithoutScope()
        {
            // Arrange
            var transport = new MockTransport(r => new MockResponse(200));

            // Act
            await SendGetRequest(transport, StorageServerTimeoutPolicy.Shared, uri: new Uri("http://foo.com/"));

            // Assert
            Assert.AreEqual("http://foo.com/", transport.SingleRequest.Uri.ToString());
        }

        [Test]
        public async Task AppendsTimeoutToUriWithEmptyQuery()
        {
            // Arrange
            var transport = new MockTransport(r => new MockResponse(200));

            // Act
            using (StorageExtensions.CreateServiceTimeoutScope(ServerTimeout))
            {
                await SendGetRequest(transport, StorageServerTimeoutPolicy.Shared, uri: new Uri("http://foo.com/"));
            }

            // Assert
            Assert.AreEqual($"http://foo.com/?timeout={ServerTimeoutSeconds}", transport.SingleRequest.Uri.ToString());
        }

        [Test]
        public async Task AppendsTimeoutToUriWithNonEmptyQuery()
        {
            // Arrange
            var transport = new MockTransport(r => new MockResponse(200));

            // Act
            using (StorageExtensions.CreateServiceTimeoutScope(ServerTimeout))
            {
                await SendGetRequest(transport, StorageServerTimeoutPolicy.Shared, uri: new Uri("http://foo.com/?bar=baz"));
            }

            // Assert
            Assert.AreEqual($"http://foo.com/?bar=baz&timeout={ServerTimeoutSeconds}", transport.SingleRequest.Uri.ToString());
        }

        [Test]
        public async Task DoesNotOverrideAlreadyPresentTimeout()
        {
            // Arrange
            var transport = new MockTransport(r => new MockResponse(200));

            // Act
            using (StorageExtensions.CreateServiceTimeoutScope(ServerTimeout))
            {
                await SendGetRequest(transport, StorageServerTimeoutPolicy.Shared, uri: new Uri("http://foo.com/?timeout=25"));
            }

            // Assert
            Assert.AreEqual("http://foo.com/?timeout=25", transport.SingleRequest.Uri.ToString());
        }

        [Test]
        public async Task NestedScopeWins()
        {
            // Arrange
            var transport = new MockTransport(r => new MockResponse(200));

            // Act
            using (StorageExtensions.CreateServiceTimeoutScope(ServerTimeout))
            {
                using (StorageExtensions.CreateServiceTimeoutScope(ServerTimeout.Add(TimeSpan.FromSeconds(1))))
                {
                    await SendGetRequest(transport, StorageServerTimeoutPolicy.Shared, uri: new Uri("http://foo.com/"));
                }
            }

            // Assert
            Assert.AreEqual($"http://foo.com/?timeout={ServerTimeout.TotalSeconds + 1}", transport.SingleRequest.Uri.ToString());
        }

        [Test]
        public async Task CanUnsetTheTimeout()
        {
            // Arrange
            var transport = new MockTransport(r => new MockResponse(200));

            // Act
            using (StorageExtensions.CreateServiceTimeoutScope(ServerTimeout))
            {
                using (StorageExtensions.CreateServiceTimeoutScope(null))
                {
                    await SendGetRequest(transport, StorageServerTimeoutPolicy.Shared, uri: new Uri("http://foo.com/"));
                }
            }

            // Assert
            Assert.AreEqual("http://foo.com/", transport.SingleRequest.Uri.ToString());
        }
    }
}

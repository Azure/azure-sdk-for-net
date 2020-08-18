// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Iot.Hub.Service.Authentication;
using FluentAssertions;
using NUnit.Framework;

namespace Azure.Iot.Hub.Service.Tests
{
    [Category("Unit")]
    [Parallelizable(ParallelScope.All)]
    public class IotHubSasCredentialTests
    {
        private static readonly Uri s_endpoint = new Uri("https://fake_endpoint");
        private static readonly string s_testSharedAccessKey;

        static IotHubSasCredentialTests()
        {
            // Create a base64 encoded key to be used for mocking the shared access key value.
            var rnd = new Random();
            var rndBytes = new byte[32];
            rnd.NextBytes(rndBytes);

            s_testSharedAccessKey = Convert.ToBase64String(rndBytes);
        }

        [Test]
        public void ValidateCtorParameters()
        {
            // Arrange
            string sharedAccessPolicy = "policy";
            string sharedAccessKey = "key";

            // Act and Assert
            Assert.Throws<ArgumentNullException>(() => new IotHubSasCredential(sharedAccessPolicy, null));
            Assert.Throws<ArgumentNullException>(() => new IotHubSasCredential(null, sharedAccessKey));
        }

        [Test]
        public void CtorParametersNegativeTimeToLiveThrowsException()
        {
            // Arrange
            string sharedAccessPolicy = "policy";
            string sharedAccessKey = "key";
            var ttl = TimeSpan.FromSeconds(-10);

            // Act and Assert
            Assert.Throws<ArgumentException>(() => new IotHubSasCredential(sharedAccessPolicy, sharedAccessKey, ttl));
        }

        [Test]
        public void CtorSetsDefaultTimeToLive()
        {
            // Arrange
            string sharedAccessPolicy = "policy";
            string sharedAccessKey = "key";

            // Act
            var credentials = new IotHubSasCredential(sharedAccessPolicy, sharedAccessKey);

            // Assert
            credentials.SasTokenTimeToLive.Should().BePositive();
        }

        [Test]
        public async Task CachesTokenIfNotExpired()
        {
            // Arrange
            var ttl = TimeSpan.FromMinutes(1);
            var ctx = new TokenRequestContext();
            var cts = new CancellationTokenSource();

            // Act
            var credential = new IotHubSasCredential("policy", s_testSharedAccessKey, ttl)
            {
                Endpoint = s_endpoint,
            };

            string initialToken = credential.GetToken(ctx, cts.Token).Token;
            await Task.Delay(2000).ConfigureAwait(false);
            string newToken = credential.GetToken(ctx, cts.Token).Token;

            // Assert
            newToken.Should().BeEquivalentTo(initialToken, "Token should be cached and returned");
        }

        [Test]
        public async Task RegeneratesTokenIfExpired()
        {
            // Arrange
            var ttl = TimeSpan.FromSeconds(1);
            var ctx = new TokenRequestContext();
            var cts = new CancellationTokenSource();

            // Act
            var credential = new IotHubSasCredential("policy", s_testSharedAccessKey, ttl)
            {
                Endpoint = s_endpoint,
            };

            string initialToken = credential.GetToken(ctx, cts.Token).Token;
            await Task.Delay(2000).ConfigureAwait(false);
            string newToken = credential.GetToken(ctx, cts.Token).Token;

            // Assert
            newToken.Should().NotBeEquivalentTo(initialToken, "Token has expired, and should be regenerated");
        }
    }
}

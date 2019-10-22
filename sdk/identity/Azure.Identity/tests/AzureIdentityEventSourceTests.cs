// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.Tracing;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Testing;
using Azure.Identity.Tests.Mock;
using NUnit.Framework;

namespace Azure.Identity.Tests
{
    // Avoid running these tests in parallel with anything else that's sharing the event source
    [NonParallelizable]
    public class AzureIdentityEventSourceTests
    {
        private TestEventListener _listener;

        [SetUp]
        public void Setup()
        {
            _listener = new TestEventListener();
            _listener.EnableEvents(AzureIdentityEventSource.Singleton, EventLevel.Verbose);
        }

        [Test]
        public void MatchesNameAndGuid()
        {
            // Arrange & Act
            Type eventSourceType = typeof(AzureIdentityEventSource);

            // Assert
            Assert.NotNull(eventSourceType);
            Assert.AreEqual("Azure-Core", EventSource.GetName(eventSourceType));
            Assert.AreEqual(Guid.Parse("44cbc7c6-6776-5f3c-36c1-75cd3ef19ea9"), EventSource.GetGuid(eventSourceType));
            Assert.IsNotEmpty(EventSource.GenerateManifest(eventSourceType, "assemblyPathToIncludeInManifest"));
        }

        //[Test]
        //public async Task ClientSecretCredentialSuccessEvents()
        //{
        //    var credential = new ClientSecretCredential(Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), Guid.NewGuid().ToString());

        //    credential._client(new MockAadIdentityClient(new AccessToken(Guid.NewGuid().ToString(), DateTimeOffset.UtcNow.AddMinutes(10))));

        //    credential.GetTokenAsync(new TokenRequestContext(MockScopes.Default, ))
        //}
    }
}

﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.Pipeline;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class NextLinkOperationImplementationTests
    {
        [Test]
        public void ConstructRehydrationTokenTest()
        {
            var requetMethod = RequestMethod.Get;
            var startRequestUri = new Uri("https://test");
            var nextRequestUri = "nextRequestUri";
            var headerSource = "None";
            string lastKnownLocation = null;
            var finalStateVia = OperationFinalStateVia.OperationLocation.ToString();
            var token = NextLinkOperationImplementation.GetRehydrationToken(requetMethod, startRequestUri, nextRequestUri, headerSource, lastKnownLocation, finalStateVia);
            Assert.AreEqual(requetMethod, token.RequestMethod);
            Assert.AreEqual(startRequestUri, token.InitialUri);
            Assert.AreEqual(nextRequestUri, token.NextRequestUri);
            Assert.AreEqual(headerSource, token.HeaderSource);
            Assert.AreEqual(lastKnownLocation, token.LastKnownLocation);
            Assert.AreEqual(finalStateVia, token.FinalStateVia);
        }

        [Test]
        public void ConstructNextLinkOperationTest()
        {
            var operationId = Guid.NewGuid().ToString();
            var requestMethod = RequestMethod.Delete;
            var rehydrationToken = new RehydrationToken(null, null, "None", $"https://management.azure.com/subscriptions/subscription-id/providers/Microsoft.Compute/locations/region/operations/{operationId}?api-version=2019-12-01", "https://test", requestMethod, null, OperationFinalStateVia.AzureAsyncOperation.ToString());
            var operation = (NextLinkOperationImplementation)NextLinkOperationImplementation.Create(HttpPipelineBuilder.Build(new MockClientOptions()), rehydrationToken, null);
            Assert.NotNull(operation);
            Assert.AreEqual(operationId, operation.OperationId);
            Assert.AreEqual(requestMethod, operation.RequestMethod);
        }

        [Test]
        public void GetNullOperationIdWithIvalidNextRequestUri()
        {
            var rehydrationToken = new RehydrationToken(null, null, "None", $"invalidNextRequestUri", "https://test", RequestMethod.Delete, null, OperationFinalStateVia.AzureAsyncOperation.ToString());
            var operation = NextLinkOperationImplementation.Create(HttpPipelineBuilder.Build(new MockClientOptions()), rehydrationToken, null);
            Assert.Null(((NextLinkOperationImplementation)operation).OperationId);
        }

        [Test]
        public void ThrowOnNextLinkOperationImplementationCreateWithNullRehydrationToken()
        {
            Assert.Throws<ArgumentNullException>(() => NextLinkOperationImplementation.Create(HttpPipelineBuilder.Build(new MockClientOptions()), null));
        }

        [Test]
        public void ThrowOnInvalidUri()
        {
            Assert.Throws<ArgumentException>(() => NextLinkOperationImplementation.Create(HttpPipelineBuilder.Build(new MockClientOptions()), default(RehydrationToken)));
        }

        [Test]
        public void ThrowOnNextLinkOperationImplementationCreateWithNullHttpPipeline()
        {
            Assert.Throws<ArgumentNullException>(() => NextLinkOperationImplementation.Create(null, new RehydrationToken(null, null, "None", "nextRequestUri", "https://test", RequestMethod.Delete, null, OperationFinalStateVia.AzureAsyncOperation.ToString()), null));
        }

        private class MockClientOptions : ClientOptions
        {
        }
    }
}

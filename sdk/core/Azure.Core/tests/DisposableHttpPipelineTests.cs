// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core.Serialization;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class DisposableHttpPipelineTests
    {
        [Test]
        public void DisposeWithDisposableTransport([Values(true, false)] bool isOwned)
        {
            var transport = new MockDisposableHttpPipelineTransport();
            var target = new DisposableHttpPipeline(transport, 0, 0, new[] { new MockPolicy(transport, HttpMessageSanitizer.Default) }, ResponseClassifier.Shared, isOwned);

            target.Dispose();
            Assert.AreEqual(isOwned, transport.DisposeCalled);
        }

        [Test]
        public void DisposeWithoutDisposableTransport([Values(true, false)] bool isOwned)
        {
            var transport = new MockHttpPipelineTransport();
            var target = new DisposableHttpPipeline(transport, 0, 0, new[] { new MockPolicy(transport, HttpMessageSanitizer.Default) }, ResponseClassifier.Shared, isOwned);

            target.Dispose();
        }

        private class MockHttpPipelineTransport : HttpPipelineTransport
        {
            public override void Process(HttpMessage message) { throw new NotImplementedException(); }
            public override ValueTask ProcessAsync(HttpMessage message) { throw new NotImplementedException(); }
            public override Request CreateRequest() { throw new NotImplementedException(); }
        }

        private class MockDisposableHttpPipelineTransport : HttpPipelineTransport, IDisposable
        {
            public override void Process(HttpMessage message) { throw new NotImplementedException(); }
            public override ValueTask ProcessAsync(HttpMessage message) { throw new NotImplementedException(); }
            public override Request CreateRequest() { throw new NotImplementedException(); }

            public bool DisposeCalled;
            public void Dispose() => DisposeCalled = true;
        }

        private class MockPolicy : HttpPipelineTransportPolicy
        {
            public MockPolicy(HttpPipelineTransport transport, HttpMessageSanitizer sanitizer) : base(transport, sanitizer) { }
        }
    }
}

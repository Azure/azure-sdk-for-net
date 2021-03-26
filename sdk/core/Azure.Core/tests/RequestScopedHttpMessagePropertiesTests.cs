// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Moq;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class RequestScopedHttpMessagePropertiesTests : PolicyTestBase
    {
        private Mock<HttpPipelineSynchronousPolicy> policyMock;
        private List<HttpMessage> messages;

        [SetUp]
        public void Setup()
        {
            policyMock = new Mock<HttpPipelineSynchronousPolicy>();
            policyMock.CallBase = true;
            policyMock.Setup(p => p.OnSendingRequest(It.IsAny<HttpMessage>()))
                .Callback<HttpMessage>(message =>
                {
                    messages.Add(message);
                }).Verifiable();
            messages = new List<HttpMessage>();
        }

        [Test]
        public async Task MessageHasScopedProperty()
        {
            var transport = new MockTransport(r => new MockResponse(200));

            using (HttpPipeline.CreateHttpMessagePropertyScope("foo", "bar"))
            {
                await SendGetRequest(transport, policyMock.Object);
            }

            Assert.AreEqual(1, messages.Count);
            messages[0].TryGetProperty("foo", out var fooProperty);
            Assert.AreEqual("bar", fooProperty);
        }

        [Test]
        public async Task ScopeIsTerminated()
        {
            var transport = new MockTransport(r => new MockResponse(200));

            using (HttpPipeline.CreateHttpMessagePropertyScope("foo", "bar"))
            {
                await SendGetRequest(transport, policyMock.Object);
            }

            await SendGetRequest(transport, policyMock.Object);

            Assert.AreEqual(2, messages.Count);
            Assert.IsTrue(messages[0].TryGetProperty("foo", out var _));
            Assert.IsFalse(messages[1].TryGetProperty("foo", out var _));
        }

        [Test]
        public async Task IndependentPropertiesAreMerged()
        {
            var transport = new MockTransport(r => new MockResponse(200));

            using (HttpPipeline.CreateHttpMessagePropertyScope("foo1", "bar1"))
            using (HttpPipeline.CreateHttpMessagePropertyScope("foo2", "bar2"))
            {
                await SendGetRequest(transport, policyMock.Object);
            }

            Assert.AreEqual(1, messages.Count);
            messages[0].TryGetProperty("foo1", out var foo1Property);
            messages[0].TryGetProperty("foo2", out var foo2Property);
            Assert.AreEqual("bar1", foo1Property);
            Assert.AreEqual("bar2", foo2Property);
        }

        [Test]
        public async Task MostNestedScopeWins()
        {
            var transport = new MockTransport(r => new MockResponse(200));

            using (HttpPipeline.CreateHttpMessagePropertyScope("foo", "bar1"))
            using (HttpPipeline.CreateHttpMessagePropertyScope("foo", "bar2"))
            {
                await SendGetRequest(transport, policyMock.Object);
            }

            Assert.AreEqual(1, messages.Count);
            messages[0].TryGetProperty("foo", out var fooProperty);
            Assert.AreEqual("bar2", fooProperty);
        }
    }
}

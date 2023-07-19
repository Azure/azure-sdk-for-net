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
        private Mock<HttpPipelineSynchronousPolicy> _policyMock;
        private List<HttpMessage> _messages;

        [SetUp]
        public void Setup()
        {
            _policyMock = new Mock<HttpPipelineSynchronousPolicy>();
            _policyMock.CallBase = true;
            _policyMock.Setup(p => p.OnSendingRequest(It.IsAny<HttpMessage>()))
                .Callback<HttpMessage>(message =>
                {
                    _messages.Add(message);
                }).Verifiable();
            _messages = new List<HttpMessage>();
        }

        [Test]
        public async Task MessageHasScopedProperty()
        {
            var transport = new MockTransport(r => new MockResponse(200));

            using (HttpPipeline.CreateHttpMessagePropertiesScope(new Dictionary<string, object>() { { "foo", "bar" } }))
            {
                await SendGetRequest(transport, _policyMock.Object);
            }

            Assert.AreEqual(1, _messages.Count);
            _messages[0].TryGetProperty("foo", out var fooProperty);
            Assert.AreEqual("bar", fooProperty);
        }

        [Test]
        public async Task ScopeIsTerminated()
        {
            var transport = new MockTransport(r => new MockResponse(200));

            using (HttpPipeline.CreateHttpMessagePropertiesScope(new Dictionary<string, object>() { { "foo", "bar" } }))
            {
                await SendGetRequest(transport, _policyMock.Object);
            }

            await SendGetRequest(transport, _policyMock.Object);

            Assert.AreEqual(2, _messages.Count);
            Assert.IsTrue(_messages[0].TryGetProperty("foo", out var _));
            Assert.IsFalse(_messages[1].TryGetProperty("foo", out var _));
        }

        [Test]
        public async Task IndependentPropertiesAreMerged()
        {
            var transport = new MockTransport(r => new MockResponse(200));

            using (HttpPipeline.CreateHttpMessagePropertiesScope(new Dictionary<string, object>() { { "foo1", "bar1" } }))
            using (HttpPipeline.CreateHttpMessagePropertiesScope(new Dictionary<string, object>() { { "foo2", "bar2" } }))
            {
                await SendGetRequest(transport, _policyMock.Object);
            }

            Assert.AreEqual(1, _messages.Count);
            _messages[0].TryGetProperty("foo1", out var foo1Property);
            _messages[0].TryGetProperty("foo2", out var foo2Property);
            Assert.AreEqual("bar1", foo1Property);
            Assert.AreEqual("bar2", foo2Property);
        }

        [Test]
        public async Task MostNestedScopeWins()
        {
            var transport = new MockTransport(r => new MockResponse(200));

            using (HttpPipeline.CreateHttpMessagePropertiesScope(new Dictionary<string, object>() { { "foo", "bar1" } }))
            using (HttpPipeline.CreateHttpMessagePropertiesScope(new Dictionary<string, object>() { { "foo", "bar2" } }))
            {
                await SendGetRequest(transport, _policyMock.Object);
            }

            Assert.AreEqual(1, _messages.Count);
            _messages[0].TryGetProperty("foo", out var fooProperty);
            Assert.AreEqual("bar2", fooProperty);
        }

        [Test]
        public async Task CanUnsetParentValue()
        {
            var transport = new MockTransport(r => new MockResponse(200));

            using (HttpPipeline.CreateHttpMessagePropertiesScope(new Dictionary<string, object>() { { "foo", "bar" } }))
            using (HttpPipeline.CreateHttpMessagePropertiesScope(new Dictionary<string, object>() { { "foo", null } }))
            {
                await SendGetRequest(transport, _policyMock.Object);
            }

            Assert.AreEqual(1, _messages.Count);
            Assert.IsFalse(_messages[0].TryGetProperty("foo", out var _));
        }
    }
}

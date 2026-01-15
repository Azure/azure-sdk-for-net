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

            Assert.That(_messages.Count, Is.EqualTo(1));
            _messages[0].TryGetProperty("foo", out var fooProperty);
            Assert.That(fooProperty, Is.EqualTo("bar"));
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

            Assert.That(_messages.Count, Is.EqualTo(2));
            Assert.That(_messages[0].TryGetProperty("foo", out var _), Is.True);
            Assert.That(_messages[1].TryGetProperty("foo", out var _), Is.False);
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

            Assert.That(_messages.Count, Is.EqualTo(1));
            _messages[0].TryGetProperty("foo1", out var foo1Property);
            _messages[0].TryGetProperty("foo2", out var foo2Property);
            Assert.That(foo1Property, Is.EqualTo("bar1"));
            Assert.That(foo2Property, Is.EqualTo("bar2"));
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

            Assert.That(_messages.Count, Is.EqualTo(1));
            _messages[0].TryGetProperty("foo", out var fooProperty);
            Assert.That(fooProperty, Is.EqualTo("bar2"));
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

            Assert.That(_messages.Count, Is.EqualTo(1));
            Assert.That(_messages[0].TryGetProperty("foo", out var _), Is.False);
        }
    }
}

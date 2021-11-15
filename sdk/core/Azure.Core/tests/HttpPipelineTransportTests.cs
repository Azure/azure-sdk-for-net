// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class HttpPipelineTransportTests
    {
        [Test]
        public void DisposeCallsDisposeInternal()
        {
            var target = new MockHttpPipelineTransport();
            target.Dispose();

            Assert.IsTrue(target.DisposeCalled);
        }

        [Test]
        public void CreateReturnsStaticInstanceWhenNoOptionsArePassed([Values(true, false)] bool noOptionsSpecified)
        {
            var options = new HttpPipelineTransportOptions();
            var target = noOptionsSpecified ? HttpPipelineTransport.Create() : HttpPipelineTransport.Create(options);
            var target2 = noOptionsSpecified ? HttpPipelineTransport.Create() : HttpPipelineTransport.Create(options);
#if NETFRAMEWORK
            var sharedInstance = HttpWebRequestTransport.Shared;
#else
            var sharedInstance = HttpClientTransport.Shared;
#endif

            Assert.AreEqual(noOptionsSpecified, target == sharedInstance);
            Assert.AreEqual(noOptionsSpecified, target == target2);
        }

        private class MockHttpPipelineTransport : HttpPipelineTransport
        {
            public override void Process(HttpMessage message) { throw new NotImplementedException(); }
            public override ValueTask ProcessAsync(HttpMessage message) { throw new NotImplementedException(); }
            public override Request CreateRequest() { throw new NotImplementedException(); }

            public bool DisposeCalled { get; set; }
            internal override void DisposeInternal() => DisposeCalled = true;
        }
    }
}

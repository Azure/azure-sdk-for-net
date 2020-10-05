// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class HttpPipelineTests
    {
        [Test]
        public async Task DoesntDisposeRequestInSendRequestAsync()
        {
            HttpPipeline httpPipeline = HttpPipelineBuilder.Build(new TestOptions()
            {
                Transport = new MockTransport(new MockResponse(200))
            });

            using MockRequest request = (MockRequest)httpPipeline.CreateRequest();

            MockResponse response = (MockResponse)await httpPipeline.SendRequestAsync(request, default);

            Assert.False(request.IsDisposed);
            Assert.False(response.IsDisposed);
        }

        private class TestOptions : ClientOptions
        {
        }
    }
}

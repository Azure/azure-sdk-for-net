// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using ClientModel.Tests;
using ClientModel.Tests.Mocks;
using NUnit.Framework;
using System.ClientModel.Primitives;
using System.Net.Http;
using System.Threading.Tasks;

namespace System.ClientModel.Tests.Pipeline;

public class HttpClientPipelineTransportTests : SyncAsyncTestBase
{
    public HttpClientPipelineTransportTests(bool isAsync) : base(isAsync)
    {
    }

    [Test]
    public async Task CanGetAndSetUri()
    {
        Uri? requestUri = null;
        var mockHandler = new MockHttpClientHandler(
            httpRequestMessage =>
            {
                requestUri = httpRequestMessage.RequestUri;
            });

        var expectedUri = new Uri("http://example.com:340");
        HttpClientPipelineTransport transport = new(new HttpClient(mockHandler));

        using PipelineMessage message = transport.CreateMessage();
        message.Request.Method = "GET";
        message.Request.Uri = expectedUri;

        await transport.ProcessSyncOrAsync(message, IsAsync);

        Assert.AreEqual(expectedUri, requestUri);
    }
}

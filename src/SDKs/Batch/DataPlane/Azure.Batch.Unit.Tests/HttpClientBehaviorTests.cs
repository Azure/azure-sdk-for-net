// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Azure.Batch.Unit.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Batch.Protocol;
    using Microsoft.Net.Http.Server;
    using Xunit;

    public class HttpClientBehaviorTests
    {
        private const string url = "http://localhost:2055";

        [Theory]
        [MemberData(nameof(HttpMethods))]
        public async Task HttpClient_IncludesContentLengthHeaderOnExpectedHttpVerbs(HttpMethod httpMethod)
        {
            BatchSharedKeyCredential creds = new BatchSharedKeyCredential(ClientUnitTestCommon.DummyAccountName, ClientUnitTestCommon.DummyAccountKey);

            HttpRequestMessage message = new HttpRequestMessage(httpMethod, url);
            message.Headers.Add("client-request-id", Guid.NewGuid().ToString());

            await creds.ProcessHttpRequestAsync(message, CancellationToken.None);
            Assert.NotNull(message.Headers.Authorization);

            var settings = new WebListenerSettings()
            {
                Authentication = { Schemes = AuthenticationSchemes.None },
                UrlPrefixes = { url }
            };
            using (WebListener listener = new WebListener(settings))
            {
                listener.Start();
                Task listenTask = AcceptAndAssertAsync(httpMethod, listener, AssertRequestHasExpectedContentLength);

                HttpClient client = new HttpClient();
                await client.SendAsync(message);

                await listenTask;
            }
        }

        public static IEnumerable<object[]> HttpMethods()
        {
            yield return new[] { HttpMethod.Delete };
            yield return new[] { HttpMethod.Post };
            yield return new[] { HttpMethod.Get };
            yield return new[] { HttpMethod.Head };
            yield return new[] { new HttpMethod("PATCH") };
            yield return new[] { HttpMethod.Put };
            yield return new[] { HttpMethod.Options };
        }

        private static async Task AcceptAndAssertAsync(HttpMethod httpMethod, WebListener listener, Action<HttpMethod, RequestContext> assertLambda)
        {
            using (RequestContext ctx = await listener.AcceptAsync())
            {
                assertLambda(httpMethod, ctx);
                ctx.Response.StatusCode = 200;
            }
        }

        private static void AssertRequestHasExpectedContentLength(HttpMethod httpMethod, RequestContext ctx)
        {
            if (httpMethod == HttpMethod.Head || httpMethod == HttpMethod.Get)
            {
                Assert.DoesNotContain(ctx.Request.Headers.Keys, str => str == "Content-Length");
            }
            else if (httpMethod == HttpMethod.Delete || httpMethod == new HttpMethod("PATCH") || httpMethod == HttpMethod.Options)
            {
                Assert.Contains(ctx.Request.Headers.Keys, str => str == "Content-Length");
                Assert.Equal("0", ctx.Request.Headers["Content-Length"].Single());
            }
            else if (httpMethod == HttpMethod.Post || httpMethod == HttpMethod.Put)
            {
                Assert.Contains(ctx.Request.Headers.Keys, str => str == "Content-Length");
                Assert.Equal("0", ctx.Request.Headers["Content-Length"].Single());
            }
            else
            {
                throw new ArgumentException($"Unexpected HTTP request type: {httpMethod}");
            }
        }
    }
}

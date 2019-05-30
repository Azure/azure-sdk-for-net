using System;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Microsoft.AspNetCore.Http;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class HttpClientTransportFunctionalTests: PipelineTestBase
    {
        [NonParallelizable]
        [Theory]
        [TestCase("HTTP_PROXY", "http://microsoft.com")]
        [TestCase("ALL_PROXY", "http://microsoft.com")]
        public async Task ProxySettingsAreReadFromEnvironment(string envVar, string url)
        {
            try
            {
                using (TestServer testServer = new TestServer(async context =>
                {
                    context.Response.Headers["Via"] = "Test-Proxy";
                    await context.Response.WriteAsync("Hello");
                }))
                {
                    Environment.SetEnvironmentVariable(envVar, testServer.Address.ToString());

                    var transport = new HttpClientTransport();
                    Request request = transport.CreateRequest();
                    request.UriBuilder.Uri = new Uri(url);
                    Response response = await ExecuteRequest(request, transport);
                    Assert.True(response.Headers.TryGetValue("Via", out var via));
                    Assert.AreEqual("Test-Proxy", via);
                }
            }
            finally
            {
                Environment.SetEnvironmentVariable(envVar, null);
            }
        }
    }
}

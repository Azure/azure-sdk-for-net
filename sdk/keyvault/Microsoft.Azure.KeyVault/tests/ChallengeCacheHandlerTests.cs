using Microsoft.Azure.KeyVault.Customized.Authentication;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Kvp = System.Collections.Generic.KeyValuePair<string, string>;

namespace Microsoft.Azure.KeyVault.Tests
{
    public class ChallengeCacheHandlerTests
    {
        [Fact]
        public async Task CacheAddOn401Async()
        {
            var handler = new ChallengeCacheHandler();

            var expChallenge = MockChallenge.Create();

            handler.InnerHandler = new StaticChallengeResponseHandler(HttpStatusCode.Unauthorized, expChallenge.ToString());

            var client = new HttpClient(handler);

            var requestUrl = CreateMockUrl(2);

            var _ = await client.SendAsync(new HttpRequestMessage(HttpMethod.Get, requestUrl));

            AssertChallengeCacheEntry(requestUrl, expChallenge);
        }

        [Fact]
        public async Task CacheUpdateOn401Async()
        {
            string requestUrlBase = CreateMockUrl();

            string requestUrl1 = CreateMockUrl(requestUrlBase, 2);

            HttpBearerChallengeCache.GetInstance().SetChallengeForURL(new Uri(requestUrl1), MockChallenge.Create().ToHttpBearerChallenge(requestUrl1));

            string requestUrl2 = CreateMockUrl(requestUrlBase, 2);

            var handler = new ChallengeCacheHandler();

            var expChallenge = MockChallenge.Create();

            handler.InnerHandler = new StaticChallengeResponseHandler(HttpStatusCode.Unauthorized, expChallenge.ToString());

            var client = new HttpClient(handler);

            var _ = await client.SendAsync(new HttpRequestMessage(HttpMethod.Get, requestUrl2));

            AssertChallengeCacheEntry(requestUrl1, expChallenge);

            AssertChallengeCacheEntry(requestUrl2, expChallenge);
        }

        [Fact]
        public async Task CacheNotUpdatedNoChallengeAsync()
        {
            var handler = new ChallengeCacheHandler();

            handler.InnerHandler = new StaticChallengeResponseHandler(HttpStatusCode.Unauthorized, null);

            var client = new HttpClient(handler);

            var requestUrl = CreateMockUrl(2);

            var _ = await client.SendAsync(new HttpRequestMessage(HttpMethod.Get, requestUrl));

            AssertChallengeCacheEntry(requestUrl, null);
        }

        [Fact]
        public async Task CacheNotUpdatedNon401Aysnc()
        {
            var handler = new ChallengeCacheHandler();

            var expChallenge = MockChallenge.Create();

            handler.InnerHandler = new StaticChallengeResponseHandler(HttpStatusCode.Forbidden, expChallenge.ToString());

            var client = new HttpClient(handler);

            var requestUrl = CreateMockUrl(2);

            var _ = await client.SendAsync(new HttpRequestMessage(HttpMethod.Get, requestUrl));

            AssertChallengeCacheEntry(requestUrl, null);
        }

        [Fact]
        public async Task CacheNotUpdatedNonBearerChallengeAsync()
        {
            var handler = new ChallengeCacheHandler();

            handler.InnerHandler = new StaticChallengeResponseHandler(HttpStatusCode.Unauthorized, MockChallenge.Create("PoP").ToString());

            var client = new HttpClient(handler);

            var requestUrl = CreateMockUrl(2);

            var _ = await client.SendAsync(new HttpRequestMessage(HttpMethod.Get, requestUrl));

            AssertChallengeCacheEntry(requestUrl, null);
        }

        private static void AssertChallengeCacheEntry(string requestUrl, MockChallenge expChallenge)
        {
            var actChallenge = HttpBearerChallengeCache.GetInstance().GetChallengeForURL(new Uri(requestUrl));

            if (expChallenge == null)
            {
                Assert.Null(actChallenge);
            }
            else
            {
                Assert.NotNull(actChallenge);

                Assert.Equal(expChallenge.AuthorizationServer, actChallenge.AuthorizationServer);

                Assert.Equal(expChallenge.Scope, actChallenge.Scope);

                Assert.Equal(expChallenge.Resource, actChallenge.Resource);
            }
        }

        private static string BuildChallengeString(params Kvp[] parameters)
        {
            // remove the trailing ',' and return
            return BuildChallengeString("Bearer", parameters);
        }

        private static string BuildChallengeString(string challengeType, params Kvp[] parameters)
        {
            StringBuilder buff = new StringBuilder(challengeType).Append(" ");

            foreach (var kvp in parameters)
            {
                buff.Append(kvp.Key).Append("=\"").Append(kvp.Value).Append("\",");
            }

            // remove the trailing ',' and return
            return buff.Remove(buff.Length - 1, 1).ToString();
        }

        public static string CreateMockUrl(int pathCount = 0)
        {
            return CreateMockUrl("https://" + Guid.NewGuid().ToString("N"), pathCount);
        }

        public static string CreateMockUrl(string baseUrl, int pathCount = 0)
        {
            var buff = new StringBuilder(baseUrl);

            if(baseUrl.EndsWith("/"))
            {
                buff.Remove(buff.Length - 1, 1);
            }

            for (int i = 0; i < pathCount; i++)
            {
                buff.Append("/").Append(Guid.NewGuid().ToString("N"));
            }

            return buff.ToString();
        }

        private class MockChallenge
        {
            public string ChallengeType { get; set; }

            public string AuthorizationServer { get; set; }

            public string Resource { get; set; }

            public string Scope { get; set; }

            public static MockChallenge Create(string challengeType = null, string authority = null, string resource = null, string scope = null)
            {
                var mock = new MockChallenge();
                mock.ChallengeType = challengeType ?? "Bearer";
                mock.AuthorizationServer = authority ?? CreateMockUrl(1);
                mock.Resource = resource ?? CreateMockUrl(0);
                mock.Scope = scope ?? mock.Resource + "/.default";
                return mock;
            }

            public HttpBearerChallenge ToHttpBearerChallenge(string requestUrl)
            {
                return new HttpBearerChallenge(new Uri(requestUrl), ToString());
            }

            public override string ToString()
            {
                var parameters = new List<Kvp>();

                StringBuilder buff = new StringBuilder();

                if(AuthorizationServer != null)
                {
                    parameters.Add(new Kvp("authorization", AuthorizationServer));
                }

                if (Resource != null)
                {
                    parameters.Add(new Kvp("resource", Resource));
                }

                if (Scope != null)
                {
                    parameters.Add(new Kvp("scope", Scope));
                }

                return BuildChallengeString(ChallengeType, parameters.ToArray());
            }

        }


        private class StaticChallengeResponseHandler : HttpMessageHandler
        {
            private HttpStatusCode _statusCode;
            private string _challengeHeader;

            public StaticChallengeResponseHandler(HttpStatusCode statusCode, string challengeHeader)
            {
                _statusCode = statusCode;
                _challengeHeader = challengeHeader;
            }

            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                return Task.FromResult(CreateResponse(request));
            }

            private HttpResponseMessage CreateResponse(HttpRequestMessage request)
            {
                var response = new HttpResponseMessage(_statusCode);

                response.RequestMessage = request;

                if(_challengeHeader != null)
                {
                    response.Headers.Add("WWW-Authenticate", _challengeHeader);
                }

                return response;
            }
        }
    }
}

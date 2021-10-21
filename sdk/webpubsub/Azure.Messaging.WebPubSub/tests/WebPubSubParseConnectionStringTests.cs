// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Web;

using NUnit.Framework;

namespace Azure.Messaging.WebPubSub.Tests
{
    [TestFixture]
    public class WebPubSubParseConnectionStringTests
    {
        private const string FakeAccessKey = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789ABCDEFGH";
        private static readonly JwtSecurityTokenHandler JwtTokenHandler = new JwtSecurityTokenHandler();

        [TestCase("Endpoint=https://host;AccessKey={0};Version=1.0;", "https://host")]
        [TestCase("Endpoint=http://host;AccessKey={0};Version=1.0;", "http://host")]
        [TestCase("Endpoint=http://host;AccessKey={0};Version=1.0;Port=8080;", "http://host:8080")]
        [TestCase("AccessKey={0};Endpoint=http://host;Version=1.0;", "http://host")]
        public void ParseConnectionStringTests(string connectionString, string url)
        {
            connectionString = string.Format(connectionString, FakeAccessKey);
            var (uri, credential) = WebPubSubServiceClient.ParseConnectionString(connectionString);
            Assert.AreEqual(new Uri(url), uri);
            Assert.AreEqual(FakeAccessKey, credential.Key);
        }

        [TestCase(null, null)]
        [TestCase("ab", new[] { "a" })]
        [TestCase("ab", new[] { "a", "a", "a" })]
        [TestCase("ab", new[] { "a", "b", "c" })]
        [TestCase("ab", new string[0])]
        public void TestGenerateUriContainsExpectedPayloadsDto(string userId, string[] roles)
        {
            var serviceClient = new WebPubSubServiceClient(string.Format("Endpoint=http://localhost;Port=8080;AccessKey={0};Version=1.0;", FakeAccessKey), "hub");
            var expiresAt = DateTimeOffset.UtcNow + TimeSpan.FromMinutes(5);
            var uri = serviceClient.GetClientAccessUri(expiresAt, userId, roles);
            var token = HttpUtility.ParseQueryString(uri.Query).Get("access_token");
            Assert.NotNull(token);
            var jwt = JwtTokenHandler.ReadJwtToken(token);

            var audience = jwt.Claims.FirstOrDefault(s => s.Type == "aud");
            Assert.NotNull(audience);
            Assert.AreEqual("http://localhost:8080/client/hubs/hub", audience.Value);
            var iat = jwt.Claims.FirstOrDefault(s => s.Type == "iat")?.Value;
            Assert.NotNull(iat);
            Assert.IsTrue(long.TryParse(iat, out var issuedAt));
            var exp = jwt.Claims.FirstOrDefault(s => s.Type == "exp")?.Value;
            Assert.NotNull(exp);
            Assert.IsTrue(long.TryParse(exp, out var expireAt));

            // default expire after should be ~5 minutes (~300 seconds)
            var expireAfter = expireAt - issuedAt;
            Assert.IsTrue(expireAfter > 295 && expireAfter < 305);

            var sub = jwt.Claims.Where(s => s.Type == "sub").Select(s => s.Value).ToArray();

            if (userId != null)
            {
                Assert.AreEqual(1, sub.Length);
                Assert.AreEqual(userId, sub[0]);
            }
            else
            {
                Assert.IsEmpty(sub);
            }

            var roleClaims = jwt.Claims.Where(s => s.Type == "role").Select(s => s.Value).ToArray();
            if (roles?.Length > 0)
            {
                Assert.AreEqual(roles, roleClaims);
            }
            else
            {
                Assert.IsEmpty(roleClaims);
            }
        }

        [TestCase(null, null)]
        [TestCase("ab", new[] { "a" })]
        [TestCase("ab", new[] { "a", "a", "a" })]
        [TestCase("ab", new[] { "a", "b", "c" })]
        [TestCase("ab", new string[0])]
        public void TestGenerateUriContainsExpectedPayloads(string userId, string[] roles)
        {
            var serviceClient = new WebPubSubServiceClient(string.Format("Endpoint=http://localhost;Port=8080;AccessKey={0};Version=1.0;", FakeAccessKey), "hub");
            var uri = serviceClient.GetClientAccessUri(TimeSpan.FromMinutes(5), userId, roles);
            var token = HttpUtility.ParseQueryString(uri.Query).Get("access_token");
            Assert.NotNull(token);
            var jwt = JwtTokenHandler.ReadJwtToken(token);

            var audience = jwt.Claims.FirstOrDefault(s => s.Type == "aud");
            Assert.NotNull(audience);
            Assert.AreEqual("http://localhost:8080/client/hubs/hub", audience.Value);
            var iat = jwt.Claims.FirstOrDefault(s => s.Type == "iat")?.Value;
            Assert.NotNull(iat);
            Assert.IsTrue(long.TryParse(iat, out var issuedAt));
            var exp = jwt.Claims.FirstOrDefault(s => s.Type == "exp")?.Value;
            Assert.NotNull(exp);
            Assert.IsTrue(long.TryParse(exp, out var expireAt));

            // default expire after should be ~5 minutes (~300 seconds)
            var expireAfter = expireAt - issuedAt;
            Assert.IsTrue(expireAfter > 295 && expireAfter < 305);

            var sub = jwt.Claims.Where(s => s.Type == "sub").Select(s => s.Value).ToArray();

            if (userId != null)
            {
                Assert.AreEqual(1, sub.Length);
                Assert.AreEqual(userId, sub[0]);
            }
            else
            {
                Assert.IsEmpty(sub);
            }

            var roleClaims = jwt.Claims.Where(s => s.Type == "role").Select(s => s.Value).ToArray();
            if (roles?.Length > 0)
            {
                Assert.AreEqual(roles, roleClaims);
            }
            else
            {
                Assert.IsEmpty(roleClaims);
            }
        }

        [TestCase("Endpoint=http://localhost;Port=8080;AccessKey={0};Version=1.0;", "hub", "ws://localhost:8080/client/hubs/hub")]
        [TestCase("Endpoint=https://a;AccessKey={0};Version=1.0;", "hub", "wss://a/client/hubs/hub")]
        [TestCase("Endpoint=http://a;AccessKey={0};Version=1.0;", "hub", "ws://a/client/hubs/hub")]
        public void TestGenerateUriUseSameKidWithSameKey(string connectionString, string hub, string expectedUrl)
        {
            var serviceClient = new WebPubSubServiceClient(string.Format(connectionString, FakeAccessKey), hub);
            var uri1 = serviceClient.GetClientAccessUri();
            var uri2 = serviceClient.GetClientAccessUri();
            var urlBuilder = new UriBuilder(uri1);
            urlBuilder.Query = string.Empty;
            Assert.AreEqual(expectedUrl, urlBuilder.Uri.ToString());
            var token1 = HttpUtility.ParseQueryString(uri1.Query).Get("access_token");
            Assert.NotNull(token1);
            var token2 = HttpUtility.ParseQueryString(uri2.Query).Get("access_token");
            Assert.NotNull(token2);
            var jwt1 = JwtTokenHandler.ReadJwtToken(token1);
            var jwt2 = JwtTokenHandler.ReadJwtToken(token2);
            Assert.AreEqual(jwt1.Header.Kid, jwt2.Header.Kid);
        }
    }
}

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
            Assert.Multiple(() =>
            {
                Assert.That(uri, Is.EqualTo(new Uri(url)));
                Assert.That(credential.Key, Is.EqualTo(FakeAccessKey));
            });
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
            Assert.That(token, Is.Not.Null);
            var jwt = JwtTokenHandler.ReadJwtToken(token);

            var audience = jwt.Claims.FirstOrDefault(s => s.Type == "aud");
            Assert.That(audience, Is.Not.Null);
            Assert.That(audience.Value, Is.EqualTo("http://localhost:8080/client/hubs/hub"));
            var iat = jwt.Claims.FirstOrDefault(s => s.Type == "iat")?.Value;

            Assert.That(iat, Is.Not.Null);
            Assert.That(long.TryParse(iat, out var issuedAt), Is.True);

            var exp = jwt.Claims.FirstOrDefault(s => s.Type == "exp")?.Value;

            Assert.That(exp, Is.Not.Null);
            Assert.That(long.TryParse(exp, out var expireAt), Is.True);

            // default expire after should be ~5 minutes (~300 seconds)
            var expireAfter = expireAt - issuedAt;
            Assert.That(expireAfter > 295 && expireAfter < 305, Is.True);

            var sub = jwt.Claims.Where(s => s.Type == "sub").Select(s => s.Value).ToArray();

            if (userId != null)
            {
                Assert.That(sub.Length, Is.EqualTo(1));
                Assert.That(sub[0], Is.EqualTo(userId));
            }
            else
            {
                Assert.That(sub, Is.Empty);
            }

            var roleClaims = jwt.Claims.Where(s => s.Type == "role").Select(s => s.Value).ToArray();
            if (roles?.Length > 0)
            {
                Assert.That(roleClaims, Is.EqualTo(roles));
            }
            else
            {
                Assert.That(roleClaims, Is.Empty);
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
            Assert.That(token, Is.Not.Null);
            var jwt = JwtTokenHandler.ReadJwtToken(token);

            var audience = jwt.Claims.FirstOrDefault(s => s.Type == "aud");
            Assert.That(audience, Is.Not.Null);
            Assert.That(audience.Value, Is.EqualTo("http://localhost:8080/client/hubs/hub"));
            var iat = jwt.Claims.FirstOrDefault(s => s.Type == "iat")?.Value;

            Assert.That(iat, Is.Not.Null);
            Assert.That(long.TryParse(iat, out var issuedAt), Is.True);

            var exp = jwt.Claims.FirstOrDefault(s => s.Type == "exp")?.Value;

            Assert.That(exp, Is.Not.Null);
            Assert.That(long.TryParse(exp, out var expireAt), Is.True);

            // default expire after should be ~5 minutes (~300 seconds)
            var expireAfter = expireAt - issuedAt;
            Assert.That(expireAfter > 295 && expireAfter < 305, Is.True);

            var sub = jwt.Claims.Where(s => s.Type == "sub").Select(s => s.Value).ToArray();

            if (userId != null)
            {
                Assert.That(sub.Length, Is.EqualTo(1));
                Assert.That(sub[0], Is.EqualTo(userId));
            }
            else
            {
                Assert.That(sub, Is.Empty);
            }

            var roleClaims = jwt.Claims.Where(s => s.Type == "role").Select(s => s.Value).ToArray();
            if (roles?.Length > 0)
            {
                Assert.That(roleClaims, Is.EqualTo(roles));
            }
            else
            {
                Assert.That(roleClaims, Is.Empty);
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
            Assert.That(urlBuilder.Uri.ToString(), Is.EqualTo(expectedUrl));
            var token1 = HttpUtility.ParseQueryString(uri1.Query).Get("access_token");
            Assert.That(token1, Is.Not.Null);
            var token2 = HttpUtility.ParseQueryString(uri2.Query).Get("access_token");
            Assert.That(token2, Is.Not.Null);
            var jwt1 = JwtTokenHandler.ReadJwtToken(token1);
            var jwt2 = JwtTokenHandler.ReadJwtToken(token2);
            Assert.That(jwt2.Header.Kid, Is.EqualTo(jwt1.Header.Kid));
        }
    }
}

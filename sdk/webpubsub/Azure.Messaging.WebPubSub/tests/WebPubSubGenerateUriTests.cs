// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading;
using System.Web;

using NUnit.Framework;

namespace Azure.Messaging.WebPubSub.Tests
{
    [TestFixture]
    public class WebPubSubGenerateUriTests
    {
        private const string FakeAccessKey = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789ABCDEFGH";

        private static readonly JwtSecurityTokenHandler s_jwtTokenHandler = new();

        [TestCase(0, 60)]
        [TestCase(1, 1)]
        [TestCase(2, 2)]
        [TestCase(3, 3)]
        [TestCase(4, 4)]
        public void AccessKeyExpiresAfterTests(int minutesToExpire, int expectedMinutesAfter)
        {
            var serviceClient = new WebPubSubServiceClient(string.Format("Endpoint=http://localhost;Port=8080;AccessKey={0};Version=1.0;", FakeAccessKey), "hub");
            var utcnow = DateTimeOffset.UtcNow;
            var expiresAfter = TimeSpan.FromMinutes(minutesToExpire);

            Uri uri = serviceClient.GetClientAccessUri(expiresAfter, "foo", null );
            var token = HttpUtility.ParseQueryString(uri.Query).Get("access_token");
            Assert.NotNull(token);
            var jwt = s_jwtTokenHandler.ReadJwtToken(token);

            var expireTime = jwt.Claims.FirstOrDefault(s => s.Type == "exp")?.Value;
            Assert.IsTrue(long.TryParse(expireTime, out var expireTimestamp));
            Assert.AreEqual(utcnow.Add(TimeSpan.FromMinutes(expectedMinutesAfter)).ToUnixTimeSeconds(), expireTimestamp);
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        public void AccessKeyExpireAtTests(int minutesToExpire)
        {
            var serviceClient = new WebPubSubServiceClient(string.Format("Endpoint=http://localhost;Port=8080;AccessKey={0};Version=1.0;", FakeAccessKey), "hub");
            var expireAt = DateTimeOffset.UtcNow.Add(TimeSpan.FromMinutes(minutesToExpire));

            Uri uri = serviceClient.GetClientAccessUri(expireAt, "foo", null );
            var token = HttpUtility.ParseQueryString(uri.Query).Get("access_token");
            Assert.NotNull(token);
            var jwt = s_jwtTokenHandler.ReadJwtToken(token);

            var exp = jwt.Claims.FirstOrDefault(s => s.Type == "exp")?.Value;
            Assert.IsTrue(long.TryParse(exp, out var expTimestamp));
            Assert.AreEqual(expireAt.ToUnixTimeSeconds(), expTimestamp);
        }

        [Test]
        public void GetMinutesToExpireTest()
        {
            DateTimeOffset expiresAt;
            expiresAt = DateTimeOffset.UtcNow.AddSeconds(0);
            Assert.AreEqual(1, WebPubSubServiceClient.GetMinutesToExpire(expiresAt));
            expiresAt = DateTimeOffset.UtcNow.AddSeconds(59);
            Assert.AreEqual(1, WebPubSubServiceClient.GetMinutesToExpire(expiresAt));
            expiresAt = DateTimeOffset.UtcNow.AddSeconds(61);
            Assert.AreEqual(1, WebPubSubServiceClient.GetMinutesToExpire(expiresAt));
            expiresAt = DateTimeOffset.UtcNow.AddSeconds(119);
            Assert.AreEqual(1, WebPubSubServiceClient.GetMinutesToExpire(expiresAt));
            expiresAt = DateTimeOffset.UtcNow.AddSeconds(121);
            Assert.AreEqual(2, WebPubSubServiceClient.GetMinutesToExpire(expiresAt));

            TimeSpan expiresAfter;
            expiresAfter = TimeSpan.FromSeconds(0);
            Assert.AreEqual(1, WebPubSubServiceClient.GetMinutesToExpire(expiresAfter));
            expiresAfter = TimeSpan.FromSeconds(59);
            Assert.AreEqual(1, WebPubSubServiceClient.GetMinutesToExpire(expiresAfter));
            expiresAfter = TimeSpan.FromSeconds(61);
            Assert.AreEqual(1, WebPubSubServiceClient.GetMinutesToExpire(expiresAfter));
            expiresAfter = TimeSpan.FromSeconds(119);
            Assert.AreEqual(1, WebPubSubServiceClient.GetMinutesToExpire(expiresAfter));
            expiresAfter = TimeSpan.FromSeconds(121);
            Assert.AreEqual(2, WebPubSubServiceClient.GetMinutesToExpire(expiresAfter));
        }

        [Test]
        public void CreateGenerateClientTokenImplRequestTest()
        {
            var client = new WebPubSubServiceClient(string.Format("Endpoint=http://localhost;Port=8080;AccessKey={0};Version=1.0;", FakeAccessKey), "hub");

            var source = new CancellationTokenSource();
            RequestContext context = new() { CancellationToken = source.Token };
            var expectRoles = new[] { "a", "b" };
            var request = client.CreateGenerateClientTokenImplRequest("foo", new[] {"a", "b"}, 1, null, context);

            var url = request.Request.Uri.ToString();
            var queryString = url.Substring(url.IndexOf('?'));

            var uri = HttpUtility.ParseQueryString(queryString);
            Assert.AreEqual("foo", uri.Get("userId"));
            Assert.AreEqual("1", uri.Get("minutesToExpire"));

            var actualRoles = uri.GetValues("role");
            Assert.AreEqual(expectRoles.Length, actualRoles.Length);
            Assert.IsTrue(actualRoles.Contains("a"));
            Assert.IsTrue(actualRoles.Contains("b"));
        }
    }
}

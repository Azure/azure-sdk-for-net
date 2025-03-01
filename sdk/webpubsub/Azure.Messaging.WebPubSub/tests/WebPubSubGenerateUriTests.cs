// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Azure.Core;
using Azure.Identity;
using Moq;
using NUnit.Framework;

namespace Azure.Messaging.WebPubSub.Tests
{
    [TestFixture]
    public class WebPubSubGenerateUriTests
    {
        private const string FakeAccessKey = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789ABCDEFGH";

        private static readonly JwtSecurityTokenHandler s_jwtTokenHandler = new();

        [TestCase(WebPubSubClientProtocol.Default, "/client")]
        [TestCase(WebPubSubClientProtocol.Mqtt, "/clients/mqtt")]
        [TestCase(WebPubSubClientProtocol.SocketIO, "/clients/socketio")]
        public async Task GetClientAccessUri_AccessKey_Test(WebPubSubClientProtocol clientType, string clientUriPrefix)
        {
            var serviceClient = new WebPubSubServiceClient(string.Format("Endpoint=http://localhost;Port=8080;AccessKey={0};Version=1.0;", FakeAccessKey), "hub");
            var expectedUriPrefix = $"ws://localhost:8080{clientUriPrefix}/hubs/hub?access_token=";
            // Synchronize
            Uri sUri = serviceClient.GetClientAccessUri(TimeSpan.FromMinutes(1), default, default, default, clientType, default);
            var token = HttpUtility.ParseQueryString(sUri.Query).Get("access_token");
            Assert.NotNull(token);
            JwtSecurityToken jwt = s_jwtTokenHandler.ReadJwtToken(token);
            var aud = jwt.Claims.FirstOrDefault(s => s.Type == "aud")?.Value;
            Assert.AreEqual($"http://localhost:8080{clientUriPrefix}/hubs/hub", aud);
            Assert.True(sUri.ToString().StartsWith(expectedUriPrefix));
            Assert.True(serviceClient.GetClientAccessUri(DateTimeOffset.UtcNow.AddMinutes(1), default, default, default, clientType, default).ToString().StartsWith(expectedUriPrefix));
            // Asynchronize
            Uri asyncUri = await serviceClient.GetClientAccessUriAsync(TimeSpan.FromMinutes(1), default, default, default, clientType, default);
            var asyncToken = HttpUtility.ParseQueryString(asyncUri.Query).Get("access_token");
            Assert.NotNull(asyncToken);
            JwtSecurityToken asyncJwt = s_jwtTokenHandler.ReadJwtToken(asyncToken);
            var asyncAud = asyncJwt.Claims.FirstOrDefault(s => s.Type == "aud")?.Value;
            Assert.AreEqual($"http://localhost:8080{clientUriPrefix}/hubs/hub", asyncAud);
            Assert.True(asyncUri.ToString().StartsWith(expectedUriPrefix));
            Assert.True((await serviceClient.GetClientAccessUriAsync(DateTimeOffset.Now, default, default, default, clientType, default)).ToString().StartsWith(expectedUriPrefix));
        }

        [TestCase(WebPubSubClientProtocol.Default, "/client", "default")]
        [TestCase(WebPubSubClientProtocol.Mqtt, "/clients/mqtt", "mqtt")]
        [TestCase(WebPubSubClientProtocol.SocketIO, "/clients/socketio", "socketio")]
        public async Task GetClientAccessUri_MicrosoftEntraId_DefaultClient_Test(WebPubSubClientProtocol clientType, string clientUriPrefix, string clientTypeString)
        {
            var serviceClient = new WebPubSubServiceSubClass(new Uri("https://localhost"), "hub", new DefaultAzureCredential());
            var expectedUri = new Uri($"wss://localhost{clientUriPrefix}/hubs/hub?access_token=fakeToken");
            Assert.AreEqual(expectedUri, serviceClient.GetClientAccessUri(TimeSpan.FromMinutes(1), default, default, default, clientType, default));
            Assert.AreEqual(expectedUri, serviceClient.GetClientAccessUri(DateTime.UtcNow, default, default, default, clientType, default));
            Assert.AreEqual(expectedUri, await serviceClient.GetClientAccessUriAsync(TimeSpan.FromMinutes(1), default, default, default, clientType, default));
            Assert.AreEqual(expectedUri, await serviceClient.GetClientAccessUriAsync(DateTime.UtcNow, default, default, default, clientType, default));
            for (var i = 0; i < 4; i++)
            {
                // Validate the "clientType" parameter passed to the GenerateClientTokenImpl(Async) method
                Assert.True(clientTypeString == serviceClient.InvocationParameters[i][4].ToString());
            }
        }

        /// <summary>
        /// A subclass of WebPubSubServiceClient to mock method GenerateClientTokenImpl(Async)
        /// </summary>
        private class WebPubSubServiceSubClass : WebPubSubServiceClient
        {
            public WebPubSubServiceSubClass(Uri endpoint, string hub, TokenCredential credential)
    : base(endpoint, hub, credential)
            {
            }
            public List<object[]> InvocationParameters { get; } = new();
            internal override Task<Response> GenerateClientTokenImplAsync(string userId = null, IEnumerable<string> role = null, int? minutesToExpire = null, IEnumerable<string> group = null, string clientType = null, RequestContext context = null)
            {
                InvocationParameters.Add(new object[] { userId, role, minutesToExpire, group, clientType, context });
                return Task.FromResult(Mock.Of<Response>(r => r.Content == new BinaryData("{\"token\":\"fakeToken\"}")));
            }

            internal override Response GenerateClientTokenImpl(string userId = null, IEnumerable<string> role = null, int? minutesToExpire = null, IEnumerable<string> group = null, string clientType = null, RequestContext context = null)
            {
                InvocationParameters.Add(new object[] { userId, role, minutesToExpire, group, clientType, context });
                return Mock.Of<Response>(r => r.Content == new BinaryData("{\"token\":\"fakeToken\"}"));
            }
        }

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

            Uri uri = serviceClient.GetClientAccessUri(expiresAfter, "foo", null);
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

            Uri uri = serviceClient.GetClientAccessUri(expireAt, "foo", null);
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
            var request = client.CreateGenerateClientTokenImplRequest("foo", new[] { "a", "b" }, 1, null, "default", context);

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

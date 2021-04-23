// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

using NUnit.Framework;

namespace Azure.Messaging.WebPubSub.Tests
{
    [TestFixture]
    public class WebPubSubParseConnectionStringTests
    {
        private static readonly JwtSecurityTokenHandler JwtTokenHandler = new JwtSecurityTokenHandler();

        [TestCase("Endpoint=https://host;{0};Version=1.0;", "https://host", "abcdefg")]
        [TestCase("Endpoint=http://host;{0};Version=1.0;", "http://host", "abcdefg")]
        [TestCase("Endpoint=http://host;{0};Version=1.0;Port=8080;", "http://host:8080", "abcdefg")]
        [TestCase("{0};Endpoint=http://host;Version=1.0;", "http://host", "abcdefg")]
        public void ParseConnectionStringTests(string connectionString, string url, string key)
        {
            connectionString = string.Format(connectionString, $"AccessKey={key}"); // this is so that credscan is not triggered.
            var (uri, credential) = WebPubSubServiceClient.ParseConnectionString(connectionString);
            Assert.AreEqual(new Uri(url), uri);
            Assert.AreEqual(key, credential.Key);
        }

        [TestCase("Endpoint=http://localhost;Port=8080;AccessKey=ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789ABCDEFGH;Version=1.0;")]
        public void TestGenerateUriUseSameKidWithSameKey(string connectionString)
        {
            var serviceClient = new WebPubSubServiceClient(" Endpoint=http://localhost;Port=8080;AccessKey=ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789ABCDEFGH;Version=1.0;", "hub");
            var uri1 = serviceClient.GetClientAccessUri();
            var uri2 = serviceClient.GetClientAccessUri();

            Assert.AreEqual("localhost:8080", uri1.Authority);
            Assert.AreEqual("/client/hubs/hub", uri1.AbsolutePath);
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

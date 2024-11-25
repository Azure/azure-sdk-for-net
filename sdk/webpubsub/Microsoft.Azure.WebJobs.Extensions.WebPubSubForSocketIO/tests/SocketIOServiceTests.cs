// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure;
using Azure.Identity;
using Azure.Messaging.WebPubSub;
using Microsoft.Azure.WebJobs.Extensions.WebPubSubForSocketIO.Config;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSubForSocketIO.Tests
{
    public class SocketIOServiceTests
    {
        private const string NormConnectionString = "Endpoint=http://localhost;Port=8080;AccessKey=ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789ABCDEFGH;Version=1.0;";
        private const string SecConnectionString = "Endpoint=https://abc;AccessKey=ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789ABCDEFGH;Version=1.0;";

        [TestCase(NormConnectionString, "http://localhost:8080/", "/clients/socketio/hubs/testHub", null)]
        [TestCase(NormConnectionString, "http://localhost:8080/", "/clients/socketio/hubs/testHub", "uid")]
        [TestCase(SecConnectionString, "https://abc/", "/clients/socketio/hubs/testHub", "uid")]
        public void TestWebPubSubConnection_Scheme(string connectionString, string expectedEndpoint, string expectedPath, string userId)
        {
            var connectionInfo = new SocketIOConnectionInfo(connectionString);

            Assert.NotNull(connectionInfo.KeyCredential);
            Assert.AreEqual(connectionString, connectionInfo.ConnectionString);
            Assert.AreEqual(expectedEndpoint, connectionInfo.Endpoint.ToString());
            Assert.Null(connectionInfo.TokenCredential);

            var service = new WebPubSubForSocketIOService(connectionInfo.Endpoint, connectionInfo.KeyCredential, "testHub");

            var clientConnection = service.GetNegotiationResult(userId);

            Assert.NotNull(clientConnection);
            Assert.AreEqual(expectedEndpoint, clientConnection.Endpoint.AbsoluteUri);
            Assert.AreEqual(expectedPath, clientConnection.Path);
            Assert.NotNull(clientConnection.Token);

            var jwt = new JwtSecurityTokenHandler().ReadJwtToken(clientConnection.Token);

            if (string.IsNullOrEmpty(userId))
            {
                Assert.IsNull(jwt.Subject);
            }
            else
            {
                Assert.AreEqual(userId, jwt.Subject);
            }
        }

        [TestCase]
        public void TestValidationOptionsParser()
        {
            var testconnection = "Endpoint=http://abc;Port=888;AccessKey=ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789ABCDEFGH==A;Version=1.0;";
            var info = new SocketIOConnectionInfo(testconnection);

            var configs = new WebPubSubValidationOptions(info);

            Assert.IsTrue(configs.TryGetKey("abc", out var key));
            Assert.AreEqual("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789ABCDEFGH==A", key);
        }

        [TestCase("http://localhost:8080/", "localhost")]
        [TestCase("https://abc.com/", "abc.com")]
        public void TestValidAadSchema(string endpoint, string host)
        {
            var info = new SocketIOConnectionInfo(endpoint, new DefaultAzureCredential());

            Assert.Null(info.KeyCredential);
            Assert.Null(info.ConnectionString);
            Assert.AreEqual(endpoint, info.Endpoint.ToString());
            Assert.NotNull(info.TokenCredential);

            var configs = new WebPubSubValidationOptions(info);

            Assert.IsTrue(configs.TryGetKey(host, out var key));
            Assert.Null(key);
        }

        [TestCase("https://sio-5kkfcgr2obqvm.webpubsub.azure.com/")]
        [TestCase("https://sio-5kkfcgr2obqvm.webpubsub.azure.com")]
        public void TestNegotiateResultForAad(string uri)
        {
            var token = "eyJhbGciOiJIUzI1NiIsImtpZCI6InMtZjZlMTVhZmItNjIxZS00OTc5LTgyZTgtN2FiMGQ4ZmIwMDM1IiwidHlwIjoiSldUIn0.eyJuYmYiOjE3MjcwNzAxODQsImV4cCI6MTcyNzA3MzcyNCwiaWF0IjoxNzI3MDcwMTg0LCJpc3MiOiJodHRwczovL3dlYnB1YnN1Yi5henVyZS5jb20iLCJhdWQiOiJodHRwczovL3Npby01a2tmY2dyMm9icXZtLndlYnB1YnN1Yi5henVyZS5jb20vY2xpZW50cy9zb2NrZXRpby9odWJzL2h1YiJ9.h3QkRTQ4";
            var clientMoc = new Mock<WebPubSubServiceClient>();
            clientMoc.Setup(c => c.GetClientAccessUri(It.IsAny<TimeSpan>(), It.IsAny<string>(), It.IsAny<IEnumerable<string>>(), It.IsAny<IEnumerable<string>>(), It.IsAny<WebPubSubClientProtocol>(), It.IsAny<CancellationToken>()))
                .Returns(new Uri($"https://abc.com?access_token={token}"));
            clientMoc.Setup(c => c.Hub).Returns("hub");
            clientMoc.Setup(c => c.Endpoint).Returns(new Uri(uri));

            var service = new WebPubSubForSocketIOService(clientMoc.Object);
            var result = service.GetNegotiationResult("user");

            Assert.AreEqual("https://sio-5kkfcgr2obqvm.webpubsub.azure.com/", result.Endpoint.AbsoluteUri);
            Assert.AreEqual("/clients/socketio/hubs/hub", result.Path);
            Assert.AreEqual(token, result.Token);
        }

        [Test]
        public void TestNegotiationResultForKey()
        {
            var clientMoc = new Mock<WebPubSubServiceClient>();
            clientMoc.Setup(c => c.Hub).Returns("hub");
            clientMoc.Setup(c => c.Endpoint).Returns(new Uri("https://abc.com"));

            var service = new WebPubSubForSocketIOService(clientMoc.Object, new AzureKeyCredential("abcdefghijklmn"));
            var result = service.GetNegotiationResult("user");

            Assert.AreEqual("https://abc.com/", result.Endpoint.AbsoluteUri);
            Assert.AreEqual("/clients/socketio/hubs/hub", result.Path);

            var jwt = new JwtSecurityTokenHandler().ReadJwtToken(result.Token);
            Assert.AreEqual("user", jwt.Subject);
            Assert.AreEqual("https://abc.com/clients/socketio/hubs/hub", jwt.Audiences.First());
        }
    }
}

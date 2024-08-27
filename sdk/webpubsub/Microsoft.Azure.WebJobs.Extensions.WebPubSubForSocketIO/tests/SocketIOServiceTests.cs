// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Core;
using Azure.Identity;
using Microsoft.Azure.WebJobs.Extensions.WebPubSubForSocketIO.Config;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSubForSocketIO.Tests
{
    public class SocketIOServiceTests
    {
        private const string NormConnectionString = "Endpoint=http://localhost;Port=8080;AccessKey=ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789ABCDEFGH;Version=1.0;";
        private const string SecConnectionString = "Endpoint=https://abc;AccessKey=ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789ABCDEFGH;Version=1.0;";

        [TestCase(NormConnectionString, "http://localhost:8080/", "/clients/socketio/hubs/testHub")]
        [TestCase(SecConnectionString, "https://abc/", "/clients/socketio/hubs/testHub")]
        public void TestWebPubSubConnection_Scheme(string connectionString, string expectedEndpoint, string expectedPath)
        {
            var connectionInfo = new SocketIOConnectionInfo(connectionString);

            Assert.NotNull(connectionInfo.KeyCredential);
            Assert.AreEqual(connectionString, connectionInfo.ConnectionString);
            Assert.AreEqual(expectedEndpoint, connectionInfo.Endpoint.ToString());
            Assert.Null(connectionInfo.TokenCredential);

            var service = new WebPubSubForSocketIOService(connectionInfo.Endpoint, connectionInfo.KeyCredential, "testHub");

            var clientConnection = service.GetNegotiationResult();

            Assert.NotNull(clientConnection);
            Assert.AreEqual(expectedEndpoint, clientConnection.Endpoint.AbsoluteUri);
            Assert.AreEqual(expectedPath, clientConnection.Path);
            Assert.NotNull(clientConnection.Token);
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
    }
}

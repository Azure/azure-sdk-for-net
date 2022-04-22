// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub.Tests
{
    public class WebPubSubServiceTests
    {
        private const string NormConnectionString = "Endpoint=http://localhost;Port=8080;AccessKey=ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789ABCDEFGH;Version=1.0;";
        private const string SecConnectionString = "Endpoint=https://abc;AccessKey=ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789ABCDEFGH;Version=1.0;";

        [TestCase(NormConnectionString, "ws://localhost:8080/client/hubs/testHub")]
        [TestCase(SecConnectionString, "wss://abc/client/hubs/testHub")]
        public void TestWebPubSubConnection_Scheme(string connectionString, string expectedBaseUrl)
        {
            var service = new WebPubSubService(connectionString, "testHub");

            var clientConnection = service.GetClientConnection();

            Assert.NotNull(clientConnection);
            Assert.AreEqual(expectedBaseUrl, clientConnection.BaseUri.AbsoluteUri);
            Assert.NotNull(clientConnection.AccessToken);

            var absoluteUrl = $"{expectedBaseUrl}?access_token={clientConnection.AccessToken}";
            Assert.AreEqual(absoluteUrl, clientConnection.Uri.AbsoluteUri);
        }

        [TestCase]
        public void TestValidationOptionsParser()
        {
            var testconnection = "Endpoint=http://abc;Port=888;AccessKey=ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789ABCDEFGH==A;Version=1.0;";
            var configs = new WebPubSubValidationOptions(testconnection);

            Assert.IsTrue(configs.TryGetKey("abc", out var key));
            Assert.AreEqual("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789ABCDEFGH==A", key);
        }

        [TestCase]
        public void TestValidationOptionsWithoutAccessKey()
        {
            var testconnection = "Endpoint=http://abc;Version=1.0;";
            var configs = new WebPubSubValidationOptions(testconnection);

            Assert.IsTrue(configs.TryGetKey("abc", out var key));
            Assert.Null(key);
        }
    }
}

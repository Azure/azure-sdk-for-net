// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Xunit;

namespace Microsoft.Azure.WebJobs.Extensions.WebPubSub.Tests
{
    public class WebPubSubServiceTests
    {
        private const string NormConnectionString = "Endpoint=http://localhost;Port=8080;AccessKey=ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789ABCDEFGH;Version=1.0;";
        private const string SecConnectionString = "Endpoint=https://abc;AccessKey=ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789ABCDEFGH;Version=1.0;";

        [Theory]
        [InlineData(NormConnectionString, "ws://localhost:8080/client/hubs/testHub")]
        [InlineData(SecConnectionString, "wss://abc/client/hubs/testHub")]
        public void TestWebPubSubConnection_Scheme(string connectionString, string expectedBaseUrl)
        {
            var service = new WebPubSubService(connectionString, "testHub");

            var clientConnection = service.GetClientConnection();

            Assert.NotNull(clientConnection);
            Assert.Equal(expectedBaseUrl, clientConnection.BaseUrl);
        }

        [Fact]
        public void TestConfigParser()
        {
            var testconnection = "Endpoint=http://abc;Port=888;AccessKey=ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789ABCDEFGH==A;Version=1.0;";
            var configs = new ServiceConfigParser(testconnection);

            Assert.Equal("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789ABCDEFGH==A", configs.AccessKey);
            Assert.Equal("http://abc/", configs.Endpoint.ToString());
            Assert.Equal(888, configs.Port);
        }
    }
}

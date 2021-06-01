using Microsoft.Azure.CognitiveServices.Knowledge.QnAMaker;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace QnAMaker.Tests
{
    public class QnAMakerEndpointKeysTests: BaseTests
    {
        [Fact]
        public void QnAMakerEndpointKeysGetEnpointKeys()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "QnAMakerEndpointKeysGetEnpointKeys");

                IQnAMakerClient client = GetQnAMakerClient(HttpMockServer.CreateInstance());
                var keys = client.EndpointKeys.GetKeysAsync().Result;
                Assert.NotEmpty(keys.PrimaryEndpointKey);
                Assert.NotEmpty(keys.SecondaryEndpointKey);
            }
        }

        [Fact]
        public void QnAMakerEndpointKeysRefreshKeys()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "QnAMakerEndpointKeysRefreshKeys");

                IQnAMakerClient client = GetQnAMakerClient(HttpMockServer.CreateInstance());
                var keys = client.EndpointKeys.RefreshKeysAsync("SecondaryKey").Result;
                Assert.NotEmpty(keys.PrimaryEndpointKey);
                Assert.NotEmpty(keys.SecondaryEndpointKey);
            }
        }
    }
}

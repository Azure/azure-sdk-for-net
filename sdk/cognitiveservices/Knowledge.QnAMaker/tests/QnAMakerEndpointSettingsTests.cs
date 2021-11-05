using Microsoft.Azure.CognitiveServices.Knowledge.QnAMaker;
using Microsoft.Azure.CognitiveServices.Knowledge.QnAMaker.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace QnAMaker.Tests
{
    public class QnAMakerEndpointSettingsTests : BaseTests
    {
        [Fact]
        public void QnAMakerEndpointSettingsReadUpdate()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "QnAMakerEndpointSettingsReadUpdate");
                IQnAMakerClient client = GetQnAMakerClient(HttpMockServer.CreateInstance());

                client.EndpointSettings.UpdateSettingsAsync(new EndpointSettingsDTO
                {
                    ActiveLearning = new EndpointSettingsDTOActiveLearning()
                    {
                        Enable = "true"
                    }
                }).Wait();


                // Read
                var endpointSettings = client.EndpointSettings.GetSettingsAsync().Result;
                Assert.True(bool.Parse(endpointSettings.ActiveLearning.Enable));
            }
        }
    }
}

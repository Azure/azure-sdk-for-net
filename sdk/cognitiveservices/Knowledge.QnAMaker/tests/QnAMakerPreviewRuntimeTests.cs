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
    public class QnAMakerPreviewRuntimeTests : BaseTests
    {
        [Fact]
        public void QnAMakerPreviewRuntimeGenerateAnswerTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "QnAMakerPreviewRuntimeGenerateAnswerTest");

                var client = GetQnAMakerPreviewRuntimeClient(HttpMockServer.CreateInstance());
                var queryDTO = new QueryDTO();
                queryDTO.Question = "new question";
                queryDTO.IsTest = true;
                var answer = client.Runtime.GenerateAnswerAsync("192233e1-0ec8-44dc-8285-57a541b7c79c", queryDTO).Result;
                Assert.Equal(1, answer.Answers.Count);
                Assert.Equal(100, answer.Answers[0].Score);
            }
        }
    }
}

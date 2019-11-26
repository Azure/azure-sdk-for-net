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
    public class QnAMakerRuntimeTests: BaseTests
    {
        [Fact]
        public void QnAMakerRuntimeGenerateAnswerTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "QnAMakerRuntimeGenerateAnswerTest");

                var client = GetQnAMakerRuntimeClient(HttpMockServer.CreateInstance());
                var answer = client.Runtime.GenerateAnswer("8758c6af-fa29-4e03-a517-9c36927f558f", new QueryDTO(question: "good afternoon"));
                Assert.Equal(1, answer.Answers.Count);
                Assert.Equal(100, answer.Answers[0].Score);
            }
        }
    }
}

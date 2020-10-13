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

                var client = GetQnAMakerClient(HttpMockServer.CreateInstance());
                var queryDTO = new QueryDTO();
                queryDTO.Question = "hi there";
                queryDTO.IsTest = true;
                queryDTO.Top = 10;
                queryDTO.AnswerSpanRequest = new QueryDTOAnswerSpanRequest
                {
                    Enable = true,
                    ScoreThreshold = 10.0,
                    TopAnswersWithSpan = 3
                };

                queryDTO.Context = new QueryDTOContext
                {
                    PreviousQnaId = -1,
                    PreviousUserQuery = ""
                };
               var answer = client.Knowledgebase.GenerateAnswerAsync("0667a3c4-fd61-4f13-9ada-a7fc0e257112", queryDTO).Result;

                Assert.Equal(6, answer.Answers.Count);
                Assert.True(answer.Answers[0].Score > 95);
              
            }
        }
    }
}

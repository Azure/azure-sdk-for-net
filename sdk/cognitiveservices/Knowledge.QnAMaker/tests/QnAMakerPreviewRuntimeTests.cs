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
        private static readonly string KbId = "0667a3c4-fd61-4f13-9ada-a7fc0e257112";

        [Fact]
        public void QnAMakerPreviewRuntimeGenerateAnswerTest()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "QnAMakerPreviewRuntimeGenerateAnswerTest");

                var client = GetQnAMakerClient(HttpMockServer.CreateInstance());
                var queryDTO = new QueryDTO();
                queryDTO.Question = "new question";
                queryDTO.Top = 3;
                queryDTO.IsTest = true;
                queryDTO.AnswerSpanRequest = new QueryDTOAnswerSpanRequest()
                {
                    Enable = true,
                    ScoreThreshold = 5.0,
                    TopAnswersWithSpan = 1
                };

                var answer = client.Knowledgebase.GenerateAnswerAsync(KbId , queryDTO).Result;
                Assert.Equal(1, answer.Answers.Count);
                Assert.NotEmpty(answer.Answers[0].AnswerSpan.Text);                
                Assert.Equal(100, answer.Answers[0].Score);
            }
        }
    }
}

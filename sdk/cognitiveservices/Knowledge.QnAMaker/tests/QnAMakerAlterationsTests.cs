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
    public class QnAMakerAlterationsTests: BaseTests
    {
        [Fact(Skip="https://github.com/Azure/azure-sdk-for-net/issues/6210")]
        public void QnAMakerAlterationsReadUpdate()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "QnAMakerAlterationsReadUpdate");
                IQnAMakerClient client = GetQnAMakerClient(HttpMockServer.CreateInstance());

                client.Alterations.ReplaceAsync(new WordAlterationsDTO
                {
                    WordAlterations = new List<AlterationsDTO>
                    {
                        new AlterationsDTO
                        {
                            Alterations = new List<string>{ "qnamaker", "qna maker"}
                        }
                    }
                }).Wait();


                // Read
                var alterations = client.Alterations.GetAsync().Result;
                Assert.Equal(1, alterations.WordAlterations.Count);
                Assert.True(alterations.WordAlterations[0].Alterations.Contains("qnamaker"));
            }
        }
    }
}

using Azure.AI.Personalizer.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;
using System.Collections.Generic;
using System;
using Azure.AI.Personalizer;
using System.Threading.Tasks;

namespace Microsoft.Azure.AI.Personalizer.Tests
{
    public class EvaluationsTests : BaseTests
    {
        [Fact]
        public void GetEvaluations()
        {
            using (MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "GetEvaluations");
                EvaluationsRestClient client = GetEvaluationsClient(HttpMockServer.CreateInstance());
                IList<Evaluation> evaluations = (IList<Evaluation>)client.List();
                Assert.True(evaluations.Count > 0);
                Assert.Equal("myFirstEvaluation", evaluations[0].Name);
            }
        }

        [Fact]
        public void CreateEvaluation()
        {
            using (MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "CreateEvaluation");
                EvaluationsRestClient client = GetEvaluationsClient(HttpMockServer.CreateInstance());
                var evaluation = new EvaluationContract(
                    name: "myFirstEvaluation",
                    startTime: new DateTime(2018, 12, 19),
                    endTime: new DateTime(2019, 1, 19),
                    policies: new PolicyContract[]
                    {
                        new PolicyContract(name: "Custom Policy 1", arguments: "--cb_explore_adf --epsilon 0.2 --dsjson --cb_type ips -l 0.5 --l1 1E-07 --power_t 0.5")
                    });
                evaluation.EnableOfflineExperimentation = true;
                Evaluation createdEvaluation = client.Create(evaluation);
                Assert.Equal(evaluation.Name, createdEvaluation.Name);
            }
        }

        [Fact]
        public void GetEvaluation()
        {
            using (MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "GetEvaluation");
                EvaluationsRestClient client = GetEvaluationsClient(HttpMockServer.CreateInstance());
                string evaluationId = "014fd077-b5ab-495b-8ef9-f6d2dce9c624";
                Evaluation evaluation = client.Get(evaluationId);
                Assert.Equal(evaluationId, evaluation.Id);
            }
        }

        [Fact]
        public void DeleteEvaluation()
        {
            using (MockContext.Start(this.GetType()))
            {
                HttpMockServer.Initialize(this.GetType(), "DeleteEvaluation");
                EvaluationsRestClient client = GetEvaluationsClient(HttpMockServer.CreateInstance());
                string evaluationId = "b58c6d92-b727-48c1-9487-4be2782c9e0a";
                client.Delete(evaluationId);
            }
        }
    }
}

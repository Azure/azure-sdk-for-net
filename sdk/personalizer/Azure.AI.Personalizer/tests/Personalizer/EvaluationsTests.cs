#pragma warning disable SA1636 // File header copyright text should match
//Copyright(c) Microsoft Corporation.All rights reserved.
#pragma warning restore SA1636 // File header copyright text should match
//Licensed under the MIT License.

//using System;
//using System.Collections.Generic;
//using System.Threading.Tasks;
//using NUnit.Framework;

//namespace Azure.AI.Personalizer.Tests
//{
//    public class EvaluationsTests : PersonalizerTestBase
//    {
//        public EvaluationsTests(bool isAsync) : base(isAsync)
//        {
//        }
//        private const string EvaluationName = "SDKEvaluation";

//        [Test]
//        public async Task EvaluationTests()
//        {
//            System.Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Record");
//            System.Environment.SetEnvironmentVariable("PERSONALIZER_API_KEY_SINGLE_SLOT", "d039cfb6669b4297a002e263db501a12");
//            System.Environment.SetEnvironmentVariable("PERSONALIZER_ENDPOINT_SINGLE_SLOT", "https://ormichaeevaluations.ppe.cognitiveservices.azure.com/");
//            PersonalizerAdministrationClient client = GetAdministrationClient(isSingleSlot: true);
//            string evaluationId = "123456789";
//            await SubmitEvaluation(client);
//            await ApplyEvaluation(client, evaluationId);
//            await GetEvaluation(client, evaluationId);
//            await GetEvaluations(client);
//            await DeleteEvaluation(client, evaluationId);
//        }

//#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
//        private async Task SubmitEvaluation(PersonalizerAdministrationClient client)
//#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
//        {
//            var evaluation = new PersonalizerEvaluationOptions(
//                name: EvaluationName,
//                startTime: DateTime.SpecifyKind(new DateTime(2021, 08, 01), DateTimeKind.Utc),
//                endTime: DateTime.SpecifyKind(new DateTime(2120, 08, 01), DateTimeKind.Utc),
//                policies: new PersonalizerPolicy[]
//                {
//                    new PersonalizerPolicy(name: "CustomPolicy1", arguments: "--cb_explore_adf --epsilon 0.2 --dsjson --cb_type ips -l 0.5 --l1 1E-07 --power_t 0.5")
//                });
//            evaluation.EnableOfflineExperimentation = true;
//            try
//            {
//                var eval = await client.CreatePersonalizerEvaluationAsync(evaluation);
//            }
//            catch (Exception e)
//            {
//                Assert.Equals("No logs exist in date range.", e.Message);
//            }
//            var ex = Assert.ThrowsAsync<Exception>(async () => await client.CreatePersonalizerEvaluationAsync(evaluation));
//            Assert.AreEqual("No logs exist in date range.", ex.Message);
//        }

//        private async Task ApplyEvaluation(PersonalizerAdministrationClient client, string evaluationId)
//        {
//            apply policy from evaluation
//            PersonalizerPolicyReferenceOptions policyReferenceContract = new PersonalizerPolicyReferenceOptions(evaluationId, "Hyper1");
//            await client.ApplyPersonalizerEvaluationAsync(policyReferenceContract);
//        }

//        private async Task GetEvaluation(PersonalizerAdministrationClient client, string evaluationId)
//        {
//            PersonalizerEvaluation evaluation = await client.GetPersonalizerEvaluationAsync(evaluationId);
//            Assert.AreEqual(evaluationId, evaluation.Id);
//        }

//        private async Task GetEvaluations(PersonalizerAdministrationClient client)
//        {
//            AsyncPageable<PersonalizerEvaluation> evaluations = client.GetPersonalizerEvaluationsAsync();
//            int numEvaluations = 0;
//            PersonalizerEvaluation eval0 = null;
//            await foreach (PersonalizerEvaluation evaluation in evaluations)
//            {
//                numEvaluations++;
//                if (numEvaluations == 1)
//                {
//                    eval0 = evaluation;
//                    break;
//                }
//            }
//            Assert.NotNull(eval0);
//            Assert.AreEqual("PersonalizerEvaluation", eval0.GetType().Name);
//            Assert.AreEqual("Azure.AI.Personalizer.PersonalizerEvaluation", eval0.GetType().FullName);
//            var policyResult = eval0.PolicyResults;
//            Assert.AreEqual("CustomPolicy1", policyResult[0].Name);
//            Assert.AreEqual(EvaluationName, eval0.Name);
//        }

//        private async Task DeleteEvaluation(PersonalizerAdministrationClient client, string evaluationId)
//        {
//            await client.DeletePersonalizerEvaluationAsync(evaluationId);
//        }

//        private async Task SendNRankRequests(int n)
//        {
////            PersonalizerClient client = await GetPersonalizerClientAsync(isSingleSlot: true, shouldSetProperties: true);
//            IList<object> contextFeatures = new List<object>() {
//            new { Features = new { day = "tuesday", time = "night", weather = "rainy" } },
//            new { Features = new { userId = "1234", payingUser = true, favoriteGenre = "documentary", hoursOnSite = 0.12, lastwatchedType = "movie" } }
//            };
//            IList<PersonalizerRankableAction> actions = new List<PersonalizerRankableAction>();
//            actions.Add(
//                new PersonalizerRankableAction(
//                    id: "Person1",
//                    features:
//                    new List<object>() { new { videoType = "documentary", videoLength = 35, director = "CarlSagan" }, new { mostWatchedByAge = "30-35" } }
//            ));
//            actions.Add(
//                new PersonalizerRankableAction(
//                    id: "Person2",
//                    features:
//                        new List<object>() { new { videoType = "documentary", videoLength = 35, director = "CarlSagan" }, new { mostWatchedByAge = "40-45" } }
//            ));

//            for (int i = 0; i < n; i++)
//            {
//                await client.RankAsync(actions, contextFeatures);
//            }
//        }
//    }
//}

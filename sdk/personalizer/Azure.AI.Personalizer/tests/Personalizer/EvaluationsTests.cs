// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.AI.Personalizer.Tests
{
    public class EvaluationsTests : PersonalizerTestBase
    {
        public EvaluationsTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public async Task GetEvaluations()
        {
            PersonalizerAdministrationClient client = GetPersonalizerAdministrationClient();
            AsyncPageable<PersonalizerEvaluation> evaluations = client.GetPersonalizerEvaluationsAsync();
            int numEvaluations = 0;
            PersonalizerEvaluation eval0 = null;
            PersonalizerEvaluation eval1 = null;
            await foreach (PersonalizerEvaluation evaluation in evaluations)
            {
                numEvaluations++;
                if (numEvaluations == 1)
                {
                    eval0 = evaluation;
                }
                else if (numEvaluations == 2)
                {
                    eval1 = evaluation;
                    break;
                }
            }
            Assert.NotNull(eval0);
            Assert.NotNull(eval1);
            Assert.AreEqual("PersonalizerEvaluation", eval0.GetType().Name);
            Assert.AreEqual("Azure.AI.Personalizer.PersonalizerEvaluation", eval0.GetType().FullName);
            Assert.False(evaluations.Equals(eval1));
            var policyResult = eval0.PolicyResults;
            Assert.AreEqual(1, policyResult.Count);
            Assert.AreEqual("Custom Policy 1", policyResult[0].Name);
            Assert.AreEqual(0, policyResult[0].Summary.Count);
            Assert.AreEqual(85, policyResult[0].Arguments.Length);
            Assert.Null(policyResult[0].PolicySource);
            Assert.Null(policyResult[0].TotalSummary);
            Assert.AreEqual("myFirstEvaluation", eval0.Name);
        }

        [Test]
        public async Task CreateEvaluation()
        {
            PersonalizerAdministrationClient client = GetPersonalizerAdministrationClient();
            var evaluation = new PersonalizerEvaluationOptions(
                name: "sdkTestEvaluation",
                startTime: DateTime.SpecifyKind(new DateTime(2021, 06, 01), DateTimeKind.Utc),
                endTime: DateTime.SpecifyKind(new DateTime(2021, 06, 30), DateTimeKind.Utc),
                policies: new PersonalizerPolicy[]
                {
                    new PersonalizerPolicy(name: "Custom Policy 1", arguments: "--cb_explore_adf --epsilon 0.2 --dsjson --cb_type ips -l 0.5 --l1 1E-07 --power_t 0.5")
                });
            evaluation.EnableOfflineExperimentation = true;
            PersonalizerCreateEvaluationOperation createdEvaluation = await client.CreatePersonalizerEvaluationAsync(evaluation);
            await createdEvaluation.WaitForCompletionAsync();
            Assert.AreEqual(evaluation.Name, createdEvaluation.Value.Name);
        }

        [Test]
        public async Task GetEvaluation()
        {
            PersonalizerAdministrationClient client = GetPersonalizerAdministrationClient();
            string evaluationId = "014fd077-b5ab-495b-8ef9-f6d2dce9c624";
            PersonalizerEvaluation evaluation = await client.GetPersonalizerEvaluationAsync(evaluationId);
            Assert.AreEqual(evaluationId, evaluation.Id);
        }

        [Test]
        public async Task DeleteEvaluation()
        {
            PersonalizerAdministrationClient client = GetPersonalizerAdministrationClient();
            string evaluationId = "b58c6d92-b727-48c1-9487-4be2782c9e0a";
            await client.DeletePersonalizerEvaluationAsync(evaluationId);
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.AI.Personalizer.Models;
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
            PersonalizerClient client = GetPersonalizerClient();
            List<Evaluation> evaluations = (List<Evaluation>)await client.Evaluations.ListAsync();
            Assert.True(evaluations.Count > 0);
            Assert.AreEqual("Evaluation", evaluations[0].GetType().Name);
            Assert.AreEqual("Azure.AI.Personalizer.Models.Evaluation", evaluations[0].GetType().FullName);
            Assert.False(evaluations[0].Equals(evaluations[1]));
            var policyResult = evaluations[0].PolicyResults;
            Assert.AreEqual(1, policyResult.Count);
            Assert.AreEqual("Custom Policy 1", policyResult[0].Name);
            Assert.AreEqual(0, policyResult[0].Summary.Count);
            Assert.AreEqual(85, policyResult[0].Arguments.Length);
            Assert.Null(policyResult[0].PolicySource);
            Assert.Null(policyResult[0].TotalSummary);
            Assert.AreEqual("myFirstEvaluation", evaluations[0].Name);
        }

        [Test]
        public async Task CreateEvaluation()
        {
            PersonalizerClient client = GetPersonalizerClient();
            var evaluation = new EvaluationContract(
                name: "myFirstEvaluation",
                startTime: new DateTime(2018, 12, 19),
                endTime: new DateTime(2019, 1, 19),
                policies: new PolicyContract[]
                {
                    new PolicyContract(name: "Custom Policy 1", arguments: "--cb_explore_adf --epsilon 0.2 --dsjson --cb_type ips -l 0.5 --l1 1E-07 --power_t 0.5")
                });
            evaluation.EnableOfflineExperimentation = true;
            Evaluation createdEvaluation = await client.Evaluations.CreateAsync(evaluation);
            Assert.AreEqual(evaluation.Name, createdEvaluation.Name);
        }

        [Test]
        public async Task GetEvaluation()
        {
            PersonalizerClient client = GetPersonalizerClient();
            string evaluationId = "014fd077-b5ab-495b-8ef9-f6d2dce9c624";
            Evaluation evaluation = await client.Evaluations.GetAsync(evaluationId);
            Assert.AreEqual(evaluationId, evaluation.Id);
        }

        [Test]
        public async Task DeleteEvaluation()
        {
            PersonalizerClient client = GetPersonalizerClient();
            string evaluationId = "b58c6d92-b727-48c1-9487-4be2782c9e0a";
            await client.Evaluations.DeleteAsync(evaluationId);
        }
    }
}

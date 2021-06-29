// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
        public void GetEvaluations()
        {
            PersonalizerClient client = GetPersonalizerClient();
            var evaluations = client.Evaluations.List().Value;
            Assert.True(evaluations.Count > 0);
            Assert.AreEqual("myFirstEvaluation", evaluations[0].Name);
        }

        [Test]
        public void CreateEvaluation()
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
            Evaluation createdEvaluation = client.Evaluations.Create(evaluation);
            Assert.AreEqual(evaluation.Name, createdEvaluation.Name);
        }

        [Test]
        public void GetEvaluation()
        {
            PersonalizerClient client = GetPersonalizerClient();
            string evaluationId = "014fd077-b5ab-495b-8ef9-f6d2dce9c624";
            Evaluation evaluation = client.Evaluations.Get(evaluationId);
            Assert.AreEqual(evaluationId, evaluation.Id);
        }

        [Test]
        public void DeleteEvaluation()
        {
            PersonalizerClient client = GetPersonalizerClient();
            string evaluationId = "b58c6d92-b727-48c1-9487-4be2782c9e0a";
            client.Evaluations.Delete(evaluationId);
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.AI.Personalizer.Models;
using NUnit.Framework;

namespace Azure.AI.Personalizer.Tests
{
    public class EvaluationTests: PersonalizerTestBase
    {
        public EvaluationTests(bool isAsync): base(isAsync)
        {
        }

        [Test]
        public async Task ApplyEvaluation()
        {
            PersonalizerClient client = GetPersonalizerClient();
            PolicyReferenceContract policyReferenceContract = new PolicyReferenceContract("628a6299-ce45-4a9d-98a6-017c2c9ff008", "Inter-len1");
            await client.Evaluation.ApplyAsync(policyReferenceContract);
        }
    }
}

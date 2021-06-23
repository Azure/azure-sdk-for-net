using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.AI.Personalizer;
using Azure.AI.Personalizer.Models;
using NUnit.Framework;

namespace Microsoft.Azure.AI.Personalizer.Tests
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

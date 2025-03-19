// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Provisioning.Expressions;
using Azure.Provisioning.Primitives;
using Azure.Provisioning.CognitiveServices;
using NUnit.Framework;

namespace Azure.Provisioning.Tests.Expressions
{
    public class IndexExpressionTests
    {
        [Test]
        public void ValidateIndexExpressionWithStringLiteral()
        {
            CognitiveServicesAccount ai = new(nameof(ai));

            Infrastructure infra = new();
            infra.Add(ai);

            var inferenceEndpoint = new IndexExpression(
                (BicepExpression)ai.Properties.Endpoints!,
                "Azure AI Model Inference API");
            infra.Add(new ProvisioningOutput("connectionString", typeof(string))
            {
                Value = BicepFunction.Interpolate($"Endpoint={inferenceEndpoint}")
            });

            ProvisioningPlan plan = infra.Build();
            string bicep = plan.Compile().First().Value;
            Console.WriteLine(bicep);
        }
    }
}

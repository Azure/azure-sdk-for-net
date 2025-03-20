// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Provisioning.Expressions;
using NUnit.Framework;

namespace Azure.Provisioning.Tests.Expressions
{
    public class InterpolatedStringExpressionTest
    {
        [TestCaseSource(nameof(stringInterpolationTestData))]
        public string ValidateStringInterpolationWithStringLiteral(BicepValue<string> expression)
        {
            return expression.ToString();
        }

        private static IEnumerable<TestCaseData> stringInterpolationTestData
        {
            get
            {
                // test provisionable variable
                var variable = new ProvisioningVariable("v", typeof(string));
                yield return new TestCaseData(
                    BicepFunction.Interpolate(
                        $"Var={new ProvisioningVariable("v", typeof(string))}"
                        ))
                {
                    ExpectedResult = "Var=${v}"
                };

                // test index expression in interpolation
                yield return new TestCaseData(
                    BicepFunction.Interpolate(
                        $"Endpoint={new IndexExpression(
                            new IdentifierExpression("dict"),
                            new StringLiteralExpression("test")
                        )}"))
                {
                    ExpectedResult = "'Endpoint=${dict['test']}'"
                };
            }
        }
    }
}

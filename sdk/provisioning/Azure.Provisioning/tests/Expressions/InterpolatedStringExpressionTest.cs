// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Provisioning.Expressions;
using NUnit.Framework;

namespace Azure.Provisioning.Tests.Expressions
{
    public class InterpolatedStringExpressionTest
    {
        [TestCaseSource(nameof(BicepFunctionInterpolateTestData))]
        public string ValidateBicepFunctionInterpolate(BicepValue<string> expression)
        {
            return expression.ToString();
        }

        private static IEnumerable<TestCaseData> BicepFunctionInterpolateTestData()
        {
            // test provisionable variable
            yield return new TestCaseData(
                BicepFunction.Interpolate(
                    $"Var={new ProvisioningVariable("foo", typeof(string))}"
                    ))
                .Returns("'Var=${foo}'");

            // test index expression in interpolation
            yield return new TestCaseData(
                BicepFunction.Interpolate(
                    $"Endpoint={new IndexExpression(
                        new IdentifierExpression("foo"),
                        new StringLiteralExpression("bar")
                    )}"))
                .Returns("'Endpoint=${foo['bar']}'");
        }
    }
}

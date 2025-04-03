// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.Expressions;
using NUnit.Framework;

namespace Azure.Provisioning.Tests.Expressions
{
    public class InterpolatedStringExpressionTest
    {
        [Test]
        public void ValidateBicepFunctionInterpolate()
        {
            // test provisionable variable
            AssertExpression(
                "'Var=${foo}'",
                BicepFunction.Interpolate(
                    $"Var={new ProvisioningVariable("foo", typeof(string))}"
                    )
                );

            // test index expression in interpolation
            AssertExpression(
                "'Endpoint=${foo['bar']}'",
                BicepFunction.Interpolate(
                    $"Endpoint={new IndexExpression(
                        new IdentifierExpression("foo"),
                        new StringLiteralExpression("bar")
                    )}")
                );

            static void AssertExpression(string expected, BicepValue<string> expression)
                => Assert.AreEqual(expected, expression.ToString());
        }
    }
}

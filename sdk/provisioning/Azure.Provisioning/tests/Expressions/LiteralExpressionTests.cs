// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Provisioning.Expressions;
using NUnit.Framework;

namespace Azure.Provisioning.Tests.Expressions
{
    public class LiteralExpressionTests
    {
        [TestCaseSource(nameof(ValidateLiteralExpressionTestData))]
        public string? ValidateLiteralExpression(LiteralExpression literal)
        {
            return literal.ToString();
        }

        private static IEnumerable<TestCaseData> ValidateLiteralExpressionTestData()
        {
            yield return new TestCaseData(new NullLiteralExpression()).Returns("null");

            yield return new TestCaseData(new BoolLiteralExpression(true)).Returns("true");
            yield return new TestCaseData(new BoolLiteralExpression(false)).Returns("false");

            yield return new TestCaseData(new IntLiteralExpression(3141592)).Returns("3141592");
            yield return new TestCaseData(new IntLiteralExpression(-271828)).Returns("-271828");

            yield return new TestCaseData(new StringLiteralExpression("ordinary string")).Returns("'ordinary string'");
            yield return new TestCaseData(new StringLiteralExpression("string with 'single quote'")).Returns("'string with \\'single quote\\''");
        }
    }
}

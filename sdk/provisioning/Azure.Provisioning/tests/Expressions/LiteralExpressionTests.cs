// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.Expressions;
using NUnit.Framework;

namespace Azure.Provisioning.Tests.Expressions
{
    public class LiteralExpressionTests
    {
        [Test]
        public void ValidateLiteralExpression()
        {
            // null literal
            AssertExpression(
                "null",
                new NullLiteralExpression()
                );

            // bool literal
            AssertExpression(
                "true",
                new BoolLiteralExpression(true)
                );
            AssertExpression(
                "false",
                new BoolLiteralExpression(false)
                );

            // int literal
            AssertExpression(
                "3141592",
                new IntLiteralExpression(3141592)
                );
            AssertExpression(
                "-271828",
                new IntLiteralExpression(-271828)
                );

            // string literal
            AssertExpression(
                "'ordinary string'",
                new StringLiteralExpression("ordinary string")
                );
            AssertExpression(
                @"'string with \'single quote\''",
                new StringLiteralExpression("string with 'single quote'")
                );

            static void AssertExpression(string expected, LiteralExpression expression)
                => Assert.AreEqual(expected, expression.ToString());
        }
    }
}

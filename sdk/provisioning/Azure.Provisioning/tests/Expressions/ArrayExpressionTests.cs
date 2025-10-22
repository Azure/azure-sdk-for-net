// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Provisioning.Expressions;
using NUnit.Framework;

namespace Azure.Provisioning.Tests.Expressions
{
    public class ArrayExpressionTests
    {
        [Test]
        public void ValidateArrayExpressions()
        {
            // NOTE: our AST always produces multi-line arrays with indents, except for empty array, it produces []
            // empty array
            AssertExpression(
                "[]",
                new ArrayExpression()
                );

            // array of literals
            AssertExpression(
                """
                [
                  314
                  false
                  'foo'
                ]
                """,
                new ArrayExpression(new IntLiteralExpression(314), new BoolLiteralExpression(false), new StringLiteralExpression("foo"))
                );

            // array of objects
            var obj = new ObjectExpression(
                new PropertyExpression("p1", new StringLiteralExpression("p1 value")));
            AssertExpression(
                """
                [
                  {
                    p1: 'p1 value'
                  }
                ]
                """,
                new ArrayExpression(obj)
                );

            static void AssertExpression(string expected, ArrayExpression expression)
                => Assert.AreEqual(
                   expected.NormalizeLineEndings(),
                   expression.ToString().NormalizeLineEndings()
                );
        }
    }
}

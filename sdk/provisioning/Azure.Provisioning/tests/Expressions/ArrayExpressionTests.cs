// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Provisioning.Expressions;
using NUnit.Framework;

namespace Azure.Provisioning.Tests.Expressions
{
    public class ArrayExpressionTests
    {
        [TestCaseSource(nameof(ValidateArrayExpressionTestData))]
        public string ValidateArrayExpressions(ArrayExpression expression)
        {
            return expression.ToString();
        }

        private static IEnumerable<TestCaseData> ValidateArrayExpressionTestData()
        {
            // NOTE: our AST always produces multi-line arrays with indents
            // empty array
            yield return new TestCaseData(new ArrayExpression())
                .Returns($"[]");
            // array of literals
            yield return new TestCaseData(new ArrayExpression(new IntLiteralExpression(314), new BoolLiteralExpression(false), new StringLiteralExpression("foo")))
                .Returns(@"[
  314
  false
  'foo'
]");
            // array of objects
            var obj = new ObjectExpression(
                new PropertyExpression("p1", new StringLiteralExpression("p1 value")));
            yield return new TestCaseData(new ArrayExpression(obj))
                .Returns(@"[
  {
    p1: 'p1 value'
  }
]");
        }
    }
}

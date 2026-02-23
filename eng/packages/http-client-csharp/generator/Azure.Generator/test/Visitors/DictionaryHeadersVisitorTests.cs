// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Generator.Tests.TestHelpers;
using Azure.Generator.Visitors;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Snippets;
using Microsoft.TypeSpec.Generator.Statements;
using Moq;
using NUnit.Framework;

namespace Azure.Generator.Tests.Visitors
{
    public class DictionaryHeadersVisitorTests
    {
        [Test]
        public void UpdatesSetDelimitedWithDictionaryArgumentToAdd()
        {
            // Arrange
            MockHelpers.LoadMockGenerator();
            var visitor = new TestDictionaryHeadersVisitor();
            var mockMethod = new Mock<MethodProvider>();
            var dictionaryType = new CSharpType(typeof(IDictionary<string, string>));
            var varExpr = new VariableExpression(dictionaryType, "metadata");
            var invokeMethod = new InvokeMethodExpression(
                null,
                "SetDelimited",
                [Snippet.Literal("x-ms-meta-"), varExpr, Snippet.Literal(",")]);
            var statement = new ExpressionStatement(invokeMethod);

            // Act
            var result = visitor.InvokeVisitExpressionStatement(statement, mockMethod.Object);

            // Assert
            Assert.IsNotNull(result);
            var resultExpression = result as ExpressionStatement;
            Assert.IsNotNull(resultExpression);

            var resultInvoke = resultExpression!.Expression as InvokeMethodExpression;
            Assert.IsNotNull(resultInvoke);
            Assert.AreEqual("Add", resultInvoke!.MethodName);
            Assert.AreEqual(2, resultInvoke.Arguments.Count);
            Assert.AreEqual(invokeMethod.Arguments[0], resultInvoke.Arguments[0]);
            Assert.AreEqual(varExpr, resultInvoke.Arguments[1]);
        }

        [Test]
        public void DoesNotUpdateSetDelimitedWithNonDictionaryArgument()
        {
            // Arrange
            MockHelpers.LoadMockGenerator();
            var visitor = new TestDictionaryHeadersVisitor();
            var mockMethod = new Mock<MethodProvider>();
            var listType = new CSharpType(typeof(IList<string>));
            var varExpr = new VariableExpression(listType, "tags");
            var invokeMethod = new InvokeMethodExpression(
                null,
                "SetDelimited",
                [Snippet.Literal("x-ms-tags"), varExpr, Snippet.Literal(",")]);
            var statement = new ExpressionStatement(invokeMethod);

            // Act
            var result = visitor.InvokeVisitExpressionStatement(statement, mockMethod.Object);

            // Assert
            Assert.IsNotNull(result);
            var resultExpression = result as ExpressionStatement;
            Assert.IsNotNull(resultExpression);

            var resultInvoke = resultExpression!.Expression as InvokeMethodExpression;
            Assert.IsNotNull(resultInvoke);
            Assert.AreEqual("SetDelimited", resultInvoke!.MethodName);
            Assert.AreEqual(3, resultInvoke.Arguments.Count);
        }

        [Test]
        public void DoesNotUpdateSetDelimitedWithInsufficientArguments()
        {
            // Arrange
            MockHelpers.LoadMockGenerator();
            var visitor = new TestDictionaryHeadersVisitor();
            var mockMethod = new Mock<MethodProvider>();
            var invokeMethod = new InvokeMethodExpression(null, "SetDelimited", []);
            var statement = new ExpressionStatement(invokeMethod);

            // Act
            var result = visitor.InvokeVisitExpressionStatement(statement, mockMethod.Object);

            // Assert
            Assert.IsNotNull(result);
            var resultExpression = result as ExpressionStatement;
            Assert.IsNotNull(resultExpression);

            var resultInvoke = resultExpression!.Expression as InvokeMethodExpression;
            Assert.IsNotNull(resultInvoke);
            Assert.AreEqual("SetDelimited", resultInvoke!.MethodName);
        }

        [Test]
        public void DoesNotUpdateOtherMethodCalls()
        {
            // Arrange
            MockHelpers.LoadMockGenerator();
            var visitor = new TestDictionaryHeadersVisitor();
            var mockMethod = new Mock<MethodProvider>();
            var dictionaryType = new CSharpType(typeof(IDictionary<string, string>));
            var varExpr = new VariableExpression(dictionaryType, "metadata");
            var invokeMethod = new InvokeMethodExpression(
                null,
                "SomeOtherMethod",
                [Snippet.Literal("x-ms-meta-"), varExpr]);
            var statement = new ExpressionStatement(invokeMethod);

            // Act
            var result = visitor.InvokeVisitExpressionStatement(statement, mockMethod.Object);

            // Assert
            Assert.IsNotNull(result);
            var resultExpression = result as ExpressionStatement;
            Assert.IsNotNull(resultExpression);

            var resultInvoke = resultExpression!.Expression as InvokeMethodExpression;
            Assert.IsNotNull(resultInvoke);
            Assert.AreEqual("SomeOtherMethod", resultInvoke!.MethodName);
        }

        private class TestDictionaryHeadersVisitor : DictionaryHeadersVisitor
        {
            public MethodBodyStatement? InvokeVisitExpressionStatement(ExpressionStatement statement, MethodProvider method)
            {
                return VisitExpressionStatement(statement, method);
            }
        }
    }
}

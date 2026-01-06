// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Tests.TestHelpers;
using Azure.Generator.Visitors;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Snippets;
using Microsoft.TypeSpec.Generator.Statements;
using Moq;
using NUnit.Framework;

namespace Azure.Generator.Tests.Visitors
{
    public class InvokeDelimitedMethodVisitorTests
    {
        [Test]
        public void UpdatesAppendQueryDelimitedMethodCall()
        {
            // Arrange
            MockHelpers.LoadMockGenerator();
            var visitor = new TestInvokeDelimitedMethodVisitor();
            var mockMethod = new Mock<MethodProvider>();
            var invokeMethod = new InvokeMethodExpression(null, "AppendQueryDelimited", []);
            var statement = new ExpressionStatement(invokeMethod);

            // Act
            var result = visitor.InvokeVisitExpressionStatement(statement, mockMethod.Object);

            // Assert
            Assert.That(result, Is.Not.Null);
            var resultExpression = result as ExpressionStatement;
            Assert.That(resultExpression, Is.Not.Null);

            var resultInvoke = resultExpression!.Expression as InvokeMethodExpression;
            Assert.That(resultInvoke, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(resultInvoke!.MethodName, Is.EqualTo("AppendQueryDelimited"));
                Assert.That(resultInvoke.ExtensionType,
                    Is.EqualTo(AzureClientGenerator.Instance.RawRequestUriBuilderExtensionsDefinition.Type));
            });
        }

        [Test]
        public void UpdatesSetDelimitedMethodCall()
        {
            // Arrange
            MockHelpers.LoadMockGenerator();
            var visitor = new TestInvokeDelimitedMethodVisitor();
            var mockMethod = new Mock<MethodProvider>();
            var invokeMethod = new InvokeMethodExpression(null, "SetDelimited", []);
            var statement = new ExpressionStatement(invokeMethod);

            // Act
            var result = visitor.InvokeVisitExpressionStatement(statement, mockMethod.Object);

            // Assert
            Assert.That(result, Is.Not.Null);
            var resultExpression = result as ExpressionStatement;
            Assert.That(resultExpression, Is.Not.Null);

            var resultInvoke = resultExpression!.Expression as InvokeMethodExpression;
            Assert.That(resultInvoke, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(resultInvoke!.MethodName, Is.EqualTo("SetDelimited"));
                Assert.That(resultInvoke.ExtensionType,
                    Is.EqualTo(AzureClientGenerator.Instance.RequestHeaderExtensionsDefinition.Type));
            });
        }

        [Test]
        public void DoesNotUpdateOtherMethodCalls()
        {
            // Arrange
            MockHelpers.LoadMockGenerator();
            var visitor = new TestInvokeDelimitedMethodVisitor();
            var mockMethod = new Mock<MethodProvider>();
            var invokeMethod = new InvokeMethodExpression(null, "SomeOtherMethod", []);
            var statement = new ExpressionStatement(invokeMethod);

            // Act
            var result = visitor.InvokeVisitExpressionStatement(statement, mockMethod.Object);

            // Assert
            Assert.That(result, Is.Not.Null);
            var resultExpression = result as ExpressionStatement;
            Assert.That(resultExpression, Is.Not.Null);

            var resultInvoke = resultExpression!.Expression as InvokeMethodExpression;
            Assert.That(resultInvoke, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(resultInvoke!.MethodName, Is.EqualTo("SomeOtherMethod"));
                Assert.That(resultInvoke.ExtensionType, Is.Null);
            });
        }

        [Test]
        public void DoesNotUpdateNonInvokeMethodExpressions()
        {
            // Arrange
            MockHelpers.LoadMockGenerator();
            var visitor = new TestInvokeDelimitedMethodVisitor();
            var mockMethod = new Mock<MethodProvider>();
            var statement = new ExpressionStatement(Snippet.True);

            // Act
            var result = visitor.InvokeVisitExpressionStatement(statement, mockMethod.Object);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.EqualTo(statement));
        }

        [Test]
        public void UpdatesMultipleDelimitedMethodCalls()
        {
            // Arrange
            MockHelpers.LoadMockGenerator();
            var visitor = new TestInvokeDelimitedMethodVisitor();
            var mockMethod = new Mock<MethodProvider>();
            var invokeMethod1 = new InvokeMethodExpression(null, "AppendQueryDelimited", []);
            var statement1 = new ExpressionStatement(invokeMethod1);

            var invokeMethod2 = new InvokeMethodExpression(null, "SetDelimited", []);
            var statement2 = new ExpressionStatement(invokeMethod2);

            // Act
            var result1 = visitor.InvokeVisitExpressionStatement(statement1, mockMethod.Object);
            var result2 = visitor.InvokeVisitExpressionStatement(statement2, mockMethod.Object);

            // Assert
            var resultInvoke1 = (result1 as ExpressionStatement)?.Expression as InvokeMethodExpression;
            Assert.That(resultInvoke1, Is.Not.Null);
            Assert.That(resultInvoke1!.ExtensionType,
                Is.EqualTo(AzureClientGenerator.Instance.RawRequestUriBuilderExtensionsDefinition.Type));

            var resultInvoke2 = (result2 as ExpressionStatement)?.Expression as InvokeMethodExpression;
            Assert.That(resultInvoke2, Is.Not.Null);
            Assert.That(resultInvoke2!.ExtensionType,
                Is.EqualTo(AzureClientGenerator.Instance.RequestHeaderExtensionsDefinition.Type));
        }

        private class TestInvokeDelimitedMethodVisitor : InvokeDelimitedMethodVisitor
        {
            public MethodBodyStatement? InvokeVisitExpressionStatement(ExpressionStatement statement, MethodProvider method)
            {
                return VisitExpressionStatement(statement, method);
            }
        }
    }
}

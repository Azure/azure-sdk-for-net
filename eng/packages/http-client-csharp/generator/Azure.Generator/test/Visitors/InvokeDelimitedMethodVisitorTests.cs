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
            Assert.IsNotNull(result);
            var resultExpression = result as ExpressionStatement;
            Assert.IsNotNull(resultExpression);

            var resultInvoke = resultExpression!.Expression as InvokeMethodExpression;
            Assert.IsNotNull(resultInvoke);
            Assert.AreEqual("AppendQueryDelimited", resultInvoke!.MethodName);
            Assert.AreEqual(AzureClientGenerator.Instance.RawRequestUriBuilderExtensionsDefinition.Type,
                resultInvoke.ExtensionType);
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
            Assert.IsNotNull(result);
            var resultExpression = result as ExpressionStatement;
            Assert.IsNotNull(resultExpression);

            var resultInvoke = resultExpression!.Expression as InvokeMethodExpression;
            Assert.IsNotNull(resultInvoke);
            Assert.AreEqual("SetDelimited", resultInvoke!.MethodName);
            Assert.AreEqual(AzureClientGenerator.Instance.RequestHeaderExtensionsDefinition.Type,
                resultInvoke.ExtensionType);
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
            Assert.IsNotNull(result);
            var resultExpression = result as ExpressionStatement;
            Assert.IsNotNull(resultExpression);

            var resultInvoke = resultExpression!.Expression as InvokeMethodExpression;
            Assert.IsNotNull(resultInvoke);
            Assert.AreEqual("SomeOtherMethod", resultInvoke!.MethodName);
            Assert.IsNull(resultInvoke.ExtensionType);
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
            Assert.IsNotNull(result);
            Assert.AreEqual(statement, result);
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
            Assert.IsNotNull(resultInvoke1);
            Assert.AreEqual(AzureClientGenerator.Instance.RawRequestUriBuilderExtensionsDefinition.Type,
                resultInvoke1!.ExtensionType);

            var resultInvoke2 = (result2 as ExpressionStatement)?.Expression as InvokeMethodExpression;
            Assert.IsNotNull(resultInvoke2);
            Assert.AreEqual(AzureClientGenerator.Instance.RequestHeaderExtensionsDefinition.Type,
                resultInvoke2!.ExtensionType);
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

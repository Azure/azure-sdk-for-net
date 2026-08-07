// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Generator.Tests.TestHelpers;
using Azure.Generator.Visitors;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Snippets;
using Moq;
using NUnit.Framework;

namespace Azure.Generator.Tests.Visitors
{
    public class StreamingResponseVisitorTests
    {
        [TestCase("CreateJsonLines")]
        [TestCase("CreateSse")]
        public void WrapsAzureResponse(string methodName)
        {
            MockHelpers.LoadMockGenerator();
            var response = new VariableExpression(typeof(Response), "response");
            var expression = new InvokeMethodExpression(null, methodName, [response]);

            new TestStreamingResponseVisitor().Visit(expression, new Mock<MethodProvider>().Object);

            var wrappedResponse = (expression.Arguments[0] as ScopedApi)?.Original as NewInstanceExpression;
            Assert.IsNotNull(wrappedResponse);
            Assert.AreEqual(typeof(AzurePipelineResponse), wrappedResponse!.Type?.FrameworkType);
            Assert.AreSame(response, wrappedResponse.Parameters[0]);
        }

        [Test]
        public void DoesNotWrapOtherMethods()
        {
            MockHelpers.LoadMockGenerator();
            var response = new VariableExpression(typeof(Response), "response");
            var expression = new InvokeMethodExpression(null, "FromValue", [response]);

            new TestStreamingResponseVisitor().Visit(expression, new Mock<MethodProvider>().Object);

            Assert.AreSame(response, expression.Arguments[0]);
        }

        private class TestStreamingResponseVisitor : StreamingResponseVisitor
        {
            public void Visit(InvokeMethodExpression expression, MethodProvider method)
                => VisitInvokeMethodExpression(expression, method);
        }
    }
}

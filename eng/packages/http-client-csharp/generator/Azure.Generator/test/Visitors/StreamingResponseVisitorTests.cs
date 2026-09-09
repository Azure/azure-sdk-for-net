// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Generator.Tests.TestHelpers;
using Azure.Generator.Visitors;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Snippets;
using Microsoft.TypeSpec.Generator.Statements;
using Moq;
using NUnit.Framework;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Tests.Visitors
{
    public class StreamingResponseVisitorTests
    {
        [Test]
        public void TransfersHttpMessageContentForStreamingReturnType()
        {
            MockHelpers.LoadMockGenerator();
            var message = new VariableExpression(typeof(HttpMessage), "message");
            var processMessage = CreateInvocation(
                "ProcessMessageAsync",
                new CSharpType(typeof(Task<>), typeof(Response)),
                message);
            processMessage.Update(callAsAsync: true);
            var response = new ScopedApi<Response>(processMessage);
            var expression = CreateInvocation(
                "CreateSse",
                typeof(BinaryData),
                response);

            new TestStreamingResponseVisitor().Visit(expression, CreateMethod(CreateStreamingResponseType()));

            var wrappedResponse = (expression.Arguments[0] as ScopedApi)?.Original as NewInstanceExpression;
            Assert.IsNotNull(wrappedResponse);
            Assert.AreEqual(typeof(AzurePipelineResponse), wrappedResponse!.Type?.FrameworkType);
            Assert.AreSame(message, wrappedResponse.Parameters[0]);
        }

        [Test]
        public void PreservesPipelineProcessingBeforeCreatingStreamingResult()
        {
            MockHelpers.LoadMockGenerator();
            var message = new VariableExpression(typeof(HttpMessage), "message");
            var processMessage = CreateInvocation(
                "ProcessMessageAsync",
                new CSharpType(typeof(Task<>), typeof(Response)),
                message);
            processMessage.Update(callAsAsync: true);
            var response = new ScopedApi<Response>(processMessage);
            var createResult = CreateInvocation("CreateSse", typeof(BinaryData), response);
            var method = CreateMethod(CreateStreamingResponseType());
            var visitor = new TestStreamingResponseVisitor();
            var statements = visitor.Visit(new MethodBodyStatements([Return(createResult)]), method);

            visitor.Visit(createResult, method);

            Assert.AreEqual(2, statements.Statements.Count);
            Assert.AreSame(response, ((ExpressionStatement)statements.Statements[0]).Expression);
            var wrappedResponse = (createResult.Arguments[0] as ScopedApi)?.Original as NewInstanceExpression;
            Assert.IsNotNull(wrappedResponse);
            Assert.AreSame(message, wrappedResponse!.Parameters[0]);
        }

        [Test]
        public void PreservesPipelineProcessingInsideTry()
        {
            MockHelpers.LoadMockGenerator();
            var message = new VariableExpression(typeof(HttpMessage), "message");
            var processMessage = CreateInvocation(
                "ProcessMessageAsync",
                new CSharpType(typeof(Task<>), typeof(Response)),
                message);
            processMessage.Update(callAsAsync: true);
            var response = new ScopedApi<Response>(processMessage);
            var createResult = CreateInvocation("CreateSse", typeof(BinaryData), response);
            var method = CreateMethod(CreateStreamingResponseType());
            var tryExpression = new TryExpression(new ExpressionStatement(message), Return(createResult));
            var visitor = new TestStreamingResponseVisitor();

            tryExpression = visitor.Visit(tryExpression, method);
            visitor.Visit(createResult, method);

            var body = (MethodBodyStatements)tryExpression.Body;
            var statements = body.Statements.Count == 1 && body.Statements[0] is MethodBodyStatements nested
                ? nested
                : body;
            Assert.AreEqual(3, statements.Statements.Count);
            Assert.AreSame(response, ((ExpressionStatement)statements.Statements[1]).Expression);
            var wrappedResponse = (createResult.Arguments[0] as ScopedApi)?.Original as NewInstanceExpression;
            Assert.IsNotNull(wrappedResponse);
            Assert.AreSame(message, wrappedResponse!.Parameters[0]);
        }

        [Test]
        public void DoesNotWrapAzureResponseForNonStreamingReturnType()
        {
            MockHelpers.LoadMockGenerator();
            var response = new VariableExpression(typeof(Response), "response");
            var expression = CreateInvocation("CreateSse", typeof(BinaryData), response);

            new TestStreamingResponseVisitor().Visit(expression, CreateMethod(typeof(BinaryData)));

            Assert.AreSame(response, expression.Arguments[0]);
        }

        [Test]
        public void DoesNotWrapAzureResponseWithoutHttpMessage()
        {
            MockHelpers.LoadMockGenerator();
            var response = new VariableExpression(typeof(Response), "response");
            var expression = CreateInvocation("CreateSse", typeof(BinaryData), response);

            new TestStreamingResponseVisitor().Visit(expression, CreateMethod(CreateStreamingResponseType()));

            Assert.AreSame(response, expression.Arguments[0]);
        }

        [Test]
        public void DoesNotWrapNonAzureResponseForStreamingReturnType()
        {
            MockHelpers.LoadMockGenerator();
            var response = new VariableExpression(typeof(BinaryData), "response");
            var expression = CreateInvocation(
                "CreateSse",
                typeof(BinaryData),
                response);

            new TestStreamingResponseVisitor().Visit(expression, CreateMethod(CreateStreamingResponseType()));

            Assert.AreSame(response, expression.Arguments[0]);
        }

        [Test]
        public void DoesNotThrowForProviderBackedGenericReturnType()
        {
            MockHelpers.LoadMockGenerator();
            var response = new VariableExpression(typeof(Response), "response");
            var expression = CreateInvocation("CreateResult", typeof(BinaryData), response);
            var returnType = new TestGenericTypeProvider().Type;

            Assert.DoesNotThrow(() =>
                new TestStreamingResponseVisitor().Visit(expression, CreateMethod(returnType)));
            Assert.AreSame(response, expression.Arguments[0]);
        }

        private static InvokeMethodExpression CreateInvocation(string name, CSharpType returnType, ValueExpression response)
        {
            var signature = new MethodSignature(
                name,
                null,
                MethodSignatureModifiers.Public | MethodSignatureModifiers.Static,
                returnType,
                null,
                []);
            return new InvokeMethodExpression(null, signature, [response]);
        }

        private static MethodProvider CreateMethod(CSharpType returnType)
        {
            var signature = new MethodSignature(
                "TestMethod",
                null,
                MethodSignatureModifiers.Public | MethodSignatureModifiers.Async,
                new CSharpType(typeof(Task<>), returnType),
                null,
                []);
            return new TestMethodProvider(signature);
        }

#pragma warning disable SCME0005 // Type is for evaluation purposes only and is subject to change or removal in future updates.
        private static CSharpType CreateStreamingResponseType()
            => new(typeof(System.ClientModel.AsyncStreamingClientResult<>), typeof(BinaryData));
#pragma warning restore SCME0005 // Type is for evaluation purposes only and is subject to change or removal in future updates.

        private class TestStreamingResponseVisitor : StreamingResponseVisitor
        {
            public void Visit(InvokeMethodExpression expression, MethodProvider method)
                => VisitInvokeMethodExpression(expression, method);

            public MethodBodyStatements Visit(MethodBodyStatements statements, MethodProvider method)
                => (MethodBodyStatements)VisitStatements(statements, method);

            public TryExpression Visit(TryExpression expression, MethodProvider method)
                => VisitTryExpression(expression, method);
        }

        private class TestMethodProvider : MethodProvider
        {
            public TestMethodProvider(MethodSignature signature)
                : base(signature, new Mock<TypeProvider>().Object, null)
            {
            }
        }

        private class TestGenericTypeProvider : TypeProvider
        {
            protected override string BuildName() => "SearchResult";

            protected override string BuildNamespace() => "Azure.Search.Documents.Models";

            protected override string BuildRelativeFilePath() => $"{Name}.cs";

            protected override CSharpType[] GetTypeArguments() => [typeof(BinaryData)];
        }
    }
}

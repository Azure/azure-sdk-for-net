// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Generator.Primitives;
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
        public void ForwardsProtocolOperationCancellation(
            [Values("CreateSse", "CreateJsonLines")] string factoryName,
            [Values(false, true)] bool nullableContext,
            [Values("context", "requestContext")] string contextName)
        {
            MockHelpers.LoadMockGenerator();
            var context = new ParameterProvider(
                contextName,
                $"The request context.",
                new CSharpType(typeof(RequestContext), isNullable: nullableContext),
                defaultValue: nullableContext ? Null : null);
            var method = CreateMethod(CreateStreamingResponseType(), context);
            var expression = CreateStreamingFactory(factoryName);
            var visitor = new TestStreamingResponseVisitor();

            visitor.Visit(expression, method);

            Assert.AreEqual(factoryName == "CreateSse" ? 3 : 2, expression.Arguments.Count);
            Assert.AreEqual($"({contextName}?.CancellationToken ?? default)", expression.Arguments[^1].ToDisplayString());
            if (factoryName == "CreateSse")
            {
                Assert.AreSame(Null, expression.Arguments[1]);
            }
            var arguments = expression.Arguments;

            visitor.Visit(expression, method);

            CollectionAssert.AreEqual(arguments, expression.Arguments, "Revisiting must not duplicate cancellation or predicates.");
        }

        [Test]
        public void PreservesSseCompletionPredicate()
        {
            MockHelpers.LoadMockGenerator();
            var expression = CreateStreamingFactory("CreateSse");
            var predicate = new VariableExpression(typeof(Delegate), "isTerminalEvent");
            expression.Update(arguments: [expression.Arguments[0], predicate]);

            new TestStreamingResponseVisitor().Visit(
                expression, CreateMethod(CreateStreamingResponseType(), KnownAzureParameters.OptionalRequestContext));

            Assert.AreEqual(3, expression.Arguments.Count);
            Assert.AreSame(predicate, expression.Arguments[1]);
            Assert.AreEqual("(context?.CancellationToken ?? default)", expression.Arguments[2].ToDisplayString());
        }

        [TestCase("CreateSse")]
        [TestCase("CreateJsonLines")]
        public void PreservesExistingProtocolCancellation(string factoryName)
        {
            MockHelpers.LoadMockGenerator();
            var expression = CreateStreamingFactory(factoryName);
            var cancellationToken = new VariableExpression(typeof(CancellationToken), "operationToken");
            expression.Update(arguments: factoryName == "CreateSse"
                ? [expression.Arguments[0], Null, cancellationToken]
                : [expression.Arguments[0], cancellationToken]);
            var argumentCount = expression.Arguments.Count;

            new TestStreamingResponseVisitor().Visit(
                expression, CreateMethod(CreateStreamingResponseType(), KnownAzureParameters.OptionalRequestContext));

            Assert.AreEqual(argumentCount, expression.Arguments.Count);
            Assert.AreSame(cancellationToken, expression.Arguments[^1]);
        }

        [Test]
        public void PreservesConvenienceCancellation(
            [Values("CreateSse", "CreateJsonLines")] string factoryName,
            [Values(false, true)] bool typed)
        {
            MockHelpers.LoadMockGenerator();
            var expression = CreateStreamingFactory(factoryName);
            var cancellationToken = KnownAzureParameters.CancellationTokenWithoutDefault;
            var arguments = new List<ValueExpression> { expression.Arguments[0] };
            if (typed)
            {
                expression.Update(typeArguments: [typeof(BinaryData)]);
                arguments.Add(new VariableExpression(typeof(Delegate), "parser"));
            }
            if (factoryName == "CreateSse")
            {
                arguments.Add(new VariableExpression(typeof(Delegate), "isTerminalEvent"));
            }
            arguments.Add(cancellationToken);
            expression.Update(arguments: arguments);

            new TestStreamingResponseVisitor().Visit(expression, CreateMethod(CreateStreamingResponseType(), cancellationToken));

            Assert.AreEqual(arguments.Count, expression.Arguments.Count);
            CollectionAssert.AreEqual(arguments.Skip(1), expression.Arguments.Skip(1));
        }

        [TestCase("CreateSse")]
        [TestCase("CreateJsonLines")]
        public void DoesNotAddCancellationWithoutRequestContext(string factoryName)
        {
            MockHelpers.LoadMockGenerator();
            var expression = CreateStreamingFactory(factoryName);

            new TestStreamingResponseVisitor().Visit(expression, CreateMethod(CreateStreamingResponseType()));

            Assert.AreEqual(1, expression.Arguments.Count);
        }

        [TestCase("CreateResult", false, false)]
        [TestCase("CreateSse", true, false)]
        [TestCase("CreateJsonLines", true, false)]
        [TestCase("CreateSse", false, true)]
        [TestCase("CreateJsonLines", false, true)]
        public void DoesNotAddProtocolCancellationToOtherFactories(string factoryName, bool otherDeclaringType, bool generic)
        {
            MockHelpers.LoadMockGenerator();
            var expression = CreateStreamingFactory(factoryName);
            if (otherDeclaringType)
            {
                expression.Update(instanceReference: Static(typeof(BinaryData)));
            }
            if (generic)
            {
                expression.Update(typeArguments: [typeof(BinaryData)]);
            }

            new TestStreamingResponseVisitor().Visit(
                expression, CreateMethod(CreateStreamingResponseType(), KnownAzureParameters.OptionalRequestContext));

            Assert.AreEqual(1, expression.Arguments.Count);
        }

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

        private static InvokeMethodExpression CreateStreamingFactory(string name)
        {
            var message = new VariableExpression(typeof(HttpMessage), "message");
            var processMessage = CreateInvocation(
                "ProcessMessageAsync",
                new CSharpType(typeof(Task<>), typeof(Response)),
                message);
            processMessage.Update(callAsAsync: true);
            return Static(typeof(AsyncStreamingResult)).Invoke(name, new ScopedApi<Response>(processMessage));
        }

        private static MethodProvider CreateMethod(CSharpType returnType, params ParameterProvider[] parameters)
        {
            var signature = new MethodSignature(
                "TestMethod",
                null,
                MethodSignatureModifiers.Public | MethodSignatureModifiers.Async,
                new CSharpType(typeof(Task<>), returnType),
                null,
                parameters);
            return new TestMethodProvider(signature);
        }

        private static CSharpType CreateStreamingResponseType()
            => new(typeof(System.ClientModel.AsyncStreamingResult<>), typeof(BinaryData));

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

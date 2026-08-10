// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Generator.Tests.TestHelpers;
using Azure.Generator.Visitors;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Snippets;
using Moq;
using NUnit.Framework;

namespace Azure.Generator.Tests.Visitors
{
    public class StreamingResponseVisitorTests
    {
        [Test]
        public void WrapsAzureResponseForStreamingReturnType()
        {
            MockHelpers.LoadMockGenerator();
            var response = new VariableExpression(typeof(Response), "response");
            var expression = CreateInvocation(
                "ArbitraryFactoryName",
                typeof(BinaryData),
                response);

            new TestStreamingResponseVisitor().Visit(expression, CreateMethod(CreateStreamingResponseType()));

            var wrappedResponse = (expression.Arguments[0] as ScopedApi)?.Original as NewInstanceExpression;
            Assert.IsNotNull(wrappedResponse);
            Assert.AreEqual(typeof(AzurePipelineResponse), wrappedResponse!.Type?.FrameworkType);
            Assert.AreSame(response, wrappedResponse.Parameters[0]);
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
        public void DoesNotWrapAzureResponseForProviderBackedGenericReturnType()
        {
            MockHelpers.LoadMockGenerator();
            var response = new VariableExpression(typeof(Response), "response");
            var expression = CreateInvocation("CreateResponse", typeof(BinaryData), response);

            new TestStreamingResponseVisitor().Visit(expression, CreateMethod(new GenericTypeProvider("GenericType", "Sample").Type));

            Assert.AreSame(response, expression.Arguments[0]);
        }

        [Test]
        public void WrapsAzureResponseForProviderBackedStreamingReturnType()
        {
            MockHelpers.LoadMockGenerator();
            var response = new VariableExpression(typeof(Response), "response");
            var expression = CreateInvocation("CreateResponse", typeof(BinaryData), response);
            var returnType = new GenericTypeProvider("AsyncStreamingClientResult", "System.ClientModel").Type;

            new TestStreamingResponseVisitor().Visit(expression, CreateMethod(returnType));

            var wrappedResponse = (expression.Arguments[0] as ScopedApi)?.Original as NewInstanceExpression;
            Assert.IsNotNull(wrappedResponse);
            Assert.AreSame(response, wrappedResponse!.Parameters[0]);
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
        }

        private class TestMethodProvider : MethodProvider
        {
            public TestMethodProvider(MethodSignature signature)
                : base(signature, new Mock<TypeProvider>().Object, null)
            {
            }
        }

        private class GenericTypeProvider : TypeProvider
        {
            private readonly string _name;
            private readonly string _namespace;

            public GenericTypeProvider(string name, string @namespace)
            {
                _name = name;
                _namespace = @namespace;
            }

            protected override string BuildName() => _name;
            protected override string BuildNamespace() => _namespace;
            protected override string BuildRelativeFilePath() => Path.Combine("src", $"{Name}.cs");
            protected override CSharpType[] GetTypeArguments() => [typeof(BinaryData)];
        }
    }
}

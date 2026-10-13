// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Tests.Common;
using Azure.Generator.Tests.TestHelpers;
using System.Linq;
using NUnit.Framework;
using Azure.Generator.Providers;
using Azure.Generator.Providers.Abstraction;
using Azure.Core;
using Azure.Core.Pipeline;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Statements;
using System.Threading;

namespace Azure.Generator.Tests.Providers.Abstractions
{
    internal class AzureClientResponseProviderTests
    {
        [Test]
        public void ValidateReturnTypeIsOverridden()
        {
            ClientProvider clientProvider = CreateMockClientProvider();

            var method = clientProvider.Methods.FirstOrDefault(x => !x.Signature.Name.EndsWith("Async"));
            Assert.NotNull(method);
            Assert.NotNull(method!.Signature.ReturnType);
            Assert.IsTrue(method!.Signature.ReturnType!.Equals(typeof(Response)));
        }

        [Test]
        public void ValidateBodyOfClientOperationIsOverridden()
        {
            var clientProvider = CreateMockClientProvider();

            var method = clientProvider.Methods.FirstOrDefault(x => x.Signature.Parameters.Any(p => p.Type.Equals(typeof(RequestContext))) && !x.Signature.Name.EndsWith("Async"));
            Assert.NotNull(method);
            Assert.NotNull(method!.BodyStatements);
            Assert.AreEqual(Helpers.GetExpectedFromFile(), method.BodyStatements!.ToDisplayString());
        }

        [Test]
        public void ValidateClientResponseExceptionTypeIsOverridden()
        {
            MockHelpers.LoadMockGenerator();
            var pipelineExtensions =
                AzureClientGenerator.Instance.OutputLibrary.TypeProviders.FirstOrDefault(t => t.Name == "ClientPipelineExtensions");
            Assert.NotNull(pipelineExtensions);
            var method = pipelineExtensions!.Methods.FirstOrDefault(x => x.Signature.Name == "ProcessMessage");
            Assert.NotNull(method);
            Assert.NotNull(method!.BodyStatements);
            Assert.AreEqual(Helpers.GetExpectedFromFile(), method.BodyStatements!.ToDisplayString());
        }

        [TestCase(false)]
        [TestCase(true)]
        public void PipelineSendPreservesContextTokenAndErrorOptions(bool isAsync)
        {
            MockHelpers.LoadMockGenerator();
            var pipeline = new HttpPipelineProvider(new VariableExpression(typeof(HttpPipeline), "pipeline"));
            var message = new VariableExpression(typeof(HttpMessage), "message").ToApi<HttpMessageApi>();
            var context = new VariableExpression(typeof(RequestContext), "context").ToApi<HttpRequestOptionsApi>();
            var statements = new MethodBodyStatements(isAsync
                ? pipeline.SendMessageAsync(message, context)
                : pipeline.SendMessage(message, context));
            string body = statements.ToDisplayString();

            Assert.That(body, Does.Contain("(global::System.Threading.CancellationToken userCancellationToken, global::Azure.ErrorOptions errorOptions) = context.Parse();"));
            Assert.That(body, Does.Contain(isAsync
                ? "await pipeline.SendAsync(message, userCancellationToken)"
                : "pipeline.Send(message, userCancellationToken)"));
            Assert.That(body, Does.Contain("errorOptions & global::Azure.ErrorOptions.NoThrow"));
            Assert.That(body, Does.Contain("return message.Response;"));
        }

        [Test]
        public void PipelineSendUsesEnumerationTokenAndContextErrorOptions()
        {
            MockHelpers.LoadMockGenerator();
            var pipeline = new HttpPipelineProvider(new VariableExpression(typeof(HttpPipeline), "pipeline"));
            var message = new VariableExpression(typeof(HttpMessage), "message").ToApi<HttpMessageApi>();
            var context = new VariableExpression(typeof(RequestContext), "context").ToApi<HttpRequestOptionsApi>();
            var token = new VariableExpression(typeof(CancellationToken), "enumerationCancellationToken");
            string body = new MethodBodyStatements(pipeline.SendMessageAsync(message, context, token)).ToDisplayString();

            Assert.That(body, Does.Contain("global::Azure.ErrorOptions errorOptions = "));
            Assert.That(body, Does.Contain("context?.ErrorOptions ?? global::Azure.ErrorOptions.Default"));
            Assert.That(body, Does.Not.Contain("userCancellationToken"));
            Assert.That(body, Does.Not.Contain("context.Parse()"));
            Assert.That(body, Does.Not.Contain("Item2"));
            Assert.That(body, Does.Contain("await pipeline.SendAsync(message, enumerationCancellationToken)"));
            Assert.That(body, Does.Contain("errorOptions & global::Azure.ErrorOptions.NoThrow"));
            Assert.That(body, Does.Contain("return message.Response;"));
        }

        private static ClientProvider CreateMockClientProvider()
        {
            var client = InputFactory.Client("TestClient", methods: [InputFactory.BasicServiceMethod("foo", InputFactory.Operation("foo"))]);
            MockHelpers.LoadMockGenerator(clientResponseApi: AzureClientResponseProvider.Instance);
            var clientProvider = AzureClientGenerator.Instance.TypeFactory.CreateClient(client)!;
            return clientProvider;
        }
    }
}

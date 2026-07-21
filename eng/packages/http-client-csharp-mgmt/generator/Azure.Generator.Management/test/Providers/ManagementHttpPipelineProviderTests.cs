// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Generator.Management.Providers.Abstraction;
using Azure.Generator.Management.Tests.TestHelpers;
using Microsoft.TypeSpec.Generator.Expressions;
using NUnit.Framework;

namespace Azure.Generator.Management.Tests.Providers
{
    internal class ManagementHttpPipelineProviderTests
    {
        [SetUp]
        public void SetUp()
        {
            _plugin = ManagementMockHelpers.LoadMockPlugin();
        }

        [Test]
        public void CreateMessageAppliesServicePackageUserAgent()
        {
            var pipeline = ManagementHttpPipelineProvider.Instance.FromExpression(
                new VariableExpression(typeof(HttpPipeline), "Pipeline"));
            var requestOptions = _plugin.Object.TypeFactory.HttpRequestOptionsApi.FromExpression(
                new VariableExpression(typeof(RequestContext), "context"));

            var statements = pipeline.CreateMessage(
                requestOptions,
                new VariableExpression(typeof(Uri), "uri"),
                new VariableExpression(typeof(string), "method").As<string>(),
                new VariableExpression(typeof(ResponseClassifier), "classifier"),
                out _,
                out _);

            var code = string.Join("\n", statements.Select(statement => statement.ToDisplayString()));
            Assert.That(code, Does.Contain("global::Azure.Core.HttpMessage message = Pipeline.CreateMessage();"));
            Assert.That(code, Does.Contain("_userAgent.Apply(message);"));
        }

        private Moq.Mock<ManagementClientGenerator> _plugin = null!;
    }
}

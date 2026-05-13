// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Tests.Common;
using Azure.Generator.Management.Tests.TestHelpers;
using Microsoft.TypeSpec.Generator;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Statements;
using NUnit.Framework;
using System;
using System.Reflection;

namespace Azure.Generator.Mgmt.Tests
{
    internal class ModelFactoryVisitorTests
    {
        [Test]
        public void ModelFactoryParametersPreserveLastContractNames()
        {
            var parentModel = InputFactory.Model(
                "TestResource",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Json);

            var plugin = ManagementMockHelpers.LoadMockPlugin(
                inputModels: () => [parentModel]);
            var model = plugin.Object.TypeFactory.CreateModel(parentModel)!;
            var modelFactory = plugin.Object.OutputLibrary.TypeProviders.OfType<ModelFactoryProvider>().Single();

            var eTagParameter = new ParameterProvider("eTag", $"ETag description", typeof(string));
            eTagParameter.Update(wireInfo: new WireInformation(default, "etag"));
            var ipv4Parameter = new ParameterProvider("ipv4Address", $"IPv4 description", typeof(string));
            ipv4Parameter.Update(wireInfo: new WireInformation(default, "ipv4Address"));
            var ipv6Parameter = new ParameterProvider("ipv6Address", $"IPv6 description", typeof(string));
            ipv6Parameter.Update(wireInfo: new WireInformation(default, "ipv6Address"));

            var signature = new MethodSignature(
                "TestResource",
                $"Creates a test resource.",
                MethodSignatureModifiers.Public | MethodSignatureModifiers.Static,
                model.Type,
                $"A test resource.",
                [eTagParameter, ipv4Parameter, ipv6Parameter]);
            var method = new MethodProvider(signature, MethodBodyStatement.Empty, modelFactory);

            var lastContractView = new TestModelFactoryView(modelFactory.Name);
            var previousSignature = new MethodSignature(
                "TestResource",
                $"Creates a test resource.",
                MethodSignatureModifiers.Public | MethodSignatureModifiers.Static,
                model.Type,
                $"A test resource.",
                [
                    new ParameterProvider("etag", $"ETag description", typeof(string)),
                    new ParameterProvider("iPv4Address", $"IPv4 description", typeof(string)),
                    new ParameterProvider("iPv6Address", $"IPv6 description", typeof(string))
                ]);
            lastContractView.MethodsToBuild = [new MethodProvider(previousSignature, MethodBodyStatement.Empty, lastContractView)];

            SetLastContractView(modelFactory, lastContractView);
            modelFactory.Update(methods: [method]);

            var updateParameterNames = typeof(Management.Visitors.ModelFactoryVisitor).GetMethod(
                "UpdateParameterNames",
                BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.That(updateParameterNames, Is.Not.Null);

            updateParameterNames!.Invoke(new Management.Visitors.ModelFactoryVisitor(), [method]);

            var updatedMethod = modelFactory.Methods.Single();
            Assert.That(updatedMethod.Signature.Parameters.Select(p => p.Name), Is.EqualTo(new[] { "etag", "iPv4Address", "iPv6Address" }));

            var rendered = new TypeProviderWriter(modelFactory).Write().Content;
            Assert.That(rendered, Does.Contain("string etag"));
            Assert.That(rendered, Does.Not.Contain("string eTag"));
        }

        private static void SetLastContractView(TypeProvider typeProvider, TypeProvider lastContractView)
        {
            typeof(TypeProvider).GetField(
                    "_lastContractView",
                    BindingFlags.NonPublic | BindingFlags.Instance)!
                .SetValue(typeProvider, new Lazy<TypeProvider?>(() => lastContractView));
        }

        private class TestModelFactoryView : TypeProvider
        {
            private readonly string _name;

            public TestModelFactoryView(string name)
            {
                _name = name;
            }

            public MethodProvider[] MethodsToBuild { get; set; } = [];

            protected override string BuildName() => _name;

            protected override string BuildRelativeFilePath() => $"{Name}.cs";

            protected override MethodProvider[] BuildMethods() => MethodsToBuild;
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Tests.Common;
using Azure.Generator.Management.Tests.TestHelpers;
using Microsoft.TypeSpec.Generator;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.Statements;
using NUnit.Framework;
using System;
using System.Reflection;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

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

        [Test]
        public void KeepsExistingFactoryMethodsForSdkModels()
        {
            var inputModel = InputFactory.Model(
                "TestModel",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Json,
                properties: [InputFactory.Property("value", InputPrimitiveType.String)]);

            var plugin = ManagementMockHelpers.LoadMockPlugin(
                inputModels: () => [inputModel]);
            var model = plugin.Object.TypeFactory.CreateModel(inputModel)!;
            var modelFactory = plugin.Object.OutputLibrary.TypeProviders.OfType<ModelFactoryProvider>().Single();
            var signature = new MethodSignature(
                "TestModel",
                $"Creates a test model.",
                MethodSignatureModifiers.Public | MethodSignatureModifiers.Static,
                model.Type,
                $"A test model.",
                [new ParameterProvider("value", $"Value description", typeof(string))]);
            var method = new MethodProvider(signature, MethodBodyStatement.Empty, modelFactory);
            modelFactory.Update(methods: [method]);

            var visitType = typeof(Management.Visitors.ModelFactoryVisitor).GetMethod(
                "VisitType",
                BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.That(visitType, Is.Not.Null);

            visitType!.Invoke(new Management.Visitors.ModelFactoryVisitor(), [modelFactory]);

            Assert.That(modelFactory.Methods, Has.Count.EqualTo(1));
            Assert.That(modelFactory.Methods[0].Signature.Name, Is.EqualTo("TestModel"));
        }

        [Test]
        public void RestoresMissingLastContractFactoryMethodsForSdkModels()
        {
            var inputModel = InputFactory.Model(
                "TestModel",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Json,
                properties: [InputFactory.Property("value", InputPrimitiveType.String)]);

            var plugin = ManagementMockHelpers.LoadMockPlugin(
                inputModels: () => [inputModel]);
            var model = plugin.Object.TypeFactory.CreateModel(inputModel)!;
            var modelFactory = plugin.Object.OutputLibrary.TypeProviders.OfType<ModelFactoryProvider>().Single();
            var lastContractView = new TestModelFactoryView(modelFactory.Name);
            var previousSignature = new MethodSignature(
                "TestModel",
                $"Creates a test model.",
                MethodSignatureModifiers.Public | MethodSignatureModifiers.Static,
                model.Type,
                $"A test model.",
                [new ParameterProvider("value", $"Value description", typeof(string))]);
            lastContractView.MethodsToBuild = [new MethodProvider(previousSignature, MethodBodyStatement.Empty, lastContractView)];
            SetLastContractView(modelFactory, lastContractView);
            modelFactory.Update(methods: []);

            var visitType = typeof(Management.Visitors.ModelFactoryVisitor).GetMethod(
                "VisitType",
                BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.That(visitType, Is.Not.Null);

            visitType!.Invoke(new Management.Visitors.ModelFactoryVisitor(), [modelFactory]);

            Assert.That(modelFactory.Methods, Has.Count.EqualTo(1));
            Assert.That(modelFactory.Methods[0].Signature.Name, Is.EqualTo("TestModel"));
            Assert.That(Management.Visitors.ModelFactoryBackwardCompatHelper.IsBackwardCompatMethod(modelFactory.Methods[0]), Is.True);
            var rendered = new TypeProviderWriter(modelFactory).Write().Content;
            Assert.That(rendered, Does.Contain("EditorBrowsable"));
            Assert.That(rendered, Does.Contain("EditorBrowsableState.Never"));
            Assert.That(rendered, Does.Contain("return new global::Samples.Models.TestModel"));
        }

        [Test]
        public void DoesNotRestoreLastContractFactoryMethodsImplementedByCustomCode()
        {
            var inputModel = InputFactory.Model(
                "TestModel",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Json,
                properties: [InputFactory.Property("value", InputPrimitiveType.String)]);

            var plugin = ManagementMockHelpers.LoadMockPlugin(
                inputModels: () => [inputModel]);
            var model = plugin.Object.TypeFactory.CreateModel(inputModel)!;
            var modelFactory = plugin.Object.OutputLibrary.TypeProviders.OfType<ModelFactoryProvider>().Single();
            var previousSignature = new MethodSignature(
                "TestModel",
                $"Creates a test model.",
                MethodSignatureModifiers.Public | MethodSignatureModifiers.Static,
                model.Type,
                $"A test model.",
                [new ParameterProvider("value", $"Value description", typeof(string))]);
            var lastContractView = new TestModelFactoryView(modelFactory.Name);
            lastContractView.MethodsToBuild = [new MethodProvider(previousSignature, MethodBodyStatement.Empty, lastContractView)];
            var customCodeView = new TestModelFactoryView(modelFactory.Name);
            customCodeView.MethodsToBuild = [new MethodProvider(previousSignature, MethodBodyStatement.Empty, customCodeView)];
            SetLastContractView(modelFactory, lastContractView);
            ManagementMockHelpers.SetCustomCodeView(modelFactory, customCodeView);
            modelFactory.Update(methods: []);

            var visitType = typeof(Management.Visitors.ModelFactoryVisitor).GetMethod(
                "VisitType",
                BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.That(visitType, Is.Not.Null);

            visitType!.Invoke(new Management.Visitors.ModelFactoryVisitor(), [modelFactory]);

            Assert.That(modelFactory.Methods, Is.Empty);
        }

        [Test]
        public void RebuildsPrimaryFactoryBodyFromCurrentConstructor()
        {
            var inputModel = InputFactory.Model(
                "TestModel",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Json,
                 properties:
                [
                    InputFactory.Property("id", InputPrimitiveType.String),
                    InputFactory.Property("name", InputPrimitiveType.String),
                ]);

            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [inputModel]);
            var model = plugin.Object.TypeFactory.CreateModel(inputModel)!;
            var modelFactory = plugin.Object.OutputLibrary.TypeProviders.OfType<ModelFactoryProvider>().Single();
            var idParameter = new ParameterProvider("id", $"", typeof(string));
            var nameParameter = new ParameterProvider("name", $"", typeof(string));
            var legacyParameter = new ParameterProvider("legacyValue", $"", typeof(string));
            var signature = new MethodSignature(
                "TestModel",
                $"Creates a test model.",
                MethodSignatureModifiers.Public | MethodSignatureModifiers.Static,
                model.Type,
                $"A test model.",
                [idParameter, nameParameter, legacyParameter]);
            var method = new MethodProvider(
                signature,
                Return(new NewInstanceExpression(model.Type, [nameParameter, idParameter])),
                modelFactory);
            modelFactory.Update(methods: [method]);

            Management.Visitors.ModelFactoryBackwardCompatHelper.FixModelFactoryConstructorCalls(modelFactory.Methods);

            var rendered = new TypeProviderWriter(modelFactory).Write().Content;
            Assert.That(rendered, Does.Contain("string legacyValue"));
            Assert.That(rendered, Does.Contain("return new global::Samples.Models.TestModel(id, name, ((global::System.Collections.Generic.IDictionary<string, global::System.BinaryData>)default));"));
        }

        [Test]
        public void SkipsAmbiguousDuplicateFactoryParameters()
        {
            var inputModel = InputFactory.Model(
                "TestModel",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Json,
                properties: [InputFactory.Property("name", InputPrimitiveType.String)]);

            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [inputModel]);
            var model = plugin.Object.TypeFactory.CreateModel(inputModel)!;
            var modelFactory = plugin.Object.OutputLibrary.TypeProviders.OfType<ModelFactoryProvider>().Single();
            var firstNameParameter = new ParameterProvider("name", $"", typeof(string));
            var secondNameParameter = new ParameterProvider("name", $"", typeof(string));
            var signature = new MethodSignature(
                "TestModel",
                $"Creates a test model.",
                MethodSignatureModifiers.Public | MethodSignatureModifiers.Static,
                model.Type,
                $"A test model.",
                [firstNameParameter, secondNameParameter]);
            var method = new MethodProvider(
                signature,
                Return(new NewInstanceExpression(model.Type, [firstNameParameter])),
                modelFactory);
            modelFactory.Update(methods: [method]);

            Assert.DoesNotThrow(() => Management.Visitors.ModelFactoryBackwardCompatHelper.FixModelFactoryConstructorCalls(modelFactory.Methods));
        }

        [Test]
        public void RebuildsDeserializeConstructorCallFromCurrentConstructor()
        {
            var inputModel = InputFactory.Model(
                "TestModel",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Json,
                properties:
                [
                    InputFactory.Property("id", InputPrimitiveType.String),
                    InputFactory.Property("name", InputPrimitiveType.String),
                ]);

            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [inputModel]);
            var model = plugin.Object.TypeFactory.CreateModel(inputModel)!;
            var modelFactory = plugin.Object.OutputLibrary.TypeProviders.OfType<ModelFactoryProvider>().Single();
            var id = new VariableExpression(typeof(string), "id");
            var name = new VariableExpression(typeof(string), "name");
            var staleNameDeclaration = Declare("name0", typeof(string), Default, out var staleName);
            var method = new MethodProvider(
                new MethodSignature(
                    "DeserializeTestModel",
                    null,
                    MethodSignatureModifiers.Internal | MethodSignatureModifiers.Static,
                    model.Type,
                    null,
                    []),
                MethodBodyStatement.Empty,
                modelFactory);
            method.Update(
                signature: method.Signature,
                bodyStatements: new MethodBodyStatement[]
                {
                    staleNameDeclaration,
                    Return(new NewInstanceExpression(model.Type, [id, name, staleName]))
                });
            modelFactory.Update(methods: [method]);

            Management.Visitors.ModelFactoryBackwardCompatHelper.FixConstructorCalls(modelFactory.Methods);

            var rendered = new TypeProviderWriter(modelFactory).Write().Content;
            Assert.That(rendered, Does.Not.Contain("name0"));
            Assert.That(rendered, Does.Contain("return new global::Samples.Models.TestModel(id, name, ((global::System.Collections.Generic.IDictionary<string, global::System.BinaryData>)default));"));
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

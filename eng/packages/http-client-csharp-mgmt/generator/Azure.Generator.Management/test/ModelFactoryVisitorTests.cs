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
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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
        public void BackwardCompatFactoryMethodIsPreservedForCurrentModelType()
        {
            var emptyModel = InputFactory.Model(
                "EmptyResourceData",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Json);

            var plugin = ManagementMockHelpers.LoadMockPlugin(
                inputModels: () => [emptyModel]);
            var model = plugin.Object.TypeFactory.CreateModel(emptyModel)!;
            var modelFactory = plugin.Object.OutputLibrary.TypeProviders.OfType<ModelFactoryProvider>().Single();

            var signature = new MethodSignature(
                "EmptyResourceData",
                $"Creates an empty resource.",
                MethodSignatureModifiers.Public | MethodSignatureModifiers.Static,
                model.Type,
                $"An empty resource.",
                [],
                Attributes: [new AttributeStatement(typeof(EditorBrowsableAttribute), FrameworkEnumValue(EditorBrowsableState.Never))]);
            var method = new MethodProvider(signature, MethodBodyStatement.Empty, modelFactory);

            Assert.That(Management.Visitors.ModelFactoryBackwardCompatHelper.ShouldPreserveBackwardCompatMethod(method, model.Type), Is.True);

            var lastContractView = new TestModelFactoryView(modelFactory.Name)
            {
                MethodsToBuild = [method]
            };
            SetLastContractView(modelFactory, lastContractView);

            var currentMethods = new List<MethodProvider>();
            Management.Visitors.ModelFactoryBackwardCompatHelper.AddBackwardCompatMethodsFromLastContractView(modelFactory, currentMethods);

            Assert.That(currentMethods, Has.Count.EqualTo(1));
            Assert.That(currentMethods[0].Signature.Name, Is.EqualTo("EmptyResourceData"));
        }

        [Test]
        public void PreviousFactoryMethodOrderIsPreservedWhenCurrentOrderDiffers()
        {
            var modelInput = InputFactory.Model(
                "ReorderedResourceData",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Json,
                properties:
                [
                    InputFactory.Property("name", InputPrimitiveType.String),
                    InputFactory.Property("count", InputPrimitiveType.Int32)
                ]);

            var plugin = ManagementMockHelpers.LoadMockPlugin(
                inputModels: () => [modelInput]);
            var model = plugin.Object.TypeFactory.CreateModel(modelInput)!;
            var modelFactory = plugin.Object.OutputLibrary.TypeProviders.OfType<ModelFactoryProvider>().Single();

            var nameParameter = new ParameterProvider("name", $"Name description", typeof(string));
            var countParameter = new ParameterProvider("count", $"Count description", typeof(int));
            var currentSignature = new MethodSignature(
                "ReorderedResourceData",
                $"Creates a reordered resource.",
                MethodSignatureModifiers.Public | MethodSignatureModifiers.Static,
                model.Type,
                $"A reordered resource.",
                [nameParameter, countParameter]);
            var currentMethod = new MethodProvider(currentSignature, MethodBodyStatement.Empty, modelFactory);

            var previousSignature = new MethodSignature(
                "ReorderedResourceData",
                $"Creates a reordered resource.",
                MethodSignatureModifiers.Public | MethodSignatureModifiers.Static,
                model.Type,
                $"A reordered resource.",
                [countParameter, nameParameter]);
            var previousMethod = new MethodProvider(previousSignature, MethodBodyStatement.Empty, modelFactory);
            var lastContractView = new TestModelFactoryView(modelFactory.Name)
            {
                MethodsToBuild = [previousMethod]
            };
            SetLastContractView(modelFactory, lastContractView);

            var currentMethods = new List<MethodProvider> { currentMethod };
            Management.Visitors.ModelFactoryBackwardCompatHelper.AddBackwardCompatMethodsFromLastContractView(modelFactory, currentMethods);

            Assert.That(currentMethods, Has.Count.EqualTo(2));
            var addedMethod = currentMethods[1];
            Assert.That(addedMethod.Signature.Parameters.Select(p => p.Name), Is.EqualTo(new[] { "count", "name" }));

            modelFactory.Update(methods: currentMethods);
            var rendered = new TypeProviderWriter(modelFactory).Write().Content;
            Assert.That(rendered, Does.Contain("ReorderedResourceData(int count, string name)"));
            Assert.That(rendered, Does.Contain("return ReorderedResourceData(name, count);"));
        }

        [Test]
        public void MissingFactoryMethodCanBeRestoredFromApiBaselineForCustomizedResourceData()
        {
            var propertiesInput = InputFactory.Model(
                "FileServiceUsageProperties",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Json);
            var dataInput = InputFactory.Model(
                "FileServiceUsageData",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Json);

            var plugin = ManagementMockHelpers.LoadMockPlugin(
                inputModels: () => [propertiesInput, dataInput]);
            _ = plugin.Object.TypeFactory.CreateModel(propertiesInput)!;
            _ = plugin.Object.TypeFactory.CreateModel(dataInput)!;
            var modelFactory = plugin.Object.OutputLibrary.TypeProviders.OfType<ModelFactoryProvider>().Single();
            modelFactory.Update(methods: []);

            var outputDirectory = Management.ManagementClientGenerator.Instance.Configuration.OutputDirectory;
            var apiDirectory = Path.Combine(outputDirectory, "api");
            Directory.CreateDirectory(apiDirectory);
            var apiFile = Path.Combine(apiDirectory, "sample-library.net10.0.cs");
            var customizeDirectory = Path.Combine(outputDirectory, "src", "Customize");
            Directory.CreateDirectory(customizeDirectory);
            var customizeFile = Path.Combine(customizeDirectory, "sample-libraryModelFactory.cs");
            var compatibilityFile = Path.Combine(outputDirectory, "src", "Generated", $"{modelFactory.Name}.Compatibility.cs");
            File.WriteAllText(apiFile, "        public static Samples.Models.FileServiceUsageData FileServiceUsageData(Azure.Core.ResourceIdentifier id, string name, Azure.Core.ResourceType resourceType, Azure.ResourceManager.Models.SystemData systemData, Samples.Models.FileServiceUsageProperties properties) { throw null; }");
            File.WriteAllText(customizeFile, """[CodeGenSuppress("FileServiceUsageData", typeof(ResourceIdentifier), typeof(string), typeof(ResourceType), typeof(SystemData), typeof(FileServiceUsageProperties))]""");
            try
            {
                var currentMethods = new List<MethodProvider>();
                Management.Visitors.ModelFactoryBackwardCompatHelper.AddBackwardCompatMethodsFromLastContractView(modelFactory, currentMethods);

                Assert.That(currentMethods, Has.Count.EqualTo(1));
                var addedMethod = currentMethods[0];
                Assert.That(addedMethod.Signature.Parameters.Select(p => p.Name), Is.EqualTo(new[] { "id", "name", "resourceType", "systemData", "properties" }));

                modelFactory.Update(methods: currentMethods);
                var rendered = new TypeProviderWriter(modelFactory).Write().Content;
                Assert.That(rendered, Does.Contain("FileServiceUsageData(global::Azure.Core.ResourceIdentifier id, string name, global::Azure.Core.ResourceType resourceType, global::Azure.ResourceManager.Models.SystemData systemData, global::Samples.Models.FileServiceUsageProperties properties)"));
                Assert.That(rendered, Does.Contain("return new global::Samples.Models.FileServiceUsageData("));
                Assert.That(rendered, Does.Contain("null,"));
                Assert.That(rendered, Does.Contain("properties);"));

                Management.Visitors.ModelFactoryBackwardCompatHelper.WriteSuppressedConstructorFactoryCompatibilityFile(outputDirectory);
                var compatibilityContent = File.ReadAllText(compatibilityFile);
                Assert.That(compatibilityContent, Does.Contain("public static global::Samples.Models.FileServiceUsageData FileServiceUsageData(global::Azure.Core.ResourceIdentifier id, string name, global::Azure.Core.ResourceType resourceType, global::Azure.ResourceManager.Models.SystemData systemData, global::Samples.Models.FileServiceUsageProperties properties)"));
                Assert.That(compatibilityContent, Does.Contain("return new global::Samples.Models.FileServiceUsageData(id, name, resourceType, systemData, null, properties);"));
            }
            finally
            {
                File.Delete(apiFile);
                File.Delete(customizeFile);
                File.Delete(compatibilityFile);
            }
        }

        [Test]
        public void AddsLegacyConstructorOverloadWhenPreviousOrderDiffers()
        {
            var modelInput = InputFactory.Model(
                "ConstructorOrderModel",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Json,
                properties:
                [
                    InputFactory.Property("name", InputPrimitiveType.String),
                    InputFactory.Property("count", InputPrimitiveType.Int32)
                ]);

            var plugin = ManagementMockHelpers.LoadMockPlugin(
                inputModels: () => [modelInput]);
            var model = plugin.Object.TypeFactory.CreateModel(modelInput)!;
            var fullParameters = model.FullConstructor.Signature.Parameters;
            Assert.That(fullParameters.Count, Is.GreaterThan(1));

            var previousParameters = fullParameters.Reverse().ToArray();
            var previousSignature = new ConstructorSignature(
                model.Type,
                $"Legacy constructor.",
                MethodSignatureModifiers.Internal,
                previousParameters);
            var previousConstructor = new ConstructorProvider(previousSignature, MethodBodyStatement.Empty, model);
            var lastContractView = new TestModelFactoryView(model.Name)
            {
                ConstructorsToBuild = [previousConstructor]
            };
            SetLastContractView(model, lastContractView);

            var originalConstructorCount = model.Constructors.Count;
            Management.Visitors.ConstructorCompatibilityVisitor.AddLegacyConstructorOverloads(model);

            Assert.That(model.Constructors.Count, Is.EqualTo(originalConstructorCount + 1));
            var addedConstructor = model.Constructors.Last();
            Assert.That(addedConstructor.Signature.Parameters.Select(p => p.Name), Is.EqualTo(previousParameters.Select(p => p.Name)));
            Assert.That(addedConstructor.Signature.Initializer, Is.Not.Null);
            Assert.That(addedConstructor.Signature.Initializer!.IsBase, Is.False);
            Assert.That(
                addedConstructor.Signature.Initializer.Arguments.OfType<VariableExpression>().Select(arg => arg.Declaration.RequestedName),
                Is.EqualTo(fullParameters.Select(p => p.Name)));
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

            public ConstructorProvider[] ConstructorsToBuild { get; set; } = [];

            protected override string BuildName() => _name;

            protected override string BuildRelativeFilePath() => $"{Name}.cs";

            protected override MethodProvider[] BuildMethods() => MethodsToBuild;

            protected override ConstructorProvider[] BuildConstructors() => ConstructorsToBuild;
        }
    }
}

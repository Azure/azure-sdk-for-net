// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Tests.Common;
using Azure.Generator.Management.Tests.TestHelpers;
using Microsoft.TypeSpec.Generator;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.SourceInput;
using Microsoft.TypeSpec.Generator.Statements;
using NUnit.Framework;
using System.Reflection;
using System.Text;
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

            ModelTestHelper.SetLastContractView(modelFactory, lastContractView);
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
            ModelTestHelper.SetLastContractView(modelFactory, lastContractView);
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
        public void RestoredFactoryMethodRegeneratesDocumentationFromCurrentModel()
        {
            var inputModel = InputFactory.Model(
                "TestModel",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Json,
                properties: [InputFactory.Property("value", InputPrimitiveType.String)]);

            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [inputModel]);
            var model = plugin.Object.TypeFactory.CreateModel(inputModel)!;
            model.FullConstructor.Signature.Parameters.Single(parameter => parameter.Name == "value")
                .Update(description: $"Current parameter summary.\nCurrent parameter details.");
            var modelFactory = plugin.Object.OutputLibrary.TypeProviders.OfType<ModelFactoryProvider>().Single();
            var previousMethod = CreatePreviousFactoryMethod(
                modelFactory,
                model.Type,
                "value",
                $"Previous parameter summary.\n            Previous parameter details.");

            Assert.That(
                Management.Visitors.ModelFactoryBackwardCompatHelper.TryCreateBackwardCompatMethod(
                    previousMethod,
                    modelFactory,
                    out var restoredMethod),
                Is.True);

            var docs = DescribeDocs(restoredMethod!);

            Assert.That(docs, Does.Contain("TestModel description"));
            Assert.That(docs, Does.Contain("Current parameter summary."));
            Assert.That(docs, Does.Contain("Current parameter details."));
            Assert.That(docs, Does.Not.Contain("Previous model summary."));
            Assert.That(docs, Does.Not.Contain("Previous parameter summary."));
            Assert.That(docs, Does.Not.Contain("Previous parameter details."));
            Assert.That(docs, Does.Contain("A new global::Samples.Models.TestModel instance for mocking."));
            Assert.That(docs, Does.Not.Contain("Previous return summary."));
        }

        [Test]
        public void RestoredFactoryMethodSignatureCarriesCurrentModelDescription()
        {
            var restored = BuildRestoredMethodWithUnmatchedParameter(
                $"Legacy parameter summary.\n            Legacy parameter details.");

            // The signature is the single source of the docs, so it must carry the current model's description.
            // Leaving it empty is what let a later rebuild silently produce no summary at all.
            Assert.That(restored.Signature.Description?.ToString(), Is.EqualTo("TestModel description"));

            var docs = DescribeDocs(restored);
            Assert.That(docs, Does.Contain("TestModel description"));
            Assert.That(docs, Does.Not.Contain("Legacy parameter details."));
            Assert.That(docs, Does.Not.Contain("Previous model summary."));
            Assert.That(docs, Does.Not.Contain("Previous return summary."));
        }

        [Test]
        public void RestoredFactoryMethodDocumentationSurvivesBackwardCompatOverloadFixup()
        {
            var inputModel = InputFactory.Model(
                "TestModel",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Json,
                properties: [InputFactory.Property("value", InputPrimitiveType.String)]);

            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [inputModel]);
            var model = plugin.Object.TypeFactory.CreateModel(inputModel)!;
            var modelFactory = plugin.Object.OutputLibrary.TypeProviders.OfType<ModelFactoryProvider>().Single();
            var previousMethod = CreatePreviousFactoryMethod(
                modelFactory,
                model.Type,
                "value",
                $"Previous parameter summary.\n            Previous parameter details.");

            Assert.That(
                Management.Visitors.ModelFactoryBackwardCompatHelper.TryCreateBackwardCompatMethod(
                    previousMethod,
                    modelFactory,
                    out var restoredMethod),
                Is.True);

            var primaryMethod = modelFactory.Methods.Single(
                method => !Management.Visitors.ModelFactoryBackwardCompatHelper.IsBackwardCompatMethod(method)
                    && method.Signature.Name == "TestModel");
            var docsBeforeFixup = DescribeDocs(restoredMethod!);

            Management.Visitors.ModelFactoryBackwardCompatHelper.FixModelFactoryBackwardCompatOverloads(
                [primaryMethod, restoredMethod!]);

            Assert.That(DescribeDocs(restoredMethod!), Is.EqualTo(docsBeforeFixup));
            Assert.That(docsBeforeFixup, Does.Not.Contain("Previous parameter details."));
        }

        [Test]
        public void RestoredFactoryMethodDropsUnmatchedLastContractDocumentation()
        {
            var restored = BuildRestoredMethodWithUnmatchedParameter(
                $"Legacy parameter summary.\n            \n             - First item.\n            Legacy parameter details.");
            var docs = DescribeDocs(restored);

            // The parameter no longer maps to the model, so there is no current description to regenerate. The
            // previous one is dropped rather than salvaged: it came back out of generated C# with its cref text
            // already lost and the writer's indentation baked in.
            Assert.That(docs, Does.Not.Contain("Legacy parameter"));
            Assert.That(docs, Does.Contain("<param name=\"legacyValue\">"));

            // Model factory methods are for mocking and never validate, so they must not document exceptions.
            Assert.That(restored.XmlDocs.Exceptions, Is.Empty);
        }

        [Test]
        public void RestoredFactoryMethodDocumentationIsIndependentOfLastContractIndentation()
        {
            // The indentation is varied on a parameter that still maps to the model as well as one that does not,
            // so this cannot pass merely because unmatched text is discarded.
            var firstDocs = DescribeDocs(BuildRestoredMethodWithIndentedLegacyDocs(
                $"Previous parameter summary.\n            Previous parameter details.",
                $"Legacy parameter summary.\n             - First item.\n            Legacy parameter details."));
            var secondDocs = DescribeDocs(BuildRestoredMethodWithIndentedLegacyDocs(
                $"Previous parameter summary.\n                        Previous parameter details.",
                $"Legacy parameter summary.\n                         - First item.\n                        Legacy parameter details."));

            Assert.That(secondDocs, Is.EqualTo(firstDocs));

            // The matched parameter is documented from the current model regardless of how the last contract was
            // indented, and no rendered line carries the writer's indentation. That growth is the #62444 regression.
            Assert.That(firstDocs, Does.Contain("Current parameter summary."));
            Assert.That(firstDocs, Does.Contain("Current parameter details."));
            Assert.That(firstDocs, Does.Not.Contain("Previous parameter details."));
            Assert.That(
                firstDocs.Split('\n').Any(line => line.StartsWith("      ")),
                Is.False,
                "regenerated documentation must not carry the last contract's continuation indentation");
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
            ModelTestHelper.SetLastContractView(modelFactory, lastContractView);
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
        public void DoesNotRestoreLastContractFactoryMethodsSuppressedByApiCompatBaseline()
        {
            var inputModel = InputFactory.Model(
                "TestModel",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Json,
                properties: [InputFactory.Property("value", InputPrimitiveType.String)]);

            var baseline = ApiCompatBaseline.Parse(
            [
                $"MembersMustExist : Member '{ResolveModelFactoryFullName(inputModel)}.TestModel(System.String)' does not exist in the implementation but it does exist in the contract."
            ]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(
                inputModels: () => [inputModel],
                apiCompatBaseline: baseline);
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
            ModelTestHelper.SetLastContractView(modelFactory, lastContractView);
            modelFactory.Update(methods: []);

            var visitType = typeof(Management.Visitors.ModelFactoryVisitor).GetMethod(
                "VisitType",
                BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.That(visitType, Is.Not.Null);

            visitType!.Invoke(new Management.Visitors.ModelFactoryVisitor(), [modelFactory]);

            Assert.That(modelFactory.Methods, Is.Empty);
        }

        [Test]
        public void DoesNotRestoreLastContractFactoryMethodsReferencingSuppressedTypes()
        {
            var inputModel = InputFactory.Model(
                "TestModel",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Json,
                properties: [InputFactory.Property("value", InputPrimitiveType.String)]);

            var baseline = ApiCompatBaseline.Parse(
            [
                "TypesMustExist : Type 'Samples.Models.RemovedModel' does not exist in the implementation but it does exist in the contract."
            ]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(
                inputModels: () => [inputModel],
                apiCompatBaseline: baseline);
            var model = plugin.Object.TypeFactory.CreateModel(inputModel)!;
            var modelFactory = plugin.Object.OutputLibrary.TypeProviders.OfType<ModelFactoryProvider>().Single();
            var removedType = new CSharpType(typeof(global::Samples.Models.RemovedModel));
            var previousSignature = new MethodSignature(
                "TestModel",
                $"Creates a test model.",
                MethodSignatureModifiers.Public | MethodSignatureModifiers.Static,
                model.Type,
                $"A test model.",
                [new ParameterProvider("removed", $"A parameter typed with a removed model.", removedType)]);
            var lastContractView = new TestModelFactoryView(modelFactory.Name);
            lastContractView.MethodsToBuild = [new MethodProvider(previousSignature, MethodBodyStatement.Empty, lastContractView)];
            ModelTestHelper.SetLastContractView(modelFactory, lastContractView);
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

        [Test]
        public void RebuildsDeserializeConstructorCallWithCasingOnlyDifference()
        {
            var inputModel = InputFactory.Model(
                "TestModel",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Json,
                properties:
                [
                    InputFactory.Property("vmwareId", InputPrimitiveType.String),
                ]);

            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [inputModel]);
            var model = plugin.Object.TypeFactory.CreateModel(inputModel)!;
            var modelFactory = plugin.Object.OutputLibrary.TypeProviders.OfType<ModelFactoryProvider>().Single();
            model.FullConstructor.Signature.Parameters[0].Update(name: "vMwareId");
            var vmwareId = new VariableExpression(typeof(string), "vmwareId");
            var method = new MethodProvider(
                new MethodSignature(
                    "DeserializeTestModel",
                    null,
                    MethodSignatureModifiers.Internal | MethodSignatureModifiers.Static,
                    model.Type,
                    null,
                    []),
                Return(new NewInstanceExpression(model.Type, [vmwareId])),
                modelFactory);
            modelFactory.Update(methods: [method]);

            Management.Visitors.ModelFactoryBackwardCompatHelper.FixConstructorCalls(modelFactory.Methods);

            var rendered = new TypeProviderWriter(modelFactory).Write().Content;
            Assert.That(rendered, Does.Contain("return new global::Samples.Models.TestModel(vmwareId, ((global::System.Collections.Generic.IDictionary<string, global::System.BinaryData>)default));"));
        }

        [Test]
        public void RebuildsDeserializeConstructorCallPrefersExactCasing()
        {
            var inputModel = InputFactory.Model(
                "TestModel",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Json,
                properties:
                [
                    InputFactory.Property("vmwareId", InputPrimitiveType.String),
                ]);

            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [inputModel]);
            var model = plugin.Object.TypeFactory.CreateModel(inputModel)!;
            var modelFactory = plugin.Object.OutputLibrary.TypeProviders.OfType<ModelFactoryProvider>().Single();
            var legacyVmwareId = new VariableExpression(typeof(string), "vMwareId");
            var vmwareId = new VariableExpression(typeof(string), "vmwareId");
            var method = new MethodProvider(
                new MethodSignature(
                    "DeserializeTestModel",
                    null,
                    MethodSignatureModifiers.Internal | MethodSignatureModifiers.Static,
                    model.Type,
                    null,
                    []),
                Return(new NewInstanceExpression(model.Type, [legacyVmwareId, vmwareId])),
                modelFactory);
            modelFactory.Update(methods: [method]);

            Management.Visitors.ModelFactoryBackwardCompatHelper.FixConstructorCalls(modelFactory.Methods);

            var rendered = new TypeProviderWriter(modelFactory).Write().Content;
            Assert.That(rendered, Does.Contain("return new global::Samples.Models.TestModel(vmwareId, ((global::System.Collections.Generic.IDictionary<string, global::System.BinaryData>)default));"));
            Assert.That(rendered, Does.Not.Contain("TestModel(vMwareId"));
        }

        private static MethodProvider CreatePreviousFactoryMethod(
            TypeProvider modelFactory,
            CSharpType returnType,
            string parameterName,
            FormattableString parameterDescription)
        {
            var previousSignature = new MethodSignature(
                "TestModel",
                $"Previous model summary.",
                MethodSignatureModifiers.Public | MethodSignatureModifiers.Static,
                returnType,
                $"Previous return summary.",
                [new ParameterProvider(parameterName, parameterDescription, typeof(string))]);
            var lastContractView = new TestModelFactoryView(modelFactory.Name);
            return new MethodProvider(previousSignature, MethodBodyStatement.Empty, lastContractView);
        }

        private static MethodProvider BuildRestoredMethodWithUnmatchedParameter(
            FormattableString parameterDescription)
        {
            var inputModel = InputFactory.Model(
                "TestModel",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Json,
                properties: [InputFactory.Property("value", InputPrimitiveType.String)]);

            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [inputModel]);
            var model = plugin.Object.TypeFactory.CreateModel(inputModel)!;

            var modelFactory = plugin.Object.OutputLibrary.TypeProviders.OfType<ModelFactoryProvider>().Single();
            var previousMethod = CreatePreviousFactoryMethod(
                modelFactory,
                model.Type,
                "legacyValue",
                parameterDescription);

            Assert.That(
                Management.Visitors.ModelFactoryBackwardCompatHelper.TryCreateBackwardCompatMethod(
                    previousMethod,
                    modelFactory,
                    out var restoredMethod),
                Is.True);

            return restoredMethod!;
        }

        private static MethodProvider BuildRestoredMethodWithIndentedLegacyDocs(
            FormattableString matchedLegacyDescription,
            FormattableString unmatchedLegacyDescription)
        {
            var inputModel = InputFactory.Model(
                "TestModel",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Json,
                properties: [InputFactory.Property("value", InputPrimitiveType.String)]);

            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [inputModel]);
            var model = plugin.Object.TypeFactory.CreateModel(inputModel)!;
            model.FullConstructor.Signature.Parameters.Single(parameter => parameter.Name == "value")
                .Update(description: $"Current parameter summary.\nCurrent parameter details.");

            var modelFactory = plugin.Object.OutputLibrary.TypeProviders.OfType<ModelFactoryProvider>().Single();
            var previousSignature = new MethodSignature(
                "TestModel",
                $"Previous model summary.",
                MethodSignatureModifiers.Public | MethodSignatureModifiers.Static,
                model.Type,
                $"Previous return summary.",
                [
                    new ParameterProvider("value", matchedLegacyDescription, typeof(string)),
                    new ParameterProvider("legacyValue", unmatchedLegacyDescription, typeof(string))
                ]);
            var lastContractView = new TestModelFactoryView(modelFactory.Name);
            var previousMethod = new MethodProvider(previousSignature, MethodBodyStatement.Empty, lastContractView);

            Assert.That(
                Management.Visitors.ModelFactoryBackwardCompatHelper.TryCreateBackwardCompatMethod(
                    previousMethod,
                    modelFactory,
                    out var restoredMethod),
                Is.True);

            return restoredMethod!;
        }

        private static string DescribeDocs(MethodProvider method)
        {
            var builder = new StringBuilder();
            builder.AppendLine("<summary>");
            foreach (var line in method.XmlDocs.Summary?.Lines ?? [])
            {
                builder.AppendLine(line.ToString());
            }

            foreach (var parameter in method.XmlDocs.Parameters)
            {
                builder.AppendLine($"<param name=\"{parameter.Parameter.Name}\">");
                foreach (var line in parameter.Lines)
                {
                    builder.AppendLine(line.ToString());
                }
            }

            if (method.XmlDocs.Returns is not null)
            {
                builder.AppendLine("<returns>");
                foreach (var line in method.XmlDocs.Returns.Lines)
                {
                    builder.AppendLine(line.ToString());
                }
            }

            return builder.ToString().Replace("\r\n", "\n");
        }

        /// <summary>
        /// Loads the mock plugin once purely to discover the fully-qualified name the model factory will be given,
        /// so a baseline entry can be written for it before the plugin is reloaded with that baseline attached.
        /// </summary>
        private static string ResolveModelFactoryFullName(InputModelType inputModel)
        {
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [inputModel]);
            return plugin.Object.OutputLibrary.TypeProviders.OfType<ModelFactoryProvider>().Single().Type.FullyQualifiedName;
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

        [Test]
        public void PrimaryFactoryMethodDocumentationSurvivesConstructorCallFixup()
        {
            var inputModel = InputFactory.Model(
                "TestModel",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Json,
                properties: [InputFactory.Property("value", InputPrimitiveType.String)]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [inputModel]);
            _ = plugin.Object.TypeFactory.CreateModel(inputModel)!;
            var modelFactory = plugin.Object.OutputLibrary.TypeProviders.OfType<ModelFactoryProvider>().Single();

            var before = DescribeDocs(modelFactory.Methods.Single());
            Assert.That(before, Does.Contain("TestModel description"));

            Management.Visitors.ModelFactoryBackwardCompatHelper.FixModelFactoryConstructorCalls(modelFactory.Methods);

            // Rebuilding the constructor call only changes the body. The summary that core attached to the primary
            // factory method lives on the XmlDocProvider, not on the (empty) signature description, so a signature
            // round-trip would silently erase it.
            Assert.That(DescribeDocs(modelFactory.Methods.Single()), Is.EqualTo(before));
        }
}
}

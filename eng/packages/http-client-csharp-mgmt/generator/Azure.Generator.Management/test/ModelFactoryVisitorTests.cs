// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Primitives;
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
        public void ModelFactoryParametersPreserveSwappedLastContractNames()
        {
            Assert.That(
                PreservePreviousParameterNames(
                    ["createdOn", "lastUpdatedOn"],
                    ["lastUpdatedOn", "createdOn"]),
                Is.EqualTo(new[] { "lastUpdatedOn", "createdOn" }));
        }

        [Test]
        public void ModelFactoryParametersPreserveRotatedLastContractNames()
        {
            Assert.That(
                PreservePreviousParameterNames(
                    ["alertRuleName", "description", "provisioningState"],
                    ["description", "provisioningState", "alertRuleName"]),
                Is.EqualTo(new[] { "description", "provisioningState", "alertRuleName" }));
        }

        [Test]
        public void ModelFactoryParametersDoNotRestoreDuplicateLastContractNames()
        {
            Assert.That(
                PreservePreviousParameterNames(
                    ["firstName", "secondName"],
                    ["duplicateName", "duplicateName"]),
                Is.EqualTo(new[] { "firstName", "secondName" }));
        }

        [Test]
        public void ModelFactoryParameterDocsPreserveLastContractDescriptions()
        {
            var parentModel = InputFactory.Model(
                "TestResource",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Json);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [parentModel]);
            var model = plugin.Object.TypeFactory.CreateModel(parentModel)!;
            var modelFactory = plugin.Object.OutputLibrary.TypeProviders.OfType<ModelFactoryProvider>().Single();
            ParameterProvider[] currentParameters =
            [
                new ParameterProvider("createdOn", $"Created on description", typeof(DateTimeOffset?)),
                new ParameterProvider("lastUpdatedOn", $"Last updated on description", typeof(DateTimeOffset?))
            ];
            var method = new MethodProvider(
                new MethodSignature(
                    "TestResource",
                    $"Creates a test resource.",
                    MethodSignatureModifiers.Public | MethodSignatureModifiers.Static,
                    model.Type,
                    $"A test resource.",
                    currentParameters),
                MethodBodyStatement.Empty,
                modelFactory);
            var lastContractView = new TestModelFactoryView(modelFactory.Name);
            lastContractView.MethodsToBuild =
            [
                new MethodProvider(
                    new MethodSignature(
                        "TestResource",
                        $"Creates a test resource.",
                        MethodSignatureModifiers.Public | MethodSignatureModifiers.Static,
                        model.Type,
                        $"A test resource.",
                        [
                            new ParameterProvider("lastUpdatedOn", $"Last updated on description", typeof(DateTimeOffset?)),
                            new ParameterProvider("createdOn", $"Created on description", typeof(DateTimeOffset?))
                        ]),
                    MethodBodyStatement.Empty,
                    lastContractView)
            ];

            SetLastContractView(modelFactory, lastContractView);
            modelFactory.Update(methods: [method]);
            UpdateParameterNames(method);

            Assert.That(method.Signature.Parameters[0].Description?.ToString(), Is.EqualTo("Last updated on description"));
            Assert.That(method.Signature.Parameters[1].Description?.ToString(), Is.EqualTo("Created on description"));
        }

        [Test]
        public void ModelFactoryParameterCasingAndReorderingPreserveSemanticProviders()
        {
            var parentModel = InputFactory.Model(
                "TestResource",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Json);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [parentModel]);
            var model = plugin.Object.TypeFactory.CreateModel(parentModel)!;
            var modelFactory = plugin.Object.OutputLibrary.TypeProviders.OfType<ModelFactoryProvider>().Single();
            var method = new MethodProvider(
                new MethodSignature(
                    "TestResource",
                    $"Creates a test resource.",
                    MethodSignatureModifiers.Public | MethodSignatureModifiers.Static,
                    model.Type,
                    $"A test resource.",
                    [
                        new ParameterProvider("createdOn", $"Created on description", typeof(DateTimeOffset?)),
                        new ParameterProvider("lastUpdatedOn", $"Last updated on description", typeof(DateTimeOffset?))
                    ]),
                MethodBodyStatement.Empty,
                modelFactory);
            var lastContractView = new TestModelFactoryView(modelFactory.Name);
            lastContractView.MethodsToBuild =
            [
                new MethodProvider(
                    new MethodSignature(
                        "TestResource",
                        $"Creates a test resource.",
                        MethodSignatureModifiers.Public | MethodSignatureModifiers.Static,
                        model.Type,
                        $"A test resource.",
                        [
                            new ParameterProvider("LastUpdatedOn", $"Last updated on description", typeof(DateTimeOffset?)),
                            new ParameterProvider("CreatedOn", $"Created on description", typeof(DateTimeOffset?))
                        ]),
                    MethodBodyStatement.Empty,
                    lastContractView)
            ];

            SetLastContractView(modelFactory, lastContractView);
            modelFactory.Update(methods: [method]);
            UpdateParameterNames(method);

            Assert.That(method.Signature.Parameters.Select(parameter => parameter.Name), Is.EqualTo(new[] { "LastUpdatedOn", "CreatedOn" }));
            Assert.That(method.Signature.Parameters.Select(parameter => parameter.Description.ToString()), Is.EqualTo(new[] { "Last updated on description", "Created on description" }));
        }

        [Test]
        public void ModelFactoryParameterRenamesPreserveFlattenedArguments()
        {
            var propertiesModel = InputFactory.Model(
                "TestProperties",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Json,
                properties: [InputFactory.Property("value", InputPrimitiveType.String)]);
            var parentModel = InputFactory.Model(
                "TestResource",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Json,
                properties:
                [
                    InputFactory.Property("properties", propertiesModel),
                    InputFactory.Property("kind", InputPrimitiveType.String)
                ]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [parentModel, propertiesModel]);
            var model = plugin.Object.TypeFactory.CreateModel(parentModel)!;
            var properties = plugin.Object.TypeFactory.CreateModel(propertiesModel)!;
            var modelFactory = plugin.Object.OutputLibrary.TypeProviders.OfType<ModelFactoryProvider>().Single();
            var valueParameter = new ParameterProvider("value", $"Value description", typeof(string));
            var kindParameter = new ParameterProvider("kind", $"Kind description", typeof(string));
            var propertiesArguments = properties.FullConstructor.Signature.Parameters
                .Select(parameter => parameter.Name == "value" ? valueParameter : parameter.DefaultValue ?? Default)
                .ToArray();
            var modelArguments = model.FullConstructor.Signature.Parameters
                .Select(parameter => parameter.Name switch
                {
                    "properties" => New.Instance(properties.Type, propertiesArguments),
                    "kind" => kindParameter,
                    _ => parameter.DefaultValue ?? Default
                })
                .ToArray();
            var method = new MethodProvider(
                new MethodSignature(
                    "TestResource",
                    $"Creates a test resource.",
                    MethodSignatureModifiers.Public | MethodSignatureModifiers.Static,
                    model.Type,
                    $"A test resource.",
                    [valueParameter, kindParameter]),
                Return(New.Instance(model.Type, modelArguments)),
                modelFactory);
            var lastContractView = new TestModelFactoryView(modelFactory.Name);
            lastContractView.MethodsToBuild =
            [
                new MethodProvider(
                    new MethodSignature(
                        "TestResource",
                        $"Creates a test resource.",
                        MethodSignatureModifiers.Public | MethodSignatureModifiers.Static,
                        model.Type,
                        $"A test resource.",
                        [
                            new ParameterProvider("kind", $"Kind description", typeof(string)),
                            new ParameterProvider("value", $"Value description", typeof(string))
                        ]),
                    MethodBodyStatement.Empty,
                    lastContractView)
            ];

            SetLastContractView(modelFactory, lastContractView);
            modelFactory.Update(methods: [method]);
            UpdateParameterNames(method);
            Management.Visitors.ModelFactoryBackwardCompatHelper.FixModelFactoryConstructorCalls(modelFactory.Methods);

            var rendered = new TypeProviderWriter(modelFactory).Write().Content;
            Assert.That(rendered, Does.Contain("new global::Samples.Models.TestProperties(value"));
            Assert.That(rendered, Does.Contain("kind,"));
        }

        [Test]
        public void RebuildDoesNotReuseNestedParameterForSiblingModel()
        {
            var leftModel = InputFactory.Model(
                "LeftModel",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Json,
                properties: [InputFactory.Property("value", InputPrimitiveType.String)]);
            var rightModel = InputFactory.Model(
                "RightModel",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Json,
                properties: [InputFactory.Property("value", InputPrimitiveType.String)]);
            var parentModel = InputFactory.Model(
                "ParentModel",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Json,
                properties:
                [
                    InputFactory.Property("left", leftModel),
                    InputFactory.Property("right", rightModel)
                ]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [parentModel, leftModel, rightModel]);
            var parent = plugin.Object.TypeFactory.CreateModel(parentModel)!;
            var left = plugin.Object.TypeFactory.CreateModel(leftModel)!;
            _ = plugin.Object.TypeFactory.CreateModel(rightModel)!;
            var modelFactory = plugin.Object.OutputLibrary.TypeProviders.OfType<ModelFactoryProvider>().Single();
            var valueParameter = new ParameterProvider("value", $"Value description", typeof(string));
            var leftArguments = left.FullConstructor.Signature.Parameters
                .Select(parameter => parameter.Name == "value" ? valueParameter : parameter.DefaultValue ?? Default)
                .ToArray();
            var parentArguments = parent.FullConstructor.Signature.Parameters
                .Select(parameter => parameter.Name switch
                {
                    "left" => New.Instance(left.Type, leftArguments),
                    _ => parameter.DefaultValue ?? Default
                })
                .ToArray();
            var method = new MethodProvider(
                new MethodSignature(
                    "ParentModel",
                    $"Creates a parent model.",
                    MethodSignatureModifiers.Public | MethodSignatureModifiers.Static,
                    parent.Type,
                    $"A parent model.",
                    [valueParameter]),
                Return(New.Instance(parent.Type, parentArguments)),
                modelFactory);
            modelFactory.Update(methods: [method]);

            Management.Visitors.ModelFactoryBackwardCompatHelper.FixModelFactoryConstructorCalls(modelFactory.Methods);

            var rendered = new TypeProviderWriter(modelFactory).Write().Content;
            Assert.That(rendered, Does.Contain("new global::Samples.Models.LeftModel(value"));
            Assert.That(rendered, Does.Not.Contain("new global::Samples.Models.RightModel(value"));
        }

        [Test]
        public void RebuildScopesNestedParameterAcrossReorderedAndInsertedSiblingModels()
        {
            var leftModel = InputFactory.Model(
                "LeftModel",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Json,
                properties: [InputFactory.Property("value", InputPrimitiveType.String)]);
            var rightModel = InputFactory.Model(
                "RightModel",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Json,
                properties: [InputFactory.Property("value", InputPrimitiveType.String)]);
            var middleModel = InputFactory.Model(
                "MiddleModel",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Json,
                properties: [InputFactory.Property("value", InputPrimitiveType.String)]);
            var parentModel = InputFactory.Model(
                "ParentModel",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Json,
                properties:
                [
                    InputFactory.Property("middle", middleModel),
                    InputFactory.Property("right", rightModel),
                    InputFactory.Property("left", leftModel)
                ]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [parentModel, leftModel, rightModel, middleModel]);
            var parent = plugin.Object.TypeFactory.CreateModel(parentModel)!;
            var left = plugin.Object.TypeFactory.CreateModel(leftModel)!;
            _ = plugin.Object.TypeFactory.CreateModel(rightModel)!;
            _ = plugin.Object.TypeFactory.CreateModel(middleModel)!;
            var modelFactory = plugin.Object.OutputLibrary.TypeProviders.OfType<ModelFactoryProvider>().Single();
            Assert.That(parent.FullConstructor.Signature.Parameters.Take(3).Select(parameter => parameter.Name), Is.EqualTo(new[] { "middle", "right", "left" }));

            var valueParameter = new ParameterProvider("value", $"Value description", typeof(string));
            var leftArguments = left.FullConstructor.Signature.Parameters
                .Select(parameter => parameter.Name == "value" ? valueParameter : parameter.DefaultValue ?? Default)
                .ToArray();
            ValueExpression[] staleArguments = [New.Instance(left.Type, leftArguments), Default];
            var method = new MethodProvider(
                new MethodSignature(
                    "ParentModel",
                    $"Creates a parent model.",
                    MethodSignatureModifiers.Public | MethodSignatureModifiers.Static,
                    parent.Type,
                    $"A parent model.",
                    [valueParameter]),
                Return(New.Instance(parent.Type, staleArguments)),
                modelFactory);
            modelFactory.Update(methods: [method]);

            Management.Visitors.ModelFactoryBackwardCompatHelper.FixModelFactoryConstructorCalls(modelFactory.Methods);

            var rendered = new TypeProviderWriter(modelFactory).Write().Content;
            Assert.That(rendered, Does.Contain("new global::Samples.Models.LeftModel(value"));
            Assert.That(rendered, Does.Not.Contain("new global::Samples.Models.RightModel(value"));
            Assert.That(rendered, Does.Not.Contain("new global::Samples.Models.MiddleModel(value"));
        }

        [Test]
        public void RebuildScopesGuardedNestedParameterAcrossReorderedAndInsertedSiblingModels()
        {
            var leftModel = InputFactory.Model(
                "LeftModel",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Json,
                properties: [InputFactory.Property("value", InputPrimitiveType.String)]);
            var rightModel = InputFactory.Model(
                "RightModel",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Json,
                properties: [InputFactory.Property("value", InputPrimitiveType.String)]);
            var middleModel = InputFactory.Model(
                "MiddleModel",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Json,
                properties: [InputFactory.Property("value", InputPrimitiveType.String)]);
            var parentModel = InputFactory.Model(
                "ParentModel",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Json,
                properties:
                [
                    InputFactory.Property("middle", middleModel),
                    InputFactory.Property("right", rightModel),
                    InputFactory.Property("left", leftModel)
                ]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [parentModel, leftModel, rightModel, middleModel]);
            var parent = plugin.Object.TypeFactory.CreateModel(parentModel)!;
            var left = plugin.Object.TypeFactory.CreateModel(leftModel)!;
            _ = plugin.Object.TypeFactory.CreateModel(rightModel)!;
            _ = plugin.Object.TypeFactory.CreateModel(middleModel)!;
            var leftProperty = parent.Properties.Single(property => property.Name == "Left");
            var leftValueProperty = left.Properties.Single(property => property.Name == "Value");
            var flattenedValue = new FlattenedPropertyProvider(
                $"Value description",
                MethodSignatureModifiers.Public,
                leftValueProperty.Type,
                "value",
                leftValueProperty.Body,
                parent,
                leftProperty,
                leftValueProperty);
            var valueParameter = flattenedValue.AsParameter;
            var leftArguments = left.FullConstructor.Signature.Parameters
                .Select(parameter => parameter.Name == "value" ? valueParameter : parameter.DefaultValue ?? Default)
                .ToArray();
            var guardedLeft = new TernaryConditionalExpression(
                valueParameter.Is(Null),
                Default,
                New.Instance(left.Type, leftArguments));
            ValueExpression[] staleArguments = [guardedLeft, Default];
            var modelFactory = plugin.Object.OutputLibrary.TypeProviders.OfType<ModelFactoryProvider>().Single();
            var method = new MethodProvider(
                new MethodSignature(
                    "ParentModel",
                    $"Creates a parent model.",
                    MethodSignatureModifiers.Public | MethodSignatureModifiers.Static,
                    parent.Type,
                    $"A parent model.",
                    [valueParameter]),
                Return(New.Instance(parent.Type, staleArguments)),
                modelFactory);
            modelFactory.Update(methods: [method]);

            Management.Visitors.ModelFactoryBackwardCompatHelper.FixModelFactoryConstructorCalls(modelFactory.Methods);

            var rendered = new TypeProviderWriter(modelFactory).Write().Content;
            Assert.That(rendered, Does.Contain("new global::Samples.Models.LeftModel(value"));
            Assert.That(rendered, Does.Not.Contain("new global::Samples.Models.RightModel(value"));
            Assert.That(rendered, Does.Not.Contain("new global::Samples.Models.MiddleModel(value"));
        }

        [Test]
        public void RebuildScopesNestedParameterBetweenSameTypeSiblings()
        {
            var childModel = InputFactory.Model(
                "ChildModel",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Json,
                properties: [InputFactory.Property("value", InputPrimitiveType.String)]);
            var parentModel = InputFactory.Model(
                "ParentModel",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Json,
                properties:
                [
                    InputFactory.Property("right", childModel),
                    InputFactory.Property("left", childModel)
                ]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [parentModel, childModel]);
            var parent = plugin.Object.TypeFactory.CreateModel(parentModel)!;
            var child = plugin.Object.TypeFactory.CreateModel(childModel)!;
            var leftProperty = parent.Properties.Single(property => property.Name == "Left");
            var valueProperty = child.Properties.Single(property => property.Name == "Value");
            var flattenedValue = new FlattenedPropertyProvider(
                $"Value description",
                MethodSignatureModifiers.Public,
                valueProperty.Type,
                "value",
                valueProperty.Body,
                parent,
                leftProperty,
                valueProperty);
            var valueParameter = flattenedValue.AsParameter;
            var childArguments = child.FullConstructor.Signature.Parameters
                .Select(parameter => parameter.Name == "value" ? valueParameter : parameter.DefaultValue ?? Default)
                .ToArray();
            ValueExpression[] staleArguments = [New.Instance(child.Type, childArguments), Default];
            var modelFactory = plugin.Object.OutputLibrary.TypeProviders.OfType<ModelFactoryProvider>().Single();
            var method = new MethodProvider(
                new MethodSignature(
                    "ParentModel",
                    $"Creates a parent model.",
                    MethodSignatureModifiers.Public | MethodSignatureModifiers.Static,
                    parent.Type,
                    $"A parent model.",
                    [valueParameter]),
                Return(New.Instance(parent.Type, staleArguments)),
                modelFactory);
            modelFactory.Update(methods: [method]);

            Management.Visitors.ModelFactoryBackwardCompatHelper.FixModelFactoryConstructorCalls(modelFactory.Methods);

            var rendered = new TypeProviderWriter(modelFactory).Write().Content;
            const string childCall = "new global::Samples.Models.ChildModel(value";
            var parentCall = rendered[rendered.IndexOf("return new global::Samples.Models.ParentModel(", StringComparison.Ordinal)..];
            Assert.That(parentCall, Does.Contain(childCall));
            Assert.That(parentCall.Split(childCall).Length - 1, Is.EqualTo(1));
            Assert.That(parentCall.IndexOf("default", StringComparison.Ordinal), Is.LessThan(parentCall.IndexOf(childCall, StringComparison.Ordinal)));
        }

        [Test]
        public void RebuildScopesNestedGrandchildParameterByPropertyPath()
        {
            var leafModel = InputFactory.Model(
                "LeafModel",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Json,
                properties: [InputFactory.Property("value", InputPrimitiveType.String)]);
            var branchModel = InputFactory.Model(
                "BranchModel",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Json,
                properties:
                [
                    InputFactory.Property("rightChild", leafModel),
                    InputFactory.Property("leftChild", leafModel)
                ]);
            var rootModel = InputFactory.Model(
                "RootModel",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Json,
                properties: [InputFactory.Property("wrapper", branchModel)]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [rootModel, branchModel, leafModel]);
            var root = plugin.Object.TypeFactory.CreateModel(rootModel)!;
            var branch = plugin.Object.TypeFactory.CreateModel(branchModel)!;
            var leaf = plugin.Object.TypeFactory.CreateModel(leafModel)!;
            var wrapperProperty = root.Properties.Single(property => property.Name == "Wrapper");
            var leftChildProperty = branch.Properties.Single(property => property.Name == "LeftChild");
            var valueProperty = leaf.Properties.Single(property => property.Name == "Value");
            var childValue = new FlattenedPropertyProvider(
                $"Value description",
                MethodSignatureModifiers.Public,
                valueProperty.Type,
                "value",
                valueProperty.Body,
                branch,
                leftChildProperty,
                valueProperty);
            var wrapperChildValue = new FlattenedPropertyProvider(
                $"Value description",
                MethodSignatureModifiers.Public,
                valueProperty.Type,
                "value",
                valueProperty.Body,
                root,
                wrapperProperty,
                childValue);
            var valueParameter = wrapperChildValue.AsParameter;
            var leafArguments = leaf.FullConstructor.Signature.Parameters
                .Select(parameter => parameter.Name == "value" ? valueParameter : parameter.DefaultValue ?? Default)
                .ToArray();
            ValueExpression[] staleBranchArguments = [New.Instance(leaf.Type, leafArguments), Default];
            var staleBranch = New.Instance(branch.Type, staleBranchArguments);
            var rootArguments = root.FullConstructor.Signature.Parameters
                .Select(parameter => parameter.Name == "wrapper" ? staleBranch : parameter.DefaultValue ?? Default)
                .ToArray();
            var modelFactory = plugin.Object.OutputLibrary.TypeProviders.OfType<ModelFactoryProvider>().Single();
            var method = new MethodProvider(
                new MethodSignature(
                    "RootModel",
                    $"Creates a root model.",
                    MethodSignatureModifiers.Public | MethodSignatureModifiers.Static,
                    root.Type,
                    $"A root model.",
                    [valueParameter]),
                Return(New.Instance(root.Type, rootArguments)),
                modelFactory);
            modelFactory.Update(methods: [method]);

            Management.Visitors.ModelFactoryBackwardCompatHelper.FixModelFactoryConstructorCalls(modelFactory.Methods);

            var rendered = new TypeProviderWriter(modelFactory).Write().Content;
            const string leafCall = "new global::Samples.Models.LeafModel(value";
            var branchCall = rendered[rendered.IndexOf("new global::Samples.Models.BranchModel(", StringComparison.Ordinal)..];
            Assert.That(branchCall, Does.Contain(leafCall));
            Assert.That(branchCall.Split(leafCall).Length - 1, Is.EqualTo(1));
            Assert.That(branchCall.IndexOf("default", StringComparison.Ordinal), Is.LessThan(branchCall.IndexOf(leafCall, StringComparison.Ordinal)));
        }

        [Test]
        public void RebuildResolvesCompleteFlattenedPropertyPath()
        {
            var applicationModel = InputFactory.Model(
                "ApplicationModel",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Json,
                properties: [InputFactory.Property("applications", InputPrimitiveType.String)]);
            var galleryModel = InputFactory.Model(
                "GalleryModel",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Json,
                properties: [InputFactory.Property("galleryProfile", applicationModel)]);
            var vmModel = InputFactory.Model(
                "VmModel",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Json,
                properties: [InputFactory.Property("vm", galleryModel)]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [vmModel, galleryModel, applicationModel]);
            var vm = plugin.Object.TypeFactory.CreateModel(vmModel)!;
            var gallery = plugin.Object.TypeFactory.CreateModel(galleryModel)!;
            var application = plugin.Object.TypeFactory.CreateModel(applicationModel)!;
            var vmProperty = vm.Properties.Single(property => property.Name == "Vm");
            var galleryProfileProperty = gallery.Properties.Single(property => property.Name == "GalleryProfile");
            var applicationsProperty = application.Properties.Single(property => property.Name == "Applications");
            var galleryApplications = new FlattenedPropertyProvider(
                $"Applications description",
                MethodSignatureModifiers.Public,
                applicationsProperty.Type,
                "galleryApplications",
                applicationsProperty.Body,
                gallery,
                galleryProfileProperty,
                applicationsProperty);
            var vmGalleryApplications = new FlattenedPropertyProvider(
                $"Applications description",
                MethodSignatureModifiers.Public,
                applicationsProperty.Type,
                "vmGalleryApplications",
                applicationsProperty.Body,
                vm,
                vmProperty,
                galleryApplications);
            var applicationsParameter = vmGalleryApplications.AsParameter;
            var modelFactory = plugin.Object.OutputLibrary.TypeProviders.OfType<ModelFactoryProvider>().Single();
            var method = new MethodProvider(
                new MethodSignature(
                    "VmModel",
                    $"Creates a VM model.",
                    MethodSignatureModifiers.Public | MethodSignatureModifiers.Static,
                    vm.Type,
                    $"A VM model.",
                    [applicationsParameter]),
                Return(New.Instance(
                    vm.Type,
                    vm.FullConstructor.Signature.Parameters.Select(parameter => parameter.DefaultValue ?? Default).ToArray())),
                modelFactory);
            modelFactory.Update(methods: [method]);

            Management.Visitors.ModelFactoryBackwardCompatHelper.FixModelFactoryConstructorCalls(modelFactory.Methods);

            var rendered = new TypeProviderWriter(modelFactory).Write().Content;
            Assert.That(rendered, Does.Contain("new global::Samples.Models.ApplicationModel(vmGalleryApplications"));
        }

        [Test]
        public void RebuildReservationsDistinguishSameNamedParametersByIdentity()
        {
            var detailsModel = InputFactory.Model(
                "DetailsModel",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Json,
                properties: [InputFactory.Property("value", InputPrimitiveType.String)]);
            var parentModel = InputFactory.Model(
                "ParentModel",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Json,
                properties:
                [
                    InputFactory.Property("value", InputPrimitiveType.String),
                    InputFactory.Property("details", detailsModel)
                ]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [parentModel, detailsModel]);
            var parent = plugin.Object.TypeFactory.CreateModel(parentModel)!;
            var details = plugin.Object.TypeFactory.CreateModel(detailsModel)!;
            var valueProperty = parent.Properties.Single(property => property.Name == "Value");
            var detailsProperty = parent.Properties.Single(property => property.Name == "Details");
            var detailsValueProperty = details.Properties.Single(property => property.Name == "Value");
            var detailsValue = new FlattenedPropertyProvider(
                $"Details value description",
                MethodSignatureModifiers.Public,
                detailsValueProperty.Type,
                "value",
                detailsValueProperty.Body,
                parent,
                detailsProperty,
                detailsValueProperty);
            var valueParameter = new ParameterProvider("value", $"Value description", valueProperty.Type, property: valueProperty);
            var detailsValueParameter = detailsValue.AsParameter;
            var modelFactory = plugin.Object.OutputLibrary.TypeProviders.OfType<ModelFactoryProvider>().Single();
            var method = new MethodProvider(
                new MethodSignature(
                    "ParentModel",
                    $"Creates a parent model.",
                    MethodSignatureModifiers.Public | MethodSignatureModifiers.Static,
                    parent.Type,
                    $"A parent model.",
                    [valueParameter, detailsValueParameter]),
                Return(New.Instance(
                    parent.Type,
                    parent.FullConstructor.Signature.Parameters.Select(parameter => parameter.DefaultValue ?? Default).ToArray())),
                modelFactory);
            modelFactory.Update(methods: [method]);

            Management.Visitors.ModelFactoryBackwardCompatHelper.FixModelFactoryConstructorCalls(modelFactory.Methods);

            var rendered = new TypeProviderWriter(modelFactory).Write().Content;
            Assert.That(rendered, Does.Contain("new global::Samples.Models.ParentModel(value,"));
            Assert.That(rendered, Does.Contain("new global::Samples.Models.DetailsModel(value0"));
        }

        [Test]
        public void RebuildEnforcesReservationsBeforeContextualMatching()
        {
            var detailsModel = InputFactory.Model(
                "DetailsModel",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Json,
                properties: [InputFactory.Property("value", InputPrimitiveType.String)]);
            var parentModel = InputFactory.Model(
                "ParentModel",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Json,
                properties:
                [
                    InputFactory.Property("details", detailsModel),
                    InputFactory.Property("detailsValue", InputPrimitiveType.String)
                ]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [parentModel, detailsModel]);
            var parent = plugin.Object.TypeFactory.CreateModel(parentModel)!;
            _ = plugin.Object.TypeFactory.CreateModel(detailsModel)!;
            var detailsValueProperty = parent.Properties.Single(property => property.Name == "DetailsValue");
            var detailsValueParameter = new ParameterProvider(
                "detailsValue",
                $"Details value description",
                detailsValueProperty.Type,
                property: detailsValueProperty);
            var modelFactory = plugin.Object.OutputLibrary.TypeProviders.OfType<ModelFactoryProvider>().Single();
            var method = new MethodProvider(
                new MethodSignature(
                    "ParentModel",
                    $"Creates a parent model.",
                    MethodSignatureModifiers.Public | MethodSignatureModifiers.Static,
                    parent.Type,
                    $"A parent model.",
                    [detailsValueParameter]),
                Return(New.Instance(parent.Type, [detailsValueParameter, Default])),
                modelFactory);
            modelFactory.Update(methods: [method]);

            Management.Visitors.ModelFactoryBackwardCompatHelper.FixModelFactoryConstructorCalls(modelFactory.Methods);

            var rendered = new TypeProviderWriter(modelFactory).Write().Content;
            Assert.That(rendered, Does.Contain("new global::Samples.Models.ParentModel(((global::Samples.Models.DetailsModel)default), detailsValue"));
            Assert.That(rendered, Does.Not.Contain("new global::Samples.Models.DetailsModel(detailsValue"));
        }

        [Test]
        public void RebuildUsesCollisionPrefixWhenExactContextualNameIsReserved()
        {
            var detailsModel = InputFactory.Model(
                "DetailsModel",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Json,
                properties: [InputFactory.Property("value", InputPrimitiveType.String)]);
            var parentModel = InputFactory.Model(
                "ParentModel",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Json,
                properties:
                [
                    InputFactory.Property("details", detailsModel),
                    InputFactory.Property("detailsValue", InputPrimitiveType.String)
                ]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [parentModel, detailsModel]);
            var parent = plugin.Object.TypeFactory.CreateModel(parentModel)!;
            var details = plugin.Object.TypeFactory.CreateModel(detailsModel)!;
            var detailsProperty = parent.Properties.Single(property => property.Name == "Details");
            var detailsValueProperty = parent.Properties.Single(property => property.Name == "DetailsValue");
            var valueProperty = details.Properties.Single(property => property.Name == "Value");
            var nestedValue = new FlattenedPropertyProvider(
                $"Nested value description",
                MethodSignatureModifiers.Public,
                valueProperty.Type,
                "valueDetailsValue",
                valueProperty.Body,
                parent,
                detailsProperty,
                valueProperty);
            var detailsValueParameter = new ParameterProvider(
                "detailsValue",
                $"Details value description",
                detailsValueProperty.Type,
                property: detailsValueProperty);
            var nestedValueParameter = nestedValue.AsParameter;
            var modelFactory = plugin.Object.OutputLibrary.TypeProviders.OfType<ModelFactoryProvider>().Single();
            var method = new MethodProvider(
                new MethodSignature(
                    "ParentModel",
                    $"Creates a parent model.",
                    MethodSignatureModifiers.Public | MethodSignatureModifiers.Static,
                    parent.Type,
                    $"A parent model.",
                    [detailsValueParameter, nestedValueParameter]),
                Return(New.Instance(parent.Type, [detailsValueParameter, Default])),
                modelFactory);
            modelFactory.Update(methods: [method]);

            Management.Visitors.ModelFactoryBackwardCompatHelper.FixModelFactoryConstructorCalls(modelFactory.Methods);

            var rendered = new TypeProviderWriter(modelFactory).Write().Content;
            Assert.That(rendered, Does.Contain("new global::Samples.Models.DetailsModel(valueDetailsValue"));
            Assert.That(rendered, Does.Contain(")), detailsValue"));
        }

        [Test]
        public void RebuildDoesNotReserveFlattenedParameterForSameNamedTopLevelProperty()
        {
            var detailsModel = InputFactory.Model(
                "DetailsModel",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Json,
                properties: [InputFactory.Property("value", InputPrimitiveType.String)]);
            var parentModel = InputFactory.Model(
                "ParentModel",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Json,
                properties:
                [
                    InputFactory.Property("details", detailsModel),
                    InputFactory.Property("detailsValue", InputPrimitiveType.String)
                ]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [parentModel, detailsModel]);
            var parent = plugin.Object.TypeFactory.CreateModel(parentModel)!;
            var details = plugin.Object.TypeFactory.CreateModel(detailsModel)!;
            var detailsProperty = parent.Properties.Single(property => property.Name == "Details");
            var valueProperty = details.Properties.Single(property => property.Name == "Value");
            var flattenedValue = new FlattenedPropertyProvider(
                $"Details value description",
                MethodSignatureModifiers.Public,
                valueProperty.Type,
                "detailsValue",
                valueProperty.Body,
                parent,
                detailsProperty,
                valueProperty);
            var detailsValueParameter = flattenedValue.AsParameter;
            var modelFactory = plugin.Object.OutputLibrary.TypeProviders.OfType<ModelFactoryProvider>().Single();
            var method = new MethodProvider(
                new MethodSignature(
                    "ParentModel",
                    $"Creates a parent model.",
                    MethodSignatureModifiers.Public | MethodSignatureModifiers.Static,
                    parent.Type,
                    $"A parent model.",
                    [detailsValueParameter]),
                Return(New.Instance(
                    parent.Type,
                    parent.FullConstructor.Signature.Parameters.Select(parameter => parameter.DefaultValue ?? Default).ToArray())),
                modelFactory);
            modelFactory.Update(methods: [method]);

            Management.Visitors.ModelFactoryBackwardCompatHelper.FixModelFactoryConstructorCalls(modelFactory.Methods);

            var rendered = new TypeProviderWriter(modelFactory).Write().Content;
            Assert.That(rendered, Does.Contain("new global::Samples.Models.DetailsModel(detailsValue"));
            Assert.That(rendered, Does.Contain(")), ((string)default)"));
        }

        [Test]
        public void RebuildContextualMatchingRequiresCompletePathWords()
        {
            var idModel = InputFactory.Model(
                "IdModel",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Json,
                properties: [InputFactory.Property("name", InputPrimitiveType.String)]);
            var parentModel = InputFactory.Model(
                "ParentModel",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Json,
                properties: [InputFactory.Property("id", idModel)]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [parentModel, idModel]);
            var parent = plugin.Object.TypeFactory.CreateModel(parentModel)!;
            _ = plugin.Object.TypeFactory.CreateModel(idModel)!;
            var identityNameParameter = new ParameterProvider("identityName", $"Identity name description", typeof(string));
            var modelFactory = plugin.Object.OutputLibrary.TypeProviders.OfType<ModelFactoryProvider>().Single();
            var method = new MethodProvider(
                new MethodSignature(
                    "ParentModel",
                    $"Creates a parent model.",
                    MethodSignatureModifiers.Public | MethodSignatureModifiers.Static,
                    parent.Type,
                    $"A parent model.",
                    [identityNameParameter]),
                Return(New.Instance(
                    parent.Type,
                    parent.FullConstructor.Signature.Parameters.Select(parameter => parameter.DefaultValue ?? Default).ToArray())),
                modelFactory);
            modelFactory.Update(methods: [method]);

            Management.Visitors.ModelFactoryBackwardCompatHelper.FixModelFactoryConstructorCalls(modelFactory.Methods);

            var rendered = new TypeProviderWriter(modelFactory).Write().Content;
            Assert.That(rendered, Does.Not.Contain("new global::Samples.Models.IdModel(identityName"));
        }

        [Test]
        public void RebuildConsumesDuplicateNamedParametersByIdentity()
        {
            var leftModel = InputFactory.Model(
                "LeftModel",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Json,
                properties: [InputFactory.Property("value", InputPrimitiveType.String)]);
            var rightModel = InputFactory.Model(
                "RightModel",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Json,
                properties: [InputFactory.Property("value", InputPrimitiveType.String)]);
            var parentModel = InputFactory.Model(
                "ParentModel",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Json,
                properties:
                [
                    InputFactory.Property("left", leftModel),
                    InputFactory.Property("right", rightModel)
                ]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [parentModel, leftModel, rightModel]);
            var parent = plugin.Object.TypeFactory.CreateModel(parentModel)!;
            var left = plugin.Object.TypeFactory.CreateModel(leftModel)!;
            var right = plugin.Object.TypeFactory.CreateModel(rightModel)!;
            var leftValueProperty = left.Properties.Single(property => property.Name == "Value");
            var rightValueProperty = right.Properties.Single(property => property.Name == "Value");
            var leftValueParameter = new ParameterProvider(
                "value",
                $"Left value description",
                leftValueProperty.Type,
                property: leftValueProperty);
            var rightValueParameter = new ParameterProvider(
                "value",
                $"Right value description",
                rightValueProperty.Type,
                property: rightValueProperty);
            var modelFactory = plugin.Object.OutputLibrary.TypeProviders.OfType<ModelFactoryProvider>().Single();
            var method = new MethodProvider(
                new MethodSignature(
                    "ParentModel",
                    $"Creates a parent model.",
                    MethodSignatureModifiers.Public | MethodSignatureModifiers.Static,
                    parent.Type,
                    $"A parent model.",
                    [leftValueParameter, rightValueParameter]),
                Return(New.Instance(
                    parent.Type,
                    parent.FullConstructor.Signature.Parameters.Select(parameter => parameter.DefaultValue ?? Default).ToArray())),
                modelFactory);
            modelFactory.Update(methods: [method]);

            Management.Visitors.ModelFactoryBackwardCompatHelper.FixModelFactoryConstructorCalls(modelFactory.Methods);

            var rendered = new TypeProviderWriter(modelFactory).Write().Content;
            Assert.That(rendered, Does.Contain("new global::Samples.Models.LeftModel(value"));
            Assert.That(rendered, Does.Contain("new global::Samples.Models.RightModel(value0"));
        }

        [Test]
        public void ModelFactoryParametersPreserveLastContractNamesForSdkModels()
        {
            var inputModel = InputFactory.Model(
                "TestModel",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Json,
                properties:
                [
                    InputFactory.Property("firstValue", InputPrimitiveType.String),
                    InputFactory.Property("secondValue", InputPrimitiveType.String),
                    InputFactory.Property("jobTier", InputPrimitiveType.String)
                ]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [inputModel]);
            var model = plugin.Object.TypeFactory.CreateModel(inputModel)!;
            var modelFactory = plugin.Object.OutputLibrary.TypeProviders.OfType<ModelFactoryProvider>().Single();
            var method = new MethodProvider(
                new MethodSignature(
                    "TestModel",
                    $"Creates a test model.",
                    MethodSignatureModifiers.Public | MethodSignatureModifiers.Static,
                    model.Type,
                    $"A test model.",
                    [
                        new ParameterProvider("firstValue", $"First value description", typeof(string)),
                        new ParameterProvider("secondValue", $"Second value description", typeof(string)),
                        new ParameterProvider("jobTier", $"Job tier description", typeof(string))
                    ]),
                MethodBodyStatement.Empty,
                modelFactory);
            var lastContractView = new TestModelFactoryView(modelFactory.Name);
            lastContractView.MethodsToBuild =
            [
                new MethodProvider(
                    new MethodSignature(
                        "TestModel",
                        $"Creates a test model.",
                        MethodSignatureModifiers.Public | MethodSignatureModifiers.Static,
                        model.Type,
                        $"A test model.",
                        [
                            new ParameterProvider("secondValue", $"Second value description", typeof(string)),
                            new ParameterProvider("firstValue", $"First value description", typeof(string)),
                            new ParameterProvider("queueJobTier", $"Queue job tier description", typeof(string))
                        ]),
                    MethodBodyStatement.Empty,
                    lastContractView)
            ];

            SetLastContractView(modelFactory, lastContractView);
            modelFactory.Update(methods: [method]);

            var visitType = typeof(Management.Visitors.ModelFactoryVisitor).GetMethod(
                "VisitType",
                BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.That(visitType, Is.Not.Null);
            visitType!.Invoke(new Management.Visitors.ModelFactoryVisitor(), [modelFactory]);

            Assert.That(
                modelFactory.Methods.Single().Signature.Parameters.Select(parameter => parameter.Name),
                Is.EqualTo(new[] { "secondValue", "firstValue", "queueJobTier" }));
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

        private static string[] PreservePreviousParameterNames(string[] currentNames, string[] previousNames)
        {
            var parentModel = InputFactory.Model(
                "TestResource",
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Input | InputModelTypeUsage.Json);

            var plugin = ManagementMockHelpers.LoadMockPlugin(
                inputModels: () => [parentModel]);
            var model = plugin.Object.TypeFactory.CreateModel(parentModel)!;
            var modelFactory = plugin.Object.OutputLibrary.TypeProviders.OfType<ModelFactoryProvider>().Single();
            var currentParameters = currentNames
                .Select(name => new ParameterProvider(name, $"{name} description", typeof(string)))
                .ToArray();
            var method = new MethodProvider(
                new MethodSignature(
                    "TestResource",
                    $"Creates a test resource.",
                    MethodSignatureModifiers.Public | MethodSignatureModifiers.Static,
                    model.Type,
                    $"A test resource.",
                    currentParameters),
                MethodBodyStatement.Empty,
                modelFactory);

            var lastContractView = new TestModelFactoryView(modelFactory.Name);
            var previousParameters = previousNames
                .Select(name => new ParameterProvider(name, $"{name} description", typeof(string)))
                .ToArray();
            lastContractView.MethodsToBuild =
            [
                new MethodProvider(
                    new MethodSignature(
                        "TestResource",
                        $"Creates a test resource.",
                        MethodSignatureModifiers.Public | MethodSignatureModifiers.Static,
                        model.Type,
                        $"A test resource.",
                        previousParameters),
                    MethodBodyStatement.Empty,
                    lastContractView)
            ];

            SetLastContractView(modelFactory, lastContractView);
            modelFactory.Update(methods: [method]);

            UpdateParameterNames(method);

            return modelFactory.Methods.Single().Signature.Parameters.Select(parameter => parameter.Name).ToArray();
        }

        private static void UpdateParameterNames(MethodProvider method)
        {
            var updateParameterNames = typeof(Management.Visitors.ModelFactoryVisitor).GetMethod(
                "UpdateParameterNames",
                BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.That(updateParameterNames, Is.Not.Null);
            updateParameterNames!.Invoke(new Management.Visitors.ModelFactoryVisitor(), [method]);
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

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management;
using Azure.Generator.Management.Tests.Common;
using Azure.Generator.Management.Tests.TestHelpers;
using Azure.Generator.Management.Visitors;
using Azure.Core;
using Microsoft.CodeAnalysis;
using Microsoft.TypeSpec.Generator;
using Microsoft.TypeSpec.Generator.EmitterRpc;
using Microsoft.TypeSpec.Generator.Expressions;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using Microsoft.TypeSpec.Generator.SourceInput;
using Microsoft.TypeSpec.Generator.Statements;
using NUnit.Framework;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Reflection;
using System.Text;
using System.Text.Json;
using static Microsoft.TypeSpec.Generator.Snippets.Snippet;

namespace Azure.Generator.Mgmt.Tests
{
    internal class FlattenedCompatibilityTests
    {
        [Test]
        public void PreservesHistoricalLeafType(
            [Values] bool safeFlatten, [Values] bool previouslyNullable, [Values] bool wrapperRequired, [Values] bool leafRequired)
        {
            var propertyName = safeFlatten ? "CapacitySize" : "Size";
            var (plugin, model, inner) = CreateCapacityModel(safeFlatten, wrapperRequired, leafRequired);
            var previous = new ContractView(model.Name);
            previous.ContractProperties =
            [
                new PropertyProvider(null, MethodSignatureModifiers.Public,
                    new CSharpType(typeof(long), isNullable: previouslyNullable), propertyName,
                    new AutoPropertyBody(true), previous)
            ];
            ModelTestHelper.SetLastContractView(model, previous);

            Visit(model);

            var property = model.Properties.Single(p => p.Name == propertyName);
            Assert.That(property.Type, Is.EqualTo(new CSharpType(typeof(long), isNullable: previouslyNullable)));
            Assert.That(inner.Properties.Single(p => p.Name == "Size").Type.IsNullable, Is.EqualTo(!leafRequired),
                "Preserving the public API must not change the wire property's requiredness.");
            var text = plugin.Object.GetWriter(model).Write().Content;
            Assert.That(text, previouslyNullable || leafRequired
                ? Does.Not.Contain("Capacity.Size.GetValueOrDefault()")
                : Does.Contain("Capacity.Size.GetValueOrDefault()"));

            var type = Compile(plugin.Object).GetType("Samples.Models.CapacityModel")!;
            var instance = Activator.CreateInstance(type, nonPublic: true)!;
            var leaf = type.GetProperty(propertyName)!;
            Assert.That(leaf.GetValue(instance), Is.EqualTo(previouslyNullable ? null : (object)0L),
                "An absent wrapper must be readable without changing its wire state.");
            Assert.That(type.GetProperty("Capacity", BindingFlags.Instance | BindingFlags.NonPublic)!.GetValue(instance), Is.Null);
            if (!wrapperRequired)
            {
                using var absent = JsonDocument.Parse(ModelReaderWriter.Write(instance, new ModelReaderWriterOptions("W")));
                Assert.That(absent.RootElement.TryGetProperty("capacity", out _), Is.False);
            }
            foreach (var value in new[] { 0L, long.MinValue, long.MaxValue, 37L })
            {
                leaf.SetValue(instance, value);
                Assert.That(leaf.GetValue(instance), Is.EqualTo(value));
                using var json = JsonDocument.Parse(ModelReaderWriter.Write(instance, new ModelReaderWriterOptions("J")));
                Assert.That(json.RootElement.GetProperty("capacity").GetProperty("size").GetInt64(), Is.EqualTo(value));
            }
            var roundTrip = ModelReaderWriter.Read(new BinaryData("""{"capacity":{"size":19}}"""), type, new ModelReaderWriterOptions("J"));
            Assert.That(leaf.GetValue(roundTrip), Is.EqualTo(19L));
            if (!leafRequired)
            {
                var omitted = ModelReaderWriter.Read(new BinaryData("""{"capacity":{}}"""), type, new ModelReaderWriterOptions("J"));
                Assert.That(leaf.GetValue(omitted), Is.EqualTo(previouslyNullable ? null : (object)0L));
                using var absentLeaf = JsonDocument.Parse(ModelReaderWriter.Write(omitted!, new ModelReaderWriterOptions("W")));
                Assert.That(absentLeaf.RootElement.GetProperty("capacity").TryGetProperty("size", out _), Is.False);
            }
            if (previouslyNullable && !leafRequired)
            {
                leaf.SetValue(instance, null);
                Assert.That(leaf.GetValue(instance), Is.Null);
                using var cleared = JsonDocument.Parse(ModelReaderWriter.Write(instance, new ModelReaderWriterOptions("W")));
                Assert.That(cleared.RootElement.GetProperty("capacity").TryGetProperty("size", out _), Is.False);
            }
            else if (previouslyNullable)
            {
                leaf.SetValue(instance, null);
                Assert.That(leaf.GetValue(instance), Is.EqualTo(safeFlatten ? null : (object)37L),
                    "Keep existing null-setter semantics for required wire leaves: safe flatten clears its wrapper; explicit flatten preserves siblings.");
            }
        }

        [Test]
        public void RestoredConstructorPreservesExactTypesAndValues([Values] bool previouslyNullable, [Values] bool wrapperRequired)
        {
            var oldType = previouslyNullable ? "long?" : "long";
            var sku = InputFactory.Model("CapacitySku", properties:
            [
                InputFactory.Property("name", InputPrimitiveType.String, isRequired: true),
                InputFactory.Property("tier", InputPrimitiveType.String)
            ]);
            var properties = InputFactory.Model("CapacityProperties", properties:
            [
                InputFactory.Property("sku", sku, isRequired: true),
                InputFactory.Property("baseSizeTiB", InputPrimitiveType.Int64),
                InputFactory.Property("extendedCapacitySizeTiB", InputPrimitiveType.Int64)
            ]);
            var wrapper = InputFactory.Property("properties", properties, isRequired: wrapperRequired);
            Flatten(wrapper);
            var input = InputFactory.Model("CapacityData", properties:
            [
                InputFactory.Property("location", InputFactory.Primitive.String("azureLocation", "Azure.Core.azureLocation"), isRequired: true),
                wrapper
            ]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(
                inputModels: () => [input, properties, sku],
                lastContractCompilation: () => Helpers.BuildCompilation(
                [
                    ("LastContract.cs", $$"""
                    namespace Samples.Models
                    {
                        public partial class CapacityData
                        {
                            public CapacityData(Azure.Core.AzureLocation location, CapacitySku sku, {{oldType}} baseSizeTiB, {{oldType}} extendedCapacitySizeTiB) { }
                            public Azure.Core.AzureLocation Location { get; set; }
                            public CapacitySku Sku { get; set; }
                            public {{oldType}} BaseSizeTiB { get; set; }
                            public {{oldType}} ExtendedCapacitySizeTiB { get; set; }
                        }
                        public partial class CapacitySku { }
                    }
                    """)
                ]));
            var model = plugin.Object.TypeFactory.CreateModel(input)!;
            var skuProvider = plugin.Object.TypeFactory.CreateModel(sku)!;
            Visit(model);
            ManagementMockHelpers.ProcessTypeForBackCompatibility(model);

            var constructors = model.Constructors.Where(c => c.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Public)).ToArray();
            Assert.That(constructors.Any(c => c.Signature.Parameters.Count == (wrapperRequired ? 2 : 1)), Is.True);
            var compatibility = constructors.Single(c => c.Signature.Parameters.Count == 4);
            Assert.That(compatibility.Signature.Parameters.Select(p => p.Type),
                Is.EqualTo(new CSharpType[] { typeof(AzureLocation), skuProvider.Type,
                    new(typeof(long), isNullable: previouslyNullable), new(typeof(long), isNullable: previouslyNullable) }),
                "Parameter count alone does not establish binary compatibility.");
            Assert.That(compatibility.Signature.Initializer!.IsBase, Is.False);
            Assert.That(compatibility.Signature.Initializer.Arguments.Select(a => a.ToDisplayString()),
                Is.EqualTo(wrapperRequired ? new[] { "location", "sku" } : new[] { "location" }));
            var body = compatibility.BodyStatements!.ToDisplayString();
            Assert.That(body, Does.Contain("BaseSizeTiB = baseSizeTiB"));
            Assert.That(body, Does.Contain("ExtendedCapacitySizeTiB = extendedCapacitySizeTiB"));

            var assembly = Compile(plugin.Object);
            var type = assembly.GetType("Samples.Models.CapacityData")!;
            var skuType = assembly.GetType("Samples.Models.CapacitySku")!;
            var skuInstance = Activator.CreateInstance(skuType, ["Premium"])!;
            var valueType = previouslyNullable ? typeof(long?) : typeof(long);
            var constructor = type.GetConstructor([typeof(AzureLocation), skuType, valueType, valueType]);
            Assert.That(constructor, Is.Not.Null);
            var instance = constructor!.Invoke([AzureLocation.WestUS, skuInstance, 23L, 41L]);
            Assert.That(type.GetProperty("Location")!.GetValue(instance), Is.EqualTo(AzureLocation.WestUS));
            Assert.That(type.GetProperty("Sku")!.GetValue(instance), Is.SameAs(skuInstance));
            Assert.That(type.GetProperty("BaseSizeTiB")!.GetValue(instance), Is.EqualTo(23L));
            Assert.That(type.GetProperty("ExtendedCapacitySizeTiB")!.GetValue(instance), Is.EqualTo(41L));
            using var json = JsonDocument.Parse(ModelReaderWriter.Write(instance, new ModelReaderWriterOptions("J")));
            Assert.That(json.RootElement.GetProperty("properties").GetProperty("baseSizeTiB").GetInt64(), Is.EqualTo(23L));
            Assert.That(json.RootElement.GetProperty("properties").GetProperty("extendedCapacitySizeTiB").GetInt64(), Is.EqualTo(41L));
            if (previouslyNullable)
            {
                var omitted = constructor.Invoke([AzureLocation.WestUS, skuInstance, null, null]);
                Assert.That(type.GetProperty("BaseSizeTiB")!.GetValue(omitted), Is.Null);
                Assert.That(type.GetProperty("ExtendedCapacitySizeTiB")!.GetValue(omitted), Is.Null);
            }
        }

        [Test]
        public void SafeFlattenRestoresExactConstructor([Values] bool previouslyNullable, [Values] bool wrapperRequired)
        {
            var oldType = previouslyNullable ? "long?" : "long";
            var inner = InputFactory.Model("CapacityProperties", properties: [InputFactory.Property("size", InputPrimitiveType.Int64)]);
            var input = InputFactory.Model("CapacityModel", properties:
            [
                InputFactory.Property("location", InputPrimitiveType.String, isRequired: true),
                InputFactory.Property("capacity", inner, isRequired: wrapperRequired)
            ]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [input, inner],
                lastContractCompilation: () => Helpers.BuildCompilation(
                [
                    ("LastContract.cs", $$"""
                    namespace Samples.Models
                    {
                        public partial class CapacityModel
                        {
                            public CapacityModel(string location, {{oldType}} capacitySize) { }
                            public string Location { get; set; }
                            public {{oldType}} CapacitySize { get; set; }
                        }
                    }
                    """)
                ]));
            var model = plugin.Object.TypeFactory.CreateModel(input)!;
            Visit(model);
            ManagementMockHelpers.ProcessTypeForBackCompatibility(model);
            var type = Compile(plugin.Object).GetType("Samples.Models.CapacityModel")!;
            var constructor = type.GetConstructor([typeof(string), previouslyNullable ? typeof(long?) : typeof(long)]);
            Assert.That(constructor, Is.Not.Null);
            var instance = constructor!.Invoke(["westus", 31L]);
            Assert.That(type.GetProperty("Location")!.GetValue(instance), Is.EqualTo("westus"));
            Assert.That(type.GetProperty("CapacitySize")!.GetValue(instance), Is.EqualTo(31L));
            using var json = JsonDocument.Parse(ModelReaderWriter.Write(instance, new ModelReaderWriterOptions("J")));
            Assert.That(json.RootElement.GetProperty("capacity").GetProperty("size").GetInt64(), Is.EqualTo(31L));
        }

        [Test]
        public void MixedHistoricalConstructorNullabilityRequiresCustomization(
            [Values] bool safeFlatten, [Values] bool wrapperRequired, [Values] bool nullableFirst,
            [Values("none", "custom", "partial-custom", "baseline", "baseline-nullable")] string resolution)
        {
            var name = safeFlatten ? "CapacitySize" : "Size";
            var parameterName = safeFlatten ? "capacitySize" : "size";
            var nonNullableConstructor = $"public CapacityModel(string location, long {parameterName}) {{ }}";
            var nullableConstructor = $"public CapacityModel(string location, long? {parameterName}) {{ }}";
            var inner = InputFactory.Model("CapacityProperties", properties: [InputFactory.Property("size", InputPrimitiveType.Int64)]);
            var wrapper = InputFactory.Property("capacity", inner, isRequired: wrapperRequired);
            if (!safeFlatten)
            {
                Flatten(wrapper);
            }
            var input = InputFactory.Model("CapacityModel", properties:
            [
                InputFactory.Property("location", InputPrimitiveType.String, isRequired: true),
                wrapper
            ]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(
                inputModels: () => [input, inner],
                apiCompatBaseline: resolution is "baseline" or "baseline-nullable" ? ApiCompatBaseline.Parse(
                    [$"MembersMustExist : Member 'Samples.Models.CapacityModel..ctor(System.String, {(resolution == "baseline" ? "System.Int64" : "System.Nullable<System.Int64>")})' does not exist in the implementation but it does exist in the contract."]) : null,
                customizationSources: resolution is "custom" or "partial-custom"
                    ? [$$"""
                        namespace Samples.Models
                        {
                            public partial class CapacityModel
                            {
                                public CapacityModel(string location, long {{parameterName}}) : this(location)
                                {
                                    {{name}} = {{parameterName}};
                                }
                                {{(resolution == "custom" ? $"public CapacityModel(string location, long? {parameterName}) : this(location) {{ {name} = {parameterName}; }}" : "")}}
                            }
                        }
                        """]
                    : null,
                lastContractCompilation: () => Helpers.BuildCompilation(
                [
                    ("LastContract.cs", $$"""
                    namespace Samples.Models
                    {
                        public partial class CapacityModel
                        {
                            {{(nullableFirst ? nullableConstructor : nonNullableConstructor)}}
                            {{(nullableFirst ? nonNullableConstructor : nullableConstructor)}}
                            public string Location { get; set; }
                            public long? {{name}} { get; set; }
                        }
                    }
                    """)
                ]));
            var model = plugin.Object.TypeFactory.CreateModel(input)!;
            using var diagnostics = CaptureDiagnostics(plugin);
            Visit(model);
            ManagementMockHelpers.ProcessTypeForBackCompatibility(model);
            _ = plugin.Object.GetWriter(model).Write();

            var constructors = model.Constructors.Concat(model.CustomCodeView?.Constructors ?? [])
                .Where(c => c.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Public)
                    && c.Signature.Parameters.Count == 2).ToArray();
            Assert.That(constructors.Any(c => c.Signature.Parameters[1].Type.Equals(new CSharpType(typeof(long?)))), Is.EqualTo(resolution is not ("partial-custom" or "baseline-nullable")));
            Assert.That(constructors.Any(c => c.Signature.Parameters[1].Type.Equals(new CSharpType(typeof(long)))), Is.EqualTo(resolution is "custom" or "partial-custom" or "baseline-nullable"));
            var messages = Encoding.UTF8.GetString(diagnostics.ToArray());
            Assert.That(messages.Contains("\"severity\":\"error\""), Is.EqualTo(resolution is "none" or "partial-custom"));
            if (resolution is "none" or "partial-custom")
            {
                Assert.That(messages, Does.Contain(resolution == "none" ? "CapacityModel(string, long)" : "CapacityModel(string, long?)"));
                Assert.That(messages, Does.Contain("custom constructor"));
            }
        }

        [Test]
        public void InternalHistoricalLeafDoesNotOverrideCurrentType([Values] bool safeFlatten)
        {
            var (plugin, model, _) = CreateCapacityModel(safeFlatten, wrapperRequired: false);
            var previous = new ContractView(model.Name);
            var name = safeFlatten ? "CapacitySize" : "Size";
            previous.ContractProperties =
            [
                new PropertyProvider(null, MethodSignatureModifiers.Internal, typeof(long), name, new AutoPropertyBody(true), previous)
            ];
            ModelTestHelper.SetLastContractView(model, previous);
            using var diagnostics = CaptureDiagnostics(plugin);
            Visit(model);
            _ = plugin.Object.GetWriter(model).Write();
            Assert.That(model.Properties.Single(p => p.Name == name).Type, Is.EqualTo(new CSharpType(typeof(long?))));
            Assert.That(Encoding.UTF8.GetString(diagnostics.ToArray()), Does.Not.Contain("\"severity\":\"error\""));
        }

        [Test]
        public void IncompatibleLeafTypeRequiresMappingUnlessCustomized([Values] bool safeFlatten, [Values] bool customized)
        {
            var (plugin, model, _) = CreateCapacityModel(safeFlatten, wrapperRequired: false);
            var previous = new ContractView(model.Name);
            var name = safeFlatten ? "CapacitySize" : "Size";
            previous.ContractProperties =
            [
                new PropertyProvider(null, MethodSignatureModifiers.Public, typeof(Uri), name, new AutoPropertyBody(true), previous)
            ];
            ModelTestHelper.SetLastContractView(model, previous);
            if (customized)
            {
                var custom = new ContractView(model.Name);
                custom.ContractProperties =
                [
                    new PropertyProvider(null, MethodSignatureModifiers.Public, typeof(Uri), name, new AutoPropertyBody(true), custom)
                ];
                ManagementMockHelpers.SetCustomCodeView(model, custom);
            }
            using var diagnostics = CaptureDiagnostics(plugin);
            Visit(model);
            var messages = Encoding.UTF8.GetString(diagnostics.ToArray());
            Assert.That(messages.Contains("\"severity\":\"error\""), Is.EqualTo(!customized));
            if (!customized)
            {
                Assert.That(messages, Does.Contain(name));
                Assert.That(messages, Does.Contain("explicit mapping"));
            }
        }

        [Test]
        public void LostSafeFlattenedLeafRequiresCustomization([Values(false, true)] bool customProperty, [Values(false, true)] bool acceptedRemoval)
        {
            var entries = InputFactory.Model("ManagedByResources", properties:
            [
                InputFactory.Property("clientId", InputPrimitiveType.String),
                InputFactory.Property("resourceIds", InputFactory.Array(InputPrimitiveType.String))
            ]);
            var input = InputFactory.Model("VolumePatch", properties:
            [
                InputFactory.Property("managedBy", InputFactory.Array(entries))
            ]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [input, entries],
                apiCompatBaseline: acceptedRemoval
                    ? ApiCompatBaseline.Parse(["MembersMustExist : Member 'Samples.Models.VolumePatch.ManagedByResourceId.get()' does not exist in the implementation but it does exist in the contract."])
                    : null,
                customizationSources: customProperty
                    ? ["namespace Samples.Models { public partial class VolumePatch { public Azure.Core.ResourceIdentifier ManagedByResourceId { get; set; } } }"]
                    : null,
                lastContractCompilation: () => Helpers.BuildCompilation(
                [
                    ("LastContract.cs", """
                    namespace Samples.Models
                    {
                        public partial class VolumePatch
                        {
                            public Azure.Core.ResourceIdentifier ManagedByResourceId { get; set; }
                        }
                    }
                    """)
                ]));
            using var diagnostics = CaptureDiagnostics(plugin);
            var model = plugin.Object.TypeFactory.CreateModel(input)!;
            Visit(model);
            _ = plugin.Object.GetWriter(model).Write();

            var messages = Encoding.UTF8.GetString(diagnostics.ToArray());
            if (customProperty || acceptedRemoval)
            {
                Assert.That(messages, Does.Not.Contain("\"severity\":\"error\""));
                return;
            }
            Assert.That(messages, Does.Contain("ManagedByResourceId"));
            Assert.That(messages, Does.Contain("customization"));
            Assert.That(messages, Does.Contain("\"severity\":\"error\""));
        }

        [TestCase(false)]
        [TestCase(true)]
        public void FactoryPreservesNestedValuesOrReportsUnmappedArgument(bool changedToArray)
        {
            var managed = InputFactory.Model("ManagedByInfo", properties: changedToArray
                ? [InputFactory.Property("clientId", InputPrimitiveType.String), InputFactory.Property("resourceIds", InputFactory.Array(InputPrimitiveType.String))]
                : [InputFactory.Property("resourceId", InputFactory.Primitive.String("armResourceIdentifier", "Azure.Core.armResourceIdentifier"))]);
            var properties = InputFactory.Model("VolumeProperties", properties:
            [
                InputFactory.Property("sizeGiB", InputPrimitiveType.Int64),
                InputFactory.Property("managedBy", changedToArray ? InputFactory.Array(managed) : managed)
            ]);
            var wrapper = InputFactory.Property("properties", properties);
            Flatten(wrapper);
            var input = InputFactory.Model("VolumePatch", properties: [wrapper]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [input, properties, managed],
                configurationJson: """{"package-name":"Samples"}""");
            using var diagnostics = CaptureDiagnostics(plugin);
            var model = plugin.Object.TypeFactory.CreateModel(input)!;
            Visit(model);
            var factory = plugin.Object.OutputLibrary.TypeProviders.OfType<ModelFactoryProvider>().Single();
            var previous = new ContractView(factory.Name);
            var signature = new MethodSignature("VolumePatch", null,
                MethodSignatureModifiers.Public | MethodSignatureModifiers.Static, model.Type, null,
                [
                    new ParameterProvider("sizeGiB", $"", typeof(long?), Default),
                    new ParameterProvider("managedByResourceId", $"", typeof(ResourceIdentifier), Default)
                ]);
            previous.ContractMethods = [new MethodProvider(signature, MethodBodyStatement.Empty, previous)];
            ModelTestHelper.SetLastContractView(factory, previous);
            ManagementMockHelpers.ProcessTypeForBackCompatibility(factory);
            _ = plugin.Object.GetWriter(factory).Write();

            var messages = Encoding.UTF8.GetString(diagnostics.ToArray());
            if (changedToArray)
            {
                Assert.That(messages, Does.Contain("managedByResourceId"));
                Assert.That(messages, Does.Not.Contain("parameter 'sizeGiB'"));
                Assert.That(messages, Does.Contain("custom factory overload"));
                Assert.That(messages, Does.Contain("\"severity\":\"error\""));
            }
            else
            {
                Assert.That(messages, Does.Not.Contain("\"severity\":\"error\""));
                var compatibility = factory.Methods.Single(ModelFactoryBackwardCompatHelper.IsBackwardCompatMethod);
                var body = compatibility.BodyStatements!.ToDisplayString();
                Assert.That(body, Does.Contain("managedByResourceId"));
                Assert.That(body, Does.Contain("new global::Samples.Models.ManagedByInfo(managedByResourceId"));
                Assert.That(body, Does.Contain("sizeGiB"));
                var assembly = Compile(plugin.Object, includeFactory: true);
                var method = assembly.GetType(factory.Type.FullyQualifiedName)!.GetMethod("VolumePatch", [typeof(long?), typeof(ResourceIdentifier)])!;
                var id = new ResourceIdentifier("/subscriptions/sub/resourceGroups/rg/providers/Test/widgets/a");
                var result = method.Invoke(null, [55L, id])!;
                Assert.That(result.GetType().GetProperty("SizeGiB")!.GetValue(result), Is.EqualTo(55L));
                Assert.That(result.GetType().GetProperty("ManagedByResourceId")!.GetValue(result),
                    Is.EqualTo(id));
                using var json = JsonDocument.Parse(ModelReaderWriter.Write(result, new ModelReaderWriterOptions("J")));
                Assert.That(json.RootElement.GetProperty("properties").GetProperty("managedBy").GetProperty("resourceId").GetString(),
                    Is.EqualTo("/subscriptions/sub/resourceGroups/rg/providers/Test/widgets/a"));
                var omitted = method.Invoke(null, [null, null])!;
                Assert.That(omitted.GetType().GetProperty("ManagedByResourceId")!.GetValue(omitted), Is.Null);
            }
        }

        [Test]
        public void FactoryDiagnosticHonorsCustomOverloadsAndBaseline([Values] bool customMethod, [Values] bool acceptedRemoval)
        {
            var input = InputFactory.Model("VolumePatch", properties: [InputFactory.Property("sizeGiB", InputPrimitiveType.Int64)]);
            var baseline = acceptedRemoval ? ApiCompatBaseline.Parse(
                ["MembersMustExist : Member 'Samples.SamplesModelFactory.VolumePatch(System.String)' does not exist in the implementation but it does exist in the contract."]) : null;
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [input], apiCompatBaseline: baseline,
                configurationJson: """{"package-name":"Samples"}""");
            var model = plugin.Object.TypeFactory.CreateModel(input)!;
            var factory = plugin.Object.OutputLibrary.TypeProviders.OfType<ModelFactoryProvider>().Single();
            var signature = new MethodSignature("VolumePatch", null, MethodSignatureModifiers.Public | MethodSignatureModifiers.Static,
                model.Type, null, [new ParameterProvider("managedByResourceId", $"", typeof(string))],
                Attributes: [new AttributeStatement(typeof(EditorBrowsableAttribute), FrameworkEnumValue(EditorBrowsableState.Never))]);
            var method = new MethodProvider(signature, Return(Default), factory);
            factory.Update(methods: [method]);
            if (customMethod)
            {
                var custom = new ContractView(factory.Name);
                custom.ContractMethods = [new MethodProvider(signature, Return(Default), custom)];
                ManagementMockHelpers.SetCustomCodeView(factory, custom);
            }
            using var diagnostics = CaptureDiagnostics(plugin);
            ModelFactoryBackwardCompatHelper.ValidateBackwardCompatArguments(factory);
            var messages = Encoding.UTF8.GetString(diagnostics.ToArray());
            Assert.That(messages.Contains("\"severity\":\"error\""), Is.EqualTo(!customMethod && !acceptedRemoval), factory.Type.FullyQualifiedName);
        }

        [Test]
        public void FactoryGuardAndNamedDefaultDoNotCountAsPreservedValues()
        {
            var input = InputFactory.Model("VolumePatch", properties: [InputFactory.Property("sizeGiB", InputPrimitiveType.Int64)]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [input]);
            var model = plugin.Object.TypeFactory.CreateModel(input)!;
            var factory = plugin.Object.OutputLibrary.TypeProviders.OfType<ModelFactoryProvider>().Single();
            var parameter = new ParameterProvider("managedByResourceId", $"", typeof(string));
            var signature = new MethodSignature("VolumePatch", null, MethodSignatureModifiers.Public | MethodSignatureModifiers.Static,
                model.Type, null, [parameter],
                Attributes: [new AttributeStatement(typeof(EditorBrowsableAttribute), FrameworkEnumValue(EditorBrowsableState.Never))]);
            var method = new MethodProvider(signature,
                new MethodBodyStatement[]
                {
                    parameter.Assign(Null, nullCoalesce: true).Terminate(),
                    Return(new TernaryConditionalExpression(parameter.Is(Null), Default,
                        New.Instance(model.Type, new PositionalParameterReferenceExpression(parameter.Name, Default))))
                }, factory);
            factory.Update(methods: [method]);
            using var diagnostics = CaptureDiagnostics(plugin);
            ModelFactoryBackwardCompatHelper.ValidateBackwardCompatArguments(factory);
            Assert.That(Encoding.UTF8.GetString(diagnostics.ToArray()), Does.Contain("managedByResourceId"));
        }

        [Test]
        public void FactoryValidationRecognizesNestedRenamedAndConvertedValues()
        {
            var timestamp = new InputDateTimeType(DateTimeKnownEncoding.Rfc3339, "utcDateTime", "TypeSpec.utcDateTime", InputPrimitiveType.String);
            var properties = InputFactory.Model("PolicyProperties", properties:
            [
                InputFactory.Property("startTime", timestamp),
                InputFactory.Property("count", InputPrimitiveType.Int64, isRequired: true),
                InputFactory.Property("tags", InputFactory.Array(InputPrimitiveType.String))
            ]);
            var input = InputFactory.Model("PolicyModel", properties: [InputFactory.Property("properties", properties)]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [input, properties]);
            var model = plugin.Object.TypeFactory.CreateModel(input)!;
            var inner = plugin.Object.TypeFactory.CreateModel(properties)!;
            var factory = plugin.Object.OutputLibrary.TypeProviders.OfType<ModelFactoryProvider>().Single();
            var signature = new MethodSignature("PolicyModel", null, MethodSignatureModifiers.Public | MethodSignatureModifiers.Static,
                model.Type, null,
                [
                    new ParameterProvider("legacyTimestamp", $"", typeof(DateTimeOffset?), Default,
                        property: inner.Properties.Single(p => p.Name == "StartsOn")),
                    new ParameterProvider("count", $"", typeof(long?), Default),
                    new ParameterProvider("tags", $"", typeof(IEnumerable<string>), Default)
                ]);
            var previous = new ContractView(factory.Name);
            previous.ContractMethods = [new MethodProvider(signature, MethodBodyStatement.Empty, previous)];
            ModelTestHelper.SetLastContractView(factory, previous);
            ManagementMockHelpers.ProcessTypeForBackCompatibility(factory);
            using var diagnostics = CaptureDiagnostics(plugin);
            _ = plugin.Object.GetWriter(factory).Write();
            Assert.That(Encoding.UTF8.GetString(diagnostics.ToArray()), Does.Not.Contain("\"severity\":\"error\""));
            var body = factory.Methods.Single(ModelFactoryBackwardCompatHelper.IsBackwardCompatMethod).BodyStatements!.ToDisplayString();
            Assert.That(body, Does.Contain("legacyTimestamp"));
            Assert.That(body, Does.Contain("count.GetValueOrDefault()"));
            Assert.That(body, Does.Contain("ToList()"));
        }

        private static (Moq.Mock<ManagementClientGenerator> Plugin, ModelProvider Model, ModelProvider Inner) CreateCapacityModel(
            bool safeFlatten, bool wrapperRequired, bool leafRequired = false)
        {
            var inner = InputFactory.Model("CapacityProperties", properties: [InputFactory.Property("size", InputPrimitiveType.Int64, isRequired: leafRequired)]);
            var wrapper = InputFactory.Property("capacity", inner, isRequired: wrapperRequired);
            if (!safeFlatten)
            {
                Flatten(wrapper);
            }
            var input = InputFactory.Model("CapacityModel", properties: [wrapper]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [input, inner]);
            return (plugin, plugin.Object.TypeFactory.CreateModel(input)!, plugin.Object.TypeFactory.CreateModel(inner)!);
        }

        private static void Flatten(InputModelProperty property)
            => typeof(InputModelProperty).GetProperty(nameof(InputModelProperty.Decorators))!.SetValue(property,
                new[] { new InputDecoratorInfo("Azure.ResourceManager.@flattenProperty", new Dictionary<string, BinaryData>()) });

        private static void Visit(ModelProvider model)
        {
            var visit = typeof(LibraryVisitor).GetMethod("VisitTypeCore", BindingFlags.NonPublic | BindingFlags.Instance)!;
            foreach (var visitor in ManagementClientGenerator.Instance.Visitors)
            {
                visit.Invoke(visitor, [model]);
            }
        }

        private static MemoryStream CaptureDiagnostics(Moq.Mock<ManagementClientGenerator> plugin)
        {
            var stream = new MemoryStream();
            var emitter = (Emitter)Activator.CreateInstance(typeof(Emitter),
                BindingFlags.Instance | BindingFlags.NonPublic, null, [stream], null)!;
            plugin.Setup(p => p.Emitter).Returns(emitter);
            return stream;
        }

        private static Assembly Compile(ManagementClientGenerator plugin, bool includeFactory = false)
        {
            var types = plugin.OutputLibrary.TypeProviders.Where(t => t is ModelProvider
                || (includeFactory && t is ModelFactoryProvider)
                || t.Name is "Argument" or "Optional" or "ChangeTrackingList" or "ChangeTrackingDictionary"
                    or "ModelSerializationExtensions" or "TypeFormatters" or "SerializationFormat" or "SamplesContext").ToArray();
            var documents = types.Concat(types.SelectMany(t => t.SerializationProviders))
                .Select(t => (t.Name + ".cs", plugin.GetWriter(t).Write().Content))
                // Scalar JSON paths do not need the separately source-generated context type builders.
                .Append(("Context.cs", """
                    namespace Samples
                    {
                        public partial class SamplesContext
                        {
                            public static SamplesContext Default { get; } = new SamplesContext();
                        }
                    }
                    """));
            var compilation = Helpers.BuildCompilation(documents)
                .WithAssemblyName("FlattenedCompatibility" + Guid.NewGuid().ToString("N"))
                .AddReferences(((string)AppContext.GetData("TRUSTED_PLATFORM_ASSEMBLIES")!).Split(Path.PathSeparator)
                    .Select(path => MetadataReference.CreateFromFile(path)));
            using var stream = new MemoryStream();
            var result = compilation.Emit(stream);
            Assert.That(result.Success, Is.True, string.Join(Environment.NewLine, result.Diagnostics.Where(d => d.Severity == DiagnosticSeverity.Error)));
            return Assembly.Load(stream.ToArray());
        }

        private sealed class ContractView(string name) : TypeProvider
        {
            public PropertyProvider[] ContractProperties { get; set; } = [];
            public MethodProvider[] ContractMethods { get; set; } = [];
            protected override string BuildName() => name;
            protected override string BuildRelativeFilePath() => $"{Name}.cs";
            protected override PropertyProvider[] BuildProperties() => ContractProperties;
            protected override MethodProvider[] BuildMethods() => ContractMethods;
        }
    }
}

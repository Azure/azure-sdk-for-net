// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Providers;
using Azure.Generator.Management.Tests.Common;
using Azure.Generator.Management.Tests.TestHelpers;
using Azure.Generator.Management.Visitors;
using Azure.Generator.Management;
using Azure.ResourceManager;
using Azure.ResourceManager.Models;
using Microsoft.TypeSpec.Generator.ClientModel.Providers;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using NUnit.Framework;
using System.Reflection;

namespace Azure.Generator.Mgmt.Tests
{
    public class ResourceDataModelProviderTests
    {
        [Test]
        public void ResourceDataModelProviderAvoidsStaleResourceClientCustomCodeView()
        {
            var (client, models) = InputResourceData.ClientWithResource();
            var resourceModel = models.Single();
            _ = ManagementMockHelpers.LoadMockPlugin(inputModels: () => models, clients: () => [client]);

            var modelProvider = new ResourceDataModelProvider(resourceModel);

            Assert.That(modelProvider.Name, Is.EqualTo("ResponseTypeData"));
            Assert.That(modelProvider.CustomCodeView, Is.Null);
            Assert.That(modelProvider.BaseType?.FrameworkType, Is.Not.EqualTo(typeof(ArmResource)));
        }

        [Test]
        public void ResourceDataModelUsesTrackedResourceDataBase()
        {
            var trackedResourceModel = InputFactory.Model(
                "TrackedResource",
                properties:
                [
                    InputFactory.Property("id", InputPrimitiveType.String, isReadOnly: true),
                    InputFactory.Property("name", InputPrimitiveType.String, isReadOnly: true),
                    InputFactory.Property("type", InputPrimitiveType.String, isReadOnly: true),
                    InputFactory.Property("location", InputPrimitiveType.String),
                ],
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Json);
            typeof(InputModelType).GetProperty(nameof(InputModelType.CrossLanguageDefinitionId))!
                .GetSetMethod(true)!
                .Invoke(trackedResourceModel, ["Azure.ResourceManager.CommonTypes.TrackedResource"]);

            var resourceModel = InputFactory.Model(
                "NewRelicMonitorResource",
                properties: [InputFactory.Property("properties", InputPrimitiveType.String)],
                baseModel: trackedResourceModel,
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Json);
            _ = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [trackedResourceModel, resourceModel]);

            var modelProvider = new ModelProvider(resourceModel);
            Assert.That(modelProvider.Name, Is.EqualTo("NewRelicMonitorResource"));
            Assert.That(modelProvider.BaseType?.AreNamesEqual(new CSharpType(typeof(TrackedResourceData))), Is.True);
        }

        [Test]
        public void ResourceDataModelWithTrackedResourceBaseFiltersInheritedPropertiesAndOverridesSerialization()
        {
            var trackedResourceModel = InputFactory.Model(
                "TrackedResource",
                properties:
                [
                    InputFactory.Property("id", InputPrimitiveType.String, isReadOnly: true),
                    InputFactory.Property("name", InputPrimitiveType.String, isReadOnly: true),
                    InputFactory.Property("type", InputPrimitiveType.String, isReadOnly: true),
                    InputFactory.Property("systemData", InputPrimitiveType.String, isReadOnly: true),
                    InputFactory.Property("location", InputPrimitiveType.String),
                    InputFactory.Property("tags", new InputDictionaryType("dict", InputPrimitiveType.String, InputPrimitiveType.String)),
                ],
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Json);
            typeof(InputModelType).GetProperty(nameof(InputModelType.CrossLanguageDefinitionId))!
                .GetSetMethod(true)!
                .Invoke(trackedResourceModel, ["Azure.ResourceManager.CommonTypes.TrackedResource"]);

            var resourceModel = InputFactory.Model(
                "PrivateCloud",
                properties:
                [
                    InputFactory.Property("name0", InputPrimitiveType.String, wireName: "name", serializedName: "name"),
                    InputFactory.Property("properties", InputPrimitiveType.String),
                ],
                baseModel: trackedResourceModel,
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Json);
            _ = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [trackedResourceModel, resourceModel]);
            var trackedResourceType = new CSharpType(typeof(TrackedResourceData));
            ManagementClientGenerator.Instance.TypeFactory.CSharpTypeMap[trackedResourceType] =
                new SystemObjectModelProvider(trackedResourceType, trackedResourceModel);

            var resourceDataModel = new ResourceDataModelProvider(resourceModel);
            // Reproduce the real generation ordering where constructors and serialization can be
            // built before inherited ARM properties are removed by the visitor.
            _ = resourceDataModel.Constructors;
            _ = resourceDataModel.SerializationProviders.SelectMany(s => s.Methods).ToArray();

            var visitor = new TestableInheritableSystemObjectModelVisitor();
            var result = visitor.InvokePreVisitModel(resourceModel, resourceDataModel);

            Assert.That(result, Is.Not.Null);
            Assert.That(result!.BaseModelProvider, Is.InstanceOf<SystemObjectModelProvider>());
            var propertyNames = result.Properties.Select(p => p.Name).ToList();
            Assert.That(propertyNames, Does.Not.Contain("Id"));
            Assert.That(propertyNames, Does.Not.Contain("Name"));
            Assert.That(propertyNames, Does.Not.Contain("ResourceType"));
            Assert.That(propertyNames, Does.Not.Contain("SystemData"));
            Assert.That(propertyNames, Does.Not.Contain("Tags"));
            Assert.That(propertyNames, Does.Not.Contain("Location"));
            Assert.That(propertyNames, Does.Contain("Name0"));
            Assert.That(propertyNames, Does.Contain("Properties"));

            var serialization = result.SerializationProviders.OfType<MrwSerializationTypeDefinition>().Single();
            var jsonModelWriteCore = serialization.Methods.Single(m => m.Signature.Name == "JsonModelWriteCore");
            Assert.That(jsonModelWriteCore.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Override), Is.True);

            var modelContent = new TypeProviderWriter(result).Write().Content;
            Assert.That(modelContent, Does.Contain("Name0"));

            var serializationContent = new TypeProviderWriter(serialization).Write().Content;
            Assert.That(serializationContent, Does.Contain("protected override void JsonModelWriteCore"));
            Assert.That(serializationContent, Does.Contain("base.JsonModelWriteCore(writer, options);"));
        }

        [Test]
        public void ResourceDataWithCustomBaseDeserializesInheritedMetadata()
        {
            var customBaseModel = InputFactory.Model(
                "SampleWritableResource",
                properties:
                [
                    InputFactory.Property("id", InputPrimitiveType.String, isReadOnly: true),
                    InputFactory.Property("name", InputPrimitiveType.String, isReadOnly: true),
                    InputFactory.Property("type", InputPrimitiveType.String, isReadOnly: true),
                ],
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Json);
            var childResourceModel = InputFactory.Model(
                "ChildResource",
                properties:
                [
                    InputFactory.Property("id", InputPrimitiveType.String, isReadOnly: true),
                    InputFactory.Property("name", InputPrimitiveType.String, isReadOnly: true),
                    InputFactory.Property("type", InputPrimitiveType.String, isReadOnly: true),
                    InputFactory.Property("etag", InputPrimitiveType.String, isReadOnly: true),
                    InputFactory.Property("properties", InputPrimitiveType.String),
                ],
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Json);
            _ = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [customBaseModel, childResourceModel]);

            var customBaseProvider = ManagementClientGenerator.Instance.TypeFactory.CreateModel(customBaseModel)!;
            var childProvider = new ResourceDataModelProvider(childResourceModel);
            SetCustomCodeView(childProvider, new CustomBaseCodeView(childProvider.Name, customBaseProvider.Type));

            // Reproduce the generation ordering where serialization can be built before the
            // inherited metadata properties are removed from the child model surface.
            _ = childProvider.Constructors;
            _ = childProvider.SerializationProviders.SelectMany(s => s.Methods).ToArray();

            var visitor = new TestableInheritableSystemObjectModelVisitor();
            var result = visitor.InvokePreVisitModel(childResourceModel, childProvider);

            Assert.That(result, Is.Not.Null);
            Assert.That(result!.BaseModelProvider, Is.SameAs(customBaseProvider));
            var propertyNames = result.Properties.Select(p => p.Name).ToList();
            Assert.That(propertyNames, Does.Not.Contain("Id"));
            Assert.That(propertyNames, Does.Not.Contain("Name"));
            Assert.That(propertyNames, Does.Not.Contain("ResourceType"));
            Assert.That(propertyNames, Does.Contain("ETag"));
            Assert.That(propertyNames, Does.Contain("Properties"));

            var serialization = result.SerializationProviders.OfType<MrwSerializationTypeDefinition>().Single();
            var serializationContent = new TypeProviderWriter(serialization).Write().Content;
            Assert.That(serializationContent, Does.Contain("string id = default;"));
            Assert.That(serializationContent, Does.Contain("string name = default;"));
            Assert.That(serializationContent, Does.Contain("string @type = default;"));
            Assert.That(serializationContent, Does.Contain("NameEquals(\"id\"u8)"));
            Assert.That(serializationContent, Does.Contain("NameEquals(\"name\"u8)"));
            Assert.That(serializationContent, Does.Contain("NameEquals(\"type\"u8)"));
            Assert.That(serializationContent, Does.Contain("id = prop.Value.GetString();"));
            Assert.That(serializationContent, Does.Contain("name = prop.Value.GetString();"));
            Assert.That(serializationContent, Does.Contain("@type = prop.Value.GetString();"));
            Assert.That(serializationContent, Does.Contain("new global::Samples.ChildResourceData("));
            Assert.That(serializationContent, Does.Contain("id,"));
            Assert.That(serializationContent, Does.Contain("name,"));
            Assert.That(serializationContent, Does.Contain("@type,"));
        }

        [Test]
        public void ResourceDataReferencesUseRootNamespaceForEquivalentInputModelInstances()
        {
            var (client, models) = InputResourceData.ClientWithResource();
            var resourceModel = models.Single();
            var equivalentResourceModel = InputFactory.Model(resourceModel.Name);
            var referencingModel = InputFactory.Model(
                "ApplicableScheduleProperties",
                properties: [InputFactory.Property("labVmsShutdown", equivalentResourceModel)]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(
                inputModels: () => [resourceModel, referencingModel],
                clients: () => [client]);

            var referencingModelProvider = plugin.Object.TypeFactory.CreateModel(referencingModel);

            Assert.That(referencingModelProvider, Is.Not.Null);
            var modelContent = new TypeProviderWriter(referencingModelProvider!).Write().Content;
            Assert.That(modelContent, Does.Contain("global::Samples.ResponseTypeData"));
            Assert.That(modelContent, Does.Not.Contain("global::Samples.Models.ResponseTypeData"));

            var serialization = referencingModelProvider!.SerializationProviders.OfType<MrwSerializationTypeDefinition>().Single();
            var serializationContent = new TypeProviderWriter(serialization).Write().Content;
            Assert.That(serializationContent, Does.Contain("global::Samples.ResponseTypeData"));
            Assert.That(serializationContent, Does.Not.Contain("global::Samples.Models.ResponseTypeData"));
        }

        [Test]
        public void ResourceDataSerializationUsesRootNamespaceForSelfReferences()
        {
            var (client, models) = InputResourceData.ClientWithResource();
            var resourceModel = models.Single();
            var plugin = ManagementMockHelpers.LoadMockPlugin(
                inputModels: () => models,
                clients: () => [client]);

            var resourceDataModel = plugin.Object.TypeFactory.CreateModel(resourceModel);
            Assert.That(resourceDataModel, Is.Not.Null);

            var visitor = new TestableResourceVisitor();
            var result = visitor.InvokeVisitType(resourceDataModel!);
            var serialization = result!.SerializationProviders.OfType<MrwSerializationTypeDefinition>().Single();
            var serializationContent = new TypeProviderWriter(serialization).Write().Content;

            Assert.That(serializationContent, Does.Not.Contain("Models.ResponseTypeData"));
            Assert.That(serializationContent, Does.Not.Contain("global::Samples.Models.ResponseTypeData"));
        }

        [Test]
        public void DerivedSerializationFromResponseHidesBaseWithNewModifier()
        {
            var baseModel = InputFactory.Model(
                "NetworkInterface",
                properties: [InputFactory.Property("id", InputPrimitiveType.String, isReadOnly: true)],
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Json);
            var derivedModel = InputFactory.Model(
                "VirtualMachineScaleSetNetworkInterface",
                properties: [InputFactory.Property("parentId", InputPrimitiveType.String, isReadOnly: true)],
                baseModel: baseModel,
                usage: InputModelTypeUsage.Output | InputModelTypeUsage.Json);
            var getBaseOperation = InputFactory.Operation(
                "getBase",
                responses: [InputFactory.OperationResponse([200], baseModel)],
                path: "/subscriptions/{subscriptionId}/providers/Microsoft.Tests/networkInterfaces/{networkInterfaceName}");
            var getBaseMethod = InputFactory.BasicServiceMethod(
                "getBase",
                getBaseOperation,
                response: InputFactory.ServiceMethodResponse(baseModel, null));
            var getDerivedOperation = InputFactory.Operation(
                "getDerived",
                responses: [InputFactory.OperationResponse([200], derivedModel)],
                path: "/subscriptions/{subscriptionId}/providers/Microsoft.Tests/networkInterfaces/{networkInterfaceName}");
            var getDerivedMethod = InputFactory.BasicServiceMethod(
                "getDerived",
                getDerivedOperation,
                response: InputFactory.ServiceMethodResponse(derivedModel, null));
            var client = InputFactory.Client("TestClient", methods: [getBaseMethod, getDerivedMethod]);
            var plugin = ManagementMockHelpers.LoadMockPlugin(inputModels: () => [baseModel, derivedModel], clients: () => [client]);
            var baseProvider = plugin.Object.TypeFactory.CreateModel(baseModel)!;
            var derivedProvider = plugin.Object.TypeFactory.CreateModel(derivedModel)!;
            var baseSerialization = baseProvider.SerializationProviders.OfType<MrwSerializationTypeDefinition>().Single();
            var derivedSerialization = derivedProvider.SerializationProviders.OfType<MrwSerializationTypeDefinition>().Single();
            var visitor = new TestableSerializationVisitor();

            foreach (var method in derivedSerialization.Methods)
            {
                visitor.InvokeVisitMethod(method);
            }

            var baseResponseOperator = baseSerialization.Methods.Single(m => m.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Operator)
                && m.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Explicit));
            var derivedFromResponse = derivedSerialization.Methods.Single(m => m.Signature.Name == SerializationVisitor.FromResponseMethodName);
            Assert.That(baseResponseOperator.Signature.Name, Is.Not.EqualTo(SerializationVisitor.FromResponseMethodName));
            Assert.That(derivedFromResponse.Signature.Modifiers.HasFlag(MethodSignatureModifiers.New), Is.True);
        }

        private class TestableInheritableSystemObjectModelVisitor : InheritableSystemObjectModelVisitor
        {
            public ModelProvider? InvokePreVisitModel(InputModelType inputType, ModelProvider? type)
            {
                return base.PreVisitModel(inputType, type);
            }
        }

        private class TestableResourceVisitor : ResourceVisitor
        {
            public TypeProvider? InvokeVisitType(TypeProvider type)
            {
                return base.VisitType(type);
            }
        }

        private class TestableSerializationVisitor : SerializationVisitor
        {
            public MethodProvider? InvokeVisitMethod(MethodProvider method)
            {
                return base.VisitMethod(method);
            }
        }

        private static void SetCustomCodeView(TypeProvider typeProvider, TypeProvider customCodeTypeProvider)
        {
            var currentType = typeProvider.GetType();
            while (currentType is not null)
            {
                var field = currentType.GetField("_customCodeView", BindingFlags.NonPublic | BindingFlags.Instance);
                if (field is not null)
                {
                    field.SetValue(typeProvider, new Lazy<TypeProvider>(() => customCodeTypeProvider));
                    return;
                }

                currentType = currentType.BaseType;
            }

            Assert.Fail("Could not find TypeProvider._customCodeView field.");
        }

        private class CustomBaseCodeView(string name, CSharpType baseType) : TypeProvider
        {
            protected override CSharpType BuildBaseType() => baseType;
            protected override string BuildName() => name;
            protected override string BuildRelativeFilePath() => $"{name}.cs";
        }
    }
}

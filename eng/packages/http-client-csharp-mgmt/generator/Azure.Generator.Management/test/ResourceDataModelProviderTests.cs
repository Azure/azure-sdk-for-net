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
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Models;
using Azure.Generator.Provisioning.Primitives;
using Azure.Generator.Provisioning.Providers;
using Azure.Generator.Provisioning.Tests.TestHelpers;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Input.Extensions;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json;

namespace Azure.Generator.Provisioning.Tests
{
    public class ProvisioningResourceProjectionTests
    {
        [SetUp]
        public void SetUp()
        {
            ProvisioningMockHelpers.LoadMockPlugin();
        }

        [Test]
        public void ProjectionDeserializesEmitterMetadata()
        {
            var model = CreateModel("TestResourceData");
            var method = CreateMethod(ResourceOperationKind.Create, ResourceScope.Extension);
            using var document = JsonDocument.Parse(
                """
                {
                  "resourceModelId": "Sample.Models.TestResourceData",
                  "resourceName": "TestResource",
                  "resourceType": "Microsoft.Test/widgets",
                  "singletonResourceName": "default",
                  "parentResourceId": "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Test/parents/{parentName}",
                  "nameConstraints": {
                    "pattern": "[a-z]+",
                    "minLength": 1,
                    "maxLength": 24
                  },
                  "resourceIdPatterns": [
                    "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Test/widgets/default"
                  ],
                  "apiVersions": [
                    "2024-01-01",
                    "2024-02-01"
                  ],
                  "methodIds": [
                    "Sample.CreateWidget"
                  ],
                  "rbacRoles": [
                    {
                      "name": "TestRole",
                      "value": "11111111-1111-1111-1111-111111111111"
                    }
                  ],
                  "readableScopes": [
                    "ResourceGroup"
                  ],
                  "writableScopes": [
                    "Extension"
                  ],
                  "isExtensionResource": true
                }
                """);

            var projection = ProvisioningResourceProjection.Deserialize(
                document.RootElement,
                new Dictionary<string, InputModelType> { [model.CrossLanguageDefinitionId] = model },
                new Dictionary<string, ResourceMethod> { [method.InputMethod.CrossLanguageDefinitionId] = method });

            Assert.That(projection.ResourceModel, Is.SameAs(model));
            Assert.That(projection.ResourceName, Is.EqualTo("TestResource"));
            Assert.That(projection.ResourceType, Is.EqualTo("Microsoft.Test/widgets"));
            Assert.That(projection.SingletonResourceName, Is.EqualTo("default"));
            Assert.That(projection.ParentResourceId!.SerializedPath, Is.EqualTo(
                "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Test/parents/{parentName}"));
            Assert.That(projection.NameConstraints, Is.EqualTo(new ArmResourceNameConstraints("[a-z]+", 1, 24)));
            Assert.That(projection.ResourceIdPatterns.Select(p => p.SerializedPath), Is.EqualTo(new[]
            {
                "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Test/widgets/default"
            }));
            Assert.That(projection.ApiVersions, Is.EqualTo(new[] { "2024-01-01", "2024-02-01" }));
            Assert.That(projection.Methods, Is.EqualTo(new[] { method }));
            Assert.That(projection.RbacRoles, Is.EqualTo(new[]
            {
                new ArmResourceRbacRole("TestRole", "11111111-1111-1111-1111-111111111111")
            }));
            Assert.That(projection.ReadableScopes, Is.EqualTo(new[] { ResourceScope.ResourceGroup }));
            Assert.That(projection.WritableScopes, Is.EqualTo(new[] { ResourceScope.Extension }));
            Assert.That(projection.IsExtensionResource, Is.True);
        }

        [Test]
        public void ReadOnlyResourcePropertiesAreNotSettable()
        {
            var writableProperty = CreateProperty("WritableValue");
            var model = CreateModel("ReadOnlyWidget", [writableProperty]);
            var readOnlyResource = CreateMetadata(
                model,
                "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Test/widgets/{widgetName}",
                "Microsoft.Test/widgets",
                ResourceScope.ResourceGroup,
                ["2024-01-01"],
                methods: [CreateMethod(ResourceOperationKind.Read, ResourceScope.ResourceGroup)]);
            ProvisioningMockHelpers.LoadMockPlugin(inputModels: () => [model]);
            var provider = CreateResourceProvider(readOnlyResource);

            var propertyInfo = ((IProvisioningPropertyInfo)provider).GetProvisioningPropertyInfo(writableProperty);

            Assert.That(propertyInfo, Is.Not.Null);
            Assert.That(propertyInfo!.IsOutput, Is.False);
            Assert.That(propertyInfo.IsSettable, Is.False);
        }

        [Test]
        public void UpdateOnlyResourcePropertiesAreNotSettable()
        {
            var writableProperty = CreateProperty("WritableValue");
            var model = CreateModel("UpdateOnlyWidget", [writableProperty]);
            var updateOnlyResource = CreateMetadata(
                model,
                "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Test/widgets/{widgetName}",
                "Microsoft.Test/widgets",
                ResourceScope.ResourceGroup,
                ["2024-01-01"],
                methods:
                [
                    CreateMethod(ResourceOperationKind.Read, ResourceScope.ResourceGroup),
                    CreateMethod(ResourceOperationKind.Update, ResourceScope.ResourceGroup)
                ]);
            ProvisioningMockHelpers.LoadMockPlugin(inputModels: () => [model]);
            var provider = CreateResourceProvider(updateOnlyResource);

            var propertyInfo = ((IProvisioningPropertyInfo)provider).GetProvisioningPropertyInfo(writableProperty);

            Assert.That(provider.ResourceProjection!.WritableScopes, Is.Empty);
            Assert.That(propertyInfo, Is.Not.Null);
            Assert.That(propertyInfo!.IsSettable, Is.False);
        }

        [Test]
        public void ReadOnlyExtensionResourceDoesNotExposeScopeMetadata()
        {
            var model = CreateModel("ReadOnlyExtension");
            var resource = CreateMetadata(
                model,
                "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Test/widgets/{widgetName}/providers/Microsoft.Test/extensions/{extensionName}",
                "Microsoft.Test/extensions",
                ResourceScope.Extension,
                ["2024-01-01"],
                methods: [CreateMethod(ResourceOperationKind.Read, ResourceScope.Extension)]);
            ProvisioningMockHelpers.LoadMockPlugin(inputModels: () => [model]);
            var provider = CreateResourceProvider(resource);

            Assert.That(provider.ResourceProjection!.WritableScopes, Is.Empty);
            Assert.That(provider.ResourceProjection.IsExtensionResource, Is.False);
            Assert.That(provider.Properties.Any(property => property.Name == "Scope"), Is.False);
        }

        [Test]
        public void WritableExtensionResourceExposesScopeMetadata()
        {
            var model = CreateModel("WritableExtension");
            var resource = CreateMetadata(
                model,
                "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Test/widgets/{widgetName}/providers/Microsoft.Test/extensions/{extensionName}",
                "Microsoft.Test/extensions",
                ResourceScope.Extension,
                ["2024-01-01"],
                methods:
                [
                    CreateMethod(ResourceOperationKind.Read, ResourceScope.Extension),
                    CreateMethod(ResourceOperationKind.Create, ResourceScope.Extension)
                ]);
            ProvisioningMockHelpers.LoadMockPlugin(inputModels: () => [model]);
            var provider = CreateResourceProvider(resource);

            Assert.That(provider.ResourceProjection!.WritableScopes, Does.Contain(ResourceScope.Extension));
            Assert.That(provider.ResourceProjection.IsExtensionResource, Is.True);
            Assert.That(provider.Properties.Any(property => property.Name == "Scope"), Is.True);
        }

        [Test]
        public void ReadOnlyResourceNameRemainsSettable()
        {
            var nameProperty = CreateProperty("Name", isRequired: true);
            var model = CreateModel("ReadOnlyWidget", [nameProperty]);
            var readOnlyResource = CreateMetadata(
                model,
                "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Test/widgets/{widgetName}",
                "Microsoft.Test/widgets",
                ResourceScope.ResourceGroup,
                ["2024-01-01"],
                methods: [CreateMethod(ResourceOperationKind.Read, ResourceScope.ResourceGroup)]);
            ProvisioningMockHelpers.LoadMockPlugin(inputModels: () => [model]);
            var provider = CreateResourceProvider(readOnlyResource);

            var propertyInfo = ((IProvisioningPropertyInfo)provider).GetProvisioningPropertyInfo(nameProperty);

            Assert.That(propertyInfo, Is.Not.Null);
            Assert.That(propertyInfo!.IsOutput, Is.False);
            Assert.That(propertyInfo.IsRequired, Is.True);
            Assert.That(propertyInfo.IsSettable, Is.True);
        }

        [Test]
        public void ReadOnlyResourceRequiredBodyPropertiesAreNotRequired()
        {
            var requiredProperty = CreateProperty("RequiredValue", isRequired: true);
            var model = CreateModel("ReadOnlyWidget", [requiredProperty]);
            var readOnlyResource = CreateMetadata(
                model,
                "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Test/widgets/{widgetName}",
                "Microsoft.Test/widgets",
                ResourceScope.ResourceGroup,
                ["2024-01-01"],
                methods: [CreateMethod(ResourceOperationKind.Read, ResourceScope.ResourceGroup)]);
            ProvisioningMockHelpers.LoadMockPlugin(inputModels: () => [model]);
            var provider = CreateResourceProvider(readOnlyResource);

            var propertyInfo = ((IProvisioningPropertyInfo)provider).GetProvisioningPropertyInfo(requiredProperty);

            Assert.That(propertyInfo, Is.Not.Null);
            Assert.That(propertyInfo!.IsOutput, Is.False);
            Assert.That(propertyInfo.IsRequired, Is.False);
            Assert.That(propertyInfo.IsSettable, Is.False);
        }

        [Test]
        public void UppercaseSerializedNameIsNotTreatedAsResourceNameMetadata()
        {
            var uppercaseNameProperty = CreateProperty("Name", isRequired: true, serializedName: "Name");
            var model = CreateModel("ReadOnlyWidget", [uppercaseNameProperty]);
            var readOnlyResource = CreateMetadata(
                model,
                "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Test/widgets/{widgetName}",
                "Microsoft.Test/widgets",
                ResourceScope.ResourceGroup,
                ["2024-01-01"],
                methods: [CreateMethod(ResourceOperationKind.Read, ResourceScope.ResourceGroup)]);
            ProvisioningMockHelpers.LoadMockPlugin(inputModels: () => [model]);
            var provider = CreateResourceProvider(readOnlyResource);

            var propertyInfo = ((IProvisioningPropertyInfo)provider).GetProvisioningPropertyInfo(uppercaseNameProperty);

            Assert.That(propertyInfo, Is.Not.Null);
            Assert.That(propertyInfo!.IsOutput, Is.False);
            Assert.That(propertyInfo.IsRequired, Is.False);
            Assert.That(propertyInfo.IsSettable, Is.False);
        }

        [Test]
        public void UppercaseSerializedTypeIsNotTreatedAsResourceTypeMetadata()
        {
            var uppercaseTypeProperty = CreateProperty("Type", isReadOnly: true, serializedName: "Type");
            var model = CreateModel("ReadOnlyWidget", [uppercaseTypeProperty]);
            var readOnlyResource = CreateMetadata(
                model,
                "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Test/widgets/{widgetName}",
                "Microsoft.Test/widgets",
                ResourceScope.ResourceGroup,
                ["2024-01-01"],
                methods: [CreateMethod(ResourceOperationKind.Read, ResourceScope.ResourceGroup)]);
            ProvisioningMockHelpers.LoadMockPlugin(inputModels: () => [model]);
            var provider = CreateResourceProvider(readOnlyResource);

            var propertyInfo = ((IProvisioningPropertyInfo)provider).GetProvisioningPropertyInfo(uppercaseTypeProperty);

            Assert.That(propertyInfo, Is.Not.Null);
            Assert.That(propertyInfo!.IsOutput, Is.True);
        }

        [Test]
        public void ModelOnlyReferencedByReadOnlyResourceIsNotSettable()
        {
            var detailsValueProperty = CreateProperty("RequiredValue", isRequired: true);
            var detailsModel = CreateModel("ReadOnlyWidgetDetails", [detailsValueProperty]);
            var detailsProperty = CreateProperty("Details", type: detailsModel);
            var resourceModel = CreateModel("ReadOnlyWidget", [detailsProperty]);
            var readOnlyResource = CreateMetadata(
                resourceModel,
                "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Test/widgets/{widgetName}",
                "Microsoft.Test/widgets",
                ResourceScope.ResourceGroup,
                ["2024-01-01"],
                methods: [CreateMethod(ResourceOperationKind.Read, ResourceScope.ResourceGroup)]);
            ProvisioningMockHelpers.LoadMockPlugin(inputModels: () => [resourceModel, detailsModel]);
            var resourceProvider = CreateResourceProvider(readOnlyResource);
            RegisterResourceProviders(resourceProvider);
            var modelProvider = new ProvisioningModelProvider(detailsModel);

            var propertyInfo = ((IProvisioningPropertyInfo)modelProvider).GetProvisioningPropertyInfo(detailsValueProperty);

            Assert.That(propertyInfo, Is.Not.Null);
            Assert.That(propertyInfo!.IsOutput, Is.False);
            Assert.That(propertyInfo.IsRequired, Is.False);
            Assert.That(propertyInfo.IsSettable, Is.False);
        }

        [Test]
        public void ModelReferencedByWritableResourceRemainsSettable()
        {
            var detailsValueProperty = CreateProperty("RequiredValue", isRequired: true);
            var detailsModel = CreateModel("WritableWidgetDetails", [detailsValueProperty]);
            var detailsProperty = CreateProperty("Details", type: detailsModel);
            var resourceModel = CreateModel("WritableWidget", [detailsProperty]);
            var writableResource = CreateMetadata(
                resourceModel,
                "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Test/widgets/{widgetName}",
                "Microsoft.Test/widgets",
                ResourceScope.ResourceGroup,
                ["2024-01-01"],
                methods:
                [
                    CreateMethod(ResourceOperationKind.Read, ResourceScope.ResourceGroup),
                    CreateMethod(ResourceOperationKind.Create, ResourceScope.ResourceGroup)
                ]);
            ProvisioningMockHelpers.LoadMockPlugin(inputModels: () => [resourceModel, detailsModel]);
            var resourceProvider = CreateResourceProvider(writableResource);
            RegisterResourceProviders(resourceProvider);
            var modelProvider = new ProvisioningModelProvider(detailsModel);

            var propertyInfo = ((IProvisioningPropertyInfo)modelProvider).GetProvisioningPropertyInfo(detailsValueProperty);

            Assert.That(propertyInfo, Is.Not.Null);
            Assert.That(propertyInfo!.IsOutput, Is.False);
            Assert.That(propertyInfo.IsRequired, Is.True);
            Assert.That(propertyInfo.IsSettable, Is.True);
        }

        [Test]
        public void ReadOnlyResourceModelReferencedByWritableParentBodyIsSettable()
        {
            var childNameProperty = CreateProperty("Name", isRequired: true);
            var childValueProperty = CreateProperty("HostName", isRequired: true);
            var childModel = CreateModel("FrontendEndpoint", [childNameProperty, childValueProperty]);
            var childListProperty = CreateProperty(
                "FrontendEndpoints",
                type: new InputArrayType("array", "ArrayFrontendEndpoint", childModel));
            var parentModel = CreateModel("FrontDoor", [childListProperty]);
            var readOnlyChildResource = CreateMetadata(
                childModel,
                "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Test/frontDoors/{frontDoorName}/frontendEndpoints/{frontendEndpointName}",
                "Microsoft.Test/frontDoors/frontendEndpoints",
                ResourceScope.ResourceGroup,
                ["2024-01-01"],
                methods: [CreateMethod(ResourceOperationKind.Read, ResourceScope.ResourceGroup)],
                parentResourceId: "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Test/frontDoors/{frontDoorName}");
            var writableParentResource = CreateMetadata(
                parentModel,
                "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Test/frontDoors/{frontDoorName}",
                "Microsoft.Test/frontDoors",
                ResourceScope.ResourceGroup,
                ["2024-01-01"],
                methods:
                [
                    CreateMethod(ResourceOperationKind.Read, ResourceScope.ResourceGroup),
                    CreateMethod(ResourceOperationKind.Create, ResourceScope.ResourceGroup)
                ]);
            ProvisioningMockHelpers.LoadMockPlugin(inputModels: () => [parentModel, childModel]);
            var providers = CreateAndRegisterResourceProviders(writableParentResource, readOnlyChildResource);
            var parentProvider = providers[0];
            var childProvider = providers[1];

            var childNameInfo = ((IProvisioningPropertyInfo)childProvider).GetProvisioningPropertyInfo(childNameProperty);
            var childValueInfo = ((IProvisioningPropertyInfo)childProvider).GetProvisioningPropertyInfo(childValueProperty);

            Assert.That(ProvisioningGenerator.Instance.InputLibrary.IsModelSettable(childModel), Is.True);
            Assert.That(childProvider.Constructors.Single().Signature.Modifiers.HasFlag(MethodSignatureModifiers.Public), Is.True);
            Assert.That(childNameInfo, Is.Not.Null);
            Assert.That(childNameInfo!.IsSettable, Is.True);
            Assert.That(childValueInfo, Is.Not.Null);
            Assert.That(childValueInfo!.IsOutput, Is.False);
            Assert.That(childValueInfo.IsRequired, Is.True);
            Assert.That(childValueInfo.IsSettable, Is.True);
        }

        [Test]
        public void SharedResourceModelUsesModelSettableUsage()
        {
            var valueProperty = CreateProperty("Value", isRequired: true);
            var sharedModel = CreateModel("Profile", [valueProperty]);
            var writableResource = CreateMetadata(
                sharedModel,
                "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Test/profiles/{profileName}",
                "Microsoft.Test/profiles",
                ResourceScope.ResourceGroup,
                ["2024-01-01"],
                methods:
                [
                    CreateMethod(ResourceOperationKind.Read, ResourceScope.ResourceGroup),
                    CreateMethod(ResourceOperationKind.Create, ResourceScope.ResourceGroup)
                ]);
            var readOnlySiblingResource = CreateMetadata(
                sharedModel,
                "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Test/profiles/{profileName}/revisions/{revisionName}",
                "Microsoft.Test/profiles/revisions",
                ResourceScope.ResourceGroup,
                ["2024-01-01"],
                resourceName: "ProfileRevision",
                methods: [CreateMethod(ResourceOperationKind.Read, ResourceScope.ResourceGroup)],
                parentResourceId: "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Test/profiles/{profileName}");
            ProvisioningMockHelpers.LoadMockPlugin(inputModels: () => [sharedModel]);
            var providers = CreateAndRegisterResourceProviders(writableResource, readOnlySiblingResource);
            var writableProvider = providers[0];
            var readOnlySiblingProvider = providers[1];

            var writablePropertyInfo = ((IProvisioningPropertyInfo)writableProvider).GetProvisioningPropertyInfo(valueProperty);
            var readOnlySiblingPropertyInfo = ((IProvisioningPropertyInfo)readOnlySiblingProvider).GetProvisioningPropertyInfo(valueProperty);

            Assert.That(ProvisioningGenerator.Instance.InputLibrary.IsModelSettable(sharedModel), Is.True);
            Assert.That(writablePropertyInfo, Is.Not.Null);
            Assert.That(writablePropertyInfo!.IsSettable, Is.True);
            Assert.That(readOnlySiblingPropertyInfo, Is.Not.Null);
            Assert.That(readOnlySiblingPropertyInfo!.IsSettable, Is.True);
            Assert.That(readOnlySiblingProvider.Constructors.Single().Signature.Modifiers.HasFlag(MethodSignatureModifiers.Public), Is.True);
        }

        [Test]
        public void ReadOnlyResourceDoesNotInheritSettableUsageThroughNonDiscriminatorBaseModel()
        {
            var baseModel = CreateModel("ProxyResource");
            var writableProperty = CreateProperty("WritableValue", isRequired: true);
            var writableModel = CreateModel("WritableResource", [writableProperty], baseModel);
            var readOnlyProperty = CreateProperty("ReadOnlyValue", isRequired: true);
            var readOnlyModel = CreateModel("DeletedResource", [readOnlyProperty], baseModel);
            var writableResource = CreateMetadata(
                writableModel,
                "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Test/resources/{resourceName}",
                "Microsoft.Test/resources",
                ResourceScope.ResourceGroup,
                ["2024-01-01"],
                methods:
                [
                    CreateMethod(ResourceOperationKind.Read, ResourceScope.ResourceGroup),
                    CreateMethod(ResourceOperationKind.Create, ResourceScope.ResourceGroup)
                ]);
            var readOnlyResource = CreateMetadata(
                readOnlyModel,
                "/subscriptions/{subscriptionId}/providers/Microsoft.Test/deletedResources/{resourceName}",
                "Microsoft.Test/deletedResources",
                ResourceScope.Subscription,
                ["2024-01-01"],
                methods: [CreateMethod(ResourceOperationKind.Read, ResourceScope.Subscription)]);
            ProvisioningMockHelpers.LoadMockPlugin(inputModels: () => [baseModel, writableModel, readOnlyModel]);
            var providers = CreateAndRegisterResourceProviders(writableResource, readOnlyResource);
            var writableProvider = providers[0];
            var readOnlyProvider = providers[1];

            var writablePropertyInfo = ((IProvisioningPropertyInfo)writableProvider).GetProvisioningPropertyInfo(writableProperty);
            var readOnlyPropertyInfo = ((IProvisioningPropertyInfo)readOnlyProvider).GetProvisioningPropertyInfo(readOnlyProperty);

            Assert.That(ProvisioningGenerator.Instance.InputLibrary.IsModelSettable(writableModel), Is.True);
            Assert.That(ProvisioningGenerator.Instance.InputLibrary.IsModelSettable(readOnlyModel), Is.False);
            Assert.That(writablePropertyInfo, Is.Not.Null);
            Assert.That(writablePropertyInfo!.IsSettable, Is.True);
            Assert.That(readOnlyPropertyInfo, Is.Not.Null);
            Assert.That(readOnlyPropertyInfo!.IsSettable, Is.False);
            Assert.That(readOnlyProvider.Constructors.Single().Signature.Modifiers.HasFlag(MethodSignatureModifiers.Internal), Is.True);
        }

        [Test]
        public void SingletonResourceNameIsNotSettable()
        {
            var nameProperty = CreateProperty("Name", isRequired: true);
            var model = CreateModel("SingletonWidget", [nameProperty]);
            var singletonResource = CreateMetadata(
                model,
                "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Test/widgets/default",
                "Microsoft.Test/widgets",
                ResourceScope.ResourceGroup,
                ["2024-01-01"],
                singletonResourceName: "default",
                methods: [CreateMethod(ResourceOperationKind.Read, ResourceScope.ResourceGroup)]);
            ProvisioningMockHelpers.LoadMockPlugin(inputModels: () => [model]);
            var provider = CreateResourceProvider(singletonResource);

            var propertyInfo = ((IProvisioningPropertyInfo)provider).GetProvisioningPropertyInfo(nameProperty);

            Assert.That(propertyInfo, Is.Not.Null);
            Assert.That(propertyInfo!.IsOutput, Is.False);
            Assert.That(propertyInfo.IsSettable, Is.False);
            Assert.That(propertyInfo.DefaultValue, Is.EqualTo("default"));
        }

        [Test]
        public void WritableResourcePropertiesRemainSettable()
        {
            var writableProperty = CreateProperty("WritableValue");
            var model = CreateModel("WritableWidget", [writableProperty]);
            var writableResource = CreateMetadata(
                model,
                "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Test/widgets/{widgetName}",
                "Microsoft.Test/widgets",
                ResourceScope.ResourceGroup,
                ["2024-01-01"],
                methods:
                [
                    CreateMethod(ResourceOperationKind.Read, ResourceScope.ResourceGroup),
                    CreateMethod(ResourceOperationKind.Create, ResourceScope.ResourceGroup)
                ]);
            ProvisioningMockHelpers.LoadMockPlugin(inputModels: () => [model]);
            var provider = CreateResourceProvider(writableResource);

            var propertyInfo = ((IProvisioningPropertyInfo)provider).GetProvisioningPropertyInfo(writableProperty);

            Assert.That(propertyInfo, Is.Not.Null);
            Assert.That(propertyInfo!.IsOutput, Is.False);
            Assert.That(propertyInfo.IsSettable, Is.True);
        }

        [Test]
        public void ReadOnlyResourceConstructorIsInternal()
        {
            var model = CreateModel("ReadOnlyWidget");
            var readOnlyResource = CreateMetadata(
                model,
                "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Test/widgets/{widgetName}",
                "Microsoft.Test/widgets",
                ResourceScope.ResourceGroup,
                ["2024-01-01"],
                methods: [CreateMethod(ResourceOperationKind.Read, ResourceScope.ResourceGroup)]);
            ProvisioningMockHelpers.LoadMockPlugin(inputModels: () => [model]);
            var provider = CreateResourceProvider(readOnlyResource);

            var constructor = provider.Constructors.Single();

            Assert.That(constructor.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Internal), Is.True);
            Assert.That(constructor.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Public), Is.False);
        }

        [Test]
        public void WritableResourceConstructorIsPublic()
        {
            var model = CreateModel("WritableWidget");
            var writableResource = CreateMetadata(
                model,
                "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Test/widgets/{widgetName}",
                "Microsoft.Test/widgets",
                ResourceScope.ResourceGroup,
                ["2024-01-01"],
                methods:
                [
                    CreateMethod(ResourceOperationKind.Read, ResourceScope.ResourceGroup),
                    CreateMethod(ResourceOperationKind.Create, ResourceScope.ResourceGroup)
                ]);
            ProvisioningMockHelpers.LoadMockPlugin(inputModels: () => [model]);
            var provider = CreateResourceProvider(writableResource);

            var constructor = provider.Constructors.Single();

            Assert.That(constructor.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Public), Is.True);
            Assert.That(constructor.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Internal), Is.False);
        }

        [Test]
        public void DerivedReadOnlyResourcePropertiesAreNotSettable()
        {
            var discriminatorProperty = CreateProperty("Kind", isRequired: true, isDiscriminator: true);
            var baseModel = CreateModel("ReadOnlyWidget", [discriminatorProperty]);
            var derivedProperty = CreateProperty("WritableValue");
            var derivedModel = CreateModel(
                "DerivedReadOnlyWidget",
                [derivedProperty],
                baseModel,
                discriminatorValue: "derived",
                discriminatorProperty: discriminatorProperty);
            AddDiscriminatedSubtype(baseModel, derivedModel);
            var readOnlyResource = CreateMetadata(
                baseModel,
                "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Test/widgets/{widgetName}",
                "Microsoft.Test/widgets",
                ResourceScope.ResourceGroup,
                ["2024-01-01"],
                methods: [CreateMethod(ResourceOperationKind.Read, ResourceScope.ResourceGroup)]);
            ProvisioningMockHelpers.LoadMockPlugin(inputModels: () => [baseModel, derivedModel]);
            var baseProvider = CreateResourceProvider(readOnlyResource);
            RegisterResourceProviders(baseProvider);
            var derivedProvider = new ProvisioningResourceProvider(derivedModel);

            var propertyInfo = ((IProvisioningPropertyInfo)derivedProvider).GetProvisioningPropertyInfo(derivedProperty);

            Assert.That(derivedProvider.Name, Is.EqualTo("DerivedReadOnlyWidget"));
            Assert.That(propertyInfo, Is.Not.Null);
            Assert.That(propertyInfo!.IsOutput, Is.False);
            Assert.That(propertyInfo.IsSettable, Is.False);
        }

        [Test]
        public void DerivedWritableResourcePropertiesRemainSettable()
        {
            var discriminatorProperty = CreateProperty("Kind", isRequired: true, isDiscriminator: true);
            var baseModel = CreateModel("WritableWidget", [discriminatorProperty]);
            var derivedProperty = CreateProperty("WritableValue");
            var derivedModel = CreateModel(
                "DerivedWritableWidget",
                [derivedProperty],
                baseModel,
                discriminatorValue: "derived",
                discriminatorProperty: discriminatorProperty);
            AddDiscriminatedSubtype(baseModel, derivedModel);
            var writableResource = CreateMetadata(
                baseModel,
                "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Test/widgets/{widgetName}",
                "Microsoft.Test/widgets",
                ResourceScope.ResourceGroup,
                ["2024-01-01"],
                methods:
                [
                    CreateMethod(ResourceOperationKind.Read, ResourceScope.ResourceGroup),
                    CreateMethod(ResourceOperationKind.Create, ResourceScope.ResourceGroup)
                ]);
            ProvisioningMockHelpers.LoadMockPlugin(inputModels: () => [baseModel, derivedModel]);
            var baseProvider = CreateResourceProvider(writableResource);
            RegisterResourceProviders(baseProvider);
            var derivedProvider = new ProvisioningResourceProvider(derivedModel);

            var propertyInfo = ((IProvisioningPropertyInfo)derivedProvider).GetProvisioningPropertyInfo(derivedProperty);

            Assert.That(derivedProvider.Name, Is.EqualTo("DerivedWritableWidget"));
            Assert.That(propertyInfo, Is.Not.Null);
            Assert.That(propertyInfo!.IsOutput, Is.False);
            Assert.That(propertyInfo.IsSettable, Is.True);
        }

        private static ArmResourceMetadata CreateMetadata(
            InputModelType model,
            string resourceIdPattern,
            string resourceType,
            ResourceScope scope,
            IReadOnlyList<string> apiVersions,
            IReadOnlyList<ArmResourceRbacRole>? rbacRoles = null,
            string? resourceName = null,
            string? singletonResourceName = null,
            string? parentResourceId = null,
            ArmResourceNameConstraints? nameConstraints = null,
            IReadOnlyList<ResourceMethod>? methods = null)
        {
            var path = new RequestPathPattern(resourceIdPattern);
            return new ArmResourceMetadata(
                path,
                resourceName ?? model.Name,
                new ResourceTypePattern(resourceType),
                model,
                new ArmScopeInfo(scope, RequestPathPattern.GetFromScope(scope, path), null),
                methods ?? [],
                singletonResourceName,
                parentResourceId is null ? null : new RequestPathPattern(parentResourceId),
                [],
                nameConstraints ?? new ArmResourceNameConstraints(null, null, null),
                apiVersions,
                rbacRoles ?? [new ArmResourceRbacRole("FirstRole", "11111111-1111-1111-1111-111111111111")]);
        }

        private static InputModelType CreateModel(
            string name,
            IReadOnlyList<InputModelProperty>? properties = null,
            InputModelType? baseModel = null,
            IReadOnlyList<InputModelType>? derivedModels = null,
            string? discriminatorValue = null,
            InputModelProperty? discriminatorProperty = null)
            => new(
                name,
                "Sample.Models",
                $"Sample.Models.{name}",
                "public",
                null,
                string.Empty,
                "Test model.",
                InputModelTypeUsage.Input | InputModelTypeUsage.Output,
                properties ?? [],
                baseModel,
                derivedModels ?? [],
                discriminatorValue,
                discriminatorProperty,
                new Dictionary<string, InputModelType>(),
                null,
                false,
                new InputSerializationOptions(),
                false);

        private static ResourceMethod CreateMethod(ResourceOperationKind kind, ResourceScope scope)
        {
            var path = RequestPathPattern.GetFromScope(scope, new RequestPathPattern("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Test/widgets/{widgetName}"));
            var methodName = $"{kind}Widget";
            var operation = new InputOperation(
                methodName,
                null,
                string.Empty,
                $"{methodName} description",
                null,
                "public",
                [],
                [new InputOperationResponse([200], null, [], false, ["application/json"])],
                kind == ResourceOperationKind.Read ? "GET" : "PUT",
                string.Empty,
                path.SerializedPath,
                null,
                null,
                false,
                true,
                true,
                $"Sample.{methodName}",
                "Sample");
            var method = new InputBasicServiceMethod(
                methodName,
                "public",
                [],
                null,
                null,
                operation,
                [],
                new InputServiceMethodResponse(null, null),
                null,
                false,
                true,
                true,
                operation.CrossLanguageDefinitionId);
            var client = new InputClient(
                "Widgets",
                "Sample",
                "Sample.Widgets",
                string.Empty,
                "Widgets description",
                isMultiServiceClient: false,
                [method],
                [],
                null,
                [],
                ["2024-01-01"]);
            return new ResourceMethod(kind, method, path, new ArmScopeInfo(scope, path, null), client);
        }

        private static void RegisterResourceProviders(params ProvisioningResourceProvider[] providers)
        {
            var outputLibrary = ProvisioningGenerator.Instance.OutputLibrary;
            var resourceProjections = providers
                .Where(provider => provider.ResourceProjection is not null)
                .Select(provider => provider.ResourceProjection!)
                .ToList();
            var resourcesByModel = providers
                .Where(provider => provider.ResourceProjection is not null)
                .GroupBy(provider => provider.ResourceProjection!.ResourceModel)
                .ToDictionary(
                    group => group.Key,
                    group => group.ToList());

            typeof(ProvisioningOutputLibrary)
                .GetField("_resources", BindingFlags.Instance | BindingFlags.NonPublic)!
                .SetValue(outputLibrary, providers);
            typeof(ProvisioningOutputLibrary)
                .GetField("_resourcesByIdPattern", BindingFlags.Instance | BindingFlags.NonPublic)!
                .SetValue(outputLibrary, new Dictionary<string, ProvisioningResourceProvider>());
            typeof(ProvisioningOutputLibrary)
                .GetField("_resourcesByModel", BindingFlags.Instance | BindingFlags.NonPublic)!
                .SetValue(outputLibrary, resourcesByModel);
            RegisterResourceProjections(resourceProjections);
        }

        private static void RegisterResourceProjections(IReadOnlyList<ProvisioningResourceProjection> resourceProjections)
        {
            var inputLibrary = ProvisioningGenerator.Instance.InputLibrary;
            typeof(ProvisioningInputLibrary)
                .GetField("_resourceProjections", BindingFlags.Instance | BindingFlags.NonPublic)!
                .SetValue(ProvisioningGenerator.Instance.InputLibrary, resourceProjections);
            typeof(ProvisioningInputLibrary)
                .GetField("_modelSettableUsage", BindingFlags.Instance | BindingFlags.NonPublic)!
                .SetValue(inputLibrary, CollectModelSettableUsage(resourceProjections));
        }

        private static Dictionary<string, bool> CollectModelSettableUsage(IReadOnlyList<ProvisioningResourceProjection> projections)
        {
            var projectionsByModel = projections
                .GroupBy(projection => projection.ResourceModel)
                .ToDictionary(group => group.Key, group => group.ToList());
            var usage = new Dictionary<string, bool>();
            var visited = new HashSet<(InputType Type, bool IsSettable)>();
            var queue = new Queue<(InputType Type, bool IsSettable)>(
                projections.Select(projection => ((InputType)projection.ResourceModel, projection.WritableScopes.Count > 0)));

            while (queue.TryDequeue(out var item))
            {
                if (!visited.Add(item))
                {
                    continue;
                }

                switch (item.Type)
                {
                    case InputModelType model:
                        var isSettable = item.IsSettable ||
                            (projectionsByModel.TryGetValue(model, out var modelProjections) &&
                             modelProjections.Any(projection => projection.WritableScopes.Count > 0));
                        usage[model.CrossLanguageDefinitionId] = isSettable ||
                            (usage.TryGetValue(model.CrossLanguageDefinitionId, out var existing) && existing);
                        if (model.BaseModel != null)
                        {
                            queue.Enqueue((model.BaseModel, isSettable));
                        }
                        foreach (var derived in model.DiscriminatedSubtypes.Values)
                        {
                            queue.Enqueue((derived, isSettable));
                        }
                        foreach (var property in GetProperties(model, projectionsByModel.ContainsKey(model)))
                        {
                            queue.Enqueue((property.Type, isSettable && !property.IsReadOnly));
                        }
                        if (!projectionsByModel.ContainsKey(model) && model.AdditionalProperties != null)
                        {
                            queue.Enqueue((model.AdditionalProperties, isSettable));
                        }
                        break;
                    case InputArrayType array:
                        queue.Enqueue((array.ValueType, item.IsSettable));
                        break;
                    case InputDictionaryType dictionary:
                        queue.Enqueue((dictionary.KeyType, item.IsSettable));
                        queue.Enqueue((dictionary.ValueType, item.IsSettable));
                        break;
                    case InputNullableType nullable:
                        queue.Enqueue((nullable.Type, item.IsSettable));
                        break;
                    case InputLiteralType literal:
                        queue.Enqueue((literal.ValueType, item.IsSettable));
                        break;
                    case InputUnionType union:
                        foreach (var variant in union.VariantTypes)
                        {
                            queue.Enqueue((variant, item.IsSettable));
                        }
                        break;
                }
            }

            return usage;
        }

        private static IEnumerable<InputModelProperty> GetProperties(InputModelType model, bool includeBaseProperties)
        {
            if (!includeBaseProperties)
            {
                return model.Properties;
            }

            var hierarchy = new Stack<InputModelType>();
            for (var current = model; current != null; current = current.BaseModel)
            {
                hierarchy.Push(current);
            }
            return hierarchy.SelectMany(type => type.Properties);
        }

        private static void AddDiscriminatedSubtype(InputModelType baseModel, InputModelType derivedModel)
        {
            var discriminatedSubtypes = (IDictionary<string, InputModelType>)baseModel.DiscriminatedSubtypes;
            discriminatedSubtypes[derivedModel.DiscriminatorValue!] = derivedModel;
        }

        private static ProvisioningResourceProvider CreateResourceProvider(ArmResourceMetadata metadata)
        {
            return CreateAndRegisterResourceProviders(metadata)[0];
        }

        private static ProvisioningResourceProvider[] CreateAndRegisterResourceProviders(params ArmResourceMetadata[] metadata)
        {
            var projections = metadata.Select(CreateProjection).ToArray();
            RegisterResourceProjections(projections);
            var providers = projections.Select(projection => new ProvisioningResourceProvider(projection)).ToArray();
            RegisterResourceProviders(providers);
            return providers;
        }

        private static ProvisioningResourceProjection CreateProjection(ArmResourceMetadata metadata)
        {
            var readableScopes = metadata.Methods.Any(method => method.Kind == ResourceOperationKind.Read)
                ? new[] { metadata.Scope.Kind }
                : [];
            var writableScopes = metadata.Methods.Any(method => method.Kind == ResourceOperationKind.Create)
                ? new[] { metadata.Scope.Kind }
                : [];
            return new(
                metadata.ResourceModel,
                metadata.ResourceName,
                metadata.ResourceType.SerializedResourceType,
                metadata.SingletonResourceName,
                metadata.ParentResourceId,
                metadata.NameConstraints,
                [metadata.ResourceIdPattern],
                metadata.ApiVersions,
                metadata.Methods,
                metadata.RbacRoles,
                readableScopes,
                writableScopes,
                writableScopes.Contains(ResourceScope.Extension));
        }

        private static InputModelProperty CreateProperty(string name, bool isRequired = false, bool isReadOnly = false, bool isDiscriminator = false, InputType? type = null, string? serializedName = null)
            => new(
                name: name,
                summary: null,
                doc: $"Description for {name}",
                type: type ?? InputPrimitiveType.String,
                isRequired: isRequired,
                isReadOnly: isReadOnly,
                isApiVersion: false,
                defaultValue: null,
                isHttpMetadata: false,
                access: null,
                isDiscriminator: isDiscriminator,
                serializedName: serializedName ?? name.ToVariableName(),
                serializationOptions: new(json: new(serializedName ?? name.ToVariableName())));
    }
}

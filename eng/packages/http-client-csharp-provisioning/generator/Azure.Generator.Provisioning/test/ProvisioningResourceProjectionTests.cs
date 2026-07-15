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
        public void SameResourceTypeAndModelCollapse()
        {
            var model = CreateModel("TestResourceData");
            var resourceGroupResource = CreateMetadata(
                model,
                "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Test/widgets/{widgetName}",
                "Microsoft.Test/widgets",
                ResourceScope.ResourceGroup,
                ["2024-01-01"]);
            var subscriptionResource = CreateMetadata(
                model,
                "/subscriptions/{subscriptionId}/providers/Microsoft.Test/widgets/{widgetName}",
                "Microsoft.Test/widgets",
                ResourceScope.Subscription,
                ["2024-02-01"],
                [new ArmResourceRbacRole("SecondRole", "22222222-2222-2222-2222-222222222222")]);

            var projections = ProvisioningResourceProjection.Create([resourceGroupResource, subscriptionResource]);

            Assert.That(projections, Has.Count.EqualTo(1));
            Assert.That(projections[0].Metadata, Is.EqualTo(new[] { resourceGroupResource, subscriptionResource }));
            Assert.That(projections[0].ResourceName, Is.EqualTo(resourceGroupResource.ResourceName));
            Assert.That(projections[0].ResourceType, Is.EqualTo("Microsoft.Test/widgets"));
            Assert.That(projections[0].ResourceModel, Is.SameAs(model));
            Assert.That(projections[0].ResourceIdPatterns.Select(p => p.SerializedPath), Is.EqualTo(new[]
            {
                resourceGroupResource.ResourceIdPattern.SerializedPath,
                subscriptionResource.ResourceIdPattern.SerializedPath
            }));
            Assert.That(projections[0].ApiVersions, Is.EqualTo(new[] { "2024-01-01", "2024-02-01" }));
            Assert.That(projections[0].RbacRoles.Select(r => r.Name), Is.EqualTo(new[] { "FirstRole", "SecondRole" }));
        }

        [Test]
        public void SameResourceTypeWithDifferentModelsDoesNotCollapse()
        {
            var firstModel = CreateModel("FirstResourceData");
            var secondModel = CreateModel("SecondResourceData");
            var firstResource = CreateMetadata(
                firstModel,
                "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Test/widgets/{widgetName}",
                "Microsoft.Test/widgets",
                ResourceScope.ResourceGroup,
                ["2024-01-01"]);
            var secondResource = CreateMetadata(
                secondModel,
                "/subscriptions/{subscriptionId}/providers/Microsoft.Test/widgets/{widgetName}",
                "Microsoft.Test/widgets",
                ResourceScope.Subscription,
                ["2024-01-01"]);

            var projections = ProvisioningResourceProjection.Create([firstResource, secondResource]);

            Assert.That(projections, Has.Count.EqualTo(2));
            Assert.That(projections[0].ResourceModel, Is.SameAs(firstModel));
            Assert.That(projections[1].ResourceModel, Is.SameAs(secondModel));
        }

        [Test]
        public void CollapsedProjectionDropsInconsistentPerEntryValues()
        {
            var model = CreateModel("TestResourceData");
            var firstResource = CreateMetadata(
                model,
                "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Test/widgets/{widgetName}/children/default",
                "Microsoft.Test/widgets/children",
                ResourceScope.ResourceGroup,
                ["2024-01-01"],
                resourceName: "FirstResource",
                singletonResourceName: "default",
                parentResourceId: "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Test/widgets/{widgetName}",
                nameConstraints: new ArmResourceNameConstraints("[a-z]+", 1, 24));
            var secondResource = CreateMetadata(
                model,
                "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Test/widgets/{widgetName}/children/current",
                "Microsoft.Test/widgets/children",
                ResourceScope.ResourceGroup,
                ["2024-01-01"],
                resourceName: "SecondResource",
                singletonResourceName: "current",
                parentResourceId: "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Test/otherWidgets/{widgetName}",
                nameConstraints: new ArmResourceNameConstraints("[0-9]+", 1, 24));

            var projection = ProvisioningResourceProjection.Create([firstResource, secondResource])[0];

            Assert.That(projection.ResourceName, Is.EqualTo(model.Name));
            Assert.That(projection.SingletonResourceName, Is.Null);
            Assert.That(projection.ParentResourceId, Is.Null);
            Assert.That(projection.NameConstraints, Is.EqualTo(new ArmResourceNameConstraints(null, null, null)));
        }

        [Test]
        public void CollapsedProjectionKeepsOnlyConsistentParentResourceId()
        {
            var model = CreateModel("TestResourceData");
            const string parentResourceId = "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Test/widgets/{widgetName}";
            var firstResource = CreateMetadata(
                model,
                "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Test/widgets/{widgetName}/children/first",
                "Microsoft.Test/widgets/children",
                ResourceScope.ResourceGroup,
                ["2024-01-01"],
                parentResourceId: parentResourceId);
            var secondResource = CreateMetadata(
                model,
                "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Test/widgets/{widgetName}/children/second",
                "Microsoft.Test/widgets/children",
                ResourceScope.ResourceGroup,
                ["2024-01-01"],
                parentResourceId: parentResourceId);
            var parentlessResource = CreateMetadata(
                model,
                "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Test/widgets/{widgetName}/children/third",
                "Microsoft.Test/widgets/children",
                ResourceScope.ResourceGroup,
                ["2024-01-01"]);

            var consistentProjection = ProvisioningResourceProjection.Create([firstResource, secondResource])[0];
            var mixedNullProjection = ProvisioningResourceProjection.Create([firstResource, parentlessResource])[0];

            Assert.That(consistentProjection.ParentResourceId, Is.EqualTo(firstResource.ParentResourceId));
            Assert.That(mixedNullProjection.ParentResourceId, Is.Null);
        }

        [Test]
        public void CollapsedProjectionKeepsOnlyConsistentSingletonResourceName()
        {
            var model = CreateModel("TestResourceData");
            var firstResource = CreateMetadata(
                model,
                "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Test/widgets/{widgetName}/children/default",
                "Microsoft.Test/widgets/children",
                ResourceScope.ResourceGroup,
                ["2024-01-01"],
                singletonResourceName: "default");
            var secondResource = CreateMetadata(
                model,
                "/subscriptions/{subscriptionId}/providers/Microsoft.Test/widgets/{widgetName}/children/default",
                "Microsoft.Test/widgets/children",
                ResourceScope.Subscription,
                ["2024-01-01"],
                singletonResourceName: "default");
            var mixedNullResource = CreateMetadata(
                model,
                "/providers/Microsoft.Test/widgets/{widgetName}/children/default",
                "Microsoft.Test/widgets/children",
                ResourceScope.Tenant,
                ["2024-01-01"]);

            var consistentProjection = ProvisioningResourceProjection.Create([firstResource, secondResource])[0];
            var mixedNullProjection = ProvisioningResourceProjection.Create([firstResource, mixedNullResource])[0];

            Assert.That(consistentProjection.SingletonResourceName, Is.EqualTo("default"));
            Assert.That(mixedNullProjection.SingletonResourceName, Is.Null);
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
                resourceType,
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
            var resourceProjectionsByModel = resourceProjections
                .GroupBy(projection => projection.ResourceModel)
                .ToDictionary(
                    group => group.Key,
                    group => group.ToList());

            typeof(ProvisioningInputLibrary)
                .GetField("_resourceProjections", BindingFlags.Instance | BindingFlags.NonPublic)!
                .SetValue(ProvisioningGenerator.Instance.InputLibrary, resourceProjections);
            typeof(ProvisioningInputLibrary)
                .GetField("_resourceProjectionsByModel", BindingFlags.Instance | BindingFlags.NonPublic)!
                .SetValue(ProvisioningGenerator.Instance.InputLibrary, resourceProjectionsByModel);
            typeof(ProvisioningInputLibrary)
                .GetField("_modelSettableUsage", BindingFlags.Instance | BindingFlags.NonPublic)!
                .SetValue(ProvisioningGenerator.Instance.InputLibrary, null);
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
            var projections = ProvisioningResourceProjection.Create(metadata);
            RegisterResourceProjections(projections);
            var providers = projections.Select(projection => new ProvisioningResourceProvider(projection)).ToArray();
            RegisterResourceProviders(providers);
            return providers;
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

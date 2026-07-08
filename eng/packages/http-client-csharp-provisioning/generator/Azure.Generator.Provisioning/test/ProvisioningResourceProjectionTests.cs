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
            var provider = new ProvisioningResourceProvider(ProvisioningResourceProjection.Create([readOnlyResource])[0]);

            var propertyInfo = ((IProvisioningPropertyInfo)provider).GetProvisioningPropertyInfo(writableProperty);

            Assert.That(propertyInfo, Is.Not.Null);
            Assert.That(propertyInfo!.IsOutput, Is.False);
            Assert.That(propertyInfo.IsSettable, Is.False);
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
            var provider = new ProvisioningResourceProvider(ProvisioningResourceProjection.Create([writableResource])[0]);

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
            var provider = new ProvisioningResourceProvider(ProvisioningResourceProjection.Create([readOnlyResource])[0]);

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
            var provider = new ProvisioningResourceProvider(ProvisioningResourceProjection.Create([writableResource])[0]);

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
                discriminatorProperty);
            var readOnlyResource = CreateMetadata(
                baseModel,
                "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Test/widgets/{widgetName}",
                "Microsoft.Test/widgets",
                ResourceScope.ResourceGroup,
                ["2024-01-01"],
                methods: [CreateMethod(ResourceOperationKind.Read, ResourceScope.ResourceGroup)]);
            ProvisioningMockHelpers.LoadMockPlugin(inputModels: () => [baseModel, derivedModel]);
            var baseProvider = new ProvisioningResourceProvider(ProvisioningResourceProjection.Create([readOnlyResource])[0]);
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
                discriminatorProperty);
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
            var baseProvider = new ProvisioningResourceProvider(ProvisioningResourceProjection.Create([writableResource])[0]);
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
                [],
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
        }

        private static InputModelProperty CreateProperty(string name, bool isRequired = false, bool isReadOnly = false, bool isDiscriminator = false)
            => new(
                name: name,
                summary: null,
                doc: $"Description for {name}",
                type: InputPrimitiveType.String,
                isRequired: isRequired,
                isReadOnly: isReadOnly,
                isApiVersion: false,
                defaultValue: null,
                isHttpMetadata: false,
                access: null,
                isDiscriminator: isDiscriminator,
                serializedName: name.ToVariableName(),
                serializationOptions: new(json: new(name.ToVariableName())));
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Models;
using Azure.Generator.Provisioning.Primitives;
using Azure.Generator.Provisioning.Tests.TestHelpers;
using Microsoft.TypeSpec.Generator.Input;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Azure.Generator.Provisioning.Tests
{
    public class ProvisioningResourceProjectionTests
    {
        [SetUp]
        public void SetUp()
        {
            ProvisioningMockHelpers.LoadMockGenerator();
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
        public void CollapsedProjectionComparesParentResourceIdByEqualityNotHashCode()
        {
            var model = CreateModel("TestResourceData");
            var firstParent = new RequestPathPattern("/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Test/widgets/{widgetName}");
            var secondParent = new RequestPathPattern(firstParent.AsEnumerable());
            var firstResource = CreateMetadata(
                model,
                "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Test/widgets/{widgetName}/children/first",
                "Microsoft.Test/widgets/children",
                ResourceScope.ResourceGroup,
                ["2024-01-01"],
                parentResourceIdPattern: firstParent);
            var secondResource = CreateMetadata(
                model,
                "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Test/widgets/{widgetName}/children/second",
                "Microsoft.Test/widgets/children",
                ResourceScope.ResourceGroup,
                ["2024-01-01"],
                parentResourceIdPattern: secondParent);

            var projection = ProvisioningResourceProjection.Create([firstResource, secondResource])[0];

            Assert.That(firstParent, Is.EqualTo(secondParent));
            Assert.That(firstParent.GetHashCode(), Is.Not.EqualTo(secondParent.GetHashCode()));
            Assert.That(projection.ParentResourceId, Is.EqualTo(firstParent));
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
            RequestPathPattern? parentResourceIdPattern = null,
            ArmResourceNameConstraints? nameConstraints = null)
        {
            var path = new RequestPathPattern(resourceIdPattern);
            return new ArmResourceMetadata(
                path,
                resourceName ?? model.Name,
                resourceType,
                model,
                new ArmScopeInfo(scope, RequestPathPattern.GetFromScope(scope, path), null),
                [],
                singletonResourceName,
                parentResourceIdPattern ?? (parentResourceId is null ? null : new RequestPathPattern(parentResourceId)),
                [],
                nameConstraints ?? new ArmResourceNameConstraints(null, null, null),
                apiVersions,
                rbacRoles ?? [new ArmResourceRbacRole("FirstRole", "11111111-1111-1111-1111-111111111111")]);
        }

        private static InputModelType CreateModel(string name, IReadOnlyList<InputModelProperty>? properties = null)
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
                null,
                [],
                null,
                null,
                new Dictionary<string, InputModelType>(),
                null,
                false,
                new InputSerializationOptions(),
                false);
    }
}

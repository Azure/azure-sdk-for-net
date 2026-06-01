// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Models;
using Azure.Generator.Provisioning.Primitives;
using Microsoft.TypeSpec.Generator.Input;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Azure.Generator.Provisioning.Tests
{
    public class ProvisioningResourceProjectionTests
    {
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
                ["2024-02-01"]);

            var projections = ProvisioningResourceProjection.Create([resourceGroupResource, subscriptionResource]);

            Assert.That(projections, Has.Count.EqualTo(1));
            Assert.That(projections[0].PrimaryMetadata, Is.SameAs(resourceGroupResource));
            Assert.That(projections[0].Metadata, Is.EqualTo(new[] { resourceGroupResource, subscriptionResource }));
            Assert.That(projections[0].ResourceIdPatterns.Select(p => p.SerializedPath), Is.EqualTo(new[]
            {
                resourceGroupResource.ResourceIdPattern.SerializedPath,
                subscriptionResource.ResourceIdPattern.SerializedPath
            }));
            Assert.That(projections[0].ApiVersions, Is.EqualTo(new[] { "2024-01-01", "2024-02-01" }));
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

        private static ArmResourceMetadata CreateMetadata(
            InputModelType model,
            string resourceIdPattern,
            string resourceType,
            ResourceScope scope,
            IReadOnlyList<string> apiVersions)
        {
            var path = new RequestPathPattern(resourceIdPattern);
            return new ArmResourceMetadata(
                path,
                model.Name,
                resourceType,
                model,
                new ArmScopeInfo(scope, RequestPathPattern.GetFromScope(scope, path), null),
                [],
                null,
                null,
                [],
                new ArmResourceNameConstraints(null, null, null),
                apiVersions,
                []);
        }

        private static InputModelType CreateModel(string name)
            => new(
                name,
                "Sample.Models",
                $"Sample.Models.{name}",
                "public",
                null,
                string.Empty,
                "Test model.",
                InputModelTypeUsage.Input | InputModelTypeUsage.Output,
                [],
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

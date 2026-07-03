// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Models;
using Azure.Generator.Provisioning.Primitives;
using Azure.Generator.Provisioning.Providers;
using Azure.Generator.Provisioning.Tests.TestHelpers;
using Microsoft.TypeSpec.Generator.Input;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Azure.Generator.Provisioning.Tests
{
    public class ProvisioningResourceProviderTests
    {
        [SetUp]
        public void SetUp()
        {
            ProvisioningMockHelpers.LoadMockPlugin();
        }

        [Test]
        public void SingletonNamePropertyUsesFixedOutputDefault()
        {
            var nameProperty = CreateProperty("Name", "name", InputPrimitiveType.String);
            var resourceModel = CreateModel("Resource", [nameProperty]);
            _ = new ProvisioningModelProvider(resourceModel).Properties;
            var proxyModel = CreateModel("ProxyResource", baseModel: resourceModel);
            var model = CreateModel("ChildResource", baseModel: proxyModel);
            var metadata = CreateMetadata(
                model,
                "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Test/parents/{parentName}/children/default",
                "Microsoft.Test/parents/children",
                ResourceScope.ResourceGroup,
                ["2024-01-01"]);
            var projection = ProvisioningResourceProjection.Create([metadata])[0];
            var provider = new ProvisioningResourceProvider(projection);

            var info = ((IProvisioningPropertyInfo)provider).GetProvisioningPropertyInfo(nameProperty);

            Assert.That(info, Is.Not.Null);
            Assert.That(info!.PropertyName, Is.EqualTo("Name"));
            Assert.That(info.IsOutput, Is.True);
            Assert.That(info.IsRequired, Is.False);
            Assert.That(info.DefaultValue, Is.EqualTo("default"));
            Assert.That(info.BicepPath, Is.EqualTo(new[] { "name" }));

            var nameProvider = provider.Properties.OfType<ProvisioningPropertyProvider>().Single(property => property.Name == "Name");
            Assert.That(nameProvider.IsOutput, Is.True);
            Assert.That(nameProvider.IsRequired, Is.False);
            Assert.That(nameProvider.DefaultValue, Is.EqualTo("default"));
        }

        private static ArmResourceMetadata CreateMetadata(
            InputModelType model,
            string resourceIdPattern,
            string resourceType,
            ResourceScope scope,
            IReadOnlyList<string> apiVersions,
            string? singletonResourceName = null)
        {
            var path = new RequestPathPattern(resourceIdPattern);
            return new ArmResourceMetadata(
                path,
                model.Name,
                resourceType,
                model,
                new ArmScopeInfo(scope, RequestPathPattern.GetFromScope(scope, path), null),
                [],
                singletonResourceName,
                null,
                [],
                new ArmResourceNameConstraints(null, null, null),
                apiVersions,
                []);
        }

        private static InputModelType CreateModel(string name, IReadOnlyList<InputModelProperty>? properties = null, InputModelType? baseModel = null)
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
                null,
                null,
                new Dictionary<string, InputModelType>(),
                null,
                false,
                new InputSerializationOptions(),
                false);

        private static InputModelProperty CreateProperty(string name, string serializedName, InputType type, bool isReadOnly = false)
            => new(
                name: name,
                summary: null,
                doc: $"Description for {name}",
                type: type,
                isRequired: false,
                isReadOnly: isReadOnly,
                isApiVersion: false,
                defaultValue: null,
                isHttpMetadata: false,
                access: null,
                isDiscriminator: false,
                serializedName: serializedName,
                serializationOptions: new(json: new(serializedName)));
    }
}

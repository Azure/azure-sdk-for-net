// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Compute.Tests.Unit
{
    public class ModelReaderWriterTests
    {
        private const string AvailabilitySetJson = """
        {
            "id": "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg1/providers/Microsoft.Compute/availabilitySets/as1",
            "name": "as1",
            "type": "Microsoft.Compute/availabilitySets",
            "location": "eastus",
            "tags": {
                "environment": "test"
            },
            "systemData": {
                "createdBy": "user@example.com",
                "createdByType": "User",
                "createdAt": "2023-01-01T00:00:00Z"
            },
            "properties": {
                "platformFaultDomainCount": 2
            }
        }
        """;

        [Test]
        public void ConstructedFromWireJson()
        {
            var json = BinaryData.FromString(AvailabilitySetJson);

            AvailabilitySetData model = ModelReaderWriter.Read<AvailabilitySetData>(json)!;
            AvailabilitySetData contextModel = ModelReaderWriter.Read<AvailabilitySetData>(
                json,
                ModelReaderWriterOptions.Json,
                AzureResourceManagerComputeContext.Default)!;

            AssertAvailabilitySetData(model);
            AssertAvailabilitySetData(contextModel);
        }

        [Test]
        public void ConstructedFromModelJsonBuilder()
        {
            var resourceId = new ResourceIdentifier("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg1/providers/Microsoft.Compute/availabilitySets/as1");
            ModelJsonBuilder json = new();
            json.Set("$.id"u8, resourceId.ToString());
            json.Set("$.name"u8, "as1");
            json.Set("$.type"u8, "Microsoft.Compute/availabilitySets");
            json.Set("$.location"u8, "eastus");
            json.Set("$.properties.platformFaultDomainCount"u8, 2);

            AvailabilitySetData model = ModelReaderWriter.Read<AvailabilitySetData>(json.ToBinaryData())!;

            AssertAvailabilitySetIdentity(model);
            Assert.That(model.PlatformFaultDomainCount, Is.EqualTo(2));
        }

        [Test]
        public void ConstructedFromGenericTypedBuilder()
        {
            AvailabilitySetData model = ArmModelBuilder<AvailabilitySetData>.For(AvailabilitySetDataPaths)
                .Set(data => data.Id, new ResourceIdentifier("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg1/providers/Microsoft.Compute/availabilitySets/as1"))
                .Set(data => data.Name, "as1")
                .Set(data => data.ResourceType, new ResourceType("Microsoft.Compute/availabilitySets"))
                .Set(data => data.Location, AzureLocation.EastUS)
                .Set(data => data.PlatformFaultDomainCount, 2)
                .Build(AzureResourceManagerComputeContext.Default);

            AssertAvailabilitySetIdentity(model);
            Assert.That(model.PlatformFaultDomainCount, Is.EqualTo(2));
        }

        [Test]
        public void ConstructedFromConstructorBuilder()
        {
            AvailabilitySetData model = ArmModelBuilder<AvailabilitySetData>.For(
                    new AvailabilitySetData(AzureLocation.EastUS),
                    AvailabilitySetDataPaths)
                .Set(data => data.Id, new ResourceIdentifier("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg1/providers/Microsoft.Compute/availabilitySets/as1"))
                .Set(data => data.Name, "as1")
                .Set(data => data.ResourceType, new ResourceType("Microsoft.Compute/availabilitySets"))
                .Set(data => data.PlatformFaultDomainCount, 2)
                .Build(AzureResourceManagerComputeContext.Default);

            AssertAvailabilitySetIdentity(model);
            Assert.That(model.PlatformFaultDomainCount, Is.EqualTo(2));
        }

        private static void AssertAvailabilitySetData(AvailabilitySetData model)
        {
            Assert.Multiple(() =>
            {
                AssertAvailabilitySetIdentity(model);
                Assert.That(model.Tags["environment"], Is.EqualTo("test"));
                Assert.That(model.SystemData.CreatedBy, Is.EqualTo("user@example.com"));
                Assert.That(model.SystemData.CreatedByType, Is.EqualTo(CreatedByType.User));
                Assert.That(model.PlatformFaultDomainCount, Is.EqualTo(2));
            });
        }

        private static readonly IReadOnlyDictionary<string, string> AvailabilitySetDataPaths = new Dictionary<string, string>
        {
            [nameof(AvailabilitySetData.Id)] = "$.id",
            [nameof(AvailabilitySetData.Name)] = "$.name",
            [nameof(AvailabilitySetData.ResourceType)] = "$.type",
            [nameof(AvailabilitySetData.Location)] = "$.location",
            [nameof(AvailabilitySetData.PlatformFaultDomainCount)] = "$.properties.platformFaultDomainCount",
        };

        private static void AssertAvailabilitySetIdentity(AvailabilitySetData model)
        {
            Assert.Multiple(() =>
            {
                Assert.That(model.Id, Is.EqualTo(new ResourceIdentifier("/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg1/providers/Microsoft.Compute/availabilitySets/as1")));
                Assert.That(model.Name, Is.EqualTo("as1"));
                Assert.That(model.ResourceType, Is.EqualTo(new ResourceType("Microsoft.Compute/availabilitySets")));
                Assert.That(model.Location, Is.EqualTo(AzureLocation.EastUS));
            });
        }
    }
}

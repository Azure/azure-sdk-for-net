// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Network.Models;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Network.Tests
{
    [NUnit.Framework.Category("Compatibility")]
    public class CustomIPPrefixReferenceCompatibilityTests
    {
        private const string Prefix = "/subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/rg/providers/Microsoft.Network/";
        private static readonly string[] ChildIds = { Prefix + "customIPPrefixes/child1", Prefix + "customIPPrefixes/child2" };
        private static readonly string[] PublicIds = { Prefix + "publicIPPrefixes/public1", Prefix + "publicIPPrefixes/public2" };
        private static readonly PropertyInfo Properties = typeof(CustomIPPrefixData).GetProperty("Properties", BindingFlags.Instance | BindingFlags.NonPublic);

        [TestCase("ChildCustomIPPrefixList", typeof(WritableSubResource), "ChildCustomIPPrefixes")]
        [TestCase("ChildCustomIPPrefixes", typeof(CustomIPPrefixData), "ChildCustomIPPrefixes")]
        [TestCase("PublicIPPrefixes", typeof(WritableSubResource), "PublicIPPrefixes")]
        public void ReleasedGetterLazilyInitializesNativeStorage(string name, Type elementType, string nativeName)
        {
            var model = new CustomIPPrefixData();
            Assert.That(Properties.GetValue(model), Is.Null);
            PropertyInfo property = typeof(CustomIPPrefixData).GetProperty(name);
            Assert.That(property.PropertyType, Is.EqualTo(typeof(IReadOnlyList<>).MakeGenericType(elementType)));
            Assert.That(property.SetMethod, Is.Null);
            Assert.That(property.GetValue(model), Is.Empty);
            Assert.That(Properties.GetValue(model), Is.Not.Null);
            Assert.That(GetNativeList(model, nativeName), Is.Empty);
            if (name == "ChildCustomIPPrefixes")
            {
                Assert.That(property.GetCustomAttribute<ObsoleteAttribute>().Message,
                    Is.EqualTo("This property is obsolete and will be removed in a future release"));
                Assert.That(property.GetCustomAttribute<ObsoleteAttribute>().IsError, Is.False);
                Assert.That(property.GetCustomAttribute<EditorBrowsableAttribute>().State, Is.EqualTo(EditorBrowsableState.Never));
            }
            else
            {
                Assert.That(property.GetCustomAttribute<ObsoleteAttribute>(), Is.Null);
                string wireName = name == "ChildCustomIPPrefixList" ? "childCustomIpPrefixes" : "publicIpPrefixes";
                Assert.That(property.GetCustomAttributesData().Single(a => a.AttributeType.Name == "WirePathAttribute")
                    .ConstructorArguments[0].Value, Is.EqualTo("properties." + wireName));
            }
        }

        [TestCase("{}")]
        [TestCase("""{"properties":{}}""")]
        [TestCase("""{"properties":{"childCustomIpPrefixes":[],"publicIpPrefixes":[]}}""")]
        [TestCase("""{"properties":{"childCustomIpPrefixes":null,"publicIpPrefixes":null}}""")]
        public void MissingAndEmptyReferencesRemainEmpty(string payload)
        {
            CustomIPPrefixData model = ModelReaderWriter.Read<CustomIPPrefixData>(BinaryData.FromString(payload));
            AssertReferences(model, Array.Empty<string>(), Array.Empty<string>());
        }

        [Test]
        public void BothChildFacadesAndPublicReferencesUseNativeWireArrays()
        {
            CustomIPPrefixData model = ReadModel();
            object properties = Properties.GetValue(model);
            AssertReferences(model, ChildIds, PublicIds);
            Assert.That(Properties.GetValue(model), Is.SameAs(properties));
            BinaryData serialized = AssertPersistence(model, ChildIds, PublicIds);
            AssertReferences(ModelReaderWriter.Read<CustomIPPrefixData>(serialized), ChildIds, PublicIds);
        }

        [Test]
        public void UpdatedNativeReferencesAreVisibleInNewSnapshotsWithoutReplacingStorage()
        {
            CustomIPPrefixData model = ReadModel();
            object properties = Properties.GetValue(model);
            IReadOnlyList<WritableSubResource> childView = model.ChildCustomIPPrefixList;
            IReadOnlyList<WritableSubResource> publicView = model.PublicIPPrefixes;
            var children = (IList<NetworkSubResource>)GetNativeList(model, "ChildCustomIPPrefixes");
            var publicPrefixes = (IList<NetworkSubResource>)GetNativeList(model, "PublicIPPrefixes");
            string updatedChild = Prefix + "customIPPrefixes/updated";
            string thirdChild = Prefix + "customIPPrefixes/child3";
            string updatedPublic = Prefix + "publicIPPrefixes/updated";
            string thirdPublic = Prefix + "publicIPPrefixes/public3";
            children[0].Id = new ResourceIdentifier(updatedChild);
            children.Add(new NetworkSubResource { Id = new ResourceIdentifier(thirdChild) });
            publicPrefixes[0].Id = new ResourceIdentifier(updatedPublic);
            publicPrefixes.Add(new NetworkSubResource { Id = new ResourceIdentifier(thirdPublic) });
            string[] expectedChildren = { updatedChild, ChildIds[1], thirdChild };
            string[] expectedPublic = { updatedPublic, PublicIds[1], thirdPublic };
            Assert.That(childView.Select(item => item.Id.ToString()), Is.EqualTo(ChildIds));
            Assert.That(publicView.Select(item => item.Id.ToString()), Is.EqualTo(PublicIds));
            AssertReferences(model, expectedChildren, expectedPublic);
            Assert.That(Properties.GetValue(model), Is.SameAs(properties));
            AssertPersistence(model, expectedChildren, expectedPublic);
        }

        [TestCase("ChildCustomIPPrefixList", "ChildCustomIPPrefixes")]
        [TestCase("PublicIPPrefixes", "PublicIPPrefixes")]
        public void ReferenceSnapshotsContainFreshIdOnlyProjectionsWithoutWriteback(string name, string nativeName)
        {
            CustomIPPrefixData model = ReadModel();
            PropertyInfo property = typeof(CustomIPPrefixData).GetProperty(name);
            var snapshot = (IReadOnlyList<WritableSubResource>)property.GetValue(model);
            var freshSnapshot = (IReadOnlyList<WritableSubResource>)property.GetValue(model);
            Assert.That(freshSnapshot, Is.Not.SameAs(snapshot));
            Assert.That(freshSnapshot[0], Is.Not.SameAs(snapshot[0]));
            Assert.That(snapshot[0].Id, Is.EqualTo(GetNativeList(model, nativeName)[0].Id));
            using (JsonDocument json = JsonDocument.Parse(ModelReaderWriter.Write(snapshot[0], ModelReaderWriterOptions.Json)))
            {
                Assert.That(json.RootElement.EnumerateObject().Select(p => p.Name), Is.EqualTo(new[] { "id" }));
            }
            snapshot[0].Id = new ResourceIdentifier(Prefix + "customIPPrefixes/local");
            Assert.That(freshSnapshot[0].Id, Is.EqualTo(GetNativeList(model, nativeName)[0].Id));
            AssertReferences(model, ChildIds, PublicIds);
            AssertPersistence(model, ChildIds, PublicIds);
        }

        [Test]
        public void NullReferencesPreserveNativeAndLegacyAliasBehavior()
        {
            CustomIPPrefixData model = ModelReaderWriter.Read<CustomIPPrefixData>(
                BinaryData.FromString("""{"properties":{"childCustomIpPrefixes":[null],"publicIpPrefixes":[null]}}"""));
            Assert.That(model.ChildCustomIPPrefixList.Single(), Is.Null);
            Assert.That(model.PublicIPPrefixes.Single(), Is.Null);
#pragma warning disable CS0618
            Assert.Throws<NullReferenceException>(() => { _ = model.ChildCustomIPPrefixes; });
#pragma warning restore CS0618
            using JsonDocument json = JsonDocument.Parse(ModelReaderWriter.Write(model, ModelReaderWriterOptions.Json));
            Assert.That(json.RootElement.GetProperty("properties").GetProperty("childCustomIpPrefixes")[0].ValueKind, Is.EqualTo(JsonValueKind.Null));
            Assert.That(json.RootElement.GetProperty("properties").GetProperty("publicIpPrefixes")[0].ValueKind, Is.EqualTo(JsonValueKind.Null));
        }

        private static CustomIPPrefixData ReadModel() =>
            ModelReaderWriter.Read<CustomIPPrefixData>(BinaryData.FromString(JsonSerializer.Serialize(new
            {
                properties = new
                {
                    childCustomIpPrefixes = ChildIds.Select(id => new { id }),
                    publicIpPrefixes = PublicIds.Select(id => new { id })
                }
            })));

        private static IReadOnlyList<NetworkSubResource> GetNativeList(CustomIPPrefixData model, string name)
        {
            object properties = Properties.GetValue(model);
            return (IReadOnlyList<NetworkSubResource>)properties.GetType().GetProperty(name).GetValue(properties);
        }

        private static void AssertReferences(CustomIPPrefixData model, string[] children, string[] publicPrefixes)
        {
            Assert.That(model.ChildCustomIPPrefixList.Select(item => item.Id.ToString()), Is.EqualTo(children));
#pragma warning disable CS0618
            Assert.That(model.ChildCustomIPPrefixes.Select(item => item.Id.ToString()), Is.EqualTo(children));
#pragma warning restore CS0618
            Assert.That(model.PublicIPPrefixes.Select(item => item.Id.ToString()), Is.EqualTo(publicPrefixes));
        }

        private static BinaryData AssertPersistence(CustomIPPrefixData model, string[] children, string[] publicPrefixes)
        {
            BinaryData data = ModelReaderWriter.Write(model, ModelReaderWriterOptions.Json);
            using JsonDocument json = JsonDocument.Parse(data);
            JsonElement properties = json.RootElement.GetProperty("properties");
            Assert.That(properties.EnumerateObject().Select(p => p.Name),
                Is.EquivalentTo(new[] { "childCustomIpPrefixes", "publicIpPrefixes" }));
            AssertWireArray(properties.GetProperty("childCustomIpPrefixes"), children);
            AssertWireArray(properties.GetProperty("publicIpPrefixes"), publicPrefixes);
            return data;
        }

        private static void AssertWireArray(JsonElement array, string[] ids)
        {
            Assert.That(array.EnumerateArray().Select(item => item.GetProperty("id").GetString()), Is.EqualTo(ids));
            foreach (JsonElement item in array.EnumerateArray())
            {
                Assert.That(item.EnumerateObject().Select(p => p.Name), Is.EqualTo(new[] { "id" }));
            }
        }
    }
}

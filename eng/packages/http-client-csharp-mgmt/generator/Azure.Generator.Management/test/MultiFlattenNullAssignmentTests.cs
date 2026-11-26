// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Reflection;
using System.Text.Json;
using Azure.Generator.MgmtTypeSpec.Tests;
using Azure.Generator.MgmtTypeSpec.Tests.Models;
using NUnit.Framework;

namespace Azure.Generator.Mgmt.Tests
{
    /// <summary>
    /// Runtime regression tests for assigning null through a forwarding property
    /// (<c>MultiFlattenTestData.InnerSelectionType</c> -> <c>Properties.InnerSelectionType</c>)
    /// whose leaf is a safe-flattened optional wrapper with a required reference leaf. See #63548 / #63609.
    /// </summary>
    internal class MultiFlattenNullAssignmentTests
    {
        private static readonly PropertyInfo PropertiesProperty =
            typeof(MultiFlattenTestData).GetProperty("Properties", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public)!;

        private static object? GetProperties(MultiFlattenTestData model) => PropertiesProperty.GetValue(model);

        private static JsonElement Serialize(MultiFlattenTestData model)
        {
            var data = ((IPersistableModel<MultiFlattenTestData>)model).Write(new ModelReaderWriterOptions("J"));
            return JsonDocument.Parse(data).RootElement.Clone();
        }

        private static bool TryGetPropertiesJson(JsonElement root, out JsonElement properties)
            => root.TryGetProperty("properties", out properties);

        [Test]
        public void NullAssignmentWithAbsentWrapperDoesNotCreateWrapper()
        {
            MultiFlattenTestData model = null!;
            Assert.DoesNotThrow(() => model = new MultiFlattenTestData { InnerSelectionType = null });

            Assert.That(GetProperties(model), Is.Null);
            Assert.That(model.InnerSelectionType, Is.Null);

            JsonElement root = default;
            Assert.DoesNotThrow(() => root = Serialize(model));
            if (TryGetPropertiesJson(root, out var properties))
            {
                Assert.That(properties.TryGetProperty("inner", out _), Is.False);
            }
        }

        [Test]
        public void NullAssignmentWithExistingWrapperClearsOnlyInnerLeaf()
        {
            var model = new MultiFlattenTestData
            {
                Channel = FlattenChannel.Stable,
                Disabled = true,
                InnerSelectionType = "value"
            };
            Assert.That(Serialize(model).GetProperty("properties").TryGetProperty("inner", out _), Is.True);

            var wrapper = GetProperties(model);
            Assert.That(wrapper, Is.Not.Null);

            model.InnerSelectionType = null;

            Assert.That(GetProperties(model), Is.SameAs(wrapper));
            Assert.That(model.InnerSelectionType, Is.Null);
            Assert.That(model.Channel, Is.EqualTo(FlattenChannel.Stable));
            Assert.That(model.Disabled, Is.True);

            var properties = Serialize(model).GetProperty("properties");
            Assert.That(properties.TryGetProperty("inner", out _), Is.False);
            Assert.That(properties.GetProperty("channel").GetString(), Is.EqualTo(FlattenChannel.Stable.ToString()));
            Assert.That(properties.GetProperty("disabled").GetBoolean(), Is.True);
        }

        [Test]
        public void NonNullAssignmentWithAbsentWrapperCreatesWrapperAndInner()
        {
            var model = new MultiFlattenTestData();
            Assert.That(GetProperties(model), Is.Null);

            model.InnerSelectionType = "value";

            Assert.That(GetProperties(model), Is.Not.Null);
            Assert.That(model.InnerSelectionType, Is.EqualTo("value"));

            // Set the required sibling only after the forwarding assignment so the model serializes safely.
            model.Channel = FlattenChannel.Rapid;

            var properties = Serialize(model).GetProperty("properties");
            Assert.That(properties.GetProperty("inner").GetProperty("selectionType").GetString(), Is.EqualTo("value"));
        }
    }
}

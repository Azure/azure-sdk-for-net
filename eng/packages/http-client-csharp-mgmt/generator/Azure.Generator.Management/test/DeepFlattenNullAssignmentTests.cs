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
    /// Runtime + serialization regression tests for null assignment through multi-level forwarding chains.
    /// <c>MultiFlattenTestData.DeepInnerSelectionType</c> forwards through two wrappers
    /// (<c>Properties</c> -> <c>DeepMiddle</c>) to a safe-flattened required reference leaf, while
    /// <c>MultiFlattenTestData.Mode</c> (a plain sibling leaf in the same middle wrapper) is a control whose leaf is explicitly flattened
    /// (lazy-create-and-assign) and must keep that behavior.
    /// </summary>
    internal class DeepFlattenNullAssignmentTests
    {
        private static object? Get(object target, string name)
            => target.GetType().GetProperty(name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)!.GetValue(target);

        private static JsonElement Serialize<T>(T model) where T : class, IPersistableModel<T>
            => JsonDocument.Parse(model.Write(new ModelReaderWriterOptions("J"))).RootElement.Clone();

        // ---- Deep safe-flatten chain (Data -> Properties -> DeepMiddle -> DeepInner.selectionType) ----

        [Test]
        public void DeepNullAssignmentWithAbsentOuterWrapperCreatesNothing()
        {
            MultiFlattenTestData model = null!;
            Assert.DoesNotThrow(() => model = new MultiFlattenTestData { DeepInnerSelectionType = null });

            Assert.That(Get(model, "Properties"), Is.Null);
            Assert.That(model.DeepInnerSelectionType, Is.Null);

            JsonElement root = default;
            Assert.DoesNotThrow(() => root = Serialize(model));
            Assert.That(root.TryGetProperty("properties", out _), Is.False);
        }

        [Test]
        public void DeepNullAssignmentWithAbsentMiddleWrapperDoesNotCreateMiddle()
        {
            var model = new MultiFlattenTestData { Channel = FlattenChannel.Rapid };
            var properties = Get(model, "Properties");
            Assert.That(properties, Is.Not.Null);

            model.DeepInnerSelectionType = null;

            Assert.That(Get(model, "Properties"), Is.SameAs(properties));
            Assert.That(Get(properties!, "DeepMiddle"), Is.Null);

            var json = Serialize(model).GetProperty("properties");
            Assert.That(json.GetProperty("channel").GetString(), Is.EqualTo(FlattenChannel.Rapid.ToString()));
            Assert.That(json.TryGetProperty("deepMiddle", out _), Is.False);
        }

        [Test]
        public void DeepNullAssignmentWithExistingWrappersClearsOnlyDeepLeaf()
        {
            var model = new MultiFlattenTestData
            {
                Channel = FlattenChannel.Stable,
                Disabled = true,
                Mode = "mode",
                DeepNote = "note",
                DeepInnerSelectionType = "value"
            };
            var properties = Get(model, "Properties");
            var middle = Get(properties!, "DeepMiddle");
            Assert.That(middle, Is.Not.Null);
            Assert.That(Serialize(model).GetProperty("properties").GetProperty("deepMiddle").TryGetProperty("deepInner", out _), Is.True);

            model.DeepInnerSelectionType = null;

            Assert.That(Get(model, "Properties"), Is.SameAs(properties));
            Assert.That(Get(properties!, "DeepMiddle"), Is.SameAs(middle));
            Assert.That(model.DeepInnerSelectionType, Is.Null);
            Assert.That(model.Channel, Is.EqualTo(FlattenChannel.Stable));
            Assert.That(model.Disabled, Is.True);
            Assert.That(model.Mode, Is.EqualTo("mode"));
            Assert.That(model.DeepNote, Is.EqualTo("note"));

            var json = Serialize(model).GetProperty("properties");
            Assert.That(json.GetProperty("channel").GetString(), Is.EqualTo(FlattenChannel.Stable.ToString()));
            Assert.That(json.GetProperty("disabled").GetBoolean(), Is.True);
            var middleJson = json.GetProperty("deepMiddle");
            Assert.That(middleJson.GetProperty("mode").GetString(), Is.EqualTo("mode"));
            Assert.That(middleJson.GetProperty("deepNote").GetString(), Is.EqualTo("note"));
            Assert.That(middleJson.TryGetProperty("deepInner", out _), Is.False);
        }

        [Test]
        public void DeepNonNullAssignmentWithAbsentWrappersCreatesChain()
        {
            var model = new MultiFlattenTestData();
            Assert.That(Get(model, "Properties"), Is.Null);

            model.DeepInnerSelectionType = "value";

            var properties = Get(model, "Properties");
            Assert.That(properties, Is.Not.Null);
            Assert.That(Get(properties!, "DeepMiddle"), Is.Not.Null);
            Assert.That(model.DeepInnerSelectionType, Is.EqualTo("value"));

            // Fill the required siblings only after the forwarding assignment so the model serializes safely.
            model.Channel = FlattenChannel.Rapid;
            model.Mode = "mode";

            var middleJson = Serialize(model).GetProperty("properties").GetProperty("deepMiddle");
            Assert.That(middleJson.GetProperty("mode").GetString(), Is.EqualTo("mode"));
            Assert.That(middleJson.GetProperty("deepInner").GetProperty("selectionType").GetString(), Is.EqualTo("value"));
        }

        // ---- Explicit-flatten control (Data -> Properties -> DeepMiddle.mode, plain leaf, all explicit flatten) ----

        [Test]
        public void ExplicitFlattenNullAssignmentWithAbsentWrapperKeepsLazyCreateSemantics()
        {
            var model = new MultiFlattenTestData { Mode = null };

            // Explicit flatten setters are lazy-create-and-assign: both wrappers are created even for null.
            var properties = Get(model, "Properties");
            Assert.That(properties, Is.Not.Null);
            Assert.That(Get(properties!, "DeepMiddle"), Is.Not.Null);
            Assert.That(model.Mode, Is.Null);
        }

        [Test]
        public void ExplicitFlattenNonNullAssignmentWithAbsentWrapperCreatesChainAndSerializes()
        {
            var model = new MultiFlattenTestData();
            model.Mode = "mode";
            model.Channel = FlattenChannel.Rapid;

            Assert.That(model.Mode, Is.EqualTo("mode"));
            var middleJson = Serialize(model).GetProperty("properties").GetProperty("deepMiddle");
            Assert.That(middleJson.GetProperty("mode").GetString(), Is.EqualTo("mode"));
        }

        [Test]
        public void ExplicitFlattenNullAssignmentWithExistingWrappersPreservesWrappersAndSiblings()
        {
            var model = new MultiFlattenTestData
            {
                Channel = FlattenChannel.Stable,
                DeepNote = "note",
                DeepInnerSelectionType = "value",
                Mode = "mode"
            };
            var properties = Get(model, "Properties");
            var middle = Get(properties!, "DeepMiddle");

            model.Mode = null;

            Assert.That(Get(model, "Properties"), Is.SameAs(properties));
            Assert.That(Get(properties!, "DeepMiddle"), Is.SameAs(middle));
            Assert.That(model.Mode, Is.Null);
            Assert.That(model.DeepNote, Is.EqualTo("note"));
            Assert.That(model.DeepInnerSelectionType, Is.EqualTo("value"));
            Assert.That(model.Channel, Is.EqualTo(FlattenChannel.Stable));
        }
    }
}

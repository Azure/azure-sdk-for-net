// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text;
using BasicTypeSpec;
using NUnit.Framework;

#pragma warning disable SCME0001 // JsonPatch is experimental.

namespace TestProjects.Local.Tests
{
    [TestFixture]
    public class JsonPatchPropagationTests
    {
        [TestCase("requiredModel", false)]
        [TestCase("requiredModel", true)]
        [TestCase("modelWithRequiredNullable", false)]
        [TestCase("modelWithRequiredNullable", true)]
        public void GetPatchValueWithMissingNestedModel(string propertyName, bool explicitNull)
        {
            var model = ReadModel(explicitNull ? $"{{\"{propertyName}\":null}}" : "{}");
            byte[] path = Encoding.UTF8.GetBytes($"$.{propertyName}.unknown");

            Assert.IsFalse(model.Patch.TryGetValue(path, out string? value));
            Assert.IsNull(value);
        }

        [TestCase("requiredModel", false)]
        [TestCase("requiredModel", true)]
        [TestCase("modelWithRequiredNullable", false)]
        [TestCase("modelWithRequiredNullable", true)]
        public void SetPatchValueWithMissingNestedModel(string propertyName, bool explicitNull)
        {
            var model = ReadModel(explicitNull ? $"{{\"{propertyName}\":null}}" : "{}");
            byte[] path = Encoding.UTF8.GetBytes($"$.{propertyName}.unknown");

            model.Patch.Set(path, "updated");

            Assert.AreEqual("updated", model.Patch.GetString(path));
            Assert.IsNull(model.RequiredModel);
            Assert.IsNull(model.ModelWithRequiredNullable);
        }

        [TestCase("requiredModel")]
        [TestCase("modelWithRequiredNullable")]
        public void PatchValuesPropagateToExistingNestedModel(string propertyName)
        {
            var model = ReadModel($"{{\"{propertyName}\":{{\"unknown\":\"original\"}}}}");
            byte[] path = Encoding.UTF8.GetBytes($"$.{propertyName}.unknown");

            Assert.AreEqual("original", model.Patch.GetString(path));

            model.Patch.Set(path, "updated");

            Assert.AreEqual("updated", model.Patch.GetString(path));
            string? nestedValue = propertyName == "requiredModel"
                ? model.RequiredModel.Patch.GetString("$.unknown"u8)
                : model.ModelWithRequiredNullable.Patch.GetString("$.unknown"u8);
            Assert.AreEqual("updated", nestedValue);
        }

        private static RoundTripModel ReadModel(string json)
        {
            return ModelReaderWriter.Read<RoundTripModel>(
                BinaryData.FromString(json), ModelReaderWriterOptions.Json, BasicTypeSpecContext.Default)
                ?? throw new AssertionException("Deserialization returned null.");
        }
    }
}

#pragma warning restore SCME0001

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text.Json;
using Azure.Core.Serialization;
using Azure.Core.Tests.PatchModels;
using NUnit.Framework;

namespace Azure.Core.Tests.Public
{
    public class PatchModelTests
    {
        [Test]
        public void CanPatchIntProperty()
        {
            SimplePatchModel model = new();
            model.Count = 2;

            ValidatePatch("""{"count":2}""", model);
        }

        [Test]
        public void CanPatchStringProperty()
        {
            SimplePatchModel model = new();
            model.Name = "abc";

            ValidatePatch("""{"name":"abc"}""", model);
        }

        [Test]
        public void CanPatchDateTimeProperty()
        {
            DateTimeOffset updateTime = DateTimeOffset.Parse("2023-10-19T10:19:10.0190001Z");

            SimplePatchModel model = new();
            model.UpdatedOn = updateTime;

            ValidatePatch($"{{\"updatedOn\":\"{updateTime:O}\"}}", model);
        }

        [Test]
        public void CanRoundTripSimpleModel()
        {
            BinaryData json = BinaryData.FromString("""
                {
                    "name": "abc",
                    "count": 1
                }
                """);

            SimplePatchModel model = ModelSerializer.Deserialize<SimplePatchModel>(json);

            Assert.AreEqual(1, model.Count);
            Assert.AreEqual("abc", model.Name);

            model.Name = "xyz";
            model.Count = 2;

            ValidatePatch("""{"count":2, "name":"xyz"}""", model);
        }

        [Test]
        public void CanPatchChildModel()
        {
            ParentPatchModel model = new();

            model.Child.B = "bb";
            model.Child.A = "aa";

            ValidatePatch("""{"child": {"a": "aa", "b": "bb"}}""", model);
        }

        [Test]
        public void CanPatchChildModelOneProperty()
        {
            ParentPatchModel model = new();

            model.Child.A = "aa";

            ValidatePatch("""{"child": {"a": "aa"}}""", model);
        }

        #region Helpers
        private static void ValidatePatch<T>(string expected, IModelJsonSerializable<T> model)
        {
            using Stream stream = new MemoryStream();
            using Utf8JsonWriter writer = new(stream);
            model.Serialize(writer, new ModelSerializerOptions("P"));
            writer.Flush();
            stream.Position = 0;

            string actual = BinaryData.FromStream(stream).ToString();

            AreEqualJson(expected, actual);
        }

        private static void AreEqualJson(string expected, string actual)
        {
            JsonDocument doc = JsonDocument.Parse(expected);

            using MemoryStream stream = new();
            using Utf8JsonWriter writer = new(stream);
            doc.WriteTo(writer);
            writer.Flush();
            stream.Position = 0;
            BinaryData buffer = BinaryData.FromStream(stream);

            Assert.AreEqual(buffer.ToString(), actual);
        }
        #endregion
    }
}

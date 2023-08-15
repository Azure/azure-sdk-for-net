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

        #region Standard model

        [Test]
        public void CanSetIntProperty()
        {
            JsonDocument doc = JsonDocument.Parse("""
                {
                    "name": "abc",
                    "count": 1,
                    "updatedOn": "2023-10-19T10:19:10.0190001Z"
                }
                """);
            SimpleStandardModel model = SimpleStandardModel.DeserializeSimpleStandardModel(doc.RootElement, new ModelSerializerOptions("J"));
            model.Count = 2;

            ValidateSerialize("""
                {
                    "name": "abc",
                    "count": 2,
                    "updatedOn": "2023-10-19T10:19:10.0190001Z"
                }
                """, model);
        }

        [Test]
        public void CanSetStringProperty()
        {
            JsonDocument doc = JsonDocument.Parse("""
                {
                    "name": "abc",
                    "count": 1,
                    "updatedOn": "2023-10-19T10:19:10.0190001Z"
                }
                """);
            SimpleStandardModel model = SimpleStandardModel.DeserializeSimpleStandardModel(doc.RootElement, new ModelSerializerOptions("J"));
            model.Name = "xyz";

            ValidateSerialize("""
                {
                    "name": "xyz",
                    "count": 1,
                    "updatedOn": "2023-10-19T10:19:10.0190001Z"
                }
                """, model);
        }

        [Test]
        public void CanSetDateTimeProperty()
        {
            DateTimeOffset updateTime = DateTimeOffset.Parse("2023-10-20T10:20:10.0190001Z");
            JsonDocument doc = JsonDocument.Parse("""
                {
                    "name": "abc",
                    "count": 1,
                    "updatedOn": "2023-10-19T10:19:10.0190001Z"
                }
                """);

            SimpleStandardModel model = SimpleStandardModel.DeserializeSimpleStandardModel(doc.RootElement, new ModelSerializerOptions("J"));
            model.UpdatedOn = updateTime;

            ValidateSerialize("""
                {
                    "name": "abc",
                    "count": 1,
                    "updatedOn": "2023-10-20T10:20:10.0190001Z"
                }
                """, model);
        }

        [Test]
        public void CanRoundTripSimpleStandardModel()
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
        #endregion standard model

        [Test]
        public void CanPatchNestedModel()
        {
            ParentPatchModel model = new();

            model.Child.B = "bb";

            ValidatePatch("""{"child": {"b": "bb"}}""", model);

            model.Child.A = "aa";

            ValidatePatch("""{"child": {"a": "aa", "b": "bb"}}""", model);
        }

        [Test]
        public void CanPatchNestedModelOneProperty()
        {
            ParentPatchModel model = new();

            model.Child.A = "aa";

            ValidatePatch("""{"child": {"a": "aa"}}""", model);
        }

        [Test]
        public void CanPatchNestedModelOnePropertyAndChangeIt()
        {
            ParentPatchModel model = new();

            model.Child.A = "a1";

            ValidatePatch("""{"child": {"a": "a1"}}""", model);

            model.Child.A = "a2";

            ValidatePatch("""{"child": {"a": "a2"}}""", model);
        }

        [Test]
        public void CanPatchNestedModelInterleaveChanges()
        {
            ParentPatchModel model = new();

            model.Id = "id1";
            model.Child.B = "b1";
            model.Child.A = "a1";

            ValidatePatch("""{"child": {"a": "a1", "b": "b1"}, "id": "id1"}""", model);

            model.Child.A = "a2";
            model.Id = "id2";

            ValidatePatch("""{"child": {"a": "a2", "b": "b1"}, "id": "id2"}""", model);

            model.Child.A = null;
            model.Child.B = null;

            ValidatePatch("""{"child": {"a": null, "b": null}, "id": "id2"}""", model);
        }

        [Test]
        public void CanRoundTripNestedModel()
        {
            BinaryData json = BinaryData.FromString("""
                {
                    "id": "123",
                    "child": {
                        "a": "aa",
                        "b": "bb"
                    }
                }
                """);

            ParentPatchModel model = ModelSerializer.Deserialize<ParentPatchModel>(json);

            Assert.AreEqual("123", model.Id);
            Assert.AreEqual("aa", model.Child.A);
            Assert.AreEqual("bb", model.Child.B);

            ValidateSerialize("""{"id": "123", "child": {"a": "aa", "b": "bb"}}""", model);
            ValidatePatch(string.Empty, model);

            model.Child.A = "a2";
            model.Child.B = null;

            ValidateSerialize("""{"id": "123", "child": {"a": "a2", "b": null}}""", model);
            ValidatePatch("""{"child": {"a": "a2", "b": null}}""", model);
        }

        #region Helpers
        private static void ValidateSerialize<T>(string expected, IModelJsonSerializable<T> model)
        {
            using Stream stream = new MemoryStream();
            using Utf8JsonWriter writer = new(stream);
            model.Serialize(writer, new ModelSerializerOptions("J"));
            writer.Flush();
            stream.Position = 0;

            string actual = BinaryData.FromStream(stream).ToString();

            AreEqualJson(expected, actual);
        }

        private static void ValidatePatch<T>(string expected, IModelJsonSerializable<T> model)
        {
            using Stream stream = new MemoryStream();
            using Utf8JsonWriter writer = new(stream);
            model.Serialize(writer, new ModelSerializerOptions("P"));
            writer.Flush();
            stream.Position = 0;

            string actual = BinaryData.FromStream(stream).ToString();

            if (expected.Length == 0)
            {
                Assert.AreEqual(expected, actual);
                return;
            }

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

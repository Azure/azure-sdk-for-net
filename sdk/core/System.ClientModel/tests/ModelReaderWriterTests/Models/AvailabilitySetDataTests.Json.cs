// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.Client.Models.ResourceManager.Compute;
using System.Text.Json;
using NUnit.Framework;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Models
{
    internal partial class AvailabilitySetDataTests
    {
        [Test]
        public void AddInt32Property()
        {
            var model = GetInitialModel();
            var pointer = "$.foobar"u8;
            model.Patch.Set(pointer, 5);

            Assert.AreEqual(5, model.Patch.GetInt32(pointer));
            Assert.AreEqual(5, model.Patch.GetNullableInt32(pointer));

            var data = WriteModifiedModel(model, "foobar", "5");

            var model2 = GetRoundTripModel(data);
            Assert.AreEqual(5, model2.Patch.GetInt32(pointer));
            Assert.AreEqual(5, model2.Patch.GetNullableInt32(pointer));

            AssertCommon(model, model2);
        }

        [Test]
        public void GetInt32FailsWhenNull()
        {
            var model = GetInitialModel();
            model.Patch.SetNull("$.foobar"u8);

            Assert.Throws<FormatException>(() => model.Patch.GetInt32("$.foobar"u8));
            var data = WriteModifiedModel(model, "foobar", "null");

            var model2 = GetRoundTripModel(data);
            Assert.AreEqual(null, model2.Patch.GetNullableInt32("$.foobar"u8));
            Assert.Throws<FormatException>(() => model2.Patch.GetInt32("$.foobar"u8));

            AssertCommon(model, model2);
        }

        [Test]
        public void AddStringProperty()
        {
            var value = "some value";
            var pointer = "$.foobar"u8;

            var model = GetInitialModel();
            model.Patch.Set(pointer, value);

            Assert.AreEqual(value, model.Patch.GetString(pointer));
            var data = WriteModifiedModel(model, "foobar", "\"some value\"");

            var model2 = GetRoundTripModel(data);
            Assert.AreEqual(value, model2.Patch.GetString(pointer));

            AssertCommon(model, model2);
        }

        [Test]
        public void AddNullProperty()
        {
            var pointer = "$.foobar"u8;

            var model = GetInitialModel();
            model.Patch.SetNull(pointer);
            Assert.AreEqual(null, model.Patch.GetString(pointer));
            Assert.AreEqual(null, model.Patch.GetNullableInt32(pointer));

            var data = WriteModifiedModel(model, "foobar", "null");

            var model2 = GetRoundTripModel(data);
            Assert.AreEqual(null, model2.Patch.GetString(pointer));
            Assert.AreEqual(null, model2.Patch.GetNullableInt32(pointer));

            AssertCommon(model, model2);
        }

        [Test]
        public void ChangeFlattenedProperty()
        {
            ReadOnlySpan<byte> propertyNameSpan = "$.properties.platformUpdateDomainCount"u8;
            int expectedValue = 999;

            var model = GetInitialModel();

            model.Patch.Set(propertyNameSpan, expectedValue);

            Assert.AreEqual(expectedValue, model.Patch.GetInt32(propertyNameSpan));
            Assert.AreEqual(expectedValue, model.Patch.GetNullableInt32(propertyNameSpan));

            var data = WriteModifiedModel(model, "platformUpdateDomainCount", $"{expectedValue}");

            var model2 = GetRoundTripModel(data);
            // potential symmetry issue we set with Patch property but we have to get on the round trip with actual property
            //Assert.AreEqual(expectedValue, model2.Patch.GetInt32(propertyNameSpan));
            Assert.AreEqual(expectedValue, model2.PlatformUpdateDomainCount);

            AssertCommon(model, model2, "platformUpdateDomainCount");
        }

        [Test]
        public void ChangeExistingProperty()
        {
            ReadOnlySpan<byte> propertyNameSpan = "$.location"u8;
            string propertyName = "location";
            string expectedValue = "new-location";

            var model = GetInitialModel();

            model.Patch.Set(propertyNameSpan, expectedValue);

            Assert.AreEqual(expectedValue, model.Patch.GetString(propertyNameSpan));
            Assert.AreEqual("eastus", model.Location);

            var data = WriteModifiedModel(model, propertyName, $"\"{expectedValue}\"");

            var model2 = GetRoundTripModel(data);
            // potential symmetry issue we set with Patch property but we have to get on the round trip with actual property
            //Assert.AreEqual(expectedValue, model2.Patch.GetString(propertyNameSpan));
            Assert.AreEqual(expectedValue, model2.Location);

            AssertCommon(model, model2, propertyName);
        }

        [Test]
        public void ChangeExistingNestedProperty()
        {
            ReadOnlySpan<byte> propertyNameSpan = "$.sku.name"u8;
            string expectedValue = "new-sku-name";

            var model = GetInitialModel();

            Assert.AreEqual("Classic", model.Sku.Name);

            model.Patch.Set(propertyNameSpan, expectedValue);

            Assert.AreEqual(expectedValue, model.Patch.GetString(propertyNameSpan));
            // should this propagate before serialization time?
            //Assert.AreEqual(expectedValue, model.Sku.Patch.GetString("name"u8));

            var data = WriteModifiedModel(model);

            var model2 = GetRoundTripModel(data);
            // potential symmetry issue we set with Patch property but we have to get on the round trip with actual property
            //Assert.AreEqual(expectedValue, model2.Patch.GetString(propertyNameSpan));
            //Assert.AreEqual(expectedValue, model2.Sku.Patch.GetString("name"u8));
            Assert.AreEqual(expectedValue, model2.Sku.Name);

            AssertCommon(model, model2, "sku");
        }

        [Test]
        public void AddNewNestedProperty()
        {
            ReadOnlySpan<byte> propertyNameSpan = "$.sku.something"u8;
            string expectedValue = "something-value";

            var model = GetInitialModel();

            model.Patch.Set(propertyNameSpan, expectedValue);

            Assert.AreEqual(expectedValue, model.Patch.GetString(propertyNameSpan));

            var data = WriteModifiedModel(model, "something", "\"something-value\"");

            var model2 = GetRoundTripModel(data);
            //Assert.AreEqual(expectedValue, model2.Json.GetString(propertyNameSpan));
            Assert.AreEqual(expectedValue, model2.Sku.Patch.GetString("$.something"u8));

            AssertCommon(model, model2, "sku");
        }

        [Test]
        public void AddComplexPropertyAsJson()
        {
            ReadOnlySpan<byte> expectedValue = "{\"x\":{\"y\":123}}"u8;
            var pointer = "$.foobar"u8;
            var model = GetInitialModel();

            model.Patch.Set(pointer, expectedValue);

            CollectionAssert.AreEqual(expectedValue.ToArray(), model.Patch.GetJson(pointer).ToArray());

            var data = WriteModifiedModel(model, "foobar", "{\"x\":{\"y\":123}}");

            var model2 = GetRoundTripModel(data);
            CollectionAssert.AreEqual(expectedValue.ToArray(), model2.Patch.GetJson(pointer).ToArray());

            AssertCommon(model, model2);
        }

        [Test]
        public void AddComplexPropertyAsAnonModel()
        {
            ReadOnlySpan<byte> expectedValue = "{\"x\":{\"y\":123}}"u8;
            var pointer = "$.foobar"u8;
            var model = GetInitialModel();

            model.Patch.Set(pointer, JsonSerializer.SerializeToUtf8Bytes(new
            {
                x = new
                {
                    y = 123
                }
            }));

            CollectionAssert.AreEqual(expectedValue.ToArray(), model.Patch.GetJson(pointer).ToArray());

            var data = WriteModifiedModel(model, "foobar", "{\"x\":{\"y\":123}}");

            var model2 = GetRoundTripModel(data);
            CollectionAssert.AreEqual(expectedValue.ToArray(), model2.Patch.GetJson(pointer).ToArray());

            AssertCommon(model, model2);
        }

        [Test]
        public void ReplaceExistingComplex()
        {
            ReadOnlySpan<byte> expectedValue = "{\"name\":\"replaced-name\",\"foo\":123}"u8;
            var pointer = "$.sku"u8;
            var model = GetInitialModel();

            model.Patch.Set(pointer, expectedValue);

            CollectionAssert.AreEqual(expectedValue.ToArray(), model.Patch.GetJson(pointer).ToArray());

            var data = WriteModifiedModel(model, "sku", "{\"name\":\"replaced-name\",\"foo\":123}");

            var model2 = GetRoundTripModel(data);
            Assert.AreEqual("replaced-name", model2.Sku.Name);
            Assert.AreEqual(123, model2.Sku.Patch.GetInt32("$.foo"u8));

            AssertCommon(model, model2, "sku");
        }

        [Test]
        public void SetClrAfterJsonProperty()
        {
            var model = GetInitialModel();
            var pointer = "$.location"u8;

            model.Patch.Set(pointer, "new-location");
            Assert.AreEqual("new-location", model.Patch.GetString(pointer));

            //setting the location property directly does not override the patch
            //if we want this we need to tie property setters to the patch which is very tricky
            model.Location = "another-location";
            Assert.AreEqual("new-location", model.Patch.GetString(pointer));

            var data = WriteModifiedModel(model);

            var model2 = GetRoundTripModel(data);

            Assert.AreEqual("new-location", model2.Location);
        }

        [Test]
        public void AddNewFlattenedProperty()
        {
            Assert.Fail("Not implemented");
        }

        private AvailabilitySetData GetInitialModel()
        {
            var model = ModelReaderWriter.Read<AvailabilitySetData>(BinaryData.FromString(JsonPayload));
            Assert.IsNotNull(model);
            return model!;
        }

        private static BinaryData WriteModifiedModel(AvailabilitySetData model, string? propertyName = null, string? expectedJsonValue = null)
        {
            var data = ModelReaderWriter.Write(model);
            if (propertyName is not null)
            {
                var json = data.ToString();
                Assert.IsTrue(json.Contains($"\"{propertyName}\":{expectedJsonValue}"), $"Did not find \"{propertyName}\":{expectedJsonValue}, json was:\n{json}");
            }
            return data;
        }

        private static AvailabilitySetData GetRoundTripModel(BinaryData data)
        {
            var model2 = ModelReaderWriter.Read<AvailabilitySetData>(data);
            Assert.IsNotNull(model2);
            return model2!;
        }

        private static void AssertCommon(AvailabilitySetData model, AvailabilitySetData model2, params string[] skips)
        {
            Assert.AreEqual("extraSku", model2.Patch.GetString("$.extraSku"u8));
            Assert.AreEqual("extraRoot", model2.Patch.GetString("$.extraRoot"u8));
            CompareAvailabilitySetData(model, model2, "J", skips);
        }
    }
}

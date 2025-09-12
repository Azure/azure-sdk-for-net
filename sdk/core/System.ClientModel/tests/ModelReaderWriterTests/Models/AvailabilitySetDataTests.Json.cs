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
            Assert.AreEqual(5, model.Patch.GetNullableValue<int>(pointer));
            Assert.AreEqual(
                "[{\"op\":\"add\",\"path\":\"/foobar\",\"value\":5}]",
                model.Patch.ToString());

            var data = ModelReaderWriter.Write(model);
            Assert.AreEqual(
                "{\"name\":\"testAS-3375\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375\",\"type\":\"Microsoft.Compute/availabilitySets\",\"sku\":{\"name\":\"Classic\"},\"tags\":{\"key\":\"value\"},\"location\":\"eastus\",\"properties\":{\"platformUpdateDomainCount\":5,\"platformFaultDomainCount\":3},\"extraSku\":\"extraSku\",\"extraRoot\":\"extraRoot\",\"foobar\":5}",
                data.ToString());

            var model2 = GetRoundTripModel(data);
            Assert.AreEqual(5, model2.Patch.GetInt32(pointer));
            Assert.AreEqual(5, model2.Patch.GetNullableValue<int>(pointer));
            Assert.AreEqual("[]", model2.Patch.ToString());

            AssertCommon(model, model2);
        }

        [Test]
        public void GetInt32FailsWhenNull()
        {
            var model = GetInitialModel();
            model.Patch.SetNull("$.foobar"u8);

            Assert.Throws<FormatException>(() => model.Patch.GetInt32("$.foobar"u8));
            var data = ModelReaderWriter.Write(model);
            Assert.AreEqual(
                "{\"name\":\"testAS-3375\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375\",\"type\":\"Microsoft.Compute/availabilitySets\",\"sku\":{\"name\":\"Classic\"},\"tags\":{\"key\":\"value\"},\"location\":\"eastus\",\"properties\":{\"platformUpdateDomainCount\":5,\"platformFaultDomainCount\":3},\"extraSku\":\"extraSku\",\"extraRoot\":\"extraRoot\",\"foobar\":null}",
                data.ToString());

            var model2 = GetRoundTripModel(data);
            Assert.AreEqual(null, model2.Patch.GetNullableValue<int>("$.foobar"u8));
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
            var data = ModelReaderWriter.Write(model);
            Assert.AreEqual(
                "{\"name\":\"testAS-3375\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375\",\"type\":\"Microsoft.Compute/availabilitySets\",\"sku\":{\"name\":\"Classic\"},\"tags\":{\"key\":\"value\"},\"location\":\"eastus\",\"properties\":{\"platformUpdateDomainCount\":5,\"platformFaultDomainCount\":3},\"extraSku\":\"extraSku\",\"extraRoot\":\"extraRoot\",\"foobar\":\"some value\"}",
                data.ToString());

            var model2 = GetRoundTripModel(data);
            Assert.AreEqual(value, model2.Patch.GetString(pointer));

            AssertCommon(model, model2);
        }

        [Test]
        public void AddSameStringProperty()
        {
            var value = "some value";
            var pointer = "$.foobar"u8;

            var model = GetInitialModel();
            model.Patch.Set(pointer, value);
            Assert.AreEqual(
                "[{\"op\":\"add\",\"path\":\"/foobar\",\"value\":\"some value\"}]",
                model.Patch.ToString());

            model.Patch.Set("$['foobar']"u8, "some other value");

            Assert.AreEqual("some other value", model.Patch.GetString(pointer));
            Assert.AreEqual("some other value", model.Patch.GetString("$['foobar']"u8));
            Assert.AreEqual(
                "[{\"op\":\"add\",\"path\":\"/foobar\",\"value\":\"some other value\"}]",
                model.Patch.ToString());

            var data = ModelReaderWriter.Write(model);
            Assert.AreEqual(
                "{\"name\":\"testAS-3375\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375\",\"type\":\"Microsoft.Compute/availabilitySets\",\"sku\":{\"name\":\"Classic\"},\"tags\":{\"key\":\"value\"},\"location\":\"eastus\",\"properties\":{\"platformUpdateDomainCount\":5,\"platformFaultDomainCount\":3},\"extraSku\":\"extraSku\",\"extraRoot\":\"extraRoot\",\"foobar\":\"some other value\"}",
                data.ToString());

            var model2 = GetRoundTripModel(data);
            Assert.AreEqual("some other value", model2.Patch.GetString(pointer));
            Assert.AreEqual("some other value", model2.Patch.GetString("$['foobar']"u8));
            Assert.AreEqual("[]", model2.Patch.ToString());

            AssertCommon(model, model2);
        }

        [Test]
        public void AddNullProperty()
        {
            var pointer = "$.foobar"u8;

            var model = GetInitialModel();
            model.Patch.SetNull(pointer);
            Assert.AreEqual(null, model.Patch.GetString(pointer));
            Assert.AreEqual(null, model.Patch.GetNullableValue<int>(pointer));
            Assert.AreEqual(
                "[{\"op\":\"add\",\"path\":\"/foobar\",\"value\":null}]",
                model.Patch.ToString());

            var data = ModelReaderWriter.Write(model);
            Assert.AreEqual(
                "{\"name\":\"testAS-3375\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375\",\"type\":\"Microsoft.Compute/availabilitySets\",\"sku\":{\"name\":\"Classic\"},\"tags\":{\"key\":\"value\"},\"location\":\"eastus\",\"properties\":{\"platformUpdateDomainCount\":5,\"platformFaultDomainCount\":3},\"extraSku\":\"extraSku\",\"extraRoot\":\"extraRoot\",\"foobar\":null}",
                data.ToString());

            var model2 = GetRoundTripModel(data);
            Assert.AreEqual(null, model2.Patch.GetString(pointer));
            Assert.AreEqual(null, model2.Patch.GetNullableValue<int>(pointer));
            Assert.AreEqual("[]", model2.Patch.ToString());

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
            Assert.AreEqual(expectedValue, model.Patch.GetNullableValue<int>(propertyNameSpan));
            Assert.AreEqual(
                "[{\"op\":\"replace\",\"path\":\"/properties/platformUpdateDomainCount\",\"value\":999}]",
                model.Patch.ToString());

            var data = ModelReaderWriter.Write(model);
            Assert.AreEqual(
                "{\"name\":\"testAS-3375\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375\",\"type\":\"Microsoft.Compute/availabilitySets\",\"sku\":{\"name\":\"Classic\"},\"tags\":{\"key\":\"value\"},\"location\":\"eastus\",\"properties\":{\"platformFaultDomainCount\":3,\"platformUpdateDomainCount\":999},\"extraSku\":\"extraSku\",\"extraRoot\":\"extraRoot\"}",
                data.ToString());

            var model2 = GetRoundTripModel(data);

            Assert.AreEqual(expectedValue, model2.Patch.GetInt32(propertyNameSpan));
            Assert.AreEqual(expectedValue, model2.PlatformUpdateDomainCount);
            Assert.AreEqual("[]", model2.Patch.ToString());

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
            Assert.AreEqual(
                "[{\"op\":\"replace\",\"path\":\"/location\",\"value\":\"new-location\"}]",
                model.Patch.ToString());

            var data = ModelReaderWriter.Write(model);
            Assert.AreEqual(
                "{\"name\":\"testAS-3375\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375\",\"type\":\"Microsoft.Compute/availabilitySets\",\"sku\":{\"name\":\"Classic\"},\"tags\":{\"key\":\"value\"},\"properties\":{\"platformUpdateDomainCount\":5,\"platformFaultDomainCount\":3},\"extraSku\":\"extraSku\",\"extraRoot\":\"extraRoot\",\"location\":\"new-location\"}",
                data.ToString());

            var model2 = GetRoundTripModel(data);
            Assert.AreEqual(expectedValue, model2.Patch.GetString(propertyNameSpan));
            Assert.AreEqual(expectedValue, model2.Location);
            Assert.AreEqual("[]", model2.Patch.ToString());

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
            Assert.AreEqual(expectedValue, model.Sku.Patch.GetString("$.name"u8));
            Assert.AreEqual("[]", model.Patch.ToString());
            Assert.AreEqual(
                "[{\"op\":\"replace\",\"path\":\"/name\",\"value\":\"new-sku-name\"}]",
                model.Sku.Patch.ToString());

            var data = ModelReaderWriter.Write(model);
            Assert.AreEqual(
                "{\"name\":\"testAS-3375\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375\",\"type\":\"Microsoft.Compute/availabilitySets\",\"sku\":{\"name\":\"new-sku-name\"},\"tags\":{\"key\":\"value\"},\"location\":\"eastus\",\"properties\":{\"platformUpdateDomainCount\":5,\"platformFaultDomainCount\":3},\"extraSku\":\"extraSku\",\"extraRoot\":\"extraRoot\"}",
                data.ToString());

            var model2 = GetRoundTripModel(data);
            Assert.AreEqual(expectedValue, model2.Patch.GetString(propertyNameSpan));
            Assert.AreEqual(expectedValue, model2.Sku.Patch.GetString("$.name"u8));
            Assert.AreEqual(expectedValue, model2.Sku.Name);
            Assert.AreEqual("[]", model2.Patch.ToString());
            Assert.AreEqual("[]", model2.Sku.Patch.ToString());

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
            Assert.AreEqual(expectedValue, model.Sku.Patch.GetString("$.something"u8));
            Assert.AreEqual("[]", model.Patch.ToString());
            Assert.AreEqual(
                "[{\"op\":\"add\",\"path\":\"/something\",\"value\":\"something-value\"}]",
                model.Sku.Patch.ToString());

            var data = ModelReaderWriter.Write(model);
            Assert.AreEqual(
                "{\"name\":\"testAS-3375\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375\",\"type\":\"Microsoft.Compute/availabilitySets\",\"sku\":{\"name\":\"Classic\",\"something\":\"something-value\"},\"tags\":{\"key\":\"value\"},\"location\":\"eastus\",\"properties\":{\"platformUpdateDomainCount\":5,\"platformFaultDomainCount\":3},\"extraSku\":\"extraSku\",\"extraRoot\":\"extraRoot\"}",
                data.ToString());

            var model2 = GetRoundTripModel(data);

            Assert.AreEqual(expectedValue, model2.Patch.GetString(propertyNameSpan));
            Assert.AreEqual("Classic", model2.Sku.Name);
            Assert.AreEqual(expectedValue, model2.Sku.Patch.GetString("$.something"u8));
            Assert.AreEqual("[]", model2.Patch.ToString());
            Assert.AreEqual("[]", model2.Sku.Patch.ToString());

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
            Assert.AreEqual("{\"y\":123}"u8.ToArray(), model.Patch.GetJson("$.foobar.x"u8).ToArray());
            Assert.AreEqual(123, model.Patch.GetInt32("$.foobar.x.y"u8));
            Assert.AreEqual(123, model.Patch.GetNullableValue<int>("$.foobar.x.y"u8));
            Assert.AreEqual(
                "[{\"op\":\"add\",\"path\":\"/foobar\",\"value\":{\"x\":{\"y\":123}}}]",
                model.Patch.ToString());

            var data = ModelReaderWriter.Write(model);
            Assert.AreEqual(
                "{\"name\":\"testAS-3375\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375\",\"type\":\"Microsoft.Compute/availabilitySets\",\"sku\":{\"name\":\"Classic\"},\"tags\":{\"key\":\"value\"},\"location\":\"eastus\",\"properties\":{\"platformUpdateDomainCount\":5,\"platformFaultDomainCount\":3},\"extraSku\":\"extraSku\",\"extraRoot\":\"extraRoot\",\"foobar\":{\"x\":{\"y\":123}}}",
                data.ToString());

            var model2 = GetRoundTripModel(data);

            CollectionAssert.AreEqual(expectedValue.ToArray(), model2.Patch.GetJson(pointer).ToArray());
            Assert.AreEqual("{\"y\":123}"u8.ToArray(), model2.Patch.GetJson("$.foobar.x"u8).ToArray());
            Assert.AreEqual(123, model2.Patch.GetInt32("$.foobar.x.y"u8));
            Assert.AreEqual(123, model2.Patch.GetNullableValue<int>("$.foobar.x.y"u8));
            Assert.AreEqual("[]", model2.Patch.ToString());

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
            Assert.AreEqual(
                "[{\"op\":\"add\",\"path\":\"/foobar\",\"value\":{\"x\":{\"y\":123}}}]",
                model.Patch.ToString());

            var data = ModelReaderWriter.Write(model);
            Assert.AreEqual(
                "{\"name\":\"testAS-3375\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375\",\"type\":\"Microsoft.Compute/availabilitySets\",\"sku\":{\"name\":\"Classic\"},\"tags\":{\"key\":\"value\"},\"location\":\"eastus\",\"properties\":{\"platformUpdateDomainCount\":5,\"platformFaultDomainCount\":3},\"extraSku\":\"extraSku\",\"extraRoot\":\"extraRoot\",\"foobar\":{\"x\":{\"y\":123}}}",
                data.ToString());

            var model2 = GetRoundTripModel(data);
            CollectionAssert.AreEqual(expectedValue.ToArray(), model2.Patch.GetJson(pointer).ToArray());
            Assert.AreEqual("[]", model2.Patch.ToString());

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
            Assert.AreEqual("[]", model.Patch.ToString());
            Assert.AreEqual(
                "[{\"op\":\"replace\",\"path\":\"/\",\"value\":{\"name\":\"replaced-name\",\"foo\":123}}]",
                model.Sku.Patch.ToString());

            var data = ModelReaderWriter.Write(model);
            Assert.AreEqual(
                "{\"name\":\"testAS-3375\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375\",\"type\":\"Microsoft.Compute/availabilitySets\",\"sku\":{\"name\":\"replaced-name\",\"foo\":123},\"tags\":{\"key\":\"value\"},\"location\":\"eastus\",\"properties\":{\"platformUpdateDomainCount\":5,\"platformFaultDomainCount\":3},\"extraSku\":\"extraSku\",\"extraRoot\":\"extraRoot\"}",
                data.ToString());

            var model2 = GetRoundTripModel(data);
            Assert.AreEqual("replaced-name", model2.Sku.Name);
            Assert.AreEqual(123, model2.Sku.Patch.GetInt32("$.foo"u8));
            Assert.AreEqual("[]", model2.Patch.ToString());
            Assert.AreEqual("[]", model2.Sku.Patch.ToString());

            model2.Patch.Set("$.sku.foo"u8, 999);
            Assert.AreEqual("[{\"op\":\"replace\",\"path\":\"/foo\",\"value\":999}]", model2.Sku.Patch.ToString());

            AssertCommon(model, model2, "sku");
        }

        [Test]
        public void SetClrAfterJsonProperty()
        {
            var model = GetInitialModel();
            var pointer = "$.location"u8;

            model.Patch.Set(pointer, "new-location");

            Assert.AreEqual("new-location", model.Patch.GetString(pointer));
            Assert.AreEqual(
                "[{\"op\":\"replace\",\"path\":\"/location\",\"value\":\"new-location\"}]",
                model.Patch.ToString());

            //setting the location property directly does not override the patch
            //if we want this we need to tie property setters to the patch which is very tricky
            model.Location = "another-location";
            Assert.AreEqual("new-location", model.Patch.GetString(pointer));

            var data = ModelReaderWriter.Write(model);
            Assert.AreEqual(
                "{\"name\":\"testAS-3375\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375\",\"type\":\"Microsoft.Compute/availabilitySets\",\"sku\":{\"name\":\"Classic\"},\"tags\":{\"key\":\"value\"},\"properties\":{\"platformUpdateDomainCount\":5,\"platformFaultDomainCount\":3},\"extraSku\":\"extraSku\",\"extraRoot\":\"extraRoot\",\"location\":\"new-location\"}",
                data.ToString());

            var model2 = GetRoundTripModel(data);

            Assert.AreEqual("new-location", model2.Location);
            Assert.AreEqual("[]", model2.Patch.ToString());
        }

        [Test]
        public void AddNewObjectThenANewPropertyToThatObject()
        {
            var model = GetInitialModel();

            model.Patch.Set("$.foobar"u8, "{\"x\":\"value\"}"u8);

            Assert.AreEqual("{\"x\":\"value\"}"u8.ToArray(), model.Patch.GetJson("$.foobar"u8).ToArray());
            Assert.AreEqual(
                "[{\"op\":\"add\",\"path\":\"/foobar\",\"value\":{\"x\":\"value\"}}]",
                model.Patch.ToString());

            model.Patch.Set("$.foobar.name"u8, "vmName1");

            Assert.AreEqual("vmName1", model.Patch.GetString("$.foobar.name"u8));
            Assert.AreEqual(
                "[{\"op\":\"add\",\"path\":\"/foobar\",\"value\":{\"x\":\"value\",\"name\":\"vmName1\"}}]",
                model.Patch.ToString());

            var data = ModelReaderWriter.Write(model);
            Assert.AreEqual(
                "{\"name\":\"testAS-3375\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375\",\"type\":\"Microsoft.Compute/availabilitySets\",\"sku\":{\"name\":\"Classic\"},\"tags\":{\"key\":\"value\"},\"location\":\"eastus\",\"properties\":{\"platformUpdateDomainCount\":5,\"platformFaultDomainCount\":3},\"extraSku\":\"extraSku\",\"extraRoot\":\"extraRoot\",\"foobar\":{\"x\":\"value\",\"name\":\"vmName1\"}}",
                data.ToString());

            var model2 = GetRoundTripModel(data);

            Assert.AreEqual("{\"x\":\"value\",\"name\":\"vmName1\"}"u8.ToArray(), model2.Patch.GetJson("$.foobar"u8).ToArray());
            Assert.AreEqual("vmName1", model2.Patch.GetString("$.foobar.name"u8));
            Assert.AreEqual("[]", model2.Patch.ToString());

            AssertCommon(model, model2);
        }

        private AvailabilitySetData GetInitialModel()
        {
            var model = ModelReaderWriter.Read<AvailabilitySetData>(BinaryData.FromString(JsonPayload));
            Assert.IsNotNull(model);
            return model!;
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

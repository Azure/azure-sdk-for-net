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
        public void NoSeedAndNoPatches()
        {
            AvailabilitySetData model = new("eastus");

            Assert.That(model.Patch.TryGetJson("$.extraSku"u8, out _), Is.False);
        }

        [Test]
        public void AddInt32Property()
        {
            var model = GetInitialModel();
            var pointer = "$.foobar"u8;
            model.Patch.Set(pointer, 5);

            Assert.That(model.Patch.GetInt32(pointer), Is.EqualTo(5));
            Assert.That(model.Patch.GetNullableValue<int>(pointer), Is.EqualTo(5));
            Assert.That(
                model.Patch.ToString(),
                Is.EqualTo("[{\"op\":\"add\",\"path\":\"/foobar\",\"value\":5}]"));

            var data = ModelReaderWriter.Write(model);
            Assert.That(
                data.ToString(),
                Is.EqualTo("{\"name\":\"testAS-3375\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375\",\"type\":\"Microsoft.Compute/availabilitySets\",\"sku\":{\"name\":\"Classic\"},\"tags\":{\"key\":\"value\"},\"location\":\"eastus\",\"properties\":{\"platformUpdateDomainCount\":5,\"platformFaultDomainCount\":3},\"extraSku\":\"extraSku\",\"extraRoot\":\"extraRoot\",\"foobar\":5}"));

            var model2 = GetRoundTripModel(data);
            Assert.That(model2.Patch.GetInt32(pointer), Is.EqualTo(5));
            Assert.That(model2.Patch.GetNullableValue<int>(pointer), Is.EqualTo(5));
            Assert.That(model2.Patch.ToString(), Is.EqualTo("[]"));

            AssertCommon(model, model2);
        }

        [Test]
        public void GetInt32FailsWhenNull()
        {
            var model = GetInitialModel();
            model.Patch.SetNull("$.foobar"u8);

            Assert.Throws<FormatException>(() => model.Patch.GetInt32("$.foobar"u8));
            var data = ModelReaderWriter.Write(model);
            Assert.That(
                data.ToString(),
                Is.EqualTo("{\"name\":\"testAS-3375\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375\",\"type\":\"Microsoft.Compute/availabilitySets\",\"sku\":{\"name\":\"Classic\"},\"tags\":{\"key\":\"value\"},\"location\":\"eastus\",\"properties\":{\"platformUpdateDomainCount\":5,\"platformFaultDomainCount\":3},\"extraSku\":\"extraSku\",\"extraRoot\":\"extraRoot\",\"foobar\":null}"));

            var model2 = GetRoundTripModel(data);
            Assert.That(model2.Patch.GetNullableValue<int>("$.foobar"u8), Is.EqualTo(null));
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

            Assert.That(model.Patch.GetString(pointer), Is.EqualTo(value));
            var data = ModelReaderWriter.Write(model);
            Assert.That(
                data.ToString(),
                Is.EqualTo("{\"name\":\"testAS-3375\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375\",\"type\":\"Microsoft.Compute/availabilitySets\",\"sku\":{\"name\":\"Classic\"},\"tags\":{\"key\":\"value\"},\"location\":\"eastus\",\"properties\":{\"platformUpdateDomainCount\":5,\"platformFaultDomainCount\":3},\"extraSku\":\"extraSku\",\"extraRoot\":\"extraRoot\",\"foobar\":\"some value\"}"));

            var model2 = GetRoundTripModel(data);
            Assert.That(model2.Patch.GetString(pointer), Is.EqualTo(value));

            AssertCommon(model, model2);
        }

        [Test]
        public void AddSameStringProperty()
        {
            var value = "some value";
            var pointer = "$.foobar"u8;

            var model = GetInitialModel();
            model.Patch.Set(pointer, value);
            Assert.That(
                model.Patch.ToString(),
                Is.EqualTo("[{\"op\":\"add\",\"path\":\"/foobar\",\"value\":\"some value\"}]"));

            model.Patch.Set("$['foobar']"u8, "some other value");

            Assert.That(model.Patch.GetString(pointer), Is.EqualTo("some other value"));
            Assert.That(model.Patch.GetString("$['foobar']"u8), Is.EqualTo("some other value"));
            Assert.That(
                model.Patch.ToString(),
                Is.EqualTo("[{\"op\":\"add\",\"path\":\"/foobar\",\"value\":\"some other value\"}]"));

            var data = ModelReaderWriter.Write(model);
            Assert.That(
                data.ToString(),
                Is.EqualTo("{\"name\":\"testAS-3375\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375\",\"type\":\"Microsoft.Compute/availabilitySets\",\"sku\":{\"name\":\"Classic\"},\"tags\":{\"key\":\"value\"},\"location\":\"eastus\",\"properties\":{\"platformUpdateDomainCount\":5,\"platformFaultDomainCount\":3},\"extraSku\":\"extraSku\",\"extraRoot\":\"extraRoot\",\"foobar\":\"some other value\"}"));

            var model2 = GetRoundTripModel(data);
            Assert.That(model2.Patch.GetString(pointer), Is.EqualTo("some other value"));
            Assert.That(model2.Patch.GetString("$['foobar']"u8), Is.EqualTo("some other value"));
            Assert.That(model2.Patch.ToString(), Is.EqualTo("[]"));

            AssertCommon(model, model2);
        }

        [Test]
        public void AddNullProperty()
        {
            var pointer = "$.foobar"u8;

            var model = GetInitialModel();
            model.Patch.SetNull(pointer);
            Assert.That(model.Patch.GetString(pointer), Is.EqualTo(null));
            Assert.That(model.Patch.GetNullableValue<int>(pointer), Is.EqualTo(null));
            Assert.That(
                model.Patch.ToString(),
                Is.EqualTo("[{\"op\":\"add\",\"path\":\"/foobar\",\"value\":null}]"));

            var data = ModelReaderWriter.Write(model);
            Assert.That(
                data.ToString(),
                Is.EqualTo("{\"name\":\"testAS-3375\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375\",\"type\":\"Microsoft.Compute/availabilitySets\",\"sku\":{\"name\":\"Classic\"},\"tags\":{\"key\":\"value\"},\"location\":\"eastus\",\"properties\":{\"platformUpdateDomainCount\":5,\"platformFaultDomainCount\":3},\"extraSku\":\"extraSku\",\"extraRoot\":\"extraRoot\",\"foobar\":null}"));

            var model2 = GetRoundTripModel(data);
            Assert.That(model2.Patch.GetString(pointer), Is.EqualTo(null));
            Assert.That(model2.Patch.GetNullableValue<int>(pointer), Is.EqualTo(null));
            Assert.That(model2.Patch.ToString(), Is.EqualTo("[]"));

            AssertCommon(model, model2);
        }

        [Test]
        public void ChangeFlattenedProperty()
        {
            ReadOnlySpan<byte> propertyNameSpan = "$.properties.platformUpdateDomainCount"u8;
            int expectedValue = 999;

            var model = GetInitialModel();

            model.Patch.Set(propertyNameSpan, expectedValue);

            Assert.That(model.Patch.GetInt32(propertyNameSpan), Is.EqualTo(expectedValue));
            Assert.That(model.Patch.GetNullableValue<int>(propertyNameSpan), Is.EqualTo(expectedValue));
            Assert.That(
                model.Patch.ToString(),
                Is.EqualTo("[{\"op\":\"replace\",\"path\":\"/properties/platformUpdateDomainCount\",\"value\":999}]"));

            var data = ModelReaderWriter.Write(model);
            Assert.That(
                data.ToString(),
                Is.EqualTo("{\"name\":\"testAS-3375\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375\",\"type\":\"Microsoft.Compute/availabilitySets\",\"sku\":{\"name\":\"Classic\"},\"tags\":{\"key\":\"value\"},\"location\":\"eastus\",\"properties\":{\"platformFaultDomainCount\":3,\"platformUpdateDomainCount\":999},\"extraSku\":\"extraSku\",\"extraRoot\":\"extraRoot\"}"));

            var model2 = GetRoundTripModel(data);

            Assert.That(model2.Patch.GetInt32(propertyNameSpan), Is.EqualTo(expectedValue));
            Assert.That(model2.PlatformUpdateDomainCount, Is.EqualTo(expectedValue));
            Assert.That(model2.Patch.ToString(), Is.EqualTo("[]"));

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

            Assert.That(model.Patch.GetString(propertyNameSpan), Is.EqualTo(expectedValue));
            Assert.That(model.Location, Is.EqualTo("eastus"));
            Assert.That(
                model.Patch.ToString(),
                Is.EqualTo("[{\"op\":\"replace\",\"path\":\"/location\",\"value\":\"new-location\"}]"));

            var data = ModelReaderWriter.Write(model);
            Assert.That(
                data.ToString(),
                Is.EqualTo("{\"name\":\"testAS-3375\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375\",\"type\":\"Microsoft.Compute/availabilitySets\",\"sku\":{\"name\":\"Classic\"},\"tags\":{\"key\":\"value\"},\"properties\":{\"platformUpdateDomainCount\":5,\"platformFaultDomainCount\":3},\"extraSku\":\"extraSku\",\"extraRoot\":\"extraRoot\",\"location\":\"new-location\"}"));

            var model2 = GetRoundTripModel(data);
            Assert.That(model2.Patch.GetString(propertyNameSpan), Is.EqualTo(expectedValue));
            Assert.That(model2.Location, Is.EqualTo(expectedValue));
            Assert.That(model2.Patch.ToString(), Is.EqualTo("[]"));

            AssertCommon(model, model2, propertyName);
        }

        [Test]
        public void ChangeExistingNestedProperty()
        {
            ReadOnlySpan<byte> propertyNameSpan = "$.sku.name"u8;
            string expectedValue = "new-sku-name";

            var model = GetInitialModel();

            Assert.That(model.Sku.Name, Is.EqualTo("Classic"));

            model.Patch.Set(propertyNameSpan, expectedValue);

            Assert.That(model.Patch.GetString(propertyNameSpan), Is.EqualTo(expectedValue));
            Assert.That(model.Sku.Patch.GetString("$.name"u8), Is.EqualTo(expectedValue));
            Assert.That(model.Patch.ToString(), Is.EqualTo("[]"));
            Assert.That(
                model.Sku.Patch.ToString(),
                Is.EqualTo("[{\"op\":\"replace\",\"path\":\"/name\",\"value\":\"new-sku-name\"}]"));

            var data = ModelReaderWriter.Write(model);
            Assert.That(
                data.ToString(),
                Is.EqualTo("{\"name\":\"testAS-3375\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375\",\"type\":\"Microsoft.Compute/availabilitySets\",\"sku\":{\"name\":\"new-sku-name\"},\"tags\":{\"key\":\"value\"},\"location\":\"eastus\",\"properties\":{\"platformUpdateDomainCount\":5,\"platformFaultDomainCount\":3},\"extraSku\":\"extraSku\",\"extraRoot\":\"extraRoot\"}"));

            var model2 = GetRoundTripModel(data);
            Assert.That(model2.Patch.GetString(propertyNameSpan), Is.EqualTo(expectedValue));
            Assert.That(model2.Sku.Patch.GetString("$.name"u8), Is.EqualTo(expectedValue));
            Assert.That(model2.Sku.Name, Is.EqualTo(expectedValue));
            Assert.That(model2.Patch.ToString(), Is.EqualTo("[]"));
            Assert.That(model2.Sku.Patch.ToString(), Is.EqualTo("[]"));

            AssertCommon(model, model2, "sku");
        }

        [Test]
        public void AddNewNestedProperty()
        {
            ReadOnlySpan<byte> propertyNameSpan = "$.sku.something"u8;
            string expectedValue = "something-value";

            var model = GetInitialModel();

            model.Patch.Set(propertyNameSpan, expectedValue);

            Assert.That(model.Patch.GetString(propertyNameSpan), Is.EqualTo(expectedValue));
            Assert.That(model.Sku.Patch.GetString("$.something"u8), Is.EqualTo(expectedValue));
            Assert.That(model.Patch.ToString(), Is.EqualTo("[]"));
            Assert.That(
                model.Sku.Patch.ToString(),
                Is.EqualTo("[{\"op\":\"add\",\"path\":\"/something\",\"value\":\"something-value\"}]"));

            var data = ModelReaderWriter.Write(model);
            Assert.That(
                data.ToString(),
                Is.EqualTo("{\"name\":\"testAS-3375\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375\",\"type\":\"Microsoft.Compute/availabilitySets\",\"sku\":{\"name\":\"Classic\",\"something\":\"something-value\"},\"tags\":{\"key\":\"value\"},\"location\":\"eastus\",\"properties\":{\"platformUpdateDomainCount\":5,\"platformFaultDomainCount\":3},\"extraSku\":\"extraSku\",\"extraRoot\":\"extraRoot\"}"));

            var model2 = GetRoundTripModel(data);

            Assert.That(model2.Patch.GetString(propertyNameSpan), Is.EqualTo(expectedValue));
            Assert.That(model2.Sku.Name, Is.EqualTo("Classic"));
            Assert.That(model2.Sku.Patch.GetString("$.something"u8), Is.EqualTo(expectedValue));
            Assert.That(model2.Patch.ToString(), Is.EqualTo("[]"));
            Assert.That(model2.Sku.Patch.ToString(), Is.EqualTo("[]"));

            AssertCommon(model, model2, "sku");
        }

        [Test]
        public void AddComplexPropertyAsJson()
        {
            ReadOnlySpan<byte> expectedValue = "{\"x\":{\"y\":123}}"u8;
            var pointer = "$.foobar"u8;
            var model = GetInitialModel();

            model.Patch.Set(pointer, expectedValue);

            Assert.That(model.Patch.GetJson(pointer).ToArray(), Is.EqualTo(expectedValue.ToArray()).AsCollection);
            Assert.That(model.Patch.GetJson("$.foobar.x"u8).ToArray(), Is.EqualTo("{\"y\":123}"u8.ToArray()));
            Assert.That(model.Patch.GetInt32("$.foobar.x.y"u8), Is.EqualTo(123));
            Assert.That(model.Patch.GetNullableValue<int>("$.foobar.x.y"u8), Is.EqualTo(123));
            Assert.That(
                model.Patch.ToString(),
                Is.EqualTo("[{\"op\":\"add\",\"path\":\"/foobar\",\"value\":{\"x\":{\"y\":123}}}]"));

            var data = ModelReaderWriter.Write(model);
            Assert.That(
                data.ToString(),
                Is.EqualTo("{\"name\":\"testAS-3375\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375\",\"type\":\"Microsoft.Compute/availabilitySets\",\"sku\":{\"name\":\"Classic\"},\"tags\":{\"key\":\"value\"},\"location\":\"eastus\",\"properties\":{\"platformUpdateDomainCount\":5,\"platformFaultDomainCount\":3},\"extraSku\":\"extraSku\",\"extraRoot\":\"extraRoot\",\"foobar\":{\"x\":{\"y\":123}}}"));

            var model2 = GetRoundTripModel(data);

            Assert.That(model2.Patch.GetJson(pointer).ToArray(), Is.EqualTo(expectedValue.ToArray()).AsCollection);
            Assert.That(model2.Patch.GetJson("$.foobar.x"u8).ToArray(), Is.EqualTo("{\"y\":123}"u8.ToArray()));
            Assert.That(model2.Patch.GetInt32("$.foobar.x.y"u8), Is.EqualTo(123));
            Assert.That(model2.Patch.GetNullableValue<int>("$.foobar.x.y"u8), Is.EqualTo(123));
            Assert.That(model2.Patch.ToString(), Is.EqualTo("[]"));

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

            Assert.That(model.Patch.GetJson(pointer).ToArray(), Is.EqualTo(expectedValue.ToArray()).AsCollection);
            Assert.That(
                model.Patch.ToString(),
                Is.EqualTo("[{\"op\":\"add\",\"path\":\"/foobar\",\"value\":{\"x\":{\"y\":123}}}]"));

            var data = ModelReaderWriter.Write(model);
            Assert.That(
                data.ToString(),
                Is.EqualTo("{\"name\":\"testAS-3375\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375\",\"type\":\"Microsoft.Compute/availabilitySets\",\"sku\":{\"name\":\"Classic\"},\"tags\":{\"key\":\"value\"},\"location\":\"eastus\",\"properties\":{\"platformUpdateDomainCount\":5,\"platformFaultDomainCount\":3},\"extraSku\":\"extraSku\",\"extraRoot\":\"extraRoot\",\"foobar\":{\"x\":{\"y\":123}}}"));

            var model2 = GetRoundTripModel(data);
            Assert.That(model2.Patch.GetJson(pointer).ToArray(), Is.EqualTo(expectedValue.ToArray()).AsCollection);
            Assert.That(model2.Patch.ToString(), Is.EqualTo("[]"));

            AssertCommon(model, model2);
        }

        [Test]
        public void ReplaceExistingComplex()
        {
            ReadOnlySpan<byte> expectedValue = "{\"name\":\"replaced-name\",\"foo\":123}"u8;
            var pointer = "$.sku"u8;
            var model = GetInitialModel();

            model.Patch.Set(pointer, expectedValue);

            Assert.That(model.Patch.GetJson(pointer).ToArray(), Is.EqualTo(expectedValue.ToArray()).AsCollection);
            Assert.That(model.Patch.ToString(), Is.EqualTo("[]"));
            Assert.That(
                model.Sku.Patch.ToString(),
                Is.EqualTo("[{\"op\":\"replace\",\"path\":\"/\",\"value\":{\"name\":\"replaced-name\",\"foo\":123}}]"));

            var data = ModelReaderWriter.Write(model);
            Assert.That(
                data.ToString(),
                Is.EqualTo("{\"name\":\"testAS-3375\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375\",\"type\":\"Microsoft.Compute/availabilitySets\",\"sku\":{\"name\":\"replaced-name\",\"foo\":123},\"tags\":{\"key\":\"value\"},\"location\":\"eastus\",\"properties\":{\"platformUpdateDomainCount\":5,\"platformFaultDomainCount\":3},\"extraSku\":\"extraSku\",\"extraRoot\":\"extraRoot\"}"));

            var model2 = GetRoundTripModel(data);
            Assert.That(model2.Sku.Name, Is.EqualTo("replaced-name"));
            Assert.That(model2.Sku.Patch.GetInt32("$.foo"u8), Is.EqualTo(123));
            Assert.That(model2.Patch.ToString(), Is.EqualTo("[]"));
            Assert.That(model2.Sku.Patch.ToString(), Is.EqualTo("[]"));

            model2.Patch.Set("$.sku.foo"u8, 999);
            Assert.That(model2.Sku.Patch.ToString(), Is.EqualTo("[{\"op\":\"replace\",\"path\":\"/foo\",\"value\":999}]"));

            AssertCommon(model, model2, "sku");
        }

        [Test]
        public void SetClrAfterJsonProperty()
        {
            var model = GetInitialModel();
            var pointer = "$.location"u8;

            model.Patch.Set(pointer, "new-location");

            Assert.That(model.Patch.GetString(pointer), Is.EqualTo("new-location"));
            Assert.That(
                model.Patch.ToString(),
                Is.EqualTo("[{\"op\":\"replace\",\"path\":\"/location\",\"value\":\"new-location\"}]"));

            //setting the location property directly does not override the patch
            //if we want this we need to tie property setters to the patch which is very tricky
            model.Location = "another-location";
            Assert.That(model.Patch.GetString(pointer), Is.EqualTo("new-location"));

            var data = ModelReaderWriter.Write(model);
            Assert.That(
                data.ToString(),
                Is.EqualTo("{\"name\":\"testAS-3375\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375\",\"type\":\"Microsoft.Compute/availabilitySets\",\"sku\":{\"name\":\"Classic\"},\"tags\":{\"key\":\"value\"},\"properties\":{\"platformUpdateDomainCount\":5,\"platformFaultDomainCount\":3},\"extraSku\":\"extraSku\",\"extraRoot\":\"extraRoot\",\"location\":\"new-location\"}"));

            var model2 = GetRoundTripModel(data);

            Assert.That(model2.Location, Is.EqualTo("new-location"));
            Assert.That(model2.Patch.ToString(), Is.EqualTo("[]"));
        }

        [Test]
        public void AddNewObjectThenANewPropertyToThatObject()
        {
            var model = GetInitialModel();

            model.Patch.Set("$.foobar"u8, "{\"x\":\"value\"}"u8);

            Assert.That(model.Patch.GetJson("$.foobar"u8).ToArray(), Is.EqualTo("{\"x\":\"value\"}"u8.ToArray()));
            Assert.That(
                model.Patch.ToString(),
                Is.EqualTo("[{\"op\":\"add\",\"path\":\"/foobar\",\"value\":{\"x\":\"value\"}}]"));

            model.Patch.Set("$.foobar.name"u8, "vmName1");

            Assert.That(model.Patch.GetString("$.foobar.name"u8), Is.EqualTo("vmName1"));
            Assert.That(
                model.Patch.ToString(),
                Is.EqualTo("[{\"op\":\"add\",\"path\":\"/foobar\",\"value\":{\"x\":\"value\",\"name\":\"vmName1\"}}]"));

            var data = ModelReaderWriter.Write(model);
            Assert.That(
                data.ToString(),
                Is.EqualTo("{\"name\":\"testAS-3375\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375\",\"type\":\"Microsoft.Compute/availabilitySets\",\"sku\":{\"name\":\"Classic\"},\"tags\":{\"key\":\"value\"},\"location\":\"eastus\",\"properties\":{\"platformUpdateDomainCount\":5,\"platformFaultDomainCount\":3},\"extraSku\":\"extraSku\",\"extraRoot\":\"extraRoot\",\"foobar\":{\"x\":\"value\",\"name\":\"vmName1\"}}"));

            var model2 = GetRoundTripModel(data);

            Assert.That(model2.Patch.GetJson("$.foobar"u8).ToArray(), Is.EqualTo("{\"x\":\"value\",\"name\":\"vmName1\"}"u8.ToArray()));
            Assert.That(model2.Patch.GetString("$.foobar.name"u8), Is.EqualTo("vmName1"));
            Assert.That(model2.Patch.ToString(), Is.EqualTo("[]"));

            AssertCommon(model, model2);
        }

        private AvailabilitySetData GetInitialModel()
        {
            var model = ModelReaderWriter.Read<AvailabilitySetData>(BinaryData.FromString(JsonPayload));
            Assert.That(model, Is.Not.Null);
            return model!;
        }

        private static AvailabilitySetData GetRoundTripModel(BinaryData data)
        {
            var model2 = ModelReaderWriter.Read<AvailabilitySetData>(data);
            Assert.That(model2, Is.Not.Null);
            return model2!;
        }

        private static void AssertCommon(AvailabilitySetData model, AvailabilitySetData model2, params string[] skips)
        {
            Assert.That(model2.Patch.GetString("$.extraSku"u8), Is.EqualTo("extraSku"));
            Assert.That(model2.Patch.GetString("$.extraRoot"u8), Is.EqualTo("extraRoot"));
            CompareAvailabilitySetData(model, model2, "J", skips);
        }
    }
}

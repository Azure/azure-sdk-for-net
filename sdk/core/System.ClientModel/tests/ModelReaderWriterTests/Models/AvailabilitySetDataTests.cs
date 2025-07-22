// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.Client;
using System.ClientModel.Tests.Client.Models.ResourceManager.Compute;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
#if SOURCE_GENERATOR
using System.ClientModel.SourceGeneration.Tests;
#endif

namespace System.ClientModel.Tests.ModelReaderWriterTests.Models
{
    internal class AvailabilitySetDataTests : ModelJsonTests<AvailabilitySetData>
    {
        protected override string WirePayload => File.ReadAllText(TestData.GetLocation("AvailabilitySetData/AvailabilitySetDataWireFormat.json")).TrimEnd();

        protected override string JsonPayload => WirePayload;

#if SOURCE_GENERATOR
        protected override ModelReaderWriterContext Context => BasicContext.Default;
#else
        protected override ModelReaderWriterContext Context => new TestClientModelReaderWriterContext();
#endif

        protected override string GetExpectedResult(string format)
        {
            var expectedSerializedString = "{";
            if (format == "J")
                expectedSerializedString += "\"name\":\"testAS-3375\",\"id\":\"/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375\",\"type\":\"Microsoft.Compute/availabilitySets\",";
            expectedSerializedString += "\"sku\":{\"name\":\"Classic\"";
            expectedSerializedString += "},\"tags\":{\"key\":\"value\"},\"location\":\"eastus\",\"properties\":{\"platformUpdateDomainCount\":5,\"platformFaultDomainCount\":3}";
            if (format == "J")
                expectedSerializedString += ",\"extraSku\":\"extraSku\",\"extraRoot\":\"extraRoot\"";
            expectedSerializedString += "}";
            return expectedSerializedString; ;
        }

        protected override void VerifyModel(AvailabilitySetData model, string format)
        {
            Dictionary<string, string> expectedTags = new Dictionary<string, string>() { { "key", "value" } };

            Assert.AreEqual("/subscriptions/e37510d7-33b6-4676-886f-ee75bcc01871/resourceGroups/testRG-6497/providers/Microsoft.Compute/availabilitySets/testAS-3375", model.Id!.ToString());
            CollectionAssert.AreEquivalent(expectedTags, model.Tags);
            Assert.AreEqual("eastus", model.Location);
            Assert.AreEqual("testAS-3375", model.Name);
            Assert.AreEqual("Microsoft.Compute/availabilitySets", model.ResourceType!.ToString());
            Assert.AreEqual(5, model.PlatformUpdateDomainCount);
            Assert.AreEqual(3, model.PlatformFaultDomainCount);
            Assert.AreEqual("Classic", model.Sku.Name);
        }

        protected override void CompareModels(AvailabilitySetData model, AvailabilitySetData model2, string format)
            => CompareAvailabilitySetData(model, model2, format);

        internal static void CompareAvailabilitySetData(AvailabilitySetData model, AvailabilitySetData model2, string format)
        {
            if (model is null)
            {
                Assert.IsNull(model2);
                return;
            }

            Assert.AreEqual(format == "W" ? null : model.Id, model2.Id);
            Assert.AreEqual(model.Location, model2.Location);
            Assert.AreEqual(format == "W" ? null : model.Name, model2.Name);
            Assert.AreEqual(model.PlatformFaultDomainCount, model2.PlatformFaultDomainCount);
            Assert.AreEqual(model.PlatformUpdateDomainCount, model2.PlatformUpdateDomainCount);
            if (format == "J")
                Assert.AreEqual(model.ResourceType, model2.ResourceType);
            CollectionAssert.AreEquivalent(model.Tags, model2.Tags);
            Assert.AreEqual(model.Sku.Name, model2.Sku.Name);
        }

        [Test]
        public void RoundTripWithAdditionalProperty_Int()
        {
            var model = GetInitialModel();
            model.Json.Set("foobar"u8, 5);
            Assert.AreEqual(5, model.Json.GetInt32("foobar"u8));
            Assert.AreEqual(5, model.Json.GetNullableInt32("foobar"u8));

            var data = WriteModifiedModel(model, "5");

            var model2 = GetRoundTripModel(data);
            Assert.AreEqual(5, model2.Json.GetInt32("foobar"u8));
            Assert.AreEqual(5, model2.Json.GetNullableInt32("foobar"u8));

            AssertCommon(model, model2);

            AssertFromRawData(model2, 5);
        }

        [Test]
        public void GetInt32FailsWhenNull()
        {
            var model = GetInitialModel();
            model.Json.SetNull("foobar"u8);

            AssertJsonException(() => model.Json.GetInt32("foobar"u8));
            var data = WriteModifiedModel(model, "null");

            var model2 = GetRoundTripModel(data);
            AssertJsonException(() => model2.Json.GetInt32("foobar"u8));

            AssertCommon(model, model2);

            AssertFromRawData<int?>(model2, null);
        }

        [Test]
        public void RoundTripWithAdditionalProperty_String()
        {
            var value = "some value";
            var model = GetInitialModel();
            model.Json.Set("foobar"u8, value);

            Assert.AreEqual(value, model.Json.GetString("foobar"u8));
            var data = WriteModifiedModel(model, "\"some value\"");

            var model2 = GetRoundTripModel(data);
            Assert.AreEqual(value, model2.Json.GetString("foobar"u8));

            AssertCommon(model, model2);

            AssertFromRawData(model2, value);
        }

        [Test]
        public void RoundTripWithAdditionalProperty_Null()
        {
            var model = GetInitialModel();
            model.Json.SetNull("foobar"u8);
            Assert.AreEqual(null, model.Json.GetString("foobar"u8));
            Assert.AreEqual(null, model.Json.GetNullableInt32("foobar"u8));

            var data = WriteModifiedModel(model, "null");

            var model2 = GetRoundTripModel(data);
            Assert.AreEqual(null, model2.Json.GetString("foobar"u8));
            Assert.AreEqual(null, model2.Json.GetNullableInt32("foobar"u8));

            AssertCommon(model, model2);

            AssertFromRawData<string?>(model2, null);
        }

        private AvailabilitySetData GetInitialModel()
        {
            var model = ModelReaderWriter.Read<AvailabilitySetData>(BinaryData.FromString(JsonPayload));
            Assert.IsNotNull(model);
            return model!;
        }

        private static void AssertJsonException(Action lambda)
        {
            bool exceptionThrown = false;
            try
            {
                lambda();
            }
            catch (Exception ex)
            {
                exceptionThrown = true;
                Assert.AreEqual("JsonException", ex.GetType().Name);
                Assert.IsTrue(ex.Message.StartsWith("The JSON value could not be converted to"));
            }
            finally
            {
                Assert.IsTrue(exceptionThrown, "Expected GetInt32 to throw when the value is null");
            }
        }

        private static BinaryData WriteModifiedModel(AvailabilitySetData model, string expectedJsonValue)
        {
            var data = ModelReaderWriter.Write(model);
            var json = data.ToString();
            Assert.IsTrue(json.Contains($"\"foobar\":{expectedJsonValue}"), $"Did not find \"foobar\":{expectedJsonValue}, json was:\n{json}");
            return data;
        }

        private static AvailabilitySetData GetRoundTripModel(BinaryData data)
        {
            var model2 = ModelReaderWriter.Read<AvailabilitySetData>(data);
            Assert.IsNotNull(model2);
            return model2!;
        }

        private static void AssertCommon(AvailabilitySetData model, AvailabilitySetData model2)
        {
            Assert.AreEqual("extraSku", model2.Json.GetString("extraSku"u8));
            Assert.AreEqual("extraRoot", model2.Json.GetString("extraRoot"u8));
            CompareAvailabilitySetData(model, model2, "J");
        }
        private static void AssertFromRawData<T>(AvailabilitySetData model, T value)
        {
            var rawData = GetRawData(model);
            //will contain 2 from the TestData and 1 from the additional property we injected
            Assert.AreEqual(3, rawData.Count);
            Assert.IsTrue(rawData.ContainsKey("foobar"));
            Assert.AreEqual(value, rawData["foobar"].ToObjectFromJson<T>());
        }
    }
}

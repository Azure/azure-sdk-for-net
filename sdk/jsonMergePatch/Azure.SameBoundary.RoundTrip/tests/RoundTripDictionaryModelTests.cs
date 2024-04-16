// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using NUnit.Framework;

namespace Azure.SameBoundary.RoundTrip.Tests
{
    public class RoundTripDictionaryModelTests
    {
        [Test]
        public void Case1_ReceivedDataShouldBeRegardedAsNotChanged()
        {
            var model = TestHelper.ReadModelFromFile<RoundTripDictionaryModel>("RoundTripDictionary_AllPropertiesReceived.json");
            string actual = TestHelper.ReadJsonFromModel(model);
            string expected = TestHelper.ReadJsonFromFile("Empty.json");
            Assert.IsTrue(TestHelper.AreEqualJson(expected, actual));
        }

        [Test]
        public void Case2_ChangeDictionaryPropertyShouldBeSerialized()
        {
            var model = TestHelper.ReadModelFromFile<RoundTripDictionaryModel>("RoundTripDictionary_AllPropertiesReceived.json");
            model.RequiredStringDictionary.Add("key3", "value3");
            model.OptionalStringDictionary["key1"] = null;
            model.RequiredIntDictionary["key1"] = 5;
            model.OptionalIntDictionary.Remove("key1");
            model.RequiredModelDictionary["key1"] = new RoundTripDummy();
            model.OptionalModelDictionary.Add("key3", new RoundTripDummy());
            model.RequiredDictionaryDictionary["key1"] = new Dictionary<string, RoundTripDummy> { { "newKey", new RoundTripDummy() { Property = "p"} } };
            model.OptionalDictionaryDictionary.Remove("key1");
            model.RequiredArrayDictionary["key1"] = new List<RoundTripDummy> { new RoundTripDummy() { Property = "p" } };
            model.OptionalArrayDictionary.Add("key3", new List<RoundTripDummy> { new RoundTripDummy() { Property = "p" } });
            string actual = TestHelper.ReadJsonFromModel(model);
            string expected = TestHelper.ReadJsonFromFile("RoundTripDictionary_Case2_ChangeInDictionaryShouldBeSerialized.json");
            Assert.IsTrue(TestHelper.AreEqualJson(expected, actual));
        }

        [Test]
        public void Case3_ChangeDictionaryItemShouldBeSerialized()
        {
            var model = TestHelper.ReadModelFromFile<RoundTripDictionaryModel>("RoundTripDictionary_AllPropertiesReceived.json");
            model.RequiredModelDictionary["key1"].Property = "newProperty";
            model.OptionalModelDictionary["key1"].Property = null;
            model.RequiredDictionaryDictionary["key1"]["newKey"] = new RoundTripDummy() { Property = "newProperty" };
            model.OptionalDictionaryDictionary["key1"].Remove("a");
            model.RequiredArrayDictionary["key1"].Add(new RoundTripDummy() { Property = "newProperty" });
            model.OptionalArrayDictionary["key1"][0] = new RoundTripDummy() { Property = "newProperty" };
            string actual = TestHelper.ReadJsonFromModel(model);
            string expected = TestHelper.ReadJsonFromFile("RoundTripDictionary_Case3_ChangeInDictionaryItemShouldBeSerialized.json");
            Assert.IsTrue(TestHelper.AreEqualJson(expected, actual));
        }

        [Test]
        public void Case4_ChangeDictionaryInnerItemShouldBeSerialized()
        {
            var model = TestHelper.ReadModelFromFile<RoundTripDictionaryModel>("RoundTripDictionary_AllPropertiesReceived.json");
            model.RequiredDictionaryDictionary["key1"]["a"].Property = "newProperty";
            model.OptionalDictionaryDictionary["key1"]["a"].Property = null;
            model.RequiredArrayDictionary["key1"][0].Property = "newProperty";
            model.OptionalArrayDictionary["key1"][0].Property = null;
            string actual = TestHelper.ReadJsonFromModel(model);
            string expected = TestHelper.ReadJsonFromFile("RoundTripDictionary_Case4_ChangeInDictionaryInnerItemShouldBeSerialized.json");
            Assert.IsTrue(TestHelper.AreEqualJson(expected, actual));
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using NUnit.Framework;

namespace Azure.SameBoundary.RoundTrip.Tests
{
    public class RoundTripArrayModelTests
    {
        [Test]
        public void Case1_ReceivedDataShouldBeRegardedAsNotChanged()
        {
            var model = TestHelper.ReadModelFromFile<RoundTripArrayModel>("RoundTripArray_AllPropertiesReceived.json");
            string actual = TestHelper.ReadJsonFromModel<RoundTripArrayModel>(model);
            string expected = TestHelper.ReadJsonFromFile("Empty.json");
            Assert.IsTrue(TestHelper.AreEqualJson(expected, actual));
        }

        [Test]
        public void Case2_ChangeOnArrayPropertyShouldBeSerialized()
        {
            var model = TestHelper.ReadModelFromFile<RoundTripArrayModel>("RoundTripArray_AllPropertiesReceived.json");
            model.RequiredStringArray.RemoveAt(1);
            model.OptionalStringArray[0] = "a";
            model.RequiredIntArray.Remove(4);
            model.OptionalIntArray.Add(1);
            model.RequiredModelArray.RemoveAt(1);
            model.OptionalModelArray.Add(new RoundTripDummy());
            model.RequiredArrayArray[0] = new List<RoundTripDummy>();
            model.OptionalArrayArray[0] = null;
            model.RequiredDictionaryArray.RemoveAt(1);
            model.OptionalDictionaryArray[0] = new Dictionary<string, RoundTripDummy>();
            string actual = TestHelper.ReadJsonFromModel<RoundTripArrayModel>(model);
            string expected = TestHelper.ReadJsonFromFile("RoundTripArray_Case2_ChangeOnArrayPropertyShouldBeSerialized.json");
            Assert.IsTrue(TestHelper.AreEqualJson(expected, actual));
        }

        [Test]
        public void Case3_ChangeOnArrayItemShouldBeSerialized()
        {
            var model = TestHelper.ReadModelFromFile<RoundTripArrayModel>("RoundTripArray_AllPropertiesReceived.json");
            model.RequiredModelArray[0].Property = "a";
            model.RequiredArrayArray[0].Add(new RoundTripDummy());
            model.OptionalArrayArray[0].RemoveAt(0);
            model.RequiredDictionaryArray[0]["a"] = new RoundTripDummy();
            model.OptionalDictionaryArray[0].Add("a", new RoundTripDummy());
            string actual = TestHelper.ReadJsonFromModel<RoundTripArrayModel>(model);
            string expected = TestHelper.ReadJsonFromFile("RoundTripArray_Case3_ChangeOnArrayItemShouldBeSerialized.json");
            Assert.IsTrue(TestHelper.AreEqualJson(expected, actual));
        }

        [Test]
        public void Case4_ChangeOnArrayInnerItemShouldBeSerialized()
        {
            var model = TestHelper.ReadModelFromFile<RoundTripArrayModel>("RoundTripArray_AllPropertiesReceived.json");
            model.RequiredArrayArray[0][0].Property = "x_changed";
            model.OptionalArrayArray[0][0].Property = null;
            model.RequiredDictionaryArray[0]["key1"].Property = "value1_changed";
            model.OptionalDictionaryArray[0]["key1"].Property = null;
            string actual = TestHelper.ReadJsonFromModel<RoundTripArrayModel>(model);
            string expected = TestHelper.ReadJsonFromFile("RoundTripArray_Case4_ChangeOnArrayInnerItemShouldBeSerialized.json");
            Assert.IsTrue(TestHelper.AreEqualJson(expected, actual));
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;

namespace Azure.SameBoundary.RoundTrip.Tests
{
    public class RoundTripNestedModelTests
    {
        [Test]
        public void Case1_ReceivedDataShouldBeRegardedAsNotChanged()
        {
            var model = TestHelper.ReadModelFromFile<RoundTripNestedModel>("RoundTripNested_AllPropertiesReceived.json");
            string actual = TestHelper.ReadJsonFromModel<RoundTripNestedModel>(model);
            string expected = TestHelper.ReadJsonFromFile("Empty.json");
            Assert.IsTrue(TestHelper.AreEqualJson(expected, actual));
        }

        [Test]
        public void Case2_ChangeInNestedModelShouldBeSerialized()
        {
            var model = TestHelper.ReadModelFromFile<RoundTripNestedModel>("RoundTripNested_AllPropertiesReceived.json");
            model.RequiredModel.Property = "b";
            model.OptionalModel.Property = null;
            string actual = TestHelper.ReadJsonFromModel<RoundTripNestedModel>(model);
            string expected = TestHelper.ReadJsonFromFile("RoundTripNested_Case2_ChangeInNestedModelShouldBeSerialized.json");
            Assert.IsTrue(TestHelper.AreEqualJson(expected, actual));
        }

        [Test]
        public void Case3_ChangeModelPropertyShouldBeSerialized()
        {
            var model = TestHelper.ReadModelFromFile<RoundTripNestedModel>("RoundTripNested_AllPropertiesReceived.json");
            model.OptionalModel = new RoundTripDummy() { Property = "a" };
            string actual = TestHelper.ReadJsonFromModel<RoundTripNestedModel>(model);
            string expected = TestHelper.ReadJsonFromFile("RoundTripNested_Case3_ChangeModelPropertyShouldBeSerialized.json");
            Assert.IsTrue(TestHelper.AreEqualJson(expected, actual));
        }
    }
}

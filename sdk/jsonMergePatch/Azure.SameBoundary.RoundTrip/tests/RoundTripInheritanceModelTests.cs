// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;

namespace Azure.SameBoundary.RoundTrip.Tests
{
    public class RoundTripInheritanceModelTests
    {
        [Test]
        public void Case1_ReceivedDataShouldBeRegardedAsNotChanged()
        {
            var model = TestHelper.ReadModelFromFile<RoundTripInheritanceModel>("RoundTripInheritance_AllPropertiesReceived.json");
            string actual = TestHelper.ReadJsonFromModel<RoundTripInheritanceModel>(model);
            string expected = TestHelper.ReadJsonFromFile("Empty.json");
            Assert.IsTrue(TestHelper.AreEqualJson(expected, actual));
        }

        [Test]
        public void Case2_ChangeInInBaseModelShouldBeSerialized()
        {
            var model = TestHelper.ReadModelFromFile<RoundTripInheritanceModel>("RoundTripInheritance_AllPropertiesReceived.json");
            model.BaseProperty1 = null;
            model.BaseProperty2 = 3;
            model.BaseProperty3["a"] = "b";
            string actual = TestHelper.ReadJsonFromModel<RoundTripInheritanceModel>(model);
            string expected = TestHelper.ReadJsonFromFile("RoundTripInheritance_Case2_ChangeInInBaseModelShouldBeSerialized.json");
            Assert.IsTrue(TestHelper.AreEqualJson(expected, actual));
        }

        [Test]
        public void Case3_ChangeInMultipleLevelsAreSerializedCorrectly()
        {
            var model = TestHelper.ReadModelFromFile<RoundTripAddAnotherLevelToInheritanceModel>("RoundTripInheritance_AllPropertiesReceived.json");
            model.BaseProperty1 = null;
            model.BaseProperty2 = 3;
            model.BaseProperty3["a"] = "b";
            model.ExtendedProperty = null;
            string actual = TestHelper.ReadJsonFromModel<RoundTripAddAnotherLevelToInheritanceModel>(model);
            string expected = TestHelper.ReadJsonFromFile("RoundTripInheritance_Case3_ChangeInMultipleLevelsAreSerializedCorrectly.json");
            Assert.IsTrue(TestHelper.AreEqualJson(expected, actual));
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;

namespace Azure.SameBoundary.RoundTrip.Tests
{
    public class RoundTripPrimitiveModelTests
    {
        [Test]
        public void Case1_ReceivedDataShouldBeRegardedAsNotChanged()
        {
            var model = TestHelper.ReadModelFromFile<RoundTripPrimitiveModel>("RoundTripPrimitive_AllPropertiesReceived.json");
            string actual = TestHelper.ReadJsonFromModel(model);
            string expected = TestHelper.ReadJsonFromFile("RoundTripPrimitive_Case1_ReceivedDataShouldBeRegardedAsNotChanged.json");
            Assert.IsTrue(TestHelper.AreEqualJson(expected, actual));
        }

        [Test]
        public void Case2_ExplicitSetPropertyShouldBeSerializedOtherwiseNot()
        {
            var model = TestHelper.ReadModelFromFile<RoundTripPrimitiveModel>("RoundTripPrimitive_AllPropertiesReceived.json");
            model.RequiredString = "changed";
            model.OptionalInt = null;
            string actual = TestHelper.ReadJsonFromModel(model);
            string expected = TestHelper.ReadJsonFromFile("RoundTripPrimitive_Case2_ExplicitSetPropertyShouldBeSerializedOtherwiseNot.json");
            Assert.IsTrue(TestHelper.AreEqualJson(expected, actual));
        }
    }
}

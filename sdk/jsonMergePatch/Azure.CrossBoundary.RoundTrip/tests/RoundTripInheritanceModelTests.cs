// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;

namespace Azure.CrossBoundary.RoundTrip.Tests
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
    }
}

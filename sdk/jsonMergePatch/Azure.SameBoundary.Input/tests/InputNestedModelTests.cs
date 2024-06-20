// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;

namespace Azure.SameBoundary.Input.Tests
{
    public class InputNestedModelTests
    {
        [Test]
        public void PropertiesInNestedModelShouldBeSerialized()
        {
            InputNestedModel model = new InputNestedModel(new InputDummy() { Property = "a"});
            model.OptionalModel = new InputDummy() { Property = "b" };
            string actual = TestHelper.ReadJsonFromModel(model);
            string expected = TestHelper.ReadJsonFromFile("InputNested_PropertiesInNestedModelShouldBeSerialized.json");
            Assert.IsTrue(TestHelper.AreEqualJson(expected, actual));
        }
    }
}

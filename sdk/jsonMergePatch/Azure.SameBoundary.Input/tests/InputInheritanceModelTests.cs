// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using NUnit.Framework;

namespace Azure.SameBoundary.Input.Tests
{
    public class InputInheritanceModelTests
    {
        [Test]
        public void Case1_PropertiesInBaseModelShouldBeSerialized()
        {
            InputInheritanceModel model = new InputInheritanceModel(2);
            model.BaseProperty1 = "stringProperty";
            model.BaseProperty3.Add("a", "a");
            model.BaseProperty3["b"] = null;
            string actual = TestHelper.ReadJsonFromModel((IJsonModel<InputInheritanceModel>)model);

            /* Expected
            {
                "baseProperty1": "stringProperty",
                "baseProperty3":
                {
                    "a": "a",
                    "b": null
                }
            }
            */
            string expected = TestHelper.ReadJsonFromFile("InputInheritance_Case1_PropertiesInBaseModelShouldBeSerialized.json");
            TestHelper.AreEqualJson(expected, actual);
        }

        [Test]
        public void Case2_MultipleLevelsAreSerializedCorrectly()
        {
            InputAddAnotherLevelToInheritanceModel model = new InputAddAnotherLevelToInheritanceModel(2);
            model.BaseProperty1 = "stringProperty";
            model.ExtendedProperty = "extendedProperty";
            model.AnotherLevelProperty = "anotherLevelProperty";
            string actual = TestHelper.ReadJsonFromModel((IJsonModel<InputAddAnotherLevelToInheritanceModel>)model);

            /* Expected
             {
                "baseProperty1": "stringProperty",
                "extendedProperty": "extendedProperty",
                "anotherLevelProperty": "anotherLevelProperty"
            }
             */
            string expected = TestHelper.ReadJsonFromFile("InputInheritance_Case2_MultipleLevelsAreSerializedCorrectly.json");
            TestHelper.AreEqualJson(expected, actual);
        }
    }
}

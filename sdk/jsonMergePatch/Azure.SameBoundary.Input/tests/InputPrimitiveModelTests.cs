// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Azure.SameBoundary.Input.Tests
{
    public class InputPrimitiveModelTests
    {
        [Test]
        public void Case1_RequiredPropertyShouldBeRegardedAsChanged()
        {
            InputPrimitiveModel model = new InputPrimitiveModel("required", 5);
            string actual = TestHelper.ReadJsonFromModel(model);

            // Expected:
            //{
            //    "requiredString": "required",
            //    "requiredInt":  5
            //}
            var expected = TestHelper.ReadJsonFromFile("InputPrimitive_Case1_RequiredPropertyShouldBeRegardedAsChanged.json");
            Assert.IsTrue(TestHelper.AreEqualJson(expected, actual));
        }

        [Test]
        public void Case2_IWantToChangeOnlyOneRequiredProperty()
        {
            // This test is an oen question for the scenario when user only wants to change the `requiredString`.
            // The payload they expect might be {"requiredString": "required"}
            // But we don't have a parameterless pulic constructor.
            // Do we need to add a new API for this scenario?
        }

        [Test]
        public void Case3_ExplicitSetPropertyShouldBeSerializedOtherwiseNot()
        {
            InputPrimitiveModel model = new InputPrimitiveModel("required", 5);
            model.OptionalInt = 6;
            string actual = TestHelper.ReadJsonFromModel(model);

            // Expected:
            //{
            //    "requiredString": "required",
            //    "requiredInt": 5,
            //    "optionalInt": 6
            //}
            var expected = TestHelper.ReadJsonFromFile("InputPrimitive_Case3_ExplicitSetPropertyShouldBeSerializedOtherwiseNot.json");
            Assert.IsTrue(TestHelper.AreEqualJson(expected, actual));
        }

        [Test]
        public void Case4_ExplicitSetNullShouldBeSerialized()
        {
            InputPrimitiveModel model = new InputPrimitiveModel("required", 5);
            model.OptionalInt = null;
            model.OptionalString = null;
            string actual = TestHelper.ReadJsonFromModel(model);

            // Expected:
            //{
            //    "requiredString": "required",
            //    "requiredInt": 5,
            //    "optionalInt": null,
            //    "optionalString":  null
            //}
            var expected = TestHelper.ReadJsonFromFile("InputPrimitive_Case4_ExplicitSetNullShouldBeSerialized.json");
            Assert.IsTrue(TestHelper.AreEqualJson(expected, actual));
        }
    }
}

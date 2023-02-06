// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using NUnit.Framework;

namespace Azure.Core.Tests.Public
{
    public class JsonDataLeafTests
    {
        #region Convert tests

        [Test]
        public void CanConvertIntLeafToInt()
        {
            dynamic data = JsonDataTestHelpers.CreateFromJson("5");
            Assert.AreEqual(5, (int)data);
        }

        [Test]
        public void CanConvertIntLeafPropertyToInt()
        {
            dynamic data = JsonDataTestHelpers.CreateFromJson(@"{ ""value"": 5 }");
            Assert.AreEqual(5, (int)data.value);
        }

        [Test]
        public void CanConvertIntLeafToDouble()
        {
            dynamic data = JsonDataTestHelpers.CreateFromJson("5");
            Assert.AreEqual(5d, (double)data);
        }

        [Test]
        public void CanConvertIntLeafPropertyToDouble()
        {
            dynamic data = JsonDataTestHelpers.CreateFromJson(@"{ ""value"": 5 }");
            Assert.AreEqual(5d, (double)data.value);
        }

        [Test]
        public void CanConvertIntLeafToLong()
        {
            dynamic data = JsonDataTestHelpers.CreateFromJson("5");
            Assert.AreEqual((long)5, (long)data);
        }

        [Test]
        public void CanConvertIntLeafPropertyToLong()
        {
            dynamic data = JsonDataTestHelpers.CreateFromJson(@"{ ""value"": 5 }");
            Assert.AreEqual((long)5, (long)data.value);
        }

        [Test]
        public void CannotConvertIntLeafToString()
        {
            dynamic data = JsonDataTestHelpers.CreateFromJson("5");
            Assert.Throws<InvalidOperationException>(
                () => { var s = (string)data; }
            );
        }

        [Test]
        public void CannotConvertIntLeafPropertyToString()
        {
            dynamic data = JsonDataTestHelpers.CreateFromJson(@"{ ""value"": 5 }");
            Assert.Throws<InvalidOperationException>(
                () => { var s = (string)data.value; }
            );
        }

        [Test]
        public void CannotConvertIntLeafToBoolean()
        {
            dynamic data = JsonDataTestHelpers.CreateFromJson("5");
            Assert.Throws<InvalidOperationException>(
                () => { var b = (bool)data; }
            );
        }

        [Test]
        public void CannotConvertIntLeafPropertyToBoolean()
        {
            dynamic data = JsonDataTestHelpers.CreateFromJson(@"{ ""value"": 5 }");
            Assert.Throws<InvalidOperationException>(
                () => { var b = (bool)data.value; }
            );
        }

        [Test]
        public void CannotConvertIntLeafToModel()
        {
            dynamic data = JsonDataTestHelpers.CreateFromJson("5");

            // TODO: Throws JsonException - is that preferred over
            // InvalidOperationException?

            Assert.Throws<JsonException>(
                () => { var model = (SampleModel)data; }
            );
        }

        [Test]
        public void CannotConvertIntLeafPropertyToModel()
        {
            dynamic data = JsonDataTestHelpers.CreateFromJson(@"{ ""value"": 5 }");

            // TODO: Throws JsonException - is that preferred over
            // InvalidOperationException?

            Assert.Throws<JsonException>(
                () => { var model = (SampleModel)data.value; }
            );
        }

        #endregion

        #region GetMember tests

        [Test]
        public void CannotGetMemberOnLeaf()
        {
            dynamic data = JsonDataTestHelpers.CreateFromJson("5");
            Assert.Throws<InvalidOperationException>(
                () => { var x = data.Property; }
            );
        }

        [Test]
        public void CannotGetMemberOnLeafProperty()
        {
            dynamic data = JsonDataTestHelpers.CreateFromJson(@"{ ""value"": 5 }");
            Assert.Throws<InvalidOperationException>(
                () => { var x = data.value.Property; }
            );
        }
        #endregion

        #region SetMember tests

        [Test]
        public void CannotSetMemberOnLeaf()
        {
            dynamic data = JsonDataTestHelpers.CreateFromJson("5");
            Assert.Throws<InvalidOperationException>(
                () => { data.Property = "invalid"; }
            );
        }

        [Test]
        public void CannotSetMemberOnLeafProperty()
        {
            dynamic data = JsonDataTestHelpers.CreateFromJson(@"{ ""value"": 5 }");
            Assert.Throws<InvalidOperationException>(
                () => { data.value.Property = "invalid"; }
            );
        }

        [Test]
        public void CanSetLeafProperty()
        {
            dynamic data = JsonDataTestHelpers.CreateFromJson(@"{ ""value"": 5 }");
            data.value = 6;
            Assert.AreEqual(6, (int)data.value);
        }

        [Test]
        public void CanSetLeafPropertyToDifferentType()
        {
            dynamic data = JsonDataTestHelpers.CreateFromJson(@"{ ""value"": 5 }");
            data.value = "valid";
            Assert.AreEqual("valid", (string)data.value);
        }

        #endregion

        #region GetIndex tests

        [Test]
        public void CannotGetIndexPropertyOnLeaf()
        {
            // TODO: Make exception messages consistent.

            dynamic data = JsonDataTestHelpers.CreateFromJson("5");
            Assert.Throws<InvalidOperationException>(
                () => { var x = data["Property"]; }
            );
        }

        [Test]
        public void CannotGetIndexPropertyOnLeafProperty()
        {
            // TODO: Make exception messages consistent.

            dynamic data = JsonDataTestHelpers.CreateFromJson(@"{ ""value"": 5 }");
            Assert.Throws<InvalidOperationException>(
                () => { var x = data.value["Property"]; }
            );
        }

        [Test]
        public void CannotGetArrayIndexOnLeaf()
        {
            // TODO: Make exception messages consistent.

            dynamic data = JsonDataTestHelpers.CreateFromJson("5");
            Assert.Throws<InvalidOperationException>(
                () => { var x = data[0]; }
            );
        }

        [Test]
        public void CannotGetArrayIndexOnLeafProperty()
        {
            // TODO: Make exception messages consistent.

            dynamic data = JsonDataTestHelpers.CreateFromJson(@"{ ""value"": 5 }");
            Assert.Throws<InvalidOperationException>(
                () => { var x = data.value[0]; }
            );
        }

        #endregion

        #region SetIndex tests

        [Test]
        public void CannotSetIndexPropertyOnLeaf()
        {
            // TODO: Make exception messages consistent.

            dynamic data = JsonDataTestHelpers.CreateFromJson("5");
            Assert.Throws<InvalidOperationException>(
                () => { data["Property"] = "invalid"; }
            );
        }

        [Test]
        public void CannotSetIndexPropertyOnLeafProperty()
        {
            // TODO: Make exception messages consistent.

            dynamic data = JsonDataTestHelpers.CreateFromJson(@"{ ""value"": 5 }");
            Assert.Throws<InvalidOperationException>(
                () => { data.value["Property"] = "invalid"; }
            );
        }

        [Test]
        public void CannotSetArrayIndexOnLeaf()
        {
            // TODO: Make exception messages consistent.

            dynamic data = JsonDataTestHelpers.CreateFromJson("5");
            Assert.Throws<InvalidOperationException>(
                () => { data[0] = "invalid"; }
            );
        }

        [Test]
        public void CannotSetArrayIndexOnLeafProperty()
        {
            // TODO: Make exception messages consistent.

            dynamic data = JsonDataTestHelpers.CreateFromJson(@"{ ""value"": 5 }");
            Assert.Throws<InvalidOperationException>(
                () => { data.value[0] = "invalid"; }
            );
        }
        #endregion

        #region Array behaviors tests

        [Test]
        public void CannotEnumerateLeaf()
        {
            // TODO: This exception says "exepcted kind to be object" - improve this.

            dynamic data = JsonDataTestHelpers.CreateFromJson("5");
            Assert.Throws<InvalidOperationException>(
                () => { foreach (var item in data) { } }
            );
        }

        [Test]
        public void CannotEnumerateLeafProperty()
        {
            // TODO: This exception says "exepcted kind to be object" - improve this.

            dynamic data = JsonDataTestHelpers.CreateFromJson(@"{ ""value"": 5 }");
            Assert.Throws<InvalidOperationException>(
                () => { foreach (var item in data.value) { } }
            );
        }

        #endregion
    }
}

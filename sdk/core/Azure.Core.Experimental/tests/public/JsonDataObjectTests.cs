// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.Core.Tests.Public
{
    public class JsonDataObjectTests
    {
        #region Convert tests

        [Test]
        public void CannotConvertObjectToLeaf()
        {
            dynamic data = JsonDataTestHelpers.CreateFromJson(@"{ ""value"": 5 }");

            // TODO: Standardize Exception types.
            Assert.Throws<InvalidOperationException>(() => { var i = (int)data; });
            Assert.Throws<InvalidOperationException>(() => { var b = (bool)data; });
            Assert.Throws<InvalidOperationException>(() => { var s = (string)data; });
            Assert.Throws<JsonException>(() => { var time = (DateTime)data; });
        }

        [Test]
        public void CanConvertObjectToModel()
        {
            dynamic data = JsonDataTestHelpers.CreateFromJson(
                @"{ ""Message"": ""Hi"",
                    ""Number"" : 5 }");

            Assert.AreEqual(new SampleModel("Hi", 5), (SampleModel)data);
        }

        [Test]
        public void CanConvertObjectToModelWithExtraProperties()
        {
            // TODO: this is just how JsonSerializer works - change this
            // test to do something useful.
            dynamic data = JsonDataTestHelpers.CreateFromJson(
                @"{ ""Message"": ""Hi"",
                    ""Number"" : 5,
                    ""Invalid"" : ""Not on SampleModel"" }");

            SampleModel model = data;

            Assert.AreEqual("Hi", model.Message);
            Assert.AreEqual(5, model.Number);
        }

        // TODO: remove
        [Test]
        public void GoofingOffWithSerializerOptions()
        {
            //string json = @"{ ""Message"": ""Hi"",
            //        ""Number"" : 5,
            //        ""Invalid"" : ""Not on SampleModel"" }";

            // "invalid"" is silently ignored
            // https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/migrate-from-newtonsoft?pivots=dotnet-7-0#missingmemberhandling
            // called "missing on the target type"
            string json = @"{ ""message"": ""Hi"",
                    ""invalid"" : ""Not on SampleModel"" }";

            //dynamic data = JsonDataTestHelpers.CreateFromJson(json);

            var model = JsonSerializer.Deserialize<SampleModel>(json,
                new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            var d = JsonSerializer.Deserialize<IDictionary<string, object>>(json);
            //var i = JsonSerializer.Deserialize<int>(json);

            //SampleModel model = data;

            Assert.AreEqual("Hi", model.Message);
            Assert.AreEqual(5, model.Number);
        }

        #endregion

        #region GetMember tests

        public void CanGetMemberOnObject()
        {
            dynamic data = JsonDataTestHelpers.CreateFromJson(@"{ ""value"": 5 }");
            Assert.AreEqual(5, (int)data.value);
        }

        #endregion

        #region SetMember tests

        public void CanSetMemberOnObject()
        {
            dynamic data = JsonDataTestHelpers.CreateFromJson(@"{ ""value"": 5 }");
            Assert.AreEqual(5, (int)data.value);

            data.value = 6;
            Assert.AreEqual(6, (int)data.value);
        }

        #endregion

        #region GetIndex tests

        public void CanGetIndexPropertyOnObject()
        {
            dynamic data = JsonDataTestHelpers.CreateFromJson(@"{ ""value"": ""hi"" }");
            string prop = data["value"];
            Assert.AreEqual("hi", prop);
        }

        [Test]
        public void CannotGetArrayIndexOnObject()
        {
            dynamic data = JsonDataTestHelpers.CreateFromJson(@"{ ""value"": ""hi"" }");
            Assert.Throws<InvalidOperationException>(
                () => { var x = data[0]; }
            );
        }
        #endregion

        #region SetIndex tests

        public void CanSetIndexPropertyOnObject()
        {
            dynamic data = JsonDataTestHelpers.CreateFromJson(@"{ ""value"": ""hi"" }");
            data["value"] = "hello";
            Assert.AreEqual("hello", (string)data["value"]);
        }

        [Test]
        public void CannotSetArrayIndexOnObject()
        {
            dynamic data = JsonDataTestHelpers.CreateFromJson(@"{ ""value"": ""hi"" }");
            Assert.Throws<InvalidOperationException>(
                () => { data[0] = "invalid"; }
            );
        }

        #endregion

        [Test]
        public void CanEnumerateObject()
        {
            dynamic data = JsonDataTestHelpers.CreateFromJson(@"{ ""first"": 1, ""second"": 2 }");

            var expectedKeys = new[] { "first", "second" };
            var expectedValues = new[] { 1, 2 };

            int i = 0;
            foreach (var pair in data)
            {
                Assert.AreEqual(expectedKeys[i], pair.Key);
                Assert.AreEqual(expectedValues[i], (int)pair.Value);
                i++;
            }
        }
    }
}

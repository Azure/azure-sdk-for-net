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
            dynamic data = JsonDataTestHelpers.CreateFromJson(
                @"{ ""Message"": ""Hi"",
                    ""Number"" : 5,
                    ""Invalid"" : ""Not on SampleModel"" }");

            SampleModel model = data;

            Assert.AreEqual("Hi", model.Message);
            Assert.AreEqual(5, model.Number);
        }

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
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml;
using _Type.Dictionary;
using NUnit.Framework;

namespace TestProjects.Spector.Tests.Http._Type.Dictionary
{
    public class DictionaryTests : SpectorTestBase
    {
        [SpectorTest]
        public Task Int32ValueGet() => Test(async (host) =>
        {
            var response = await new DictionaryClient(host, null).GetInt32ValueClient().GetAsync();
            Assert.AreEqual(2, response.Value.Count);
            Assert.AreEqual(1, response.Value["k1"]);
            Assert.AreEqual(2, response.Value["k2"]);
        });

        [SpectorTest]
        public Task Int32ValuePut() => Test(async (host) =>
        {
            var response = await new DictionaryClient(host, null).GetInt32ValueClient().PutAsync(new Dictionary<string, int>()
            {
                {"k1", 1 },
                {"k2", 2 }
            });
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task Int64ValueGet() => Test(async (host) =>
        {
            var response = await new DictionaryClient(host, null).GetInt64ValueClient().GetAsync();
            Assert.AreEqual(2, response.Value.Count);
            Assert.AreEqual(9007199254740991, response.Value["k1"]);
            Assert.AreEqual(-9007199254740991, response.Value["k2"]);
        });

        [SpectorTest]
        public Task Int64ValuePut() => Test(async (host) =>
        {
            var response = await new DictionaryClient(host, null).GetInt64ValueClient().PutAsync(new Dictionary<string, long>()
            {
                {"k1", 9007199254740991 },
                {"k2", -9007199254740991 }
            });
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task BooleanGet() => Test(async (host) =>
        {
            var response = await new DictionaryClient(host, null).GetBooleanValueClient().GetAsync();
            Assert.AreEqual(2, response.Value.Count);
            Assert.AreEqual(true, response.Value["k1"]);
            Assert.AreEqual(false, response.Value["k2"]);
        });

        [SpectorTest]
        public Task BooleanPut() => Test(async (host) =>
        {
            var response = await new DictionaryClient(host, null).GetBooleanValueClient().PutAsync(new Dictionary<string, bool>()
            {
                {"k1", true },
                {"k2", false }
            });
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task StringGet() => Test(async (host) =>
        {
            var response = await new DictionaryClient(host, null).GetStringValueClient().GetAsync();
            Assert.AreEqual(2, response.Value.Count);
            Assert.AreEqual("hello", response.Value["k1"]);
            Assert.AreEqual("", response.Value["k2"]);
        });

        [SpectorTest]
        public Task StringPut() => Test(async (host) =>
        {
            var response = await new DictionaryClient(host, null).GetStringValueClient().PutAsync(new Dictionary<string, string>()
            {
                {"k1", "hello" },
                {"k2", "" }
            });
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task Float32ValueGet() => Test(async (host) =>
        {
            var response = await new DictionaryClient(host, null).GetFloat32ValueClient().GetAsync();
            Assert.AreEqual(1, response.Value.Count);
            Assert.AreEqual(43.125f, response.Value["k1"]);
        });

        [SpectorTest]
        public Task Float32ValuePut() => Test(async (host) =>
        {
            var response = await new DictionaryClient(host, null).GetFloat32ValueClient().PutAsync(new Dictionary<string, float>()
            {
                {"k1", 43.125f }
            });
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task DatetimeValueGet() => Test(async (host) =>
        {
            var response = await new DictionaryClient(host, null).GetDatetimeValueClient().GetAsync();
            Assert.AreEqual(1, response.Value.Count);
            Assert.AreEqual(DateTimeOffset.Parse("2022-08-26T18:38:00Z"), response.Value["k1"]);
        });

        [SpectorTest]
        public Task DatetimeValuePut() => Test(async (host) =>
        {
            var response = await new DictionaryClient(host, null).GetDatetimeValueClient().PutAsync(new Dictionary<string, DateTimeOffset>()
            {
                {"k1", DateTimeOffset.Parse("2022-08-26T18:38:00Z") }
            });
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task DurationValueGet() => Test(async (host) =>
        {
            var response = await new DictionaryClient(host, null).GetDurationValueClient().GetAsync();
            Assert.AreEqual(1, response.Value.Count);
            Assert.AreEqual(XmlConvert.ToTimeSpan("P123DT22H14M12.011S"), response.Value["k1"]);
        });

        [SpectorTest]
        public Task DurationValuePut() => Test(async (host) =>
        {
            var response = await new DictionaryClient(host, null).GetDurationValueClient().PutAsync(new Dictionary<string, TimeSpan>()
            {
                {"k1", XmlConvert.ToTimeSpan("P123DT22H14M12.011S") }
            });
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task UnknownValueGet() => Test(async (host) =>
        {
            var response = await new DictionaryClient(host, null).GetUnknownValueClient().GetAsync();
            Assert.AreEqual(3, response.Value.Count);
            Assert.AreEqual(1, response.Value["k1"].ToObjectFromJson<int>());
            Assert.AreEqual("hello", response.Value["k2"].ToObjectFromJson<string>());
            Assert.AreEqual(null, response.Value["k3"]);
        });

        [SpectorTest]
        public Task UnknownValuePut() => Test(async (host) =>
        {
            var response = await new DictionaryClient(host, null).GetUnknownValueClient().PutAsync(new Dictionary<string, BinaryData?>()
            {
                {"k1", new BinaryData(1) },
                {"k2", new BinaryData("\"hello\"") },
                {"k3", null }
            });
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task ModelValueGet() => Test(async (host) =>
        {
            var response = await new DictionaryClient(host, null).GetModelValueClient().GetAsync();
            Assert.AreEqual(2, response.Value.Count);
            Assert.AreEqual("hello", response.Value["k1"].Property);
            Assert.AreEqual("world", response.Value["k2"].Property);
        });

        [SpectorTest]
        public Task ModelValuePut() => Test(async (host) =>
        {
            var response = await new DictionaryClient(host, null).GetModelValueClient().PutAsync(new Dictionary<string, InnerModel>()
            {
                {"k1", new InnerModel("hello") },
                {"k2", new InnerModel("world") }
            });
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task RecursiveModelValueGet() => Test(async (host) =>
        {
            var response = await new DictionaryClient(host, null).GetRecursiveModelValueClient().GetAsync();
            Assert.AreEqual(2, response.Value.Count);
            Assert.AreEqual("hello", response.Value["k1"].Property);
            Assert.AreEqual(0, response.Value["k1"].Children.Count);
            Assert.AreEqual("world", response.Value["k2"].Property);
            Assert.AreEqual("inner world", response.Value["k2"].Children["k2.1"].Property);
        });

        [SpectorTest]
        public Task RecursiveModelValuePut() => Test(async (host) =>
        {
            var firstModel = new InnerModel("hello");
            firstModel.Children.Clear();
            var response = await new DictionaryClient(host, null).GetRecursiveModelValueClient().PutAsync(new Dictionary<string, InnerModel>()
            {
                ["k1"] = firstModel,
                ["k2"] = new InnerModel("world")
                {
                    Children =
                    {
                        ["k2.1"] = new InnerModel("inner world")
                    }
                }
            });
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task NullableFloatValueGet() => Test(async (host) =>
        {
            var response = await new DictionaryClient(host, null).GetNullableFloatValueClient().GetAsync();
            Assert.AreEqual(3, response.Value.Count);
            Assert.AreEqual(1.25f, response.Value["k1"]);
            Assert.AreEqual(0.5f, response.Value["k2"]);
            Assert.AreEqual(null, response.Value["k3"]);
        });

        [SpectorTest]
        public Task NullableFloatValuePut() => Test(async (host) =>
        {
            var response = await new DictionaryClient(host, null).GetNullableFloatValueClient().PutAsync(new Dictionary<string, float?>()
            {
                {"k1", 1.25f },
                {"k2", 0.5f },
                {"k3", null }
            });
            Assert.AreEqual(204, response.Status);
        });
    }

}


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
            Assert.That(response.Value.Count, Is.EqualTo(2));
            Assert.Multiple(() =>
            {
                Assert.That(response.Value["k1"], Is.EqualTo(1));
                Assert.That(response.Value["k2"], Is.EqualTo(2));
            });
        });

        [SpectorTest]
        public Task Int32ValuePut() => Test(async (host) =>
        {
            var response = await new DictionaryClient(host, null).GetInt32ValueClient().PutAsync(new Dictionary<string, int>()
            {
                {"k1", 1 },
                {"k2", 2 }
            });
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task Int64ValueGet() => Test(async (host) =>
        {
            var response = await new DictionaryClient(host, null).GetInt64ValueClient().GetAsync();
            Assert.That(response.Value.Count, Is.EqualTo(2));
            Assert.Multiple(() =>
            {
                Assert.That(response.Value["k1"], Is.EqualTo(9007199254740991));
                Assert.That(response.Value["k2"], Is.EqualTo(-9007199254740991));
            });
        });

        [SpectorTest]
        public Task Int64ValuePut() => Test(async (host) =>
        {
            var response = await new DictionaryClient(host, null).GetInt64ValueClient().PutAsync(new Dictionary<string, long>()
            {
                {"k1", 9007199254740991 },
                {"k2", -9007199254740991 }
            });
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task BooleanGet() => Test(async (host) =>
        {
            var response = await new DictionaryClient(host, null).GetBooleanValueClient().GetAsync();
            Assert.That(response.Value.Count, Is.EqualTo(2));
            Assert.Multiple(() =>
            {
                Assert.That(response.Value["k1"], Is.EqualTo(true));
                Assert.That(response.Value["k2"], Is.EqualTo(false));
            });
        });

        [SpectorTest]
        public Task BooleanPut() => Test(async (host) =>
        {
            var response = await new DictionaryClient(host, null).GetBooleanValueClient().PutAsync(new Dictionary<string, bool>()
            {
                {"k1", true },
                {"k2", false }
            });
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task StringGet() => Test(async (host) =>
        {
            var response = await new DictionaryClient(host, null).GetStringValueClient().GetAsync();
            Assert.That(response.Value.Count, Is.EqualTo(2));
            Assert.Multiple(() =>
            {
                Assert.That(response.Value["k1"], Is.EqualTo("hello"));
                Assert.That(response.Value["k2"], Is.EqualTo(""));
            });
        });

        [SpectorTest]
        public Task StringPut() => Test(async (host) =>
        {
            var response = await new DictionaryClient(host, null).GetStringValueClient().PutAsync(new Dictionary<string, string>()
            {
                {"k1", "hello" },
                {"k2", "" }
            });
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task Float32ValueGet() => Test(async (host) =>
        {
            var response = await new DictionaryClient(host, null).GetFloat32ValueClient().GetAsync();
            Assert.That(response.Value.Count, Is.EqualTo(1));
            Assert.That(response.Value["k1"], Is.EqualTo(43.125f));
        });

        [SpectorTest]
        public Task Float32ValuePut() => Test(async (host) =>
        {
            var response = await new DictionaryClient(host, null).GetFloat32ValueClient().PutAsync(new Dictionary<string, float>()
            {
                {"k1", 43.125f }
            });
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task DatetimeValueGet() => Test(async (host) =>
        {
            var response = await new DictionaryClient(host, null).GetDatetimeValueClient().GetAsync();
            Assert.That(response.Value.Count, Is.EqualTo(1));
            Assert.That(response.Value["k1"], Is.EqualTo(DateTimeOffset.Parse("2022-08-26T18:38:00Z")));
        });

        [SpectorTest]
        public Task DatetimeValuePut() => Test(async (host) =>
        {
            var response = await new DictionaryClient(host, null).GetDatetimeValueClient().PutAsync(new Dictionary<string, DateTimeOffset>()
            {
                {"k1", DateTimeOffset.Parse("2022-08-26T18:38:00Z") }
            });
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task DurationValueGet() => Test(async (host) =>
        {
            var response = await new DictionaryClient(host, null).GetDurationValueClient().GetAsync();
            Assert.That(response.Value.Count, Is.EqualTo(1));
            Assert.That(response.Value["k1"], Is.EqualTo(XmlConvert.ToTimeSpan("P123DT22H14M12.011S")));
        });

        [SpectorTest]
        public Task DurationValuePut() => Test(async (host) =>
        {
            var response = await new DictionaryClient(host, null).GetDurationValueClient().PutAsync(new Dictionary<string, TimeSpan>()
            {
                {"k1", XmlConvert.ToTimeSpan("P123DT22H14M12.011S") }
            });
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task UnknownValueGet() => Test(async (host) =>
        {
            var response = await new DictionaryClient(host, null).GetUnknownValueClient().GetAsync();
            Assert.That(response.Value.Count, Is.EqualTo(3));
            Assert.Multiple(() =>
            {
                Assert.That(response.Value["k1"].ToObjectFromJson<int>(), Is.EqualTo(1));
                Assert.That(response.Value["k2"].ToObjectFromJson<string>(), Is.EqualTo("hello"));
                Assert.That(response.Value["k3"], Is.EqualTo(null));
            });
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
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task ModelValueGet() => Test(async (host) =>
        {
            var response = await new DictionaryClient(host, null).GetModelValueClient().GetAsync();
            Assert.That(response.Value.Count, Is.EqualTo(2));
            Assert.Multiple(() =>
            {
                Assert.That(response.Value["k1"].Property, Is.EqualTo("hello"));
                Assert.That(response.Value["k2"].Property, Is.EqualTo("world"));
            });
        });

        [SpectorTest]
        public Task ModelValuePut() => Test(async (host) =>
        {
            var response = await new DictionaryClient(host, null).GetModelValueClient().PutAsync(new Dictionary<string, InnerModel>()
            {
                {"k1", new InnerModel("hello") },
                {"k2", new InnerModel("world") }
            });
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task RecursiveModelValueGet() => Test(async (host) =>
        {
            var response = await new DictionaryClient(host, null).GetRecursiveModelValueClient().GetAsync();
            Assert.That(response.Value.Count, Is.EqualTo(2));
            Assert.Multiple(() =>
            {
                Assert.That(response.Value["k1"].Property, Is.EqualTo("hello"));
                Assert.That(response.Value["k1"].Children.Count, Is.EqualTo(0));
                Assert.That(response.Value["k2"].Property, Is.EqualTo("world"));
                Assert.That(response.Value["k2"].Children["k2.1"].Property, Is.EqualTo("inner world"));
            });
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
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task NullableFloatValueGet() => Test(async (host) =>
        {
            var response = await new DictionaryClient(host, null).GetNullableFloatValueClient().GetAsync();
            Assert.That(response.Value.Count, Is.EqualTo(3));
            Assert.Multiple(() =>
            {
                Assert.That(response.Value["k1"], Is.EqualTo(1.25f));
                Assert.That(response.Value["k2"], Is.EqualTo(0.5f));
                Assert.That(response.Value["k3"], Is.EqualTo(null));
            });
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
            Assert.That(response.Status, Is.EqualTo(204));
        });
    }

}


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml;
using _Type._Array;
using NUnit.Framework;

namespace TestProjects.Spector.Tests.Http._Type._Array
{
    internal class ArrayTests : SpectorTestBase
    {
        [SpectorTest]
        public Task Int32ValueGet() => Test(async (host) =>
        {
            var response = await new ArrayClient(host, null).GetInt32ValueClient().GetAsync();
            Assert.That(response.Value, Is.EqualTo(new[] { 1, 2 }).AsCollection);
        });

        [SpectorTest]
        public Task Int32ValuePut() => Test(async (host) =>
        {
            var response = await new ArrayClient(host, null).GetInt32ValueClient().PutAsync(new List<int> { 1, 2 });
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task Int64ValueGet() => Test(async (host) =>
        {
            var response = await new ArrayClient(host, null).GetInt64ValueClient().GetAsync();
            Assert.That(response.Value, Is.EqualTo(new[] { 9007199254740991, -9007199254740991 }).AsCollection);
        });

        [SpectorTest]
        public Task Int64ValuePut() => Test(async (host) =>
        {
            var response = await new ArrayClient(host, null).GetInt64ValueClient().PutAsync(new List<long> { 9007199254740991, -9007199254740991 });
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task BooleanValueGet() => Test(async (host) =>
        {
            var response = await new ArrayClient(host, null).GetBooleanValueClient().GetAsync();
            Assert.That(response.Value, Is.EqualTo(new[] { true, false }).AsCollection);
        });

        [SpectorTest]
        public Task BooleanValuePut() => Test(async (host) =>
        {
            var response = await new ArrayClient(host, null).GetBooleanValueClient().PutAsync(new List<bool> { true, false });
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task StringValueGet() => Test(async (host) =>
        {
            var response = await new ArrayClient(host, null).GetStringValueClient().GetAsync();
            Assert.That(response.Value, Is.EqualTo(new[] { "hello", "" }).AsCollection);
        });

        [SpectorTest]
        public Task StringValuePut() => Test(async (host) =>
        {
            var response = await new ArrayClient(host, null).GetStringValueClient().PutAsync(new List<string> { "hello", "" });
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task Float32ValueGet() => Test(async (host) =>
        {
            var response = await new ArrayClient(host, null).GetFloat32ValueClient().GetAsync();
            Assert.That(response.Value, Is.EqualTo(new[] { 43.125f }).AsCollection);
        });

        [SpectorTest]
        public Task Float32ValuePut() => Test(async (host) =>
        {
            var response = await new ArrayClient(host, null).GetFloat32ValueClient().PutAsync(new List<float> { 43.125f });
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task DatetimeValueGet() => Test(async (host) =>
        {
            var response = await new ArrayClient(host, null).GetDatetimeValueClient().GetAsync();
            Assert.That(response.Value.Count, Is.EqualTo(1));
            Assert.That(response.Value[0], Is.EqualTo(DateTimeOffset.Parse("2022-08-26T18:38:00Z")));
        });

        [SpectorTest]
        public Task DatetimeValuePut() => Test(async (host) =>
        {
            var response = await new ArrayClient(host, null).GetDatetimeValueClient().PutAsync(new List<DateTimeOffset> { DateTimeOffset.Parse("2022-08-26T18:38:00Z") });
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task DurationValueGet() => Test(async (host) =>
        {
            var response = await new ArrayClient(host, null).GetDurationValueClient().GetAsync();
            Assert.That(response.Value.Count, Is.EqualTo(1));
            Assert.That(response.Value[0], Is.EqualTo(XmlConvert.ToTimeSpan("P123DT22H14M12.011S")));
        });

        [SpectorTest]
        public Task DurationValuePut() => Test(async (host) =>
        {
            var response = await new ArrayClient(host, null).GetDurationValueClient().PutAsync(new List<TimeSpan> { XmlConvert.ToTimeSpan("P123DT22H14M12.011S") });
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task UnknownValueGet() => Test(async (host) =>
        {
            var response = await new ArrayClient(host, null).GetUnknownValueClient().GetAsync();
            Assert.Multiple(() =>
            {
                Assert.That(response.Value[0].ToObjectFromJson<int>(), Is.EqualTo(1));
                Assert.That(response.Value[1].ToObjectFromJson<string>(), Is.EqualTo("hello"));
                Assert.That(response.Value[2], Is.Null);
            });
        });

        [SpectorTest]
        public Task UnknownValuePut() => Test(async (host) =>
        {
            var response = await new ArrayClient(host, null).GetUnknownValueClient().PutAsync(new List<BinaryData?> { new BinaryData(1), new BinaryData("\"hello\""), null });
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task ModelValueGet() => Test(async (host) =>
        {
            var response = await new ArrayClient(host, null).GetModelValueClient().GetAsync();
            Assert.That(response.Value.Count, Is.EqualTo(2));
            Assert.Multiple(() =>
            {
                Assert.That(response.Value[0].Property, Is.EqualTo("hello"));
                Assert.That(response.Value[1].Property, Is.EqualTo("world"));
            });
        });

        [SpectorTest]
        public Task ModelValuePut() => Test(async (host) =>
        {
            var response = await new ArrayClient(host, null).GetModelValueClient().PutAsync(new List<InnerModel> { new InnerModel("hello"), new InnerModel("world") });
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task NullableBoolValueGet() => Test(async (host) =>
        {
            var response = await new ArrayClient(host, null).GetNullableBooleanValueClient().GetAsync();
            Assert.That(response.Value.Count, Is.EqualTo(3));
            Assert.Multiple(() =>
            {
                Assert.That(response.Value[0], Is.True);
                Assert.That(response.Value[1], Is.Null);
                Assert.That(response.Value[2], Is.False);
            });
        });

        [SpectorTest]
        public Task NullableBoolValuePut() => Test(async (host) =>
        {
            var response = await new ArrayClient(host, null).GetNullableBooleanValueClient().PutAsync([true, null, false]);
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task NullableFloatValueGet() => Test(async (host) =>
        {
            var response = await new ArrayClient(host, null).GetNullableFloatValueClient().GetAsync();
            Assert.That(response.Value, Is.EqualTo(new float?[] { 1.25f, null, 3.0f }).AsCollection);
        });

        [SpectorTest]
        public Task NullableFloatValuePut() => Test(async (host) =>
        {
            var response = await new ArrayClient(host, null).GetNullableFloatValueClient().PutAsync(new List<float?> { 1.25f, null, 3.0f });
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task NullableIntValueGet() => Test(async (host) =>
        {
            var response = await new ArrayClient(host, null).GetNullableInt32ValueClient().GetAsync();
            Assert.That(response.Value, Is.EqualTo(new int?[] { 1, null, 3 }).AsCollection);
        });

        [SpectorTest]
        public Task NullableIntValuePut() => Test(async (host) =>
        {
            var response = await new ArrayClient(host, null).GetNullableInt32ValueClient().PutAsync([1, null, 3]);
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task NullableModelValueGet() => Test(async (host) =>
        {
            var response = await new ArrayClient(host, null).GetNullableModelValueClient().GetAsync();
            Assert.That(response.Value.Count, Is.EqualTo(3));
            Assert.Multiple(() =>
            {
                Assert.That(response.Value[0].Property, Is.EqualTo("hello"));
                Assert.That(response.Value[1], Is.Null);
                Assert.That(response.Value[2].Property, Is.EqualTo("world"));
            });
        });

        [SpectorTest]
        public Task NullableModelValuePut() => Test(async (host) =>
        {
            var response = await new ArrayClient(host, null).GetNullableModelValueClient().PutAsync([new InnerModel("hello"), null, new InnerModel("world")]);
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task NullableStringValueGet() => Test(async (host) =>
        {
            var response = await new ArrayClient(host, null).GetNullableStringValueClient().GetAsync();
            Assert.That(response.Value.Count, Is.EqualTo(3));
            Assert.Multiple(() =>
            {
                Assert.That(response.Value[0], Is.EqualTo("hello"));
                Assert.That(response.Value[1], Is.Null);
                Assert.That(response.Value[2], Is.EqualTo("world"));
            });
        });

        [SpectorTest]
        public Task NullableStringValuePut() => Test(async (host) =>
        {
            var response = await new ArrayClient(host, null).GetNullableStringValueClient().PutAsync(["hello", null, "world"]);
            Assert.That(response.Status, Is.EqualTo(204));
        });
    }
}

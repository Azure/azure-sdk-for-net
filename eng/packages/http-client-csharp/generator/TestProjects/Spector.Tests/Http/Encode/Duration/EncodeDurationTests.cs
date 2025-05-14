// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Encode.Duration;
using Encode.Duration._Property;
using NUnit.Framework;

namespace TestProjects.Spector.Tests.Http.Encode.Duration
{
    public class EncodeDurationTests : SpectorTestBase
    {
        [SpectorTest]
        public Task HeaderDefault() => Test(async (host) =>
        {
            var input = new TimeSpan(40, 0, 0, 0);
            var response = await new DurationClient(host, null).GetHeaderClient().DefaultAsync(input);
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task HeaderFloat64Seconds() => Test(async (host) =>
        {
            var input = TimeSpan.FromSeconds(35.625);
            var response = await new DurationClient(host, null).GetHeaderClient().Float64SecondsAsync(input);
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task HeaderFloatSeconds() => Test(async (host) =>
        {
            var input = TimeSpan.FromSeconds(35.625);
            var response = await new DurationClient(host, null).GetHeaderClient().FloatSecondsAsync(input);
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task HeaderInt32Seconds() => Test(async (host) =>
        {
            var input = TimeSpan.FromSeconds(36);
            var response = await new DurationClient(host, null).GetHeaderClient().Int32SecondsAsync(input);
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task HeaderISO8601() => Test(async (host) =>
        {
            var input = new TimeSpan(40, 0, 0, 0);
            var response = await new DurationClient(host, null).GetHeaderClient().Iso8601Async(input);
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task HeaderISO8601Array() => Test(async (host) =>
        {
            var data1 = new TimeSpan(40, 0, 0, 0);
            var data2 = new TimeSpan(50, 0, 0, 0);
            var response = await new DurationClient(host, null).GetHeaderClient().Iso8601ArrayAsync(new[] { data1, data2 });
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task PropertyDefault() => Test(async (host) =>
        {
            var data = new
            {
                value = "P40D",
            };
            BinaryData binaryData = new BinaryData(data);
            var response = await new DurationClient(host, null).GetPropertyClient().DefaultAsync(RequestContent.Create(binaryData), null);
            JsonElement jsonResult = JsonDocument.Parse(response.ContentStream!).RootElement;
            Assert.AreEqual("P40D", jsonResult.GetProperty("value").ToString());
        });

        [SpectorTest]
        public Task PropertyDefaultConvenience() => Test(async (host) =>
        {
            var body = new DefaultDurationProperty(new TimeSpan(40, 0, 0, 0));
            var result = await new DurationClient(host, null).GetPropertyClient().DefaultAsync(body);
            Assert.AreEqual(body.Value, result.Value.Value);
        });

        [SpectorTest]
        public Task PropertyISO8601() => Test(async (host) =>
        {
            var data = new
            {
                value = "P40D",
            };
            BinaryData binaryData = new BinaryData(data);
            var response = await new DurationClient(host, null).GetPropertyClient().Iso8601Async(RequestContent.Create(binaryData), null);
            JsonElement jsonResult = JsonDocument.Parse(response.ContentStream!).RootElement;
            Assert.AreEqual("P40D", jsonResult.GetProperty("value").ToString());
        });

        [SpectorTest]
        public Task PropertyISO8601Convenience() => Test(async (host) =>
        {
            var body = new ISO8601DurationProperty(new TimeSpan(40, 0, 0, 0));
            var response = await new DurationClient(host, null).GetPropertyClient().Iso8601Async(body);
            Assert.AreEqual(body.Value, response.Value.Value);
        });

        [SpectorTest]
        public Task PropertyInt32Seconds() => Test(async (host) =>
        {
            var data = new
            {
                value = 36,
            };
            BinaryData binaryData = new BinaryData(data);
            var response = await new DurationClient(host, null).GetPropertyClient().Int32SecondsAsync(RequestContent.Create(binaryData), null);
            JsonElement jsonResult = JsonDocument.Parse(response.ContentStream!).RootElement;
            Assert.AreEqual("36", jsonResult.GetProperty("value").ToString());
        });

        [SpectorTest]
        public Task PropertyInt32SecondsConvenience() => Test(async (host) =>
        {
            var body = new Int32SecondsDurationProperty(TimeSpan.FromSeconds(36));
            var response = await new DurationClient(host, null).GetPropertyClient().Int32SecondsAsync(body);
            Assert.AreEqual(body.Value, response.Value.Value);
        });

        [SpectorTest]
        public Task PropertyFloatSeconds() => Test(async (host) =>
        {
            var data = new
            {
                value = 35.625,
            };
            BinaryData binaryData = new BinaryData(data);
            var response = await new DurationClient(host, null).GetPropertyClient().FloatSecondsAsync(RequestContent.Create(binaryData), null);
            JsonElement jsonResult = JsonDocument.Parse(response.ContentStream!).RootElement;
            Assert.AreEqual("35.625", jsonResult.GetProperty("value").ToString());
        });

        [SpectorTest]
        public Task PropertyFloatSecondsConvenience() => Test(async (host) =>
        {
            var body = new FloatSecondsDurationProperty(TimeSpan.FromSeconds(35.625));
            var response = await new DurationClient(host, null).GetPropertyClient().FloatSecondsAsync(body);
            Assert.AreEqual(body.Value, response.Value.Value);
        });

        [SpectorTest]
        public Task PropertyFloat64Seconds() => Test(async (host) =>
        {
            var data = new
            {
                value = 35.625,
            };
            BinaryData binaryData = new BinaryData(data);
            var response = await new DurationClient(host, null).GetPropertyClient().FloatSecondsAsync(RequestContent.Create(binaryData), null);
            JsonElement jsonResult = JsonDocument.Parse(response.ContentStream!).RootElement;
            Assert.AreEqual("35.625", jsonResult.GetProperty("value").ToString());
        });

        [SpectorTest]
        public Task PropertyFloat64SecondsConvenience() => Test(async (host) =>
        {
            var body = new Float64SecondsDurationProperty(TimeSpan.FromSeconds(35.625));
            var response = await new DurationClient(host, null).GetPropertyClient().Float64SecondsAsync(body);
            Assert.AreEqual(body.Value, response.Value.Value);
        });

        [SpectorTest]
        public Task PropertyFloatSecondsArray() => Test(async (host) =>
        {
            var data = new
            {
                value = new[] { 35.625, 46.75 }
            };
            BinaryData binaryData = new BinaryData(data);
            var response = await new DurationClient(host, null).GetPropertyClient().FloatSecondsArrayAsync(RequestContent.Create(binaryData), null);
            JsonElement jsonResult = JsonDocument.Parse(response.ContentStream!).RootElement;
            Assert.AreEqual("35.625", jsonResult.GetProperty("value")[0].ToString());
            Assert.AreEqual("46.75", jsonResult.GetProperty("value")[1].ToString());
        });

        [SpectorTest]
        public Task PropertyFloatSecondsArrayConvenience() => Test(async (host) =>
        {
            var data1 = TimeSpan.FromSeconds(35.625);
            var data2 = TimeSpan.FromSeconds(46.75);
            var body = new FloatSecondsDurationArrayProperty(new[] { data1, data2});
            var response = await new DurationClient(host, null).GetPropertyClient().FloatSecondsArrayAsync(body);
            Assert.AreEqual(body.Value, response.Value.Value);
        });

        [SpectorTest]
        public Task QueryDefault() => Test(async (host) =>
        {
            var input = new TimeSpan(40, 0, 0, 0);
            var response = await new DurationClient(host, null).GetQueryClient().DefaultAsync(input);
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task QueryISO8601() => Test(async (host) =>
        {
            var input = new TimeSpan(40, 0, 0, 0);
            var response = await new DurationClient(host, null).GetQueryClient().Iso8601Async(input);
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task QueryInt32Seconds() => Test(async (host) =>
        {
            var input = TimeSpan.FromSeconds(36);
            var response = await new DurationClient(host, null).GetQueryClient().Int32SecondsAsync(input);
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task QueryFloatSeconds() => Test(async (host) =>
        {
            var input = TimeSpan.FromSeconds(35.625);
            var response = await new DurationClient(host, null).GetQueryClient().FloatSecondsAsync(input);
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task QueryFloat64Seconds() => Test(async (host) =>
        {
            var input = TimeSpan.FromSeconds(35.625);
            var response = await new DurationClient(host, null).GetQueryClient().Float64SecondsAsync(input);
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task QueryInt32SecondsArray() => Test(async (host) =>
        {
            var data1 = TimeSpan.FromSeconds(36);
            var data2 = TimeSpan.FromSeconds(47);
            var response = await new DurationClient(host, null).GetQueryClient().Int32SecondsArrayAsync(new[] { data1, data2 });
            Assert.AreEqual(204, response.Status);
        });
    }
}
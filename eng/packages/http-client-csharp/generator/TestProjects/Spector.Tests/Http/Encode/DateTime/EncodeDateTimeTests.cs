// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Encode.Datetime;
using NUnit.Framework;

namespace TestProjects.Spector.Tests.Http.Encode.Datetime
{
    public class EncodeDateTimeTests : SpectorTestBase
    {
        [SpectorTest]
        public Task ResponseHeaderDefault() => Test(async (host) =>
        {
            var response = await new DatetimeClient(host, null).GetResponseHeaderClient().DefaultAsync();
            Assert.AreEqual(204, response.Status);

            Assert.IsTrue(response.Headers.TryGetValue("value", out string? header));
            Assert.AreEqual("Fri, 26 Aug 2022 14:38:00 GMT", header);
        });

        [SpectorTest]
        public Task ResponseHeaderRfc3339() => Test(async (host) =>
        {
            var response = await new DatetimeClient(host, null).GetResponseHeaderClient().Rfc3339Async();
            Assert.AreEqual(204, response.Status);

            Assert.IsTrue(response.Headers.TryGetValue("value", out string? header));
            Assert.AreEqual("2022-08-26T18:38:00.000Z", header);
        });

        [SpectorTest]
        public Task ResponseHeaderRfc7231() => Test(async (host) =>
        {
            var response = await new DatetimeClient(host, null).GetResponseHeaderClient().Rfc7231Async();
            Assert.AreEqual(204, response.Status);

            Assert.IsTrue(response.Headers.TryGetValue("value", out string? header));
            Assert.AreEqual("Fri, 26 Aug 2022 14:38:00 GMT", header);
        });

        [SpectorTest]
        public Task ResponseHeaderUnixTimestamp() => Test(async (host) =>
        {
            var response = await new DatetimeClient(host, null).GetResponseHeaderClient().UnixTimestampAsync();
            Assert.AreEqual(204, response.Status);

            Assert.IsTrue(response.Headers.TryGetValue("value", out string? header));
            Assert.AreEqual("1686566864", header);
        });

        [SpectorTest]
        public Task HeaderDefault() => Test(async (host) =>
        {
            DateTimeOffset data = DateTimeOffset.Parse("Fri, 26 Aug 2022 14:38:00 GMT");
            var response = await new DatetimeClient(host, null).GetHeaderClient().DefaultAsync(data);
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task HeaderRfc3339() => Test(async (host) =>
        {
            DateTimeOffset data = DateTimeOffset.Parse("2022-08-26T18:38:00.000Z");
            var response = await new DatetimeClient(host, null).GetHeaderClient().Rfc3339Async(data);
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task HeaderRfc7231() => Test(async (host) =>
        {
            DateTimeOffset data = DateTimeOffset.Parse("Fri, 26 Aug 2022 14:38:00 GMT");
            var response = await new DatetimeClient(host, null).GetHeaderClient().Rfc7231Async(data);
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task HeaderUnixTimestamp() => Test(async (host) =>
        {
            DateTimeOffset data = DateTimeOffset.FromUnixTimeSeconds(1686566864);
            var response = await new DatetimeClient(host, null).GetHeaderClient().UnixTimestampAsync(data);
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task HeaderUnixTimestampArray() => Test(async (host) =>
        {
            DateTimeOffset data1 = DateTimeOffset.FromUnixTimeSeconds(1686566864);
            DateTimeOffset data2 = DateTimeOffset.FromUnixTimeSeconds(1686734256);
            var response = await new DatetimeClient(host, null).GetHeaderClient().UnixTimestampArrayAsync(new[] { data1, data2 });
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task QueryDefault() => Test(async (host) =>
        {
            DateTimeOffset data = DateTimeOffset.Parse("2022-08-26T18:38:00.000Z");
            var response = await new DatetimeClient(host, null).GetQueryClient().DefaultAsync(data);
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task QueryRfc3339() => Test(async (host) =>
        {
            DateTimeOffset data = DateTimeOffset.Parse("2022-08-26T18:38:00.000Z");
            var response = await new DatetimeClient(host, null).GetQueryClient().Rfc3339Async(data);
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task QueryRfc7231() => Test(async (host) =>
        {
            DateTimeOffset data = DateTimeOffset.Parse("Fri, 26 Aug 2022 14:38:00 GMT");
            var response = await new DatetimeClient(host, null).GetQueryClient().Rfc7231Async(data);
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task QueryUnixTimestamp() => Test(async (host) =>
        {
            DateTimeOffset data = DateTimeOffset.FromUnixTimeSeconds(1686566864);
            var response = await new DatetimeClient(host, null).GetQueryClient().UnixTimestampAsync(data);
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task QueryUnixTimestampArray() => Test(async (host) =>
        {
            DateTimeOffset data1 = DateTimeOffset.FromUnixTimeSeconds(1686566864);
            DateTimeOffset data2 = DateTimeOffset.FromUnixTimeSeconds(1686734256);
            var response = await new DatetimeClient(host, null).GetQueryClient().UnixTimestampArrayAsync(new[] { data1, data2 });
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task PropertyDefault() => Test(async (host) =>
        {
            DateTimeOffset data = DateTimeOffset.Parse("2022-08-26T18:38:00.000Z");
            var body = new DefaultDatetimeProperty(data);
            var response = await new DatetimeClient(host, null).GetPropertyClient().DefaultAsync(body);
            Assert.AreEqual(body.Value, response.Value.Value);
        });

        [SpectorTest]
        public Task PropertyRfc3339() => Test(async (host) =>
        {
            DateTimeOffset data = DateTimeOffset.Parse("2022-08-26T18:38:00.000Z");
            var body = new Rfc3339DatetimeProperty(data);
            var response = await new DatetimeClient(host, null).GetPropertyClient().Rfc3339Async(body);
            Assert.AreEqual(body.Value, response.Value.Value);
        });

        [SpectorTest]
        public Task PropertyRfc7231() => Test(async (host) =>
        {
            DateTimeOffset data = DateTimeOffset.Parse("Fri, 26 Aug 2022 14:38:00 GMT");
            var body = new Rfc7231DatetimeProperty(data);
            var response = await new DatetimeClient(host, null).GetPropertyClient().Rfc7231Async(body);
            Assert.AreEqual(body.Value, response.Value.Value);
        });


        [SpectorTest]
        public Task PropertyUnixTimestamp() => Test(async (host) =>
        {
            DateTimeOffset data = DateTimeOffset.FromUnixTimeSeconds(1686566864);
            var body = new UnixTimestampDatetimeProperty(data);
            var response = await new DatetimeClient(host, null).GetPropertyClient().UnixTimestampAsync(body);
            Assert.AreEqual(body.Value, response.Value.Value);
        });

        [SpectorTest]
        public Task PropertyUnixTimestampArray() => Test(async (host) =>
        {
            DateTimeOffset data1 = DateTimeOffset.FromUnixTimeSeconds(1686566864);
            DateTimeOffset data2 = DateTimeOffset.FromUnixTimeSeconds(1686734256);
            var body = new UnixTimestampArrayDatetimeProperty(new[] { data1, data2 });
            var response = await new DatetimeClient(host, null).GetPropertyClient().UnixTimestampArrayAsync(body);
            Assert.AreEqual(body.Value, response.Value.Value);
        });
    }
}
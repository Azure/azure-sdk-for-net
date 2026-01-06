// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;
using Parameters.CollectionFormat;

namespace TestProjects.Spector.Tests.Http.Parameters.CollectionFormat
{
    public class CollectionFormatParametersTests : SpectorTestBase
    {
        [SpectorTest]
        public Task QueryMulti() => Test(async (host) =>
        {
            List<string> colors = ["blue", "red", "green"];
            var response = await new CollectionFormatClient(host, null).GetQueryClient().MultiAsync(colors);
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task QueryMultiAsArray() => Test(async (host) =>
        {
            string[] colors = ["blue", "red", "green"];
            var response = await new CollectionFormatClient(host, null).GetQueryClient().MultiAsync(colors);
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task QueryCsv() => Test(async (host) =>
        {
            List<string> colors = ["blue", "red", "green"];
            var response = await new CollectionFormatClient(host, null).GetQueryClient().CsvAsync(colors);
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task QuerySsv() => Test(async (host) =>
        {
            List<string> colors = ["blue", "red", "green"];
            var response = await new CollectionFormatClient(host, null).GetQueryClient().SsvAsync(colors);
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task QueryPipes() => Test(async (host) =>
        {
            List<string> colors = ["blue", "red", "green"];
            var response = await new CollectionFormatClient(host, null).GetQueryClient().PipesAsync(colors);
            Assert.That(response.Status, Is.EqualTo(204));
        });

        [SpectorTest]
        public Task HeaderCsv() => Test(async (host) =>
        {
            List<string> colors = ["blue", "red", "green"];
            var response = await new CollectionFormatClient(host, null).GetHeaderClient().CsvAsync(colors);
            Assert.That(response.Status, Is.EqualTo(204));
        });
    }
}
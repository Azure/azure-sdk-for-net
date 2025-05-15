// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using NUnit.Framework;
using Parameters.Path;

namespace TestProjects.Spector.Tests.Http.Parameters.Path
{
    public class PathTests : SpectorTestBase
    {
        [SpectorTest]
        public Task Normal() => Test(async (host) =>
        {
            var client = new PathClient(host, null);
            var name = "foo";
            var response = await client.NormalAsync(name);
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        [TestCase(true)]
        [TestCase(false)]
        public Task OptionalPathParamIncluded(bool isOptional) => Test(async (host) =>
        {
            var client = new PathClient(host, null);
            string? name = isOptional ? null : "foo";
            var response = await client.OptionalAsync(name);
            Assert.AreEqual(204, response.Status);
        });
    }
}
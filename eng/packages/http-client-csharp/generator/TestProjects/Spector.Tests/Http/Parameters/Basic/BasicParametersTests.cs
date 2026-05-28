// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using NUnit.Framework;
using Parameters.Basic;
using Parameters.Basic.Models;

namespace TestProjects.Spector.Tests.Http.Parameters.Basic
{
    public class BasicParametersTests : SpectorTestBase
    {
        [SpectorTest]
        public Task ExplicitBodySimple() => Test(async (host) =>
        {
            var client = new BasicClient(host, null).GetExplicitBodyClient();
            var body = new User("foo");
            var response = await client.SimpleAsync(body);
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task ImplicitBodySimple() => Test(async (host) =>
        {
            var client = new BasicClient(host, null).GetImplicitBodyClient();
            var name = "foo";
            var response = await client.SimpleAsync(name);
            Assert.AreEqual(204, response.Status);
        });
    }
}

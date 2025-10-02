// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Client.Overload;
using NUnit.Framework;

namespace TestProjects.Spector.Tests.Http.Client.Overload
{
    public class OverloadTests : SpectorTestBase
    {
        [SpectorTest]
        public Task Client_Overload_list() => Test(async (host) =>
        {
            var response = await new OverloadClient(host, null).GetAllAsync();
            Assert.AreEqual(200, response.GetRawResponse().Status);

            var results = response.Value;
            Assert.AreEqual(2, results.Count);
            Assert.AreEqual("foo", results[0].Name);
            Assert.AreEqual("car", results[0].Scope);
            Assert.AreEqual("bar", results[1].Name);
            Assert.AreEqual("bike", results[1].Scope);
        });

        [SpectorTest]
        public Task Client_Overload_listByScope() => Test(async (host) =>
        {
            var response = await new OverloadClient(host, null).GetAllAsync(scope: "car");
            Assert.AreEqual(200, response.GetRawResponse().Status);

            var results = response.Value;
            Assert.AreEqual(1, results.Count);
            Assert.AreEqual("foo", results[0].Name);
            Assert.AreEqual("car", results[0].Scope);
        });
    }
}
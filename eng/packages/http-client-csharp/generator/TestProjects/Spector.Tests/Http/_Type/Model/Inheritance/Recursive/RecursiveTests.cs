// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using _Type.Model.Inheritance.Recursive;
using NUnit.Framework;

namespace TestProjects.Spector.Tests.Http._Type.Model.Inheritance.Recursive
{
    public class RecursiveTests : SpectorTestBase
    {
        [SpectorTest]
        public Task RecursiveGet() => Test(async (host) =>
        {
            var response = await new RecursiveClient(host, null).GetAsync();

            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual(0, response.Value.Level);
            Assert.AreEqual(2, response.Value.Extension.Count);
            Assert.AreEqual(1, response.Value.Extension[0].Level);
            Assert.AreEqual(1, response.Value.Extension[0].Extension.Count);
            Assert.AreEqual(2, response.Value.Extension[0].Extension[0].Level);
            Assert.AreEqual(1, response.Value.Extension[1].Level);
            Assert.AreEqual(0, response.Value.Extension[0].Extension[0].Extension.Count);
            Assert.IsTrue(response.Value.Extension[1].Extension is null || response.Value.Extension[1].Extension.Count == 0);
        });

        [SpectorTest]
        public Task RecursivePut() => Test(async (host) =>
        {
            var data = new Extension(0);
            var extensions = data.Extension;
            Extension item1 = new(1);
            item1.Extension.Add(new Extension(2));
            Extension item2 = new(1);
            extensions.Add(item1);
            extensions.Add(item2);

            var response = await new RecursiveClient(host, null).PutAsync(data);
            Assert.AreEqual(204, response.Status);
        });

    }
}
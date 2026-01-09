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

            Assert.Multiple(() =>
            {
                Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
                Assert.That(response.Value.Level, Is.EqualTo(0));
                Assert.That(response.Value.Extension.Count, Is.EqualTo(2));
            });
            Assert.Multiple(() =>
            {
                Assert.That(response.Value.Extension[0].Level, Is.EqualTo(1));
                Assert.That(response.Value.Extension[0].Extension.Count, Is.EqualTo(1));
            });
            Assert.Multiple(() =>
            {
                Assert.That(response.Value.Extension[0].Extension[0].Level, Is.EqualTo(2));
                Assert.That(response.Value.Extension[1].Level, Is.EqualTo(1));
                Assert.That(response.Value.Extension[0].Extension[0].Extension.Count, Is.EqualTo(0));
                Assert.That(response.Value.Extension[1].Extension is null || response.Value.Extension[1].Extension.Count == 0, Is.True);
            });
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
            Assert.That(response.Status, Is.EqualTo(204));
        });

    }
}
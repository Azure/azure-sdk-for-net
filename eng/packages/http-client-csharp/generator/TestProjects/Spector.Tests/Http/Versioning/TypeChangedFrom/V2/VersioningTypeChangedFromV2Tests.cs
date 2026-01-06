// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias TypeChangedFromV2;
using System.Threading.Tasks;
using NUnit.Framework;
using TypeChangedFromV2::Versioning.TypeChangedFrom;

namespace TestProjects.Spector.Tests.Http.Versioning.TypeChangedFrom.V2
{
    public class VersioningTypeChangedFromTests : SpectorTestBase
    {
        [SpectorTest]
        public Task Versioning_TypeChangedFrom_Test() => Test(async (host) =>
        {
            TestModel body = new TestModel("foo", "bar");
            var response = await new TypeChangedFromClient(host).TestAsync("baz", body);
            Assert.Multiple(() =>
            {
                Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
                Assert.That(response.Value.Prop, Is.EqualTo("foo"));
                Assert.That(response.Value.ChangedProp, Is.EqualTo("bar"));
            });
        });
    }
}

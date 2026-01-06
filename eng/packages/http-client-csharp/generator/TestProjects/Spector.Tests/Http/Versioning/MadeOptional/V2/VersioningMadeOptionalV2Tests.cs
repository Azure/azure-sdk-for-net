// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias MadeOptionalV2;
using System.Linq;
using System.Threading.Tasks;
using MadeOptionalV2::Versioning.MadeOptional;
using NUnit.Framework;

namespace TestProjects.Spector.Tests.Http.Versioning.MadeOptional.V2
{
    public class VersioningMadeOptionalV2Tests : SpectorTestBase
    {
        [SpectorTest]
        public void CheckMadeOptionalMembers()
        {
            var constructors = typeof(TestModel).GetConstructors();
            Assert.That(constructors, Is.Not.Null);
            Assert.That(constructors, Has.Length.EqualTo(1));
            /* optional property will not show in public constructor signature. */
            Assert.That(constructors[0].GetParameters().Any(p => p.Name == "changedProp"), Is.False);
        }

        [SpectorTest]
        public Task Versioning_MadeOptional_Test() => Test(async (host) =>
        {
            TestModel body = new TestModel("foo");
            var response = await new MadeOptionalClient(host).TestAsync(body);
            Assert.Multiple(() =>
            {
                Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
                Assert.That(response.Value.Prop, Is.EqualTo("foo"));
            });
        });
    }
}

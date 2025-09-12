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
            Assert.IsNotNull(constructors);
            Assert.AreEqual(1, constructors.Length);
            /* optional property will not show in public constructor signature. */
            Assert.False(constructors[0].GetParameters().Any(p => p.Name == "changedProp"));
        }

        [SpectorTest]
        public Task Versioning_MadeOptional_Test() => Test(async (host) =>
        {
            TestModel body = new TestModel("foo");
            var response = await new MadeOptionalClient(host).TestAsync(body);
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual("foo", response.Value.Prop);
        });
    }
}

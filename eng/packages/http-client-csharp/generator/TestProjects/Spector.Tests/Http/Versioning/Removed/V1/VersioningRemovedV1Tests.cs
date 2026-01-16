// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias RemovedV1;
using System;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using RemovedV1::Versioning.Removed;
using RemovedV1::Versioning.Removed.V1;

namespace TestProjects.Spector.Tests.Http.Versioning.Removed.V1
{
    public class VersioningRemovedV1Tests : SpectorTestBase
    {
        [SpectorTest]
        public void TestRemovedMembers()
        {
            var assembly = typeof(RemovedClient).Assembly;
            /* check existence of the removed model ModelV1. */
            var modelV1Type = assembly.GetType("Versioning.Removed.ModelV1");
            Assert.That(modelV1Type, Is.Not.Null);

            /* check existence of the removed enum EnumV1. */
            var enumV1Type = assembly.GetType("Versioning.Removed.EnumV1");
            Assert.That(enumV1Type, Is.Not.Null);

            /* check existence of removed method V1 */
            var removedMethods = typeof(RemovedClient).GetMethods().Where(m => m.Name == "V1" || m.Name == "V1Async");
            Assert.That(removedMethods.Count(), Is.EqualTo(4));

            /* check existence of removed parameter. */
            var v2Methods = typeof(RemovedClient).GetMethods().Where(m => m.Name == "V2" || m.Name == "V2Async");
            Assert.That(v2Methods, Is.Not.Null);
            Assert.That(v2Methods.Count(), Is.EqualTo(4));
            foreach (var method in v2Methods)
            {
                Assert.That(method.GetParameters().Any(p => p.Name == "param"), Is.True);
            }

            /* check existence of removed interface. */
            var interfaceV1Type = assembly.GetType("Versioning.Removed.InterfaceV1");
            Assert.That(interfaceV1Type, Is.Not.Null);

            // Only initial versions is defined
            var enumType = typeof(RemovedClientOptions.ServiceVersion);
            Assert.That(enumType.GetEnumNames(), Is.EqualTo(new string[] { "V1" }));
        }

        [SpectorTest]
        public Task Versioning_Removed_V3Model() => Test(async (host) =>
        {
            var model = new ModelV3("123", EnumV3.EnumMemberV1);
            var response = await new RemovedClient(host).ModelV3Async(model);
            Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
            Assert.That(response.Value.Id, Is.EqualTo("123"));
            Assert.That(response.Value.EnumProp, Is.EqualTo(EnumV3.EnumMemberV1));
        });
    }
}

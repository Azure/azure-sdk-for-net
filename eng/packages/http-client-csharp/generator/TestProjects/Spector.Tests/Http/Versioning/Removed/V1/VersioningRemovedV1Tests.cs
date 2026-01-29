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
            Assert.IsNotNull(modelV1Type);

            /* check existence of the removed enum EnumV1. */
            var enumV1Type = assembly.GetType("Versioning.Removed.EnumV1");
            Assert.IsNotNull(enumV1Type);

            /* check existence of removed method V1 */
            var removedMethods = typeof(RemovedClient).GetMethods().Where(m => m.Name == "V1" || m.Name == "V1Async");
            Assert.AreEqual(4, removedMethods.Count());

            /* check existence of removed parameter. */
            var v2Methods = typeof(RemovedClient).GetMethods().Where(m => m.Name == "V2" || m.Name == "V2Async");
            Assert.IsNotNull(v2Methods);
            Assert.AreEqual(4, v2Methods.Count());
            foreach (var method in v2Methods)
            {
                Assert.IsTrue(method.GetParameters().Any(p => p.Name == "param"));
            }

            /* check existence of removed interface. */
            var interfaceV1Type = assembly.GetType("Versioning.Removed.InterfaceV1");
            Assert.IsNotNull(interfaceV1Type);

            // Only initial versions is defined
            var enumType = typeof(RemovedClientOptions.ServiceVersion);
            Assert.AreEqual(new string[] { "V1" }, enumType.GetEnumNames());
        }

        [SpectorTest]
        public Task Versioning_Removed_V3Model() => Test(async (host) =>
        {
            var model = new ModelV3("123", EnumV3.EnumMemberV1);
            var response = await new RemovedClient(host).ModelV3Async(model);
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual("123", response.Value.Id);
            Assert.AreEqual(EnumV3.EnumMemberV1, response.Value.EnumProp);
        });
    }
}

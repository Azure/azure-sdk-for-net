// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias RemovedV2;
using System;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using RemovedV2::Versioning.Removed;
using RemovedV2::Versioning.Removed.V2;

namespace TestProjects.Spector.Tests.Http.Versioning.Removed.V2
{
    public class VersioningRemovedV2Tests : SpectorTestBase
    {
        [SpectorTest]
        public void TestRemovedMembers()
        {
            /* check existence of the removed model ModelV1. */
            Assert.IsNull(Type.GetType("Versioning.Removed.V2.Models.ModelV1"));

            /* check existence of the removed enum EnumV1. */
            Assert.IsNull(Type.GetType("Versioning.Removed.V2.Models.EnumV1"));

            /* verify ModelV2. */
            var properties = typeof(ModelV2).GetProperties();
            Assert.IsNotNull(properties);
            Assert.AreEqual(3, properties.Length);
            /* verify removed property RemovedProp in V2.*/
            Assert.IsNull(typeof(ModelV2).GetProperty("RemovedProp"));

            /* verify EnumV2 */
            Assert.IsTrue(typeof(EnumV2).IsEnum);
            var enumValues = typeof(EnumV2).GetEnumNames();
            Assert.IsNotNull(enumValues);
            Assert.AreEqual(1, enumValues.Length);
            /* verify added enum value EnumMemberV1. */
            Assert.IsFalse(enumValues.Contains("EnumMemberV1"));

            /* check existence of removed method V1 */
            var removedMethods = typeof(RemovedClient).GetMethods().Where(m => m.Name == "V1" || m.Name == "V1Async");
            Assert.AreEqual(0, removedMethods.Count());

            /* check existence of removed parameter. */
            var v2Methods = typeof(RemovedClient).GetMethods().Where(m => m.Name == "V2" || m.Name == "V2Async");
            Assert.IsNotNull(v2Methods);
            Assert.AreEqual(4, v2Methods.Count());
            foreach (var method in v2Methods)
            {
                Assert.False(method.GetParameters().Any(p => p.Name == "param"));
            }

            /* check existence of removed interface. */
            Assert.IsNull(Type.GetType("Versioning.Removed.V2.InterfaceV1"));

            // All 3 versions are defined
            var enumType = typeof(RemovedClientOptions.ServiceVersion);
            Assert.AreEqual(new string[] { "V1", "V2preview", "V2" }, enumType.GetEnumNames());
        }

        [SpectorTest]
        public Task Versioning_Removed_v2() => Test(async (host) =>
        {
            ModelV2 modelV2 = new ModelV2("foo", EnumV2.EnumMemberV2, BinaryData.FromObjectAsJson("bar"));
            var response = await new RemovedClient(host).V2Async(modelV2);
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual("foo", response.Value.Prop);
            Assert.AreEqual(EnumV2.EnumMemberV2, response.Value.EnumProp);
            Assert.AreEqual("bar", response.Value.UnionProp.ToObjectFromJson<string>());
        });

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

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
            Assert.That(Type.GetType("Versioning.Removed.V2.Models.ModelV1"), Is.Null);

            /* check existence of the removed enum EnumV1. */
            Assert.That(Type.GetType("Versioning.Removed.V2.Models.EnumV1"), Is.Null);

            /* verify ModelV2. */
            var properties = typeof(ModelV2).GetProperties();
            Assert.That(properties, Is.Not.Null);
            Assert.That(properties.Length, Is.EqualTo(3));
            /* verify removed property RemovedProp in V2.*/
            Assert.That(typeof(ModelV2).GetProperty("RemovedProp"), Is.Null);

            /* verify EnumV2 */
            Assert.That(typeof(EnumV2).IsEnum, Is.True);
            var enumValues = typeof(EnumV2).GetEnumNames();
            Assert.That(enumValues, Is.Not.Null);
            Assert.That(enumValues.Length, Is.EqualTo(1));
            /* verify added enum value EnumMemberV1. */
            Assert.That(enumValues.Contains("EnumMemberV1"), Is.False);

            /* check existence of removed method V1 */
            var removedMethods = typeof(RemovedClient).GetMethods().Where(m => m.Name == "V1" || m.Name == "V1Async");
            Assert.That(removedMethods.Count(), Is.EqualTo(0));

            /* check existence of removed parameter. */
            var v2Methods = typeof(RemovedClient).GetMethods().Where(m => m.Name == "V2" || m.Name == "V2Async");
            Assert.That(v2Methods, Is.Not.Null);
            Assert.That(v2Methods.Count(), Is.EqualTo(4));
            foreach (var method in v2Methods)
            {
                Assert.That(method.GetParameters().Any(p => p.Name == "param"), Is.False);
            }

            /* check existence of removed interface. */
            Assert.That(Type.GetType("Versioning.Removed.V2.InterfaceV1"), Is.Null);

            // All 3 versions are defined
            var enumType = typeof(RemovedClientOptions.ServiceVersion);
            Assert.That(enumType.GetEnumNames(), Is.EqualTo(new string[] { "V1", "V2preview", "V2" }));
        }

        [SpectorTest]
        public Task Versioning_Removed_v2() => Test(async (host) =>
        {
            ModelV2 modelV2 = new ModelV2("foo", EnumV2.EnumMemberV2, BinaryData.FromObjectAsJson("bar"));
            var response = await new RemovedClient(host).V2Async(modelV2);
            Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
            Assert.That(response.Value.Prop, Is.EqualTo("foo"));
            Assert.That(response.Value.EnumProp, Is.EqualTo(EnumV2.EnumMemberV2));
            Assert.That(response.Value.UnionProp.ToObjectFromJson<string>(), Is.EqualTo("bar"));
        });

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

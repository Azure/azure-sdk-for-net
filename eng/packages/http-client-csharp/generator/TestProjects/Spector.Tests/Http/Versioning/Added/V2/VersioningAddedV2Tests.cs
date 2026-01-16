// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias VersioningAddedV2;

using System;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using VersioningAddedV2::Versioning.Added;

namespace TestProjects.Spector.Tests.Http.Versioning.Added.V2
{
    public class VersioningAddedV2Tests : SpectorTestBase
    {
        [SpectorTest]
        public void TestAddedMembersV2Client()
        {
            /* verify ModelV1. */
            var properties = typeof(ModelV1).GetProperties();
            Assert.That(properties, Is.Not.Null);
            Assert.That(properties.Length, Is.EqualTo(3));
            /* verify added property UnionProp in V2.*/
            Assert.That(typeof(ModelV1).GetProperty("UnionProp"), Is.Not.Null);

            /* verify EnumV1. */
            Assert.That(typeof(EnumV1).IsEnum, Is.True);
            var enumValues = typeof(EnumV1).GetEnumNames();
            Assert.That(enumValues, Is.Not.Null);
            Assert.That(enumValues.Length, Is.EqualTo(2));
            /* verify added enum value EnumMemberV2. */
            Assert.That(enumValues.Contains("EnumMemberV2"), Is.True);

            /* check existence of the added model ModelV2. */
            var modelV2Type = typeof(ModelV1).Assembly.GetType("Versioning.Added.ModelV2");
            Assert.That(modelV2Type, Is.Not.Null);

            /* check existence of the added enum EnumV2. */
            var enumV2Type = typeof(ModelV1).Assembly.GetType("Versioning.Added.EnumV2");
            Assert.That(enumV2Type, Is.Not.Null);

            /* check the added parameter. */
            var methods = typeof(AddedClient).GetMethods().Where(m => m.Name == "V1" || m.Name == "V1Async");
            Assert.That(methods, Is.Not.Null);
            Assert.That(methods.Count(), Is.EqualTo(4));
            var methodsArray = methods.ToArray();
            foreach (var method in methodsArray)
            {
                Assert.That(method.GetParameters().Any(p => p.Name == "headerV2"), Is.True);
            }

            /* check the existence of added method in V2. */
            var addedMethods = typeof(AddedClient).GetMethods().Where(m => m.Name == "V2" || m.Name == "V2Async");
            Assert.That(addedMethods, Is.Not.Null);
            Assert.That(addedMethods.Count(), Is.EqualTo(4));

            /* check the existence of added interface in V2. */
            var interfaceV2Type = typeof(ModelV1).Assembly.GetType("Versioning.Added.InterfaceV2");
            Assert.That(interfaceV2Type, Is.Not.Null);
        }

        [SpectorTest]
        public Task Versioning_Added_v1() => Test(async (host) =>
        {
            ModelV1 modelV1 = new ModelV1("foo", EnumV1.EnumMemberV2, BinaryData.FromObjectAsJson(10));
            var response = await new AddedClient(host).V1Async("bar", modelV1);
            Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
            Assert.That(response.Value.Prop, Is.EqualTo("foo"));
            Assert.That(response.Value.EnumProp, Is.EqualTo(EnumV1.EnumMemberV2));
            Assert.That(response.Value.UnionProp.ToObjectFromJson<int>(), Is.EqualTo(10));
        });

        [SpectorTest]
        public Task Versioning_Added_v2() => Test(async (host) =>
        {
            ModelV2 modelV2 = new ModelV2("foo", EnumV2.EnumMember, BinaryData.FromObjectAsJson("bar"));
            var response = await new AddedClient(host).V2Async(modelV2);
            Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
            Assert.That(response.Value.Prop, Is.EqualTo("foo"));
            Assert.That(response.Value.EnumProp, Is.EqualTo(EnumV2.EnumMember));
            Assert.That(response.Value.UnionProp.ToObjectFromJson<string>(), Is.EqualTo("bar"));
        });

        [SpectorTest]
        public Task Versioning_Added_InterfaceV2() => Test(async (host) =>
        {
            ModelV2 modelV2 = new ModelV2("foo", EnumV2.EnumMember, BinaryData.FromObjectAsJson("bar"));
            var response = await new AddedClient(host).GetInterfaceV2Client().V2InInterfaceAsync(modelV2);
            Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
            Assert.That(response.Value.Prop, Is.EqualTo("foo"));
            Assert.That(response.Value.EnumProp, Is.EqualTo(EnumV2.EnumMember));
            Assert.That(response.Value.UnionProp.ToObjectFromJson<string>(), Is.EqualTo("bar"));
        });
    }
}

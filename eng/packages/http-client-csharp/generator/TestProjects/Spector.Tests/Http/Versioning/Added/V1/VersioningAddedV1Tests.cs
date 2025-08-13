// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias VersioningAddedV1;

using System;
using System.Linq;
using NUnit.Framework;
using VersioningAddedV1::Versioning.Added;

namespace TestProjects.Spector.Tests.Http.Versioning.Added.V1
{
    public class VersioningAddedV1Tests : SpectorTestBase
    {
        [SpectorTest]
        public void TestAddedMembersV1Client()
        {
            /* verify ModelV1. */
            var properties = typeof(ModelV1).GetProperties();
            Assert.IsNotNull(properties);
            Assert.AreEqual(2, properties.Length);
            /* verify property UnionProp added in V2 is not present.*/
            Assert.IsNull(typeof(ModelV1).GetProperty("UnionProp"));

            /* verify EnumV1. */
            Assert.True(typeof(EnumV1).IsEnum);
            var enumValues = typeof(EnumV1).GetEnumNames();
            Assert.IsNotNull(enumValues);
            Assert.AreEqual(1, enumValues.Length);
            /* verify added enum value EnumMemberV2. */
            Assert.IsFalse(enumValues.Contains("EnumMemberV2"));

            /* check existence of the added model ModelV2. */
            Assert.IsNull(Type.GetType("Versioning.Added.V1.Models.ModelV2"));

            /* check existence of the added enum EnumV2. */
            Assert.IsNull(Type.GetType("Versioning.Added.V1.Models.EnumV2"));

            /* check the added parameter. */
            var methods = typeof(AddedClient).GetMethods().Where(m => m.Name == "V1" || m.Name == "V1Async");
            Assert.IsNotNull(methods);
            Assert.AreEqual(4, methods.Count());
            var methodsArray = methods.ToArray();
            foreach (var method in methodsArray)
            {
                Assert.IsFalse(method.GetParameters().Any(p => p.Name == "headerV2"));
            }

            /* check the existence of added method in V2. */
            var addedMethods = typeof(AddedClient).GetMethods().Where(m => m.Name == "V2" || m.Name == "V2Async");
            Assert.IsEmpty(addedMethods);

            /* check the existence of added interface in V2. */
            Assert.IsNull(Type.GetType("Versioning.Added.V1.InterfaceV2"));
        }
    }
}

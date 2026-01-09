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
            Assert.That(properties, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(properties, Has.Length.EqualTo(2));
                /* verify property UnionProp added in V2 is not present.*/
                Assert.That(typeof(ModelV1).GetProperty("UnionProp"), Is.Null);

                /* verify EnumV1. */
                Assert.That(typeof(EnumV1).IsEnum, Is.True);
            });
            var enumValues = typeof(EnumV1).GetEnumNames();
            Assert.That(enumValues, Is.Not.Null);
            Assert.That(enumValues, Has.Length.EqualTo(1));
            Assert.Multiple(() =>
            {
                /* verify added enum value EnumMemberV2. */
                Assert.That(enumValues.Contains("EnumMemberV2"), Is.False);

                /* check existence of the added model ModelV2. */
                Assert.That(Type.GetType("Versioning.Added.V1.Models.ModelV2"), Is.Null);

                /* check existence of the added enum EnumV2. */
                Assert.That(Type.GetType("Versioning.Added.V1.Models.EnumV2"), Is.Null);
            });

            /* check the added parameter. */
            var methods = typeof(AddedClient).GetMethods().Where(m => m.Name == "V1" || m.Name == "V1Async");
            Assert.That(methods, Is.Not.Null);
            Assert.That(methods.Count(), Is.EqualTo(4));
            var methodsArray = methods.ToArray();
            foreach (var method in methodsArray)
            {
                Assert.That(method.GetParameters().Any(p => p.Name == "headerV2"), Is.False);
            }

            /* check the existence of added method in V2. */
            var addedMethods = typeof(AddedClient).GetMethods().Where(m => m.Name == "V2" || m.Name == "V2Async");
            Assert.Multiple(() =>
            {
                Assert.That(addedMethods, Is.Empty);

                /* check the existence of added interface in V2. */
                Assert.That(Type.GetType("Versioning.Added.V1.InterfaceV2"), Is.Null);
            });
        }
    }
}

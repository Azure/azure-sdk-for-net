// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias RenamedFromV1;

using System;
using System.Linq;
using NUnit.Framework;
using RenamedFromV1::Versioning.RenamedFrom;

namespace TestProjects.Spector.Tests.Http.Versioning.RenamedFrom.V1
{
    public class VersioningRenamedFromV1Tests : SpectorTestBase
    {
        [SpectorTest]
        public void TestRenamedMembersV1Client()
        {
            var assembly = typeof(RenamedFromClient).Assembly;

            /* check that the old model name `OldModel` is present in V1. */
            var oldModel = assembly.GetType("Versioning.RenamedFrom.OldModel");
            Assert.IsNotNull(oldModel);
            var newModel = assembly.GetType("Versioning.RenamedFrom.NewModel");
            Assert.IsNull(newModel);

            /* check the old property of model. */
            var properties = typeof(OldModel).GetProperties();
            Assert.IsNotNull(properties);
            Assert.AreEqual(3, properties.Length);
            Assert.IsNull(typeof(OldModel).GetProperty("NewProp"));
            Assert.IsNotNull(typeof(OldModel).GetProperty("OldProp"));

            /* check that the old enum name `OldEnum` is present in V1. */
            var oldEnum = assembly.GetType("Versioning.RenamedFrom.OldEnum");
            Assert.IsNotNull(oldEnum);
            var newEnum = assembly.GetType("Versioning.RenamedFrom.NewEnum");
            Assert.IsNull(newEnum);

            /* check the old enum value. */
            var enumValues = typeof(OldEnum).GetEnumNames();
            Assert.IsNotNull(enumValues);
            Assert.AreEqual(1, enumValues.Length);
            Assert.IsTrue(enumValues.Contains("OldEnumMember"));
            Assert.IsFalse(enumValues.Contains("NewEnumMember"));

            /* check the old operation name. */
            var oldMethods = typeof(RenamedFromClient).GetMethods().Where(m => m.Name == "OldOp" || m.Name == "OldOpAsync");
            Assert.AreEqual(4, oldMethods.Count());
            var newMethods = typeof(RenamedFromClient).GetMethods().Where(m => m.Name == "NewOp" || m.Name == "NewOpAsync");
            Assert.AreEqual(0, newMethods.Count());

            /* check the old interface name `OldInterface` is present in V1. */
            var oldInterface = assembly.GetType("Versioning.RenamedFrom.OldInterface");
            Assert.IsNotNull(oldInterface);
            var newInterface = assembly.GetType("Versioning.RenamedFrom.NewInterface");
            Assert.IsNull(newInterface);
        }
    }
}

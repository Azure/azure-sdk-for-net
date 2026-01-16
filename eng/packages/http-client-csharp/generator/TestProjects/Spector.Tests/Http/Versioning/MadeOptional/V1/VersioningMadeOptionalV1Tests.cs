// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias MadeOptionalV1;

using System.Linq;
using MadeOptionalV1::Versioning.MadeOptional;
using NUnit.Framework;

namespace TestProjects.Spector.Tests.Http.Versioning.MadeOptional.V1
{
    public class VersioningMadeOptionalV1Tests : SpectorTestBase
    {
        [SpectorTest]
        public void CheckMadeOptionalMembers()
        {
            var constructors = typeof(TestModel).GetConstructors();
            Assert.That(constructors, Is.Not.Null);
            Assert.That(constructors.Length, Is.EqualTo(1));
            /* property will not in public constructor signature. */
            Assert.That(constructors[0].GetParameters().Any(p => p.Name == "changedProp"), Is.True);
        }
    }
}

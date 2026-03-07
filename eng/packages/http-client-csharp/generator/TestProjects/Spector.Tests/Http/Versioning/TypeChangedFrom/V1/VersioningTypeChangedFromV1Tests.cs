// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias TypeChangedFromV1;

using System.Linq;
using NUnit.Framework;
using TypeChangedFromV1::Versioning.TypeChangedFrom;

namespace TestProjects.Spector.Tests.Http.Versioning.TypeChangedFrom.V1
{
    public class VersioningTypeChangedFromV1Tests : SpectorTestBase
    {
        [SpectorTest]
        public void TestTypeChangedFromV1Client()
        {
            /* check that V1 TestModel.ChangedProp is int (the old type). */
            var changedProp = typeof(TestModel).GetProperty("ChangedProp");
            Assert.IsNotNull(changedProp);
            Assert.AreEqual(typeof(int), changedProp!.PropertyType,
                "Expected V1 TestModel.ChangedProp to be of type int (old type)");

            /* check that V1 Test operation accepts int param (the old type). */
            var methods = typeof(TypeChangedFromClient).GetMethods()
                .Where(m => (m.Name == "Test" || m.Name == "TestAsync") &&
                            m.GetParameters().Any(p => p.Name == "param"))
                .ToArray();
            Assert.IsTrue(methods.Length > 0);
            foreach (var method in methods)
            {
                var paramType = method.GetParameters().First(p => p.Name == "param").ParameterType;
                Assert.AreEqual(typeof(int), paramType,
                    "Expected V1 Test method param to be of type int (old type)");
            }
        }
    }
}

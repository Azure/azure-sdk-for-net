// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias ReturnTypeChangedFromV1;

using System.Linq;
using NUnit.Framework;
using ReturnTypeChangedFromV1::Versioning.ReturnTypeChangedFrom;

namespace TestProjects.Spector.Tests.Http.Versioning.ReturnTypeChangedFrom.V1
{
    public class VersioningReturnTypeChangedFromV1Tests : SpectorTestBase
    {
        [SpectorTest]
        public void TestReturnTypeChangedFromV1Client()
        {
            /* check that V1 `Test` returns int (the old return type). */
            var methods = typeof(ReturnTypeChangedFromClient).GetMethods()
                .Where(m => m.Name == "Test" && m.ReturnType.IsGenericType)
                .ToArray();
            Assert.IsTrue(methods.Length > 0);
            var returnTypes = methods.Select(m => m.ReturnType).ToArray();
            /* sync method returns Response<int> */
            Assert.IsTrue(returnTypes.Any(t => t.GetGenericArguments()[0] == typeof(int)),
                "Expected V1 Test method to return Response<int> (old return type)");
        }
    }
}

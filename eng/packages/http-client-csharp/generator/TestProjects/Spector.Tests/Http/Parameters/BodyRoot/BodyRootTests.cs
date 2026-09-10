// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using NUnit.Framework;
using Parameters.BodyRoot;

namespace TestProjects.Spector.Tests.Http.Parameters.BodyRoot
{
    public class BodyRootTests : SpectorTestBase
    {
        [SpectorTest]
        public Task Nested() => Test(async (host) =>
        {
            var body = new NestedParameterBody(new BodyRootModel
            {
                Category = "widget",
                LinkType = "hard",
                WasSuccessful = true
            });

            var response = await new BodyRootClient(host, null).NestedAsync(body);
            Assert.AreEqual(204, response.Status);
        });
    }
}

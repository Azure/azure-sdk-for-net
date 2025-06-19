// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using Server.Path.Single;
using System.Threading.Tasks;

namespace TestProjects.Spector.Tests.Http.Server.Path.Single
{
    public class SingleTests : SpectorTestBase
    {
        [SpectorTest]
        public Task MyOp() => Test(async (host) =>
        {
            var result = await new SingleClient(host, null).MyOpAsync();
            Assert.AreEqual(200, result.Status);
        });
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Parameters.Query;
using NUnit.Framework;

namespace TestProjects.Spector.Tests.Http.Parameters.Query
{
    public class QueryTests : SpectorTestBase
    {
        [SpectorTest]
        public Task Parameters_Query_Constant() => Test(async (host) =>
        {
            var response = await new QueryClient(host, null).GetConstantClient().PostAsync();
            Assert.AreEqual(204, response.Status);
        });
    }
}

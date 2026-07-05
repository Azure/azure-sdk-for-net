// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Client.Clientnamespace;
using Client.Clientnamespace.Second;
using NUnit.Framework;

namespace TestProjects.Spector.Tests.Http.Client.Namespace
{
    public class ClientNamespaceTests : SpectorTestBase
    {
        [SpectorTest]
        public Task FirstClient() => Test(async (host) =>
        {
            var response = await new ClientNamespaceFirstClient(host, null).GetFirstAsync();
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.IsNotNull(response.Value);
        });

        [SpectorTest]
        public Task SecondClient() => Test(async (host) =>
        {
            var response = await new ClientNamespaceSecondClient(host, null).GetSecondAsync();
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.IsNotNull(response.Value);
        });
    }
}
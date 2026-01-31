// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Specs.Azure.Core.Lro.Rpc;
using Azure;
using NUnit.Framework;

namespace TestProjects.Spector.Tests.Http.Azure.Core.Lro.Rpc
{
    public class LongRunningOperation : SpectorTestBase
    {
        [SpectorTest]
        public Task LongRunningRpc_Completed() => Test(async (host) =>
        {
            var option = new GenerationOptions("text");
            var response = await new RpcClient(host, null).LongRunningRpcAsync(WaitUntil.Completed, option);
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual("text data", response.Value.Data);
        });

        [SpectorTest]
        public Task LongRunningRpc_Started() => Test(async (host) =>
        {
            var option = new GenerationOptions("text");
            var response = await new RpcClient(host, null).LongRunningRpcAsync(WaitUntil.Started, option);
            Assert.AreEqual(202, response.GetRawResponse().Status);
            Assert.AreEqual(true, response.GetRawResponse().Headers.TryGetValue("operation-location", out string? operationLocation));
            Assert.AreEqual(true, operationLocation!.Contains("/azure/core/lro/rpc/generations/operations/operation1"));
        });


    }
}
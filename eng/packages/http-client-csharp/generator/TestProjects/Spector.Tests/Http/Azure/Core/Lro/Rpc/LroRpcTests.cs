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
            Assert.Multiple(() =>
            {
                Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
                Assert.That(response.Value.Data, Is.EqualTo("text data"));
            });
        });

        [SpectorTest]
        public Task LongRunningRpc_Started() => Test(async (host) =>
        {
            var option = new GenerationOptions("text");
            var response = await new RpcClient(host, null).LongRunningRpcAsync(WaitUntil.Started, option);
            Assert.That(response.GetRawResponse().Status, Is.EqualTo(202));
            Assert.That(response.GetRawResponse().Headers.TryGetValue("operation-location", out string? operationLocation), Is.EqualTo(true));
            Assert.That(operationLocation!.Contains("/azure/core/lro/rpc/generations/operations/operation1"), Is.EqualTo(true));
        });


    }
}
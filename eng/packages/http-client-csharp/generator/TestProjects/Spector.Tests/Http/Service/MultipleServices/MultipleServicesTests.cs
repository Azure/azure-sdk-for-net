// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using NUnit.Framework;
using Service.MultipleServices.ServiceA;
using Service.MultipleServices.ServiceA.SubNamespace;
using Service.MultipleServices.ServiceB;
using Service.MultipleServices.ServiceB.SubNamespace;

namespace TestProjects.Spector.Tests.Http.Service.MultipleServices
{
    public class MultipleServicesTests : SpectorTestBase
    {
        [SpectorTest]
        public Task ServiceA_OpA() => Test(async (host) =>
        {
            var client = new ServiceAClient(host, new ServiceAClientOptions());
            var operations = client.GetAOperationsClient();
            var response = await operations.OpAAsync();
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task ServiceA_SubOpA() => Test(async (host) =>
        {
            var client = new ServiceAClient(host, new ServiceAClientOptions());
            ASubNamespace subClient = client.GetASubNamespaceClient();
            var response = await subClient.SubOpAAsync();
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task ServiceB_OpB() => Test(async (host) =>
        {
            var client = new ServiceBClient(host, new ServiceBClientOptions());
            var operations = client.GetBOperationsClient();
            var response = await operations.OpBAsync();
            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task ServiceB_SubOpB() => Test(async (host) =>
        {
            var client = new ServiceBClient(host, new ServiceBClientOptions());
            BSubNamespace subClient = client.GetBSubNamespaceClient();
            var response = await subClient.SubOpBAsync();
            Assert.AreEqual(204, response.Status);
        });
    }
}

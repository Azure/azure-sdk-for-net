// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias SrvDrivenV2;
extern alias SrvDrivenV1;
using System.Threading.Tasks;
using NUnit.Framework;
using SrvDrivenV2::Resiliency.ServiceDriven;

namespace TestProjects.Spector.Tests.Http.Resiliency.SrvDriven.V2
{
    public partial class SrvDrivenV2Tests : SpectorTestBase
    {
        private const string ServiceDeploymentV2 = "v2";

        [SpectorTest]
        public Task AddOperation() => Test(async (host) =>
        {
            var client = new ResiliencyServiceDrivenClient(host, ServiceDeploymentV2);
            var response = await client.AddOperationAsync();

            Assert.AreEqual(204, response.Status);
        });

        // This test validates the "new" client behavior when the api version is set to V1.
        [SpectorTest]
        public Task AddOptionalParamFromNone_WithApiVersionV1() => Test(async (host) =>
        {
            var options = new ResiliencyServiceDrivenClientOptions(ResiliencyServiceDrivenClientOptions.ServiceVersion.V1);
            var client = new ResiliencyServiceDrivenClient(host, ServiceDeploymentV2, options);
            var response = await client.FromNoneAsync();

            Assert.AreEqual(204, response.Status);
        });

        // This test validates the "new" client behavior when the api version is set to V2.
        [SpectorTest]
        public Task AddOptionalParamFromNone_WithApiVersionV2() => Test(async (host) =>
        {
            var options = new ResiliencyServiceDrivenClientOptions(ResiliencyServiceDrivenClientOptions.ServiceVersion.V2);
            var client = new ResiliencyServiceDrivenClient(host, ServiceDeploymentV2, options);
            var response = await client.FromNoneAsync("new", cancellationToken: default);

            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task AddOptionalParamFromOneOptional_WithApiVersionV1() => Test(async (host) =>
        {
            var options = new ResiliencyServiceDrivenClientOptions(ResiliencyServiceDrivenClientOptions.ServiceVersion.V1);
            var client = new ResiliencyServiceDrivenClient(host, ServiceDeploymentV2, options);
            var response = await client.FromOneOptionalAsync("optional");

            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task AddOptionalParamFromOneOptional_WithApiVersionV2() => Test(async (host) =>
        {
            var options = new ResiliencyServiceDrivenClientOptions(ResiliencyServiceDrivenClientOptions.ServiceVersion.V2);
            var client = new ResiliencyServiceDrivenClient(host, ServiceDeploymentV2, options);
            var response = await client.FromOneOptionalAsync("optional", "new", cancellationToken: default);

            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task AddOptionalParamFromOneRequired_WithApiVersionV1() => Test(async (host) =>
        {
            var options = new ResiliencyServiceDrivenClientOptions(ResiliencyServiceDrivenClientOptions.ServiceVersion.V1);
            var client = new ResiliencyServiceDrivenClient(host, ServiceDeploymentV2, options);
            var response = await client.FromOneRequiredAsync("required");

            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task AddOptionalParamFromOneRequired_WithApiVersionV2() => Test(async (host) =>
        {
            var options = new ResiliencyServiceDrivenClientOptions(ResiliencyServiceDrivenClientOptions.ServiceVersion.V2);
            var client = new ResiliencyServiceDrivenClient(host, ServiceDeploymentV2, options);
            var response = await client.FromOneRequiredAsync("required", "new", cancellationToken: default);

            Assert.AreEqual(204, response.Status);
        });
    }
}

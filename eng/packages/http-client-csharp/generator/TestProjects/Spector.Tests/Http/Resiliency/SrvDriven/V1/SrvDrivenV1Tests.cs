// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

extern alias SrvDrivenV1;

using System.Threading.Tasks;
using NUnit.Framework;
using SrvDrivenV1::Resiliency.ServiceDriven;

namespace TestProjects.Spector.Tests.Http.Resiliency.SrvDriven.V1
{
    /// <summary>
    /// Contains tests for the service-driven resiliency V1 client.
    /// </summary>
    public partial class SrvDrivenV1Tests : SpectorTestBase
    {
        private const string ServiceDeploymentV1 = "v1";
        private const string ServiceDeploymentV2 = "v2";

        // This test validates the v1 client behavior when both the service deployment and api version are set to V1.
        [SpectorTest]
        public Task AddOptionalParamFromNone_V1Client_V1Service_WithApiVersionV1() => Test(async (host) =>
        {
            var options = new ResiliencyServiceDrivenClientOptions(ResiliencyServiceDrivenClientOptions.ServiceVersion.V1);
            var client = new ResiliencyServiceDrivenClient(host, ServiceDeploymentV1, options);
            var response = await client.FromNoneAsync();

            Assert.AreEqual(204, response.Status);
        });

        // This test validates the v1 client behavior when the service deployment is set to V2 and the api version is set to V1.
        [SpectorTest]
        public Task AddOptionalParamFromNone_V1Client_V2Service_WithApiVersionV1() => Test(async (host) =>
        {
            var options = new ResiliencyServiceDrivenClientOptions(ResiliencyServiceDrivenClientOptions.ServiceVersion.V1);
            var client = new ResiliencyServiceDrivenClient(host, ServiceDeploymentV2, options);
            var response = await client.FromNoneAsync();

            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task AddOptionalParamFromOneOptional_V1Client_V1Service_WithApiVersionV1() => Test(async (host) =>
        {
            var options = new ResiliencyServiceDrivenClientOptions(ResiliencyServiceDrivenClientOptions.ServiceVersion.V1);
            var client = new ResiliencyServiceDrivenClient(host, ServiceDeploymentV1, options);
            var response = await client.FromOneOptionalAsync("optional");

            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task AddOptionalParamFromOneOptional_V1Client_V2Service_WithApiVersionV1() => Test(async (host) =>
        {
            var options = new ResiliencyServiceDrivenClientOptions(ResiliencyServiceDrivenClientOptions.ServiceVersion.V1);
            var client = new ResiliencyServiceDrivenClient(host, ServiceDeploymentV2, options);
            var response = await client.FromOneOptionalAsync("optional", cancellationToken: default);

            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task AddOptionalParamFromOneRequired_V1Client_V1Service_WithApiVersionV1() => Test(async (host) =>
        {
            var options = new ResiliencyServiceDrivenClientOptions(ResiliencyServiceDrivenClientOptions.ServiceVersion.V1);
            var client = new ResiliencyServiceDrivenClient(host, ServiceDeploymentV1, options);
            var response = await client.FromOneRequiredAsync("required");

            Assert.AreEqual(204, response.Status);
        });

        [SpectorTest]
        public Task AddOptionalParamFromOneRequired_V1Client_V2Service_WithApiVersionV1() => Test(async (host) =>
        {
            var options = new ResiliencyServiceDrivenClientOptions(ResiliencyServiceDrivenClientOptions.ServiceVersion.V1);
            var client = new ResiliencyServiceDrivenClient(host, ServiceDeploymentV2, options);
            var response = await client.FromOneRequiredAsync("required");

            Assert.AreEqual(204, response.Status);
        });
    }
}

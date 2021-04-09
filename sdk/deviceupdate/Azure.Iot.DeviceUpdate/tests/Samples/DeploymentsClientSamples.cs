// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.IoT.DeviceUpdate.Models;
using NUnit.Framework;

namespace Azure.IoT.DeviceUpdate.Tests
{
    /// <summary>
    /// Deployment management tests.
    /// </summary>
    /// <seealso cref="SamplesBase{ServiceClientTestEnvironment}"/>
    public class DeploymentsClientSamples : SamplesBase<ServiceClientTestEnvironment>
    {
        private DeploymentsClient CreateClient()
        {
            return new DeploymentsClient(
                TestEnvironment.AccountEndpoint,
                TestEnvironment.InstanceId,
                TestEnvironment.Credential);
        }

        [Test]
        public async Task GetAllDeployments()
        {
            var client = CreateClient();
            AsyncPageable<Deployment> response = client.GetAllDeploymentsAsync();
            Assert.IsNotNull(response);
            int counter = 0;
            await foreach (var item in response)
            {
                Assert.IsNotNull(item);
                counter++;
            }
            Assert.IsTrue(counter > 0);
        }

        [Test]
        public async Task GetDeployment()
        {
            var client = CreateClient();
            var expected = TestEnvironment;
            var response = await client.GetDeploymentAsync(expected.DeploymentId);
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Value);
            var actual = response.Value;
            Assert.AreEqual(expected.DeploymentId, actual.DeploymentId);
            Assert.AreEqual(DeploymentType.Complete, actual.DeploymentType);
            Assert.AreEqual(DeviceGroupType.DeviceGroupDefinitions, actual.DeviceGroupType);
            Assert.AreEqual(expected.Provider, actual.UpdateId.Provider);
            Assert.AreEqual(expected.Model, actual.UpdateId.Name);
            Assert.AreEqual(expected.Version, actual.UpdateId.Version);
        }

        [Test]
        public async Task GetDeployment_NotFound()
        {
            var client = CreateClient();
            try
            {
                await client.GetDeploymentAsync("_fake_");
            }
            catch (RequestFailedException e)
            {
                Assert.AreEqual(404, e.Status);
            }
        }

        [Test]
        public async Task CreateCancelAndDeleteDeployment()
        {
            var client = CreateClient();
            var expected = TestEnvironment;
            var deploymentId = Guid.NewGuid().ToString("N");
            var response = await client.CreateOrUpdateDeploymentAsync(
                               deploymentId,
                               new Deployment(deploymentId, DeploymentType.Complete,
                                   new DateTimeOffset(2020, 1, 1, 0, 0, 0, TimeSpan.Zero),
                                   DeviceGroupType.DeviceGroupDefinitions, new[] { expected.DeviceId },
                                   new UpdateId(expected.Provider, expected.Model, expected.Version)));
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Value);
            Assert.AreEqual(deploymentId, response.Value.DeploymentId);

            response = await client.GetDeploymentAsync(deploymentId);
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Value);
            Assert.AreEqual(deploymentId, response.Value.DeploymentId);
            Assert.IsFalse(response.Value.IsCanceled);

            var status = await client.GetDeploymentStatusAsync(deploymentId);
            Assert.IsNotNull(status);
            Assert.IsNotNull(status.Value);
            Assert.AreEqual(DeploymentState.Active, status.Value.DeploymentState);

            response = await client.CancelDeploymentAsync(deploymentId);
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Value);
            Assert.AreEqual(deploymentId, response.Value.DeploymentId);
            Assert.IsTrue(response.Value.IsCanceled);

            var delete = await client.DeleteDeploymentAsync(deploymentId);
            Assert.IsNotNull(delete);
            Assert.AreEqual(200, delete.Status);

            try
            {
                await client.GetDeploymentStatusAsync(deploymentId);
            }
            catch (RequestFailedException e)
            {
                Assert.AreEqual(404, e.Status);
            }
        }

        [Test]
        public async Task GetDeploymentStatus()
        {
            var client = CreateClient();
            var expected = TestEnvironment;
            var response = await client.GetDeploymentStatusAsync(expected.DeploymentId);
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Value);
            var actual = response.Value;
            Assert.AreEqual(DeploymentState.Active, actual.DeploymentState);
        }

        [Test]
        public async Task GetDeploymentStatus_NotFound()
        {
            var client = CreateClient();
            try
            {
                await client.GetDeploymentStatusAsync("_fake_");
            }
            catch (RequestFailedException e)
            {
                Assert.AreEqual(404, e.Status);
            }
        }

        [Test]
        public async Task GetDeploymentDevices()
        {
            var client = CreateClient();
            var expected = TestEnvironment;
            AsyncPageable<DeploymentDeviceState> response = client.GetDeploymentDevicesAsync(expected.DeploymentId);
            Assert.IsNotNull(response);
            int counter = 0;
            await foreach (var item in response)
            {
                Assert.IsNotNull(item);
                counter++;
            }

            Assert.IsTrue(counter > 0);
        }

        [Test]
        public async Task GetDeploymentDevices_NotFound()
        {
            var client = CreateClient();
            var expected = TestEnvironment;
            AsyncPageable<DeploymentDeviceState> response = client.GetDeploymentDevicesAsync("_fake_");
            Assert.IsNotNull(response);
            try
            {
                await foreach (var _ in response)
                { }
                Assert.Fail("Should have thrown 404");
            }
            catch (RequestFailedException e)
            {
                Assert.AreEqual(404, e.Status);
            }
        }
    }
}

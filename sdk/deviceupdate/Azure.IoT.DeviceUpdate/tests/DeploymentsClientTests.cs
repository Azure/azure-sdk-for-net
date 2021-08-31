// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.IoT.DeviceUpdate.Models;
using NUnit.Framework;

namespace Azure.IoT.DeviceUpdate.Tests
{
    /// <summary>
    /// Deployment management tests.
    /// </summary>
    /// <seealso cref="RecordedTestBase{ServiceClientTestEnvironment}"/>
    public class DeploymentsClientTests : RecordedTestBase<ServiceClientTestEnvironment>
    {
        public DeploymentsClientTests(bool isAsync) : base(isAsync)
        {
            //TODO: https://github.com/Azure/autorest.csharp/issues/689
            TestDiagnostics = false;
        }

        private DeploymentsClient CreateClient()
        {
            return InstrumentClient(new DeploymentsClient(
                TestEnvironment.AccountEndpoint,
                TestEnvironment.InstanceId,
                TestEnvironment.Credential,
                InstrumentClientOptions(new DeviceUpdateClientOptions())
            ));
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

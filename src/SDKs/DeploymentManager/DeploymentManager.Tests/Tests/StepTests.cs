using Management.DeploymentManager.Tests;
using Microsoft.Azure.Management.DeploymentManager;
using Microsoft.Azure.Management.DeploymentManager.Models;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Net;
using Xunit;

namespace DeploymentManager.Tests
{
    public class StepTests : TestBase
    {
        [Fact]
        public void StepsCrudTests()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (var context = MockContext.Start(typeof(StepTests).FullName))
            {
                var resourceClient = DeploymentManagerTestUtilities.GetResourceManagementClient(context, handler);
                var deploymentManagerClient = DeploymentManagerTestUtilities.GetDeploymentManagerClient(context, handler);

                var clientHelper = new DeploymentManagerClientHelper(this, context);

                // Create resource group
                var location = DeploymentManagerTestUtilities.Location;
                clientHelper.TryCreateResourceGroup(location);

                // Test Create step.
                var stepName = "sdk-for-net";
                var stepProperties = new WaitStepProperties()
                {
                    Attributes = new WaitStepAttributes()
                    {
                        Duration = "PT5M"
                    }
                };

                var inputStep = new StepResource(
                    location: location,
                    properties: stepProperties,
                    name: stepName);

                var stepResponse = deploymentManagerClient.Steps.CreateOrUpdate(
                    resourceGroupName: clientHelper.ResourceGroupName,
                    stepName: stepName,
                    stepInfo: inputStep);

                this.ValidateStep(inputStep, stepResponse);

                // Test Get step.
                var getStepResource = deploymentManagerClient.Steps.Get(
                    resourceGroupName: clientHelper.ResourceGroupName,
                    stepName: stepName);

                this.ValidateStep(inputStep, getStepResource);

                // Test Update step.
                ((WaitStepProperties)(getStepResource.Properties)).Attributes.Duration = "PT10M";
                var updatedStepResource = deploymentManagerClient.Steps.CreateOrUpdate(
                    resourceGroupName: clientHelper.ResourceGroupName,
                    stepName: stepName,
                    stepInfo: getStepResource);

                this.ValidateStep(getStepResource, updatedStepResource);

                // Test Delete step.
                deploymentManagerClient.Steps.Delete(
                    resourceGroupName: clientHelper.ResourceGroupName,
                    stepName: stepName);

                var cloudException = Assert.Throws<CloudException>(() => deploymentManagerClient.Steps.Get(
                    resourceGroupName: clientHelper.ResourceGroupName,
                    stepName: stepName));
                Assert.Equal(HttpStatusCode.NotFound, cloudException.Response.StatusCode);

                clientHelper.DeleteResourceGroup();
            }
        }

        private void ValidateStep(StepResource inputStep, StepResource stepResponse)
        {
            Assert.NotNull(stepResponse);
            Assert.Equal(inputStep.Location, stepResponse.Location);
            Assert.Equal(inputStep.Name, stepResponse.Name);

            var stepProperties = stepResponse.Properties as WaitStepProperties;
            Assert.NotNull(stepProperties);
            Assert.Equal(((WaitStepProperties)inputStep.Properties).Attributes.Duration, stepProperties.Attributes.Duration);
        }
    }
}

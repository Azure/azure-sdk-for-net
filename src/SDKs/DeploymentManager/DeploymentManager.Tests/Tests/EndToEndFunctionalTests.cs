using Management.DeploymentManager.Tests;
using Microsoft.Azure.Management.DeploymentManager;
using Microsoft.Azure.Management.DeploymentManager.Models;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using Xunit;

namespace DeploymentManager.Tests
{
    public class EndToEndFunctionalTests : AdmTestBase
    {
        [Fact]
        public void TopologyAndRolloutScenarioTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (var context = MockContext.Start(typeof(EndToEndFunctionalTests).FullName))
            {
                var deploymentManagerClient = DeploymentManagerTestUtilities.GetDeploymentManagerClient(context, handler);

                var clientHelper = new DeploymentManagerClientHelper(this, context);

                // Create resource group
                var location = DeploymentManagerTestUtilities.Location;
                clientHelper.TryCreateResourceGroup(location);

                // Create artifact source
                var artifactSource = this.CreateArtifactSource(artifactSourceName, location, deploymentManagerClient, clientHelper);

                // Test Create service topology.
                var serviceTopologyName = "sdk-for-net";

                var inputTopology = new ServiceTopologyResource(
                    location: location,
                    name: serviceTopologyName,
                    artifactSourceId: artifactSource.Id);

                var createTopologyResponse = deploymentManagerClient.ServiceTopologies.CreateOrUpdate(
                    resourceGroupName: clientHelper.ResourceGroupName,
                    serviceTopologyName: serviceTopologyName,
                    serviceTopologyInfo: inputTopology);

                this.ValidateTopology(inputTopology, createTopologyResponse);

                // Test Get topology.
                var serviceTopology = deploymentManagerClient.ServiceTopologies.Get(
                    resourceGroupName: clientHelper.ResourceGroupName,
                    serviceTopologyName: serviceTopologyName);

                this.ValidateTopology(inputTopology, serviceTopology);

                // Test CRUD operations on services. 
                this.ServiceCrudTests(artifactSource, serviceTopology, location, deploymentManagerClient, clientHelper);

                // Create another artifact source to test update topology.
                artifactSource = this.CreateArtifactSource(updatedArtifactSourceName, location, deploymentManagerClient, clientHelper);

                // Test Update topology.
                serviceTopology.ArtifactSourceId = artifactSource.Id;
                var updatedStepResource = deploymentManagerClient.ServiceTopologies.CreateOrUpdate(
                    resourceGroupName: clientHelper.ResourceGroupName,
                    serviceTopologyName: serviceTopologyName,
                    serviceTopologyInfo: serviceTopology);

                this.ValidateTopology(serviceTopology, updatedStepResource);

                // Test Delete topology.
                deploymentManagerClient.ServiceTopologies.Delete(
                    resourceGroupName: clientHelper.ResourceGroupName,
                    serviceTopologyName: serviceTopologyName);

                var cloudException = Assert.Throws<CloudException>(() => deploymentManagerClient.ServiceTopologies.Get(
                    resourceGroupName: clientHelper.ResourceGroupName,
                    serviceTopologyName: serviceTopologyName));
                Assert.Equal(HttpStatusCode.NotFound, cloudException.Response.StatusCode);

                // Cleanup artifact source
                this.CleanupArtifactSources(location, deploymentManagerClient, clientHelper);

                clientHelper.DeleteResourceGroup();
            }
        }

        private void ServiceCrudTests(
            ArtifactSource artifactSource,
            ServiceTopologyResource serviceTopologyResource,
            string location, 
            AzureDeploymentManagerClient deploymentManagerClient, 
            DeploymentManagerClientHelper clientHelper)
        {
            var serviceName = "Contoso_Service";
            var targetLocation = "East US 2";

            var inputService = new ServiceResource(
                location: location,
                name: serviceName,
                targetLocation: targetLocation,
                targetSubscriptionId: subscriptionId);

            var createServiceResponse = deploymentManagerClient.Services.CreateOrUpdate(
                resourceGroupName: clientHelper.ResourceGroupName,
                serviceTopologyName: serviceTopologyResource.Name,
                serviceName: serviceName,
                serviceInfo: inputService);

            this.ValidateService(inputService, createServiceResponse);

            // Test Get service.
            var service = deploymentManagerClient.Services.Get(
                resourceGroupName: clientHelper.ResourceGroupName,
                serviceTopologyName: serviceTopologyResource.Name,
                serviceName: serviceName);

            this.ValidateService(inputService, service);

            // Test CRUD operations on service units. 
            this.ServiceUnitCrudTests(artifactSource, serviceTopologyResource, serviceName, location, deploymentManagerClient, clientHelper);

            // Test Update service.
            service.TargetSubscriptionId = "1e591dc1-b014-4754-b53b-58b67bcab1cd";
            var updatedService = deploymentManagerClient.Services.CreateOrUpdate(
                resourceGroupName: clientHelper.ResourceGroupName,
                serviceTopologyName: serviceTopologyResource.Name,
                serviceName: serviceName,
                serviceInfo: service);

            this.ValidateService(service, updatedService);

            // Test Delete service.
            deploymentManagerClient.Services.Delete(
                resourceGroupName: clientHelper.ResourceGroupName,
                serviceTopologyName: serviceTopologyResource.Name,
                serviceName: serviceName);

            var cloudException = Assert.Throws<CloudException>(() => deploymentManagerClient.Services.Get(
                resourceGroupName: clientHelper.ResourceGroupName,
                serviceTopologyName: serviceTopologyResource.Name,
                serviceName: serviceName));
            Assert.Equal(HttpStatusCode.NotFound, cloudException.Response.StatusCode);
        }

        private void ServiceUnitCrudTests(
            ArtifactSource artifactSource,
            ServiceTopologyResource serviceTopologyResource,
            string serviceName,
            string location, 
            AzureDeploymentManagerClient deploymentManagerClient, 
            DeploymentManagerClientHelper clientHelper)
        {
            var serviceUnitName = "Contoso_WebApp";
            var targetResourceGroup = "sdk-net-targetResourceGroup";
            var artifacts = new ServiceUnitArtifacts()
            {
                ParametersArtifactSourceRelativePath = "Parameters/WebApp.Parameters.json",
                TemplateArtifactSourceRelativePath = "Templates/WebApp.Template.json"
            };

            var inputServiceUnit = new ServiceUnitResource(
                location: location,
                targetResourceGroup: targetResourceGroup,
                name: serviceUnitName,
                deploymentMode: DeploymentMode.Incremental,
                artifacts: artifacts);

            var createServiceResponse = deploymentManagerClient.ServiceUnits.CreateOrUpdate(
                resourceGroupName: clientHelper.ResourceGroupName,
                serviceTopologyName: serviceTopologyResource.Name,
                serviceName: serviceName,
                serviceUnitName: serviceUnitName,
                serviceUnitInfo: inputServiceUnit);

            this.ValidateServiceUnit(inputServiceUnit, createServiceResponse);

            // Test Get service unit.
            var serviceUnit = deploymentManagerClient.ServiceUnits.Get(
                resourceGroupName: clientHelper.ResourceGroupName,
                serviceTopologyName: serviceTopologyResource.Name,
                serviceName: serviceName,
                serviceUnitName: serviceUnitName);

            this.ValidateServiceUnit(inputServiceUnit, serviceUnit);

            this.RolloutCrudTests(
                serviceTopologyResource.Id,
                artifactSource.Id,
                serviceUnit.Id,
                location,
                deploymentManagerClient,
                clientHelper);

            // Test Update service unit.
            serviceUnit.DeploymentMode = DeploymentMode.Complete;
            serviceUnit.Artifacts.ParametersArtifactSourceRelativePath = "Parameters/WebApp.Parameters.Dup.json";
            serviceUnit.Artifacts.TemplateArtifactSourceRelativePath = "Templates/WebApp.Template.Dup.json";
            var updatedService = deploymentManagerClient.ServiceUnits.CreateOrUpdate(
                resourceGroupName: clientHelper.ResourceGroupName,
                serviceTopologyName: serviceTopologyResource.Name,
                serviceName: serviceName,
                serviceUnitName: serviceUnitName,
                serviceUnitInfo: serviceUnit);

            this.ValidateServiceUnit(serviceUnit, updatedService);

            // Test Delete service unit.
            deploymentManagerClient.ServiceUnits.Delete(
                resourceGroupName: clientHelper.ResourceGroupName,
                serviceTopologyName: serviceTopologyResource.Name,
                serviceName: serviceName,
                serviceUnitName: serviceUnitName);

            clientHelper.DeleteResourceGroup(targetResourceGroup);

            var cloudException = Assert.Throws<CloudException>(() => deploymentManagerClient.ServiceUnits.Get(
                resourceGroupName: clientHelper.ResourceGroupName,
                serviceTopologyName: serviceTopologyResource.Name,
                serviceName: serviceName,
                serviceUnitName: serviceUnitName));
            Assert.Equal(HttpStatusCode.NotFound, cloudException.Response.StatusCode);
        }

        private void RolloutCrudTests(
            string serviceTopologyId,
            string artifactSourceId,
            string serviceUnitId,
            string location, 
            AzureDeploymentManagerClient deploymentManagerClient, 
            DeploymentManagerClientHelper clientHelper)
        {
            var rolloutName = "rollout1";
            var identity = new Identity()
            {
                Type = "userAssigned",
                IdentityIds = new List<string>()
                {
                    "/subscriptions/53012dcb-5039-4e96-8e6c-5d913da1cdb5/resourcegroups/adm-sdk-tests/providers/Microsoft.ManagedIdentity/userassignedidentities/admsdktests"
                }
            };

            var stepGroup = new Step(
                name: "First_Region",
                deploymentTargetId: serviceUnitId);

            var rolloutRequest = new RolloutRequest(
                location: location,
                buildVersion: "1.0.0.0",
                identity: identity,
                targetServiceTopologyId: serviceTopologyId,
                artifactSourceId: artifactSourceId,
                stepGroups: new List<Step>() { stepGroup });

            var createServiceResponse = deploymentManagerClient.Rollouts.CreateOrUpdate(
                resourceGroupName: clientHelper.ResourceGroupName,
                rolloutName: rolloutName,
                rolloutRequest: rolloutRequest);

            this.ValidateRollout(rolloutRequest, createServiceResponse);

            // Test Get rollout.
            var rollout = deploymentManagerClient.Rollouts.Get(
                resourceGroupName: clientHelper.ResourceGroupName,
                rolloutName: rolloutName);

            Assert.NotNull(rollout);
            Assert.Equal("Running", rollout.Status);
            Assert.NotNull(rollout.OperationInfo);
            Assert.Equal(0, rollout.OperationInfo.RetryAttempt);
     
            // Test cancel rollout.
            rollout = deploymentManagerClient.Rollouts.Cancel(
                resourceGroupName: clientHelper.ResourceGroupName,
                rolloutName: rolloutName);

            Assert.NotNull(rollout);
            Assert.Equal("Canceling", rollout.Status);

            this.WaitForRolloutTermination(
                rolloutName,
                deploymentManagerClient,
                clientHelper);

            // Test delete rollout.
            deploymentManagerClient.Rollouts.Delete(
                resourceGroupName: clientHelper.ResourceGroupName,
                rolloutName: rolloutName);

            var cloudException = Assert.Throws<CloudException>(() => deploymentManagerClient.Rollouts.Get(
                resourceGroupName: clientHelper.ResourceGroupName,
                rolloutName: rolloutName));
            Assert.Equal(HttpStatusCode.NotFound, cloudException.Response.StatusCode);
        }

        private void WaitForRolloutTermination(
            string rolloutName,
            AzureDeploymentManagerClient deploymentManagerClient, 
            DeploymentManagerClientHelper clientHelper)
        {
            Rollout rollout;
            do
            {
                Thread.Sleep(TimeSpan.FromMinutes(1));
                rollout = deploymentManagerClient.Rollouts.Get(
                   resourceGroupName: clientHelper.ResourceGroupName,
                   rolloutName: rolloutName);
            } while (rollout.Status == "Running");
        }

        private void ValidateRollout(RolloutRequest rolloutRequest, RolloutRequest rolloutResponse)
        {
            Assert.NotNull(rolloutResponse);
            Assert.Equal(rolloutRequest.Location, rolloutResponse.Location);
            Assert.Equal(rolloutRequest.ArtifactSourceId, rolloutResponse.ArtifactSourceId);
            Assert.Equal(rolloutRequest.TargetServiceTopologyId, rolloutResponse.TargetServiceTopologyId);
            Assert.Equal(rolloutRequest.StepGroups.Count, rolloutResponse.StepGroups.Count);
        }

        private void ValidateServiceUnit(ServiceUnitResource inputServiceUnit, ServiceUnitResource serviceUnitResponse)
        {
            Assert.NotNull(serviceUnitResponse);
            Assert.Equal(inputServiceUnit.Location, serviceUnitResponse.Location);
            Assert.Equal(inputServiceUnit.Name, serviceUnitResponse.Name);
            Assert.Equal(inputServiceUnit.DeploymentMode, serviceUnitResponse.DeploymentMode);
            Assert.Equal(inputServiceUnit.Artifacts.ParametersArtifactSourceRelativePath, serviceUnitResponse.Artifacts.ParametersArtifactSourceRelativePath);
            Assert.Equal(inputServiceUnit.Artifacts.TemplateArtifactSourceRelativePath, serviceUnitResponse.Artifacts.TemplateArtifactSourceRelativePath);
        }

        private void ValidateService(ServiceResource inputService, ServiceResource serviceResponse)
        {
            Assert.NotNull(serviceResponse);
            Assert.Equal(inputService.Location, serviceResponse.Location);
            Assert.Equal(inputService.Name, serviceResponse.Name);
            Assert.Equal(inputService.TargetLocation, serviceResponse.TargetLocation);
            Assert.Equal(inputService.TargetSubscriptionId, serviceResponse.TargetSubscriptionId);
        }

        private void ValidateTopology(ServiceTopologyResource inputTopology, ServiceTopologyResource serviceTopologyResponse)
        {
            Assert.NotNull(serviceTopologyResponse);
            Assert.Equal(inputTopology.Location, serviceTopologyResponse.Location);
            Assert.Equal(inputTopology.Name, serviceTopologyResponse.Name);
            Assert.Equal(inputTopology.ArtifactSourceId, serviceTopologyResponse.ArtifactSourceId);
        }
    }
}

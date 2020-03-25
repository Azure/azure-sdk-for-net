// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace DeploymentManager.Tests
{
    using Management.DeploymentManager.Tests;
    using Microsoft.Azure.Management.DeploymentManager;
    using Microsoft.Azure.Management.DeploymentManager.Models;
    using Microsoft.Azure.Test.HttpRecorder;
    using Microsoft.Rest.Azure;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using System;
    using System.Collections.Generic;
    using System.Net;
    using Xunit;

    public class EndToEndFunctionalTests : TestBase
    {
        private static string subscriptionId;
        private const string ArtifactSourceType = "AzureStorage";
        private const string ArtifactRoot = @"Tests\ArtifactRoot";
        private const string ContainerName = "artifacts";

        private const string ParametersFileName = "Storage.Parameters.json";
        private const string InvalidParametersFileName = "Storage_Invalid.Parameters.json";
        private const string TemplateFileName = "Storage.Template.json";
        private const string ParametersCopyFileName = "Storage.Copy.Parameters.json";
        private const string TemplateCopyFileName = "Storage.Copy.Template.json";

        private const string ParametersArtifactSourceRelativePath = ArtifactRoot + @"\" + ParametersFileName;
        private const string TemplateArtifactSourceRelativePath = ArtifactRoot + @"\" + TemplateFileName;
        private const string InvalidParametersArtifactSourceRelativePath = ArtifactRoot + @"\" + InvalidParametersFileName;
        private const string ParametersCopyArtifactSourceRelativePath = ArtifactRoot + @"\" + ParametersCopyFileName;
        private const string TemplateCopyArtifactSourceRelativePath = ArtifactRoot + @"\" + TemplateCopyFileName;

        /// <summary>
        /// Tests the end to end scenarios by creating all dependent resources that are part of the API.
        /// </summary>
        [Fact]
        public void TopologyAndRolloutScenarioTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (var context = MockContext.Start(typeof(EndToEndFunctionalTests)))
            {
                var deploymentManagerClient = DeploymentManagerTestUtilities.GetDeploymentManagerClient(context, handler);
                var clientHelper = new DeploymentManagerClientHelper(this, context);

                var te = TestEnvironmentFactory.GetTestEnvironment();
                EndToEndFunctionalTests.subscriptionId = te.SubscriptionId;

                var location = clientHelper.GetProviderLocation("Microsoft.DeploymentManager", "serviceTopologies");

                try
                {
                    // Create resource group
                    clientHelper.TryCreateResourceGroup(location);

                    var artifactSourceName = clientHelper.ResourceGroupName + "ArtifactSource";
                    var updatedArtifactSourceName = clientHelper.ResourceGroupName + "UpdatedArtifactSource";
                    var storageAccountName = clientHelper.ResourceGroupName + "stgacct";

                    // Create artifact source
                    var artifactSource = this.CreateArtifactSource(
                        storageAccountName,
                        artifactSourceName,
                        location,
                        deploymentManagerClient,
                        clientHelper,
                        setupContainer: true);

                    // Test Create service topology.
                    var serviceTopologyName = clientHelper.ResourceGroupName + "ServiceTopology";

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
                    artifactSource = this.CreateArtifactSource(
                        storageAccountName,
                        updatedArtifactSourceName,
                        location,
                        deploymentManagerClient,
                        clientHelper);

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
                    this.CleanupArtifactSources(artifactSourceName, location, deploymentManagerClient, clientHelper);
                    this.CleanupArtifactSources(updatedArtifactSourceName, location, deploymentManagerClient, clientHelper);

                    cloudException = Assert.Throws<CloudException>(() => deploymentManagerClient.ArtifactSources.Get(
                        resourceGroupName: clientHelper.ResourceGroupName,
                        artifactSourceName: artifactSourceName));
                    Assert.Equal(HttpStatusCode.NotFound, cloudException.Response.StatusCode);
                }
                finally
                {
                    clientHelper.DeleteResourceGroup();
                }
            }
        }

        private void ServiceCrudTests(
            ArtifactSource artifactSource,
            ServiceTopologyResource serviceTopologyResource,
            string location, 
            AzureDeploymentManagerClient deploymentManagerClient, 
            DeploymentManagerClientHelper clientHelper)
        {
            var serviceName = clientHelper.ResourceGroupName + "Service";
            var targetLocation = location;

            var inputService = new ServiceResource(
                location: location,
                name: serviceName,
                targetLocation: targetLocation,
                targetSubscriptionId: EndToEndFunctionalTests.subscriptionId);

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
            this.ServiceUnitCrudTests(
                artifactSource, 
                serviceTopologyResource, 
                serviceName, 
                location, 
                deploymentManagerClient, 
                clientHelper);

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
            var serviceUnitName = clientHelper.ResourceGroupName + "ServiceUnit";
            var failureServiceUnitName = clientHelper.ResourceGroupName + "InvalidServiceUnit";
            var targetResourceGroup = clientHelper.ResourceGroupName;
            var artifacts = new ServiceUnitArtifacts()
            {
                ParametersArtifactSourceRelativePath = ParametersFileName,
                TemplateArtifactSourceRelativePath = TemplateFileName 
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

            // Create a service unit that fails deployment for failure rollout scenario.
            var invalidArtifacts = new ServiceUnitArtifacts()
            {
                ParametersArtifactSourceRelativePath = InvalidParametersFileName,
                TemplateArtifactSourceRelativePath = TemplateFileName 
            };

            var failureServiceUnitInput = new ServiceUnitResource(
                location: location,
                targetResourceGroup: targetResourceGroup,
                name: failureServiceUnitName,
                deploymentMode: DeploymentMode.Incremental,
                artifacts: invalidArtifacts);

            var failureServiceUnitResponse = deploymentManagerClient.ServiceUnits.CreateOrUpdate(
                resourceGroupName: clientHelper.ResourceGroupName,
                serviceTopologyName: serviceTopologyResource.Name,
                serviceName: serviceName,
                serviceUnitName: failureServiceUnitName,
                serviceUnitInfo: failureServiceUnitInput);
            
            this.ValidateServiceUnit(failureServiceUnitInput, failureServiceUnitResponse);

            // Test Steps CRUD operations along with running a rollout.
            this.StepsCrudTests(
                serviceTopologyResource.Id,
                artifactSource.Id,
                serviceUnit.Id,
                failureServiceUnitResponse.Id,
                location,
                clientHelper,
                deploymentManagerClient);

            // Test Update service unit.
            serviceUnit.DeploymentMode = DeploymentMode.Complete;
            serviceUnit.Artifacts.ParametersArtifactSourceRelativePath = ParametersCopyFileName;
            serviceUnit.Artifacts.TemplateArtifactSourceRelativePath = TemplateCopyFileName;
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

            var cloudException = Assert.Throws<CloudException>(() => deploymentManagerClient.ServiceUnits.Get(
                resourceGroupName: clientHelper.ResourceGroupName,
                serviceTopologyName: serviceTopologyResource.Name,
                serviceName: serviceName,
                serviceUnitName: serviceUnitName));
            Assert.Equal(HttpStatusCode.NotFound, cloudException.Response.StatusCode);

            deploymentManagerClient.ServiceUnits.Delete(
                resourceGroupName: clientHelper.ResourceGroupName,
                serviceTopologyName: serviceTopologyResource.Name,
                serviceName: serviceName,
                serviceUnitName: failureServiceUnitName);
        }

        private void StepsCrudTests(
            string serviceTopologyId,
            string artifactSourceId,
            string serviceUnitId,
            string failureServiceUnitId,
            string location,
            DeploymentManagerClientHelper clientHelper,
            AzureDeploymentManagerClient deploymentManagerClient)
        {
            // Test Create step.
            var stepName = clientHelper.ResourceGroupName + "WaitStep";
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

            this.RolloutCrudTests(
                serviceTopologyId: serviceTopologyId,
                artifactSourceId: artifactSourceId,
                serviceUnitId: serviceUnitId,
                failureServiceUnitId: failureServiceUnitId,
                stepId: getStepResource.Id,
                location: location,
                deploymentManagerClient: deploymentManagerClient,
                clientHelper: clientHelper);

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

        private void RolloutCrudTests(
            string serviceTopologyId,
            string artifactSourceId,
            string serviceUnitId,
            string failureServiceUnitId,
            string stepId,
            string location, 
            AzureDeploymentManagerClient deploymentManagerClient, 
            DeploymentManagerClientHelper clientHelper)
        {
            var rolloutName = clientHelper.ResourceGroupName + "Rollout";
            var failureRolloutName = clientHelper.ResourceGroupName + "FailureRollout";

            var userAssignedIdentity = this.SetManagedIdentity(clientHelper); 

            var identity = new Identity()
            {
                Type = "userAssigned",
                IdentityIds = new List<string>()
                {
                    userAssignedIdentity
                }
            };

            var stepGroup = new Step(
                name: "First_Region",
                deploymentTargetId: serviceUnitId)
            {
                PreDeploymentSteps = new List<PrePostStep> () { new PrePostStep(stepId) }
            };

            var stepGroupForFailureRollout = new Step(
                name: "FirstRegion",
                deploymentTargetId: failureServiceUnitId);

            var rolloutRequest = new RolloutRequest(
                location: location,
                buildVersion: "1.0.0.0",
                identity: identity,
                targetServiceTopologyId: serviceTopologyId,
                artifactSourceId: artifactSourceId,
                stepGroups: new List<Step>() { stepGroup });

            var createRolloutResponse = deploymentManagerClient.Rollouts.CreateOrUpdate(
                resourceGroupName: clientHelper.ResourceGroupName,
                rolloutName: rolloutName,
                rolloutRequest: rolloutRequest);

            this.ValidateRollout(rolloutRequest, createRolloutResponse);

            // Kick off a rollout that would fail to test restart operation.
            var failureRolloutRequest = new RolloutRequest(
                location: location,
                buildVersion: "1.0.0.0",
                identity: identity,
                targetServiceTopologyId: serviceTopologyId,
                artifactSourceId: artifactSourceId,
                stepGroups: new List<Step>() { stepGroupForFailureRollout });

            var failureRolloutResponse = deploymentManagerClient.Rollouts.CreateOrUpdate(
                resourceGroupName: clientHelper.ResourceGroupName,
                rolloutName: failureRolloutName,
                rolloutRequest: failureRolloutRequest);

            this.ValidateRollout(failureRolloutRequest, failureRolloutResponse);

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

            // Check status of rollout expected to fail and attempt restart operation.
            var failureRollout = this.WaitForRolloutTermination(
                failureRolloutName,
                deploymentManagerClient,
                clientHelper);

            Assert.NotNull(failureRollout);
            Assert.Equal("Failed", failureRollout.Status);

            // Test Restart rollout.
            failureRollout = deploymentManagerClient.Rollouts.Restart(
                resourceGroupName: clientHelper.ResourceGroupName,
                rolloutName: failureRolloutName);

            Assert.NotNull(failureRollout);
            Assert.Equal("Running", failureRollout.Status);
            Assert.Equal(1, failureRollout.TotalRetryAttempts);
            Assert.Equal(false.ToString(), failureRollout.OperationInfo.SkipSucceededOnRetry.ToString());
        }

        private Rollout WaitForRolloutTermination(
            string rolloutName,
            AzureDeploymentManagerClient deploymentManagerClient, 
            DeploymentManagerClientHelper clientHelper)
        {
            Rollout rollout;
            do
            {
                DeploymentManagerTestUtilities.Sleep(TimeSpan.FromMinutes(1));
                rollout = deploymentManagerClient.Rollouts.Get(
                   resourceGroupName: clientHelper.ResourceGroupName,
                   rolloutName: rolloutName);
            } while (rollout.Status == "Running");

            return rollout;
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
            Assert.Equal(inputService.TargetSubscriptionId, serviceResponse.TargetSubscriptionId);
        }

        private void ValidateTopology(ServiceTopologyResource inputTopology, ServiceTopologyResource serviceTopologyResponse)
        {
            Assert.NotNull(serviceTopologyResponse);
            Assert.Equal(inputTopology.Location, serviceTopologyResponse.Location);
            Assert.Equal(inputTopology.Name, serviceTopologyResponse.Name);
            Assert.Equal(inputTopology.ArtifactSourceId, serviceTopologyResponse.ArtifactSourceId);
        }

        private string SetManagedIdentity(
            DeploymentManagerClientHelper clientHelper)
        {
            var identityName = clientHelper.ResourceGroupName + "Identity";
            var identityId = clientHelper.CreateManagedIdentity(EndToEndFunctionalTests.subscriptionId, identityName);
            return identityId;
        }

        private ArtifactSource CreateArtifactSource(
            string storageAccountName,
            string artifactSourceName,
            string location, 
            AzureDeploymentManagerClient deploymentManagerClient, 
            DeploymentManagerClientHelper clientHelper,
            bool setupContainer = false)
        {
            if (setupContainer)
            {
                this.SetupContainer(storageAccountName, clientHelper);
            }

            var authentication = new SasAuthentication()
            {
                SasUri = clientHelper.GetBlobContainerSasUri(
                    clientHelper.ResourceGroupName,
                    storageAccountName,
                    containerName: EndToEndFunctionalTests.ContainerName)
            };

            var inputArtifactSource = new ArtifactSource(
                location: location,
                sourceType: EndToEndFunctionalTests.ArtifactSourceType,
                authentication: authentication,
                artifactRoot: EndToEndFunctionalTests.ArtifactRoot,
                name: artifactSourceName);

            var artifactSourceResponse = deploymentManagerClient.ArtifactSources.CreateOrUpdate(
                resourceGroupName: clientHelper.ResourceGroupName,
                artifactSourceName: artifactSourceName,
                artifactSourceInfo: inputArtifactSource);

            this.ValidateArtifactSource(inputArtifactSource, artifactSourceResponse);
            return artifactSourceResponse;
        }

        private void SetupContainer(
            string storageAccountName,
            DeploymentManagerClientHelper clientHelper)
        {
            if (HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                clientHelper.CreateStorageAccount(storageAccountName);
                var storageAccountNameForTemplate = clientHelper.ResourceGroupName + "stgtempl";
                var storageAccountReplacementSymbol = "__STORAGEACCOUNTNAME__";

                this.ReplaceString(storageAccountReplacementSymbol, storageAccountNameForTemplate, ParametersArtifactSourceRelativePath);
                this.ReplaceString(storageAccountReplacementSymbol, storageAccountNameForTemplate, TemplateArtifactSourceRelativePath);
                this.ReplaceString(storageAccountReplacementSymbol, storageAccountNameForTemplate, ParametersCopyArtifactSourceRelativePath);
                this.ReplaceString(storageAccountReplacementSymbol, storageAccountNameForTemplate, TemplateCopyArtifactSourceRelativePath);

                clientHelper.UploadBlob(storageAccountName, ContainerName, ParametersArtifactSourceRelativePath, ParametersArtifactSourceRelativePath);
                clientHelper.UploadBlob(storageAccountName, ContainerName, ParametersCopyArtifactSourceRelativePath, ParametersCopyArtifactSourceRelativePath);
                clientHelper.UploadBlob(storageAccountName, ContainerName, InvalidParametersArtifactSourceRelativePath, InvalidParametersArtifactSourceRelativePath);
                clientHelper.UploadBlob(storageAccountName, ContainerName, TemplateArtifactSourceRelativePath, TemplateArtifactSourceRelativePath);
                clientHelper.UploadBlob(storageAccountName, ContainerName, TemplateCopyArtifactSourceRelativePath, TemplateCopyArtifactSourceRelativePath);
            }
        }

        private void ReplaceRolloutSymbols(
            string rolloutName,
            string targetServiceTopologyId,
            string artifactSourceId,
            string stepId,
            string serviceUnitId,
            string filePath)
        {
            this.ReplaceString("__ROLLOUT_NAME__", rolloutName, filePath);
            this.ReplaceString("__TARGET_SERVICE_TOPOLOGY__", targetServiceTopologyId, filePath);
            this.ReplaceString("__ARTIFACT_SOURCE_ID__", artifactSourceId, filePath);
            this.ReplaceString("__STEP_ID__", stepId, filePath);
            this.ReplaceString("__SERVICE_UNIT_ID__", serviceUnitId, filePath);
        }

        private void ReplaceString(
            string replacementSymbol,
            string replacementValue,
            string filePath)
        {
            if (HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                var fileSystemUtils = new FileSystemUtils();
                var fileContents = fileSystemUtils.ReadFileAsText(filePath);

                fileContents = fileContents.Replace(replacementSymbol, replacementValue);

                fileSystemUtils.WriteFile(filePath, fileContents);
            }
        }

        protected void CleanupArtifactSources(
            string artifactSourceName,
            string location, 
            AzureDeploymentManagerClient deploymentManagerClient, 
            DeploymentManagerClientHelper clientHelper)
        {
            deploymentManagerClient.ArtifactSources.Delete(
                resourceGroupName: clientHelper.ResourceGroupName,
                artifactSourceName: artifactSourceName);
        }

        private void ValidateArtifactSource(ArtifactSource inputArtifactSource, ArtifactSource artifactSourceResponse)
        {
            Assert.NotNull(artifactSourceResponse);
            Assert.Equal(inputArtifactSource.Location, artifactSourceResponse.Location);
            Assert.Equal(inputArtifactSource.Name, artifactSourceResponse.Name);
            Assert.Equal(inputArtifactSource.SourceType, artifactSourceResponse.SourceType);
            Assert.Equal(inputArtifactSource.ArtifactRoot, artifactSourceResponse.ArtifactRoot);
            Assert.Equal(typeof(SasAuthentication), artifactSourceResponse.Authentication.GetType());
        }
    }
}


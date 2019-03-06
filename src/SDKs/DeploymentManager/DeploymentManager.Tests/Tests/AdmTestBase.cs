using System;
using System.Collections.Generic;
using System.Text;
using Management.DeploymentManager.Tests;
using Microsoft.Azure.Management.DeploymentManager;
using Microsoft.Azure.Management.DeploymentManager.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;

namespace DeploymentManager.Tests
{
    public abstract class AdmTestBase : TestBase
    {
        protected const string subscriptionId = "53012dcb-5039-4e96-8e6c-5d913da1cdb5";
        protected const string artifactSourceName = "sdk-for-net-topologyv1";
        protected const string updatedArtifactSourceName = "sdk-for-net-topologyv2";
        protected const string artifactSourceType = "AzureStorage";
        protected const string artifactRoot = "builds/1.0.0.0";

        protected ArtifactSource CreateArtifactSource(
            string artifactSourceName,
            string location, 
            AzureDeploymentManagerClient deploymentManagerClient, 
            DeploymentManagerClientHelper clientHelper)
        {
            var authentication = new SasAuthentication()
            {
                SasUri = clientHelper.GetBlobContainerSasUri()
            };

            var inputArtifactSource = new ArtifactSource(
                location: location,
                sourceType: artifactSourceType,
                authentication: authentication,
                artifactRoot: artifactRoot,
                name: artifactSourceName);

            return deploymentManagerClient.ArtifactSources.CreateOrUpdate(
                resourceGroupName: clientHelper.ResourceGroupName,
                artifactSourceName: artifactSourceName,
                artifactSourceInfo: inputArtifactSource);
        }

        protected void CleanupArtifactSources(
            string location, 
            AzureDeploymentManagerClient deploymentManagerClient, 
            DeploymentManagerClientHelper clientHelper)
        {
            deploymentManagerClient.ArtifactSources.Delete(
                resourceGroupName: clientHelper.ResourceGroupName,
                artifactSourceName: artifactSourceName);
            deploymentManagerClient.ArtifactSources.Delete(
                resourceGroupName: clientHelper.ResourceGroupName,
                artifactSourceName: updatedArtifactSourceName);
        }
    }
}

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
        protected const string artifactSourceName = "sdk-for-net-topologyv1";
        protected const string updatedArtifactSourceName = "sdk-for-net-topologyv2";
        protected const string artifactSourceType = "AzureStorage";
        protected const string artifactRoot = "builds/1.0.0.0";
        protected SasAuthentication authentication = new SasAuthentication("https://sdktests.blob.core.windows.net/artifacts?st=2019-02-25T21%3A41%3A01Z&se=2025-02-26T21%3A41%3A00Z&sp=rl&sv=2018-03-28&sr=c&sig=ikGqTrRIrRB60SwlmGvwxCByQMGERiRGP4cOjFxUdso%3D");

        protected ArtifactSource CreateArtifactSource(
            string artifactSourceName,
            string location, 
            AzureDeploymentManagerClient deploymentManagerClient, 
            DeploymentManagerClientHelper clientHelper)
        {
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

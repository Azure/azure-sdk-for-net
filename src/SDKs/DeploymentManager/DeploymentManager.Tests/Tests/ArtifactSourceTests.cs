using Management.DeploymentManager.Tests;
using Microsoft.Azure.Management.DeploymentManager;
using Microsoft.Azure.Management.DeploymentManager.Models;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace DeploymentManager.Tests
{
    public class ArtifactSourceTests : TestBase
    {
        [Fact]
        public void CreateArtifactSource()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (var context = MockContext.Start(typeof(ArtifactSourceTests).FullName))
            {
                var resourceClient = DeploymentManagerTestUtilities.GetResourceManagementClient(context, handler);
                var deploymentManagerClient = DeploymentManagerTestUtilities.GetDeploymentManagerClient(context, handler);

                var clientHelper = new DeploymentManagerClientHelper(this, context);

                // Create resource group
                var location = DeploymentManagerTestUtilities.Location;
                clientHelper.TryCreateResourceGroup(location);

                // Test Create Artifact Source.
                var artifactSourceName = "sdk-for-net";
                var artifactSourceType = "AzureStorage";
                var artifactRoot = "artifactroot";
                var authentication = new SasAuthentication("https://sdknetstorage.blob.core.windows.net/artifactsource?st=2018-09-24&se=2022-11-15&sp=rl&&sig=eSYYxKf02ox87ZbaK%2Bc62O%2BiL%2FJk3OlI3%2BunqqtlsaM%3D");

                var inputArtifactSource = new ArtifactSource(
                    location: location,
                    sourceType: artifactSourceType,
                    authentication: authentication,
                    artifactRoot: artifactRoot,
                    name: artifactSourceName);

                var artifactSourceResponse = deploymentManagerClient.ArtifactSources.CreateOrUpdate(
                    resourceGroupName: clientHelper.ResourceGroupName,
                    artifactSourceName: artifactSourceName,
                    artifactSourceInfo: inputArtifactSource);

                this.ValidateArtifactSource(inputArtifactSource, artifactSourceResponse);

                // Test Delete Artifact Source.
                var getArtifactSourceResponse = deploymentManagerClient.ArtifactSources.Get(
                    resourceGroupName: clientHelper.ResourceGroupName,
                    artifactSourceName: artifactSourceName);

                this.ValidateArtifactSource(inputArtifactSource, getArtifactSourceResponse);

                // Test Update Artifact Source.
                artifactSourceResponse.ArtifactRoot = "newartifactroot";
                var updatedArtifactSource = deploymentManagerClient.ArtifactSources.CreateOrUpdate(
                    resourceGroupName: clientHelper.ResourceGroupName,
                    artifactSourceName: artifactSourceName,
                    artifactSourceInfo: artifactSourceResponse);

                this.ValidateArtifactSource(artifactSourceResponse, updatedArtifactSource);

                // Test Delete Artifact Source.
                deploymentManagerClient.ArtifactSources.Delete(
                    resourceGroupName: clientHelper.ResourceGroupName,
                    artifactSourceName: artifactSourceName);

                var cloudException = Assert.Throws<CloudException>(() => deploymentManagerClient.ArtifactSources.Get(
                    resourceGroupName: clientHelper.ResourceGroupName,
                    artifactSourceName: artifactSourceName));
                Assert.Equal(HttpStatusCode.NotFound, cloudException.Response.StatusCode);
            }
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

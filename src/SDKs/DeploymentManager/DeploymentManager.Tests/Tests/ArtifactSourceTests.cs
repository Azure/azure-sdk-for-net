using Management.DeploymentManager.Tests;
using Microsoft.Azure.Management.DeploymentManager;
using Microsoft.Azure.Management.DeploymentManager.Models;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Net;
using Xunit;

namespace DeploymentManager.Tests
{
    public class ArtifactSourceTests : TestBase
    {
        [Fact]
        public void ArtifactSourceCrudTests()
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
                var authentication = new SasAuthentication("https://sdktests.blob.core.windows.net/artifacts?st=2019-02-25T21%3A41%3A01Z&se=2025-02-26T21%3A41%3A00Z&sp=rl&sv=2018-03-28&sr=c&sig=ikGqTrRIrRB60SwlmGvwxCByQMGERiRGP4cOjFxUdso%3D");

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

                // Test get Artifact Source.
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

                clientHelper.DeleteResourceGroup();
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

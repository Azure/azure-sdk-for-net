using Microsoft.Orbital.Models;
using Microsoft.Orbital.Tests.Helpers;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Collections.Generic;
using System.Net;
using Xunit;

namespace Microsoft.Orbital.Tests
{
    public class SpacecraftTests : TestBase
    {
        [Fact]
        public void SpacecraftApiTests()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
                var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

                var resourcesClient = GetResourceManagementClientWithHandler(context, handler1);
                var azureOrbitalClient = GetAzureOrbitalClientWithHandler(context, handler2);
                var location = "westus2";

                string resourceGroupName = TestUtilities.GenerateName("csmrg");
                resourcesClient.ResourceGroups.CreateOrUpdate(
                    resourceGroupName,
                    new ResourceGroup()
                    { 
                        Location = location 
                    });

                var spacecraftName = TestUtilities.GenerateName();
                var noradId = "25544";
                var titleLine = "ISS";
                var tleLine1 = "1 25544U 98067A   08264.51782528 -.00002182  00000-0 -11606-4 0  2927";
                var tleLine2 = "2 25544  51.6416 247.4627 0006703 130.5360 325.0288 15.72125391563537";
                var links = new List<SpacecraftLink>()
                    {
                        new SpacecraftLink(45, 45, "uplink", "RHCP"),
                        new SpacecraftLink(55, 55, "downlink", "LHCP")

                    };

                var putSpacecraft = azureOrbitalClient.Orbital.CreateOrUpdateSpacecraft(
                    resourceGroupName,
                    spacecraftName,
                    noradId,
                    location,
                    tags: null,
                    titleLine,
                    tleLine1,
                    tleLine2,
                    links);

                Assert.Equal(spacecraftName, putSpacecraft.Name);
                Assert.Equal(noradId, putSpacecraft.NoradId);
                Assert.Equal(titleLine, putSpacecraft.TitleLine);
                Assert.Equal(tleLine1, putSpacecraft.TleLine1);
                Assert.Equal(tleLine2, putSpacecraft.TleLine2);
                Assert.NotNull(putSpacecraft.Links);

                var getSpacecraft = azureOrbitalClient.Orbital.GetSpacecraft(resourceGroupName, spacecraftName);

                Assert.Equal(spacecraftName, getSpacecraft.Name);
                Assert.Equal(noradId, getSpacecraft.NoradId);
                Assert.Equal(titleLine, getSpacecraft.TitleLine);
                Assert.Equal(tleLine1, getSpacecraft.TleLine1);
                Assert.Equal(tleLine2, getSpacecraft.TleLine2);
                Assert.NotNull(getSpacecraft.Links);

                var listSpacecraftsByResourceGroup = azureOrbitalClient.Orbital.ListSpacecraftsByResourceGroup(resourceGroupName) as List<Spacecraft>;

                Assert.Single(listSpacecraftsByResourceGroup);
                Assert.Equal(spacecraftName, listSpacecraftsByResourceGroup[0].Name);
                Assert.Equal(noradId, listSpacecraftsByResourceGroup[0].NoradId);
                Assert.Equal(titleLine, listSpacecraftsByResourceGroup[0].TitleLine);
                Assert.Equal(tleLine1, listSpacecraftsByResourceGroup[0].TleLine1);
                Assert.Equal(tleLine2, listSpacecraftsByResourceGroup[0].TleLine2);
                Assert.NotNull(listSpacecraftsByResourceGroup[0].Links);

                azureOrbitalClient.Orbital.DeleteSpacecraft(resourceGroupName, spacecraftName);
                listSpacecraftsByResourceGroup = azureOrbitalClient.Orbital.ListSpacecraftsByResourceGroup(resourceGroupName) as List<Spacecraft>;
                Assert.Empty(listSpacecraftsByResourceGroup);

            }
        }
    }
}
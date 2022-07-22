using Microsoft.Orbital.Models;
using Microsoft.Orbital.Tests.Helpers;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Collections.Generic;
using System.Net;
using Xunit;
using EndPoint = Microsoft.Orbital.Models.EndPoint;

namespace Microsoft.Orbital.Tests
{
    public class ContactProfileTests : TestBase
    {
        [Fact]
        public void ContactProfileApiTests()
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


                var contactProfileName = TestUtilities.GenerateName();
                var polarization = "RHCP";
                var direction = "Downlink";
                var gainOverTemperature = 25;
                var eirpdBW = 0;
                var centerFrequencyMHz = 8160;
                var bandwidthMHz = 150;
                var ipAddress = "10.2.0.3";
                var endPointName = "AQUA_directplayback";
                var port = "4000";
                var protocol = "TCP";
                var minimumViableContactDuration = "PT1M";
                var minimumElevationDegrees = 5;
                var autoTrackingConfiguration = AutoTrackingConfiguration.XBand;
                var demodulationConfiguration = "<config factory=\"Attribute\" factoryType=\"generic\">\r\n\t<projectName>quantumRX</projectName>\r\n\t<projectVersion>1.0.0</projectVersion></config>\r\n";

                var links = new List<ContactProfileLink>()
                {
                    new ContactProfileLink(){
                        Polarization = polarization,
                        Direction = direction,
                        GainOverTemperature = gainOverTemperature,
                        EirpdBW = eirpdBW,
                        Channels = new List<ContactProfileLinkChannel>(){
                            new ContactProfileLinkChannel()
                            {
                                CenterFrequencyMHz = centerFrequencyMHz,
                                BandwidthMHz = bandwidthMHz,
                                EndPoint = new EndPoint()
                                {
                                    IpAddress = ipAddress,
                                    EndPointName = endPointName,
                                    Port = port,
                                    Protocol = protocol
                                },
                                ModulationConfiguration = null,
                                DemodulationConfiguration = demodulationConfiguration,
                                EncodingConfiguration = null,
                                DecodingConfiguration = null
                             }}}};

                var putContactProfile = azureOrbitalClient.Orbital.CreateOrUpdateContactProfile(
                    resourceGroupName,
                    contactProfileName,
                    links,
                    location,
                    tags: null,
                    minimumViableContactDuration,
                    minimumElevationDegrees,
                    autoTrackingConfiguration);

                Assert.Equal(contactProfileName, putContactProfile.Name);
                Assert.Equal(minimumElevationDegrees, putContactProfile.MinimumElevationDegrees);
                Assert.Equal(minimumViableContactDuration, putContactProfile.MinimumViableContactDuration);
                Assert.Equal(autoTrackingConfiguration, putContactProfile.AutoTrackingConfiguration);
                Assert.Single(putContactProfile.Links);
                Assert.Equal(polarization, putContactProfile.Links[0].Polarization);
                Assert.Equal(direction, putContactProfile.Links[0].Direction);
                Assert.Equal(gainOverTemperature, putContactProfile.Links[0].GainOverTemperature);
                Assert.Equal(eirpdBW, putContactProfile.Links[0].EirpdBW);
                Assert.Single(putContactProfile.Links[0].Channels);
                Assert.Equal(centerFrequencyMHz, putContactProfile.Links[0].Channels[0].CenterFrequencyMHz);
                Assert.Equal(bandwidthMHz, putContactProfile.Links[0].Channels[0].BandwidthMHz);
                Assert.Equal(demodulationConfiguration, putContactProfile.Links[0].Channels[0].DemodulationConfiguration);
                Assert.NotNull(putContactProfile.Links[0].Channels[0].EndPoint);
                Assert.Equal(ipAddress, putContactProfile.Links[0].Channels[0].EndPoint.IpAddress);
                Assert.Equal(port, putContactProfile.Links[0].Channels[0].EndPoint.Port);
                Assert.Equal(protocol, putContactProfile.Links[0].Channels[0].EndPoint.Protocol);

                var getContactProfile = azureOrbitalClient.Orbital.GetContactProfile(resourceGroupName, contactProfileName);

                Assert.Equal(contactProfileName, getContactProfile.Name);
                Assert.Equal(minimumElevationDegrees, getContactProfile.MinimumElevationDegrees);
                Assert.Equal(minimumViableContactDuration, getContactProfile.MinimumViableContactDuration);
                Assert.Equal(autoTrackingConfiguration, getContactProfile.AutoTrackingConfiguration);
                Assert.Single(getContactProfile.Links);
                Assert.Equal(polarization, getContactProfile.Links[0].Polarization);
                Assert.Equal(direction, getContactProfile.Links[0].Direction);
                Assert.Equal(gainOverTemperature, getContactProfile.Links[0].GainOverTemperature);
                Assert.Equal(eirpdBW, getContactProfile.Links[0].EirpdBW);
                Assert.Single(getContactProfile.Links[0].Channels);
                Assert.Equal(centerFrequencyMHz, getContactProfile.Links[0].Channels[0].CenterFrequencyMHz);
                Assert.Equal(bandwidthMHz, getContactProfile.Links[0].Channels[0].BandwidthMHz);
                Assert.Equal(demodulationConfiguration, getContactProfile.Links[0].Channels[0].DemodulationConfiguration);
                Assert.NotNull(getContactProfile.Links[0].Channels[0].EndPoint);
                Assert.Equal(ipAddress, getContactProfile.Links[0].Channels[0].EndPoint.IpAddress);
                Assert.Equal(port, getContactProfile.Links[0].Channels[0].EndPoint.Port);
                Assert.Equal(protocol, getContactProfile.Links[0].Channels[0].EndPoint.Protocol);

                var listContactProfile = azureOrbitalClient.Orbital.ListContactProfilesByResourceGroup(resourceGroupName);

                Assert.NotNull(listContactProfile);
                Assert.Single(listContactProfile);

                azureOrbitalClient.Orbital.DeleteContactProfile(resourceGroupName, contactProfileName);
                listContactProfile = azureOrbitalClient.Orbital.ListContactProfilesByResourceGroup(resourceGroupName);
                Assert.Empty(listContactProfile);

            }
        }
    }
}
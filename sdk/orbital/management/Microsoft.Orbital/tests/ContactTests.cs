using Microsoft.Orbital.Models;
using Microsoft.Orbital.Tests.Helpers;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Net;
using Xunit;
using EndPoint = Microsoft.Orbital.Models.EndPoint;

namespace Microsoft.Orbital.Tests
{
    public class ContactTests  : TestBase
    {

        [Fact]
        public void ContactApiTests()
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

                //create spacecraft
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

                azureOrbitalClient.Orbital.CreateOrUpdateSpacecraft(
                    resourceGroupName,
                    spacecraftName,
                    noradId,
                    location,
                    tags: null,
                    titleLine,
                    tleLine1,
                    tleLine2,
                    links);

                //create contact profile
                var contactProfileName = TestUtilities.GenerateName();
                var polarization = "RHCP";
                var direction = "Downlink";
                var gainOverTemperature = 25;
                var eirpdBW = 0;
                var centerFrequencyMHz = 8160;
                var bandwidthMHz = 150;
                var ipAddress = "10.2.0.3";
                var endPointName = "directplayback";
                var port = "4000";
                var protocol = "TCP";
                var minimumViableContactDuration = "PT1M";
                var minimumElevationDegrees = 5;
                var autoTrackingConfiguration = AutoTrackingConfiguration.XBand;
                var demodulationConfiguration = "<config factory=\"Attribute\" factoryType=\"generic\">\r\n\t<projectName>quantumRX</projectName>\r\n\t<projectVersion>1.0.0</projectVersion></config>\r\n";

                var contactProfileLinks = new List<ContactProfileLink>()
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

                var contactProfile = azureOrbitalClient.Orbital.CreateOrUpdateContactProfile(
                    resourceGroupName,
                    contactProfileName,
                    contactProfileLinks,
                    location,
                    tags: null,
                    minimumViableContactDuration,
                    minimumElevationDegrees,
                    autoTrackingConfiguration);

                //list available contacts
                var groundStationName = "WESTUS2_0";
                var contactProfileRefrence = new ContactParametersContactProfile(contactProfile.Id);
                var startTime = DateTime.Now.AddDays(2);
                var endTime = startTime.AddDays(1);
                
                var availableContacts = azureOrbitalClient.Orbital.ListAvailableContacts(resourceGroupName, 
                    spacecraftName,
                    contactProfileRefrence, 
                    groundStationName,
                    startTime,
                    endTime);

                Assert.NotNull(availableContacts);

                //schedule contact
                if (availableContacts.Value.Count > 0)
                {
                    var firstAvailableContact = availableContacts.Value[0];
                    var contactName = TestUtilities.GenerateName();
                    var putContact = azureOrbitalClient.Orbital.CreateContact(resourceGroupName,
                        spacecraftName,
                        contactName,
                        new Contact()
                        {
                            ReservationStartTime = (DateTime)firstAvailableContact.RxStartTime,
                            ReservationEndTime = (DateTime)firstAvailableContact.RxEndTime,
                            GroundStationName = groundStationName,
                            ContactProfile = new ContactsPropertiesContactProfile(contactProfile.Id),
                        });

                    Assert.Equal(contactName, putContact.Name);

                    var getContact = azureOrbitalClient.Orbital.GetContact(resourceGroupName, spacecraftName, contactName);
                    Assert.Equal(contactName, getContact.Name);

                    var listContact = azureOrbitalClient.Orbital.ListContactsBySpacecraftName(resourceGroupName, spacecraftName);
                    Assert.Single(listContact);

                    azureOrbitalClient.Orbital.DeleteContact(resourceGroupName, spacecraftName, contactName);
                    listContact = azureOrbitalClient.Orbital.ListContactsBySpacecraftName(resourceGroupName, spacecraftName);
                    Assert.Empty(listContact);
                }
            }
        }
    }
}
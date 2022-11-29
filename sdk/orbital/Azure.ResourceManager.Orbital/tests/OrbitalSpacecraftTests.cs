// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Xml;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Orbital.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Resources.Models;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Azure.ResourceManager.Orbital.Tests
{
    public class OrbitalSpacecraftTests : OrbitalManagementTestBase
    {
        public OrbitalSpacecraftTests(bool isAsync)
            : base(isAsync)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task GetAvailableContacts()
        {
            var location = AzureLocation.WestUS2;
            ResourceGroupResource rg = await CreateResourceGroupAsync(Subscription, "testorbitalrg", location);
            var spacecraftCollection = rg.GetOrbitalSpacecrafts();
            string spacecraftName = Recording.GenerateAssetName("spacecraft");
            // Create Spacecraft
            OrbitalSpacecraftResource spacecraft = await CreateSpacecraftAsync(rg, spacecraftName, location);
            Assert.AreEqual(spacecraftName, spacecraft.Data.Name);
            // Create contact profile
            string contactProfileName = Recording.GenerateAssetName("contact");
            var channels = new List<OrbitalContactProfileLinkChannel>()
            {
                new OrbitalContactProfileLinkChannel("linkChannel", 8160, 150, new OrbitalContactEndpoint(IPAddress.Parse("10.2.0.3"), "directplayback", "50000", OrbitalContactProtocol.Tcp))
                {
                    DemodulationConfiguration = "<config factory=\"Attribute\" factoryType=\"generic\">\r\n\t<projectName>quantumRX</projectName>\r\n\t<projectVersion>1.3.0</projectVersion></config>\r\n"
                }
            };
            var contactProfileData = new OrbitalContactProfileData(location)
            {
                Links =
                {
                    new OrbitalContactProfileLink("profileLink", OrbitalLinkPolarization.Rhcp, OrbitalLinkDirection.Downlink, channels)
                    {
                        GainOverTemperature = 25,
                        EirpdBW = 0
                    }
                },
                MinimumViableContactDuration = XmlConvert.ToTimeSpan("PT1M"),
                MinimumElevationDegrees = 5,
                AutoTrackingConfiguration = AutoTrackingConfiguration.XBand,
                NetworkSubnetId = new ResourceIdentifier("/subscriptions/db1ab6f0-4769-4b27-930e-01e2ef9c123c/resourceGroups/feng_test/providers/Microsoft.Network/virtualNetworks/orbital-network/subnets/orbital")
            };
            var lro = await rg.GetOrbitalContactProfiles().CreateOrUpdateAsync(WaitUntil.Completed, contactProfileName, contactProfileData);
            OrbitalContactProfileResource contactProfile = lro.Value;
            // List available contacts
            var startTime = DateTime.Parse("2022-09-30T15:04:10.4408530Z");
            var endTime = DateTime.Parse("2022-10-02T15:04:10.4408530Z");
            var content = new OrbitalAvailableContactsContent(new WritableSubResource() { Id = contactProfile.Id }, "WESTUS2_0", startTime, endTime);
            var contactsLro = await spacecraft.GetAllAvailableContactsAsync(WaitUntil.Completed, content);
            Assert.Greater(contactsLro.Value.Values.Count, 0);

            // Delete
            await spacecraft.DeleteAsync(WaitUntil.Completed);
        }
    }
}

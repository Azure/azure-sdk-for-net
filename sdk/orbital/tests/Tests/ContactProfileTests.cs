using Microsoft.Azure.Management.Orbital.Models;
using Microsoft.Azure.Management.Orbital.Tests.Helpers;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Xunit;
using EndPoint = Microsoft.Azure.Management.Orbital.Models.EndPoint;

namespace Microsoft.Azure.Management.Orbital.Tests.Tests
{
    public class ContactProfileTests : TestBase
    {
        private RecordedDelegatingHandler handler;
        private AzureOrbitalClient client; 

        public ContactProfileTests()
            : base()
        {
            handler = new RecordedDelegatingHandler { SubsequentStatusCodeToReturn = HttpStatusCode.OK };
        }

        [Fact]
        public void ContactProfileCRUDTests()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                this.client =  GetAzureOrbitalClient(context, handler);

                // create a resource group
                Assert.True(VerifyExistenceOrCreateResourceGroup(this.rgName, this.location));
                               
                // create a contact profile
                CreateContactProfileTest(this.client);

                // get a contact profile that was just created 
                GetContactProfileTest();

                // delete a contact profile 
                DeleteContactProfileTest(this.client);

                // delete a resource group
                DeleteResourceGroupTest();
            }
        }
        internal void DeleteContactProfileTest(AzureOrbitalClient client)
        {
            client.Orbital.DeleteContactProfile(this.rgName, this.contactProfileName);
        }
        private void GetContactProfileTest()
        {
            ContactProfile actual = this.client.Orbital.GetContactProfile(this.rgName, this.contactProfileName);

            if (!this.IsRecording)
            {
                Assert.NotNull(actual);

                Assert.Equal(this.contactProfileName, actual.Name);
            }
        }
        internal ContactProfile CreateContactProfileTest(AzureOrbitalClient client)
        {
            var links = new List<ContactProfileLink>();

            var channel = new List<ContactProfileLinkChannel>();

            var endpoint1 = new EndPoint("10.0.1.0", "AQUA_command", "4000", "TCP");

            var channel1 = new ContactProfileLinkChannel(2106.4063, 0.036, endpoint1, "AQUA_UPLINK_BPSK", "na", "AQUA_CMD_CCSDS", "na");

            channel.Add(channel1);

            links.Add(new ContactProfileLink(
                "RHCP",
                "uplink",
                channel,
                0,
                45));

            ContactProfile actual = client.Orbital.BeginCreateOrUpdateContactProfile(
                this.rgName,
                this.contactProfileName,
                links,
                this.location,
                null,
                "PT1M",
                10,
                "xBand");


            if (!this.IsRecording)
            {
                Assert.NotNull(actual);
            }

            return actual;
        }

        private void DeleteResourceGroupTest()
        {
            DeleteResourceGroup(this.rgName);
        }
    }
}

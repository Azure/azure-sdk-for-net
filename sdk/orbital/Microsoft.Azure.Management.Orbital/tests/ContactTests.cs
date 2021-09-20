using Microsoft.Azure.Management.Orbital.Models;
using Microsoft.Azure.Management.Orbital.Tests.Helpers;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Net;
using Xunit;

namespace Microsoft.Azure.Management.Orbital.Tests.Tests
{
    public class ContactTests  : TestBase
    {
        private RecordedDelegatingHandler handler;

        private AzureOrbitalClient client; 

        public ContactTests()
            : base()
        {
            handler = new RecordedDelegatingHandler { SubsequentStatusCodeToReturn = HttpStatusCode.OK };
        }

        [Fact]
        public void ContactCRUDTests()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                this.client = GetClientWithHandler(context, handler);

                // create a resource group
                Assert.True(VerifyExistenceOrCreateResourceGroup(rgName, this.location));

                /** Contact Test cases **/

                // create a contact profile
                CreateContactTest(this.client);

                // get a contact profile that was just created 
                GetContactTest();

                // delete a contact profile 
                DeleteContactTest();


                // delete a resource group
                DeleteResourceGroupTest();
            }
        }
        private void CreateContactTest(AzureOrbitalClient client)
        {
            SpacecraftTests spacecraftTests = new SpacecraftTests();

            Spacecraft spacecraft = spacecraftTests.CreateSpacecraftTest(client);

            ContactProfileTests contactProfileTests = new ContactProfileTests();

            ContactProfile contactProfile = contactProfileTests.CreateContactProfileTest(client);

            ResourceReference resourceReference = new ResourceReference(contactProfile.Id);


            // get the list of available contacts 
            AvailableContactsListResult availableContacts = this.client.Orbital.ListAvailableContacts(resourceGroupName: rgName,
                                                                                                      spacecraftName: this.spacecraftName,
                                                                                                      contactProfile: new ContactParametersContactProfile(contactProfile.Id),
                                                                                                      groundStationName: this.gsName,
                                                                                                      startTime: this.startTime,
                                                                                                      endTime: this.endTime);
            // create a contact 

            if(availableContacts.Value.Count > 0)
            {
                var firstAvailableContact = availableContacts.Value[0];

                Contact actual = this.client.Orbital.BeginCreateContact(resourceGroupName: rgName,
                                                                        spacecraftName: this.spacecraftName,
                                                                        contactName: this.contactName,
                                                                        properties: new ContactsProperties()
                                                                        {
                                                                            ReservationStartTime = (DateTime)firstAvailableContact.Properties.RxStartTime,
                                                                            ReservationEndTime = (DateTime)firstAvailableContact.Properties.RxEndTime, 
                                                                            GroundStationName = this.gsName,
                                                                            ContactProfile = new ContactsPropertiesContactProfile(contactProfile.Id),
                                                                         });
                Assert.NotNull(actual);
            }

        }
        private void GetContactTest()
        {
            Contact actual = this.client.Orbital.GetContact(rgName, this.spacecraftName, this.contactName);

            if (!this.IsRecording)
            {
                Assert.NotNull(actual);
                Assert.Equal(this.contactName, actual.Name);
            }
        }

        // BVT - Build verification test 
        // UT  - unit tests 

        /** Delete resources **/
        private void DeleteContactTest()
        {
            this.client.Orbital.DeleteContact(rgName, this.spacecraftName, this.contactName);

            //delete spacecraft
            SpacecraftTests spacecraftTests = new SpacecraftTests();
            spacecraftTests.DeleteSpacecraftTest(this.client);

            //delete contact profile
            ContactProfileTests contactProfileTests = new ContactProfileTests();
            contactProfileTests.DeleteContactProfileTest(this.client);

        }
        private void DeleteResourceGroupTest()
        {
            DeleteResourceGroup(rgName);
        }
    }
}
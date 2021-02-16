using Microsoft.Azure.Management.Orbital.Models;
using Microsoft.Azure.Management.Orbital.Tests.Helpers;
using Microsoft.Azure.Test.HttpRecorder;
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
                this.client =  GetAzureOrbitalClient(context, handler);

                // create a resource group
                Assert.True(VerifyExistenceOrCreateResourceGroup(this.rgName, this.location));


                
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
            AvailableContactsListResult availableContacts = this.client.Orbital.ListAvailableContacts(this.rgName, 
                                                                                                        this.spacecraftName, 
                                                                                                        resourceReference, 
                                                                                                        this.gsName, 
                                                                                                        this.startTime, 
                                                                                                        this.endTime);
            // create a contact 

            if(availableContacts.Value.Count > 0)
            {
                var firstAvailableContact = availableContacts.Value[0];

                Contact actual = this.client.Orbital.BeginCreateContact(this.rgName, 
                                                                        this.spacecraftName, 
                                                                        this.contactName, 
                                                                        new Contact(
                                                                            (DateTime)firstAvailableContact.Properties.RxStartTime,
                                                                            (DateTime)firstAvailableContact.Properties.RxEndTime,
                                                                            this.gsName,
                                                                            resourceReference,
                                                                            null,
                                                                            null,
                                                                            this.contactName,
                                                                            null,
                                                                            firstAvailableContact.Properties.RxStartTime,
                                                                            firstAvailableContact.Properties.RxEndTime,
                                                                            firstAvailableContact.Properties.TxStartTime,
                                                                            firstAvailableContact.Properties.TxEndTime,
                                                                            null,
                                                                            firstAvailableContact.Properties.MaximumElevationDegrees,
                                                                            firstAvailableContact.Properties.StartAzimuthDegrees,
                                                                            firstAvailableContact.Properties.EndAzimuthDegrees,
                                                                            firstAvailableContact.Properties.StartElevationDegrees,
                                                                            firstAvailableContact.Properties.EndElevationDegrees,
                                                                            null
                                                                            ));
                Assert.NotNull(actual);
            }

        }
        private void GetContactTest()
        {
            Contact actual = this.client.Orbital.GetContact(this.rgName, this.spacecraftName, this.contactName);

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
            this.client.Orbital.DeleteContact(this.rgName, this.spacecraftName, this.contactName);

            //delete spacecraft
            SpacecraftTests spacecraftTests = new SpacecraftTests();
            spacecraftTests.DeleteSpacecraftTest(this.client);

            //delete contact profile
            ContactProfileTests contactProfileTests = new ContactProfileTests();
            contactProfileTests.DeleteContactProfileTest(this.client);

        }
        private void DeleteResourceGroupTest()
        {
            DeleteResourceGroup(this.rgName);
        }
    }
}

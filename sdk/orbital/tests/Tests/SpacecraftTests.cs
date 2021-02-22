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
using Xunit.Sdk;
using EndPoint = Microsoft.Azure.Management.Orbital.Models.EndPoint;

namespace Microsoft.Azure.Management.Orbital.Tests.Tests
{
    public class SpacecraftTests : TestBase
    {
        private RecordedDelegatingHandler handler;

        private AzureOrbitalClient client;
        
        public SpacecraftTests()
            : base()
        {
            handler = new RecordedDelegatingHandler { SubsequentStatusCodeToReturn = HttpStatusCode.OK };
        }

        [Fact]
        public void SpacecraftCRUDTests()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                this.client =  GetAzureOrbitalClient(context, handler);

                // create a resource group
                Assert.True(VerifyExistenceOrCreateResourceGroup(rgName, this.location));

                // create a spacecraft
                CreateSpacecraftTest(this.client);

                // get a spacecraft that was just created 
                GetSpacecraftTest();

                // delete a spacecraft 
                DeleteSpacecraftTest(this.client);

                // delete a resource group
                DeleteResourceGroupTest();
            }
        }

        /** Spacecraft Test cases **/
        internal Spacecraft CreateSpacecraftTest(AzureOrbitalClient client)
        {
            var links = new List<SpacecraftLink>();
            links.Add(new SpacecraftLink(45, 45, "uplink", "RHCP"));
            links.Add(new SpacecraftLink(55, 55, "downlink", "LHCP"));


            Spacecraft actual = client.Orbital.BeginCreateOrUpdateSpacecraft(
                rgName,
                this.spacecraftName,
                "25544",
                this.location,
                null,
                "ISS",
                "1 25544U 98067A   08264.51782528 -.00002182  00000-0 -11606-4 0  2927",
                "2 25544  51.6416 247.4627 0006703 130.5360 325.0288 15.72125391563537",
                links);

            if (!this.IsRecording)
            {
                Assert.NotNull(actual);
            }

            return actual;
        }
       
        private void GetSpacecraftTest()
        {
            Spacecraft actual = this.client.Orbital.GetSpacecraft(rgName, this.spacecraftName);

            if (!this.IsRecording)
            {
                Assert.NotNull(actual);
                Assert.Equal(this.spacecraftName, actual.Name);
            }
        }
        internal void DeleteSpacecraftTest(AzureOrbitalClient client)
        {
            client.Orbital.DeleteSpacecraft(rgName, this.spacecraftName);
        }
        private void DeleteResourceGroupTest()
        {
            DeleteResourceGroup(rgName);
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Linq;
using Xunit;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;

namespace Compute.Tests
{
    public class CapacityReservationTests : VMTestBase
    {
        [Fact]
        public void TestCapacityReservationOperations()
        {
            string originalTestLocation = Environment.GetEnvironmentVariable("AZURE_VM_TEST_LOCATION");
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", "eastus");
                EnsureClientsInitialized(context);

                string baseRGName = ComputeManagementTestUtilities.GenerateName(TestPrefix);
                string rgName = baseRGName + "CR";
                string crgName = "CRG-1";
                string crName = "CR-1";

                try
                {
                    // Create a capacity reservation group, then get the capacity reservation group and validate that they match
                    CapacityReservationGroup createdCRG = CreateCapacityReservationGroup(rgName, crgName, new List<string> { "1", "2" });
                    CapacityReservationGroup returnedCRG = m_CrpClient.CapacityReservationGroups.Get(rgName, crgName);
                    ValidateCapacityReservationGroup(createdCRG, returnedCRG);

                    createdCRG.Tags = new Dictionary<string, string>() { { "testKey", "testValue" } };
                    returnedCRG = m_CrpClient.CapacityReservationGroups.Update(rgName, crgName, createdCRG.Tags);
                    ValidateCapacityReservationGroup(createdCRG, returnedCRG);

                    //List CapacityReservationGroups by subscription and by resourceGroup
                    var listCRGsResponse = m_CrpClient.CapacityReservationGroups.ListByResourceGroup(rgName);
                    Assert.Single(listCRGsResponse);
                    ValidateCapacityReservationGroup(createdCRG, listCRGsResponse.First());
                    listCRGsResponse = m_CrpClient.CapacityReservationGroups.ListBySubscription();

                    returnedCRG = listCRGsResponse.First(crg => crg.Id == createdCRG.Id);
                    Assert.NotNull(returnedCRG);
                    ValidateCapacityReservationGroup(createdCRG, returnedCRG);

                    //Create CapacityReservation within the CapacityReservationGroup and validate
                    var createdCR = CreateCapacityReservation(rgName, crgName, crName, "Standard_DS1_v2", availabilityZone: "1");
                    var returnedCRWithInstanceView = m_CrpClient.CapacityReservations.Get(rgName, crgName, crName, expand: "instanceView");
                    ValidateCapacityReservation(createdCR, returnedCRWithInstanceView, isInstanceViewIncluded : true);

                    //List CapacityReservations
                    var listCRsResponse = m_CrpClient.CapacityReservations.ListByCapacityReservationGroup(rgName, crgName);
                    Assert.Single(listCRsResponse);
                    ValidateCapacityReservation(createdCR, listCRsResponse.First());

                    //Delete CapacityReservations and CapacityReservations
                    m_CrpClient.CapacityReservations.Delete(rgName, crgName, crName);
                    m_CrpClient.CapacityReservationGroups.Delete(rgName, crgName);

                }
                finally
                {
                    m_ResourcesClient.ResourceGroups.Delete(rgName);
                    Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", originalTestLocation);
                }
            }
        }

        [Fact]
        public void TestNonZonalCapacityReservationGroupInstanceView()
        {
            string originalTestLocation = Environment.GetEnvironmentVariable("AZURE_VM_TEST_LOCATION");
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", "eastus");
                EnsureClientsInitialized(context);

                string baseRGName = ComputeManagementTestUtilities.GenerateName(TestPrefix);
                string rgName = baseRGName + "CR";
                string crgName = "CRG-1";
                string crName = "CR-1";

                try
                {
                    //Create a capacity reservation group, then get the capacity reseravation group and validate that they match
                    CapacityReservationGroup createdCRG = CreateCapacityReservationGroup(rgName, crgName, availabilityZones: null);
                    CapacityReservationGroup returnedCRG = m_CrpClient.CapacityReservationGroups.Get(rgName, crgName);
                    ValidateCapacityReservationGroup(createdCRG, returnedCRG);

                    //Create CapacityReservation within the CapacityReservationGroup and validate
                    var createdCR = CreateCapacityReservation(rgName, crgName, crName, "Standard_DS1_v2");
                    var returnedCR = m_CrpClient.CapacityReservations.Get(rgName, crgName, crName, expand: "instanceView");
                    ValidateCapacityReservation(createdCR, returnedCR, isInstanceViewIncluded: true);

                    // Validate Capacity Reservation group instance view
                    CapacityReservationGroup returnedCRGWithInstanceView = m_CrpClient.CapacityReservationGroups.Get(rgName, crgName, CapacityReservationGroupInstanceViewTypes.InstanceView);
                    ValidateCapacityReservationGroupInstanceView(returnedCRGWithInstanceView, createdCR);

                    //Delete CapacityReservations and CapacityReservationGroups
                    m_CrpClient.CapacityReservations.Delete(rgName, crgName, crName);
                    m_CrpClient.CapacityReservationGroups.Delete(rgName, crgName);

                }
                finally
                {
                    m_ResourcesClient.ResourceGroups.Delete(rgName);
                    Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", originalTestLocation);
                }
            }
        }

        private void ValidateCapacityReservationGroup(CapacityReservationGroup expectedCRG, CapacityReservationGroup actualCRG)
        {
            if (expectedCRG == null)
            {
                Assert.Null(actualCRG);
            }
            else
            {
                Assert.NotNull(actualCRG);
                if (expectedCRG.CapacityReservations == null)
                {
                    Assert.Null(actualCRG.CapacityReservations);
                }
                else
                {
                    Assert.NotNull(actualCRG);
                    Assert.True(actualCRG.CapacityReservations.SequenceEqual(expectedCRG.CapacityReservations));
                }
                Assert.Equal(expectedCRG.Location, actualCRG.Location);
                Assert.Equal(expectedCRG.Name, actualCRG.Name);

                if (expectedCRG.Zones != null)
                {
                    Assert.True(actualCRG.Zones.SequenceEqual(expectedCRG.Zones));
                }
            }
        }

        private void ValidateCapacityReservationGroupInstanceView(CapacityReservationGroup actualCRGWithInstanceView, params CapacityReservation[] expectedCapacityReservationsInInstanceView)
        {
            Assert.NotNull(actualCRGWithInstanceView);
            Assert.Equal(expectedCapacityReservationsInInstanceView.Count(), actualCRGWithInstanceView.InstanceView.CapacityReservations.Count);
            foreach (CapacityReservation capacityReservation in expectedCapacityReservationsInInstanceView)
            {
                Assert.True(actualCRGWithInstanceView.InstanceView.CapacityReservations.FirstOrDefault(cr => cr.Name.Equals(capacityReservation.Name)) != null);
            }
        }

        private void ValidateCapacityReservation(CapacityReservation expectedCR, CapacityReservation actualCR, bool isInstanceViewIncluded = false)
        {
            if (expectedCR == null)
            {
                Assert.Null(actualCR);
            }
            else
            {
                Assert.NotNull(actualCR);
                if (expectedCR.VirtualMachinesAssociated == null)
                {
                    Assert.Null(actualCR.VirtualMachinesAssociated);
                }
                else
                {
                    Assert.NotNull(actualCR);
                    Assert.True(actualCR.VirtualMachinesAssociated.SequenceEqual(expectedCR.VirtualMachinesAssociated));
                }
                Assert.Equal(expectedCR.Location, actualCR.Location);
                Assert.Equal(expectedCR.Name, actualCR.Name);
                Assert.Equal(expectedCR.ReservationId, actualCR.ReservationId);
                Assert.NotNull(actualCR.Sku);
                Assert.Equal(expectedCR.Sku.Name, actualCR.Sku.Name);
                Assert.NotNull(actualCR.PlatformFaultDomainCount);
                Assert.Equal(expectedCR.PlatformFaultDomainCount, actualCR.PlatformFaultDomainCount);
                Assert.Equal(expectedCR.Sku.Capacity, actualCR.Sku.Capacity);
                if(isInstanceViewIncluded)
                {
                    Assert.NotNull(actualCR.InstanceView.UtilizationInfo.CurrentCapacity);
                    Assert.Equal(actualCR.Sku.Capacity, actualCR.InstanceView.UtilizationInfo.CurrentCapacity);
                }
                if (expectedCR.Zones != null)
                {
                    Assert.Equal(1, actualCR.Zones.Count);
                    Assert.True(actualCR.Zones.SequenceEqual(expectedCR.Zones));
                }
            }
        }

    }
}

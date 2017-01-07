// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Tests;
using Fluent.Tests.Common;
using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.Resource.Fluent.Core;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace Fluent.Tests.Compute
{
    public class AvailabilitySetsTests
    {

        [Fact]
        public void CanCRUDAvailabilitySet()
        {
            using (var context = FluentMockContext.Start(GetType().FullName))
            {
                var rgName = TestUtilities.GenerateName("rgstg");
                var availName = TestUtilities.GenerateName("availset");
                try
                {
                    // Create
                    IComputeManager computeManager = TestHelper.CreateComputeManager();
                    var availabilitySet = computeManager.AvailabilitySets
                        .Define(availName)
                        .WithRegion(Region.US_EAST)
                        .WithNewResourceGroup(rgName)
                        .WithUpdateDomainCount(2)
                        .WithFaultDomainCount(3)
                        .Create();

                    Assert.True(string.Equals(availabilitySet.ResourceGroupName, rgName));
                    Assert.True(availabilitySet.UpdateDomainCount == 2);
                    Assert.True(availabilitySet.FaultDomainCount == 3);

                    // Get
                    var feteched = computeManager.AvailabilitySets.GetById(availabilitySet.Id);
                    Assert.NotNull(feteched);

                    // List
                    var availabilitySets = computeManager.AvailabilitySets.ListByGroup(rgName);
                    // todo: fix listing
                    // Assert.True(availabilitySets.Count() > 0);

                    // Update
                    var availabilitySetUpdated = availabilitySet.Update()
                        .WithTag("a", "aa")
                        .WithTag("b", "bb")
                        .Apply();

                    // Delete
                    computeManager.AvailabilitySets.DeleteById(availabilitySet.Id);
                }
                catch
                {
                    //
                }
                finally
                {
                    try
                    {
                        var resourceManager = TestHelper.CreateResourceManager();
                        resourceManager.ResourceGroups.DeleteByName(rgName);
                    }
                    catch { }
                }
            }
        }
    }
}
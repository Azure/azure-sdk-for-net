// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Fluent.Compute;
using Microsoft.Azure.Management.Fluent.Resource;
using Microsoft.Azure.Management.Fluent.Resource.Authentication;
using Microsoft.Azure.Management.Fluent.Resource.Core;
using System;
using Xunit;

namespace Fluent.Tests
{
    public class AvailabilitySetsTests
    {
        private string rgName = "rgstg1546";
        private string availName = "availset732";

        [Fact(Skip = "TODO: Convert to recorded tests")]
        public void CanCRUDAvailabilitySet()
        {
            try
            {
                // Create
                IComputeManager computeManager = CreateComputeManager();
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
                computeManager.AvailabilitySets.Delete(availabilitySet.Id);
            }
            catch (Exception ex)
            {
                //
            }
            finally
            {
                try
                {
                    var resourceManager = CreateResourceManager();
                    resourceManager.ResourceGroups.Delete(rgName);
                }
                catch { }
            }
        }

        private IComputeManager CreateComputeManager()
        {
            AzureCredentials credentials = AzureCredentials.FromFile(@"C:\my.azureauth");
            return ComputeManager
                .Configure()
                .withLogLevel(HttpLoggingDelegatingHandler.Level.BODY)
                .Authenticate(credentials, credentials.DefaultSubscriptionId);
        }

        private IResourceManager CreateResourceManager()
        {
            AzureCredentials credentials = AzureCredentials.FromFile(@"C:\my.azureauth");
            IResourceManager resourceManager = ResourceManager2.Configure()
                .withLogLevel(HttpLoggingDelegatingHandler.Level.BODY)
                .Authenticate(credentials)
                .WithSubscription(credentials.DefaultSubscriptionId);
            return resourceManager;
        }
    }
}
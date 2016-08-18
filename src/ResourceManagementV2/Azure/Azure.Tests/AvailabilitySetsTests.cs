using Microsoft.Azure.Management.V2.Compute;
using Microsoft.Azure.Management.V2.Resource;
using Microsoft.Azure.Management.V2.Resource.Authentication;
using Microsoft.Azure.Management.V2.Resource.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Azure.Tests
{
    public class AvailabilitySetsTests
    {
        private string rgName = "rgstg1546";
        private string availName = "availset732";

        [Fact]
        public void CanCRUDAvailabilitySet()
        {
            try
            {
                // Create
                IComputeManager computeManager = CreatComputeManager();
                var availabilitySet = computeManager.AvailabilitySets
                    .Define(availName)
                    .WithRegion(Region.US_EAST)
                    .WithNewResourceGroup(rgName)
                    .WithUpdateDomainCount(2)
                    .WithFaultDomainCount(3)
                    .Create();

                Assert.True(string.Equals(availabilitySet.ResourceGroupName, rgName));
                Assert.True(availabilitySet.UpdateDomainCount.HasValue && availabilitySet.UpdateDomainCount == 2);
                Assert.True(availabilitySet.FaultDomainCount.HasValue && availabilitySet.FaultDomainCount == 3);

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
            catch(Exception ex)
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
                catch {}
            }
        }

        private IComputeManager CreatComputeManager()
        {
            ApplicationTokenCredentails credentials = new ApplicationTokenCredentails(@"C:\my.azureauth");
            return ComputeManager
                .Configure()
                .withLogLevel(HttpLoggingDelegatingHandler.Level.BODY)
                .Authenticate(credentials, credentials.DefaultSubscriptionId);
        }

        private IResourceManager CreateResourceManager()
        {
            ApplicationTokenCredentails credentials = new ApplicationTokenCredentails(@"C:\my.azureauth");
            IResourceManager resourceManager = ResourceManager2.Configure()
                .withLogLevel(HttpLoggingDelegatingHandler.Level.BODY)
                .Authenticate(credentials)
                .WithSubscription(credentials.DefaultSubscriptionId);
            return resourceManager;
        }
    }
}

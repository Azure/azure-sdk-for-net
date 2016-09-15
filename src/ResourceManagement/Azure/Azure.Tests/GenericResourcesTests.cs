using Microsoft.Azure.Management.V2.Resource;
using Microsoft.Azure.Management.V2.Resource.Authentication;
using Microsoft.Azure.Management.V2.Resource.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Azure.Tests
{
    public class GenericResourcesTests
    {

        private string resourceName = "rgweb955";
        private string rgName = "csmrg720";
        private string newRgName = "csmrg189";

        [Fact(Skip = "TODO: Convert to recorded tests")]
        public void CanCreateUpdateMoveResource()
        {
            IResourceManager resourceManager = CreateResourceManager();
            IGenericResources genericResources = resourceManager.GenericResources;

            IGenericResource resource = genericResources.Define(resourceName)
                .WithRegion(Region.US_EAST)
                .WithNewResourceGroup(rgName)
                .WithResourceType("sites")
                .WithProviderNamespace("Microsoft.Web")
                .WithoutPlan()
                .WithApiVersion("2015-08-01")
                .WithParentResource("")
                .WithProperties(JsonConvert.DeserializeObject("{\"SiteMode\":\"Limited\",\"ComputeMode\":\"Shared\"}"))
                .Create();

            // List
            var found = (from r in genericResources.ListByGroup(rgName)
                         where string.Equals(r.Name, resourceName, StringComparison.OrdinalIgnoreCase)
                         select r).FirstOrDefault();
            Assert.NotNull(found);

            // Get
            resource = genericResources.Get(rgName, 
                resource.ResourceProviderNamespace,
                resource.ParentResourceId,
                resource.ResourceType,
                resource.Name,
                resource.ApiVersion);

            // Move
            IResourceGroup newGroup = resourceManager
                .ResourceGroups
                .Define(newRgName)
                .WithRegion(Region.US_EAST)
                .Create();
            genericResources.MoveResources(rgName, newGroup, new List<string>
            {
                resource.Id
            });

            // Check existence [TODO: Server returned "MethodNotAllowed" for CheckExistence call]
            /*bool exists = genericResources.CheckExistence(newRgName,
                resource.ResourceProviderNamespace,
                resource.ParentResourceId,
                resource.ResourceType,
                resource.Name,
                resource.ApiVersion);

            Assert.True(exists);
            */

            // Get and update
            resource = genericResources.Get(newRgName,
                resource.ResourceProviderNamespace,
                resource.ParentResourceId,
                resource.ResourceType,
                resource.Name,
                resource.ApiVersion);
            resource.Update()
                .WithApiVersion("2015-08-01")
                .WithProperties(JsonConvert.DeserializeObject("{\"SiteMode\":\"Limited\",\"ComputeMode\":\"Dynamic\"}"))
                .Apply();
        }

        private IResourceManager CreateResourceManager()
        {
            ApplicationTokenCredentials credentials = new ApplicationTokenCredentials(@"C:\my.azureauth");
            IResourceManager resourceManager = ResourceManager2.Configure()
                .withLogLevel(HttpLoggingDelegatingHandler.Level.BODY)
                .Authenticate(credentials)
                .WithSubscription(credentials.DefaultSubscriptionId);
            return resourceManager;
        }
    }
}


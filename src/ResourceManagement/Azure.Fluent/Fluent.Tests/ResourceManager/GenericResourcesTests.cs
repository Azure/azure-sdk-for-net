// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Azure.Tests;
using Fluent.Tests.Common;
using Microsoft.Azure.Management.Resource.Fluent;
using Microsoft.Azure.Management.Resource.Fluent.Core;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Fluent.Tests.ResourceManager
{
    public class GenericResourcesTests
    {

        private string resourceName = "rgweb955";
        private string rgName = "csmrg720";
        private string newRgName = "csmrg189";

        [Fact]
        public void CanCreateUpdateMoveResource()
        {
            using (var context = FluentMockContext.Start(this.GetType().FullName))
            {
                IResourceManager resourceManager = TestHelper.CreateResourceManager();
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
        }
    }
}


using Microsoft.Azure.Management.V2.Resource;
using Microsoft.Azure.Management.V2.Resource.Authentication;
using Microsoft.Azure.Management.V2.Resource.ResourceGroup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Microsoft.Azure.Management.V2.Resource.Core;

namespace Azure.Tests
{
    public class Class1
    {
        [Fact]

        public void FirstTest()
        {
            Assert.True(true);

            string subscriptionId = "";
            ApplicationTokenCredentails credentials = null;

            IResourceManager resourceManager = ResourceManager2.Configure()
                .withLogLevel(HttpLoggingDelegatingHandler.Level.BODY)
                .Authenticate(credentials)
                .WithSubscription(subscriptionId);

            var resourceGroup = resourceManager.ResourceGroups
                .Define("")
                .WithRegion("west us")
                .CreateAsync().Result;

            resourceGroup.Update()
                .WithTag("", "")
                .ApplyAsync().Wait();




        }
    }
}

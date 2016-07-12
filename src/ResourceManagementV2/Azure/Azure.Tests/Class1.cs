using Microsoft.Azure.Management.V2.Resource;
using Microsoft.Azure.Management.V2.Resource.Authentication;
using Microsoft.Azure.Management.V2.Resource.ResourceGroup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Microsoft.Azure.Management.V2.Resource.Core;
using Microsoft.Azure.Management.V2.Storage;

namespace Azure.Tests
{
    public class Class1
    {
        [Fact]

        public void FirstTest()
        {
            string tenantId = "";
            string clientId = "";
            string clientSecret = "";
            string subscriptionId = "";

            ApplicationTokenCredentails credentials = new ApplicationTokenCredentails(tenantId, 
                clientId, 
                clientSecret);

            /**
            IResourceManager resourceManager = ResourceManager2.Configure()
                .withLogLevel(HttpLoggingDelegatingHandler.Level.BODY)
                .Authenticate(credentials)
                .WithSubscription(subscriptionId);

            var resourceGroup = resourceManager.ResourceGroups
                .Define("mynewrg")
                .WithRegion("west us")
                .CreateAsync().Result;
            **/

            IStorageManager storageManager = StorageManager
                .Configure()
                .withLogLevel(HttpLoggingDelegatingHandler.Level.BODY)
                .Authenticate(credentials, subscriptionId);


            var storageAccount = storageManager.StorageAccounts
                .Define("anuredbluv")
                .WithRegion("east us")
                .WithNewResourceGroup("myrg123")
                .CreateAsync().Result;

            Console.WriteLine(storageAccount);
        }
    }
}

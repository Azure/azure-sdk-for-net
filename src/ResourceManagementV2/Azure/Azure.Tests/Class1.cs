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
            ApplicationTokenCredentails credentials = new ApplicationTokenCredentails(@"C:\my.azureauth");
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
                .Authenticate(credentials, credentials.SubscriptionId);

            var storageAccount = storageManager.StorageAccounts
                .Define("anuredbluv")
                .WithRegion("east us")
                .WithNewResourceGroup("myrg123")
                .CreateAsync().Result;

            Console.WriteLine(storageAccount);
        }
    }
}

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
using Microsoft.Azure.Management.V2.Compute;
using Microsoft.Azure.Management;

namespace AzureTests
{
    public class Class1
    {
        [Fact]

        public void FirstTest()
        {
            ApplicationTokenCredentails credentials = new ApplicationTokenCredentails(@"C:\my.azureauth");

            /*IComputeManager computeManager = ComputeManager
                .Configure()
                .withLogLevel(HttpLoggingDelegatingHandler.Level.BODY)
                .Authenticate(credentials, credentials.DefaultSubscriptionId);

           computeManager.VirtualMachines.List();*/ 

            /**
            IResourceManager resourceManager = ResourceManager2.Configure()
                .withLogLevel(HttpLoggingDelegatingHandler.Level.BODY)
                .Authenticate(credentials)
                .WithSubscription(credentials.DefaultSubscriptionId);

            resourceManager.ResourceGroups
                .Define("mynewrg")
                .WithRegion(Region.US_WEST)
                .CreateAsync().ContinueWith((Task<IResourceGroup> result) =>
                {
                    Console.WriteLine(result.Result.ProvisioningState);
                }).Wait();
            **/

            IStorageManager storageManager = StorageManager
                .Configure()
                .withLogLevel(HttpLoggingDelegatingHandler.Level.BODY)
                .Authenticate(credentials, credentials.DefaultSubscriptionId);

            var storageAccount = storageManager.StorageAccounts
                .Define("anuredbluv")
                .WithRegion("east us")
                .WithNewResourceGroup("myrg123")
                .CreateAsync().Result;

            Console.WriteLine(storageAccount);
        }
    }
}

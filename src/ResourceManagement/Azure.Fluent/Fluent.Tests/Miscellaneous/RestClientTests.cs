// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management;
using Microsoft.Azure.Management.Fluent.Resource;
using Microsoft.Azure.Management.Fluent.Resource.Authentication;
using Microsoft.Azure.Management.Fluent.Resource.Core;
using Microsoft.Azure.Management.Fluent.Storage;
using Microsoft.Rest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Fluent.Tests.Miscellaneous
{
    public class RestClientTests
    {
        private string rgName = ResourceNamer.RandomResourceName("rg", 15);
        private string stgName = ResourceNamer.RandomResourceName("stg", 15);

        [Fact(Skip = "TODO: Convert to recorded tests")]
        public void CanSetMultipleDelegateHandlers()
        {
            // Sets the intercepter so that logging and user agent in log can be asserted.
            var logAndUserAgentInterceptor = new LogAndUserAgentInterceptor();
            ServiceClientTracing.AddTracingInterceptor(logAndUserAgentInterceptor);
            ServiceClientTracing.IsEnabled = true;
            try
            {
                AzureCredentials credentials = AzureCredentials.FromFile(@"C:\my2.azureauth");
                credentials.WithDefaultSubscription(null); // Clearing subscriptionId loaded from the auth 
                                                           // file so that below WithDefaultSubscription() 
                                                           // will force listing subscriptions and fetching
                                                           // the first.
                var azure = Azure
                    .Configure()
                    .WithUserAgent("azure-fluent-test", "1.0.0-prelease")
                    .WithLogLevel(HttpLoggingDelegatingHandler.Level.BODY)
                    .Authenticate(credentials)
                    .WithDefaultSubscription();

                IStorageAccount storageAccount = azure.StorageAccounts
    .               Define(stgName)
    .               WithRegion(Region.US_EAST)
                   .WithNewResourceGroup(rgName)
                   .Create();

                Assert.True(string.Equals(storageAccount.ResourceGroupName, rgName));
                azure.ResourceGroups.Delete(rgName);
            }
            catch
            {

            }
            finally
            {
                ServiceClientTracing.RemoveTracingInterceptor(logAndUserAgentInterceptor);
                ServiceClientTracing.IsEnabled = false;
            }
            Assert.True(logAndUserAgentInterceptor.FoundUserAgentInLog);
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Management.FrontDoor;
using Microsoft.Azure.Management.FrontDoor.Models;
using Microsoft.Rest;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using FrontDoor.Tests.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using Xunit;
using System.Threading;
using Microsoft.Azure.Test.HttpRecorder;

namespace FrontDoor.Tests.Helpers
{
    public static class FrontDoorTestUtilities
    {
        public static bool IsTestTenant = false;
        private static HttpClientHandler Handler = null;

        // These should be filled in only if test tenant is true
        public static string certName = null;
        public static string certPassword = null;
        private static string testSubscription = null;
        private static Uri testUri = null;

        // These are used to create default accounts
        public static string DefaultLocation = IsTestTenant ? null : "westus";

        public static ResourceManagementClient GetResourceManagementClient(MockContext context, RecordedDelegatingHandler handler)
        {
            if (IsTestTenant)
            {
                return null;
            }
            else
            {
                handler.IsPassThrough = true;
                ResourceManagementClient resourcesClient = context.GetServiceClient<ResourceManagementClient>(handlers: handler);
                return resourcesClient;
            }
        }

        public static FrontDoorManagementClient GetFrontDoorManagementClient(MockContext context, RecordedDelegatingHandler handler)
        {
            FrontDoorManagementClient frontDoorClient;
            if (IsTestTenant)
            {
                frontDoorClient = new FrontDoorManagementClient(new TokenCredentials("xyz"), GetHandler());
                frontDoorClient.SubscriptionId = testSubscription;
                frontDoorClient.BaseUri = testUri;
            }
            else
            {
                handler.IsPassThrough = true;
                frontDoorClient = context.GetServiceClient<FrontDoorManagementClient>(handlers: handler);
            }
            return frontDoorClient;
        }

        private static HttpClientHandler GetHandler()
        {
            return Handler;
        }

        public static string CreateResourceGroup(ResourceManagementClient resourcesClient)
        {
            const string testPrefix = "FrontDoorResourceGroup";
            var rgname = TestUtilities.GenerateName(testPrefix);

            if (!IsTestTenant)
            {
                var resourceGroup = resourcesClient.ResourceGroups.CreateOrUpdate(
                    rgname,
                    new ResourceGroup
                    {
                        Location = DefaultLocation
                    });
            }

            return rgname;
        }

        public static void DeleteResourceGroup(ResourceManagementClient resourcesClient, string resourceGroupName)
        {
            if (!IsTestTenant)
            {
                resourcesClient.ResourceGroups.Delete(resourceGroupName);
            }
        }

        public static void WaitIfNotInPlaybackMode(int minutesToWait = 1)
        {
            if (HttpMockServer.Mode != HttpRecorderMode.Playback)
            { 
                Thread.Sleep(TimeSpan.FromMinutes(minutesToWait));
            }
        }
    }
}
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.DataMigration;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Net.Http;
using System.Threading;

namespace DataMigration.Tests.Helpers
{
    public static class Utilities
    {
        /// <summary>
        /// Random generator.
        /// </summary>
        private static Random random = new Random();

        public static bool IsTestTenant = false;
        private static HttpClientHandler Handler = null;

        // These should be filled in only if test tenant is true
        public static string certName = null;
        public static string certPassword = null;
        private static string testSubscription = null;
        private static Uri testUri = null;

        // These are used to create default accounts
        public static string DefaultLocation = IsTestTenant ? null : "westus2";

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

        public static DataMigrationServiceClient GetDataMigrationManagementClient(MockContext context, RecordedDelegatingHandler handler)
        {
            DataMigrationServiceClient dmClient;
            if (IsTestTenant)
            {
                dmClient = new DataMigrationServiceClient(new TokenCredentials("xyz"), GetHandler());
                dmClient.SubscriptionId = testSubscription;
                dmClient.BaseUri = testUri;
            }
            else
            {
                handler.IsPassThrough = true;
                dmClient = context.GetServiceClient<DataMigrationServiceClient>(handlers: handler);
            }
            return dmClient;
        }

        private static HttpClientHandler GetHandler()
        {
#if DNX451
            if (Handler == null)
            {
                //talk to yugangw-msft, if the code doesn't work under dnx451 (same with net451)
                X509Certificate2 cert = new X509Certificate2(certName, certPassword);
                Handler = new System.Net.Http.WebRequestHandler();
                ((WebRequestHandler)Handler).ClientCertificates.Add(cert);
                ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => { return true; };
            }
#endif
            return Handler;
        }

        public static string CreateResourceGroup(ResourceManagementClient resourcesClient, string namePrefix = "dmssdkrg", string location = "westus2")
        {
            var rgname = TestUtilities.GenerateName(namePrefix);

            if (!IsTestTenant)
            {
                var resourceGroup = resourcesClient.ResourceGroups.CreateOrUpdate(
                    rgname,
                    new ResourceGroup
                    {
                        Location = location
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
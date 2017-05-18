// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure;
using Microsoft.Azure.Management.Analysis;
using Microsoft.Azure.Management.Analysis.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Runtime.Serialization.Json;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Xunit;

namespace AnalysisServices.Tests.Helpers
{
    public static class AnalysisServicesTestUtilities
    {
        private static HttpClientHandler Handler = null;
        private static string testSubscription = "00000000-0000-0000-0000-000000000000";
        private static Uri testUri = new Uri("https://api-dogfood.resources.windows-int.net/");

        // These should be filled in only if test tenant is true
#if DNX451
        private static string certName = null;
        private static string certPassword = null;
#endif
        // These are used to create default accounts
        public static string DefaultResourceGroup = "TestRG";
        public static string DefaultServerName = "azsdktest";
        public static string DefaultLocation = "West US";
        public static ResourceSku DefaultSku = new ResourceSku
        {
            Name = SkuName.S1.ToString(),
            Tier = SkuTier.Standard.ToString()
        };

        public static Dictionary<string, string> DefaultTags = new Dictionary<string, string>
            {
                {"key1","value1"},
                {"key2","value2"}
            };

        public static IList<string> DefaultAdministrators = new List<string>()
        {
            "aztest0@stabletest.ccsctp.net",
            "aztest1@stabletest.ccsctp.net"
        };

        public static string DefaultBakcupStorageAccount = "FT_Permanent_Group_A/stabletestbackupsa";

        public static string DefaultBackupBlobContainer = "backups";

        public static BackupConfiguration DefaultBackupConfiguration = new BackupConfiguration("FT_Permanent_Group_A/stabletestbackupsa", "backups", Environment.GetEnvironmentVariable("AAS_DEFAULT_BACKUP_STORAGE_ACCESS_KEY"));

        public static string GetDefaultCreatedResponse(string provisioningState, string state)
        {
            string responseFormat = @"{{
                            'id':'/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.AnalysisServices/servers/{2}',
                            'name':'{2}',
                            'type':'Microsoft.AnalysisServices/servers',
                            'location':'{3}',
                            'sku':{{
                                'name':'{4}'
                            }},
                            'tags':{5},
                            'properties':{{
                                'state':'{6}',
                                'provisioningState':'{7}', 
                                'serverFullName':'asazure://wcus.asazure-int.windows.net/{2}',
                                'asAdministrators':{{
                                'members':{8}
                                }},
                                'backupConfiguration':{{
                                'storageAccount':'{9}',
                                'blobContainer':'{10}'
                                }}
                            }}
                            }}";
            
            var tags = JsonConvert.SerializeObject(DefaultTags, new KeyValuePairConverter());
            var admins = JsonConvert.SerializeObject(DefaultAdministrators);
            return string.Format(
                responseFormat,
                testSubscription,
                DefaultResourceGroup,
                DefaultServerName,
                DefaultLocation,
                DefaultSku.Name,
                tags,
                provisioningState,
                state,
                admins,
                DefaultBakcupStorageAccount,
                DefaultBackupBlobContainer);
        }

        public static ResourceManagementClient GetResourceManagementClient(MockContext context, RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = true;
            ResourceManagementClient resourcesClient = context.GetServiceClient<ResourceManagementClient>(handlers: handler);
            return resourcesClient;
        }

        public static AnalysisServicesServer GetDefaultAnalysisServicesResource()
        {
            AnalysisServicesServer defaultServer = new AnalysisServicesServer
            {
                Location = DefaultLocation,
                Tags = DefaultTags,
                Sku = DefaultSku,
                AsAdministrators = new ServerAdministrators(DefaultAdministrators),
                BackupConfiguration = DefaultBackupConfiguration
            };

            return defaultServer;
        }

        /// <summary>
        /// Default constructor for management clients, using the TestSupport Infrastructure
        /// </summary>
        /// <param name="testBase">the test class</param>
        /// <param name="context">Mock context object</param>
        /// <returns>A redis cache management client, created from the current context (environment variables)</returns>
        public static AnalysisServicesManagementClient GetAnalysisServicesClient(this TestBase testBase, MockContext context)
        {
            return context.GetServiceClient<AnalysisServicesManagementClient>();
        }

        public static AnalysisServicesManagementClient GetAnalysisServicesClient(RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = false;
            var client = new AnalysisServicesManagementClient(new TokenCredentials("xyz"), handler);
            client.SubscriptionId = "00000000-0000-0000-0000-000000000000";
            if (HttpMockServer.Mode != HttpRecorderMode.Record)
            {
                client.LongRunningOperationRetryTimeout = 0;
            }
            return client;
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
        
        public static void WaitIfNotInPlaybackMode()
        {
            if (Environment.GetEnvironmentVariable("AZURE_TEST_MODE") != null &&
                !Environment.GetEnvironmentVariable("AZURE_TEST_MODE").
                Equals("Playback", StringComparison.CurrentCultureIgnoreCase))
            {
                Thread.Sleep(TimeSpan.FromMinutes(1));
            }
        }
    }
}

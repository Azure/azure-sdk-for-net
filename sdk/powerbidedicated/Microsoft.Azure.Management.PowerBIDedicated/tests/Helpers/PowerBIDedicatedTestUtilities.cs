// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure;
using Microsoft.Azure.Management.PowerBIDedicated;
using Microsoft.Azure.Management.PowerBIDedicated.Models;
 using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using DedicatedServices.Tests.Helpers;
using Xunit;

namespace DedicatedServices.Tests.Helpers
{
    public static class PowerBIDedicatedTestUtilities
    {
        private static HttpClientHandler Handler = null;
        private static Uri testUri = new Uri("https://api-dogfood.resources.windows-int.net/");

        // These should be filled in only if test tenant is true
#if FullNetFx
        private static string certName = null;
        private static string certPassword = null;
#endif
        // These are used to create default accounts
        public static string DefaultResourceGroup = "TestRG";
        public static string DefaultCapacityName = "pbidsdktest";
        public static string DefaultLocation = "West Central US";

        public static ResourceSku DefaultSku = new ResourceSku
        {
            Name = "A1"
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

        public static DedicatedCapacity GetDefaultDedicatedResource()
        {
            DedicatedCapacity defaultCapacity = new DedicatedCapacity
            {
                Location = DefaultLocation,
                Tags = DefaultTags,
                Sku = DefaultSku,
                Administration = new DedicatedCapacityAdministrators(DefaultAdministrators),
            };

            return defaultCapacity;
        }

        /// <summary>
        /// Default constructor for management clients, using the TestSupport Infrastructure
        /// </summary>
        /// <param name="testBase">the test class</param>
        /// <param name="context">Mock context object</param>
        /// <returns>A redis cache management client, created from the current context (environment variables)</returns>
        public static PowerBIDedicatedManagementClient GetDedicatedServicesClient(this TestBase testBase, MockContext context)
        {
            return context.GetServiceClient<PowerBIDedicatedManagementClient>();
        }

        private static HttpClientHandler GetHandler()
        {
#if FullNetFx
            if (Handler == null)
            {
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

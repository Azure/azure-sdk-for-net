// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Kusto;
using Microsoft.Azure.Management.Kusto.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;

namespace DedicatedServices.Tests.Helpers
{
    public static class KustoTestUtilities
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
        public static string DefaultCapacityName = "kustosdktest";
        public static string DefaultLocation = "West US";

        public static Dictionary<string, string> DefaultTags = new Dictionary<string, string>
        {
            {"key1","value1"},
            {"key2","value2"}
        };

        public static Cluster GetDefaultClusterResource()
        {
            var defaultCluster = new Cluster()
            {
                Location = DefaultLocation,
                Tags = DefaultTags,
            };

            return defaultCluster;
        }

        /// <summary>
        /// Default constructor for management clients, using the TestSupport Infrastructure
        /// </summary>
        /// <param name="testBase">the test class</param>
        /// <param name="context">Mock context object</param>
        /// <returns>A Kusto management client, created from the current context (environment variables)</returns>
        public static KustoManagementClient GetKustoManagementClient(this TestBase testBase, MockContext context)
        {
            return context.GetServiceClient<KustoManagementClient>();
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

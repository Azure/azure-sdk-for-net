// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information. 

using Microsoft.Azure.Management.Samples.Common;
using System;
using System.Collections.Generic;
using System.Net.Http;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
using Microsoft.Azure.Management.Cdn.Fluent;
using Microsoft.Azure.Management.Cdn.Fluent.Models;
using Microsoft.Azure.Management.AppService.Fluent;

namespace ManageCdn
{
    public class Program
    {
        private static readonly string Suffix = ".azurewebsites.net";

        /**
         * Azure CDN sample for managing CDN profiles:
         * - Create 8 web apps in 8 regions:
         *    * 2 in US
         *    * 2 in EU
         *    * 2 in Southeast
         *    * 1 in Brazil
         *    * 1 in Japan
         * - Create CDN profile using Standard Verizon SKU with endpoints in each region of Web apps.
         * - Load some content (referenced by Web Apps) to the CDN endpoints.
         */
        public static void RunSample(IAzure azure)
        {
            string cdnProfileName = Utilities.CreateRandomName("cdnStandardProfile");
            string rgName = SdkContext.RandomResourceName("rgCDN_", 24);
            var appNames = new string[8];

            try
            {

                azure.ResourceGroups.Define(rgName)
                        .WithRegion(Region.USCentral)
                        .Create();

                // ============================================================
                // Create 8 websites
                for (int i = 0; i < 8; i++)
                {
                    appNames[i] = SdkContext.RandomResourceName("webapp" + (i + 1) + "-", 20);
                }

                // 2 in US
                CreateWebApp(azure, rgName, appNames[0], Region.USWest);
                CreateWebApp(azure, rgName, appNames[1], Region.USEast);

                // 2 in EU
                CreateWebApp(azure, rgName, appNames[2], Region.EuropeWest);
                CreateWebApp(azure, rgName, appNames[3], Region.EuropeNorth);

                // 2 in Southeast
                CreateWebApp(azure, rgName, appNames[4], Region.AsiaSouthEast);
                CreateWebApp(azure, rgName, appNames[5], Region.AustraliaSouthEast);

                // 1 in Brazil
                CreateWebApp(azure, rgName, appNames[6], Region.BrazilSouth);

                // 1 in Japan
                CreateWebApp(azure, rgName, appNames[7], Region.JapanWest);

                // =======================================================================================
                // Create CDN profile using Standard Verizon SKU with endpoints in each region of Web apps.
                Utilities.Log("Creating a CDN Profile");

                // create Cdn Profile definition object that will let us do a for loop
                // to define all 8 endpoints and then parallelize their creation
                var profileDefinition = azure.CdnProfiles.Define(cdnProfileName)
                        .WithRegion(Region.USCentral)
                        .WithExistingResourceGroup(rgName)
                        .WithStandardVerizonSku();

                // define all the endpoints. We need to keep track of the last creatable stage
                // to be able to call create on the entire Cdn profile deployment definition.
                ICreatable<ICdnProfile> cdnCreatable = null;
                foreach (var webSite in appNames)
                {
                    cdnCreatable = profileDefinition
                            .DefineNewEndpoint()
                                .WithOrigin(webSite + Suffix)
                                .WithHostHeader(webSite + Suffix)
                                .WithCompressionEnabled(true)
                                .WithContentTypeToCompress("application/javascript")
                                .WithQueryStringCachingBehavior(QueryStringCachingBehavior.IgnoreQueryString)
                            .Attach();
                }

                // create profile and then all the defined endpoints in parallel
                ICdnProfile profile = cdnCreatable.Create();

                // =======================================================================================
                // Load some content (referenced by Web Apps) to the CDN endpoints.
                var contentToLoad = new HashSet<string>();
                contentToLoad.Add("/server.js");
                contentToLoad.Add("/pictures/microsoft_logo.png");

                foreach (ICdnEndpoint endpoint in profile.Endpoints.Values)
                {
                    endpoint.LoadContent(contentToLoad);
                }

            }
            finally
            {
                try
                {
                    Utilities.Log("Deleting Resource Group: " + rgName);
                    azure.ResourceGroups.DeleteByName(rgName);
                    Utilities.Log("Deleted Resource Group: " + rgName);
                }
                catch
                {
                    Utilities.Log("Did not create any resources in Azure. No clean up is necessary");
                }
            }
        }
        public static void Main(string[] args)
        {
            try
            {
                //=================================================================
                // Authenticate
                var credentials = SdkContext.AzureCredentialsFactory.FromFile(Environment.GetEnvironmentVariable("AZURE_AUTH_LOCATION"));

                var azure = Azure
                    .Configure()
                    .WithLogLevel(HttpLoggingDelegatingHandler.Level.Basic)
                    .Authenticate(credentials)
                    .WithDefaultSubscription();

                // Print selected subscription
                Utilities.Log("Selected subscription: " + azure.SubscriptionId);

                RunSample(azure);
            }
            catch (Exception e)
            {
                Utilities.Log(e);
            }
        }

        private static IWebApp CreateWebApp(IAzure azure, string rgName, string appName, Region region)
        {
            var appUrl = appName + Suffix;

            Utilities.Log("Creating web app " + appName + " with master branch...");

            var app = azure.WebApps
                    .Define(appName)
                    .WithRegion(region)
                    .WithExistingResourceGroup(rgName)
                    .WithNewWindowsPlan(PricingTier.StandardS1)
                    .WithJavaVersion(JavaVersion.V8Newest)
                    .WithWebContainer(WebContainer.Tomcat8_0Newest)
                    .DefineSourceControl()
                        .WithPublicGitRepository("https://github.com/jianghaolu/azure-site-test")
                        .WithBranch("master")
                        .Attach()
                    .Create();

            Utilities.Log("Created web app " + app.Name);
            Utilities.Print(app);

            Utilities.Log("CURLing " + appUrl + "...");
            Utilities.Log(Utilities.CheckAddress("http://" + appUrl));
            return app;
        }
    }
}

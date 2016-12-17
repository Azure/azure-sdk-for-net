// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information. 

using Microsoft.Azure.Management.AppService.Fluent;
using Microsoft.Azure.Management.Cdn.Fluent;
using Microsoft.Azure.Management.Cdn.Fluent.Models;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.Redis.Fluent.Models;
using Microsoft.Azure.Management.Resource.Fluent;
using Microsoft.Azure.Management.Resource.Fluent.Authentication;
using Microsoft.Azure.Management.Resource.Fluent.Core;
using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
using Microsoft.Azure.Management.Samples.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ManageRedis
{
    public class Program
    {
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
        private static readonly string RG_NAME = ResourceNamer.RandomResourceName("rgCDN_", 24);
        private static readonly string SUFFIX = ".azurewebsites.net";

        public static void Main(string[] args)
        {
            string cdnProfileName = Utilities.CreateRandomName("cdnStandardProfile");
            var appNames = new string[8];

            try
            {
                //=================================================================
                // Authenticate
                var credentials = AzureCredentials.FromFile(Environment.GetEnvironmentVariable("AZURE_AUTH_LOCATION"));

                var azure = Azure
                    .Configure()
                    .WithLogLevel(HttpLoggingDelegatingHandler.Level.BASIC)
                    .Authenticate(credentials)
                    .WithDefaultSubscription();

                // Print selected subscription
                Console.WriteLine("Selected subscription: " + azure.SubscriptionId);
                
                try
                {

                    azure.ResourceGroups.Define(RG_NAME)
                            .WithRegion(Region.US_CENTRAL)
                            .Create();

                    // ============================================================
                    // Create 8 websites
                    for (int i = 0; i < 8; i++)
                    {
                        appNames[i] = ResourceNamer.RandomResourceName("webapp" + (i + 1) + "-", 20);
                    }

                    // 2 in US
                    CreateWebApp(azure, appNames[0], Region.US_WEST);
                    CreateWebApp(azure, appNames[1], Region.US_EAST);

                    // 2 in EU
                    CreateWebApp(azure, appNames[2], Region.EUROPE_WEST);
                    CreateWebApp(azure, appNames[3], Region.EUROPE_NORTH);

                    // 2 in Southeast
                    CreateWebApp(azure, appNames[4], Region.ASIA_SOUTHEAST);
                    CreateWebApp(azure, appNames[5], Region.AUSTRALIA_SOUTHEAST);

                    // 1 in Brazil
                    CreateWebApp(azure, appNames[6], Region.BRAZIL_SOUTH);

                    // 1 in Japan
                    CreateWebApp(azure, appNames[7], Region.JAPAN_WEST);
                    // =======================================================================================
                    // Create CDN profile using Standard Verizon SKU with endpoints in each region of Web apps.
                    Console.WriteLine("Creating a CDN Profile");

                    // create Cdn Profile definition object that will let us do a for loop
                    // to define all 8 endpoints and then parallelize their creation
                    var profileDefinition = azure.CdnProfiles.Define(cdnProfileName)
                            .WithRegion(Region.US_CENTRAL)
                            .WithExistingResourceGroup(RG_NAME)
                            .WithStandardVerizonSku();

                    // define all the endpoints. We need to keep track of the last creatable stage
                    // to be able to call create on the entire Cdn profile deployment definition.
                    ICreatable<ICdnProfile> cdnCreatable = null;
                    foreach(var webSite in appNames)
                    {
                        cdnCreatable = profileDefinition
                                .DefineNewEndpoint()
                                    .WithOrigin(webSite + SUFFIX)
                                    .WithHostHeader(webSite + SUFFIX)
                                    .WithCompressionEnabled(true)
                                    .WithContentTypeToCompress("application/javascript")
                                    .WithQueryStringCachingBehavior(QueryStringCachingBehavior.IgnoreQueryString)
                                .Attach();
                    }

                    // create profile and then all the defined endpoints in parallel
                    ICdnProfile profile = cdnCreatable.Create();

                    // =======================================================================================
                    // Load some content (referenced by Web Apps) to the CDN endpoints.
                    var contentToLoad = new List<string>();
                    contentToLoad.Add("/server.js");
                    contentToLoad.Add("/pictures/microsoft_logo.png");

                    foreach(ICdnEndpoint endpoint in profile.Endpoints.Values)
                    {
                        endpoint.LoadContent(contentToLoad);
                    }

                }
                catch (Exception f)
                {
                    Console.WriteLine(f);
                }
                finally
                {
                    try
                    {
                        Console.WriteLine("Deleting Resource Group: " + RG_NAME);
                        azure.ResourceGroups.DeleteByName(RG_NAME);
                        Console.WriteLine("Deleted Resource Group: " + RG_NAME);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Did not create any resources in Azure. No clean up is necessary");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private static IWebApp CreateWebApp(IAzure azure, string appName, Region region)
        {
            var planName = ResourceNamer.RandomResourceName("jplan_", 15);
            var appUrl = appName + SUFFIX;

            Console.WriteLine("Creating web app " + appName + " with master branch...");

            var app = azure.WebApps
                    .Define(appName)
                    .WithExistingResourceGroup(RG_NAME)
                    .WithNewAppServicePlan(planName)
                    .WithRegion(region)
                    .WithPricingTier(AppServicePricingTier.Standard_S1)
                    .WithJavaVersion(JavaVersion.Java_8_Newest)
                    .WithWebContainer(WebContainer.Tomcat_8_0_Newest)
                    .DefineSourceControl()
                        .WithPublicGitRepository("https://github.com/jianghaolu/azure-site-test.git")
                        .WithBranch("master")
                        .Attach()
                    .Create();

            Console.WriteLine("Created web app " + app.Name);
            Utilities.Print(app);

            Console.WriteLine("CURLing " + appUrl + "...");
            Console.WriteLine(CheckAddress("http://" + appUrl));
            return app;
        }

        private static HttpResponseMessage CheckAddress(string url)
        {
            using (var client = new HttpClient())
            {
                return client.GetAsync(url).Result;
            }
        }
    }
}

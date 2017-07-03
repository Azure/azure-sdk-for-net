// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.AppService.Fluent;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Authentication;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Samples.Common;
using Microsoft.Azure.Management.TrafficManager.Fluent;
using System;
using System.Linq;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using Microsoft.Azure.Management.AppService.Fluent.Models;

namespace ManageWebAppWithAuthentication
{
    /**
     * Azure App Service sample for managing authentication for web apps.
     *  - Create 4 web apps under the same new app service plan with:
     *    - Active Directory login for 1
     *    - Facebook login for 2
     *    - Google login for 3
     *    - Microsoft login for 4
     */

    public class Program
    {
        public static void RunSample(IAzure azure)
        {
            string suffix = ".azurewebsites.net";
            string app1Name = SdkContext.RandomResourceName("webapp1-", 20);
            string app2Name = SdkContext.RandomResourceName("webapp2-", 20);
            string app3Name = SdkContext.RandomResourceName("webapp3-", 20);
            string app4Name = SdkContext.RandomResourceName("webapp4-", 20);
            string app1Url = app1Name + suffix;
            string app2Url = app2Name + suffix;
            string app3Url = app3Name + suffix;
            string app4Url = app4Name + suffix;
            string rgName = SdkContext.RandomResourceName("rg1NEMV_", 24);

            try
            {


                //============================================================
                // Create a web app with a new app service plan

                Utilities.Log("Creating web app " + app1Name + " in resource group " + rgName + "...");

                IWebApp app1 = azure.WebApps.Define(app1Name)
                        .WithRegion(Region.USWest)
                        .WithNewResourceGroup(rgName)
                        .WithNewWindowsPlan(PricingTier.StandardS1)
                        .WithJavaVersion(JavaVersion.V8Newest)
                        .WithWebContainer(WebContainer.Tomcat8_0Newest)
                        .Create();

                Utilities.Log("Created web app " + app1.Name);
                Utilities.Print(app1);

                //============================================================
                // Set up active directory authentication

                Utilities.Log("Please create an AD application with redirect URL " + app1Url);
                Utilities.Log("Application ID is:");
                string applicationId = Utilities.ReadLine();
                Utilities.Log("Tenant ID is:");
                string tenantId = Utilities.ReadLine();

                Utilities.Log("Updating web app " + app1Name + " to use active directory login...");

                app1.Update()
                        .DefineAuthentication()
                            .WithDefaultAuthenticationProvider(BuiltInAuthenticationProvider.AzureActiveDirectory)
                            .WithActiveDirectory(applicationId, "https://sts.windows.net/" + tenantId)
                            .Attach()
                        .Apply();

                Utilities.Log("Added active directory login to " + app1.Name);
                Utilities.Print(app1);

                //============================================================
                // Create a second web app

                Utilities.Log("Creating another web app " + app2Name + " in resource group " + rgName + "...");
                IAppServicePlan plan = azure.AppServices.AppServicePlans.GetById(app1.AppServicePlanId);
                IWebApp app2 = azure.WebApps.Define(app2Name)
                        .WithExistingWindowsPlan(plan)
                        .WithExistingResourceGroup(rgName)
                        .WithJavaVersion(JavaVersion.V8Newest)
                        .WithWebContainer(WebContainer.Tomcat8_0Newest)
                        .Create();

                Utilities.Log("Created web app " + app2.Name);
                Utilities.Print(app2);

                //============================================================
                // Set up Facebook authentication

                Utilities.Log("Please create a Facebook developer application with whitelisted URL " + app2Url);
                Utilities.Log("App ID is:");
                string fbAppId = Utilities.ReadLine();
                Utilities.Log("App secret is:");
                string fbAppSecret = Utilities.ReadLine();

                Utilities.Log("Updating web app " + app2Name + " to use Facebook login...");

                app2.Update()
                        .DefineAuthentication()
                            .WithDefaultAuthenticationProvider(BuiltInAuthenticationProvider.Facebook)
                            .WithFacebook(fbAppId, fbAppSecret)
                            .Attach()
                        .Apply();

                Utilities.Log("Added Facebook login to " + app2.Name);
                Utilities.Print(app2);

                //============================================================
                // Create a 3rd web app with a public GitHub repo in Azure-Samples

                Utilities.Log("Creating another web app " + app3Name + "...");
                IWebApp app3 = azure.WebApps.Define(app3Name)
                        .WithExistingWindowsPlan(plan)
                        .WithNewResourceGroup(rgName)
                        .DefineSourceControl()
                            .WithPublicGitRepository("https://github.com/Azure-Samples/app-service-web-dotnet-get-started")
                            .WithBranch("master")
                            .Attach()
                        .Create();

                Utilities.Log("Created web app " + app3.Name);
                Utilities.Print(app3);

                //============================================================
                // Set up Google authentication

                Utilities.Log("Please create a Google developer application with redirect URL " + app3Url);
                Utilities.Log("Client ID is:");
                string gClientId = Utilities.ReadLine();
                Utilities.Log("Client secret is:");
                string gClientSecret = Utilities.ReadLine();

                Utilities.Log("Updating web app " + app3Name + " to use Google login...");

                app3.Update()
                        .DefineAuthentication()
                            .WithDefaultAuthenticationProvider(BuiltInAuthenticationProvider.Google)
                            .WithGoogle(gClientId, gClientSecret)
                            .Attach()
                        .Apply();

                Utilities.Log("Added Google login to " + app3.Name);
                Utilities.Print(app3);

                //============================================================
                // Create a 4th web app

                Utilities.Log("Creating another web app " + app4Name + "...");
                IWebApp app4 = azure.WebApps
                        .Define(app4Name)
                        .WithExistingWindowsPlan(plan)
                        .WithExistingResourceGroup(rgName)
                        .Create();

                Utilities.Log("Created web app " + app4.Name);
                Utilities.Print(app4);

                //============================================================
                // Set up Google authentication

                Utilities.Log("Please create a Microsoft developer application with redirect URL " + app4Url);
                Utilities.Log("Client ID is:");
                string clientId = Utilities.ReadLine();
                Utilities.Log("Client secret is:");
                string clientSecret = Utilities.ReadLine();

                Utilities.Log("Updating web app " + app3Name + " to use Microsoft login...");

                app4.Update()
                        .DefineAuthentication()
                            .WithDefaultAuthenticationProvider(BuiltInAuthenticationProvider.MicrosoftAccount)
                            .WithMicrosoft(clientId, clientSecret)
                            .Attach()
                        .Apply();

                Utilities.Log("Added Microsoft login to " + app4.Name);
                Utilities.Print(app4);
            }
            finally
            {
                try
                {
                    Utilities.Log("Deleting Resource Group: " + rgName);
                    azure.ResourceGroups.DeleteByName(rgName);
                    Utilities.Log("Deleted Resource Group: " + rgName);
                }
                catch (NullReferenceException)
                {
                    Utilities.Log("Did not create any resources in Azure. No clean up is necessary");
                }
                catch (Exception g)
                {
                    Utilities.Log(g);
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
    }
}
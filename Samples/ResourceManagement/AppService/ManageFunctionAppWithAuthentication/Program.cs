// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.AppService.Fluent;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Samples.Common;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ManageFunctionAppWithAuthentication
{
    public class Program
    {
        /**
         * Azure App Service basic sample for managing function apps.
         *  - Create 4 function apps under the same new app service plan:
         *    - Deploy to 1 using FTP
         *    - Deploy to 2 using local Git repository
         *    - Deploy to 3 using a publicly available Git repository
         *    - Deploy to 4 using a GitHub repository with continuous integration
         */


        public static void RunSample(IAzure azure)
        {
            // New resources
            string suffix         = ".azurewebsites.net";
            string app1Name       = SdkContext.RandomResourceName("webapp1-", 20);
            string app2Name       = SdkContext.RandomResourceName("webapp2-", 20);
            string app1Url        = app1Name + suffix;
            string app2Url        = app2Name + suffix;
            string rgName         = SdkContext.RandomResourceName("rg1NEMV_", 24);

            try {


                //============================================================
                // Create a function app with admin level auth

                Utilities.Log("Creating function app " + app1Name + " in resource group " + rgName + " with admin level auth...");

                IFunctionApp app1 = azure.AppServices.FunctionApps.Define(app1Name)
                        .WithRegion(Region.USWest)
                        .WithNewResourceGroup(rgName)
                        .WithLocalGitSourceControl()
                        .Create();

                Utilities.Log("Created function app " + app1.Name);
                Utilities.Print(app1);

                //============================================================
                // Create a second function app with function level auth

                Utilities.Log("Creating another function app " + app2Name + " in resource group " + rgName + " with function level auth...");
                IAppServicePlan plan = azure.AppServices.AppServicePlans.GetById(app1.AppServicePlanId);
                IFunctionApp app2 = azure.AppServices.FunctionApps.Define(app2Name)
                        .WithExistingAppServicePlan(plan)
                        .WithExistingResourceGroup(rgName)
                        .WithExistingStorageAccount(app1.StorageAccount)
                        .WithLocalGitSourceControl()
                        .Create();

                Utilities.Log("Created function app " + app2.Name);
                Utilities.Print(app2);

                //============================================================
                // Deploy to app 1 through Git

                Utilities.Log("Deploying a local function app to " + app1Name + " through Git...");

                IPublishingProfile profile = app1.GetPublishingProfile();
                Utilities.DeployByGit(profile, "square-function-app-admin-auth");

                // warm up
                Utilities.Log("Warming up " + app1Url + "/api/square...");
                Utilities.PostAddress("http://" + app1Url + "/api/square", "625");
                SdkContext.DelayProvider.Delay(5000);
                Utilities.Log("CURLing " + app1Url + "/api/square...");
                Utilities.Log("Square of 625 is " + Utilities.PostAddress("http://" + app1Url + "/api/square?code=" + app1.GetMasterKey(), "625"));

                //============================================================
                // Deploy to app 2 through Git

                Utilities.Log("Deploying a local function app to " + app2Name + " through Git...");

                profile = app2.GetPublishingProfile();
                Utilities.DeployByGit(profile, "square-function-app-function-auth");

                Utilities.Log("Deployment to function app " + app2.Name + " completed");
                Utilities.Print(app2);


                string masterKey = app2.GetMasterKey();
                var functionsHeader = new Dictionary<string, string>();
                functionsHeader["x-functions-key"] = masterKey;
                string response = Utilities.CheckAddress("http://" + app2Url + "/admin/functions/square/keys", functionsHeader);
                Regex pattern = new Regex(@"""name"":""default"",""value"":""([\w=/]+)""");
                Match matcher = pattern.Match(response);
                string functionKey = matcher.Captures[0].Value;

                // warm up
                Utilities.Log("Warming up " + app2Url + "/api/square...");
                Utilities.PostAddress("http://" + app2Url + "/api/square", "725");
                SdkContext.DelayProvider.Delay(5000);
                Utilities.Log("CURLing " + app2Url + "/api/square...");
                Utilities.Log("Square of 725 is " + Utilities.PostAddress("http://" + app2Url + "/api/square?code=" + functionKey, "725"));
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
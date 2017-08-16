// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.AppService.Fluent;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Samples.Common;
using System;
using System.IO;

namespace ManageFunctionAppSourceControl
{
    public class Program
    {
        /**
         * Azure App Service basic sample for managing function apps.
         *  - Create 5 function apps under the same new app service plan:
         *    - Deploy to 1 using FTP
         *    - Deploy to 2 using local Git repository
         *    - Deploy to 3 using a publicly available Git repository
         *    - Deploy to 4 using a GitHub repository with continuous integration
         *    - Deploy to 5 using web deploy
         */

        public static void RunSample(IAzure azure)
        {
            // New resources
            string suffix         = ".azurewebsites.net";
            string app1Name       = SdkContext.RandomResourceName("webapp1-", 20);
            string app2Name       = SdkContext.RandomResourceName("webapp2-", 20);
            string app3Name       = SdkContext.RandomResourceName("webapp3-", 20);
            string app4Name       = SdkContext.RandomResourceName("webapp4-", 20);
            string app5Name       = SdkContext.RandomResourceName("webapp5-", 20);
            string app1Url        = app1Name + suffix;
            string app2Url        = app2Name + suffix;
            string app3Url        = app3Name + suffix;
            string app4Url        = app4Name + suffix;
            string app5Url        = app5Name + suffix;
            string rgName         = SdkContext.RandomResourceName("rg1NEMV_", 24);

            try {


                //============================================================
                // Create a function app with a new app service plan

                Utilities.Log("Creating function app " + app1Name + " in resource group " + rgName + "...");

                IFunctionApp app1 = azure.AppServices.FunctionApps.Define(app1Name)
                        .WithRegion(Region.USWest)
                        .WithNewResourceGroup(rgName)
                        .Create();

                Utilities.Log("Created function app " + app1.Name);
                Utilities.Print(app1);

                //============================================================
                // Deploy to app 1 through FTP

                Utilities.Log("Deploying a function app to " + app1Name + " through FTP...");

                IPublishingProfile profile = app1.GetPublishingProfile();
                Utilities.UploadFileToFunctionApp(profile, Path.Combine(Utilities.ProjectPath, "Asset", "square-function-app", "host.json"));
                Utilities.UploadFileToFunctionApp(profile, Path.Combine(Utilities.ProjectPath, "Asset", "square-function-app", "square", "function.json"), "square/function.json");
                Utilities.UploadFileToFunctionApp(profile, Path.Combine(Utilities.ProjectPath, "Asset", "square-function-app", "square", "index.js"), "square/index.js");

                // sync triggers
                app1.SyncTriggers();

                Utilities.Log("Deployment square app to web app " + app1.Name + " completed");
                Utilities.Print(app1);

                // warm up
                Utilities.Log("Warming up " + app1Url + "/api/square...");
                Utilities.PostAddress("http://" + app1Url + "/api/square", "625");
                SdkContext.DelayProvider.Delay(5000);
                Utilities.Log("CURLing " + app1Url + "/api/square...");
                Utilities.Log(Utilities.PostAddress("http://" + app1Url + "/api/square", "625"));

                //============================================================
                // Create a second function app with local git source control

                Utilities.Log("Creating another function app " + app2Name + " in resource group " + rgName + "...");
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
                // Deploy to app 2 through local Git

                Utilities.Log("Deploying a local Tomcat source to " + app2Name + " through Git...");

                profile = app2.GetPublishingProfile();
                Utilities.DeployByGit(profile, "square-function-app");

                Utilities.Log("Deployment to function app " + app2.Name + " completed");
                Utilities.Print(app2);

                // warm up
                Utilities.Log("Warming up " + app2Url + "/api/square...");
                Utilities.PostAddress("http://" + app2Url + "/api/square", "725");
                SdkContext.DelayProvider.Delay(5000);
                Utilities.Log("CURLing " + app2Url + "/api/square...");
                Utilities.Log("Square of 725 is " + Utilities.PostAddress("http://" + app2Url + "/api/square", "725"));

                //============================================================
                // Create a 3rd function app with a public GitHub repo in Azure-Samples

                Utilities.Log("Creating another function app " + app3Name + "...");
                IFunctionApp app3 = azure.AppServices.FunctionApps.Define(app3Name)
                        .WithExistingAppServicePlan(plan)
                        .WithNewResourceGroup(rgName)
                        .WithExistingStorageAccount(app2.StorageAccount)
                        .DefineSourceControl()
                            .WithPublicGitRepository("https://github.com/jianghaolu/square-function-app-sample")
                            .WithBranch("master")
                            .Attach()
                        .Create();

                Utilities.Log("Created function app " + app3.Name);
                Utilities.Print(app3);

                // warm up
                Utilities.Log("Warming up " + app3Url + "/api/square...");
                Utilities.PostAddress("http://" + app3Url + "/api/square", "825");
                SdkContext.DelayProvider.Delay(5000);
                Utilities.Log("CURLing " + app3Url + "/api/square...");
                Utilities.Log("Square of 825 is " + Utilities.PostAddress("http://" + app3Url + "/api/square", "825"));

                //============================================================
                // Create a 4th function app with a personal GitHub repo and turn on continuous integration

                Utilities.Log("Creating another function app " + app4Name + "...");
                IFunctionApp app4 = azure.AppServices.FunctionApps
                        .Define(app4Name)
                        .WithExistingAppServicePlan(plan)
                        .WithExistingResourceGroup(rgName)
                        .WithExistingStorageAccount(app3.StorageAccount)
                        // Uncomment the following lines to turn on 4th scenario
                        //.DefineSourceControl()
                        //    .WithContinuouslyIntegratedGitHubRepository("username", "reponame")
                        //    .WithBranch("master")
                        //    .WithGitHubAccessToken("YOUR GITHUB PERSONAL TOKEN")
                        //    .Attach()
                        .Create();

                Utilities.Log("Created function app " + app4.Name);
                Utilities.Print(app4);

                // warm up
                Utilities.Log("Warming up " + app4Url + "...");
                Utilities.CheckAddress("http://" + app4Url);
                SdkContext.DelayProvider.Delay(5000);
                Utilities.Log("CURLing " + app4Url + "...");
                Utilities.Log(Utilities.CheckAddress("http://" + app4Url));

                //============================================================
                // Create a 5th function app with web deploy

                Utilities.Log("Creating another function app " + app5Name + "...");
                IFunctionApp app5 = azure.AppServices.FunctionApps
                    .Define(app5Name)
                    .WithExistingAppServicePlan(plan)
                    .WithExistingResourceGroup(rgName)
                    .WithExistingStorageAccount(app3.StorageAccount)
                    .Create();

                Utilities.Log("Created function app " + app5.Name);
                Utilities.Print(app5);

                Utilities.Log("Deploying to " + app5Name + " through web deploy...");
                app5.Deploy()
                    .WithPackageUri("https://github.com/Azure/azure-sdk-for-net/raw/Fluent/Samples/Asset/square-function-app.zip")
                    .WithExistingDeploymentsDeleted(true)
                    .Execute();

                // warm up
                Utilities.Log("Warming up " + app5Url + "/api/square...");
                Utilities.PostAddress("http://" + app5Url + "/api/square", "925");
                SdkContext.DelayProvider.Delay(5000);
                Utilities.Log("CURLing " + app5Url + "/api/square...");
                Utilities.Log("Square of 925 is " + Utilities.PostAddress("http://" + app5Url + "/api/square", "925"));
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
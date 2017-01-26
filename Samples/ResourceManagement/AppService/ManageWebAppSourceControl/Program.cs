// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using CoreFtp;
using Microsoft.Azure.Management.AppService.Fluent;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.Resource.Fluent;
using Microsoft.Azure.Management.Resource.Fluent.Core;
using Microsoft.Azure.Management.Samples.Common;
using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ManageWebAppSourceControl
{
    public class Program
    {
        private const string Suffix = ".azurewebsites.net";

        /**
         * Azure App Service basic sample for managing web apps.
         * Note: you need to have the Git command line available on your PATH. The sample makes a direct call to 'git'.
         *  - Create 4 web apps under the same new app service plan:
         *    - Deploy to 1 using FTP
         *    - Deploy to 2 using local Git repository
         *    - Deploy to 3 using a publicly available Git repository
         *    - Deploy to 4 using a GitHub repository with continuous integration
         */
        public static void RunSample(IAzure azure)
        {
            string app1Name = SdkContext.RandomResourceName("webapp1-", 20);
            string app2Name = SdkContext.RandomResourceName("webapp2-", 20);
            string app3Name = SdkContext.RandomResourceName("webapp3-", 20);
            string app4Name = SdkContext.RandomResourceName("webapp4-", 20);
            string app1Url = app1Name + Suffix;
            string app2Url = app2Name + Suffix;
            string app3Url = app3Name + Suffix;
            string app4Url = app4Name + Suffix;
            string planName = SdkContext.RandomResourceName("jplan_", 15);
            string rgName = SdkContext.RandomResourceName("rg1NEMV_", 24);

            try
            {
                //============================================================
                // Create a web app with a new app service plan

                Utilities.Log("Creating web app " + app1Name + " in resource group " + rgName + "...");

                var app1 = azure.WebApps
                        .Define(app1Name)
                        .WithNewResourceGroup(rgName)
                        .WithNewAppServicePlan(planName)
                        .WithRegion(Region.USWest)
                        .WithPricingTier(AppServicePricingTier.StandardS1)
                        .WithJavaVersion(JavaVersion.V8Newest)
                        .WithWebContainer(WebContainer.Tomcat8_0Newest)
                        .Create();

                Utilities.Log("Created web app " + app1.Name);
                Utilities.Print(app1);

                //============================================================
                // Deploy to app 1 through FTP

                Utilities.Log("Deploying helloworld.War to " + app1Name + " through FTP...");

                UploadFileToFtp(app1.GetPublishingProfile(), "helloworld.war", "Asset/helloworld.war").GetAwaiter().GetResult();

                Utilities.Log("Deployment helloworld.War to web app " + app1.Name + " completed");
                Utilities.Print(app1);

                // warm up
                Utilities.Log("Warming up " + app1Url + "/helloworld...");
                CheckAddress("http://" + app1Url + "/helloworld");
                SdkContext.DelayProvider.Delay(5000, CancellationToken.None).Wait();
                Utilities.Log("CURLing " + app1Url + "/helloworld...");
                Utilities.Log(CheckAddress("http://" + app1Url + "/helloworld"));

                //============================================================
                // Create a second web app with local git source control

                Utilities.Log("Creating another web app " + app2Name + " in resource group " + rgName + "...");
                var plan = azure.AppServices.AppServicePlans.GetByGroup(rgName, planName);
                var app2 = azure.WebApps
                        .Define(app2Name)
                        .WithExistingResourceGroup(rgName)
                        .WithExistingAppServicePlan(plan)
                        .WithLocalGitSourceControl()
                        .WithJavaVersion(JavaVersion.V8Newest)
                        .WithWebContainer(WebContainer.Tomcat8_0Newest)
                        .Create();

                Utilities.Log("Created web app " + app2.Name);
                Utilities.Print(app2);

                //============================================================
                // Deploy to app 2 through local Git

                Utilities.Log("Deploying a local Tomcat source to " + app2Name + " through Git...");

                var profile = app2.GetPublishingProfile();
                string gitCommand = "git";
                string gitInitArgument = @"init";
                string gitAddArgument = @"add -A";
                string gitCommitArgument = @"commit -am ""Initial commit"" ";
                string gitPushArgument = @"push " + string.Format("https://{0}:{1}@{2}", profile.GitUsername, profile.GitPassword, profile.GitUrl) + " master:master -f";

                ProcessStartInfo info = new ProcessStartInfo(gitCommand, gitInitArgument);
                info.WorkingDirectory = "Asset/azure-samples-appservice-helloworld";
                Process.Start(info).WaitForExit();
                info.Arguments = gitAddArgument;
                Process.Start(info).WaitForExit();
                info.Arguments = gitCommitArgument;
                Process.Start(info).WaitForExit();
                info.Arguments = gitPushArgument;
                Process.Start(info).WaitForExit();

                Utilities.Log("Deployment to web app " + app2.Name + " completed");
                Utilities.Print(app2);

                // warm up
                Utilities.Log("Warming up " + app2Url + "/helloworld...");
                CheckAddress("http://" + app2Url + "/helloworld");
                SdkContext.DelayProvider.Delay(5000, CancellationToken.None).Wait();
                Utilities.Log("CURLing " + app2Url + "/helloworld...");
                Utilities.Log(CheckAddress("http://" + app2Url + "/helloworld"));

                //============================================================
                // Create a 3rd web app with a public GitHub repo in Azure-Samples

                Utilities.Log("Creating another web app " + app3Name + "...");
                var app3 = azure.WebApps
                        .Define(app3Name)
                        .WithNewResourceGroup(rgName)
                        .WithExistingAppServicePlan(plan)
                        .DefineSourceControl()
                            .WithPublicGitRepository("https://github.com/Azure-Samples/app-service-web-dotnet-get-started")
                            .WithBranch("master")
                            .Attach()
                        .Create();

                Utilities.Log("Created web app " + app3.Name);
                Utilities.Print(app3);

                // warm up
                Utilities.Log("Warming up " + app3Url + "...");
                CheckAddress("http://" + app3Url);
                SdkContext.DelayProvider.Delay(5000, CancellationToken.None).Wait();
                Utilities.Log("CURLing " + app3Url + "...");
                Utilities.Log(CheckAddress("http://" + app3Url));

                //============================================================
                // Create a 4th web app with a personal GitHub repo and turn on continuous integration

                Utilities.Log("Creating another web app " + app4Name + "...");
                var app4 = azure.WebApps
                        .Define(app4Name)
                        .WithExistingResourceGroup(rgName)
                        .WithExistingAppServicePlan(plan)
                        // Uncomment the following lines to turn on 4th scenario
                        //.DefineSourceControl()
                        //    .WithContinuouslyIntegratedGitHubRepository("username", "reponame")
                        //    .WithBranch("master")
                        //    .WithGitHubAccessToken("YOUR GITHUB PERSONAL TOKEN")
                        //    .Attach()
                        .Create();

                Utilities.Log("Created web app " + app4.Name);
                Utilities.Print(app4);

                // warm up
                Utilities.Log("Warming up " + app4Url + "...");
                CheckAddress("http://" + app4Url);
                SdkContext.DelayProvider.Delay(5000, CancellationToken.None).Wait();
                Utilities.Log("CURLing " + app4Url + "...");
                Utilities.Log(CheckAddress("http://" + app4Url));
            }
            catch (FileNotFoundException)
            {
                Utilities.Log("Cannot find 'git' command line. Make sure Git is installed and the directory of git.exe is included in your PATH environment variable.");
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
                    .WithLogLevel(HttpLoggingDelegatingHandler.Level.BASIC)
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
        
        private static HttpResponseMessage CheckAddress(string url)
        {
            using (var client = new HttpClient())
            {
                return client.GetAsync(url).Result;
            }
        }

        public static async Task UploadFileToFtp(IPublishingProfile profile, string fileName, string filePath)
        {
            string host = profile.FtpUrl.Split(new char[] { '/' }, 2)[0];

            using (var ftpClient = new FtpClient(new FtpClientConfiguration
            {
                Host = host,
                Username = profile.FtpUsername,
                Password = profile.FtpPassword
            }))
            {
                var fileinfo = new FileInfo(filePath);
                await ftpClient.LoginAsync();
                await ftpClient.ChangeWorkingDirectoryAsync("./site/wwwroot/webapps");

                using (var writeStream = await ftpClient.OpenFileWriteStreamAsync(fileName))
                {
                    var fileReadStream = fileinfo.OpenRead();
                    await fileReadStream.CopyToAsync(writeStream);
                }
            }

        }
    }
}
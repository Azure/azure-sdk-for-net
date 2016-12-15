// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using CoreFtp;
using Microsoft.Azure.Management.AppService.Fluent;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.Resource.Fluent;
using Microsoft.Azure.Management.Resource.Fluent.Authentication;
using Microsoft.Azure.Management.Resource.Fluent.Core;
using Microsoft.Azure.Management.Samples.Common;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ManageWebAppSourceControl
{
    /**
     * Azure App Service basic sample for managing web apps.
     *  - Create 4 web apps under the same new app service plan:
     *    - Deploy to 1 using FTP
     *    - Deploy to 2 using local Git repository
     *    - Deploy to 3 using a publicly available Git repository
     *    - Deploy to 4 using a GitHub repository with continuous integration
     */

    public class Program
    {
        private static readonly string suffix = ".azurewebsites.net";
        private static readonly string app1Name = ResourceNamer.RandomResourceName("webapp1-", 20);
        private static readonly string app2Name = ResourceNamer.RandomResourceName("webapp2-", 20);
        private static readonly string app3Name = ResourceNamer.RandomResourceName("webapp3-", 20);
        private static readonly string app4Name = ResourceNamer.RandomResourceName("webapp4-", 20);
        private static readonly string app1Url = app1Name + suffix;
        private static readonly string app2Url = app2Name + suffix;
        private static readonly string app3Url = app3Name + suffix;
        private static readonly string app4Url = app4Name + suffix;
        private static readonly string planName = ResourceNamer.RandomResourceName("jplan_", 15);
        private static readonly string rgName = ResourceNamer.RandomResourceName("rg1NEMV_", 24);

        public static void Main(string[] args)
        {
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
                    //============================================================
                    // Create a web app with a new app service plan

                    Console.WriteLine("Creating web app " + app1Name + " in resource group " + rgName + "...");

                    var app1 = azure.WebApps
                            .Define(app1Name)
                            .WithNewResourceGroup(rgName)
                            .WithNewAppServicePlan(planName)
                            .WithRegion(Region.US_WEST)
                            .WithPricingTier(AppServicePricingTier.Standard_S1)
                            .WithJavaVersion(JavaVersion.Java_8_Newest)
                            .WithWebContainer(WebContainer.Tomcat_8_0_Newest)
                            .Create();

                    Console.WriteLine("Created web app " + app1.Name);
                    Utilities.Print(app1);

                    //============================================================
                    // Deploy to app 1 through FTP

                    Console.WriteLine("Deploying helloworld.War to " + app1Name + " through FTP...");

                    UploadFileToFtp(app1.GetPublishingProfile(), "helloworld.war", "Asset/helloworld.war").GetAwaiter().GetResult();

                    Console.WriteLine("Deployment helloworld.War to web app " + app1.Name + " completed");
                    Utilities.Print(app1);

                    // warm up
                    Console.WriteLine("Warming up " + app1Url + "/helloworld...");
                    CheckAddress("http://" + app1Url + "/helloworld");
                    Thread.Sleep(5000);
                    Console.WriteLine("CURLing " + app1Url + "/helloworld...");
                    Console.WriteLine(CheckAddress("http://" + app1Url + "/helloworld"));

                    //============================================================
                    // Create a second web app with local git source control

                    Console.WriteLine("Creating another web app " + app2Name + " in resource group " + rgName + "...");
                    var plan = azure.AppServices.AppServicePlans.GetByGroup(rgName, planName);
                    var app2 = azure.WebApps
                            .Define(app2Name)
                            .WithExistingResourceGroup(rgName)
                            .WithExistingAppServicePlan(plan)
                            .WithLocalGitSourceControl()
                            .WithJavaVersion(JavaVersion.Java_8_Newest)
                            .WithWebContainer(WebContainer.Tomcat_8_0_Newest)
                            .Create();

                    Console.WriteLine("Created web app " + app2.Name);
                    Utilities.Print(app2);

                    //============================================================
                    // Deploy to app 2 through local Git

                    Console.WriteLine("Deploying a local Tomcat source to " + app2Name + " through Git...");

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

                    Console.WriteLine("Deployment to web app " + app2.Name + " completed");
                    Utilities.Print(app2);

                    // warm up
                    Console.WriteLine("Warming up " + app2Url + "/helloworld...");
                    CheckAddress("http://" + app2Url + "/helloworld");
                    Thread.Sleep(5000);
                    Console.WriteLine("CURLing " + app2Url + "/helloworld...");
                    Console.WriteLine(CheckAddress("http://" + app2Url + "/helloworld"));

                    //============================================================
                    // Create a 3rd web app with a public GitHub repo in Azure-Samples

                    Console.WriteLine("Creating another web app " + app3Name + "...");
                    var app3 = azure.WebApps
                            .Define(app3Name)
                            .WithNewResourceGroup(rgName)
                            .WithExistingAppServicePlan(plan)
                            .DefineSourceControl()
                                .WithPublicGitRepository("https://github.com/Azure-Samples/app-service-web-dotnet-get-started")
                                .WithBranch("master")
                                .Attach()
                            .Create();

                    Console.WriteLine("Created web app " + app3.Name);
                    Utilities.Print(app3);

                    // warm up
                    Console.WriteLine("Warming up " + app3Url + "...");
                    CheckAddress("http://" + app3Url);
                    Thread.Sleep(5000);
                    Console.WriteLine("CURLing " + app3Url + "...");
                    Console.WriteLine(CheckAddress("http://" + app3Url));

                    //============================================================
                    // Create a 4th web app with a personal GitHub repo and turn on continuous integration

                    Console.WriteLine("Creating another web app " + app4Name + "...");
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

                    Console.WriteLine("Created web app " + app4.Name);
                    Utilities.Print(app4);

                    // warm up
                    Console.WriteLine("Warming up " + app4Url + "...");
                    CheckAddress("http://" + app4Url);
                    Thread.Sleep(5000);
                    Console.WriteLine("CURLing " + app4Url + "...");
                    Console.WriteLine(CheckAddress("http://" + app4Url));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                finally
                {
                    try
                    {
                        Console.WriteLine("Deleting Resource Group: " + rgName);
                        azure.ResourceGroups.DeleteByName(rgName);
                        Console.WriteLine("Deleted Resource Group: " + rgName);
                    }
                    catch (NullReferenceException)
                    {
                        Console.WriteLine("Did not create any resources in Azure. No clean up is necessary");
                    }
                    catch (Exception g)
                    {
                        Console.WriteLine(g);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
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
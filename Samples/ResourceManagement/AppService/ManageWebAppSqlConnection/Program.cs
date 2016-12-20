// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.IO;
using System.Net.Http;
using System.Threading;
using Microsoft.Azure.Management.AppService.Fluent;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.Resource.Fluent;
using Microsoft.Azure.Management.Resource.Fluent.Authentication;
using Microsoft.Azure.Management.Resource.Fluent.Core;
using Microsoft.Azure.Management.Samples.Common;
using System.Linq;
using Microsoft.Azure.Management.AppService.Fluent.Models;
using System.Threading.Tasks;
using CoreFtp;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.Azure.Management.Sql.Fluent;

namespace ManageWebAppSqlConnection
{
    /**
     * Azure App Service basic sample for managing web apps.
     *  - Create a SQL database in a new SQL server
     *  - Create a web app deployed with Project Nami (WordPress's SQL Server variant)
     *      that contains the app settings to connect to the SQL database
     *  - Update the SQL server's firewall rules to allow the web app to access
     *  - Clean up
     */

    public class Program
    {
        private static readonly string suffix = ".azurewebsites.net";
        private static readonly string appName = ResourceNamer.RandomResourceName("webapp1-", 20);
        private static readonly string appUrl = appName + suffix;
        private static readonly string sqlServerName = ResourceNamer.RandomResourceName("jsdkserver", 20);
        private static readonly string sqlDbName = ResourceNamer.RandomResourceName("jsdkdb", 20);
        private static readonly string admin = "jsdkadmin";
        private static readonly string password = "StrongPass!123";
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
                    // Create a sql server

                    Console.WriteLine("Creating SQL server " + sqlServerName + "...");

                    ISqlServer server = azure.SqlServers.Define(sqlServerName)
                            .WithRegion(Region.US_WEST)
                            .WithNewResourceGroup(rgName)
                            .WithAdministratorLogin(admin)
                            .WithAdministratorPassword(password)
                            .Create();

                    Console.WriteLine("Created SQL server " + server.Name);

                    //============================================================
                    // Create a sql database for the web app to use

                    Console.WriteLine("Creating SQL database " + sqlDbName + "...");

                    ISqlDatabase db = server.Databases.Define(sqlDbName)
                            .WithoutElasticPool()
                            .WithoutSourceDatabaseId()
                            .Create();

                    Console.WriteLine("Created SQL database " + db.Name);

                    //============================================================
                    // Create a web app with a new app service plan

                    Console.WriteLine("Creating web app " + appName + "...");

                    IWebApp app = azure.WebApps
                            .Define(appName)
                            .WithExistingResourceGroup(rgName)
                            .WithNewAppServicePlan(planName)
                            .WithRegion(Region.US_WEST)
                            .WithPricingTier(AppServicePricingTier.Standard_S1)
                            .WithPhpVersion(PhpVersion.Php5_6)
                            .DefineSourceControl()
                                .WithPublicGitRepository("https://github.com/ProjectNami/projectnami")
                                .WithBranch("master")
                                .Attach()
                            .WithAppSetting("ProjectNami.DBHost", server.FullyQualifiedDomainName)
                            .WithAppSetting("ProjectNami.DBName", db.Name)
                            .WithAppSetting("ProjectNami.DBUser", admin)
                            .WithAppSetting("ProjectNami.DBPass", password)
                            .Create();

                    Console.WriteLine("Created web app " + app.Name);
                    Utilities.Print(app);

                    //============================================================
                    // Allow web app to access the SQL server

                    Console.WriteLine("Allowing web app " + appName + " to access SQL server...");

                    Microsoft.Azure.Management.Sql.Fluent.SqlServer.Update.IUpdate update = server.Update();
                    foreach (var ip in app.OutboundIpAddresses)
                    {
                        update = update.WithNewFirewallRule(ip);
                    }
                    server = update.Apply();

                    Console.WriteLine("Firewall rules added for web app " + appName);
                    Utilities.PrintSqlServer(server);

                    Console.WriteLine("Your WordPress app is ready.");
                    Console.WriteLine("Please navigate to http://" + appUrl + " to finish the GUI setup. Press enter to exit.");
                    Console.ReadLine();

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
    }
}
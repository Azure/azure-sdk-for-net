﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.AppService.Fluent;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.Resource.Fluent;
using Microsoft.Azure.Management.Resource.Fluent.Core;
using Microsoft.Azure.Management.Samples.Common;
using Microsoft.Azure.Management.Sql.Fluent;
using System;
using System.Net.Http;

namespace ManageWebAppSqlConnection
{

    public class Program
    {
        private const string SUFFIX = ".azurewebsites.net";
        private const string ADMIN = "jsdkadmin";
        private const string PASSWORD = "StrongPass!123";

        /**
         * Azure App Service basic sample for managing web apps.
         *  - Create a SQL database in a new SQL server
         *  - Create a web app deployed with Project Nami (WordPress's SQL Server variant)
         *      that contains the app settings to connect to the SQL database
         *  - Update the SQL server's firewall rules to allow the web app to access
         *  - Clean up
         */

        public static void RunSample(IAzure azure)
        {
            string appName = SharedSettings.RandomResourceName("webapp1-", 20);
            string appUrl = appName + SUFFIX;
            string sqlServerName = SharedSettings.RandomResourceName("jsdkserver", 20);
            string sqlDbName = SharedSettings.RandomResourceName("jsdkdb", 20);
            string planName = SharedSettings.RandomResourceName("jplan_", 15);
            string rgName = SharedSettings.RandomResourceName("rg1NEMV_", 24);

            try
            {
                //============================================================
                // Create a sql server

                Utilities.Log("Creating SQL server " + sqlServerName + "...");

                ISqlServer server = azure.SqlServers.Define(sqlServerName)
                        .WithRegion(Region.US_WEST)
                        .WithNewResourceGroup(rgName)
                        .WithAdministratorLogin(ADMIN)
                        .WithAdministratorPassword(PASSWORD)
                        .Create();

                Utilities.Log("Created SQL server " + server.Name);

                //============================================================
                // Create a sql database for the web app to use

                Utilities.Log("Creating SQL database " + sqlDbName + "...");

                ISqlDatabase db = server.Databases.Define(sqlDbName)
                        .Create();

                Utilities.Log("Created SQL database " + db.Name);

                //============================================================
                // Create a web app with a new app service plan

                Utilities.Log("Creating web app " + appName + "...");

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
                        .WithAppSetting("ProjectNami.DBUser", ADMIN)
                        .WithAppSetting("ProjectNami.DBPass", PASSWORD)
                        .Create();

                Utilities.Log("Created web app " + app.Name);
                Utilities.Print(app);

                //============================================================
                // Allow web app to access the SQL server

                Utilities.Log("Allowing web app " + appName + " to access SQL server...");

                Microsoft.Azure.Management.Sql.Fluent.SqlServer.Update.IUpdate update = server.Update();
                foreach (var ip in app.OutboundIpAddresses)
                {
                    update = update.WithNewFirewallRule(ip);
                }
                server = update.Apply();

                Utilities.Log("Firewall rules added for web app " + appName);
                Utilities.PrintSqlServer(server);

                Utilities.Log("Your WordPress app is ready.");
                Utilities.Log("Please navigate to http://" + appUrl + " to finish the GUI setup. Press enter to exit.");
                Utilities.ReadLine();

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
                var credentials = SharedSettings.AzureCredentialsFactory.FromFile(Environment.GetEnvironmentVariable("AZURE_AUTH_LOCATION"));

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
    }
}
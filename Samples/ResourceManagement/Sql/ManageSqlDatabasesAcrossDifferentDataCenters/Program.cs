// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.Compute.Fluent.Models;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.Network.Fluent;
using Microsoft.Azure.Management.Resource.Fluent.Authentication;
using Microsoft.Azure.Management.Resource.Fluent.Core;
using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
using Microsoft.Azure.Management.Samples.Common;
using Microsoft.Azure.Management.Sql.Fluent;
using Microsoft.Azure.Management.Sql.Fluent.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ManageSqlDatabasesAcrossDifferentDataCenters
{
    /**
     * Azure Storage sample for managing SQL Database -
     *  - Create 3 SQL Servers in different region.
     *  - Create a master database in master SQL Server.
     *  - Create 2 more SQL Servers in different azure regions
     *  - Create secondary read only databases in these server with source as database in server created in step 1.
     *  - Create 5 virtual networks in different regions.
     *  - Create one VM in each of the virtual network.
     *  - Update all three databases to have firewall rules with range of each of the virtual network.
     */

    public class Program
    {
        private static readonly string sqlServerName = Utilities.CreateRandomName("sqlserver");
        private static readonly string rgName = Utilities.CreateRandomName("rgRSSDRE");
        private static readonly string administratorLogin = "sqladmin3423";
        private static readonly string administratorPassword = "myS3cureP@ssword";
        private static readonly string slaveSqlServer1Name = "slave1sql";
        private static readonly string slaveSqlServer2Name = "slave2sql";
        private static readonly string databaseName = "mydatabase";
        private static readonly string networkNamePrefix = "network";
        private static readonly string virtualMachineNamePrefix = "samplevm";

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
                    // ============================================================
                    // Create a SQL Server, with 2 firewall rules.

                    var masterSqlServer = azure.SqlServers.Define(sqlServerName)
                            .WithRegion(Region.US_EAST)
                            .WithNewResourceGroup(rgName)
                            .WithAdministratorLogin(administratorLogin)
                            .WithAdministratorPassword(administratorPassword)
                            .Create();

                    Utilities.PrintSqlServer(masterSqlServer);

                    // ============================================================
                    // Create a Database in master SQL server created above.
                    Console.WriteLine("Creating a database");

                    var masterDatabase = masterSqlServer.Databases.Define(databaseName)
                            .WithEdition(DatabaseEditions.Basic)
                            .Create();
                    Utilities.PrintDatabase(masterDatabase);

                    // Create secondary databases for the master database
                    var sqlServerInSecondaryLocation = azure.SqlServers
                            .Define(Utilities.CreateRandomName(slaveSqlServer1Name))
                            .WithRegion(masterDatabase.DefaultSecondaryLocation)
                            .WithExistingResourceGroup(rgName)
                            .WithAdministratorLogin(administratorLogin)
                            .WithAdministratorPassword(administratorPassword)
                            .Create();
                    Utilities.PrintSqlServer(sqlServerInSecondaryLocation);

                    Console.WriteLine("Creating database in slave SQL Server.");
                    var secondaryDatabase = sqlServerInSecondaryLocation.Databases.Define(databaseName)
                            .WithSourceDatabase(masterDatabase)
                            .WithMode(CreateMode.OnlineSecondary)
                            .Create();
                    Utilities.PrintDatabase(secondaryDatabase);

                    var sqlServerInEurope = azure.SqlServers
                            .Define(Utilities.CreateRandomName(slaveSqlServer2Name))
                            .WithRegion(Region.EUROPE_WEST)
                            .WithExistingResourceGroup(rgName)
                            .WithAdministratorLogin(administratorLogin)
                            .WithAdministratorPassword(administratorPassword)
                            .Create();
                    Utilities.PrintSqlServer(sqlServerInEurope);

                    Console.WriteLine("Creating database in second slave SQL Server.");
                    var secondaryDatabaseInEurope = sqlServerInEurope.Databases.Define(databaseName)
                            .WithSourceDatabase(masterDatabase)
                            .WithMode(CreateMode.OnlineSecondary)
                            .Create();
                    Utilities.PrintDatabase(secondaryDatabaseInEurope);

                    // ============================================================
                    // Create Virtual Networks in different regions
                    var regions = new List<Region>();

                    regions.Add(Region.US_EAST);
                    regions.Add(Region.US_WEST);
                    regions.Add(Region.EUROPE_NORTH);
                    regions.Add(Region.ASIA_SOUTHEAST);
                    regions.Add(Region.JAPAN_EAST);

                    var creatableNetworks = new List<ICreatable<INetwork>>();

                    Console.WriteLine("Creating virtual networks in different regions.");

                    foreach (Region region in regions)
                    {
                        creatableNetworks.Add(azure.Networks.Define(Utilities.CreateRandomName(networkNamePrefix))
                                .WithRegion(region)
                                .WithExistingResourceGroup(rgName));
                    }
                    var networks = azure.Networks.Create(creatableNetworks.ToArray());

                    // ============================================================
                    // Create virtual machines attached to different virtual networks created above.
                    var creatableVirtualMachines = new List<ICreatable<IVirtualMachine>>();

                    foreach (var network in networks)
                    {
                        var vmName = Utilities.CreateRandomName(virtualMachineNamePrefix);
                        var publicIpAddressCreatable = azure.PublicIpAddresses
                                .Define(vmName)
                                .WithRegion(network.Region)
                                .WithExistingResourceGroup(rgName)
                                .WithLeafDomainLabel(vmName);
                        creatableVirtualMachines.Add(azure.VirtualMachines.Define(vmName)
                                .WithRegion(network.Region)
                                .WithExistingResourceGroup(rgName)
                                .WithExistingPrimaryNetwork(network)
                                .WithSubnet(network.Subnets.Values.First().Name)
                                .WithPrimaryPrivateIpAddressDynamic()
                                .WithNewPrimaryPublicIpAddress(publicIpAddressCreatable)
                                .WithPopularWindowsImage(KnownWindowsVirtualMachineImage.WINDOWS_SERVER_2012_R2_DATACENTER)
                                .WithAdminUsername(administratorLogin)
                                .WithAdminPassword(administratorPassword)
                                .WithSize(VirtualMachineSizeTypes.StandardD3V2));
                    }
                    var ipAddresses = new Dictionary<string, string>();
                    var virtualMachines = azure.VirtualMachines.Create(creatableVirtualMachines.ToArray());
                    foreach (var virtualMachine in virtualMachines)
                    {
                        ipAddresses.Add(virtualMachine.Name, virtualMachine.GetPrimaryPublicIpAddress().IpAddress);
                    }

                    Console.WriteLine("Adding firewall rule for each of virtual network network");

                    var sqlServers = new List<ISqlServer>();
                    sqlServers.Add(sqlServerInSecondaryLocation);
                    sqlServers.Add(sqlServerInEurope);
                    sqlServers.Add(masterSqlServer);

                    foreach (var sqlServer in sqlServers)
                    {
                        foreach (var ipAddress in ipAddresses)
                        {
                            sqlServer.FirewallRules.Define(ipAddress.Key).WithIpAddress(ipAddress.Value).Create();
                        }
                    }

                    foreach (var sqlServer in sqlServers)
                    {
                        Console.WriteLine("Print firewall rules in Sql Server in " + sqlServer.RegionName);

                        var firewallRules = sqlServer.FirewallRules.List();
                        foreach (var firewallRule in firewallRules)
                        {
                            Utilities.PrintFirewallRule(firewallRule);
                        }
                    }

                    // Delete the SQL Server.
                    Console.WriteLine("Deleting all Sql Servers");
                    foreach (var sqlServer in sqlServers)
                    {
                        azure.SqlServers.DeleteById(sqlServer.Id);
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
                        Console.WriteLine("Deleting Resource Group: " + rgName);
                        azure.ResourceGroups.DeleteByName(rgName);
                        Console.WriteLine("Deleted Resource Group: " + rgName);
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
    }
}
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.Resource.Fluent;
using Microsoft.Azure.Management.Resource.Fluent.Authentication;
using Microsoft.Azure.Management.Resource.Fluent.Core;
using Microsoft.Azure.Management.KeyVault.Fluent.Models;
using Microsoft.Azure.Management.Samples.Common;
using System;

namespace ManageKeyVault
{
    /**
     * Azure Key Vault sample for managing key vaults -
     *  - Create a key vault
     *  - Authorize an application
     *  - Update a key vault
     *    - alter configurations
     *    - change permissions
     *  - Create another key vault
     *  - List key vaults
     *  - Delete a key vault.
     */

    public class Program
    {
        private static readonly string vaultName1 = ResourceNamer.RandomResourceName("vault1", 20);
        private static readonly string vaultName2 = ResourceNamer.RandomResourceName("vault2", 20);
        private static readonly string rgName = ResourceNamer.RandomResourceName("rgNEMV", 24);

        public static void Main(string[] args)
        {
            try
            {
                //=================================================================
                // Authenticate
                AzureCredentials credentials = AzureCredentials.FromFile(Environment.GetEnvironmentVariable("AZURE_AUTH_LOCATION"));

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
                    // Create a key vault with empty access policy

                    Console.WriteLine("Creating a key vault...");

                    var vault1 = azure.Vaults
                            .Define(vaultName1)
                            .WithRegion(Region.US_WEST)
                            .WithNewResourceGroup(rgName)
                            .WithEmptyAccessPolicy()
                            .Create();

                    Console.WriteLine("Created key vault");
                    Utilities.PrintVault(vault1);

                    //============================================================
                    // Authorize an application

                    Console.WriteLine("Authorizing the application associated with the current service principal...");

                    vault1 = vault1.Update()
                            .DefineAccessPolicy()
                                .ForServicePrincipal(AzureCredentials.FromFile(Environment.GetEnvironmentVariable("AZURE_AUTH_LOCATION")).ClientId)
                                .AllowKeyAllPermissions()
                                .AllowSecretPermissions(SecretPermissions.Get)
                                .AllowSecretPermissions(SecretPermissions.List)
                                .Attach()
                            .Apply();

                    Console.WriteLine("Updated key vault");
                    Utilities.PrintVault(vault1);

                    //============================================================
                    // Update a key vault

                    Console.WriteLine("Update a key vault to enable deployments and add permissions to the application...");

                    vault1 = vault1.Update()
                            .WithDeploymentEnabled()
                            .WithTemplateDeploymentEnabled()
                            .UpdateAccessPolicy(vault1.AccessPolicies[0].ObjectId)
                                .AllowSecretAllPermissions()
                                .Parent()
                            .Apply();

                    Console.WriteLine("Updated key vault");
                    // Print the network security group
                    Utilities.PrintVault(vault1);

                    //============================================================
                    // Create another key vault

                    var vault2 = azure.Vaults
                            .Define(vaultName2)
                            .WithRegion(Region.US_EAST)
                            .WithExistingResourceGroup(rgName)
                            .DefineAccessPolicy()
                                .ForServicePrincipal(AzureCredentials.FromFile(Environment.GetEnvironmentVariable("AZURE_AUTH_LOCATION")).ClientId)
                                .AllowKeyPermissions(KeyPermissions.List)
                                .AllowKeyPermissions(KeyPermissions.Get)
                                .AllowKeyPermissions(KeyPermissions.Decrypt)
                                .AllowSecretPermissions(SecretPermissions.Get)
                                .Attach()
                            .Create();

                    Console.WriteLine("Created key vault");
                    // Print the network security group
                    Utilities.PrintVault(vault2);

                    //============================================================
                    // List key vaults

                    Console.WriteLine("Listing key vaults...");

                    foreach (var vault in azure.Vaults.ListByGroup(rgName))
                    {
                        Utilities.PrintVault(vault);
                    }

                    //============================================================
                    // Delete key vaults
                    Console.WriteLine("Deleting the key vaults");
                    azure.Vaults.Delete(vault1.Id);
                    azure.Vaults.Delete(vault2.Id);
                    Console.WriteLine("Deleted the key vaults");
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
                        azure.ResourceGroups.Delete(rgName);
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
    }
}
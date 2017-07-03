// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.KeyVault.Fluent.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Authentication;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Samples.Common;
using System;

namespace ManageKeyVault
{
    public class Program
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
        public static void RunSample(IAzure azure)
        {
            string vaultName1 = SdkContext.RandomResourceName("vault1", 20);
            string vaultName2 = SdkContext.RandomResourceName("vault2", 20);
            string rgName = SdkContext.RandomResourceName("rgNEMV", 24);
            try
            {
                //============================================================
                // Create a key vault with empty access policy

                Utilities.Log("Creating a key vault...");

                var vault1 = azure.Vaults
                        .Define(vaultName1)
                        .WithRegion(Region.USWest)
                        .WithNewResourceGroup(rgName)
                        .WithEmptyAccessPolicy()
                        .Create();

                Utilities.Log("Created key vault");
                Utilities.PrintVault(vault1);

                //============================================================
                // Authorize an application

                Utilities.Log("Authorizing the application associated with the current service principal...");

                vault1 = vault1.Update()
                        .DefineAccessPolicy()
                            .ForServicePrincipal(SdkContext.AzureCredentialsFactory.FromFile(Environment.GetEnvironmentVariable("AZURE_AUTH_LOCATION")).ClientId)
                            .AllowKeyAllPermissions()
                            .AllowSecretPermissions(SecretPermissions.Get)
                            .AllowSecretPermissions(SecretPermissions.List)
                            .Attach()
                        .Apply();

                Utilities.Log("Updated key vault");
                Utilities.PrintVault(vault1);

                //============================================================
                // Update a key vault

                Utilities.Log("Update a key vault to enable deployments and add permissions to the application...");

                vault1 = vault1.Update()
                        .WithDeploymentEnabled()
                        .WithTemplateDeploymentEnabled()
                        .UpdateAccessPolicy(vault1.AccessPolicies[0].ObjectId)
                            .AllowSecretAllPermissions()
                            .Parent()
                        .Apply();

                Utilities.Log("Updated key vault");
                // Print the network security group
                Utilities.PrintVault(vault1);

                //============================================================
                // Create another key vault

                var vault2 = azure.Vaults
                        .Define(vaultName2)
                        .WithRegion(Region.USEast)
                        .WithExistingResourceGroup(rgName)
                        .DefineAccessPolicy()
                            .ForServicePrincipal(SdkContext.AzureCredentialsFactory.FromFile(Environment.GetEnvironmentVariable("AZURE_AUTH_LOCATION")).ClientId)
                            .AllowKeyPermissions(KeyPermissions.List)
                            .AllowKeyPermissions(KeyPermissions.Get)
                            .AllowKeyPermissions(KeyPermissions.Decrypt)
                            .AllowSecretPermissions(SecretPermissions.Get)
                            .Attach()
                        .Create();

                Utilities.Log("Created key vault");
                // Print the network security group
                Utilities.PrintVault(vault2);

                //============================================================
                // List key vaults

                Utilities.Log("Listing key vaults...");

                foreach (var vault in azure.Vaults.ListByResourceGroup(rgName))
                {
                    Utilities.PrintVault(vault);
                }

                //============================================================
                // Delete key vaults
                Utilities.Log("Deleting the key vaults");
                azure.Vaults.DeleteById(vault1.Id);
                azure.Vaults.DeleteById(vault2.Id);
                Utilities.Log("Deleted the key vaults");
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
                AzureCredentials credentials = SdkContext.AzureCredentialsFactory.FromFile(Environment.GetEnvironmentVariable("AZURE_AUTH_LOCATION"));

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
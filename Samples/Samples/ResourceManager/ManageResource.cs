// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Authentication;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Samples.Common;
using System;

namespace ManageResource
{
    public class Program
    {
        /**
        * Azure Resource sample for managing resources -
        * - Create a resource
        * - Update a resource
        * - Create another resource
        * - List resources
        * - Delete a resource.
        */
        public static void RunSample(IAzure azure)
        {
            var resourceGroupName = SdkContext.RandomResourceName("rgRSMR", 24);
            var resourceName1 = SdkContext.RandomResourceName("rn1", 24);
            var resourceName2 = SdkContext.RandomResourceName("rn2", 24);

            try
            {
                //=============================================================
                // Create resource group.

                Utilities.Log("Creating a resource group with name: " + resourceGroupName);

                azure.ResourceGroups
                    .Define(resourceGroupName)
                    .WithRegion(Region.USWest)
                    .Create();

                //=============================================================
                // Create storage account.

                Utilities.Log("Creating a storage account with name: " + resourceName1);

                var storageAccount = azure.StorageAccounts
                    .Define(resourceName1)
                    .WithRegion(Region.USWest)
                    .WithExistingResourceGroup(resourceGroupName)
                    .Create();

                Utilities.Log("Storage account created: " + storageAccount.Id);

                //=============================================================
                // Update - set the sku name

                Utilities.Log("Updating the storage account with name: " + resourceName1);

                storageAccount.Update()
                    .WithSku(Microsoft.Azure.Management.Storage.Fluent.Models.SkuName.StandardRAGRS)
                    .Apply();

                Utilities.Log("Updated the storage account with name: " + resourceName1);

                //=============================================================
                // Create another storage account.

                Utilities.Log("Creating another storage account with name: " + resourceName2);

                var storageAccount2 = azure.StorageAccounts.Define(resourceName2)
                    .WithRegion(Region.USWest)
                    .WithExistingResourceGroup(resourceGroupName)
                    .Create();

                Utilities.Log("Storage account created: " + storageAccount2.Id);

                //=============================================================
                // List storage accounts.

                Utilities.Log("Listing all storage accounts for resource group: " + resourceGroupName);

                foreach (var sAccount in azure.StorageAccounts.List())
                {
                    Utilities.Log("Storage account: " + sAccount.Name);
                }

                //=============================================================
                // Delete a storage accounts.

                Utilities.Log("Deleting storage account: " + resourceName2);

                azure.StorageAccounts.DeleteById(storageAccount2.Id);

                Utilities.Log("Deleted storage account: " + resourceName2);
            }
            catch (Exception ex)
            {
                Utilities.Log(ex);
            }
            finally
            {
                try
                {
                    Utilities.Log("Deleting Resource Group: " + resourceGroupName);
                    azure.ResourceGroups.DeleteByName(resourceGroupName);
                    Utilities.Log("Deleted Resource Group: " + resourceGroupName);
                }
                catch (Exception ex)
                {
                    Utilities.Log(ex);
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

                RunSample(azure);
            }
            catch (Exception ex)
            {
                Utilities.Log(ex);
            }
        }
    }
}
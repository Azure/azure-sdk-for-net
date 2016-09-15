using Microsoft.Azure.Management;
using Microsoft.Azure.Management.V2.Resource;
using Microsoft.Azure.Management.V2.Resource.Authentication;
using Microsoft.Azure.Management.V2.Resource.Core;
using System;

namespace Samples
{
    public static class ManageResource
    {
        /**
         * Azure Resource sample for managing resources -
         * - Create a resource
         * - Update a resource
         * - Create another resource
         * - List resources
         * - Delete a resource.
         */

        public static void TestManageResource()
        {
            var rgName = ResourceNamer.RandomResourceName("rgRSMA", 24);
            var resourceName1 = ResourceNamer.RandomResourceName("rn1", 24);
            var resourceName2 = ResourceNamer.RandomResourceName("rn2", 24);

            try
            {
                //=================================================================
                // Authenticate

                var tokenCredentials = new ApplicationTokenCredentials(Environment.GetEnvironmentVariable("AZURE_AUTH_LOCATION"));

                var azure = Azure
                    .Configure()
                    .withLogLevel(HttpLoggingDelegatingHandler.Level.BODY)
                    .Authenticate(tokenCredentials).WithSubscription(tokenCredentials.DefaultSubscriptionId);

                try
                {
                    //=============================================================
                    // Create resource group.

                    Console.WriteLine("Creating a resource group with name: " + rgName);

                    azure.ResourceGroups
                        .Define(rgName)
                        .WithRegion(Region.US_WEST)
                        .Create();

                    //=============================================================
                    // Create storage account.

                    Console.WriteLine("Creating a storage account with name: " + resourceName1);

                    var storageAccount = azure.StorageAccounts
                        .Define(resourceName1)
                        .WithRegion(Region.US_WEST)
                        .WithExistingResourceGroup(rgName)
                            .Create();

                    Console.WriteLine("Storage account created: " + storageAccount.Id);

                    //=============================================================
                    // Update - set the sku name

                    Console.WriteLine("Updating the storage account with name: " + resourceName1);

                    storageAccount.Update()
                        .WithSku(Microsoft.Azure.Management.Storage.Models.SkuName.StandardRAGRS)
                        .Apply();

                    Console.WriteLine("Updated the storage account with name: " + resourceName1);

                    //=============================================================
                    // Create another storage account.

                    Console.WriteLine("Creating another storage account with name: " + resourceName2);

                    var storageAccount2 = azure.StorageAccounts.Define(resourceName2)
                        .WithRegion(Region.US_WEST)
                        .WithExistingResourceGroup(rgName)
                        .Create();

                    Console.WriteLine("Storage account created: " + storageAccount2.Id);

                    //=============================================================
                    // List storage accounts.

                    Console.WriteLine("Listing all storage accounts for resource group: " + rgName);

                    foreach (var sAccount in azure.StorageAccounts.List())
                    {
                        Console.WriteLine("Storage account: " + sAccount.Name);
                    }

                    //=============================================================
                    // Delete a storage accounts.

                    Console.WriteLine("Deleting storage account: " + resourceName2);

                    azure.StorageAccounts.Delete(storageAccount2.Id);

                    Console.WriteLine("Deleted storage account: " + resourceName2);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                finally
                {
                    try
                    {
                        Console.WriteLine("Deleting Resource Group: " + rgName);
                        azure.ResourceGroups.Delete(rgName);
                        Console.WriteLine("Deleted Resource Group: " + rgName);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Search.Fluent;
using Microsoft.Azure.Management.Search.Fluent.Models;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Authentication;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Samples.Common;
using System;

namespace ManageSearch
{
    public class Program
    {
        private static readonly Region Region = Region.USEast;


        /**
         * Azure Search sample for managing search service.
         *  - Create a Search service resource with a free SKU
         *  - Create a Search service resource with a standard SKU, one replica and one partition
         *  - Create a new query key and delete a query key
         *  - Update the Search service with three replicas and three partitions
         *  - Regenerate the primary and secondary admin keys
         *  - Delete the Search service
         */
        public static void RunSample(IAzure azure)
        {
            string rgName = SdkContext.RandomResourceName("rgSearch", 15);
            string searchServiceName = SdkContext.RandomResourceName("search", 20);

            try
            {
                //=============================================================
                // Check if the name for the Azure Search service to be created is available

                if (!azure.SearchServices.CheckNameAvailability(searchServiceName).IsAvailable)
                {
                    throw new Exception("Search service name is not available: " + searchServiceName);
                }

                // Azure limits the number of free Search service resource to one per subscription
                // List all Search services in the subscription and skip if there is already one resource of type free SKU
                var createFreeService = true;
                var resources = azure.SearchServices.List();
                foreach (var item in resources)
                {
                    if (item.Sku.Name.Equals(Microsoft.Azure.Management.Search.Fluent.Models.SkuName.Free))
                    {
                        createFreeService = false;
                        break;
                    }
                }

                if (createFreeService)
                {
                    //=============================================================
                    // Create a Azure Search service resource with a "free" SKU

                    Utilities.Log("Creating an Azure Search service using \"free\" SKU");

                    ISearchService searchServiceFree = azure.SearchServices.Define(searchServiceName + "free")
                        .WithRegion(Region)
                        .WithNewResourceGroup(rgName)
                        .WithFreeSku()
                        .Create();

                    Utilities.Log("Created Azure Search service with free SKU: " + searchServiceFree.Id);
                    Utilities.Print(searchServiceFree);
                }

                //=============================================================
                // Create an Azure Search service resource of type Standard SKU

                Utilities.Log("Creating an Azure Search service");

                ISearchService searchService = azure.SearchServices.Define(searchServiceName)
                        .WithRegion(Region)
                        .WithNewResourceGroup(rgName)
                        .WithStandardSku()
                        .WithPartitionCount(1)
                        .WithReplicaCount(1)
                        .Create();

                Utilities.Log("Created Azure Search service with standard SKU: " + searchService.Id);
                Utilities.Print(searchService);


                //=============================================================
                // Iterate through the Azure Search service resources

                Utilities.Log("List all the Azure Search services for a given resource group");

                foreach (ISearchService service in azure.SearchServices.ListByResourceGroup(rgName))
                {
                    Utilities.Print(service);
                }


                //=============================================================
                // Add a query key for the Search service resource

                Utilities.Log("Add a query key to an Azure Search service");

                searchService.CreateQueryKey("testKey1");


                //=============================================================
                // Regenerate the admin keys for an Azure Search service resource

                Utilities.Log("Regenerate the admin keys for an Azure Search service");

                searchService.RegenerateAdminKeys(AdminKeyKind.Primary);
                searchService.RegenerateAdminKeys(AdminKeyKind.Secondary);


                //=============================================================
                // Update the Search service to use three replicas and three partitions and update the tags

                Utilities.Log("Update an Azure Search service");

                searchService = searchService.Update()
                        .WithTag("tag2", "value2")
                        .WithTag("tag3", "value3")
                        .WithoutTag("tag1")
                        .WithReplicaCount(1)
                        .WithPartitionCount(2)
                        .Apply();

                Utilities.Print(searchService);


                //=============================================================
                // Delete a query key for an Azure Search service resource

                Utilities.Log("Delete a query key for an Azure Search service");

                searchService.DeleteQueryKey(searchService.ListQueryKeys()[1].Key);

                Utilities.Print(searchService);


                //=============================================================
                // Delete the Search service resource

                Utilities.Log("Delete an Azure Search service resource");

                azure.SearchServices.DeleteByResourceGroup(rgName, searchServiceName);

            }
            finally
            {
                try
                {
                    Utilities.Log("Deleting Resource Group: " + rgName);
                    azure.ResourceGroups.BeginDeleteByName(rgName);
                    Utilities.Log("Deleted Resource Group: " + rgName);
                }
                catch (Exception)
                {
                    Utilities.Log("Did not create any resources in Azure. No clean up is necessary");
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
            catch (Exception ex)
            {
                Utilities.Log(ex);
            }
        }
    }
}
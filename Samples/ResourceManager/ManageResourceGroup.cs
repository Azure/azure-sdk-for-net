// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Authentication;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Samples.Common;
using System;

namespace ManageResourceGroup
{
    public class Program
    {
        /**
         * Azure Resource sample for managing resource groups -
         * - Create a resource group
         * - Update a resource group
         * - Create another resource group
         * - List resource groups
         * - Delete a resource group.
         */
        public static void RunSample(IAzure azure)
        {
            var rgName = SdkContext.RandomResourceName("rgRSMA", 24);
            var rgName2 = SdkContext.RandomResourceName("rgRSMA", 24);
            var resourceTagName = SdkContext.RandomResourceName("rgRSTN", 24);
            var resourceTagValue = SdkContext.RandomResourceName("rgRSTV", 24);
            
            try
            {
                //=============================================================
                // Create resource group.

                Utilities.Log("Creating a resource group with name: " + rgName);

                var resourceGroup = azure.ResourceGroups
                        .Define(rgName)
                        .WithRegion(Region.USWest)
                        .Create();

                Utilities.Log("Created a resource group with name: " + rgName);

                //=============================================================
                // Update the resource group.

                Utilities.Log("Updating the resource group with name: " + rgName);

                resourceGroup.Update()
                    .WithTag(resourceTagName, resourceTagValue)
                    .Apply();

                Utilities.Log("Updated the resource group with name: " + rgName);

                //=============================================================
                // Create another resource group.

                Utilities.Log("Creating another resource group with name: " + rgName2);

                var resourceGroup2 = azure.ResourceGroups
                    .Define(rgName2)
                    .WithRegion(Region.USWest)
                    .Create();

                Utilities.Log("Created another resource group with name: " + rgName2);

                //=============================================================
                // List resource groups.

                Utilities.Log("Listing all resource groups");

                foreach (var rGroup in azure.ResourceGroups.List())
                {
                    Utilities.Log("Resource group: " + rGroup.Name);
                }

                //=============================================================
                // Delete a resource group.

                Utilities.Log("Deleting resource group: " + rgName2);

                azure.ResourceGroups.DeleteByName(rgName2);

                Utilities.Log("Deleted resource group: " + rgName2);
            }
            finally
            {
                try
                {
                    Utilities.Log("Deleting Resource Group: " + rgName);
                    azure.ResourceGroups.DeleteByName(rgName);
                    Utilities.Log("Deleted Resource Group: " + rgName);
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
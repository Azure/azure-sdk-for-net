// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.Resource.Fluent;
using Microsoft.Azure.Management.Resource.Fluent.Authentication;
using Microsoft.Azure.Management.Resource.Fluent.Core;
using System;

namespace ManageResourceGroup
{
    /**
     * Azure Resource sample for managing resource groups -
     * - Create a resource group
     * - Update a resource group
     * - Create another resource group
     * - List resource groups
     * - Delete a resource group.
     */

    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var rgName = ResourceNamer.RandomResourceName("rgRSMA", 24);
                var rgName2 = ResourceNamer.RandomResourceName("rgRSMA", 24);
                var resourceTagName = ResourceNamer.RandomResourceName("rgRSTN", 24);
                var resourceTagValue = ResourceNamer.RandomResourceName("rgRSTV", 24);

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

                    try
                    {
                        //=============================================================
                        // Create resource group.

                        Console.WriteLine("Creating a resource group with name: " + rgName);

                        var resourceGroup = azure.ResourceGroups
                                .Define(rgName)
                                .WithRegion(Region.US_WEST)
                                .Create();

                        Console.WriteLine("Created a resource group with name: " + rgName);

                        //=============================================================
                        // Update the resource group.

                        Console.WriteLine("Updating the resource group with name: " + rgName);

                        resourceGroup.Update()
                            .WithTag(resourceTagName, resourceTagValue)
                            .Apply();

                        Console.WriteLine("Updated the resource group with name: " + rgName);

                        //=============================================================
                        // Create another resource group.

                        Console.WriteLine("Creating another resource group with name: " + rgName2);

                        var resourceGroup2 = azure.ResourceGroups
                            .Define(rgName2)
                            .WithRegion(Region.US_WEST)
                            .Create();

                        Console.WriteLine("Created another resource group with name: " + rgName2);

                        //=============================================================
                        // List resource groups.

                        Console.WriteLine("Listing all resource groups");

                        foreach (var rGroup in azure.ResourceGroups.List())
                        {
                            Console.WriteLine("Resource group: " + rGroup.Name);
                        }

                        //=============================================================
                        // Delete a resource group.

                        Console.WriteLine("Deleting resource group: " + rgName2);

                        azure.ResourceGroups.DeleteByName(rgName2);

                        Console.WriteLine("Deleted resource group: " + rgName2);
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
                            azure.ResourceGroups.DeleteByName(rgName);
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
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
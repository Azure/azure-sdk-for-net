using Microsoft.Azure.Management;
using Microsoft.Azure.Management.V2.Resource;
using Microsoft.Azure.Management.V2.Resource.Authentication;
using Microsoft.Azure.Management.V2.Resource.Core;
using System;

namespace Samples
{
    public static class ManageResourceGroup
    {
        /**
         * Azure Resource sample for managing resource groups -
         * - Create a resource group
         * - Update a resource group
         * - Create another resource group
         * - List resource groups
         * - Delete a resource group.
         */

        public static void TestManageResourceGroup()
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
                            .Define(rgName)
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

                        azure.ResourceGroups.Delete(rgName2);

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
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
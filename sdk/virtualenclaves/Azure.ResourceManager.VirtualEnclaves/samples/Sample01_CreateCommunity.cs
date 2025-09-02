// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.VirtualEnclaves;
using Azure.ResourceManager.VirtualEnclaves.Models;

namespace Azure.ResourceManager.VirtualEnclaves.Samples
{
    public class Sample01_CreateCommunity
    {
        public static async Task Main(string[] args)
        {
            try
            {
                // Initialize the client with logging
                var options = new ArmClientOptions();
                options.Diagnostics.IsLoggingEnabled = true;
                options.Diagnostics.IsDistributedTracingEnabled = true;

                var credential = new DefaultAzureCredential();
                var client = new ArmClient(credential, default, options);

                // Get specific subscription
                string subscriptionId = "your_subscription_id";
                var subscription = await client.GetSubscriptions().GetAsync(subscriptionId);

                // Get existing resource group
                string resourceGroupName = "your_resource_group";
                Console.WriteLine($"Getting resource group {resourceGroupName}...");
                var resourceGroup = await subscription.Value.GetResourceGroupAsync(resourceGroupName);

                // Create community configuration
                var communityData = new CommunityResourceData(AzureLocation.WestUS)
                {
                    Properties = new CommunityProperties
                    {
                        // Configure DNS servers (using same value as test)
                        DnsServers = { "168.63.129.16" },

                        // Configure address space with valid subnet mask between /8 and /17
                        AddressSpace = "10.0.0.0/16"
                    },
                    Tags =
                    {
                        ["purpose"] = "demo",
                        ["environment"] = "development"
                    }
                };

                // Create the community
                string communityName = "your_community_name";
                Console.WriteLine($"Creating community {communityName}...");

                var communities = resourceGroup.Value.GetCommunityResources();
                var operation = await communities.CreateOrUpdateAsync(
                    WaitUntil.Completed,
                    communityName,
                    communityData);

                var community = operation.Value;
                Console.WriteLine($"Created community with ID: {community.Data.Id}");

                // Verify address space availability
                var addressSpaceCheck = new CheckAddressSpaceAvailabilityContent(
                    community.Id,
                    new EnclaveVirtualNetworkModel
                    {
                        NetworkSize = "small",
                        CustomCidrRange = "10.0.0.0/16",
                        SubnetConfigurations = { new SubnetConfiguration("default", 20) },
                        AllowSubnetCommunication = true
                    });

                Console.WriteLine("Checking address space availability...");
                var availabilityResponse = await community.CheckAddressSpaceAvailabilityAsync(addressSpaceCheck);
                Console.WriteLine($"Address space availability check result: {availabilityResponse.Value.Value}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}

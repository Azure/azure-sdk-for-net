// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information. 

using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.Redis.Fluent.Models;
using Microsoft.Azure.Management.Resource.Fluent;
using Microsoft.Azure.Management.Resource.Fluent.Authentication;
using Microsoft.Azure.Management.Resource.Fluent.Core;
using Microsoft.Azure.Management.Samples.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManageRedis
{
    public class Program
    {
        /**
         * Azure Redis sample for managing Redis Cache:
         *  - Create a Redis Cache and print out hostname.
         *  - Get access keys.
         *  - Regenerate access keys.
         *  - Create another 2 Redis Caches with Premium Sku.
         *  - List all Redis Caches in a resource group – for each cache with Premium Sku:
         *     - set Redis patch schedule to Monday at 5 am.
         *     - update shard count.
         *     - enable non-SSL port.
         *     - modify max memory policy and reserved settings.
         *     - restart it.
         *  - Clean up all resources.
         */
        public static void Main(string[] args)
        {
            var redisCacheName1 = Utilities.CreateRandomName("rc1");
            var redisCacheName2 = Utilities.CreateRandomName("rc2");
            var redisCacheName3 = Utilities.CreateRandomName("rc3");
            var rgName = Utilities.CreateRandomName("rgRCMC");

            try
            {
                var tokenCredentials = AzureCredentials.FromFile(Environment.GetEnvironmentVariable("AZURE_AUTH_LOCATION"));

                var azure = Azure
                    .Configure()
                    .WithLogLevel(HttpLoggingDelegatingHandler.Level.BODY)
                    .Authenticate(tokenCredentials).WithSubscription(tokenCredentials.DefaultSubscriptionId);

                // Print selected subscription
                Console.WriteLine("Selected subscription: " + azure.SubscriptionId);

                try
                {
                    // ============================================================
                    // Create a Redis cache

                    Console.WriteLine("Creating a Redis Cache");

                    var redisCache1 = azure.RedisCaches.Define(redisCacheName1)
                            .WithRegion(Region.US_CENTRAL)
                            .WithNewResourceGroup(rgName)
                            .WithBasicSku()
                            .Create();

                    Console.WriteLine("Created a Redis Cache:");
                    Utilities.PrintRedisCache(redisCache1);

                    // ============================================================
                    // Get | regenerate Redis Cache access keys

                    Console.WriteLine("Getting Redis Cache access keys");
                    var redisAccessKeys = redisCache1.Keys;
                    Utilities.PrintRedisAccessKeys(redisAccessKeys);

                    Console.WriteLine("Regenerating secondary Redis Cache access key");
                    redisAccessKeys = redisCache1.RegenerateKey(RedisKeyType.Secondary);
                    Utilities.PrintRedisAccessKeys(redisAccessKeys);

                    // ============================================================
                    // Create another two Redis Caches

                    Console.WriteLine("Creating two more Redis Caches with Premium Sku");

                    var redisCache2 = azure.RedisCaches.Define(redisCacheName2)
                            .WithRegion(Region.US_CENTRAL)
                            .WithNewResourceGroup(rgName)
                            .WithPremiumSku()
                            .Create();

                    Console.WriteLine("Created a Redis Cache:");
                    Utilities.PrintRedisCache(redisCache2);

                    var redisCache3 = azure.RedisCaches.Define(redisCacheName3)
                            .WithRegion(Region.US_CENTRAL)
                            .WithNewResourceGroup(rgName)
                            .WithPremiumSku(2)
                            .Create();

                    Console.WriteLine("Created a Redis Cache:");
                    Utilities.PrintRedisCache(redisCache3);

                    // ============================================================
                    // List Redis Caches inside the resource group

                    Console.WriteLine("Listing Redis Caches");

                    var redisCaches = azure.RedisCaches;

                    // List Redis Caches and select Premium Sku instances only
                    var caches = redisCaches.ListByGroup(rgName)
                        .Where(rc => rc.IsPremium)
                        .Select(rc => rc.AsPremium());

                    foreach (var premium in caches)
                    {
                        // Update each Premium Sku Redis Cache instance
                        Console.WriteLine("Updating Premium Redis Cache");
                        premium.Update()
                                .WithPatchSchedule(Microsoft.Azure.Management.Redis.Fluent.Models.DayOfWeek.Monday, 5)
                                .WithShardCount(4)
                                .WithNonSslPort()
                                .WithRedisConfiguration("maxmemory-policy", "allkeys-random")
                                .WithRedisConfiguration("maxmemory-reserved", "20")
                                .Apply();

                        Console.WriteLine("Updated Redis Cache:");
                        Utilities.PrintRedisCache(premium);

                        // Restart Redis Cache
                        Console.WriteLine("Restarting updated Redis Cache");
                        premium.ForceReboot(RebootType.AllNodes);

                        Console.WriteLine("Redis Cache restart scheduled");
                    }

                    // ============================================================
                    // Delete a Redis Cache

                    Console.WriteLine("Deleting a Redis Cache  - " + redisCache1.Name);

                    azure.RedisCaches.DeleteById(redisCache1.Id);

                    Console.WriteLine("Deleted Redis Cache");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                finally
                {
                    if (azure.ResourceGroups.GetByName(rgName) != null)
                    {
                        Console.WriteLine("Deleting Resource Group: " + rgName);
                        azure.ResourceGroups.DeleteByName(rgName);
                        Console.WriteLine("Deleted Resource Group: " + rgName);
                    }
                    else
                    {
                        Console.WriteLine("Did not create any resources in Azure. No clean up is necessary");
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

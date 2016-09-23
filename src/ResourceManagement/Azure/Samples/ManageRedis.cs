// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management;
using Microsoft.Azure.Management.Fluent.Redis;
using Microsoft.Azure.Management.Fluent.Redis.Models;
using Microsoft.Azure.Management.V2.Resource.Authentication;
using Microsoft.Azure.Management.V2.Resource.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DayOfWeek = Microsoft.Azure.Management.Fluent.Redis.Models.DayOfWeek;

namespace Samples
{
    public static class ManageRedis
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
        public static void TestRedisCache()
        {
            var redisCacheName1 = Utilities.createRandomName("rc1");
            var redisCacheName2 = Utilities.createRandomName("rc2");
            var redisCacheName3 = Utilities.createRandomName("rc3");
            var rgName = Utilities.createRandomName("rgRCMC");

            try
            {
                var tokenCredentials = new ApplicationTokenCredentials(Environment.GetEnvironmentVariable("AZURE_AUTH_LOCATION"));

                var azure = Azure
                    .Configure()
                    .withLogLevel(HttpLoggingDelegatingHandler.Level.BODY)
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
                    var redisAccessKeys = redisCache1.Keys();
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
                        .Where( rc => rc.IsPremium)
                        .Select( rc => rc.AsPremium());

                    foreach(var premium in caches)
                    {
                        // Update each Premium Sku Redis Cache instance
                        Console.WriteLine("Updating Premium Redis Cache");
                        premium.Update()
                                .WithPatchSchedule(DayOfWeek.Monday, 5)
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

                    azure.RedisCaches.Delete(redisCache1.Id);

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
                        azure.ResourceGroups.Delete(rgName);
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

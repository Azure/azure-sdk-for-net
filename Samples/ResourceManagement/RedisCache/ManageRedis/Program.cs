// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information. 

using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.Redis.Fluent.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
using Microsoft.Azure.Management.Samples.Common;
using System;
using System.Linq;

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
        public static void RunSample(IAzure azure)
        {
            var redisCacheName1 = SdkContext.RandomResourceName("rc1", 20);
            var redisCacheName2 = SdkContext.RandomResourceName("rc2", 20);
            var redisCacheName3 = SdkContext.RandomResourceName("rc3", 20);
            var rgName = SdkContext.RandomResourceName("rgRCMC", 20);

            try
            {
                // ============================================================
                // Create a Redis cache

                Utilities.Log("Creating a Redis Cache");

                var redisCache1 = azure.RedisCaches.Define(redisCacheName1)
                        .WithRegion(Region.USCentral)
                        .WithNewResourceGroup(rgName)
                        .WithBasicSku()
                        .Create();

                Utilities.Log("Created a Redis Cache:");
                Utilities.PrintRedisCache(redisCache1);

                // ============================================================
                // Get | regenerate Redis Cache access keys

                Utilities.Log("Getting Redis Cache access keys");
                var redisAccessKeys = redisCache1.GetKeys();
                Utilities.PrintRedisAccessKeys(redisAccessKeys);

                Utilities.Log("Regenerating secondary Redis Cache access key");
                redisAccessKeys = redisCache1.RegenerateKey(RedisKeyType.Secondary);
                Utilities.PrintRedisAccessKeys(redisAccessKeys);

                // ============================================================
                // Create another two Redis Caches

                Utilities.Log("Creating two more Redis Caches with Premium Sku");

                var redisCache2 = azure.RedisCaches.Define(redisCacheName2)
                        .WithRegion(Region.USCentral)
                        .WithNewResourceGroup(rgName)
                        .WithPremiumSku()
                        .WithShardCount(3)
                        .Create();

                Utilities.Log("Created a Redis Cache:");
                Utilities.PrintRedisCache(redisCache2);

                var redisCache3 = azure.RedisCaches.Define(redisCacheName3)
                        .WithRegion(Region.USCentral)
                        .WithNewResourceGroup(rgName)
                        .WithPremiumSku(2)
                        .WithShardCount(3)
                        .Create();

                Utilities.Log("Created a Redis Cache:");
                Utilities.PrintRedisCache(redisCache3);

                // ============================================================
                // List Redis Caches inside the resource group

                Utilities.Log("Listing Redis Caches");

                var redisCaches = azure.RedisCaches;

                // List Redis Caches and select Premium Sku instances only
                var caches = redisCaches.ListByResourceGroup(rgName)
                    .Where(rc => rc.IsPremium)
                    .Select(rc => rc.AsPremium());

                foreach (var premium in caches)
                {
                    // Update each Premium Sku Redis Cache instance
                    Utilities.Log("Updating Premium Redis Cache");
                    premium.Update()
                            .WithPatchSchedule(Microsoft.Azure.Management.Redis.Fluent.Models.DayOfWeek.Monday, 5)
                            .WithShardCount(4)
                            .WithNonSslPort()
                            .WithRedisConfiguration("maxmemory-policy", "allkeys-random")
                            .WithRedisConfiguration("maxmemory-reserved", "20")
                            .Apply();

                    Utilities.Log("Updated Redis Cache:");
                    Utilities.PrintRedisCache(premium);

                    // Restart Redis Cache
                    Utilities.Log("Restarting updated Redis Cache");
                    premium.ForceReboot(RebootType.AllNodes, 1);

                    Utilities.Log("Redis Cache restart scheduled");
                }

                // ============================================================
                // Delete a Redis Cache

                Utilities.Log("Deleting a Redis Cache  - " + redisCache1.Name);

                azure.RedisCaches.DeleteById(redisCache1.Id);

                Utilities.Log("Deleted Redis Cache");
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
                var tokenCredentials = SdkContext.AzureCredentialsFactory.FromFile(Environment.GetEnvironmentVariable("AZURE_AUTH_LOCATION"));

                var azure = Azure
                    .Configure()
                    .WithLogLevel(HttpLoggingDelegatingHandler.Level.BodyAndHeaders)
                    .Authenticate(tokenCredentials).WithSubscription(tokenCredentials.DefaultSubscriptionId);

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

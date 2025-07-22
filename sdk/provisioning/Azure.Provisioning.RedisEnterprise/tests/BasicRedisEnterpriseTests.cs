// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.RedisEnterprise.Tests;

public class BasicRedisEnterpriseTests(bool async) : ProvisioningTestBase(async)
{
    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.cache/redis-enterprise-vectordb/main.bicep")]
    public async Task CreateRedisEnterpriseVectorDB()
    {
        await using Trycep test = CreateBicepTest();
        await test.Define(
            ctx =>
            {
                Infrastructure infra = new();
                RedisEnterpriseCluster redisEnterprise =
                    new("redisEnterprise", "2022-01-01")
                    {
                        Sku = new RedisEnterpriseSku
                        {
                            Name = RedisEnterpriseSkuName.EnterpriseE10,
                            Capacity = 2
                        }
                    };
                infra.Add(redisEnterprise);
                RedisEnterpriseDatabase database =
                    new("redisDatabase", "2022-01-01")
                    {
                        Name = "default",
                        Parent = redisEnterprise,
                        EvictionPolicy = RedisEnterpriseEvictionPolicy.NoEviction,
                        ClusteringPolicy = RedisEnterpriseClusteringPolicy.EnterpriseCluster,
                        Modules =
                        [
                            new RedisEnterpriseModule { Name = "RediSearch" },
                            new RedisEnterpriseModule { Name = "RedisJSON" }
                        ],
                        Port = 10000
                    };
                infra.Add(database);
                return infra;
            })
        .Compare(
            """
            @description('The location for the resource(s) to be deployed.')
            param location string = resourceGroup().location

            resource redisEnterprise 'Microsoft.Cache/redisEnterprise@2022-01-01' = {
              name: take('redisenterprise${uniqueString(resourceGroup().id)}', 24)
              location: location
              sku: {
                name: 'Enterprise_E10'
                capacity: 2
              }
            }

            resource redisDatabase 'Microsoft.Cache/redisEnterprise/databases@2022-01-01' = {
              name: 'default'
              properties: {
                clusteringPolicy: 'EnterpriseCluster'
                evictionPolicy: 'NoEviction'
                modules: [
                  {
                    name: 'RediSearch'
                  }
                  {
                    name: 'RedisJSON'
                  }
                ]
                port: 10000
              }
              parent: redisEnterprise
            }
            """)
        .Lint()
        .ValidateAsync(); // Just validate...  Deploying takes a hot minute.
    }
}

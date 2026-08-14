// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.RedisEnterprise.Tests;

public class BasicRedisEnterpriseTests
{
    internal static Trycep CreateRedisEnterpriseVectorDBTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                #region Snippet:RedisEnterpriseBasic
                Infrastructure infra = new();
                ProvisioningParameter principalId = new ProvisioningParameter("principalId", typeof(string))
                {
                    Description = "The principal ID of the user assigned identity to use for the Redis Enterprise cluster."
                };
                infra.Add(principalId);
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
                AccessPolicyAssignment accessPolicyAssignment =
                    new("accessPolicyAssignment", "2022-01-01")
                    {
                        Parent = database,
                        AccessPolicyName = "default",
                        UserObjectId = principalId
                    };
                infra.Add(accessPolicyAssignment);
                #endregion
                return infra;
            });
    }

    [Test]
    [Description("https://github.com/Azure/azure-quickstart-templates/blob/master/quickstarts/microsoft.cache/redis-enterprise-vectordb/main.bicep")]
    public async Task CreateRedisEnterpriseVectorDB()
    {
        await using Trycep test = CreateRedisEnterpriseVectorDBTest();
        test.Compare(
            """
            @description('The principal ID of the user assigned identity to use for the Redis Enterprise cluster.')
            param principalId string

            @description('The location for the resource(s) to be deployed.')
            param location string = resourceGroup().location

            resource redisEnterprise 'Microsoft.Cache/redisEnterprise@2022-01-01' = {
              name: take('redisEnterprise-${uniqueString(resourceGroup().id)}', 60)
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

            resource accessPolicyAssignment 'Microsoft.Cache/redisEnterprise/databases/accessPolicyAssignments@2022-01-01' = {
              name: take('accessPolicyAssignment${uniqueString(resourceGroup().id)}', 60)
              properties: {
                accessPolicyName: 'default'
                user: {
                  objectId: principalId
                }
              }
              parent: redisDatabase
            }
            """);
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Sql.Tests
{
    public class SqlManagementTestUtilities
    {
        public static string DefaultLocation
        {
            get
            {
                return "Japan East";
            }
        }

        public static SqlManagementClient GetSqlManagementClient(MockContext context, RecordedDelegatingHandler handler = null)
        {
            if (handler != null)
            {
                handler.IsPassThrough = true;
            }

            var client = context.GetServiceClient<SqlManagementClient>(handlers:
                handler ?? new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
            return client;
        }
        
        public static ResourceManagementClient GetResourceManagementClient(MockContext context, RecordedDelegatingHandler handler)
        {
            handler.IsPassThrough = true;
            var client = context.GetServiceClient<ResourceManagementClient>(handlers: handler);
            return client;
        }

        public static string GenerateName(
            string prefix = null,
            [System.Runtime.CompilerServices.CallerMemberName]
            string methodName="GenerateName_failed")
        {
            return HttpMockServer.GetAssetName(methodName, prefix);
        }

        public static string GenerateIpAddress()
        {
            Random r = new Random();
            return String.Format("{0}.{1}.{2}.{3}", r.Next(256), r.Next(256), r.Next(256), r.Next(256));
        }

        public static void AssertCollection<T>(IEnumerable<T> expected, IEnumerable<T> actual)
        {
            Assert.Equal(expected.Count(), actual.Count());

            foreach (var elem in expected)
            {
                Assert.True(actual.Contains(elem));
            }

            foreach (var elem in actual)
            {
                Assert.True(expected.Contains(elem));
            }
        }

        public static void ValidateServer(Microsoft.Azure.Management.Sql.Models.Server actual, string name, string login, string version, Dictionary<string, string> tags, string location)
        {
            Assert.NotNull(actual);
            Assert.Equal(name, actual.Name);
            Assert.Equal(login, actual.AdministratorLogin);
            Assert.Equal(version, actual.Version);
            SqlManagementTestUtilities.AssertCollection(tags, actual.Tags);
            Assert.Equal(location, actual.Location);
        }

        public static void ValidateDatabase(Database expected, Database actual, string name)
        {
            Assert.Equal(name, actual.Name);
            Assert.Equal(expected.Location, actual.Location);
            Assert.Equal(expected.ElasticPoolName, actual.ElasticPoolName);
            Assert.NotNull(actual.CreationDate);
            Assert.NotNull(actual.DatabaseId);
            Assert.NotNull(actual.Id);
            Assert.NotNull(actual.Type);

            if (!string.IsNullOrEmpty(expected.Collation))
            {
                Assert.Equal(expected.Collation, actual.Collation);
            }
            else
            {
                Assert.NotNull(actual.Collation);
            }

            if (!string.IsNullOrEmpty(expected.Edition))
            {
                Assert.Equal(expected.Edition, actual.Edition);
            }
            else
            {
                Assert.NotNull(actual.Edition);
            }

            if (expected.MaxSizeBytes != null)
            {
                Assert.Equal(expected.MaxSizeBytes, actual.MaxSizeBytes);
            }
            else
            {
                Assert.NotNull(actual.MaxSizeBytes);
            }

            if (expected.RequestedServiceObjectiveId != null)
            {
                Assert.Equal(expected.RequestedServiceObjectiveId, actual.RequestedServiceObjectiveId);
            }
            else
            {
                Assert.NotNull(actual.RequestedServiceObjectiveId);
            }

            if (!string.IsNullOrEmpty(expected.RequestedServiceObjectiveName))
            {
                Assert.Equal(expected.RequestedServiceObjectiveName, actual.RequestedServiceObjectiveName);
            }
            else
            {
                Assert.NotNull(actual.RequestedServiceObjectiveName);
            }

            if (expected.Tags != null)
            {
                SqlManagementTestUtilities.AssertCollection(expected.Tags, actual.Tags);
            }
        }

        public static void ValidateDatabaseEx(Database expected, Database actual)
        {
            Assert.Equal(expected.Name, actual.Name);
            Assert.Equal(expected.Location, actual.Location);
            Assert.Equal(expected.ElasticPoolName, actual.ElasticPoolName);
            Assert.NotNull(actual.CreationDate);
            Assert.NotNull(actual.DatabaseId);
            Assert.NotNull(actual.Id);
            Assert.NotNull(actual.Type);

            if (!string.IsNullOrEmpty(expected.Collation))
            {
                Assert.Equal(expected.Collation, actual.Collation);
            }
            else
            {
                Assert.NotNull(actual.Collation);
            }

            if (!string.IsNullOrEmpty(expected.Edition))
            {
                Assert.Equal(expected.Edition, actual.Edition);
            }
            else
            {
                Assert.NotNull(actual.Edition);
            }

            if (expected.MaxSizeBytes != null)
            {
                Assert.Equal(expected.MaxSizeBytes, actual.MaxSizeBytes);
            }
            else
            {
                Assert.NotNull(actual.MaxSizeBytes);
            }

            if (expected.RequestedServiceObjectiveId != null)
            {
                Assert.Equal(expected.RequestedServiceObjectiveId, actual.RequestedServiceObjectiveId);
            }
            else
            {
                Assert.NotNull(actual.RequestedServiceObjectiveId);
            }

            if (!string.IsNullOrEmpty(expected.RequestedServiceObjectiveName))
            {
                Assert.Equal(expected.RequestedServiceObjectiveName, actual.RequestedServiceObjectiveName);
            }
            else
            {
                Assert.NotNull(actual.RequestedServiceObjectiveName);
            }

            if (expected.Tags != null)
            {
                SqlManagementTestUtilities.AssertCollection(expected.Tags, actual.Tags);
            }
        }

        public static void ValidateElasticPool(ElasticPool expected, ElasticPool actual, string name)
        {
            Assert.Equal(name, actual.Name);
            Assert.Equal(expected.Location, actual.Location);

            if (expected.Edition != null)
            {
                Assert.Equal(expected.Edition, actual.Edition);
            }
            else
            {
                Assert.NotNull(actual.Edition);
            }

            if(expected.Tags != null)
            {
                AssertCollection(expected.Tags, actual.Tags);
            }

            Assert.NotNull(actual.CreationDate);
            Assert.NotNull(actual.DatabaseDtuMax);
            Assert.NotNull(actual.DatabaseDtuMin);
            Assert.NotNull(actual.Dtu);
            Assert.NotNull(actual.Id);
            Assert.NotNull(actual.State);
            Assert.NotNull(actual.StorageMB);
            Assert.NotNull(actual.Type);
        }

        public static void ValidateFirewallRule(FirewallRule expected, FirewallRule actual, string name)
        {
            Assert.NotNull(actual.Id);
            Assert.Equal(expected.StartIpAddress, actual.StartIpAddress);
            Assert.Equal(expected.EndIpAddress, actual.EndIpAddress);
        }

        public static void RunTestInNewResourceGroup(string suiteName, string testName, string resourcePrefix, Action<ResourceManagementClient, SqlManagementClient, ResourceGroup> test)
        {
            using (MockContext context = MockContext.Start(suiteName, testName))
            {
                var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
                var resourceClient = SqlManagementTestUtilities.GetResourceManagementClient(context, handler);
                var sqlClient = SqlManagementTestUtilities.GetSqlManagementClient(context, handler);

                ResourceGroup resourceGroup = null;

                try
                {
                    string rgName = SqlManagementTestUtilities.GenerateName(resourcePrefix);
                    resourceGroup = resourceClient.ResourceGroups.CreateOrUpdate(
                        rgName,
                        new ResourceGroup
                        {
                            Location = SqlManagementTestUtilities.DefaultLocation,
                            Tags = new Dictionary<string, string>() { { rgName, DateTime.UtcNow.ToString("u") } }
                        });

                    test(resourceClient, sqlClient, resourceGroup);
                }
                finally
                {
                    if (resourceGroup != null)
                    {
                        resourceClient.ResourceGroups.Delete(resourceGroup.Name);
                    }
                }
            }
        }

        internal static void RunTestInNewV12Server(string suiteName, string testName, string testPrefix, Action<ResourceManagementClient, SqlManagementClient, ResourceGroup, Server> test)
        {
            RunTestInNewResourceGroup(suiteName, testName, testPrefix, (resClient, sqlClient, resGroup) =>
            {
                string serverNameV12 = SqlManagementTestUtilities.GenerateName(testPrefix);
                string login = "dummylogin";
                string password = "Un53cuRE!";
                string version12 = "12.0";
                Dictionary<string, string> tags = new Dictionary<string, string>()
                    {
                        { "tagKey1", "TagValue1" }
                    };

                var v12Server = sqlClient.Servers.CreateOrUpdate(resGroup.Name, serverNameV12, new Microsoft.Azure.Management.Sql.Models.Server()
                {
                    AdministratorLogin = login,
                    AdministratorLoginPassword = password,
                    Version = version12,
                    Tags = tags,
                    Location = SqlManagementTestUtilities.DefaultLocation,
                });
                SqlManagementTestUtilities.ValidateServer(v12Server, serverNameV12, login, version12, tags, SqlManagementTestUtilities.DefaultLocation);

                test(resClient, sqlClient, resGroup, v12Server);
            });
        }

        internal static Task<Database[]> CreateDatabasesAsync(
            SqlManagementClient sqlClient,
            string resourceGroupName,
            Server server,
            string testPrefix,
            int count)
        {
            List<Task<Database>> createDbTasks = new List<Task<Database>>();
            for (int i = 0; i < count; i++)
            {
                string name = SqlManagementTestUtilities.GenerateName(testPrefix);
                createDbTasks.Add(sqlClient.Databases.CreateOrUpdateAsync(
                    resourceGroupName,
                    server.Name, 
                    name,
                    new Database()
                    {
                        Location = server.Location
                    }));
            }

            // Wait for all databases to be created.
            return Task.WhenAll(createDbTasks);
        }
    }
}

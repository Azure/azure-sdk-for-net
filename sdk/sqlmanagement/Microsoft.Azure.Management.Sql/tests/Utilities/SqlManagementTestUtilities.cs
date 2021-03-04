// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Microsoft.Azure.Management.ResourceManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;
using Microsoft.Azure.Management.KeyVault;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.KeyVault.Models;
using Microsoft.Azure.Management.KeyVault.Models;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Sql.Tests.Utilities;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Azure.KeyVault.WebKey;
using Microsoft.Rest.Azure;
using System.Threading;
using System.Net.Http;

namespace Sql.Tests
{
    public class SqlManagementTestUtilities
    {
        public const string DefaultLogin = "dummylogin";
        public const string DefaultPassword = "Un53cuRE!";

        public const string TestPrefix = "sqlcrudtest-";

        public const string TestPublicMaintenanceConfiguration = "DB_1";

        public static string GenerateName(
            string prefix = TestPrefix,
            [System.Runtime.CompilerServices.CallerMemberName]
            string methodName="GenerateName_failed")
        {
            try
            {
                return HttpMockServer.GetAssetName(methodName, prefix);
            }
            catch (KeyNotFoundException e)
            {
                throw new KeyNotFoundException(string.Format("Generated name not found for calling method: {0}", methodName), e);
            }
        }

        public static string GenerateIpAddress()
        {
            Random r = new Random();
            return String.Format("{0}.{1}.{2}.{3}", r.Next(256), r.Next(256), r.Next(256), r.Next(256));
        }

        public static void AssertCollection<T>(IEnumerable<T> expected, IEnumerable<T> actual)
        {
            if (Equals(expected, actual))
            {
                return;
            }

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

        public static void ValidateServer(Server actual, string name, string login, string version, Dictionary<string, string> tags, string location, string publicNetworkAccess = null, string minimalTlsVersion = null)
        {
            Assert.NotNull(actual);
            Assert.Equal(name, actual.Name);
            Assert.Equal(login, actual.AdministratorLogin);
            Assert.Equal(version, actual.Version);
            SqlManagementTestUtilities.AssertCollection(tags, actual.Tags);

            // Location is being returned two different ways across different APIs.
            Assert.Equal(location.ToLower().Replace(" ", ""), actual.Location.ToLower().Replace(" ", ""));

            if (publicNetworkAccess != null)
            {
                Assert.Equal(publicNetworkAccess, actual.PublicNetworkAccess);
            }

            if (minimalTlsVersion != null)
            {
                Assert.Equal(minimalTlsVersion, actual.MinimalTlsVersion);
            }
        }

        public static void ValidateInstancePool(
            InstancePool actual, string name, int vCores, string subnetId, string location, Dictionary<string, string> tags)
        {
            Assert.NotNull(actual);

            Assert.Equal(name, actual.Name);
            Assert.Equal(vCores, actual.VCores);
            Assert.Equal(subnetId, actual.SubnetId);
            SqlManagementTestUtilities.AssertCollection(tags, actual.Tags);

            // Location is being returned two different ways across different APIs.
            Assert.Equal(location.ToLower().Replace(" ", ""), actual.Location.ToLower().Replace(" ", ""));
        }

        public static void ValidateInstancePoolUsage(
            Usage actual,
            int? currentValue,
            int? limit,
            int? requestedLimit,
            string usageName)
        {
            Assert.NotNull(actual);
            Assert.Equal(currentValue, actual.CurrentValue);
            Assert.Equal(limit, actual.Limit);
            Assert.Equal(requestedLimit, actual.RequestedLimit);
            Assert.Equal(usageName, actual.Name.Value);
        }

        public static void ValidateManagedInstance(ManagedInstance actual, string name, string login, Dictionary<string, string> tags, string location, string instancePoolId = null, bool shouldCheckState = false)
        {
            Assert.NotNull(actual);
            Assert.Equal(name, actual.Name);
            Assert.Equal(login, actual.AdministratorLogin);

            if (shouldCheckState)
            {
                Assert.Equal("Succeeded", actual.ProvisioningState);
            }

            SqlManagementTestUtilities.AssertCollection(tags, actual.Tags);

            if (instancePoolId != null)
            {
                Assert.Equal(actual.InstancePoolId, instancePoolId);
            }

            // Location is being returned two different ways across different APIs.
            Assert.Equal(location.ToLower().Replace(" ", ""), actual.Location.ToLower().Replace(" ", ""));
        }

        public static void ValidateManagedInstanceOperation(ManagedInstanceOperation actual, string operationName, string operationFriendlyName, int percentComplete, string state, bool isCancellable)
        {
            Assert.NotNull(actual);
            Assert.Equal(operationName, actual.Name);
            Assert.Equal(operationFriendlyName, actual.OperationFriendlyName);
            Assert.Equal(percentComplete, actual.PercentComplete);
            Assert.Equal(state, actual.State);
            Assert.Equal(isCancellable, actual.IsCancellable);
        }

        public static void ValidateDatabase(dynamic expected, Database actual, string name)
        {
            Assert.Equal(name, actual.Name);
            Assert.Equal(expected.ElasticPoolName, actual.ElasticPoolName);
            Assert.NotNull(actual.CreationDate);
            Assert.NotNull(actual.DatabaseId);
            Assert.NotNull(actual.Id);
            Assert.NotNull(actual.Type);

            // Old 2014-04-01 apis return en-us location friendly name, e.g. "Japan East",
            // newer apis return locaion id e.g. "japaneast". This makes comparison
            // logic annoying until we have a newer api-version for database.
            //Assert.Equal(expected.Location, actual.Location);

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
                AssertCollection(expected.Tags, actual.Tags);
            }

            if (expected.ReadScale != null)
            {
                Assert.Equal(expected.ReadScale, actual.ReadScale);
            }

            if (expected.HighAvailabilityReplicaCount != null)
            {
                Assert.Equal(expected.HighAvailabilityReplicaCount, actual.HighAvailabilityReplicaCount);
            }

            if (!string.IsNullOrEmpty(expected.StorageAccountType))
            {
                Assert.Equal(expected.StorageAccountType, actual.StorageAccountType);
            }

            if (!string.IsNullOrEmpty(expected.MaintenanceConfigurationId))
            {
                Assert.Equal(expected.MaintenanceConfigurationId, actual.MaintenanceConfigurationId);
            }
        }

        public static void ValidateDatabaseEx(Database expected, Database actual)
        {
            Assert.Equal(expected.Name, actual.Name);
            Assert.Equal(expected.ElasticPoolName, actual.ElasticPoolName);
            Assert.NotNull(actual.CreationDate);
            Assert.NotNull(actual.DatabaseId);
            Assert.NotNull(actual.Id);
            Assert.NotNull(actual.Type);

            // Old 2014-04-01 apis return en-us location friendly name, e.g. "Japan East",
            // newer apis return locaion id e.g. "japaneast". This makes comparison
            // logic annoying until we have a newer api-version for database.
            //Assert.Equal(expected.Location, actual.Location);

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

		public static void ValidateManagedDatabase(dynamic expected, ManagedDatabase actual, string name)
        {
            Assert.Equal(name, actual.Name);
            Assert.NotNull(actual.CreationDate);
            Assert.NotNull(actual.Id);
            Assert.NotNull(actual.Type);

            // Old 2014-04-01 apis return en-us location friendly name, e.g. "Japan East",
            // newer apis return locaion id e.g. "japaneast". This makes comparison
            // logic annoying until we have a newer api-version for database.
            //Assert.Equal(expected.Location, actual.Location);

            if (!string.IsNullOrEmpty(expected.Collation))
            {
                Assert.Equal(expected.Collation, actual.Collation);
            }
            else
            {
                Assert.NotNull(actual.Collation);
            }

            if (expected.Location != null)
            {
                Assert.Equal(expected.Location, actual.Location);
            }
            else
            {
                Assert.NotNull(actual.Location);
            }
        }

        public static void ValidateManagedDatabaseEx(ManagedDatabase expected, ManagedDatabase actual)
        {
            Assert.Equal(expected.Name, actual.Name);
            Assert.NotNull(actual.CreationDate);
            Assert.NotNull(actual.Id);
            Assert.NotNull(actual.Type);

            // Old 2014-04-01 apis return en-us location friendly name, e.g. "Japan East",
            // newer apis return locaion id e.g. "japaneast". This makes comparison
            // logic annoying until we have a newer api-version for database.
            //Assert.Equal(expected.Location, actual.Location);

            if (!string.IsNullOrEmpty(expected.Collation))
            {
                Assert.Equal(expected.Collation, actual.Collation);
            }
            else
            {
                Assert.NotNull(actual.Collation);
            }

            if (expected.Location != null)
            {
                Assert.Equal(expected.Location, actual.Location);
            }
            else
            {
                Assert.NotNull(actual.Location);
            }
        }

        public static void ValidateElasticPool(dynamic expected, ElasticPool actual, string name)
        {
            Assert.Equal(name, actual.Name);

            // Old 2014-04-01 apis return en-us location friendly name, e.g. "Japan East",
            // newer apis return locaion id e.g. "japaneast". This makes comparison
            // logic annoying until we have a newer api-version for elastic pool.
            //Assert.Equal(expected.Location, actual.Location);

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

            if (!string.IsNullOrEmpty(expected.MaintenanceConfigurationId))
            {
                Assert.Equal(expected.MaintenanceConfigurationId, actual.MaintenanceConfigurationId);
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

        public static void ValidateFailoverGroup(FailoverGroup expected, FailoverGroup actual, string name)
        {
            Assert.NotNull(actual);
            Assert.NotNull(actual.Id);
            Assert.NotNull(actual.Type);
            Assert.NotNull(actual.Location);

            Assert.Equal(name, actual.Name);
            Assert.Equal(expected.ReadOnlyEndpoint.FailoverPolicy, actual.ReadOnlyEndpoint.FailoverPolicy);
            Assert.Equal(expected.ReadWriteEndpoint.FailoverPolicy, actual.ReadWriteEndpoint.FailoverPolicy);
            Assert.Equal(expected.ReadWriteEndpoint.FailoverWithDataLossGracePeriodMinutes, actual.ReadWriteEndpoint.FailoverWithDataLossGracePeriodMinutes);

            AssertCollection(expected.Databases, actual.Databases);
            AssertCollection(expected.PartnerServers.Select(s => s.Id), actual.PartnerServers.Select(s => s.Id));
            AssertCollection(expected.Tags, actual.Tags);
        }

        public static void ValidateInstanceFailoverGroup(InstanceFailoverGroup expected, InstanceFailoverGroup actual, string name)
        {
            Assert.NotNull(actual);
            Assert.NotNull(actual.Id);
            Assert.NotNull(actual.Type);

            Assert.Equal(name, actual.Name);
            Assert.Equal(expected.ReadOnlyEndpoint.FailoverPolicy, actual.ReadOnlyEndpoint.FailoverPolicy);
            Assert.Equal(expected.ReadWriteEndpoint.FailoverPolicy, actual.ReadWriteEndpoint.FailoverPolicy);
            Assert.Equal(expected.ReadWriteEndpoint.FailoverWithDataLossGracePeriodMinutes, actual.ReadWriteEndpoint.FailoverWithDataLossGracePeriodMinutes);

            Assert.Equal(expected.ManagedInstancePairs.FirstOrDefault().PrimaryManagedInstanceId, actual.ManagedInstancePairs.FirstOrDefault().PrimaryManagedInstanceId);
            Assert.Equal(expected.ManagedInstancePairs.FirstOrDefault().PartnerManagedInstanceId, actual.ManagedInstancePairs.FirstOrDefault().PartnerManagedInstanceId);
        }

        public static void ValidateFirewallRule(FirewallRule expected, FirewallRule actual, string name)
        {
            Assert.NotNull(actual.Id);
            Assert.Equal(expected.StartIpAddress, actual.StartIpAddress);
            Assert.Equal(expected.EndIpAddress, actual.EndIpAddress);
        }

        public static void ValidateServerKey(ServerKey actual, string expectedName, string expectedKeyType, string expectedUri)
        {
            Assert.NotNull(actual);
            Assert.Equal(expectedName, actual.Name);
            Assert.Equal(expectedKeyType, actual.ServerKeyType);
            Assert.Equal(expectedUri, actual.Uri);
        }

        public static void ValidateManagedInstanceKey(ManagedInstanceKey actual, string expectedName, string expectedKeyType, string expectedUri)
        {
            Assert.NotNull(actual);
            Assert.Equal(expectedName, actual.Name);
            Assert.Equal(expectedKeyType, actual.ServerKeyType);
            Assert.Equal(expectedUri, actual.Uri);
        }

        public static void ValidateVirtualNetworkRule(VirtualNetworkRule expected, VirtualNetworkRule actual, string name)
        {
            Assert.NotNull(actual.Id);
            Assert.Equal(expected.VirtualNetworkSubnetId, actual.VirtualNetworkSubnetId);
        }

        public static void ValidatePrivateEndpointConnection(PrivateEndpointConnection expected, PrivateEndpointConnection actual)
        {
            Assert.NotNull(actual);
            Assert.Equal(expected.Id, actual.Id);
            Assert.Equal(expected.PrivateLinkServiceConnectionState.Status, actual.PrivateLinkServiceConnectionState.Status);
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
                string name = SqlManagementTestUtilities.GenerateName();
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

		internal static Task<ManagedDatabase[]> CreateManagedDatabasesAsync(
            SqlManagementClient sqlClient,
            string resourceGroupName,
            ManagedInstance managedInstance,
            string testPrefix,
            int count)
        {
            List<Task<ManagedDatabase>> createDbTasks = new List<Task<ManagedDatabase>>();
            for (int i = 0; i < count; i++)
            {
                string name = SqlManagementTestUtilities.GenerateName();
                createDbTasks.Add(sqlClient.ManagedDatabases.CreateOrUpdateAsync(
                    resourceGroupName,
                    managedInstance.Name,
                    name,
                    new ManagedDatabase()
                    {
                        Location = managedInstance.Location
                    }));
            }

            // Wait for all databases to be created.
            return Task.WhenAll(createDbTasks);
        }

        internal static Server CreateServer(SqlManagementClient sqlClient, ResourceGroup resourceGroup, string location, string testPrefix = TestPrefix)
        {
            string version12 = "12.0";
            string serverName = GenerateName(testPrefix);
            Dictionary<string, string> tags = new Dictionary<string, string>();

            var v12Server = sqlClient.Servers.CreateOrUpdate(resourceGroup.Name, serverName, new Server()
            {
                AdministratorLogin = DefaultLogin,
                AdministratorLoginPassword = DefaultPassword,
                Version = version12,
                Tags = tags,
                Location = location,
            });
            ValidateServer(v12Server, serverName, DefaultLogin, version12, tags, location);
            return v12Server;
        }

        /// <summary>
        /// Creates a key vault, grants the server and current user access to that vault,
        /// and creates a key in the vault.
        /// </summary>
        internal static KeyBundle CreateKeyVaultKeyWithServerAccess(
            SqlManagementTestContext context,
            ResourceGroup resourceGroup,
            Server server)
        {
            if (server.Identity == null)
            {
                throw new InvalidOperationException("Server has no identity");
            }

            return CreateKeyVaultKeyAccessibleByIdentity(context, resourceGroup, server.Identity);
        }

        /// <summary>
        /// Creates a key vault, grants the managed instance and current user access to that vault,
        /// and creates a key in the vault.
        /// </summary>
        internal static KeyBundle CreateKeyVaultKeyWithManagedInstanceAccess(
            SqlManagementTestContext context,
            ResourceGroup resourceGroup,
            ManagedInstance managedInstance)
        {
            if (managedInstance.Identity == null)
            {
                throw new InvalidOperationException("managedInstance has no identity");
            }

            return CreateKeyVaultKeyAccessibleByIdentity(context, resourceGroup, managedInstance.Identity);
        }

        private static KeyBundle CreateKeyVaultKeyAccessibleByIdentity(SqlManagementTestContext context,
            ResourceGroup resourceGroup, ResourceIdentity identity)
        {
            var sqlClient = context.GetClient<SqlManagementClient>();
            var keyVaultManagementClient = context.GetClient<KeyVaultManagementClient>();
            var keyVaultClient = TestEnvironmentUtilities.GetKeyVaultClient();

            // Prepare vault permissions for the server
            var permissions = new Permissions()
            {
                Keys = new List<string>()
                {
                    KeyPermissions.WrapKey,
                    KeyPermissions.UnwrapKey,
                    KeyPermissions.Get,
                    KeyPermissions.List
                }
            };

            var aclEntry = new AccessPolicyEntry(identity.TenantId.Value,
                identity.PrincipalId.Value.ToString(), permissions);

            // Prepare vault permissions for the app used in this test
            var appPermissions = new Permissions()
            {
                Keys = new List<string>()
                {
                    KeyPermissions.Create,
                    KeyPermissions.Delete,
                    KeyPermissions.Get,
                    KeyPermissions.List
                }
            };
            string authObjectId = TestEnvironmentUtilities.GetUserObjectId();
            var aclEntryUser = new AccessPolicyEntry(identity.TenantId.Value, authObjectId, appPermissions);

            // Create a vault
            var accessPolicy = new List<AccessPolicyEntry>() {aclEntry, aclEntryUser};
            string vaultName = SqlManagementTestUtilities.GenerateName();
            string vaultLocation = TestEnvironmentUtilities.DefaultLocation;
            var vault = keyVaultManagementClient.Vaults.CreateOrUpdate(resourceGroup.Name, vaultName,
                new VaultCreateOrUpdateParameters()
                {
                    Location = vaultLocation,
                    Properties = new VaultProperties()
                    {
                        AccessPolicies = accessPolicy,
                        TenantId = identity.TenantId.Value,
                        EnableSoftDelete = true
                    }
                });

            // Create a key
            // This can be flaky if attempted immediately after creating the vault. Adding short sleep to improve robustness.
            TestUtilities.Wait(TimeSpan.FromSeconds(3));
            string keyName = SqlManagementTestUtilities.GenerateName();
            return keyVaultClient.CreateKeyAsync(vault.Properties.VaultUri, keyName, JsonWebKeyType.Rsa,
                keyOps: JsonWebKeyOperation.AllOperations).GetAwaiter().GetResult();
        }

        internal static string GetServerKeyNameFromKeyBundle(KeyBundle keyBundle)
        {
            string vaultName = keyBundle.KeyIdentifier.VaultWithoutScheme.Split('.').First();
            return $"{vaultName}_{keyBundle.KeyIdentifier.Name}_{keyBundle.KeyIdentifier.Version}";
        }

        public static void ExecuteWithRetry(System.Action action, TimeSpan timeout, TimeSpan retryDelay, Func<CloudException, bool> acceptedErrorFunction)
        {
            DateTime timeoutTime = DateTime.Now.Add(timeout);
            bool passed = false;
            while (DateTime.Now < timeoutTime && !passed)
            {
                try
                {
                    action();
                    passed = true;
                }
                catch (CloudException e) when (acceptedErrorFunction(e))
                {
                    TestUtilities.Wait(retryDelay);
                }
            }
        }

        public static string GetTestMaintenanceConfigurationId(string subscriptionId)
        {
            return $"/subscriptions/{subscriptionId}/providers/Microsoft.Maintenance/publicMaintenanceConfigurations/SQL_{TestEnvironmentUtilities.DefaultLocation.Replace(" ", string.Empty)}_{TestPublicMaintenanceConfiguration}";
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Sql.Tests.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Sku = Microsoft.Azure.Management.Sql.Models.Sku;

namespace Sql.Tests
{
    public class SqlManagementTestContext : IDisposable
    {
        public SqlManagementTestContext(
            object suiteObject,
            [CallerMemberName]
            string testName="error_determining_test_name")
        {
            var providersToIgnore = new Dictionary<string, string>
            {
                {"Microsoft.Sql", null},
                {"Microsoft.Network", null}
            };

            var userAgentsToIgnore = new Dictionary<string, string>
            {
            };

            HttpMockServer.Matcher = new PermissiveRecordMatcherWithApiExclusion(true, providersToIgnore, userAgentsToIgnore);

            _mockContext = MockContext.Start(suiteObject.GetType().Name, testName);
        }

        private readonly MockContext _mockContext;

        private bool disposedValue = false; // To detect redundant calls

        private readonly Dictionary<Type, IDisposable> _serviceClientCache = new Dictionary<Type, IDisposable>();

        private readonly List<ResourceGroup> _resourceGroups = new List<ResourceGroup>();

        public TServiceClient GetClient<TServiceClient>() where TServiceClient :class, IDisposable
        {
            if (_serviceClientCache.TryGetValue(typeof(TServiceClient), out IDisposable clientObject))
            {
                return (TServiceClient)clientObject;
            }

            TServiceClient client = _mockContext.GetServiceClient<TServiceClient>();
            _serviceClientCache.Add(typeof(TServiceClient), client);
            return client;
        }

        public ResourceGroup CreateResourceGroup()
        {
            return CreateResourceGroup(TestEnvironmentUtilities.DefaultLocation);
        }

        public ResourceGroup CreateResourceGroup(string location)
        {
            ResourceManagementClient resourceClient = GetClient<ResourceManagementClient>();

            string rgName = SqlManagementTestUtilities.GenerateName();
            ResourceGroup resourceGroup = resourceClient.ResourceGroups.CreateOrUpdate(
                rgName,
                new ResourceGroup
                {
                    Location = location,
                    Tags = new Dictionary<string, string>() { { rgName, DateTime.UtcNow.ToString("u") } }
                });

            _resourceGroups.Add(resourceGroup);

            return resourceGroup;
        }

        public void DeleteResourceGroup(string resourceGroupName)
        {
            ResourceManagementClient resourceClient = GetClient<ResourceManagementClient>();
            resourceClient.ResourceGroups.BeginDelete(resourceGroupName);
        }

        public Server CreateServer(ResourceGroup resourceGroup)
        {
            return CreateServer(resourceGroup, TestEnvironmentUtilities.DefaultLocation);
        }

        public Server CreateServer(ResourceGroup resourceGroup, string location)
        {
            SqlManagementClient sqlClient = GetClient<SqlManagementClient>();

            string version12 = "12.0";
            string serverName = SqlManagementTestUtilities.GenerateName();
            Dictionary<string, string> tags = new Dictionary<string, string>();

            var v12Server = sqlClient.Servers.CreateOrUpdate(resourceGroup.Name, serverName, new Server()
            {
                AdministratorLogin = SqlManagementTestUtilities.DefaultLogin,
                AdministratorLoginPassword = SqlManagementTestUtilities.DefaultPassword,
                Version = version12,
                Tags = tags,
                Location = location,
            });

            SqlManagementTestUtilities.ValidateServer(v12Server, serverName, SqlManagementTestUtilities.DefaultLogin, version12, tags, location);

            return v12Server;
        }

        public ManagedInstance CreateManagedInstance(ResourceGroup resourceGroup, string name = null)
        {
            return this.CreateManagedInstance(resourceGroup, new ManagedInstance(), name);
        }

        public ManagedInstance CreateManagedInstance(ResourceGroup resourceGroup, ManagedInstance initialManagedInstance, string name = null)
        {
            SqlManagementClient sqlClient = GetClient<SqlManagementClient>();

            string miName = name ?? SqlManagementTestUtilities.GenerateName("net-sdk-crud-tests-");
            var payload = this.GetManagedInstancePayload(initialManagedInstance);

            return sqlClient.ManagedInstances.CreateOrUpdate(resourceGroup.Name, miName, payload);
        }

        public List<ManagedInstance> ListManagedInstanceByResourceGroup(string rgName)
        {
            SqlManagementClient sqlClient = GetClient<SqlManagementClient>();
            return sqlClient.ManagedInstances.ListByResourceGroup(rgName).ToList();
        }

        private ManagedInstance GetManagedInstancePayload(ManagedInstance mi)
        {
            if (mi.VCores > 8)
            {
                throw new Exception("Do not create managed instance with vCore larger then 8, because infrastructure limitation.");
            }

            var tags = ManagedInstanceTestUtilities.Tags;
            if (mi.Tags != null && mi.Tags.Count > 0)
            {
                foreach (var tag in mi.Tags)
                {
                    tags.Add(tag.Key, tag.Value);
                }
            }

            var payload = new ManagedInstance()
            {
                AdministratorLogin = ManagedInstanceTestUtilities.Username,
                AdministratorLoginPassword = ManagedInstanceTestUtilities.Password,
                Collation = mi.Collation,
                InstancePoolId = mi.InstancePoolId,
                KeyId = mi.KeyId,
                LicenseType = mi.LicenseType,
                Location = ManagedInstanceTestUtilities.Region,
                MaintenanceConfigurationId = mi.MaintenanceConfigurationId,
                ProxyOverride = mi.ProxyOverride,
                PublicDataEndpointEnabled = mi.PublicDataEndpointEnabled,
                RequestedBackupStorageRedundancy = mi.RequestedBackupStorageRedundancy ?? "Geo",
                StorageSizeInGB = mi.StorageSizeInGB ?? 32,
                SubnetId = ManagedInstanceTestUtilities.SubnetResourceId,
                Tags = tags,
                VCores = mi.VCores ?? 4,
                ZoneRedundant = mi.ZoneRedundant
            };

            if (mi.Sku != null)
            {
                if (mi.Sku.Name.Contains("Gen4"))
                {
                    throw new Exception("Provision only on Gen5 hardwere.");
                }
                payload.Sku = new Sku()
                {
                    Name = mi.Sku.Name
                };
            }


            if (mi.Identity != null)
            {
                payload.Identity = mi.Identity;
                if (mi.Identity.Type == IdentityType.SystemAssignedUserAssigned || mi.Identity.Type == IdentityType.UserAssigned)
                {
                    payload.PrimaryUserAssignedIdentityId = mi.PrimaryUserAssignedIdentityId;
                }
            }

            return payload;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // Dispose managed state (managed objects).

                    // Begin deleting resource groups
                    ResourceManagementClient resourceClient = GetClient<ResourceManagementClient>();
                    _resourceGroups.ForEach(rg => resourceClient.ResourceGroups.BeginDelete(rg.Name));

                    // Dispose clients
                    foreach (IDisposable client in _serviceClientCache.Values)
                    {
                        client.Dispose();
                    }

                    // Dispose context
                    _mockContext.Dispose();
                }

                disposedValue = true;
            }
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            Dispose(true);
        }
    }
}

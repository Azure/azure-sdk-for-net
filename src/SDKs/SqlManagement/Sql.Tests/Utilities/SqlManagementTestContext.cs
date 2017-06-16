﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;

namespace Sql.Tests
{
    public class SqlManagementTestContext : IDisposable
    {
        public SqlManagementTestContext(
            object suiteObject,
            [CallerMemberName]
            string testName="error_determining_test_name")
        {
            _mockContext = MockContext.Start(suiteObject.GetType().FullName, testName);
        }

        private readonly MockContext _mockContext;

        private readonly RecordedDelegatingHandler _handler = new RecordedDelegatingHandler
        {
            StatusCodeToReturn = HttpStatusCode.OK,
            IsPassThrough = true
        };

        private bool disposedValue = false; // To detect redundant calls

        private readonly Dictionary<Type, IDisposable> _serviceClientCache = new Dictionary<Type, IDisposable>();

        private readonly List<ResourceGroup> _resourceGroups = new List<ResourceGroup>();

        public TServiceClient GetClient<TServiceClient>() where TServiceClient :class, IDisposable
        {
            IDisposable clientObject;
            if (_serviceClientCache.TryGetValue(typeof(TServiceClient), out clientObject))
            {
                return (TServiceClient)clientObject;
            }

            TServiceClient client = _mockContext.GetServiceClient<TServiceClient>();
            _serviceClientCache.Add(typeof(TServiceClient), client);
            return client;
        }

        public ResourceGroup CreateResourceGroup(string location = SqlManagementTestUtilities.DefaultLocationId)
        {
            ResourceManagementClient resourceClient = GetClient<ResourceManagementClient>();

            string rgName = SqlManagementTestUtilities.GenerateName();
            ResourceGroup resourceGroup = resourceClient.ResourceGroups.CreateOrUpdate(
                rgName,
                new ResourceGroup
                {
                    Location = SqlManagementTestUtilities.DefaultLocation,
                    Tags = new Dictionary<string, string>() { { rgName, DateTime.UtcNow.ToString("u") } }
                });

            _resourceGroups.Add(resourceGroup);

            return resourceGroup;
        }

        public Server CreateServer(ResourceGroup resourceGroup, string location = SqlManagementTestUtilities.DefaultLocationId)
        {
            SqlManagementClient sqlClient = GetClient<SqlManagementClient>();
            return SqlManagementTestUtilities.CreateServer(sqlClient, resourceGroup, location);
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

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Management.SqlVirtualMachine;
using Microsoft.Azure.Management.SqlVirtualMachine.Tests.Utilities;
using Microsoft.Azure.Management.Storage;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Runtime.CompilerServices;

namespace SqlVirtualMachine.Tests
{
    public class SqlVirtualMachineTestContext : IDisposable
    {
        public string location;

        public MockClient client;
       
        public ResourceGroup resourceGroup { get; private set; }

        private MockContext _mockContext;
        
        private int resourceCounter = 0;

        private bool disposedValue = false;

        public SqlVirtualMachineTestContext(object suiteObject, [CallerMemberName] string testName = "error_determining_test_name")
        {
            location = Constants.location;
            _mockContext = MockContext.Start(suiteObject.GetType(), testName);
            client = new MockClient(_mockContext);
            resourceGroup = CreateResourceGroup(location);
        }

        public ResourceGroup CreateResourceGroup(string location)
        {
            string rgName = Constants.resourceGroupName;
            var resourceGroup = client.resourceClient.ResourceGroups.CreateOrUpdate(rgName, new ResourceGroup()
            {
                Location = this.location,
            });
            return resourceGroup;
        }

        private void DeleteResourceGroup()
        {
            client.resourceClient.ResourceGroups.Delete(resourceGroup.Name);
        }

        public SqlVirtualMachineManagementClient getSqlClient()
        {
            return client.sqlClient;
        }

        public string generateResourceName()
        {
            return "test-" + (++resourceCounter);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    DeleteResourceGroup();

                    // Dispose client
                    client.Dispose();

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
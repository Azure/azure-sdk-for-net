using System;
using Microsoft.Azure.Management.StoragePool;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Text;

namespace StoragePool.Tests
{
    class StoragePoolTestBase : TestBase, IDisposable
    {
        public StoragePoolManagementClient StoragePoolClient { get; private set; }

        public StoragePoolTestBase(MockContext context)
        {
            this.StoragePoolClient = context.GetServiceClient<StoragePoolManagementClient>();
        }

        public void Dispose()
        {
            this.StoragePoolClient.Dispose();
        }
    }
}

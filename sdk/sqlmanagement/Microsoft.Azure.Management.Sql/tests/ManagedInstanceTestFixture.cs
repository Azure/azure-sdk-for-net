using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using Xunit;
using Sku = Microsoft.Azure.Management.Sql.Models.Sku;

namespace Sql.Tests
{
    public class ManagedInstanceTestFixture : IDisposable
    {
        public SqlManagementTestContext Context { get; set; }

        public ResourceGroup ResourceGroup { get; set; }

        public ManagedInstance ManagedInstance { get; set; }

        public ManagedInstanceTestFixture()
        {
            Context = new SqlManagementTestContext(this);

            try
            {
                SqlManagementClient sqlClient = Context.GetClient<SqlManagementClient>();

                ResourceGroup = Context.CreateResourceGroup(ManagedInstanceTestUtilities.Region);
                ManagedInstance = Context.CreateManagedInstance(ResourceGroup);
            }
            catch(Exception ex)
            {
                Context.Dispose();
            }
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}

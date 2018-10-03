using System;
using System.Collections.Generic;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
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

                ResourceGroup = Context.CreateResourceGroup();

                Sku sku = new Sku();
                sku.Name = "MIGP8G4";
                sku.Tier = "GeneralPurpose";
                ManagedInstance = sqlClient.ManagedInstances.CreateOrUpdate(ResourceGroup.Name,
                    "crud-tests-" + SqlManagementTestUtilities.GenerateName(), new ManagedInstance()
                    {
                        AdministratorLogin = SqlManagementTestUtilities.DefaultLogin,
                        AdministratorLoginPassword = SqlManagementTestUtilities.DefaultPassword,
                        Sku = sku,
                        SubnetId =
                            "/subscriptions/a8c9a924-06c0-4bde-9788-e7b1370969e1/resourceGroups/RG_MIPlayground/providers/Microsoft.Network/virtualNetworks/VNET_MIPlayground/subnets/MISubnet",
                        Tags = new Dictionary<string, string>(),
                        Location = TestEnvironmentUtilities.DefaultLocationId,
                    });
            }
            catch(Exception)
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

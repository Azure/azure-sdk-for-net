using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.Sql;
using Microsoft.Azure.Management.Sql.Models;
using Microsoft.Rest.Azure;
using System.Linq;
using Xunit;

namespace Sql.Tests
{
    public class ManagedInstanceDnsAliasCrudScenarioTest
    {
        [Fact]
        public void TestManagedInstanceDnsAlias()
        {
            using (SqlManagementTestContext context = new SqlManagementTestContext(this))
            {
                ResourceGroup resourceGroup = context.CreateResourceGroup();
                SqlManagementClient sqlClient = context.GetClient<SqlManagementClient>();

                // Create primary and partner managed instance.
                var sourceInstance = context.CreateManagedInstance(resourceGroup);
                var targetInstance = context.CreateManagedInstance(resourceGroup);

                string dnsAliasName = SqlManagementTestUtilities.GenerateName();

                // Create dns alias without dns record.
                ManagedServerDnsAliasCreation parameters = new ManagedServerDnsAliasCreation(createDnsRecord: false);
                ManagedServerDnsAlias dnsAlias = sqlClient.ManagedServerDnsAliases.CreateOrUpdate(resourceGroup.Name, sourceInstance.Name, dnsAliasName, parameters);
                ValidateDnsAlias(dnsAlias, dnsAliasName, sourceInstance.Name, false);

                // Update dns alias to have dns record.
                parameters.CreateDnsRecord = true;
                dnsAlias = sqlClient.ManagedServerDnsAliases.CreateOrUpdate(resourceGroup.Name, sourceInstance.Name, dnsAliasName, parameters);
                ValidateDnsAlias(dnsAlias, dnsAliasName, sourceInstance.Name, true);

                // List aliases to check that functionality.
                var dnsAliases = sqlClient.ManagedServerDnsAliases.ListByManagedInstance(resourceGroup.Name, sourceInstance.Name);

                // Verify there is only 1 dns alias.
                Assert.Single(dnsAliases);
                ValidateDnsAlias(dnsAliases.ElementAt(0), dnsAliasName, sourceInstance.Name, true);

                // Acquire DNS alias from source instance to point to target instance.
                ManagedServerDnsAliasAcquisition acquisitionParams = new ManagedServerDnsAliasAcquisition(dnsAlias.Id);
                sqlClient.ManagedServerDnsAliases.Acquire(resourceGroup.Name, targetInstance.Name, dnsAliasName, acquisitionParams);

                // Get the alias from the target instance
                dnsAlias = sqlClient.ManagedServerDnsAliases.Get(resourceGroup.Name, targetInstance.Name, dnsAliasName);
                ValidateDnsAlias(dnsAlias, dnsAliasName, targetInstance.Name, true);

                // Assert that the alias is no longer present on the source instance.
                Assert.Throws<CloudException>(() => sqlClient.ManagedServerDnsAliases.Get(resourceGroup.Name, sourceInstance.Name, dnsAliasName));

                // Delete the dns alias
                sqlClient.ManagedServerDnsAliases.Delete(resourceGroup.Name, targetInstance.Name, dnsAliasName);

                // Assert that the alias is deleted.
                Assert.Throws<CloudException>(() => sqlClient.ManagedServerDnsAliases.Get(resourceGroup.Name, targetInstance.Name, dnsAliasName));
            }
        }

        private void ValidateDnsAlias(ManagedServerDnsAlias dnsAlias, string expectedName, string expectedManagedInstanceName, bool hasDnsRecord)
        {
            Assert.NotNull(dnsAlias);
            Assert.Equal(expectedName, dnsAlias.Name);
            Assert.Contains(expectedManagedInstanceName, dnsAlias.Id);
            if(hasDnsRecord)
            {
                Assert.NotNull(dnsAlias.AzureDnsRecord);
            }
            else
            {
                Assert.Null(dnsAlias.AzureDnsRecord);
            }
        }
    }
}

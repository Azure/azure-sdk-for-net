using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using CosmosDB.Tests.ScenarioTests;
using Microsoft.Azure.Management.CosmosDB;
using Microsoft.Azure.Management.CosmosDB.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;
using Location = Microsoft.Azure.Management.CosmosDB.Models.Location;

namespace CosmosDB.Tests
{
    [CollectionDefinition("TestCollection")]
    public class TestCollection : ICollectionFixture<TestFixture>
    {

    }
    public class TestFixture : IDisposable
    {
        public CosmosDBManagementClient CosmosDBManagementClient;
        public ResourceManagementClient ResourceManagementClient;
        public string ResourceGroupName;
        public string Location = "central us";

        private MockContext context = null;
        private Dictionary<AccountType, string> accounts;

        public TestFixture()
        {
        }

        // The MockContext used by the TestFixture must be created in the test class itself
        // due to how the .NET SDK TestFramework works. So instead of configuring all this in the
        // construct of TestFixture, we call Init in the constructor of the test class with a new MockContext, eg,
        //
        // public MyTestClass()
        // {
        //    this.fixture = fixture;
        //    fixture.Init(MockContext.Start(this.GetType()));
        // }
        public void Init(MockContext context)
        {
            bool firstRun = this.context == null;
            this.accounts = new Dictionary<AccountType, string>();
            this.context = context;

            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            handler1.IsPassThrough = true;
            this.ResourceManagementClient = context.GetServiceClient<ResourceManagementClient>(handlers: handler1);

            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            handler2.IsPassThrough = true;
            this.CosmosDBManagementClient = context.GetServiceClient<CosmosDBManagementClient>(handlers: handler2);

            if (firstRun)
            {
                // Create a resource group for testing.
                const string testPrefix = "CosmosDBDotNetSDKTestsRG";
                this.ResourceGroupName = TestUtilities.GenerateName(testPrefix);

                var resourceGroupDefinition = new ResourceGroup
                {
                    Location = Location
                };
                ResourceManagementClient.ResourceGroups.CreateOrUpdate(this.ResourceGroupName, resourceGroupDefinition);
            }
        }

        public void Dispose()
        {
            ResourceManagementClient.ResourceGroups.Delete(this.ResourceGroupName);
            this.context.Dispose();
        }

        public enum AccountType
        {
            PitrSql,
            Sql,
            Mongo32,
            Mongo36,
            Table,
            Cassandra,
            Gremlin
        }
        
        public string GetDatabaseAccountName(AccountType accountType)
        {
            string accountName;
            if (!this.accounts.TryGetValue(accountType, out accountName))
            {
                if (accountType == AccountType.PitrSql)
                {
                    accountName = CreateDatabaseAccount(
                        kind: DatabaseAccountKind.GlobalDocumentDB,
                        enablePitr: true
                    );
                }
                else if (accountType == AccountType.Sql)
                {
                    accountName = CreateDatabaseAccount(
                       kind: DatabaseAccountKind.GlobalDocumentDB,
                       enablePitr: false
                   );
                }
                else if (accountType == AccountType.Mongo32)
                {
                    accountName = CreateDatabaseAccount(
                        kind: DatabaseAccountKind.MongoDB,
                        serverVersion: "3.2",
                        enablePitr: true
                    );
                }
                else if (accountType == AccountType.Mongo36)
                {
                    accountName = CreateDatabaseAccount(
                        kind: DatabaseAccountKind.MongoDB,
                        serverVersion: "3.6",
                        enablePitr: true
                    );
                }
                else if (accountType == AccountType.Table)
                {
                    accountName = CreateDatabaseAccount(
                        capabilities: new List<Capability> { new Capability("EnableTable") },
                        enablePitr: false
                    );
                }
                else if (accountType == AccountType.Cassandra)
                {
                    accountName = CreateDatabaseAccount(
                        capabilities: new List<Capability> { new Capability("EnableCassandra") },
                        enablePitr: false
                    );
                }
                else if (accountType == AccountType.Gremlin)
                {
                    accountName = CreateDatabaseAccount(
                        capabilities: new List<Capability> { new Capability("EnableGremlin") },
                        enablePitr: false
                    );
                }
                accounts[accountType] = accountName;
            }
            return accountName;
        }

        private string CreateDatabaseAccount(string kind = "GlobalDocumentDB", List<Capability> capabilities = null, string serverVersion = null, bool enablePitr = true)
        {
            var databaseAccountName = TestUtilities.GenerateName("databaseaccount");
            var parameters = new DatabaseAccountCreateUpdateParameters
            {
                Location = this.Location,
                Kind = kind,
                Locations = new List<Location> { new Location(locationName: this.Location) },
                IsVirtualNetworkFilterEnabled = true,
                EnableAutomaticFailover = false,
                EnableMultipleWriteLocations = false,
                DisableKeyBasedMetadataWriteAccess = false,
                NetworkAclBypass = NetworkAclBypass.AzureServices,
                CreateMode = CreateMode.Default,
                Capabilities = capabilities
            };
            if (enablePitr)
            {
                parameters.BackupPolicy = new ContinuousModeBackupPolicy();
            }
            if (serverVersion != null)
            {
                parameters.ApiProperties = new ApiProperties
                {
                    ServerVersion = serverVersion
                };
            }

            var databaseAccount = this.CosmosDBManagementClient.DatabaseAccounts.CreateOrUpdateWithHttpMessagesAsync(
                this.ResourceGroupName,
                databaseAccountName,
                parameters
            ).GetAwaiter().GetResult().Body;

            return databaseAccountName;
        }
    }
}

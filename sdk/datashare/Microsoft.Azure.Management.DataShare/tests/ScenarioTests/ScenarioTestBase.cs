namespace DataShare.Tests.ScenarioTests
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.DataShare;
    using Microsoft.Azure.Management.ResourceManager;
    using Microsoft.Azure.Management.Storage;
    using Microsoft.Azure.Management.ResourceManager.Models;
    using Microsoft.Azure.Management.Storage.Models;
    using Microsoft.Azure.Test.HttpRecorder;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Identity = Microsoft.Azure.Management.DataShare.Models.Identity;
    using Sku = Microsoft.Azure.Management.Storage.Models.Sku;

    public abstract class ScenarioTestBase<T>
    {
        private const string ResourceGroupNamePrefix = "sdktestingadsrg";
        protected const string AccountNamePrefix = "sdktstshareaccount";
        protected const string AccountLocation = "eastus";
        protected static Type Type = typeof(T);
        public static Sku DefaultSku = new Sku(SkuName.StandardGRS);
        public static Dictionary<string, string> DefaultTags = new Dictionary<string, string>
        {
            {"key1","value1"},
            {"key2","value2"}
        };


        protected static string storageActName = "storageactsample";
        protected static string tenantId = Environment.GetEnvironmentVariable(DataShareE2EScenarioTests.tenant);
        protected static string srvPrincipal = Environment.GetEnvironmentVariable(DataShareE2EScenarioTests.servicePrincipal);

        protected static Identity identity = new Identity(tenantId, srvPrincipal, "SystemAssigned");

        protected string ResourceGroupName { get; private set; }
        protected string AccountName { get; private set; }
        protected DataShareManagementClient Client { get; private set; }

        protected async Task RunTest(
            Func<DataShareManagementClient, Task> initialAction,
            Func<DataShareManagementClient, Task> finallyAction,
            [CallerMemberName] string methodName = "")
        {
            const string modeEnvironmentVariableName = "AZURE_TEST_MODE";
            const string playback = "Playback";

            using (MockContext mockContext = MockContext.Start(Type, methodName))
            {
                string mode = Environment.GetEnvironmentVariable(modeEnvironmentVariableName);

                if (mode != null && mode.Equals(playback, StringComparison.OrdinalIgnoreCase))
                {
                    HttpMockServer.Mode = HttpRecorderMode.Playback;
                }

                //this.ResourceGroupName = TestUtilities.GenerateName(ScenarioTestBase<T>.ResourceGroupNamePrefix);
                this.ResourceGroupName = ScenarioTestBase<T>.ResourceGroupNamePrefix;

                // this.AccountName = TestUtilities.GenerateName(ScenarioTestBase<T>.AccountNamePrefix);
                this.AccountName = ScenarioTestBase<T>.AccountNamePrefix;

                this.Client =
                    mockContext.GetServiceClient<DataShareManagementClient>(
                        TestEnvironmentFactory.GetTestEnvironment());

                ResourceManagementClient resourceManagementClient =
                    mockContext.GetServiceClient<ResourceManagementClient>(TestEnvironmentFactory.GetTestEnvironment());

                resourceManagementClient.ResourceGroups.CreateOrUpdate(
                    this.ResourceGroupName,
                    new ResourceGroup() { Location = ScenarioTestBase<T>.AccountLocation });

                StorageManagementClient storageManagementClient = mockContext.GetServiceClient<StorageManagementClient>(TestEnvironmentFactory.GetTestEnvironment());
                CreateStorageAccount(this.ResourceGroupName, storageActName, storageManagementClient);

                await initialAction(this.Client);

                if (finallyAction != null)
                {
                    await finallyAction(this.Client);
                }

                resourceManagementClient.ResourceGroups.Delete(this.ResourceGroupName);
            }
        }

        /// <summary>
        /// Create a new Storage Account. If one already exists then the request still succeeds
        /// </summary>
        /// <param name="rgname">Resource Group Name</param>
        /// <param name="acctName">Account Name</param>
        /// <param name="useCoolStorage">Use Cool Storage</param>
        /// <param name="useEncryption">Use Encryption</param>
        /// <param name="storageMgmtClient">Storage Management Client</param>
        private static void CreateStorageAccount(string rgname, string acctName, StorageManagementClient storageMgmtClient)
        {
            StorageAccountCreateParameters parameters = GetDefaultStorageAccountParameters();

            Console.WriteLine("Creating a storage account...");
            var storageAccount = storageMgmtClient.StorageAccounts.Create(rgname, acctName, parameters);
            Console.WriteLine("Storage account created with name " + storageAccount.Name);
        }

        private static StorageAccountCreateParameters GetDefaultStorageAccountParameters()
        {
            StorageAccountCreateParameters account = new StorageAccountCreateParameters
            {
                Location = AccountLocation,
                Kind = Kind.StorageV2,
                Tags = DefaultTags,
                Sku = DefaultSku
            };

            return account;
        }
    }
}

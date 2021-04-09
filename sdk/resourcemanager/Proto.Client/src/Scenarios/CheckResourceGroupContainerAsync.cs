using Azure.ResourceManager.Core;
using Proto.Compute;
using System;
using System.Threading.Tasks;
using Azure.Identity;

namespace Proto.Client
{
    class CheckResourceGroupContainerAsync : Scenario
    {
        public CheckResourceGroupContainerAsync() : base() { }

        public CheckResourceGroupContainerAsync(ScenarioContext context) : base(context) { }

        public override void Execute()
        {
            ExecuteAsync().ConfigureAwait(false).GetAwaiter().GetResult();
        }

        private async System.Threading.Tasks.Task ExecuteAsync()
        {
            var client = new ArmClient(new DefaultAzureCredential());
            var subscription = client.GetSubscriptions().TryGet(Context.SubscriptionId);

            // Create Resource Group
            Console.WriteLine($"--------Start create group {Context.RgName}--------");
            var resourceGroup = subscription.GetResourceGroups().Construct(Context.Loc).CreateOrUpdate(Context.RgName).Value;
            CleanUp.Add(resourceGroup.Id);
            var rgOps = subscription.GetResourceGroups().Get(Context.RgName);
            var resourceGroupContainer = subscription.GetResourceGroups();
            var rg = new Azure.ResourceManager.Resources.Models.ResourceGroup("East US");
            var resourceGroupData = new ResourceGroupData(rg);

            ShouldThrow<ArgumentNullException>(
                () => resourceGroupContainer.Construct(null),
                "Construct with null loc didn't throw",
                "Construct");

            ShouldThrow<ArgumentNullException>(
                () => resourceGroupContainer.CreateOrUpdate("test", null),
                "CreateOrUpdate with null resourceGroupData didn't throw",
                "CreateOrUpdate");

            await ShouldThrowAsync<ArgumentException>(
                async () => await resourceGroupContainer.CreateOrUpdateAsync(" ", resourceGroupData),
                "CreateOrUpdateAsync with whitespaces only string didn't throw",
                "CreateOrUpdateAsync");

            ShouldThrow<ArgumentNullException>(
                () => resourceGroupContainer.StartCreateOrUpdate("test", null),
                "StartCreateOrUpdate with null ResourceGroupData didn't throw",
                "StartCreateOrUpdate");

            await ShouldThrowAsync<ArgumentException>(
                async () => await resourceGroupContainer.StartCreateOrUpdateAsync(" ", resourceGroupData),
                "StartCreateOrUpdateAsync with whitespaces only string didn't throw",
                "StartCreateOrUpdateAsync");

            ShouldThrow<ArgumentException>(
                () => resourceGroupContainer.Get(null),
                "Get with null string didn't throw",
                "Get");

            await ShouldThrowAsync<ArgumentException>(
                async () => await resourceGroupContainer.GetAsync("  "),
                "GetAsync with whitespaces only string didn't throw",
                "GetAsync");

            Console.WriteLine("--------Done--------");
        }

        private static void ShouldThrow<T>(Action lambda, string failMessage, string method)
        {
            try
            {
                lambda();
                throw new Exception(failMessage);
            }
            catch (Exception e) when (e.GetType() == typeof(T))
            {
                Console.WriteLine($"{method} Exception was thrown as expected.");
            }
        }

        private static async Task ShouldThrowAsync<T>(Func<Task> lambda, string failMessage, string method)
        {
            try
            {
                await lambda();
                throw new Exception(failMessage);
            }
            catch (Exception e) when (e.GetType() == typeof(T))
            {
                Console.WriteLine($"{method} Exception was thrown as expected.");
            }
        }
    }
}

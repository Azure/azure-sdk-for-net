using Azure.ResourceManager.Core;
using Proto.Compute;
using System;
using System.Threading.Tasks;
using Azure.Identity;

namespace Proto.Client
{
    class CheckResourceGroupOpsAsync : Scenario
    {
        public CheckResourceGroupOpsAsync() : base() { }

        public CheckResourceGroupOpsAsync(ScenarioContext context) : base(context) { }

        public override void Execute()
        {
            ExecuteAsync().ConfigureAwait(false).GetAwaiter().GetResult();
        }

        private async System.Threading.Tasks.Task ExecuteAsync()
        {
            var client = new ArmClient(new DefaultAzureCredential());
            var subscription = client.GetSubscriptionOperations(Context.SubscriptionId);

            // Create Resource Group
            Console.WriteLine($"--------Start create group {Context.RgName}--------");
            var resourceGroup = subscription.GetResourceGroups().Construct(Context.Loc).CreateOrUpdate(Context.RgName).Value;
            CleanUp.Add(resourceGroup.Id);
            var rgOps = subscription.GetResourceGroupOperations(Context.RgName);

            ShouldThrow<ArgumentException>(
                () => rgOps.AddTag("", ""), 
                "AddTag with empty string didn't throw",
                "AddTag");

            await ShouldThrowAsync<ArgumentException>(
                async () => await rgOps.AddTagAsync(null, null),
                "AddTagAsync with null string didn't throw",
                "AddTagAsync");

            ShouldThrow<ArgumentException>(
                () => rgOps.StartAddTag("", null), 
                "StartAddTag with empty string didn't throw",
                "StartAddTag");

            await ShouldThrowAsync<ArgumentException>(
                async () => await rgOps.StartAddTagAsync(" ", "test"), 
                "StartAddTagAsync with whitespaces only string didn't throw",
                "StartAddTagAsync");

            // Create AvailabilitySet
            Console.WriteLine("--------Create AvailabilitySet async--------");
            var aset = (await (await resourceGroup.GetAvailabilitySets().Construct("Aligned").StartCreateOrUpdateAsync(Context.VmName + "_aSet")).WaitForCompletionAsync()).Value;
            var data = aset.Get().Value.Data;

            ShouldThrow<ArgumentException>(
                () => rgOps.CreateResource<AvailabilitySetContainer, AvailabilitySet, ResourceGroupResourceIdentifier, AvailabilitySetData>("", data), 
                "CreateResource with empty string didn't throw",
                "CreateResource");
            
            await ShouldThrowAsync<ArgumentException>(
                async () => await rgOps.CreateResourceAsync<AvailabilitySetContainer, ResourceGroupResourceIdentifier, AvailabilitySet, AvailabilitySetData>(" ", data),
                "CreateResourceAsync with whitespaces string didn't throw",
                "CreateResourceAsync");

            ShouldThrow<ArgumentNullException>(
                () => rgOps.SetTags(null), 
                "SetTags with null didn't throw",
                "SetTags");

            await ShouldThrowAsync<ArgumentNullException>(
                async () => await rgOps.SetTagsAsync(null), 
                "SetTagsAsync with null didn't throw",
                "SetTagsAsync");

            ShouldThrow<ArgumentNullException>(
                () => rgOps.StartSetTags(null),
                "StartSetTags with null didn't throw",
                "StartSetTags");
            
            await ShouldThrowAsync<ArgumentNullException>(
                async () => await rgOps.StartSetTagsAsync(null), 
                "StartSetTagsAsync with null didn't throw",
                "StartSetTagsAsync");

            ShouldThrow<ArgumentException>(
                () => rgOps.RemoveTag(""), 
                "RemoveTag with empty string didn't throw",
                "RemoveTag");

            await ShouldThrowAsync<ArgumentException>(
                async () => await rgOps.RemoveTagAsync(null), 
                "RemoveTagAsync with null didn't throw",
                "RemoveTagAsync");

            ShouldThrow<ArgumentException>(
                () => rgOps.StartRemoveTag(" "), 
                "StartRemoveTag with whitespace string didn't throw",
                "StartRemoveTag");

            await ShouldThrowAsync<ArgumentException>(
                async () => await rgOps.StartRemoveTagAsync(null), 
                "StartRemoveTagAsync with null didn't throw", 
                "StartRemoveTagAsync");

            ShouldThrow<ArgumentNullException>(
                () => rgOps.CreateResource<AvailabilitySetContainer, AvailabilitySet, ResourceGroupResourceIdentifier, AvailabilitySetData>("tester", null),
                "CreateResource model exception not thrown",
                "CreateResource");

            await ShouldThrowAsync<ArgumentNullException>(
                async () => await rgOps.CreateResourceAsync<AvailabilitySetContainer, ResourceGroupResourceIdentifier, AvailabilitySet, AvailabilitySetData>("tester", null),
                "CreateResourceAsync model exception not thrown",
                "CreateResourceAsync");

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

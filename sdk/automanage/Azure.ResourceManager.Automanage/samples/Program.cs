using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.Automanage;
using Azure.ResourceManager.Automanage.Models;
using Azure.ResourceManager.Resources;

namespace AutoManageTest
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
            SubscriptionResource subscription = armClient.GetDefaultSubscription();

			var vmName = string.Concat("amvm", Environment.UserName);
            var vm = await subscription.CreateVM("sdkTest", vmName);

            //best practices profile
            string profileId = "/providers/Microsoft.Automanage/bestPractices/AzureBestPracticesProduction";

            var assignment = await armClient.CreateAssignment(vm.Id, profileId);
            var l = await armClient.WaitAssignmentCompleted(vm.Id);
        }
    }
}
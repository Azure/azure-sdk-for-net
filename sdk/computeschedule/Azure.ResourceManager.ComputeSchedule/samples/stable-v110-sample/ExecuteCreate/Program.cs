using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.ComputeSchedule.Models;
using UtilityMethods;

namespace ExecuteCreate
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            var blockedOperationsException = new HashSet<string> { "SchedulingOperationsBlockedException", "NonSchedulingOperationsBlockedException" };

            // Location: The location of the virtual machines
            const string location = "eastus2euap";

            // SubscriptionId: The subscription id under which the virtual machines are located, in this case, we are using a dummy subscriptionId
            const string subscriptionId = "a4f8220e-84cb-47a6-b2c0-c1900805f616";

            // ResourceGroupName: The resource group name under which the virtual machines are located, in this case, we are using a dummy resource group name
            const string resourceGroupName = "demo-rg";

            Dictionary<string, ResourceOperationDetails> completedOperations = [];
            // Credential: The Azure credential used to authenticate the request
            TokenCredential cred = new DefaultAzureCredential();

            // Client: The Azure Resource Manager client used to interact with the Azure Resource Manager API
            ArmClient client = new(cred);
            var subscriptionResource = HelperMethods.GetSubscriptionResource(client, subscriptionId);
            var resourceGroupResource = await subscriptionResource.GetResourceGroupAsync(resourceGroupName);

            // Execution parameters for the request including the retry policy used by Scheduledactions to retry the operation in case of failures
            var executionParams = new ScheduledActionExecutionParameterDetail()
            {
                RetryPolicy = new UserRequestRetryPolicy()
                {
                    // Number of times ScheduledActions should retry the operation in case of failures: Range 0-7
                    RetryCount = 3,
                    // Time window in minutes within which ScheduledActions should retry the operation in case of failures: Range in minutes 5-120
                    RetryWindowInMinutes = 45
                }
            };

            /*
             * Before creating a virtual machine, a virtual network and subnet must be created in the resource group
             * This is what will be used by the virtual machine
             */
            var options = new ArmClientOptions();
            options.SetApiVersion(new ResourceType("Microsoft.Network/virtualNetworks"), "2025-03-01");
            var vnetClient = new ArmClient(cred, subscriptionId, options);
            var vnet = await HelperMethods.CreateVirtualNetwork(resourceGroupResource, "default-subnet", "default-vnet", location, vnetClient);
            var subnet = HelperMethods.GetSubnetId(vnet);

            // resource overrides generation for the create operation
            var resourceOverrideOne = HelperMethods.GenerateResourceOverrideItem(
                "vmnameOne",
                location,
                "Standard_D2ads_v5",
                "YourStr0ngP@ssword123!",
                "testUserName");

            var resourceOverrideTwo = HelperMethods.GenerateResourceOverrideItem(
                "vmnameTwo",
                location,
                "Standard_D2ads_v5",
                "YourStr0ngP@ssword123!",
                "testUserName");

            // Create type operation: Create operation on virtual machines
            await ComputescheduleOperations.ExecuteCreateOperation(
                completedOperations,
                executionParams,
                subscriptionResource,
                blockedOperationsException, 
                [resourceOverrideOne, resourceOverrideTwo],
                3,
                true,
                location,
                resourceGroupName,
                subscriptionId,
                vnet.Id.Name,
                subnet.Name);
        }
    }
}

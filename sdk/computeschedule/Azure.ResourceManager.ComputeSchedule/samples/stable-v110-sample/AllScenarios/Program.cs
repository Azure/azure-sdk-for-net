using Azure;
using Azure.Core;
using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.ComputeSchedule;
using Azure.ResourceManager.ComputeSchedule.Models;
using Azure.ResourceManager.Resources;
using System.ClientModel.Primitives;
using UtilityMethods;

namespace AllScenarios
{
    public static class Program
    {
        /// <summary>
        /// This project shows a sample use case for the ComputeSchedule SDK
        /// </summary>
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

            // Execute type operation: Start operation on virtual machines
            //await ExecuteStartOperation(
            //    completedOperations,
            //    executionParams,
            //    subscriptionResource,
            //    blockedOperationsException,
            //    location,
            //    subscriptionId,
            //    resourceGroupName);

            /*
             * Before creating a virtual machine, a virtual network and subnet must be created in the resource group
             * This is what will be used by the virtual machine
             */
            var vnet = await HelperMethods.CreateVirtualNetwork(resourceGroupResource, "default-subnet", "default-vnet", location, client);
            var subnet = HelperMethods.GetSubnetId(vnet);

            // Create type operation: Create operation on virtual machines
            await ExecuteCreateOperation(
                completedOperations,
                executionParams,
                subscriptionResource,
                blockedOperationsException,
                location,
                resourceGroupName,
                subscriptionId,
                vnet.Id.Name,
                subnet.Name);

            // Delete type operation: Delete operation on virtual machines
            //var resourceIdsToDelete = new List<ResourceIdentifier>()
            //{
            //    new($"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/vmTestOne"),
            //};
            //await ExecuteDeleteOperation(
            //    resourceIdsToDelete,
            //    executionParams,
            //    subscriptionResource,
            //    blockedOperationsException,
            //    location,
            //    resourceGroupName,
            //    subscriptionId,
            //    Guid.NewGuid().ToString());
        }

        /// <summary>
        /// This method details the happy path for executing a delete type operation in ScheduledActions
        /// </summary>
        /// <param name="resourceIds">List of resource IDs to delete</param>
        /// <param name="executionParameterDetail">Execution parameters for the request</param>
        /// <param name="subscriptionResource">Subscription resource with Computeschedule operations</param>
        /// <param name="blockedOperationsException">Exceptions representing blocked operations</param>
        /// <param name="location">Location of the virtual machines operation</param>
        /// <param name="rgName">Resource group name of the virtual machines</param>
        /// <param name="subscriptionId">Subscription Id of the virtual machines</param>
        /// <param name="correlationId">Correlation Id for the request</param>
        private static async Task ExecuteDeleteOperation(
            List<ResourceIdentifier> resourceIds,
            ScheduledActionExecutionParameterDetail executionParameterDetail,
            SubscriptionResource subscriptionResource,
            HashSet<string> blockedOperationsException,
            string location,
            string rgName,
            string subscriptionId,
            string correlationId)
        {
            ExecuteDeleteContent executedeletecontent = new(executionParameterDetail, new UserRequestResources(resourceIds))
            {
                CorrelationId = correlationId,
                IsForceDeletion = true,
            };

            var deleteops = ModelReaderWriter.Write(executedeletecontent, ModelReaderWriterOptions.Json);
            Console.WriteLine(deleteops.ToString());

            try
            {
                // Execute the delete operation
                DeleteResourceOperationResult? result = await subscriptionResource.ExecuteVirtualMachineDeleteOperationAsync(location, executedeletecontent);
                Dictionary<string, ResourceOperationDetails> completedOperations = [];
                /// <summary>
                /// Each operationId corresponds to a virtual machine operation in ScheduledActions. 
                /// The method below excludes resources that have not been processed in ScheduledActions due to a number of reasons 
                /// like operation conflicts, virtual machines not being found in an Azure location etc 
                /// and returns only the valid operations that have passed validation checks to be polled.
                /// </summary>
                var validOperationIds = HelperMethods.ExcludeResourcesNotProcessed(result.Results).Keys.ToHashSet();

                if (validOperationIds.Count > 0)
                {
                    await HelperMethods.PollOperationStatus(validOperationIds, completedOperations, location, subscriptionResource);
                }
                else
                {
                    Console.WriteLine("No valid operations to poll");
                    return;
                }
            }
            catch (RequestFailedException ex)
            {
                /// <summary>
                /// Request examples that could make a request fall into this catch block include:
                /// VALIDATION ERRORS:
                /// - No resourceids provided in request
                /// - Over 100 resourceids provided in request
                /// - RetryPolicy.RetryCount value > 7
                /// - RetryPolicy.RetryWindowInMinutes value > 120
                /// COMPUTESCHEDULE BLOCKING ERRORS:
                /// - Scheduling Operations Blocked due to an ongoing outage in downstream services
                /// - Non-Scheduling Operations Blocked, eg VirtualMachinesGetOperationStatus operations, due to an ongoing outage in downstream services
                /// </summary>
                Console.WriteLine($"Request failed with ErrorCode:{ex.ErrorCode} and ErrorMessage: {ex.Message}");

                if (ex.ErrorCode != null && blockedOperationsException.Contains(ex.ErrorCode))
                {
                    /// Operation blocking on scheduling/non-scheduling actions can be due to scenarios like outages in downstream services.
                    Console.WriteLine($"Operation Blocking is turned on, request may succeed later.");
                }
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Request failed with Exception:{ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// This method details the happy path for executing a create type operation in ScheduledActions
        /// </summary>
        /// <param name="completedOperations">Hashset of completed operations to track</param>
        /// <param name="executionParameterDetail">Execution parameters for the request</param>
        /// <param name="subscriptionResource">Subscription resource with Computeschedule operations</param>
        /// <param name="subscriptionId">SubscriptionId for request</param>
        /// <param name="blockedOperationsException">Exceptions representing blocked operations</param>
        /// <param name="location">Location of the virtual machines operation</param>
        /// <param name="rgName">Resource group name of the virtual machines</param>
        /// <param name="subscriptionId">Subscription Id of the virtual machines</param>
        private static async Task ExecuteCreateOperation(
            Dictionary<string, ResourceOperationDetails> completedOperations,
            ScheduledActionExecutionParameterDetail executionParameterDetail,
            SubscriptionResource subscriptionResource,
            HashSet<string> blockedOperationsException,
            string location,
            string rgName,
            string subscriptionId,
            string vnetName,
            string subnetName)
        {
            // CorrelationId: This is a unique identifier used internally to track and monitor operations in ScheduledActions
            var correlationId = Guid.NewGuid().ToString();

            // resource overrides generation for the create operation
            var resourceOverrideOne = HelperMethods.GenerateResourceOverrideItem(
                "override-vm-name",
                location,
                "Standard_D2ads_v5",
                "YourStr0ngP@ssword123!",
                "testUserName");

            var resourceOverrideTwo = HelperMethods.GenerateResourceOverrideItem
                ("override-vm-name-two",
                location,
                "Standard_D2ads_v5",
                "YourStr0ngP@ssword123!",
                "testUserName");

            // The request body for the executecreate operation on virtual machines
            var executecreatecontent = HelperMethods.BuildExecuteCreateRequest(
                "test-vm-prefix",
                correlationId,
                3,
                executionParameterDetail,
                rgName,
                vnetName,
                subnetName,
                location,
                [resourceOverrideOne, resourceOverrideTwo],
                subscriptionId,
                true
                );

            var createOps = ModelReaderWriter.Write(executecreatecontent, ModelReaderWriterOptions.Json);
            Console.WriteLine(createOps.ToString());

            try
            {
                // Execute the create operation
                CreateResourceOperationResult? result = await subscriptionResource.ExecuteVirtualMachineCreateOperationAsync(location, executecreatecontent);

                /// <summary>
                /// Each operationId corresponds to a virtual machine operation in ScheduledActions. 
                /// The method below excludes resources that have not been processed in ScheduledActions due to a number of reasons 
                /// like operation conflicts, virtual machines not being found in an Azure location etc 
                /// and returns only the valid operations that have passed validation checks to be polled.
                /// </summary>
                var validOps = HelperMethods.ExcludeResourcesNotProcessed(result.Results);
                completedOperations.Clear();

                if (validOps.Count > 0)
                {
                    await HelperMethods.PollOperationStatus([.. validOps.Keys], completedOperations, location, subscriptionResource);
                }
                else
                {
                    Console.WriteLine("No valid operations to poll");
                    return;
                }
            }
            catch (RequestFailedException ex)
            {
                /// <summary>
                /// Request examples that could make a request fall into this catch block include:
                /// VALIDATION ERRORS:
                /// - No resourceids provided in request
                /// - Over 100 resourceids provided in request
                /// - RetryPolicy.RetryCount value > 7
                /// - RetryPolicy.RetryWindowInMinutes value > 120
                /// COMPUTESCHEDULE BLOCKING ERRORS:
                /// - Scheduling Operations Blocked due to an ongoing outage in downstream services
                /// - Non-Scheduling Operations Blocked, eg VirtualMachinesGetOperationStatus operations, due to an ongoing outage in downstream services
                /// </summary>
                Console.WriteLine($"Request failed with ErrorCode:{ex.ErrorCode} and ErrorMessage: {ex.Message}");

                if (ex.ErrorCode != null && blockedOperationsException.Contains(ex.ErrorCode))
                {
                    /// Operation blocking on scheduling/non-scheduling actions can be due to scenarios like outages in downstream services.
                    Console.WriteLine($"Operation Blocking is turned on, request may succeed later.");
                }
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Request failed with Exception:{ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// This method details the happy path for executing an execute type operation in ScheduledActions
        /// </summary>
        /// <param name="completedOperations">Hashset of completed operations to track</param>
        /// <param name="executionParameterDetail">Execution parameters for the request</param>
        /// <param name="retryPolicy">User retry policy values</param>
        /// <param name="subscriptionResource">Subscription resource with Computeschedule operations</param>
        /// <param name="blockedOperationsException">Exceptions representing blocked operations</param>
        /// <param name="location">Location of the virtual machines operation</param>
        /// <param name="resourceIds">ResourceIds to perform the Computeschedule execute operation on</param>
        /// <returns></returns>
        private static async Task ExecuteStartOperation(
            Dictionary<string, ResourceOperationDetails> completedOperations,
            ScheduledActionExecutionParameterDetail executionParameterDetail,
            SubscriptionResource subscriptionResource,
            HashSet<string> blockedOperationsException,
            string location,
            string subscriptionId,
            string resourceGroupName)
        {
            // List of virtual machine resource identifiers to perform execute/submit type operations on, in this case, we are using dummy VMs. Virtual Machines must all be under the same subscriptionid
            var resourceIds = new List<ResourceIdentifier>()
            {
                new($"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/dummy-vm-600"),
                new($"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/dummy-vm-611"),
                new($"/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Compute/virtualMachines/dummy-vm-612"),
            };

            try
            {
                // CorrelationId: This is a unique identifier used internally to track and monitor operations in ScheduledActions
                var correlationId = Guid.NewGuid().ToString();

                // The request body for the executestart operation on virtual machines
                var executeStartRequest = new ExecuteStartContent(executionParameterDetail, new UserRequestResources(resourceIds), correlationId);

                StartResourceOperationResult? result = await subscriptionResource.ExecuteVirtualMachineStartAsync(location, executeStartRequest);

                /// <summary>
                /// Each operationId corresponds to a virtual machine operation in ScheduledActions. 
                /// The method below excludes resources that have not been processed in ScheduledActions due to a number of reasons 
                /// like operation conflicts, virtual machines not being found in an Azure location etc 
                /// and returns only the valid operations that have passed validation checks to be polled.
                /// </summary>
                var validOperationIds = HelperMethods.ExcludeResourcesNotProcessed(result.Results).Keys.ToHashSet();
                completedOperations.Clear();

                if (validOperationIds.Count > 0)
                {
                    await HelperMethods.PollOperationStatus(validOperationIds, completedOperations, location, subscriptionResource);
                }
                else
                {
                    Console.WriteLine("No valid operations to poll");
                    return;
                }
            }
            catch (RequestFailedException ex)
            {
                /// <summary>
                /// Request examples that could make a request fall into this catch block include:
                /// VALIDATION ERRORS:
                /// - No resourceids provided in request
                /// - Over 100 resourceids provided in request
                /// - RetryPolicy.RetryCount value > 7
                /// - RetryPolicy.RetryWindowInMinutes value > 120
                /// COMPUTESCHEDULE BLOCKING ERRORS:
                /// - Scheduling Operations Blocked due to an ongoing outage in downstream services
                /// - Non-Scheduling Operations Blocked, eg VirtualMachinesGetOperationStatus operations, due to an ongoing outage in downstream services
                /// </summary>
                Console.WriteLine($"Request failed with ErrorCode:{ex.ErrorCode} and ErrorMessage: {ex.Message}");

                if (ex.ErrorCode != null && blockedOperationsException.Contains(ex.ErrorCode))
                {
                    /// Operation blocking on scheduling/non-scheduling actions can be due to scenarios like outages in downstream services.
                    Console.WriteLine($"Operation Blocking is turned on, request may succeed later.");
                }
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Request failed with Exception:{ex.Message}");
                throw;
            }
        }
    }
}

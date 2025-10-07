using Azure;
using Azure.Core;
using Azure.ResourceManager.ComputeSchedule;
using Azure.ResourceManager.ComputeSchedule.Models;
using Azure.ResourceManager.Resources;
using System.ClientModel.Primitives;

namespace UtilityMethods
{
    public static class ComputescheduleOperations
    {
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
        /// <param name="vmCount">Number of virtual machines to create</param>
        /// <param name="includeOverrides">Whether to include resource overrides in the request</param>
        /// <param name="resourceOverrideDetails">The resource override details to apply while creating the virtual machines</param>
        public static async Task<Dictionary<string, ResourceIdentifier>> ExecuteCreateOperation(
            Dictionary<string, ResourceOperationDetails> completedOperations,
            ScheduledActionExecutionParameterDetail executionParameterDetail,
            SubscriptionResource subscriptionResource,
            HashSet<string> blockedOperationsException,
            List<Dictionary<string, BinaryData>> resourceOverrideDetails,
            int vmCount,
            bool includeOverrides,
            string location,
            string rgName,
            string subscriptionId,
            string vnetName,
            string subnetName)
        {
            // CorrelationId: This is a unique identifier used internally to track and monitor operations in ScheduledActions
            var correlationId = Guid.NewGuid().ToString();

            // The request body for the executecreate operation on virtual machines
            var executecreatecontent = HelperMethods.BuildExecuteCreateRequest(
                "TVP",
                correlationId,
                vmCount,
                executionParameterDetail,
                rgName,
                vnetName,
                subnetName,
                location,
                resourceOverrideDetails,
                subscriptionId,
                includeOverrides
                );

            var createOps = ModelReaderWriter.Write(executecreatecontent, ModelReaderWriterOptions.Json);
            Console.WriteLine(createOps.ToString());

            var allCreatedVms = new Dictionary<string, ResourceIdentifier>();

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
                    allCreatedVms = await HelperMethods.PollOperationStatus([.. validOps.Keys], completedOperations, location, subscriptionResource);
                }
                else
                {
                    Console.WriteLine("No valid operations to poll");
                }

                return allCreatedVms;
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
        /// This method details the happy path for executing a delete type operation in ScheduledActions
        /// </summary>
        /// <param name="resourceIds">List of resource IDs to delete</param>
        /// <param name="executionParameterDetail">Execution parameters for the request</param>
        /// <param name="subscriptionResource">Subscription resource with Computeschedule operations</param>
        /// <param name="blockedOperationsException">Exceptions representing blocked operations</param>
        /// <param name="location">Location of the virtual machines operation</param>
        /// <param name="isForceDeletion">Indicates if the deletion is forced</param>
        public static async Task ExecuteDeleteOperation(
            List<ResourceIdentifier> resourceIds,
            ScheduledActionExecutionParameterDetail executionParameterDetail,
            SubscriptionResource subscriptionResource,
            HashSet<string> blockedOperationsException,
            string location,
            bool isForceDeletion)
        {
            // CorrelationId: This is a unique identifier used internally to track and monitor operations in ScheduledActions
            var correlationId = Guid.NewGuid().ToString();

            ExecuteDeleteContent executedeletecontent = new(executionParameterDetail, new UserRequestResources(resourceIds))
            {
                CorrelationId = correlationId,
                IsForceDeletion = isForceDeletion,
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
        /// This method details the happy path for executing an execute type operation in ScheduledActions
        /// </summary>
        /// <param name="completedOperations">Hashset of completed operations to track</param>
        /// <param name="executionParameterDetail">Execution parameters for the request</param>
        /// <param name="subscriptionResource">Subscription resource with Computeschedule operations</param>
        /// <param name="blockedOperationsException">Exceptions representing blocked operations</param>
        /// <param name="location">Location of the virtual machines operation</param>
        /// <param name="resourceIds">ResourceIds to perform the Computeschedule execute operation on</param>
        /// <returns></returns>
        public static async Task ExecuteStartOperation(
            Dictionary<string, ResourceOperationDetails> completedOperations,
            ScheduledActionExecutionParameterDetail executionParameterDetail,
            SubscriptionResource subscriptionResource,
            HashSet<string> blockedOperationsException,
            List<ResourceIdentifier> resourceIds,
            string location)
        {
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

        /// <summary>
        /// This method details the happy path for executing an execute type operation in ScheduledActions
        /// </summary>
        /// <param name="completedOperations">Hashset of completed operations to track</param>
        /// <param name="executionParameterDetail">Execution parameters for the request</param>
        /// <param name="subscriptionResource">Subscription resource with Computeschedule operations</param>
        /// <param name="blockedOperationsException">Exceptions representing blocked operations</param>
        /// <param name="location">Location of the virtual machines operation</param>
        /// <param name="resourceIds">ResourceIds to perform the Computeschedule execute operation on</param>
        /// <returns></returns>
        public static async Task ExecuteDeallocateOperation(
            Dictionary<string, ResourceOperationDetails> completedOperations,
            ScheduledActionExecutionParameterDetail executionParameterDetail,
            SubscriptionResource subscriptionResource,
            HashSet<string> blockedOperationsException,
            List<ResourceIdentifier> resourceIds,
            string location)
        {
            try
            {
                // CorrelationId: This is a unique identifier used internally to track and monitor operations in ScheduledActions
                var correlationId = Guid.NewGuid().ToString();

                // The request body for the executedeallocate operation on virtual machines
                var executeDeallocateRequest = new ExecuteDeallocateContent(executionParameterDetail, new UserRequestResources(resourceIds), correlationId);

                DeallocateResourceOperationResult? result = await subscriptionResource.ExecuteVirtualMachineDeallocateAsync(location, executeDeallocateRequest);

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

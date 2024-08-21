// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;
using Azure.ResourceManager.ComputeSchedule.Models;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.Compute;

namespace Azure.ResourceManager.ComputeSchedule.Tests
{
    public class ComputeScheduleTestBaseOperations : ComputeScheduleManagementTestBase
    {
        private static readonly string s_vmArmIdFormat = "/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Compute/virtualMachines/{2}}";

        public ComputeScheduleTestBaseOperations(bool isAsync, RecordedTestMode mode) : base(isAsync, mode)
        {
        }

        public ComputeScheduleTestBaseOperations(bool isAsync) : base(isAsync)
        {
        }

        protected static async Task<StartResourceOperationResponse> TestSubmitStartAsync(string location, SubmitStartContent submitStartRequest, string subid)
        {
            TokenCredential cred = new DefaultAzureCredential();
            ArmClient client = new(cred);
            SubscriptionResource subscriptionResource = GenerateSubscriptionResource(client, subid);
            SubmitStartContent content = submitStartRequest;
            StartResourceOperationResponse result;

            try
            {
                result = await subscriptionResource.VirtualMachinesSubmitStartScheduledActionAsync(location, content);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException?.Message);
                throw;
            }
            return result;
        }

        protected static async Task<DeallocateResourceOperationResponse> TestSubmitDeallocateAsync(string location, SubmitDeallocateContent submitStartRequest, string subid)
        {
            TokenCredential cred = new DefaultAzureCredential();
            ArmClient client = new(cred);
            SubscriptionResource subscriptionResource = GenerateSubscriptionResource(client, subid);
            SubmitDeallocateContent content = submitStartRequest;
            DeallocateResourceOperationResponse result;

            try
            {
                result = await subscriptionResource.VirtualMachinesSubmitDeallocateScheduledActionAsync(location, content);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException?.Message);
                throw;
            }
            return result;
        }

        protected static async Task<HibernateResourceOperationResponse> TestSubmitHibernateAsync(string location, SubmitHibernateContent submitStartRequest, string subid)
        {
            TokenCredential cred = new DefaultAzureCredential();
            ArmClient client = new(cred);
            SubscriptionResource subscriptionResource = GenerateSubscriptionResource(client, subid);
            SubmitHibernateContent content = submitStartRequest;
            HibernateResourceOperationResponse result;

            try
            {
                result = await subscriptionResource.VirtualMachinesSubmitHibernateScheduledActionAsync(location, content);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException?.Message);
                throw;
            }
            return result;
        }

        protected static async Task<StartResourceOperationResponse> TestExecuteStartAsync(string location, ExecuteStartContent executeStartRequest, string subid)
        {
            TokenCredential cred = new DefaultAzureCredential();
            ArmClient client = new(cred);
            SubscriptionResource subscriptionResource = GenerateSubscriptionResource(client, subid);
            ExecuteStartContent content = executeStartRequest;
            StartResourceOperationResponse result;
            try
            {
                result = await subscriptionResource.VirtualMachinesExecuteStartScheduledActionAsync(location, content);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException?.Message);
                throw;
            }

            return result;
        }

        protected static async Task<DeallocateResourceOperationResponse> TestExecuteDeallocateAsync(string location, ExecuteDeallocateContent executeDeallocateRequest, string subid)
        {
            TokenCredential cred = new DefaultAzureCredential();
            ArmClient client = new(cred);
            SubscriptionResource subscriptionResource = GenerateSubscriptionResource(client, subid);
            ExecuteDeallocateContent content = executeDeallocateRequest;

            DeallocateResourceOperationResponse result;
            try
            {
                result = await subscriptionResource.VirtualMachinesExecuteDeallocateScheduledActionAsync(location, content);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException?.Message);
                throw;
            }

            return result;
        }

        protected static async Task<HibernateResourceOperationResponse> TestExecuteHibernateAsync(string location, ExecuteHibernateContent executeHibernateRequest, string subid)
        {
            TokenCredential cred = new DefaultAzureCredential();
            ArmClient client = new(cred);
            SubscriptionResource subscriptionResource = GenerateSubscriptionResource(client, subid);
            ExecuteHibernateContent content = executeHibernateRequest;
            HibernateResourceOperationResponse result;

            try
            {
                result = await subscriptionResource.VirtualMachinesExecuteHibernateScheduledActionAsync(location, content);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException?.Message);
                throw;
            }
            return result;
        }

        protected static async Task<GetOperationStatusResponse> TestGetOpsStatusAsync(string location, GetOperationStatusContent getOpsStatusRequest, string subid)
        {
            TokenCredential cred = new DefaultAzureCredential();

            ArmClient client = new(cred);
            SubscriptionResource subscriptionResource = GenerateSubscriptionResource(client, subid);
            GetOperationStatusContent content = getOpsStatusRequest;
            GetOperationStatusResponse result;

            try
            {
                result = await subscriptionResource.VirtualMachinesGetOperationStatusScheduledActionAsync(location, content);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException?.Message);
                throw;
            }

            return result;
        }

        protected static async Task<CancelOperationsResponse> TestCancelOpsAsync(string location, CancelOperationsContent cancelOpsRequest, string subid)
        {
            TokenCredential cred = new DefaultAzureCredential();

            ArmClient client = new(cred);
            SubscriptionResource subscriptionResource = GenerateSubscriptionResource(client, subid);
            CancelOperationsContent content = cancelOpsRequest;
            CancelOperationsResponse result;

            try
            {
                result = await subscriptionResource.VirtualMachinesCancelOperationsScheduledActionAsync(location, content);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException?.Message);
                throw;
            }
            return result;
        }

        protected static async Task<GetOperationErrorsResponse> TestGetOperationErrorsAsync(string location, GetOperationErrorsContent getOperationErrorsRequest, string subid)
        {
            TokenCredential cred = new DefaultAzureCredential();

            ArmClient client = new(cred);
            SubscriptionResource subscriptionResource = GenerateSubscriptionResource(client, subid);
            GetOperationErrorsContent content = getOperationErrorsRequest;
            GetOperationErrorsResponse result;

            try
            {
                result = await subscriptionResource.VirtualMachinesGetOperationErrorsScheduledActionAsync(location, content);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException?.Message);
                throw;
            }
            return result;
        }

        private protected static Models.Resources GenerateResources(string resourceGroupName, SubscriptionResource subscriptionId, string resourceNamePrefix, int numResources)
        {
            var resourcesList = new List<ResourceIdentifier>();

            for (int i = 0; i < numResources; i++)
            {
                var item = new ResourceIdentifier(string.Format(s_vmArmIdFormat, subscriptionId, resourceGroupName, $"{resourceNamePrefix}-{i}"));

                resourcesList.Add(item);
            }

            return new Models.Resources(resourcesList);
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Management.RecoveryServices.Backup.Models;
using Microsoft.Azure.Management.RecoveryServices.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;
using HttpStatusCode = System.Net.HttpStatusCode;

namespace Microsoft.Azure.Management.RecoveryServices.Backup.Tests
{
    public class TestHelper : IDisposable
    {
        public string ResourceGroup = "SwaggerTestRg";
        public string VaultName = "SDKTestRsVault";
        public string Location = "westus";
        public string FabricName = "Azure";

        public RecoveryServicesClient VaultClient { get; private set; }

        public RecoveryServicesBackupClient BackupClient { get; private set; }

        public void Initialize(MockContext context)
        {
            VaultClient = this.GetVaultClient(context);
            BackupClient = this.GetBackupClient(context);

            CreateResourceGroup(context);

            CreateVault(VaultName);
        }

        private void CreateResourceGroup(MockContext context)
        {
            ResourceManagementClient resourcesClient = this.GetResourcesClient(context);

            try
            {
                resourcesClient.ResourceGroups.CreateOrUpdate(ResourceGroup,
                new ResourceGroup
                {
                    Location = Location
                });

            }
            catch (CloudException ex)
            {
                if (ex.Response.StatusCode != System.Net.HttpStatusCode.Conflict) throw;
            }
        }

        private void CreateVault(string vaultName)
        {
            Vault vault = new Vault()
            {
                Location = Location,
                Sku = new Sku()
                {
                    Name = SkuName.Standard
                },
                Properties = new VaultProperties()
            };

            try
            {
                VaultClient.Vaults.CreateOrUpdate(ResourceGroup, vaultName, vault);
            }
            catch (CloudException ex)
            {
                if (ex.Response.StatusCode != System.Net.HttpStatusCode.Conflict) throw;
            }
        }

        public void DisposeVaults()
        {
            var vaults = VaultClient.Vaults.ListByResourceGroup(ResourceGroup);
            foreach (var vault in vaults)
            {
                VaultClient.Vaults.Delete(ResourceGroup, vault.Name);
            }
        }

        public List<ProtectionPolicyResource> ListAllPoliciesWithRetries()
        {
            List<ProtectionPolicyResource> policies = new List<ProtectionPolicyResource>();

            RetryActionWithTimeout(
                () => policies = GetPagedList(() => BackupClient.BackupPolicies.List(VaultName, ResourceGroup),
                        nextLink => BackupClient.BackupPolicies.ListNext(nextLink)),
                () => policies.Count > 0,
                TimeSpan.FromMinutes(5),
                ResourceNotSyncedRetryLogic);

            return policies;
        }

        public ProtectionPolicyResource GetPolicyWithRetries(string policyName)
        {
            ProtectionPolicyResource policy = null;
            RetryActionWithTimeout(
                () => policy = BackupClient.ProtectionPolicies.Get(VaultName, ResourceGroup, policyName),
                () => policy != null,
                TimeSpan.FromMinutes(5),
                ResourceNotSyncedRetryLogic);

            return policy;
        }

        public string EnableProtection(string containerName, string protectedItemName, string policyName)
        {
            ProtectionPolicyResource policy = GetPolicyWithRetries(policyName);

            BackupClient.ProtectionContainers.Refresh(VaultName, ResourceGroup, FabricName);

            IPage<WorkloadProtectableItemResource> protectableItems = BackupClient.BackupProtectableItems.List(VaultName, ResourceGroup);

            var desiredProtectedItem = (AzureIaaSComputeVMProtectableItem) protectableItems.First(
                protectableItem => containerName.ToLower().Contains(protectableItem.Name.ToLower())
                ).Properties;

            Assert.NotNull(desiredProtectedItem);

            var item = new ProtectedItemResource()
            {
                Properties = new AzureIaaSComputeVMProtectedItem()
                {
                    PolicyId = policy.Id,
                    SourceResourceId = desiredProtectedItem.VirtualMachineId,
                }
            };
            
            var response = BackupClient.ProtectedItems.CreateOrUpdateWithHttpMessagesAsync(
                VaultName, ResourceGroup, FabricName, containerName, protectedItemName, item).Result;
            ValidateOperationResponse(response);

            var jobResponse = GetOperationResponse<ProtectedItemResource, OperationStatusJobExtendedInfo>(
                containerName, protectedItemName, response,
                operationId => BackupClient.ProtectedItemOperationResults.GetWithHttpMessagesAsync(
                    VaultName, ResourceGroup, FabricName, containerName, protectedItemName, operationId).Result,
                operationId => BackupClient.ProtectedItemOperationStatuses.GetWithHttpMessagesAsync(
                    VaultName, ResourceGroup, FabricName, containerName, protectedItemName, operationId).Result);

            Assert.NotNull(jobResponse.JobId);

            return jobResponse.JobId;
        }

        public string Backup(string containerName, string protectedItemName)
        {
            BackupRequestResource request = new BackupRequestResource()
            {
                Properties = new IaasVMBackupRequest()
                {
                    RecoveryPointExpiryTimeInUTC = DateTime.UtcNow.AddDays(2),
                },
            };

            var response = BackupClient.Backups.TriggerWithHttpMessagesAsync(
                VaultName, ResourceGroup, FabricName, containerName, protectedItemName, request).Result;
            ValidateOperationResponse(response);

            var jobResponse = GetOperationResponse<ProtectedItemResource, OperationStatusJobExtendedInfo>(
                containerName, protectedItemName, response,
                operationId => BackupClient.ProtectedItemOperationResults.GetWithHttpMessagesAsync(
                    VaultName, ResourceGroup, FabricName, containerName, protectedItemName, operationId).Result,
                operationId => BackupClient.ProtectedItemOperationStatuses.GetWithHttpMessagesAsync(
                    VaultName, ResourceGroup, FabricName, containerName, protectedItemName, operationId).Result);

            Assert.NotNull(jobResponse.JobId);

            return jobResponse.JobId;
        }

        public void WaitForJobCompletion(string jobId)
        {
            string jobStatus = string.Empty;

            RetryActionWithTimeout(
                () => jobStatus = GetJobStatus(jobId),
                () => !IsJobInProgress(jobStatus),
                TimeSpan.FromHours(3),
                statusCode =>
                {
                    TestUtilities.Wait(5000);
                    return true;
                });
        }

        public string GetJobStatus(string jobId)
        {
            var result = BackupClient.JobDetails.GetWithHttpMessagesAsync(VaultName, ResourceGroup, jobId).Result;
            Assert.NotNull(result);
            Assert.Equal(result.Response.StatusCode, System.Net.HttpStatusCode.OK);
            return ((AzureIaaSVMJob)result.Body.Properties).Status;
        }

        public bool IsJobInProgress(string jobStatus)
        {
            return jobStatus.CompareTo("InProgress") == 0 || jobStatus.CompareTo("Cancelling") == 0;
        }

        public void RetryActionWithTimeout(Action action, Func<bool> validator, TimeSpan timeout, Func<HttpStatusCode, bool> shouldRetry)
        {
            DateTime timedOut = DateTime.Now + timeout;

            do
            {
                try
                {
                    action();
                }
                catch (CloudException exception)
                {
                    if (!shouldRetry(exception.Response.StatusCode))
                    {
                        throw;
                    }
                }
            }
            while (DateTime.Now < timedOut && !validator());
        }

        private void ValidateOperationResponse(AzureOperationResponse response)
        {
            Assert.NotNull(response);
            Assert.Equal(System.Net.HttpStatusCode.Accepted, response.Response.StatusCode);
            Assert.True(response.Response.Headers.Contains("Location"));
            Assert.True(response.Response.Headers.Contains("Azure-AsyncOperation"));
            Assert.True(response.Response.Headers.Contains("Retry-After"));
        }
        
        public List<ProtectedItemResource> ListProtectedItems()
        {
            return GetPagedList(
                () => BackupClient.BackupProtectedItems.List(VaultName, ResourceGroup),
                nextLink => BackupClient.BackupProtectedItems.ListNext(nextLink));
        }

        public List<T> GetPagedList<T>(Func<IPage<T>> listResources, Func<string, IPage<T>> listNext)
            where T : Models.Resource
        {
            var resources = new List<T>();
            string nextLink = null;

            var pagedResources = listResources();

            foreach (var pagedResource in pagedResources)
            {
                resources.Add(pagedResource);
            }

            while (!string.IsNullOrEmpty(nextLink))
            {
                nextLink = pagedResources.NextPageLink;

                foreach (var pagedResource in listNext(nextLink))
                {
                    resources.Add(pagedResource);
                }
            }

            return resources;
        }

        public List<RecoveryPointResource> ListRecoveryPoints(string containerName, string protectedItemName)
        {
            return GetPagedList(
                () => BackupClient.RecoveryPoints.List(VaultName, ResourceGroup, FabricName, containerName, protectedItemName),
                nextLink => BackupClient.RecoveryPoints.ListNext(nextLink));
        }

        public string Restore(string containerName, string protectedItemName, string recoveryPointName, string sourceResourceId, string storageAccountId)
        {
            RestoreRequestResource request = new RestoreRequestResource()
            {
                Properties = new IaasVMRestoreRequest()
                {
                    CreateNewCloudService = false,
                    RecoveryPointId = recoveryPointName,
                    RecoveryType = RecoveryType.RestoreDisks,
                    Region = Location,
                    SourceResourceId = sourceResourceId,
                    StorageAccountId = storageAccountId,
                }
            };
            var response = BackupClient.Restores.TriggerWithHttpMessagesAsync(
                VaultName, ResourceGroup, FabricName, containerName, protectedItemName, recoveryPointName, request).Result;
            ValidateOperationResponse(response);

            var jobResponse = GetOperationResponse<ProtectedItemResource, OperationStatusJobExtendedInfo>(
                containerName, protectedItemName, response,
                operationId => BackupClient.ProtectedItemOperationResults.GetWithHttpMessagesAsync(
                    VaultName, ResourceGroup, FabricName, containerName, protectedItemName, operationId).Result,
                operationId => BackupClient.ProtectedItemOperationStatuses.GetWithHttpMessagesAsync(
                    VaultName, ResourceGroup, FabricName, containerName, protectedItemName, operationId).Result);

            Assert.NotNull(jobResponse.JobId);

            return jobResponse.JobId;
        }

        public string DisableProtection(string containerName, string itemName)
        {
            var response = BackupClient.ProtectedItems.DeleteWithHttpMessagesAsync(
                VaultName, ResourceGroup, FabricName, containerName, itemName).Result;
            ValidateOperationResponse(response);

            var jobResponse = GetOperationStatus<OperationStatusJobExtendedInfo>(
                containerName, itemName, response,
                operationId => BackupClient.BackupOperationStatuses.GetWithHttpMessagesAsync(
                    VaultName, ResourceGroup, operationId).Result);

            Assert.NotNull(jobResponse.JobId);

            return jobResponse.JobId;
        }

        public TokenInformation GetBackupSecurityPin()
        {
            return BackupClient.SecurityPINs.Get(VaultName, ResourceGroup);
        }

        #region Private Method

        private T GetOperationStatus<T>(string containerName, string itemName, AzureOperationResponse response,
            Func<string, AzureOperationResponse<OperationStatus>> getOpStatus)
            where T : OperationStatusExtendedInfo
        {
            var operationId = response.Response.Headers.GetAzureAsyncOperationId();

            var opStatusResponse = getOpStatus(operationId);

            while (opStatusResponse.Body.Status == OperationStatusValues.InProgress)
            {
                TestUtilities.Wait(5000);

                opStatusResponse = getOpStatus(operationId);
            }

            opStatusResponse = getOpStatus(operationId);
            Assert.Equal(OperationStatusValues.Succeeded, opStatusResponse.Body.Status);

            return (T)(opStatusResponse.Body.Properties);
        }

        private S GetOperationResponse<T, S>(string containerName, string protectedItemName, AzureOperationResponse response,
            Func<string, AzureOperationResponse<T>> getOpResult,
            Func<string, AzureOperationResponse<OperationStatus>> getOpStatus)
            where T : class
            where S : OperationStatusExtendedInfo
        {
            var operationId = response.Response.Headers.Location.Segments.Last();

            var opResponse = getOpResult(operationId);

            while (opResponse.Response.StatusCode == System.Net.HttpStatusCode.Accepted)
            {
                TestUtilities.Wait(5000);

                opResponse = getOpResult(opResponse.Response.Headers.Location.Segments.Last());
            }

            var opStatusResponse = getOpStatus(operationId);

            return (S)(opStatusResponse.Body.Properties);
        }

        private bool ResourceNotSyncedRetryLogic(HttpStatusCode statusCode)
        {
            bool shouldRetry = statusCode == (HttpStatusCode)429 || statusCode == HttpStatusCode.NotFound;
            if (shouldRetry)
            {
                TestUtilities.Wait(TimeSpan.FromSeconds(30));
            }
            return shouldRetry;
        }


        #endregion
        public void Dispose()
        {
            DisposeVaults();
            BackupClient.Dispose();
            VaultClient.Dispose();
        }
    }
}

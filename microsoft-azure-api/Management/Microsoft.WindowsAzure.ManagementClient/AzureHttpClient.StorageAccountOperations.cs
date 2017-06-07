//-----------------------------------------------------------------------
// <copyright file="AzureHttpClient.StorageAccountOperations.cs" company="Microsoft">
//    Copyright 2012 Microsoft Corporation
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
// <summary>
//    Contains code for the StorageAccount operations on the AzureHttpClient class.
// </summary>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.ManagementClient.v1_7
{
    /// <summary>
    /// The main class of the client library, contains all of the Async methods that 
    /// represent Azure APIs
    /// </summary>
    public partial class AzureHttpClient
    {
        /// <summary>
        /// Begins an asychronous operation to list the storage accounts in the subscription.
        /// </summary>
        /// <param name="token">An optional <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> which returns a <see cref="StorageAccountPropertiesCollection"/></returns>
        public Task<StorageAccountPropertiesCollection> ListStorageAccountsAsync(CancellationToken token = default(CancellationToken))
        {
            HttpRequestMessage message = CreateBaseMessage(HttpMethod.Get, CreateTargetUri(UriFormatStrings.StorageServices));

            return StartGetTask<StorageAccountPropertiesCollection>(message, token);
        }

        /// <summary>
        /// Begins an asychronous operation to get the properties associated with a storage account.
        /// </summary>
        /// <param name="storageAccountName">The name of the storage account.</param>
        /// <param name="token">An optional <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> which returns a <see cref="StorageAccountProperties"/> object.</returns>
        public Task<StorageAccountProperties> GetStorageAccountPropertiesAsync(string storageAccountName, CancellationToken token = default(CancellationToken))
        {
            Validation.ValidateStorageAccountName(storageAccountName);

            HttpRequestMessage message = CreateBaseMessage(HttpMethod.Get, CreateTargetUri(UriFormatStrings.StorageServicesAndAccount, storageAccountName));

            return StartGetTask<StorageAccountProperties>(message, token);

        }

        /// <summary>
        /// Begins an asychronous operation to get the access keys associated with a storage account.
        /// </summary>
        /// <param name="storageAccountName">The name of the storage account.</param>
        /// <param name="token">An optional <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> which returns a <see cref="StorageAccountKeys"/> object.</returns>
        public Task<StorageAccountKeys> GetStorageAccountKeysAsync(string storageAccountName, CancellationToken token = default(CancellationToken))
        {
            Validation.ValidateStorageAccountName(storageAccountName);

            HttpRequestMessage message = CreateBaseMessage(HttpMethod.Get, CreateTargetUri(UriFormatStrings.GetStorageAccountKeys, storageAccountName));

            return StartGetTask<StorageAccountKeys>(message, token);

        }

        /// <summary>
        /// Begins and asyncrounous operation to regenerate one of the storage account keys.
        /// </summary>
        /// <param name="storageAccountName">The name of the storage account.</param>
        /// <param name="keyType">Which storage account key to regenerate.</param>
        /// <param name="token">An optional <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> which returns a new <see cref="StorageAccountKeys"/> object.</returns>
        public Task<StorageAccountKeys> RegenerateStorageAccountKeys(string storageAccountName, StorageAccountKeyType keyType, CancellationToken token = default(CancellationToken))
        {
            Validation.ValidateStorageAccountName(storageAccountName);

            RegenerateStorageAccountKeysInfo info = RegenerateStorageAccountKeysInfo.Create(keyType);

            HttpRequestMessage message = CreateBaseMessage(HttpMethod.Post, CreateTargetUri(UriFormatStrings.RegenerateStorageAccountKeys, storageAccountName), info);

            //while this, clearly, is not a get operation, it returns a custom datacontract
            //so we can use the StartGetTask method to get the right return value
            return StartGetTask<StorageAccountKeys>(message, token);
        }

        /// <summary>
        /// Begins an asychronous operation to create a storage account.
        /// </summary>
        /// <param name="storageAccountName">A name for the storage account that is unique within Azure. Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.
        /// This name is the DNS prefix name and can be used to access blobs, queues, and tables in the storage account.
        /// For example: http://ServiceName.blob.core.windows.net/mycontainer/. Required. </param>
        /// <param name="label">The label for the storage account, may be up to 100 characters in length. Required.</param>
        /// <param name="description">A description for the storage account. May be up to 1024 characters in length. Optional, may be null.</param>
        /// <param name="location">A location for the storage account. Valid values are returned from <see cref="AzureHttpClient.ListLocationsAsync"/>. Either location or affinity group is required, but not both.</param>
        /// <param name="affinityGroup">The name of an existing affinity group associated with this subscription. Valid values are returned from <see cref="ListAffinityGroupsAsync"/>. Either location or affinity group is required, but not both.</param>
        /// <param name="geoReplicationEnabled">Specifies whether the storage account is created with the geo-replication enabled. 
        /// If set to true, the data in the storage account is replicated across more than one geographic location so as to enable resilience in the face of catastrophic service loss.
        /// Default is true. </param>
        /// <param name="extendedProperties">An optional <see cref="IDictionary{String, String}"/> that contains Name Value pairs representing user defined metadata for the storage account.</param>
        /// <param name="token">An optional <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> which returns a string representing the operation Id for this operation.</returns>
        /// <remarks>CreateStorageAccountAsync is a long-running asynchronous operation. When the Task representing CreateStorageAccountAsync is complete,
        /// without throwing an exception, this indicates that the operation as been accepted by the server, but has not completed. To track progress of
        /// the long-running operation use the operation Id returned from the CreateStorageAccountAsync <see cref="Task"/> in calls to <see cref="GetOperationStatusAsync"/>
        /// until it returns either <see cref="OperationStatus.Succeeded"/> or <see cref="OperationStatus.Failed"/>.</remarks>
        public Task<string> CreateStorageAccountAsync(string storageAccountName, string label, string description, string location, string affinityGroup, bool geoReplicationEnabled = true, IDictionary<string, string> extendedProperties = null, CancellationToken token = default(CancellationToken))
        {
            CreateStorageAccountInfo info = CreateStorageAccountInfo.Create(storageAccountName, description, label, affinityGroup, location, geoReplicationEnabled, extendedProperties);

            HttpRequestMessage message = CreateBaseMessage(HttpMethod.Post, CreateTargetUri(UriFormatStrings.StorageServices), info);

            return StartSendTask(message, token);
        }

        /// <summary>
        /// Begins an asychronous operation to delete a storage account.
        /// </summary>
        /// <param name="storageAccountName">The name of the storage account to delete.</param>
        /// <param name="token">An optional <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> which returns a string representing the operation Id for this operation.</returns>
        /// <remarks>When the Task representing DeleteStorageAccountAsync is complete, and does not throw an exception, the operation is complete. 
        /// There is no need to track the operation Id using GetOperationStatus with this operation.
        /// </remarks>
        public Task<string> DeleteStorageAccountAsync(string storageAccountName, CancellationToken token = default(CancellationToken))
        {
            Validation.ValidateStorageAccountName(storageAccountName);

            HttpRequestMessage message = CreateBaseMessage(HttpMethod.Delete, CreateTargetUri(UriFormatStrings.StorageServicesAndAccount, storageAccountName));

            return StartSendTask(message, token);
        }

        /// <summary>
        /// Begins and asychrounous operation to update a storage account
        /// </summary>
        /// <param name="storageAccountName">The name of the storage account.</param>
        /// <param name="label">The label for the storage account, may be up to 100 characters in length. Optional, may be null.</param>
        /// <param name="description">A description for the storage account. May be up to 1024 characters in length. Optional, may be null.</param>
        /// <param name="geoReplicationEnabled">Specifies whether the storage account is created with the geo-replication enabled. 
        /// If set to true, the data in the storage account is replicated across more than one geographic location so as to enable resilience in the face of catastrophic service loss.
        /// Default is true. </param>
        /// <param name="extendedProperties">An optional <see cref="IDictionary{String, String}"/> that contains Name Value pairs representing user defined metadata for the storage account.</param>
        /// <param name="token">An optional <see cref="CancellationToken"/>.</param>
        /// <returns></returns>
        public Task<string> UpdateStorageAccountAsync(string storageAccountName, string label, string description, bool geoReplicationEnabled,
            IDictionary<string, string> extendedProperties = null, CancellationToken token = default(CancellationToken))
        {
            Validation.ValidateStorageAccountName(storageAccountName);

            UpdateStorageAccountInfo info = UpdateStorageAccountInfo.Create(label, description, geoReplicationEnabled, extendedProperties);

            HttpRequestMessage message = CreateBaseMessage(HttpMethod.Put, CreateTargetUri(UriFormatStrings.StorageServicesAndAccount, storageAccountName), info);

            return StartSendTask(message, token);
        }

        //TODO: Regenerate Storage Account Keys
    }
}

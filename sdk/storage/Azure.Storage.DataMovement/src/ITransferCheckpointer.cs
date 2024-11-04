// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.DataMovement.JobPlan;

namespace Azure.Storage.DataMovement
{
    internal interface ITransferCheckpointer
    {
        Task AddNewJobAsync(
            string transferId,
            StorageResource source,
            StorageResource destination,
            CancellationToken cancellationToken = default);

        Task AddNewJobPartAsync(
            string transferId,
            int partNumber,
            Stream headerStream,
            CancellationToken cancellationToken = default);

        Task<bool> IsEnumerationCompleteAsync(
            string transferId,
            CancellationToken cancellationToken = default);

        Task SetEnumerationCompleteAsync(
            string transferId,
            CancellationToken cancellationToken = default);

        Task<int> GetCurrentJobPartCountAsync(
            string transferId,
            CancellationToken cancellationToken = default);

        Task<DataTransferStatus> GetJobStatusAsync(
            string transferId,
            CancellationToken cancellationToken = default);

        Task SetJobStatusAsync(
            string transferId,
            DataTransferStatus status,
            CancellationToken cancellationToken = default);

        Task<JobPartPlanHeader> GetJobPartAsync(
            string transferId,
            int partNumber,
            CancellationToken cancellationToken = default);

        Task SetJobPartStatusAsync(
            string transferId,
            int partNumber,
            DataTransferStatus status,
            CancellationToken cancellationToken = default);

        Task<DataTransferProperties> GetDataTransferPropertiesAsync(
            string transferId,
            CancellationToken cancellationToken = default);

        Task<bool> TryRemoveStoredTransferAsync(
            string transferId,
            CancellationToken cancellationToken = default);

        Task<List<string>> GetStoredTransfersAsync(CancellationToken cancellationToken = default);
    }
}

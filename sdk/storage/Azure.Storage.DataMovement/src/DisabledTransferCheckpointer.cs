// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Storage.DataMovement.JobPlan;

namespace Azure.Storage.DataMovement
{
    internal class DisabledTransferCheckpointer : ITransferCheckpointer
    {
        public Task AddNewJobAsync(string transferId, StorageResource source, StorageResource destination, CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }

        public Task AddNewJobPartAsync(string transferId, int partNumber, JobPartPlanHeader header, CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }

        public Task<int> GetCurrentJobPartCountAsync(string transferId, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(0);
        }

        public Task<TransferProperties> GetTransferPropertiesAsync(string transferId, CancellationToken cancellationToken = default)
        {
            throw Errors.CheckpointerDisabled(nameof(GetTransferPropertiesAsync));
        }

        public Task<JobPartPlanHeader> GetJobPartAsync(string transferId, int partNumber, CancellationToken cancellationToken = default)
        {
            throw Errors.CheckpointerDisabled(nameof(GetJobPartAsync));
        }

        public Task<TransferStatus> GetJobStatusAsync(string transferId, CancellationToken cancellationToken = default)
        {
            throw Errors.CheckpointerDisabled(nameof(GetJobStatusAsync));
        }

        public Task<List<string>> GetStoredTransfersAsync(CancellationToken cancellationToken = default)
        {
            return Task.FromResult(new List<string>());
        }

        public Task<bool> IsEnumerationCompleteAsync(string transferId, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(true);
        }

        public Task SetEnumerationCompleteAsync(string transferId, CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }

        public Task SetJobPartStatusAsync(string transferId, int partNumber, TransferStatus status, CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }

        public Task SetJobStatusAsync(string transferId, TransferStatus status, CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }

        public Task<bool> TryRemoveStoredTransferAsync(string transferId, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(true);
        }
    }
}

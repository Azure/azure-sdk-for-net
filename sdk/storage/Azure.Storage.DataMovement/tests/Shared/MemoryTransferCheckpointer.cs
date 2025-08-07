// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Storage.DataMovement.JobPlan;

namespace Azure.Storage.DataMovement.Tests;

internal class MemoryTransferCheckpointer : ITransferCheckpointer
{
    public class Job
    {
        public string TransferId { get; set; }
        public DateTimeOffset CreationTime { get; set; }
        public JobPlanOperation Operation { get; set; }
        public TransferStatus Status { get; set; }
        public StorageResource Source { get; set; }
        public StorageResource Destination { get; set; }
        public bool EnumerationComplete { get; set; }
        public Dictionary<int, JobPart> Parts { get; set; } = new();
    }
    public class JobPart
    {
        public TransferStatus Status { get; set; }
        private JobPartPlanHeader _plan;
        public JobPartPlanHeader Plan
        {
            // do this conversion because no deep copy implemented currently
            get
            {
                if (_plan == null)
                {
                    return null;
                }
                using MemoryStream ms = new();
                _plan.Serialize(ms);
                return JobPartPlanHeader.Deserialize(ms);
            }
            set
            {
                if (value == null)
                {
                    _plan = null;
                }
                using MemoryStream ms = new();
                value.Serialize(ms);
                _plan = JobPartPlanHeader.Deserialize(ms);
            }
        }
    }

    public Dictionary<string, Job> Jobs { get; set; } = new();

    public virtual Task AddNewJobAsync(string transferId, StorageResource source, StorageResource destination, CancellationToken cancellationToken = default)
    {
        CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
        if (Jobs.ContainsKey(transferId))
        {
            throw new Exception($"Job {transferId} already exists.");
        }
        Jobs[transferId] = new Job
        {
            TransferId = transferId,
            CreationTime = DateTimeOffset.Now,
            Operation = JobPlanOperation.Upload, // TODO
            Source = source,
            Destination = destination,
            Status = new(TransferState.Queued, false, false),
        };
        return Task.CompletedTask;
    }

    public virtual Task AddNewJobPartAsync(string transferId, int partNumber, JobPartPlanHeader header, CancellationToken cancellationToken = default)
    {
        CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
        if (!Jobs.TryGetValue(transferId, out Job job))
        {
            throw new Exception("Job does not exist.");
        }
        if (job.Parts.ContainsKey(partNumber))
        {
            throw new Exception($"Job part {partNumber} already exists for job {job.TransferId}.");
        }
        job.Parts.Add(partNumber, new()
        {
            Plan = header,
            Status = new(TransferState.Queued, false, false),
        });
        return Task.CompletedTask;
    }

    public virtual Task<int> GetCurrentJobPartCountAsync(string transferId, CancellationToken cancellationToken = default)
    {
        CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
        return Task.FromResult(Jobs.TryGetValue(transferId, out Job job) ? job.Parts.Count : 0);
    }

    public virtual Task<TransferProperties> GetTransferPropertiesAsync(string transferId, CancellationToken cancellationToken = default)
    {
        CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
        if (!Jobs.TryGetValue(transferId, out Job job))
        {
            throw new Exception("Job does not exist.");
        }
        return Task.FromResult(new TransferProperties()
        {
            TransferId = job.TransferId,
            SourceUri = job.Source.Uri,
            SourceProviderId = job.Source.ProviderId,
            DestinationUri = job.Destination.Uri,
            DestinationProviderId = job.Destination.ProviderId,
            IsContainer = job.Source.IsContainer,
        });
    }

    public virtual Task<JobPartPlanHeader> GetJobPartAsync(string transferId, int partNumber, CancellationToken cancellationToken = default)
    {
        CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
        if (!Jobs.TryGetValue(transferId, out Job job))
        {
            throw new Exception("Job does not exist.");
        }
        if (!job.Parts.TryGetValue(partNumber, out JobPart part))
        {
            throw new Exception($"Job part {partNumber} does not exists for job {job.TransferId}.");
        }
        return Task.FromResult(part.Plan);
    }

    public virtual Task<TransferStatus> GetJobStatusAsync(string transferId, CancellationToken cancellationToken = default)
    {
        CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
        if (!Jobs.TryGetValue(transferId, out Job job))
        {
            throw new Exception("Job does not exist.");
        }
        return Task.FromResult(job.Status.DeepCopy());
    }

    public virtual Task<List<string>> GetStoredTransfersAsync(CancellationToken cancellationToken = default)
    {
        CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
        return Task.FromResult(Jobs.Keys.ToList());
    }

    public virtual Task<bool> IsEnumerationCompleteAsync(string transferId, CancellationToken cancellationToken = default)
    {
        CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
        return Task.FromResult(Jobs.TryGetValue(transferId, out Job job) && job.EnumerationComplete);
    }

    public virtual Task SetEnumerationCompleteAsync(string transferId, CancellationToken cancellationToken = default)
    {
        CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
        if (Jobs.TryGetValue(transferId, out Job job))
        {
            job.EnumerationComplete = true;
        }
        return Task.CompletedTask;
    }

    public virtual Task SetJobPartStatusAsync(string transferId, int partNumber, TransferStatus status, CancellationToken cancellationToken = default)
    {
        CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
        if (Jobs.TryGetValue(transferId, out Job job) && job.Parts.TryGetValue(partNumber, out JobPart part))
        {
            part.Status = status.DeepCopy();
        }
        return Task.CompletedTask;
    }

    public virtual Task SetJobStatusAsync(string transferId, TransferStatus status, CancellationToken cancellationToken = default)
    {
        CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
        if (Jobs.TryGetValue(transferId, out Job job))
        {
            job.Status = status.DeepCopy();
        }
        return Task.CompletedTask;
    }

    public virtual Task<bool> TryRemoveStoredTransferAsync(string transferId, CancellationToken cancellationToken = default)
    {
        CancellationHelper.ThrowIfCancellationRequested(cancellationToken);
        return Task.FromResult(Jobs.Remove(transferId));
    }
}

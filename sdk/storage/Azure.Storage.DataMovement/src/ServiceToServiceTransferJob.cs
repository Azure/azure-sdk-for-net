// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

namespace Azure.Storage.DataMovement
{
    internal class ServiceToServiceTransferJob : TransferJobInternal
    {
        /// <summary>
        /// Create Storage Transfer Job.
        /// </summary>
        internal ServiceToServiceTransferJob(
            DataTransfer dataTransfer,
            StorageResourceItem sourceResource,
            StorageResourceItem destinationResource,
            DataTransferOptions transferOptions,
            TransferCheckpointer checkpointer,
            DataTransferErrorMode errorHandling,
            ArrayPool<byte> arrayPool,
            ClientDiagnostics clientDiagnostics)
            : base(dataTransfer,
                  sourceResource,
                  destinationResource,
                  ServiceToServiceJobPart.CreateJobPartAsync,
                  ServiceToServiceJobPart.CreateJobPartAsync,
                  transferOptions,
                  checkpointer,
                  errorHandling,
                  arrayPool,
                  clientDiagnostics)
        {
        }

        /// <summary>
        /// Create Storage Transfer Job.
        /// </summary>
        internal ServiceToServiceTransferJob(
            DataTransfer dataTransfer,
            StorageResourceContainer sourceResource,
            StorageResourceContainer destinationResource,
            DataTransferOptions transferOptions,
            TransferCheckpointer checkpointer,
            DataTransferErrorMode errorHandling,
            ArrayPool<byte> arrayPool,
            ClientDiagnostics clientDiagnostics)
            : base(dataTransfer,
                  sourceResource,
                  destinationResource,
                  ServiceToServiceJobPart.CreateJobPartAsync,
                  ServiceToServiceJobPart.CreateJobPartAsync,
                  transferOptions,
                  checkpointer,
                  errorHandling,
                  arrayPool,
                  clientDiagnostics)
        {
        }
    }
}

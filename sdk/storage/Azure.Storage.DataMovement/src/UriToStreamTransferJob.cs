// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Buffers;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Azure.Core.Pipeline;

namespace Azure.Storage.DataMovement
{
    internal class UriToStreamTransferJob : TransferJobInternal
    {
        /// <summary>
        /// Create Storage Transfer Job for single transfer
        /// </summary>
        internal UriToStreamTransferJob(
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
                  UriToStreamJobPart.CreateJobPartAsync,
                  UriToStreamJobPart.CreateJobPartAsync,
                  transferOptions,
                  checkpointer,
                  errorHandling,
                  arrayPool,
                  clientDiagnostics)
        {
        }

        /// <summary>
        /// Create Storage Transfer Job for container transfer
        /// </summary>
        internal UriToStreamTransferJob(
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
                  UriToStreamJobPart.CreateJobPartAsync,
                  UriToStreamJobPart.CreateJobPartAsync,
                  transferOptions,
                  checkpointer,
                  errorHandling,
                  arrayPool,
                  clientDiagnostics)
        {
        }
    }
}

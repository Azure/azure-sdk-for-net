// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Storage.DataMovement
{
    internal class DisabledTransferCheckpointer : TransferCheckpointer
    {
        public DisabledTransferCheckpointer() { }

        public override Task AddNewJobAsync(string transferId, StorageResource source, StorageResource destination, CancellationToken cancellationToken = default)
        {
            Console.WriteLine("AddNewJobAsync");
            return Task.CompletedTask;
        }

        public override Task AddNewJobPartAsync(string transferId, int partNumber, Stream headerStream, CancellationToken cancellationToken = default)
        {
            Console.WriteLine("AddNewJobPartAsync");
            return Task.CompletedTask;
        }

        public override Task<int> CurrentJobPartCountAsync(string transferId, CancellationToken cancellationToken = default)
        {
            Console.WriteLine("CurrentJobPartCountAsync");
            return Task.FromResult(0);
        }

        public override Task<List<string>> GetStoredTransfersAsync(CancellationToken cancellationToken = default)
        {
            Console.WriteLine("GetStoredTransfersAsync");
            return Task.FromResult(new List<string>());
        }

        public override Task<Stream> ReadJobPartPlanFileAsync(string transferId, int partNumber, int offset, int length, CancellationToken cancellationToken = default)
        {
            Console.WriteLine("ReadJobPartPlanFileAsync");
            throw Errors.CheckpointerDisabled();
        }

        public override Task<Stream> ReadJobPlanFileAsync(string transferId, int offset, int length, CancellationToken cancellationToken = default)
        {
            Console.WriteLine("ReadJobPlanFileAsync");
            throw Errors.CheckpointerDisabled();
        }

        public override Task SetJobPartTransferStatusAsync(string transferId, int partNumber, DataTransferStatus status, CancellationToken cancellationToken = default)
        {
            Console.WriteLine("SetJobPartTransferStatusAsync");
            return Task.CompletedTask;
        }

        public override Task SetJobTransferStatusAsync(string transferId, DataTransferStatus status, CancellationToken cancellationToken = default)
        {
            Console.WriteLine("SetJobTransferStatusAsync");
            return Task.CompletedTask;
        }

        public override Task<bool> TryRemoveStoredTransferAsync(string transferId, CancellationToken cancellationToken = default)
        {
            Console.WriteLine("TryRemoveStoredTransferAsync");
            return Task.FromResult(false);
        }

        public override Task WriteToJobPlanFileAsync(string transferId, int fileOffset, byte[] buffer, int bufferOffset, int length, CancellationToken cancellationToken = default)
        {
            Console.WriteLine("WriteToJobPlanFileAsync");
            return Task.CompletedTask;
        }
    }
}

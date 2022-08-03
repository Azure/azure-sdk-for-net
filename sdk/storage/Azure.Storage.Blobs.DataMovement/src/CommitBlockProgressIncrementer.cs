// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Storage.Blobs.DataMovement.Models;

namespace Azure.Storage.Blobs.DataMovement
{
    internal class CommitBlockProgressIncrementer : Progress<(long Offset, long Size)>
    {
        private long _actualAmountOfRanges;
        internal ConcurrentBag<(long Offset, long Size)> _commitBlockRanges;
        // TODO: update to be the delegate that takes in the commit block list
        internal Func<Task> _commitBlockDelegate;

        /// <summary>
        /// Initializes the constructor for the internal progress tracker to kick off commit block list task
        /// </summary>
        /// <param name="expectedAmountofRanges"></param>
        /// <param name="commitBlockDelegate"></param>
        /// <param name="existingBlockRanges">
        /// Block Ranges that have already been staged.
        /// (Used specifically in the scenario of resuming an upload job).
        /// </param>
        public CommitBlockProgressIncrementer(
            long expectedAmountofRanges,
            Func<Task> commitBlockDelegate,
            List<(long Offset, long Size)> existingBlockRanges = default)
        {
            Argument.AssertNotNull(expectedAmountofRanges, nameof(expectedAmountofRanges));
            Argument.AssertNotNull(commitBlockDelegate, nameof(commitBlockDelegate));
            _actualAmountOfRanges = 0;
            _commitBlockDelegate = commitBlockDelegate;
            _commitBlockRanges =
                (!existingBlockRanges?.Any() ?? false)
                ? new ConcurrentBag<(long Offset, long Size)>(existingBlockRanges)
                : new ConcurrentBag<(long Offset, long Size)>();
        }

        /// <summary>
        /// Increments the current value and reports it to the progress handler
        /// </summary>
        /// <param name="offset"></param>
        /// <param name="size"></param>
        public void Report(long offset, long size)
        {
            _commitBlockRanges.Add((offset, size));
            Interlocked.Increment(ref _actualAmountOfRanges);
        }

        /// <summary>
        /// Zeroes out the current accumulation of the ranges
        /// </summary>
        public void Reset()
        {
#if NETSTANDARD2_1_OR_GREATER
            _commitBlockRanges.Clear();
#else
            ConcurrentBag<(long Offset, long Size)> emptyBag = new ConcurrentBag<(long Offset, long Size)>();
            Interlocked.Exchange(ref _commitBlockRanges, emptyBag);
#endif
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Storage.Files.Shares;
using Azure.Storage.Files.Shares.Models;

namespace Azure.Storage.DataMovement.Files.Shares
{
    internal class PathScanner
    {
        public static Lazy<PathScanner> Singleton { get; } = new Lazy<PathScanner>(() => new PathScanner());

        public virtual async IAsyncEnumerable<ShareFileClient> ScanFilesAsync(
            ShareDirectoryClient directory,
            [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            await foreach ((ShareDirectoryClient _, ShareFileClient file) in
                ScanAsync(directory, cancellationToken).ConfigureAwait(false))
            {
                if (file != default)
                {
                    yield return file;
                }
            }
        }

        public virtual async IAsyncEnumerable<(ShareDirectoryClient Dir, ShareFileClient File)> ScanAsync(
            ShareDirectoryClient directory,
            [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            Argument.AssertNotNull(directory, nameof(directory));

            Queue<ShareDirectoryClient> toScan = new();
            toScan.Enqueue(directory);

            while (toScan.Count > 0)
            {
                ShareDirectoryClient current = toScan.Dequeue();
                await foreach (ShareFileItem item in current.GetFilesAndDirectoriesAsync(
                    cancellationToken: cancellationToken).ConfigureAwait(false))
                {
                    if (item.IsDirectory)
                    {
                        ShareDirectoryClient subdir = current.GetSubdirectoryClient(item.Name);
                        toScan.Enqueue(subdir);
                        yield return (Dir: subdir, File: null);
                    }
                    else
                    {
                        yield return (Dir: null, File: current.GetFileClient(item.Name));
                    }
                }
            }
        }
    }
}

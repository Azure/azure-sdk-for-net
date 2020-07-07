// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
#if PUBLICPROTOCOL
using Microsoft.Azure.WebJobs.Storage;
using Microsoft.Azure.WebJobs.Storage.Blob;
#else
#endif
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;

#if PUBLICPROTOCOL
namespace Microsoft.Azure.WebJobs.Protocols
#else
namespace Microsoft.Azure.WebJobs.Host.Protocols
#endif
{
    /// <summary>Represents a command that signals a heartbeat from a running host instance.</summary>
#if PUBLICPROTOCOL
    
    public class HeartbeatCommand : IHeartbeatCommand
#else
    internal class HeartbeatCommand : IHeartbeatCommand
#endif
    {
        private readonly CloudBlockBlob _blob;

        /// <summary>
        /// Initializes a new instance of the <see cref="HeartbeatCommand"/> class.
        /// </summary>
        /// <param name="blob">The heartbeat blob.</param>
        public HeartbeatCommand(CloudBlockBlob blob)
        {
            if (blob == null)
            {
                throw new ArgumentNullException("blob");
            }

            _blob = blob;
        }

        /// <inheritdoc />
        public async Task BeatAsync(CancellationToken cancellationToken)
        {
            bool isContainerNotFoundException = false;

            try
            {
                await _blob.UploadTextAsync(String.Empty, cancellationToken: cancellationToken);
                return;
            }
            catch (StorageException exception)
            {
                if (exception.IsNotFoundContainerNotFound())
                {
                    isContainerNotFoundException = true;
                }
                else
                {
                    throw;
                }
            }

            Debug.Assert(isContainerNotFoundException, "Blob Container was not found");
            await _blob.Container.CreateIfNotExistsAsync(cancellationToken);
            await _blob.UploadTextAsync(String.Empty, cancellationToken: cancellationToken);
        }
    }
}

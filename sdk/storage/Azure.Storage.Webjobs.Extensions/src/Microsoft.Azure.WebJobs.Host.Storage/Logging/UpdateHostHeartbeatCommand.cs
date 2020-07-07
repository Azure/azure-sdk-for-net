// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Storage;
using Microsoft.Azure.WebJobs.Host.Protocols;
using Microsoft.Azure.WebJobs.Host.Timers;

namespace Microsoft.Azure.WebJobs.Host.Executors
{
    internal class UpdateHostHeartbeatCommand : IRecurrentCommand
    {
        private readonly IHeartbeatCommand _heartbeatCommand;

        public UpdateHostHeartbeatCommand(IHeartbeatCommand heartbeatCommand)
        {
            if (heartbeatCommand == null)
            {
                throw new ArgumentNullException("heartbeatCommand");
            }

            _heartbeatCommand = heartbeatCommand;
        }

        public async Task<bool> TryExecuteAsync(CancellationToken cancellationToken)
        {
            try
            {
                await _heartbeatCommand.BeatAsync(cancellationToken);
                return true;
            }
            catch (StorageException exception)
            {
                if (exception.IsServerSideError())
                {
                    return false;
                }

                throw;
            }
        }
    }
}

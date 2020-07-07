// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Host.Executors
{
    internal class FixedHostIdProvider : IHostIdProvider
    {
        private readonly string _hostId;

        public FixedHostIdProvider(string hostId)
        {
            _hostId = hostId;

            if (_hostId == null)
            {
                _hostId = Guid.NewGuid().ToString("N");
            }
        }

        public Task<string> GetHostIdAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(_hostId);
        }
    }
}

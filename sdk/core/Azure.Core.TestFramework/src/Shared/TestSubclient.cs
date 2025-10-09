// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;

namespace Azure.Core.TestFramework
{
    internal class TestSubclient
    {
        public virtual Task<string> MethodAsync(int i, CancellationToken cancellationToken = default)
        {
            return Task.FromResult("Async " + i + " " + cancellationToken.CanBeCanceled);
        }

        public virtual string Method(int i, CancellationToken cancellationToken = default)
        {
            return "Sync " + i + " " + cancellationToken.CanBeCanceled;
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Blobs.Bindings
{
    internal interface IBlobCommitedAction
    {
        Task ExecuteAsync(CancellationToken cancellationToken);

        void Execute();
    }
}

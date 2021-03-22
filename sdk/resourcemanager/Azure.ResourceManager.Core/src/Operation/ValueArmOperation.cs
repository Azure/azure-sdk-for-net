// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.Core
{
    internal class ValueArmOperation<TOperations> : ArmOperation<TOperations>
    {
        public override string Id => throw new NotImplementedException();

        public override TOperations Value => throw new NotImplementedException();

        public override bool HasCompleted => throw new NotImplementedException();

        public override bool HasValue => throw new NotImplementedException();

        public override Response GetRawResponse()
        {
            throw new NotImplementedException();
        }

        public override Response UpdateStatus(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public override ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public override ValueTask<Response<TOperations>> WaitForCompletionAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public override ValueTask<Response<TOperations>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

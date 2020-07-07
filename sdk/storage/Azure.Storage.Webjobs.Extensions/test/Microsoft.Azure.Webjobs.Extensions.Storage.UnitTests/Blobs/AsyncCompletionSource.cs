// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;

namespace Microsoft.Azure.WebJobs.Host.UnitTests.Blobs
{
    internal class AsyncCompletionSource
    {
        private CompletingAsyncResult _result;

        public IAsyncResult AsyncResult
        {
            get { return _result; }
        }

        public void SetAsyncResult(CompletingAsyncResult result)
        {
            if (_result != null)
            {
                throw new InvalidOperationException("SetAsyncResult has already been called.");
            }

            _result = result;
        }

        public void Complete()
        {
            if (_result == null)
            {
                throw new InvalidOperationException("SetAsyncResult was not called.");
            }

            _result.Complete();
        }
    }
}

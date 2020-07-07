// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;

namespace Microsoft.Azure.WebJobs.Host.UnitTests.Blobs.Bindings
{
    internal class CompletedCancellationSpy
    {
        private CompletedCancellableAsyncResult _result;

        public IAsyncResult AsyncResult
        {
            get { return _result; }
        }

        public bool Canceled
        {
            get
            {
                if (_result == null)
                {
                    throw new InvalidOperationException("SetAsyncResult was not called.");
                }

                return _result.Canceled;
            }
        }

        public void SetAsyncResult(CompletedCancellableAsyncResult result)
        {
            if (_result != null)
            {
                throw new InvalidOperationException("SetAsyncResult has already been called.");
            }

            _result = result;
        }
    }
}

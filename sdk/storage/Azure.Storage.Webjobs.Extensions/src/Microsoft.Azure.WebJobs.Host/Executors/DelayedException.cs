// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;

namespace Microsoft.Azure.WebJobs.Host.Executors
{
    internal class DelayedException : IDelayedException
    {
        private readonly Exception _exception;

        public DelayedException(Exception exception)
        {
            _exception = exception;
        }

        public Exception Exception
        {
            get
            {
                return _exception;
            }
        }

        public void Throw()
        {
            throw _exception;
        }
    }
}

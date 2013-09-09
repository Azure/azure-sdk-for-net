// -----------------------------------------------------------------------------------------
// <copyright file="AlwaysRetry.cs" company="Microsoft">
//    Copyright 2012 Microsoft Corporation
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
// -----------------------------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Storage.Core
{
    using Microsoft.WindowsAzure.Storage.RetryPolicies;
    using System;

    public class AlwaysRetry : IRetryPolicy
    {
        private TimeSpan deltaBackoff;
        private int maximumAttempts;

        public AlwaysRetry(TimeSpan deltaBackoff, int maxAttempts)
        {
            this.deltaBackoff = deltaBackoff;
            this.maximumAttempts = maxAttempts;
        }

        public bool ShouldRetry(int currentRetryCount, int statusCode, Exception lastException, out TimeSpan retryInterval, OperationContext operationContext)
        {
            retryInterval = this.deltaBackoff;
            return currentRetryCount < this.maximumAttempts;
        }

        public IRetryPolicy CreateInstance()
        {
            return new AlwaysRetry(this.deltaBackoff, this.maximumAttempts);
        }
    }
}

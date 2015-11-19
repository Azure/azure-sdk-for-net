// Copyright (c) Microsoft Corporation
// All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not
// use this file except in compliance with the License.  You may obtain a copy
// of the License at http://www.apache.org/licenses/LICENSE-2.0
// 
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED
// WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE,
// MERCHANTABLITY OR NON-INFRINGEMENT.
// 
// See the Apache Version 2.0 License for specific language governing
// permissions and limitations under the License.
namespace Microsoft.WindowsAzure.Management.HDInsight.Framework.Rest.Retries
{
    using System;
    using System.Net;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Retries;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Rest.CustomMessageHandlers;

    /// <summary>
    /// A retry policy for the Rest client derived from the user provided retry policy.
    /// </summary>
    internal class HttpRestClientRetryPolicy : Framework.Rest.IRetryPolicy
    {
        private readonly IRetryPolicy retryPolicy;

        public HttpRestClientRetryPolicy(IRetryPolicy retryPolicy)
        {
            if (retryPolicy == null)
            {
                throw new ArgumentNullException("retryPolicy");
            }

            this.retryPolicy = retryPolicy;
        }

        public bool ShouldRetry(Exception exception, int attempt, out TimeSpan delay)
        {
            //Ask the underlying retry policy for the retry parameters.
            var retryParameters = this.retryPolicy.GetRetryParameters(attempt, exception);
            delay = retryParameters.WaitTime;

            //The underlying retry policy does not know about InvalidExpectedStatusCodeException
            //so we handle that here. For everything else we defer back to the underlying retry policy
            var invalidStatusCodeException = exception as InvalidExpectedStatusCodeException;
            if (invalidStatusCodeException != null)
            {
                return RetryUtils.IsTransientHttpStatusCode(invalidStatusCodeException.ReceivedStatusCode);
            }
            return retryParameters.ShouldRetry;
        }
    }
}

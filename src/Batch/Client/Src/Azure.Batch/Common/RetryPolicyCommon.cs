// Copyright (c) Microsoft and contributors.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//
// See the License for the specific language governing permissions and
// limitations under the License.

﻿namespace Microsoft.Azure.Batch.Common
{
    using System;

    internal static class RetryPolicyCommon
    {
        internal static bool ShouldRetry(Exception exception, OperationContext operationContext, int maxRetries)
        {
            bool shouldRetry;
            int currentRetryCount = operationContext.RequestResults.Count - 1;

            if (currentRetryCount < maxRetries)
            {
                BatchException batchException = exception as BatchException;
                if (batchException != null)
                {
                    int statusCode = (int)batchException.RequestInformation.HttpStatusCode;

                    if ((statusCode >= 400 && statusCode < 500)
                        || statusCode == 501 // Not Implemented
                        || statusCode == 505 // Version Not Supported
                        )
                    {
                        shouldRetry = false;
                    }
                    else
                    {
                        shouldRetry = true;
                    }
                }
                else
                {
                    //Note that we use a blacklist here in order to have the most robust retry policy --
                    //attempting to guess all the possible exception types thrown by the network stack to craft a
                    //white list is error prone and so we avoid it.
                    if (exception is Microsoft.Rest.ValidationException)
                    {
                        //TODO: Consider blacklisting SystemException, but SystemException includes TimeoutException which it seems we probably want to retry on
                        shouldRetry = false;
                    }
                    else
                    {
                        //Retry on all other exceptions which aren't a BatchException since those exceptions
                        //mean we haven't heard back from the server
                        shouldRetry = true;
                    }
                }
            }
            else
            {
                shouldRetry = false; //We are out of retries to perform so we will not retry
            }

            return shouldRetry;
        }

        internal static void ValidateArguments(TimeSpan deltaBackoff, int maxRetries)
        {
            if (deltaBackoff < TimeSpan.Zero)
            {
                throw new ArgumentOutOfRangeException("deltaBackoff");
            }

            if (maxRetries < 0)
            {
                throw new ArgumentOutOfRangeException("maxRetries");
            }
        }
    }
}

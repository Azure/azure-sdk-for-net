// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

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

                    if ((statusCode >= 400 && statusCode < 500 
                        && statusCode != 408 // Timeout
                        && statusCode != 429 // Too many reqeuests
                        )
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
                    //Note that we use a disallow list here in order to have the most robust retry policy --
                    //attempting to guess all the possible exception types thrown by the network stack to craft a
                    //white list is error prone and so we avoid it.
                    if (exception is Microsoft.Rest.ValidationException)
                    {
                        //TODO: Consider adding SystemException to disallow list, but SystemException includes TimeoutException which it seems we probably want to retry on
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
                throw new ArgumentOutOfRangeException(nameof(deltaBackoff));
            }

            if (maxRetries < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(maxRetries));
            }
        }
    }
}

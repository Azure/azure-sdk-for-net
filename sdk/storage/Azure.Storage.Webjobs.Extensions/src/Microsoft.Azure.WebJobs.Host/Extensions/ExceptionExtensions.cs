// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.Host.Diagnostics;

namespace System
{
    internal static class ExceptionExtensions
    {
        public static string ToDetails(this Exception exception)
        {
            if (exception == null)
            {
                throw new ArgumentNullException("exception");
            }

            // Additional details are only available on StorageException.
            IDictionary<string, string> additionalDetails = GetAdditionalDetails(exception);

            if (additionalDetails == null || additionalDetails.Count == 0)
            {
                return ExceptionFormatter.GetFormattedException(exception);
            }
            else
            {
                StringBuilder builder = new StringBuilder();
                builder.AppendLine(ExceptionFormatter.GetFormattedException(exception));

                builder.AppendLine("Additional Details:");

                foreach (KeyValuePair<string, string> detail in additionalDetails)
                {
                    builder.AppendFormat("{0}: {1}", detail.Key, detail.Value);
                    builder.AppendLine();
                }

                return builder.ToString();
            }
        }

        private static IDictionary<string, string> GetAdditionalDetails(Exception exception)
        {
#if false // $$$  get this dynamically? 
            StorageException storageException = exception as StorageException;

            if (storageException == null)
            {
                return null;
            }

            RequestResult result = storageException.RequestInformation;

            if (result == null)
            {
                return null;
            }

            StorageExtendedErrorInformation extendedErrorInformation = result.ExtendedErrorInformation;

            if (extendedErrorInformation == null)
            {
                return null;
            }

            return extendedErrorInformation.AdditionalDetails;
#else
            return null;
#endif 
        }

        public static bool IsTimeout(this Exception exception)
        {
            while (exception != null)
            {
                if (exception is FunctionTimeoutException)
                {
                    return true;
                }

                exception = exception.InnerException;
            }

            return false;
        }

        public static bool IsFatal(this Exception exception)
        {
            while (exception != null)
            {
                if ((exception is OutOfMemoryException && !(exception is InsufficientMemoryException)) ||
                    exception is ThreadAbortException ||
                    exception is AccessViolationException ||
                    exception is SEHException ||
                    exception is StackOverflowException)
                {
                    return true;
                }

                if (exception is TypeInitializationException &&
                    exception is TargetInvocationException)
                {
                    break;
                }

                exception = exception.InnerException;
            }

            return false;
        }
    }
}

// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.Cosmos.Table;

namespace Microsoft.Azure.WebJobs.Host.Tables
{
    internal static class TableExtensions
    {
        /// <summary>
        /// Determines whether the exception is due to a 404 Not Found error with the error code TableNotFound.
        /// </summary>
        /// <param name="exception">The storage exception.</param>
        /// <returns>
        /// <see langword="true"/> if the exception is due to a 404 Not Found error with the error code
        /// TableNotFound; otherwise <see langword="false"/>.
        /// </returns>
        public static bool IsNotFoundTableNotFound(this StorageException exception)
        {
            if (exception == null)
            {
                throw new ArgumentNullException("exception");
            }

            RequestResult result = exception.RequestInformation;

            if (result == null)
            {
                return false;
            }

            if (result.HttpStatusCode != 404)
            {
                return false;
            }

            StorageExtendedErrorInformation extendedInformation = result.ExtendedErrorInformation;

            if (extendedInformation == null)
            {
                return false;
            }

            return extendedInformation.ErrorCode == "TableNotFound";
        }

        public static string GetDetailedErrorMessage(this StorageException exception)
        {
            if (exception == null)
            {
                throw new ArgumentNullException("exception");
            }

            string message = exception.Message;

            if (exception.RequestInformation != null)
            {
                message += $" (HTTP status code {exception.RequestInformation.HttpStatusCode.ToString()}: "
                    + $"{exception.RequestInformation.ExtendedErrorInformation?.ErrorCode}. "
                    + $"{exception.RequestInformation.ExtendedErrorInformation?.ErrorMessage})";
            }

            return message;
        }
    }
}

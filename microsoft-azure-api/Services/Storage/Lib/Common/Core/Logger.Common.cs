//-----------------------------------------------------------------------
// <copyright file="Logger.Common.cs" company="Microsoft">
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
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Storage.Core
{
    using System;
    using System.Globalization;
    using System.Threading;

    internal static partial class Logger
    {
#if !WINDOWS_PHONE
        private const string TraceFormat = "{0}: {1}";

        /// <summary>
        /// Creates a well-formatted log entry so that logs can be easily parsed
        /// </summary>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <param name="format">A composite format string.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        /// <returns>Log entry that contains common log prefix and a copy of format in which the format items have been replaced by the string representation of the corresponding objects in args.</returns>
        private static string FormatLine(OperationContext operationContext, string format, object[] args)
        {
            return string.Format(
                CultureInfo.InvariantCulture,
                Logger.TraceFormat,
                (operationContext == null) ? "*" : operationContext.ClientRequestID,
                (args == null) ? format : string.Format(CultureInfo.InvariantCulture, format, args).Replace('\n', '.'));
        }

        /// <summary>
        /// Determines if the current operation context allows for a specific level of log entry.
        /// </summary>
        /// <param name="level">Level of the log entry.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns><c>true</c> if the entry should be logged; otherwise <c>false</c>.</returns>
        private static bool ShouldLog(LogLevel level, OperationContext operationContext)
        {
            return (operationContext == null) || (level <= operationContext.LogLevel);
        }
#endif
    }
}

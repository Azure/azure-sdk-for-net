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

namespace Microsoft.Azure.Batch.Protocol.Core
{
    using System;
    using System.Globalization;
    using System.Threading;

    internal static partial class Logger
    {
        private const string TraceFormat = "{0} : {1}";

        /// <summary>
        /// Creates a well-formatted log entry so that logs can be easily parsed
        /// </summary>
        /// <param name="clientRequestId">The client-request-id.</param>
        /// <param name="format">A composite format string.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        /// <returns>Log entry that contains common log prefix and a copy of format in which the format items have been replaced by the string representation of the corresponding objects in args.</returns>
        private static string FormatLine(string clientRequestId, string format, object[] args)
        {
            return string.Format(
                CultureInfo.InvariantCulture,
                Logger.TraceFormat,
                clientRequestId,
                (args == null) ? format : string.Format(CultureInfo.InvariantCulture, format, args).Replace('\n', '.'));
        }

        /// <summary>
        /// Determines if the current entry should be logged.
        /// </summary>
        /// <param name="entryLogLevel">Log level of the entry.</param>
        /// <param name="intentedLogLevel">Intended log level.</param>
        /// <returns><c>true</c> if the entry should be logged; otherwise <c>false</c>.</returns>
        private static bool ShouldLog(LogLevel entryLogLevel, LogLevel intentedLogLevel)
        {
            return entryLogLevel <= intentedLogLevel;
        }
    }
}

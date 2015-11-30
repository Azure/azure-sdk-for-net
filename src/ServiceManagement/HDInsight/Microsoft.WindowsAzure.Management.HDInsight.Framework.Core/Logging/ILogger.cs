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
namespace Microsoft.WindowsAzure.Management.HDInsight.Logging
{
    /// <summary>
    /// The main interfaces used for logging within the system.
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Logs a "message" level severity with "normal" verbosity.
        /// </summary>
        /// <param name="message">
        /// The message to log.
        /// </param>
        void LogMessage(string message);

        /// <summary>
        /// Logs with the severity and verbosity supplied.
        /// </summary>
        /// <param name="message">
        /// The message to log.
        /// </param>
        /// <param name="severity">
        /// The severity.
        /// </param>
        /// <param name="verbosity">
        /// The verbosity.
        /// </param>
        void LogMessage(string message, Severity severity, Verbosity verbosity);

        /// <summary>
        /// Adds a log writer to the logger.
        /// </summary>
        /// <param name="writer">
        /// The log writer.
        /// </param>
        void AddWriter(ILogWriter writer);

        /// <summary>
        /// Removes a log writer.
        /// </summary>
        /// <param name="writer">The log writer.</param>
        void RemoveWriter(ILogWriter writer);
    }
}

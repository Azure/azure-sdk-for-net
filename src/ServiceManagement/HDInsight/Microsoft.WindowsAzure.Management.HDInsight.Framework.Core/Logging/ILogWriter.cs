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
    /// The severity of a log message.
    /// </summary>
    public enum Severity
    {
        /// <summary>
        /// The message has no severity.
        /// </summary>
        None,

        /// <summary>
        /// The message has "message" severity.
        /// </summary>
        Message,

        /// <summary>
        /// The message has "informational" severity.
        /// </summary>
        Informational,

        /// <summary>
        /// The message has "warning" severity.
        /// </summary>
        Warning,

        /// <summary>
        /// The message has "error" severity.
        /// </summary>
        Error,

        /// <summary>
        /// The message has "critical" severity.
        /// </summary>
        Critical,
    }

    /// <summary>
    /// The verbosity of the message.
    /// </summary>
    public enum Verbosity
    {
        /// <summary>
        /// The message has "quiet" verbosity (don't report).
        /// </summary>
        Quiet,

        /// <summary>
        /// The message has "minimal" verbosity.
        /// </summary>
        Minimal,

        /// <summary>
        /// The message has "normal" verbosity.
        /// </summary>
        Normal,

        /// <summary>
        /// The message has "detailed" verbosity.
        /// </summary>
        Detailed,

        /// <summary>
        /// The message has "diagnostic" verbosity.
        /// </summary>
        Diagnostic
    }

    /// <summary>
    /// The base interface used for logging within this system.
    /// This can be implemented to utilize any logging system 
    /// desired by the consumer.
    /// </summary>
    public interface ILogWriter
    {
        /// <summary>
        /// Used to process a log message.
        /// </summary>
        /// <param name="severity">
        /// The severity of the message.
        /// </param>
        /// <param name="verbosity">
        /// The verbosity of the message.
        /// </param>
        /// <param name="content">
        /// The content of the message.
        /// </param>
        void Log(Severity severity, Verbosity verbosity, string content);
    }
}

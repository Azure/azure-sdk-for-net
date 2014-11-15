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
    using System;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using Microsoft.WindowsAzure.Management.HDInsight.Framework.Core.Library;

    /// <summary>
    /// Extends log provider with logging helper methods.
    /// </summary>
    public static class LogProviderExtensions
    {
        /// <summary>
        /// Logs an exception to the logger.
        /// </summary>
        /// <param name="provider">
        /// The log provider that contains the logger.
        /// </param>
        /// <param name="exception">
        /// The Exception to log.
        /// </param>
        ///// <param name="memberName">
        ///// The name of the calling member.
        ///// </param>
        ///// <param name="sourceFilePath">
        ///// The name of source file.
        ///// </param>
        ///// <param name="sourceLineNumber">
        ///// The source file line number.
        ///// </param>
        [SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed",
            Justification = "This is required for the caller attributes to function properly. [tgs]")]
        public static void LogException(this ILogProvider provider,
                                        Exception exception)
        {
            var stackFrame = new StackFrame(1, true);
            var method = stackFrame.GetMethod();
            string memberName = null;
            if (method.IsNotNull())
            {
                memberName = method.Name;
            }
            var sourceFilePath = stackFrame.GetFileName();
            var sourceLineNumber = stackFrame.GetFileLineNumber();
            if (exception.IsNull())
            {
                throw new ArgumentNullException("exception");
            }
            InternalLogMessage(provider, exception.ToString(), Severity.Error, Verbosity.Normal, memberName, sourceFilePath, sourceLineNumber);
        }

        /// <summary>
        /// Logs a message to the logger.
        /// </summary>
        /// <param name="provider">
        /// The log provider that contains the logger.
        /// </param>
        /// <param name="message">
        /// The message to log.
        /// </param>
        /// <param name="severity">
        /// The severity of the message to log.
        /// </param>
        /// <param name="verbosity">
        /// The verbosity of the message to log.
        /// </param>
        ///// <param name="memberName">
        ///// The name of the calling member.
        ///// </param>
        ///// <param name="sourceFilePath">
        ///// The name of source file.
        ///// </param>
        ///// <param name="sourceLineNumber">
        ///// The source file line number.
        ///// </param>
        [SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed",
            Justification = "This is required for the caller attributes to function properly. [tgs]")]
        public static void LogMessage(this ILogProvider provider, 
                                      string message, 
                                      Severity severity, 
                                      Verbosity verbosity)
                                      //[CallerMemberName] string memberName = "", 
                                      //[CallerFilePath] string sourceFilePath = "", 
                                      //[CallerLineNumber] int sourceLineNumber = 0)
        {
            var stackFrame = new StackFrame(1, true);
            var method = stackFrame.GetMethod();
            string memberName = null;
            if (method.IsNotNull())
            {
                memberName = method.Name;
            }
            var sourceFilePath = stackFrame.GetFileName();
            var sourceLineNumber = stackFrame.GetFileLineNumber();
            if (provider.IsNull())
            {
                throw new ArgumentNullException("provider");
            }
            InternalLogMessage(provider, message, severity, verbosity, memberName, sourceFilePath, sourceLineNumber);
        }

        [SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters",
            MessageId = "Microsoft.WindowsAzure.Management.HDInsight.Logging.ILogger.LogMessage(System.String,Microsoft.WindowsAzure.Management.HDInsight.Logging.Severity,Microsoft.WindowsAzure.Management.HDInsight.Logging.Verbosity)",
            Justification = "Acceptable in this usage. [tgs]")]
        private static void InternalLogMessage(ILogProvider provider, 
                                               string message, 
                                               Severity severity, 
                                               Verbosity verbosity, 
                                               string memberName, 
                                               string sourceFilePath, 
                                               int sourceLineNumber)
        {
            var format = sourceFilePath.IsNotNull()
                              ? "  Type: {0}\r\nMember: {1}\r\n  File: {2}({3})\r\n   UTC: {4}\r\n{5}\r\nThread: {6}"
                              : "  Type: {0}\r\nMember: {1}\r\n   UTC: {4}\r\n{5}\r\nThread: {6}";
            var logger = provider.Logger;
            if (logger.IsNotNull())
            {
                var typeName = provider.GetType().Name;
                var logMessage = string.Format(
                    CultureInfo.InvariantCulture,
                    format,
                    typeName,
                    memberName,
                    sourceFilePath,
                    sourceLineNumber,
                    DateTime.UtcNow.ToString("o", CultureInfo.InvariantCulture),
                    message,
                    Thread.CurrentThread.ManagedThreadId);
                logger.LogMessage(logMessage, severity, verbosity);
            }
        }
    }
}

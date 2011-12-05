//-----------------------------------------------------------------------
// <copyright file="TraceHelper.cs" company="Microsoft">
//    Copyright 2011 Microsoft Corporation
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
// <summary>
//    Contains code for the TraceHelper class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient
{
    using System;
    using System.Diagnostics;
    using System.Threading;

    /// <summary>
    /// Tracing helper class.
    /// </summary>
    internal class TraceHelper
    {
        /// <summary>
        /// Internal flag for turning on tracing.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.StyleCop.CSharp.MaintainabilityRules",
            "SA1401:FieldsMustBePrivate",
            Justification = "Unable to change while remaining backwards compatible.")]
        internal static bool TracingOn = false;

        /// <summary>
        /// Internal format string for trace messages.
        /// </summary>
        private const string InternalFormat = "Thread {0}, Tickcount {1}, ";

        /// <summary>
        /// Writes the line.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="arg">The arguments.</param>
        [Conditional("DEBUG")]
        internal static void WriteLine(string format, params object[] arg)
        {
            if (TracingOn)
            {
                WriteLineInternal(format, arg);
            }
        }

        /// <summary>
        /// Writes the line internal.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="arg">The arguments.</param>
        private static void WriteLineInternal(string format, params object[] arg)
        {
            string traceString = string.Format(format, arg);
            string internalTraceString = string.Format(InternalFormat + traceString, Thread.CurrentThread.ManagedThreadId, Environment.TickCount);
            Debug.WriteLine(internalTraceString);
        }
    }
}

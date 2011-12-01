//-----------------------------------------------------------------------
// <copyright file="TraceHelper.cs" company="Microsoft">
//    Copyright (c)2010 Microsoft. All rights reserved.
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

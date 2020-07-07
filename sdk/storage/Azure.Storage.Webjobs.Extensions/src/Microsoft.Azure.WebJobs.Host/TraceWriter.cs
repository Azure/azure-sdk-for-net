// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Diagnostics;

namespace Microsoft.Azure.WebJobs.Host
{
    /// <summary>
    /// Base class for trace writers used by the <see cref="JobHost"/> for
    /// event tracing. See <see cref="JobHostConfiguration.Tracing"/> for details.
    /// </summary>
    [Obsolete("Will be removed in an upcoming version. Use Microsoft.Extensions.Logging.ILogger instead.")]
    public abstract class TraceWriter
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        /// <param name="level">The <see cref="TraceLevel"/> used to filter trace events.</param>
        protected TraceWriter(TraceLevel level)
        {
            Level = level;
        }

        /// <summary>
        /// Gets or sets the <see cref="TraceLevel"/> filter used to filter trace events.
        /// Only trace events with a <see cref="TraceLevel"/> less than or equal to
        /// this level will be traced.
        /// <remarks>
        /// Level filtering will be done externally by the <see cref="JobHost"/>, so
        /// it shouldn't be done by this class.
        /// </remarks>
        /// </summary>
        public TraceLevel Level { get; set; }

        /// <summary>
        /// Writes a trace event.
        /// </summary>
        /// <param name="traceEvent">The <see cref="TraceEvent"/> to trace.</param>
        public abstract void Trace(TraceEvent traceEvent);

        /// <summary>
        /// Writes a <see cref="TraceLevel.Verbose"/> level trace event.
        /// </summary>
        /// <param name="message">The trace message.</param>
        /// <param name="source">The source of the message.</param>
        public void Verbose(string message, string source = null)
        {
            Trace(new TraceEvent(TraceLevel.Verbose, message, source));
        }

        /// <summary>
        /// Writes a <see cref="TraceLevel.Info"/> level trace event.
        /// </summary>
        /// <param name="message">The trace message.</param>
        /// <param name="source">The source of the message.</param>
        public void Info(string message, string source = null)
        {
            Trace(new TraceEvent(TraceLevel.Info, message, source));
        }

        /// <summary>
        /// Writes a <see cref="TraceLevel.Warning"/> level trace event.
        /// </summary>
        /// <param name="message">The trace message.</param>
        /// <param name="source">The source of the message.</param>
        public void Warning(string message, string source = null)
        {
            Trace(new TraceEvent(TraceLevel.Warning, message, source));
        }

        /// <summary>
        /// Writes a <see cref="TraceLevel.Error"/> level trace event.
        /// </summary>
        /// <param name="message">The trace message.</param>
        /// <param name="ex">The optional <see cref="Exception"/> for the error.</param>
        /// <param name="source">The source of the message.</param>
        public void Error(string message, Exception ex = null, string source = null)
        {
            Trace(new TraceEvent(TraceLevel.Error, message, source, ex));
        }

        /// <summary>
        /// Flush any buffered trace events.
        /// </summary>
        public virtual void Flush()
        {
        }
    }
}

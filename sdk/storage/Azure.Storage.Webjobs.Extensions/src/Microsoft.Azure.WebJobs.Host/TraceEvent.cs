// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;

namespace Microsoft.Azure.WebJobs.Host
{
    /// <summary>
    /// Defines a trace event that can be written to a <see cref="TraceWriter"/>.
    /// </summary>
    [Obsolete("Will be removed in an upcoming version. Use Microsoft.Extensions.Logging.ILogger instead.")]
    public class TraceEvent
    {
        private IDictionary<string, object> _properties;

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        /// <param name="level">The level of the trace.</param>
        /// <param name="message">The trace message.</param>
        /// <param name="source">The source of the trace (may be null).</param>
        /// <param name="exception">The exception that caused the trace (may be null).</param>
        public TraceEvent(TraceLevel level, string message, string source = null, Exception exception = null)
        {
            Level = level;
            Message = message;
            Source = source;
            Exception = exception;
            Timestamp = DateTime.UtcNow;
        }

        /// <summary>
        /// The time the trace was recorded.
        /// </summary>
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// The level of the trace.
        /// </summary>
        public TraceLevel Level { get; set; }

        /// <summary>
        /// The source of the trace.
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        /// The trace message.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// The exception that caused the trace.
        /// </summary>
        public Exception Exception { get; set; }

        /// <summary>
        /// Gets a set of properties for the <see cref="TraceEvent"/>.
        /// </summary>
        public IDictionary<string, object> Properties
        {
            get
            {
                if (_properties == null)
                {
                    _properties = new Dictionary<string, object>();
                }
                return _properties;
            }
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "{0} {1} {2} {3} {4}", Timestamp, Level.ToString(), Message, Source, Exception);
        }
    }
}

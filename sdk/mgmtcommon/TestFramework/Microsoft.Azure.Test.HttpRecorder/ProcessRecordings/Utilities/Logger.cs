#if FullNetFx && NETCOREAPP2_0

namespace Microsoft.Azure.Test.HttpRecorder.ProcessRecordings.Utilities
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Exposes static methods for logging various events (e.g. debug,
    /// informational, warning, etc.). This class cannot be inherited.
    /// </summary>
    /// <remarks>
    /// All methods of the <b>Logger</b> class are static
    /// and can therefore be called without creating an instance of the class.
    /// </remarks>


    public sealed class Logger
    {
        private static TraceSource defaultTraceSource = new TraceSource("defaultTraceSource");

        private Logger() { } // all members are static

        /// <summary>
        /// Flushes all the trace listeners in the trace listener collection.
        /// </summary>

        public static void Flush()
        {
            defaultTraceSource.Flush();
        }

        /// <summary>
        /// Logs an event to the trace listeners using the specified
        /// event type and message.
        /// </summary>
        /// <param name="eventType">One of the System.Diagnostics.TraceEventType
        /// values that specifies the type of event being logged.</param>
        /// <param name="message">The message to log.</param>

        public static void Log(TraceEventType eventType, string message)
        {
#if DEBUG
            // Some debug listeners (e.g. DbgView.exe) don't buffer output, so
            // Debug.Write() is effectively the same as Debug.WriteLine().
            // For optimal appearance in these listeners, format the output
            // for a single call to Debug.WriteLine().
            StringBuilder sb = new StringBuilder();

            sb.Append(eventType.ToString());
            sb.Append(": ");
            sb.Append(message);

            string formattedMessage = sb.ToString();
            Debug.WriteLine(formattedMessage);
#endif
            defaultTraceSource.TraceEvent(eventType, 0, message);
        }

        /// <summary>
        /// Logs a debug event to the trace listeners using the specified
        /// format string and arguments.
        /// </summary>
        /// <param name="provider">An System.IFormatProvider that supplies
        /// culture-specific formatting information.</param>
        /// <param name="format">A composite format string.</param>
        /// <param name="args">An System.Object array containing zero or more
        /// objects to format.</param>

        public static void LogDebug(IFormatProvider provider, string format, params object[] args)
        {
            string message = string.Format(provider, format, args);
            LogDebug(message);
        }

        /// <summary>
        /// Logs a debug event to the trace listeners.
        /// </summary>
        /// <param name="message">The message to log.</param>
        public static void LogDebug(string message)
        {
            Log(TraceEventType.Verbose, message);
        }

        /// <summary>
        /// Logs a critical event to the trace listeners using the specified
        /// format string and arguments.
        /// </summary>
        /// <param name="provider">An System.IFormatProvider that supplies
        /// culture-specific formatting information.</param>
        /// <param name="format">A composite format string.</param>
        /// <param name="args">An System.Object array containing zero or more
        /// objects to format.</param>
        public static void LogCritical(IFormatProvider provider, string format, params object[] args)
        {
            string message = string.Format(provider, format, args);
            LogCritical(message);
        }

        /// <summary>
        /// Logs a critical event to the trace listeners.
        /// </summary>
        /// <param name="message">The message to log.</param>
        public static void LogCritical(string message)
        {
            Log(TraceEventType.Critical, message);
        }

        /// <summary>
        /// Logs an error event to the trace listeners using the specified
        /// format string and arguments.
        /// </summary>
        /// <param name="provider">An System.IFormatProvider that supplies
        /// culture-specific formatting information.</param>
        /// <param name="format">A composite format string.</param>
        /// <param name="args">An System.Object array containing zero or more
        /// objects to format.</param>
        public static void LogError(IFormatProvider provider, string format, params object[] args)
        {
            string message = string.Format(provider, format, args);
            LogError(message);
        }

        /// <summary>
        /// Logs an error event to the trace listeners.
        /// </summary>
        /// <param name="message">The message to log.</param>
        public static void LogError(string message)
        {
            Log(TraceEventType.Error, message);
        }

        /// <summary>
        /// Logs an informational event to the trace listeners using the specified
        /// format string and arguments.
        /// </summary>
        /// <param name="provider">An System.IFormatProvider that supplies
        /// culture-specific formatting information.</param>
        /// <param name="format">A composite format string.</param>
        /// <param name="args">An System.Object array containing zero or more
        /// objects to format.</param>
        public static void LogInfo(IFormatProvider provider, string format, params object[] args)
        {
            string message = string.Format(provider, format, args);
            LogInfo(message);
        }


        /// <summary>
        /// Logs an informational event to the trace listeners.
        /// </summary>
        /// <param name="message">The message to log.</param>
        public static void LogInfo(string message)
        {
            Log(TraceEventType.Information, message);
        }

        /// <summary>
        /// Logs a warning event to the trace listeners using the specified
        /// format string and arguments.
        /// </summary>
        /// <param name="provider">An System.IFormatProvider that supplies
        /// culture-specific formatting information.</param>
        /// <param name="format">A composite format string.</param>
        /// <param name="args">An System.Object array containing zero or more
        /// objects to format.</param>
        public static void LogWarning(IFormatProvider provider, string format, params object[] args)
        {
            string message = string.Format(provider, format, args);
            LogWarning(message);
        }

        /// <summary>
        /// Logs a warning event to the trace listeners.
        /// </summary>
        /// <param name="message">The message to log.</param>
        public static void LogWarning(string message)
        {
            Log(TraceEventType.Warning, message);
        }
    }
}
#endif
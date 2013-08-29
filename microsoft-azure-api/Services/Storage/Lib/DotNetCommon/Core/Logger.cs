//-----------------------------------------------------------------------
// <copyright file="Logger.cs" company="Microsoft">
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
    using Microsoft.WindowsAzure.Storage.Shared.Protocol;
    using System;
    using System.Diagnostics;

    internal static partial class Logger
    {
#if !WINDOWS_PHONE
        private static TraceSource traceSource = new TraceSource(Constants.LogSourceName);
        private static volatile bool isClosed = false;
#endif

#if !WINDOWS_PHONE
        static Logger()
        {
            AppDomain.CurrentDomain.DomainUnload += new EventHandler(Logger.AppDomainUnloadEvent);
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(Logger.ProcessExitEvent);
        }
#endif

#if !WINDOWS_PHONE
        private static void Close()
        {
            Logger.isClosed = true;

            TraceSource source = Logger.traceSource;
            if (source != null)
            {
                Logger.traceSource = null;
                source.Close();
            }
        }

        private static void ProcessExitEvent(object sender, EventArgs e)
        {
            Logger.Close();
        }

        private static void AppDomainUnloadEvent(object sender, EventArgs e)
        {
            Logger.Close();
        }
#endif

        internal static void LogError(OperationContext operationContext, string format, params object[] args)
        {
#if WINDOWS_PHONE
            if (Logger.ShouldLog(LogLevel.Error, operationContext))
            {
                Debug.WriteLine(Logger.FormatLine(operationContext, format, args));
            }
#else
            if (!Logger.isClosed &&
                Logger.traceSource.Switch.ShouldTrace(TraceEventType.Error) &&
                Logger.ShouldLog(LogLevel.Error, operationContext))
            {
                Logger.traceSource.TraceEvent(TraceEventType.Error, 1, Logger.FormatLine(operationContext, format, args));
            }
#endif
        }

        internal static void LogWarning(OperationContext operationContext, string format, params object[] args)
        {
#if WINDOWS_PHONE
            if (Logger.ShouldLog(LogLevel.Warning, operationContext))
            {
                Debug.WriteLine(Logger.FormatLine(operationContext, format, args));
            }
#else
            if (!Logger.isClosed &&
                Logger.traceSource.Switch.ShouldTrace(TraceEventType.Warning) &&
                Logger.ShouldLog(LogLevel.Warning, operationContext))
            {
                Logger.traceSource.TraceEvent(TraceEventType.Warning, 2, Logger.FormatLine(operationContext, format, args));
            }
#endif
        }

        internal static void LogInformational(OperationContext operationContext, string format, params object[] args)
        {
#if WINDOWS_PHONE
            if (Logger.ShouldLog(LogLevel.Informational, operationContext))
            {
                Debug.WriteLine(Logger.FormatLine(operationContext, format, args));
            }
#else
            if (!Logger.isClosed &&
                Logger.traceSource.Switch.ShouldTrace(TraceEventType.Information) &&
                Logger.ShouldLog(LogLevel.Informational, operationContext))
            {
                Logger.traceSource.TraceEvent(TraceEventType.Information, 3, Logger.FormatLine(operationContext, format, args));
            }
#endif
        }

        internal static void LogVerbose(OperationContext operationContext, string format, params object[] args)
        {
#if WINDOWS_PHONE
            if (Logger.ShouldLog(LogLevel.Verbose, operationContext))
            {
                Debug.WriteLine(Logger.FormatLine(operationContext, format, args));
            }
#else
            if (!Logger.isClosed &&
                Logger.traceSource.Switch.ShouldTrace(TraceEventType.Verbose) &&
                Logger.ShouldLog(LogLevel.Verbose, operationContext))
            {
                Logger.traceSource.TraceEvent(TraceEventType.Verbose, 4, Logger.FormatLine(operationContext, format, args));
            }
#endif
        }
    }
}

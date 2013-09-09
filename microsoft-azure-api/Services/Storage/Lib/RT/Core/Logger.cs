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
    using System.Diagnostics.Tracing;

    internal static partial class Logger
    {
        private static StorageEventSource eventSource = new StorageEventSource();

        internal static void LogError(OperationContext operationContext, string format, params object[] args)
        {
            if (Logger.eventSource.IsEnabled() &&
                Logger.ShouldLog(LogLevel.Error, operationContext))
            {
                Logger.eventSource.Error(Logger.FormatLine(operationContext, format, args));
            }
        }

        internal static void LogWarning(OperationContext operationContext, string format, params object[] args)
        {
            if (Logger.eventSource.IsEnabled() &&
                Logger.ShouldLog(LogLevel.Warning, operationContext))
            {
                Logger.eventSource.Warning(Logger.FormatLine(operationContext, format, args));
            }
        }

        internal static void LogInformational(OperationContext operationContext, string format, params object[] args)
        {
            if (Logger.eventSource.IsEnabled() &&
                Logger.ShouldLog(LogLevel.Informational, operationContext))
            {
                Logger.eventSource.Informational(Logger.FormatLine(operationContext, format, args));
            }
        }

        internal static void LogVerbose(OperationContext operationContext, string format, params object[] args)
        {
            if (Logger.eventSource.IsEnabled() &&
                Logger.ShouldLog(LogLevel.Verbose, operationContext))
            {
                Logger.eventSource.Verbose(Logger.FormatLine(operationContext, format, args));
            }
        }
    }
}

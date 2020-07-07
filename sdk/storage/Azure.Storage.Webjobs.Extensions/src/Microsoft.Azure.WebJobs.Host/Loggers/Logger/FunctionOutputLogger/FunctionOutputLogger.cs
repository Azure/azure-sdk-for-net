// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.IO;
using System.Threading;
using Microsoft.Azure.WebJobs.Host.Loggers;
using Microsoft.Extensions.Logging;

namespace Microsoft.Azure.WebJobs.Logging
{
    /// <summary>
    /// A logger explicitly for writing out logs to the <see cref="TextWriter"/> returned from <see cref="IFunctionOutput.Output"/>. This 
    /// is only intended to be used with the Function.{FunctionName}.User logger. Most opertions are no-op otherwise.
    /// </summary>
    internal class FunctionOutputLogger : ILogger
    {
        private static AsyncLocal<IFunctionOutput> _asyncLocalOutput = new AsyncLocal<IFunctionOutput>();

        private bool _isUserFunction = false;

        public FunctionOutputLogger(string categoryName)
        {
            _isUserFunction = LogCategories.IsFunctionUserCategory(categoryName);
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public static void SetOutput(IFunctionOutput output)
        {
            _asyncLocalOutput.Value = output;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return _isUserFunction;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            string formattedMessage = formatter(state, exception);

            if (IsEnabled(logLevel))
            {
                InvokeTextWriter(_asyncLocalOutput.Value?.Output, formattedMessage, exception);
            }
        }

        protected void InvokeTextWriter(TextWriter textWriter, string formattedMessage, Exception exception)
        {
            if (textWriter != null)
            {
                string message = formattedMessage;
                if (!string.IsNullOrEmpty(message) &&
                     message.EndsWith("\r\n", StringComparison.OrdinalIgnoreCase))
                {
                    // remove any terminating return+line feed, since we're
                    // calling WriteLine below
                    message = message.Substring(0, message.Length - 2);
                }

                textWriter.WriteLine(message);
                if (exception != null)
                {
                    textWriter.WriteLine(exception.ToDetails());
                }
            }
        }
    }
}

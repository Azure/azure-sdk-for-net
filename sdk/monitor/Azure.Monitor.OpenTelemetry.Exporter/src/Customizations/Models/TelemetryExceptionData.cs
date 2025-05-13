// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Globalization;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using OpenTelemetry.Logs;

namespace Azure.Monitor.OpenTelemetry.Exporter.Models
{
    internal partial class TelemetryExceptionData
    {
        internal const int MaxExceptionCountToSave = 10;

        public TelemetryExceptionData(int version, LogRecord logRecord, string? message, ChangeTrackingDictionary<string, string> properties) : base(version)
        {
            if (logRecord.Exception == null)
            {
                throw new ArgumentNullException(nameof(logRecord), "logRecord.Exception cannot be null.");
            }

            Properties = properties;
            Measurements = new ChangeTrackingDictionary<string, double>();

#pragma warning disable CS0618 // Type or member is obsolete
            // TODO: Remove warning disable with next Stable release.
            SeverityLevel = LogsHelper.GetSeverityLevel(logRecord.LogLevel);
#pragma warning restore CS0618 // Type or member is obsolete
            ProblemId = LogsHelper.GetProblemId(logRecord.Exception).Truncate(SchemaConstants.ExceptionData_ProblemId_MaxLength);

            // collect the set of exceptions detail info from the passed in exception
            List<TelemetryExceptionDetails> exceptions = new List<TelemetryExceptionDetails>();
            ConvertExceptionTree(logRecord.Exception, message, null, exceptions);

            // trim if we have too many, also add a custom exception to let the user know we're trimmed
            if (exceptions.Count > MaxExceptionCountToSave)
            {
                // create our "message" exception.
                InnerExceptionCountExceededException countExceededException =
                    new InnerExceptionCountExceededException(
                        string.Format(
                            CultureInfo.InvariantCulture,
                            "The number of inner exceptions was {0} which is larger than {1}, the maximum number allowed during transmission. All but the first {1} have been dropped.",
                            exceptions.Count,
                            MaxExceptionCountToSave));

                // remove all but the first N exceptions
                exceptions.RemoveRange(MaxExceptionCountToSave,
                    exceptions.Count - MaxExceptionCountToSave);

                // we'll add our new exception and parent it to the root exception (first one in the list)
                exceptions.Add(new TelemetryExceptionDetails(countExceededException, countExceededException.Message, exceptions[0]));
            }

            Exceptions = exceptions;
        }

        private void ConvertExceptionTree(Exception exception, string? message, TelemetryExceptionDetails? parentExceptionDetails, List<TelemetryExceptionDetails> exceptions)
        {
            // For upper level exception see if message was provided and do not use exception.message in that case
            if (parentExceptionDetails != null && string.IsNullOrWhiteSpace(message))
            {
                message = exception.Message;
            }

            TelemetryExceptionDetails exceptionDetails = new TelemetryExceptionDetails(exception, message, parentExceptionDetails);

            exceptions.Add(exceptionDetails);

            if (exception is AggregateException aggregate)
            {
                foreach (Exception inner in aggregate.InnerExceptions)
                {
                    ConvertExceptionTree(inner, null, exceptionDetails, exceptions);
                }
            }
            else if (exception.InnerException != null)
            {
                ConvertExceptionTree(exception.InnerException, null, exceptionDetails, exceptions);
            }
        }
    }
}

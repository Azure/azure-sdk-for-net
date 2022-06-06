// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Monitor.OpenTelemetry.Exporter.Models
{
    internal partial class TelemetryExceptionDetails
    {
        /// <summary>
        /// Creates a new instance of ExceptionDetails from a System.Exception and a parent ExceptionDetails.
        /// </summary>
        internal TelemetryExceptionDetails(Exception exception, string message, TelemetryExceptionDetails parentExceptionDetails)
        {
            if (exception == null)
            {
                throw new ArgumentNullException(nameof(exception));
            }
            if (message == null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            Message = message.Truncate(SchemaConstants.ExceptionDetails_Message_MaxLength);
            Id = exception.GetHashCode();
            TypeName = exception.GetType().FullName.Truncate(SchemaConstants.ExceptionDetails_TypeName_MaxLength);

            if (parentExceptionDetails != null)
            {
                OuterId = parentExceptionDetails.Id;
            }

            ParsedStack = StackFrame.GetSanitizedStackFrame(exception, out bool hasFullStack);
            HasFullStack = hasFullStack;
        }
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;

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

            this.Message = message.Truncate(SchemaConstants.ExceptionDetails_Message_MaxLength);
            this.Id = exception.GetHashCode();
            this.TypeName = exception.GetType().FullName.Truncate(SchemaConstants.ExceptionDetails_TypeName_MaxLength);

            if (parentExceptionDetails != null)
            {
                this.OuterId = parentExceptionDetails.Id;
            }

            this.ParsedStack = GetSanitizedStackFrame(exception, out bool hasFullStack);
            this.HasFullStack = hasFullStack;
        }

        internal static List<StackFrame> GetSanitizedStackFrame(Exception exception, out bool hasFullStack)
        {
            var orderedStackTrace = new List<StackFrame>();
            hasFullStack = true;

            var stack = new StackTrace(exception, true);
            var frames = stack.GetFrames();
            if (frames != null && frames.Any())
            {
                int totalLength = 0;
                for (int counter = 0; counter < frames.Length; counter++)
                {
                    // 1) Check if we have exceeded MaxFrames.
                    if (orderedStackTrace.Count == SchemaConstants.ExceptionDetails_Stack_MaxFrames)
                    {
                        hasFullStack = false;
                        break;
                    }

                    // 2) Skip middle part of the stack.
                    // This algorithm will select FRAMES from beginning and end of the collection.
                    // Once the LENGTH exceeds max, any remaining FRAMES in the middle of the collection will be ignored.
                    // Example: Assuming frames.Length == 10
                    // counter: 0, 1, 2, 3, 4, 5, 6, 7, 8, 9
                    // index:   9, 0, 8, 1, 7, 2, 6, 3, 5, 4
                    int index = (counter % 2 == 0) ? (frames.Length - 1 - (counter / 2)) : (counter / 2);

                    var convertedStackFrame = new StackFrame(frames[index], index);
                    totalLength += convertedStackFrame.GetStackFrameLength();

                    if (totalLength > SchemaConstants.ExceptionDetails_Stack_MaxLength)
                    {
                        hasFullStack = false;
                        break;
                    }
                    else
                    {
                        // Always insert FRAMES in the middle of the new collection to preserve original order.
                        orderedStackTrace.Insert(orderedStackTrace.Count / 2, convertedStackFrame);
                    }
                }
            }

            return orderedStackTrace;
        }
    }
}

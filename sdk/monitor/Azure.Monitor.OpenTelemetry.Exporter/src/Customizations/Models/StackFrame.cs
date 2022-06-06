// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;

namespace Azure.Monitor.OpenTelemetry.Exporter.Models
{
    internal partial class StackFrame
    {
        /// <summary>
        /// Converts a System.Diagnostics.StackFrame to a Azure.Monitor.OpenTelemetry.Exporter.Models.StackFrame.
        /// </summary>
        public StackFrame(System.Diagnostics.StackFrame stackFrame, int frameId)
        {
            string fullName, assemblyName;

            var methodInfo = stackFrame.GetMethod();
            if (methodInfo == null)
            {
                fullName = "unknown";
                assemblyName = "unknown";
            }
            else
            {
                assemblyName = methodInfo.Module.Assembly.FullName;
                if (methodInfo.DeclaringType != null)
                {
                    fullName = methodInfo.DeclaringType.FullName + "." + methodInfo.Name;
                }
                else
                {
                    fullName = methodInfo.Name;
                }
            }

            // Setters
            this.Method = fullName.Truncate(SchemaConstants.StackFrame_Method_MaxLength);
            this.Level = frameId;
            this.Assembly = assemblyName.Truncate(SchemaConstants.StackFrame_Assembly_MaxLength);
            this.FileName = stackFrame.GetFileName()?.Truncate(SchemaConstants.StackFrame_FileName_MaxLength);

            int line = stackFrame.GetFileLineNumber();
            if (line != 0) // 0 means it is unavailable
            {
                this.Line = line;
            }
        }

        /// <summary>
        /// Gets the stack frame length for only the strings in the stack frame.
        /// </summary>
        internal int GetStackFrameLength() => (this.Method?.Length ?? 0) + (this.Assembly?.Length ?? 0) + (this.FileName?.Length ?? 0);

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
                    // 1) Check that we don't exceeded MaxFrames.
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

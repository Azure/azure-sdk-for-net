// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Azure.Monitor.OpenTelemetry.Exporter.Models
{
    internal partial class TelemetryExceptionDetails
    {
        public const int MaxParsedStackLength = 32768;

        /// <summary>
        /// Creates a new instance of ExceptionDetails from a System.Exception and a parent ExceptionDetails.
        /// </summary>
        internal TelemetryExceptionDetails(Exception exception, string message, TelemetryExceptionDetails parentExceptionDetails) : this(message)
        {
            if (exception == null)
            {
                throw new ArgumentNullException(nameof(exception));
            }

            Id = exception.GetHashCode();
            TypeName = exception.GetType().FullName;

            if (parentExceptionDetails != null)
            {
                OuterId = parentExceptionDetails.Id;
            }

            var stack = new StackTrace(exception, true);

            var frames = stack.GetFrames();
            Tuple<List<StackFrame>, bool> sanitizedTuple = SanitizeStackFrame(frames, GetStackFrame, GetStackFrameLength);
            ParsedStack = sanitizedTuple.Item1;
            HasFullStack = sanitizedTuple.Item2;
        }

        /// <summary>
        /// Converts a System.Diagnostics.StackFrame to a Microsoft.ApplicationInsights.Extensibility.Implementation.TelemetryTypes.StackFrame.
        /// </summary>
        internal static StackFrame GetStackFrame(System.Diagnostics.StackFrame stackFrame, int frameId)
        {
            var methodInfo = stackFrame.GetMethod();
            string fullName;
            string assemblyName;

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

            var convertedStackFrame = new StackFrame(frameId, fullName);

            convertedStackFrame.Assembly = assemblyName;
            convertedStackFrame.FileName = stackFrame.GetFileName();

            // 0 means it is unavailable
            int line = stackFrame.GetFileLineNumber();
            if (line != 0)
            {
                convertedStackFrame.Line = line;
            }

            return convertedStackFrame;
        }

        /// <summary>
        /// Gets the stack frame length for only the strings in the stack frame.
        /// </summary>
        internal static int GetStackFrameLength(StackFrame stackFrame)
        {
            var stackFrameLength = (stackFrame.Method == null ? 0 : stackFrame.Method.Length)
                                   + (stackFrame.Assembly == null ? 0 : stackFrame.Assembly.Length)
                                   + (stackFrame.FileName == null ? 0 : stackFrame.FileName.Length);
            return stackFrameLength;
        }

        /// <summary>
        /// Sanitizing stack to 32k while selecting the initial and end stack trace.
        /// </summary>
        private static Tuple<List<TOutput>, bool> SanitizeStackFrame<TInput, TOutput>(
            IList<TInput> inputList,
            Func<TInput, int, TOutput> converter,
            Func<TOutput, int> lengthGetter)
        {
            List<TOutput> orderedStackTrace = new List<TOutput>();
            bool hasFullStack = true;
            if (inputList != null && inputList.Count > 0)
            {
                int currentParsedStackLength = 0;
                for (int level = 0; level < inputList.Count; level++)
                {
                    // Skip middle part of the stack
                    int current = (level % 2 == 0) ? (inputList.Count - 1 - (level / 2)) : (level / 2);

                    TOutput convertedStackFrame = converter(inputList[current], current);
                    currentParsedStackLength += lengthGetter(convertedStackFrame);

                    if (currentParsedStackLength > MaxParsedStackLength)
                    {
                        hasFullStack = false;
                        break;
                    }

                    orderedStackTrace.Insert(orderedStackTrace.Count / 2, convertedStackFrame);
                }
            }

            return new Tuple<List<TOutput>, bool>(orderedStackTrace, hasFullStack);
        }
    }
}

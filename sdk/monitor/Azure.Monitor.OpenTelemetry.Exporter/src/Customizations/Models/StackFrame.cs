// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Monitor.OpenTelemetry.Exporter.Internals;

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

            var methodInfo = stackFrame.GetMethodWithoutWarning();
            if (methodInfo == null)
            {
                // In an AOT scenario GetMethod() will return null. Note this can happen even in non AOT scenarios.
                // Instead, call ToString() which gives a string like this:
                // "MethodName + 0x00 at offset 000 in file:line:column <filename unknown>:0:0"
                fullName = stackFrame.ToString();
                assemblyName = "unknown";
            }
            else
            {
                assemblyName = methodInfo.Module.Assembly.FullName ?? "unknown";
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
    }
}

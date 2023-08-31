// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;

namespace Azure.Monitor.OpenTelemetry.Exporter.Models
{
    internal partial class StackFrame
    {
        /// <summary>
        /// Converts a System.Diagnostics.StackFrame to a Azure.Monitor.OpenTelemetry.Exporter.Models.StackFrame.
        /// </summary>
        [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "TODO...")]
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
            // TODO: IF WE'RE UNABLE TO GET fullname or AssemblyName, we should fall back to stackFrame.ToString().
            // ToString gives a string like this: "System.ThrowHelper.ThrowArgumentNullException(ExceptionArgument) + 0x31 at offset 49 in file:line:column <filename unknown>:0:0"
            // We can split on the '+' to get the methodName.
            // In an AOT scenario, assemblyName will be unavailable.

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

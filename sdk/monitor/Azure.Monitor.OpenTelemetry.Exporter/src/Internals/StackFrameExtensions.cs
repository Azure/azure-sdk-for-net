// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals
{
    internal static class StackFrameExtensions
    {
        /// <summary>
        /// Wrapper for <see cref="System.Diagnostics.StackFrame.GetMethod"/>.
        /// This method disables the Trimmer warning "IL2026:RequiresUnreferencedCode".
        /// Callers MUST handle the null condition.
        /// </summary>
        /// <remarks>
        /// In an AOT scenario GetMethod() will return null. Note this can happen even in non AOT scenarios.
        /// Instead, call ToString() which gives a string like this:
        /// "MethodName + 0x00 at offset 000 in file:line:column filename unknown:0:0".
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "We will handle the null condition and call ToString() instead.")]
        public static MethodBase? GetMethodWithoutWarning(this System.Diagnostics.StackFrame stackFrame) => stackFrame.GetMethod();
    }
}

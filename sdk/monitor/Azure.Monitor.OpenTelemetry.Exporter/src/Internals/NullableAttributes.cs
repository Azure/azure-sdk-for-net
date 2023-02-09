// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// The following code was borrowed from https://github.com/dotnet/runtime/blob/main/src/libraries/System.Private.CoreLib/src/System/Diagnostics/CodeAnalysis/NullableAttributes.cs
// These classes are available in .NET versions after NetStandard2.0
// For more information see: https://learn.microsoft.com/dotnet/csharp/language-reference/attributes/nullable-analysis

#if NETSTANDARD2_0

namespace System.Diagnostics.CodeAnalysis
{
#pragma warning disable SA1649 // File name should match first type name

    /// <summary>
    /// Specifies that when a method returns <see cref="ReturnValue"/>, the parameter will not be null even if the corresponding type allows it.
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter, Inherited = false)]
    internal sealed class NotNullWhenAttribute : Attribute
    {
        /// <summary>Initializes the attribute with the specified return value condition.</summary>
        /// <param name="returnValue">
        /// The return value condition. If the method returns this value, the associated parameter will not be null.
        /// </param>
        public NotNullWhenAttribute(bool returnValue) => ReturnValue = returnValue;

        /// <summary>Gets the return value condition.</summary>
        public bool ReturnValue { get; }
    }

#pragma warning restore SA1649 // File name should match first type name
}
#endif

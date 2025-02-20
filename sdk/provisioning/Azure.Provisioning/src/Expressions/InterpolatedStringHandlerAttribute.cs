// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.Runtime.CompilerServices;

#if !NET6_0_OR_GREATER
/// <summary>Indicates the attributed type is to be used as an interpolated string handler.</summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = false, Inherited = false)]
internal sealed class InterpolatedStringHandlerAttribute : Attribute { }
#endif

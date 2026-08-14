// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#if !NET5_0_OR_GREATER

namespace System.Runtime.Versioning
{
    /// <summary>
    /// Polyfill for <see cref="UnsupportedOSPlatformAttribute"/> which is only available in .NET 5+.
    /// Marks APIs that are unsupported on a given platform.
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Constructor | AttributeTargets.Enum | AttributeTargets.Event | AttributeTargets.Field | AttributeTargets.Interface | AttributeTargets.Method | AttributeTargets.Module | AttributeTargets.Property | AttributeTargets.Struct, AllowMultiple = true, Inherited = false)]
    internal sealed class UnsupportedOSPlatformAttribute : Attribute
    {
        public UnsupportedOSPlatformAttribute(string platformName)
        {
            PlatformName = platformName;
        }

        public string PlatformName { get; }
    }
}

#endif

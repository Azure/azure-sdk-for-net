// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

#if StorageSDK
namespace Azure.Storage.Shared
#else
namespace Azure.Core
#endif
{
    /// <summary>
    /// Marks methods that call methods on other client and don't need their diagnostics verified
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    internal class ForwardsClientCallsAttribute : Attribute
    {
    }
}

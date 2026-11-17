// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Reflection;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Proxies.Support
{
    internal static class ProxyOptionsInspector
    {
        // Working copies share the lookup index built from the caller's Proxies collection.
        internal static object? GetProxyIndex(ModelReaderWriterOptions passedInOptions)
        {
            return typeof(ModelReaderWriterOptions).GetField("_index", BindingFlags.NonPublic | BindingFlags.Instance)!.GetValue(passedInOptions);
        }
    }
}

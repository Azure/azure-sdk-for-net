// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Reflection;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Proxies.Support
{
    internal static class ProxyOptionsInspector
    {
        internal static object? GetProxies(ModelReaderWriterOptions passedInOptions)
        {
            return typeof(ModelReaderWriterOptions).GetField("_proxies", BindingFlags.NonPublic | BindingFlags.Instance)!.GetValue(passedInOptions);
        }
    }
}

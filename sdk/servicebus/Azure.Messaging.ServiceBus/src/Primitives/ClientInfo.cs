// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Reflection;
using System.Runtime.Versioning;

namespace Azure.Messaging.ServiceBus.Primitives
{
    internal static class ClientInfo
    {
        internal static Assembly assembly = GetAssesmbly();
        internal static readonly string Product = GetAssemblyAttributeValue<AssemblyProductAttribute>(assembly, p => p.Product);
        internal static readonly string Version = GetAssemblyAttributeValue<AssemblyFileVersionAttribute>(assembly, v => v.Version);
        internal static readonly string Framework = GetAssemblyAttributeValue<TargetFrameworkAttribute>(assembly, f => f.FrameworkName);

        internal static readonly string Platform = GetPlatform();

        internal static string GetPlatform()
        {
            try
            {
#if NETSTANDARD2_0
                return System.Runtime.InteropServices.RuntimeInformation.OSDescription;
#elif UAP10_0
                return "UAP";
#elif NET461
                return Environment.OSVersion.VersionString;
#else
                return "Unknown";
#endif
            }
            catch
            {
                // ignored
                return null;
            }
        }

        internal static Assembly GetAssesmbly()
        {
            return typeof(ClientInfo).GetTypeInfo().Assembly;
        }

        internal static string GetAssemblyAttributeValue<T>(Assembly assembly, Func<T, string> getter) where T : Attribute
        {
            return !(assembly.GetCustomAttribute(typeof(T)) is T attribute) ? null : getter(attribute);
        }
    }
}

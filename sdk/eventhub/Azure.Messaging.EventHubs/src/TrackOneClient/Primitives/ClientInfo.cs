// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Reflection;
using System.Runtime.Versioning;
using Microsoft.Azure.Amqp;

namespace TrackOne
{
    internal static class ClientInfo
    {
        private static readonly string s_product;
        private static readonly string s_version;
        private static readonly string s_framework;
        private static readonly string s_platform;

        static ClientInfo()
        {
            try
            {
                Assembly assembly = typeof(ClientInfo).GetTypeInfo().Assembly;
                s_product = GetAssemblyAttributeValue<AssemblyProductAttribute>(assembly, p => p.Product);
                s_version = GetAssemblyAttributeValue<AssemblyFileVersionAttribute>(assembly, v => v.Version);
                s_framework = GetAssemblyAttributeValue<TargetFrameworkAttribute>(assembly, f => f.FrameworkName);
#if FullNetFx
                platform = Environment.OSVersion.VersionString;
#else
                s_platform = System.Runtime.InteropServices.RuntimeInformation.OSDescription;
#endif
            }
            catch { }
        }

        public static void Add(AmqpConnectionSettings settings)
        {
            settings.AddProperty("product", s_product);
            settings.AddProperty("version", s_version);
            settings.AddProperty("framework", s_framework);
            settings.AddProperty("platform", s_platform);
        }

        private static string GetAssemblyAttributeValue<T>(Assembly assembly, Func<T, string> getter) where T : Attribute
        {
            return !(assembly.GetCustomAttribute(typeof(T)) is T attribute) ? null : getter(attribute);
        }
    }
}

// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.Azure.EventHubs
{
    using System;
    using System.Reflection;
    using System.Runtime.Versioning;
    using Microsoft.Azure.Amqp;

    static class ClientInfo
    {
        static readonly string product;
        static readonly string version;
        static readonly string framework;
        static readonly string platform;

        static ClientInfo()
        {
            try
            {
                Assembly assembly = typeof(ClientInfo).GetTypeInfo().Assembly;
                product = GetAssemblyAttributeValue<AssemblyProductAttribute>(assembly, p => p.Product);
                version = GetAssemblyAttributeValue<AssemblyFileVersionAttribute>(assembly, v => v.Version);
                framework = GetAssemblyAttributeValue<TargetFrameworkAttribute>(assembly, f => f.FrameworkName);
#if NETSTANDARD2_0
                platform = System.Runtime.InteropServices.RuntimeInformation.OSDescription;
#elif UAP10_0
                platform = "UAP";
#elif NET461
                platform = Environment.OSVersion.VersionString;
#elif IOS
                platform = "IOS";
#endif
            }
            catch { }
        }

        public static void Add(AmqpConnectionSettings settings)
        {
            settings.AddProperty("product", product);
            settings.AddProperty("version", version);
            settings.AddProperty("framework", framework);
            settings.AddProperty("platform", platform);
        }

        static string GetAssemblyAttributeValue<T>(Assembly assembly, Func<T, string> getter) where T : Attribute
        {
            var attribute = assembly.GetCustomAttribute(typeof(T)) as T;
            return attribute == null ? null : getter(attribute);
        }
    }
}

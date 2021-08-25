// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Azure.Core
{
    internal static class HttpHeaderUtilities
    {
        public static string GetUserAgentValue(Assembly assembly, string? applicationId)
        {
            const string PackagePrefix = "Azure.";

            AssemblyInformationalVersionAttribute? versionAttribute = assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>();
            if (versionAttribute == null)
            {
                throw new InvalidOperationException($"{nameof(AssemblyInformationalVersionAttribute)} is required on client SDK assembly '{assembly.FullName}'.");
            }

            string version = versionAttribute.InformationalVersion;

            string assemblyName = assembly.GetName().Name!;
            if (assemblyName.StartsWith(PackagePrefix, StringComparison.Ordinal))
            {
                assemblyName = assemblyName.Substring(PackagePrefix.Length);
            }

            int hashSeparator = version.IndexOf("+", StringComparison.Ordinal);
            if (hashSeparator != -1)
            {
                version = version.Substring(0, hashSeparator);
            }

            var platformInformation = $"({RuntimeInformation.FrameworkDescription}; {RuntimeInformation.OSDescription})";
            return $"{(applicationId == null ? "" : applicationId + " ")}azsdk-net-{assemblyName}/{version} {platformInformation}";
        }

        public static void SetUserAgentHeader(RequestHeaders headers, object source)
        {
            var assembly = source.GetType().Assembly;
            headers.SetValue(HttpHeader.Names.UserAgent, GetUserAgentValue(assembly, null));
        }
    }
}

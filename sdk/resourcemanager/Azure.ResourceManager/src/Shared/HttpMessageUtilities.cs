// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Reflection;
using System.Runtime.InteropServices;
using Azure.Core;

namespace Azure.ResourceManager.Core
{
    internal static class HttpMessageUtilities
    {
        internal static readonly string PlatformInformation = $"({RuntimeInformation.FrameworkDescription}; {RuntimeInformation.OSDescription})";

        private static string GetUserAgentName(string componentName, string componentVersion, string? applicationId)
        {
            string result;
            if (applicationId != null)
            {
                result = $"{applicationId} azsdk-net-{componentName}/{componentVersion} {PlatformInformation}";
            }
            else
            {
                result = $"azsdk-net-{componentName}/{componentVersion} {PlatformInformation}";
            }
            return result;
        }

        internal static string GetUserAgentName(object source, ClientOptions options)
        {
            const string PackagePrefix = "Azure.";

            Assembly assembly = source.GetType().Assembly!;

            AssemblyInformationalVersionAttribute? versionAttribute = assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>();
            if (versionAttribute == null)
            {
                throw new InvalidOperationException($"{nameof(AssemblyInformationalVersionAttribute)} is required on client SDK assembly '{assembly.FullName}' (inferred from the use of options type '{options.GetType().FullName}').");
            }

            string version = versionAttribute.InformationalVersion;

            string assemblyName = assembly.GetName().Name!;
            if (assemblyName.StartsWith(PackagePrefix, StringComparison.Ordinal))
            {
                assemblyName = assemblyName.Substring(PackagePrefix.Length);
            }

            int hashSeparator = version.IndexOfOrdinal('+');
            if (hashSeparator != -1)
            {
                version = version.Substring(0, hashSeparator);
            }

            return GetUserAgentName(assemblyName, version, options.Diagnostics.ApplicationId);
        }

        private static int IndexOfOrdinal(this string s, char c)
        {
#if NET5_0_OR_GREATER
            return s.IndexOf(c, StringComparison.Ordinal);
#else
            return s.IndexOf(c);
#endif
        }
    }
}

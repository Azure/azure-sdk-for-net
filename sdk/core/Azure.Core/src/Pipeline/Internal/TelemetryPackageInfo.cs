// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Azure.Core.Pipeline
{
    /// <summary>
    /// Information about the package to be included in UserAgent telemetry
    /// </summary>
    public class TelemetryPackageInfo
    {
        /// <summary>
        ///
        /// </summary>
        public string UserAgentValue { get; }

        internal TelemetryPackageInfo(Assembly assembly, string? applicationId = null)
        {
            UserAgentValue = GenerateUserAgentString(assembly, applicationId);
        }

        /// <summary>
        /// Creates an instance of a <see cref="TelemetryPackageInfo"/> based on the Type provided.
        /// </summary>
        /// <param name="applicationId"></param>
        /// <typeparam name="T">The type contained by the Assembly used to generate package name and version information.</typeparam>
        /// <returns></returns>
        public static TelemetryPackageInfo Create<T>(string? applicationId = null)
        {
            var assembly = Assembly.GetAssembly(typeof(T));
            return new TelemetryPackageInfo(assembly!, applicationId);
        }

        internal static string GenerateUserAgentString(Assembly clientAssembly, string? applicationId = null)
        {
            const string PackagePrefix = "Azure.";

            AssemblyInformationalVersionAttribute? versionAttribute = clientAssembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>();
            if (versionAttribute == null)
            {
                throw new InvalidOperationException(
                    $"{nameof(AssemblyInformationalVersionAttribute)} is required on client SDK assembly '{clientAssembly.FullName}'.");
            }

            string version = versionAttribute.InformationalVersion;

            string assemblyName = clientAssembly.GetName().Name!;
            if (assemblyName.StartsWith(PackagePrefix, StringComparison.Ordinal))
            {
                assemblyName = assemblyName.Substring(PackagePrefix.Length);
            }

            int hashSeparator = version.IndexOfOrdinal('+');
            if (hashSeparator != -1)
            {
                version = version.Substring(0, hashSeparator);
            }
            var platformInformation = $"({RuntimeInformation.FrameworkDescription}; {RuntimeInformation.OSDescription})";

            return applicationId != null
                ? $"{applicationId} azsdk-net-{assemblyName}/{version} {platformInformation}"
                : $"azsdk-net-{assemblyName}/{version} {platformInformation}";
        }
    }
}

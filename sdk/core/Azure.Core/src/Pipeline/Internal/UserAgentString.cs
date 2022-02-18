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
    public class UserAgentString
    {
        private string _userAgent;

        /// <summary>
        /// Initialize an instance of <see cref="UserAgentString"/>.
        /// </summary>
        /// <param name="assembly">The <see cref="Assembly"/> used to generate the package name and version information for the <see cref="UserAgentString"/> value.</param>
        /// <param name="applicationId">An optional applicationId to be prepended to the <see cref="UserAgentString"/> value. This value behaves exactly like the <see cref="DiagnosticsOptions.ApplicationId"/> property.</param>
        public UserAgentString(Assembly assembly, string? applicationId = null)
        {
            _userAgent = GenerateUserAgentString(assembly, applicationId);
        }

        /// <summary>
        /// Creates an instance of a <see cref="UserAgentString"/> based on the Type provided.
        /// </summary>
        /// <param name="applicationId"></param>
        /// <typeparam name="T">The type contained by the Assembly used to generate package name and version information.</typeparam>
        /// <returns></returns>
        public static UserAgentString FromType<T>(string? applicationId = null)
        {
            var assembly = Assembly.GetAssembly(typeof(T));
            return new UserAgentString(assembly!, applicationId);
        }

        /// <summary>
        /// Returns a formatted UserAgent string
        /// </summary>
        public override string ToString() => _userAgent;

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

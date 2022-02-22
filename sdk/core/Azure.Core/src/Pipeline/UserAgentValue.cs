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
    public class UserAgentValue
    {
        private string _userAgent;

        /// <summary>
        /// Initialize an instance of <see cref="UserAgentValue"/> by extracting the name and version information from the <see cref="Assembly"/> associated with the <paramref name="type"/>.
        /// </summary>
        /// <param name="type">The <see cref="Type"/> used to generate the package name and version information for the <see cref="UserAgentValue"/> value.</param>
        /// <param name="applicationId">An optional value to be prepended to the <see cref="UserAgentValue"/>.
        /// This value overrides the behavior of the <see cref="DiagnosticsOptions.ApplicationId"/> property for the <see cref="HttpMessage"/> it is applied to.</param>
        public UserAgentValue(Type type, string? applicationId = null)
        {
            var assembly = Assembly.GetAssembly(type);
            if (assembly == null) throw new ArgumentException($"The type parameter {type.FullName} does not have a valid Assembly");
            _userAgent = GenerateUserAgentString(assembly, applicationId);
        }

        /// <summary>
        /// Creates an instance of a <see cref="UserAgentValue"/> based on the Type provided.
        /// </summary>
        /// <param name="applicationId"></param>
        /// <typeparam name="T">The type contained by the Assembly used to generate package name and version information.</typeparam>
        /// <returns></returns>
        public static UserAgentValue FromType<T>(string? applicationId = null)
        {
            return new UserAgentValue(typeof(T), applicationId);
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

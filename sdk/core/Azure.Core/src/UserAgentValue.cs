// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Reflection;
using System.Runtime.InteropServices;
using Azure.Core.Pipeline;

namespace Azure.Core
{
    /// <summary>
    /// Information about the package to be included in UserAgent telemetry
    /// </summary>
    public class UserAgentValue
    {
        private string _userAgent;

        /// <summary>
        /// The package type represented by this <see cref="UserAgentValue"/> instance.
        /// </summary>
        public Type PackageType { get; }

        /// <summary>
        /// The value of the applicationId used to initialize this <see cref="UserAgentValue"/> instance.
        /// </summary>
        public string? ApplicationId { get; }

        /// <summary>
        /// Initialize an instance of <see cref="UserAgentValue"/> by extracting the name and version information from the <see cref="Assembly"/> associated with the <paramref name="packageType"/>.
        /// </summary>
        /// <param name="packageType">The <see cref="Type"/> used to generate the package name and version information for the <see cref="UserAgentValue"/> value.</param>
        /// <param name="applicationId">An optional value to be prepended to the <see cref="UserAgentValue"/>.
        /// This value overrides the behavior of the <see cref="DiagnosticsOptions.ApplicationId"/> property for the <see cref="HttpMessage"/> it is applied to.</param>
        public UserAgentValue(Type packageType, string? applicationId = null)
        {
            PackageType = packageType;
            ApplicationId = applicationId;
            var assembly = Assembly.GetAssembly(packageType);
            if (assembly == null) throw new ArgumentException($"The type parameter {packageType.FullName} does not have a valid Assembly");
            _userAgent = GenerateUserAgentString(assembly, applicationId);
        }

        /// <summary>
        /// Returns a formatted UserAgent string
        /// </summary>
        public override string ToString() => _userAgent;

        /// <summary>
        /// Sets the package name and version portion of the UserAgent telemetry value for the context of the <paramref name="message"/>
        /// Note: If <see cref="DiagnosticsOptions.IsTelemetryEnabled"/> is false, this value is never used.
        /// </summary>
        /// <param name="message">The <see cref="HttpMessage"/> that will use this <see cref="UserAgentValue"/>.</param>
        public void ApplyToMessage(HttpMessage message)
        {
            message.SetInternalProperty(typeof(UserAgentValueKey), ToString());
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

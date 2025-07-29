// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Reflection;
using Azure.Core.Pipeline;
using System.ClientModel.Primitives;

namespace Azure.Core
{
    /// <summary>
    /// Details about the package to be included in UserAgent telemetry
    /// </summary>
    public class TelemetryDetails
    {
        private const int MaxApplicationIdLength = 24;
        private readonly string _userAgent;

        /// <summary>
        /// The package type represented by this <see cref="TelemetryDetails"/> instance.
        /// </summary>
        public Assembly Assembly { get; }

        /// <summary>
        /// The value of the applicationId used to initialize this <see cref="TelemetryDetails"/> instance.
        /// </summary>
        public string? ApplicationId { get; }

        /// <summary>
        /// Initialize an instance of <see cref="TelemetryDetails"/> by extracting the name and version information from the <see cref="System.Reflection.Assembly"/> associated with the <paramref name="assembly"/>.
        /// </summary>
        /// <param name="assembly">The <see cref="System.Reflection.Assembly"/> used to generate the package name and version information for the <see cref="TelemetryDetails"/> value.</param>
        /// <param name="applicationId">An optional value to be prepended to the <see cref="TelemetryDetails"/>.
        /// This value overrides the behavior of the <see cref="DiagnosticsOptions.ApplicationId"/> property for the <see cref="HttpMessage"/> it is applied to.</param>
        public TelemetryDetails(Assembly assembly, string? applicationId = null)
        {
            Argument.AssertNotNull(assembly, nameof(assembly));
            if (applicationId?.Length > MaxApplicationIdLength)
            {
                throw new ArgumentOutOfRangeException(nameof(applicationId), $"{nameof(applicationId)} must be shorter than {MaxApplicationIdLength + 1} characters");
            }

            Assembly = assembly;
            ApplicationId = applicationId;
            _userAgent = GenerateUserAgentString(assembly, applicationId);
        }

        /// <summary>
        /// Sets the package name and version portion of the UserAgent telemetry value for the context of the <paramref name="message"/>
        /// Note: If <see cref="DiagnosticsOptions.IsTelemetryEnabled"/> is false, this value is never used.
        /// </summary>
        /// <param name="message">The <see cref="HttpMessage"/> that will use this <see cref="TelemetryDetails"/>.</param>
        public void Apply(HttpMessage message)
        {
            message.SetProperty(typeof(UserAgentValueKey), ToString());
        }

        internal static string GenerateUserAgentString(Assembly clientAssembly, string? applicationId = null)
        {
            // Always use System.ClientModel's UserAgentPolicy.GenerateUserAgentString and apply Azure SDK specific transformations
            string userAgentString = UserAgentPolicy.GenerateUserAgentString(clientAssembly, applicationId);
            return ApplyAzureSdkTransformations(userAgentString, clientAssembly);
        }

        private static string ApplyAzureSdkTransformations(string userAgentString, Assembly clientAssembly)
        {
            // Transform the assembly name from System.ClientModel format to Azure SDK format
            string assemblyName = clientAssembly.GetName().Name!;
            string azureSdkAssemblyName = TransformToAzureSdkAssemblyName(assemblyName);

            // Replace the assembly name in the user agent string
            return userAgentString.Replace($"{assemblyName}/", $"{azureSdkAssemblyName}/");
        }

        private static string TransformToAzureSdkAssemblyName(string assemblyName)
        {
            // Azure SDK specific: Convert assembly name to azsdk-net- format
            const string PackagePrefix = "Azure.";
            if (assemblyName.StartsWith(PackagePrefix, StringComparison.Ordinal))
            {
                assemblyName = assemblyName.Substring(PackagePrefix.Length);
            }
            return $"azsdk-net-{assemblyName}";
        }

        /// <summary>
        /// The properly formatted UserAgent string based on this <see cref="TelemetryDetails"/> instance.
        /// </summary>
        public override string ToString() => _userAgent;
    }
}

// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using Azure.Core.Pipeline;

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
            : this(assembly, applicationId, new RuntimeInformationWrapper())
        { }

        internal TelemetryDetails(Assembly assembly, string? applicationId = null, RuntimeInformationWrapper? runtimeInformation = default)
        {
            Argument.AssertNotNull(assembly, nameof(assembly));
            if (applicationId?.Length > MaxApplicationIdLength)
            {
                throw new ArgumentOutOfRangeException(nameof(applicationId), $"{nameof(applicationId)} must be shorter than {MaxApplicationIdLength + 1} characters");
            }

            Assembly = assembly;
            ApplicationId = applicationId;
            _userAgent = GenerateUserAgentString(assembly, applicationId, runtimeInformation);
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

        internal static string GenerateUserAgentString(Assembly clientAssembly, string? applicationId = null, RuntimeInformationWrapper? runtimeInformation = default)
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
            runtimeInformation ??= new RuntimeInformationWrapper();
            var platformInformation = $"({runtimeInformation.FrameworkDescription}; {runtimeInformation.OSDescription})";

            return applicationId != null
                ? $"{applicationId} azsdk-net-{assemblyName}/{version} {platformInformation}"
                : $"azsdk-net-{assemblyName}/{version} {platformInformation}";
        }

        /// <summary>
        /// The properly formatted UserAgent string based on this <see cref="TelemetryDetails"/> instance.
        /// </summary>
        public override string ToString() => _userAgent;

        private static string EnsureProperParenthesisMatching(string userAgent)
        {
            var stack = new Stack<char>();
            bool needsFix = false;
            StringBuilder? fixedUserAgent = null;
            for (int i = 0; i < userAgent.Length; i++)
            {
                switch (userAgent[i])
                {
                    case '(':
                        stack.Push('(');
                        if (needsFix)
                        {
                            // Since we're fixing the string, we need to copy the current char
                            fixedUserAgent!.Append('(');
                        }
                        break;
                    case ')':
                        if (stack.Count == 0 || stack.Pop() != '(')
                        {
                            if (!needsFix)
                            {
                                needsFix = true;
                                // We need to fix the string, so we need to copy it into a StringBuilder, excluding the invalid closing parenthesis
                                fixedUserAgent = new(userAgent.Length);
                                fixedUserAgent.Append(userAgent, 0, i - 1);
                            }
                        }
                        else if (needsFix)
                        {
                            // Since we're fixing the string, we need to copy the current char
                            fixedUserAgent!.Append(')');
                        }
                        break;
                    default:
                        if (needsFix)
                        {
                            // Since we're fixing the string, we need to copy the current char
                            fixedUserAgent!.Append(userAgent[i]);
                        }
                        break;
                }
            }
            if (stack.Count > 0)
            {
                if (!needsFix)
                {
                    // We need to fix the string, so we need to copy it into a StringBuilder, excluding the invalid closing parenthesis
                    fixedUserAgent = new(userAgent.Length + stack.Count);
                    fixedUserAgent.Append(userAgent);
                }
                while (stack.Count > 0)
                {
                    var paren = stack.Pop();
                    if (paren == '(')
                    {
                        fixedUserAgent!.Append(')');
                    }
                    else
                    {
                        fixedUserAgent!.Append('(');
                    }
                }
            }
            return needsFix ? fixedUserAgent!.ToString() : userAgent;
        }
    }
}

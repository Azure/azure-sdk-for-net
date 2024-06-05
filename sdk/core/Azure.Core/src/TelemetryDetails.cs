// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
using System.Net.Http.Headers;
using System.Reflection;
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

            // RFC 9110 section 5.5 https://www.rfc-editor.org/rfc/rfc9110.txt#section-5.5 does not require any specific encoding : "Fields needing a greater range of characters
            // can use an encoding, such as the one defined in RFC8187." RFC8187 is targeted at parameter values, almost always filename, so using url encoding here instead, which is
            // more widely used. Since user-agent does not usually contain non-ascii, only encode when necessary.
            // This was added to support operating systems with non-ascii characters in their release names.
            string osDescription;
#if NET8_0_OR_GREATER
            osDescription = Ascii.IsValid(runtimeInformation.OSDescription) ? runtimeInformation.OSDescription : WebUtility.UrlEncode(runtimeInformation.OSDescription);
#else
            osDescription = ContainsNonAscii(runtimeInformation.OSDescription) ? WebUtility.UrlEncode(runtimeInformation.OSDescription) : runtimeInformation.OSDescription;
#endif

            var platformInformation = EscapeProductInformation($"({runtimeInformation.FrameworkDescription}; {osDescription})");

            return applicationId != null
                ? $"{applicationId} azsdk-net-{assemblyName}/{version} {platformInformation}"
                : $"azsdk-net-{assemblyName}/{version} {platformInformation}";
        }

        /// <summary>
        /// The properly formatted UserAgent string based on this <see cref="TelemetryDetails"/> instance.
        /// </summary>
        public override string ToString() => _userAgent;

        /// <summary>
        /// If the ProductInformation is not in the proper format, this escapes any ')' , '(' or '\' characters per https://www.rfc-editor.org/rfc/rfc7230#section-3.2.6
        /// </summary>
        /// <param name="productInfo">The ProductInfo portion of the UserAgent</param>
        /// <returns></returns>
        private static string EscapeProductInformation(string productInfo)
        {
            // If the string is already valid, we don't need to escape anything
            bool success = false;
            try
            {
                success = ProductInfoHeaderValue.TryParse(productInfo, out var _);
            }
            catch (Exception)
            {
                // Invalid values can throw in Framework due to https://github.com/dotnet/runtime/issues/28558
                // Treat this as a failure to parse.
            }
            if (success)
            {
                return productInfo;
            }

            var sb = new StringBuilder(productInfo.Length + 2);
            sb.Append('(');
            // exclude the first and last characters, which are the enclosing parentheses
            for (int i = 1; i < productInfo.Length - 1; i++)
            {
                char c = productInfo[i];
                if (c == ')' || c == '(')
                {
                    sb.Append('\\');
                }
                // If we see a \, we don't need to escape it if it's followed by a '\', '(', or ')', because it is already escaped.
                else if (c == '\\')
                {
                    if (i + 1 < (productInfo.Length - 1))
                    {
                        char next = productInfo[i + 1];
                        if (next == '\\' || next == '(' || next == ')')
                        {
                            sb.Append(c);
                            sb.Append(next);
                            i++;
                            continue;
                        }
                        else
                        {
                            sb.Append('\\');
                        }
                    }
                    else
                    {
                        sb.Append('\\');
                    }
                }
                sb.Append(c);
            }
            sb.Append(')');
            return sb.ToString();
        }

        private static bool ContainsNonAscii(string value)
        {
            foreach (char c in value)
            {
                if ((int)c > 0x7f)
                {
                    return true;
                }
            }
            return false;
        }
    }
}

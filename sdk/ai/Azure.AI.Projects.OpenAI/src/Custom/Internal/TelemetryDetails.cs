// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net;
using System.Net.Http.Headers;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

#nullable enable

namespace Azure.AI.Projects.OpenAI;

/// <summary>
/// Details about the package to be included in UserAgent telemetry
/// </summary>
internal class TelemetryDetails
{
    private const int MaxApplicationIdLength = 99;

    /// <summary>
    /// The package type represented by this <see cref="TelemetryDetails"/> instance.
    /// </summary>
    public Assembly Assembly { get; }

    public RuntimeInformationWrapper Runtime { get; }

    private UserAgentInfo? _cachedUserAgentInfo = null;
    public UserAgentInfo UserAgent => _cachedUserAgentInfo ??= GetUserAgentInfo();

    private readonly string? _userAgentApplicationId;

    internal TelemetryDetails(Assembly assembly, string? applicationId = null)
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
        Runtime = runtimeInformation ?? new();
        _userAgentApplicationId = applicationId;
    }

    private UserAgentInfo GetUserAgentInfo()
    {
        string assemblyName = Assembly.GetName().Name!;

        AssemblyInformationalVersionAttribute? versionAttribute
            = Assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()
                ?? throw new InvalidOperationException(
                    $"{nameof(AssemblyInformationalVersionAttribute)} is required on client SDK assembly '{Assembly.FullName}'.");

        int hashSeparatorPosition = versionAttribute.InformationalVersion.LastIndexOf('+');
        string version = hashSeparatorPosition == -1
            ? versionAttribute.InformationalVersion
            : versionAttribute.InformationalVersion.Substring(0, hashSeparatorPosition);

    // RFC 9110 section 5.5 https://www.rfc-editor.org/rfc/rfc9110.txt#section-5.5 does not require any specific encoding : "Fields needing a greater range of characters
    // can use an encoding, such as the one defined in RFC8187." RFC8187 is targeted at parameter values, almost always filename, so using url encoding here instead, which is
    // more widely used. Since user-agent does not usually contain non-ascii, only encode when necessary.
    // This was added to support operating systems with non-ascii characters in their release names.
#if NET8_0_OR_GREATER
        string osDescription = Ascii.IsValid(Runtime.OSDescription) ? Runtime.OSDescription : WebUtility.UrlEncode(Runtime.OSDescription);
#else
        static bool ContainsNonAscii(string value)
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
        string osDescription = ContainsNonAscii(Runtime.OSDescription) ? WebUtility.UrlEncode(Runtime.OSDescription) : Runtime.OSDescription;
#endif

        string platform = EscapeProductInformation($"({Runtime.FrameworkDescription}; {osDescription})");

        return new UserAgentInfo(assemblyName, version, platform, _userAgentApplicationId);
    }

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

    public class UserAgentInfo
    {
        public string? ApplicationId { get; }

        public string AssemblyName { get; }

        public string Version { get; }

        public string Platform { get; }

        private string? _cachedValueFull = null;
        private string? _cachedValueNoPlatform = null;

        public UserAgentInfo(string assemblyName, string version, string platform, string? applicationId = null)
        {
            AssemblyName = assemblyName;
            Version = version;
            Platform = platform;
            ApplicationId = applicationId;
        }

        public string ToString(bool includePlatformInformation)
        {
            if (includePlatformInformation)
            {
                return _cachedValueFull ??= $"{ApplicationId}{(ApplicationId?.Length > 0 == true ? " " : "")}{AssemblyName}/{Version} {Platform}";
            }
            else
            {
                return _cachedValueNoPlatform ??= $"{ApplicationId}{(ApplicationId?.Length > 0 == true ? " " : "")}{AssemblyName}/{Version}";
            }
        }

        public override string ToString() => ToString(includePlatformInformation: true);
    }

    internal class RuntimeInformationWrapper
    {
        public virtual string FrameworkDescription => RuntimeInformation.FrameworkDescription;
        public virtual string OSDescription => RuntimeInformation.OSDescription;
        public virtual Architecture OSArchitecture => RuntimeInformation.OSArchitecture;
        public virtual Architecture ProcessArchitecture => RuntimeInformation.ProcessArchitecture;
        public virtual bool IsOSPlatform(OSPlatform osPlatform) => RuntimeInformation.IsOSPlatform(osPlatform);
    }
}

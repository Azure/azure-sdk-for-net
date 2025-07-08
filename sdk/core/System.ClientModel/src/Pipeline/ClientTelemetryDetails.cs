// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.Net;
using System.Net.Http.Headers;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace System.ClientModel.Primitives;

/// <summary>
/// Details about the client package to be included in user agent telemetry.
/// </summary>
public class ClientTelemetryDetails
{
    private const int MaxApplicationIdLength = 24;
    private readonly string _userAgent;

    /// <summary>
    /// The package type represented by this <see cref="ClientTelemetryDetails"/> instance.
    /// </summary>
    public Assembly Assembly { get; }

    /// <summary>
    /// The value of the applicationId used to initialize this <see cref="ClientTelemetryDetails"/> instance.
    /// </summary>
    public string? ApplicationId { get; }

    /// <summary>
    /// Initialize an instance of <see cref="ClientTelemetryDetails"/> by extracting the name and version information from the <see cref="System.Reflection.Assembly"/> associated with the <paramref name="assembly"/>.
    /// </summary>
    /// <param name="assembly">The <see cref="System.Reflection.Assembly"/> used to generate the package name and version information for the <see cref="ClientTelemetryDetails"/> value.</param>
    /// <param name="applicationId">An optional value to be prepended to the <see cref="ClientTelemetryDetails"/>.</param>
    public ClientTelemetryDetails(Assembly assembly, string? applicationId = null)
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
    /// Sets the package name and version portion of the user agent telemetry value for the context of the <paramref name="message"/>.
    /// </summary>
    /// <param name="message">The <see cref="PipelineMessage"/> that will use this <see cref="ClientTelemetryDetails"/>.</param>
    public void Apply(PipelineMessage message)
    {
        message.SetProperty(typeof(UserAgentValueKey), ToString());
    }

    internal static string GenerateUserAgentString(Assembly clientAssembly, string? applicationId = null)
    {
        AssemblyInformationalVersionAttribute? versionAttribute = clientAssembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>();
        if (versionAttribute == null)
        {
            throw new InvalidOperationException(
                $"{nameof(AssemblyInformationalVersionAttribute)} is required on client SDK assembly '{clientAssembly.FullName}'.");
        }

        string version = versionAttribute.InformationalVersion;

        string assemblyName = clientAssembly.GetName().Name!;

        int hashSeparator = version.IndexOf('+');
        if (hashSeparator != -1)
        {
            version = version.Substring(0, hashSeparator);
        }

        // RFC 9110 section 5.5 https://www.rfc-editor.org/rfc/rfc9110.txt#section-5.5 does not require any specific encoding : "Fields needing a greater range of characters
        // can use an encoding, such as the one defined in RFC8187." RFC8187 is targeted at parameter values, almost always filename, so using url encoding here instead, which is
        // more widely used. Since user-agent does not usually contain non-ascii, only encode when necessary.
        // This was added to support operating systems with non-ascii characters in their release names.
        string osDescription;
#if NET8_0_OR_GREATER
        osDescription = System.Text.Ascii.IsValid(RuntimeInformation.OSDescription) ? RuntimeInformation.OSDescription : WebUtility.UrlEncode(RuntimeInformation.OSDescription);
#else
        osDescription = ContainsNonAscii(RuntimeInformation.OSDescription) ? WebUtility.UrlEncode(RuntimeInformation.OSDescription) : RuntimeInformation.OSDescription;
#endif

        var platformInformation = EscapeProductInformation($"({RuntimeInformation.FrameworkDescription}; {osDescription})");

        return applicationId != null
            ? $"{applicationId} {assemblyName}/{version} {platformInformation}"
            : $"{assemblyName}/{version} {platformInformation}";
    }

    /// <summary>
    /// The properly formatted user agent string based on this <see cref="ClientTelemetryDetails"/> instance.
    /// </summary>
    public override string ToString() => _userAgent;

    /// <summary>
    /// If the ProductInformation is not in the proper format, this escapes any ')' , '(' or '\' characters per https://www.rfc-editor.org/rfc/rfc7230#section-3.2.6
    /// </summary>
    /// <param name="productInfo">The ProductInfo portion of the user agent</param>
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
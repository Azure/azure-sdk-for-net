// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;
using System.Net;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;

namespace System.ClientModel.Primitives;

/// <summary>
/// A pipeline policy that adds user agent headers to HTTP requests.
/// </summary>
public class UserAgentPolicy : PipelinePolicy
{
    private const int MaxApplicationIdLength = 24;
    private readonly string _userAgent;

    /// <summary>
    /// The package type represented by this <see cref="UserAgentPolicy"/> instance.
    /// </summary>
    public Assembly Assembly { get; }

    /// <summary>
    /// The value of the applicationId used to initialize this <see cref="UserAgentPolicy"/> instance.
    /// </summary>
    public string? ApplicationId { get; }

    /// <summary>
    /// The formatted user agent string that will be added to HTTP requests by this policy.
    /// </summary>
    public string UserAgentValue => _userAgent;

    /// <summary>
    /// Initialize an instance of <see cref="UserAgentPolicy"/> by extracting the name and version information from the <see cref="System.Reflection.Assembly"/> associated with the <paramref name="callerAssembly"/>.
    /// </summary>
    /// <param name="callerAssembly">The <see cref="System.Reflection.Assembly"/> used to generate the package name and version information for the user agent.</param>
    /// <param name="applicationId">An optional value to be prepended to the user agent string.</param>
    public UserAgentPolicy(Assembly callerAssembly, string? applicationId = null)
    {
        Argument.AssertNotNull(callerAssembly, nameof(callerAssembly));
        if (applicationId?.Length > MaxApplicationIdLength)
        {
            throw new ArgumentOutOfRangeException(nameof(applicationId), $"{nameof(applicationId)} must be shorter than {MaxApplicationIdLength + 1} characters");
        }

        Assembly = callerAssembly;
        ApplicationId = applicationId;
        _userAgent = GenerateUserAgentString(callerAssembly, applicationId, new RuntimeInformationWrapper());
    }

    /// <summary>
    /// Process the pipeline message synchronously.
    /// </summary>
    /// <param name="message">The pipeline message to process.</param>
    /// <param name="pipeline">The remaining pipeline policies.</param>
    /// <param name="currentIndex">The current index in the pipeline.</param>
    public override void Process(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
    {
        AddUserAgentHeader(message);
        ProcessNext(message, pipeline, currentIndex);
    }

    /// <summary>
    /// Process the pipeline message asynchronously.
    /// </summary>
    /// <param name="message">The pipeline message to process.</param>
    /// <param name="pipeline">The remaining pipeline policies.</param>
    /// <param name="currentIndex">The current index in the pipeline.</param>
    /// <returns>A ValueTask representing the asynchronous operation.</returns>
    public override async ValueTask ProcessAsync(PipelineMessage message, IReadOnlyList<PipelinePolicy> pipeline, int currentIndex)
    {
        AddUserAgentHeader(message);
        await ProcessNextAsync(message, pipeline, currentIndex).ConfigureAwait(false);
    }

    private void AddUserAgentHeader(PipelineMessage message)
    {
        message.Request.Headers.Add("User-Agent", _userAgent);
    }

    /// <summary>
    /// Generates a user agent string from the provided assembly and optional application ID using custom runtime information.
    /// This method is intended for testing scenarios that need to mock runtime information.
    /// </summary>
    /// <param name="callerAssembly">The caller assembly to extract name and version information from.</param>
    /// <param name="applicationId">An optional application ID to prepend to the user agent string.</param>
    /// <param name="runtimeInformation">Custom runtime information for testing scenarios.</param>
    /// <returns>A formatted user agent string.</returns>
    internal static string GenerateUserAgentString(Assembly callerAssembly, string? applicationId, RuntimeInformationWrapper runtimeInformation)
    {
        AssemblyInformationalVersionAttribute? versionAttribute = callerAssembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>();
        if (versionAttribute == null)
        {
            throw new InvalidOperationException(
                $"{nameof(AssemblyInformationalVersionAttribute)} is required on client SDK assembly '{callerAssembly.FullName}'.");
        }

        string version = versionAttribute.InformationalVersion;

        string assemblyName = callerAssembly.GetName().Name!;

        int hashSeparator = version.IndexOf('+');
        if (hashSeparator != -1)
        {
            version = version.Substring(0, hashSeparator);
        }

        // RFC 9110 section 5.5 https://www.rfc-editor.org/rfc/rfc9110.txt#section-5.5 does not require any specific encoding : "Fields needing a greater range of characters
        // can use an encoding, such as the one defined in RFC8187." RFC8187 is targeted at parameter values, almost always filename, so using url encoding here instead, which is
        // more widely used. Since user-agent does not usually contain non-ascii, only encode when necessary.
        // This was added to support operating systems with non-ascii characters in their release names.
        string osDescription = runtimeInformation.OSDescription;
#if NET8_0_OR_GREATER
        osDescription = System.Text.Ascii.IsValid(osDescription) ? osDescription : WebUtility.UrlEncode(osDescription);
#else
        osDescription = ContainsNonAscii(osDescription) ? WebUtility.UrlEncode(osDescription) : osDescription;
#endif

        var platformInformation = EscapeProductInformation($"({runtimeInformation.FrameworkDescription}; {osDescription})");

        return applicationId != null
            ? $"{applicationId} {assemblyName}/{version} {platformInformation}"
            : $"{assemblyName}/{version} {platformInformation}";
    }

    /// <summary>
    /// If the ProductInformation is not in the proper format, this escapes any ')' , '(' or '\' characters per https://www.rfc-editor.org/rfc/rfc7230#section-3.2.6
    /// </summary>
    /// <param name="productInfo">The ProductInfo portion of the user agent</param>
    /// <returns>The escaped product information string.</returns>
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

    /// <summary>
    /// Checks if a string contains any non-ASCII characters.
    /// </summary>
    /// <param name="value">The string to check.</param>
    /// <returns>True if the string contains non-ASCII characters, false otherwise.</returns>
    private static bool ContainsNonAscii(string value)
    {
#if NET8_0_OR_GREATER
        return !System.Text.Ascii.IsValid(value);
#else
        foreach (char c in value)
        {
            if ((int)c > 0x7f)
            {
                return true;
            }
        }
        return false;
#endif
    }
}

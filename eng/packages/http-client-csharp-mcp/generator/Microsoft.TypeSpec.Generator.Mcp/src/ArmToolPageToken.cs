// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System;
using System.Text;

namespace Microsoft.TypeSpec.Generator.Mcp;

internal static class ArmToolPageToken
{
    internal static string? Resume(string? token, string operation, string scope, Uri endpoint)
    {
        if (token is null)
        {
            return null;
        }
        if (token.Length > 32_768)
        {
            throw new ArgumentException("The continuation token is too large.", nameof(token));
        }
        string decoded;
        try
        {
            decoded = new UTF8Encoding(false, true).GetString(Convert.FromBase64String(token));
        }
        catch (Exception exception) when (exception is FormatException or DecoderFallbackException)
        {
            throw new ArgumentException("Invalid continuation token.", nameof(token), exception);
        }
        var prefix = Prefix(operation, scope, endpoint);
        if (!decoded.StartsWith(prefix, StringComparison.Ordinal))
        {
            throw new ArgumentException("The continuation token belongs to a different operation or scope.", nameof(token));
        }
        return new Uri(endpoint, ValidatePath(decoded[prefix.Length..], scope)).AbsoluteUri;
    }

    internal static string? Wrap(string? token, string operation, string scope, Uri endpoint)
    {
        if (token is null)
        {
            return null;
        }
        var path = token;
        if (Uri.TryCreate(token, UriKind.Absolute, out var absolute))
        {
            if (absolute.Scheme != endpoint.Scheme || absolute.Authority != endpoint.Authority || absolute.UserInfo.Length != 0)
            {
                throw new ArgumentException("The SDK continuation link is outside the configured ARM endpoint.", nameof(token));
            }
            path = absolute.PathAndQuery;
        }
        return Convert.ToBase64String(Encoding.UTF8.GetBytes(Prefix(operation, scope, endpoint) + ValidatePath(path, scope)));
    }

    private static string Prefix(string operation, string scope, Uri endpoint) =>
        operation + "\n" + scope + "\n" + endpoint.GetLeftPart(UriPartial.Authority) + "\n";

    private static string ValidatePath(string path, string scope)
    {
        if (!path.StartsWith("/", StringComparison.Ordinal) || path.StartsWith("//", StringComparison.Ordinal) ||
            path.Contains('\\') || !Uri.TryCreate("https://arm.invalid" + path, UriKind.Absolute, out var uri) ||
            uri.Fragment.Length != 0 || !Uri.UnescapeDataString(uri.AbsolutePath).Equals(Uri.UnescapeDataString(scope), StringComparison.OrdinalIgnoreCase))
        {
            throw new ArgumentException("The continuation token is not a same-scope ARM page.", nameof(path));
        }
        return uri.PathAndQuery;
    }
}

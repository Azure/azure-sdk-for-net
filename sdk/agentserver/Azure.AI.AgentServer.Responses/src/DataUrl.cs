// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.AI.AgentServer.Responses;

/// <summary>
/// Utility methods for working with base64 data URLs
/// (e.g., <c>data:image/png;base64,iVBOR...</c> or <c>data:text/plain;base64,SGVs...</c>).
/// <para>
/// Data URLs follow the format <c>data:[&lt;mediatype&gt;][;base64],&lt;data&gt;</c>.
/// These utilities help handlers extract the raw bytes and media type from
/// <see cref="Models.MessageContentInputImageContent.ImageUrl"/> and
/// <see cref="Models.MessageContentInputFileContent.FileData"/> values.
/// </para>
/// </summary>
public static class DataUrl
{
    private const string DataScheme = "data";
    private const string Base64Marker = ";base64";

    /// <summary>
    /// Determines whether the specified <see cref="Uri"/> is a base64 data URL.
    /// </summary>
    /// <param name="uri">The URI to check.</param>
    /// <returns><c>true</c> if <paramref name="uri"/> uses the <c>data:</c> scheme; otherwise, <c>false</c>.</returns>
    public static bool IsDataUrl(Uri? uri)
        => uri is not null && string.Equals(uri.Scheme, DataScheme, StringComparison.OrdinalIgnoreCase);

    /// <summary>
    /// Determines whether the specified string is a base64 data URL.
    /// </summary>
    /// <param name="value">The string to check.</param>
    /// <returns><c>true</c> if <paramref name="value"/> starts with <c>data:</c>; otherwise, <c>false</c>.</returns>
    public static bool IsDataUrl(string? value)
        => value is not null && value.StartsWith("data:", StringComparison.OrdinalIgnoreCase);

    /// <summary>
    /// Decodes the base64 payload from a data URL <see cref="Uri"/>.
    /// </summary>
    /// <param name="uri">A data URL (e.g., <c>data:image/png;base64,iVBOR...</c>).</param>
    /// <returns>The decoded bytes.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="uri"/> is <c>null</c>.</exception>
    /// <exception cref="FormatException">
    /// The URI is not a data URL or does not contain a valid base64 payload.
    /// </exception>
    public static byte[] DecodeBytes(Uri uri)
    {
        ArgumentNullException.ThrowIfNull(uri);
        return DecodeBytesCore(uri.OriginalString);
    }

    /// <summary>
    /// Decodes the base64 payload from a data URL string.
    /// </summary>
    /// <param name="dataUrl">A data URL string (e.g., <c>data:text/plain;base64,SGVs...</c>).</param>
    /// <returns>The decoded bytes.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="dataUrl"/> is <c>null</c>.</exception>
    /// <exception cref="FormatException">
    /// The string is not a data URL or does not contain a valid base64 payload.
    /// </exception>
    public static byte[] DecodeBytes(string dataUrl)
    {
        ArgumentNullException.ThrowIfNull(dataUrl);
        return DecodeBytesCore(dataUrl);
    }

    /// <summary>
    /// Attempts to decode the base64 payload from a data URL <see cref="Uri"/>.
    /// </summary>
    /// <param name="uri">A data URL, or <c>null</c>.</param>
    /// <param name="bytes">When this method returns <c>true</c>, contains the decoded bytes.</param>
    /// <returns><c>true</c> if decoding succeeded; otherwise, <c>false</c>.</returns>
    public static bool TryDecodeBytes(Uri? uri, out byte[] bytes)
    {
        bytes = Array.Empty<byte>();
        if (uri is null)
            return false;
        return TryDecodeBytesCore(uri.OriginalString, out bytes);
    }

    /// <summary>
    /// Attempts to decode the base64 payload from a data URL string.
    /// </summary>
    /// <param name="dataUrl">A data URL string, or <c>null</c>.</param>
    /// <param name="bytes">When this method returns <c>true</c>, contains the decoded bytes.</param>
    /// <returns><c>true</c> if decoding succeeded; otherwise, <c>false</c>.</returns>
    public static bool TryDecodeBytes(string? dataUrl, out byte[] bytes)
    {
        bytes = Array.Empty<byte>();
        if (dataUrl is null)
            return false;
        return TryDecodeBytesCore(dataUrl, out bytes);
    }

    /// <summary>
    /// Extracts the media type from a data URL <see cref="Uri"/>
    /// (e.g., returns <c>"image/png"</c> from <c>data:image/png;base64,...</c>).
    /// </summary>
    /// <param name="uri">A data URL.</param>
    /// <returns>The media type string, or <c>null</c> if the URI is not a data URL or has no media type.</returns>
    public static string? GetMediaType(Uri? uri)
        => uri is not null ? GetMediaTypeCore(uri.OriginalString) : null;

    /// <summary>
    /// Extracts the media type from a data URL string
    /// (e.g., returns <c>"text/plain"</c> from <c>data:text/plain;base64,...</c>).
    /// </summary>
    /// <param name="dataUrl">A data URL string.</param>
    /// <returns>The media type string, or <c>null</c> if the string is not a data URL or has no media type.</returns>
    public static string? GetMediaType(string? dataUrl)
        => dataUrl is not null ? GetMediaTypeCore(dataUrl) : null;

    // ─── Internal helpers ────────────────────────────────────────────

    private static byte[] DecodeBytesCore(string value)
    {
        int commaIndex = value.IndexOf(',');
        if (commaIndex < 0 || !value.StartsWith("data:", StringComparison.OrdinalIgnoreCase))
            throw new FormatException("Invalid data URL: expected format 'data:[<mediatype>][;base64],<data>'.");

        string header = value[..commaIndex];
        if (header.IndexOf(Base64Marker, StringComparison.OrdinalIgnoreCase) < 0)
            throw new FormatException("Data URL does not contain the ';base64' marker. Only base64-encoded data URLs are supported.");

        string base64Part = value[(commaIndex + 1)..];
        return Convert.FromBase64String(base64Part);
    }

    private static bool TryDecodeBytesCore(string value, out byte[] bytes)
    {
        bytes = Array.Empty<byte>();

        int commaIndex = value.IndexOf(',');
        if (commaIndex < 0 || !value.StartsWith("data:", StringComparison.OrdinalIgnoreCase))
            return false;

        string header = value[..commaIndex];
        if (header.IndexOf(Base64Marker, StringComparison.OrdinalIgnoreCase) < 0)
            return false;

        string base64Part = value[(commaIndex + 1)..];
        try
        {
            bytes = Convert.FromBase64String(base64Part);
            return true;
        }
        catch (FormatException)
        {
            return false;
        }
    }

    private static string? GetMediaTypeCore(string value)
    {
        if (!value.StartsWith("data:", StringComparison.OrdinalIgnoreCase))
            return null;

        // Format: data:<mediatype>;base64,<data> or data:<mediatype>,<data>
        int afterScheme = 5; // length of "data:"
        int commaIndex = value.IndexOf(',', afterScheme);
        if (commaIndex < 0)
            return null;

        string header = value[afterScheme..commaIndex];

        // Remove ";base64" suffix if present
        int base64Pos = header.IndexOf(Base64Marker, StringComparison.OrdinalIgnoreCase);
        string mediaType = base64Pos >= 0 ? header[..base64Pos] : header;

        return mediaType.Length > 0 ? mediaType : null;
    }
}

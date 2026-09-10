// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Buffers;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace System.ClientModel.Primitives;

/// <summary>
/// Computes a stable cache key for a credential section by canonically
/// serializing the merged content (sorted leaf paths) and hashing it.
/// </summary>
internal static class CredentialSectionHasher
{
    private const int CharStackThreshold = 256;

    private static readonly LeafPathComparer s_leafComparer = new();

    public static string ComputeKey(IConfigurationSection section)
    {
        if (section is null)
        {
            return string.Empty;
        }

        // Most credential sections are small (TenantId, ClientId, ClientSecret,
        // Authority, etc.); pre-size to avoid backing-array resize for the
        // common case. Larger sections still grow normally.
        var leaves = new List<KeyValuePair<string, string?>>(capacity: 8);
        Collect(section, string.Empty, leaves);
        leaves.Sort(s_leafComparer);

#if NET8_0_OR_GREATER
        return ComputeKeyFast(leaves);
#else
        return ComputeKeyFallback(leaves);
#endif
    }

#if NET8_0_OR_GREATER
    private static string ComputeKeyFast(List<KeyValuePair<string, string?>> leaves)
    {
        // Compute an upper bound on the canonical byte stream size so we
        // can allocate one buffer up front and write into it directly,
        // hashing once at the end. This avoids the per-leaf overhead of
        // multiple IncrementalHash.AppendData calls.
        //
        // Per-leaf upper bound:
        //   <keyLen digits, max 10>  ':'  <UTF-8 max bytes for key>
        //   '='
        //   <valLen digits, max 10>  ':'  <UTF-8 max bytes for value>
        //   ';'
        const int PerLeafFixed = 10 + 1 + 1 + 10 + 1 + 1; // separators + length-digit slack
        int upper = 0;
        foreach (KeyValuePair<string, string?> e in leaves)
        {
            int keyMax = e.Key.Length == 0 ? 0 : Encoding.UTF8.GetMaxByteCount(e.Key.Length);
            int valMax = (e.Value?.Length ?? 0) == 0 ? 0 : Encoding.UTF8.GetMaxByteCount(e.Value!.Length);
            upper += PerLeafFixed + keyMax + valMax;
        }

        byte[] rented = ArrayPool<byte>.Shared.Rent(Math.Max(upper, 1));
        try
        {
            Span<byte> buf = rented;
            int pos = 0;

            foreach (KeyValuePair<string, string?> e in leaves)
            {
                // Length-prefix both key and value so that no value content can
                // be confused with the structural separators '=' or ';'. This
                // prevents cache-key collisions for values containing those
                // bytes (e.g., connection-string-like secrets such as "b;c=d").
                //
                // IConfiguration treats keys case-insensitively, so we
                // normalize keys to lower-invariant before hashing — two
                // configurations that differ only in the casing of their keys
                // must produce the same cache key. Values are NOT normalized;
                // they are case-sensitive (tokens, secrets, IDs).
                pos += WriteLengthPrefixed(buf.Slice(pos), e.Key, lowerInvariant: true);
                buf[pos++] = (byte)'=';
                pos += WriteLengthPrefixed(buf.Slice(pos), e.Value ?? string.Empty, lowerInvariant: false);
                buf[pos++] = (byte)';';
            }

            Span<byte> hash = stackalloc byte[32];
            SHA256.HashData(buf.Slice(0, pos), hash);
            return Convert.ToBase64String(hash);
        }
        finally
        {
            ArrayPool<byte>.Shared.Return(rented);
        }
    }

    private static int WriteLengthPrefixed(Span<byte> dest, string text, bool lowerInvariant)
    {
        // Lower-case (or pass through) into a stack/pool char buffer so we
        // never allocate a transient lowered string.
        char[]? rentedChars = lowerInvariant && text.Length > CharStackThreshold
            ? ArrayPool<char>.Shared.Rent(text.Length)
            : null;
        try
        {
            scoped Span<char> charBuf = rentedChars is not null
                ? rentedChars.AsSpan(0, text.Length)
                : stackalloc char[lowerInvariant ? text.Length : 0];

            scoped ReadOnlySpan<char> chars;
            if (lowerInvariant)
            {
                int n = text.AsSpan().ToLowerInvariant(charBuf);
                chars = charBuf.Slice(0, n);
            }
            else
            {
                chars = text.AsSpan();
            }

            int written = 0;

            // <length>:
            if (!chars.Length.TryFormat(dest, out int intLen, default, CultureInfo.InvariantCulture))
            {
                ThrowFormatFailed();
            }
            written += intLen;
            dest[written++] = (byte)':';

            // <utf8 bytes>
            if (chars.Length > 0)
            {
                if (!Encoding.UTF8.TryGetBytes(chars, dest.Slice(written), out int byteLen))
                {
                    ThrowEncodingFailed();
                }
                written += byteLen;
            }

            return written;
        }
        finally
        {
            if (rentedChars is not null)
            {
                ArrayPool<char>.Shared.Return(rentedChars);
            }
        }
    }

    private static void ThrowFormatFailed()
        => throw new InvalidOperationException("Failed to format integer length prefix.");

    private static void ThrowEncodingFailed()
        => throw new InvalidOperationException("Failed to encode UTF-8 bytes for credential section hash.");
#else
    // Pre-net8 fallback: assemble the canonical form via StringBuilder and
    // hash the resulting byte[] in one shot. Equivalent to the original
    // implementation; produces an identical byte stream so the golden hashes
    // match across TFMs.
    private static string ComputeKeyFallback(List<KeyValuePair<string, string?>> leaves)
    {
        var sb = new StringBuilder();
        foreach (KeyValuePair<string, string?> entry in leaves)
        {
            string key = entry.Key.ToLowerInvariant();
            string value = entry.Value ?? string.Empty;
            sb.Append(key.Length).Append(':').Append(key)
              .Append('=')
              .Append(value.Length).Append(':').Append(value)
              .Append(';');
        }

        byte[] bytes = Encoding.UTF8.GetBytes(sb.ToString());
        using var sha = SHA256.Create();
        byte[] hash = sha.ComputeHash(bytes);
        return Convert.ToBase64String(hash);
    }
#endif

    private static void Collect(IConfigurationSection section, string relativePath, List<KeyValuePair<string, string?>> target)
    {
        string? value = section.Value;
        if (value is not null)
        {
            target.Add(new KeyValuePair<string, string?>(relativePath, value));
        }

        foreach (IConfigurationSection child in section.GetChildren())
        {
            string childPath = relativePath.Length == 0 ? child.Key : relativePath + ":" + child.Key;
            Collect(child, childPath, target);
        }
    }

    private sealed class LeafPathComparer : IComparer<KeyValuePair<string, string?>>
    {
        public int Compare(KeyValuePair<string, string?> x, KeyValuePair<string, string?> y)
            => string.Compare(x.Key, y.Key, StringComparison.OrdinalIgnoreCase);
    }
}

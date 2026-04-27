// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
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
    public static string ComputeKey(IConfigurationSection section)
    {
        if (section is null)
        {
            return string.Empty;
        }

        var leaves = new SortedDictionary<string, string?>(StringComparer.OrdinalIgnoreCase);
        Collect(section, string.Empty, leaves);

        var sb = new StringBuilder();
        foreach (KeyValuePair<string, string?> entry in leaves)
        {
            sb.Append(entry.Key).Append('=').Append(entry.Value ?? string.Empty).Append(';');
        }

        byte[] bytes = Encoding.UTF8.GetBytes(sb.ToString());
#if NET8_0_OR_GREATER
        byte[] hash = SHA256.HashData(bytes);
#else
        using var sha = SHA256.Create();
        byte[] hash = sha.ComputeHash(bytes);
#endif
        return Convert.ToBase64String(hash);
    }

    private static void Collect(IConfigurationSection section, string relativePath, SortedDictionary<string, string?> target)
    {
        string? value = section.Value;
        if (value is not null)
        {
            target[relativePath] = value;
        }

        foreach (IConfigurationSection child in section.GetChildren())
        {
            string childPath = relativePath.Length == 0 ? child.Key : relativePath + ":" + child.Key;
            Collect(child, childPath, target);
        }
    }
}

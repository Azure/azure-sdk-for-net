// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System.Buffers;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.Configuration;

namespace System.ClientModel.Tests.Internal.Perf;

[MemoryDiagnoser]
public class CredentialSectionHasherBenchmarks
{
    private IConfigurationSection _small = null!;
    private IConfigurationSection _typical = null!;
    private IConfigurationSection _nested = null!;
    private IConfigurationSection _largeValue = null!;

    [GlobalSetup]
    public void Setup()
    {
        _small = Build(new Dictionary<string, string?> { ["Cred:Token"] = "abc" });
        _typical = Build(new Dictionary<string, string?>
        {
            ["Cred:TenantId"] = "11111111-2222-3333-4444-555555555555",
            ["Cred:ClientId"] = "aaaaaaaa-bbbb-cccc-dddd-eeeeeeeeeeee",
            ["Cred:ClientSecret"] = "s3cretValue~ABCDEFGHIJKLMNOPQRSTUV",
            ["Cred:Authority"] = "https://login.microsoftonline.com/",
        });
        _nested = Build(new Dictionary<string, string?>
        {
            ["Cred:TenantId"] = "tid",
            ["Cred:ClientId"] = "cid",
            ["Cred:Inner:A"] = "1",
            ["Cred:Inner:B"] = "2",
            ["Cred:Inner:Deep:X"] = "x",
            ["Cred:Inner:Deep:Y"] = "y",
        });
        _largeValue = Build(new Dictionary<string, string?>
        {
            ["Cred:Blob"] = new string('a', 1024),
        });
    }

    private static IConfigurationSection Build(IDictionary<string, string?> data)
    {
        var cfg = new ConfigurationBuilder().AddInMemoryCollection(data).Build();
        return cfg.GetSection("Cred");
    }

    // ---- New (current impl) ----

    [Benchmark]
    public string New_Small() => System.ClientModel.Primitives.CredentialSectionHasher.ComputeKey(_small);

    [Benchmark]
    public string Old_Small() => OldImpl.ComputeKey(_small);

    [Benchmark]
    public string New_Typical() => System.ClientModel.Primitives.CredentialSectionHasher.ComputeKey(_typical);

    [Benchmark]
    public string Old_Typical() => OldImpl.ComputeKey(_typical);

    [Benchmark]
    public string New_Nested() => System.ClientModel.Primitives.CredentialSectionHasher.ComputeKey(_nested);

    [Benchmark]
    public string Old_Nested() => OldImpl.ComputeKey(_nested);

    [Benchmark]
    public string New_LargeValue() => System.ClientModel.Primitives.CredentialSectionHasher.ComputeKey(_largeValue);

    [Benchmark]
    public string Old_LargeValue() => OldImpl.ComputeKey(_largeValue);

    // ---- Old implementation (verbatim from commit 89c7101be3a) ----
    private static class OldImpl
    {
        public static string ComputeKey(IConfigurationSection section)
        {
            if (section is null) return string.Empty;

            var leaves = new SortedDictionary<string, string?>(StringComparer.OrdinalIgnoreCase);
            Collect(section, string.Empty, leaves);

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
}

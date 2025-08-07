// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using BenchmarkDotNet.Attributes;

namespace Azure.Core.Perf;

[MemoryDiagnoser]
public class HttpMessageSanitizerBenchmark
{
    private HttpMessageSanitizer _sanitizer;

    [GlobalSetup]
    public void Setup()
    {
        _sanitizer = new HttpMessageSanitizer(
            allowedQueryParameters: new[] { "api-version" },
            allowedHeaders: Array.Empty<string>()
            );
    }

    [Benchmark]
    public string SanitizeHeader()
    {
        return _sanitizer.SanitizeHeader("header", "value");
    }

    [Benchmark]
    public string SanitizeUrl()
    {
        return _sanitizer.SanitizeUrl("https://www.example.com");
    }

    [Benchmark]
    public string SanitizeUrlWithQueryNoValue()
    {
        return _sanitizer.SanitizeUrl("https://www.example.com?param1");
    }

    [Benchmark]
    public string SanitizeUrlWithAllowedQuery()
    {
        return _sanitizer.SanitizeUrl("https://www.example.com?api-version=2024-05-01");
    }

    [Benchmark]
    public string SanitizeUrlWithDisallowedQuery()
    {
        return _sanitizer.SanitizeUrl("https://www.example.com?param1=value1");
    }
}

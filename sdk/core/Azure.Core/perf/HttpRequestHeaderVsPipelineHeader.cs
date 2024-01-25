// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// |                    Categories | count |            Method |        Mean |    Error |   StdDev | Ratio |  Gen 0 | Allocated |
// |------------------------------ |------ |------------------ |------------:|---------:|---------:|------:|-------:|----------:|
// |      CreateHttpRequestMessage |     2 | HttpRequestHeader |    656.1 ns |  2.51 ns |  2.35 ns |  1.00 | 0.0048 |     496 B |
// |      CreateHttpRequestMessage |     2 | ArrayBackedHeader |    470.6 ns |  0.74 ns |  0.58 ns |  0.72 | 0.0048 |     496 B |
// |                               |       |                   |             |          |          |       |        |           |
// |      CreateHttpRequestMessage |     3 | HttpRequestHeader |    727.0 ns |  2.69 ns |  2.52 ns |  1.00 | 0.0048 |     496 B |
// |      CreateHttpRequestMessage |     3 | ArrayBackedHeader |    608.6 ns |  2.65 ns |  2.35 ns |  0.84 | 0.0076 |     776 B |
// |                               |       |                   |             |          |          |       |        |           |
// |      CreateHttpRequestMessage |     8 | HttpRequestHeader |  1,287.3 ns |  4.97 ns |  4.40 ns |  1.00 | 0.0114 |   1,104 B |
// |      CreateHttpRequestMessage |     8 | ArrayBackedHeader |  1,180.9 ns | 14.22 ns | 13.30 ns |  0.92 | 0.0134 |   1,384 B |
// |                               |       |                   |             |          |          |       |        |           |
// |      CreateHttpRequestMessage |    16 | HttpRequestHeader |  2,490.9 ns |  6.50 ns |  5.43 ns |  1.00 | 0.0267 |   2,736 B |
// |      CreateHttpRequestMessage |    16 | ArrayBackedHeader |  2,504.4 ns |  6.96 ns |  5.81 ns |  1.01 | 0.0305 |   3,016 B |
// |                               |       |                   |             |          |          |       |        |           |
// |      CreateHttpRequestMessage |    32 | HttpRequestHeader |  4,374.9 ns | 12.06 ns | 10.07 ns |  1.00 | 0.0381 |   4,120 B |
// |      CreateHttpRequestMessage |    32 | ArrayBackedHeader |  5,410.5 ns | 21.57 ns | 19.12 ns |  1.24 | 0.0458 |   4,656 B |
// |                               |       |                   |             |          |          |       |        |           |
// | CreateHttpRequestMessageTwice |     2 | HttpRequestHeader |  1,324.0 ns |  5.69 ns |  5.04 ns |  1.00 | 0.0114 |   1,256 B |
// | CreateHttpRequestMessageTwice |     2 | ArrayBackedHeader |    950.8 ns |  4.91 ns |  4.35 ns |  0.72 | 0.0095 |   1,032 B |
// |                               |       |                   |             |          |          |       |        |           |
// | CreateHttpRequestMessageTwice |     3 | HttpRequestHeader |  1,506.9 ns |  5.77 ns |  5.40 ns |  1.00 | 0.0134 |   1,336 B |
// | CreateHttpRequestMessageTwice |     3 | ArrayBackedHeader |  1,137.6 ns |  0.91 ns |  0.80 ns |  0.76 | 0.0134 |   1,312 B |
// |                               |       |                   |             |          |          |       |        |           |
// | CreateHttpRequestMessageTwice |     8 | HttpRequestHeader |  2,855.4 ns | 15.61 ns | 14.60 ns |  1.00 | 0.0305 |   2,888 B |
// | CreateHttpRequestMessageTwice |     8 | ArrayBackedHeader |  2,187.8 ns |  2.24 ns |  1.75 ns |  0.77 | 0.0267 |   2,528 B |
// |                               |       |                   |             |          |          |       |        |           |
// | CreateHttpRequestMessageTwice |    16 | HttpRequestHeader |  5,452.2 ns | 15.40 ns | 12.86 ns |  1.00 | 0.0687 |   6,792 B |
// | CreateHttpRequestMessageTwice |    16 | ArrayBackedHeader |  4,419.1 ns | 29.19 ns | 27.31 ns |  0.81 | 0.0610 |   5,792 B |
// |                               |       |                   |             |          |          |       |        |           |
// | CreateHttpRequestMessageTwice |    32 | HttpRequestHeader |  9,906.1 ns | 11.67 ns |  9.11 ns |  1.00 | 0.1068 |  10,840 B |
// | CreateHttpRequestMessageTwice |    32 | ArrayBackedHeader |  8,834.6 ns | 20.36 ns | 15.90 ns |  0.89 | 0.0916 |   8,816 B |
// |                               |       |                   |             |          |          |       |        |           |
// |                 MultipleReads |     8 | HttpRequestHeader |  2,976.5 ns | 11.14 ns |  9.30 ns |  1.00 | 0.0229 |   2,472 B |
// |                 MultipleReads |     8 | ArrayBackedHeader |  1,447.9 ns |  2.72 ns |  2.55 ns |  0.49 | 0.0153 |   1,472 B |
// |                               |       |                   |             |          |          |       |        |           |
// |                 MultipleReads |    16 | HttpRequestHeader |  5,971.1 ns | 19.34 ns | 17.14 ns |  1.00 | 0.0534 |   5,448 B |
// |                 MultipleReads |    16 | ArrayBackedHeader |  3,195.2 ns | 24.38 ns | 22.80 ns |  0.54 | 0.0305 |   3,168 B |
// |                               |       |                   |             |          |          |       |        |           |
// |                 MultipleReads |    32 | HttpRequestHeader | 11,225.7 ns | 40.46 ns | 35.87 ns |  1.00 | 0.0916 |   9,520 B |
// |                 MultipleReads |    32 | ArrayBackedHeader |  7,953.4 ns | 37.65 ns | 35.22 ns |  0.71 | 0.0458 |   4,936 B |

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.CompilerServices;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;

namespace Azure.Core.Perf
{
    [GroupBenchmarksBy(BenchmarkLogicalGroupRule.ByCategory)]
    [CategoriesColumn]
    [SimpleJob(RuntimeMoniker.Net60)]
    public class HttpRequestHeaderVsPipelineHeader
    {
        private static readonly (string, string)[] _testHeaders =
        {
            ("x-ms-client-request-id", "id"),
            ("x-ms-return-client-request-id", "id"),
            ("Accept", "application/json"),
            ("Cache-Control", "adcde"),
            ("Connection", "adcde"),
            ("Content-Disposition", "adcde"),
            ("Content-Encoding", "adcde"),
            ("Content-Language", "en-US"),
            ("x-ms-custom-3", "3"),
            ("x-ms-custom-4", "4"),

            ("Content-Length", "14"),
            ("Content-Location", "adcde"),
            ("Content-MD5", "eyJrZXkiOiJ2YWx1ZSJ9"),
            ("Content-Range", "adcde"),
            ("Content-Security-Policy", "adcde"),
            ("Content-Type", "application/json"),
            ("Custom-Header", "foo"),
            ("Custom-Header-2", "bar"),
            ("x-ms-custom-1", "1"),
            ("x-ms-custom-2", "2"),

            ("Date", "Tue, 12 Nov 2019 08:00:00 GMT"),
            ("If-Match", "*"),
            ("If-Modified-Since", "Tue, 01 Dec 2023 08:00:00 GMT"),
            ("If-None-Match", "*"),
            ("If-Range", "*"),
            ("If-Unmodified-Since", "Tue, 01 Dec 2023 08:00:00 GMT"),
            ("Range", "bytes=0-100"),
            ("Referer", "adcde"),
            ("User-Agent", "adcde"),
            ("X-Cache", "adcde"),

            ("X-Content-Duration", "adcde"),
            ("x-ms-custom-5", "5"),
        };

#if NET6_0_OR_GREATER
        [Benchmark(Baseline = true)]
        [BenchmarkCategory("CreateHttpRequestMessage")]
        // Policies that are always used by default
        // - ReadClientRequestIdPolicy.Shared - reads header "x-ms-client-request-id"
        // - ClientRequestIdPolicy.Shared - sets "x-ms-client-request-id", "x-ms-return-client-request-id"
        // So we should have at least 2 sets and one read
        [Arguments(2)]
        [Arguments(3)]
        [Arguments(8)]
        [Arguments(16)]
        [Arguments(32)]
        public HttpRequestMessage CreateHttpRequestMessage_HttpRequestHeader(int count)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "https://foo.com");
            request.Content = new ByteArrayContent(Array.Empty<byte>());
            for (int i = 0; i < count; i++)
            {
                var (key, value) = _testHeaders[i];
                // HttpRequestHeaders doesn't have `Set`, so old key must be removed first. We can call `NonValidated.Contains` instead of `Remove` to simulate checks for header that isn't present
                request.Headers.NonValidated.Contains(key);
                if (!request.Headers.TryAddWithoutValidation(key, value))
                {
                    request.Content.Headers.NonValidated.Contains(key);
                    request.Content.Headers.TryAddWithoutValidation(key, value);
                }
            }

            request.Headers.NonValidated.TryGetValues("x-ms-client-request-id", out _);
            return request;
        }
#endif

        [Benchmark]
        [BenchmarkCategory("CreateHttpRequestMessage")]
        [Arguments(2)]
        [Arguments(3)]
        [Arguments(8)]
        [Arguments(16)]
        [Arguments(32)]
        public HttpRequestMessage CreateHttpRequestMessage_ArrayBackedHeader(int count)
        {
            var headers = new ArrayBackedPropertyBag<IgnoreCaseString, object>();
            for (int i = 0; i < count; i++)
            {
                var (key, value) = _testHeaders[i];
                headers.Set(new IgnoreCaseString(key), value);
            }

            headers.TryGetValue(new IgnoreCaseString("x-ms-client-request-id"), out _);
            return CreateHttpRequest(ref headers);
        }

#if NET6_0_OR_GREATER
        [Benchmark(Baseline = true)]
        [BenchmarkCategory("CreateHttpRequestMessageTwice")]
        [Arguments(2)]
        [Arguments(3)]
        [Arguments(8)]
        [Arguments(16)]
        [Arguments(32)]
        public HttpRequestMessage[] CreateHttpRequestMessageTwice_HttpRequestHeader(int count)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "https://foo.com")
            {
                Content = new ByteArrayContent(Array.Empty<byte>())
            };

            var retryRequest = new HttpRequestMessage(HttpMethod.Post, "https://foo.com")
            {
                Content = new ByteArrayContent(Array.Empty<byte>())
            };

            for (int i = 0; i < count; i++)
            {
                var (key, value) = _testHeaders[i];
                // HttpRequestHeaders doesn't have `Set`, so old key must be removed first. We can call `NonValidated.Contains` to speed things up
                request.Headers.NonValidated.Contains(key);
                if (!request.Headers.TryAddWithoutValidation(key, value))
                {
                    request.Content.Headers.NonValidated.Contains(key);
                    request.Content.Headers.TryAddWithoutValidation(key, value);
                }
            }

            request.Headers.NonValidated.TryGetValues("x-ms-client-request-id", out _);
            foreach (var header in request.Headers.NonValidated)
            {
                retryRequest.Headers.TryAddWithoutValidation(header.Key, header.Value);
            }
            foreach (var header in request.Content.Headers.NonValidated)
            {
                retryRequest.Content.Headers.TryAddWithoutValidation(header.Key, header.Value);
            }
            return new[] { request, retryRequest };
        }
#endif

        [Benchmark]
        [BenchmarkCategory("CreateHttpRequestMessageTwice")]
        [Arguments(2)]
        [Arguments(3)]
        [Arguments(8)]
        [Arguments(16)]
        [Arguments(32)]
        public HttpRequestMessage[] CreateHttpRequestMessageTwice_ArrayBackedHeader(int count)
        {
            var headers = new ArrayBackedPropertyBag<IgnoreCaseString, object>();
            for (int i = 0; i < count; i++)
            {
                var (key, value) = _testHeaders[i];
                headers.Set(new IgnoreCaseString(key), value);
            }

            headers.TryGetValue(new IgnoreCaseString("x-ms-client-request-id"), out _);

            var request = CreateHttpRequest(ref headers);
            var retryRequest = CreateHttpRequest(ref headers);

            return new[] { request, retryRequest };
        }

#if NET6_0_OR_GREATER
        [Benchmark(Baseline = true)]
        [BenchmarkCategory("MultipleReads")]
        [Arguments(8)]
        [Arguments(16)]
        [Arguments(32)]
        public string[] MultipleReads_HttpRequestHeader(int count)
        {
            var result = new string[count];
            var request = new HttpRequestMessage(HttpMethod.Post, "https://foo.com");
            request.Content = new ByteArrayContent(Array.Empty<byte>());
            for (int i = 0; i < count; i++)
            {
                var (key, value) = _testHeaders[i];
                // HttpRequestHeaders doesn't have `Set`, so old key must be removed first. We can call `NonValidated.Contains` to speed things up
                request.Headers.NonValidated.Contains(key);
                if (!request.Headers.TryAddWithoutValidation(key, value))
                {
                    request.Content.Headers.NonValidated.Contains(key);
                    request.Content.Headers.TryAddWithoutValidation(key, value);
                }
            }

            var headers = request.Headers;
            var content = request.Content;
            for (int i = 0; i < count; i++)
            {
                var (key, _) = _testHeaders[i];
                if (headers.NonValidated.TryGetValues(key, out var values) || content.Headers.NonValidated.TryGetValues(key, out values))
                {
                    result[i] = string.Join(',', values);
                }
            }

            var j = 0;
            foreach (var header in headers.NonValidated)
            {
                result[j] = string.Join(',', header.Value);
                j++;
            }

            foreach (var header in content.Headers.NonValidated)
            {
                result[j] = string.Join(',', header.Value);
                j++;
            }

            return result;
        }
#endif

        [Benchmark]
        [BenchmarkCategory("MultipleReads")]
        [Arguments(8)]
        [Arguments(16)]
        [Arguments(32)]
        public string[] MultipleReads_ArrayBackedHeader(int count)
        {
            var result = new string[count];
            var headers = new ArrayBackedPropertyBag<IgnoreCaseString, object>();
            for (int i = 0; i < count; i++)
            {
                var (key, value) = _testHeaders[i];
                headers.Set(new IgnoreCaseString(key), value);
            }

            for (int i = 0; i < count; i++)
            {
                var (key, _) = _testHeaders[i];
                if (headers.TryGetValue(new IgnoreCaseString(key), out var value))
                {
                    result[i] = value switch
                    {
                        string headerValue => headerValue,
                        List<string> headerValues => string.Join(",", headerValues),
                        _ => result[i]
                    };
                }
            }

            for (int i = 0; i < headers.Count; i++)
            {
                headers.GetAt(i, out _, out var value);
                result[i] = value switch
                {
                    string headerValue => headerValue,
                    List<string> headerValues => string.Join(",", headerValues),
                    _ => result[i]
                };
            }

            CreateHttpRequest(ref headers);
            return result;
        }

        private readonly struct IgnoreCaseString : IEquatable<IgnoreCaseString>
        {
            private readonly string _value;

            public IgnoreCaseString(string value)
            {
                _value = value;
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public bool Equals(IgnoreCaseString other) => string.Equals(_value, other._value, StringComparison.OrdinalIgnoreCase);
            public override bool Equals(object obj) => obj is IgnoreCaseString other && Equals(other);
            public override int GetHashCode() => _value.GetHashCode();

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator ==(IgnoreCaseString left, IgnoreCaseString right) => left.Equals(right);
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static bool operator !=(IgnoreCaseString left, IgnoreCaseString right) => !left.Equals(right);
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public static implicit operator string(IgnoreCaseString ics) => ics._value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static HttpRequestMessage CreateHttpRequest(ref ArrayBackedPropertyBag<IgnoreCaseString, object> headers)
        {
            var content = new ByteArrayContent(Array.Empty<byte>());
            var request = new HttpRequestMessage(HttpMethod.Post, "https://foo.com") { Content = content };
            for (int i = 0; i < headers.Count; i++)
            {
                headers.GetAt(i, out var name, out var value);
                switch (value)
                {
                    case string stringValue:
                        if (!request.Headers.TryAddWithoutValidation(name, stringValue))
                        {
                            content.Headers.TryAddWithoutValidation(name, stringValue);
                        }
                        break;
                    case List<string> listValue:
                        if (!request.Headers.TryAddWithoutValidation(name, listValue))
                        {
                            content.Headers.TryAddWithoutValidation(name, listValue);
                        }
                        break;
                }
            }

            return request;
        }
    }
}

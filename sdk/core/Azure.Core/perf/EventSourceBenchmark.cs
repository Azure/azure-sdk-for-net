// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Azure.Core.Diagnostics;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Benchmarks.Local;
using Benchmarks.Nuget;

namespace Azure.Core.Perf
{
    [SimpleJob(RuntimeMoniker.Net80)]
    public class EventSourceBenchmark
    {
        private const string UriString = @"http://example.azure.com/some/rest/api?method=send&api-version=1";
        private static readonly string[] AllowedHeaders = { "Date", "Custom-Header" };
        private static readonly string[] AllowedQueryParameters = { "api-version" };
        private static readonly HttpMessageSanitizer Sanitizer = new(AllowedHeaders, AllowedQueryParameters);

        private string _sanitizedUri;
        private byte[] _headersBytes;
        private Benchmarks.Local.EventSourceScenario _localScenario;
        private Benchmarks.Nuget.EventSourceScenario _nugetScenario;

        [GlobalSetup]
        public void SetUp()
        {
            // Build URI and message
            var uri = new RawRequestUriBuilder();
            uri.AppendRaw(UriString, true);

            var message = new HttpRequestMessage();
            message.Headers.TryAddWithoutValidation("Date", "10/14/2020");
            message.Headers.TryAddWithoutValidation("Custom-Header", "Value");
            message.Headers.TryAddWithoutValidation("Header-To-Skip", "Skipped Value");

            _sanitizedUri = Sanitizer.SanitizeUrl(uri.ToString());
            _headersBytes = FormatHeaders(message);

            _localScenario = new Benchmarks.Local.EventSourceScenario(_sanitizedUri, _headersBytes);
            _nugetScenario = new Benchmarks.Nuget.EventSourceScenario(_sanitizedUri, _headersBytes);
        }

        [GlobalCleanup]
        public void CleanUp()
        {
            _localScenario.Dispose();
            _nugetScenario.Dispose();
        }

        // Local benchmarks
        [Benchmark]
        public void Local_OldImplementation()
        {
            _localScenario.RunOld(_sanitizedUri, _headersBytes);
        }

        [Benchmark]
        public void Local_NewImplementation()
        {
            _localScenario.RunNew(_sanitizedUri, _headersBytes);
        }

        [Benchmark]
        public void Local_NewImplementation_AfterFormatting()
        {
            _localScenario.RunNewPreformatted();
        }

        // Nuget benchmarks
        [Benchmark(Baseline = true)]
        public void Nuget_OldImplementation()
        {
            _nugetScenario.RunOld(_sanitizedUri, _headersBytes);
        }

        [Benchmark]
        public void Nuget_NewImplementation()
        {
            _nugetScenario.RunNew(_sanitizedUri, _headersBytes);
        }

        [Benchmark]
        public void Nuget_NewImplementation_AfterFormatting()
        {
            _nugetScenario.RunNewPreformatted();
        }

        private byte[] FormatHeaders(HttpRequestMessage message)
        {
            var stringBuilder = new StringBuilder();
            foreach (var header in message.Headers)
            {
                stringBuilder.Append(header.Key);
                stringBuilder.Append(':');
                stringBuilder.AppendLine(string.Join(",", header.Value));
            }
            return Encoding.UTF8.GetBytes(stringBuilder.ToString());
        }
    }
}

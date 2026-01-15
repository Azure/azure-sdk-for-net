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

namespace Azure.Core.Perf
{
    [SimpleJob(RuntimeMoniker.Net80)]
    public class EventSourceBenchmark
    {
        private const string UriString = @"http://example.azure.com/some/rest/api?method=send&api-version=1";
        private static readonly string[] AllowedHeaders = { "Date", "Custom-Header" };
        private static readonly string[] AllowedQueryParameters = { "api-version" };
        private static readonly HttpMessageSanitizer Sanitizer = new(AllowedHeaders, AllowedQueryParameters);

        private RawRequestUriBuilder _uri;
        private string _sanitizedUri;
        private byte[] _headersBytes;

        private AzureEventSourceListener _sourceListener;
        private CustomEventSource _eventSource;
        private int _iteration;
        private HttpRequestMessage _message;

        [GlobalSetup]
        public void SetUp()
        {
            // Build URI and message
            _uri = new RawRequestUriBuilder();
            _uri.AppendRaw(UriString, true);

            _message = new HttpRequestMessage();
            _message.Headers.TryAddWithoutValidation("Date", "10/14/2020");
            _message.Headers.TryAddWithoutValidation("Custom-Header", "Value");
            _message.Headers.TryAddWithoutValidation("Header-To-Skip", "Skipped Value");

            _sanitizedUri = Sanitizer.SanitizeUrl(_uri.ToString());
            _headersBytes = FormatHeaders();

            _sourceListener = new AzureEventSourceListener(_ => { }, EventLevel.LogAlways);
            _eventSource = new CustomEventSource();
            _sourceListener.EnableEvents(_eventSource, EventLevel.LogAlways);
        }

        [GlobalCleanup]
        public void CleanUp()
        {
            _sourceListener.Dispose();
            _eventSource.Dispose();
        }

        // Benchmarks
        [Benchmark(Description = "Old implementation, includes reformatting")]
        public void OldImplementation_CallFormatting()
        {
            _eventSource.RequestOld(Sanitizer.SanitizeUrl(_uri.ToString()), _iteration++, _iteration, FormatHeaders());
        }

        [Benchmark(Description = "New implementation, includes reformatting")]
        public void NewImplementation_CallFormatting()
        {
            _eventSource.RequestNew(Sanitizer.SanitizeUrl(_uri.ToString()), _iteration++, _iteration, FormatHeaders());
        }

        [Benchmark(Description = "New implementation, no reformatting")]
        public void NewImplementation_AfterFormatting()
        {
            _eventSource.RequestNew(_sanitizedUri, _iteration++, _iteration, _headersBytes);
        }

        private byte[] FormatHeaders()
        {
            var stringBuilder = new StringBuilder();
            foreach (var header in _message.Headers)
            {
                stringBuilder.Append(header.Key);
                stringBuilder.Append(':');
                stringBuilder.AppendLine(string.Join(",", header.Value));
            }
            return Encoding.UTF8.GetBytes(stringBuilder.ToString());
        }
    }
}

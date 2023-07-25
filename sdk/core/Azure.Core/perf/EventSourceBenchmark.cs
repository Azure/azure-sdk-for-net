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
    [SimpleJob(RuntimeMoniker.Net462)]
    [SimpleJob(RuntimeMoniker.Net60)]
    public class EventSourceBenchmark
    {
        private const string UriString = @"http://example.azure.com/some/rest/api?method=send&api-version=1";
        private static readonly string[] AllowedHeaders = { "Date", "Custom-Header" };
        private static readonly string[] AllowedQueryParameters = { "api-version" };
        private static readonly HttpMessageSanitizer Sanitizer = new(AllowedHeaders, AllowedQueryParameters);

        private AzureEventSourceListener _sourceListener;
        private EventSource _eventSource;
        private RawRequestUriBuilder _uri;
        private HttpRequestMessage _message;
        private int _iteration;
        private string _sanitizedUri;
        private byte[] _headersBytes;

        [GlobalSetup]
        public void SetUp()
        {
            _sourceListener = new AzureEventSourceListener((_, _) => { }, EventLevel.LogAlways);
            _eventSource = new EventSource();
            _sourceListener.EnableEvents(_eventSource, EventLevel.LogAlways);

            _uri = new RawRequestUriBuilder();
            _uri.AppendRaw(UriString, true);

            _message = new HttpRequestMessage();
            _message.Headers.TryAddWithoutValidation("Date", "10/14/2020");
            _message.Headers.TryAddWithoutValidation("Custom-Header", "Value");
            _message.Headers.TryAddWithoutValidation("Header-To-Skip", "Skipped Value");

            _sanitizedUri = Sanitizer.SanitizeUrl(_uri.ToString());
            _headersBytes = FormatHeaders();
        }

        [GlobalCleanup]
        public void CleanUp()
        {
            _sourceListener.Dispose();
            _eventSource.Dispose();
        }

        [Benchmark(Baseline = true, Description = "Old implementation")]
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
            foreach (HttpHeader header in GetHeaders(_message.Headers))
            {
                stringBuilder.Append(header.Name);
                stringBuilder.Append(':');
                string newValue = Sanitizer.SanitizeHeader(header.Name, header.Value);
                stringBuilder.AppendLine(newValue);
            }
            return Encoding.UTF8.GetBytes(stringBuilder.ToString());
        }

        internal static IEnumerable<HttpHeader> GetHeaders(HttpHeaders headers)
        {
#if NET6_0_OR_GREATER
            foreach (var (key, values) in headers.NonValidated)
            {
                yield return new HttpHeader(key, values.Count switch
                {
                    0 => string.Empty,
                    1 => values.ToString(),
                    _ => string.Join(",", values)
                });
            }
#else
            foreach (KeyValuePair<string, IEnumerable<string>> header in headers)
            {
                yield return new HttpHeader(header.Key, string.Join(",", header.Value));
            }
#endif
        }

        private class EventSource : AzureEventSource
        {
            public EventSource() : base("Azure-Core") { }

            [Event(1, Level = EventLevel.Informational)]
            public void RequestOld(string strParam, int intParam, double doubleParam, byte[] bytesParam)
            {
                WriteEvent(1, strParam, intParam, doubleParam, bytesParam);
            }

            [Event(2, Level = EventLevel.Informational)]
            public void RequestNew(string strParam, int intParam, double doubleParam, byte[] bytesParam)
            {
                WriteEventNew(2, strParam, intParam, doubleParam, bytesParam);
            }

            [NonEvent]
            private unsafe void WriteEventNew(int eventId, string arg0, int arg1, double arg2, byte[] arg3)
            {
                if (!IsEnabled())
                {
                    return;
                }

                arg0 ??= string.Empty;
                fixed (char* arg0Ptr = arg0)
                {
                    EventData* data = stackalloc EventData[5];
                    data[0].DataPointer = (IntPtr)arg0Ptr;
                    data[0].Size = (arg0.Length + 1) * 2;
                    data[1].DataPointer = (IntPtr)(&arg1);
                    data[1].Size = 4;
                    data[2].DataPointer = (IntPtr)(&arg2);
                    data[2].Size = 8;

                    var blobSize = arg3.Length;
                    fixed (byte* blob = &arg3[0])
                    {
                        data[3].DataPointer = (IntPtr)(&blobSize);
                        data[3].Size = 4;
                        data[4].DataPointer = (IntPtr)blob;
                        data[4].Size = blobSize;
                        WriteEventCore(eventId, 4, data);
                    }
                }
            }
        }
    }
}

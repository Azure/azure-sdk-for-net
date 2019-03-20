// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Base.Buffers;
using Azure.Base.Http;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using Azure.Base.Http.Pipeline;

namespace Azure
{

    public class HttpPipelineOptions
    {
        private List<PolicyRegistration> _pipelinePolicies;

        public HttpPipelineOptions()
        {
            _pipelinePolicies = new List<PolicyRegistration>();
            TransportPolicy = () => new HttpClientTransport();
        }

        public ICollection<PolicyRegistration> PipelinePolicies => _pipelinePolicies;

        public Func<HttpPipelineTransport> TransportPolicy { get; set; }

        public bool DisableTelemetry { get; set; }

        public string ApplicationId { get; set; }

        public HttpPipelineOptions Clone()
        {
            return new HttpPipelineOptions()
            {
                TransportPolicy = TransportPolicy,
                _pipelinePolicies = new List<PolicyRegistration>(PipelinePolicies),
                ApplicationId = ApplicationId,
                DisableTelemetry =  DisableTelemetry
            };
        }


    }

    public enum HttpPipelineSection
    {
        PreRetry,
        Retry,
        PostRetry
    }

    public struct PolicyRegistration
    {
        public HttpPipelineSection Section { get; }
        public Func<HttpPipelinePolicy, HttpPipelinePolicy> PolicyFactory { get; }

        public PolicyRegistration(HttpPipelineSection section, Func<HttpPipelinePolicy, HttpPipelinePolicy> policyFactory)
        {
            Section = section;
            PolicyFactory = policyFactory;
        }
    }

    public static class ClientPipelineBuilderExtensions
    {
        public static HttpPipeline Build(this HttpPipelineOptions options, string componentName, string componentVersion)
        {
            if (!options.DisableTelemetry)
            {
                options = options.Clone();
                options.AddHeaders(HttpHeader.Common.CreateUserAgent(componentName, componentVersion, options.ApplicationId));
            }

            var transport = options.TransportPolicy();

            HttpPipelinePolicy currentPolicy = transport;

            foreach (var section in options.PipelinePolicies.Reverse().GroupBy(registration => registration.Section))
            {
                foreach (var pipelineBuilderPipelinePolicy in section)
                {
                    currentPolicy = pipelineBuilderPipelinePolicy.PolicyFactory(currentPolicy);
                }
            }

            return new HttpPipeline(transport, currentPolicy);
        }

        public static HttpPipelineOptions AddLogging(this HttpPipelineOptions options, int[] excludeCodes = null)
        {
            return options.Append(HttpPipelineSection.PostRetry, next => new LoggingPolicy(next, excludeCodes));
        }

        public static HttpPipelineOptions AddFixedRetry(this HttpPipelineOptions options, int maxRetries, TimeSpan delay, params int[] retriableCodes)
        {
            return options.Replace(HttpPipelineSection.Retry, next => new FixedPolicy(next, maxRetries, delay, retriableCodes));
        }

        public static HttpPipelineOptions AddHeaders(this HttpPipelineOptions options, params HttpHeader[] headers)
        {
            return options.Replace(HttpPipelineSection.PreRetry, next => new AddHeadersPolicy(next, headers));
        }

        public static HttpPipelineOptions UseHttpClient(this HttpPipelineOptions options, HttpClient client)
        {
            options.TransportPolicy =  () => {
                return new HttpClientTransport()
                {
                    Client = client
                };
            };
            return options;
        }

        public static HttpPipelineOptions UseHttpClient(this HttpPipelineOptions options, Action<HttpClientHandler> configure)
        {
            options.TransportPolicy =  () => {
                var handler = new HttpClientHandler();
                configure(handler);
                return new HttpClientTransport()
                {
                    Client = new HttpClient(handler)
                };
            };

            return options;
        }

        public static HttpPipelineOptions Append(this HttpPipelineOptions options, HttpPipelineSection section, Func<HttpPipelinePolicy, HttpPipelinePolicy> policyFactory)
        {
            options.PipelinePolicies.Add(new PolicyRegistration(section, policyFactory));
            return options;
        }

        public static HttpPipelineOptions TryAppend(this HttpPipelineOptions options, HttpPipelineSection section, Func<HttpPipelinePolicy, HttpPipelinePolicy> policyFactory)
        {
            if (options.PipelinePolicies.All(p => p.Section != section))
            {
                options.PipelinePolicies.Add(new PolicyRegistration(section, policyFactory));
            }
            return options;
        }

        public static HttpPipelineOptions Replace(this HttpPipelineOptions options, HttpPipelineSection section, Func<HttpPipelinePolicy, HttpPipelinePolicy> policyFactory)
        {
            foreach (var registration in options.PipelinePolicies.Where(registration => registration.Section == section).ToArray())
            {
                options.PipelinePolicies.Remove(registration);
            }

            return options.Append(section, policyFactory);
        }
    }

    public readonly struct Response
    {
        readonly HttpMessage _message;

        public Response(HttpMessage message)
            => _message = message;

        public int Status => _message.Status;

        public Stream ContentStream => _message.ResponseContentStream;

        public bool TryGetHeader(ReadOnlySpan<byte> name, out long value)
        {
            value = default;
            if (!TryGetHeader(name, out ReadOnlySpan<byte> bytes)) return false;
            if (!Utf8Parser.TryParse(bytes, out value, out int consumed) || consumed != bytes.Length)
                throw new Exception("bad content-length value");
            return true;
        }

        public bool TryGetHeader(ReadOnlySpan<byte> name, out ReadOnlySpan<byte> value)
            => _message.TryGetHeader(name, out value);

        public bool TryGetHeader(ReadOnlySpan<byte> name, out string value)
        {
            if (TryGetHeader(name, out ReadOnlySpan<byte> span)) {
                value = span.AsciiToString();
                return true;
            }
            value = default;
            return false;
        }

        public bool TryGetHeader(string name, out long value)
        {
            value = default;
            if (!TryGetHeader(name, out string valueString)) return false;
            if (!long.TryParse(valueString, out value))
                throw new Exception("bad content-length value");
            return true;
        }

        public bool TryGetHeader(string name, out string value)
        {
            var utf8Name = Encoding.ASCII.GetBytes(name);
            return TryGetHeader(utf8Name, out value);
        }

        public void Dispose() => _message.Dispose();

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => base.Equals(obj);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => base.GetHashCode();

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString()
        {
            var responseStream = _message.ResponseContentStream;
            if (responseStream.CanSeek) {
                var position = responseStream.Position;
                var reader = new StreamReader(responseStream);
                var result = $"{Status} {reader.ReadToEnd()}";
                responseStream.Seek(position, SeekOrigin.Begin);
                return result;
            }

            return $"Status : {Status.ToString()}";
        }
    }
}

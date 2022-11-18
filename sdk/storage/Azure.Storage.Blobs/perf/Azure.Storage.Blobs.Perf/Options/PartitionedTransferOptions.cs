// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using System.Threading;
using System;
using System.Linq;
using System.Net.Http.Headers;
using Azure.Core.Pipeline;
using Azure.Storage.Blobs.Perf.Infrastructure.Models.ClientSideEncryption;
using Azure.Storage.Blobs.Specialized;
using Azure.Test.Perf;
using CommandLine;

namespace Azure.Storage.Blobs.Perf.Options
{
    public class PartitionedTransferOptions : SizeOptions, IBlobClientOptionsProvider, IStorageTransferOptionsProvider
    {
        private long? _maximumTransferSize;
        private long? _initialTransferSize;
        private int? _maximumConcurrency;

        [Option("transfer-block-size")]
        public long? MaximumTransferSize
        {
            get => _maximumTransferSize;
            set
            {
                _maximumTransferSize = value;
                UpdateStorageTransferOptions();
            }
        }

        [Option("transfer-initial-size")]
        public long? InitialTransferSize
        {
            get => _initialTransferSize;
            set
            {
                _initialTransferSize = value;
                UpdateStorageTransferOptions();
            }
        }

        [Option("transfer-concurrency")]
        public int? MaximumConcurrency
        {
            get => _maximumConcurrency;
            set
            {
                _maximumConcurrency = value;
                UpdateStorageTransferOptions();
            }
        }

        [Option("client-encryption")]
        public string EncryptionVersionString { get; set; }

        [Option("cache-responses")]
        public bool CacheResponses { get; set; }

        public StorageTransferOptions StorageTransferOptions { get; private set; }

        BlobClientOptions IBlobClientOptionsProvider.ClientOptions
        {
            get
            {
                static bool TryParseEncryptionVersion(
                    string versionString,
                    out ClientSideEncryptionVersion version)
                {
                    switch (versionString)
                    {
                        case "2.0":
                            version = ClientSideEncryptionVersion.V2_0;
                            return true;
#pragma warning disable CS0618 // obsolete
                        case "1.0":
                            version = ClientSideEncryptionVersion.V1_0;
                            return true;
#pragma warning restore CS0618 // obsolete
                        default:
                            version = 0;
                            return false;
                    }
                }
                var result = new SpecializedBlobClientOptions
                {
                    ClientSideEncryption = TryParseEncryptionVersion(EncryptionVersionString, out ClientSideEncryptionVersion version)
                        ? new ClientSideEncryptionOptions(version)
                        {
                            KeyEncryptionKey = new LocalKeyEncryptionKey(),
                            KeyWrapAlgorithm = "foo"
                        }
                        : default
                };

                if (CacheResponses)
                {
                    result.Transport = new HttpClientTransport(new ResponseCachingHandler());
                }

                return result;
            }
        }

        private void UpdateStorageTransferOptions()
        {
            StorageTransferOptions = new StorageTransferOptions()
            {
                MaximumConcurrency = _maximumConcurrency,
                MaximumTransferSize = _maximumTransferSize,
                InitialTransferSize = _initialTransferSize,
            };
        }

        private class ResponseCachingHandler : DelegatingHandler
        {
            private readonly Dictionary<HttpRequestMessage, ResponseSource> _cache;

            public ResponseCachingHandler() : base(new HttpClientHandler())
            {
                _cache = new Dictionary<HttpRequestMessage, ResponseSource>(new HttpRequestMessageComparer());
            }

            protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                if (!_cache.TryGetValue(request, out var responseSource))
                {
                    var response = await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
                    responseSource = await ResponseSource.CreateAsync(response).ConfigureAwait(false);
                    _cache[request] = responseSource;
                    return response;
                }

                return responseSource.CreateResponseMessage(request);
            }
#if NET5_0_OR_GREATER
            protected override HttpResponseMessage Send(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                if (!_cache.TryGetValue(request, out var responseSource))
                {
                    var response = base.Send(request, cancellationToken);
                    responseSource = ResponseSource.Create(response);
                    _cache[request] = responseSource;
                    return response;
                }

                return responseSource.CreateResponseMessage(request);
            }
#endif

            private class ResponseSource
            {
                private readonly BinaryData _content;
                private readonly HttpStatusCode _statusCode;
                private readonly List<KeyValuePair<string, IEnumerable<string>>> _headers;
                private readonly string _reasonPhrase;
                private readonly Version _version;

                private ResponseSource(HttpResponseMessage response, BinaryData content)
                {
                    _content = content;
                    _headers = response.Headers.ToList();
                    _statusCode = response.StatusCode;
                    _reasonPhrase = response.ReasonPhrase;
                    _version = response.Version;
                }

                public HttpResponseMessage CreateResponseMessage(HttpRequestMessage requestMessage)
                {
                    var message = new HttpResponseMessage(_statusCode)
                    {
                        Content = new StreamContent(_content.ToStream()),
                        ReasonPhrase = _reasonPhrase,
                        RequestMessage = requestMessage,
                        Version = _version
                    };

                    foreach (var header in _headers)
                    {
                        if (string.Equals(header.Key, "x-ms-client-request-id", StringComparison.OrdinalIgnoreCase) && requestMessage.Headers.TryGetValues(header.Key, out var values))
                        {
                            message.Headers.TryAddWithoutValidation(header.Key, values);
                        }
                        else
                        {
                            message.Headers.TryAddWithoutValidation(header.Key, header.Value);
                        }
                    }

                    return message;
                }

                public static async ValueTask<ResponseSource> CreateAsync(HttpResponseMessage response)
                {
                    var content = new BinaryData(string.Empty);
                    if (response.Content != null)
                    {
                        var stream = await response.Content.ReadAsStreamAsync();
                        content = await BinaryData.FromStreamAsync(stream).ConfigureAwait(false);
                    }

                    return new ResponseSource(response, content);
                }
#if NET5_0_OR_GREATER
                public static ResponseSource Create(HttpResponseMessage response)
                {
                    var content = new BinaryData(string.Empty);
                    if (response.Content != null)
                    {
                        var stream = response.Content.ReadAsStream();
                        content = BinaryData.FromStream(stream);
                    }

                    return new ResponseSource(response, content);
                }
#endif
            }
        }

        private class HttpRequestMessageComparer : IEqualityComparer<HttpRequestMessage>
        {
            public bool Equals(HttpRequestMessage x, HttpRequestMessage y)
            {
                if (ReferenceEquals(x, y))
                {
                    return true;
                }

                if (ReferenceEquals(x, null))
                {
                    return false;
                }

                if (ReferenceEquals(y, null))
                {
                    return false;
                }

                if (x.GetType() != y.GetType())
                {
                    return false;
                }

                return x.Method.Equals(y.Method)
                    && Equals(x.RequestUri, y.RequestUri)
                    && x.Version.Equals(y.Version);
/*
#if NET5_0_OR_GREATER
                    && x.VersionPolicy == y.VersionPolicy
                    && EqualOptions(x.Options, y.Options)
#else
                    && EqualOptions(x.Properties, y.Properties)
#endif
                    && EqualHeaders(x.Headers, y.Headers)
                    && EqualContent(x.Content, y.Content);
*/
            }

            public int GetHashCode(HttpRequestMessage obj)
            {
                var hc1 = (uint)(obj.Method?.GetHashCode() ?? 0);
                var hc2 = (uint)(obj.RequestUri?.GetHashCode() ?? 0);
                var hc3 = (uint)(obj.Version?.GetHashCode() ?? 0);

                var hc12 = (hc1 + hc2) * (hc1 + hc2 + 1) / 2 + hc2;
                var hc123 = (hc12 + hc3) * (hc12 + hc3 + 1) / 2 + hc3;

                return (int)hc123;
            }

            private static bool EqualOptions(IDictionary<string, object> xOptions, IDictionary<string, object> yOptions)
            {
                if (xOptions.Count != yOptions.Count)
                {
                    return false;
                }

                foreach (var kvp in xOptions)
                {
                    if (!xOptions.TryGetValue(kvp.Key, out var yValue) || !Equals(kvp.Value, yValue))
                    {
                        return false;
                    }
                }

                return true;
            }

            private static bool EqualHeaders(HttpRequestHeaders xHeaders, HttpRequestHeaders yHeaders)
            {
                foreach (var xHeader in xHeaders)
                {
                    if (!yHeaders.TryGetValues(xHeader.Key, out var yValues))
                    {
                        return false;
                    }

                    if (!xHeader.Value.SequenceEqual(yValues))
                    {
                        return false;
                    }
                }

                return true;
            }

            private static bool EqualContent(HttpContent xContent, HttpContent yContent)
            {
                return true;
            }
        }
    }
}

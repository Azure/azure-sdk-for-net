// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Azure;
using Azure.Base.Diagnostics;
using Azure.Base.Http;
using Azure.Base.Http.Pipeline;
using System;
using System.ComponentModel;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.ApplicationModel.Configuration
{
    public class ConfigurationClientOptions : HttpPipelineOptions
    {
        Version _serviceAPIVersion = Version.V1;

        public ConfigurationClientOptions()
        {
            ComponentName = "Azure.Configuration";
            ComponentVersion = "1.0.0";
            RetryPolicy = s_defaultRetryPolicy;
        }

        static HttpPipelinePolicy s_defaultRetryPolicy = new FixedRetryPolicy(3, TimeSpan.Zero,
            //429, // Too Many Requests TODO (pri 2): this needs to throttle based on x-ms-retry-after 
            500, // Internal Server Error 
            503, // Service Unavailable
            504  // Gateway Timeout
        );

        public Version ServiceVersion {
            get => _serviceAPIVersion;
            set {
                if (value != Version.V1) throw new ArgumentOutOfRangeException(nameof(value));
                _serviceAPIVersion = Version.V1;
            }
        }

        public enum Version : ushort
        {
            V1,
        }

        #region nobody wants to see these
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => base.Equals(obj);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => base.GetHashCode();

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString() => base.ToString();
        #endregion
    }

    public partial class ConfigurationClient
    {
        readonly Uri _baseUri;
        readonly string _credential;
        readonly byte[] _secret;
        HttpPipeline _pipeline;

        public ConfigurationClient(string connectionString)
            : this(connectionString, new ConfigurationClientOptions())
        { }

        public ConfigurationClient(string connectionString, ConfigurationClientOptions options)
        {
            if (connectionString == null) throw new ArgumentNullException(nameof(connectionString));
            if (options == null) throw new ArgumentNullException(nameof(options));
            _pipeline = HttpPipeline.Create(options);
            ParseConnectionString(connectionString, out _baseUri, out _credential, out _secret);
        }

        public HttpPipeline Pipeline => _pipeline;

        [KnownException(typeof(HttpRequestException), Message = "The request failed due to an underlying issue such as network connectivity, DNS failure, or timeout.")]
        [HttpError(typeof(RequestFailedException), 412, Message = "matching item is already in the store")]
        [HttpError(typeof(RequestFailedException), 429, Message = "too many requests")]
        [UsageErrors(typeof(RequestFailedException), 401, 409, 408, 500, 502, 503, 504)]
        public async Task<Response<ConfigurationSetting>> AddAsync(ConfigurationSetting setting, CancellationToken cancellation = default)
        {
            if (setting == null) throw new ArgumentNullException(nameof(setting));
            if (string.IsNullOrEmpty(setting.Key)) throw new ArgumentNullException($"{nameof(setting)}.{nameof(setting.Key)}");
            if (!string.IsNullOrEmpty(setting.ETag)) throw new ArgumentException($"{nameof(setting)}.{nameof(setting.ETag)} has to be null");

            Uri uri = BuildUriForKvRoute(setting);

            using (HttpMessage message = _pipeline.CreateMessage(cancellation)) {
                ReadOnlyMemory<byte> content = Serialize(setting);

                message.SetRequestLine(HttpVerb.Put, uri);

                message.AddHeader("Host", uri.Host);
                message.AddHeader(IfNoneMatch, "*");
                message.AddHeader(MediaTypeKeyValueApplicationHeader);
                message.AddHeader(HttpHeader.Common.JsonContentType);
                message.AddHeader(HttpHeader.Common.CreateContentLength(content.Length));
                AddClientRequestID(message);
                AddAuthenticationHeaders(message, uri, HttpVerb.Put, content, _secret, _credential);

                message.SetContent(HttpMessageContent.Create(content));

                await _pipeline.SendMessageAsync(message).ConfigureAwait(false);

                var response = message.Response;
                if (response.Status == 200) {
                    return await CreateResponse(response, cancellation);
                }
                else throw new RequestFailedException(response);
            }
        }

        public async Task<Response<ConfigurationSetting>> SetAsync(ConfigurationSetting setting, RequestOptions options = null, CancellationToken cancellation = default)
        {
            if (setting == null) throw new ArgumentNullException(nameof(setting));
            if (string.IsNullOrEmpty(setting.Key)) throw new ArgumentNullException($"{nameof(setting)}.{nameof(setting.Key)}");

            Uri uri = BuildUriForKvRoute(setting);

            using (HttpMessage message = _pipeline.CreateMessage(cancellation)) {
                ReadOnlyMemory<byte> content = Serialize(setting);

                message.SetRequestLine(HttpVerb.Put, uri);

                message.AddHeader("Host", uri.Host);
                message.AddHeader(MediaTypeKeyValueApplicationHeader);
                message.AddHeader(HttpHeader.Common.JsonContentType);
                message.AddHeader(HttpHeader.Common.CreateContentLength(content.Length));
                AddOptionsHeaders(options, message);
                AddClientRequestID(message);
                AddAuthenticationHeaders(message, uri, HttpVerb.Put, content, _secret, _credential);

                message.SetContent(HttpMessageContent.Create(content));

                await _pipeline.SendMessageAsync(message).ConfigureAwait(false);

                var response = message.Response;
                if (response.Status == 200) {
                    return await CreateResponse(response, cancellation);
                }
                if (response.Status == 409) throw new RequestFailedException(response, "the item is locked");
                else throw new RequestFailedException(response);
            }
        }

        public async Task<Response<ConfigurationSetting>> UpdateAsync(ConfigurationSetting setting, RequestOptions options = null, CancellationToken cancellation = default)
        {
            if (setting == null) throw new ArgumentNullException(nameof(setting));
            if (string.IsNullOrEmpty(setting.Key)) throw new ArgumentNullException($"{nameof(setting)}.{nameof(setting.Key)}");

            Uri uri = BuildUriForKvRoute(setting);

            using (HttpMessage message = _pipeline.CreateMessage(cancellation)) {
                ReadOnlyMemory<byte> content = Serialize(setting);

                message.SetRequestLine(HttpVerb.Put, uri);

                message.AddHeader("Host", uri.Host);
                message.AddHeader(MediaTypeKeyValueApplicationHeader);
                message.AddHeader(HttpHeader.Common.JsonContentType);
                message.AddHeader(HttpHeader.Common.CreateContentLength(content.Length));
                AddOptionsHeaders(options, message);
                AddClientRequestID(message);
                AddAuthenticationHeaders(message, uri, HttpVerb.Put, content, _secret, _credential);

                message.SetContent(HttpMessageContent.Create(content));

                await _pipeline.SendMessageAsync(message).ConfigureAwait(false);

                var response = message.Response;
                if (response.Status == 200) {
                    return await CreateResponse(response, cancellation);
                }
                else throw new RequestFailedException(response);
            }
        }

        public async Task<Response> DeleteAsync(string key, RequestOptions options = null, CancellationToken cancellation = default)
        {
            if (string.IsNullOrEmpty(key)) throw new ArgumentNullException(nameof(key));

            Uri uri = BuildUriForKvRoute(key, options);

            using (HttpMessage message = _pipeline.CreateMessage(cancellation)) {
                message.SetRequestLine(HttpVerb.Delete, uri);

                message.AddHeader("Host", uri.Host);
                AddOptionsHeaders(options, message);
                AddClientRequestID(message);
                AddAuthenticationHeaders(message, uri, HttpVerb.Delete, content: default, _secret, _credential);

                await _pipeline.SendMessageAsync(message).ConfigureAwait(false);

                var response = message.Response;
                if (response.Status == 200 || response.Status == 204) {
                    return response;
                }
                else throw new RequestFailedException(response);
            }
        }

        public async Task<Response<ConfigurationSetting>> LockAsync(string key, RequestOptions options = null, CancellationToken cancellation = default)
        {
            if (string.IsNullOrEmpty(key)) throw new ArgumentNullException(nameof(key));

            Uri uri = BuildUriForLocksRoute(key, options);

            using (HttpMessage message = _pipeline.CreateMessage(cancellation)) {
                message.SetRequestLine(HttpVerb.Put, uri);

                message.AddHeader("Host", uri.Host);
                AddOptionsHeaders(options, message);
                AddClientRequestID(message);
                AddAuthenticationHeaders(message, uri, HttpVerb.Put, content: default, _secret, _credential);

                await _pipeline.SendMessageAsync(message).ConfigureAwait(false);

                var response = message.Response;
                if (response.Status == 200) {
                    return await CreateResponse(response, cancellation);
                }
                else throw new RequestFailedException(response);
            }
        }

        public async Task<Response<ConfigurationSetting>> UnlockAsync(string key, RequestOptions options = null, CancellationToken cancellation = default)
        {
            if (string.IsNullOrEmpty(key)) throw new ArgumentNullException(nameof(key));

            Uri uri = BuildUriForLocksRoute(key, options);

            using (HttpMessage message = _pipeline.CreateMessage(cancellation)) {
                message.SetRequestLine(HttpVerb.Delete, uri);

                message.AddHeader("Host", uri.Host);
                AddOptionsHeaders(options, message);
                AddClientRequestID(message);
                AddAuthenticationHeaders(message, uri, HttpVerb.Delete, content: default, _secret, _credential);

                await _pipeline.SendMessageAsync(message).ConfigureAwait(false);

                var response = message.Response;
                if (response.Status == 200) {
                    return await CreateResponse(response, cancellation);
                }
                else throw new RequestFailedException(response);
            }
        }

        public async Task<Response<ConfigurationSetting>> GetAsync(string key, RequestOptions options = null, CancellationToken cancellation = default)
        {
            if (string.IsNullOrEmpty(key)) throw new ArgumentNullException($"{nameof(key)}");

            Uri uri = BuildUriForKvRoute(key, options);

            using (HttpMessage message = _pipeline.CreateMessage(cancellation)) {
                message.SetRequestLine(HttpVerb.Get, uri);

                message.AddHeader("Host", uri.Host);
                message.AddHeader(MediaTypeKeyValueApplicationHeader);
                AddOptionsHeaders(options, message);
                AddClientRequestID(message);
                message.AddHeader(HttpHeader.Common.JsonContentType);

                AddAuthenticationHeaders(message, uri, HttpVerb.Get, content: default, _secret, _credential);

                await _pipeline.SendMessageAsync(message).ConfigureAwait(false);

                var response = message.Response;
                if (response.Status == 200) {
                    return await CreateResponse(response, cancellation);
                }
                else throw new RequestFailedException(response);
            }
        }

        public async Task<Response<SettingBatch>> GetBatchAsync(BatchRequestOptions batchOptions, CancellationToken cancellation = default)
        {
            var uri = BuildUriForGetBatch(batchOptions);

            using (HttpMessage message = _pipeline.CreateMessage(cancellation)) {
                message.SetRequestLine(HttpVerb.Get, uri);

                message.AddHeader("Host", uri.Host);
                message.AddHeader(MediaTypeKeyValueApplicationHeader);
                AddOptionsHeaders(batchOptions, message);
                AddClientRequestID(message);
                AddAuthenticationHeaders(message, uri, HttpVerb.Get, content: default, _secret, _credential);

                await _pipeline.SendMessageAsync(message).ConfigureAwait(false);

                Response response = message.Response;
                if (response.Status == 200 || response.Status == 206 /* partial */) {
                    var batch = await ConfigurationServiceSerializer.ParseBatchAsync(response, batchOptions, cancellation);
                    return new Response<SettingBatch>(response, batch);
                }
                else throw new RequestFailedException(response);
            }
        }

        public async Task<Response<SettingBatch>> GetRevisionsAsync(BatchRequestOptions options, CancellationToken cancellation = default)
        {
            var uri = BuildUriForRevisions(options);

            using (HttpMessage message = _pipeline.CreateMessage(cancellation)) {
                message.SetRequestLine(HttpVerb.Get, uri);

                message.AddHeader("Host", uri.Host);
                message.AddHeader(MediaTypeKeyValueApplicationHeader);
                AddOptionsHeaders(options, message);
                AddClientRequestID(message);
                AddAuthenticationHeaders(message, uri, HttpVerb.Get, content: default, _secret, _credential);

                await _pipeline.SendMessageAsync(message).ConfigureAwait(false);

                Response response = message.Response;
                if (response.Status == 200 || response.Status == 206 /* partial */) {
                    var batch = await ConfigurationServiceSerializer.ParseBatchAsync(response, options, cancellation);
                    return new Response<SettingBatch>(response, batch);
                }
                else throw new RequestFailedException(response);
            }
        }
    }
}

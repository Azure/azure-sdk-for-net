// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Azure;
using Azure.Base.Diagnostics;
using Azure.Base.Http;
using Azure.Base.Http.Pipeline;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.ApplicationModel.Configuration
{
    public partial class ConfigurationClient
    {
        const string ComponentName = "Azure.Configuration";
        const string ComponentVersion = "1.0.0";

        static readonly HttpPipelinePolicy s_defaultRetryPolicy = RetryPolicy.CreateFixed(3, TimeSpan.Zero,
            //429, // Too Many Requests TODO (pri 2): this needs to throttle based on x-ms-retry-after
            500, // Internal Server Error
            503, // Service Unavailable
            504  // Gateway Timeout
        );

        readonly Uri _baseUri;
        readonly string _credential;
        readonly byte[] _secret;
        HttpPipeline _pipeline;

        public static HttpPipelineOptions CreateDefaultPipelineOptions()
        {
            var options = new HttpPipelineOptions(HttpClientTransport.Shared);
            options.LoggingPolicy = LoggingPolicy.Shared;
            options.RetryPolicy = s_defaultRetryPolicy;
            return options;
        }

        public ConfigurationClient(string connectionString)
            : this(connectionString, CreateDefaultPipelineOptions())
        {
        }

        public ConfigurationClient(string connectionString, HttpPipelineOptions options)
        {
            if (connectionString == null) throw new ArgumentNullException(nameof(connectionString));
            if (options == null) throw new ArgumentNullException(nameof(options));

            _pipeline = options.Build(ComponentName, ComponentVersion);
            ParseConnectionString(connectionString, out _baseUri, out _credential, out _secret);
        }

        [KnownException(typeof(HttpRequestException), Message = "The request failed due to an underlying issue such as network connectivity, DNS failure, or timeout.")]
        [HttpError(typeof(RequestFailedException), 412, Message = "Matching item is already in the store")]
        [HttpError(typeof(RequestFailedException), 429, Message = "Too many requests")]
        [UsageErrors(typeof(RequestFailedException), 401, 409, 408, 500, 502, 503, 504)]
        public async Task<Response<ConfigurationSetting>> AddAsync(ConfigurationSetting setting, CancellationToken cancellation = default)
        {
            if (setting == null) throw new ArgumentNullException(nameof(setting));
            if (string.IsNullOrEmpty(setting.Key)) throw new ArgumentNullException($"{nameof(setting)}.{nameof(setting.Key)}");

            Uri uri = BuildUriForKvRoute(setting);

            using (HttpMessage message = _pipeline.CreateMessage(cancellation)) {
                ReadOnlyMemory<byte> content = Serialize(setting);

                message.SetRequestLine(HttpVerb.Put, uri);

                message.AddHeader(IfNoneMatch, "*");
                message.AddHeader(MediaTypeKeyValueApplicationHeader);
                message.AddHeader(HttpHeader.Common.JsonContentType);
                AddClientRequestID(message);
                AddAuthenticationHeaders(message, uri, HttpVerb.Put, content, _secret, _credential);

                message.SetContent(HttpMessageContent.Create(content));

                await _pipeline.SendMessageAsync(message).ConfigureAwait(false);

                var response = message.Response;
                if (response.Status == 200 || response.Status == 201) {
                    return await CreateResponse(response, cancellation);
                }
                else throw new RequestFailedException(response);
            }
        }

        public async Task<Response<ConfigurationSetting>> AddAsync(string key, string value, string label = default, CancellationToken cancellation = default)
        {
            if (string.IsNullOrEmpty(key)) throw new ArgumentNullException($"{nameof(key)}");
            return await AddAsync(new ConfigurationSetting(key, value, label), cancellation);
        }

        public async Task<Response<ConfigurationSetting>> SetAsync(ConfigurationSetting setting, CancellationToken cancellation = default)
        {
            if (setting == null) throw new ArgumentNullException(nameof(setting));
            if (string.IsNullOrEmpty(setting.Key)) throw new ArgumentNullException($"{nameof(setting)}.{nameof(setting.Key)}");

            Uri uri = BuildUriForKvRoute(setting);

            using (HttpMessage message = _pipeline.CreateMessage(cancellation)) {
                ReadOnlyMemory<byte> content = Serialize(setting);

                message.SetRequestLine(HttpVerb.Put, uri);

                message.AddHeader(MediaTypeKeyValueApplicationHeader);
                message.AddHeader(HttpHeader.Common.JsonContentType);
                if (setting.ETag != default)
                {
                    message.AddHeader(IfMatchName, $"\"{setting.ETag.ToString()}\"");
                }

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

        public async Task<Response<ConfigurationSetting>> SetAsync(string key, string value, string label = default, CancellationToken cancellation = default)
        {
            if (string.IsNullOrEmpty(key)) throw new ArgumentNullException($"{nameof(key)}");
            return await SetAsync(new ConfigurationSetting(key, value, label), cancellation);
        }

        public async Task<Response<ConfigurationSetting>> UpdateAsync(ConfigurationSetting setting, CancellationToken cancellation = default)
        {
            if (setting == null) throw new ArgumentNullException(nameof(setting));
            if (string.IsNullOrEmpty(setting.Key)) throw new ArgumentNullException($"{nameof(setting)}.{nameof(setting.Key)}");

            Uri uri = BuildUriForKvRoute(setting);

            using (HttpMessage message = _pipeline.CreateMessage(cancellation)) {
                ReadOnlyMemory<byte> content = Serialize(setting);

                message.SetRequestLine(HttpVerb.Put, uri);

                message.AddHeader(MediaTypeKeyValueApplicationHeader);
                message.AddHeader(HttpHeader.Common.JsonContentType);

                if(setting.ETag != default)
                {
                    message.AddHeader(IfMatchName, $"\"{setting.ETag}\"");
                }
                else
                {
                    message.AddHeader(IfMatchName, "*");
                }

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

        public async Task<Response<ConfigurationSetting>> UpdateAsync(string key, string value, string label = default, CancellationToken cancellation = default)
        {
            if (string.IsNullOrEmpty(key)) throw new ArgumentNullException($"{nameof(key)}");
            return await UpdateAsync(new ConfigurationSetting(key, value, label), cancellation);
        }

        public async Task<Response> DeleteAsync(string key, string label = default, ETag etag = default, CancellationToken cancellation = default)
        {
            if (string.IsNullOrEmpty(key)) throw new ArgumentNullException(nameof(key));

            Uri uri = BuildUriForKvRoute(key, label);

            using (HttpMessage message = _pipeline.CreateMessage(cancellation)) {
                message.SetRequestLine(HttpVerb.Delete, uri);

                if (etag != default)
                {
                    message.AddHeader(IfMatchName, $"\"{etag.ToString()}\"");
                }

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

        public async Task<Response<ConfigurationSetting>> LockAsync(string key, string label = default, CancellationToken cancellation = default)
        {
            if (string.IsNullOrEmpty(key)) throw new ArgumentNullException(nameof(key));

            Uri uri = BuildUriForLocksRoute(key, label);

            using (HttpMessage message = _pipeline.CreateMessage(cancellation)) {
                message.SetRequestLine(HttpVerb.Put, uri);

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

        public async Task<Response<ConfigurationSetting>> UnlockAsync(string key, string label = default, CancellationToken cancellation = default)
        {
            if (string.IsNullOrEmpty(key)) throw new ArgumentNullException(nameof(key));

            Uri uri = BuildUriForLocksRoute(key, label);

            using (HttpMessage message = _pipeline.CreateMessage(cancellation)) {
                message.SetRequestLine(HttpVerb.Delete, uri);

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

        public async Task<Response<ConfigurationSetting>> GetAsync(string key, string label = default, CancellationToken cancellation = default)
        {
            if (string.IsNullOrEmpty(key)) throw new ArgumentNullException($"{nameof(key)}");

            Uri uri = BuildUriForKvRoute(key, label);

            using (HttpMessage message = _pipeline.CreateMessage(cancellation)) {
                message.SetRequestLine(HttpVerb.Get, uri);

                message.AddHeader(MediaTypeKeyValueApplicationHeader);
                message.AddHeader(HttpHeader.Common.JsonContentType);
                AddClientRequestID(message);

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

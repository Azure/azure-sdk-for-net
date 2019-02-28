// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Azure.Base.Diagnostics;
using Azure.Base.Http;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

// TODO (pri 1): Add all functionality from the spec: https://msazure.visualstudio.com/Azure%20AppConfig/Azure%20AppConfig%20Team/_git/AppConfigService?path=%2Fdocs%2Fprotocol&version=GBdev
// TODO (pri 1): Support "List subset of keys" 
// TODO (pri 1): Support "Time-Based Access" 
// TODO (pri 1): Support "KeyValue Revisions"
// TODO (pri 1): Support "Real-time Consistency"
// TODO (pri 2): Add support for filters (fields, label, etc.)
// TODO (pri 2): Make sure the whole object gets deserialized/serialized.
// TODO (pri 3): Add retry policy with automatic throttling
namespace Azure.ApplicationModel.Configuration
{
    public partial class ConfigurationClient
    {
        const string SdkName = "Azure.Configuration";
        const string SdkVersion = "1.0.0";

        readonly Uri _baseUri;
        readonly string _credential;
        readonly byte[] _secret;
        HttpPipeline.Options _options;
        HttpPipeline Pipeline;

        public ConfigurationClient(string connectionString)
            : this(connectionString, options: new HttpPipeline.Options())
        {
        }

        public ConfigurationClient(string connectionString, HttpPipeline.Options options)
        {
            if (connectionString == null) throw new ArgumentNullException(nameof(connectionString));
            if (options == null) throw new ArgumentNullException(nameof(options));

            _options = options;
            Pipeline = HttpPipeline.Create(_options, SdkName, SdkVersion);
            ParseConnectionString(connectionString, out _baseUri, out _credential, out _secret);
        }

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

            using (HttpMessage message = Pipeline.CreateMessage(_options, cancellation)) {
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

                await Pipeline.SendMessageAsync(message).ConfigureAwait(false);

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

            using (HttpMessage message = Pipeline.CreateMessage(_options, cancellation)) {
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

                await Pipeline.SendMessageAsync(message).ConfigureAwait(false);

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

            using (HttpMessage message = Pipeline.CreateMessage(_options, cancellation)) {
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

                await Pipeline.SendMessageAsync(message).ConfigureAwait(false);

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

            using (HttpMessage message = Pipeline.CreateMessage(_options, cancellation)) {
                message.SetRequestLine(HttpVerb.Delete, uri);

                message.AddHeader("Host", uri.Host);
                AddOptionsHeaders(options, message);
                AddClientRequestID(message);
                AddAuthenticationHeaders(message, uri, HttpVerb.Delete, content: default, _secret, _credential);

                await Pipeline.SendMessageAsync(message).ConfigureAwait(false);

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

            using (HttpMessage message = Pipeline.CreateMessage(_options, cancellation)) {
                message.SetRequestLine(HttpVerb.Put, uri);

                message.AddHeader("Host", uri.Host);
                AddOptionsHeaders(options, message);
                AddClientRequestID(message);
                AddAuthenticationHeaders(message, uri, HttpVerb.Put, content: default, _secret, _credential);

                await Pipeline.SendMessageAsync(message).ConfigureAwait(false);

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

            using (HttpMessage message = Pipeline.CreateMessage(_options, cancellation)) {
                message.SetRequestLine(HttpVerb.Delete, uri);

                message.AddHeader("Host", uri.Host);
                AddOptionsHeaders(options, message);
                AddClientRequestID(message);
                AddAuthenticationHeaders(message, uri, HttpVerb.Delete, content: default, _secret, _credential);

                await Pipeline.SendMessageAsync(message).ConfigureAwait(false);

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

            using (HttpMessage message = Pipeline.CreateMessage(_options, cancellation)) {
                message.SetRequestLine(HttpVerb.Get, uri);

                message.AddHeader("Host", uri.Host);
                message.AddHeader(MediaTypeKeyValueApplicationHeader);
                AddOptionsHeaders(options, message);
                AddClientRequestID(message);
                message.AddHeader(HttpHeader.Common.JsonContentType);

                AddAuthenticationHeaders(message, uri, HttpVerb.Get, content: default, _secret, _credential);

                await Pipeline.SendMessageAsync(message).ConfigureAwait(false);

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

            using (HttpMessage message = Pipeline.CreateMessage(_options, cancellation)) {
                message.SetRequestLine(HttpVerb.Get, uri);

                message.AddHeader("Host", uri.Host);
                message.AddHeader(MediaTypeKeyValueApplicationHeader);
                AddOptionsHeaders(batchOptions, message);
                AddClientRequestID(message);
                AddAuthenticationHeaders(message, uri, HttpVerb.Get, content: default, _secret, _credential);

                await Pipeline.SendMessageAsync(message).ConfigureAwait(false);

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

            using (HttpMessage message = Pipeline.CreateMessage(_options, cancellation)) {
                message.SetRequestLine(HttpVerb.Get, uri);

                message.AddHeader("Host", uri.Host);
                message.AddHeader(MediaTypeKeyValueApplicationHeader);
                AddOptionsHeaders(options, message);
                AddClientRequestID(message);
                AddAuthenticationHeaders(message, uri, HttpVerb.Get, content: default, _secret, _credential);

                await Pipeline.SendMessageAsync(message).ConfigureAwait(false);

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

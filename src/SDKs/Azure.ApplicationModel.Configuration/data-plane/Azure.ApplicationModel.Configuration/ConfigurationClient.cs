// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Azure.Base.Diagnostics;
using Azure.Base.Http;
using Azure.Base.Http.Pipeline;

namespace Azure.ApplicationModel.Configuration
{
    public partial class ConfigurationClient
    {
        private readonly Uri _baseUri;
        private readonly HttpPipeline _pipeline;

        public ConfigurationClient(string connectionString)
            : this(connectionString, new ConfigurationClientOptions())
        {
        }

        public ConfigurationClient(string connectionString, ConfigurationClientOptions options)
        {
            if (connectionString == null) throw new ArgumentNullException(nameof(connectionString));
            if (options == null) throw new ArgumentNullException(nameof(options));

            ParseConnectionString(connectionString, out _baseUri, out var credential, out var secret);

            _pipeline = HttpPipeline.Build(options,
                    options.RetryPolicy,
                    ClientRequestIdPolicy.Singleton,
                    new AuthenticationPolicy(credential, secret),
                    options.LoggingPolicy);
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

            using (var request = _pipeline.CreateRequest())
            {
                ReadOnlyMemory<byte> content = Serialize(setting);

                request.SetRequestLine(HttpPipelineMethod.Put, uri);

                request.AddHeader(IfNoneMatch, "*");
                request.AddHeader(MediaTypeKeyValueApplicationHeader);
                request.AddHeader(HttpHeader.Common.JsonContentType);

                request.Content = HttpPipelineRequestContent.Create(content);

                var response = await _pipeline.SendRequestAsync(request, cancellation).ConfigureAwait(false);

                if (response.Status == 200 || response.Status == 201)
                {
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

            using (var request = _pipeline.CreateRequest())
            {
                ReadOnlyMemory<byte> content = Serialize(setting);

                request.SetRequestLine(HttpPipelineMethod.Put, uri);

                request.AddHeader(MediaTypeKeyValueApplicationHeader);
                request.AddHeader(HttpHeader.Common.JsonContentType);

                if (setting.ETag != default)
                {
                    request.AddHeader(IfMatchName, $"\"{setting.ETag.ToString()}\"");
                }

                request.Content = HttpPipelineRequestContent.Create(content);

                var response = await _pipeline.SendRequestAsync(request, cancellation).ConfigureAwait(false);

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

            using (var request = _pipeline.CreateRequest())
            {
                ReadOnlyMemory<byte> content = Serialize(setting);

                request.SetRequestLine(HttpPipelineMethod.Put, uri);

                request.AddHeader(MediaTypeKeyValueApplicationHeader);
                request.AddHeader(HttpHeader.Common.JsonContentType);

                if (setting.ETag != default)
                {
                    request.AddHeader(IfMatchName, $"\"{setting.ETag}\"");
                }
                else
                {
                    request.AddHeader(IfMatchName, "*");
                }

                request.Content = HttpPipelineRequestContent.Create(content);

                var response = await _pipeline.SendRequestAsync(request, cancellation).ConfigureAwait(false);

                if (response.Status == 200)
                {
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

            using (var request = _pipeline.CreateRequest())
            {
                request.SetRequestLine(HttpPipelineMethod.Delete, uri);

                if (etag != default)
                {
                    request.AddHeader(IfMatchName, $"\"{etag.ToString()}\"");
                }

                var response = await _pipeline.SendRequestAsync(request, cancellation).ConfigureAwait(false);

                if (response.Status == 200 || response.Status == 204)
                {
                    return response;
                }
                else throw new RequestFailedException(response);
            }
        }

        public async Task<Response<ConfigurationSetting>> LockAsync(string key, string label = default, CancellationToken cancellation = default)
        {
            if (string.IsNullOrEmpty(key)) throw new ArgumentNullException(nameof(key));

            Uri uri = BuildUriForLocksRoute(key, label);

            using (var request = _pipeline.CreateRequest())
            {
                request.SetRequestLine(HttpPipelineMethod.Put, uri);

                var response = await _pipeline.SendRequestAsync(request, cancellation).ConfigureAwait(false);

                if (response.Status == 200)
                {
                    return await CreateResponse(response, cancellation);
                }
                else throw new RequestFailedException(response);
            }
        }

        public async Task<Response<ConfigurationSetting>> UnlockAsync(string key, string label = default, CancellationToken cancellation = default)
        {
            if (string.IsNullOrEmpty(key)) throw new ArgumentNullException(nameof(key));

            Uri uri = BuildUriForLocksRoute(key, label);

            using (var request = _pipeline.CreateRequest())
            {
                request.SetRequestLine(HttpPipelineMethod.Delete, uri);



                var response = await _pipeline.SendRequestAsync(request, cancellation).ConfigureAwait(false);
                if (response.Status == 200)
                {
                    return await CreateResponse(response, cancellation);
                }
                else throw new RequestFailedException(response);
            }
        }

        public async Task<Response<ConfigurationSetting>> GetAsync(string key, string label = default, DateTimeOffset acceptDateTime = default, CancellationToken cancellation = default)
        {
            if (string.IsNullOrEmpty(key)) throw new ArgumentNullException($"{nameof(key)}");

            Uri uri = BuildUriForKvRoute(key, label);

            using (var request = _pipeline.CreateRequest())
            {
                request.SetRequestLine(HttpPipelineMethod.Get, uri);

                request.AddHeader(MediaTypeKeyValueApplicationHeader);
                if (acceptDateTime != default)
                {
                    var dateTime = acceptDateTime.UtcDateTime.ToString(AcceptDateTimeFormat);
                    request.AddHeader(AcceptDatetimeHeader, dateTime);
                }
                request.AddHeader(HttpHeader.Common.JsonContentType);

                var response = await _pipeline.SendRequestAsync(request, cancellation).ConfigureAwait(false);

                if (response.Status == 200) {
                    return await CreateResponse(response, cancellation);
                }
                else throw new RequestFailedException(response);
            }
        }

        public async Task<Response<SettingBatch>> GetBatchAsync(SettingSelector selector, CancellationToken cancellation = default)
        {
            var uri = BuildUriForGetBatch(selector);

            using (var request = _pipeline.CreateRequest())
            {
                request.SetRequestLine(HttpPipelineMethod.Get, uri);

                request.AddHeader(MediaTypeKeyValueApplicationHeader);
                if (selector.AsOf.HasValue)
                {
                    var dateTime = selector.AsOf.Value.UtcDateTime.ToString(AcceptDateTimeFormat);
                    request.AddHeader(AcceptDatetimeHeader, dateTime);
                }
                var response = await _pipeline.SendRequestAsync(request, cancellation).ConfigureAwait(false);

                if (response.Status == 200 || response.Status == 206 /* partial */)
                {
                    var batch = await ConfigurationServiceSerializer.ParseBatchAsync(response, selector, cancellation);
                    return new Response<SettingBatch>(response, batch);
                }
                else throw new RequestFailedException(response);
            }
        }

        public async Task<Response<SettingBatch>> GetRevisionsAsync(SettingSelector selector, CancellationToken cancellation = default)
        {
            var uri = BuildUriForRevisions(selector);

            using (var request = _pipeline.CreateRequest())
            {
                request.SetRequestLine(HttpPipelineMethod.Get, uri);

                request.AddHeader(MediaTypeKeyValueApplicationHeader);
                if (selector.AsOf.HasValue)
                {
                    var dateTime = selector.AsOf.Value.UtcDateTime.ToString(AcceptDateTimeFormat);
                    request.AddHeader(AcceptDatetimeHeader, dateTime);
                }
                var response = await _pipeline.SendRequestAsync(request, cancellation).ConfigureAwait(false);

                if (response.Status == 200 || response.Status == 206 /* partial */)
                {
                    var batch = await ConfigurationServiceSerializer.ParseBatchAsync(response, selector, cancellation);
                    return new Response<SettingBatch>(response, batch);
                }
                else throw new RequestFailedException(response);
            }
        }
    }
}

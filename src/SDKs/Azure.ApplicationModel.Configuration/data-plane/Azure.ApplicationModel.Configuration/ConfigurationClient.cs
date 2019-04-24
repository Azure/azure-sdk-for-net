// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Diagnostics;
using Azure.Core.Pipeline;
using Azure.Core.Pipeline.Policies;

namespace Azure.ApplicationModel.Configuration
{
    /// <summary>
    /// ConfigurationClient can be used for all operations with a <see cref="ConfigurationSetting"/> in the Azure Configuration Store.
    /// </summary>
    public partial class ConfigurationClient
    {
        private readonly Uri _baseUri;
        private readonly HttpPipeline _pipeline;


        /// <summary>
        /// Protected constructor to allow mocking
        /// </summary>
        protected ConfigurationClient()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationClient"/>.
        /// </summary>
        /// <param name="connectionString">Connection string with authentication option and related parameters.</param>
        public ConfigurationClient(string connectionString)
            : this(connectionString, new ConfigurationClientOptions())
        {
        }

        /// <summary>
        /// Creates a <see cref="ConfigurationClient"/> that sends requests to the configuration store.
        /// </summary>
        /// <param name="connectionString">Connection string with authentication option and related parameters.</param>
        /// <param name="options">Options that allow configure the management of the request sent to the configuration store.</param>
        public ConfigurationClient(string connectionString, ConfigurationClientOptions options)
        {
            if (connectionString == null) throw new ArgumentNullException(nameof(connectionString));
            if (options == null) throw new ArgumentNullException(nameof(options));

            ParseConnectionString(connectionString, out _baseUri, out var credential, out var secret);

            _pipeline = HttpPipeline.Build(options,
                    options.ResponseClassifier,
                    options.RetryPolicy,
                    ClientRequestIdPolicy.Singleton,
                    new AuthenticationPolicy(credential, secret),
                    options.LoggingPolicy,
                    BufferResponsePolicy.Singleton);
        }

        /// <summary>
        /// Creates a <see cref="ConfigurationSetting"/> only if the setting does not already exist in the configuration store.
        /// </summary>
        /// <param name="setting"><see cref="ConfigurationSetting"/> to create.</param>
        /// <param name="cancellation">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual async Task<Response<ConfigurationSetting>> AddAsync(ConfigurationSetting setting, CancellationToken cancellation = default)
        {
            if (setting == null) throw new ArgumentNullException(nameof(setting));
            if (string.IsNullOrEmpty(setting.Key)) throw new ArgumentNullException($"{nameof(setting)}.{nameof(setting.Key)}");

            using (var request = _pipeline.CreateRequest())
            {
                ReadOnlyMemory<byte> content = Serialize(setting);

                request.Method = HttpPipelineMethod.Put;

                BuildUriForKvRoute(request.UriBuilder, setting);

                request.Headers.Add(IfNoneMatch, "*");
                request.Headers.Add(MediaTypeKeyValueApplicationHeader);
                request.Headers.Add(HttpHeader.Common.JsonContentType);

                request.Content = HttpPipelineRequestContent.Create(content);

                var response = await _pipeline.SendRequestAsync(request, cancellation).ConfigureAwait(false);

                if (response.Status == 200 || response.Status == 201)
                {
                    return await CreateResponse(response, cancellation);
                }
                else throw new RequestFailedException(response);
            }
        }

        /// <summary>
        /// Creates a <see cref="ConfigurationSetting"/> only if the setting does not already exist in the configuration store.
        /// </summary>
        /// <param name="key">The primary identifier of a configuration setting.</param>
        /// <param name="value">The value of the configuration setting.</param>
        /// <param name="label">The value used to group configuration settings.</param>
        /// <param name="cancellation">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual async Task<Response<ConfigurationSetting>> AddAsync(string key, string value, string label = default, CancellationToken cancellation = default)
        {
            if (string.IsNullOrEmpty(key)) throw new ArgumentNullException($"{nameof(key)}");
            return await AddAsync(new ConfigurationSetting(key, value, label), cancellation);
        }

        /// <summary>
        /// Creates a <see cref="ConfigurationSetting"/> if it doesn't exist or overrides an existing setting in the configuration store.
        /// </summary>
        /// <param name="setting"><see cref="ConfigurationSetting"/> to create.</param>
        /// <param name="cancellation">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual async Task<Response<ConfigurationSetting>> SetAsync(ConfigurationSetting setting, CancellationToken cancellation = default)
        {
            if (setting == null) throw new ArgumentNullException(nameof(setting));
            if (string.IsNullOrEmpty(setting.Key)) throw new ArgumentNullException($"{nameof(setting)}.{nameof(setting.Key)}");

            using (var request = _pipeline.CreateRequest())
            {
                ReadOnlyMemory<byte> content = Serialize(setting);

                request.Method = HttpPipelineMethod.Put;
                BuildUriForKvRoute(request.UriBuilder, setting);
                request.Headers.Add(MediaTypeKeyValueApplicationHeader);
                request.Headers.Add(HttpHeader.Common.JsonContentType);

                if (setting.ETag != default)
                {
                    request.Headers.Add(IfMatchName, $"\"{setting.ETag.ToString()}\"");
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

        /// <summary>
        /// Creates a <see cref="ConfigurationSetting"/> if it doesn't exist or overrides an existing setting in the configuration store.
        /// </summary>
        /// <param name="key">The primary identifier of a configuration setting.</param>
        /// <param name="value">The value of the configuration setting.</param>
        /// <param name="label">The value used to group configuration settings.</param>
        /// <param name="cancellation">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual async Task<Response<ConfigurationSetting>> SetAsync(string key, string value, string label = default, CancellationToken cancellation = default)
        {
            if (string.IsNullOrEmpty(key)) throw new ArgumentNullException($"{nameof(key)}");
            return await SetAsync(new ConfigurationSetting(key, value, label), cancellation);
        }

        /// <summary>
        /// Updates an existing <see cref="ConfigurationSetting"/> in the configuration store.
        /// </summary>
        /// <param name="setting"><see cref="ConfigurationSetting"/> to update.</param>
        /// <param name="cancellation">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual async Task<Response<ConfigurationSetting>> UpdateAsync(ConfigurationSetting setting, CancellationToken cancellation = default)
        {
            if (setting == null) throw new ArgumentNullException(nameof(setting));
            if (string.IsNullOrEmpty(setting.Key)) throw new ArgumentNullException($"{nameof(setting)}.{nameof(setting.Key)}");

            using (var request = _pipeline.CreateRequest())
            {
                ReadOnlyMemory<byte> content = Serialize(setting);

                request.Method = HttpPipelineMethod.Put;
                BuildUriForKvRoute(request.UriBuilder, setting);
                request.Headers.Add(MediaTypeKeyValueApplicationHeader);
                request.Headers.Add(HttpHeader.Common.JsonContentType);

                if (setting.ETag != default)
                {
                    request.Headers.Add(IfMatchName, $"\"{setting.ETag}\"");
                }
                else
                {
                    request.Headers.Add(IfMatchName, "*");
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

        /// <summary>
        /// Updates an existing <see cref="ConfigurationSetting"/> in the configuration store.
        /// </summary>
        /// <param name="key">The primary identifier of a configuration setting.</param>
        /// <param name="value">The value of the configuration setting.</param>
        /// <param name="label">The value used to group configuration settings.</param>
        /// <param name="cancellation">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual async Task<Response<ConfigurationSetting>> UpdateAsync(string key, string value, string label = default, CancellationToken cancellation = default)
        {
            if (string.IsNullOrEmpty(key)) throw new ArgumentNullException($"{nameof(key)}");
            return await UpdateAsync(new ConfigurationSetting(key, value, label), cancellation);
        }

        /// <summary>
        /// Deletes an existing <see cref="ConfigurationSetting"/> in the configuration store.
        /// </summary>
        /// <param name="key">The primary identifier of a configuration setting.</param>
        /// <param name="label">The value used to group configuration settings.</param>
        /// <param name="etag">The value of an etag indicates the state of a configuration setting within a configuration store.
        /// If it is specified, the configuration setting is only deleted if etag value matches etag value in the configuration store.
        /// If no etag value is passed in, then the setting is always deleted.</param>
        /// <param name="cancellation">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual async Task<Response> DeleteAsync(string key, string label = default, ETag etag = default, CancellationToken cancellation = default)
        {
            if (string.IsNullOrEmpty(key)) throw new ArgumentNullException(nameof(key));

            using (var request = _pipeline.CreateRequest())
            {
                request.Method  = HttpPipelineMethod.Delete;
                BuildUriForKvRoute(request.UriBuilder, key, label);

                if (etag != default)
                {
                    request.Headers.Add(IfMatchName, $"\"{etag.ToString()}\"");
                }

                var response = await _pipeline.SendRequestAsync(request, cancellation).ConfigureAwait(false);

                if (response.Status == 200 || response.Status == 204)
                {
                    return response;
                }
                else throw new RequestFailedException(response);
            }
        }

        /// <summary>
        /// Retrieve an existing <see cref="ConfigurationSetting"/> from the configuration store.
        /// </summary>
        /// <param name="key">The primary identifier of a configuration setting.</param>
        /// <param name="label">The value used to group configuration settings</param>
        /// <param name="acceptDateTime">The setting will be retrieved exactly as it existed at the provided time.</param>
        /// <param name="cancellation">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual async Task<Response<ConfigurationSetting>> GetAsync(string key, string label = default, DateTimeOffset acceptDateTime = default, CancellationToken cancellation = default)
        {
            if (string.IsNullOrEmpty(key)) throw new ArgumentNullException($"{nameof(key)}");

            using (var request = _pipeline.CreateRequest())
            {
                request.Method = HttpPipelineMethod.Get;
                BuildUriForKvRoute(request.UriBuilder, key, label);
                request.Headers.Add(MediaTypeKeyValueApplicationHeader);

                if (acceptDateTime != default)
                {
                    var dateTime = acceptDateTime.UtcDateTime.ToString(AcceptDateTimeFormat);
                    request.Headers.Add(AcceptDatetimeHeader, dateTime);
                }
                request.Headers.Add(HttpHeader.Common.JsonContentType);

                var response = await _pipeline.SendRequestAsync(request, cancellation).ConfigureAwait(false);

                if (response.Status == 200) {
                    return await CreateResponse(response, cancellation);
                }
                else throw new RequestFailedException(response);
            }
        }

        /// <summary>
        /// Fetches the <see cref="ConfigurationSetting"/> from the configuration store that match the options selected in the <see cref="SettingSelector"/>.
        /// </summary>
        /// <param name="selector">Set of options for selecting settings from the configuration store</param>
        /// <param name="cancellation">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual async Task<Response<SettingBatch>> GetBatchAsync(SettingSelector selector, CancellationToken cancellation = default)
        {
            using (var request = _pipeline.CreateRequest())
            {
                request.Method = HttpPipelineMethod.Get;
                BuildUriForGetBatch(request.UriBuilder, selector);
                request.Headers.Add(MediaTypeKeyValueApplicationHeader);
                if (selector.AsOf.HasValue)
                {
                    var dateTime = selector.AsOf.Value.UtcDateTime.ToString(AcceptDateTimeFormat);
                    request.Headers.Add(AcceptDatetimeHeader, dateTime);
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

        /// <summary>
        /// Lists chronological/historical representation of <see cref="ConfigurationSetting"/> from the configuration store that match the options selected in the <see cref="SettingSelector"/>.
        /// </summary>
        /// <remarks>Revisions are provided in descending order from their respective <see cref="ConfigurationSetting.LastModified"/> date.</remarks>
        /// <param name="selector">Set of options for selecting settings from the configuration store</param>
        /// <param name="cancellation">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual async Task<Response<SettingBatch>> GetRevisionsAsync(SettingSelector selector, CancellationToken cancellation = default)
        {
            using (var request = _pipeline.CreateRequest())
            {
                request.Method = HttpPipelineMethod.Get;
                BuildUriForRevisions(request.UriBuilder, selector);
                request.Headers.Add(MediaTypeKeyValueApplicationHeader);
                if (selector.AsOf.HasValue)
                {
                    var dateTime = selector.AsOf.Value.UtcDateTime.ToString(AcceptDateTimeFormat);
                    request.Headers.Add(AcceptDatetimeHeader, dateTime);
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

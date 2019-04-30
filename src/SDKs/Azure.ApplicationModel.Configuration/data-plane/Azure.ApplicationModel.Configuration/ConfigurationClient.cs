// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core.Pipeline.Policies;

namespace Azure.ApplicationModel.Configuration
{
    /// <summary>
    /// The client to use for interacting with the Azure Configuration Store.
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
        /// <param name="options">Options that allow to configure the management of the request sent to the configuration store.</param>
        public ConfigurationClient(string connectionString, ConfigurationClientOptions options)
        {
            if (connectionString == null)
                throw new ArgumentNullException(nameof(connectionString));
            if (options == null)
                throw new ArgumentNullException(nameof(options));

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
        /// <param name="key">The primary identifier of a configuration setting.</param>
        /// <param name="value">The value of the configuration setting.</param>
        /// <param name="label">The value used to group configuration settings.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual async Task<Response<ConfigurationSetting>> AddAsync(string key, string value, string label = default, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(key)) throw new ArgumentNullException($"{nameof(key)}");
            return await AddAsync(new ConfigurationSetting(key, value, label), cancellationToken);
        }

        /// <summary>
        /// Creates a <see cref="ConfigurationSetting"/> only if the setting does not already exist in the configuration store.
        /// </summary>
        /// <param name="key">The primary identifier of a configuration setting.</param>
        /// <param name="value">The value of the configuration setting.</param>
        /// <param name="label">The value used to group configuration settings.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual Response<ConfigurationSetting> Add(string key, string value, string label = default, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(key)) throw new ArgumentNullException($"{nameof(key)}");
            return Add(new ConfigurationSetting(key, value, label), cancellationToken);
        }

        /// <summary>
        /// Creates a <see cref="ConfigurationSetting"/> only if the setting does not already exist in the configuration store.
        /// </summary>
        /// <param name="setting"><see cref="ConfigurationSetting"/> to create.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual async Task<Response<ConfigurationSetting>> AddAsync(ConfigurationSetting setting, CancellationToken cancellationToken = default)
        {
            using (Request request = CreateAddRequest(setting))
            {
                Response response = await _pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);

                switch (response.Status)
                {
                    case 200:
                    case 201:
                        return await CreateResponseAsync(response, cancellationToken);
                    default:
                        throw new RequestFailedException(response);
                }
            }
        }

        /// <summary>
        /// Creates a <see cref="ConfigurationSetting"/> only if the setting does not already exist in the configuration store.
        /// </summary>
        /// <param name="setting"><see cref="ConfigurationSetting"/> to create.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual Response<ConfigurationSetting> Add(ConfigurationSetting setting, CancellationToken cancellationToken = default)
        {
            using (Request request = CreateAddRequest(setting))
            {
                Response response = _pipeline.SendRequest(request, cancellationToken);

                switch (response.Status)
                {
                    case 200:
                    case 201:
                        return CreateResponse(response, cancellationToken);
                    default:
                        throw new RequestFailedException(response);
                }
            }
        }

        private Request CreateAddRequest(ConfigurationSetting setting)
        {
            if (setting == null)
                throw new ArgumentNullException(nameof(setting));
            if (string.IsNullOrEmpty(setting.Key))
                throw new ArgumentNullException($"{nameof(setting)}.{nameof(setting.Key)}");

            var request = _pipeline.CreateRequest();

            ReadOnlyMemory<byte> content = Serialize(setting);

            request.Method = HttpPipelineMethod.Put;

            BuildUriForKvRoute(request.UriBuilder, setting);

            request.Headers.Add(IfNoneMatch, "*");
            request.Headers.Add(MediaTypeKeyValueApplicationHeader);
            request.Headers.Add(HttpHeader.Common.JsonContentType);
            request.Content = HttpPipelineRequestContent.Create(content);

            return request;
        }

        /// <summary>
        /// Creates a <see cref="ConfigurationSetting"/> if it doesn't exist or overrides an existing setting in the configuration store.
        /// </summary>
        /// <param name="key">The primary identifier of a configuration setting.</param>
        /// <param name="value">The value of the configuration setting.</param>
        /// <param name="label">The value used to group configuration settings.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual async Task<Response<ConfigurationSetting>> SetAsync(string key, string value, string label = default, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(key)) throw new ArgumentNullException($"{nameof(key)}");
            return await SetAsync(new ConfigurationSetting(key, value, label), cancellationToken);
        }

        /// <summary>
        /// Creates a <see cref="ConfigurationSetting"/> if it doesn't exist or overrides an existing setting in the configuration store.
        /// </summary>
        /// <param name="key">The primary identifier of a configuration setting.</param>
        /// <param name="value">The value of the configuration setting.</param>
        /// <param name="label">The value used to group configuration settings.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual Response<ConfigurationSetting> Set(string key, string value, string label = default, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(key)) throw new ArgumentNullException($"{nameof(key)}");
            return Set(new ConfigurationSetting(key, value, label), cancellationToken);
        }

        /// <summary>
        /// Creates a <see cref="ConfigurationSetting"/> if it doesn't exist or overrides an existing setting in the configuration store.
        /// </summary>
        /// <param name="setting"><see cref="ConfigurationSetting"/> to create.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual async Task<Response<ConfigurationSetting>> SetAsync(ConfigurationSetting setting, CancellationToken cancellationToken = default)
        {
            using (Request request = CreateSetRequest(setting))
            {
                Response response = await _pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);

                switch (response.Status)
                {
                    case 200:
                        return await CreateResponseAsync(response, cancellationToken);
                    case 409:
                        throw new RequestFailedException(response, "The setting is locked");
                    default:
                        throw new RequestFailedException(response);
                }
            }
        }

        /// <summary>
        /// Creates a <see cref="ConfigurationSetting"/> if it doesn't exist or overrides an existing setting in the configuration store.
        /// </summary>
        /// <param name="setting"><see cref="ConfigurationSetting"/> to create.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual Response<ConfigurationSetting> Set(ConfigurationSetting setting, CancellationToken cancellationToken = default)
        {
            using (Request request = CreateSetRequest(setting))
            {
                var response = _pipeline.SendRequest(request, cancellationToken);

                switch (response.Status)
                {
                    case 200:
                        return CreateResponse(response, cancellationToken);
                    case 409:
                        throw new RequestFailedException(response, "The setting is locked");
                    default:
                        throw new RequestFailedException(response);
                }
            }
        }

        private Request CreateSetRequest(ConfigurationSetting setting)
        {
            if (setting == null)
                throw new ArgumentNullException(nameof(setting));
            if (string.IsNullOrEmpty(setting.Key))
                throw new ArgumentNullException($"{nameof(setting)}.{nameof(setting.Key)}");

            Request request = _pipeline.CreateRequest();
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
            return request;
        }

        /// <summary>
        /// Updates an existing <see cref="ConfigurationSetting"/> in the configuration store.
        /// </summary>
        /// <param name="key">The primary identifier of a configuration setting.</param>
        /// <param name="value">The value of the configuration setting.</param>
        /// <param name="label">The value used to group configuration settings.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual async Task<Response<ConfigurationSetting>> UpdateAsync(string key, string value, string label = default, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(key))
                throw new ArgumentNullException($"{nameof(key)}");
            return await UpdateAsync(new ConfigurationSetting(key, value, label), cancellationToken);
        }


        /// <summary>
        /// Updates an existing <see cref="ConfigurationSetting"/> in the configuration store.
        /// </summary>
        /// <param name="key">The primary identifier of a configuration setting.</param>
        /// <param name="value">The value of the configuration setting.</param>
        /// <param name="label">The value used to group configuration settings.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual Response<ConfigurationSetting> Update(string key, string value, string label = default, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(key))
                throw new ArgumentNullException($"{nameof(key)}");
            return Update(new ConfigurationSetting(key, value, label), cancellationToken);
        }

        /// <summary>
        /// Updates an existing <see cref="ConfigurationSetting"/> in the configuration store.
        /// </summary>
        /// <param name="setting"><see cref="ConfigurationSetting"/> to update.</param>
        /// <param name="cancellation">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual async Task<Response<ConfigurationSetting>> UpdateAsync(ConfigurationSetting setting, CancellationToken cancellation = default)
        {
            using (Request request = CreateUpdateRequest(setting))
            {
                Response response = await _pipeline.SendRequestAsync(request, cancellation).ConfigureAwait(false);

                switch (response.Status)
                {
                    case 200:
                        return await CreateResponseAsync(response, cancellation);
                    default:
                        throw new RequestFailedException(response);
                }
            }
        }

        /// <summary>
        /// Updates an existing <see cref="ConfigurationSetting"/> in the configuration store.
        /// </summary>
        /// <param name="setting"><see cref="ConfigurationSetting"/> to update.</param>
        /// <param name="cancellation">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual Response<ConfigurationSetting> Update(ConfigurationSetting setting, CancellationToken cancellation = default)
        {
            using (Request request = CreateUpdateRequest(setting))
            {
                Response response = _pipeline.SendRequest(request, cancellation);

                switch (response.Status)
                {
                    case 200:
                        return CreateResponse(response, cancellation);
                    default:
                        throw new RequestFailedException(response);
                }
            }
        }

        private Request CreateUpdateRequest(ConfigurationSetting setting)
        {
            if (setting == null)
                throw new ArgumentNullException(nameof(setting));
            if (string.IsNullOrEmpty(setting.Key))
                throw new ArgumentNullException($"{nameof(setting)}.{nameof(setting.Key)}");

            Request request = _pipeline.CreateRequest();
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
            return request;
        }

        /// <summary>
        /// Deletes an existing <see cref="ConfigurationSetting"/> in the configuration store.
        /// </summary>
        /// <param name="key">The primary identifier of a configuration setting.</param>
        /// <param name="label">The value used to group configuration settings.</param>
        /// <param name="etag">The value of an etag indicates the state of a configuration setting within a configuration store.
        /// If it is specified, the configuration setting is only deleted if etag value matches etag value in the configuration store.
        /// If no etag value is passed in, then the setting is always deleted.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual async Task<Response> DeleteAsync(string key, string label = default, ETag etag = default, CancellationToken cancellationToken = default)
        {
            using (Request request = CreateDeleteRequest(key, label, etag))
            {
                Response response = await _pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);

                switch (response.Status)
                {
                    case 200:
                    case 204:
                        return response;
                    default:
                        throw new RequestFailedException(response);
                }
            }
        }

        /// <summary>
        /// Deletes an existing <see cref="ConfigurationSetting"/> in the configuration store.
        /// </summary>
        /// <param name="key">The primary identifier of a configuration setting.</param>
        /// <param name="label">The value used to group configuration settings.</param>
        /// <param name="etag">The value of an etag indicates the state of a configuration setting within a configuration store.
        /// If it is specified, the configuration setting is only deleted if etag value matches etag value in the configuration store.
        /// If no etag value is passed in, then the setting is always deleted.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual Response Delete(string key, string label = default, ETag etag = default, CancellationToken cancellationToken = default)
        {
            using (Request request = CreateDeleteRequest(key, label, etag))
            {
                Response response = _pipeline.SendRequest(request, cancellationToken);

                switch (response.Status)
                {
                    case 200:
                    case 204:
                        return response;
                    default:
                        throw new RequestFailedException(response);
                }
            }
        }

        private Request CreateDeleteRequest(string key, string label, ETag etag)
        {
            if (string.IsNullOrEmpty(key))
                throw new ArgumentNullException(nameof(key));

            Request request = _pipeline.CreateRequest();
            request.Method = HttpPipelineMethod.Delete;
            BuildUriForKvRoute(request.UriBuilder, key, label);

            if (etag != default)
            {
                request.Headers.Add(IfMatchName, $"\"{etag.ToString()}\"");
            }

            return request;
        }

        /// <summary>
        /// Retrieve an existing <see cref="ConfigurationSetting"/> from the configuration store.
        /// </summary>
        /// <param name="key">The primary identifier of a configuration setting.</param>
        /// <param name="label">The value used to group configuration settings.</param>
        /// <param name="acceptDateTime">The setting will be retrieved exactly as it existed at the provided time.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual async Task<Response<ConfigurationSetting>> GetAsync(string key, string label = default, DateTimeOffset acceptDateTime = default, CancellationToken cancellationToken = default)
        {
            using (Request request = CreateGetRequest(key, label, acceptDateTime))
            {
                Response response = await _pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);

                switch (response.Status)
                {
                    case 200:
                        return await CreateResponseAsync(response, cancellationToken);
                    default:
                        throw new RequestFailedException(response);
                }
            }
        }

        /// <summary>
        /// Retrieve an existing <see cref="ConfigurationSetting"/> from the configuration store.
        /// </summary>
        /// <param name="key">The primary identifier of a configuration setting.</param>
        /// <param name="label">The value used to group configuration settings.</param>
        /// <param name="acceptDateTime">The setting will be retrieved exactly as it existed at the provided time.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual Response<ConfigurationSetting> Get(string key, string label = default, DateTimeOffset acceptDateTime = default, CancellationToken cancellationToken = default)
        {
            using (Request request = CreateGetRequest(key, label, acceptDateTime))
            {
                Response response = _pipeline.SendRequest(request, cancellationToken);

                switch (response.Status)
                {
                    case 200:
                        return CreateResponse(response, cancellationToken);
                    default:
                        throw new RequestFailedException(response);
                }
            }
        }

        private Request CreateGetRequest(string key, string label, DateTimeOffset acceptDateTime)
        {
            if (string.IsNullOrEmpty(key))
                throw new ArgumentNullException($"{nameof(key)}");

            Request request = _pipeline.CreateRequest();
            request.Method = HttpPipelineMethod.Get;
            BuildUriForKvRoute(request.UriBuilder, key, label);
            request.Headers.Add(MediaTypeKeyValueApplicationHeader);

            if (acceptDateTime != default)
            {
                var dateTime = acceptDateTime.UtcDateTime.ToString(AcceptDateTimeFormat);
                request.Headers.Add(AcceptDatetimeHeader, dateTime);
            }

            request.Headers.Add(HttpHeader.Common.JsonContentType);
            return request;
        }

        /// <summary>
        /// Fetches the <see cref="ConfigurationSetting"/> from the configuration store that match the options selected in the <see cref="SettingSelector"/>.
        /// </summary>
        /// <param name="selector">Set of options for selecting settings from the configuration store.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual async Task<Response<SettingBatch>> GetBatchAsync(SettingSelector selector, CancellationToken cancellationToken = default)
        {
            using (Request request = CreateBatchRequest(selector))
            {
                Response response = await _pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);

                switch (response.Status)
                {
                    case 200:
                    case 206:
                        return new Response<SettingBatch>(response, await ConfigurationServiceSerializer.ParseBatchAsync(response, selector, cancellationToken));
                    default:
                        throw new RequestFailedException(response);
                }
            }

        }

        /// <summary>
        /// Fetches the <see cref="ConfigurationSetting"/> from the configuration store that match the options selected in the <see cref="SettingSelector"/>.
        /// </summary>
        /// <param name="selector">Set of options for selecting settings from the configuration store.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual Response<SettingBatch> GetBatch(SettingSelector selector, CancellationToken cancellationToken = default)
        {
            using (Request request = CreateBatchRequest(selector))
            {
                Response response = _pipeline.SendRequest(request, cancellationToken);

                switch (response.Status)
                {
                    case 200:
                    case 206:
                        return new Response<SettingBatch>(response, ConfigurationServiceSerializer.ParseBatch(response, selector, cancellationToken));
                    default:
                        throw new RequestFailedException(response);
                }
            }
        }

        private Request CreateBatchRequest(SettingSelector selector)
        {
            Request request = _pipeline.CreateRequest();
            request.Method = HttpPipelineMethod.Get;
            BuildUriForGetBatch(request.UriBuilder, selector);
            request.Headers.Add(MediaTypeKeyValueApplicationHeader);
            if (selector.AsOf.HasValue)
            {
                var dateTime = selector.AsOf.Value.UtcDateTime.ToString(AcceptDateTimeFormat);
                request.Headers.Add(AcceptDatetimeHeader, dateTime);
            }

            return request;
        }

        /// <summary>
        /// Lists chronological/historical representation of <see cref="ConfigurationSetting"/> from the configuration store that match the options selected in the <see cref="SettingSelector"/>.
        /// </summary>
        /// <remarks>Revisions are provided in descending order from their respective <see cref="ConfigurationSetting.LastModified"/> date.</remarks>
        /// <param name="selector">Set of options for selecting settings from the configuration store.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual async Task<Response<SettingBatch>> GetRevisionsAsync(SettingSelector selector, CancellationToken cancellationToken = default)
        {
            using (Request request = CreateGetRevisionsRequest(selector))
            {
                Response response = await _pipeline.SendRequestAsync(request, cancellationToken).ConfigureAwait(false);
                switch (response.Status)
                {
                    case 200:
                    case 206:
                    {
                        return new Response<SettingBatch>(response, await ConfigurationServiceSerializer.ParseBatchAsync(response, selector, cancellationToken));
                    }
                    default:
                        throw new RequestFailedException(response);
                }
            }
        }

        /// <summary>
        /// Lists chronological/historical representation of <see cref="ConfigurationSetting"/> from the configuration store that match the options selected in the <see cref="SettingSelector"/>.
        /// </summary>
        /// <remarks>Revisions are provided in descending order from their respective <see cref="ConfigurationSetting.LastModified"/> date.</remarks>
        /// <param name="selector">Set of options for selecting settings from the configuration store.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/> controlling the request lifetime.</param>
        public virtual Response<SettingBatch> GetRevisions(SettingSelector selector, CancellationToken cancellationToken = default)
        {
            using (Request request = CreateGetRevisionsRequest(selector))
            {
                Response response = _pipeline.SendRequest(request, cancellationToken);
                switch (response.Status)
                {
                    case 200:
                    case 206:
                    {
                        return new Response<SettingBatch>(response, ConfigurationServiceSerializer.ParseBatch(response, selector, cancellationToken));
                    }
                    default:
                        throw new RequestFailedException(response);
                }
            }
        }

        private Request CreateGetRevisionsRequest(SettingSelector selector)
        {
            var request = _pipeline.CreateRequest();
            request.Method = HttpPipelineMethod.Get;
            BuildUriForRevisions(request.UriBuilder, selector);
            request.Headers.Add(MediaTypeKeyValueApplicationHeader);
            if (selector.AsOf.HasValue)
            {
                var dateTime = selector.AsOf.Value.UtcDateTime.ToString(AcceptDateTimeFormat);
                request.Headers.Add(AcceptDatetimeHeader, dateTime);
            }

            return request;
        }
    }
}

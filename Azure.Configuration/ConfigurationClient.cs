using Azure.Core;
using Azure.Core.Net;
using System;
using System.Threading;
using System.Threading.Tasks;

// TODO (pri 1): Add all functionality from the spec: https://msazure.visualstudio.com/Azure%20AppConfig/Azure%20AppConfig%20Team/_git/AppConfigService?path=%2Fdocs%2Fprotocol&version=GBdev
// TODO (pri 1): Support "List subset of keys" 
// TODO (pri 1): Support "Time-Based Access" 
// TODO (pri 1): Support "KeyValue Revisions"
// TODO (pri 1): Support "Real-time Consistency"
// TODO (pri 2): Add retry policy with automatic throttling
// TODO (pri 2): Add support for filters (fields, label, etc.)
// TODO (pri 2): Make sure the whole object gets deserialized/serialized.
namespace Azure.Configuration
{
    public partial class ConfigurationClient
    {
        const string SdkName = "Azure.Configuration";
        const string SdkVersion = "1.0.0";
        
        readonly Uri _baseUri;
        readonly string _credential;
        readonly byte[] _secret;
        PipelineOptions _options;
        ClientPipeline Pipeline;

        public ConfigurationClient(string connectionString) 
            : this(connectionString, options : new PipelineOptions())
        {
        }

        public ConfigurationClient(string connectionString, PipelineOptions options)
        {
            _options = options;
            Pipeline = ClientPipeline.Create(_options, SdkName, SdkVersion);
            ParseConnectionString(connectionString, out _baseUri, out _credential, out _secret);
        }

        public async Task<Response<ConfigurationSetting>> AddAsync(ConfigurationSetting setting, CancellationToken cancellation = default)
        {
            if (setting == null) throw new ArgumentNullException(nameof(setting));
            if (string.IsNullOrEmpty(setting.Key)) throw new ArgumentNullException($"{nameof(setting)}.{nameof(setting.Key)}");

            Uri uri = BuildUrlForKvRoute(setting);

            PipelineCallContext context = null;
            try {
                context = Pipeline.CreateContext(_options, cancellation, ServiceMethod.Put, uri);

                context.AddHeader(MediaTypeKeyValueApplicationHeader);
                context.AddHeader(IfNoneMatchWildcard);
                context.AddHeader(Header.Common.JsonContentType);
                context.AddContent(new SettingContent(setting, context, _secret, _credential));

                await Pipeline.ProcessAsync(context).ConfigureAwait(false);

                return await CreateKeyValueResponse(context);
            }
            catch {
                if (context != null) context.Dispose(); // TODO (pri 1) : should we always dispose given the content is eagerly deserialized?
                throw;
            }
        }

        public async Task<Response<ConfigurationSetting>> SetAsync(ConfigurationSetting setting, CancellationToken cancellation = default)
        {
            if (setting == null) throw new ArgumentNullException(nameof(setting));
            if (string.IsNullOrEmpty(setting.Key)) throw new ArgumentNullException($"{nameof(setting)}.{nameof(setting.Key)}");

            Uri url = BuildUrlForKvRoute(setting);

            PipelineCallContext context = null;
            try {
                context = Pipeline.CreateContext(_options, cancellation, ServiceMethod.Put, url);

                context.AddHeader(MediaTypeKeyValueApplicationHeader);
                context.AddHeader(Header.Common.JsonContentType);
                context.AddContent(new SettingContent(setting, context, _secret, _credential));

                await Pipeline.ProcessAsync(context).ConfigureAwait(false);

                return await CreateKeyValueResponse(context);
            }
            catch {
                if (context != null) context.Dispose();
                throw;
            }
        }

        public async Task<Response<ConfigurationSetting>> UpdateAsync(ConfigurationSetting setting, CancellationToken cancellation = default)
        {
            if (setting == null) throw new ArgumentNullException(nameof(setting));
            if (string.IsNullOrEmpty(setting.Key)) throw new ArgumentNullException($"{nameof(setting)}.{nameof(setting.Key)}");
            if (string.IsNullOrEmpty(setting.ETag)) throw new ArgumentNullException($"{nameof(setting)}.{nameof(setting.ETag)}");

            Uri url = BuildUrlForKvRoute(setting);

            PipelineCallContext context = null;
            try {
                context = Pipeline.CreateContext(_options, cancellation, ServiceMethod.Put, url);

                context.AddHeader(MediaTypeKeyValueApplicationHeader);
                context.AddHeader(IfMatchName, $"\"{setting.ETag}\"");
                context.AddHeader(Header.Common.JsonContentType);
                context.AddContent(new SettingContent(setting, context, _secret, _credential));

                await Pipeline.ProcessAsync(context).ConfigureAwait(false);

                return await CreateKeyValueResponse(context);
            }
            catch {
                if (context != null) context.Dispose();
                throw;
            }
        }

        public async Task<Response<ConfigurationSetting>> DeleteAsync(string key, SettingFilter filter = null, CancellationToken cancellation = default)
        {
            if (string.IsNullOrEmpty(key)) throw new ArgumentNullException(nameof(key));

            Uri url = BuildUrlForKvRoute(key, filter);

            PipelineCallContext context = null;
            try {
                context = Pipeline.CreateContext(_options, cancellation, ServiceMethod.Delete, url);

                AddFilterHeaders(filter, context);
                AddAuthenticationHeader(context, ServiceMethod.Delete, default, _secret, _credential);

                await Pipeline.ProcessAsync(context).ConfigureAwait(false);

                return await CreateKeyValueResponse(context);
            }
            catch {
                if (context != null) context.Dispose();
                throw;
            }
        }

        public async Task<Response<ConfigurationSetting>> LockAsync(string key, SettingFilter filter = null, CancellationToken cancellation = default)
        {
            if (string.IsNullOrEmpty(key)) throw new ArgumentNullException(nameof(key));

            Uri url = BuildUriForLocksRoute(key, filter);

            PipelineCallContext context = null;
            try {
                context = Pipeline.CreateContext(_options, cancellation, ServiceMethod.Put, url);

                AddFilterHeaders(filter, context);

                await Pipeline.ProcessAsync(context).ConfigureAwait(false);

                return await CreateKeyValueResponse(context);
            }
            catch {
                if (context != null) context.Dispose();
                throw;
            }
        }

        public async Task<Response<ConfigurationSetting>> UnlockAsync(string key, SettingFilter filter = null, CancellationToken cancellation = default)
        {
            if (string.IsNullOrEmpty(key)) throw new ArgumentNullException(nameof(key));

            Uri url = BuildUriForLocksRoute(key, filter);

            PipelineCallContext context = null;
            try {
                context = Pipeline.CreateContext(_options, cancellation, ServiceMethod.Delete, url);

                AddFilterHeaders(filter, context);

                await Pipeline.ProcessAsync(context).ConfigureAwait(false);

                return await CreateKeyValueResponse(context);
            }
            catch {
                if (context != null) context.Dispose();
                throw;
            }
        }

        public async Task<Response<ConfigurationSetting>> GetAsync(string key, SettingFilter filter = null, CancellationToken cancellation = default)
        {
            if (string.IsNullOrEmpty(key)) throw new ArgumentNullException($"{nameof(key)}");

            Uri url = BuildUrlForKvRoute(key, filter);
            
            PipelineCallContext context = null;
            try {
                context = Pipeline.CreateContext(_options, cancellation, ServiceMethod.Get, url);

                context.AddHeader(MediaTypeKeyValueApplicationHeader);
                AddFilterHeaders(filter, context);
                context.AddHeader(Header.Common.JsonContentType);

                AddAuthenticationHeader(context, ServiceMethod.Get, default, _secret, _credential);

                await Pipeline.ProcessAsync(context).ConfigureAwait(false);

                return await CreateKeyValueResponse(context);
            }
            catch {
                if (context != null) context.Dispose();
                throw;
            }
        }

        public async Task<Response<SettingBatch>> GetBatchAsync(BatchFilter filter, CancellationToken cancellation = default)
        {
            var requestUri = BuildUrlForGetBatch(filter);
            PipelineCallContext context = null;
            try {
                context = Pipeline.CreateContext(_options, cancellation, ServiceMethod.Get, requestUri);

                context.AddHeader(MediaTypeKeyValueApplicationHeader);
                if (filter.Revision != null) {
                    context.AddHeader(AcceptDatetimeHeader, filter.Revision.Value.UtcDateTime.ToString(AcceptDateTimeFormat));
                }

                await Pipeline.ProcessAsync(context).ConfigureAwait(false);

                ServiceResponse response = context.Response;
                if (!response.TryGetHeader(Header.Constants.ContentLength, out long contentLength)) {
                    throw new Exception("bad response: no content length header");
                }

                if (response.Status != 200) {
                    return new Response<SettingBatch>(response);
                }

                var batch = await SettingBatch.ParseAsync(response, cancellation);
                return new Response<SettingBatch>(response, batch);
            }
            catch {
                if (context != null) context.Dispose();
                throw;
            }
        }
    }
}

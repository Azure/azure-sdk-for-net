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
            : this(connectionString, options: new PipelineOptions())
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

            using (PipelineCallContext context = Pipeline.CreateContext(_options, cancellation))
            {
                ReadOnlyMemory<byte> content = Serialize(setting);

                context.SetRequestLine(ServiceMethod.Put, uri);

                context.AddHeader("Host", uri.Host);
                context.AddHeader(IfNoneMatchWildcard);
                context.AddHeader(MediaTypeKeyValueApplicationHeader);
                context.AddHeader(Header.Common.JsonContentType);
                context.AddHeader(Header.Common.CreateContentLength(content.Length));
                AddAuthenticationHeaders(context, uri, ServiceMethod.Put, content, _secret, _credential);

                context.SetContent(PipelineContent.Create(content));

                await Pipeline.ProcessAsync(context).ConfigureAwait(false);

                return await CreateResponse(context);
            }
        }

        public async Task<Response<ConfigurationSetting>> SetAsync(ConfigurationSetting setting, CancellationToken cancellation = default)
        {
            if (setting == null) throw new ArgumentNullException(nameof(setting));
            if (string.IsNullOrEmpty(setting.Key)) throw new ArgumentNullException($"{nameof(setting)}.{nameof(setting.Key)}");

            Uri uri = BuildUrlForKvRoute(setting);

            using (PipelineCallContext context = Pipeline.CreateContext(_options, cancellation))
            {
                ReadOnlyMemory<byte> content = Serialize(setting);

                context.SetRequestLine(ServiceMethod.Put, uri);

                context.AddHeader("Host", uri.Host);
                context.AddHeader(MediaTypeKeyValueApplicationHeader);
                context.AddHeader(Header.Common.JsonContentType);
                context.AddHeader(Header.Common.CreateContentLength(content.Length));
                AddAuthenticationHeaders(context, uri, ServiceMethod.Put, content, _secret, _credential);

                context.SetContent(PipelineContent.Create(content));

                await Pipeline.ProcessAsync(context).ConfigureAwait(false);

                return await CreateResponse(context);
            }
        }

        public async Task<Response<ConfigurationSetting>> UpdateAsync(ConfigurationSetting setting, CancellationToken cancellation = default)
        {
            if (setting == null) throw new ArgumentNullException(nameof(setting));
            if (string.IsNullOrEmpty(setting.Key)) throw new ArgumentNullException($"{nameof(setting)}.{nameof(setting.Key)}");
            if (string.IsNullOrEmpty(setting.ETag)) throw new ArgumentNullException($"{nameof(setting)}.{nameof(setting.ETag)}");

            Uri uri = BuildUrlForKvRoute(setting);

            using (PipelineCallContext context = Pipeline.CreateContext(_options, cancellation))
            {
                ReadOnlyMemory<byte> content = Serialize(setting);

                context.SetRequestLine(ServiceMethod.Put, uri);

                context.AddHeader("Host", uri.Host);
                context.AddHeader(IfMatchName, $"\"{setting.ETag}\"");
                context.AddHeader(MediaTypeKeyValueApplicationHeader);
                context.AddHeader(Header.Common.JsonContentType);
                context.AddHeader(Header.Common.CreateContentLength(content.Length));
                AddAuthenticationHeaders(context, uri, ServiceMethod.Put, content, _secret, _credential);

                context.SetContent(PipelineContent.Create(content));

                await Pipeline.ProcessAsync(context).ConfigureAwait(false);

                return await CreateResponse(context);
            }
        }

        public async Task<Response<ConfigurationSetting>> DeleteAsync(string key, SettingFilter filter = null, CancellationToken cancellation = default)
        {
            if (string.IsNullOrEmpty(key)) throw new ArgumentNullException(nameof(key));

            Uri uri = BuildUrlForKvRoute(key, filter);

            using (PipelineCallContext context = Pipeline.CreateContext(_options, cancellation))
            {
                context.SetRequestLine(ServiceMethod.Delete, uri);

                context.AddHeader("Host", uri.Host);
                AddFilterHeaders(filter, context);
                AddAuthenticationHeaders(context, uri, ServiceMethod.Delete, content: default, _secret, _credential);

                await Pipeline.ProcessAsync(context).ConfigureAwait(false);

                return await CreateResponse(context);
            }
        }

        public async Task<Response<ConfigurationSetting>> LockAsync(string key, SettingFilter filter = null, CancellationToken cancellation = default)
        {
            if (string.IsNullOrEmpty(key)) throw new ArgumentNullException(nameof(key));

            Uri uri = BuildUriForLocksRoute(key, filter);

            using (PipelineCallContext context = Pipeline.CreateContext(_options, cancellation))
            {
                context.SetRequestLine(ServiceMethod.Put, uri);

                context.AddHeader("Host", uri.Host);
                AddFilterHeaders(filter, context);

                await Pipeline.ProcessAsync(context).ConfigureAwait(false);

                return await CreateResponse(context);
            }
        }

        public async Task<Response<ConfigurationSetting>> UnlockAsync(string key, SettingFilter filter = null, CancellationToken cancellation = default)
        {
            if (string.IsNullOrEmpty(key)) throw new ArgumentNullException(nameof(key));

            Uri uri = BuildUriForLocksRoute(key, filter);

            using (PipelineCallContext context = Pipeline.CreateContext(_options, cancellation))
            {
                context.SetRequestLine(ServiceMethod.Delete, uri);

                context.AddHeader("Host", uri.Host);
                AddFilterHeaders(filter, context);

                await Pipeline.ProcessAsync(context).ConfigureAwait(false);

                return await CreateResponse(context);
            }
        }

        public async Task<Response<ConfigurationSetting>> GetAsync(string key, SettingFilter filter = null, CancellationToken cancellation = default)
        {
            if (string.IsNullOrEmpty(key)) throw new ArgumentNullException($"{nameof(key)}");

            Uri uri = BuildUrlForKvRoute(key, filter);

            using (PipelineCallContext context = Pipeline.CreateContext(_options, cancellation))
            {
                context.SetRequestLine(ServiceMethod.Get, uri);

                context.AddHeader("Host", uri.Host);
                context.AddHeader(MediaTypeKeyValueApplicationHeader);
                AddFilterHeaders(filter, context);
                context.AddHeader(Header.Common.JsonContentType);

                AddAuthenticationHeaders(context, uri, ServiceMethod.Get, content: default, _secret, _credential);

                await Pipeline.ProcessAsync(context).ConfigureAwait(false);

                return await CreateResponse(context);
            }
        }

        public async Task<Response<SettingBatch>> GetBatchAsync(BatchFilter filter, CancellationToken cancellation = default)
        {
            var uri = BuildUrlForGetBatch(filter);

            using (PipelineCallContext context = Pipeline.CreateContext(_options, cancellation))
            {
                context.SetRequestLine(ServiceMethod.Get, uri);

                context.AddHeader("Host", uri.Host);
                context.AddHeader(MediaTypeKeyValueApplicationHeader);
                if (filter.Revision != null)
                {
                    context.AddHeader(AcceptDatetimeHeader, filter.Revision.Value.UtcDateTime.ToString(AcceptDateTimeFormat));
                }

                await Pipeline.ProcessAsync(context).ConfigureAwait(false);

                ServiceResponse response = context.Response;
                if (!response.TryGetHeader(Header.Constants.ContentLength, out long contentLength))
                {
                    throw new Exception("bad response: no content length header");
                }

                if (response.Status != 200)
                {
                    return new Response<SettingBatch>(response);
                }

                var batch = await ConfigurationServiceSerializer.ParseBatchAsync(response, cancellation);
                return new Response<SettingBatch>(response, batch);
            }
        }
    }
}
